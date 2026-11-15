#!/usr/bin/env node
// The variety-ceiling numbers for 13_Production/research/monsters.md.
// Two vectors per species:
//   dataVector  — every executed axis at the resolution the data stores it
//   millerVector — the same axes collapsed to the number of levels a player can
//                  identify in isolation (Miller 1956: ~2.5 bits, about 6
//                  categories on one dimension; in a fight, under time
//                  pressure, we take 3 for timing and 4 for size)
const fs = require('fs');
const path = require('path');
const ROOT = process.argv[2] || '.';
const P = (...p) => path.join(ROOT, ...p);
const J = (f) => JSON.parse(fs.readFileSync(f, 'utf8'));

const species = J(P('Data/Monsters/species.json'));
const motion = J(P('Data/Monsters/motion.json')).species;
const attacks = J(P('Data/Monsters/attacks.json'));
const motById = Object.fromEntries(motion.map((m) => [m.speciesId, m]));
const atkById = Object.fromEntries(attacks.map((a) => [a.id, a]));

const REACH = (k) => (k === 'ranged' || k === 'magic' ? 'R' : k === 'charge' || k === 'leap' || k === 'dash' ? 'G' : k === 'aoe' ? 'A' : 'M');
const approach = (p) => {
  p = p || 'aggressive_chase';
  if (p.startsWith('skittish')) return 'flee';
  if (p.startsWith('pack') || p.startsWith('swarm')) return 'pack';
  if (p.startsWith('territorial') || p.startsWith('guardian')) return 'hold';
  return 'rush';
};
// Three identifiable timing levels. Boundaries are set where the Weber step
// (~0.17-0.21 of the interval at a 1 s standard; Rammsayer, Borter & Troche
// 2015) puts neighbouring levels clearly apart: 0.3-0.55 / 0.55-1.1 / 1.1+.
const tell3 = (t) => (t < 0.55 ? 'fast' : t < 1.1 ? 'mid' : 'slow');
const punish3 = (t) => (t < 0.45 ? 'tight' : t < 0.8 ? 'open' : 'wide');
const size4 = (h) => (h < 1.2 ? 'small' : h < 3 ? 'human' : h < 10 ? 'big' : 'huge');

function pack(s) {
  const m = motById[s.id];
  if (!m) return null;
  const atk = (m.attacks || []).filter((a) => {
    const d = atkById[a.attackId];
    return d && d.power > 0 && d.kind !== 'summon' && a.kind !== 'summon' && a.kind !== 'buff';
  });
  if (!atk.length) return null;
  const reach = [...new Set(atk.map((a) => REACH(a.kind)))].sort().join('');
  const tel = [...new Set(atk.map((a) => a.telegraph).filter((t) => t && t !== 'none'))].sort().join('');
  const slowest = Math.max(...atk.map((a) => a.windupSec));
  const rec = Math.max(...atk.map((a) => a.recoverySec));
  const h = m.heightM || s.sizeMeters;
  return {
    data: [reach, tel, slowest.toFixed(2), rec.toFixed(2), approach(m.behavior && m.behavior.aiPattern), m.locomotion.canFly === 'true' ? 'F' : 'g', h.toFixed(2)].join('|'),
    miller: [reach, tel, tell3(slowest), punish3(rec), approach(m.behavior && m.behavior.aiPattern), m.locomotion.canFly === 'true' ? 'F' : 'g', size4(h)].join('|'),
    rig: s.rigId,
  };
}

const rows = species.map((s) => ({ s, p: pack(s) })).filter((x) => x.p);
console.log(`species packed: ${rows.length} of ${species.length}`);
const uniq = (xs) => new Set(xs).size;
console.log(`\ndistinct DATA vectors   (full stored resolution): ${uniq(rows.map((x) => x.p.data))}`);
console.log(`distinct MILLER vectors (identifiable levels)    : ${uniq(rows.map((x) => x.p.miller))}`);
console.log(`distinct MILLER vectors ignoring size/flight     : ${uniq(rows.map((x) => x.p.miller.split('|').slice(0, 5).join('|')))}`);
console.log(`distinct MILLER + rig  (what you see + how it fights): ${uniq(rows.map((x) => x.p.miller + '#' + x.p.rig))}`);

// What would splitting the default "rush" class into its three declared
// patterns be worth? aggressive_chase / ambush_strike / passive_wander all take
// the same branch today (MonsterAi.cs:145-159).
{
  const split = rows.map((x) => {
    const m = motById[x.s.id];
    const p = (m.behavior && m.behavior.aiPattern) || '';
    const a = approach(p);
    return x.p.miller.replace('|rush|', '|' + (a === 'rush' ? p.split('+')[0] : a) + '|');
  });
  console.log(`distinct MILLER vectors if aggressive/ambush/passive were separate: ${uniq(split)}`);
}

// how many species sit in each Miller class
const groups = {};
rows.forEach((x) => (groups[x.p.miller] = groups[x.p.miller] || []).push(x.s.name));
const sizes = Object.values(groups).map((g) => g.length).sort((a, b) => b - a);
console.log(`\nlargest Miller classes: ${sizes.slice(0, 10).join(', ')}`);
console.log(`median Miller class size: ${sizes[Math.floor(sizes.length / 2)]}`);
const top = Object.entries(groups).sort((a, b) => b[1].length - a[1].length)[0];
console.log(`\nbiggest class (${top[1].length} species) = ${top[0]}`);
console.log(`  e.g. ${top[1].slice(0, 12).join(', ')}`);

// inside one region+ring: how many Miller classes does a player meet?
const bands = {};
for (const x of rows) for (const h of x.s.habitats || []) {
  const k = h + '/ring' + x.s.ring;
  (bands[k] = bands[k] || []).push(x);
}
const bandRows = Object.entries(bands).map(([k, list]) => ({ k, n: list.length, m: uniq(list.map((x) => x.p.miller)), d: uniq(list.map((x) => x.p.data)) })).filter((x) => x.n >= 8).sort((a, b) => b.n - a.n);
console.log('\n## inside one region+ring (>=8 species): species / distinct Miller classes / distinct data vectors');
bandRows.slice(0, 15).forEach((x) => console.log(`  ${x.k.padEnd(32)} ${String(x.n).padStart(4)}  ${String(x.m).padStart(3)}  ${String(x.d).padStart(3)}   ${(100 * x.m / x.n).toFixed(0)}% distinct`));
const totN = bandRows.reduce((a, b) => a + b.n, 0), totM = bandRows.reduce((a, b) => a + b.m, 0);
console.log(`  ALL (>=8 bands)                  ${totN}  ${totM}       ${(100 * totM / totN).toFixed(0)}% distinct`);

// --- silhouette tokens: the generator's real vocabulary
const prof = fs.readFileSync(P('Tools/blender/ascend_creatures/profile.py'), 'utf8');
const plans = fs.readFileSync(P('Tools/blender/ascend_creatures/plans.py'), 'utf8');
const src = prof + '\n' + plans;
const lits = [...src.matchAll(/["']([a-z][a-z_ ]{3,23})["']/g)].map((m) => m[1]);
const shapeTokens = [...new Set(lits)].filter((t) => !/_base$|^(name|look|none|side|head|heads|arms|horns|large|small|medium|long|thin|tall|round|soft|pointy|spiky|limb|neck|nose|snout|socket|shell|tails|tuft|wool|bulk|vbulk|biped|quad|taur|blob|ears|eye_|glow|scar|moss|stone|crystal|spore|mixed|fur_|thick|flame|armored|trailing|elongated|broken)/.test(t));
const used = {};
for (const s of species) {
  const words = s.name.toLowerCase().replace(/[^a-z ]/g, ' ').split(/\s+/);
  const hits = shapeTokens.filter((t) => (t.includes(' ') ? s.name.toLowerCase().includes(t) : words.includes(t)));
  for (const h of hits) (used[h] = used[h] || []).push(s.name);
  if (!hits.length) (used['(none)'] = used['(none)'] || []).push(s.name);
}
console.log(`\n## silhouette vocabulary in profile.py + plans.py`);
console.log(`shape tokens available: ${shapeTokens.length}`);
console.log(`tokens actually matched by a species name: ${Object.keys(used).filter((k) => k !== '(none)').length}`);
console.log(`species whose name matches no shape token (body-plan default only): ${(used['(none)'] || []).length}`);
const heavy = Object.entries(used).filter(([k]) => k !== '(none)').sort((a, b) => b[1].length - a[1].length).slice(0, 12);
console.log('most-reused tokens: ' + heavy.map(([k, v]) => `${k} x${v.length}`).join(', '));
