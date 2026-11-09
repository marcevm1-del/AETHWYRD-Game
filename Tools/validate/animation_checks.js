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

module.exports = { run };
