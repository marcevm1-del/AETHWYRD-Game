// Builds Data/World/region_graph.json from data that already exists (Wave F-lite, upgrade v10 section 9.1).
//   node Tools/atlas/build_region_graph.js          write the file
//   node Tools/atlas/build_region_graph.js --check  exit 1 if the file on disk differs from what would be written
//
// Nothing here is invented: every edge comes from one of three sources.
//   road   - a roads[] entry of physical_map.json joins the regions of its two end settlements
//            (km = the road's lengthKm; passId and river crossings are copied from the road)
//   sea    - a 'by: sea' leg of a corridor in physical_map.json (km = the leg's lengthKm)
//   border - two surface regions whose cells touch in the physical map's region raster
//            (km = straight-line distance between the two region anchors in regions.json, times unitKm;
//             lowestCrossingM = the lowest height at which the border can be crossed;
//             foot = lowestCrossingM <= passLimitM (the 2,000 m limit the roads obey) and the shared border is at least 1 km)
// Portal / waystone edges are NOT generated: Canon defines waystones only as respawn points and the proposed fast
// travel is between attuned waystones the player places, so there is no authored place to connect yet.
// regions.json and physical_map.json are read only.
const fs = require('fs');
const path = require('path');

const ROOT = path.join(__dirname, '..', '..');
const OUT = path.join(ROOT, 'Data', 'World', 'region_graph.json');
const regions = JSON.parse(fs.readFileSync(path.join(ROOT, 'Data', 'World', 'regions.json'), 'utf8'));
const pm = JSON.parse(fs.readFileSync(path.join(ROOT, 'Data', 'World', 'physical_map.json'), 'utf8'));
const tuning = JSON.parse(fs.readFileSync(path.join(ROOT, 'Data', 'World', 'world_tuning.json'), 'utf8'));

const unitKm = pm.grid.unitKm;
const cellKm = pm.grid.cellKm;
const passLimitM = pm.tuning.passLimitM;
const MIN_WALK_BORDER_KM = 1; // regions that touch along less than this are not a walkable border (one raster cell pair)
const round = (v, d = 1) => Math.round(v * 10 ** d) / 10 ** d;

const surface = regions.filter(r => r.layer === 'surface' && r.map);
const byId = Object.fromEntries(surface.map(r => [r.id, r]));
const settlementRegion = Object.fromEntries(pm.settlements.map(s => [s.id, s.region]));
const settlementByName = Object.fromEntries(pm.settlements.map(s => [s.name, s]));
const passById = Object.fromEntries(pm.passes.map(p => [p.id, p]));

const edges = [];

// roads
for (const r of pm.roads) {
  const a = settlementRegion[r.from], b = settlementRegion[r.to];
  if (!a || !b) throw new Error(`${r.id}: end settlement has no region`);
  const pass = r.passId ? passById[r.passId] : null;
  const via = (r.regions || []).filter(x => x !== a && x !== b);
  const widest = (r.crossings || []).reduce((m, c) => Math.max(m, c.widthM), 0);
  const e = {
    id: 'edge_' + r.id, a, b, kind: pass ? 'pass' : 'road', km: r.lengthKm, kmBasis: 'road_length', foot: true,
    roadId: r.id
  };
  if (pass) { e.passId = pass.id; e.passName = pass.name; e.passM = pass.m; }
  if (via.length) e.via = via;
  if ((r.crossings || []).length) { e.riverCrossings = r.crossings.length; e.widestCrossingM = widest; }
  edges.push(e);
}

// sea legs
for (const c of pm.corridors) for (const leg of c.legs) {
  if (leg.by !== 'sea') continue;
  const sa = settlementByName[leg.from], sb = settlementByName[leg.to];
  if (!sa || !sb) throw new Error(`corridor ${c.id}: sea leg ${leg.from} -> ${leg.to} has an unknown settlement`);
  edges.push({
    id: `edge_sea_${sa.region.slice(4)}_${sb.region.slice(4)}`, a: sa.region, b: sb.region, kind: 'sea',
    km: leg.lengthKm, kmBasis: 'corridor_leg', foot: false, corridorId: c.id
  });
}

// decided sea legs (Canon section 6 WF3, decided 2026-11-07): the Kitsune Isles touch no land, so a sailed leg
// Hoshizora City -> Fox Shrine Isle joins them to the mainland. Length = straight line between the two anchors (atlas unchanged).
for (const [from, to] of [['Hoshizora City', 'Fox Shrine Isle']]) {
  const sa = settlementByName[from], sb = settlementByName[to];
  if (!sa || !sb) throw new Error(`decided sea leg ${from} -> ${to} has an unknown settlement`);
  edges.push({
    id: `edge_sea_${sa.region.slice(4)}_${sb.region.slice(4)}`, a: sa.region, b: sb.region, kind: 'sea',
    km: Math.round(Math.hypot(sa.x - sb.x, sa.y - sb.y) * 10) / 10, kmBasis: 'anchor_straight_line', foot: false
  });
}

// borders from the region raster
const legend = pm.regions.legend;
const KEY = '0123456789abcdefghijklmnopqrstuvwxyzABC';
const rows = pm.regions.rows;
const elev = pm.elevation.rows;
const H = rows.length, W = rows[0].length;
const idx = ch => ch === '.' ? -1 : KEY.indexOf(ch);
const pairs = new Map(); // "i|j" (i<j) -> { n, low }
function touch(i, j, m) {
  if (i < 0 || j < 0 || i === j) return;
  const k = i < j ? `${i}|${j}` : `${j}|${i}`;
  const p = pairs.get(k) || { n: 0, low: Infinity };
  p.n++; if (m < p.low) p.low = m; pairs.set(k, p);
}
for (let y = 0; y < H; y++) for (let x = 0; x < W; x++) {
  const i = idx(rows[y][x]);
  if (i < 0) continue;
  if (x + 1 < W) touch(i, idx(rows[y][x + 1]), Math.max(elev[y][x], elev[y][x + 1]));
  if (y + 1 < H) touch(i, idx(rows[y + 1][x]), Math.max(elev[y][x], elev[y + 1][x]));
}
const borderEdges = [];
for (const [k, p] of pairs) {
  const [i, j] = k.split('|').map(Number);
  let a = legend[i], b = legend[j];
  if (a > b) [a, b] = [b, a];
  const ra = byId[a], rb = byId[b];
  if (!ra || !rb) throw new Error(`raster region ${a} / ${b} is not a surface region`);
  const d = Math.hypot(ra.map.at[0] - rb.map.at[0], ra.map.at[1] - rb.map.at[1]) * unitKm;
  borderEdges.push({
    id: `edge_border_${a.slice(4)}_${b.slice(4)}`, a, b, kind: 'border', km: round(d), kmBasis: 'anchor_straight_line',
    foot: p.low <= passLimitM && p.n * cellKm >= MIN_WALK_BORDER_KM, borderKm: round(p.n * cellKm), lowestCrossingM: Math.round(p.low)
  });
}
borderEdges.sort((x, y) => x.id < y.id ? -1 : 1);
edges.push(...borderEdges);

const nodes = surface.map(r => {
  const n = { id: r.id, name: r.name, ring: r.ring, at: r.map.at };
  if (r.map.isle) n.isle = true;
  if (r.map.floating) n.floating = true;
  return n;
});

const out = {
  version: 1,
  note: 'Generated by Tools/atlas/build_region_graph.js from physical_map.json (roads, passes, corridors, region raster) and regions.json; do not edit by hand. Docs: 12_Systems/world_graph.md.',
  source: { physicalMap: 'Data/World/physical_map.json', regions: 'Data/World/regions.json', startRegion: (tuning.map.startVisited || [])[0] },
  scale: { unitKm, passLimitM, minWalkBorderKm: MIN_WALK_BORDER_KM },
  edgeKinds: {
    road: 'a trade road between two regions (physical_map roads[])',
    pass: 'a road that crosses a named high pass (passId, passM)',
    sea: 'a sailed leg of a corridor',
    border: 'two regions touch in the atlas raster; foot=false when the lowest crossing is above the pass limit or the shared border is under 1 km'
  },
  portals: [],
  nodes,
  edges
};
const text = JSON.stringify(out, null, 1) + '\n';
if (process.argv.includes('--check')) {
  const cur = fs.existsSync(OUT) ? fs.readFileSync(OUT, 'utf8') : '';
  if (cur.split('\r\n').join('\n') !== text) { console.error('region_graph.json is out of date: run node Tools/atlas/build_region_graph.js'); process.exit(1); }
  console.log('region_graph.json is up to date');
} else {
  fs.writeFileSync(OUT, text);
  const k = {}; for (const e of edges) k[e.kind] = (k[e.kind] || 0) + 1;
  console.log(`region_graph.json: ${nodes.length} nodes, ${edges.length} edges`, k);
}
