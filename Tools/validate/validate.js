// AETHWYRD data validator. Dependency-free (plain Node).
// Usage: node Tools/validate/validate.js        → exit code 1 if anything is wrong
// Checks: 1) every row against its JSON Schema (subset: type, required, properties,
// additionalProperties:false, enum, pattern, minimum/maximum/exclusiveMinimum, minLength, minItems/maxItems, items)
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
  companions: { files: ['Companions/companions.json'], schema: 'companion' },
  banter: { files: ['Companions/banter.json'], schema: 'banter' }
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
    if (s.maxLength != null && v.length > s.maxLength) err(where, `longer than ${s.maxLength}`);
  }
  if (typeof v === 'number') {
    if (s.minimum != null && v < s.minimum) err(where, `${v} < minimum ${s.minimum}`);
    if (s.exclusiveMinimum != null && v <= s.exclusiveMinimum) err(where, `${v} must be greater than ${s.exclusiveMinimum}`);
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
// Companion roster (Wave C): exactly the 14 canonical ids, Canon romance flags, Nyx/Mochi never romanceable or rideable
{
  const CANON_IDS = ['cmp_lyra', 'cmp_seraphine', 'cmp_kiri', 'cmp_aldric', 'cmp_nyx', 'cmp_bram', 'cmp_kaito', 'cmp_mochi', 'cmp_elira', 'cmp_vexmor', 'cmp_torvald', 'cmp_suzune', 'cmp_tobin', 'cmp_elsie'];
  const NOT_ROMANCEABLE = ['cmp_nyx', 'cmp_mochi'];
  const got = rows.companions.map(c => c.id);
  if (new Set(got).size !== got.length) err('companions', 'duplicate id');
  for (const id of CANON_IDS) if (!got.includes(id)) err('companions', `missing canonical companion ${id}`);
  for (const id of got) if (!CANON_IDS.includes(id)) err(id, 'not one of the 14 canonical companions');
  for (const c of rows.companions) {
    if (c.npcId) ref(`${c.id}.npcId`, c.npcId, 'npcs');
    if (c.romanceable === NOT_ROMANCEABLE.includes(c.id)) err(c.id, `romanceable must be ${!NOT_ROMANCEABLE.includes(c.id)} (Canon section 4)`);
    if (c.romanceable && !c.adult) err(c.id, 'a romanceable companion must be an adult');
    if (c.rideable) err(c.id, 'companions are never rideable');
    if (c.roleTags.indexOf(c.preferredRole) < 0) err(c.id, 'preferredRole must be one of roleTags');
    if (new Set(c.personalityTags).size !== c.personalityTags.length) err(c.id, 'duplicate personalityTags');
    if (new Set(c.equipmentSlots).size !== c.equipmentSlots.length) err(c.id, 'duplicate equipmentSlots');
    if (!c.stub && (c.personalityTags.length < 3 || c.personalityTags.length > 4)) err(c.id, 'needs 3-4 personalityTags (stubs may have none)');
    if (NOT_ROMANCEABLE.includes(c.id) && c.equipmentSlots.length >= 4) err(c.id, 'Nyx and Mochi get a reduced equipment set');
    if (c.kind === 'childhoodFriend' !== (c.id === 'cmp_tobin' || c.id === 'cmp_elsie')) err(c.id, 'kind childhoodFriend is for Tobin and Elsie only');
    if ((c.id === 'cmp_tobin' || c.id === 'cmp_elsie') && !c.stub) err(c.id, 'Tobin and Elsie are stubs until narrative writes them');
    if (c.redeemableArc && c.id !== 'cmp_kaito') err(c.id, 'only Kaito has a redeemable arc (companion row)');
  }
  const kaito = rows.companions.find(c => c.id === 'cmp_kaito');
  if (kaito && !kaito.redeemableArc) err('cmp_kaito', 'redeemableArc must be true');
  for (const b of rows.banter) ref(`${b.id}.companionId`, b.companionId, 'companions');
}
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

// Reaction table (Combat/reactions.json): schema, known Reaction ids, one row per unordered element pair, synergies point at
// real reactions, and Freeze / Storm Prison status seconds equal combat_tuning.json "reactions" (the tuning file stays the source).
const tuningPath = path.join(DATA, 'Combat/combat_tuning.json');
const tuning = fs.existsSync(tuningPath) ? load('Combat/combat_tuning.json') : {};
if (fs.existsSync(path.join(DATA, 'Combat/reactions.json'))) {
  const rf = load('Combat/reactions.json');
  check(rf, schema('reactions'), 'reactions.json');
  const rids = new Set(), pairs = new Map(), sids = new Set();
  for (const r of rf.reactions || []) {
    if (rids.has(r.id)) err('reactions.json#' + r.id, 'duplicate reaction id'); rids.add(r.id);
    const key = (r.elements || []).slice().sort().join('+');
    if ((r.elements || []).length === 2 && r.elements[0] === r.elements[1]) err('reactions.json#' + r.id, 'elements must be two different elements');
    // Swirl is the catch-all (Wind meeting any element without its own row), so its listed pair is only a representative; it must still contain Wind.
    // consumesAura false is the Swirl rule only (it keeps the aura); every other reaction consumes it.
    if (r.id !== 'Swirl' && r.consumesAura !== true) err('reactions.json#' + r.id, 'consumesAura must be true for every reaction except Swirl');
    if (r.id === 'Swirl') { if (!(r.elements || []).includes('Wind')) err('reactions.json#Swirl', 'Swirl elements must include Wind'); }
    else {
    if (pairs.has(key)) err('reactions.json#' + r.id, `element pair ${key} already used by ${pairs.get(key)} (order does not matter)`); pairs.set(key, r.id);
    }
    const t = tuning.reactions || {};
    if (r.id === 'Freeze' && (!r.status || r.status.kind !== 'freeze' || r.status.durationSec !== t.freezeDurationSec)) err('reactions.json#Freeze', `status must be freeze for ${t.freezeDurationSec}s (combat_tuning.json reactions.freezeDurationSec)`);
    if (r.id === 'StormPrison' && (!r.status || r.status.kind !== 'stun' || r.status.durationSec !== t.stormPrisonStunSec)) err('reactions.json#StormPrison', `status must be stun for ${t.stormPrisonStunSec}s (combat_tuning.json reactions.stormPrisonStunSec)`);
  }
  for (const sy of rf.synergies || []) {
    if (sids.has(sy.id)) err('reactions.json#' + sy.id, 'duplicate synergy id'); sids.add(sy.id);
    for (const k of ['first', 'then']) if (!rids.has(sy[k])) err('reactions.json#' + sy.id, `${k} "${sy[k]}" is not a reaction in "reactions"`);
  }
}

// Boss weak points (Monsters/boss_weakpoints.json): real species, one record per boss, weak-point ids unique per boss,
// and exposedInPhases name phases that boss really has in boss_phases.json (when the boss has phases).
if (fs.existsSync(path.join(DATA, 'Monsters/boss_weakpoints.json'))) {
  const wf = load('Monsters/boss_weakpoints.json');
  check(wf, schema('boss_weakpoints'), 'boss_weakpoints.json');
  const phasesOf = {};
  if (fs.existsSync(path.join(DATA, 'Monsters/boss_phases.json'))) for (const b of load('Monsters/boss_phases.json').bosses || []) phasesOf[b.speciesId] = new Set((b.phases || []).map(p => p.name));
  const seenBoss = new Set();
  const abw = wf.armorDamageByWeight;
  if (abw) {
    if (!(abw.light <= abw.medium && abw.medium <= abw.heavy && abw.heavy <= abw.ultimate)) err('boss_weakpoints.json armorDamageByWeight', 'armor damage must not shrink as the weight grows (light <= medium <= heavy <= ultimate)');
  }
  for (const b of wf.bosses || []) {
    ref('boss_weakpoints', b.speciesId, 'species');
    // Armor must be breakable: no more than 20 heavy hits (a guard against an unbreakable bar).
    if (b.armor && abw && b.armor.maxArmor > 0 && b.armor.maxArmor / abw.heavy > 20) err(b.speciesId, `armor.maxArmor ${b.armor.maxArmor} needs ${Math.ceil(b.armor.maxArmor / abw.heavy)} heavy hits to break (more than 20): effectively unbreakable`);
    if (seenBoss.has(b.speciesId)) err(b.speciesId, 'two boss_weakpoints records for one species'); seenBoss.add(b.speciesId);
    const wids = new Set();
    for (const w of b.weakPoints || []) {
      if (wids.has(w.id)) err(b.speciesId, `duplicate weak point id "${w.id}"`); wids.add(w.id);
      if (phasesOf[b.speciesId]) for (const ph of w.exposedInPhases || []) if (!phasesOf[b.speciesId].has(ph)) err(`${b.speciesId}.${w.id}`, `exposedInPhases "${ph}" is not a phase in boss_phases.json (${[...phasesOf[b.speciesId]].join(', ')})`);
    }
  }
}

// Group tactics numbers (combat_tuning.json "groupTactics", optional): numbers never negative; keys ending Fraction / Pct are
// 0..1; keys naming slots are whole numbers 1..6.
if (tuning.groupTactics) {
  (function walk(o, p) {
    for (const [k, v] of Object.entries(o)) {
      const w = `combat_tuning.json groupTactics${p}.${k}`;
      if (v && typeof v === 'object' && !Array.isArray(v)) { walk(v, p + '.' + k); continue; }
      if (typeof v !== 'number') continue;
      if (v < 0) err(w, `${v} is negative`);
      if (/(fraction|pct)$/i.test(k) && v > 1) err(w, `${v} is a fraction and must be between 0 and 1`);
      if (/slot(s|count)$/i.test(k) && !(Number.isInteger(v) && v >= 1 && v <= 6)) err(w, `${v}: slot counts are whole numbers from 1 to 6`);
      if (/^(pressOnPlayerHp|pressOnRetreatScale|healthyPlayerHp|outnumberedRetreatBonus|hpMargin)$/.test(k) && v > 1) err(w, `${v} must be between 0 and 1`);
      if (k === 'arcDeg' && v > 360) err(w, `${v} degrees is more than a full circle`);
    }
  })(tuning.groupTactics, '');
  const gr = tuning.groupTactics.retreat || {};
  if (typeof gr.pressOnPlayerHp === 'number' && typeof gr.healthyPlayerHp === 'number' && gr.pressOnPlayerHp >= gr.healthyPlayerHp) err('combat_tuning.json groupTactics.retreat', 'pressOnPlayerHp must be below healthyPlayerHp');
  if (tuning.groupTactics.enabled !== undefined && typeof tuning.groupTactics.enabled !== 'boolean') err('combat_tuning.json groupTactics.enabled', 'must be true or false');
}
// Sandbox defaults (combat_tuning.json "sandbox", optional).
if (tuning.sandbox) {
  for (const k of ['defaultSeed', 'maxDummies', 'defaultDummyHp']) {
    const v = tuning.sandbox[k];
    if (v !== undefined && !(Number.isInteger(v) && v >= 1)) err('combat_tuning.json sandbox.' + k, `${v} must be a whole number of at least 1`);
  }
}

// Recipes (Items/recipes.json): known items and stations, and a result never ranked above its best material (systems.md §5.1).
const RANK_ORDER = ['F', 'E', 'D', 'C', 'B', 'A', 'S', 'SS', 'SSS', 'EX'];
const rankValue = r => { const m = /^([A-Z]+)([+-]?)$/.exec(r || ''); return m ? RANK_ORDER.indexOf(m[1]) * 3 + (m[2] === '+' ? 1 : m[2] === '-' ? -1 : 0) : -99; };
let recipeCount = 0;
if (fs.existsSync(path.join(DATA, 'Items/recipes.json'))) {
  const rf = load('Items/recipes.json');
  const rulesFile = fs.existsSync(path.join(DATA, 'Items/crafting_rules.json')) ? load('Items/crafting_rules.json') : null;
  const skillsFile = fs.existsSync(path.join(DATA, 'Items/life_skills.json')) ? load('Items/life_skills.json') : null;
  const skillById = Object.fromEntries(((skillsFile || {}).skills || []).map(s => [s.id, s]));
  const recipeSchema = schema('recipe');
  for (const [station, npc] of Object.entries(rf.stations || {})) if (npc) ref('recipes.stations.' + station, npc, 'npcs');
  const seen = new Set();
  for (const r of rf.recipes || []) {
    recipeCount++;
    if (!/^rcp_[a-z0-9_]+$/.test(r.id || '')) err(r.id, 'recipe id must look like rcp_*');
    if (seen.has(r.id)) err(r.id, 'duplicate recipe id'); seen.add(r.id);
    check(r, recipeSchema, `recipes.json#${r.id}`);
    if (r.lifeRank && skillsFile && !skillsFile.ranks.includes(r.lifeRank)) err(r.id, `lifeRank "${r.lifeRank}" is not a life-skill rank`);
    if (skillsFile) {
      const sk = skillById[r.skill];
      if (!sk) err(r.id, `skill "${r.skill}" is not in life_skills.json`);
      else if (sk.kind !== 'craft') err(r.id, `skill "${r.skill}" is ${sk.kind}, only craft skills have recipes`);
    }
    if (r.attuneItem) ref(r.id + '.attuneItem', r.attuneItem, 'items');
    if (r.xp != null && !(r.xp >= 1)) err(r.id, 'xp must be >= 1');
    if (rulesFile && !(r.station in (rulesFile.stationQualityCap || {}))) err(r.id, `station "${r.station}" has no stationQualityCap in crafting_rules.json`);
    if (!(r.station in (rf.stations || {}))) err(r.id, `unknown station "${r.station}"`);
    ref(r.id + '.output', r.output && r.output.itemId, 'items');
    if (!r.inputs || r.inputs.length === 0) err(r.id, 'needs inputs');
    if (new Set((r.inputs || []).map(i => i.itemId)).size !== (r.inputs || []).length) err(r.id, 'duplicate itemId in inputs (merge the counts)');
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

// 4) Physical map (Tools/validate/map_checks.js): errors fail the build, warnings are listed only
const mapChecks = require('./map_checks').run(DATA);
for (const e of mapChecks.errors) errors.push(e);

// 5) Singleton data files (a single JSON object, not an array of rows). Wave A1: Player/locomotion.json
const SINGLETONS = {
  locomotion: { file: 'Player/locomotion.json', schema: 'locomotion' },
  crafting_rules: { file: 'Items/crafting_rules.json', schema: 'crafting_rules' },
  life_skills: { file: 'Items/life_skills.json', schema: 'life_skills' },
  companion_rules: { file: 'Companions/companion_rules.json', schema: 'companion_rules' },
  mounts: { file: 'Companions/mounts.json', schema: 'mounts' },
  gear_rules: { file: 'Items/gear_rules.json', schema: 'gear_rules' },
  housing: { file: 'World/housing.json', schema: 'housing' },
  crops: { file: 'Items/crops.json', schema: 'crops' },
  stables: { file: 'Companions/stables.json', schema: 'stables' }
};
for (const [name, c] of Object.entries(SINGLETONS)) {
  if (!fs.existsSync(path.join(DATA, c.file))) { err(c.file, 'file missing'); continue; }
  const obj = load(c.file);
  check(obj, schema(c.schema), c.file);
  if (name === 'crafting_rules' && obj.qualityTiers) {
    const tiers = obj.qualityTiers;
    const ids = tiers.map(t => t.id);
    if (new Set(ids).size !== ids.length) err(c.file, 'duplicate quality tier id');
    tiers.forEach((t, i) => { if (t.index !== i) err(c.file, `qualityTiers[${i}] (${t.id}) must have index ${i}: tiers are contiguous from 0`); });
    for (let i = 1; i < tiers.length; i++) {
      if (!(tiers[i].statMult >= tiers[i - 1].statMult)) err(c.file, `statMult must not fall from ${tiers[i - 1].id} to ${tiers[i].id}`);
      if (!(tiers[i].valueMult >= tiers[i - 1].valueMult)) err(c.file, `valueMult must not fall from ${tiers[i - 1].id} to ${tiers[i].id}`);
    }
    const normal = tiers.find(t => t.id === 'normal');
    if (!normal) err(c.file, 'needs a "normal" tier');
    else if (normal.statMult !== 1 || normal.valueMult !== 1 || normal.buffMult !== 1) err(c.file, 'normal tier multipliers must all be 1');
    for (const [k, m] of [['rankQualityCap', obj.rankQualityCap], ['stationQualityCap', obj.stationQualityCap]])
      for (const [key, tid] of Object.entries(m || {})) {
        if (!ids.includes(tid)) err(c.file, `${k}.${key}: unknown tier "${tid}"`);
        else if (!tiers.find(t => t.id === tid).craftable) err(c.file, `${k}.${key}: "${tid}" is not craftable`);
      }
    const caps = ['F', 'E', 'D', 'C', 'B', 'A', 'S', 'SS', 'SSS'].map(r => ids.indexOf((obj.rankQualityCap || {})[r]));
    for (let i = 1; i < caps.length; i++) if (caps[i] < caps[i - 1]) err(c.file, 'rankQualityCap must not fall as rank rises');
  }
  if (name === 'life_skills' && obj.skills) {
    const sids = obj.skills.map(s => s.id);
    if (new Set(sids).size !== sids.length) err(c.file, 'duplicate skill id');
    const ranks = obj.ranks || [];
    if (new Set(ranks).size !== ranks.length || ranks.join() !== 'F,E,D,C,B,A,S,SS,SSS') err(c.file, 'ranks must be F,E,D,C,B,A,S,SS,SSS once each, in order');
    const xr = (obj.xp || {}).xpToReach || {};
    if (xr.F !== 0) err(c.file, 'xpToReach.F must be 0');
    for (let i = 1; i < ranks.length; i++) if (!(xr[ranks[i]] > xr[ranks[i - 1]])) err(c.file, `xpToReach must rise strictly (${ranks[i - 1]} -> ${ranks[i]})`);
    for (const s of obj.skills) {
      if (s.kind === 'craft' && !s.station) err(s.id, 'a craft skill needs a station');
      if (s.kind !== 'craft' && s.station) err(s.id, `a ${s.kind} skill has no station`);
    }
    if (fs.existsSync(path.join(DATA, 'Items/crafting_rules.json'))) {
      const rl = load('Items/crafting_rules.json');
      for (const s of obj.skills) if (s.station && !(s.station in (rl.stationQualityCap || {}))) err(s.id, `station "${s.station}" has no stationQualityCap`);
    }
  }
  if (name === 'gear_rules' && obj.runes) {
    // Small and additive (09_Equipment/item_and_economy_design.md 5.4): per-source caps keep fittings from becoming mandatory.
    const CAP = { atk: 6, matk: 6, def: 6, mdef: 6, hp: 40, crit: 0.03 };
    const rf = load('Items/recipes.json');
    const outputs = new Set(rf.recipes.map(r => r.output.itemId));
    const statCheck = (who, st, mult = 1) => { for (const [k, v] of Object.entries(st)) if (v > CAP[k] * mult) err(who, `stat ${k} ${v} is above the cap ${CAP[k] * mult}`); };
    const runeIds = obj.runes.map(r => r.id);
    if (new Set(runeIds).size !== runeIds.length) err(c.file, 'duplicate rune');
    for (const r of obj.runes) {
      const it = ITEMS_BY_ID[r.id];
      if (!it) err(r.id, 'rune item does not exist'); else if (it.category !== 'rune') err(r.id, `item category is ${it.category}, expected rune`);
      if (!outputs.has(r.id)) err(r.id, 'no recipe makes this rune');
      statCheck(r.id, r.stats);
    }
    for (const w of obj.runeWords) {
      for (const rid of w.runes) if (!runeIds.includes(rid)) err(w.id, `rune ${rid} is not defined`);
      statCheck(w.id, w.stats, 1.5);
      for (const cat of w.fits) if (!w.runes.every(rid => (obj.runes.find(r => r.id === rid) || { fits: [] }).fits.includes(cat))) err(w.id, `not every rune fits ${cat}`);
    }
    const seqs = obj.runeWords.map(w => w.runes.join());
    if (new Set(seqs).size !== seqs.length) err(c.file, 'two rune words share one rune sequence');
    const encItems = obj.enchantments.map(e => e.itemId);
    if (new Set(encItems).size !== encItems.length) err(c.file, 'two enchantments share a scroll');
    for (const e of obj.enchantments) {
      const it = ITEMS_BY_ID[e.itemId];
      if (!it) err(e.id, 'scroll item does not exist'); else if (it.category !== 'scroll') err(e.id, `item category is ${it.category}, expected scroll`);
      if (!outputs.has(e.itemId)) err(e.id, 'no recipe makes this scroll');
      statCheck(e.id, e.stats, 1.5);
      if (e.element && !e.fits.every(f => f === 'weapon')) err(e.id, 'only weapon enchantments apply an element');
    }
    for (const a of obj.assemblies) {
      const out = ITEMS_BY_ID[a.output];
      if (!out || out.category !== 'weapon') err(a.id, 'output must be a weapon item');
      for (const p of [...a.blades, ...a.hilts]) { const it = ITEMS_BY_ID[p]; if (!it || it.category !== 'part') err(a.id, `${p} is not a part item`); else if (!outputs.has(p)) err(a.id, `no recipe makes ${p}`); }
    }
    for (const [k, st] of Object.entries(obj.stations)) if (!(st in rf.stations)) err(c.file, `stations.${k}: "${st}" is not a recipe station`);
    if (/durab|repair|decay|break|destroy|fail/i.test((JSON.stringify(obj).match(/"[^"]+":/g) || []).join(' '))) err(c.file, 'no durability, repair or failure keys (Canon Slow-Life)');
  }
  if (name === 'housing' && obj.tiers) {
    const T = obj.tiers, ranks = ['F', 'E', 'D', 'C', 'B', 'A', 'S', 'SS', 'SSS'];
    if (new Set(T.map(t => t.id)).size !== T.length) err(c.file, 'duplicate tier id');
    if (T[0].cost !== 0 || T[0].plots !== 0) err(c.file, 'the first tier is free and has no plots (it is the inn room everyone starts in)');
    for (let i = 1; i < T.length; i++) {
      if (ranks.indexOf(T[i].rank) < ranks.indexOf(T[i - 1].rank)) err(T[i].id, 'rank must not fall');
      if (!(T[i].cost > T[i - 1].cost)) err(T[i].id, 'cost must rise');
      if (T[i].storageStacks < T[i - 1].storageStacks || T[i].plots < T[i - 1].plots) err(T[i].id, 'storage and plots must not fall (an upgrade never takes anything away)');
      for (const f of T[i - 1].features) if (!T[i].features.includes(f)) err(T[i].id, `feature "${f}" is lost on upgrade`);
    }
    if (/upkeep|rent|decay|wither|spoil|rot|tax|chore|guild/i.test((JSON.stringify(obj).match(/"[^"]+":/g) || []).join(' ') + T.map(t => t.features.join(' ')).join(' '))) err(c.file, 'no upkeep, decay or guild ownership (Canon Slow-Life; the player cannot own a guild)');
    const crops = load('Items/crops.json');
    for (const seed of Object.keys(obj.starterSeeds)) if (!crops.crops.some(cr => cr.seedItem === seed)) err(c.file, `starter seed ${seed} belongs to no crop`);
  }
  if (name === 'crops' && obj.crops) {
    const rf = load('Items/recipes.json');
    const used = new Set(rf.recipes.filter(r => ['cooking', 'brewing', 'alchemy'].includes(r.skill)).flatMap(r => r.inputs.map(i => i.itemId)));
    const rl = load('Items/crafting_rules.json');
    for (const [rk, tid] of Object.entries(obj.qualityByRank)) { const t = rl.qualityTiers.find(x => x.id === tid); if (!t || !t.craftable) err(c.file, `qualityByRank.${rk}: "${tid}" is not a craftable tier`); }
    const ids = obj.crops.map(x => x.id);
    if (new Set(ids).size !== ids.length) err(c.file, 'duplicate crop id');
    const sk = load('Items/life_skills.json').skills.find(s => s.id === obj.skill);
    if (!sk || sk.kind !== 'gather') err(c.file, `skill "${obj.skill}" must be a gather skill in life_skills.json`);
    const shops = load('Items/shops.json');
    for (const cr of obj.crops) {
      ref(cr.id + '.seedItem', cr.seedItem, 'items'); ref(cr.id + '.yieldItem', cr.yieldItem, 'items');
      if (!used.has(cr.yieldItem)) err(cr.id, `yield ${cr.yieldItem} feeds no cooking, brewing or alchemy recipe`);
      if (!shops.some(s => (s.stock || []).some(x => x.itemId === cr.seedItem))) err(cr.id, `seed ${cr.seedItem} is not sold anywhere`);
    }
    if (/wither|decay|spoil|rot|water|chore/i.test((JSON.stringify(obj).match(/"[^"]+":/g) || []).join(' '))) err(c.file, 'crops never wither, spoil or need watering (Canon Slow-Life)');
  }
  if (name === 'stables' && obj.boardingByTier) {
    const hs = load('World/housing.json');
    const tiers = hs.tiers.map(t => t.id);
    for (const k of Object.keys(obj.boardingByTier)) if (!tiers.includes(k)) err(c.file, `boardingByTier.${k} is not a home tier`);
    for (const t of hs.tiers) if (!(t.id in obj.boardingByTier)) err(c.file, `home tier ${t.id} has no boardingByTier entry`);
    let prev = 0;
    for (const t of hs.tiers) { const n = obj.boardingByTier[t.id] || 0; if (n < prev) err(c.file, `boarding must not fall at ${t.id}`); prev = n; }
    const feat = obj.breeding.requiresFeature;
    const first = hs.tiers.find(t => t.features.includes(feat));
    if (!first) err(c.file, `no home tier has the "${feat}" feature`);
    for (const t of hs.tiers) if (!t.features.includes(feat) && (obj.boardingByTier[t.id] || 0) > 0) err(c.file, `${t.id} boards partners but has no ${feat}`);
    const pop = load('Monsters/population.json');
    const tierNames = new Set(pop.map(p => p.tier));
    for (const m of obj.breeding.heritableMarkings) if (!tierNames.has(m)) err(c.file, `marking "${m}" is not a population tier`);
    const sn = obj.sanctuary;
    if (sn[0].minSpecies !== 0) err(c.file, 'sanctuary must start at 0 species');
    for (let i = 1; i < sn.length; i++) if (!(sn[i].minSpecies > sn[i - 1].minSpecies)) err(c.file, 'sanctuary levels must rise');
    if (!(obj.breeding.crossElementChance < 1 && obj.breeding.crossPityBreedings >= 2)) err(c.file, 'cross-element hatchlings must stay rare (chance below 1, pity at least 2)');
    if (/hunger|starv|sick|disease|escape|runaway|decay|upkeep|flying|aquatic|wyvern|dragon/i.test((JSON.stringify(obj).match(/"[^"]+":/g) || []).join(' '))) err(c.file, 'no hunger, sickness, escape, decay, upkeep or flying/aquatic mounts (Canon Slow-Life)');
  }
  if (name === 'companion_rules' && obj.presets) {
    const b = obj.presets.Balanced;
    if (b) for (const [k, v] of Object.entries(b)) if (k !== 'defaultOrder' && v !== 1) err(c.file, `presets.Balanced.${k} must be 1 (identity)`);
    if (b && b.defaultOrder !== 'Follow') err(c.file, 'presets.Balanced.defaultOrder must be Follow');
    const r = obj.retreat || {};
    if (!(r.lowHpFraction + r.hysteresis < 1)) err(c.file, 'retreat.lowHpFraction + hysteresis must stay below 1');
    if (!(r.recoverHpFraction > r.lowHpFraction)) err(c.file, 'retreat.recoverHpFraction must exceed lowHpFraction');
    const maxRetreat = Math.max(...Object.values(obj.presets).map(p => p.retreatHpMult)) * r.mortalBondsHpMult * r.lowHpFraction;
    if (!(maxRetreat < 1)) err(c.file, 'highest retreat threshold must stay below 1');
  }
  if (name === 'companion_rules' && obj.relationships) {
    const R = obj.relationships;
    for (const [t, d] of Object.entries(R.tracks)) {
      const m = d.stages.map(x => x.min);
      if (m[0] !== 0) err(c.file, `relationships.tracks.${t}: first stage must start at 0`);
      for (let i = 1; i < m.length; i++) if (!(m[i] > m[i - 1])) err(c.file, `relationships.tracks.${t}: stage mins must rise`);
      if (new Set(d.stages.map(x => x.id)).size !== d.stages.length) err(c.file, `relationships.tracks.${t}: duplicate stage id`);
    }
    const has = (t, id) => R.tracks[t].stages.some(x => x.id === id);
    if (!has('closeness', R.romance.minCloseness)) err(c.file, 'relationships.romance.minCloseness is not a closeness stage');
    if (!has('trust', R.romance.minTrust)) err(c.file, 'relationships.romance.minTrust is not a trust stage');
    if (!(R.departure.minTension > R.romance.maxTensionExclusive)) err(c.file, 'departure.minTension must exceed romance.maxTensionExclusive');
    for (const [k, e] of Object.entries(R.events)) {
      for (const [t, v] of Object.entries(e.deltas)) if (Math.abs(v) > R.maxDeltaPerEvent) err(c.file, `event ${k}: ${t} delta ${v} exceeds maxDeltaPerEvent ${R.maxDeltaPerEvent}`);
      if (!e.once && !e.cooldownDays) err(c.file, `event ${k}: needs once or cooldownDays so it cannot be farmed`);
    }
  }
  if (name === 'mounts' && obj.families) {
    const BAD = /flying|aerial|celestial|dragon|griffin|griffon|aquatic|wyvern|pegasus|hippogriff|drake/i;
    const FLY_RIG = /flyer|wyvern|dragon|avian|fish|floating|cephalopod|serpent|naga/i;
    const FLY_TYPE = /^(Dragon|Avian|Aquatic|Spirit|Mythic Beast)$/;
    const loco = load('Player/locomotion.json');
    const species = Object.fromEntries(load('Monsters/species.json').map(s => [s.id, s]));
    for (const [fk, f] of Object.entries(obj.families)) {
      if (BAD.test(fk)) err(c.file, `family "${fk}" is a flying/celestial/dragon/aquatic mount (Canon: no flying mounts; aquatic is an open question)`);
      for (const t of Object.keys(f.terrain)) if (!(t in loco.terrain)) err(c.file, `${fk}: terrain "${t}" is not a locomotion terrain`);
      const st = f.stamina;
      if (!(st.exhaustedBelow < st.recoverTo)) err(c.file, `${fk}: stamina.exhaustedBelow must be below recoverTo (hysteresis)`);
      if (!(st.recoverTo <= st.max)) err(c.file, `${fk}: stamina.recoverTo must not exceed max`);
      if (new Set(f.species).size !== f.species.length) err(c.file, `${fk}: duplicate species`);
      for (const id of f.species) {
        const sp = species[id];
        if (BAD.test(id)) err(c.file, `${fk}: species id ${id} names a flying/celestial/dragon/aquatic creature`);
        if (!sp) { err(c.file, `${fk}: species ${id} does not exist in species.json`); continue; }
        if (FLY_RIG.test(sp.rigId) || FLY_TYPE.test(sp.type)) err(c.file, `${fk}: species ${id} (${sp.type}, ${sp.rigId}) flies, is a dragon/celestial/aquatic or not a ground beast`);
        if (sp.isUnique || sp.isTyrant) err(c.file, `${fk}: species ${id} is a unique/tyrant`);
        if (sp.sizeMeters < 1.2) err(c.file, `${fk}: species ${id} is too small to ride`);
      }
    }
    if (obj.speedMps.value !== 10 || obj.speedMps.placeholder !== false) err(c.file, 'speedMps is settled at 10 m/s (placeholder false, decided 2026-11-07, Canon section 6 Mount speed)');
  }
  if (name === 'locomotion' && obj.state && obj.baseSpeed) {
    // blend thresholds {0, walk, run, sprint} must strictly ascend
    const th = [0, 'walk', 'run', 'sprint'].map(k => (k === 0 ? 0 : obj.baseSpeed * obj.state[k]));
    for (let i = 1; i < th.length; i++) if (!(th[i] > th[i - 1])) err(c.file, `blend thresholds must ascend (got ${th.map(x => +x.toFixed(3)).join(', ')})`);
    // walk/run/sprint mirror Combat/combat_tuning.json movement (read-only); drift fails loudly
    const mv = load('Combat/combat_tuning.json').movement || {};
    for (const [k, m] of [['walk', 'walkSpeed'], ['run', 'runSpeed'], ['sprint', 'sprintSpeed']]) {
      const v = obj.baseSpeed * obj.state[k];
      if (typeof mv[m] !== 'number' || Math.abs(v - mv[m]) > 0.01) err(c.file, `baseSpeed*state.${k} = ${+v.toFixed(3)} but combat_tuning movement.${m} = ${mv[m]} (update the mirror)`);
    }
    // sane blend bands and slope clamps
    if (!(obj.blend.walkEnter < obj.blend.runEnter && obj.blend.runEnter < obj.blend.sprintEnter)) err(c.file, 'blend.walkEnter < runEnter < sprintEnter required');
    if (obj.slope.minMult > 1 || obj.slope.maxMult < 1) err(c.file, 'slope.minMult must be <= 1 and maxMult >= 1');
  }
}

// 4b) Wave E: dungeons and puzzles (Tools/validate/dungeon_checks.js)
require('./dungeon_checks').run({ DATA, load, check, schema, err, items: new Set(rows.items.map(i => i.id)), species: new Map(rows.species.map(s => [s.id, s])), regions: rows.regions });

// 4c) Wave D: audio, accessibility and photo mode (Tools/validate/audio_checks.js)
require('./audio_checks').run({ DATA, load, check, schema, err, companionIds: rows.companions.map(c => c.id), regionTerrain: [...new Set(rows.regions.flatMap(r => (r.map && r.map.terrain) || []))] });

// 4d) Wave F-lite: region graph, Labyrinth floors, Underworld layers (Tools/validate/graph_checks.js). Its findings are counted
// separately from the map warnings above.
const graphChecks = require('./graph_checks').run({ DATA, load, check, schema, err, regions: rows.regions });

// 4e) Upgrade v4 subset: living world (Tools/validate/living_checks.js)
require('./living_checks').run({ DATA, load, check, schema, err, regions: rows.regions, species: new Map(rows.species.map(s => [s.id, s])), items: new Set(rows.items.map(i => i.id)), npcs: rows.npcs });

// 3) Report
const counts = Object.entries(rows).map(([n, l]) => `${n} ${l.length}`).concat([`recipes ${recipeCount}`]).join(' · ');
if (errors.length) {
  console.error(`✗ ${errors.length} problem(s)\n` + errors.map(e => '  - ' + e).join('\n'));
  process.exit(1);
}
for (const w of mapChecks.warnings) console.warn('  ! ' + w);
console.log(`✓ Data valid. ${counts}`);
console.log(`  ${mapChecks.summary}`);
for (const w of graphChecks.warnings) console.warn('  ! ' + w);
console.log(`  ${graphChecks.summary}`);
