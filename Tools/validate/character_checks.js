// Character customization and silhouette rules (12_Systems/character_customization.md). Called from validate.js.
const fs = require('fs');
const path = require('path');

function hsv(hex) {
  const r = parseInt(hex.slice(1, 3), 16) / 255, g = parseInt(hex.slice(3, 5), 16) / 255, b = parseInt(hex.slice(5, 7), 16) / 255;
  const mx = Math.max(r, g, b), mn = Math.min(r, g, b);
  return { s: mx === 0 ? 0 : (mx - mn) / mx, v: mx };
}

function run({ DATA, load, check, schema, err }) {
  const has = f => fs.existsSync(path.join(DATA, f));
  if (!has('Characters/customization.json')) { err('customization.json', 'file missing'); return; }
  const w = 'customization.json', c = load('Characters/customization.json');
  check(c, schema('customization'), w);
  const lib = has('Characters/human_library.json') ? load('Characters/human_library.json') : { hairStyles: [], outfits: [], bodies: [] };
  const face = has('Characters/face_expressions.json') ? load('Characters/face_expressions.json') : { expressions: {} };
  const moves = has('Combat/weapon_movesets.json') ? load('Combat/weapon_movesets.json') : { families: [] };
  const ids = k => (c[k] || []).map(x => x.id);
  const byId = k => new Map((c[k] || []).map(x => [x.id, x]));
  for (const k of ['families', 'colourSlots', 'palettes', 'hairColours', 'irisColours', 'eyeShapes', 'pupilStyles', 'brows', 'mouths', 'expressions', 'faces', 'hairStyles', 'outfitPieces', 'accessories', 'weapons', 'sockets', 'looks']) {
    const l = ids(k); if (new Set(l).size !== l.length) err(w, `duplicate id in ${k}`);
  }
  for (const f of ['feminine', 'masculine']) if (!ids('families').includes(f)) err(w, `missing family ${f}`);
  const slots = new Set(ids('colourSlots')), sockets = new Set(ids('sockets'));
  const g = c.styleGuard || {};
  for (const [cat, slot] of Object.entries(c.materialSlots || {})) if (slot !== 'skin' && !slots.has(slot)) err(w, `materialSlots.${cat} names unknown slot ${slot}`);
  for (const p of c.palettes || []) {
    for (const s of slots) if (!(p.slots || {})[s]) err(w, `palette ${p.id} has no colour for slot ${s}`);
    for (const [s, hex] of Object.entries(p.slots || {})) {
      if (!slots.has(s)) err(w, `palette ${p.id} names unknown slot ${s}`);
      const q = hsv(hex);
      if (q.v < g.minValue - 1e-6 || q.v > g.maxValue + 1e-6 || q.s > g.maxSaturation + 1e-6) err(w, `palette ${p.id} slot ${s} ${hex} is outside the style guard (art_direction.md section 2)`);
    }
  }
  // built options must exist in the generator's data
  const libHair = new Map((lib.hairStyles || []).map(h => [h.id, h]));
  const sexOf = { feminine: 'female', masculine: 'male' };
  for (const h of c.hairStyles || []) {
    if (h.status === 'built') {
      const gh = libHair.get(h.generatorStyle);
      if (!gh) err(w, `hair ${h.id} is built but generatorStyle "${h.generatorStyle}" is not in human_library.json`);
      else for (const f of h.families) if (gh.body !== sexOf[f]) err(w, `hair ${h.id} offered to ${f} but the generator builds it for ${gh.body}`);
    } else if (h.generatorStyle) err(w, `hair ${h.id} is planned but names a generatorStyle`);
  }
  const genParts = new Set((lib.outfits || []).flatMap(o => o.parts || []));
  const cats = new Set(Object.keys(c.materialSlots || {}));
  for (const o of c.outfitPieces || []) {
    if (o.status === 'built') {
      if (!o.parts || o.parts.length === 0) err(w, `outfit piece ${o.id} is built but lists no parts`);
      for (const p of o.parts || []) if (!genParts.has(p)) err(w, `outfit piece ${o.id} part "${p}" is not built by any human_library outfit`);
    }
    for (const [cat, slot] of Object.entries(o.materials || {})) {
      if (!cats.has(cat)) err(w, `outfit piece ${o.id} material ${cat} is not a known material category`);
      if (!slots.has(slot)) err(w, `outfit piece ${o.id} maps ${cat} to unknown slot ${slot}`);
    }
  }
  for (const e of c.expressions || []) if (!(e.faceExpression in (face.expressions || {}))) err(w, `expression ${e.id} uses ${e.faceExpression}, which face_expressions.json does not define`);
  const eye = byId('eyeShapes'), brow = byId('brows'), mouth = byId('mouths'), expr = byId('expressions');
  for (const f of c.faces || []) {
    if (!eye.has(f.eyes)) err(w, `face ${f.id} eyes ${f.eyes} unknown`);
    if (!brow.has(f.brows)) err(w, `face ${f.id} brows ${f.brows} unknown`);
    if (!mouth.has(f.mouth)) err(w, `face ${f.id} mouth ${f.mouth} unknown`);
    if (!expr.has(f.restExpression)) err(w, `face ${f.id} restExpression ${f.restExpression} unknown`);
  }
  const wf = new Set((Array.isArray(moves.families) ? moves.families : Object.values(moves.families || {})).map(x => x.id));
  for (const x of c.weapons || []) {
    if (!wf.has(x.weaponFamily)) err(w, `weapon ${x.id} family ${x.weaponFamily} is not in weapon_movesets.json`);
    for (const s of [x.held, x.heldOff, x.sheathed].filter(Boolean)) if (!sockets.has(s)) err(w, `weapon ${x.id} socket ${s} unknown`);
  }
  for (const a of c.accessories || []) {
    if (!sockets.has(a.socket)) err(w, `accessory ${a.id} socket ${a.socket} unknown`);
    if (!slots.has(a.colourSlot)) err(w, `accessory ${a.id} colour slot ${a.colourSlot} unknown`);
  }
  const fam = byId('families'), face_ = byId('faces'), hair = byId('hairStyles'), piece = byId('outfitPieces'), acc = byId('accessories'), wpn = byId('weapons'), pal = byId('palettes'), look = byId('looks');
  for (const f of c.families || []) {
    const lk = look.get(f.defaultLook);
    if (!lk) err(w, `family ${f.id} default look ${f.defaultLook} unknown`);
    else if (lk.family !== f.id || lk.status !== 'built') err(w, `family ${f.id} default look must be a built look of that family`);
    if (!(lib.bodies || []).some(b => b.id === f.generatorBody)) err(w, `family ${f.id} generatorBody ${f.generatorBody} not in human_library.json`);
    if (!(f.heightM.min <= f.heightM.default && f.heightM.default <= f.heightM.max)) err(w, `family ${f.id} default height outside its range`);
  }
  for (const l of c.looks || []) {
    const refs = [];
    const need = (m, k, what) => { const x = m.get(k); if (!x) { err(w, `look ${l.id} ${what} ${k} unknown`); return null; } refs.push(x); return x; };
    const fc = need(face_, l.face, 'face'), hr = need(hair, l.hair, 'hair');
    if (!pal.has(l.palette)) err(w, `look ${l.id} palette ${l.palette} unknown`);
    for (const [slot, pid] of Object.entries(l.outfit || {})) {
      const p = need(piece, pid, 'outfit piece');
      if (p && p.slot !== slot) err(w, `look ${l.id} puts ${pid} (a ${p.slot}) in slot ${slot}`);
    }
    for (const a of l.accessories || []) need(acc, a, 'accessory');
    if (l.weapon) need(wpn, l.weapon, 'weapon');
    for (const x of refs) if (x.families && !x.families.includes(l.family)) err(w, `look ${l.id} uses ${x.id}, which is not made for ${l.family}`);
    if (fc) for (const [m, k] of [[eye, fc.eyes], [brow, fc.brows], [mouth, fc.mouth]]) { const o = m.get(k); if (o) refs.push(o); }
    const unbuilt = refs.filter(x => x.status === 'planned').map(x => x.id);
    if (l.status === 'built' && unbuilt.length) err(w, `look ${l.id} is marked built but uses planned options: ${unbuilt.join(', ')}`);
  }

  // ---- silhouette library
  if (!has('Characters/silhouettes.json')) { err('silhouettes.json', 'file missing'); return; }
  const sw = 'silhouettes.json', s = load('Characters/silhouettes.json');
  check(s, schema('silhouettes'), sw);
  const catIds = new Set((s.categories || []).map(x => x.id));
  const AX = s.axes || {};
  const list = s.silhouettes || [];
  const sid = list.map(x => x.id);
  if (new Set(sid).size !== sid.length) err(sw, 'duplicate silhouette id');
  for (const f of ['feminine', 'masculine']) {
    const n = list.filter(x => x.family === f).length;
    if (n < 30) err(sw, `${f} has ${n} silhouettes; at least 30 are required`);
  }
  const usedCats = new Set();
  for (const x of list) {
    if (!catIds.has(x.category)) err(sw, `${x.id} category ${x.category} unknown`);
    usedCats.add(x.family + '/' + x.category);
    for (const a of Object.keys(AX)) if (!(a in (x.shape || {}))) err(sw, `${x.id} has no value for axis ${a}`);
    for (const [a, v] of Object.entries(x.shape || {})) {
      if (!(a in AX)) err(sw, `${x.id} names unknown axis ${a}`);
      else if (!AX[a].includes(v)) err(sw, `${x.id} ${a}=${v} is not a listed value`);
    }
    for (const u of x.uses || []) if (!piece.has(u) && !hair.has(u) && !acc.has(u) && !wpn.has(u)) err(sw, `${x.id} uses ${u}, which is not in customization.json`);
  }
  for (const f of ['feminine', 'masculine']) for (const ccat of catIds) if (!usedCats.has(f + '/' + ccat)) err(sw, `${f} has no silhouette in category ${ccat}`);
  // distinctness: within a family, two silhouettes must differ on at least 3 outline axes (the decorative axes do not count)
  const OUTLINE = ['hair', 'hairLength', 'outer', 'sleeves', 'lower', 'armor', 'weapon', 'build', 'stance', 'headwear'];
  let worst = 99, pair = '';
  for (let i = 0; i < list.length; i++) for (let j = i + 1; j < list.length; j++) {
    const a = list[i], b = list[j];
    if (a.family !== b.family) continue;
    const d = OUTLINE.filter(k => (a.shape || {})[k] !== (b.shape || {})[k]).length;
    if (d < worst) { worst = d; pair = `${a.id}/${b.id}`; }
    if (d < 3) err(sw, `${a.id} and ${b.id} differ on only ${d} outline axes (need 3)`);
  }
  return { silhouettes: list.length, minOutlineDifference: worst, closestPair: pair };
}
module.exports = { run };
