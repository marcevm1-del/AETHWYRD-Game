// Validator rules for Data/Characters/locomotion_clips.json (written by Tools/blender/build_locomotion_clips.py).
// The manifest is the record of what the Blender clip set measured; this check fails when it is missing, when a clip the
// controller needs is absent, when a lengths/loop/speed promise in 13_Production/animation_clips_required.md is broken,
// or when a gait slid its feet. It does not (and cannot) check the FBX files, which are local and gitignored.
// Called from validate.js. A missing manifest is reported, never skipped.
const fs = require('fs');
const path = require('path');

const NEEDED = {
  Idle: { loop: true }, Walk: { loop: true, speed: 2.2 }, Run: { loop: true, speed: 6.5 }, Sprint: { loop: true, speed: 9.5 },
  JumpStart: { loop: false }, Fall: { loop: true }, Land: { loop: false }, Dodge: { loop: false },
};
const MAX_SLIDE_PCT = 3.0;

function run({ DATA, load, err }) {
  locomotion({ DATA, load, err });
  combat({ DATA, load, err });
  riders({ DATA, load, err });
}

function locomotion({ DATA, load, err }) {
  const f = 'Characters/locomotion_clips.json', w = 'locomotion_clips.json';
  if (!fs.existsSync(path.join(DATA, f))) { err(w, 'file missing (run Tools/blender/build_locomotion_clips.py)'); return; }
  const m = load(f);
  if (m.schema !== 'locomotion_clips/1') err(w, 'unknown schema ' + m.schema);
  if (m.rigContract !== 'human_v1') err(w, 'rigContract must be human_v1');
  const by = new Map((m.clips || []).map(c => [c.name, c]));
  if (by.size !== (m.clips || []).length) err(w, 'duplicate clip name');
  for (const [name, want] of Object.entries(NEEDED)) {
    const c = by.get(name);
    if (!c) { err(w, `missing clip ${name}`); continue; }
    if (c.loop !== want.loop) err(w, `${name}: loop must be ${want.loop}`);
    if (!(c.frames > 0) || !(c.fps > 0)) err(w, `${name}: frames and fps must be positive`);
    else if (Math.abs(c.frames / c.fps - c.seconds) > 1e-3) err(w, `${name}: seconds ${c.seconds} does not match frames/fps`);
    if (c.rootMotion !== false) err(w, `${name}: clips are in place (rootMotion false)`);
    if (want.speed !== undefined) {
      if (c.designSpeedMps !== want.speed) err(w, `${name}: designSpeedMps must be ${want.speed} (the blend-tree threshold)`);
      const sl = c.metrics && c.metrics.footSlideMeanPct;
      if (typeof sl !== 'number') err(w, `${name}: footSlideMeanPct not measured`);
      else if (sl > MAX_SLIDE_PCT) err(w, `${name}: feet slide ${sl} % (max ${MAX_SLIDE_PCT})`);
    }
    if (c.loop && !(c.metrics && c.metrics.loopClosureM <= 1e-3)) err(w, `${name}: loop does not close`);
    if (!(c.metrics && c.metrics.minBoneZ >= -0.02)) err(w, `${name}: a bone goes under the floor`);
  }
  // the dodge clip must be exactly the dodge window (combat_tuning.json is canonical; the clip changes with it)
  const dodge = by.get('Dodge'), tuning = load('Combat/combat_tuning.json');
  const dur = tuning.dodge && tuning.dodge.durationSec;
  if (dodge && dur !== undefined && Math.abs(dodge.seconds - dur) > 1e-6) err(w, `Dodge is ${dodge.seconds} s but combat_tuning.json dodge.durationSec is ${dur}`);
  for (const c of m.crossCheck || []) {
    if (typeof c.footSlideMeanPct === 'number' && c.footSlideMeanPct > MAX_SLIDE_PCT) err(w, `${c.name} on ${c.body}: feet slide ${c.footSlideMeanPct} %`);
  }
  if (!(m.crossCheck || []).length) err(w, 'crossCheck is empty: the clips were not measured on a second body');
}

// ---- combat clip sets (Data/Characters/combat_clips.json, written by Tools/blender/build_combat_clips.py) -------------------------
// Attack clips are exactly startup + active + recovery of their hit weight, with the four events on exact frames, and the manifest records
// the attackTiming block it was built from, so a tuning change that is not followed by a rebuild fails here. The weapon coverage is derived
// from Data/Items/items.json weaponType and every Data/Classes weapon list: a weapon without a family cannot ship by being left off a list.
const crypto = require('crypto');
const SPECIAL = { HeavyRelease: 'heavy', Riposte: 'heavy', Launcher: 'launch', Slam: 'heavy', SkillCast: 'medium' };
const FIXED = ['Ready', 'Charge', ...Object.keys(SPECIAL)];

function combat({ DATA, load, err }) {
  const f = 'Characters/combat_clips.json', w = 'combat_clips.json';
  if (!fs.existsSync(path.join(DATA, f))) { err(w, 'file missing (run Tools/blender/build_combat_clips.py)'); return; }
  const m = load(f), tuning = load('Combat/combat_tuning.json').attackTiming;
  if (m.schema !== 'combat_clips/1') err(w, 'unknown schema ' + m.schema);
  const hash = crypto.createHash('sha1').update(stable(tuning)).digest('hex').slice(0, 12);
  // the same canonical form as Python's json.dumps(sort_keys=True) (default separators), see stable()
  if (m.tuning.hash !== hash) err(w, `attackTiming changed since the clips were built (manifest ${m.tuning.hash}, now ${hash}): rebuild with build_combat_clips.py`);
  for (const wt of ['light', 'medium', 'heavy', 'launch']) {
    const a = m.tuning.windows[wt], b = tuning[wt];
    if (!a || a.startupSec !== b.startupSec || a.activeSec !== b.activeSec || a.recoverySec !== b.recoverySec) err(w, `window ${wt} differs from combat_tuning.json`);
  }
  const fps = m.fps, near = x => Math.abs(x - Math.round(x)) < 1e-6;
  for (const wt of ['light', 'medium', 'heavy', 'launch']) for (const k of ['startupSec', 'activeSec', 'recoverySec']) if (!near(tuning[wt][k] * fps)) err(w, `${wt}.${k} is not a whole number of frames at ${fps} fps`);
  const families = new Map((m.families || []).map(x => [x.id, x]));
  // weapon coverage, derived
  const weapons = new Set();
  for (const it of load('Items/items.json')) if (it.weaponType) weapons.add(it.weaponType);
  const classes = load('Classes/classes.json');
  for (const c of Array.isArray(classes) ? classes : classes.classes) for (const wp of c.weapons || []) weapons.add(wp);
  for (const wp of weapons) if (!(wp in (m.weaponToFamily || {}))) err(w, `weapon "${wp}" has no combat family`);
  for (const [wp, fam] of Object.entries(m.weaponToFamily || {})) if (!families.has(fam)) err(w, `weapon "${wp}" maps to unknown family ${fam}`);
  for (const fam of families.values()) {
    const names = new Map(fam.clips.map(c => [c.name, c]));
    for (const n of FIXED) if (!names.has(n)) err(w, `${fam.id}: missing clip ${n}`);
    for (let i = 1; i <= fam.hitCount; i++) if (!names.has('Hit' + i)) err(w, `${fam.id}: missing clip Hit${i}`);
    for (const c of fam.clips) {
      const id = `${fam.id}/${c.name}`;
      if (Math.abs(c.frames / c.fps - c.seconds) > 1e-3) err(w, `${id}: seconds does not match frames/fps`);
      if (c.fps !== fps) err(w, `${id}: fps ${c.fps} differs from the set's ${fps}`);
      if (c.metrics.minBoneZ < -0.02) err(w, `${id}: a bone goes under the floor`);
      if (c.name === 'Ready' || c.name === 'Charge') { if (!c.loop || !(c.metrics.loopClosureM <= 1e-3)) err(w, `${id}: loop does not close`); continue; }
      const wt = SPECIAL[c.name] || (c.weight);
      const win = tuning[wt];
      if (!win) { err(w, `${id}: unknown weight ${wt}`); continue; }
      const want = Math.round((win.startupSec + win.activeSec + win.recoverySec) * fps);
      if (c.frames !== want) err(w, `${id}: ${c.frames} frames, ${wt} windows make ${want}`);
      const ev = c.events || {};
      if (ev.ActiveBegin !== Math.round(win.startupSec * fps) || ev.ActiveEnd !== Math.round((win.startupSec + win.activeSec) * fps) || ev.RecoveryEnd !== want || ev.StartupEnd !== ev.ActiveBegin) err(w, `${id}: events do not match the ${wt} windows`);
      if (!(c.metrics.handTravelM >= 0.2)) err(w, `${id}: wind-up does not travel to the contact pose (telegraph)`);
    }
  }
}


// ---- rider pose clips (Data/Characters/rider_clips.json, written by Tools/blender/build_rider_clips.py) ---------------------------------
// Families, species and rigs are derived from Data/Companions/mounts.json and Data/Monsters/species.json: a mount family without rider clips,
// or a mount species whose rig has no saddle anchor, fails here. Mounted attacks use the attack windows of combat_tuning.json and exactly
// mountedCombat.maxChainHits hits; seated clips straddle; MountUp/Dismount/Stagger join the seated pose and start/end on the ground.
const RIDER_NEEDED = ['Idle', 'Walk', 'Trot', 'Gallop', 'Hit1', 'Hit2', 'Hit3', 'Skill', 'MountUp', 'Dismount', 'Stagger'];
const RIDER_GROUND = ['MountUp', 'Dismount', 'Stagger'];
const RIDER_WEIGHT = { Hit1: 'light', Hit2: 'light', Hit3: 'medium', Skill: 'medium' };

function riders({ DATA, load, err }) {
  const f = 'Characters/rider_clips.json', w = 'rider_clips.json';
  if (!fs.existsSync(path.join(DATA, f))) { err(w, 'file missing (run Tools/blender/build_rider_clips.py)'); return; }
  const m = load(f), mounts = load('Companions/mounts.json'), tuning = load('Combat/combat_tuning.json').attackTiming;
  if (m.schema !== 'rider_clips/1') err(w, 'unknown schema ' + m.schema);
  const hash = crypto.createHash('sha1').update(stable(tuning)).digest('hex').slice(0, 12);
  if (m.tuning.hash !== hash) err(w, `attackTiming changed since the rider clips were built (manifest ${m.tuning.hash}, now ${hash}): rebuild with build_rider_clips.py`);
  if (m.mountedCombatMaxChainHits !== mounts.mountedCombat.maxChainHits) err(w, `maxChainHits is ${mounts.mountedCombat.maxChainHits} in mounts.json but the clips were built for ${m.mountedCombatMaxChainHits}`);
  const species = load('Monsters/species.json'), sp = Array.isArray(species) ? species : species.species;
  const rigOf = new Map(sp.map(s => [s.id, (s.rigId || '').replace('rig_', '')]));
  const fams = new Map((m.families || []).map(x => [x.id, x]));
  for (const [id, fam] of Object.entries(mounts.families)) {
    const row = fams.get(id);
    if (!row) { err(w, `mount family ${id} has no rider clips`); continue; }
    for (const s of fam.species) { const rg = rigOf.get(s); if (!(rg in (m.anchors || {}))) err(w, `${id}: species ${s} uses rig "${rg}" which has no saddle anchor`); }
    const names = new Map(row.clips.map(c => [c.name, c]));
    for (const n of RIDER_NEEDED) if (!names.has(n)) err(w, `${id}: missing clip ${n}`);
    const stand = m.hipsRestZ - row.seatHeightM;
    for (const c of row.clips) {
      const cid = `${id}/${c.name}`, mt = c.metrics;
      if (Math.abs(c.frames / c.fps - c.seconds) > 1e-3) err(w, `${cid}: seconds does not match frames/fps`);
      if (!RIDER_GROUND.includes(c.name)) {
        if (!(mt.kneeSpreadMinM >= 0.30)) err(w, `${cid}: knees ${mt.kneeSpreadMinM} m apart (not astride)`);
        if (!(mt.hipsTravelM <= 0.08)) err(w, `${cid}: pelvis travels ${mt.hipsTravelM} m while seated`);
      }
      if (['Idle', 'Walk', 'Trot', 'Gallop'].includes(c.name) && (!c.loop || !(mt.loopClosureM <= 1e-3))) err(w, `${cid}: loop does not close`);
      if (c.name === 'MountUp' && !(mt.endFromIdleM <= 0.03)) err(w, `${cid}: does not end on the seated pose`);
      if (c.name === 'MountUp' && !(Math.abs(mt.startHipsDzM - stand) <= 0.02)) err(w, `${cid}: does not start standing on the ground (hips ${mt.startHipsDzM}, want ${stand.toFixed(3)})`);
      if (c.name === 'Dismount' && (!(mt.startFromIdleM <= 0.03) || !(Math.abs(mt.endHipsDzM - stand) <= 0.02))) err(w, `${cid}: does not leave the seat and end standing on the ground`);
      if (c.name === 'Stagger' && !(mt.startFromIdleM <= 0.03)) err(w, `${cid}: does not start on the seated pose`);
      if (RIDER_WEIGHT[c.name]) {
        const win = tuning[RIDER_WEIGHT[c.name]], want = Math.round((win.startupSec + win.activeSec + win.recoverySec) * m.attackFps), ev = c.events || {};
        if (c.frames !== want) err(w, `${cid}: ${c.frames} frames, the ${RIDER_WEIGHT[c.name]} windows make ${want}`);
        if (ev.ActiveBegin !== Math.round(win.startupSec * m.attackFps) || ev.ActiveEnd !== Math.round((win.startupSec + win.activeSec) * m.attackFps) || ev.RecoveryEnd !== want) err(w, `${cid}: events do not match the windows`);
        if (!(mt.startFromIdleM <= 0.03 && mt.endFromIdleM <= 0.03)) err(w, `${cid}: must start and end in the seated pose`);
      }
    }
    if (row.clips.filter(c => /^Hit\d+$/.test(c.name)).length !== mounts.mountedCombat.maxChainHits) err(w, `${id}: hit clips differ from mountedCombat.maxChainHits`);
  }
  for (const id of fams.keys()) if (!(id in mounts.families)) err(w, `rider clips for unknown mount family ${id}`);
}

// JSON.stringify with sorted keys and Python's default separators ", " and ": ", so the digest matches json.dumps(sort_keys=True)
function stable(v) {
  if (Array.isArray(v)) return '[' + v.map(stable).join(', ') + ']';
  if (v && typeof v === 'object') return '{' + Object.keys(v).sort().map(k => JSON.stringify(k) + ': ' + stable(v[k])).join(', ') + '}';
  return JSON.stringify(v);
}

module.exports = { run };

