// The atlas's land field and relief, ported line for line from Tools/atlas/aetheria_atlas.html (render(), sample(),
// biomeAtU(), chamfer(), boxBlur(), ROUGH). The atlas is the source of truth for positions and coastline; this file
// only reproduces its numbers in Node so other tools (build_physical_map.js) can build on them.
// Region anchors come from Data/World/regions.json → map (the same order the game's WorldMapTerrain.cs uses);
// readAtlasRegions() parses the atlas's own REGIONS table so callers can check the two agree.
'use strict';
const fs = require('fs');
const path = require('path');

const ROOT = path.resolve(__dirname, '..', '..');
const ATLAS = path.join(ROOT, 'Tools', 'atlas', 'aetheria_atlas.html');
const SEED = 1207;
const SEA_T = 0.46;
const MAP_W = 150, MAP_H = 100;
const TERRAIN_KINDS = ['plains', 'forest', 'swamp', 'steppe', 'mountain', 'volcanic', 'tundra', 'desert', 'jungle', 'spirit', 'demon'];
const ROUGH = { plains: .06, forest: .16, swamp: 0, steppe: .08, mountain: 1, volcanic: .95, tundra: .5, desert: .12, jungle: .2, spirit: .3, demon: .75 };

// ---------------------------------------------------------------- noise (verbatim)
function mulberry(a) { return function () { a |= 0; a = a + 0x6D2B79F5 | 0; let t = Math.imul(a ^ a >>> 15, 1 | a); t = t + Math.imul(t ^ t >>> 7, 61 | t) ^ t; return ((t ^ t >>> 14) >>> 0) / 4294967296; }; }
let PERM;
function seedNoise(s) { const rnd = mulberry(s); PERM = new Float32Array(4096); for (let i = 0; i < 4096; i++) PERM[i] = rnd(); }
function h(ix, iy) { return PERM[((ix * 73856093) ^ (iy * 19349663)) & 4095]; }
function vnoise(x, y) {
  const ix = Math.floor(x), iy = Math.floor(y), fx = x - ix, fy = y - iy, u = fx * fx * (3 - 2 * fx), v = fy * fy * (3 - 2 * fy);
  const a = h(ix, iy), b = h(ix + 1, iy), c = h(ix, iy + 1), d = h(ix + 1, iy + 1); return a + (b - a) * u + (c - a) * v + (a - b - c + d) * u * v;
}
function fbm(x, y, o = 4) { let s = 0, a = .5, f = 1, n = 0; for (let i = 0; i < o; i++) { s += a * vnoise(x * f, y * f); n += a; a *= .5; f *= 2.03; } return s / n; }
function smooth(a, b, v) { const x = Math.max(0, Math.min(1, (v - a) / (b - a))); return x * x * (3 - 2 * x); }

// ---------------------------------------------------------------- regions
function loadLands() {
  const regions = JSON.parse(fs.readFileSync(path.join(ROOT, 'Data', 'World', 'regions.json'), 'utf8'));
  return regions.filter(r => r.layer === 'surface' && r.map && r.map.radius > 0).map(r => {
    const t = (r.map.terrain || []).filter(k => TERRAIN_KINDS.includes(k));
    return { id: r.id, name: r.name, ring: r.ring, ax: r.map.at[0], ay: r.map.at[1], r: r.map.radius, isle: !!r.map.isle,
      terrain: t.length ? t : ['plains'], features: r.map.features || [], places: r.map.places || {} };
  });
}
// The atlas's own REGIONS table (a literal array in the HTML), for cross-checking anchors, radii and terrain.
function readAtlasRegions() {
  const html = fs.readFileSync(ATLAS, 'utf8');
  const a = html.indexOf('const REGIONS = ['), b = html.indexOf('].map(a=>({id:a[0]', a);
  if (a < 0 || b < 0) throw new Error('atlas REGIONS table not found');
  const rows = Function('"use strict";return [' + html.slice(a + 'const REGIONS = ['.length, b) + ']')();
  return rows.map(x => ({ id: x[0], name: x[1], ring: x[2], layer: x[3], biomes: x[4], ax: x[11][0], ay: x[11][1], r: x[12], isle: !!x[13] }));
}
const TERRAIN_ONLY = b => { const t = b.filter(x => !['city', 'ruins', 'coast', 'cave', 'sky'].includes(x)); return t.length ? t : ['plains']; };

// ---------------------------------------------------------------- the atlas render pass, without colour
// Returns per-pixel fields on the atlas canvas (1200 x 800 by default; pixel x,y sits at map units x*150/W, y*100/H).
function computeAtlasFields(lands, opt = {}) {
  const W = opt.W || 1200, H = opt.H || 800, SX = MAP_W / W, SY = MAP_H / H, N = W * H;
  seedNoise(opt.seed || SEED);
  const sample = (ux, uy) => {
    const wx = ux + 16 * (fbm(ux * .04, uy * .04) - .5), wy = uy + 16 * (fbm(ux * .04 + 31, uy * .04 + 17) - .5);
    let best = -1, bd = 1e9, field = 0;
    for (let i = 0; i < lands.length; i++) {
      const r = lands[i]; if (!r.r) continue; const dx = wx - r.ax, dy = wy - r.ay, d = Math.sqrt(dx * dx + dy * dy) / r.r;
      field += Math.exp(-d * d * (r.isle ? 1.8 : .7)); if (d < bd) { bd = d; best = i; }
    }
    const edge = Math.min(ux, 150 - ux, uy * 1.4, (100 - uy) * 1.4) / 9;
    field = field * Math.min(1, Math.max(0, edge)) + .28 * (fbm(ux * .11 + 5, uy * .11 + 9) - .5);
    return [field, best];
  };
  const biomeAtU = (r, ux, uy) => { const t = r.terrain; return t[Math.min(t.length - 1, Math.floor(fbm(ux * .07 + 90, uy * .07 + 40, 3) * t.length * 1.15))]; };
  const regionAt = new Int16Array(N), fieldAt = new Float32Array(N), biomeAt = new Uint8Array(N);
  for (let y = 0; y < H; y++) for (let x = 0; x < W; x++) {
    const ux = x * SX, uy = y * SY, [f, best] = sample(ux, uy), k = y * W + x, land = f > SEA_T;
    regionAt[k] = land ? best : -1; fieldAt[k] = f;
    biomeAt[k] = land ? TERRAIN_KINDS.indexOf(biomeAtU(lands[best], ux, uy)) : 255;
  }
  const chamfer = pred => {
    const d = new Float32Array(N), big = 1e6, dg = 1.4142; for (let k = 0; k < N; k++) d[k] = pred(k) ? 0 : big;
    for (let y = 0; y < H; y++) for (let x = 0; x < W; x++) { const k = y * W + x; let v = d[k]; if (x > 0) v = Math.min(v, d[k - 1] + 1); if (y > 0) { v = Math.min(v, d[k - W] + 1); if (x > 0) v = Math.min(v, d[k - W - 1] + dg); if (x < W - 1) v = Math.min(v, d[k - W + 1] + dg); } d[k] = v; }
    for (let y = H - 1; y >= 0; y--) for (let x = W - 1; x >= 0; x--) { const k = y * W + x; let v = d[k]; if (x < W - 1) v = Math.min(v, d[k + 1] + 1); if (y < H - 1) { v = Math.min(v, d[k + W] + 1); if (x < W - 1) v = Math.min(v, d[k + W + 1] + dg); if (x > 0) v = Math.min(v, d[k + W - 1] + dg); } d[k] = v; }
    return d;
  };
  const boxBlur = (v, r, passes) => {
    const t = new Float32Array(v.length); for (let p = 0; p < passes; p++) {
      for (let y = 0; y < H; y++) { let s = 0, n = 0; const row = y * W; for (let x = -r; x <= r; x++) if (x >= 0 && x < W) { s += v[row + x]; n++; }
        for (let x = 0; x < W; x++) { t[row + x] = s / n; const o = x - r, i = x + r + 1; if (o >= 0) { s -= v[row + o]; n--; } if (i < W) { s += v[row + i]; n++; } } }
      for (let x = 0; x < W; x++) { let s = 0, n = 0; for (let y = -r; y <= r; y++) if (y >= 0 && y < H) { s += t[y * W + x]; n++; }
        for (let y = 0; y < H; y++) { v[y * W + x] = s / n; const o = y - r, i = y + r + 1; if (o >= 0) { s -= t[o * W + x]; n--; } if (i < H) { s += t[i * W + x]; n++; } } }
    }
  };
  // Relief exactly as the atlas paints it: signed distance to the coast, ridged noise where the land is rough.
  const s = W / 150;
  const toSea = chamfer(k => regionAt[k] < 0), toLand = chamfer(k => regionAt[k] >= 0);
  const coast = new Float32Array(N);
  for (let y = 0; y < H; y++) for (let x = 0; x < W; x++) {
    const k = y * W + x; let d = regionAt[k] >= 0 ? toSea[k] : -toLand[k];
    if (Math.abs(d) < 3 && x > 0 && y > 0 && x < W - 1 && y < H - 1) { const gx = (fieldAt[k + 1] - fieldAt[k - 1]) * .5, gy = (fieldAt[k + W] - fieldAt[k - W]) * .5, gl = Math.hypot(gx, gy); if (gl > 1e-6) d = (fieldAt[k] - SEA_T) / gl; }
    coast[k] = d;
  }
  const rough = new Float32Array(N); for (let k = 0; k < N; k++) rough[k] = biomeAt[k] === 255 ? 0 : (ROUGH[TERRAIN_KINDS[biomeAt[k]]] || 0);
  boxBlur(rough, Math.max(1, Math.round(1.3 * s)), 2);
  const hgt = new Float32Array(N);
  for (let y = 0; y < H; y++) for (let x = 0; x < W; x++) {
    const k = y * W + x; if (regionAt[k] < 0) { hgt[k] = 0; continue; } const ux = x * SX, uy = y * SY;
    const ridge = 1 - Math.abs(2 * fbm(ux * .16 + 3, uy * .16 + 5, 5) - 1);
    hgt[k] = .28 * smooth(0, 6 * s, coast[k]) + .10 * fbm(ux * .35 + 11, uy * .35 + 7, 5) + rough[k] * (.12 + .95 * ridge * ridge) * smooth(0, 2.5 * s, coast[k]);
  }
  return { W, H, SX, SY, s, regionAt, fieldAt, biomeAt, coast, rough, hgt, sample };
}

module.exports = { ROOT, ATLAS, SEED, SEA_T, MAP_W, MAP_H, TERRAIN_KINDS, ROUGH, TERRAIN_ONLY, mulberry, seedNoise, vnoise, fbm, smooth, loadLands, readAtlasRegions, computeAtlasFields };
