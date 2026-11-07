// Wave F-lite validator rules (called from validate.js): Data/World/region_graph.json, labyrinth.json, underworld.json.
// Errors fail `npm run build`. Warnings are findings in the data that this wave deliberately does not fix (regions.json,
// Canon and the atlas stay as they are); they are counted here, NOT in the physical-map warning count.
//   Region graph : schema; file is what Tools/atlas/build_region_graph.js writes; nodes are exactly the surface regions;
//                  every physical_map road and sea leg is an edge of the same length; borders obey the pass limit;
//                  every region is reachable from the start region unless it is on KNOWN_UNREACHABLE (then a warning).
//   Labyrinth    : schema; file is what Tools/atlas/build_labyrinth_registry.js writes; 120 contiguous floors in the 3 bands of
//                  regions.json; one stair per floor pair; a guardian every tenth floor; towns/camps match the band; hidden
//                  floors sit behind hidden stairs; dungeons.json floors sit inside their region's band.
//   Underworld   : schema; 5 layers equal the 5 non-Labyrinth underworld rows of regions.json; gates equal map.at and name the
//                  surface region that owns that point in the region raster; back-doors resolve to Labyrinth floors.
const fs = require('fs');
const path = require('path');
const { spawnSync } = require('child_process');

const RANK_ORDER = ['F', 'E', 'D', 'C', 'B', 'A', 'S', 'SS', 'SSS', 'EX'];
const rankVal = r => { const m = /^([A-Z]+)([+-]?)$/.exec(r || ''); return m ? RANK_ORDER.indexOf(m[1]) * 3 + (m[2] === '+' ? 1 : m[2] === '-' ? -1 : 0) : NaN; };
// Surface regions the graph is allowed to leave unreachable (each becomes a warning, anything else is an error).
const KNOWN_UNREACHABLE = {
  reg_kitsune_isles: 'no sailed leg or border in the data (the Naming Voyage is the only sea leg)',
  reg_sky_archipelago: 'it floats; Canon bars flying mounts, so no walkable or sailed way exists'
};

function run(ctx) {
  const { DATA, load, check, schema, err, regions } = ctx;
  const warnings = [];
  const counts = { unreachable: 0, bandRank: 0, layerDepth: 0, other: 0 };
  const W = (k, m) => { counts[k]++; warnings.push('graph ' + m); };
  const has = f => fs.existsSync(path.join(DATA, f));
  const surface = regions.filter(r => r.layer === 'surface');
  const regionById = Object.fromEntries(regions.map(r => [r.id, r]));
  const ROOT = path.join(DATA, '..');
  const fresh = (script, file) => {
    const r = spawnSync(process.execPath, [path.join(ROOT, 'Tools', 'atlas', script), '--check'], { encoding: 'utf8' });
    if (r.status !== 0) err(file, `out of date: run node Tools/atlas/${script} (${(r.stderr || '').trim()})`);
  };
  const pmFile = path.join(DATA, 'World', 'physical_map.json');
  const pm = fs.existsSync(pmFile) ? JSON.parse(fs.readFileSync(pmFile, 'utf8')) : null;

  // ---------- region graph ----------
  const GF = 'World/region_graph.json';
  if (!has(GF)) err(GF, 'file missing');
  else {
    const g = load(GF);
    check(g, schema('region_graph'), GF);
    if (pm) fresh('build_region_graph.js', GF);
    const nodeIds = g.nodes.map(n => n.id);
    if (new Set(nodeIds).size !== nodeIds.length) err(GF, 'duplicate node id');
    const want = surface.map(r => r.id).sort().join(',');
    if (nodeIds.slice().sort().join(',') !== want) err(GF, `nodes must be exactly the ${surface.length} surface regions of regions.json`);
    for (const n of g.nodes) {
      const r = regionById[n.id];
      if (r && r.map && (r.map.at[0] !== n.at[0] || r.map.at[1] !== n.at[1])) err(n.id, 'node position differs from regions.json map.at');
    }
    const nodeSet = new Set(nodeIds), edgeIds = new Set();
    for (const e of g.edges) {
      if (edgeIds.has(e.id)) err(e.id, 'duplicate edge id'); edgeIds.add(e.id);
      if (!nodeSet.has(e.a) || !nodeSet.has(e.b)) err(e.id, 'edge end is not a surface region');
      if (e.a === e.b) err(e.id, 'edge joins a region to itself');
      for (const v of e.via || []) if (!nodeSet.has(v)) err(e.id, `via ${v} is not a surface region`);
      if ((e.kind === 'pass') !== !!e.passId) err(e.id, 'passId must be set exactly on pass edges');
      if ((e.kind === 'road' || e.kind === 'pass') && !e.roadId) err(e.id, 'road edge needs roadId');
      if (e.kind === 'sea' && e.foot) err(e.id, 'a sea leg is sailed, not walked (foot must be false)');
      if (e.kind === 'border') {
        const ok = e.lowestCrossingM <= g.scale.passLimitM && e.borderKm >= (g.scale.minWalkBorderKm || 0);
        if (e.foot !== ok) err(e.id, `foot=${e.foot} but the border is ${e.borderKm} km with a lowest crossing of ${e.lowestCrossingM} m`);
      }
    }
    if (pm) {
      if (g.scale.unitKm !== pm.grid.unitKm) err(GF, 'scale.unitKm differs from physical_map.json grid.unitKm');
      for (const r of pm.roads) {
        const es = g.edges.filter(e => e.roadId === r.id);
        if (es.length !== 1) err(r.id, `must be exactly one graph edge (found ${es.length})`);
        else if (es[0].km !== r.lengthKm) err(r.id, `edge length ${es[0].km} km differs from the road's ${r.lengthKm} km`);
        else if ((es[0].passId || null) !== (r.passId || null)) err(r.id, 'pass differs from the road');
      }
      for (const c of pm.corridors) for (const leg of c.legs) if (leg.by === 'sea') {
        const es = g.edges.filter(e => e.kind === 'sea' && e.corridorId === c.id);
        if (!es.some(e => e.km === leg.lengthKm)) err(c.id, `sea leg ${leg.from} -> ${leg.to} (${leg.lengthKm} km) is not a graph edge`);
      }
    }
    // reachability from the start region (walk + sail)
    if (!nodeSet.has(g.source.startRegion)) err(GF, 'startRegion is not a node');
    else {
      const adj = {}; for (const id of nodeIds) adj[id] = [];
      for (const e of g.edges) if (e.foot || e.kind === 'sea') { adj[e.a].push(e.b); adj[e.b].push(e.a); }
      const seen = new Set([g.source.startRegion]); const st = [g.source.startRegion];
      while (st.length) { const c = st.pop(); for (const n of adj[c]) if (!seen.has(n)) { seen.add(n); st.push(n); } }
      for (const id of nodeIds) {
        if (seen.has(id)) { if (KNOWN_UNREACHABLE[id]) W('other', `${id} is now reachable: remove it from KNOWN_UNREACHABLE in graph_checks.js`); continue; }
        if (KNOWN_UNREACHABLE[id]) W('unreachable', `${id} cannot be reached from ${g.source.startRegion}: ${KNOWN_UNREACHABLE[id]} (finding, regions.json untouched)`);
        else err(id, `not reachable from ${g.source.startRegion} by road, border or sea: a new orphan region`);
      }
    }
  }

  // ---------- Labyrinth ----------
  const LF = 'World/labyrinth.json';
  let lab = null;
  if (!has(LF)) err(LF, 'file missing');
  else {
    lab = load(LF);
    check(lab, schema('labyrinth'), LF);
    fresh('build_labyrinth_registry.js', LF);
    const bandOf = n => lab.bands.find(b => n >= b.floors[0] && n <= b.floors[1]);
    // bands: partition 1..120, regions exist and match
    let next = 1;
    for (const b of lab.bands) {
      if (b.floors[0] !== next) err(b.id, `band starts at ${b.floors[0]}, expected ${next}`);
      next = b.floors[1] + 1;
      const r = regionById[b.regionId];
      if (!r || r.layer !== 'underworld') err(b.id, `${b.regionId} is not an underworld region of regions.json`);
      else {
        if (r.rankMin !== b.rankMin || r.rankMax !== b.rankMax || r.ring !== b.ring) err(b.id, 'rank or ring differs from regions.json');
        const m = /Floors (\d+)-(\d+)/.exec(r.name);
        if (m && (+m[1] !== b.floors[0] || +m[2] !== b.floors[1])) err(b.id, `floors ${b.floors} differ from the region name "${r.name}"`);
        if (rankVal(b.licenceRank) < rankVal(b.rankMin) && b.id !== 'upper') err(b.id, 'licence rank is below the band rank');
      }
    }
    if (next !== 121) err(LF, 'bands must cover floors 1-120');
    // floors
    lab.floors.forEach((f, i) => {
      const n = i + 1;
      if (f.n !== n || f.id !== 'flr_' + String(n).padStart(3, '0')) err(f.id || `floors[${i}]`, `floor ${n} out of order`);
      const b = bandOf(n);
      if (!b || b.id !== f.band) err(f.id, `band ${f.band} does not hold floor ${n}`);
      if (f.guardian !== (n % 10 === 0)) err(f.id, 'a guardian floor stands on every tenth floor and nowhere else');
      if (f.safe === 'town' && b && b.settlement !== 'towns') err(f.id, `a safe town in the ${b.id} band, which has ${b.settlement}`);
      if (f.safe === 'camp' && b && b.settlement === 'none') err(f.id, 'a camp in a band with none');
      if (rankVal(f.rankMin) > rankVal(f.rankMax)) err(f.id, 'rankMin above rankMax');
      const dec = lab.decades.find(d => n >= d.floors[0] && n <= d.floors[1]);
      if (!dec || dec.biome !== f.biome) err(f.id, 'biome differs from its decade');
      if (!!dec && !!dec.hidden !== !!f.hidden || !!dec && !!dec.secret !== !!f.secret) err(f.id, 'hidden/secret differs from its decade');
      for (const d of f.dungeonIds || []) if (!has('World/dungeons.json') || !load('World/dungeons.json').some(x => x.id === d && x.floors.includes(n))) err(f.id, `dungeon ${d} does not list floor ${n}`);
    });
    // decades: contiguous
    lab.decades.forEach((d, i) => { if (d.floors[0] !== i * 10 + 1 || d.floors[1] !== i * 10 + 10) err(`decades[${i}]`, 'decades are 10 floors each from floor 1'); });
    // decade rank vs band rank: findings, not errors (world.md and regions.json disagree)
    for (const d of lab.decades) {
      const band = bandOf(d.floors[1]);
      if (band && rankVal(d.rankMax) > rankVal(band.rankMax))
        W('bandRank', `floors ${d.floors[0]}-${d.floors[1]} (${d.biome}) run up to rank ${d.rankMax} in world.md, above the ${band.id} band's regions.json rankMax ${band.rankMax}`);
    }
    // stairs
    lab.stairs.forEach((s, i) => {
      const n = i + 1;
      if (s.from !== n || s.to !== n + 1) err(s.id, `stair ${i} must join floor ${n} to ${n + 1}`);
      if (s.id !== `stair_${String(s.from).padStart(3, '0')}_${String(s.to).padStart(3, '0')}`) err(s.id, 'id does not match from/to');
      const into = lab.bands.find(b => b.floors[0] === s.to);
      if ((into ? into.licenceRank : undefined) !== s.licenceRank) err(s.id, 'a licence rank belongs on the stair into a new band and nowhere else');
      const dec = lab.decades.find(d => s.to >= d.floors[0] && s.to <= d.floors[1]);
      const expectHidden = !!dec && (dec.hidden || dec.secret) && s.to === dec.floors[0];
      if (!!s.hidden !== !!expectHidden) err(s.id, 'only the stair into a hidden or secret decade is hidden');
    });
    // back-doors
    for (const bd of lab.backDoors) {
      if (bd.floor < 1 || bd.floor > 120) err(bd.id, 'floor out of range');
      const r = regionById[bd.regionId];
      if (!r || r.layer !== 'underworld' || /labyrinth/.test(bd.regionId)) err(bd.id, `${bd.regionId} is not an Underworld layer region`);
    }
    // entrance
    const upper = regionById.reg_labyrinth_upper;
    if (lab.entrance.regionId !== 'reg_aldmere' || !regionById.reg_aldmere) err(LF, 'the entrance is beneath Aldmere City');
    if (upper && (upper.map.at[0] !== lab.entrance.mapAt[0] || upper.map.at[1] !== lab.entrance.mapAt[1])) err(LF, 'entrance.mapAt differs from the upper band gate');
    // start-heard matches world_tuning
    const wt = load('World/world_tuning.json');
    const heardInTuning = (wt.map.startHeard || []).includes('reg_labyrinth_upper');
    if (heardInTuning !== (lab.startHeard.length > 0)) err(LF, 'startHeard floors must match world_tuning map.startHeard (reg_labyrinth_upper)');
    // dungeons.json floors sit inside their region's band
    if (has('World/dungeons.json')) for (const d of load('World/dungeons.json')) {
      const b = lab.bands.find(x => x.regionId === d.regionId);
      if (!b) { err(d.id, `${d.regionId} is not a Labyrinth band`); continue; }
      for (const n of d.floors) {
        if (n < b.floors[0] || n > b.floors[1]) err(d.id, `floor ${n} is outside ${b.id} (${b.floors[0]}-${b.floors[1]})`);
        else if (!(lab.floors[n - 1].dungeonIds || []).includes(d.id)) err(d.id, `floor ${n} does not list this dungeon`);
      }
    }
  }

  // ---------- Underworld ----------
  const UF = 'World/underworld.json';
  if (!has(UF)) err(UF, 'file missing');
  else {
    const u = load(UF);
    check(u, schema('underworld'), UF);
    const uw = regions.filter(r => r.layer === 'underworld' && !/^reg_labyrinth_/.test(r.id)).map(r => r.id).sort().join(',');
    if (u.layers.map(l => l.regionId).sort().join(',') !== uw) err(UF, 'layers must be exactly the 5 non-Labyrinth underworld rows of regions.json');
    u.layers.forEach((l, i) => {
      if (l.layer !== i + 1) err(l.regionId, `layers must be in Canon order (expected layer ${i + 1})`);
      const r = regionById[l.regionId]; if (!r) return;
      if (r.rankMin !== l.rankMin || r.rankMax !== l.rankMax || r.ring !== l.ring) err(l.regionId, 'rank or ring differs from regions.json');
      if (r.map.at[0] !== l.gate.at[0] || r.map.at[1] !== l.gate.at[1]) err(l.regionId, 'gate.at differs from regions.json map.at');
      if (!regionById[l.gate.surfaceRegionId] || regionById[l.gate.surfaceRegionId].layer !== 'surface') err(l.regionId, 'gate.surfaceRegionId is not a surface region');
      if (pm) {
        const rows = pm.regions.rows, KEY = '0123456789abcdefghijklmnopqrstuvwxyzABC', cell = pm.grid.cellKm;
        const ch = rows[Math.floor(l.gate.at[1] / cell)][Math.floor(l.gate.at[0] / cell)];
        const owner = ch === '.' ? null : pm.regions.legend[KEY.indexOf(ch)];
        if (owner !== l.gate.surfaceRegionId) err(l.regionId, `gate sits in ${owner} on the map, not ${l.gate.surfaceRegionId}`);
      }
      if (r.map.depth !== l.regionsJsonDepth) err(l.regionId, 'regionsJsonDepth differs from regions.json map.depth');
      if (r.map.depth !== l.layer) W('layerDepth', `${l.regionId} is Underworld layer ${l.layer} in world.md but map.depth ${r.map.depth} in regions.json (regions.json untouched)`);
      if (l.labyrinthBackDoor) {
        const bd = lab && lab.backDoors.find(b => b.id === l.labyrinthBackDoor);
        if (!bd) err(l.regionId, `back-door ${l.labyrinthBackDoor} not found in labyrinth.json`);
        else if (bd.layer !== l.layer || bd.regionId !== l.regionId) err(l.regionId, 'back-door points at a different layer');
      }
    });
    if (lab) for (const bd of lab.backDoors) {
      const l = u.layers.find(x => x.layer === bd.layer);
      if (!l || l.labyrinthBackDoor !== bd.id) err(bd.id, `layer ${bd.layer} does not list this back-door`);
    }
  }

  const summary = `graph findings ${warnings.length} (unreachable regions ${counts.unreachable}, Labyrinth rank overlaps ${counts.bandRank}, Underworld depth mismatches ${counts.layerDepth}, other ${counts.other})`;
  return { warnings, counts, summary };
}
module.exports = { run };
