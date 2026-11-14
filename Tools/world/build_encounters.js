// Generates Data/World/encounters.json and 10_World/encounter_tables.md.
// Run: node Tools/world/build_encounters.js [--check]   (--check exits 1 if either file is stale)
//
// Inputs (all canonical, nothing is invented here): Data/World/regions.json (rank band, ring, tyrant, siege faction),
// Data/World/region_graph.json (roads, passes, sea legs, borders), Data/Monsters/species.json (rank, behaviour, family, isTyrant/isUnique)
// and Data/Monsters/population.json (who actually lives where, and when: Day / Night / Day & Night).
// Output is deterministic (no random numbers) so the file diffs cleanly. Hand-authored parts live in THEMES below.
const fs = require('fs');
const path = require('path');
const root = path.resolve(__dirname, '..', '..');
const read = (p) => JSON.parse(fs.readFileSync(path.join(root, p), 'utf8'));

const species = read('Data/Monsters/species.json');
const regions = read('Data/World/regions.json');
const graph = read('Data/World/region_graph.json');
const pop = read('Data/Monsters/population.json');

const RANKS = ['F-', 'F', 'F+', 'E-', 'E', 'E+', 'D-', 'D', 'D+', 'C-', 'C', 'C+', 'B-', 'B', 'B+', 'A-', 'A', 'A+', 'S-', 'S', 'S+', 'SS-', 'SS', 'SS+', 'SSS-', 'SSS', 'SSS+', 'EX'];
const rv = (r) => { const i = RANKS.indexOf(r); if (i < 0) throw new Error('unknown rank ' + r); return i; };
// A band letter ("C") covers its -, plain and + steps; the band's top is the + step.
const bandTop = (letter) => { const i = RANKS.map((r, k) => [r, k]).filter(([r]) => r.replace(/[+-]$/, '') === letter).map(([, k]) => k); if (!i.length) throw new Error('bad band ' + letter); return Math.max(...i); };
const bandBottom = (letter) => Math.min(...RANKS.map((r, k) => [r, k]).filter(([r]) => r.replace(/[+-]$/, '') === letter).map(([, k]) => k));

const spById = new Map(species.map((s) => [s.id, s]));
const regById = new Map(regions.map((r) => [r.id, r]));

// ---- hand-authored layer: the feel of each near-Ring-0 region, read by the encounter director and by the doc -------------------------------
const THEMES = {
  reg_whisperwood: { pacing: 'Teaching ground. Roads are nearly safe; the forest rewards a careful look.', signature: 'goblin scouts testing the road, then undead drifting out of the ruins at dusk', avoid: 'never more than two enemies at once before the first Guild rank-up' },
  reg_aldmere: { pacing: 'The first real pressure. Farm tracks stay calm by day; the ruins and fens are the front line of the Oathless Baron.', signature: 'slimes in the grass, skeleton patrols on the old Royal Valley roads, goblin raiders near the farms', avoid: 'no Pack groups on the Whisperwood road itself' },
  reg_greymoor: { pacing: 'A slow, damp danger. Fights start from the water and the mist, not from the road.', signature: 'wererats and Lizardmen in the reeds, undead walking the boardwalks after dark', avoid: 'no daylight ambush groups on the stilt-village boardwalks' },
  reg_sylvaran: { pacing: 'Gentle by day, strange by night. Most creatures here are shy.', signature: 'moss kittens and jackalopes by day, fungal things and firefly swarms after dusk', avoid: 'Passive creatures never start a fight' },
  reg_mossdeep: { pacing: 'Small-scale danger: webs, wasps and trappers under a huge canopy.', signature: 'Mother Webcrawler\'s brood, grove goblin trappers, bandit bears', avoid: 'no open-field sprawl; fights happen in clearings' },
  reg_lirian: { pacing: 'A canal city: danger is at the waterline and in the old districts, never in the market streets.', signature: 'gremlin saboteurs, clockwork sentinels, drowned things after dark', avoid: 'no combat spawns inside the walls' }
};

// ---- group sizes by behaviour; high ranks never come in crowds ---------------------------------------------------------------------------
const GROUP = { Pack: [3, 5], Swarm: [4, 8], Territorial: [1, 2], Ambush: [1, 1], Aggressive: [1, 3], Passive: [1, 3], Skittish: [1, 2], Guardian: [1, 1] };
const RING_CAP = { 1: 2, 2: 3, 3: 4, 4: 5, 5: 6, 6: 6, 7: 6, 8: 6, 9: 6 };
let curRing = 1;
const groupFor = (s) => {
  let [lo, hi] = GROUP[s.behavior] || [1, 1];
  const r = rv(s.rank);
  if (r >= rv('B-')) hi = Math.min(hi, s.behavior === 'Pack' ? 3 : 2);
  if (r >= rv('A-')) { hi = Math.min(hi, s.behavior === 'Pack' ? 2 : 1); }
  if (r >= rv('S-')) { hi = 1; }
  hi = Math.min(hi, RING_CAP[curRing]);
  lo = Math.min(lo, hi);
  return [lo, hi];
};
const CALM = new Set(['Passive', 'Skittish', 'Territorial']);
const HOSTILE = new Set(['Aggressive', 'Ambush', 'Pack', 'Swarm', 'Guardian']);

// ---- residents per region: species that have population entries there ---------------------------------------------------------------------
const res = {};
for (const r of regions) res[r.id] = new Map();
for (const p of pop) {
  if (p.tier === 'Unique' || p.spawn === 'Story') continue;
  const m = res[p.regionId]; if (!m) continue;
  const e = m.get(p.speciesId) || { n: 0, spawn: new Set() };
  e.n += 1; e.spawn.add(p.spawn); m.set(p.speciesId, e);
}

const entry = (s, e, weightScale) => ({
  speciesId: s.id,
  weight: Math.max(1, Math.round(e.n * weightScale)),
  group: groupFor(s)
});
const byRankThenId = (a, b) => rv(a.s.rank) - rv(b.s.rank) || (a.s.id < b.s.id ? -1 : 1);

const neighbours = {};
for (const ed of graph.edges) {
  if (ed.kind === 'border' && ed.foot === false) continue;
  (neighbours[ed.a] = neighbours[ed.a] || []).push({ id: ed.b, kind: ed.kind });
  (neighbours[ed.b] = neighbours[ed.b] || []).push({ id: ed.a, kind: ed.kind });
}

const out = [];
const regionRows = [];
for (const r of regions) {
  curRing = r.ring;
  const m = res[r.id];
  const lo = bandBottom(r.rankMin), hi = bandTop(r.rankMax);
  const cand = [];
  for (const [sid, e] of m) {
    const s = spById.get(sid);
    if (!s || s.isTyrant || s.isUnique) continue;
    cand.push({ s, e });
  }
  cand.sort(byRankThenId);
  // in-band first; if the region is thin, widen to everything it houses (flagged thin)
  let pool = cand.filter(({ s }) => rv(s.rank) <= hi && rv(s.rank) >= lo - 3);
  let thin = false;
  if (pool.length < 6) { pool = cand.slice(); thin = true; }
  const n = pool.length;
  const lower = pool.slice(0, Math.ceil(n * 0.45));
  const upper = pool.slice(Math.floor(n * 0.45));
  const tbl = (list, scale) => list.map(({ s, e }) => ({ s, e, ent: entry(s, e, scale) }));

  const surface = r.layer === 'surface';
  const hasRoad = (neighbours[r.id] || []).some((x) => x.kind === 'road' || x.kind === 'pass');
  const settlements = (r.defenceSettlements || []).length;

  // ROADSIDE: lower half, calm creatures only, at most 6 entries; only where a road, pass or settlement exists.
  let roadside = [];
  if (surface && (hasRoad || settlements)) {
    roadside = tbl(lower.filter(({ s }) => CALM.has(s.behavior) && s.familyKey !== 'aquatic'), 1).slice(0, 8);
    if (roadside.length < 2) roadside = tbl(lower, 1).slice(0, 4);
  }
  // WILD: the middle of the band; everything that is not top-rank. Excludes nothing by behaviour.
  const wild = tbl(pool.slice(0, Math.max(6, Math.ceil(n * 0.8))), 1).slice(-14);
  // DEEP: the top of the band, hostile first. Fewer, heavier, rarer.
  let deep = tbl(upper.filter(({ s }) => HOSTILE.has(s.behavior)), 1).slice(-8);
  if (!deep.length) deep = tbl(upper, 1).slice(-6);
  // NIGHT: residents seen at night, hostile first; falls back to the deep list.
  let night = tbl(pool.filter(({ e }) => e.spawn.has('Night') || e.spawn.has('Day & Night')), 1).filter(({ s }) => HOSTILE.has(s.behavior)).slice(-10);
  if (!night.length) night = deep.slice();

  // BORDER BLEED: up to 2 low-rank residents of each walkable neighbour, in-band for this region, at a small weight.
  const bleed = [];
  const seen = new Set(pool.map(({ s }) => s.id));
  for (const nb of (neighbours[r.id] || []).filter((x) => x.kind !== 'sea').sort((a, b) => a.id < b.id ? -1 : 1)) {
    if (!res[nb.id] || !surface || regById.get(nb.id).layer !== 'surface') continue;
    const add = [];
    for (const [sid, e] of res[nb.id]) {
      const s = spById.get(sid);
      if (!s || s.isTyrant || s.isUnique || seen.has(sid) || rv(s.rank) > hi || !(CALM.has(s.behavior) || HOSTILE.has(s.behavior))) continue;
      add.push({ s, e });
    }
    add.sort(byRankThenId);
    for (const { s } of add.slice(0, 2)) { seen.add(s.id); bleed.push({ speciesId: s.id, from: nb.id, weight: 1, group: groupFor(s) }); }
  }

  const strip = (rows) => rows.map(({ ent }) => ent);
  const row = {
    regionId: r.id,
    ring: r.ring,
    layer: r.layer,
    rankBand: `${r.rankMin}-${r.rankMax}`,
    thin,
    theme: THEMES[r.id] || null,
    rates: rateFor(r),
    tables: { roadside: strip(roadside), wild: strip(wild), deep: strip(deep), night: strip(night) },
    borderBleed: bleed,
    siege: r.noSiege ? null : { faction: r.siegeFaction, tyrantSpeciesId: r.tyrantSpeciesId, initialState: r.initialState }
  };
  regionRows.push(row);
}

function rateFor(r) {
  // Encounters per 10 minutes of walking, by zone. Ring 1 is gentle; calm regions never exceed the ring cap.
  const ringCap = [0, 1, 1.5, 2, 2.5, 3, 3.5, 4, 4.5, 5][Math.min(9, r.ring)];
  const settled = (r.defenceSettlements || []).length > 0;
  return {
    roadside: r.layer === 'surface' ? +(Math.min(0.4 + 0.1 * r.ring, 1.2)).toFixed(2) : 0,
    wild: +(Math.min(ringCap * 0.6, 3)).toFixed(2),
    deep: +(Math.min(ringCap * 0.8, 3.5)).toFixed(2),
    nightMultiplier: settled ? 1.4 : 1.2
  };
}

// ---- route table: one entry per non-border edge of the region graph --------------------------------------------------------------------------
const routes = graph.edges.filter((e) => e.kind !== 'border').map((e) => {
  const A = regById.get(e.a), B = regById.get(e.b);
  const gentle = A.ring <= B.ring ? A : B;     // the roadside table of the gentler end governs the road
  const harsh = A.ring <= B.ring ? B : A;
  // the road eases into the harsher region: the last quarter of the route draws from the harsher end's roadside table
  const km = e.km;
  return {
    edgeId: e.id, kind: e.kind, a: e.a, b: e.b, km,
    mainTable: { regionId: gentle.id, zone: 'roadside' },
    approachTable: { regionId: harsh.id, zone: e.kind === 'sea' ? 'wild' : 'roadside', lastKm: +(Math.min(km / 4, 6)).toFixed(1) },
    expectedEncounters: +(km * (e.kind === 'pass' ? 0.5 : e.kind === 'sea' ? 0.25 : 0.35)).toFixed(1),
    noCombatWithinMeters: 150
  };
});

const data = {
  version: 1,
  note: 'Generated by Tools/world/build_encounters.js from regions.json, region_graph.json, species.json and population.json. Do not edit by hand; hand-written text lives in THEMES in the generator. Docs: 10_World/encounter_tables.md.',
  rules: {
    zones: {
      roadside: 'Within 60 m of a road, pass or settlement gate. Calm creatures only. Never inside a settlement.',
      wild: 'Open land in the region. The middle of the rank band.',
      deep: 'Ruins, dens, lairs, caves and deep forest. The top of the band, hostile first.',
      night: 'Replaces wild/deep between dusk and dawn. Hostile residents seen at night.'
    },
    groupRule: 'group = [min,max] enemies per encounter; the director rolls inside it and never exceeds the ring cap below.',
    groupCapByRing: Object.fromEntries(Object.entries(RING_CAP).map(([k, v]) => [String(k), v])),
    borderBleedWeight: 'borderBleed entries add to wild and roadside tables at weight 1 each: a stray from the next region, never above this region\'s top rank.',
    tyrantRule: 'A region\'s Tyrant is never in a random table. It appears only through the siege system (siege_waves.json) and its lair.',
    safeRule: 'No random combat inside settlements, within 150 m of an inn or waystone, or on a road within noCombatWithinMeters of either end.',
    uniqueRule: 'Unique and Story-tier population entries are excluded from every table.'
  },
  regions: regionRows,
  routes
};

// ---- the doc -------------------------------------------------------------------------------------------------------------------------------
const nm = (sid) => (spById.get(sid) || { name: sid }).name;
const md = [];
md.push('# Regional encounter tables');
md.push('');
md.push('Generated by `node Tools/world/build_encounters.js` into `Data/World/encounters.json`. Do not edit by hand: change the source data or the `THEMES` block in the generator and rerun.');
md.push('');
md.push('Every table row names a species that actually lives in that region (from `Data/Monsters/population.json`), stays inside the region\'s rank band, and excludes Tyrants and Uniques. The random-encounter director reads the JSON; this page is the human view.');
md.push('');
md.push('## How a region is cut into tables');
md.push('| Zone | Where | Who |');
md.push('|---|---|---|');
for (const [k, v] of Object.entries(data.rules.zones)) md.push(`| ${k} | ${v.split('. ')[0]}. | ${v.split('. ').slice(1).join('. ') || '-'} |`);
md.push('');
md.push('Group size comes from behaviour (Pack 3-5, Swarm 4-8, Territorial 1-2, Ambush 1, Aggressive 1-3, Passive 1-3, Skittish 1-2, Guardian 1) and shrinks with rank: B- and above at most 3 (Pack) or 2, A- and above at most 2 or 1, S- and above always 1.');
md.push('');
md.push('**Safe rule:** ' + data.rules.safeRule);
md.push('');
md.push('**Tyrants:** ' + data.rules.tyrantRule);
md.push('');
md.push('## Routes (the region graph)');
md.push('A route uses the gentler end\'s roadside table, and for the last quarter of its length (max 6 km) the harsher end\'s, so a road eases the traveller into the next region.');
md.push('');
md.push('| Route | Kind | km | Expected encounters | Main table | Approach table |');
md.push('|---|---|---|---|---|---|');
for (const rt of routes) md.push(`| ${regById.get(rt.a).name} - ${regById.get(rt.b).name} | ${rt.kind} | ${rt.km} | ${rt.expectedEncounters} | ${regById.get(rt.mainTable.regionId).name} ${rt.mainTable.zone} | ${regById.get(rt.approachTable.regionId).name} ${rt.approachTable.zone} (last ${rt.approachTable.lastKm} km) |`);
md.push('');
md.push('## Regions');
const fmt = (rows) => rows.length ? rows.map((x) => `${nm(x.speciesId)} x${x.group[0] === x.group[1] ? x.group[0] : x.group[0] + '-' + x.group[1]} (w${x.weight})`).join(', ') : '(none)';
for (const g of regionRows) {
  const r = regById.get(g.regionId);
  md.push('');
  md.push(`### ${r.name} (\`${r.id}\`)`);
  md.push(`Ring ${g.ring}, ${g.layer}, ranks ${g.rankBand}${g.thin ? ', **thin habitat: tables widened to every resident**' : ''}. Rates per 10 min: roadside ${g.rates.roadside}, wild ${g.rates.wild}, deep ${g.rates.deep}, night x${g.rates.nightMultiplier}.`);
  if (g.theme) { md.push(''); md.push(`*${g.theme.pacing}* Signature: ${g.theme.signature}. Rule: ${g.theme.avoid}.`); }
  if (g.siege) md.push(`Siege: ${g.siege.faction} under ${nm(g.siege.tyrantSpeciesId)} (starts ${g.siege.initialState}).`);
  md.push('');
  md.push(`- **Roadside:** ${fmt(g.tables.roadside)}`);
  md.push(`- **Wild:** ${fmt(g.tables.wild)}`);
  md.push(`- **Deep:** ${fmt(g.tables.deep)}`);
  md.push(`- **Night:** ${fmt(g.tables.night)}`);
  if (g.borderBleed.length) md.push(`- **Border strays:** ${g.borderBleed.map((b) => `${nm(b.speciesId)} (from ${regById.get(b.from).name})`).join(', ')}`);
}
md.push('');

const jsonOut = JSON.stringify(data, null, 1) + '\n';
const mdOut = md.join('\n');
const files = [['Data/World/encounters.json', jsonOut], ['10_World/encounter_tables.md', mdOut]];
if (process.argv.includes('--check')) {
  let stale = false;
  for (const [f, body] of files) {
    const p = path.join(root, f);
    if (!fs.existsSync(p) || fs.readFileSync(p, 'utf8') !== body) { console.error('stale or missing: ' + f); stale = true; }
  }
  process.exit(stale ? 1 : 0);
}
for (const [f, body] of files) fs.writeFileSync(path.join(root, f), body);
const thinN = regionRows.filter((g) => g.thin).length;
console.log(`Encounters: ${regionRows.length} regions (${thinN} thin), ${routes.length} routes -> Data/World/encounters.json, 10_World/encounter_tables.md`);
