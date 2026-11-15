#!/usr/bin/env node
// AETHWYRD bestiary rubric — scores every species in Data/Monsters against the
// executed-axis criteria in 13_Production/research/monsters.md.
//
// Usage: node rubric.js <repo-root> [--sample] [--json out.json]
//
// Every criterion resolves to a number of points OR the string 'NA' (NOT
// ASSESSED). NOT ASSESSED never scores as zero and never scores as full: it is
// reported separately and makes the overall verdict unreachable (obligation 1
// of .claude/rules/skill-authoring.md).

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

// profile.py decides whether a species gets a bespoke silhouette or falls
// through to its body plan's default. We read the generator source rather than
// trusting the data.
const profileSrc = fs.readFileSync(P('Tools/blender/ascend_creatures/profile.py'), 'utf8');
const plansSrc = fs.readFileSync(P('Tools/blender/ascend_creatures/plans.py'), 'utf8');
const genSrc = profileSrc + '\n' + plansSrc;

// ---------------------------------------------------------------- executed axes
// Only axes some shipped code actually reads. Verified by grep over
// Code/Ascend.Core, Code/Unity/Runtime and Game/Assets/_Game/Runtime.
//
//  reach class   MonsterAi.ReachOf / MinRangeOf          executed
//  telegraph     DefenseJudge.Parse -> PlayerDefense      executed
//  windupSec     MonsterBrain.StartWindup (+ jitter)      executed
//  recoverySec   MonsterBrain AiState.Recovery            executed
//  approach      4 branches: skittish / pack|swarm /
//                territorial|guardian / default           executed
//  flies         MonsterAnimator (visible bob/hover)      executed (cosmetic)
//  element       Damage.ElementMultiplier via weakness     executed
//  size          prefabScale / heightM                    executed
//
// NOT executed (declared, no reader found): aiPattern '+stalker' suffix,
// behavior.circleRadius, physics.knockbackResist, attacks[].feintChance,
// per-species physics.poise (PoiseMeter.For keys off the RIG, not the species).

const REACH = (kind) => {
  if (kind === 'ranged' || kind === 'magic') return 'ranged';
  if (kind === 'charge' || kind === 'leap' || kind === 'dash') return 'gapcloser';
  if (kind === 'aoe') return 'aoe';
  return 'melee';
};

const approachClass = (p) => {
  p = p || 'aggressive_chase';
  if (p.startsWith('skittish')) return 'skittish';
  if (p.startsWith('pack') || p.startsWith('swarm')) return 'pack';
  if (p.startsWith('territorial') || p.startsWith('guardian')) return 'hold';
  return 'default';
};

// Weber/Miller bucketing. Getty 1975 finds the Weber fraction for duration is
// roughly constant up to ~2 s; Rammsayer, Borter & Troche (2015) report
// adjusted Weber fractions near 0.17 (visual) at a 1000 ms standard. We use a
// 25% step, which is wider than the measured discrimination threshold on
// purpose: in a fight the player must do *absolute identification* (Miller
// 1956, ~2.5 bits, about 6 categories on one dimension), not side-by-side
// discrimination. 25% over 0.3-2.45 s yields 9 buckets, already above Miller's
// identification ceiling, so the bucketing is not the limiting factor.
const WEBER_STEP = 1.25;
const bucketTime = (t, lo = 0.3) => (t > 0 ? Math.floor(Math.log(t / lo) / Math.log(WEBER_STEP)) : -1);

const sizeClass = (h) => (h < 0.8 ? 'tiny' : h < 1.6 ? 'small' : h < 3 ? 'human' : h < 8 ? 'large' : h < 30 ? 'huge' : 'colossal');

function axes(s) {
  const m = motById[s.id];
  if (!m) return null;
  const atk = (m.attacks || []).filter((a) => {
    const d = atkById[a.attackId];
    // MonsterBrain drops power 0, summons and buffs: they never reach the player.
    return d && d.power > 0 && d.kind !== 'summon' && a.kind !== 'summon' && a.kind !== 'buff';
  });
  if (!atk.length) return null;
  const reaches = [...new Set(atk.map((a) => REACH(a.kind)))].sort();
  const tels = [...new Set(atk.map((a) => a.telegraph).filter((t) => t && t !== 'none'))].sort();
  const slowest = Math.max(...atk.map((a) => a.windupSec));
  const fastest = Math.min(...atk.map((a) => a.windupSec));
  const longestRecovery = Math.max(...atk.map((a) => a.recoverySec));
  return {
    reach: reaches.join('+'),
    telegraph: tels.join('+') || 'none',
    tellTier: bucketTime(slowest),
    fastTellTier: bucketTime(fastest),
    punishTier: bucketTime(longestRecovery),
    approach: approachClass(m.behavior && m.behavior.aiPattern),
    flies: m.locomotion && m.locomotion.canFly === 'true' ? 'fly' : 'ground',
    size: sizeClass(m.heightM || s.sizeMeters),
    element: s.element,
    atk,
    slowest,
    fastest,
    longestRecovery,
    minTelegraphSec: (m.timing && m.timing.minTelegraphSec) || 0,
    jitter: Math.max(0, ...atk.map((a) => a.windupJitter || 0)),
    heightM: m.heightM || s.sizeMeters,
  };
}

// Two vectors per species.
//
// dataVector keeps every axis at the resolution the JSON stores it. It is
// nearly unique per species and is therefore NOT a measure of variety: it
// measures how many decimal places the generator wrote.
//
// fightVector collapses each axis to the number of levels a player can
// identify in isolation. In a fight the player does absolute identification
// (one tell, no reference to compare against), which Miller 1956 caps near
// 2.5 bits — about six categories on a single dimension — so three timing
// levels and four size classes are generous, not stingy. Everything scored
// below uses fightVector; dataVector exists only to show the gap.
const dataVector = (a) => [a.reach, a.telegraph, a.slowest.toFixed(2), a.longestRecovery.toFixed(2), a.approach, a.flies, (a.heightM || 0).toFixed(2)].join('|');
const tell3 = (t) => (t < 0.55 ? 'fast' : t < 1.1 ? 'mid' : 'slow');
const punish3 = (t) => (t < 0.45 ? 'tight' : t < 0.8 ? 'open' : 'wide');
const size4 = (h) => (h < 1.2 ? 'small' : h < 3 ? 'human' : h < 10 ? 'big' : 'huge');
const fightVector = (a) =>
  [a.reach, a.telegraph, tell3(a.slowest), punish3(a.longestRecovery), a.approach, a.flies, size4(a.heightM || 0)].join('|');

// ---------------------------------------------------------------- rubric
// 100 points in five categories of 20. Each criterion returns {pts, max, note}
// or {na: reason, max}.

// Variant treatments are bulk, scars, moss and glow applied on top of the base
// species' shape (creature_system.md: "the 353 variants keep their base
// species' silhouette and gain a treatment"). They are not silhouette rules, so
// they must not earn silhouette points.
const TREATMENT_TOKENS = new Set(['elder', 'ancient', 'corrupted', 'spirit', 'elemental', 'regional', 'phantom', 'lord', 'king', 'queen', 'greater', 'lesser']);

function silhouetteBespoke(s) {
  // Does profile.py / plans.py carry a shape rule keyed off this species' name
  // (or its base species' name), or does it fall through to the bare body plan?
  const names = [s.name];
  if (s.baseSpeciesId) {
    const base = species.find((x) => x.id === s.baseSpeciesId);
    if (base) names.push(base.name);
  }
  for (const n of names) {
    const words = n.toLowerCase().replace(/[^a-z ]/g, ' ').split(/\s+/).filter((w) => w.length > 3 && !TREATMENT_TOKENS.has(w));
    for (const w of words) {
      // the token must appear as a quoted string literal in the generator, not
      // merely as a substring of some identifier
      const re = new RegExp(`["']${w}["' ]`, 'i');
      if (re.test(genSrc)) return { hit: w };
    }
  }
  return null;
}

function scoreSpecies(s, ctx) {
  const a = axes(s);
  const out = { id: s.id, name: s.name, rank: s.rank, ring: s.ring, family: s.family, rig: s.rigId, cats: {}, na: [] };
  if (!a) {
    out.verdict = 'NOT ASSESSED';
    out.na.push('no motion entry or no player-reachable attack');
    out.total = null;
    return out;
  }
  out.axes = a;
  out.vector = fightVector(a);

  // ---- A. Reads at a glance (20)
  const A = [];
  const bespoke = silhouetteBespoke(s);
  A.push({ k: 'A1 silhouette rule keyed to this shape', pts: bespoke ? 8 : 0, max: 8, note: bespoke ? `profile/plans carries a rule for "${bespoke.hit}"` : 'falls through to the bare body-plan default' });
  // A2: part list differs from every rig-mate
  const parts = new Set(((s.designRecipe && s.designRecipe.parts) || []));
  const rigMates = ctx.byRig[s.rigId].filter((x) => x.id !== s.id);
  let maxJac = 0;
  for (const o of rigMates) {
    const op = new Set(((o.designRecipe && o.designRecipe.parts) || []));
    const inter = [...parts].filter((p) => op.has(p)).length;
    const uni = new Set([...parts, ...op]).size;
    const jac = uni ? inter / uni : 1;
    if (jac > maxJac) maxJac = jac;
  }
  A.push({ k: 'A2 parts differ from rig-mates', pts: parts.size === 0 ? 0 : maxJac >= 1 ? 0 : maxJac > 0.6 ? 2 : 6, max: 6, note: `max Jaccard to a rig-mate ${maxJac.toFixed(2)}, ${parts.size} parts` });
  // A3: size separates it from rig-mates in a shared region
  const coRegion = rigMates.filter((o) => (o.habitats || []).some((h) => (s.habitats || []).includes(h)));
  const sameSize = coRegion.filter((o) => sizeClass((motById[o.id] || {}).heightM || o.sizeMeters) === a.size);
  A.push({ k: 'A3 size class separates in-region', pts: sameSize.length === 0 ? 6 : sameSize.length <= 3 ? 3 : 0, max: 6, note: `${sameSize.length} rig-mates share size class "${a.size}" in a shared region` });
  out.cats.A = A;

  // ---- B. Different to fight (20)
  const B = [];
  const peers = ctx.vectorPeers[out.vector] || [];
  const inBand = peers.filter((o) => o.id !== s.id && o.ring === s.ring && (o.habitats || []).some((h) => (s.habitats || []).includes(h)));
  B.push({ k: 'B1 perceivable fight profile is its own, in its own region+ring', pts: inBand.length === 0 ? 10 : inBand.length <= 2 ? 5 : inBand.length <= 6 ? 2 : 0, max: 10, note: `${inBand.length} other species in the same region and ring fight with the same perceivable profile` });
  // B2: at least one attack no other species on its rig has
  const rigAttackCounts = ctx.rigAttackCounts[s.rigId];
  const exclusive = (s.attackIds || []).filter((id) => rigAttackCounts[id] === 1);
  const rareOnRig = (s.attackIds || []).filter((id) => rigAttackCounts[id] <= 3);
  B.push({ k: 'B2 a move its rig-mates lack', pts: exclusive.length ? 6 : rareOnRig.length ? 3 : 0, max: 6, note: exclusive.length ? `exclusive on rig: ${exclusive.join(', ')}` : rareOnRig.length ? `rare on rig (<=3 users): ${rareOnRig.join(', ')}` : 'every move is shared with 4+ rig-mates' });
  // B3: spans more than one reach class (so spacing is a real question)
  const nReach = a.reach.split('+').length;
  B.push({ k: 'B3 more than one reach class', pts: nReach >= 3 ? 4 : nReach === 2 ? 2 : 0, max: 4, note: `reach classes: ${a.reach}` });
  out.cats.B = B;

  // ---- C. Tells are fair and learnable (20)
  const C = [];
  const belowFloor = a.atk.filter((x) => x.windupSec < a.minTelegraphSec);
  C.push({ k: 'C1 every windup clears the species telegraph floor', pts: belowFloor.length === 0 ? 6 : 0, max: 6, note: belowFloor.length ? `${belowFloor.length} attacks below minTelegraphSec ${a.minTelegraphSec}` : `floor ${a.minTelegraphSec}s, fastest ${a.fastest}s` });
  // C2: punish window survives the human reaction floor. 0.25 s is the
  // accessibility cap in Canon (reduced-flash 0.25) and a common simple-reaction
  // figure; anything under it is not a window a player can use.
  C.push({ k: 'C2 punish window usable (>=0.35s)', pts: a.longestRecovery >= 0.5 ? 6 : a.longestRecovery >= 0.35 ? 3 : 0, max: 6, note: `longest recovery ${a.longestRecovery}s` });
  // C3: jitter must not swallow the discriminable step. Weber step at this
  // duration is ~0.17-0.21 of the interval (Rammsayer et al. 2015); jitter is
  // +/- a fraction of windupSec in MonsterMotion.cs:83, so jitter above ~0.17
  // makes two neighbouring tell tiers overlap.
  C.push({ k: 'C3 jitter below the Weber step (<=0.17)', pts: a.jitter <= 0.17 ? 4 : a.jitter <= 0.25 ? 2 : 0, max: 4, note: `max windupJitter ${a.jitter}` });
  // C4: more than one telegraph colour, so the defence choice is a choice
  const nTel = a.telegraph === 'none' ? 0 : a.telegraph.split('+').length;
  C.push({ k: 'C4 telegraph mix forces a defence choice', pts: nTel >= 3 ? 4 : nTel === 2 ? 2 : 0, max: 4, note: `telegraphs: ${a.telegraph}` });
  out.cats.C = C;

  // ---- D. Earns belief (20)
  const D = [];
  D.push({ k: 'D1 habitat is specific (<=4 regions)', pts: (s.habitats || []).length === 0 ? 0 : (s.habitats || []).length <= 2 ? 6 : (s.habitats || []).length <= 4 ? 4 : 1, max: 6, note: `${(s.habitats || []).length} habitats` });
  // D2: the field note names a counter the player can act on
  const fn = (s.fieldNote || '').toLowerCase();
  const actionable = /back away|keep|stay|break|interrupt|dodge|parry|block|use |fire|light|avoid|do not|don't|aim|target|wait|lure|stand|look|camera|listen|burn|scatter/.test(fn);
  const onlyWeakness = /^weak to \w+\.?$/.test(fn.trim());
  D.push({ k: 'D2 field note gives an actionable counter', pts: !fn ? 0 : onlyWeakness ? 0 : actionable ? 6 : 2, max: 6, note: fn ? (actionable ? 'names an action' : 'states facts only') : 'no field note' });
  // D3: an ecological role is recoverable from the data, not just a label.
  // Executed proxies: a non-default approach class, or a behaviour note.
  const notes = ((motById[s.id].behavior || {}).notes || []).length;
  D.push({ k: 'D3 role is in data, not only prose', pts: a.approach !== 'default' && notes >= 2 ? 4 : a.approach !== 'default' || notes >= 2 ? 2 : 0, max: 4, note: `approach ${a.approach}, ${notes} behaviour notes` });
  // D4: an aftermath/observation hook — freezeWhenObserved, audioRevealRadius,
  // or a non-zero retreatHpPct: something the player sees out of combat.
  const mm = motById[s.id];
  const hooks = [mm.menace && mm.menace.freezeWhenObserved, (mm.menace && mm.menace.audioRevealRadius) > 0, (mm.behavior && mm.behavior.retreatHpPct) > 0].filter(Boolean).length;
  D.push({ k: 'D4 out-of-combat behaviour hook', pts: hooks >= 2 ? 4 : hooks === 1 ? 2 : 0, max: 4, note: `${hooks} of 3 hooks (freezeWhenObserved, audioRevealRadius, retreatHpPct)` });
  out.cats.D = D;

  // ---- E. Remembered a week later (20)
  const E = [];
  const sig = (s.signature || '').trim();
  // A signature earns points for naming a physical feature, not a mood or colour.
  const physical = /\b(horn|antler|tail|wing|claw|fang|tooth|teeth|shell|mask|crown|eye|eyes|jaw|limb|arm|leg|spine|crack|scar|plate|hide|beak|mane|tentacle|root|cap|gill|petal|lantern|chain|rib|skull|hand|mouth|head|neck|hoof|hooves|feather|scale|spike|thorn|web|blade|helm|veil|bell|drum|hook|stinger)\b/i.test(sig);
  E.push({ k: 'E1 signature names a physical feature', pts: !sig ? 0 : physical && sig.split(/\s+/).length >= 4 ? 6 : physical ? 4 : 1, max: 6, note: sig ? `"${sig.slice(0, 60)}"` : 'no signature' });
  // E2: signature is not shared with another species
  const sigPeers = (ctx.bySignature[sig.toLowerCase()] || []).filter((x) => x.id !== s.id).length;
  E.push({ k: 'E2 signature is this species\' own', pts: !sig ? 0 : sigPeers === 0 ? 4 : 0, max: 4, note: `${sigPeers} other species share this signature line` });
  // E3: name is not a prefix of a stack of siblings sharing everything else
  const nameTwins = ctx.byVectorAndRig[out.vector + '#' + s.rigId] || [];
  E.push({ k: 'E3 not one of a stack of identical siblings', pts: nameTwins.length <= 1 ? 4 : nameTwins.length <= 4 ? 2 : 0, max: 4, note: `${nameTwins.length} species share both its rig and its whole fight vector` });
  // E4: menace style and element give it a look its rig-mates don't share
  const look = s.menaceLabel + '/' + s.element + '/' + ((s.designRecipe || {}).material || '');
  const lookPeers = rigMates.filter((o) => (o.menaceLabel + '/' + o.element + '/' + ((o.designRecipe || {}).material || '')) === look).length;
  E.push({ k: 'E4 menace+element+material not duplicated on its rig', pts: lookPeers === 0 ? 6 : lookPeers <= 2 ? 3 : 0, max: 6, note: `${lookPeers} rig-mates share menace+element+material` });
  out.cats.E = E;

  // ---- totals
  let total = 0, max = 0;
  for (const key of ['A', 'B', 'C', 'D', 'E']) {
    let ct = 0, cm = 0;
    for (const c of out.cats[key]) {
      cm += c.max;
      if (c.na) out.na.push(`${c.k}: ${c.na}`);
      else ct += c.pts;
    }
    out.cats[key + '_total'] = ct;
    total += ct; max += cm;
  }
  out.total = total;
  out.max = max;
  // Obligation 1: NOT ASSESSED outranks the pass value but not the failures.
  // Rendered silhouette, animation readability and audio are not checkable from
  // the data, so every species carries them as NOT ASSESSED by construction.
  out.unassessed = ['rendered silhouette at the 1-second test', 'gait/animation reading weight and speed', 'audio alert cue'];
  out.verdict = total >= 70 ? 'STRONG (data only)' : total >= 50 ? 'WORKABLE (data only)' : total >= 30 ? 'THIN' : 'INTERCHANGEABLE';
  return out;
}

// ---------------------------------------------------------------- context
const ctx = { byRig: {}, vectorPeers: {}, rigAttackCounts: {}, bySignature: {}, byVectorAndRig: {} };
for (const s of species) (ctx.byRig[s.rigId] = ctx.byRig[s.rigId] || []).push(s);
for (const [rig, list] of Object.entries(ctx.byRig)) {
  const c = {};
  for (const s of list) for (const id of s.attackIds || []) c[id] = (c[id] || 0) + 1;
  ctx.rigAttackCounts[rig] = c;
}
for (const s of species) {
  const a = axes(s);
  if (!a) continue;
  const v = fightVector(a);
  (ctx.vectorPeers[v] = ctx.vectorPeers[v] || []).push(s);
  (ctx.byVectorAndRig[v + '#' + s.rigId] = ctx.byVectorAndRig[v + '#' + s.rigId] || []).push(s);
  const sg = (s.signature || '').trim().toLowerCase();
  if (sg) (ctx.bySignature[sg] = ctx.bySignature[sg] || []).push(s);
}

const scored = species.map((s) => scoreSpecies(s, ctx));

// ---------------------------------------------------------------- report
const assessed = scored.filter((x) => x.total !== null);
const notAssessed = scored.filter((x) => x.total === null);
const mean = (xs) => xs.reduce((a, b) => a + b, 0) / xs.length;
const pct = (n) => ((100 * n) / assessed.length).toFixed(1) + '%';

console.log('# Rubric run over Data/Monsters');
console.log(`species: ${species.length}  scored: ${assessed.length}  NOT ASSESSED: ${notAssessed.length}`);
if (notAssessed.length) console.log('  NOT ASSESSED ids: ' + notAssessed.map((x) => x.id).join(', '));
console.log(`\nmean total: ${mean(assessed.map((x) => x.total)).toFixed(1)} / 100`);
for (const k of ['A', 'B', 'C', 'D', 'E']) {
  const label = { A: 'A reads at a glance', B: 'B different to fight', C: 'C fair tells', D: 'D earns belief', E: 'E remembered' }[k];
  console.log(`  ${label.padEnd(26)} ${mean(assessed.map((x) => x.cats[k + '_total'])).toFixed(1)} / 20`);
}
const vd = {};
assessed.forEach((x) => (vd[x.verdict] = (vd[x.verdict] || 0) + 1));
console.log('\nverdicts: ' + Object.entries(vd).map(([k, v]) => `${k} ${v} (${pct(v)})`).join(', '));

// --- the variety numbers the 680 question turns on
const vectors = new Set(assessed.map((x) => x.vector));
console.log(`\ndistinct fight vectors across the whole bestiary: ${vectors.size}`);
const collide = assessed.filter((x) => {
  const n = (ctx.vectorPeers[x.vector] || []).filter((o) => o.id !== x.id && o.ring === x.ring && (o.habitats || []).some((h) => (species.find((y) => y.id === x.id).habitats || []).includes(h)));
  x._collisions = n.length;
  return n.length > 0;
});
console.log(`species whose whole fight vector is duplicated inside their own region+ring: ${collide.length} (${pct(collide.length)})`);
console.log(`worst collision group size: ${Math.max(...assessed.map((x) => x._collisions || 0)) + 1}`);
const bespokeN = assessed.filter((x) => x.cats.A[0].pts > 0).length;
console.log(`species with a bespoke silhouette rule in profile.py/plans.py: ${bespokeN} (${pct(bespokeN)})`);
const exclN = assessed.filter((x) => x.cats.B[1].pts === 6).length;
console.log(`species with at least one attack exclusive on their rig: ${exclN} (${pct(exclN)})`);

// --- by region: distinct vectors vs species count
console.log('\n## per region: species vs distinct fight vectors');
const regions = {};
for (const s of species) for (const h of s.habitats || []) (regions[h] = regions[h] || []).push(s);
const rows = Object.entries(regions).map(([r, list]) => {
  const vs = new Set(list.map((s) => { const a = axes(s); return a ? fightVector(a) : null; }).filter(Boolean));
  return { r, n: list.length, v: vs.size, ratio: vs.size / list.length };
}).sort((a, b) => b.n - a.n);
rows.slice(0, 12).forEach((x) => console.log(`  ${x.r.padEnd(26)} ${String(x.n).padStart(4)} species  ${String(x.v).padStart(3)} vectors  ${(x.ratio * 100).toFixed(0)}%`));

// --- variants vs their base
const variants = species.filter((s) => s.variantKind && s.baseSpeciesId);
let sameAsBase = 0, baseFound = 0;
for (const v of variants) {
  const b = species.find((x) => x.id === v.baseSpeciesId);
  if (!b) continue;
  baseFound++;
  const av = axes(v), ab = axes(b);
  if (av && ab && fightVector(av) === fightVector(ab)) sameAsBase++;
}
console.log(`\nvariants with a base species: ${baseFound}; sharing their base's entire fight vector: ${sameAsBase} (${((100 * sameAsBase) / baseFound).toFixed(1)}%)`);

if (process.argv.includes('--json')) {
  const out = process.argv[process.argv.indexOf('--json') + 1];
  fs.writeFileSync(out, JSON.stringify({ scored, summary: { mean: mean(assessed.map((x) => x.total)), vectors: vectors.size, collide: collide.length } }, null, 1));
  console.log(`\nwrote ${out}`);
}

// --- sample
if (process.argv.includes('--sample')) {
  const ids = process.argv[process.argv.indexOf('--sample') + 1].split(',');
  console.log('\n\n# SAMPLE');
  for (const id of ids) {
    const x = scored.find((y) => y.id === id);
    if (!x) { console.log(`\n## ${id} — NOT FOUND`); continue; }
    console.log(`\n## ${x.name} (${x.id}) — ${x.total === null ? 'NOT ASSESSED' : x.total + '/100'} — ${x.verdict}`);
    console.log(`   rank ${x.rank} ring ${x.ring} family ${x.family} rig ${x.rig}`);
    if (x.vector) console.log(`   fight vector: ${x.vector}`);
    for (const k of ['A', 'B', 'C', 'D', 'E']) {
      if (!x.cats[k]) continue;
      console.log(`   ${k} = ${x.cats[k + '_total']}/20`);
      for (const c of x.cats[k]) console.log(`     ${c.pts}/${c.max}  ${c.k} — ${c.note}`);
    }
    console.log(`   NOT ASSESSED: ${x.unassessed.join('; ')}`);
  }
}
