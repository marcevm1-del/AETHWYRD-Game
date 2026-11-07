// AETHWYRD — monster motion & physics generator.
// Reads  Data/Monsters/species.json, rigs.json, attacks.json, motion_overrides.json, Data/Combat/combat_tuning.json
// Writes Data/Monsters/motion.json: one motion/physics profile per species, ready for Unity (Ascend/Build Monster Prefab).
// Usage: node Tools/monster_gen/motion.js            (deterministic; rerun after any data change)
//        node Tools/monster_gen/motion.js --report   (also prints the rig mapping table)
//
// Every number comes from a small set of laws (see 08_Bestiary/monster_motion_bible.md §2):
//   mass      = shapeK · density · size³
//   gait v    = √(Froude · g · legLength) · fantasyMult · modifiers           (dynamic similarity)
//   playRate  = √(refSize / size)                                             (big things move slower, look heavier)
//   turnRate  = turnDegPerSecAt1m / √size
//   windup    = base(kind) · √scale · rankFactor · menace · element · telegraphColor, never below the fairness floor
const fs = require('fs');
const path = require('path');
const ROOT = path.join(__dirname, '..', '..');
const D = p => path.join(ROOT, 'Data', p);
const readJson = (p, fallback) => fs.existsSync(D(p)) ? JSON.parse(fs.readFileSync(D(p), 'utf8')) : fallback;
const REPORT = process.argv.includes('--report');

const G = 9.81;
const RANKS = ['F', 'E', 'D', 'C', 'B', 'A', 'S', 'SS', 'SSS', 'EX'];
const rankIndex = r => Math.max(0, RANKS.indexOf(String(r).replace(/[+-]$/, '')));
const clamp = (v, a, b) => Math.max(a, Math.min(b, v));
const round = (v, d = 2) => Math.round(v * 10 ** d) / 10 ** d;

// ---------- inputs ----------
const rigsFile = readJson('Monsters/rigs.json', null);
if (!rigsFile) { console.error('Missing Data/Monsters/rigs.json. Run: node Tools/monster_gen/build_rigs.js'); process.exit(1); }
const RIGS = Object.fromEntries(rigsFile.rigs.map(r => [r.key, r]));
const ALIAS = {};
for (const r of rigsFile.rigs) { ALIAS[r.key] = r.key; for (const a of r.aliases) ALIAS[a] = ALIAS[a] || r.key; }
const listOf = (x, k) => Array.isArray(x) ? x : (x && x[k]) || [];
const SPECIES = listOf(readJson('Monsters/species.json', []), 'species');
const ATTACKS = Object.fromEntries(listOf(readJson('Monsters/attacks.json', []), 'attacks').map(a => [a.id, a]));
const OVERRIDES = readJson('Monsters/motion_overrides.json', { species: {} }).species || {};
const TUNING = readJson('Combat/combat_tuning.json', {});
const PARRY = (TUNING.parry && TUNING.parry.parryWindowSec) || 0.12;
const POISE = TUNING.poise || {};
const SHAKE_MAX = (TUNING.camera && TUNING.camera.shakeMax) || 0.6;

// ---------- modifier tables ----------
// Menace (1 Charming … 5 Horror): how it moves, not how strong it is.
const MENACE = {
  1: { label: 'Charming', speed: 0.9, windup: 1.25, squash: 1.5, steppedFps: 0, windupJitter: 0, feintChance: 0, blinkPerMin: 18, posture: 'upright_bouncy', notes: ['Exaggerated squash & stretch', 'Shakes head after being hit', 'Celebrates its own hits (tiny hop)'] },
  2: { label: 'Wild', speed: 1.0, windup: 1.0, squash: 1.0, steppedFps: 0, windupJitter: 0, feintChance: 0, blinkPerMin: 12, posture: 'natural', notes: ['Real-animal timing: alert ear/head turns, sniffing, flinching'] },
  3: { label: 'Menacing', speed: 1.05, windup: 0.95, squash: 0.7, steppedFps: 0, windupJitter: 0.05, feintChance: 0, blinkPerMin: 6, posture: 'head_low_stalking', notes: ['Stalks and circles before committing', 'Holds eye contact (look-at weight 1.0)', 'Hackles/spikes raise on alert'] },
  4: { label: 'Dread', speed: 1.0, windup: 1.0, squash: 0.3, steppedFps: 12, windupJitter: 0.25, feintChance: 0.1, blinkPerMin: 0, posture: 'too_still', notes: ['Animates on 12 fps steps (stop-motion)', 'Head turns 180° before the body', 'Sometimes glides with legs frozen', 'May freeze while the camera looks at it'] },
  5: { label: 'Horror', speed: 1.05, windup: 1.0, squash: 0.2, steppedFps: 8, windupJitter: 0.35, feintChance: 0.25, blinkPerMin: 0, posture: 'broken_symmetry', notes: ['Steps at 8 fps in bursts, then moves perfectly smoothly', 'Feints: starts a telegraph and stops', 'Copies the walk cycle of what it hunts', 'Heard before seen (audio reveal radius)'] },
};
// Element: motion feel + physics tweaks + VFX hooks
const ELEMENT = {
  None: { speed: 1, accel: 1, gravity: 1, mass: 1, windup: 1, springStiff: 1, springGrav: 1, footstepFx: 'dust', idleFx: [], trailFx: null, notes: [] },
  Fire: { speed: 1.05, accel: 1.05, gravity: 1, mass: 1, windup: 1, springStiff: 0.9, springGrav: 0.8, footstepFx: 'scorch_decal', idleFx: ['flame_flicker_noise_on_springs', 'emissive_pulse'], trailFx: 'embers', notes: ['Springs flicker upward like flame'] },
  Water: { speed: 1, accel: 0.95, gravity: 1, mass: 1.05, windup: 1, springStiff: 0.7, springGrav: 1.1, footstepFx: 'splash', idleFx: ['drip_particles', 'surface_wobble'], trailFx: 'droplets', notes: ['Wobbly springs, slides on dodges'] },
  Ice: { speed: 0.92, accel: 0.8, gravity: 1.05, mass: 1.1, windup: 1.05, springStiff: 1.4, springGrav: 1, footstepFx: 'frost_decal', idleFx: ['breath_mist', 'frost_crackle'], trailFx: 'snow_motes', notes: ['Skids when turning (low deceleration)', 'Stiff, crystalline springs'] },
  Lightning: { speed: 1.08, accel: 1.4, gravity: 1, mass: 1, windup: 0.9, springStiff: 1.2, springGrav: 1, footstepFx: 'spark', idleFx: ['arc_between_bones', 'micro_jitter_0.02m'], trailFx: 'arc_sparks', notes: ['Instant starts and stops', 'Twitchy micro-jitter at idle'] },
  Earth: { speed: 0.92, accel: 0.85, gravity: 1.1, mass: 1.3, windup: 1.05, springStiff: 1.2, springGrav: 1.2, footstepFx: 'rock_crack', idleFx: ['floating_pebbles'], trailFx: 'rock_debris', notes: ['Footsteps shake the camera ×1.5', '+0.15 knockback resist'], knockback: 0.15, shake: 1.5 },
  Wind: { speed: 1.08, accel: 1.1, gravity: 0.8, mass: 0.9, windup: 1, springStiff: 0.8, springGrav: 0.5, footstepFx: 'leaf_swirl', idleFx: ['breeze_on_springs'], trailFx: 'wind_ribbons', notes: ['Floaty jumps (+30%)', 'Springs drift sideways'], jump: 1.3 },
  Nature: { speed: 1, accel: 1, gravity: 1, mass: 1, windup: 1, springStiff: 0.9, springGrav: 1, footstepFx: 'grass_bend', idleFx: ['wind_sway', 'pollen'], trailFx: 'pollen_petals', notes: [] },
  Poison: { speed: 0.97, accel: 0.95, gravity: 1, mass: 1, windup: 1, springStiff: 0.8, springGrav: 1.2, footstepFx: 'toxic_drip_decal', idleFx: ['slow_sway', 'bubbling'], trailFx: 'toxic_fog', notes: ['Leaves a drip trail'] },
  Light: { speed: 1, accel: 1, gravity: 0.9, mass: 0.95, windup: 0.95, springStiff: 1, springGrav: 0.8, footstepFx: 'light_ripple', idleFx: ['soft_glow', 'hover_offset_0.05m'], trailFx: 'holy_motes', notes: ['Telegraphs flash brighter (easier to read)'] },
  Dark: { speed: 1.05, accel: 1.2, gravity: 1, mass: 1, windup: 1.1, springStiff: 1, springGrav: 1, footstepFx: 'shadow_puddle', idleFx: ['shadow_wisps', 'light_dims_nearby'], trailFx: 'afterimage', notes: ['Darts between shadows', 'Windup +10% because its flash is dimmer'] },
  Blood: { speed: 1, accel: 1.05, gravity: 1, mass: 1.1, windup: 1, springStiff: 0.9, springGrav: 1.2, footstepFx: 'blood_drip', idleFx: ['vein_pulse'], trailFx: 'blood_mist', notes: [] },
  Void: { speed: 1, accel: 1.3, gravity: 0.7, mass: 1, windup: 1, springStiff: 1, springGrav: 0.5, footstepFx: 'warp_ripple', idleFx: ['space_distortion'], trailFx: 'void_distortion', notes: ['Short blinks (teleport) replace dashes'], blink: true },
};
// Behavior: how it uses the space around the player
const BEHAVIOR = {
  Passive: { speed: 0.95, alert: 8, leash: 20, preferredRange: 6, circle: 0, retreatHp: 0.6, notes: ['Ignores you unless hit', 'Flees at 60% HP'] },
  Territorial: { speed: 1, alert: 12, leash: 15, preferredRange: 2, circle: 0, retreatHp: 0, notes: ['Threat display before the first attack', 'Returns to its spot when you leave the leash radius'] },
  Swarm: { speed: 1.05, alert: 14, leash: 30, preferredRange: 1.2, circle: 2, retreatHp: 0, notes: ['Separation radius ~0.6× body; surrounds you'] },
  Pack: { speed: 1.05, alert: 18, leash: 35, preferredRange: 3.5, circle: 4, retreatHp: 0.25, notes: ['Circles at the preferred range', 'Flanks: members spread 120° apart', 'Calls others with a vocal'] },
  Ambush: { speed: 1.1, alert: 4, leash: 12, preferredRange: 1, circle: 0, retreatHp: 0, notes: ['Dormant disguise pose until the reveal radius', 'First strike always has an audio cue (fairness)'] },
  Aggressive: { speed: 1.1, alert: 20, leash: 50, preferredRange: 1.5, circle: 0, retreatHp: 0, notes: ['Pursues far', 'Rarely backs off'] },
  Skittish: { speed: 1.2, alert: 14, leash: 25, preferredRange: 5, circle: 0, retreatHp: 0.5, notes: ['Bolts when approached', 'Fights only when cornered'] },
  Guardian: { speed: 0.9, alert: 10, leash: 8, preferredRange: 2, circle: 0, retreatHp: 0, notes: ['Never leaves its anchor point', 'Blocks and counters'] },
};
// Attack timing bases (seconds, at refSize, F rank)
const KIND = {
  melee: { windup: 0.45, active: 0.12, recovery: 0.5, lunge: 0.8 },
  heavy: { windup: 0.7, active: 0.15, recovery: 0.75, lunge: 1.2 },
  charge: { windup: 0.8, active: 0.6, recovery: 0.9, lunge: 0 },
  leap: { windup: 0.6, active: 0.3, recovery: 0.7, lunge: 0 },
  ranged: { windup: 0.55, active: 0.1, recovery: 0.45, lunge: 0 },
  projectile: { windup: 0.55, active: 0.1, recovery: 0.45, lunge: 0 },
  breath: { windup: 1.0, active: 1.2, recovery: 0.9, lunge: 0 },
  aoe: { windup: 0.9, active: 0.3, recovery: 0.9, lunge: 0 },
  grab: { windup: 0.6, active: 0.25, recovery: 0.8, lunge: 0.5 },
  magic: { windup: 0.7, active: 0.2, recovery: 0.6, lunge: 0 },
  buff: { windup: 0.5, active: 0.2, recovery: 0.4, lunge: 0 },
  summon: { windup: 0.9, active: 0.3, recovery: 0.6, lunge: 0 },
};
const TELEGRAPH = { blue: 1.0, red: 1.15, gold: 1.1, none: 0.85, '': 0.85 };
// keyword → candidate hitbox bones (first that exists in the rig wins)
const HITBONE = [
  [/bite|chomp|fang|maw|devour|gnaw|nibble|peck|engulf/i, ['jaw', 'maw', 'mouth', 'beak_lower', 'head', 'bulb', 'core']],
  [/claw|slash|swipe|scratch|rake|stab|cleave|swing|slam|smash|punch|club|cut|lunge|frenz/i, ['weapon_R', 'hand_R', 'h_hand_R', 'front_foot_R', 'vine_06_R', 'tentacle1_06', 'limb1_05', 'arm_R', 'core']],
  [/kick|stomp|trample|stamp/i, ['foot_R', 'front_foot_R', 'hind_foot_R', 'leg_R', 'root']],
  [/tail|sweep|whip|lash|sting/i, ['tail_06', 'tail_05', 'tail_04', 'tail_03', 'tail_08', 'spine_14', 'tail_02', 'vine_06_L', 'tentacle1_06', 'trail_04']],
  [/horn|gore|ram|headbutt|charge|butt/i, ['horn_R', 'tusk_R', 'head', 'h_head', 'cap', 'core', 'chest']],
  [/body|tackle|crash|bounce|roll|hop|leap/i, ['core', 'chest', 'body', 'spine_02', 'cephalothorax', 'thorax', 'mantle', 'pelvis']],
  [/wing|gust|buffet/i, ['wing_hand_R', 'wing_radius_R']],
  [/spit|spray|breath|beam|orb|bolt|throw|shot|web|spore|ink|screech|roar/i, ['jaw', 'mouth', 'hand_R', 'spinneret', 'cap', 'head', 'core']],
];
const FOOTSTEP = { gel: 'squelch', flesh: 'soft_pad', bone: 'bone_clack', stone: 'stone_thud', wood: 'wood_knock', chitin: 'chitin_tick', spirit: 'none', swarm: 'none', scaled: 'scale_scrape', feathered: 'bird_hop' };

// ---------- helpers ----------
const warnings = [];
const warn = m => { if (warnings.length < 300) warnings.push(m); };
function resolveRig(sp, ov) {
  if (ov && ov.rigKey) { if (RIGS[ov.rigKey]) return { key: ov.rigKey, via: 'override' }; warn(`${sp.id}: override rigKey "${ov.rigKey}" unknown`); }
  const baseOv = sp.baseSpeciesId && OVERRIDES[sp.baseSpeciesId];  // variants share their base species' body plan
  if (baseOv && baseOv.rigKey && RIGS[baseOv.rigKey]) return { key: baseOv.rigKey, via: 'override (base species)' };
  const raw = String(sp.rigId || '').replace(/^rig_/, '');
  if (ALIAS[raw]) return { key: ALIAS[raw], via: 'rigId' };
  const build = String(sp.build || '').toLowerCase();
  if (ALIAS[build]) return { key: ALIAS[build], via: 'build' };
  for (const part of `${raw}_${build}_${sp.familyKey || ''}_${sp.type || ''}`.toLowerCase().split(/[^a-z]+/)) if (ALIAS[part]) return { key: ALIAS[part], via: 'keyword' };
  warn(`${sp.id}: no rig match for rigId "${sp.rigId}" / build "${sp.build}" → medium_biped`);
  return { key: 'medium_biped', via: 'fallback' };
}
function rigHeightFrac(rig) { return Math.max(...rig.bones.map(b => Math.max(b.head[2], b.tail[2]))); }
function rigWidthFrac(rig) { return Math.max(0.05, ...rig.bones.map(b => Math.max(Math.abs(b.head[0]), Math.abs(b.tail[0])))) * 2; }
function rigLengthFrac(rig) { const ys = rig.bones.flatMap(b => [b.head[1], b.tail[1]]); return Math.max(...ys) - Math.min(...ys); }
function hash(s) { let h = 2166136261; for (const c of String(s)) h = Math.imul(h ^ c.charCodeAt(0), 16777619); return (h >>> 0) / 4294967296; }
function pickBone(rig, attack) {
  const names = new Set(rig.bones.map(b => b.name));
  const text = `${attack.id} ${attack.name || ''}`;
  for (const [re, bones] of HITBONE) if (re.test(text)) { const b = bones.find(x => names.has(x)); if (b) return b; }
  return (rig.hurtboxes[0] && rig.hurtboxes[0].bone) || 'root';
}
function kindOf(attack) {
  const k = String(attack.kind || '').toLowerCase();
  const t = `${attack.id} ${attack.name || ''}`.toLowerCase();
  if (KIND[k] && k !== 'melee') return k;
  // a generic 'melee' (or unknown) kind is refined by the attack's name
  if (/charge|rush|stampede/.test(t)) return 'charge';
  if (/leap|pounce|jump|dive/.test(t)) return 'leap';
  if (/breath/.test(t)) return 'breath';
  if (/grab|engulf|constrict|seize/.test(t)) return 'grab';
  if (/slam|smash|pound|heavy|crush|overhead/.test(t)) return 'heavy';
  if (k === 'melee') return 'melee';
  if (/throw|spit|shot|bolt|orb|web|spray/.test(t)) return 'projectile';
  return KIND[k] ? k : 'melee';
}

// ---------- per-species profile ----------
function profile(sp) {
  const ov = OVERRIDES[sp.id] || null;
  const { key: rigKey, via } = resolveRig(sp, ov);
  const rig = RIGS[rigKey];
  const size = Number(sp.sizeMeters) > 0 ? Number(sp.sizeMeters) : (ov && ov.expectedSize) || rig.refSize;
  if (ov && ov.expectedSize && Math.abs(size - ov.expectedSize) / ov.expectedSize > 0.3) warn(`${sp.id}: sizeMeters ${size} differs from the motion design size ${ov.expectedSize} by >30%`);
  const scale = size / rig.refSize;
  const ri = rankIndex(sp.rank);
  const men = MENACE[clamp(sp.menace || 2, 1, 5)];
  const el = ELEMENT[sp.element] || ELEMENT.None;
  const beh = BEHAVIOR[sp.behavior] || BEHAVIOR.Territorial;
  const P = rig.physics, L = rig.locomotion;
  const bossMult = sp.isUnique ? 1.15 : 1;

  // physics
  const mass = Math.max(0.5, P.shapeK * P.density * size ** 3 * el.mass * ((ov && ov.massMult) || 1));
  const heightM = (rig.sizeAxis === 'height' ? 1 : rigHeightFrac(rig)) * size;
  const lengthM = (rig.sizeAxis === 'length' ? 1 : Math.max(rigLengthFrac(rig), 0.3)) * size;
  const widthM = rigWidthFrac(rig) * size;
  const radius = clamp((P.collider.radiusFrac || 0.2) * size, 0.08, 12);
  const knockResist = clamp((P.knockbackResist || 0) + (el.knockback || 0) + ri * 0.03, 0, 1);
  const poiseBase = POISE[rigKey] != null ? POISE[rigKey] : Math.round(30 * (mass / 30) ** 0.35);
  const poise = Math.round(poiseBase * Math.sqrt(Math.max(scale, 0.2)) * (1 + 0.15 * ri) * bossMult);

  // locomotion
  const playRate = clamp(Math.sqrt(1 / scale), 0.4, 1.6);
  const speedMods = men.speed * el.speed * beh.speed * ((ov && ov.speedMult) || 1);
  const gaits = L.gaits.map(g => {
    const v = Math.sqrt(g.froude * G * g.legFrac * size) * L.fantasyMult * speedMods;
    return { name: g.name, speed: round(clamp(v, 0.15, 60)), froude: g.froude };
  });
  if (ov && ov.gaits) for (const g of ov.gaits) { const i = gaits.findIndex(x => x.name === g.name); if (i >= 0) Object.assign(gaits[i], g); else gaits.push(g); }
  const sorted = [...gaits].sort((a, b) => a.speed - b.speed);
  const walk = sorted[0].speed, run = sorted[sorted.length - 1].speed;
  const turn = clamp(L.turnDegPerSecAt1m / Math.sqrt(Math.max(size, 0.2)), 60, 900);
  const accel = round(L.accelG * G * el.accel, 2);

  // timing fairness floor: every real attack stays readable
  const minTelegraph = round(Math.max(0.25, PARRY + 0.18, 0.45 - ri * 0.03), 2);
  const minRecovery = round(Math.max(0.18, 0.32 - ri * 0.015), 2);
  // absolute size, human (1.7 m) = 1.0: a 14 m dragon winds up ~2× slower than a goblin, regardless of rig
  const sizeTime = clamp(Math.sqrt(size / 1.7), 0.75, 2.2);
  const reachScale = clamp(size / 1.7, 0.5, 6) ** 0.75;
  const rankFactor = Math.max(0.6, 1 - 0.035 * ri);

  const attackOv = (ov && ov.attacks) || {};
  const attacks = (sp.attackIds || []).map((id, i) => {
    const a = ATTACKS[id] || { id, kind: 'melee', telegraph: 'blue', power: 1 };
    if (!ATTACKS[id]) warn(`${sp.id}: attack ${id} not in attacks.json`);
    const k = kindOf(a), base = KIND[k];
    const powerF = clamp(0.85 + 0.15 * (a.power || 1), 0.85, 1.4);
    let windup = base.windup * sizeTime * rankFactor * men.windup * el.windup * (TELEGRAPH[a.telegraph || 'blue'] || 1) * powerF;
    windup = Math.max(windup, minTelegraph);
    const active = Math.max(0.05, base.active * sizeTime);
    const recovery = Math.max(base.recovery * sizeTime * rankFactor, minRecovery);
    const o = attackOv[id] || {};
    const r = {
      attackId: id, slot: `attack_${String(i + 1).padStart(2, '0')}`, kind: k, telegraph: a.telegraph || 'blue',
      windupSec: round(o.windupSec ?? windup), activeSec: round(o.activeSec ?? active), recoverySec: round(o.recoverySec ?? recovery),
      windupJitter: men.windupJitter, feintChance: men.feintChance,
      hitboxBone: o.hitboxBone || pickBone(rig, a), hitboxRadius: round(o.hitboxRadius ?? clamp(size * 0.18, 0.15, 6)),
      lungeDistance: round(o.lungeDistance ?? (k === 'charge' ? run * active : k === 'leap' ? clamp(size * 2, 1, 15) : base.lunge * reachScale)),
      trackingWindupDegPerSec: round(turn * 0.6, 0), trackingActiveDegPerSec: round(turn * 0.1, 0),
      animFrames: { windup: Math.round(windup * 30 / playRate), active: Math.round(active * 30 / playRate), recovery: Math.round(recovery * 30 / playRate) },
      notes: o.notes || '',
    };
    return r;
  });
  for (const id of Object.keys(attackOv)) if (!(sp.attackIds || []).includes(id)) warn(`${sp.id}: override for attack ${id} that the species doesn't have`);

  // springs (scaled by element & menace)
  const springs = rig.springChains.map(c => ({ root: c.root, length: c.length, stiffness: round(c.stiffness * el.springStiff * (men.squash > 1 ? 0.85 : 1), 3), damping: c.damping, gravity: round(c.gravity * el.springGrav, 3) }));

  const parts = rig.breakableParts.map(p => ({ partId: p.partId, bone: p.bone, hp: Math.round(((sp.stats && sp.stats.hp) || 100) * p.hpPct), materialTag: p.materialTag, onBreak: p.onBreak }));

  const out = {
    speciesId: sp.id, name: sp.name, rigKey, rigVia: via, unityAvatar: rig.unityAvatar, animSetId: sp.animSetId || `anim_${rigKey}`,
    sizeMeters: round(size), prefabScale: round(scale, 3), heightM: round(heightM), lengthM: round(lengthM), widthM: round(widthM),
    physics: {
      massKg: round(mass, 1), gravityScale: round(P.gravityScale * el.gravity, 2), linearDrag: P.linearDrag, buoyancy: P.buoyancy || 0,
      colliderType: P.collider.type, colliderRadius: round(radius), colliderHeight: round(rig.sizeAxis === 'height' ? heightM : (P.collider.heightFrac || 0.9) * lengthM), colliderAxis: P.collider.axis || 'z',
      knockbackResist: round(knockResist), launchable: String(P.launchable), ragdoll: P.ragdoll, deathStyle: P.deathStyle,
      poise, hitstopMult: round(clamp(1 + Math.log10(Math.max(mass, 1) / 50) * 0.12, 0.85, 1.4)),
      footstepShake: round(clamp((mass - 400) / 20000, 0, 1) * SHAKE_MAX * (el.shake || 1), 3),
    },
    navAgent: { radius: round(clamp(Math.max(radius, widthM / 2), 0.1, 15)), height: round(clamp(heightM, 0.2, 40)), speed: run, walkSpeed: walk, angularSpeed: round(turn, 0), acceleration: accel, stoppingDistance: round(clamp(radius + 0.4, 0.5, 20)), baseOffset: rig.locomotion.hovers ? round((rig.locomotion.hoverHeightFrac || 0.2) * size) : 0, areaMask: L.canFly ? 'Fly' : L.waterOnly ? 'Water' : 'Walkable' },
    locomotion: { gaits, playRate: round(playRate, 3), turnDegPerSec: round(turn, 0), accel, jumpHeight: round(L.jumpHeightFrac * size * (el.jump || 1)), canClimb: String(L.canClimb), canSwim: String(L.canSwim), canFly: String(L.canFly), hovers: String(L.hovers), flySpeed: L.canFly ? round(run * (L.flySpeedMult || 2)) : 0, blink: !!el.blink },
    menace: { level: sp.menace || 2, label: men.label, steppedAnimFps: men.steppedFps, posture: men.posture, blinkPerMin: men.blinkPerMin, squashStretch: men.squash, freezeWhenObserved: (sp.menace || 0) >= 4 && hash(sp.id) < 0.35, audioRevealRadius: (sp.menace || 0) >= 5 ? round(clamp(size * 8, 8, 40)) : 0, notes: men.notes },
    element: { name: sp.element || 'None', footstepFx: el.footstepFx, idleFx: el.idleFx, trailFx: el.trailFx, notes: el.notes },
    behavior: { name: sp.behavior || 'Territorial', aiPattern: sp.aiPattern || '', alertRadius: round(beh.alert * Math.sqrt(Math.max(scale, 0.3))), leashRadius: round(beh.leash * Math.sqrt(Math.max(scale, 0.3))), preferredRange: round(beh.preferredRange * Math.max(1, Math.sqrt(scale)) + radius), circleRadius: round(beh.circle * Math.sqrt(Math.max(scale, 0.3))), retreatHpPct: beh.retreatHp, notes: beh.notes },
    timing: { minTelegraphSec: minTelegraph, minRecoverySec: minRecovery, sizeTimeMult: round(sizeTime, 3), rankFactor: round(rankFactor, 3) },
    attacks, springs, parts,
    hurtboxes: rig.hurtboxes.map(h => Object.assign({}, h, { radius: h.radius != null ? round(h.radius * size, 3) : undefined, height: h.height != null ? round(h.height * size, 3) : undefined, size: h.size ? h.size.map(v => round(v * size, 3)) : undefined })),
    procedural: [...rig.procedural, ...el.idleFx.map(x => `fx:${x}`), ...((ov && ov.procedural) || [])],
    audio: { footstep: (ov && ov.footstep) || FOOTSTEP[rig.material] || 'soft_pad', vocalPitch: round(clamp((1 / Math.max(size, 0.05)) ** 0.3, 0.45, 2.2)) },
    signature: ov ? { summary: ov.summary || '', idle: ov.idle || [], movement: ov.movement || [], combat: ov.combat || [], hitReact: ov.hitReact || [], death: ov.death || '', blender: ov.blender || [], unity: ov.unity || [] } : null,
  };
  return out;
}

const profiles = SPECIES.map(profile);
const byRig = {};
profiles.forEach(p => { byRig[p.rigKey] = (byRig[p.rigKey] || 0) + 1; });
for (const id of Object.keys(OVERRIDES)) if (!SPECIES.some(s => s.id === id)) warn(`motion_overrides: species ${id} not found in species.json`);
fs.writeFileSync(D('Monsters/motion.json'), JSON.stringify({ version: 1, generatedBy: 'Tools/monster_gen/motion.js', fps: 30, count: profiles.length, species: profiles }, null, 1) + '\n');
console.log(`motion.json: ${profiles.length} species · rigs used: ` + Object.entries(byRig).sort((a, b) => b[1] - a[1]).map(([k, n]) => `${k} ${n}`).join(', '));
const fallbacks = profiles.filter(p => p.rigVia === 'fallback' || p.rigVia === 'keyword');
if (fallbacks.length) console.log(`${fallbacks.length} species matched a rig by keyword/fallback (check them, or add an alias in build_rigs.js): ` + fallbacks.slice(0, 15).map(p => `${p.speciesId}→${p.rigKey}`).join(', ') + (fallbacks.length > 15 ? ' …' : ''));
if (REPORT) { const m = {}; SPECIES.forEach((s, i) => { const k = `${s.rigId} → ${profiles[i].rigKey} (${profiles[i].rigVia})`; m[k] = (m[k] || 0) + 1; }); console.log(Object.entries(m).sort().map(([k, n]) => `  ${k}: ${n}`).join('\n')); }
if (warnings.length) { console.log(`${warnings.length} warning(s):`); warnings.slice(0, 40).forEach(w => console.log('  - ' + w)); }
