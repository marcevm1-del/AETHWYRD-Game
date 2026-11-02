// Labels the physical relief: lakes, rivers, range crests, peaks, passes, corridor roads, region and sea names,
// legend and scale. Called by build_physical_map.js with the relief PNG and the physical_map.json data; draws on an
// HTML canvas in headless Chromium (Playwright) and saves the PNG. Without Playwright it throws, and the builder
// keeps the unlabelled relief. Not a dependency of the repo: `require('playwright')` must resolve on the machine.
'use strict';
const fs = require('fs');
const path = require('path');
const os = require('os');

function loadPlaywright() {
  try { return require('playwright'); } catch (e) { /* fall through */ }
  const { execSync } = require('child_process');
  const root = execSync('npm root -g', { encoding: 'utf8' }).trim();
  return require(path.join(root, 'playwright'));
}

async function render(reliefPng, data, outPng) {
  const { chromium } = loadPlaywright();
  const regions = JSON.parse(fs.readFileSync(path.join(__dirname, '..', '..', 'Data', 'World', 'regions.json'), 'utf8'));
  const lands = regions.filter(r => r.layer === 'surface' && r.map && r.map.radius > 0).map(r => ({ id: r.id, name: r.name, ring: r.ring, at: r.map.at, isle: !!r.map.isle }));
  const gates = regions.filter(r => r.layer === 'underworld' && r.map && r.map.gate).map(r => ({ name: r.name.split(' · ')[0], at: r.map.at }));
  const payload = {
    relief: 'data:image/png;base64,' + fs.readFileSync(reliefPng).toString('base64'),
    grid: data.grid, biomeRows: data.biomes.rows, rivers: data.rivers, ranges: data.ranges, passes: data.passes, lakes: data.lakes,
    corridors: data.corridors, seas: data.seas, lands, gates,
  };
  const html = `<!doctype html><meta charset="utf-8"><body style="margin:0;background:#e9dcbc"><canvas id="c" width="1860" height="1430"></canvas>
<script>window.DATA=${JSON.stringify(payload)};</script><script>(${draw.toString()})()</script>`;
  const tmp = path.join(os.tmpdir(), 'ascend_physical_map_' + process.pid + '.html');
  fs.writeFileSync(tmp, html);
  const browser = await chromium.launch();
  try {
    const page = await browser.newPage({ viewport: { width: 1860, height: 1430 } });
    await page.goto('file://' + tmp);
    await page.waitForFunction('window.DONE === true', null, { timeout: 60000 });
    const b64 = await page.evaluate(() => document.getElementById('c').toDataURL('image/png').split(',')[1]);
    fs.writeFileSync(outPng, Buffer.from(b64, 'base64'));
  } finally { await browser.close(); fs.unlinkSync(tmp); }
  return true;
}

// Runs in the page.
function draw() {
  const D = window.DATA, cv = document.getElementById('c'), g = cv.getContext('2d');
  const S = 12, OX = 30, OY = 120; // 12 px per km, map placed below the title band
  const P = (x, y) => [OX + x * S, OY + y * S];
  const SERIF = '"Bitstream Charter", Caladea, "DejaVu Serif", FreeSerif, Georgia, serif';
  const INK = '#3b2a1a', RIVER = '#3f7896', SEA_INK = '#3d6b7c';
  const boxes = [];
  const free = (b) => !boxes.some(o => b[0] < o[2] && b[2] > o[0] && b[1] < o[3] && b[3] > o[1]);
  function label(text, x, y, o = {}) {
    const size = o.size || 14; g.save(); g.font = `${o.italic ? 'italic ' : ''}${o.weight || 600} ${size}px ${SERIF}`;
    if (o.caps) text = text.toUpperCase();
    const sp = o.spacing || 0; g.letterSpacing = sp + 'px';
    const w = g.measureText(text).width, h = size;
    const ang = o.angle || 0;
    const bw = Math.abs(Math.cos(ang)) * w + Math.abs(Math.sin(ang)) * h, bh = Math.abs(Math.sin(ang)) * w + Math.abs(Math.cos(ang)) * h;
    const b = [x - bw / 2 - 3, y - bh / 2 - 3, x + bw / 2 + 3, y + bh / 2 + 3];
    if (!o.force && !free(b)) { g.restore(); return false; }
    boxes.push(b);
    g.translate(x, y); g.rotate(ang); g.textAlign = 'center'; g.textBaseline = 'middle';
    g.lineJoin = 'round'; g.lineWidth = o.halo == null ? 4 : o.halo; g.strokeStyle = o.haloColor || 'rgba(244,234,208,.88)';
    if (g.lineWidth > 0) g.strokeText(text, 0, 0);
    g.fillStyle = o.color || INK; g.fillText(text, 0, 0); g.restore(); return true;
  }
  const img = new Image();
  img.onload = () => {
    // paper and frame
    g.fillStyle = '#eadfc2'; g.fillRect(0, 0, cv.width, cv.height);
    const W = D.grid.mapUnits[0] * S, H = D.grid.mapUnits[1] * S;
    g.drawImage(img, OX, OY, W, H);
    g.strokeStyle = INK; g.lineWidth = 3; g.strokeRect(OX - 6, OY - 6, W + 12, H + 12); g.lineWidth = 1; g.strokeRect(OX - 11, OY - 11, W + 22, H + 22);
    // km ticks on the frame every 10 km
    g.fillStyle = INK; g.font = `500 11px ${SERIF}`; g.textAlign = 'center';
    for (let x = 0; x <= 150; x += 10) { const [px] = P(x, 0); g.fillRect(px - .5, OY - 11, 1, 5); g.fillText(x, px, OY - 15); }
    g.textAlign = 'right'; for (let y = 0; y <= 100; y += 10) { const [, py] = P(0, y); g.fillRect(OX - 11, py - .5, 5, 1); g.fillText(y, OX - 14, py + 4); }
    // lakes: the lake cells, softened
    const lc = document.createElement('canvas'); lc.width = D.grid.width; lc.height = D.grid.height; const lg = lc.getContext('2d'); const id = lg.createImageData(lc.width, lc.height);
    D.biomeRows.forEach((row, j) => { for (let i = 0; i < row.length; i++) if (row[i] === 'l') { const o = (j * lc.width + i) * 4; id.data[o] = 120; id.data[o + 1] = 168; id.data[o + 2] = 182; id.data[o + 3] = 255; } });
    lg.putImageData(id, 0, 0); g.save(); g.imageSmoothingEnabled = true; g.filter = 'blur(1.2px)'; g.drawImage(lc, OX, OY, W, H); g.restore();
    // corridor roads
    g.save(); g.setLineDash([7, 5]); g.lineCap = 'round';
    for (const co of D.corridors) for (const l of co.legs) { if (!l.path) continue; g.strokeStyle = 'rgba(244,234,208,.8)'; g.lineWidth = 4.5; g.beginPath(); l.path.forEach(([x, y], i) => { const [a, b] = P(x, y); i ? g.lineTo(a, b) : g.moveTo(a, b); }); g.stroke();
      g.strokeStyle = '#8a3b22'; g.lineWidth = 2; g.stroke(); }
    g.restore();
    // rivers, widening downstream
    const rivers = D.rivers.slice().sort((a, b) => a.flowIndex - b.flowIndex);
    for (const r of rivers) {
      const wMax = Math.max(1.4, Math.min(5.5, Math.log10(r.flowIndex + 1) * 1.7)), n = r.path.length;
      g.lineCap = 'round'; g.lineJoin = 'round';
      for (let pass = 0; pass < 2; pass++) for (let i = 1; i < n; i++) {
        const t = i / (n - 1), w = (r.kind === 'river' ? .35 + .65 * t : .45 + .55 * t) * wMax;
        const [a, b] = P(...r.path[i - 1]), [c, d] = P(...r.path[i]);
        g.strokeStyle = pass ? RIVER : 'rgba(244,236,214,.75)'; g.lineWidth = pass ? w : w + 2.5; g.beginPath(); g.moveTo(a, b); g.lineTo(c, d); g.stroke();
      }
    }
    // range crests: a soft brown hachure line
    for (const r of D.ranges) { if (r.crest.length < 2) continue; g.save(); g.strokeStyle = 'rgba(92,60,34,.45)'; g.lineWidth = 2; g.setLineDash([2, 4]); g.beginPath(); r.crest.forEach(([x, y], i) => { const [a, b] = P(x, y); i ? g.lineTo(a, b) : g.moveTo(a, b); }); g.stroke(); g.restore(); }
    // title band
    g.fillStyle = INK; g.textAlign = 'left'; g.font = `700 40px ${SERIF}`; g.letterSpacing = '4px'; g.fillText('AETHERIA', OX, 58); g.letterSpacing = '0px';
    g.font = `italic 500 20px ${SERIF}`; g.fillText('The physical map: relief, ranges, rivers and passes', OX + 245, 56);
    g.font = `500 13px ${SERIF}`; g.fillStyle = '#5a4630'; g.fillText('Derived from the atlas (coastline seed 1207) and Data/World/regions.json by Tools/atlas/build_physical_map.js · 1 map unit = 1 km · north up', OX, 86);
    boxes.push([0, 0, cv.width, OY - 12]);
    // region names first (they own their anchors), then seas, ranges, rivers, passes, peaks, gates
    for (const L of D.lands) { const [x, y] = P(...L.at); label(L.name, x, y, { size: L.id === 'reg_whisperwood' || L.id === 'reg_aldmere' ? 17 : 14, caps: true, spacing: 1.5, weight: 700, force: true }); }
    for (const s of D.seas) { const [x, y] = P(...s.label); const parts = s.name.replace(/^The /, 'The\n').split('\n'); parts.forEach((t, i) => label(t, x, y + (i - (parts.length - 1) / 2) * 26, { size: 22, italic: true, color: SEA_INK, weight: 500, halo: 0, force: true, spacing: 2 })); }
    for (const r of D.ranges) {
      const c = r.crest, [x0, y0] = c[0], [x1, y1] = c[c.length - 1]; let ang = Math.atan2(y1 - y0, x1 - x0); if (ang > Math.PI / 2) ang -= Math.PI; if (ang < -Math.PI / 2) ang += Math.PI;
      const m = c[Math.floor(c.length / 2)], [x, y] = P(m[0], m[1]);
      const ok = label(r.name + (r.proposed ? '*' : ''), x, y, { size: 13, italic: true, color: '#5b3a1e', weight: 600, angle: Math.abs(ang) > 1.2 ? ang : ang * .6, spacing: 2 });
      if (!ok) label(r.name + (r.proposed ? '*' : ''), x, y + 22, { size: 13, italic: true, color: '#5b3a1e', weight: 600, spacing: 2 });
    }
    for (const r of D.rivers) {
      if (!(r.kind === 'stream' || (r.kind === 'river' && r.lengthKm >= 20) || (r.kind === 'tributary' && r.lengthKm >= 35))) continue;
      for (const f of [.55, .4, .7, .3, .8]) {
        const k = Math.floor((r.path.length - 1) * f), a = r.path[Math.max(0, k - 1)], b = r.path[Math.min(r.path.length - 1, k + 1)];
        let ang = Math.atan2(b[1] - a[1], b[0] - a[0]); if (ang > Math.PI / 2) ang -= Math.PI; if (ang < -Math.PI / 2) ang += Math.PI;
        const [x, y] = P(...r.path[k]); const nx = -Math.sin(ang) * 10, ny = Math.cos(ang) * 10, o = { size: 12, italic: true, color: RIVER, weight: 600, angle: ang, halo: 3 };
        if (label(r.name + (r.proposed ? '*' : ''), x + nx, y + ny, o) || label(r.name + (r.proposed ? '*' : ''), x - nx, y - ny, o)) break;
      }
    }
    for (const p of D.passes) {
      const [x, y] = P(...p.at); g.save(); g.strokeStyle = '#8a3b22'; g.lineWidth = 2.2; g.beginPath(); g.arc(x - 6, y, 6, -Math.PI / 2.6, Math.PI / 2.6); g.stroke(); g.beginPath(); g.arc(x + 6, y, 6, Math.PI - Math.PI / 2.6, Math.PI + Math.PI / 2.6); g.stroke(); g.restore();
      boxes.push([x - 8, y - 8, x + 8, y + 8]);
      const t = `${p.name}${p.proposed ? '*' : ''} ${p.m} m`;
      const o = { size: 12, color: '#7a3018', weight: 700 }; g.save(); g.font = `700 12px ${SERIF}`; const hw = g.measureText(t).width / 2 + 14; g.restore();
      label(t, x, y - 19, o) || label(t, x, y + 19, o) || label(t, x + hw, y, o) || label(t, x - hw, y, o);
    }
    for (const r of D.ranges) r.peaks.forEach((p, i) => {
      if (i > 1 && !p.name) return; const [x, y] = P(...p.at);
      g.save(); g.fillStyle = p.biome === 'volcanic' ? '#8a3424' : INK; g.beginPath(); g.moveTo(x, y - 6); g.lineTo(x + 5, y + 3); g.lineTo(x - 5, y + 3); g.closePath(); g.fill(); g.restore();
      boxes.push([x - 6, y - 7, x + 6, y + 4]);
      const t = p.name ? `${p.name}${p.proposed ? '*' : ''} ${p.m}` : `${p.m}`;
      const o = { size: p.name ? 12 : 10.5, weight: p.name ? 700 : 500, italic: !p.name, halo: 3 }; g.save(); g.font = `${o.weight} ${o.size}px ${SERIF}`; const hw = g.measureText(t).width / 2 + 9; g.restore();
      label(t, x, y + 13, o) || label(t, x, y - 16, o) || label(t, x + hw, y, o) || label(t, x - hw, y, o);
    });
    const seen = new Set();
    for (const gt of D.gates) { const k = gt.at.join(); if (seen.has(k)) continue; seen.add(k); const [x, y] = P(...gt.at);
      g.save(); g.fillStyle = '#3a2350'; g.strokeStyle = '#efe2c4'; g.lineWidth = 1.5; g.beginPath(); g.moveTo(x, y - 6); g.lineTo(x + 6, y + 4); g.lineTo(x - 6, y + 4); g.closePath(); g.fill(); g.stroke(); g.restore(); }
    // legend
    const LX = OX + W - 360, LY = OY + H + 26;
    g.fillStyle = INK; g.font = `700 14px ${SERIF}`; g.textAlign = 'left';
    const items = [['road', 'Trade corridor road'], ['river', 'River (wider downstream)'], ['pass', 'Pass, with its height'], ['peak', 'Summit (m)'], ['gate', 'Underworld gate'], ['crest', 'Range crest']];
    items.forEach(([k, t], i) => {
      const x = OX + 10 + (i % 3) * 250, y = LY + 6 + Math.floor(i / 3) * 26;
      g.save(); g.strokeStyle = k === 'road' ? '#8a3b22' : k === 'river' ? RIVER : k === 'crest' ? 'rgba(92,60,34,.7)' : '#8a3b22'; g.lineWidth = k === 'river' ? 4 : 2;
      if (k === 'road') g.setLineDash([7, 5]); if (k === 'crest') g.setLineDash([2, 4]);
      if (k === 'road' || k === 'river' || k === 'crest') { g.beginPath(); g.moveTo(x, y); g.lineTo(x + 34, y); g.stroke(); }
      if (k === 'pass') { g.beginPath(); g.arc(x + 11, y, 6, -1.2, 1.2); g.stroke(); g.beginPath(); g.arc(x + 23, y, 6, Math.PI - 1.2, Math.PI + 1.2); g.stroke(); }
      if (k === 'peak') { g.fillStyle = INK; g.beginPath(); g.moveTo(x + 17, y - 6); g.lineTo(x + 22, y + 3); g.lineTo(x + 12, y + 3); g.fill(); }
      if (k === 'gate') { g.fillStyle = '#3a2350'; g.beginPath(); g.moveTo(x + 17, y - 6); g.lineTo(x + 23, y + 4); g.lineTo(x + 11, y + 4); g.fill(); }
      g.restore(); g.fillStyle = INK; g.font = `500 14px ${SERIF}`; g.fillText(t, x + 44, y + 5);
    });
    g.font = `italic 500 13px ${SERIF}`; g.fillStyle = '#5a4630'; g.fillText('* proposed name (Canon §6), not yet canon. Heights in metres; relief light from the north-west.', OX + 10, LY + 66);
    // scale bar
    const sx = LX + 40, sy = LY + 10; g.fillStyle = INK; for (let i = 0; i < 4; i++) { g.fillStyle = i % 2 ? '#efe4c8' : INK; g.fillRect(sx + i * 5 * S, sy, 5 * S, 7); } g.strokeStyle = INK; g.lineWidth = 1; g.strokeRect(sx, sy, 20 * S, 7);
    g.fillStyle = INK; g.font = `500 13px ${SERIF}`; g.textAlign = 'center'; [0, 5, 10, 15, 20].forEach((v, i) => g.fillText(v + (v === 20 ? ' km' : ''), sx + i * 5 * S, sy + 24));
    // compass
    const cxp = OX + W - 40, cyp = OY + H + 50; g.save(); g.translate(cxp, cyp); g.fillStyle = INK; g.beginPath(); g.moveTo(0, -26); g.lineTo(7, 0); g.lineTo(0, -5); g.lineTo(-7, 0); g.closePath(); g.fill();
    g.strokeStyle = INK; g.lineWidth = 1.2; g.beginPath(); g.moveTo(0, 26); g.lineTo(7, 0); g.moveTo(0, 26); g.lineTo(-7, 0); g.stroke(); g.font = `700 14px ${SERIF}`; g.textAlign = 'center'; g.fillText('N', 0, -32); g.restore();
    window.DONE = true;
  };
  img.src = D.relief;
}

module.exports = { render };
