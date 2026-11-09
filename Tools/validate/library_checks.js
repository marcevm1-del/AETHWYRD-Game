// Library validator: Data/Library/libraries.json and books.json plus the book texts in 02_Lore/library/.
// Rules: unique ids; libraries sit in existing regions; every shelved book names an existing library and region and a text file that
// exists; word count within bounds; held books are never shelved; no book text names a Canon section 3 secret; rank gates and
// rewards point at real things; no library holds an unreasonable number of books.
const fs = require('fs');
const path = require('path');

const SECRETS = /Azrael|Noxveil|\bAdrian\b|Kaede|Aoyama|Malgareth|Malchior|Red Prophet|Night of Unweaving|Caspian|Nocturne|\bMina\b|Ezrath|Forgotten Ninth|Hooded Traveler|Whiskers|\bNyx\b|Lantern Seal|Lantern Night|Thirteenth Star|Unwoven Sky|Unclosed Knot|soul harvest|video game/;
const MIN_WORDS = 300, MAX_WORDS = 3000, MAX_PER_LIBRARY = 60;

exports.run = function (ctx) {
  const { DATA, load, check, schema, err, regions, species } = ctx;
  const LF = 'Library/libraries.json', BF = 'Library/books.json';
  if (!fs.existsSync(path.join(DATA, LF))) { err(LF, 'file missing'); return { summary: 'library: files missing' }; }
  if (!fs.existsSync(path.join(DATA, BF))) { err(BF, 'file missing'); return { summary: 'library: files missing' }; }
  const lf = load(LF), bf = load(BF);
  check(lf, schema('libraries'), LF);
  check(bf, schema('books'), BF);
  const regionIds = new Set(regions.map(r => r.id));
  const libs = new Map();
  for (const l of lf.libraries || []) {
    if (libs.has(l.id)) err(l.id, 'duplicate library id');
    libs.set(l.id, l);
    if (!regionIds.has(l.region)) err(l.id, `unknown region ${l.region}`);
    for (const r of l.covers || []) if (!regionIds.has(r)) err(l.id, `covers unknown region ${r}`);
  }
  const civ = new Set((load('World/civilization_archive.json').civilizations || []).map(c => c.id));
  const ids = new Set();
  const perLib = new Map();
  const ROOT = path.join(DATA, '..');
  let shelved = 0, held = 0;
  for (const b of bf.books || []) {
    if (ids.has(b.id)) err(b.id, 'duplicate book id');
    ids.add(b.id);
    if (b.status === 'hold') {
      held++;
      if (b.library || b.text) err(b.id, 'a hold book must not be shelved (library and text must be null)');
      continue;
    }
    shelved++;
    if (!b.library || !libs.has(b.library)) { err(b.id, `unknown library ${b.library}`); continue; }
    perLib.set(b.library, (perLib.get(b.library) || 0) + 1);
    if (!regionIds.has(b.region)) err(b.id, `unknown shelf region ${b.region}`);
    else if (b.region !== libs.get(b.library).region) err(b.id, `region ${b.region} is not the library's region ${libs.get(b.library).region}`);
    if (b.subjectRegion && !regionIds.has(b.subjectRegion)) err(b.id, `unknown subject region ${b.subjectRegion}`);
    if (b.words < MIN_WORDS || b.words > MAX_WORDS) err(b.id, `word count ${b.words} outside ${MIN_WORDS}-${MAX_WORDS}`);
    if (!b.text) { err(b.id, 'shelved book has no text file'); continue; }
    const tp = path.join(ROOT, b.text);
    if (!fs.existsSync(tp)) { err(b.id, `text file missing: ${b.text}`); continue; }
    if (!b.text.includes(`/${b.library}/`)) err(b.id, 'text file is not under its library folder');
    const txt = fs.readFileSync(tp, 'utf8');
    const m = SECRETS.exec(txt);
    if (m) err(b.id, `text names a Canon section 3 secret: "${m[0]}" (a book a player can read may not)`);
    for (const rw of b.rewards || []) {
      if (rw.kind === 'bestiary' && !species.has(rw.id)) err(b.id, `reward names unknown species ${rw.id}`);
      if (rw.kind === 'archive' && !civ.has(rw.id)) err(b.id, `reward names unknown civilization ${rw.id}`);
    }
  }
  for (const [id, n] of perLib) if (n > MAX_PER_LIBRARY) err(id, `holds ${n} books (limit ${MAX_PER_LIBRARY})`);
  return { summary: `library: ${libs.size} libraries · ${shelved} books shelved · ${held} held` };
};
