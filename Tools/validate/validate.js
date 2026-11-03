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
  inns: { files: ['World/inns.json'], schema: 'inn' },
  shops: { files: ['Items/shops.json'], schema: 'shop' },
  siege: { files: ['World/siege_waves.json'], schema: 'siege_wave' },
  classes: { files: ['Classes/classes.json'], schema: 'class' },
  flags: { files: ['Quests/story_flags.json'], schema: 'story_flag' },
  spells: { files: ['Spells/spells.json'], schema: 'spell' },
  monsterSpells: { files: ['Spells/monster_spells.json'], schema: 'monster_spell' },
  threads: { files: ['Spells/threads.json'], schema: 'thread' },
  loomRanks: { files: ['Spells/loom_ranks.json'], schema: 'loom_rank' },
  attunement: { files: ['Spells/attunement_tree.json'], schema: 'tree_node' },
  ascension: { files: ['Spells/ascension.json'], schema: 'ascension_node' }
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
  ((q.prerequisites || {}).quests || []).forEach(p => ref(`${q.id}.prerequisites.quests`, p, 'quests'));
  ((q.prerequisites || {}).flags || []).forEach(fl => ref(`${q.id}.prerequisites.flags`, fl, 'flags'));
  (q.setsFlags || []).forEach(fl => ref(`${q.id}.setsFlags`, fl, 'flags'));
  ((q.rewards || {}).items || []).forEach(i => ref(`${q.id}.rewards.items`, i, 'items'));
  (q.objectives || []).forEach((o, i) => {
    const where = `${q.id}.objectives[${i}]`;
    if (o.kind === 'kill' || o.kind === 'tame') ref(where, o.target, 'species');
    else if (o.kind === 'talk') ref(where, o.target, 'npcs');
    else if (o.kind === 'collect' && String(o.target).startsWith('itm_')) ref(where, o.target, 'items');
    if (o.from) ref(where + '.from', o.from, 'species');
  });
}

const ITEMS_BY_ID = Object.fromEntries(rows.items.map(i => [i.id, i]));

// Guild ranks (World/guild_ranks.json): trials are real quests, gifts real items, promotions a chain F → SSS.
if (fs.existsSync(path.join(DATA, 'World/guild_ranks.json'))) {
  const gr = load('World/guild_ranks.json');
  (gr.promotions || []).forEach((p, i) => {
    const where = `guild_ranks.promotions[${i}]`;
    if (p.trialQuestId) ref(where + '.trialQuestId', p.trialQuestId, 'quests');
    if (p.gift) ref(where + '.gift', p.gift, 'items');
    if (i > 0 && gr.promotions[i - 1].to !== p.from) err(where, `chain broken: ${gr.promotions[i - 1].to} then ${p.from}`);
    if (i > 0 && !(p.gp > gr.promotions[i - 1].gp && p.level > gr.promotions[i - 1].level)) err(where, 'GP and level should rise each rank');
  });
}

// Gathering nodes (World/gathering.json): real items, sane chances and counts.
if (fs.existsSync(path.join(DATA, 'World/gathering.json'))) {
  for (const n of load('World/gathering.json').nodes || []) {
    if (!/^node_[a-z0-9_]+$/.test(n.id || '')) err(n.id, 'node id must look like node_*');
    if (!(n.respawnHours > 0)) err(n.id, 'respawnHours must be > 0');
    for (const y of n.yields || []) {
      ref(n.id + '.yields', y.itemId, 'items');
      if (!(y.chance > 0 && y.chance <= 1) || !(y.min >= 1 && y.max >= y.min)) err(n.id, `bad yield for ${y.itemId}`);
    }
  }
}

// Boss phases (Monsters/boss_phases.json): real species, thresholds descending from 1.0, real summons.
if (fs.existsSync(path.join(DATA, 'Monsters/boss_phases.json'))) {
  for (const b of load('Monsters/boss_phases.json').bosses || []) {
    ref('boss_phases', b.speciesId, 'species');
    const at = (b.phases || []).map(p => p.atHpFraction);
    if (at[0] !== 1) err(b.speciesId, 'the first phase starts at atHpFraction 1.0');
    if (at.some((v, i) => i > 0 && !(v < at[i - 1] && v > 0))) err(b.speciesId, 'phase thresholds must fall from 1.0 toward 0');
    for (const p of b.phases || []) for (const s of p.summon || []) ref(b.speciesId + '.summon', s.speciesId, 'species');
  }
}

// Recipes (Items/recipes.json): known items and stations, and a result never ranked above its best material (systems.md §5.1).
const RANK_ORDER = ['F', 'E', 'D', 'C', 'B', 'A', 'S', 'SS', 'SSS', 'EX'];
const rankValue = r => { const m = /^([A-Z]+)([+-]?)$/.exec(r || ''); return m ? RANK_ORDER.indexOf(m[1]) * 3 + (m[2] === '+' ? 1 : m[2] === '-' ? -1 : 0) : -99; };
let recipeCount = 0;
if (fs.existsSync(path.join(DATA, 'Items/recipes.json'))) {
  const rf = load('Items/recipes.json');
  for (const [station, npc] of Object.entries(rf.stations || {})) if (npc) ref('recipes.stations.' + station, npc, 'npcs');
  const seen = new Set();
  for (const r of rf.recipes || []) {
    recipeCount++;
    if (!/^rcp_[a-z0-9_]+$/.test(r.id || '')) err(r.id, 'recipe id must look like rcp_*');
    if (seen.has(r.id)) err(r.id, 'duplicate recipe id'); seen.add(r.id);
    if (!(r.station in (rf.stations || {}))) err(r.id, `unknown station "${r.station}"`);
    ref(r.id + '.output', r.output && r.output.itemId, 'items');
    if (!r.inputs || r.inputs.length === 0) err(r.id, 'needs inputs');
    for (const i of r.inputs || []) { ref(r.id + '.inputs', i.itemId, 'items'); if (!(i.count >= 1)) err(r.id, 'input count must be ≥ 1'); }
    if (r.learnFrom) ref(r.id + '.learnFrom', r.learnFrom.npcId, 'npcs');
    const out = ITEMS_BY_ID[r.output && r.output.itemId];
    const best = Math.max(...(r.inputs || []).map(i => rankValue((ITEMS_BY_ID[i.itemId] || {}).rank)));
    if (out && rankValue(out.rank) > best) err(r.id, `result rank ${out.rank} is above its best material`);
  }
}
// Gear: weapons name a weapon type some class can wield; armour names its weight (equipment rules in Code/Ascend.Core/Equipment.cs).
const CLASS_WEAPONS = new Set(rows.classes.flatMap(c => c.weapons || []));
for (const it of rows.items) {
  if (it.category === 'weapon' && !CLASS_WEAPONS.has(it.weaponType)) err(it.id, `weaponType "${it.weaponType}" isn't in any class's weapons`);
  if (it.category === 'armor' && !it.armorWeight) err(it.id, 'armor needs an armorWeight');
}
for (const c of rows.classes) if (c.starterWeaponId) ref(c.id + '.starterWeaponId', c.starterWeaponId, 'items');
for (const sh of rows.shops) {
  ref(sh.id, sh.npcId, 'npcs');
  for (const o of sh.stock || []) {
    ref(sh.id + '.stock', o.itemId, 'items');
    const it = ITEMS_BY_ID[o.itemId];
    if (it && it.category === 'key') err(sh.id, `key item ${o.itemId} can't be sold`);
    // Anti-arbitrage (monster_core_pricing.md §7): retail is never below what any shop pays for the same item.
    for (const other of rows.shops) {
      const pays = it && other.buys.categories.includes(it.category) ? Math.floor(it.value * other.buys.rate) : 0;
      if (pays > o.price) err(sh.id, `${o.itemId} sells for ${o.price} but ${other.id} buys it for ${pays}`);
    }
  }
}
for (const i of rows.inns) {
  ref(`${i.id}.regionId`, i.regionId, 'regions'); ref(`${i.id}.keeperNpcId`, i.keeperNpcId, 'npcs', true);
  if (i.rooms.filter(r => r.tier === 'signature').length > 1) err(i.id, 'at most one signature room');
  for (const r of i.rooms) if (!/^(Well Rested|Rested)\s*\(\d+(\.\d+)?h\)/.test(r.rest)) err(i.id, `room rest "${r.rest}" must look like "Rested (2h)" or "Well Rested (4h) + meal" (read by Ascend.Core InnStay)`);
}

// Story flags: quest-set flags must actually be set by some quest
const setByQuests = new Set(rows.quests.flatMap(q => q.setsFlags || []));
for (const fl of rows.flags) if (fl.setBy === 'quest' && !setByQuests.has(fl.id)) err(fl.id, 'flag marked setBy "quest" but no quest sets it');
for (const n of rows.npcs) (n.states || []).forEach(st => ref(`${n.id}.states`, st.flag, 'flags'));
// Classes: starter weapon exists, skill IDs unique across classes, exactly one ultimate
const skillIds = new Set();
for (const c of rows.classes) {
  ref(`${c.id}.starterWeaponId`, c.starterWeaponId, 'items', true);
  for (const k of c.kit) {
    if (skillIds.has(k.id)) err(c.id, `duplicate skill id ${k.id}`); skillIds.add(k.id);
    if (!k.hits.length && !['buff', 'utility', 'ultimate'].includes(k.kind)) err(k.id, `kind "${k.kind}" needs at least one hit`);
  }
  for (const p of c.passives || []) { if (skillIds.has(p.id)) err(c.id, `duplicate passive id ${p.id}`); skillIds.add(p.id); }
  if (c.kit.filter(k => k.slot === 'ultimate').length !== 1) err(c.id, 'needs exactly one ultimate');
  if (c.kit.filter(k => k.slot === 'basic').length !== 1) err(c.id, 'needs exactly one basic attack string');
  const alloc = Object.values(c.recommendedAllocation).reduce((a, b) => a + b, 0);
  if (Math.abs(alloc - 1) > 0.001) err(c.id, `recommendedAllocation sums to ${alloc}, not 1`);
}

const speciesById0 = Object.fromEntries(rows.species.map(x => [x.id, x]));

// Spells (Spells/spells.json, proposed): ranks follow the Canon bands and tiers, Forbidden is SS, the classes are real, and
// every monster only casts spells at or below its own rank (Spells/monster_spells.json).
const SPELL_BAND = { F: 1, E: 16, D: 36, C: 61, B: 91, A: 126, S: 166, SS: 211, SSS: 261 };
const SPELL_TIER = { F: 'Basic', E: 'Basic', D: 'Intermediate', C: 'Intermediate', B: 'Advanced', A: 'Advanced', S: 'Grand', SS: 'Forbidden', SSS: 'Divine' };
const SPELL_CHANT = { Basic: 0.5, Intermediate: 1.5, Advanced: 3, Grand: 5, Forbidden: 8, Divine: null };
const spellById = Object.fromEntries(rows.spells.map(sp => [sp.id, sp]));
for (const sp of rows.spells) {
  for (const c of [...sp.primaryClasses, ...sp.altClasses]) ref(`${sp.id}.classes`, c, 'classes');
  if (sp.minLevel !== SPELL_BAND[sp.rank]) err(sp.id, `minLevel ${sp.minLevel} is not the start of rank ${sp.rank} (${SPELL_BAND[sp.rank]})`);
  if (sp.tier !== SPELL_TIER[sp.rank]) err(sp.id, `tier ${sp.tier} does not match rank ${sp.rank}`);
  if (sp.chantSec !== SPELL_CHANT[sp.tier]) err(sp.id, `chant ${sp.chantSec} does not match tier ${sp.tier}`);
  if ((sp.discipline === 'Forbidden Arts') !== (sp.rank === 'SS')) err(sp.id, 'Forbidden Arts spells are exactly the SS spells');
  if (sp.rank === 'SSS' && sp.discipline !== 'Divine') err(sp.id, 'only Divine spells are SSS');
  if (sp.element === 'Lightning' && sp.subDiscipline !== 'Storm') err(sp.id, 'Lightning spells are the Storm branch');
  if (sp.element === 'Poison' && sp.subDiscipline !== 'Blight') err(sp.id, 'Poison spells are the Blight branch');
}
for (const m of rows.monsterSpells) {
  ref(`${m.id}.speciesId`, m.speciesId, 'species');
  if (m.spellIds.length !== m.telegraphs.length) err(m.id, 'spellIds and telegraphs must be the same length');
  const species = speciesById0[m.speciesId];
  m.spellIds.forEach(sid => {
    ref(`${m.id}.spellIds`, sid, 'spells');
    const sp = spellById[sid];
    if (sp && species) {
      const letter = species.rank.replace(/[+-]$/, '');
      if (letter !== 'EX' && RANK_ORDER.indexOf(sp.rank) > RANK_ORDER.indexOf(letter)) err(m.id, `${sid} is rank ${sp.rank}, above ${species.name} (${species.rank})`);
    }
  });
}


// Spell Loom (proposed): threads, rank table, attunement tree and ascension trees.
const LOOM_RANKS = ['F', 'E', 'D', 'C', 'B', 'A', 'S', 'SS', 'SSS'];
rows.threads.forEach(t => {
  if (t.kind === 'trigger' && t.hold <= 0) err(t.id, 'trigger threads must reserve Hold');
  if (t.kind !== 'trigger' && t.hold !== 0) err(t.id, 'only trigger threads reserve Hold');
  if (t.kind === 'attune' && t.element === 'None') err(t.id, 'attune threads name an element');
  if (t.kind === 'power' && t.name !== 'Frugal' && t.strain < 1) err(t.id, 'only Frugal may have a Strain below 1');
});
const lrows = rows.loomRanks;
if (lrows.map(r => r.rank).join() !== LOOM_RANKS.join()) err('loom_ranks', 'needs exactly one row per rank F to SSS in order');
lrows.forEach((r, i) => {
  if (r.levelMin !== SPELL_BAND[r.rank]) err(r.id, 'levelMin must be the Canon band start');
  if (r.attunePoints !== Math.floor(r.levelMin / 3)) err(r.id, 'attunePoints must be floor(level / 3)');
  if (i > 0 && (r.loomSlots < lrows[i - 1].loomSlots || r.maxThreadSockets < lrows[i - 1].maxThreadSockets || r.hold < lrows[i - 1].hold)) err(r.id, 'slots, sockets and Hold never fall as rank rises');
});
const treeById = Object.fromEntries(rows.attunement.map(n => [n.id, n]));
for (const n of rows.attunement) {
  for (const l of n.links) {
    if (!treeById[l]) err(n.id, `links to unknown node ${l}`);
    else if (!treeById[l].links.includes(n.id)) err(n.id, `link to ${l} is not mutual`);
  }
  if (n.kind === 'keystone' && !n.downside) err(n.id, 'a keystone needs a stated downside');
  if (n.kind !== 'keystone' && n.downside) err(n.id, 'only keystones have a downside');
}
{
  const seen = new Set(['att_hub']); const q = ['att_hub'];
  while (q.length) { const c = q.pop(); for (const l of treeById[c] ? treeById[c].links : []) if (!seen.has(l)) { seen.add(l); q.push(l); } }
  if (!treeById.att_hub) err('attunement', 'needs att_hub');
  for (const n of rows.attunement) if (!seen.has(n.id)) err(n.id, 'not connected to the hub');
  const clusters = {};
  for (const n of rows.attunement.filter(n => n.kind !== 'hub' && n.kind !== 'start' && n.kind !== 'bridge')) { (clusters[n.cluster] = clusters[n.cluster] || []).push(n.kind); }
  for (const [c, ks] of Object.entries(clusters)) if (ks.filter(k => k === 'keystone').length !== 1 || ks.filter(k => k === 'notable').length !== 3) err('attunement', `cluster ${c} needs 1 keystone and 3 notables`);
  if (rows.attunement.filter(n => n.kind === 'start').length !== rows.classes.length) err('attunement', 'needs one start node per base class');
  for (const n of rows.attunement.filter(n => n.kind === 'start')) ref(`${n.id}.classKey`, 'cls_' + n.classKey, 'classes');
}
{
  const byClass = {};
  for (const a of rows.ascension) {
    ref(`${a.id}.baseClass`, a.baseClass, 'classes');
    (byClass[a.advancedClass] = byClass[a.advancedClass] || []).push(a);
    if (a.requires && !rows.ascension.some(x => x.id === a.requires)) err(a.id, `requires unknown node ${a.requires}`);
    if (a.kind === 'keystone' && !a.downside) err(a.id, 'a keystone needs a stated downside');
  }
  for (const [c, nodes] of Object.entries(byClass)) {
    const k = kind => nodes.filter(n => n.kind === kind).length;
    if (k('gate') !== 1 || k('notable') !== 3 || k('keystone') !== 1) err('ascension', `${c} needs 1 gate, 3 notables and 1 keystone`);
  }
}

// Regional Siege & Liberation: every region has a unique Tyrant living there, or is marked noSiege.
const speciesById = Object.fromEntries(rows.species.map(s => [s.id, s]));
const famKeys = new Set(rows.species.map(s => s.familyKey));
for (const r of rows.regions) {
  if (r.noSiege) { if (r.tyrantSpeciesId) err(r.id, 'noSiege region must not have a Tyrant'); continue; }
  if (!r.tyrantSpeciesId) { err(r.id, 'needs a tyrantSpeciesId or noSiege: true'); continue; }
  const t = speciesById[r.tyrantSpeciesId];
  if (!t) { err(r.id, `Tyrant "${r.tyrantSpeciesId}" does not exist`); continue; }
  if (!t.isUnique) err(r.id, `Tyrant ${t.id} must be a unique species`);
  if (!t.habitats.includes(r.id)) err(r.id, `Tyrant ${t.id} must live in the region`);
  if (!famKeys.has(r.siegeFaction)) err(r.id, `unknown siegeFaction "${r.siegeFaction}"`);
  if (!(r.defenceSettlements || []).length) err(r.id, 'needs defenceSettlements');
  if (!rows.siege.some(w => w.regionId === r.id)) err(r.id, 'besieged region has no siege wave set');
}
// World map: every place outside the post-game has a map position; defended towns are on the map; surface lands
// sit inside the 150 x 100 map and their anchor is not under another land's centre.
for (const r of rows.regions) {
  if (r.layer === 'post-game') { if (r.map) err(r.id, 'post-game regions are not on the world map'); continue; }
  if (!r.map) { err(r.id, 'needs a map position'); continue; }
  const [x, y] = r.map.at;
  if (x > 150 || y > 100) err(r.id, `map.at ${x},${y} is outside the 150 x 100 map`);
  if (r.layer === 'surface' && !r.map.floating) {
    if (!(r.map.radius > 0)) err(r.id, 'a surface land needs map.radius');
    if (!(r.map.terrain || []).length) err(r.id, 'a surface land needs map.terrain');
    for (const s of r.defenceSettlements || []) if (!(r.map.places || {})[s]) err(r.id, `defended town "${s}" has no map.places position`);
  }
  if (r.layer === 'underworld' && !r.map.gate) err(r.id, 'underworld regions mark their surface gate (map.gate)');
}
const lands = rows.regions.filter(r => r.layer === 'surface' && r.map && r.map.radius > 0);
for (const a of lands) for (const b of lands) if (a !== b && Math.hypot(a.map.at[0] - b.map.at[0], a.map.at[1] - b.map.at[1]) < 4) err(a.id, `map anchor too close to ${b.id}`);
for (const w of rows.siege) {
  const reg = rows.regions.find(r => r.id === w.regionId);
  if (!reg) { err(w.id, `unknown region ${w.regionId}`); continue; }
  if (reg.noSiege) err(w.id, 'wave set for a noSiege region');
  if (w.tyrantSpeciesId !== reg.tyrantSpeciesId) err(w.id, 'tyrant does not match the region');
  for (const wave of w.waves) for (const id of [...wave.units.map(u => u.speciesId), wave.lieutenantSpeciesId].filter(Boolean)) {
    const sp = speciesById[id];
    if (!sp) err(w.id, `unknown species ${id}`);
    else if (!sp.habitats.includes(w.regionId)) err(w.id, `${id} does not live in ${w.regionId}`);
  }
}
for (const q of rows.quests) {
  if (q.type === 'SiegeDefence' && q.regionState !== 'besieged') err(q.id, 'SiegeDefence quests must have regionState "besieged"');
}

// Weekly board: every weekday needs a special and at least 3 dailies (board shows 3 per day)
const WEEKDAYS = ['Solenday', 'Maelsday', 'Thorsday', 'Sylvasday', 'Kaelsday', 'Morrowsday', 'Vexday'];
for (const d of WEEKDAYS) {
  const wk = rows.weekly.filter(q => q.day === d);
  if (wk.filter(q => q.slot === 'special').length !== 1) err(`weekly ${d}`, 'needs exactly one day special');
  if (wk.filter(q => q.slot === 'daily').length < 3) err(`weekly ${d}`, 'needs at least 3 dailies');
}

// 3) Report
const counts = Object.entries(rows).map(([n, l]) => `${n} ${l.length}`).concat([`recipes ${recipeCount}`]).join(' · ');
if (errors.length) {
  console.error(`✗ ${errors.length} problem(s)\n` + errors.map(e => '  - ' + e).join('\n'));
  process.exit(1);
}
console.log(`✓ Data valid. ${counts}`);
