// Species colour (design review C2, reports/design_review_2026-10-25.md; style guide 13_Production/art_direction.md).
// A species' palette is [main, dark, accent]:
//   main + dark = its natural, folk-read colour from its family (green goblins, brown rabbits, grey-green wolves),
//                 varied per species (hue ±12°, value ±10%) so siblings differ;
//   accent      = its element, used as the ~10% accent (eyes, markings, glow), not the whole body.
// Slimes and elementals are made of their element, so their body keeps the element palette.
// No body value goes below 25% (V in HSV), so dark families keep contrast and glow carries the menace.
// Deterministic from the species id; never touches generate.js's seeded stream, so no other field moves.

// Element accent colour and the word used for it in the look text.
const ACCENT = {
  None: null,
  Fire: ['#ff7a3d', 'ember-orange'], Water: ['#4fa8e8', 'sea-blue'], Ice: ['#9fdcff', 'frost-blue'],
  Lightning: ['#ffe14d', 'electric-yellow'], Earth: ['#d1a15a', 'ochre'], Wind: ['#8fe0bd', 'pale jade'],
  Nature: ['#8fd16a', 'leaf-green'], Poison: ['#b8e986', 'sickly green'], Light: ['#ffd166', 'gold'],
  Dark: ['#9a86d8', 'violet'], Blood: ['#e0344a', 'crimson'], Void: ['#8a7cff', 'violet-edged'],
};

// Families whose bodies are their element.
const ELEMENT_BODIES = new Set(['slime', 'elemental']);

// Natural tones per family: [main, dark, words]. A species picks one by a hash of its id.
const T = (main, dark, words) => ({ main, dark, words });
const FAMILY_TONES = {
  goblinoid: [T('#6fae45', '#8a5a35', 'moss green and leather brown'), T('#8c9a4b', '#6a4a30', 'olive and hide brown'), T('#7d8f6a', '#5a4632', 'grey-green and patched leather')],
  kobold: [T('#b5653a', '#6e3b24', 'rust-red'), T('#c29545', '#7a5a2a', 'ochre'), T('#5f7a99', '#3e4f66', 'slate-blue')],
  beast: [T('#8b6a47', '#5a4230', 'warm brown'), T('#b08850', '#735634', 'tawny'), T('#8c8a85', '#5c5a56', 'ash-grey'), T('#5e4c40', '#433630', 'dark brown'), T('#d8c8a8', '#9a8a70', 'cream')],
  lycan: [T('#7f7f86', '#55555c', 'wolf-grey'), T('#7a5a40', '#52402e', 'brown'), T('#5a4a40', '#43383a', 'black-brown'), T('#e4e6ea', '#9aa0aa', 'snow-white')],
  insect: [T('#7a5230', '#4e3520', 'glossy brown'), T('#3f7a4a', '#2c5234', 'iridescent green'), T('#c08a2e', '#7a561c', 'amber'), T('#46507a', '#343a58', 'blue-black')],
  killer_insect: [T('#d9a21e', '#4a4248', 'hazard yellow banded with black'), T('#a8332b', '#5e2a28', 'lacquer-red'), T('#55555f', '#403f48', 'black')],
  undead: [T('#d8ccb0', '#8a7f68', 'bleached bone and grave-cloth'), T('#8a9a7a', '#5a6650', 'grave-mould grey-green'), T('#5a5482', '#4a4570', 'dusk-violet')],
  shadow: [T('#5a5482', '#4a4570', 'smoky violet'), T('#5a6280', '#454a62', 'storm-grey')],
  orc_giant: [T('#6e8c4a', '#4a5e32', 'olive-green'), T('#9a7a5a', '#64503c', 'sun-brown'), T('#7a7f8a', '#52565e', 'stone-grey')],
  minotaur: [T('#6b4a35', '#4a3428', 'dark chestnut'), T('#8c6a4a', '#5e4632', 'tan'), T('#5a5654', '#423f3e', 'charcoal')],
  reptile: [T('#5e8c4a', '#3e5e32', 'green'), T('#a08a50', '#6a5a34', 'sand-coloured'), T('#4a6a7a', '#344a56', 'teal-grey')],
  draconic: [T('#b03a2e', '#6e2a24', 'crimson'), T('#2e6e8e', '#244c62', 'sapphire'), T('#3e7a3a', '#2c5228', 'emerald'), T('#c8a040', '#7e6428', 'bronze'), T('#6a6a7a', '#4a4a56', 'iron-grey')],
  construct: [T('#8c8a85', '#5c5a56', 'weathered stone'), T('#a8784a', '#6a4c30', 'bronze'), T('#6a7078', '#4a4f56', 'riveted iron')],
  plant: [T('#5e8c3a', '#5a4030', 'leaf green over bark brown'), T('#7a9a4a', '#4e5a34', 'moss green and lichen grey'), T('#4e7a44', '#4a3a2c', 'deep fern green and dark bark')],
  // dark paints the back and the pattern (body.py), so for a cap it is a deeper cap colour, not the pale stem.
  mushroom: [T('#c8553d', '#8a3428', 'red with pale spots'), T('#a8784a', '#6e4c2e', 'warm brown'), T('#8c6aa8', '#5e4674', 'dusky violet')],
  demon: [T('#a8332b', '#5e2a28', 'brimstone red'), T('#6a4a7a', '#4a3a58', 'bruised violet'), T('#4e4a58', '#403c48', 'char-black')],
  aquatic: [T('#3e7fa0', '#2a5670', 'sea-blue'), T('#4a9a8a', '#326a5e', 'teal'), T('#9aa8b0', '#64707a', 'silver')],
  avian: [T('#8b6a47', '#5a4230', 'brown'), T('#4e4e5a', '#404048', 'crow-black'), T('#c8b89a', '#8a7a60', 'pale buff'), T('#4e7ab0', '#34547a', 'blue')],
  chimera: [T('#b08850', '#735634', 'lion-tawny'), T('#7a5a40', '#52402e', 'brown and dark umber')],
  serpentfolk: [T('#5e8c4a', '#3e5e32', 'green'), T('#8c6a9a', '#5c466a', 'violet'), T('#b08850', '#735634', 'gold-brown')],
  centaur: [T('#8b6a47', '#5a4230', 'chestnut'), T('#c8c4bc', '#8a8680', 'dapple-grey'), T('#5e4c40', '#433630', 'dark bay')],
  headless: [T('#5f6470', '#454852', 'gunmetal'), T('#5a5482', '#4a4570', 'violet-black')],
  gremlin: [T('#7aa04a', '#4e6a30', 'lime-green'), T('#8c7ab0', '#5c4e7a', 'lavender')],
  aberration: [T('#8a6a8a', '#5c465c', 'mauve'), T('#6a8a7a', '#465c52', 'sickly teal'), T('#a87a6a', '#6e5046', 'raw pink')],
  yokai: [T('#d8d0c0', '#8a8272', 'paper white'), T('#b04a3a', '#6e3028', 'lacquer red'), T('#4a5a7a', '#363f56', 'indigo')],
  floorborn: [T('#7a7f8a', '#52565e', 'dungeon stone'), T('#8a6a4a', '#5c4632', 'rusted iron')],
  vesperite: [T('#5a5482', '#4a4570', 'dusk violet'), T('#3e5a7a', '#2e4258', 'twilight blue')],
  sandborne: [T('#c8a060', '#86683c', 'sand gold'), T('#b07a4a', '#744e30', 'sunbaked clay')],
  humanoid_enemy: [T('#8a5a35', '#5a5f66', 'leather browns and dull steel'), T('#5a6a4a', '#4a4036', 'worn green and leather brown')],
  familiar: [T('#e8c8a0', '#a88a68', 'soft cream'), T('#e0b0c8', '#a07a8e', 'pastel pink'), T('#a0c8d8', '#6e8e9c', 'powder blue'), T('#b8d8a0', '#7e9a6a', 'mint')],
};
const MUSHROOM = /mushroom|cap\b|spore|puff|fung|myc/i;

// The review's exact Ring 0-1 cast (C2.2).
const EXPLICIT = {
  mon_goblin: ['#6fae45', '#8a5a35', '#b8bec6', 'moss green and leather brown'],
  mon_goblin_archer: ['#6fae45', '#8a5a35', '#b8bec6', 'moss green and leather brown'],
  mon_horned_rabbit: ['#a8774e', '#7a5434', '#f0e0c0', 'warm brown with a cream belly'],
  mon_forest_wolf: ['#7e8c78', '#56604f', '#f0e6cc', 'grey-green with a cream ruff'],
};

// ---------- colour maths ----------
const hex2rgb = h => [1, 3, 5].map(i => parseInt(h.slice(i, i + 2), 16) / 255);
const rgb2hex = c => '#' + c.map(v => Math.round(Math.max(0, Math.min(1, v)) * 255).toString(16).padStart(2, '0')).join('');
function rgb2hsv([r, g, b]) {
  const mx = Math.max(r, g, b), mn = Math.min(r, g, b), d = mx - mn;
  let h = 0;
  if (d) h = mx === r ? ((g - b) / d) % 6 : mx === g ? (b - r) / d + 2 : (r - g) / d + 4;
  return [(h * 60 + 360) % 360, mx ? d / mx : 0, mx];
}
function hsv2rgb([h, s, v]) {
  const c = v * s, x = c * (1 - Math.abs(((h / 60) % 2) - 1)), m = v - c;
  const [r, g, b] = h < 60 ? [c, x, 0] : h < 120 ? [x, c, 0] : h < 180 ? [0, c, x] : h < 240 ? [0, x, c] : h < 300 ? [x, 0, c] : [c, 0, x];
  return [r + m, g + m, b + m];
}
function hash(s, salt = '') { let h = 2166136261; for (const ch of salt + s) h = Math.imul(h ^ ch.charCodeAt(0), 16777619); return (h >>> 0) / 4294967296; }
const MIN_V = 0.25;
function shift(hex, dh, dv) {
  const [h, s, v] = rgb2hsv(hex2rgb(hex));
  return rgb2hex(hsv2rgb([(h + dh + 360) % 360, s, Math.min(1, Math.max(MIN_V, v * (1 + dv)))]));
}
const floorV = hex => shift(hex, 0, 0);
const valueOf = hex => rgb2hsv(hex2rgb(hex))[2];

/** { palette: [main, dark, accent], tone: words for the look text } for a species. */
function paletteFor(sp, famKey, el) {
  if (EXPLICIT[sp.id]) { const [m, d, a, words] = EXPLICIT[sp.id]; return { palette: [m, d, a], tone: words }; }
  if (ELEMENT_BODIES.has(famKey)) return { palette: el.pal.map(floorV), tone: el.tone };
  const key = famKey === 'plant' && MUSHROOM.test(sp.name) ? 'mushroom' : famKey;
  const tones = FAMILY_TONES[key] || FAMILY_TONES.beast;
  // Variants keep their base species' tone, so a family line reads as one creature in different moods.
  const anchor = sp.baseSpeciesId || sp.id;
  const bony = famKey === 'undead' && /skelet|bone|lich|ossu/i.test(sp.name); // skeletons read as bone, not shroud
  const t = bony ? tones[0] : tones[Math.floor(hash(anchor, 'tone') * tones.length)];
  const dh = (hash(sp.id, 'hue') - 0.5) * 24, dv = (hash(sp.id, 'val') - 0.5) * 0.2;
  const acc = ACCENT[sp.element] || null;
  const accent = acc ? acc[0] : shift(t.main, 0, 0.45);
  const head = acc ? acc[1].split(/[\s-]/).pop() : null; // 'leaf-green' -> 'green'
  const tone = acc && !t.words.includes(head) ? `${t.words}, with ${acc[1]} markings` : t.words;
  return { palette: [shift(t.main, dh, dv), shift(t.dark, dh, dv), accent], tone };
}

module.exports = { paletteFor, valueOf, MIN_V, FAMILY_TONES, ELEMENT_BODIES };
