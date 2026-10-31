#!/usr/bin/env node
// Builds the physical geography of Aetheria from the atlas (Tools/atlas/aetheria_atlas.html, coastline seed 1207):
//   Data/World/physical_map.json   heightmap (m), biomes, regions, ranges, peaks, rivers, lakes, seas, passes,
//                                  the five trade corridors and the consistency checks
//   10_World/maps/physical_map.png hillshaded relief with rivers, ranges, passes and labels (labels need Playwright;
//                                  without it the unlabelled relief is written instead)
// Everything is derived from the atlas's own land field and relief (atlas_field.js reproduces them exactly), so the
// coast, the region borders and where the mountains stand are the atlas's. This script only turns the relief into
// metres, lets water run downhill, finds the ranges and checks the corridors.
// Deterministic: same data, same output. Docs: 10_World/physical_geography.md.
//
// Usage: node Tools/atlas/build_physical_map.js [--no-png] [--json <path>] [--png <path>] [--quiet]
'use strict';
const fs = require('fs');
const path = require('path');
const os = require('os');
const zlib = require('zlib');
const A = require('./atlas_field.js');

const ROOT = A.ROOT;
const argv = process.argv.slice(2);
const opt = (k, d) => { const i = argv.indexOf(k); return i >= 0 ? argv[i + 1] : d; };
const OUT_JSON = path.resolve(opt('--json', path.join(ROOT, 'Data', 'World', 'physical_map.json')));
const OUT_PNG = path.resolve(opt('--png', path.join(ROOT, '10_World', 'maps', 'physical_map.png')));
const NO_PNG = argv.includes('--no-png');
const QUIET = argv.includes('--quiet');
const log = (...a) => { if (!QUIET) console.log(...a); };

// ---------------------------------------------------------------- tuning (all in one place, documented in physical_geography.md)
const T = {
  cell: 4,                 // atlas pixels per output cell: 1200x800 atlas canvas -> 300x200 cells of 0.5 km
  passLimitM: 2000,        // highest ground a trade road may cross (a summer pass); higher needs a carved pass
  passNotchM: 1900,        // a carved pass is cut down to this height
  passReportM: 700,        // a corridor's highest point above this is listed as a pass
  approachKm: 2.5,         // a road reaches a town when it gets this close (the last climb is the town's own stair or lift)
  breachMaxM: 120,         // hollows are drained by cutting their outlet up to this deep (plus breachMountain of the
  breachMountain: 0.5,     //   ground above 1000 m: mountain basins drain through gorges); deeper ones stay lakes
  rangeM: 1000,            // ground above this belongs to a range
  rangeMinKm2: 3,          // smallest range kept
  peakM: 1500,             // smallest summit listed
  lakeMinCells: 4,         // smallest lake kept (1 km^2)
  lakeMinDepthM: 6,
  lakeMaxDepthM: 120,      // lake floors are silted up to at most this far below the water
  riverMinFlow: 50,        // rain-weighted drainage (km^2) for a listed river at its mouth
  riverSourceFlow: 2.5,    // a river is traced upstream until its drainage drops below this
  tributaryFlow: 30,       // tributaries this big are traced too
  streamFlow: 8,           // "a river runs here" for the lore checks
};
// Rain weight per terrain, used for river flow (desert rivers stay small, jungle rivers big).
const RAIN = { plains: .7, forest: 1, swamp: 1.2, steppe: .35, mountain: 1.1, volcanic: .6, tundra: .5, desert: .08, jungle: 1.5, spirit: 1, demon: .35 };
// Relief value h (the atlas's hgt, 0 at the shore, ~0.3 lowland, up to ~1.45) to metres.
const toMetres = hv => 750 * hv + 2600 * Math.pow(Math.max(0, hv - 0.5), 1.4);
// Sea floor from the atlas's own depth shading (distance from the coast, km).
const seaDepth = dkm => -(5 + 120 * A.smooth(0, 4, dkm) + 1600 * A.smooth(4, 25, dkm));
// Climate: sea-level annual mean temperature by latitude (y = 0 north, 100 south), lapse 6.5 C/km.
const seaTempC = y => 0.28 * y;
const tempC = (y, m) => seaTempC(y) - 6.5 * Math.max(0, m) / 1000;
const snowlineM = y => Math.max(0, (seaTempC(y) + 5) / 6.5 * 1000);   // permanent snow where the mean is below -5 C
const treelineM = y => Math.max(0, (seaTempC(y) + 1) / 6.5 * 1000);   // trees thin out where the mean is below -1 C
const BELTS = [
  { id: 'polar', name: 'Polar coast and ice', yMax: 14, text: 'sea ice in winter, tundra, glaciers to sea level' },
  { id: 'boreal', name: 'Boreal north', yMax: 32, text: 'long winters, pine and tundra, snow on every range' },
  { id: 'temperate', name: 'Temperate heartland', yMax: 68, text: 'four mild seasons, wheat, oak and fen; snow only on the high peaks' },
  { id: 'warm', name: 'Warm south', yMax: 100, text: 'hot dry summers; desert in the south-centre, jungle and mire in the wet south-west' },
];
const beltOf = y => BELTS.find(b => y <= b.yMax).id;

// ---------------------------------------------------------------- names (only from existing text; anything else is proposed)
// Ranges are found per region; this table names them. src = where the name comes from.
const RANGE_NAMES = {
  reg_iron_hold: { name: 'Iron Hold Peaks', src: '10_World/world.md §9 heading' },
  reg_dragon_spine: { name: 'Dragon Spine', src: 'regions.json; gazetteer "The range is a ridge of black basalt peaks"' },
  reg_shen_lu: { name: 'Hundred-Stair Mountains', src: 'gazetteer.json epithet of Shen-Lu' },
  reg_haneul: { name: 'Haneul Highlands', src: '10_World/world.md §13 heading' },
  reg_heavenreach: { name: 'Heavenreach Plateau', src: '10_World/world.md §16 heading' },
  reg_apu_highlands: { name: 'Carved Mountains', src: 'gazetteer.json epithet of the Apu Highlands' },
  reg_stormreach: { name: 'Black Peaks', src: 'gazetteer.json landmark of Stormreach ("mountains scorched black by lightning")' },
  reg_gearholm: { name: 'Clockwork Mountain', src: 'gazetteer.json epithet of Gearholm' },
  reg_quaking_lands: { name: "Quakeback's Ridge", src: 'gazetteer.json landmark of the Quaking Lands ("a mountain ridge that breathes")' },
  reg_frostveil: { name: 'Glacier Teeth', src: '10_World/world.md Frostveil sub-zone, read here as its glaciated range', proposed: true },
  reg_hoshizora: { name: 'Hoshizora Cedar Mountains', src: 'gazetteer geography "steep cedar mountains capped by the Oni Volcano"', proposed: true },
  reg_zarvan: { name: 'Zarvan Mountains', src: 'gazetteer geography "The mountains of Zarvan are high, dry and bare"', proposed: true },
  reg_vharlen: { name: 'Frontier Mountains', src: 'gazetteer: "bordered by mountains to the north"; landmark "The Frontier Forts" in their passes', proposed: true },
  reg_cinderhole: { name: 'Cinder Hills', src: 'gazetteer geography "a vast pit in a range of barren hills"', proposed: true },
  reg_nox_dominion: { name: 'Nox Fire Mountains', src: 'gazetteer geography "active volcanoes ... a mountain of fire"', proposed: true },
  reg_whitewater_reach: { name: 'Whitewater Fells', src: 'none; high tundra behind the ice coast', proposed: true },
};
// Canon summits: put on the highest peak of that region's range (or the extreme named).
const PEAK_NAMES = {
  reg_apu_highlands: { name: "The Giant's Bed", src: 'gazetteer: "on the tallest stands the Giant\'s Bed"', pick: 'highest' },
  reg_heavenreach: { name: 'Tribute Peak', src: 'gazetteer landmark: "a summit above the eyries"', pick: 'highest' },
  reg_hoshizora: { name: 'Oni Volcano', src: 'gazetteer: "steep cedar mountains capped by the Oni Volcano"', pick: 'highest' },
  reg_dragon_spine: { name: 'The Burning Peaks', src: 'gazetteer landmark: "active volcanoes at the southern end of the range"', pick: 'southmost' },
  reg_nox_dominion: { name: "The Overlord's mountain of fire", src: 'gazetteer: "the Overlord\'s citadel, a fortress of black stone on a mountain of fire" (placement proposed)', pick: 'highest', proposed: true },
};
// Rivers are named after the innermost realm they water (lowest ring); those names are proposals until lore names them.
// Canon streams: matched by a place they must pass.
const CANON_RIVERS = [
  { name: 'Millbrook', near: [76.1, 58.7], km: 2.5, src: 'gazetteer Whisperwood: "dozens of brooks that feed the Millbrook stream"' },
];
const CANON_LAKES = [
  { region: 'reg_sylvaran', name: 'Moonwell Lake', src: '10_World/world.md Sylvaran sub-zone' },
  { region: 'reg_frostveil', name: "Glacirra's Lake", src: '10_World/world.md Frostveil sub-zone' },
];
// Canon passes: a region's lore says a road crosses its heights here.
const CANON_PASSES = {
  reg_haneul: { name: 'The Pass of the Red Gate', src: 'gazetteer Haneul: "a high pass between snowy peaks ... the capital sits in the saddle"; name from landmark "The Red Gate"', proposed: true },
  reg_ashira_vale: { name: 'The Hill Road', src: 'gazetteer Ashira Vale landmark: "The only road in"', keepLow: true },
  reg_vharlen: { name: 'The Frontier Forts passes', src: 'gazetteer Vharlen: "The frontier forts stand in the passes of the northern mountains"', toward: 'reg_nox_dominion' },
};
// The five corridors of 10_World/world_map_concept.md §3. Waypoints are regions.json places (or anchors).
const CORRIDORS = [
  { id: 'river_and_grain', name: 'River and grain', legs: [['reg_whisperwood:Brindlewick', 'reg_aldmere'], ['reg_aldmere', 'reg_velmark:Velmark ducal towns'], ['reg_velmark:Velmark ducal towns', 'reg_lirian:Lirian canal cities']] },
  { id: 'mountain_craft_and_oath', name: 'Mountain craft and oath', legs: [['reg_aldmere', 'reg_iron_hold:Karak Dûn'], ['reg_iron_hold:Karak Dûn', 'reg_cinderhole:Cinderhole'], ['reg_cinderhole:Cinderhole', 'reg_dragon_spine:dragon-bone monasteries']] },
  { id: 'sanctuary_and_memorial', name: 'Sanctuary and memorial', legs: [['reg_aldmere', 'reg_sylvaran:Canopy City Lothaniel'], ['reg_sylvaran:Canopy City Lothaniel', 'reg_ashira_vale:Ashira']] },
  { id: 'coastal_weather_and_navigation', name: 'Coastal weather and navigation', legs: [['reg_lirian:Lirian canal cities', 'reg_goldmere_coast:Port Goldmere'], ['reg_goldmere_coast:Port Goldmere', 'reg_true_name_isles:Naming Voyage harbor', 'sea']] },
  { id: 'desert_glass_and_caravan', name: 'Desert glass and caravan', legs: [['reg_mossdeep:Thimblefolk Mushroom Town', 'reg_sunscar:Oasis of Qadira'], ['reg_sunscar:Oasis of Qadira', 'reg_zaruma:Zaruma gold-road towns'], ['reg_sunscar:Oasis of Qadira', 'reg_zarvan:Zarvan garden cities'], ['reg_sunscar:Oasis of Qadira', "reg_dunewhale_drift:the town on Thalassa's back"]] },
];
// Lore says a river runs by these places (gazetteer geography); checked against the computed rivers.
const LORE_RIVERS = [
  ['reg_aldmere', null, 'the capital sits on a granite hill that the river curves around'],
  ['reg_whisperwood', 'Millbrook', 'brooks that feed the Millbrook stream'],
  ['reg_moraveil', null, 'a river runs through the middle'],
  ['reg_ashira_vale', 'Ashira', 'a clear, slow river runs through the middle'],
  ['reg_vharlen', null, 'the capital stands on a terrace above a great river'],
  ['reg_hoshizora', 'Hoshizora City', 'Hoshizora City stands at the mouth of the largest river'],
  ['reg_haneul', 'Haneul gate-towns', 'the river below runs fast and cold'],
  ['reg_greymoor', null, 'the flood basin of three rivers'],
  ['reg_xochitl_mire', null, 'a great basin where several rivers spread out'],
];

// ---------------------------------------------------------------- the atlas
const lands = A.loadLands();
const F = A.computeAtlasFields(lands);
const atlasRows = A.readAtlasRegions();
const W = F.W / T.cell, H = F.H / T.cell, N = W * H, CK = A.MAP_W / W; // 300 x 200, 0.5 km
const BIOME_CH = { plains: 'p', forest: 'f', swamp: 'w', steppe: 's', mountain: 'm', volcanic: 'v', tundra: 't', desert: 'd', jungle: 'j', spirit: 'i', demon: 'x', alpine: 'a', snow: 'n', beach: 'b', lake: 'l', sea: '~' };
const REG_CH = '0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ';
const cellOf = (ux, uy) => { const i = Math.max(0, Math.min(W - 1, Math.floor(ux / CK))), j = Math.max(0, Math.min(H - 1, Math.floor(uy / CK))); return j * W + i; };
const cx = c => (c % W + .5) * CK, cy = c => (Math.floor(c / W) + .5) * CK;
const r1 = v => Math.round(v * 10) / 10;
const idx = id => lands.findIndex(l => l.id === id);
const findings = [];

// Downsample: majority land/region/biome per block, mean relief.
const elev = new Float64Array(N), land = new Uint8Array(N), region = new Int16Array(N).fill(-1), base = new Array(N).fill('sea'), coastKm = new Float64Array(N);
{
  const hiM = new Float64Array(F.W * F.H);
  for (let k = 0; k < F.W * F.H; k++) hiM[k] = F.regionAt[k] >= 0 ? toMetres(F.hgt[k]) : seaDepth(-F.coast[k] / F.s);
  for (let j = 0; j < H; j++) for (let i = 0; i < W; i++) {
    const c = j * W + i, cnt = new Map(), bc = new Map(); let sum = 0, nl = 0, cd = 0;
    for (let y = 0; y < T.cell; y++) for (let x = 0; x < T.cell; x++) {
      const k = (j * T.cell + y) * F.W + i * T.cell + x; sum += hiM[k]; cd += F.coast[k] / F.s;
      const r = F.regionAt[k]; if (r >= 0) { nl++; cnt.set(r, (cnt.get(r) || 0) + 1); }
    }
    const n = T.cell * T.cell; let e = sum / n; coastKm[c] = cd / n;
    if (nl * 2 > n) {
      land[c] = 1; region[c] = [...cnt].sort((a, b) => b[1] - a[1] || a[0] - b[0])[0][0];
      for (let y = 0; y < T.cell; y++) for (let x = 0; x < T.cell; x++) { const k = (j * T.cell + y) * F.W + i * T.cell + x; if (F.regionAt[k] !== region[c]) continue; const b = A.TERRAIN_KINDS[F.biomeAt[k]]; bc.set(b, (bc.get(b) || 0) + 1); }
      base[c] = [...bc].sort((a, b) => b[1] - a[1] || (a[0] < b[0] ? -1 : 1))[0][0];
      if (e < 1) e = 1;
    } else if (e > -1) e = -1;
    elev[c] = e;
  }
}
const elevAtlas = Float64Array.from(elev); // before carving passes
const N8 = [[1, 0, 1], [-1, 0, 1], [0, 1, 1], [0, -1, 1], [1, 1, Math.SQRT2], [-1, 1, Math.SQRT2], [1, -1, Math.SQRT2], [-1, -1, Math.SQRT2]];
const nbrs = (c, f) => { const i = c % W, j = (c - i) / W; for (const [dx, dy, d] of N8) { const x = i + dx, y = j + dy; if (x >= 0 && y >= 0 && x < W && y < H) f(y * W + x, d * CK); } };

// Deterministic binary heap keyed (key, cell).
class Heap {
  constructor() { this.k = []; this.v = []; }
  get size() { return this.k.length; }
  less(a, b) { return this.k[a] < this.k[b] || (this.k[a] === this.k[b] && this.v[a] < this.v[b]); }
  swap(a, b) { [this.k[a], this.k[b]] = [this.k[b], this.k[a]]; [this.v[a], this.v[b]] = [this.v[b], this.v[a]]; }
  push(key, val) { this.k.push(key); this.v.push(val); let i = this.k.length - 1; while (i > 0) { const p = (i - 1) >> 1; if (this.less(i, p)) { this.swap(i, p); i = p; } else break; } }
  pop() {
    const key = this.k[0], val = this.v[0], lk = this.k.pop(), lv = this.v.pop();
    if (this.k.length) { this.k[0] = lk; this.v[0] = lv; let i = 0; for (;;) { const l = 2 * i + 1, r = l + 1; let m = i; if (l < this.k.length && this.less(l, m)) m = l; if (r < this.k.length && this.less(r, m)) m = r; if (m === i) break; this.swap(i, m); i = m; } }
    return [key, val];
  }
}

// ---------------------------------------------------------------- corridors and passes
function waypoint(spec) {
  const [rid, place] = spec.split(':'); const L = lands[idx(rid)];
  const at = place ? L.places[place] : [L.ax, L.ay];
  if (!at) throw new Error('no place ' + spec);
  const c = cellOf(at[0], at[1]);
  const set = []; for (let k = 0; k < N; k++) if (land[k] && Math.hypot(cx(k) - at[0], cy(k) - at[1]) <= T.approachKm) set.push(k);
  if (!set.length) { let best = -1, bd = 1e9; for (let k = 0; k < N; k++) if (land[k]) { const d = Math.hypot(cx(k) - at[0], cy(k) - at[1]); if (d < bd) { bd = d; best = k; } } set.push(best); }
  return { spec, region: rid, label: place || L.name, at, cell: land[c] ? c : set[0], set, m: Math.round(elev[land[c] ? c : set[0]]) };
}
// Minimax route over land between two cell sets: the lowest possible "highest point" on the way.
function bottleneck(S, Tset) {
  const best = new Float64Array(N).fill(Infinity), par = new Int32Array(N).fill(-1), hp = new Heap(), goal = new Uint8Array(N);
  for (const t of Tset) goal[t] = 1;
  for (const s of S) { best[s] = elev[s]; hp.push(elev[s], s); }
  let end = -1;
  while (hp.size) {
    const [b, c] = hp.pop(); if (b > best[c]) continue; if (goal[c]) { end = c; break; }
    nbrs(c, n => { if (!land[n]) return; const nb = Math.max(b, elev[n]); if (nb < best[n]) { best[n] = nb; par[n] = c; hp.push(nb, n); } });
  }
  if (end < 0) return null;
  const p = []; for (let c = end; c >= 0; c = par[c]) p.push(c); p.reverse();
  return { top: best[end], path: p };
}
// Cheapest road under the pass limit: distance, weighted by grade and altitude.
function road(S, Tset) {
  const dist = new Float64Array(N).fill(Infinity), par = new Int32Array(N).fill(-1), hp = new Heap(), goal = new Uint8Array(N);
  for (const t of Tset) goal[t] = 1;
  for (const s of S) if (elev[s] <= T.passLimitM) { dist[s] = 0; hp.push(0, s); }
  let end = -1;
  while (hp.size) {
    const [d, c] = hp.pop(); if (d > dist[c]) continue; if (goal[c]) { end = c; break; }
    nbrs(c, (n, km) => {
      if (!land[n] || elev[n] > T.passLimitM) return;
      const grade = Math.abs(elev[n] - elev[c]) / 1000 / km, alt = Math.max(0, (elev[n] - 900) / 500);
      const nd = d + km * (1 + 10 * grade + alt); if (nd < dist[n] - 1e-12) { dist[n] = nd; par[n] = c; hp.push(nd, n); }
    });
  }
  if (end < 0) return null;
  const p = []; for (let c = end; c >= 0; c = par[c]) p.push(c); p.reverse();
  return p;
}
function seaRoute(a, b) { // breadth-first over sea cells from the sea nearest a to the sea nearest b
  const nearSea = c => { let best = -1, bd = 1e9; for (let k = 0; k < N; k++) if (!land[k]) { const d = Math.hypot(cx(k) - cx(c), cy(k) - cy(c)); if (d < bd) { bd = d; best = k; } } return best; };
  const s = nearSea(a), t = nearSea(b), seen = new Int32Array(N).fill(-1), q = [s]; seen[s] = s;
  for (let qi = 0; qi < q.length; qi++) { const c = q[qi]; if (c === t) break; nbrs(c, n => { if (!land[n] && seen[n] < 0) { seen[n] = c; q.push(n); } }); }
  if (seen[t] < 0) return null; let km = 0; for (let c = t; c !== s; c = seen[c]) km += Math.hypot(cx(c) - cx(seen[c]), cy(c) - cy(seen[c]));
  return { km };
}
// Cut a notch along the lowest crossing so a road can get over (recorded as a carved pass).
function carve(bn) {
  let cut = 0, cells = 0, topCell = -1;
  for (const c of bn.path) if (elev[c] > T.passNotchM && (topCell < 0 || elev[c] > elev[topCell])) topCell = c;
  const was = elev[topCell];
  for (const c of bn.path) {
    if (elev[c] > T.passNotchM) { cut = Math.max(cut, elev[c] - T.passNotchM); elev[c] = T.passNotchM; cells++; }
    nbrs(c, n => { if (land[n] && elev[n] > T.passNotchM + 150) elev[n] = T.passNotchM + 150 + (elev[n] - T.passNotchM - 150) * 0.5; });
  }
  return { at: [r1(cx(topCell)), r1(cy(topCell))], wasM: Math.round(was), nowM: T.passNotchM, cells, maxCutM: Math.round(cut), region: lands[region[topCell]].id };
}
const carved = [];
const corridorOut = [];
for (const co of CORRIDORS) {
  const legs = [];
  for (const [fa, fb, mode] of co.legs) {
    const a = waypoint(fa), b = waypoint(fb);
    if (mode === 'sea') { const sr = seaRoute(a.cell, b.cell); legs.push({ from: a.label, to: b.label, by: 'sea', lengthKm: sr ? r1(sr.km) : null, passable: !!sr }); continue; }
    const bn = bottleneck(a.set, b.set); let carvedHere = null;
    if (!bn) { legs.push({ from: a.label, to: b.label, by: 'land', passable: false, note: 'no land route' }); continue; }
    if (bn.top > T.passLimitM) { carvedHere = carve(bn); carved.push(carvedHere); }
    const p = road(a.set, b.set);
    if (!p) { legs.push({ from: a.label, to: b.label, by: 'land', passable: false, note: 'no road under the pass limit' }); continue; }
    let km = 0, top = p[0], climb = 0; const regs = [];
    for (let i = 1; i < p.length; i++) { km += Math.hypot(cx(p[i]) - cx(p[i - 1]), cy(p[i]) - cy(p[i - 1])); climb += Math.max(0, elev[p[i]] - elev[p[i - 1]]); if (elev[p[i]] > elev[top]) top = p[i]; }
    for (const c of p) { const id = lands[region[c]].id; if (regs[regs.length - 1] !== id) regs.push(id); }
    legs.push({ from: a.label, to: b.label, by: 'land', passable: true, fromM: a.m, toM: b.m, lengthKm: r1(km), climbM: Math.round(climb), highestM: Math.round(elev[top]), highestAt: [r1(cx(top)), r1(cy(top))], highestRegion: lands[region[top]].id, regions: regs, carvedPass: carvedHere, _path: p, path: simplify(p.map(c => [cx(c), cy(c)]), 0.4).map(([x, y]) => [r1(x), r1(y)]) });
  }
  corridorOut.push({ id: co.id, name: co.name, passable: legs.every(l => l.passable), legs });
}

// ---------------------------------------------------------------- water: breach, fill, drain, accumulate (after any carving)
// Pass 1 (hybrid breaching): flood inward from the sea; when a cell lies below the way out, cut the way out down to
// it if that takes no more than breachMaxM, so shallow hollows drain through little gorges instead of becoming lakes.
// Pass 2 (filling): a clean priority-flood over the cut terrain; what still holds water is a lake.
const elevBeforeWater = Float64Array.from(elev);
{
  const z = Float64Array.from(elev), par = new Int32Array(N).fill(-1), done = new Uint8Array(N), hp = new Heap();
  for (let c = 0; c < N; c++) if (!land[c]) { done[c] = 1; let edge = false; nbrs(c, n => { if (land[n]) edge = true; }); if (edge) hp.push(0, c); }
  while (hp.size) {
    const [, c] = hp.pop(); const zc = land[c] ? z[c] : 0;
    nbrs(c, n => {
      if (done[n]) return; done[n] = 1; par[n] = c;
      if (elev[n] > zc) z[n] = elev[n];
      else {
        const path = []; let lev = elev[n] - 0.01, p = c, cut = 0;
        let top = 0;
        while (p >= 0 && land[p] && z[p] >= lev) { path.push([p, lev]); cut = Math.max(cut, elevBeforeWater[p] - lev); top = Math.max(top, elevBeforeWater[p]); lev -= 0.01; p = par[p]; }
        if (cut <= T.breachMaxM + T.breachMountain * Math.max(0, top - 1000) && lev > 0) { for (const [q, l] of path) { z[q] = l; if (elev[q] > l) elev[q] = l; } z[n] = elev[n]; }
        else z[n] = zc + 0.001;
      }
      hp.push(z[n], n);
    });
  }
}
const filled = Float64Array.from(elev), recv = new Int32Array(N).fill(-1), order = [];
{
  const done = new Uint8Array(N), hp = new Heap();
  for (let c = 0; c < N; c++) if (!land[c]) { done[c] = 1; let edge = false; nbrs(c, n => { if (land[n]) edge = true; }); if (edge) hp.push(0, c); }
  while (hp.size) {
    const [, c] = hp.pop(); if (land[c]) order.push(c);
    nbrs(c, n => { if (done[n]) return; done[n] = 1; filled[n] = Math.max(elev[n], (land[c] ? filled[c] : 0) + 0.001); recv[n] = c; hp.push(filled[n], n); });
  }
}
let breachCells = 0, breachMax = 0; for (let c = 0; c < N; c++) { const d = elevBeforeWater[c] - elev[c]; if (d > 0.5) { breachCells++; breachMax = Math.max(breachMax, d); } }
const rainOf = c => RAIN[base[c]] || .7;
const flow = new Float64Array(N), area = new Float64Array(N);
for (const c of order) { flow[c] = rainOf(c) * CK * CK; area[c] = CK * CK; }
for (let i = order.length - 1; i >= 0; i--) { const c = order[i], r = recv[c]; if (r >= 0 && land[r]) { flow[r] += flow[c]; area[r] += area[c]; } }

// Lakes: depressions the fill had to raise, deep and wide enough.
const lakeId = new Int32Array(N).fill(-1), lakes = [];
{
  const seen = new Uint8Array(N);
  for (let c = 0; c < N; c++) {
    if (seen[c] || !land[c] || filled[c] - elev[c] < 2) continue;
    const comp = [c]; seen[c] = 1;
    for (let q = 0; q < comp.length; q++) nbrs(comp[q], n => { if (!seen[n] && land[n] && filled[n] - elev[n] >= 2) { seen[n] = 1; comp.push(n); } });
    let depth = Math.max(...comp.map(k => filled[k] - elev[k]));
    if (comp.length < T.lakeMinCells || depth < T.lakeMinDepthM) continue;
    for (const k of comp) elev[k] = Math.max(elev[k], filled[k] - T.lakeMaxDepthM);
    depth = Math.max(...comp.map(k => filled[k] - elev[k]));
    const id = lakes.length; for (const k of comp) lakeId[k] = id;
    let sx = 0, sy = 0; const rc = new Map(), bc = new Map();
    for (const k of comp) { sx += cx(k); sy += cy(k); rc.set(region[k], (rc.get(region[k]) || 0) + 1); bc.set(base[k], (bc.get(base[k]) || 0) + 1); }
    const reg = lands[[...rc].sort((a, b) => b[1] - a[1] || a[0] - b[0])[0][0]].id, bio = [...bc].sort((a, b) => b[1] - a[1])[0][0];
    const arid = ['desert', 'steppe', 'demon'].includes(bio);
    lakes.push({ id: 'lake_' + String(id + 1).padStart(2, '0'), region: reg, at: [r1(sx / comp.length), r1(sy / comp.length)], areaKm2: r1(comp.length * CK * CK),
      surfaceM: Math.round(Math.max(...comp.map(k => filled[k]))), maxDepthM: Math.round(depth), kind: arid ? 'salt pan (seasonal)' : 'lake', _cells: comp.length });
  }
  for (const cl of CANON_LAKES) { const cand = lakes.filter(l => l.region === cl.region && !l.name).sort((a, b) => b._cells - a._cells)[0]; if (!cand) findings.push(`${cl.region}: "${cl.name}" (${cl.src}) has no basin in the atlas relief; place it by hand when the region is built.`); if (cand) { cand.name = cl.name; cand.nameSource = cl.src; cand.proposed = true; cand.note = 'existing name placed on the largest lake in the region (placement proposed)'; } }
}

// Rivers: main stems from the biggest mouths, traced upstream along the largest donor.
const donors = Array.from({ length: N }, () => []);
for (const c of order) if (recv[c] >= 0 && land[recv[c]]) donors[recv[c]].push(c);
const trace = (from, minFlow) => { const p = [from]; let c = from; for (;;) { const d = donors[c].filter(k => flow[k] >= minFlow).sort((a, b) => flow[b] - flow[a] || a - b)[0]; if (d === undefined) break; p.push(d); c = d; } return p.reverse(); };
const riverCells = new Uint8Array(N); for (let c = 0; c < N; c++) if (land[c] && flow[c] >= T.streamFlow) riverCells[c] = 1;
function simplify(pts, tol) {
  if (pts.length < 3) return pts; const keep = new Uint8Array(pts.length); keep[0] = keep[pts.length - 1] = 1; const st = [[0, pts.length - 1]];
  while (st.length) { const [a, b] = st.pop(); let md = 0, mi = -1; const [x1, y1] = pts[a], [x2, y2] = pts[b], L = Math.hypot(x2 - x1, y2 - y1) || 1e-9;
    for (let i = a + 1; i < b; i++) { const d = Math.abs((x2 - x1) * (y1 - pts[i][1]) - (x1 - pts[i][0]) * (y2 - y1)) / L; if (d > md) { md = d; mi = i; } }
    if (md > tol) { keep[mi] = 1; st.push([a, mi], [mi, b]); } }
  return pts.filter((_, i) => keep[i]);
}
const seaName = c => { const S = JSON.parse(fs.readFileSync(path.join(ROOT, 'Data', 'World', 'world_tuning.json'), 'utf8')).map.seas; return S.map(s => [Math.hypot(s.at[0] - cx(c), s.at[1] - cy(c)), s.name]).sort((a, b) => a[0] - b[0])[0][1]; };
function describeRiver(cells, kind, parent) {
  const pts = simplify(cells.map(c => [cx(c), cy(c)]), 0.3).map(([x, y]) => [r1(x), r1(y)]);
  let km = 0; for (let i = 1; i < cells.length; i++) km += Math.hypot(cx(cells[i]) - cx(cells[i - 1]), cy(cells[i]) - cy(cells[i - 1]));
  const rc = new Map(); const regs = []; const lk = [];
  for (const c of cells) { const id = lands[region[c]].id; rc.set(id, (rc.get(id) || 0) + 1); if (regs[regs.length - 1] !== id) regs.push(id); if (lakeId[c] >= 0 && !lk.includes(lakes[lakeId[c]].id)) lk.push(lakes[lakeId[c]].id); }
  const main = [...rc].filter(([, n]) => n >= .15 * cells.length).sort((a, b) => lands[idx(a[0])].ring - lands[idx(b[0])].ring || b[1] - a[1] || (a[0] < b[0] ? -1 : 1))[0][0];
  const src = cells[0], mouth = cells[cells.length - 1];
  const last = kind === 'river' || cells.length < 2 ? mouth : cells[cells.length - 2]; // a branch's own water, before it joins
  return { kind, main, source: { at: [r1(cx(src)), r1(cy(src))], m: Math.round(elev[src]), region: lands[region[src]].id },
    mouth: { at: [r1(cx(mouth)), r1(cy(mouth))], into: parent ? parent : seaName(mouth), region: lands[region[mouth]].id },
    lengthKm: r1(km), drainageKm2: Math.round(area[last]), flowIndex: Math.round(flow[last]), regions: [...new Set(regs)], throughLakes: lk, path: pts, _cells: cells };
}
const rivers = [];
{
  const mouths = order.filter(c => recv[c] >= 0 && !land[recv[c]] && flow[c] >= T.riverMinFlow).sort((a, b) => flow[b] - flow[a] || a - b);
  for (const m of mouths) {
    const stem = trace(m, T.riverSourceFlow); if (stem.length < 8) continue;
    const r = describeRiver(stem, 'river'); rivers.push(r);
    const onStem = new Set(stem);
    const tribs = [];
    for (const c of stem) for (const d of donors[c]) if (!onStem.has(d) && flow[d] >= T.tributaryFlow) tribs.push(d);
    tribs.sort((a, b) => flow[b] - flow[a] || a - b);
    for (const d of tribs.slice(0, 3)) { const t = trace(d, T.riverSourceFlow); if (t.length >= 8) rivers.push(describeRiver([...t, recv[d]], 'tributary', r)); }
  }
}
// Canon streams that no listed river carries: the stream nearest the place, from its source to where it joins.
for (const cr of CANON_RIVERS) {
  if (rivers.some(r => r._cells.some(c => Math.hypot(cx(c) - cr.near[0], cy(c) - cr.near[1]) <= cr.km))) continue;
  let start = -1, bd = 1e9; for (let c = 0; c < N; c++) if (riverCells[c]) { const d = Math.hypot(cx(c) - cr.near[0], cy(c) - cr.near[1]); if (d < bd) { bd = d; start = c; } }
  if (start < 0 || bd > 3) continue;
  const up = trace(start, T.riverSourceFlow), onRiver = new Map(); for (const r of rivers) for (const c of r._cells) if (!onRiver.has(c)) onRiver.set(c, r);
  const down = []; let c = start, joins = null; while (recv[c] >= 0 && land[recv[c]]) { c = recv[c]; down.push(c); if (onRiver.has(c)) { joins = onRiver.get(c); break; } }
  const st = describeRiver([...up, ...down], 'stream', joins); if (!joins) st.mouth.into = seaName(down[down.length - 1] || start);
  st.name = cr.name; st.nameSource = cr.src; st.proposed = false; rivers.push(st);
}
// Names: canon streams first, then "<region> River" (proposed), numbered when a region has several.
{
  const used = new Map();
  for (const r of rivers) {
    const canon = CANON_RIVERS.find(cr => r._cells.some(c => Math.hypot(cx(c) - cr.near[0], cy(c) - cr.near[1]) <= cr.km));
    if (canon && !rivers.some(o => o.name === canon.name)) { r.name = canon.name; r.nameSource = canon.src; r.proposed = false; continue; }
  }
  for (const r of rivers) {
    if (r.name) continue;
    const L = lands[idx(r.main)], n = (used.get(r.main) || 0) + 1; used.set(r.main, n);
    r.name = n === 1 ? `${L.name} River` : `${L.name} River ${['', '', 'II', 'III', 'IV', 'V', 'VI'][n] || n}`;
    r.nameSource = 'proposed: named after the innermost realm it waters (lowest ring among regions holding 15% of its course)'; r.proposed = true;
  }
  rivers.forEach((r, i) => { r.id = 'river_' + String(i + 1).padStart(2, '0'); });
  for (const r of rivers) if (r.mouth.into && typeof r.mouth.into === 'object') r.mouth.into = r.mouth.into.id;
}

// How much of each corridor road runs beside a river (within 1 km of a stream).
{
  const nearRiver = new Uint8Array(N); for (let c = 0; c < N; c++) if (riverCells[c]) { const i = c % W, j = (c - i) / W; for (let dy = -2; dy <= 2; dy++) for (let dx = -2; dx <= 2; dx++) { const x = i + dx, y = j + dy; if (x >= 0 && y >= 0 && x < W && y < H) nearRiver[y * W + x] = 1; } }
  for (const co of corridorOut) for (const l of co.legs) if (l._path) l.besideRiverPct = Math.round(100 * l._path.filter(c => nearRiver[c]).length / l._path.length);
}

// ---------------------------------------------------------------- biomes per cell (base terrain from the atlas, plus height and water)
const biome = new Array(N);
for (let c = 0; c < N; c++) {
  if (!land[c]) { biome[c] = 'sea'; continue; }
  if (lakeId[c] >= 0) { biome[c] = 'lake'; continue; }
  const y = cy(c), e = elev[c], b = base[c];
  if (e > snowlineM(y) && e > 900 && b !== 'volcanic' && b !== 'demon') biome[c] = 'snow';
  else if (e > treelineM(y) && e > 700 && ['mountain', 'forest', 'spirit', 'jungle', 'plains', 'steppe'].includes(b)) biome[c] = 'alpine';
  else if (coastKm[c] < 0.6 && e < 60 && b !== 'tundra' && b !== 'swamp') biome[c] = 'beach';
  else biome[c] = b;
}

// ---------------------------------------------------------------- ranges, peaks, massifs
const high = new Uint8Array(N); for (let c = 0; c < N; c++) high[c] = land[c] && elev[c] >= T.rangeM ? 1 : 0;
function comps(pred) {
  const seen = new Uint8Array(N), out = [];
  for (let c = 0; c < N; c++) { if (seen[c] || !pred(c, c)) continue; const comp = [c]; seen[c] = 1;
    for (let q = 0; q < comp.length; q++) nbrs(comp[q], n => { if (!seen[n] && pred(n, c)) { seen[n] = 1; comp.push(n); } });
    out.push(comp); }
  return out;
}
const isPeak = c => { if (elev[c] < T.peakM) return false; const i = c % W, j = (c - i) / W; for (let dy = -5; dy <= 5; dy++) for (let dx = -5; dx <= 5; dx++) { if (!dx && !dy) continue; const x = i + dx, y = j + dy; if (x < 0 || y < 0 || x >= W || y >= H) continue; const n = y * W + x; if (elev[n] > elev[c] || (elev[n] === elev[c] && n < c)) return false; } return true; };
const ranges = [];
for (let ri = 0; ri < lands.length; ri++) {
  const cs = comps((c) => high[c] && region[c] === ri).filter(cm => cm.length * CK * CK >= T.rangeMinKm2).sort((a, b) => b.length - a.length);
  if (!cs.length) continue;
  const cells = [].concat(...cs), L = lands[ri];
  // crest: principal axis of the high ground, binned every 3 km, highest-weighted centre per bin
  let sw = 0, mx = 0, my = 0; for (const c of cells) { const w = elev[c] - T.rangeM + 1; sw += w; mx += w * cx(c); my += w * cy(c); } mx /= sw; my /= sw;
  let sxx = 0, syy = 0, sxy = 0; for (const c of cells) { const w = elev[c] - T.rangeM + 1, dx = cx(c) - mx, dy = cy(c) - my; sxx += w * dx * dx; syy += w * dy * dy; sxy += w * dx * dy; }
  const th = 0.5 * Math.atan2(2 * sxy, sxx - syy), ux = Math.cos(th), uy = Math.sin(th);
  const main = cs[0], bins = new Map();
  for (const c of main) { const t = (cx(c) - mx) * ux + (cy(c) - my) * uy, b = Math.floor(t / 3); const w = Math.pow(elev[c] - T.rangeM + 1, 2); const o = bins.get(b) || { w: 0, x: 0, y: 0 }; o.w += w; o.x += w * cx(c); o.y += w * cy(c); bins.set(b, o); }
  const crest = [...bins.keys()].sort((a, b) => a - b).map(b => { const o = bins.get(b); return [r1(o.x / o.w), r1(o.y / o.w)]; });
  const peaks = cells.filter(isPeak).sort((a, b) => elev[b] - elev[a] || a - b);
  const picked = []; for (const p of peaks) { if (picked.every(q => Math.hypot(cx(p) - cx(q), cy(p) - cy(q)) >= 4)) picked.push(p); if (picked.length >= 5) break; }
  const pk = picked.map(c => ({ at: [r1(cx(c)), r1(cy(c))], m: Math.round(elev[c]), biome: base[c] }));
  const pn = PEAK_NAMES[L.id];
  if (pn && pk.length) {
    const tgt = pn.pick === 'southmost' ? pk.reduce((a, b) => b.at[1] > a.at[1] ? b : a) : pk[0];
    tgt.name = pn.name; tgt.nameSource = pn.src; tgt.proposed = !!pn.proposed;
  }
  const nm = RANGE_NAMES[L.id] || { name: `${L.name} Heights`, src: 'none; named after the region', proposed: true };
  const ys = cells.map(cy);
  ranges.push({ id: 'range_' + L.id.replace(/^reg_/, ''), name: nm.name, proposed: !!nm.proposed, nameSource: nm.src, region: L.id,
    areaKm2: Math.round(cells.length * CK * CK), meanM: Math.round(cells.reduce((s, c) => s + elev[c], 0) / cells.length), maxM: Math.round(Math.max(...cells.map(c => elev[c]))),
    trend: Math.abs(uy) > Math.abs(ux) ? 'north-south' : 'east-west', snowlineM: Math.round(snowlineM(Math.min(...ys) + (Math.max(...ys) - Math.min(...ys)) / 2)),
    crest, peaks: pk });
}
const massifs = comps(c => high[c]).filter(cm => cm.length * CK * CK >= 20).sort((a, b) => b.length - a.length).map((cm, i) => {
  const rc = new Map(); for (const c of cm) { const id = lands[region[c]].id; rc.set(id, (rc.get(id) || 0) + 1); }
  return { id: 'massif_' + (i + 1), areaKm2: Math.round(cm.length * CK * CK), regions: [...rc].sort((a, b) => b[1] - a[1]).map(x => x[0]), maxM: Math.round(Math.max(...cm.map(c => elev[c]))) };
});

// ---------------------------------------------------------------- passes: corridor high points, carved passes, canon passes
const passes = [];
const nearestPlace = at => { let b = null, bd = 1e9; for (const L of lands) for (const [n, p] of Object.entries(L.places)) { const d = Math.hypot(p[0] - at[0], p[1] - at[1]); if (d < bd) { bd = d; b = n; } } return b.replace(/ (camps|towns|cities|village)$/i, '').replace(/^the /i, ''); };
const addPass = p => { const near = passes.find(q => Math.hypot(q.at[0] - p.at[0], q.at[1] - p.at[1]) < 2.5); if (near) { near.corridors = [...new Set([...near.corridors, ...p.corridors])]; return near; } passes.push(p); return p; };
for (const co of corridorOut) for (const l of co.legs) {
  if (l.by !== 'land' || !l.passable || l.highestM < T.passReportM) continue;
  const reg = l.highestRegion, cp = CANON_PASSES[reg];
  const p = addPass({ at: l.highestAt, m: l.highestM, region: reg, corridors: [co.id], carved: !!l.carvedPass,
    name: cp ? cp.name : `${nearestPlace(l.highestAt)} Pass`, proposed: cp ? !!cp.proposed : true, nameSource: cp ? cp.src : 'proposed: the corridor\'s highest crossing, named after the nearest settlement' });
  l.pass = p;
}
// Canon passes that no corridor crosses: the lowest saddle through that region's heights between its two sides.
for (const [rid, cp] of Object.entries(CANON_PASSES)) {
  if (passes.some(p => p.region === rid)) continue;
  const ri = idx(rid), L = lands[ri];
  // route from the region's anchor to the far side of its range: the lowest way over the high ground nearest the anchor
  let best = null;
  for (let o = 0; o < lands.length; o++) {
    if (o === ri || lands[o].isle) continue; const B = lands[o]; if (cp.toward ? B.id !== cp.toward : Math.hypot(B.ax - L.ax, B.ay - L.ay) > 22) continue;
    const tgt = []; for (let c = 0; c < N; c++) if (land[c] && region[c] === o) tgt.push(c);
    const bn = bottleneck([cellOf(L.ax, L.ay)], tgt); if (!bn) continue;
    let top = bn.path[0]; for (const c of bn.path) if (elev[c] > elev[top]) top = c;
    if (region[top] !== ri && !cp.toward) continue;
    if (!best || elev[top] > best.m) best = { at: [r1(cx(top)), r1(cy(top))], m: Math.round(elev[top]), toward: B.id };
  }
  if (best && best.m < T.passReportM) { findings.push(`${rid}: lore has "${cp.name}" (${cp.src.split(';')[0]}), but the atlas relief has no real heights to cross${best.toward ? ' toward ' + best.toward : ''} (highest point on the lowest way: ${best.m} m). The heights should be added when the region is built.`); if (cp.keepLow) addPass({ at: best.at, m: best.m, region: rid, corridors: [], carved: false, toward: best.toward, name: cp.name, proposed: !!cp.proposed, nameSource: cp.src + '; placed on the highest saddle between the region and its neighbours (the relief here is gentle)' }); continue; }
  if (best) addPass({ at: best.at, m: best.m, region: rid, corridors: [], carved: false, toward: best.toward, name: cp.name, proposed: !!cp.proposed, nameSource: cp.src + '; placed on the highest saddle between the region and its neighbours' });
}
passes.forEach((p, i) => { p.id = 'pass_' + String(i + 1).padStart(2, '0'); p.class = p.m < 900 ? 'easy' : p.m < 1500 ? 'mountain pass' : 'high pass (snow in winter)'; });
for (const co of corridorOut) for (const l of co.legs) { if (l.pass) l.passId = l.pass.id; delete l.pass; }

// ---------------------------------------------------------------- per-region statistics
const regionStats = lands.map((L, ri) => {
  const cells = []; for (let c = 0; c < N; c++) if (land[c] && region[c] === ri) cells.push(c);
  const es = cells.map(c => elev[c]).sort((a, b) => a - b), q = p => Math.round(es[Math.min(es.length - 1, Math.floor(p * es.length))]);
  const bc = {}; for (const c of cells) bc[biome[c]] = (bc[biome[c]] || 0) + 1;
  const share = Object.fromEntries(Object.entries(bc).sort((a, b) => b[1] - a[1] || (a[0] < b[0] ? -1 : 1)).map(([k, v]) => [k, Math.round(100 * v / cells.length)]));
  let coast = 0; for (const c of cells) nbrs(c, (n, km) => { if (!land[n] && km === CK) coast += CK; });
  const meanY = cells.reduce((s, c) => s + cy(c), 0) / cells.length, meanE = es.reduce((s, v) => s + v, 0) / es.length;
  return { id: L.id, name: L.name, terrain: L.terrain, features: L.features, areaKm2: Math.round(cells.length * CK * CK), meanM: Math.round(meanE), p10M: q(.1), p50M: q(.5), p90M: q(.9), maxM: q(1),
    coastKm: Math.round(coast), belt: beltOf(L.ay), meanTempC: r1(tempC(meanY, meanE)), biomeShare: share, _cells: cells };
});

// ---------------------------------------------------------------- consistency checks
const checks = [];
const check = (id, ok, detail, items) => { checks.push({ id, ok, detail, ...(items && items.length ? { items } : {}) }); };
{ // atlas and regions.json agree
  const bad = [];
  for (const L of lands) { const a = atlasRows.find(x => x.id === L.id); if (!a || a.ax !== L.ax || a.ay !== L.ay || a.r !== L.r || a.isle !== L.isle || A.TERRAIN_ONLY(a.biomes).join() !== L.terrain.join()) bad.push(L.id); }
  check('atlas_matches_regions', !bad.length, 'every surface land in regions.json has the atlas\'s anchor, radius, isle flag and terrain', bad);
}
{ // anchors and places on land, in their own region
  const bad = [];
  const owner = (x, y) => { const [f, b] = F.sample(x, y); return f > A.SEA_T ? b : -1; };
  for (let ri = 0; ri < lands.length; ri++) { const L = lands[ri]; if (owner(L.ax, L.ay) !== ri) bad.push(`${L.id} anchor`);
    for (const [n, at] of Object.entries(L.places)) if (owner(at[0], at[1]) !== ri) bad.push(`${L.id} place "${n}"`); }
  check('anchors_and_places_on_land', !bad.length, 'every region anchor and every map place stands on land owned by its region (the atlas land field sampled at the exact point)', bad);
}
{ // isles are islands
  const lc = comps(c => land[c]); const compOf = new Int32Array(N).fill(-1); lc.forEach((cm, i) => cm.forEach(c => { compOf[c] = i; }));
  const mainland = lc.reduce((a, b, i) => b.length > lc[a].length ? i : a, 0);
  const bad = [], info = [];
  for (const L of lands) { const comp = compOf[cellOf(L.ax, L.ay)]; if (L.isle && comp === mainland) bad.push(`${L.id} is joined to the mainland`); if (!L.isle && comp !== mainland) info.push(`${L.id} anchor is off the mainland`); }
  check('isles_are_islands', !bad.length && !info.length, 'the isles (map.isle) are separate land; every other anchor is on the mainland', [...bad, ...info]);
}
{ // mountain regions sit high
  const bad = [], vals = [];
  for (const s of regionStats) { const mt = s.terrain.some(t => ['mountain', 'volcanic'].includes(t)); if (!mt) continue; vals.push(`${s.id} mean ${s.meanM} m, p90 ${s.p90M} m`); if (s.p90M < 1300 || s.meanM < 700) bad.push(`${s.id}: terrain ${s.terrain.join('/')} but mean ${s.meanM} m, p90 ${s.p90M} m`); }
  check('mountain_regions_high', !bad.length, 'regions whose terrain has mountain or volcanic: mean >= 700 m and the top tenth >= 1300 m', bad.length ? bad : vals);
}
{ // lowland regions stay low
  const bad = [];
  for (const s of regionStats) { if (s.terrain.some(t => ['mountain', 'volcanic', 'tundra', 'demon'].includes(t))) continue; const hi = s._cells.filter(c => elev[c] >= T.rangeM).length / s._cells.length; if (hi > .05) bad.push(`${s.id}: ${Math.round(hi * 100)}% above ${T.rangeM} m without mountain terrain`); }
  check('lowland_regions_low', !bad.length, `regions without mountain, volcanic, tundra or demon terrain have under 5% of their land above ${T.rangeM} m`, bad);
}
{ // coastal regions touch the coast
  const bad = [], extra = [];
  for (const s of regionStats) { const tagged = s.features.includes('coast'); if (tagged && s.coastKm < 3) bad.push(`${s.id}: tagged coast but ${s.coastKm} km of shoreline`); if (!tagged && s.coastKm >= 8) extra.push(`${s.id}: ${s.coastKm} km of shoreline, not tagged coast`); }
  check('coastal_regions_touch_coast', !bad.length, 'every region with the coast feature has shoreline', bad);
  check('untagged_coasts', true, 'information: regions with real shoreline that are not tagged coast (they may want the feature)', extra);
}
{ // rivers flow downhill to the sea
  const bad = []; let maxRise = 0;
  for (const r of rivers) { const cs = r._cells; for (let i = 1; i < cs.length; i++) { if (filled[cs[i]] > filled[cs[i - 1]] + 1e-6) bad.push(`${r.id} climbs at ${r1(cx(cs[i]))},${r1(cy(cs[i]))}`); if (lakeId[cs[i]] < 0) maxRise = Math.max(maxRise, elev[cs[i]] - elev[cs[i - 1]]); }
    const end = cs[cs.length - 1]; if (r.kind === 'river' && land[recv[end]]) bad.push(`${r.id} does not reach the sea`); }
  check('rivers_flow_downhill', !bad.length, `every river's water level falls from source to mouth and every main river ends in the sea; largest bank rise outside lakes ${maxRise.toFixed(1)} m (fill noise)`, bad);
}
{ // biomes match terrain
  const bad = [], info = [];
  for (const s of regionStats) { const natural = Object.entries(s.biomeShare).filter(([b]) => A.TERRAIN_KINDS.includes(b)); const top = natural[0] && natural[0][0];
    const alien = natural.filter(([b]) => !s.terrain.includes(b)).map(([b]) => b); if (alien.length || !top) bad.push(`${s.id}: ${alien.join(',')}`);
    info.push(`${s.id}: ${Object.entries(s.biomeShare).slice(0, 4).map(([b, v]) => `${b} ${v}%`).join(', ')}`); }
  check('biomes_match_terrain', !bad.length, 'every cell\'s base biome comes from its region\'s terrain list (alpine, snow, beach and lake are height and water overlays); dominant shares listed', bad.length ? bad : info);
}
{ // corridors passable
  const bad = [], items = [];
  for (const co of corridorOut) for (const l of co.legs) { const s = l.by === 'sea' ? `${co.id}: ${l.from} -> ${l.to} by sea ${l.lengthKm} km` : `${co.id}: ${l.from} -> ${l.to} ${l.lengthKm} km, highest ${l.highestM} m${l.carvedPass ? ` (pass carved from ${l.carvedPass.wasM} m)` : ''}`; items.push(s); if (!l.passable) bad.push(s + ' NOT PASSABLE'); }
  check('corridors_passable', !bad.length, `all legs of the five corridors have a road under ${T.passLimitM} m (passes carved where the atlas relief had none)`, bad.length ? bad : items);
  if (carved.length) for (const c of carved) findings.push(`Carved pass in ${c.region} at ${c.at.join(',')}: the atlas relief tops out at ${c.wasM} m on the lowest crossing; the heightmap is notched to ${c.nowM} m over ${c.cells} cells so the corridor can be walked.`);
}
{ // every settlement reachable on foot from Brindlewick
  const s = waypoint('reg_whisperwood:Brindlewick').cell, seen = new Uint8Array(N), q = [s]; seen[s] = 1;
  for (let i = 0; i < q.length; i++) nbrs(q[i], n => { if (!seen[n] && land[n] && elev[n] <= T.passLimitM) { seen[n] = 1; q.push(n); } });
  const bad = [], high = [];
  for (const L of lands) { if (L.isle) continue; for (const [n, at] of Object.entries(L.places)) { const w = waypoint(`${L.id}:${n}`);
    if (!w.set.some(c => seen[c])) bad.push(`${L.id} "${n}" at ${w.m} m`); else if (w.m > T.passLimitM) high.push(`${L.id} "${n}" stands at ${w.m} m`); } }
  check('settlements_reachable', !bad.length, `every mainland settlement can be walked to (to within ${T.approachKm} km) from Brindlewick without crossing ground above ${T.passLimitM} m`, bad.length ? bad : high);
  if (bad.length) findings.push(`Settlements cut off by high ground: ${bad.join('; ')}.`);
  if (high.length) findings.push(`Settlements the atlas relief puts above ${T.passLimitM} m (reached by road to within ${T.approachKm} km, then by their own stair or lift): ${high.join('; ')}. Their lore fits a high site only where it says so (Heavenreach eyries, Apu terrace cities); others should sit in a valley when the region is built.`);
}
{ // lore rivers
  const bad = [], ok = [];
  for (const [rid, place, text] of LORE_RIVERS) { const L = lands[idx(rid)], at = place && L.places[place] ? L.places[place] : [L.ax, L.ay];
    let best = 1e9; for (let c = 0; c < N; c++) if (riverCells[c] && region[c] === idx(rid)) best = Math.min(best, Math.hypot(cx(c) - at[0], cy(c) - at[1]));
    const line = `${rid}${place ? ' (' + place + ')' : ''}: "${text}" - nearest stream ${best > 1e8 ? 'none in region' : r1(best) + ' km'}`;
    (best <= 3 ? ok : bad).push(line); }
  check('lore_rivers', !bad.length, 'where the gazetteer says a river runs by a town, a computed stream passes within 3 km', bad.length ? bad : ok);
  for (const b of bad) findings.push(`River lore not met by the atlas relief: ${b}. The town's river should be hand-placed (or the place moved) when the region is built.`);
}
// Region data that the relief contradicts (findings only; regions.json is not changed).
function nearestSeaKm(s) { const L = lands[idx(s.id)]; let b = 1e9; for (let c = 0; c < N; c++) if (!land[c]) b = Math.min(b, Math.hypot(cx(c) - L.ax, cy(c) - L.ay)); return b; }
for (const s of regionStats) {
  const g = (JSON.parse(fs.readFileSync(path.join(ROOT, 'Data', 'World', 'gazetteer.json'), 'utf8')).regions[s.id] || {}).geography || '';
  const mt = s.terrain.some(t => ['mountain', 'volcanic'].includes(t));
  if (!mt && /\b(mountains?|peaks?|volcanic|volcano)\b/i.test(g) && s.p90M < 900) findings.push(`${s.id}: the gazetteer says "${(g.match(/[^.]*\b(mountains?|peaks?|volcanic|volcano)\b[^.]*\./i) || [''])[0].trim()}" but its terrain (${s.terrain.join('/')}) has no mountain/volcanic, so the atlas keeps it low (p90 ${s.p90M} m). Adding "mountain" or "volcanic" to its map.terrain would raise it.`);
  if (/\b(coast|fjords?|shore|skerries|beach)\b/i.test(g) && !s.features.includes('coast') && s.coastKm >= 8) findings.push(`${s.id}: ${s.coastKm} km of shoreline and the gazetteer describes a coast ("${(g.match(/[^.]*\b(coast|fjords?|shore|skerries|beach)\b[^.]*\./i) || [''])[0].trim()}"), but map.features has no "coast".`);
  if (s.features.includes('coast') && s.coastKm < 3) findings.push(`${s.id}: map.features has "coast" and the gazetteer says "${(g.match(/[^.]*\b(sea|coast|lagoon|cliffs)\b[^.]*\./i) || [''])[0].trim()}", but in the atlas the region is landlocked (${s.coastKm} km of shoreline; the nearest sea is ${r1(nearestSeaKm(s))} km from its anchor).`);
}
for (const s of regionStats) { const hi = s._cells.filter(c => elev[c] >= T.rangeM).length / s._cells.length; if (s.terrain.includes('mountain') && s.terrain.length > 1 && hi < .15) findings.push(`${s.id}: terrain lists mountain but only ${Math.round(hi * 100)}% of the land is above ${T.rangeM} m (the atlas paints its other terrain over most of it); ${s.p90M} m at the 90th percentile.`); }
for (const c of checks) if (!c.ok) findings.push(`Check ${c.id} failed: ${(c.items || []).join('; ')}`);

// ---------------------------------------------------------------- seas and coasts
const seas = JSON.parse(fs.readFileSync(path.join(ROOT, 'Data', 'World', 'world_tuning.json'), 'utf8')).map.seas.map(s => ({ name: s.name, label: s.at, coasts: [], proposed: false, nameSource: 'world_tuning.json map.seas (atlas labels)' }));
for (const s of regionStats) { if (s.coastKm < 1) continue; const cells = s._cells.filter(c => { let e = false; nbrs(c, n => { if (!land[n]) e = true; }); return e; });
  const cnt = new Map(); for (const c of cells) { const nm = seaName(c); cnt.set(nm, (cnt.get(nm) || 0) + 1); }
  for (const [nm, n] of cnt) seas.find(x => x.name === nm).coasts.push({ region: s.id, km: Math.round(n * CK) }); }
for (const s of seas) s.coasts.sort((a, b) => b.km - a.km || (a.region < b.region ? -1 : 1));

// ---------------------------------------------------------------- output JSON
const rowsInt = a => Array.from({ length: H }, (_, j) => Array.from(a.slice(j * W, (j + 1) * W), v => Math.round(v)));
const out = {
  version: 1,
  note: 'Generated by Tools/atlas/build_physical_map.js from the atlas (seed 1207) and Data/World/regions.json; do not edit by hand. Docs: 10_World/physical_geography.md.',
  source: { atlas: 'Tools/atlas/aetheria_atlas.html', seed: A.SEED, atlasCanvas: [F.W, F.H], regions: 'Data/World/regions.json', seaLevelField: A.SEA_T },
  grid: { width: W, height: H, cellKm: CK, mapUnits: [A.MAP_W, A.MAP_H], unitKm: 1, origin: 'north-west corner; x east, y south; cell (i, j) covers map units [i*0.5, i*0.5+0.5) x [j*0.5, j*0.5+0.5); row j is rows[j]' },
  tuning: T,
  elevation: { unit: 'm', seaLevel: 0, min: Math.round(Math.min(...elev)), max: Math.round(Math.max(...elev)),
    fromAtlas: 'land: m = 750*h + 2600*max(0, h-0.5)^1.4 where h is the atlas relief (hgt in render()), averaged over 4x4 atlas pixels; sea: depth from the distance to the coast, -(5 + 120*smooth(0,4,d) + 1600*smooth(4,25,d)) m; carved passes lowered as listed in passes[]',
    water: `shallow hollows drained by cutting their outlets (${breachCells} cells lowered, at most ${Math.round(breachMax)} m); the rest are lakes (lakes[]): rows give the lake floor, lakes[].surfaceM the water`,
    rows: rowsInt(elev) },
  biomes: { legend: Object.fromEntries(Object.entries(BIOME_CH).map(([k, v]) => [v, k])), note: 'base terrain = the atlas biome (region terrain, chosen by the atlas noise); alpine = above the treeline, snow = above the snowline, beach = the atlas sandy rim, lake = filled depressions', rows: Array.from({ length: H }, (_, j) => biome.slice(j * W, (j + 1) * W).map(b => BIOME_CH[b]).join('')) },
  regions: { legend: lands.map(l => l.id), note: 'character k in a row = legend[index of k in "' + REG_CH.slice(0, lands.length) + '"]; "." = sea', rows: Array.from({ length: H }, (_, j) => Array.from(region.slice(j * W, (j + 1) * W), r => r < 0 ? '.' : REG_CH[r]).join('')) },
  climate: { seaLevelTempC: 'T(y) = 0.28*y (y in map units, 0 = north); lapse 6.5 C per km of height', snowline: 'permanent snow where T < -5 C (and above 900 m; never on volcanic or demon ground); winter snow comes about 1000 m lower', treeline: 'trees thin out where T < -1 C (above 700 m)', belts: BELTS },
  ranges, massifs, rivers: rivers.map(({ _cells, main, ...r }) => r), lakes: lakes.map(({ _cells, ...l }) => l), seas, passes,
  corridors: corridorOut.map(co => ({ ...co, legs: co.legs.map(({ _top, _path, ...l }) => l) })),
  regionStats: regionStats.map(({ _cells, ...s }) => s),
  checks, findings,
};
// one row per line keeps the file diffable
let json = JSON.stringify(out, null, 1);
json = json.replace(/\[\n\s+(-?\d+(?:,\n\s+-?\d+)*)\n\s+\]/g, (m, body) => '[' + body.replace(/,\n\s+/g, ',') + ']');
json = json.replace(/\[\n\s+(-?[\d.]+),\n\s+(-?[\d.]+)\n\s+\]/g, '[$1,$2]');
fs.mkdirSync(path.dirname(OUT_JSON), { recursive: true });
fs.writeFileSync(OUT_JSON, json + '\n');
log(`wrote ${path.relative(ROOT, OUT_JSON)} (${(json.length / 1024).toFixed(0)} KB): ${ranges.length} ranges, ${rivers.length} rivers, ${lakes.length} lakes, ${passes.length} passes`);
for (const c of checks) log(`${c.ok ? 'ok  ' : 'FAIL'} ${c.id}${c.ok ? '' : ': ' + (c.items || []).join('; ')}`);
log(`${findings.length} findings`);

// ---------------------------------------------------------------- relief image
if (!NO_PNG) {
  const relief = renderRelief();
  const tmp = path.join(os.tmpdir(), 'ascend_physical_relief_' + process.pid + '.png');
  fs.writeFileSync(tmp, relief);
  fs.mkdirSync(path.dirname(OUT_PNG), { recursive: true });
  let labelled = false;
  try { labelled = require('./render_physical_map.js').render(tmp, out, OUT_PNG); } catch (e) { log('labels skipped (' + e.message.split('\n')[0] + '); writing the unlabelled relief'); }
  if (labelled && typeof labelled.then === 'function') labelled.then(() => { fs.unlinkSync(tmp); log('wrote ' + path.relative(ROOT, OUT_PNG)); }, e => { log('labels failed: ' + e.message); fs.copyFileSync(tmp, OUT_PNG); fs.unlinkSync(tmp); });
  else { fs.copyFileSync(tmp, OUT_PNG); fs.unlinkSync(tmp); log('wrote ' + path.relative(ROOT, OUT_PNG) + ' (unlabelled)'); }
}

// Hillshaded relief at the atlas's own resolution (1200 x 800), parchment palette. Carved passes are blended in
// from the 0.5 km grid; rivers and lakes are drawn by the labeller.
function renderRelief() {
  const RW = F.W, RH = F.H, px = Buffer.alloc(RW * RH * 3), hm = new Float64Array(RW * RH);
  const delta = (ux, uy) => { const i = Math.min(W - 1, Math.floor(ux / CK)), j = Math.min(H - 1, Math.floor(uy / CK)); return elev[j * W + i] - elevAtlas[j * W + i]; };
  for (let k = 0; k < RW * RH; k++) { const x = k % RW, y = (k - x) / RW; hm[k] = F.regionAt[k] >= 0 ? toMetres(F.hgt[k]) + delta(x * F.SX, y * F.SY) : seaDepth(-F.coast[k] / F.s); }
  const TINT = { plains: [196, 196, 140], forest: [128, 158, 104], swamp: [140, 150, 112], steppe: [214, 196, 140], mountain: [176, 160, 132], volcanic: [150, 112, 96], tundra: [222, 226, 220], desert: [232, 206, 150], jungle: [110, 150, 98], spirit: [150, 156, 180], demon: [150, 92, 96] };
  const mix = (a, b, t) => [a[0] + (b[0] - a[0]) * t, a[1] + (b[1] - a[1]) * t, a[2] + (b[2] - a[2]) * t];
  const lz0 = Math.hypot(-1, -1, 1.6), lx = -1 / lz0, ly = -1 / lz0, lz = 1.6 / lz0, zs = 1 / (125 * 1.2); // metres per pixel (125 m), exaggerated
  for (let y = 0; y < RH; y++) for (let x = 0; x < RW; x++) {
    const k = y * RW + x, ux = x * F.SX, uy = y * F.SY, e = hm[k]; let c;
    const paper = (A.fbm(ux * .9 + 7, uy * .9 + 3, 3) - .5) * 14 + (A.vnoise(x * .7, y * .7) - .5) * 8;
    if (F.regionAt[k] < 0) {
      const t = A.smooth(0, 1, -e / 1700);
      c = mix([170, 196, 186], [92, 128, 140], Math.pow(t, .6));
      const d = -F.coast[k] / F.s; for (const [r, a] of [[.6, .35], [1.4, .22], [2.4, .12]]) { const q = Math.max(0, 1 - Math.abs(d - r) / .18); c = mix(c, [214, 226, 210], q * a); }
    } else {
      const b = A.TERRAIN_KINDS[F.biomeAt[k]];
      c = TINT[b].slice();
      c = mix(c, [200, 178, 132], A.smooth(600, 1800, e) * .6);
      c = mix(c, [168, 156, 142], A.smooth(1800, 3000, e) * .7);
      c = mix(c, [246, 246, 240], A.smooth(snowlineM(uy) - 150, snowlineM(uy) + 250, e) * A.smooth(800, 1100, e));
      if (F.coast[k] / F.s < .6 && b !== 'tundra' && b !== 'swamp') c = mix(c, [226, 210, 166], (1 - A.smooth(.2, .6, F.coast[k] / F.s)) * .6);
      let sh = 1;
      if (x > 0 && y > 0 && x < RW - 1 && y < RH - 1) { const dx = (hm[k + 1] - hm[k - 1]) * .5 * zs, dy = (hm[k + RW] - hm[k - RW]) * .5 * zs; sh = (-dx * lx - dy * ly + lz) / Math.sqrt(dx * dx + dy * dy + 1) / lz; }
      sh = Math.max(0, Math.min(1.5, sh));
      c = c.map(v => v * (.55 + .47 * sh));
      const nb = [F.regionAt[k - 1], F.regionAt[k + 1], F.regionAt[k - RW], F.regionAt[k + RW]];
      if (nb.some(v => v !== F.regionAt[k] && v !== undefined && v !== -1) && ((x + y) >> 1) % 3 !== 0) c = c.map(v => v * .8);
    }
    const line = Math.max(0, Math.min(1, 1.4 - Math.abs(F.coast[k])));
    c = mix(c, [58, 44, 32], line * .85);
    c = c.map(v => v * .94 + 14 + paper); // warm the whole sheet toward parchment
    const o = k * 3; px[o] = Math.max(0, Math.min(255, Math.round(c[0] + 6))); px[o + 1] = Math.max(0, Math.min(255, Math.round(c[1] + 2))); px[o + 2] = Math.max(0, Math.min(255, Math.round(c[2] - 10)));
  }
  return encodePng(RW, RH, px);
}
function encodePng(w, h, rgb) {
  const raw = Buffer.alloc((w * 3 + 1) * h); for (let y = 0; y < h; y++) { raw[y * (w * 3 + 1)] = 0; rgb.copy(raw, y * (w * 3 + 1) + 1, y * w * 3, (y + 1) * w * 3); }
  const crcT = new Int32Array(256); for (let n = 0; n < 256; n++) { let c = n; for (let k = 0; k < 8; k++) c = c & 1 ? 0xEDB88320 ^ (c >>> 1) : c >>> 1; crcT[n] = c; }
  const crc = b => { let c = -1; for (let i = 0; i < b.length; i++) c = crcT[(c ^ b[i]) & 255] ^ (c >>> 8); return (c ^ -1) >>> 0; };
  const chunk = (type, data) => { const len = Buffer.alloc(4); len.writeUInt32BE(data.length); const td = Buffer.concat([Buffer.from(type), data]); const cr = Buffer.alloc(4); cr.writeUInt32BE(crc(td)); return Buffer.concat([len, td, cr]); };
  const ihdr = Buffer.alloc(13); ihdr.writeUInt32BE(w, 0); ihdr.writeUInt32BE(h, 4); ihdr[8] = 8; ihdr[9] = 2; ihdr[10] = 0; ihdr[11] = 0; ihdr[12] = 0;
  return Buffer.concat([Buffer.from([137, 80, 78, 71, 13, 10, 26, 10]), chunk('IHDR', ihdr), chunk('IDAT', zlib.deflateSync(raw, { level: 9 })), chunk('IEND', Buffer.alloc(0))]);
}
