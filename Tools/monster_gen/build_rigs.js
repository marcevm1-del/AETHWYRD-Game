// AETHWYRD — rig library builder.
// Writes Data/Monsters/rigs.json: 25 shared monster rigs with skeletons, IK and spring chains,
// hurtboxes, breakable parts, locomotion, physics and animation sets.
// Usage: node Tools/monster_gen/build_rigs.js     (edit the definitions here, then rerun)
//
// COORDINATES: Blender convention. Z is up, the creature FACES -Y, +X is its LEFT side.
// Units are normalized: the rig's reference dimension (height or length, see sizeAxis) = 1.0.
// Blender (Tools/blender/build_rig.py) multiplies by the species' sizeMeters.
// Bone names: lowercase snake_case, sides as _L / _R (Blender mirrors these automatically).
const fs = require('fs');
const path = require('path');
const OUT = path.join(__dirname, '..', '..', 'Data', 'Monsters', 'rigs.json');

// ---------- helpers ----------
const r3 = v => v.map(n => Math.round(n * 1000) / 1000);
function B(name, parent, head, tail, extra = {}) { return Object.assign({ name, parent, head: r3(head), tail: r3(tail), deform: true }, extra); }
const mirror = p => [-p[0], p[1], p[2]];
// A chain of n bones from a to b (straight line), names prefix_01..n
function chain(prefix, parent, a, b, n, extra = {}) {
  const out = [];
  let par = parent;
  for (let i = 0; i < n; i++) {
    const t0 = i / n, t1 = (i + 1) / n;
    const h = a.map((v, k) => v + (b[k] - v) * t0), t = a.map((v, k) => v + (b[k] - v) * t1);
    const nm = `${prefix}_${String(i + 1).padStart(2, '0')}`;
    out.push(B(nm, par, h, t, extra)); par = nm;
  }
  return out;
}
// Add left side (as given, +X) and mirrored right side for bones whose name ends with _L
function sides(bones) {
  const out = [];
  for (const b0 of bones) {
    const b = Object.assign({}, b0, { name: b0.name.replace(/_L_(\d+)$/, '_$1_L'), parent: b0.parent && b0.parent.replace(/_L_(\d+)$/, '_$1_L') });
    out.push(b);
    if (b.name.endsWith('_L')) {
      out.push(Object.assign({}, b, { name: b.name.replace(/_L$/, '_R'), parent: b.parent && b.parent.endsWith('_L') ? b.parent.replace(/_L$/, '_R') : b.parent, head: r3(mirror(b.head)), tail: r3(mirror(b.tail)) }));
    }
  }
  return out;
}
const S = (name, side) => side ? `${name}_${side}` : name;

// ---------- archetype skeleton builders ----------
// Humanoid biped (Unity Humanoid-compatible bone set). p = proportions at height 1.0
function humanoid(p) {
  const b = [
    B('root', null, [0, 0, 0], [0, -0.15, 0], { deform: false }),
    B('pelvis', 'root', [0, 0, p.pelvis], [0, 0, p.pelvis + 0.05]),
    B('spine_01', 'pelvis', [0, 0, p.pelvis + 0.05], [0, 0, p.pelvis + (p.chest - p.pelvis) * 0.45]),
    B('spine_02', 'spine_01', [0, 0, p.pelvis + (p.chest - p.pelvis) * 0.45], [0, 0, p.chest]),
    B('chest', 'spine_02', [0, 0, p.chest], [0, 0, p.neck]),
    B('neck', 'chest', [0, 0, p.neck], [0, -0.01, p.neck + 0.04]),
    B('head', 'neck', [0, -0.01, p.neck + 0.04], [0, -0.01, 1.0]),
    B('jaw', 'head', [0, -0.03, p.neck + 0.07], [0, -0.09, p.neck + 0.05]),
    B('eye_L', 'head', [0.03, -0.07, p.eyeZ], [0.03, -0.1, p.eyeZ], { deform: false }),
    B('clavicle_L', 'chest', [0.02, 0, p.shoulderZ], [p.shoulderX, 0.01, p.shoulderZ]),
    B('upperarm_L', 'clavicle_L', [p.shoulderX, 0.01, p.shoulderZ], [p.shoulderX + 0.02, 0.02, p.elbowZ]),
    B('forearm_L', 'upperarm_L', [p.shoulderX + 0.02, 0.02, p.elbowZ], [p.shoulderX + 0.03, -0.01, p.wristZ]),
    B('hand_L', 'forearm_L', [p.shoulderX + 0.03, -0.01, p.wristZ], [p.shoulderX + 0.03, -0.02, p.wristZ - p.hand]),
    B('thumb_01_L', 'hand_L', [p.shoulderX + 0.02, -0.03, p.wristZ - 0.01], [p.shoulderX + 0.01, -0.05, p.wristZ - p.hand * 0.6]),
    B('fingers_01_L', 'hand_L', [p.shoulderX + 0.03, -0.02, p.wristZ - p.hand], [p.shoulderX + 0.03, -0.03, p.wristZ - p.hand * 1.6]),
    B('weapon_L', 'hand_L', [p.shoulderX + 0.03, -0.03, p.wristZ - p.hand * 0.7], [p.shoulderX + 0.03, -0.15, p.wristZ - p.hand * 0.7], { deform: false }),
    B('thigh_L', 'pelvis', [p.hipX, 0, p.pelvis - 0.02], [p.hipX + 0.005, -0.01, p.knee]),
    B('calf_L', 'thigh_L', [p.hipX + 0.005, -0.01, p.knee], [p.hipX + 0.005, 0.01, p.ankle]),
    B('foot_L', 'calf_L', [p.hipX + 0.005, 0.01, p.ankle], [p.hipX + 0.005, -p.foot * 0.7, 0.012]),
    B('toe_L', 'foot_L', [p.hipX + 0.005, -p.foot * 0.7, 0.012], [p.hipX + 0.005, -p.foot, 0.01]),
  ];
  return sides(b);
}
// Quadruped, length-normalized (nose → tail base = 1.0). Faces -Y.
function quad(p) {
  const fy = -0.22, hy = 0.3, sh = p.shoulderH, hh = p.hipH ?? p.shoulderH;
  const b = [
    B('root', null, [0, 0, 0], [0, -0.15, 0], { deform: false }),
    B('pelvis', 'root', [0, hy, hh], [0, hy - 0.08, hh]),
    B('spine_01', 'pelvis', [0, hy - 0.08, hh], [0, 0.08, (hh + sh) / 2 + p.arch]),
    B('spine_02', 'spine_01', [0, 0.08, (hh + sh) / 2 + p.arch], [0, -0.1, sh]),
    B('chest', 'spine_02', [0, -0.1, sh], [0, fy, sh + 0.02]),
    ...chain('neck', 'chest', [0, fy, sh + 0.02], [0, -0.36, sh + p.neckRise], p.neckBones || 2),
    B('head', `neck_${String(p.neckBones || 2).padStart(2, '0')}`, [0, -0.36, sh + p.neckRise], [0, -0.5, sh + p.neckRise - 0.02]),
    B('jaw', 'head', [0, -0.39, sh + p.neckRise - 0.04], [0, -0.49, sh + p.neckRise - 0.07]),
    B('eye_L', 'head', [0.035, -0.44, sh + p.neckRise + 0.01], [0.035, -0.48, sh + p.neckRise + 0.01], { deform: false }),
    // front legs (digitigrade)
    B('scapula_L', 'chest', [0.03, fy + 0.04, sh], [0.06, fy, sh * 0.72]),
    B('upperarm_L', 'scapula_L', [0.06, fy, sh * 0.72], [0.06, fy + 0.03, sh * 0.42]),
    B('forearm_L', 'upperarm_L', [0.06, fy + 0.03, sh * 0.42], [0.06, fy + 0.01, sh * 0.1]),
    B('front_foot_L', 'forearm_L', [0.06, fy + 0.01, sh * 0.1], [0.06, fy - 0.03, 0.02]),
    B('front_toe_L', 'front_foot_L', [0.06, fy - 0.03, 0.02], [0.06, fy - 0.06, 0.005]),
    // hind legs
    B('thigh_L', 'pelvis', [0.06, hy, hh], [0.07, hy - 0.08, hh * 0.55]),
    B('calf_L', 'thigh_L', [0.07, hy - 0.08, hh * 0.55], [0.07, hy + 0.04, hh * 0.22]),
    B('hind_foot_L', 'calf_L', [0.07, hy + 0.04, hh * 0.22], [0.07, hy - 0.02, 0.02]),
    B('hind_toe_L', 'hind_foot_L', [0.07, hy - 0.02, 0.02], [0.07, hy - 0.06, 0.005]),
    ...chain('tail', 'pelvis', [0, hy + 0.02, hh], [0, hy + 0.02 + p.tail, hh - p.tail * 0.4], p.tailBones),
  ];
  if (p.ears) b.push(...chain('ear_L', 'head', [0.03, -0.4, sh + p.neckRise + 0.03], [0.05, -0.38, sh + p.neckRise + 0.03 + p.ears], 2));
  return sides(b.map(x => (x.name.startsWith('ear_L_') ? Object.assign(x, { name: x.name.replace(/^ear_L_(\d+)$/, 'ear_$1_L'), parent: x.parent.replace(/^ear_L_(\d+)$/, 'ear_$1_L') }) : x)));
}
// Generic leg pair for many-legged rigs
function legPair(prefix, parent, attach, dir, segs, lens) {
  // attach: [x,y,z] on the left side; dir: outward/forward angle; segs: names; lens: lengths
  const out = []; let p = attach, par = parent;
  const dirs = [[0.9, dir, 0.45], [0.6, dir * 0.6, -0.35], [0.25, dir * 0.3, -0.95], [0.1, 0, -1]];
  segs.forEach((s, i) => {
    const d = dirs[Math.min(i, dirs.length - 1)], L = lens[i];
    const n = Math.hypot(...d); const t = [p[0] + d[0] / n * L, p[1] + d[1] / n * L, Math.max(0.005, p[2] + d[2] / n * L)];
    const nm = `${prefix}_${s}_L`; out.push(B(nm, par, p, t)); par = nm; p = t;
  });
  return out;
}
function wing(prefix, parent, shoulder, span, membrane) {
  const s = shoulder;
  const b = [
    B(`${prefix}_humerus_L`, parent, s, [s[0] + span * 0.22, s[1] + 0.02, s[2] + 0.03]),
    B(`${prefix}_radius_L`, `${prefix}_humerus_L`, [s[0] + span * 0.22, s[1] + 0.02, s[2] + 0.03], [s[0] + span * 0.5, s[1] - 0.02, s[2] + 0.06]),
    B(`${prefix}_hand_L`, `${prefix}_radius_L`, [s[0] + span * 0.5, s[1] - 0.02, s[2] + 0.06], [s[0] + span * 0.58, s[1] - 0.03, s[2] + 0.06]),
  ];
  if (membrane) {
    [[0.95, 0.05, 0.02], [0.85, 0.22, -0.02], [0.65, 0.35, -0.06]].forEach(([x, y, z], i) =>
      b.push(...chain(`${prefix}_finger${i + 1}_L`, `${prefix}_hand_L`, [s[0] + span * 0.58, s[1] - 0.03, s[2] + 0.06], [s[0] + span * x, s[1] + span * y, s[2] + z], 2)));
  } else {
    b.push(...chain(`${prefix}_primaries_L`, `${prefix}_hand_L`, [s[0] + span * 0.58, s[1] - 0.03, s[2] + 0.06], [s[0] + span, s[1] + 0.12, s[2] + 0.02], 3, { spring: true }));
    b.push(...chain(`${prefix}_secondaries_L`, `${prefix}_radius_L`, [s[0] + span * 0.35, s[1], s[2] + 0.04], [s[0] + span * 0.4, s[1] + 0.18, s[2]], 2, { spring: true }));
  }
  return b.map(x => Object.assign(x, { name: x.name.replace(/_L_(\d+)$/, '_$1_L'), parent: x.parent && x.parent.replace(/_L_(\d+)$/, '_$1_L') }));
}
const fix = list => list.map(x => Object.assign(x, { name: x.name.replace(/_L_(\d+)$/, '_$1_L'), parent: x.parent && x.parent.replace(/_L_(\d+)$/, '_$1_L') }));

// ---------- shared animation sets ----------
// Frames at 30 fps, authored for a creature at the rig's refSize. Playback rate scales per species (see motion.js).
// events: footstep_L/R · hit_on/hit_off (hitbox active) · telegraph (flash VFX) · vocal · vfx · cancel (AI may cancel) · land
const C = (name, frames, loop, rootMotion, events = []) => ({ name, frames, loop, rootMotion, events });
const CORE = [
  C('idle', 90, true, false), C('idle_alert', 60, true, false), C('idle_fidget_01', 120, false, false),
  C('turn_90_L', 20, false, true), C('turn_90_R', 20, false, true), C('turn_180', 30, false, true),
  C('hit_light_front', 12, false, false), C('hit_light_back', 12, false, false),
  C('hit_heavy', 22, false, true), C('stagger', 40, false, true), C('break_down_loop', 60, true, false), C('break_recover', 30, false, false),
  C('knockdown', 28, false, true), C('getup', 36, false, false),
  C('death', 45, false, true, [{ f: 30, e: 'ragdoll' }]),
  C('spawn', 40, false, false, [{ f: 0, e: 'vfx' }]), C('taunt', 45, false, false, [{ f: 10, e: 'vocal' }]),
  C('flee_start', 15, false, true), C('sleep_loop', 120, true, false), C('eat_loop', 90, true, false),
  C('frozen_pose', 1, true, false), C('stun_loop', 40, true, false),
];
const WALKERS = [C('walk', 32, true, true, [{ f: 0, e: 'footstep_L' }, { f: 16, e: 'footstep_R' }]), C('run', 20, true, true, [{ f: 0, e: 'footstep_L' }, { f: 10, e: 'footstep_R' }]), C('walk_back', 32, true, true), C('strafe_L', 28, true, true), C('strafe_R', 28, true, true)];
const QUAD_GAITS = [C('walk', 36, true, true, [{ f: 0, e: 'footstep_L' }, { f: 9, e: 'footstep_R' }, { f: 18, e: 'footstep_R' }, { f: 27, e: 'footstep_L' }]), C('trot', 24, true, true), C('gallop', 16, true, true, [{ f: 3, e: 'footstep_L' }, { f: 11, e: 'footstep_R' }]), C('circle_L', 30, true, true), C('circle_R', 30, true, true)];
const AIRBORNE = [C('launch_air', 14, false, false), C('air_hit', 10, false, false), C('fall_loop', 20, true, false), C('slam_bounce', 18, false, false, [{ f: 2, e: 'land' }]), C('land', 14, false, false, [{ f: 1, e: 'land' }])];
const FLY = [C('fly_hover', 30, true, false), C('fly_forward', 24, true, true), C('fly_glide', 40, true, true), C('takeoff', 30, false, true), C('fly_land', 30, false, true), C('dive', 20, false, true)];
const ATTACK_SLOTS = n => Array.from({ length: n }, (_, i) => C(`attack_${String(i + 1).padStart(2, '0')}`, 40, false, true, [{ f: 4, e: 'telegraph' }, { f: 18, e: 'hit_on' }, { f: 22, e: 'hit_off' }, { f: 30, e: 'cancel' }]));
const anims = (...groups) => groups.flat();

// ---------- physics presets ----------
// shapeK: fraction of (refDim³) that is body volume. density kg/m³. mass = shapeK·density·size³ (computed per species).
const PHYS = {
  flesh: { density: 1000 }, gel: { density: 1050 }, bone: { density: 650 }, stone: { density: 2400 }, wood: { density: 700 },
  chitin: { density: 1100 }, spirit: { density: 1 }, swarm: { density: 1 }, scaled: { density: 1150 }, feathered: { density: 350 },
};

// ---------- the 25 rigs ----------
const RIGS = [];
const R = o => RIGS.push(Object.assign({ aliases: [], ikChains: [], springChains: [], hurtboxes: [], breakableParts: [], blendShapes: [], procedural: [] }, o));

// 1 BLOB
R({ key: 'blob', aliases: ['slime', 'ooze', 'jelly_blob'], description: 'Slimes and oozes: a gel dome with jiggle lobes. Moves by hopping; squash & stretch is the whole performance.',
  sizeAxis: 'height', refSize: 0.5, unityAvatar: 'Generic', boneBudget: 12, material: 'gel',
  bones: fix([B('root', null, [0, 0, 0], [0, -0.15, 0], { deform: false }), B('core', 'root', [0, 0, 0.05], [0, 0, 0.45]), B('crown', 'core', [0, 0, 0.45], [0, 0, 0.95]),
    B('lobe_front', 'core', [0, -0.1, 0.25], [0, -0.45, 0.2], { spring: true }), B('lobe_back', 'core', [0, 0.1, 0.25], [0, 0.45, 0.2], { spring: true }),
    B('lobe_L', 'core', [0.1, 0, 0.25], [0.45, 0, 0.2], { spring: true }), B('lobe_R', 'core', [-0.1, 0, 0.25], [-0.45, 0, 0.2], { spring: true }),
    B('eye_L', 'crown', [0.12, -0.38, 0.6], [0.12, -0.45, 0.6], { deform: false }), B('eye_R', 'crown', [-0.12, -0.38, 0.6], [-0.12, -0.45, 0.6], { deform: false }),
    B('mouth', 'core', [0, -0.42, 0.42], [0, -0.48, 0.4]), B('inner_item', 'core', [0, 0, 0.3], [0, 0, 0.4], { deform: false })]),
  springChains: [{ root: 'lobe_front', length: 1, stiffness: 0.35, damping: 0.18, gravity: 0.2 }, { root: 'lobe_back', length: 1, stiffness: 0.35, damping: 0.18, gravity: 0.2 }, { root: 'lobe_L', length: 1, stiffness: 0.35, damping: 0.18, gravity: 0.2 }, { root: 'lobe_R', length: 1, stiffness: 0.35, damping: 0.18, gravity: 0.2 }, { root: 'crown', length: 1, stiffness: 0.5, damping: 0.25, gravity: 0.1 }],
  hurtboxes: [{ bone: 'core', shape: 'sphere', radius: 0.42, center: [0, 0, 0.1], dmgMult: 1 }, { bone: 'inner_item', shape: 'sphere', radius: 0.08, dmgMult: 2.0, partId: 'core_nucleus' }],
  breakableParts: [{ partId: 'core_nucleus', bone: 'inner_item', hpPct: 0.25, materialTag: 'gel_core', onBreak: 'stagger_long' }],
  blendShapes: ['squash', 'stretch', 'puff', 'blink_L', 'blink_R', 'smile', 'frown', 'split_pinch'],
  procedural: ['squash_stretch_from_velocity', 'jiggle_on_hit', 'look_at_target', 'inner_item_wobble', 'surface_tension_wobble_idle'],
  locomotion: { gaits: [{ name: 'hop', froude: 2.2, legFrac: 0.5 }, { name: 'hop_fast', froude: 6, legFrac: 0.5 }, { name: 'ooze_crawl', froude: 0.08, legFrac: 0.5 }], fantasyMult: 1.0, turnDegPerSecAt1m: 360, accelG: 0.6, jumpHeightFrac: 1.6, canClimb: 'walls_slow', canSwim: true, canFly: false, hovers: false },
  physics: { shapeK: 0.5, ...PHYS.gel, collider: { type: 'sphere', radiusFrac: 0.45, centerZFrac: 0.42 }, gravityScale: 1.6, linearDrag: 0.4, knockbackResist: 0.1, launchable: true, ragdoll: 'none', deathStyle: 'splat_dissolve' },
  anims: anims(CORE, [C('hop', 24, true, true, [{ f: 6, e: 'land' }]), C('hop_fast', 16, true, true, [{ f: 4, e: 'land' }]), C('ooze_crawl', 40, true, true), C('split', 40, false, false, [{ f: 25, e: 'vfx' }])], AIRBORNE, ATTACK_SLOTS(4)),
});

// 2 STUB BIPED
R({ key: 'stub_biped', aliases: ['mushroom', 'mandrake', 'sprout', 'stub', 'walking_plant'], description: 'Tiny two-legged critters with no real arms: walking mushrooms, mandrakes, sprouts. Waddle gait, huge head/cap.',
  sizeAxis: 'height', refSize: 0.5, unityAvatar: 'Generic', boneBudget: 18, material: 'wood',
  bones: fix(sides([B('root', null, [0, 0, 0], [0, -0.15, 0], { deform: false }), B('body', 'root', [0, 0, 0.3], [0, 0, 0.55]), B('cap', 'body', [0, 0, 0.55], [0, 0, 1.0]),
    B('cap_rim_front', 'cap', [0, -0.05, 0.62], [0, -0.42, 0.58], { spring: true }), B('cap_rim_L', 'cap', [0.05, 0, 0.62], [0.42, 0, 0.58], { spring: true }), B('cap_rim_back', 'cap', [0, 0.05, 0.62], [0, 0.42, 0.58], { spring: true }),
    B('face', 'body', [0, -0.2, 0.45], [0, -0.28, 0.45]), B('mouth', 'face', [0, -0.22, 0.38], [0, -0.3, 0.36]), B('eye_L', 'face', [0.07, -0.24, 0.5], [0.07, -0.3, 0.5], { deform: false }),
    B('arm_L', 'body', [0.15, 0, 0.42], [0.3, -0.02, 0.3]), B('hand_L', 'arm_L', [0.3, -0.02, 0.3], [0.34, -0.04, 0.25]),
    B('leg_L', 'body', [0.08, 0, 0.3], [0.09, -0.01, 0.06]), B('foot_L', 'leg_L', [0.09, -0.01, 0.06], [0.09, -0.12, 0.01]), B('root_tail', 'body', [0, 0.1, 0.3], [0, 0.3, 0.05], { spring: true })])),
  ikChains: [{ name: 'leg_L', tip: 'foot_L', chainLength: 1 }, { name: 'leg_R', tip: 'foot_R', chainLength: 1 }],
  springChains: [{ root: 'cap_rim_front', length: 1, stiffness: 0.5, damping: 0.2, gravity: 0.1 }, { root: 'cap_rim_L', length: 1, stiffness: 0.5, damping: 0.2, gravity: 0.1 }, { root: 'cap_rim_R', length: 1, stiffness: 0.5, damping: 0.2, gravity: 0.1 }, { root: 'cap_rim_back', length: 1, stiffness: 0.5, damping: 0.2, gravity: 0.1 }, { root: 'root_tail', length: 1, stiffness: 0.3, damping: 0.2, gravity: 0.5 }],
  hurtboxes: [{ bone: 'cap', shape: 'sphere', radius: 0.32, dmgMult: 0.8, partId: 'cap' }, { bone: 'body', shape: 'capsule', radius: 0.17, height: 0.4, dmgMult: 1.2 }],
  breakableParts: [{ partId: 'cap', bone: 'cap', hpPct: 0.3, materialTag: 'spore_cap', onBreak: 'stop_spore_attacks' }],
  blendShapes: ['blink_L', 'blink_R', 'mouth_open', 'scream', 'cap_puff'],
  procedural: ['waddle_side_sway', 'cap_bob', 'look_at_target', 'foot_ik_ground'],
  locomotion: { gaits: [{ name: 'waddle', froude: 0.35, legFrac: 0.25 }, { name: 'scurry', froude: 2.2, legFrac: 0.25 }], fantasyMult: 1.2, turnDegPerSecAt1m: 300, accelG: 0.8, jumpHeightFrac: 0.6, canClimb: false, canSwim: false, canFly: false, hovers: false },
  physics: { shapeK: 0.25, ...PHYS.wood, collider: { type: 'capsule', radiusFrac: 0.3, heightFrac: 1.0 }, gravityScale: 1.5, linearDrag: 0.2, knockbackResist: 0.05, launchable: true, ragdoll: 'partial', deathStyle: 'topple_puff' },
  anims: anims(CORE, WALKERS, AIRBORNE, [C('burrow', 40, false, false), C('emerge', 30, false, false), C('spore_puff', 30, false, false, [{ f: 12, e: 'vfx' }])], ATTACK_SLOTS(3)),
});

// 3 SMALL BIPED (goblins, kobolds, imps) — big head, short legs, long arms
const SMALL = { pelvis: 0.42, chest: 0.6, neck: 0.66, eyeZ: 0.83, shoulderZ: 0.64, shoulderX: 0.12, elbowZ: 0.47, wristZ: 0.31, hand: 0.07, hipX: 0.06, knee: 0.22, ankle: 0.04, foot: 0.12 };
R({ key: 'small_biped', aliases: ['goblin', 'kobold', 'imp', 'gremlin', 'small_humanoid'], description: 'Goblins, kobolds, imps: 0.8–1.3 m. Oversized head and hands, short bowed legs, hunched spine. Humanoid-retargetable (Mixamo works with tweaks).',
  sizeAxis: 'height', refSize: 1.1, unityAvatar: 'Humanoid', boneBudget: 40, material: 'flesh',
  bones: fix([...humanoid(SMALL), ...sides([...chain('ear_L', 'head', [0.07, -0.02, 0.86], [0.2, 0.03, 0.92], 2, { spring: true })])].map(x => x)),
  ikChains: [{ name: 'leg_L', tip: 'foot_L', chainLength: 2, pole: 'knee_forward' }, { name: 'leg_R', tip: 'foot_R', chainLength: 2, pole: 'knee_forward' }, { name: 'arm_L', tip: 'hand_L', chainLength: 2, pole: 'elbow_back' }, { name: 'arm_R', tip: 'hand_R', chainLength: 2, pole: 'elbow_back' }],
  springChains: [{ root: 'ear_01_L', length: 2, stiffness: 0.45, damping: 0.2, gravity: 0.15 }, { root: 'ear_01_R', length: 2, stiffness: 0.45, damping: 0.2, gravity: 0.15 }],
  hurtboxes: [{ bone: 'head', shape: 'sphere', radius: 0.13, dmgMult: 1.5, partId: 'head' }, { bone: 'chest', shape: 'capsule', radius: 0.12, height: 0.25, dmgMult: 1 }, { bone: 'pelvis', shape: 'sphere', radius: 0.11, dmgMult: 1 }, { bone: 'thigh_L', shape: 'capsule', radius: 0.05, height: 0.2, dmgMult: 0.8 }, { bone: 'thigh_R', shape: 'capsule', radius: 0.05, height: 0.2, dmgMult: 0.8 }, { bone: 'upperarm_L', shape: 'capsule', radius: 0.04, height: 0.16, dmgMult: 0.7 }, { bone: 'upperarm_R', shape: 'capsule', radius: 0.04, height: 0.16, dmgMult: 0.7 }],
  breakableParts: [{ partId: 'weapon', bone: 'weapon_R', hpPct: 0.2, materialTag: 'crude_blade', onBreak: 'disarm_switch_to_claws' }],
  blendShapes: ['blink_L', 'blink_R', 'snarl', 'grin', 'mouth_open', 'fear'],
  procedural: ['look_at_target', 'foot_ik_ground', 'hunch_breathing', 'ear_twitch', 'weapon_hand_swap'],
  locomotion: { gaits: [{ name: 'walk', froude: 0.25, legFrac: 0.4 }, { name: 'run', froude: 2.0, legFrac: 0.4 }, { name: 'sprint_all_fours', froude: 3.2, legFrac: 0.4 }], fantasyMult: 1.3, turnDegPerSecAt1m: 420, accelG: 1.0, jumpHeightFrac: 0.7, canClimb: 'ledges', canSwim: true, canFly: false, hovers: false },
  physics: { shapeK: 0.016, ...PHYS.flesh, collider: { type: 'capsule', radiusFrac: 0.2, heightFrac: 1.0 }, gravityScale: 1.5, linearDrag: 0.1, knockbackResist: 0.15, launchable: true, ragdoll: 'full', deathStyle: 'ragdoll_crumple' },
  anims: anims(CORE, WALKERS, AIRBORNE, [C('sprint_all_fours', 16, true, true), C('throw', 30, false, false, [{ f: 14, e: 'hit_on' }]), C('cower', 40, true, false), C('cheer', 45, false, false), C('climb_up', 40, false, true)], ATTACK_SLOTS(4)),
});

// 4 MEDIUM BIPED (orcs, skeletons, zombies, bandits, lizardfolk)
const MED = { pelvis: 0.52, chest: 0.72, neck: 0.84, eyeZ: 0.93, shoulderZ: 0.82, shoulderX: 0.13, elbowZ: 0.63, wristZ: 0.47, hand: 0.08, hipX: 0.055, knee: 0.27, ankle: 0.045, foot: 0.13 };
R({ key: 'medium_biped', aliases: ['humanoid', 'orc', 'skeleton', 'zombie', 'undead_biped', 'lizardfolk', 'bandit', 'scarecrow', 'headless'], description: 'Human-scale bipeds 1.5–2.2 m. Standard Humanoid avatar so Mixamo and asset-store packs retarget directly.',
  sizeAxis: 'height', refSize: 1.8, unityAvatar: 'Humanoid', boneBudget: 50, material: 'flesh',
  bones: fix([...humanoid(MED), B('cape_anchor', 'chest', [0, 0.05, 0.82], [0, 0.08, 0.7], { deform: false })]),
  ikChains: [{ name: 'leg_L', tip: 'foot_L', chainLength: 2, pole: 'knee_forward' }, { name: 'leg_R', tip: 'foot_R', chainLength: 2, pole: 'knee_forward' }, { name: 'arm_L', tip: 'hand_L', chainLength: 2, pole: 'elbow_back' }, { name: 'arm_R', tip: 'hand_R', chainLength: 2, pole: 'elbow_back' }],
  hurtboxes: [{ bone: 'head', shape: 'sphere', radius: 0.11, dmgMult: 1.5, partId: 'head' }, { bone: 'chest', shape: 'capsule', radius: 0.16, height: 0.3, dmgMult: 1 }, { bone: 'pelvis', shape: 'sphere', radius: 0.14, dmgMult: 1 }, { bone: 'thigh_L', shape: 'capsule', radius: 0.07, height: 0.3, dmgMult: 0.8 }, { bone: 'thigh_R', shape: 'capsule', radius: 0.07, height: 0.3, dmgMult: 0.8 }, { bone: 'calf_L', shape: 'capsule', radius: 0.05, height: 0.28, dmgMult: 0.7 }, { bone: 'calf_R', shape: 'capsule', radius: 0.05, height: 0.28, dmgMult: 0.7 }, { bone: 'upperarm_L', shape: 'capsule', radius: 0.05, height: 0.25, dmgMult: 0.7 }, { bone: 'upperarm_R', shape: 'capsule', radius: 0.05, height: 0.25, dmgMult: 0.7 }],
  breakableParts: [{ partId: 'weapon', bone: 'weapon_R', hpPct: 0.2, materialTag: 'weapon', onBreak: 'disarm' }, { partId: 'shield', bone: 'weapon_L', hpPct: 0.25, materialTag: 'shield_scrap', onBreak: 'no_guard' }],
  blendShapes: ['blink_L', 'blink_R', 'snarl', 'mouth_open', 'pain'],
  procedural: ['look_at_target', 'foot_ik_ground', 'breathing', 'hit_lean_additive', 'aim_offset_upper_body'],
  locomotion: { gaits: [{ name: 'walk', froude: 0.25, legFrac: 0.5 }, { name: 'run', froude: 1.6, legFrac: 0.5 }], fantasyMult: 1.25, turnDegPerSecAt1m: 400, accelG: 0.9, jumpHeightFrac: 0.4, canClimb: 'ledges', canSwim: true, canFly: false, hovers: false },
  physics: { shapeK: 0.013, ...PHYS.flesh, collider: { type: 'capsule', radiusFrac: 0.17, heightFrac: 1.0 }, gravityScale: 1.5, linearDrag: 0.1, knockbackResist: 0.3, launchable: true, ragdoll: 'full', deathStyle: 'ragdoll' },
  anims: anims(CORE, WALKERS, AIRBORNE, [C('block_loop', 30, true, false), C('block_hit', 14, false, false), C('dodge_back', 18, false, true), C('throw', 30, false, false, [{ f: 14, e: 'hit_on' }]), C('climb_up', 40, false, true)], ATTACK_SLOTS(6)),
});

// 5 LARGE BIPED (ogres, minotaurs, trolls, treants)
const LARGE = { pelvis: 0.5, chest: 0.72, neck: 0.83, eyeZ: 0.92, shoulderZ: 0.8, shoulderX: 0.18, elbowZ: 0.56, wristZ: 0.36, hand: 0.1, hipX: 0.08, knee: 0.25, ankle: 0.045, foot: 0.14 };
R({ key: 'large_biped', aliases: ['ogre', 'troll', 'minotaur', 'treant', 'giant_humanoid', 'hobgoblin_large'], description: 'Hulking bipeds 2.5–5 m: wide shoulders, long arms (can knuckle-walk), heavy footfalls. Humanoid avatar with an extra belly jiggle bone.',
  sizeAxis: 'height', refSize: 3.5, unityAvatar: 'Humanoid', boneBudget: 55, material: 'flesh',
  bones: fix([...humanoid(LARGE), B('belly', 'spine_01', [0, -0.08, 0.6], [0, -0.16, 0.56], { spring: true }), ...sides([B('horn_L', 'head', [0.05, -0.02, 0.97], [0.14, -0.06, 1.04], { deform: false })])]),
  ikChains: [{ name: 'leg_L', tip: 'foot_L', chainLength: 2, pole: 'knee_forward' }, { name: 'leg_R', tip: 'foot_R', chainLength: 2, pole: 'knee_forward' }, { name: 'arm_L', tip: 'hand_L', chainLength: 2, pole: 'elbow_back' }, { name: 'arm_R', tip: 'hand_R', chainLength: 2, pole: 'elbow_back' }],
  springChains: [{ root: 'belly', length: 1, stiffness: 0.25, damping: 0.3, gravity: 0.3 }],
  hurtboxes: [{ bone: 'head', shape: 'sphere', radius: 0.08, dmgMult: 1.4, partId: 'head' }, { bone: 'chest', shape: 'capsule', radius: 0.17, height: 0.3, dmgMult: 1 }, { bone: 'belly', shape: 'sphere', radius: 0.15, dmgMult: 1.1 }, { bone: 'thigh_L', shape: 'capsule', radius: 0.07, height: 0.25, dmgMult: 0.9, partId: 'leg_L' }, { bone: 'thigh_R', shape: 'capsule', radius: 0.07, height: 0.25, dmgMult: 0.9, partId: 'leg_R' }, { bone: 'forearm_L', shape: 'capsule', radius: 0.05, height: 0.2, dmgMult: 0.8, partId: 'arm_L' }, { bone: 'forearm_R', shape: 'capsule', radius: 0.05, height: 0.2, dmgMult: 0.8, partId: 'arm_R' }],
  breakableParts: [{ partId: 'horn_L', bone: 'horn_L', hpPct: 0.12, materialTag: 'horn_shard', onBreak: 'stagger' }, { partId: 'horn_R', bone: 'horn_R', hpPct: 0.12, materialTag: 'horn_shard', onBreak: 'stagger' }, { partId: 'weapon', bone: 'weapon_R', hpPct: 0.25, materialTag: 'weapon', onBreak: 'disarm_grapple_mode' }, { partId: 'leg_L', bone: 'thigh_L', hpPct: 0.3, materialTag: '', onBreak: 'limp_knockdown' }],
  blendShapes: ['blink_L', 'blink_R', 'roar', 'snarl'],
  procedural: ['look_at_target', 'foot_ik_ground', 'heavy_breathing', 'footstep_camera_shake', 'ground_crack_decal_on_land'],
  locomotion: { gaits: [{ name: 'walk', froude: 0.2, legFrac: 0.48 }, { name: 'run', froude: 1.0, legFrac: 0.48 }, { name: 'knuckle_charge', froude: 1.8, legFrac: 0.48 }], fantasyMult: 1.1, turnDegPerSecAt1m: 380, accelG: 0.45, jumpHeightFrac: 0.15, canClimb: false, canSwim: true, canFly: false, hovers: false },
  physics: { shapeK: 0.018, ...PHYS.flesh, collider: { type: 'capsule', radiusFrac: 0.2, heightFrac: 1.0 }, gravityScale: 1.3, linearDrag: 0.05, knockbackResist: 0.75, launchable: 'only_while_staggered', ragdoll: 'partial', deathStyle: 'heavy_fall_dust' },
  anims: anims(CORE, WALKERS, AIRBORNE, [C('knuckle_charge', 18, true, true), C('ground_pound', 45, false, false, [{ f: 8, e: 'telegraph' }, { f: 28, e: 'hit_on' }, { f: 30, e: 'land' }]), C('grab_attempt', 36, false, true), C('grab_hold_loop', 30, true, false), C('throw_held', 30, false, false), C('roar', 60, false, false, [{ f: 12, e: 'vocal' }])], ATTACK_SLOTS(6)),
});

// 6 GIANT BIPED
R({ key: 'giant_biped', aliases: ['giant', 'titan', 'colossus_humanoid', 'frost_giant'], description: 'Giants 6–20 m. Same skeleton as large_biped plus climbable surfaces and weak-point sockets. Player can climb onto them (Shadow of the Colossus style grab points).',
  sizeAxis: 'height', refSize: 10, unityAvatar: 'Humanoid', boneBudget: 70, material: 'flesh',
  bones: fix([...humanoid(LARGE), B('belly', 'spine_01', [0, -0.08, 0.6], [0, -0.16, 0.56], { spring: true }), B('back_weakpoint', 'chest', [0, 0.12, 0.76], [0, 0.18, 0.76], { deform: false }), B('climb_socket_back', 'spine_02', [0, 0.14, 0.66], [0, 0.18, 0.66], { deform: false }), ...sides([B('climb_socket_arm_L', 'upperarm_L', [0.2, 0.04, 0.7], [0.22, 0.06, 0.7], { deform: false })])]),
  ikChains: [{ name: 'leg_L', tip: 'foot_L', chainLength: 2, pole: 'knee_forward' }, { name: 'leg_R', tip: 'foot_R', chainLength: 2, pole: 'knee_forward' }, { name: 'arm_L', tip: 'hand_L', chainLength: 2 }, { name: 'arm_R', tip: 'hand_R', chainLength: 2 }],
  springChains: [{ root: 'belly', length: 1, stiffness: 0.2, damping: 0.35, gravity: 0.3 }],
  hurtboxes: [{ bone: 'head', shape: 'sphere', radius: 0.08, dmgMult: 1.4, partId: 'head' }, { bone: 'back_weakpoint', shape: 'sphere', radius: 0.05, dmgMult: 3.0, partId: 'weakpoint' }, { bone: 'chest', shape: 'capsule', radius: 0.17, height: 0.3, dmgMult: 0.8 }, { bone: 'calf_L', shape: 'capsule', radius: 0.05, height: 0.22, dmgMult: 1, partId: 'leg_L' }, { bone: 'calf_R', shape: 'capsule', radius: 0.05, height: 0.22, dmgMult: 1, partId: 'leg_R' }],
  breakableParts: [{ partId: 'leg_L', bone: 'calf_L', hpPct: 0.2, materialTag: 'giant_s_hide', onBreak: 'kneel_exposes_head' }, { partId: 'leg_R', bone: 'calf_R', hpPct: 0.2, materialTag: 'giant_s_hide', onBreak: 'kneel_exposes_head' }, { partId: 'weakpoint', bone: 'back_weakpoint', hpPct: 0.15, materialTag: '', onBreak: 'break_gauge_full' }],
  blendShapes: ['blink_L', 'blink_R', 'roar'],
  procedural: ['look_at_target', 'foot_ik_ground', 'footstep_camera_shake', 'shake_off_climber', 'slow_head_track'],
  locomotion: { gaits: [{ name: 'walk', froude: 0.15, legFrac: 0.48 }, { name: 'run', froude: 0.6, legFrac: 0.48 }], fantasyMult: 1.0, turnDegPerSecAt1m: 300, accelG: 0.2, jumpHeightFrac: 0, canClimb: false, canSwim: 'wade', canFly: false, hovers: false },
  physics: { shapeK: 0.016, ...PHYS.flesh, collider: { type: 'capsule', radiusFrac: 0.18, heightFrac: 1.0 }, gravityScale: 1.0, linearDrag: 0.02, knockbackResist: 1.0, launchable: false, ragdoll: 'none', deathStyle: 'cinematic_collapse' },
  anims: anims(CORE, WALKERS, [C('stomp', 50, false, false, [{ f: 10, e: 'telegraph' }, { f: 34, e: 'hit_on' }, { f: 35, e: 'land' }]), C('sweep', 60, false, false, [{ f: 12, e: 'telegraph' }, { f: 36, e: 'hit_on' }, { f: 46, e: 'hit_off' }]), C('shake_off', 40, false, false), C('kneel', 40, false, false)], ATTACK_SLOTS(6)),
});

// 7 GOLEM
R({ key: 'golem', aliases: ['construct', 'automaton', 'stone_golem', 'gargoyle_ground'], description: 'Constructs: rigid segments (no skin deformation, every mesh piece parented to one bone), a glowing core. Joints may float with visible gaps.',
  sizeAxis: 'height', refSize: 3, unityAvatar: 'Humanoid', boneBudget: 40, material: 'stone',
  bones: fix([...humanoid(LARGE).filter(b => !/thumb|fingers|jaw|eye/.test(b.name)), B('core_gem', 'chest', [0, -0.12, 0.74], [0, -0.16, 0.74], { deform: false }), B('floating_shard_01', 'chest', [0.12, 0.1, 0.92], [0.12, 0.1, 0.98], { spring: true })]),
  ikChains: [{ name: 'leg_L', tip: 'foot_L', chainLength: 2 }, { name: 'leg_R', tip: 'foot_R', chainLength: 2 }],
  springChains: [{ root: 'floating_shard_01', length: 1, stiffness: 0.15, damping: 0.1, gravity: 0 }],
  hurtboxes: [{ bone: 'core_gem', shape: 'sphere', radius: 0.05, dmgMult: 2.5, partId: 'core' }, { bone: 'chest', shape: 'box', size: [0.4, 0.25, 0.3], dmgMult: 0.5 }, { bone: 'head', shape: 'box', size: [0.12, 0.12, 0.12], dmgMult: 1 }, { bone: 'forearm_L', shape: 'box', size: [0.1, 0.1, 0.22], dmgMult: 0.6, partId: 'arm_L' }, { bone: 'forearm_R', shape: 'box', size: [0.1, 0.1, 0.22], dmgMult: 0.6, partId: 'arm_R' }],
  breakableParts: [{ partId: 'arm_L', bone: 'forearm_L', hpPct: 0.2, materialTag: 'golem_core', onBreak: 'detach_arm_physics' }, { partId: 'arm_R', bone: 'forearm_R', hpPct: 0.2, materialTag: 'golem_core', onBreak: 'detach_arm_physics' }, { partId: 'core', bone: 'core_gem', hpPct: 0.2, materialTag: 'golem_core', onBreak: 'overload_explode_then_stun' }],
  blendShapes: [],
  procedural: ['rigid_segments', 'core_glow_pulse_by_hp', 'gap_jitter_when_damaged', 'footstep_camera_shake', 'dust_from_joints'],
  locomotion: { gaits: [{ name: 'walk', froude: 0.15, legFrac: 0.48 }, { name: 'run', froude: 0.7, legFrac: 0.48 }], fantasyMult: 1.0, turnDegPerSecAt1m: 200, accelG: 0.3, jumpHeightFrac: 0.1, canClimb: false, canSwim: 'sinks_walks_bottom', canFly: false, hovers: false },
  physics: { shapeK: 0.02, ...PHYS.stone, collider: { type: 'capsule', radiusFrac: 0.22, heightFrac: 1.0 }, gravityScale: 1.2, linearDrag: 0, knockbackResist: 0.95, launchable: 'only_while_staggered', ragdoll: 'shatter_pieces', deathStyle: 'crumble_into_rubble' },
  anims: anims(CORE, WALKERS, [C('core_charge', 60, false, false, [{ f: 10, e: 'telegraph' }, { f: 45, e: 'hit_on' }]), C('reassemble', 60, false, false), C('ground_pound', 45, false, false, [{ f: 8, e: 'telegraph' }, { f: 28, e: 'hit_on' }, { f: 30, e: 'land' }])], ATTACK_SLOTS(5)),
});

// 8 QUAD SMALL (rabbits, rats, foxes, small cats)
R({ key: 'quad_small', aliases: ['rabbit', 'rat', 'fox', 'small_beast', 'rodent', 'hare'], description: 'Small quadrupeds 0.3–0.8 m long. Hind-dominant: hopping or bounding gaits, ears and tail are their acting.',
  sizeAxis: 'length', refSize: 0.5, unityAvatar: 'Generic', boneBudget: 36, material: 'flesh',
  bones: fix(quad({ shoulderH: 0.32, hipH: 0.36, arch: 0.08, neckRise: 0.08, neckBones: 1, tail: 0.12, tailBones: 2, ears: 0.25 })),
  ikChains: [{ name: 'front_L', tip: 'front_foot_L', chainLength: 2 }, { name: 'front_R', tip: 'front_foot_R', chainLength: 2 }, { name: 'hind_L', tip: 'hind_foot_L', chainLength: 2 }, { name: 'hind_R', tip: 'hind_foot_R', chainLength: 2 }],
  springChains: [{ root: 'ear_01_L', length: 2, stiffness: 0.4, damping: 0.15, gravity: 0.2 }, { root: 'ear_01_R', length: 2, stiffness: 0.4, damping: 0.15, gravity: 0.2 }, { root: 'tail_01', length: 2, stiffness: 0.5, damping: 0.2, gravity: 0.1 }],
  hurtboxes: [{ bone: 'head', shape: 'sphere', radius: 0.09, dmgMult: 1.4, partId: 'head' }, { bone: 'spine_02', shape: 'capsule', radius: 0.12, height: 0.35, axis: 'y', dmgMult: 1 }],
  breakableParts: [{ partId: 'head', bone: 'head', hpPct: 0.35, materialTag: 'horn_shard', onBreak: 'horn_snap_no_charge' }],
  blendShapes: ['blink_L', 'blink_R', 'nose_twitch', 'mouth_open'],
  procedural: ['nose_twitch_idle', 'ear_track_sound', 'look_at_target', 'foot_ik_ground', 'body_tilt_on_slope'],
  locomotion: { gaits: [{ name: 'walk', froude: 0.3, legFrac: 0.33 }, { name: 'hop', froude: 6, legFrac: 0.33 }, { name: 'bound', froude: 22, legFrac: 0.33 }], fantasyMult: 1.0, turnDegPerSecAt1m: 540, accelG: 1.6, jumpHeightFrac: 2.0, canClimb: false, canSwim: true, canFly: false, hovers: false },
  physics: { shapeK: 0.03, ...PHYS.flesh, collider: { type: 'capsule', axis: 'y', radiusFrac: 0.16, heightFrac: 0.85 }, gravityScale: 1.6, linearDrag: 0.1, knockbackResist: 0.05, launchable: true, ragdoll: 'full', deathStyle: 'ragdoll_tumble' },
  anims: anims(CORE, QUAD_GAITS, AIRBORNE, [C('hop', 14, true, true, [{ f: 2, e: 'land' }]), C('bound', 12, true, true, [{ f: 1, e: 'land' }]), C('sit_up_listen', 60, false, false), C('dig', 40, true, false), C('thump_warning', 20, false, false, [{ f: 8, e: 'vocal' }])], ATTACK_SLOTS(3)),
});

// 9 QUAD MEDIUM (wolves, boars, big cats, deer)
R({ key: 'quad_medium', aliases: ['wolf', 'boar', 'beast', 'cat', 'deer', 'hound', 'quad'], description: 'Medium quadrupeds 1–2.5 m long. Full gait set (walk/trot/gallop), circling and pack flanking.',
  sizeAxis: 'length', refSize: 1.5, unityAvatar: 'Generic', boneBudget: 44, material: 'flesh',
  bones: fix([...quad({ shoulderH: 0.5, hipH: 0.48, arch: 0.02, neckRise: 0.06, neckBones: 2, tail: 0.32, tailBones: 4, ears: 0.08 }), ...chain('mane', 'neck_01', [0, -0.25, 0.56], [0, -0.1, 0.58], 2, { spring: true })]),
  ikChains: [{ name: 'front_L', tip: 'front_foot_L', chainLength: 2 }, { name: 'front_R', tip: 'front_foot_R', chainLength: 2 }, { name: 'hind_L', tip: 'hind_foot_L', chainLength: 2 }, { name: 'hind_R', tip: 'hind_foot_R', chainLength: 2 }],
  springChains: [{ root: 'tail_01', length: 4, stiffness: 0.35, damping: 0.18, gravity: 0.2 }, { root: 'mane_01', length: 2, stiffness: 0.4, damping: 0.2, gravity: 0.1 }, { root: 'ear_01_L', length: 2, stiffness: 0.6, damping: 0.25, gravity: 0.05 }, { root: 'ear_01_R', length: 2, stiffness: 0.6, damping: 0.25, gravity: 0.05 }],
  hurtboxes: [{ bone: 'head', shape: 'sphere', radius: 0.08, dmgMult: 1.4, partId: 'head' }, { bone: 'chest', shape: 'capsule', radius: 0.14, height: 0.3, axis: 'y', dmgMult: 1 }, { bone: 'spine_01', shape: 'capsule', radius: 0.13, height: 0.3, axis: 'y', dmgMult: 1 }, { bone: 'tail_01', shape: 'capsule', radius: 0.03, height: 0.15, dmgMult: 0.6, partId: 'tail' }],
  breakableParts: [{ partId: 'head', bone: 'head', hpPct: 0.3, materialTag: 'fang', onBreak: 'tusk_or_fang_broken_weaker_bite' }, { partId: 'tail', bone: 'tail_01', hpPct: 0.15, materialTag: 'pelt', onBreak: 'tail_cut_drop_material' }],
  blendShapes: ['blink_L', 'blink_R', 'snarl', 'mouth_open', 'ears_back'],
  procedural: ['look_at_target', 'foot_ik_ground', 'spine_bend_on_turn', 'body_tilt_on_slope', 'pant_breathing_after_run', 'hackles_raise_alert'],
  locomotion: { gaits: [{ name: 'walk', froude: 0.25, legFrac: 0.5 }, { name: 'trot', froude: 1.0, legFrac: 0.5 }, { name: 'gallop', froude: 4.5, legFrac: 0.5 }], fantasyMult: 1.15, turnDegPerSecAt1m: 400, accelG: 1.1, jumpHeightFrac: 0.6, canClimb: false, canSwim: true, canFly: false, hovers: false },
  physics: { shapeK: 0.012, ...PHYS.flesh, collider: { type: 'capsule', axis: 'y', radiusFrac: 0.16, heightFrac: 0.95 }, gravityScale: 1.4, linearDrag: 0.05, knockbackResist: 0.3, launchable: true, ragdoll: 'full', deathStyle: 'ragdoll_slide' },
  anims: anims(CORE, QUAD_GAITS, AIRBORNE, [C('pounce', 30, false, true, [{ f: 6, e: 'telegraph' }, { f: 16, e: 'hit_on' }, { f: 22, e: 'hit_off' }]), C('howl', 60, false, false, [{ f: 12, e: 'vocal' }]), C('sniff_ground', 60, true, false), C('shake_off_water', 30, false, false), C('paw_scrape_charge_windup', 30, false, false, [{ f: 2, e: 'telegraph' }])], ATTACK_SLOTS(4)),
});

// 10 QUAD LARGE (bears, behemoths, rhinos, mammoths)
R({ key: 'quad_large', aliases: ['bear', 'behemoth', 'rhino', 'mammoth', 'large_beast', 'drake_ground'], description: 'Heavy quadrupeds 2.5–8 m. Can rear up on hind legs (bears). Charges are its signature.',
  sizeAxis: 'length', refSize: 4, unityAvatar: 'Generic', boneBudget: 48, material: 'flesh',
  bones: fix([...quad({ shoulderH: 0.55, hipH: 0.48, arch: 0.05, neckRise: 0.02, neckBones: 2, tail: 0.15, tailBones: 3, ears: 0.05 }), B('belly', 'spine_01', [0, 0.05, 0.3], [0, 0, 0.24], { spring: true }), ...sides([B('tusk_L', 'jaw', [0.03, -0.45, 0.5], [0.08, -0.6, 0.6], { deform: false })])]),
  ikChains: [{ name: 'front_L', tip: 'front_foot_L', chainLength: 2 }, { name: 'front_R', tip: 'front_foot_R', chainLength: 2 }, { name: 'hind_L', tip: 'hind_foot_L', chainLength: 2 }, { name: 'hind_R', tip: 'hind_foot_R', chainLength: 2 }],
  springChains: [{ root: 'belly', length: 1, stiffness: 0.25, damping: 0.3, gravity: 0.4 }, { root: 'tail_01', length: 3, stiffness: 0.4, damping: 0.2, gravity: 0.3 }],
  hurtboxes: [{ bone: 'head', shape: 'sphere', radius: 0.08, dmgMult: 1.3, partId: 'head' }, { bone: 'chest', shape: 'capsule', radius: 0.18, height: 0.3, axis: 'y', dmgMult: 1 }, { bone: 'spine_01', shape: 'capsule', radius: 0.17, height: 0.3, axis: 'y', dmgMult: 1 }, { bone: 'forearm_L', shape: 'capsule', radius: 0.04, height: 0.15, dmgMult: 0.9, partId: 'foreleg_L' }, { bone: 'forearm_R', shape: 'capsule', radius: 0.04, height: 0.15, dmgMult: 0.9, partId: 'foreleg_R' }],
  breakableParts: [{ partId: 'tusk_L', bone: 'tusk_L', hpPct: 0.15, materialTag: 'tusk', onBreak: 'weaker_gore' }, { partId: 'tusk_R', bone: 'tusk_R', hpPct: 0.15, materialTag: 'tusk', onBreak: 'weaker_gore' }, { partId: 'foreleg_L', bone: 'forearm_L', hpPct: 0.25, materialTag: '', onBreak: 'stumble_on_charge' }],
  blendShapes: ['blink_L', 'blink_R', 'roar', 'snort'],
  procedural: ['look_at_target', 'foot_ik_ground', 'footstep_camera_shake', 'heavy_breathing', 'charge_lean'],
  locomotion: { gaits: [{ name: 'walk', froude: 0.2, legFrac: 0.5 }, { name: 'trot', froude: 0.8, legFrac: 0.5 }, { name: 'charge', froude: 2.5, legFrac: 0.5 }], fantasyMult: 1.05, turnDegPerSecAt1m: 320, accelG: 0.5, jumpHeightFrac: 0.1, canClimb: false, canSwim: true, canFly: false, hovers: false },
  physics: { shapeK: 0.02, ...PHYS.flesh, collider: { type: 'capsule', axis: 'y', radiusFrac: 0.2, heightFrac: 0.95 }, gravityScale: 1.2, linearDrag: 0.03, knockbackResist: 0.85, launchable: 'only_while_staggered', ragdoll: 'partial', deathStyle: 'heavy_fall_dust' },
  anims: anims(CORE, QUAD_GAITS, [C('rear_up', 40, false, false, [{ f: 6, e: 'telegraph' }]), C('rear_slam', 30, false, false, [{ f: 14, e: 'hit_on' }, { f: 15, e: 'land' }]), C('charge_windup', 30, false, false, [{ f: 2, e: 'telegraph' }]), C('charge_loop', 16, true, true), C('charge_skid_stop', 30, false, true), C('roar', 60, false, false, [{ f: 12, e: 'vocal' }])], ATTACK_SLOTS(5)),
});

// 11 DRAGON (winged quadruped)
R({ key: 'dragon', aliases: ['winged_quad', 'griffon', 'manticore', 'chimera', 'elder_dragon'], description: 'Four legs + a separate pair of wings (6 limbs): dragons, griffons, manticores. Long neck and tail. Flies in boss fights; never a mount (Canon).',
  sizeAxis: 'length', refSize: 12, unityAvatar: 'Generic', boneBudget: 90, material: 'scaled',
  bones: fix([...quad({ shoulderH: 0.3, hipH: 0.28, arch: 0.03, neckRise: 0.16, neckBones: 6, tail: 0.6, tailBones: 10, ears: 0 }), ...sides([...wing('wing', 'chest', [0.04, -0.14, 0.34], 0.7, true), B('horn_L', 'head', [0.025, -0.4, 0.5], [0.06, -0.33, 0.56], { deform: false })])]),
  ikChains: [{ name: 'front_L', tip: 'front_foot_L', chainLength: 2 }, { name: 'front_R', tip: 'front_foot_R', chainLength: 2 }, { name: 'hind_L', tip: 'hind_foot_L', chainLength: 2 }, { name: 'hind_R', tip: 'hind_foot_R', chainLength: 2 }, { name: 'neck_aim', tip: 'head', chainLength: 6, type: 'aim' }],
  springChains: [{ root: 'tail_04', length: 7, stiffness: 0.3, damping: 0.2, gravity: 0.2 }, { root: 'wing_finger1_01_L', length: 2, stiffness: 0.6, damping: 0.25, gravity: 0.05 }, { root: 'wing_finger1_01_R', length: 2, stiffness: 0.6, damping: 0.25, gravity: 0.05 }],
  hurtboxes: [{ bone: 'head', shape: 'sphere', radius: 0.05, dmgMult: 1.5, partId: 'head' }, { bone: 'neck_03', shape: 'capsule', radius: 0.04, height: 0.1, dmgMult: 1.1 }, { bone: 'chest', shape: 'capsule', radius: 0.1, height: 0.25, axis: 'y', dmgMult: 0.9 }, { bone: 'spine_01', shape: 'capsule', radius: 0.09, height: 0.25, axis: 'y', dmgMult: 0.9 }, { bone: 'wing_radius_L', shape: 'capsule', radius: 0.03, height: 0.25, dmgMult: 1, partId: 'wing_L' }, { bone: 'wing_radius_R', shape: 'capsule', radius: 0.03, height: 0.25, dmgMult: 1, partId: 'wing_R' }, { bone: 'tail_06', shape: 'capsule', radius: 0.025, height: 0.12, dmgMult: 1, partId: 'tail' }],
  breakableParts: [{ partId: 'horn_L', bone: 'horn_L', hpPct: 0.08, materialTag: 'horn_shard', onBreak: 'stagger' }, { partId: 'horn_R', bone: 'horn_R', hpPct: 0.08, materialTag: 'horn_shard', onBreak: 'stagger' }, { partId: 'wing_L', bone: 'wing_radius_L', hpPct: 0.18, materialTag: 'dragon_scale', onBreak: 'grounded_cannot_fly' }, { partId: 'wing_R', bone: 'wing_radius_R', hpPct: 0.18, materialTag: 'dragon_scale', onBreak: 'grounded_cannot_fly' }, { partId: 'tail', bone: 'tail_06', hpPct: 0.2, materialTag: 'dragon_scale', onBreak: 'tail_severed_no_tail_sweep' }],
  blendShapes: ['blink_L', 'blink_R', 'roar', 'snarl', 'nostril_flare', 'throat_glow'],
  procedural: ['neck_aim_ik', 'look_at_target', 'foot_ik_ground', 'tail_drag_physics', 'wing_fold_spring', 'breath_charge_throat_glow', 'footstep_camera_shake'],
  locomotion: { gaits: [{ name: 'walk', froude: 0.18, legFrac: 0.3 }, { name: 'run', froude: 1.4, legFrac: 0.3 }], fantasyMult: 1.0, turnDegPerSecAt1m: 600, accelG: 0.35, jumpHeightFrac: 0.15, canClimb: 'cliffs', canSwim: true, canFly: true, hovers: true, flySpeedMult: 2.2 },
  physics: { shapeK: 0.006, ...PHYS.scaled, collider: { type: 'capsule', axis: 'y', radiusFrac: 0.08, heightFrac: 0.6 }, gravityScale: 1.0, linearDrag: 0.02, knockbackResist: 1.0, launchable: false, ragdoll: 'none', deathStyle: 'cinematic_collapse' },
  anims: anims(CORE, QUAD_GAITS, FLY, [C('breath_windup', 45, false, false, [{ f: 2, e: 'telegraph' }]), C('breath_loop', 30, true, false, [{ f: 0, e: 'hit_on' }]), C('tail_sweep', 40, false, false, [{ f: 6, e: 'telegraph' }, { f: 20, e: 'hit_on' }, { f: 28, e: 'hit_off' }]), C('wing_buffet', 36, false, false), C('roar', 75, false, false, [{ f: 15, e: 'vocal' }])], ATTACK_SLOTS(8)),
});

// 12 HEXAPOD (ants, beetles, mantises)
R({ key: 'hexapod', aliases: ['insect', 'ant', 'beetle', 'mantis', 'bug'], description: 'Six-legged insects. Tripod gait (3 legs down at once), procedural leg IK on uneven ground. Mandibles and antennae act.',
  sizeAxis: 'length', refSize: 0.8, unityAvatar: 'Generic', boneBudget: 40, material: 'chitin',
  bones: fix(sides([B('root', null, [0, 0, 0], [0, -0.15, 0], { deform: false }), B('thorax', 'root', [0, 0, 0.18], [0, -0.15, 0.2]), B('head', 'thorax', [0, -0.15, 0.2], [0, -0.32, 0.19]), B('abdomen_01', 'thorax', [0, 0.02, 0.18], [0, 0.25, 0.2]), B('abdomen_02', 'abdomen_01', [0, 0.25, 0.2], [0, 0.48, 0.16]),
    B('mandible_L', 'head', [0.04, -0.3, 0.16], [0.02, -0.38, 0.15]), ...chain('antenna_L', 'head', [0.02, -0.28, 0.23], [0.12, -0.5, 0.33], 2, { spring: true }),
    ...legPair('leg1', 'thorax', [0.05, -0.12, 0.17], -0.6, ['coxa', 'femur', 'tibia', 'tarsus'], [0.04, 0.12, 0.15, 0.05]),
    ...legPair('leg2', 'thorax', [0.06, -0.04, 0.17], 0, ['coxa', 'femur', 'tibia', 'tarsus'], [0.04, 0.13, 0.16, 0.05]),
    ...legPair('leg3', 'thorax', [0.05, 0.03, 0.17], 0.6, ['coxa', 'femur', 'tibia', 'tarsus'], [0.04, 0.14, 0.17, 0.05])])),
  ikChains: [1, 2, 3].flatMap(i => ['L', 'R'].map(s => ({ name: `leg${i}_${s}`, tip: `leg${i}_tarsus_${s}`, chainLength: 3, procedural: true }))),
  springChains: [{ root: 'antenna_01_L', length: 2, stiffness: 0.5, damping: 0.15, gravity: 0 }, { root: 'antenna_01_R', length: 2, stiffness: 0.5, damping: 0.15, gravity: 0 }],
  hurtboxes: [{ bone: 'head', shape: 'sphere', radius: 0.08, dmgMult: 1.4, partId: 'head' }, { bone: 'thorax', shape: 'sphere', radius: 0.1, dmgMult: 0.7 }, { bone: 'abdomen_01', shape: 'capsule', radius: 0.11, height: 0.4, axis: 'y', dmgMult: 1.3, partId: 'abdomen' }],
  breakableParts: [{ partId: 'head', bone: 'mandible_L', hpPct: 0.2, materialTag: 'killer_mandible', onBreak: 'no_grab' }, { partId: 'abdomen', bone: 'abdomen_02', hpPct: 0.25, materialTag: 'venom_sac', onBreak: 'no_acid_spray' }],
  blendShapes: [],
  procedural: ['tripod_gait_ik', 'body_height_follow_terrain', 'antenna_sweep', 'mandible_clack_idle', 'wall_walk_align_to_normal'],
  locomotion: { gaits: [{ name: 'walk', froude: 0.5, legFrac: 0.2 }, { name: 'scuttle', froude: 6, legFrac: 0.2 }], fantasyMult: 1.0, turnDegPerSecAt1m: 500, accelG: 1.4, jumpHeightFrac: 0.3, canClimb: 'walls_and_ceilings', canSwim: false, canFly: 'some_variants', hovers: false },
  physics: { shapeK: 0.04, ...PHYS.chitin, collider: { type: 'capsule', axis: 'y', radiusFrac: 0.14, heightFrac: 0.9 }, gravityScale: 1.4, linearDrag: 0.1, knockbackResist: 0.25, launchable: true, ragdoll: 'partial', deathStyle: 'flip_legs_curl' },
  anims: anims(CORE, [C('walk', 24, true, true), C('scuttle', 12, true, true), C('wall_walk', 24, true, true)], AIRBORNE, [C('rear_threat', 30, false, false, [{ f: 4, e: 'telegraph' }]), C('acid_spray', 36, false, false, [{ f: 16, e: 'hit_on' }])], ATTACK_SLOTS(3)),
});

// 13 ARACHNID
R({ key: 'arachnid', aliases: ['spider', 'scorpion', 'tick', 'octopod'], description: 'Eight legs, cephalothorax + abdomen. Wave gait, wall and ceiling walking, web anchors. Menace-heavy: stillness then sudden speed.',
  sizeAxis: 'length', refSize: 1.0, unityAvatar: 'Generic', boneBudget: 48, material: 'chitin',
  bones: fix(sides([B('root', null, [0, 0, 0], [0, -0.15, 0], { deform: false }), B('cephalothorax', 'root', [0, 0, 0.2], [0, -0.2, 0.22]), B('head_eyes', 'cephalothorax', [0, -0.2, 0.22], [0, -0.26, 0.24], { deform: false }), B('abdomen', 'cephalothorax', [0, 0.02, 0.22], [0, 0.42, 0.28], { spring: true }), B('spinneret', 'abdomen', [0, 0.42, 0.26], [0, 0.47, 0.22], { deform: false }),
    B('chelicera_L', 'cephalothorax', [0.03, -0.22, 0.2], [0.03, -0.3, 0.12]), B('pedipalp_L', 'cephalothorax', [0.05, -0.2, 0.19], [0.1, -0.33, 0.12]),
    ...[[-0.15, -0.9], [-0.08, -0.3], [-0.01, 0.3], [0.06, 0.9]].flatMap(([y, d], i) => legPair(`leg${i + 1}`, 'cephalothorax', [0.06, y, 0.2], d, ['coxa', 'femur', 'tibia', 'tarsus'], [0.04, 0.22, 0.22, 0.08]))])),
  ikChains: [1, 2, 3, 4].flatMap(i => ['L', 'R'].map(s => ({ name: `leg${i}_${s}`, tip: `leg${i}_tarsus_${s}`, chainLength: 3, procedural: true }))),
  springChains: [{ root: 'abdomen', length: 1, stiffness: 0.3, damping: 0.25, gravity: 0.3 }],
  hurtboxes: [{ bone: 'cephalothorax', shape: 'sphere', radius: 0.13, dmgMult: 1 }, { bone: 'head_eyes', shape: 'sphere', radius: 0.05, dmgMult: 1.8, partId: 'eyes' }, { bone: 'abdomen', shape: 'sphere', radius: 0.18, center: [0, 0.2, 0], dmgMult: 1.3, partId: 'abdomen' }],
  breakableParts: [{ partId: 'eyes', bone: 'head_eyes', hpPct: 0.12, materialTag: 'reptile_eye', onBreak: 'blind_wild_attacks' }, { partId: 'abdomen', bone: 'abdomen', hpPct: 0.3, materialTag: 'silk', onBreak: 'no_webs' }],
  blendShapes: [],
  procedural: ['wave_gait_ik', 'wall_walk_align_to_normal', 'abdomen_pulse_breathing', 'leg_tap_idle', 'still_then_dart'],
  locomotion: { gaits: [{ name: 'creep', froude: 0.2, legFrac: 0.3 }, { name: 'dart', froude: 8, legFrac: 0.3 }], fantasyMult: 1.0, turnDegPerSecAt1m: 600, accelG: 2.0, jumpHeightFrac: 1.2, canClimb: 'walls_and_ceilings', canSwim: false, canFly: false, hovers: false },
  physics: { shapeK: 0.03, ...PHYS.chitin, collider: { type: 'sphere', radiusFrac: 0.25, centerZFrac: 0.2 }, gravityScale: 1.4, linearDrag: 0.1, knockbackResist: 0.2, launchable: true, ragdoll: 'partial', deathStyle: 'flip_legs_curl' },
  anims: anims(CORE, [C('creep', 40, true, true), C('dart', 10, true, true), C('wall_walk', 30, true, true), C('ceiling_drop', 24, false, false, [{ f: 18, e: 'land' }])], AIRBORNE, [C('web_shot', 30, false, false, [{ f: 4, e: 'telegraph' }, { f: 16, e: 'hit_on' }]), C('leap_strike', 30, false, true, [{ f: 6, e: 'telegraph' }, { f: 18, e: 'hit_on' }, { f: 22, e: 'hit_off' }])], ATTACK_SLOTS(4)),
});

// 14 SERPENT
R({ key: 'serpent', aliases: ['snake', 'wyrm', 'eel', 'worm', 'sandworm', 'basilisk'], description: 'Limbless long bodies: snakes, giant worms, eels, sea serpents. Spline-driven spine (16 bones) with a follow-the-head path solver.',
  sizeAxis: 'length', refSize: 4, unityAvatar: 'Generic', boneBudget: 24, material: 'scaled',
  bones: fix([B('root', null, [0, 0, 0], [0, -0.15, 0], { deform: false }), B('head', 'root', [0, -0.05, 0.04], [0, -0.1, 0.035]), B('jaw', 'head', [0, -0.06, 0.03], [0, -0.1, 0.02]), B('tongue', 'jaw', [0, -0.09, 0.03], [0, -0.13, 0.03], { spring: true }), ...chain('spine', 'head', [0, -0.05, 0.04], [0, 0.95, 0.03], 16), B('tail_tip', 'spine_16', [0, 0.95, 0.03], [0, 1.0, 0.02], { spring: true })]),
  ikChains: [{ name: 'spine_path', tip: 'spine_16', chainLength: 16, type: 'spline_follow_head' }],
  springChains: [{ root: 'tail_tip', length: 1, stiffness: 0.4, damping: 0.2, gravity: 0.1 }, { root: 'tongue', length: 1, stiffness: 0.7, damping: 0.1, gravity: 0 }],
  hurtboxes: [{ bone: 'head', shape: 'sphere', radius: 0.03, dmgMult: 1.6, partId: 'head' }, ...[2, 5, 8, 11, 14].map(i => ({ bone: `spine_${String(i).padStart(2, '0')}`, shape: 'sphere', radius: 0.035, dmgMult: i > 12 ? 0.8 : 1, partId: i === 14 ? 'tail' : undefined }))],
  breakableParts: [{ partId: 'head', bone: 'jaw', hpPct: 0.2, materialTag: 'fang', onBreak: 'no_venom' }, { partId: 'tail', bone: 'spine_14', hpPct: 0.2, materialTag: 'scale', onBreak: 'no_tail_whip' }],
  blendShapes: ['jaw_unhinge', 'hood_flare', 'blink'],
  procedural: ['spline_follow_head', 'lateral_undulation_by_speed', 'coil_when_idle', 'tongue_flick_idle', 'body_hugs_terrain'],
  locomotion: { gaits: [{ name: 'slither', froude: 0.4, legFrac: 0.06 }, { name: 'strike_lunge', froude: 12, legFrac: 0.06 }, { name: 'swim', froude: 0.8, legFrac: 0.06 }], fantasyMult: 1.0, turnDegPerSecAt1m: 300, accelG: 0.8, jumpHeightFrac: 0, canClimb: 'trees', canSwim: true, canFly: false, hovers: false, burrows: 'worm_variants' },
  physics: { shapeK: 0.002, ...PHYS.scaled, collider: { type: 'capsule_chain', count: 5, radiusFrac: 0.035 }, gravityScale: 1.2, linearDrag: 0.2, knockbackResist: 0.4, launchable: 'head_only', ragdoll: 'chain_physics', deathStyle: 'limp_chain' },
  anims: anims(CORE.filter(c => !/turn/.test(c.name)), [C('slither', 30, true, true), C('coil_idle', 90, true, false), C('rear_up_threat', 30, false, false, [{ f: 4, e: 'telegraph' }]), C('strike', 18, false, true, [{ f: 8, e: 'hit_on' }, { f: 11, e: 'hit_off' }]), C('constrict_loop', 40, true, false), C('burrow', 40, false, false), C('emerge', 30, false, false)], ATTACK_SLOTS(4)),
});

// 15 NAGA (serpent lower + humanoid upper; also lamias, mermaids on land)
R({ key: 'naga', aliases: ['lamia', 'mer', 'serpent_humanoid'], description: 'Humanoid torso on a serpent tail: nagas, lamias. Upper body uses humanoid arm/head bones; lower uses the serpent spine.',
  sizeAxis: 'length', refSize: 4, unityAvatar: 'Generic', boneBudget: 40, material: 'scaled',
  bones: fix(sides([B('root', null, [0, 0, 0], [0, -0.15, 0], { deform: false }), B('pelvis', 'root', [0, 0, 0.18], [0, 0, 0.22]), B('spine_01', 'pelvis', [0, 0, 0.22], [0, 0, 0.3]), B('chest', 'spine_01', [0, 0, 0.3], [0, 0, 0.38]), B('neck', 'chest', [0, 0, 0.38], [0, 0, 0.4]), B('head', 'neck', [0, 0, 0.4], [0, 0, 0.46]),
    B('upperarm_L', 'chest', [0.05, 0, 0.37], [0.07, 0, 0.3]), B('forearm_L', 'upperarm_L', [0.07, 0, 0.3], [0.08, -0.02, 0.23]), B('hand_L', 'forearm_L', [0.08, -0.02, 0.23], [0.08, -0.03, 0.21]), B('weapon_L', 'hand_L', [0.08, -0.03, 0.21], [0.08, -0.08, 0.21], { deform: false }),
    ...chain('tail', 'pelvis', [0, 0, 0.18], [0, 0.95, 0.02], 12), ...chain('hair', 'head', [0, 0.01, 0.45], [0, 0.04, 0.36], 3, { spring: true })])),
  ikChains: [{ name: 'tail_path', tip: 'tail_12', chainLength: 12, type: 'spline_follow_head' }, { name: 'arm_L', tip: 'hand_L', chainLength: 2 }, { name: 'arm_R', tip: 'hand_R', chainLength: 2 }],
  springChains: [{ root: 'hair_01', length: 3, stiffness: 0.3, damping: 0.2, gravity: 0.4 }],
  hurtboxes: [{ bone: 'head', shape: 'sphere', radius: 0.03, dmgMult: 1.5, partId: 'head' }, { bone: 'chest', shape: 'capsule', radius: 0.04, height: 0.1, dmgMult: 1 }, { bone: 'tail_03', shape: 'sphere', radius: 0.05, dmgMult: 0.9 }, { bone: 'tail_08', shape: 'sphere', radius: 0.04, dmgMult: 0.8, partId: 'tail' }],
  breakableParts: [{ partId: 'tail', bone: 'tail_08', hpPct: 0.25, materialTag: 'scale', onBreak: 'no_tail_sweep' }],
  blendShapes: ['blink_L', 'blink_R', 'hiss', 'smile'],
  procedural: ['spline_follow_head', 'upper_body_stays_upright', 'look_at_target', 'hair_spring'],
  locomotion: { gaits: [{ name: 'slither', froude: 0.5, legFrac: 0.15 }, { name: 'fast_slither', froude: 2, legFrac: 0.15 }], fantasyMult: 1.1, turnDegPerSecAt1m: 350, accelG: 0.8, jumpHeightFrac: 0, canClimb: false, canSwim: true, canFly: false, hovers: false },
  physics: { shapeK: 0.003, ...PHYS.scaled, collider: { type: 'capsule', radiusFrac: 0.05, heightFrac: 0.45 }, gravityScale: 1.3, linearDrag: 0.15, knockbackResist: 0.4, launchable: false, ragdoll: 'chain_physics', deathStyle: 'limp_chain' },
  anims: anims(CORE, [C('slither', 30, true, true), C('tail_sweep', 40, false, false, [{ f: 6, e: 'telegraph' }, { f: 20, e: 'hit_on' }, { f: 28, e: 'hit_off' }]), C('constrict_grab', 36, false, true)], ATTACK_SLOTS(5)),
});

// 16 TAUR (humanoid upper + quadruped lower): centaurs, arachne-taurs
R({ key: 'taur', aliases: ['centaur', 'arachne', 'taur_beast'], description: 'Humanoid torso on a four-legged body: centaurs. Lower body uses quad gaits; upper body aims weapons independently.',
  sizeAxis: 'length', refSize: 2.4, unityAvatar: 'Generic', boneBudget: 60, material: 'flesh',
  bones: fix([...quad({ shoulderH: 0.6, hipH: 0.6, arch: 0, neckRise: 0, neckBones: 1, tail: 0.3, tailBones: 4, ears: 0 }).filter(b => !/^(neck_01|head|jaw|eye_[LR])$/.test(b.name)),
    ...sides([B('torso_01', 'chest', [0, -0.24, 0.62], [0, -0.26, 0.78]), B('torso_02', 'torso_01', [0, -0.26, 0.78], [0, -0.27, 0.9]), B('h_neck', 'torso_02', [0, -0.27, 0.9], [0, -0.27, 0.95]), B('h_head', 'h_neck', [0, -0.27, 0.95], [0, -0.28, 1.05]),
      B('h_upperarm_L', 'torso_02', [0.09, -0.26, 0.89], [0.11, -0.25, 0.77]), B('h_forearm_L', 'h_upperarm_L', [0.11, -0.25, 0.77], [0.12, -0.3, 0.67]), B('h_hand_L', 'h_forearm_L', [0.12, -0.3, 0.67], [0.12, -0.32, 0.63]), B('weapon_L', 'h_hand_L', [0.12, -0.32, 0.64], [0.12, -0.42, 0.64], { deform: false })])]),
  ikChains: [{ name: 'front_L', tip: 'front_foot_L', chainLength: 2 }, { name: 'front_R', tip: 'front_foot_R', chainLength: 2 }, { name: 'hind_L', tip: 'hind_foot_L', chainLength: 2 }, { name: 'hind_R', tip: 'hind_foot_R', chainLength: 2 }, { name: 'arm_L', tip: 'h_hand_L', chainLength: 2 }, { name: 'arm_R', tip: 'h_hand_R', chainLength: 2 }],
  springChains: [{ root: 'tail_01', length: 4, stiffness: 0.35, damping: 0.2, gravity: 0.3 }],
  hurtboxes: [{ bone: 'h_head', shape: 'sphere', radius: 0.04, dmgMult: 1.5, partId: 'head' }, { bone: 'torso_02', shape: 'capsule', radius: 0.06, height: 0.15, dmgMult: 1 }, { bone: 'spine_01', shape: 'capsule', radius: 0.14, height: 0.35, axis: 'y', dmgMult: 0.9 }],
  breakableParts: [{ partId: 'weapon', bone: 'weapon_R', hpPct: 0.2, materialTag: 'weapon', onBreak: 'disarm_trample_mode' }],
  blendShapes: ['blink_L', 'blink_R', 'shout'],
  procedural: ['upper_body_aim_independent', 'foot_ik_ground', 'look_at_target', 'spine_bend_on_turn'],
  locomotion: { gaits: [{ name: 'walk', froude: 0.25, legFrac: 0.6 }, { name: 'trot', froude: 1.0, legFrac: 0.6 }, { name: 'gallop', froude: 3.5, legFrac: 0.6 }], fantasyMult: 1.1, turnDegPerSecAt1m: 360, accelG: 0.9, jumpHeightFrac: 0.5, canClimb: false, canSwim: true, canFly: false, hovers: false },
  physics: { shapeK: 0.02, ...PHYS.flesh, collider: { type: 'capsule', axis: 'y', radiusFrac: 0.16, heightFrac: 0.9 }, gravityScale: 1.3, linearDrag: 0.05, knockbackResist: 0.6, launchable: 'only_while_staggered', ragdoll: 'partial', deathStyle: 'ragdoll_slide' },
  anims: anims(CORE, QUAD_GAITS, [C('rear_up', 40, false, false, [{ f: 6, e: 'telegraph' }]), C('bow_shot_moving', 30, true, false, [{ f: 18, e: 'hit_on' }]), C('trample_charge', 16, true, true)], ATTACK_SLOTS(6)),
});

// 17 AVIAN (birds: crows, rocs, cockatrices, harpies-as-birds)
R({ key: 'avian', aliases: ['bird', 'crow', 'roc', 'cockatrice', 'feathered'], description: 'Feathered fliers. Hops on the ground, flaps/glides in air, dive attacks. Feather chains are spring bones.',
  sizeAxis: 'length', refSize: 0.6, unityAvatar: 'Generic', boneBudget: 40, material: 'feathered',
  bones: fix(sides([B('root', null, [0, 0, 0], [0, -0.15, 0], { deform: false }), B('body', 'root', [0, 0.1, 0.3], [0, -0.1, 0.34]), ...chain('neck', 'body', [0, -0.1, 0.34], [0, -0.2, 0.45], 2), B('head', 'neck_02', [0, -0.2, 0.45], [0, -0.28, 0.46]), B('beak_upper', 'head', [0, -0.28, 0.46], [0, -0.38, 0.44]), B('beak_lower', 'head', [0, -0.27, 0.44], [0, -0.36, 0.43]),
    ...chain('tail_feathers', 'body', [0, 0.1, 0.3], [0, 0.4, 0.28], 2, { spring: true }),
    B('thigh_L', 'body', [0.05, 0.05, 0.28], [0.06, 0.0, 0.16]), B('tarsus_L', 'thigh_L', [0.06, 0.0, 0.16], [0.06, 0.04, 0.03]), B('foot_L', 'tarsus_L', [0.06, 0.04, 0.03], [0.06, -0.04, 0.005]),
    ...wing('wing', 'body', [0.06, -0.06, 0.36], 0.8, false)])),
  ikChains: [{ name: 'leg_L', tip: 'foot_L', chainLength: 2 }, { name: 'leg_R', tip: 'foot_R', chainLength: 2 }],
  springChains: [{ root: 'tail_feathers_01', length: 2, stiffness: 0.4, damping: 0.2, gravity: 0.1 }, { root: 'wing_primaries_01_L', length: 3, stiffness: 0.5, damping: 0.2, gravity: 0.05 }, { root: 'wing_primaries_01_R', length: 3, stiffness: 0.5, damping: 0.2, gravity: 0.05 }],
  hurtboxes: [{ bone: 'head', shape: 'sphere', radius: 0.06, dmgMult: 1.5, partId: 'head' }, { bone: 'body', shape: 'capsule', radius: 0.1, height: 0.3, axis: 'y', dmgMult: 1 }, { bone: 'wing_radius_L', shape: 'capsule', radius: 0.03, height: 0.2, dmgMult: 1.1, partId: 'wing_L' }, { bone: 'wing_radius_R', shape: 'capsule', radius: 0.03, height: 0.2, dmgMult: 1.1, partId: 'wing_R' }],
  breakableParts: [{ partId: 'wing_L', bone: 'wing_radius_L', hpPct: 0.2, materialTag: 'feather', onBreak: 'grounded_hop_only' }, { partId: 'wing_R', bone: 'wing_radius_R', hpPct: 0.2, materialTag: 'feather', onBreak: 'grounded_hop_only' }],
  blendShapes: ['blink', 'beak_open', 'feather_puff'],
  procedural: ['head_stabilize_while_moving', 'look_at_target_head_tilt', 'feather_spring', 'bank_into_turns_in_air'],
  locomotion: { gaits: [{ name: 'hop', froude: 1.5, legFrac: 0.25 }, { name: 'run', froude: 3, legFrac: 0.25 }], fantasyMult: 1.0, turnDegPerSecAt1m: 600, accelG: 1.2, jumpHeightFrac: 0.8, canClimb: false, canSwim: 'surface', canFly: true, hovers: 'brief', flySpeedMult: 3.0 },
  physics: { shapeK: 0.04, ...PHYS.feathered, collider: { type: 'sphere', radiusFrac: 0.2, centerZFrac: 0.33 }, gravityScale: 1.0, linearDrag: 0.5, knockbackResist: 0.05, launchable: true, ragdoll: 'full', deathStyle: 'tumble_feathers_burst' },
  anims: anims(CORE, [C('hop', 16, true, true), C('run', 12, true, true)], FLY, AIRBORNE, [C('peck', 18, false, false, [{ f: 8, e: 'hit_on' }, { f: 10, e: 'hit_off' }]), C('dive_strike', 24, false, true, [{ f: 2, e: 'telegraph' }, { f: 16, e: 'hit_on' }, { f: 20, e: 'hit_off' }]), C('steal_grab', 24, false, true)], ATTACK_SLOTS(3)),
});

// 18 MEMBRANE FLYER (bats, imps with wings)
R({ key: 'membrane_flyer', aliases: ['bat', 'winged_imp', 'gargoyle', 'flying_small'], description: 'Bat-winged fliers: membrane wings on finger bones. Erratic flight, ceiling hang, swoops.',
  sizeAxis: 'length', refSize: 0.5, unityAvatar: 'Generic', boneBudget: 40, material: 'flesh',
  bones: fix(sides([B('root', null, [0, 0, 0], [0, -0.15, 0], { deform: false }), B('body', 'root', [0, 0.1, 0.3], [0, -0.1, 0.32]), B('head', 'body', [0, -0.1, 0.32], [0, -0.2, 0.33]), B('jaw', 'head', [0, -0.15, 0.31], [0, -0.21, 0.3]), ...chain('ear_L', 'head', [0.03, -0.13, 0.35], [0.06, -0.13, 0.43], 1, { spring: true }),
    B('leg_L', 'body', [0.04, 0.08, 0.28], [0.05, 0.18, 0.24]), B('foot_L', 'leg_L', [0.05, 0.18, 0.24], [0.05, 0.22, 0.25]),
    ...wing('wing', 'body', [0.05, -0.06, 0.33], 1.0, true)])),
  ikChains: [],
  springChains: [{ root: 'ear_01_L', length: 1, stiffness: 0.6, damping: 0.2, gravity: 0 }, { root: 'ear_01_R', length: 1, stiffness: 0.6, damping: 0.2, gravity: 0 }],
  hurtboxes: [{ bone: 'body', shape: 'sphere', radius: 0.12, dmgMult: 1 }, { bone: 'head', shape: 'sphere', radius: 0.06, dmgMult: 1.5, partId: 'head' }, { bone: 'wing_radius_L', shape: 'capsule', radius: 0.02, height: 0.25, dmgMult: 1.2, partId: 'wing_L' }, { bone: 'wing_radius_R', shape: 'capsule', radius: 0.02, height: 0.25, dmgMult: 1.2, partId: 'wing_R' }],
  breakableParts: [{ partId: 'wing_L', bone: 'wing_radius_L', hpPct: 0.15, materialTag: 'feather', onBreak: 'crash_grounded' }],
  blendShapes: ['mouth_open', 'screech'],
  procedural: ['erratic_flight_noise', 'ceiling_hang_flip', 'wing_membrane_cloth', 'bank_into_turns_in_air'],
  locomotion: { gaits: [{ name: 'crawl', froude: 0.3, legFrac: 0.15 }], fantasyMult: 1.0, turnDegPerSecAt1m: 720, accelG: 1.5, jumpHeightFrac: 0.3, canClimb: 'walls_and_ceilings', canSwim: false, canFly: true, hovers: true, flySpeedMult: 4.0 },
  physics: { shapeK: 0.02, ...PHYS.flesh, collider: { type: 'sphere', radiusFrac: 0.18, centerZFrac: 0.3 }, gravityScale: 0.8, linearDrag: 0.6, knockbackResist: 0.05, launchable: true, ragdoll: 'full', deathStyle: 'flutter_fall' },
  anims: anims(CORE.filter(c => !/turn/.test(c.name)), FLY, [C('crawl', 30, true, true), C('ceiling_hang', 90, true, false), C('swoop', 30, false, true, [{ f: 4, e: 'telegraph' }, { f: 18, e: 'hit_on' }, { f: 22, e: 'hit_off' }]), C('screech', 40, false, false, [{ f: 8, e: 'vocal' }, { f: 10, e: 'hit_on' }])], ATTACK_SLOTS(3)),
});

// 19 WYVERN (bipedal + wing-arms)
R({ key: 'wyvern', aliases: ['wyvern', 'drake_winged', 'pterosaur'], description: 'Two legs + wings that double as front limbs (walks on wing-knuckles). Lighter and faster than dragons.',
  sizeAxis: 'length', refSize: 6, unityAvatar: 'Generic', boneBudget: 70, material: 'scaled',
  bones: fix(sides([B('root', null, [0, 0, 0], [0, -0.15, 0], { deform: false }), B('pelvis', 'root', [0, 0.15, 0.3], [0, 0.05, 0.32]), B('spine_01', 'pelvis', [0, 0.05, 0.32], [0, -0.08, 0.36]), B('chest', 'spine_01', [0, -0.08, 0.36], [0, -0.16, 0.38]),
    ...chain('neck', 'chest', [0, -0.16, 0.38], [0, -0.36, 0.5], 4), B('head', 'neck_04', [0, -0.36, 0.5], [0, -0.48, 0.49]), B('jaw', 'head', [0, -0.39, 0.48], [0, -0.48, 0.46]),
    B('thigh_L', 'pelvis', [0.06, 0.15, 0.3], [0.07, 0.08, 0.17]), B('calf_L', 'thigh_L', [0.07, 0.08, 0.17], [0.07, 0.16, 0.06]), B('foot_L', 'calf_L', [0.07, 0.16, 0.06], [0.07, 0.08, 0.01]),
    ...chain('tail', 'pelvis', [0, 0.15, 0.3], [0, 0.95, 0.22], 8), ...wing('wing', 'chest', [0.05, -0.12, 0.38], 0.75, true)])),
  ikChains: [{ name: 'leg_L', tip: 'foot_L', chainLength: 2 }, { name: 'leg_R', tip: 'foot_R', chainLength: 2 }, { name: 'wingwalk_L', tip: 'wing_hand_L', chainLength: 2 }, { name: 'wingwalk_R', tip: 'wing_hand_R', chainLength: 2 }, { name: 'neck_aim', tip: 'head', chainLength: 4, type: 'aim' }],
  springChains: [{ root: 'tail_03', length: 6, stiffness: 0.3, damping: 0.2, gravity: 0.15 }],
  hurtboxes: [{ bone: 'head', shape: 'sphere', radius: 0.05, dmgMult: 1.5, partId: 'head' }, { bone: 'chest', shape: 'sphere', radius: 0.09, dmgMult: 1 }, { bone: 'wing_radius_L', shape: 'capsule', radius: 0.025, height: 0.25, dmgMult: 1.1, partId: 'wing_L' }, { bone: 'wing_radius_R', shape: 'capsule', radius: 0.025, height: 0.25, dmgMult: 1.1, partId: 'wing_R' }, { bone: 'tail_05', shape: 'capsule', radius: 0.02, height: 0.1, dmgMult: 1, partId: 'tail' }],
  breakableParts: [{ partId: 'wing_L', bone: 'wing_radius_L', hpPct: 0.18, materialTag: 'scale', onBreak: 'grounded_cannot_fly' }, { partId: 'wing_R', bone: 'wing_radius_R', hpPct: 0.18, materialTag: 'scale', onBreak: 'grounded_cannot_fly' }, { partId: 'tail', bone: 'tail_05', hpPct: 0.2, materialTag: 'stinger', onBreak: 'no_tail_sting' }],
  blendShapes: ['roar', 'blink'],
  procedural: ['neck_aim_ik', 'wingwalk_ik', 'tail_counterbalance', 'bank_into_turns_in_air', 'footstep_camera_shake'],
  locomotion: { gaits: [{ name: 'wingwalk', froude: 0.4, legFrac: 0.3 }, { name: 'run', froude: 1.8, legFrac: 0.3 }], fantasyMult: 1.0, turnDegPerSecAt1m: 600, accelG: 0.6, jumpHeightFrac: 0.4, canClimb: 'cliffs', canSwim: false, canFly: true, hovers: true, flySpeedMult: 2.8 },
  physics: { shapeK: 0.004, ...PHYS.scaled, collider: { type: 'capsule', axis: 'y', radiusFrac: 0.08, heightFrac: 0.5 }, gravityScale: 1.0, linearDrag: 0.05, knockbackResist: 0.8, launchable: false, ragdoll: 'partial', deathStyle: 'crash_slide' },
  anims: anims(CORE, [C('wingwalk', 30, true, true), C('run', 20, true, true)], FLY, [C('tail_sting', 30, false, false, [{ f: 6, e: 'telegraph' }, { f: 18, e: 'hit_on' }, { f: 21, e: 'hit_off' }]), C('dive_grab', 30, false, true)], ATTACK_SLOTS(6)),
});

// 20 SPIRIT FLOAT (wisps, ghosts, elementals, fairies-as-spirits)
R({ key: 'spirit_float', aliases: ['wisp', 'ghost', 'spirit', 'elemental', 'wraith', 'phantom', 'fairy', 'floating'], description: 'Legless floating beings. No gravity, motion from noise curves; a trailing tail chain made of VFX. Phases through thin walls (Menace 4+).',
  sizeAxis: 'height', refSize: 1.0, unityAvatar: 'Generic', boneBudget: 20, material: 'spirit',
  bones: fix(sides([B('root', null, [0, 0, 0], [0, -0.15, 0], { deform: false }), B('core', 'root', [0, 0, 0.5], [0, 0, 0.62]), B('upper', 'core', [0, 0, 0.62], [0, 0, 0.8]), B('head', 'upper', [0, 0, 0.8], [0, 0, 1.0]),
    B('arm_L', 'upper', [0.08, 0, 0.75], [0.25, -0.05, 0.6], { spring: true }), B('hand_L', 'arm_L', [0.25, -0.05, 0.6], [0.32, -0.08, 0.55], { spring: true }),
    ...chain('trail', 'core', [0, 0.02, 0.5], [0, 0.15, 0.05], 4, { spring: true })])),
  ikChains: [],
  springChains: [{ root: 'trail_01', length: 4, stiffness: 0.15, damping: 0.1, gravity: -0.05 }, { root: 'arm_L', length: 2, stiffness: 0.2, damping: 0.15, gravity: 0 }, { root: 'arm_R', length: 2, stiffness: 0.2, damping: 0.15, gravity: 0 }],
  hurtboxes: [{ bone: 'core', shape: 'sphere', radius: 0.14, dmgMult: 1.5, partId: 'core' }, { bone: 'upper', shape: 'sphere', radius: 0.16, dmgMult: 1 }],
  breakableParts: [],
  blendShapes: ['face_wail', 'face_smile', 'fade'],
  procedural: ['hover_noise_bob', 'trail_spring', 'face_camera_partial', 'phase_flicker_when_hit', 'light_intensity_pulse'],
  locomotion: { gaits: [{ name: 'drift', froude: 0.3, legFrac: 0.5 }, { name: 'dash', froude: 6, legFrac: 0.5 }], fantasyMult: 1.0, turnDegPerSecAt1m: 720, accelG: 0.8, jumpHeightFrac: 0, canClimb: false, canSwim: 'passes_through', canFly: true, hovers: true, hoverHeightFrac: 0.3, flySpeedMult: 1 },
  physics: { shapeK: 0.1, ...PHYS.spirit, collider: { type: 'sphere', radiusFrac: 0.25, centerZFrac: 0.6 }, gravityScale: 0, linearDrag: 1.5, knockbackResist: 0, launchable: 'floats_up', ragdoll: 'none', deathStyle: 'dissolve_into_motes' },
  anims: anims(CORE.filter(c => !/turn|knockdown|getup|sleep|eat/.test(c.name)), [C('drift', 60, true, true), C('dash', 12, false, true), C('phase_out', 20, false, false), C('phase_in', 20, false, false), C('cast_orb', 36, false, false, [{ f: 6, e: 'telegraph' }, { f: 22, e: 'hit_on' }])], ATTACK_SLOTS(3)),
});

// 21 PLANT ROOTED
R({ key: 'plant_rooted', aliases: ['plant', 'man_eater_plant', 'vine', 'flower_monster', 'tree_ambush'], description: 'Rooted plants that attack in place: man-eating flowers, vine traps, ambush trees. Can uproot to relocate slowly.',
  sizeAxis: 'height', refSize: 2.0, unityAvatar: 'Generic', boneBudget: 40, material: 'wood',
  bones: fix(sides([B('root', null, [0, 0, 0], [0, -0.15, 0], { deform: false }), ...chain('stem', 'root', [0, 0, 0], [0, -0.05, 0.75], 4), B('bulb', 'stem_04', [0, -0.05, 0.75], [0, -0.15, 0.9]), B('jaw_upper', 'bulb', [0, -0.1, 0.85], [0, -0.3, 0.95]), B('jaw_lower', 'bulb', [0, -0.1, 0.82], [0, -0.3, 0.75]),
    ...chain('petal_L', 'bulb', [0.05, -0.1, 0.88], [0.25, -0.1, 1.0], 2, { spring: true }),
    ...chain('vine_L', 'stem_01', [0.04, 0, 0.1], [0.6, -0.3, 0.3], 6), ...chain('root_tendril_L', 'root', [0.04, 0, 0.02], [0.4, 0.1, 0], 3)])),
  ikChains: [{ name: 'vine_L', tip: 'vine_06_L', chainLength: 6, type: 'fabrik_reach' }, { name: 'vine_R', tip: 'vine_06_R', chainLength: 6, type: 'fabrik_reach' }],
  springChains: [{ root: 'petal_01_L', length: 2, stiffness: 0.4, damping: 0.2, gravity: 0.2 }, { root: 'petal_01_R', length: 2, stiffness: 0.4, damping: 0.2, gravity: 0.2 }, { root: 'stem_02', length: 3, stiffness: 0.6, damping: 0.3, gravity: 0 }],
  hurtboxes: [{ bone: 'bulb', shape: 'sphere', radius: 0.15, dmgMult: 1.6, partId: 'bulb' }, { bone: 'stem_02', shape: 'capsule', radius: 0.07, height: 0.3, dmgMult: 0.8 }, { bone: 'vine_03_L', shape: 'capsule', radius: 0.03, height: 0.2, dmgMult: 1, partId: 'vine_L' }, { bone: 'vine_03_R', shape: 'capsule', radius: 0.03, height: 0.2, dmgMult: 1, partId: 'vine_R' }],
  breakableParts: [{ partId: 'vine_L', bone: 'vine_03_L', hpPct: 0.15, materialTag: 'sap', onBreak: 'lose_grab_reach' }, { partId: 'vine_R', bone: 'vine_03_R', hpPct: 0.15, materialTag: 'sap', onBreak: 'lose_grab_reach' }, { partId: 'bulb', bone: 'bulb', hpPct: 0.3, materialTag: 'seed', onBreak: 'stun_long' }],
  blendShapes: ['jaw_open', 'petals_close'],
  procedural: ['wind_sway', 'vine_fabrik_reach_to_target', 'bulb_track_target', 'dormant_disguise_pose'],
  locomotion: { gaits: [{ name: 'uproot_crawl', froude: 0.05, legFrac: 0.2 }], fantasyMult: 1.0, turnDegPerSecAt1m: 180, accelG: 0.2, jumpHeightFrac: 0, canClimb: false, canSwim: false, canFly: false, hovers: false, stationary: true },
  physics: { shapeK: 0.03, ...PHYS.wood, collider: { type: 'capsule', radiusFrac: 0.12, heightFrac: 0.9 }, gravityScale: 1, linearDrag: 1, knockbackResist: 1.0, launchable: false, ragdoll: 'none', deathStyle: 'wilt_collapse' },
  anims: anims(CORE.filter(c => !/turn|flee|knockdown|getup|sleep/.test(c.name)), [C('dormant', 120, true, false), C('awaken', 40, false, false, [{ f: 10, e: 'vocal' }]), C('vine_lash', 30, false, false, [{ f: 4, e: 'telegraph' }, { f: 16, e: 'hit_on' }, { f: 20, e: 'hit_off' }]), C('vine_grab_pull', 50, false, false), C('chomp', 24, false, false, [{ f: 10, e: 'hit_on' }, { f: 13, e: 'hit_off' }]), C('uproot', 60, false, false), C('uproot_crawl', 60, true, true)], ATTACK_SLOTS(4)),
});

// 22 AQUATIC (fish, sharks, piranhas)
R({ key: 'aquatic', aliases: ['fish', 'shark', 'piranha', 'sea_beast'], description: 'Fish-like swimmers. Body-wave swimming (carangiform), leap attacks out of water, flops on land.',
  sizeAxis: 'length', refSize: 1.5, unityAvatar: 'Generic', boneBudget: 24, material: 'scaled',
  bones: fix(sides([B('root', null, [0, 0, 0], [0, -0.15, 0], { deform: false }), B('head', 'root', [0, -0.25, 0.2], [0, -0.5, 0.2]), B('jaw', 'head', [0, -0.35, 0.17], [0, -0.5, 0.15]), ...chain('spine', 'head', [0, -0.25, 0.2], [0, 0.4, 0.2], 6), B('tail_fin', 'spine_06', [0, 0.4, 0.2], [0, 0.5, 0.2], { spring: true }), B('dorsal_fin', 'spine_02', [0, -0.05, 0.3], [0, 0.05, 0.4], { spring: true }), B('pectoral_L', 'head', [0.07, -0.25, 0.16], [0.18, -0.15, 0.12], { spring: true })])),
  ikChains: [{ name: 'body_wave', tip: 'spine_06', chainLength: 6, type: 'sine_wave' }],
  springChains: [{ root: 'tail_fin', length: 1, stiffness: 0.3, damping: 0.2, gravity: 0 }, { root: 'dorsal_fin', length: 1, stiffness: 0.5, damping: 0.2, gravity: 0 }, { root: 'pectoral_L', length: 1, stiffness: 0.5, damping: 0.2, gravity: 0 }, { root: 'pectoral_R', length: 1, stiffness: 0.5, damping: 0.2, gravity: 0 }],
  hurtboxes: [{ bone: 'head', shape: 'sphere', radius: 0.1, dmgMult: 1.4, partId: 'head' }, { bone: 'spine_03', shape: 'capsule', radius: 0.12, height: 0.4, axis: 'y', dmgMult: 1 }],
  breakableParts: [{ partId: 'fin', bone: 'dorsal_fin', hpPct: 0.15, materialTag: 'fish_scale', onBreak: 'slower_turns' }],
  blendShapes: ['jaw_open', 'gill_flare'],
  procedural: ['sine_wave_spine_by_speed', 'buoyancy_bob', 'flop_on_land', 'school_boids_optional'],
  locomotion: { gaits: [{ name: 'swim', froude: 1.0, legFrac: 0.3 }, { name: 'burst', froude: 6, legFrac: 0.3 }], fantasyMult: 1.0, turnDegPerSecAt1m: 400, accelG: 1.0, jumpHeightFrac: 1.0, canClimb: false, canSwim: true, canFly: false, hovers: false, waterOnly: true },
  physics: { shapeK: 0.02, ...PHYS.scaled, collider: { type: 'capsule', axis: 'y', radiusFrac: 0.12, heightFrac: 0.9 }, gravityScale: 1, buoyancy: 1.0, linearDrag: 1.0, knockbackResist: 0.3, launchable: true, ragdoll: 'chain_physics', deathStyle: 'float_belly_up' },
  anims: anims(CORE.filter(c => !/turn|walk|getup|knockdown|sleep|eat/.test(c.name)), [C('swim', 30, true, true), C('burst', 12, false, true), C('leap_bite', 30, false, true, [{ f: 4, e: 'telegraph' }, { f: 16, e: 'hit_on' }, { f: 20, e: 'hit_off' }]), C('flop_land', 20, true, false)], ATTACK_SLOTS(3)),
});

// 23 TENTACLED (krakens, octopi, jellyfish, mind-flayer-ish blobs)
R({ key: 'tentacled', aliases: ['kraken', 'octopus', 'squid', 'jellyfish', 'tentacle', 'cephalopod'], description: 'Mantle + 8 tentacles (6 bones each). Tentacles are FABRIK chains that reach for targets; ink and grab attacks.',
  sizeAxis: 'length', refSize: 3, unityAvatar: 'Generic', boneBudget: 60, material: 'flesh',
  bones: fix([B('root', null, [0, 0, 0], [0, -0.15, 0], { deform: false }), B('mantle', 'root', [0, 0.05, 0.3], [0, 0.4, 0.55]), B('head', 'mantle', [0, 0, 0.28], [0, -0.1, 0.28]), B('eye_L', 'head', [0.08, -0.08, 0.3], [0.08, -0.12, 0.3], { deform: false }), B('eye_R', 'head', [-0.08, -0.08, 0.3], [-0.08, -0.12, 0.3], { deform: false }),
    ...Array.from({ length: 8 }, (_, i) => { const a = (i / 8) * Math.PI * 2; return chain(`tentacle${i + 1}`, 'head', [Math.cos(a) * 0.06, -0.05 + Math.sin(a) * 0.06, 0.22], [Math.cos(a) * 0.6, -0.05 + Math.sin(a) * 0.6, 0.02], 6); }).flat()]),
  ikChains: Array.from({ length: 8 }, (_, i) => ({ name: `tentacle${i + 1}`, tip: `tentacle${i + 1}_06`, chainLength: 6, type: 'fabrik_reach' })),
  springChains: Array.from({ length: 8 }, (_, i) => ({ root: `tentacle${i + 1}_03`, length: 4, stiffness: 0.2, damping: 0.15, gravity: 0.1 })),
  hurtboxes: [{ bone: 'head', shape: 'sphere', radius: 0.12, dmgMult: 1.4, partId: 'head' }, { bone: 'mantle', shape: 'capsule', radius: 0.14, height: 0.4, dmgMult: 1 }, ...[1, 3, 5, 7].map(i => ({ bone: `tentacle${i}_03`, shape: 'capsule', radius: 0.03, height: 0.15, dmgMult: 1, partId: `tentacle${i}` }))],
  breakableParts: [1, 3, 5, 7].map(i => ({ partId: `tentacle${i}`, bone: `tentacle${i}_03`, hpPct: 0.1, materialTag: 'ink_sac', onBreak: 'tentacle_severed_regrows_later' })),
  blendShapes: ['mantle_pulse', 'eye_narrow', 'beak_open'],
  procedural: ['tentacle_fabrik_reach', 'tentacle_idle_curl_noise', 'mantle_jet_pulse', 'color_shift_skin'],
  locomotion: { gaits: [{ name: 'tentacle_crawl', froude: 0.2, legFrac: 0.3 }, { name: 'jet', froude: 4, legFrac: 0.3 }], fantasyMult: 1.0, turnDegPerSecAt1m: 300, accelG: 0.6, jumpHeightFrac: 0, canClimb: 'walls_slow', canSwim: true, canFly: false, hovers: false },
  physics: { shapeK: 0.02, ...PHYS.flesh, collider: { type: 'sphere', radiusFrac: 0.2, centerZFrac: 0.3 }, gravityScale: 1, buoyancy: 1.0, linearDrag: 0.8, knockbackResist: 0.7, launchable: false, ragdoll: 'chain_physics', deathStyle: 'sink_limp' },
  anims: anims(CORE.filter(c => !/turn/.test(c.name)), [C('tentacle_crawl', 40, true, true), C('jet', 20, false, true), C('ink_cloud', 30, false, false, [{ f: 10, e: 'vfx' }]), C('tentacle_slam', 36, false, false, [{ f: 6, e: 'telegraph' }, { f: 22, e: 'hit_on' }, { f: 25, e: 'hit_off' }]), C('grab_squeeze_loop', 40, true, false)], ATTACK_SLOTS(5)),
});

// 24 SWARM
R({ key: 'swarm', aliases: ['swarm', 'hive', 'locust', 'bat_swarm', 'pixie_swarm'], description: 'A cloud of tiny units acting as one monster. One controller bone; units are GPU-instanced (VFX Graph or particle system) with boid rules. HP shown as density.',
  sizeAxis: 'height', refSize: 3, unityAvatar: 'Generic', boneBudget: 3, material: 'swarm',
  bones: fix([B('root', null, [0, 0, 0], [0, -0.15, 0], { deform: false }), B('center', 'root', [0, 0, 0.5], [0, 0, 0.6], { deform: false }), B('lead', 'center', [0, -0.3, 0.5], [0, -0.4, 0.5], { deform: false })]),
  hurtboxes: [{ bone: 'center', shape: 'sphere', radius: 0.4, dmgMult: 1, note: 'radius shrinks with HP' }],
  procedural: ['boids_cohesion_alignment_separation', 'shape_morph_targets (sphere, wall, funnel, arrow)', 'density_from_hp', 'aoe_damage_preferred'],
  locomotion: { gaits: [{ name: 'drift', froude: 0.5, legFrac: 0.5 }, { name: 'surge', froude: 4, legFrac: 0.5 }], fantasyMult: 1.0, turnDegPerSecAt1m: 720, accelG: 1.0, jumpHeightFrac: 0, canClimb: false, canSwim: false, canFly: true, hovers: true, hoverHeightFrac: 0.3 },
  physics: { shapeK: 0.001, ...PHYS.swarm, collider: { type: 'sphere', radiusFrac: 0.4, centerZFrac: 0.5 }, gravityScale: 0, linearDrag: 2, knockbackResist: 1, launchable: false, ragdoll: 'none', deathStyle: 'scatter_and_fall' },
  anims: [C('form_shape', 30, false, false), C('surge_attack', 40, false, true, [{ f: 6, e: 'telegraph' }, { f: 20, e: 'hit_on' }, { f: 34, e: 'hit_off' }]), C('engulf_loop', 40, true, false, [{ f: 0, e: 'hit_on' }])],
  unitRig: { note: 'Each unit: 1–3 bones (body + 2 wings) animated by vertex shader flutter, not bones', unitsMin: 30, unitsMax: 400 },
});

// 25 AMORPHOUS HORROR (mimics, flesh horrors, menace-5 things)
R({ key: 'amorphous', aliases: ['horror', 'mimic', 'aberration', 'flesh_horror', 'shapeshifter', 'aberrant'], description: 'Menace-5 bodies that break symmetry: a core with 6 procedural limbs that can reattach, a mimic socket that copies other rigs\' silhouettes. Audio-first reveals.',
  sizeAxis: 'height', refSize: 2.0, unityAvatar: 'Generic', boneBudget: 64, material: 'flesh',
  bones: fix([B('root', null, [0, 0, 0], [0, -0.15, 0], { deform: false }), B('core', 'root', [0, 0, 0.4], [0, 0, 0.7]), B('mass_upper', 'core', [0, 0, 0.7], [0, -0.05, 0.95], { spring: true }), B('maw', 'core', [0, -0.2, 0.6], [0, -0.35, 0.55]), B('mimic_socket', 'core', [0, -0.1, 0.8], [0, -0.15, 0.8], { deform: false }),
    ...Array.from({ length: 6 }, (_, i) => { const a = (i / 6) * Math.PI * 2 + 0.3; return chain(`limb${i + 1}`, 'core', [Math.cos(a) * 0.1, Math.sin(a) * 0.1, 0.5], [Math.cos(a) * 0.55, Math.sin(a) * 0.55, (i % 2) ? 0.0 : 0.9], 5); }).flat(),
    ...Array.from({ length: 4 }, (_, i) => B(`eye_${i + 1}`, 'mass_upper', [Math.sin(i * 1.7) * 0.15, -0.2, 0.75 + i * 0.05], [Math.sin(i * 1.7) * 0.15, -0.24, 0.75 + i * 0.05], { deform: false }))]),
  ikChains: Array.from({ length: 6 }, (_, i) => ({ name: `limb${i + 1}`, tip: `limb${i + 1}_05`, chainLength: 5, type: 'fabrik_reach', procedural: true })),
  springChains: [{ root: 'mass_upper', length: 1, stiffness: 0.2, damping: 0.2, gravity: 0.3 }],
  hurtboxes: [{ bone: 'core', shape: 'sphere', radius: 0.2, dmgMult: 1 }, { bone: 'maw', shape: 'sphere', radius: 0.08, dmgMult: 1.8, partId: 'maw' }, ...[1, 2, 3, 4].map(i => ({ bone: `eye_${i}`, shape: 'sphere', radius: 0.03, dmgMult: 2.0, partId: `eye_${i}` }))],
  breakableParts: [1, 2, 3, 4].map(i => ({ partId: `eye_${i}`, bone: `eye_${i}`, hpPct: 0.06, materialTag: 'eye_of_nothing', onBreak: 'blind_side_' + i })),
  blendShapes: ['maw_open_wide', 'skin_ripple', 'face_emerge'],
  procedural: ['asymmetric_limb_timing', 'limbs_procedural_walk_any_count', 'mimic_silhouette_swap', 'stop_motion_stepping', 'eyes_open_sequentially', 'copy_target_walk_cycle'],
  locomotion: { gaits: [{ name: 'lurch', froude: 0.15, legFrac: 0.4 }, { name: 'skitter', froude: 5, legFrac: 0.4 }], fantasyMult: 1.0, turnDegPerSecAt1m: 500, accelG: 1.5, jumpHeightFrac: 0.8, canClimb: 'walls_and_ceilings', canSwim: true, canFly: false, hovers: false },
  physics: { shapeK: 0.03, ...PHYS.flesh, collider: { type: 'sphere', radiusFrac: 0.3, centerZFrac: 0.4 }, gravityScale: 1.2, linearDrag: 0.2, knockbackResist: 0.6, launchable: false, ragdoll: 'chain_physics', deathStyle: 'collapse_and_melt' },
  anims: anims(CORE, [C('lurch', 48, true, true), C('skitter', 14, true, true), C('unfold_reveal', 90, false, false, [{ f: 10, e: 'vocal' }, { f: 60, e: 'vfx' }]), C('mimic_idle', 90, true, false), C('ceiling_drop', 24, false, false, [{ f: 18, e: 'land' }])], ATTACK_SLOTS(5)),
});

// ---------- validate & write ----------
for (const r of RIGS) {
  const names = new Set();
  for (const b of r.bones) {
    if (names.has(b.name)) throw new Error(`${r.key}: duplicate bone ${b.name}`);
    if (b.parent && !r.bones.some(x => x.name === b.parent)) throw new Error(`${r.key}: ${b.name} has unknown parent ${b.parent}`);
    names.add(b.name);
  }
  for (const h of r.hurtboxes) if (!names.has(h.bone)) throw new Error(`${r.key}: hurtbox on unknown bone ${h.bone}`);
  for (const p of r.breakableParts) if (!names.has(p.bone)) throw new Error(`${r.key}: part on unknown bone ${p.bone}`);
  for (const c of r.springChains) if (!names.has(c.root)) throw new Error(`${r.key}: spring root unknown ${c.root}`);
  for (const c of r.ikChains) if (!names.has(c.tip)) throw new Error(`${r.key}: IK tip unknown ${c.tip}`);
  r.boneCount = r.bones.length;
  if (r.boneCount > r.boneBudget * 1.3) throw new Error(`${r.key}: ${r.boneCount} bones exceeds budget ${r.boneBudget}`);
  r.hurtboxes.forEach(h => { if (h.partId === undefined) delete h.partId; });
}
fs.mkdirSync(path.dirname(OUT), { recursive: true });
fs.writeFileSync(OUT, JSON.stringify({ version: 1, coordinates: 'Blender: Z up, creature faces -Y, +X = creature left. Normalized so the reference dimension = 1.0', fps: 30, rigs: RIGS }, null, 1) + '\n');
console.log(`rigs.json: ${RIGS.length} rigs · ` + RIGS.map(r => `${r.key}(${r.boneCount})`).join(' '));
