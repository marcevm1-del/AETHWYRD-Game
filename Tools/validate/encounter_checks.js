// Validator for Data/World/encounters.json. Rules: every region has exactly one entry; every species exists, is neither a Tyrant nor a Unique,
// is a resident of the region (or, for borderBleed, of the named neighbour) and is not above the region's top rank; groups obey the ring cap;
// routes match the non-border edges of region_graph.json; a surface region with roads or settlements has a roadside table; no table is empty
// in a non-thin region. It also checks the file is not stale against the generator, so a forgotten regeneration cannot pass silently.
const fs = require('fs');
const path = require('path');
const { spawnSync } = require('child_process');

const RANKS = ['F-', 'F', 'F+', 'E-', 'E', 'E+', 'D-', 'D', 'D+', 'C-', 'C', 'C+', 'B-', 'B', 'B+', 'A-', 'A', 'A+', 'S-', 'S', 'S+', 'SS-', 'SS', 'SS+', 'SSS-', 'SSS', 'SSS+', 'EX'];
const rv = (r) => RANKS.indexOf(r);

exports.run = function (ctx) {
  const { DATA, load, check, schema, err, regions, species } = ctx;
  const F = 'World/encounters.json';
  if (!fs.existsSync(path.join(DATA, F))) { err(F, 'file missing (run node Tools/world/build_encounters.js)'); return; }
  const enc = load(F);
  check(enc, schema('encounters'), F);
  const regById = new Map(regions.map((r) => [r.id, r]));
  const graph = load('World/region_graph.json');
  const pop = load('Monsters/population.json');
  const homes = new Map();
  for (const p of pop) { if (!homes.has(p.regionId)) homes.set(p.regionId, new Set()); homes.get(p.regionId).add(p.speciesId); }
  const cap = enc.rules.groupCapByRing;

  const seen = new Set();
  for (const g of enc.regions) {
    const id = g.regionId;
    if (seen.has(id)) err(id, 'duplicate region in encounters.json');
    seen.add(id);
    const r = regById.get(id);
    if (!r) { err(id, 'region does not exist'); continue; }
    if (g.ring !== r.ring) err(id, `ring ${g.ring} does not match regions.json (${r.ring})`);
    const topIdx = Math.max(...RANKS.map((x, i) => [x, i]).filter(([x]) => x.replace(/[+-]$/, '') === r.rankMax).map(([, i]) => i));
    const rows = Object.entries(g.tables).flatMap(([z, t]) => t.map((x) => ({ z, x, from: id })));
    for (const b of g.borderBleed) rows.push({ z: 'borderBleed', x: b, from: b.from });
    for (const { z, x, from } of rows) {
      const s = species.get(x.speciesId);
      const where = `${id} ${z}`;
      if (!s) { err(where, `species ${x.speciesId} does not exist`); continue; }
      if (s.isTyrant || s.isUnique) err(where, `${x.speciesId} is a Tyrant or Unique; never in a random table`);
      if (!(homes.get(from) || new Set()).has(x.speciesId)) err(where, `${x.speciesId} has no population entry in ${from}`);
      if (!g.thin && rv(s.rank) > topIdx) err(where, `${x.speciesId} (${s.rank}) is above the region top rank ${r.rankMax}`);
      if (x.group[0] > x.group[1]) err(where, `${x.speciesId} group min > max`);
      if (x.group[1] > cap[String(r.ring)]) err(where, `${x.speciesId} group max ${x.group[1]} exceeds the ring ${r.ring} cap ${cap[String(r.ring)]}`);
    }
    if (!g.thin) for (const z of ['wild', 'deep', 'night']) if (!g.tables[z].length) err(id, `${z} table is empty in a non-thin region`);
    const walkable = graph.edges.some((e) => e.kind !== 'border' && (e.a === id || e.b === id));
    if (r.layer === 'surface' && (walkable || (r.defenceSettlements || []).length) && !g.tables.roadside.length) err(id, 'surface region with a road or settlement has no roadside table');
    if (!r.noSiege && g.siege && g.siege.tyrantSpeciesId !== r.tyrantSpeciesId) err(id, 'siege tyrant does not match regions.json');
  }
  for (const r of regions) if (!seen.has(r.id)) err(r.id, 'region has no entry in encounters.json');

  const edges = new Map(graph.edges.filter((e) => e.kind !== 'border').map((e) => [e.id, e]));
  const rt = new Set();
  for (const x of enc.routes) {
    rt.add(x.edgeId);
    const e = edges.get(x.edgeId);
    if (!e) { err(x.edgeId, 'route is not a non-border edge of region_graph.json'); continue; }
    if (e.km !== x.km || e.a !== x.a || e.b !== x.b) err(x.edgeId, 'route disagrees with region_graph.json');
  }
  for (const id of edges.keys()) if (!rt.has(id)) err(id, 'edge has no route entry');

  // stale check: the generator re-derives both files and compares
  const gen = path.resolve(DATA, '..', 'Tools', 'world', 'build_encounters.js');
  if (fs.existsSync(gen)) {
    const res = spawnSync(process.execPath, [gen, '--check'], { encoding: 'utf8' });
    if (res.status !== 0) err(F, 'encounters.json or 10_World/encounter_tables.md is stale: run node Tools/world/build_encounters.js');
  } else err(F, 'generator Tools/world/build_encounters.js is missing, so staleness could not be assessed (NOT ASSESSED)');
};
