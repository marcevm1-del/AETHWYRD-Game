// Physical-map checks for Data/World/physical_map.json (called from validate.js). Dependency-free.
// Errors fail `npm run build`; warnings are printed and counted but never fail it.
//   1. Road grade   - 15 % limit on every road. Known hairpin roads (same list as the terrain tool,
//                     Tools/blender/ascend_terrain/checks.py KNOWN_HAIRPIN_ROADS) are warnings with a ceiling.
//   2. Settlement slope - warn above 12 %, error for ring0 settlements above 12 % or in water.
//   3. Settlement in water - warn when inWater is set (known: Hoshizora City, Summer Court glades).
//   4. River continuity - endsIn resolves, pathSmooth water level never rises downstream (error),
//                     a tributary ends within 3 m of the parent's level at the confluence (warning).
const fs = require('fs');
const path = require('path');

const ROAD_MAX_GRADE = 0.15;
const KNOWN_HAIRPIN_ROADS = ['road_04', 'road_05', 'road_06', 'road_12'];
// The terrain tool allows 0.5 % of its 10 m field samples over 15 %. physical_map.json only holds points about every
// 0.25 km, so a hairpin tip dominates a step and the same share cannot be measured here (today 16-37 % of steps).
// This ceiling is therefore a no-regression ratchet on the share of over-limit steps, not the 0.5 % rule.
const HAIRPIN_STEP_CEILING_PCT = 40;
const SLOPE_LIMIT_PCT = 12;
const RIVER_RISE_TOL_M = 0.05;       // water levels are rounded to 0.01 m
const CONFLUENCE_TOL_M = 3;

function run(dataDir) {
  const errors = [];
  const warnings = [];
  const counts = { roadGrade: 0, slope: 0, inWater: 0, riverDeclared: 0, riverRise: 0, confluence: 0 };
  const file = path.join(dataDir, 'World', 'physical_map.json');
  if (!fs.existsSync(file)) return { errors, warnings, counts, summary: 'physical_map.json not present, map checks skipped' };
  const map = JSON.parse(fs.readFileSync(file, 'utf8'));
  const E = (w, m) => errors.push(`physical_map ${w}: ${m}`);
  const W = (k, w, m) => { counts[k]++; warnings.push(`physical_map ${w}: ${m}`); };

  // 1. roads
  for (const r of map.roads || []) {
    const p = r.points || [];
    let steps = 0, over = 0, max = 0;
    for (let i = 1; i < p.length; i++) {
      const dist = Math.hypot(p[i][0] - p[i - 1][0], p[i][1] - p[i - 1][1]) * 1000;
      if (dist <= 0) continue;
      const g = Math.abs(p[i][2] - p[i - 1][2]) / dist;
      steps++; if (g > ROAD_MAX_GRADE) over++; if (g > max) max = g;
    }
    const stored = (r.maxGradePct || 0) / 100;
    const worst = Math.max(max, stored);
    const pctOver = steps ? 100 * over / steps : 0;
    const desc = `max grade ${(worst * 100).toFixed(1)} % (stored ${r.maxGradePct}, from points ${(max * 100).toFixed(1)}), ${over}/${steps} steps over 15 % (${pctOver.toFixed(1)} %)`;
    if (worst <= ROAD_MAX_GRADE) continue;
    if (KNOWN_HAIRPIN_ROADS.includes(r.id)) {
      if (pctOver > HAIRPIN_STEP_CEILING_PCT) E(r.id, `known hairpin road is over its ceiling of ${HAIRPIN_STEP_CEILING_PCT} % of steps: ${desc}`);
      else W('roadGrade', r.id, `known hairpin road over 15 %: ${desc}`);
    } else E(r.id, `road over the 15 % grade limit: ${desc}`);
  }

  // 2 + 3. settlements
  for (const s of map.settlements || []) {
    const slope = s.maxSlope300mPct;
    if (s.ring0) {
      if (slope > SLOPE_LIMIT_PCT) E(s.id, `ring0 settlement on ${slope} % slope (limit ${SLOPE_LIMIT_PCT})`);
      if (s.inWater) E(s.id, `ring0 settlement is in ${s.inWater}`);
    } else if (slope > SLOPE_LIMIT_PCT) W('slope', s.id, `${s.name} on ${slope} % slope within 300 m (limit ${SLOPE_LIMIT_PCT})`);
    if (s.inWater) W('inWater', s.id, `${s.name} stands in ${s.inWater}`);
  }

  // 4. rivers
  const rivers = map.rivers || [];
  const byId = Object.fromEntries(rivers.map(r => [r.id, r]));
  for (const r of rivers) {
    const e = r.endsIn;
    const ps = r.pathSmooth || [];
    if (!e || !['sea', 'lake', 'river'].includes(e.type)) E(r.id, `endsIn missing or not sea/lake/river (${JSON.stringify(e)})`);
    if (ps.length < 2) { E(r.id, 'pathSmooth has fewer than 2 points'); continue; }
    let rises = 0, worst = 0;
    for (let i = 1; i < ps.length; i++) { const up = ps[i][2] - ps[i - 1][2]; if (up > RIVER_RISE_TOL_M) { rises++; worst = Math.max(worst, up); } }
    if (rises) E(r.id, `water level rises downstream at ${rises} point(s), worst +${worst.toFixed(2)} m`);
    if (e && e.type === 'river') {
      const par = byId[e.id];
      if (!par) { E(r.id, `endsIn points at unknown river ${e.id}`); continue; }
      const end = ps[ps.length - 1];
      let best = null, bd = Infinity;
      for (const q of par.pathSmooth || []) { const d = Math.hypot(q[0] - end[0], q[1] - end[1]); if (d < bd) { bd = d; best = q; } }
      if (!best || bd > 1) { E(r.id, `end is ${bd.toFixed(2)} km from parent ${e.id}: no confluence`); continue; }
      const diff = end[2] - best[2];
      if (Math.abs(diff) > CONFLUENCE_TOL_M) W('confluence', r.id, `ends ${diff.toFixed(1)} m ${diff > 0 ? 'above' : 'below'} its parent ${e.id} at the confluence (${end[2]} m vs ${best[2]} m, limit ${CONFLUENCE_TOL_M} m)`);
    }
  }
  const summary = `map warnings ${warnings.length} (road grade ${counts.roadGrade}, settlement slope ${counts.slope}, in water ${counts.inWater}, river confluence ${counts.confluence})`;
  return { errors, warnings, counts, summary };
}
module.exports = { run };
