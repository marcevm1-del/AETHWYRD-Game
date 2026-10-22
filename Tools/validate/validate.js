// Project Ascend data validator. Dependency-free (plain Node).
// Usage: node Tools/validate/validate.js        → exit code 1 if anything is wrong
// Checks: 1) every row against its JSON Schema (subset: type, required, properties,
// additionalProperties:false, enum, pattern, minimum/maximum, minLength, minItems/maxItems, items)
// 2) IDs unique across ALL data  3) every cross-reference points at an existing ID.
const fs = require('fs');
const path = require('path');
const ROOT = path.join(__dirname, '..', '..');
const DATA = path.join(ROOT, 'Data');
const load = p => JSON.parse(fs.readFileSync(path.join(DATA, p), 'utf8'));
const schema = n => load(`Schemas/${n}.schema.json`);

// collection name → { files, schema }
const COLLECTIONS = {
  regions: { files: ['World/regions.json'], schema: 'region' },
  species: { files: ['Monsters/species.json'], schema: 'species' },
  population: { files: ['Monsters/population.json'], schema: 'population' },
  attacks: { files: ['Monsters/attacks.json'], schema: 'attack' },
  loot: { files: ['Monsters/loot_tables.json'], schema: 'loot_table' },
  items: { files: ['Items/materials.json', 'Items/items.json'], schema: 'item' },
  npcs: { files: ['NPCs/npcs.json'], schema: 'npc' },
  quests: { files: ['Quests/quests.json'], schema: 'quest' },
  weekly: { files: ['Quests/weekly_board.json'], schema: 'weekly_quest' },
  inns: { files: ['World/inns.json'], schema: 'inn' }
};

const errors = [];
const err = (where, msg) => { if (errors.length < 200) errors.push(`${where}: ${msg}`); else if (errors.length === 200) errors.push('…more errors truncated'); };

function typeOk(v, t) {
  if (Array.isArray(t)) return t.some(x => typeOk(v, x));
  switch (t) {
    case 'string': return typeof v === 'string';
    case 'number': return typeof v === 'number' && Number.isFinite(v);
    case 'integer': return Number.isInteger(v);
    case 'boolean': return typeof v === 'boolean';
    case 'array': return Array.isArray(v);
    case 'object': return v !== null && typeof v === 'object' && !Array.isArray(v);
    case 'null': return v === null;
    default: return true;
  }
}
function check(v, s, where) {
  if (s.type && !typeOk(v, s.type)) return err(where, `expected ${s.type}, got ${String(JSON.stringify(v)).slice(0, 40)}`);
  if (s.enum && !s.enum.includes(v)) err(where, `"${v}" not in [${s.enum.join(', ')}]`);
  if (typeof v === 'string') {
    if (s.pattern && !new RegExp(s.pattern).test(v)) err(where, `"${v}" does not match ${s.pattern}`);
    if (s.minLength != null && v.length < s.minLength) err(where, `shorter than ${s.minLength}`);
  }
  if (typeof v === 'number') {
    if (s.minimum != null && v < s.minimum) err(where, `${v} < minimum ${s.minimum}`);
    if (s.maximum != null && v > s.maximum) err(where, `${v} > maximum ${s.maximum}`);
  }
  if (Array.isArray(v)) {
    if (s.minItems != null && v.length < s.minItems) err(where, `fewer than ${s.minItems} items`);
    if (s.maxItems != null && v.length > s.maxItems) err(where, `more than ${s.maxItems} items`);
    if (s.items) v.forEach((x, i) => check(x, s.items, `${where}[${i}]`));
  }
  if (typeOk(v, 'object')) {
    for (const r of s.required || []) if (!(r in v)) err(where, `missing required "${r}"`);
    for (const [k, x] of Object.entries(v)) {
      if (s.properties && s.properties[k]) check(x, s.properties[k], `${where}.${k}`);
      else if (s.additionalProperties === false) err(where, `unknown field "${k}"`);
    }
  }
}

// 1) Schema validation + collect IDs
const rows = {};
const allIds = new Map();
for (const [name, c] of Object.entries(COLLECTIONS)) {
  const s = schema(c.schema);
  rows[name] = [];
  for (const f of c.files) {
    if (!fs.existsSync(path.join(DATA, f))) { err(f, 'file missing'); continue; }
    const list = load(f);
    if (!Array.isArray(list)) { err(f, 'top level must be an array'); continue; }
    list.forEach((row, i) => {
      check(row, s, `${f}#${row.id || i}`);
      if (row.id) {
        if (allIds.has(row.id)) err(f, `duplicate id "${row.id}" (also in ${allIds.get(row.id)})`);
        allIds.set(row.id, f);
      }
      rows[name].push(row);
    });
  }
}
const ID = Object.fromEntries(Object.keys(COLLECTIONS).map(n => [n, new Set(rows[n].map(r => r.id))]));
const families = new Set(rows.species.map(s => s.familyKey));

// 2) Cross-references
function ref(where, value, collection, optional = false) {
  if (optional && (value === '' || value == null)) return;
  if (!ID[collection].has(value)) err(where, `unknown ${collection} id "${value}"`);
}
for (const r of rows.regions) for (const f of r.allowedFamilies || []) if (!families.has(f)) err(r.id, `allowedFamilies: unknown family "${f}"`);
for (const s of rows.species) {
  (s.habitats || []).forEach(h => ref(`${s.id}.habitats`, h, 'regions'));
  (s.attackIds || []).forEach(a => ref(`${s.id}.attackIds`, a, 'attacks'));
  ref(`${s.id}.lootTableId`, s.lootTableId, 'loot');
  ref(`${s.id}.baseSpeciesId`, s.baseSpeciesId, 'species', true);
  if (s.tier === 'variant' && !s.baseSpeciesId) err(s.id, 'variant without baseSpeciesId');
  if (s.designRecipe && s.designRecipe.rigId !== s.rigId) err(s.id, 'designRecipe.rigId does not match rigId');
}
for (const p of rows.population) { ref(`${p.id}.speciesId`, p.speciesId, 'species'); ref(`${p.id}.regionId`, p.regionId, 'regions'); }
for (const l of rows.loot) (l.entries || []).forEach((e, i) => ref(`${l.id}.entries[${i}]`, e.itemId, 'items'));
for (const n of rows.npcs) { ref(`${n.id}.homeRegion`, n.homeRegion, 'regions'); (n.relationships || []).forEach(r => ref(`${n.id}.relationships`, r.npcId, 'npcs')); }
for (const q of [...rows.quests, ...rows.weekly]) {
  ref(`${q.id}.giver`, q.giver, 'npcs'); ref(`${q.id}.region`, q.region, 'regions');
  ((q.requirements || {}).prerequisites || []).forEach(p => ref(`${q.id}.prerequisites`, p, 'quests'));
  ((q.rewards || {}).items || []).forEach(i => ref(`${q.id}.rewards.items`, i, 'items'));
  (q.objectives || []).forEach((o, i) => {
    const where = `${q.id}.objectives[${i}]`;
    if (o.kind === 'kill' || o.kind === 'tame') ref(where, o.target, 'species');
    else if (o.kind === 'talk') ref(where, o.target, 'npcs');
    else if (o.kind === 'collect' && String(o.target).startsWith('itm_')) ref(where, o.target, 'items');
  });
}

for (const i of rows.inns) {
  ref(`${i.id}.regionId`, i.regionId, 'regions'); ref(`${i.id}.keeperNpcId`, i.keeperNpcId, 'npcs', true);
  if (i.rooms.filter(r => r.tier === 'signature').length > 1) err(i.id, 'at most one signature room');
}

// Weekly board: every weekday needs a special and at least 3 dailies (board shows 3 per day)
const WEEKDAYS = ['Solenday', 'Maelsday', 'Thorsday', 'Sylvasday', 'Kaelsday', 'Morrowsday', 'Vexday'];
for (const d of WEEKDAYS) {
  const wk = rows.weekly.filter(q => q.day === d);
  if (wk.filter(q => q.slot === 'special').length !== 1) err(`weekly ${d}`, 'needs exactly one day special');
  if (wk.filter(q => q.slot === 'daily').length < 3) err(`weekly ${d}`, 'needs at least 3 dailies');
}

// 3) Report
const counts = Object.entries(rows).map(([n, l]) => `${n} ${l.length}`).join(' · ');
if (errors.length) {
  console.error(`✗ ${errors.length} problem(s)\n` + errors.map(e => '  - ' + e).join('\n'));
  process.exit(1);
}
console.log(`✓ Data valid. ${counts}`);
