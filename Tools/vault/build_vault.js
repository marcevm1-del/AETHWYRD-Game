// Builds the Obsidian vault in ideas/ from Data/ and the design bible. Dependency-free (plain Node).
// Usage: node Tools/vault/build_vault.js   (or: npm run vault)
// Generated folders are wiped and rebuilt each run. Ideas/ and Templates/ are only created when
// missing, so notes written there by hand are never overwritten.
const fs = require('fs');
const path = require('path');
const ROOT = path.join(__dirname, '..', '..');
const VAULT = path.join(ROOT, 'ideas');
const load = p => JSON.parse(fs.readFileSync(path.join(ROOT, 'Data', p), 'utf8'));

const GENERATED = ['Monsters', 'Families', 'Regions', 'Clans', 'Fauna', 'NPCs', 'Quests', 'Inns', 'Items', 'Classes', 'Attacks', 'Loot Tables', 'Systems', 'Design Bible', 'Assets'];
const BIBLE_DIRS = ['00_Questions', '01_Core_Concept', '02_Lore', '03_Rank_System', '04_Classes', '05_Skills_Magic',
  '06_Races_Origins', '07_Characters', '08_Bestiary', '09_Equipment', '10_World', '11_Quests_Encounters',
  '12_Systems', '13_Production', 'Planning'];

const species = load('Monsters/species.json');
const populations = load('Monsters/population.json');
const rigData = load('Monsters/rigs.json');
const rigs = rigData.rigs || [];
const motionData = load('Monsters/motion.json');
const motions = motionData.species || [];
const regions = load('World/regions.json');
const npcs = load('NPCs/npcs.json');
const quests = load('Quests/quests.json');
const inns = load('World/inns.json');
const items = [...load('Items/items.json'), ...load('Items/materials.json')];
const classes = load('Classes/classes.json');
const progression = load('Classes/progression.json');
const weeklyQuests = load('Quests/weekly_board.json');
const storyFlags = load('Quests/story_flags.json');
const combatTuning = load('Combat/combat_tuning.json');
const worldTuning = load('World/world_tuning.json');
const siegeWaves = load('World/siege_waves.json');
// Optional world-building data (gazetteer, clans and fauna); region notes skip it when absent.
const loadOpt = p => fs.existsSync(path.join(ROOT, 'Data', p)) ? load(p) : null;
const gazetteer = (loadOpt('World/gazetteer.json') || {}).regions || {};
const clanData = loadOpt('World/clans.json') || {};
const byRegion = arr => (arr || []).reduce((m, x) => ((m[x.regionId] = m[x.regionId] || []).push(x), m), {});
const clansIn = byRegion(clanData.clans), faunaIn = byRegion(clanData.fauna);
const attacks = Object.fromEntries(load('Monsters/attacks.json').map(a => [a.id, a]));
const loot = Object.fromEntries(load('Monsters/loot_tables.json').map(l => [l.id, l]));
const registryFile = path.join(ROOT, 'Art', 'Generation', 'monster_models.json');
const modelRegistry = fs.existsSync(registryFile) ? JSON.parse(fs.readFileSync(registryFile, 'utf8')).models || {} : {};
const lootTables = Object.values(loot);

// ---------------------------------------------------------------- note paths and links
const safe = s => s.replace(/[\\/:*?"<>|#^[\]]/g, '-').trim();
const notePath = {}; // id -> vault path without .md
function claim(id, folder, name) {
  let p = `${folder}/${safe(name)}`;
  if (Object.values(notePath).includes(p)) p += ` (${id})`;
  notePath[id] = p;
}
for (const s of species) claim(s.id, `Monsters/${safe(s.family)}`, s.name);
for (const r of regions) claim(r.id, 'Regions', r.name);
for (const n of npcs) claim(n.id, 'NPCs', n.name);
for (const q of quests) claim(q.id, 'Quests', q.title);
for (const q of weeklyQuests) claim(q.id, 'Quests/Weekly Board', q.title);
for (const i of inns) claim(i.id, 'Inns', i.name);
for (const i of items) claim(i.id, 'Items', i.name);
for (const c of classes) claim(c.id, 'Classes', c.name);
for (const a of Object.values(attacks)) claim(a.id, 'Attacks', a.name);
for (const l of lootTables) claim(l.id, 'Loot Tables', `${l.family} ${l.rank}`);
for (const r of rigs) notePath[`rig:${r.key}`] = `Systems/Rigs/${safe(r.key)}`;
for (const f of storyFlags) claim(`flag:${f.id}`, 'Systems/Flags', f.id);
for (const c of clanData.clans || []) claim(`clan:${c.name}`, 'Clans', c.name);
for (const f of clanData.fauna || []) claim(`fauna:${f.name}`, 'Fauna', f.name);
const families = [...new Set(species.map(s => s.family))].sort();
for (const f of families) notePath[`fam:${f}`] = `Families/${safe(f)}`;

const byId = Object.fromEntries([...species, ...regions, ...npcs, ...quests, ...weeklyQuests, ...inns, ...items, ...classes, ...Object.values(attacks), ...storyFlags.map(f => ({...f, id:`flag:${f.id}`}))].map(x => [x.id, x]));
const label = id => (byId[id] && (byId[id].name || byId[id].title)) || id;
// inTable: escape the alias pipe so the link survives inside a Markdown table cell
const link = (id, inTable = false, text) => notePath[id]
  ? `[[${notePath[id]}${inTable ? '\\|' : '|'}${text || label(id)}]]` : (text || id);
const fam = f => `[[${notePath[`fam:${f}`]}|${f}]]`;
const list = (ids, inTable) => ids.length ? ids.map(id => link(id, inTable)).join(', ') : '—';
const row = (k, v) => (v === undefined || v === '' || v === null) ? '' : `| ${k} | ${v} |\n`;
const bullets = xs => (xs || []).filter(Boolean).map(x => `- ${x}`).join('\n');
const textList = xs => (xs || []).map(x => typeof x === 'string' ? x : JSON.stringify(x));
const front = o => '---\n' + Object.entries(o).map(([k, v]) => `${k}: ${Array.isArray(v) ? `[${v.join(', ')}]` : v}`).join('\n') + '\n---\n';
const tag = s => String(s).toLowerCase().replace(/[^a-z0-9]+/g, '-').replace(/^-|-$/g, '');

// ---------------------------------------------------------------- indexes
const speciesIn = {}, npcsIn = {}, questsIn = {}, innsIn = {}, droppedBy = {}, questsBy = {}, questsForMonster = {}, variantsOf = {};
const populationBySpecies = {}, populationByRegion = {};
const motionById = Object.fromEntries(motions.map(m => [m.speciesId, m]));
const attackUsers = {}, lootUsers = {};
for (const s of species) {
  for (const id of s.attackIds || []) (attackUsers[id] = attackUsers[id] || []).push(s.id);
  (lootUsers[s.lootTableId] = lootUsers[s.lootTableId] || []).push(s.id);
}
for (const p of populations) {
  (populationBySpecies[p.speciesId] = populationBySpecies[p.speciesId] || []).push(p);
  (populationByRegion[p.regionId] = populationByRegion[p.regionId] || []).push(p);
}
for (const s of species) {
  for (const r of s.habitats || []) (speciesIn[r] = speciesIn[r] || []).push(s.id);
  for (const e of (loot[s.lootTableId] || {}).entries || []) (droppedBy[e.itemId] = droppedBy[e.itemId] || []).push({ speciesId: s.id, chance: e.chance, min: e.min, max: e.max, tableId: s.lootTableId });
  if (s.baseSpeciesId) (variantsOf[s.baseSpeciesId] = variantsOf[s.baseSpeciesId] || []).push(s.id);
}
for (const n of npcs) (npcsIn[n.homeRegion] = npcsIn[n.homeRegion] || []).push(n.id);
for (const q of [...quests, ...weeklyQuests]) {
  (questsIn[q.region] = questsIn[q.region] || []).push(q.id);
  (questsBy[q.giver] = questsBy[q.giver] || []).push(q.id);
  for (const o of q.objectives || []) if (o.target && byId[o.target]?.type)
    (questsForMonster[o.target] = questsForMonster[o.target] || []).push(q.id);
}
for (const i of inns) (innsIn[i.regionId] = innsIn[i.regionId] || []).push(i.id);

// ---------------------------------------------------------------- notes
const notes = {}; // vault path -> text
const put = (id, text) => { notes[notePath[id]] = text; };

for (const s of species) {
  const st = s.stats || {};
  const lt = loot[s.lootTableId];
  const motion = motionById[s.id];
  let t = front({ type: 'monster', id: s.id, family: `"${s.family}"`, rank: `"${s.rank}"`, tier: s.tier,
    tags: ['monster', tag(s.family), ...(s.isTyrant ? ['tyrant'] : []), ...(s.isUnique ? ['unique'] : [])] });
  t += `# ${s.name}\n\n`;
  // Turnaround sheet (front / side / back) rendered by Tools/blender/bestiary_models.py; embedded by file name.
  const sheet = path.join(ROOT, '08_Bestiary', 'turnarounds', s.family.replace(/\//g, '-'), `${s.id}_sheet.jpg`);
  if (fs.existsSync(sheet)) t += `![[${s.id}_sheet.jpg]]\n*Blockout turnaround: front, side, back (views: \`${s.id}_front/side/back.jpg\`).*\n\n`;
  // 3D model status from the registry (generated FBX files are kept on the creator's PC, not in git).
  const gm = modelRegistry[s.id];
  if (gm && gm.status === 'generated')
    t += `> [!success] 3D model: generated ${gm.date}${gm.provider ? ` with ${gm.provider}` : ''} · ${gm.tris.toLocaleString('en-US')} tris · ${gm.sizeM.join(' × ')} m · local file \`${gm.fbx}\`\n\n`;
  else if (gm)
    t += `> [!note] 3D model: procedural blockout in Unity (${gm.tris.toLocaleString('en-US')} tris · ${gm.sizeM.join(' × ')} m) until the AI model is generated. Prompt in \`Art/Generation/monster_model_prompts.json\`.\n\n`;
  else
    t += `> [!note] 3D model: hand-built Ring 0 model, or not exported yet.\n\n`;
  if (s.look) t += `> ${s.look}\n\n`;
  t += '| Field | Value |\n|---|---|\n';
  t += row('Family · type', `${fam(s.family)} · ${s.type}`);
  if (s.baseSpeciesId) t += row('Variant of', `${link(s.baseSpeciesId, true)} (${s.variantKind || 'variant'})`);
  t += row('Rank · level', `${s.rank} · ${s.level} (${(s.levelRange || []).join('–')})`);
  t += row('Menace', `${s.menace} · ${s.menaceLabel}`);
  t += row('Element · weakness', `${s.element} · ${s.weakness}`);
  t += row('Size', `${s.sizeMeters} m`);
  t += row('Behaviour', `${s.behavior} (${s.aiPattern})`);
  t += row('HP · ATK · DEF · MATK · MDEF · SPD', [st.hp, st.atk, st.def, st.matk, st.mdef, st.spd].join(' · '));
  t += row('XP · gold', `${s.xp} · ${s.gold}`);
  t += row('Ring', s.ring);
  if (motion) t += row('Rig · animation', `${link(`rig:${motion.rigKey}`, true, motion.rigKey)} · \`${motion.animSetId}\``);
  t += row('Habitats', list(s.habitats || [], true));
  if (s.isTyrant) t += row('Tyrant', 'Yes');
  if (s.genre) t += row('Genre', s.genre);
  if (s.trope) t += row('Trope', s.trope);
  if (s.fieldNote) t += `\n**Field note:** ${s.fieldNote}\n`;
  if (motion) {
    const ph = motion.physics || {}, nav = motion.navAgent || {};
    t += `\n## Motion implementation\n\n- **Rig:** ${link(`rig:${motion.rigKey}`, false, motion.rigKey)} (${motion.rigVia || 'generated'}); animation set \`${motion.animSetId}\`.\n- **Dimensions:** ${motion.heightM} m high × ${motion.lengthM} m long × ${motion.widthM} m wide; prefab scale ${motion.prefabScale}.\n- **Physics:** ${ph.massKg} kg, gravity ×${ph.gravityScale}, poise ${ph.poise}, knockback resistance ${ph.knockbackResist}, death style \`${ph.deathStyle}\`.\n- **Navigation:** speed ${nav.speed} m/s, turn ${nav.angularSpeed}°/s, stopping distance ${nav.stoppingDistance} m.\n- **Attack count:** ${(motion.attacks || []).length}; **signature:** ${motion.signature || s.signature || 'none recorded'}.\n`;
  }
  if ((s.attackIds || []).length) {
    t += '\n## Attacks and responses\n\n| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |\n|---|---|---|---|---|---|---|\n';
    for (const id of s.attackIds) {
      const a = attacks[id] || { name: id };
      const response = a.telegraph === 'red' ? 'Treat as unblockable; dodge clear of the line or area.' : a.telegraph === 'gold' ? 'Grab cue; create distance or dodge before contact.' : a.telegraph === 'blue' ? 'Readable standard attack; guard, dodge or use a practiced parry.' : a.kind === 'summon' ? 'Interrupt or reposition; watch for added enemies.' : 'Keep moving and read the animation; do not assume a safe block.';
      t += `| ${link(id, true)} | ${a.kind || ''} | ${a.power ?? ''} | ${a.cooldownSec ?? ''} s | ${a.element || ''} | ${a.telegraph || ''} | ${response} |\n`;
    }
  }
  const localRelations = (s.habitats || []).map(r => regions.find(x => x.id === r)).filter(Boolean);
  t += `\n## Field guide\n\n${s.name} is a **${s.menaceLabel.toLowerCase()} ${s.type.toLowerCase()}** encountered at ${s.rank} rank, around level ${s.level}. Its documented behaviour is *${s.behavior}* and its AI pattern is *${s.aiPattern}*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.\n`;
  if (s.weakness && s.weakness !== 'None') t += `\n**Hunt preparation:** the recorded weakness is **${s.weakness}**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.\n`;
  if (s.signature) t += `\n**Signature read:** ${s.signature}. Watch for its tell and leave a response window before committing to a long combo.\n`;
  if (localRelations.length) t += `\n**Where it fits:** recorded in ${localRelations.map(r => link(r.id)).join(', ')}. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.\n`;
  if (s.designRecipe) t += `\n**Production note:** rig \`${s.designRecipe.rigId}\`, animation set \`${s.animSetId}\`; keep silhouette, movement and signature attack legible at gameplay camera distance.\n`;
  if (lt) {
    t += `\n## Loot (${link(lt.id)})\n\n| Item | Chance | Amount |\n|---|---|---|\n`;
    for (const e of lt.entries) t += `| ${link(e.itemId, true)} | ${Math.round(e.chance * 100)}% | ${e.min}–${e.max} |\n`;
  }
  if (variantsOf[s.id]) t += `\n## Variants\n\n${variantsOf[s.id].map(id => `- ${link(id)}`).join('\n')}\n`;
  const localPops = populationBySpecies[s.id] || [];
  if (localPops.length) {
    const byPopRegion = {};
    for (const p of localPops) (byPopRegion[p.regionId] = byPopRegion[p.regionId] || []).push(p);
    t += `\n## Regional populations (${localPops.length})\n\nThese are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.\n\n| Region | Forms | Rank span | Level span | Spawn windows |\n|---|---:|---|---|---|\n`;
    for (const [regionId, ps] of Object.entries(byPopRegion)) {
      const ranks = [...new Set(ps.map(p => p.rank))];
      const levels = ps.map(p => p.level);
      t += `| ${link(regionId, true)} | ${ps.length} | ${ranks.join(', ')} | ${Math.min(...levels)}–${Math.max(...levels)} | ${[...new Set(ps.map(p => p.spawn))].join(', ')} |\n`;
    }
    t += `\n### Complete population register\n\n| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |\n|---|---|---|---|---|---:|---:|---|---|\n`;
    for (const p of localPops) t += `| \`${p.id}\` | ${p.name} | ${link(p.regionId, true)} | ${p.tier} | ${p.rank} | ${p.level} | ${p.size} m | ${p.spawn} | ${p.look} |\n`;
  }
  if (questsForMonster[s.id]) t += `\n## Contracts and story encounters\n\n${questsForMonster[s.id].map(id => `- ${link(id)} — rank ${byId[id].rank}, in ${link(byId[id].region)}`).join('\n')}\n\nThese links show where the species already matters to authored play. A contract target is not a claim that every local population is hostile; check the quest objective and the creature’s behavior before engaging.\n`;
  if (s.designRecipe) {
    const d = s.designRecipe;
    t += `\n## Design recipe\n\nRig \`${d.rigId}\` · mesh \`${d.baseMesh}\` · material \`${d.material}\` · VFX \`${d.vfx}\` · `
      + `palette ${(d.palette || []).map(c => `\`${c}\``).join(' ')} · ${d.menaceStyle}\n`;
  }
  put(s.id, t);
}

for (const a of Object.values(attacks)) {
  let t = front({ type: 'monster-attack', id: a.id, telegraph: a.telegraph, kind: a.kind, tags: ['attack', tag(a.kind), tag(a.element || 'none')] }) + `# ${a.name}\n\n`;
  t += '| Field | Value |\n|---|---|\n';
  t += row('Kind · element', `${a.kind} · ${a.element || 'None'}`);
  t += row('Power · cooldown', `${a.power ?? '—'} · ${a.cooldownSec ?? 0} s`);
  t += row('Telegraph', a.telegraph || 'none');
  const response = a.telegraph === 'red' ? 'Unblockable cue: leave the attack line or marked area with a dodge.' : a.telegraph === 'gold' ? 'Grab cue: create distance or dodge before contact.' : a.telegraph === 'blue' ? 'Standard readable cue: guard, dodge or practice a parry.' : a.kind === 'summon' ? 'Watch for a change in enemy count and reposition or interrupt where possible.' : 'Read the animation and keep moving; do not assume a block is safe.';
  t += `\n## Player response\n\n${response}\n`;
  if (attackUsers[a.id]) t += `\n## Used by\n\n${attackUsers[a.id].map(id => `- ${link(id)}`).join('\n')}\n`;
  t += `\n## Animation and fairness\n\nThe telegraph describes attack intent; motion data supplies windup, active timing, hitboxes and recovery. Preserve a visible decision window at gameplay camera distance, and verify that effects do not hide the tell. A shared attack can be reused across a family, but its delivery should still match the creature’s silhouette and behavior.\n`;
  notes[notePath[a.id]] = t;
}
const attackGroups = {};
for (const a of Object.values(attacks)) (attackGroups[a.kind] = attackGroups[a.kind] || []).push(a);
notes['Systems/Attack Library'] = front({ type: 'system-index', tags: ['system', 'attack-library', 'combat'] })
  + `# Monster Attack Library\n\n${Object.values(attacks).length} reusable attack definitions. Each attack links to its users; species-specific motion data determines how the shared rule is animated and timed.\n\n`
  + Object.keys(attackGroups).sort().map(k => `## ${k}\n\n${attackGroups[k].map(a => `- ${link(a.id)} — ${a.element || 'None'}, ${a.telegraph || 'no telegraph'}, power ${a.power ?? '—'}, cooldown ${a.cooldownSec ?? 0} s`).join('\n')}`).join('\n\n');

for (const l of lootTables) {
  let t = front({ type: 'loot-table', id: l.id, family: `"${l.family}"`, rank: `"${l.rank}"`, tags: ['loot-table', tag(l.family), tag(l.rank)] }) + `# ${l.family} — ${l.rank} loot\n\n`;
  t += `This table defines the drop chances and quantities for its associated species. Each chance is an independent data value; rare chase drops can be below one percent.\n\n| Item | Chance | Quantity |\n|---|---:|---:|\n`;
  for (const e of l.entries || []) t += `| ${link(e.itemId, true)} | ${(e.chance * 100).toFixed(e.chance < 0.01 ? 3 : 1)}% | ${e.min}–${e.max} |\n`;
  if (lootUsers[l.id]) t += `\n## Used by\n\n${lootUsers[l.id].map(id => `- ${link(id)}`).join('\n')}\n`;
  t += `\n## Economy role\n\nDrop rates influence hunt value and crafting supply. Luck modifies the configured chance as a multiplier; it is not a flat percentage-point addition. Check the item’s use and rank before changing a table, and keep rare materials obtainable through reasonable repeat play.\n`;
  notes[notePath[l.id]] = t;
}
notes['Systems/Loot Table Index'] = front({ type: 'system-index', tags: ['system', 'loot', 'economy'] })
  + `# Loot Table Index\n\n${lootTables.length} family-and-rank tables define the item supply loop. Open a table to see exact chances, quantities, items and species using it.\n\n`
  + [...lootTables].sort((a, b) => a.family.localeCompare(b.family) || a.rank.localeCompare(b.rank)).map(l => `- ${link(l.id)} — ${l.family}, ${l.rank} (${(l.entries || []).length} entries)`).join('\n') + '\n';

for (const f of families) {
  const members = species.filter(s => s.family === f).sort((a, b) => a.level - b.level);
  const ranks = [...new Set(members.map(s => s.rank))];
  const elements = [...new Set(members.map(s => s.element))];
  let t = front({ type: 'family', tags: ['family', tag(f)] }) + `# ${f}\n\n${members.length} species in this family, sorted by level. Use this page to compare silhouette, threat, elemental identity and encounter role before opening an individual field guide.\n\n`;
  t += `## Family profile\n\n- **Rank span:** ${ranks.join(', ')}\n- **Element palette:** ${elements.join(', ')}\n- **Level span:** ${members[0]?.level ?? '—'}–${members[members.length - 1]?.level ?? '—'}\n- **Design test:** every variant should preserve a recognizable family silhouette while changing at least one gameplay read (reach, speed, area control, durability or attack cadence). Avoid reskin-only variants with identical combat tells.\n\n`;
  t += '| Monster | Rank | Level | Element | Menace |\n|---|---|---|---|---|\n';
  for (const s of members) t += `| ${link(s.id, true)} | ${s.rank} | ${s.level} | ${s.element} | ${s.menaceLabel} |\n`;
  notes[notePath[`fam:${f}`]] = t;
}

for (const r of regions) {
  let t = front({ type: 'region', id: r.id, layer: r.layer, ring: r.ring, tags: ['region', r.layer] }) + `# ${r.name}\n\n`;
  t += '| Field | Value |\n|---|---|\n';
  t += row('Layer · ring', `${r.layer} · ${r.ring}`);
  t += row('Ranks', `${r.rankMin}–${r.rankMax}`);
  t += row('Biomes', (r.biomes || []).join(', '));
  if (r.tyrantSpeciesId) t += row('Tyrant', link(r.tyrantSpeciesId, true));
  t += row('Siege faction · state', `${r.siegeFaction || '—'} · ${r.initialState || '—'}`);
  t += row('Settlements', (r.defenceSettlements || []).join(', '));
  const regionalWaves = siegeWaves.find(w => w.regionId === r.id);
  if (regionalWaves) {
    t += `\n## Siege encounter plan\n\nFaction **${regionalWaves.faction}**, ${regionalWaves.rankMin}–${regionalWaves.rankMax} band. The templates below are the planned defense sequence; settlements remain safe from permanent destruction under Canon §5.\n`;
    for (const w of regionalWaves.waves || []) {
      const units = (w.units || []).map(u => `${u.count} × ${link(u.speciesId)} (${byId[u.speciesId]?.rank || 'rank unlisted'})`).join(', ');
      t += `\n- **Wave ${w.wave}:** ${units || 'No units recorded.'}${w.lieutenantSpeciesId ? `; lieutenant: ${link(w.lieutenantSpeciesId)}` : ''}\n`;
    }
  }
  const gz = gazetteer[r.id];
  if (gz) {
    t += `\n> **${gz.epithet}.** ${gz.summary}\n>\n> *${gz.echo}*\n`;
    for (const [k, h] of [['overview', 'Overview'], ['geography', 'Geography'], ['ecology', 'Ecology'], ['peoples', 'Peoples'],
      ['powerAndTrade', 'Power & trade'], ['faithAndCustoms', 'Faith & customs'], ['tyrant', 'The Tyrant'], ['senses', 'Senses']])
      if (gz[k]) t += `\n## ${h}\n\n${gz[k]}\n`;
    const hist = Object.entries(gz.history || {});
    if (hist.length) t += `\n## History\n\n${hist.map(([k, v]) => `- **${k[0].toUpperCase() + k.slice(1)}:** ${v}`).join('\n')}\n`;
    for (const [k, h] of [['settlements', 'Settlements'], ['landmarks', 'Landmarks']])
      if ((gz[k] || []).length) t += `\n## ${h}\n\n${gz[k].map(x => `- **${x.name}:** ${x.text}`).join('\n')}\n`;
    if ((gz.hooks || []).length) t += `\n## Story hooks\n\n${gz.hooks.map(x => `- ${x}`).join('\n')}\n`;
  }
  t += `\n## How to read this region\n\nUse the rank band and terrain together when planning an outing. Listed monsters are the local baseline; weather, time, migration and story events can create exceptions, but should communicate why the ecology changed. In a besieged region, defend settlements when a posted event fits your route, then decide whether to pursue the Tyrant or prepare further. Liberation changes daily life and contracts; it does not erase ordinary wildlife or world events.\n`;
  if (clansIn[r.id]) t += `\n## Clans\n\n${clansIn[r.id].map(c => `- ${link(`clan:${c.name}`, false, c.name)} (${c.board}${c.leader ? `, led by ${c.leader}` : ''}): ${c.culture || c.look || ''}`).join('\n')}\n`;
  if (faunaIn[r.id]) t += `\n## Fauna\n\n${faunaIn[r.id].map(f => `- ${link(`fauna:${f.name}`, false, f.name)} (${f.group}): ${f.text}`).join('\n')}\n`;
  if (npcsIn[r.id]) t += `\n## People\n\n${npcsIn[r.id].map(id => `- ${link(id)}: ${byId[id].role}`).join('\n')}\n`;
  if (innsIn[r.id]) t += `\n## Inns\n\n${innsIn[r.id].map(id => `- ${link(id)} (${byId[id].settlement})`).join('\n')}\n`;
  if (questsIn[r.id]) t += `\n## Quests\n\n${questsIn[r.id].map(id => `- ${link(id)} (${byId[id].rank})`).join('\n')}\n`;
  const here = (speciesIn[r.id] || []).map(id => byId[id]).sort((a, b) => a.level - b.level);
  if (here.length) {
    t += `\n## Monsters (${here.length})\n\n| Monster | Family | Rank | Level |\n|---|---|---|---|\n`;
    for (const s of here) t += `| ${link(s.id, true)} | ${fam(s.family).replace('|', '\\|')} | ${s.rank} | ${s.level} |\n`;
  }
  const regionalForms = populationByRegion[r.id] || [];
  if (regionalForms.length) {
    const speciesCounts = {};
    const spawnCounts = {};
    for (const p of regionalForms) {
      speciesCounts[p.speciesId] = (speciesCounts[p.speciesId] || 0) + 1;
      spawnCounts[p.spawn] = (spawnCounts[p.spawn] || 0) + 1;
    }
    const distinctSpecies = Object.keys(speciesCounts).length;
    t += `\n## Population and spawn patterns\n\nThe data records **${regionalForms.length} named population forms** across **${distinctSpecies} species** here. These variants describe age, condition, size, appearance or timing; use them to make repeat visits feel alive while keeping regional identity legible. Recorded spawn windows: ${Object.entries(spawnCounts).map(([k, v]) => `${k} (${v})`).join(', ')}.\n\n### Complete local population register\n\n| ID | Named form | Species | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |\n|---|---|---|---|---|---:|---:|---|---|\n`;
    for (const p of regionalForms) t += `| \`${p.id}\` | ${p.name} | ${link(p.speciesId, true)} | ${p.tier} | ${p.rank} | ${p.level} | ${p.size} m | ${p.spawn} | ${p.look} |\n`;
    t += `\n**Ecology rule:** population variety should signal a cause—season, time, food, migration, siege pressure or local adaptation. Do not use sheer count as a substitute for meaningful regional identity.\n`;
  }
  const adjacent = regions.filter(x => x.id !== r.id && (x.biomes || []).some(b => (r.biomes || []).includes(b))).slice(0, 8);
  if (adjacent.length) t += `\n## Ecological neighbours\n\nShared biomes suggest plausible migration and trade routes, not identical default spawns: ${adjacent.map(x => link(x.id)).join(', ')}.\n`;
  put(r.id, t);
}

for (const c of clanData.clans || []) {
  const id = `clan:${c.name}`;
  const region = regions.find(r => r.id === c.regionId);
  const p = c.profile || {};
  let t = front({ type: 'clan', region: c.regionId, tags: ['clan', tag(c.board || 'people')] }) + `# ${c.name}\n\n`;
  t += `> ${c.look || ''}\n\n${c.culture || ''}\n\n`;
  t += `## At a glance\n\n- **Home:** ${region ? link(region.id) : c.regionId}\n- **Source board:** ${c.board || 'unclassified'}\n- **Leader:** ${c.leader || 'No named leader'}\n- **Story hook:** ${c.hook || 'No hook recorded yet.'}\n`;
  for (const [k, h] of [['origin','Origin'],['society','Society'],['beliefs','Beliefs'],['relations','Relations'],['war','Conflict and defence'],['trade','Trade'],['strengths','Strengths'],['weaknesses','Vulnerabilities'],['gameplay','Gameplay role']])
    if (p[k]) t += `\n## ${h}\n\n${p[k]}\n`;
  if (c.kinds?.length) t += `\n## Members and roles\n\n${c.kinds.map(x => `- **${x.name}** — ${x.role}: ${x.text}`).join('\n')}\n`;
  if (p.npcs?.length) t += `\n## Notable figures\n\n${p.npcs.map(x => `- **${x[0]}** (${x[1]}): ${x[2]}`).join('\n')}\n`;
  if (p.quests?.length) t += `\n## Quest seeds\n\n${bullets(p.quests)}\n`;
  t += `\n## Design guardrails\n\nKeep this people-node grounded in its stated home, needs, internal differences and relationships. Show ordinary life as well as conflict. This is a worldbuilding draft; Canon and approved game data take precedence, and unapproved details remain proposals.\n`;
  notes[notePath[id]] = t;
}

for (const f of clanData.fauna || []) {
  const id = `fauna:${f.name}`;
  const region = regions.find(r => r.id === f.regionId);
  notes[notePath[id]] = front({ type: 'local-fauna', region: f.regionId, group: `"${f.group || ''}"`, tags: ['fauna', tag(f.group || 'wildlife')] })
    + `# ${f.name}\n\n${f.text || ''}\n\n## Ecological role\n\n- **Range:** ${region ? link(region.id) : f.regionId}\n- **Group:** ${f.group || 'Unclassified'}\n- **World use:** establish what this life-form contributes to the region’s food web, seasonal rhythm, travel hazards or local livelihoods before turning it into a combat encounter.\n- **Encounter principle:** wildlife should have readable reasons to flee, feed, defend territory or approach settlements; combat is only one possible interaction.\n`;
}

for (const n of npcs) {
  let t = front({ type: 'npc', id: n.id, tier: n.tier, tags: ['npc', tag(n.faction || 'none')] }) + `# ${n.name}\n\n`;
  t += '| Field | Value |\n|---|---|\n';
  t += row('Role', n.role);
  t += row('Race', n.race);
  t += row('Home', `${link(n.homeRegion, true)} · ${n.settlement || ''}`);
  t += row('Faction', n.faction);
  t += row('Romanceable · can die', `${n.romanceable ? 'Yes' : 'No'} · ${n.canDie ? 'Yes' : 'No'}`);
  t += `\n${n.backstory || ''}\n`;
  if ((n.relationships || []).length)
    t += `\n## Relationships\n\n${n.relationships.map(r => `- ${r.kind}: ${link(r.npcId)}`).join('\n')}\n`;
  if ((n.schedule || []).length)
    t += `\n## Schedule\n\n${n.schedule.map(s => `- **${s.part}:** ${s.place}`).join('\n')}\n`;
  if ((n.states || []).length) t += `\n## Story-state map\n\nThis character can change with story flags. Use the state list to keep dialogue, appearance, availability and quest access consistent. The details remain collapsed below because they contain spoilers.\n`;
  if (n.canDie) t += `\n## Continuity note\n\nThis character is marked mortal in the data. Any death scene must follow the project’s loss rules and preserve essential progression through alternate routes or a replacement role.\n`;
  if (questsBy[n.id]) t += `\n## Quests given\n\n${questsBy[n.id].map(id => `- ${link(id)}`).join('\n')}\n`;
  if (n.secret || (n.states || []).length) {
    t += '\n> [!warning]- Spoilers (Canon §3)\n';
    if (n.secret) t += `> **Secret:** ${n.secret}\n`;
    for (const s of n.states || []) t += `> **After ${link(`flag:${s.flag}`, false, s.flag)}:** ${s.role}. ${s.note || ''}\n`;
  }
  put(n.id, t);
}

const describe = o => {
  if (o.kind === 'kill' && byId[o.target]) return `Defeat ${o.count || 1} × ${link(o.target)} (${byId[o.target].rank}, Lv ${byId[o.target].level})`;
  if (o.kind === 'choice') return `Resolve the choice: **${o.target || 'unnamed choice'}**`;
  if (o.target && byId[o.target]) return `${o.kind || 'Complete'}: ${link(o.target)}${o.count ? ` ×${o.count}` : ''}`;
  return JSON.stringify(o);
};
for (const q of quests) {
  let t = front({ type: 'quest', id: q.id, rank: `"${q.rank}"`, tags: ['quest', tag(q.type)] }) + `# ${q.title}\n\n> ${q.summary}\n\n`;
  t += '| Field | Value |\n|---|---|\n';
  t += row('Rank · type', `${q.rank} · ${q.type}`);
  t += row('Giver', link(q.giver, true));
  t += row('Region', link(q.region, true));
  if (q.requirements && Object.keys(q.requirements).length) t += row('Requirements', Object.entries(q.requirements).map(([k, v]) => `${k}: ${Array.isArray(v) ? v.join(', ') : typeof v === 'object' ? JSON.stringify(v) : v}`).join('; '));
  const pre = q.prerequisites || {};
  const preText = [...(pre.quests || []).map(id => `quest ${link(id, true)}`), ...(pre.flags || []).map(x => `flag ${link(`flag:${x}`, true, x)}`), pre.act && `Act ${pre.act}`, pre.rank && `rank ${pre.rank}`].filter(Boolean);
  if (preText.length) t += row('Prerequisites', preText.join('; '));
  if (q.regionState) t += row('Region state', q.regionState);
  const rw = q.rewards || {};
  t += row('Rewards', [rw.gold && `${rw.gold} gold`, rw.gp && `${rw.gp} GP`, rw.xp && `${rw.xp} XP`,
    ...(rw.items || []).map(i => link(i, true))].filter(Boolean).join(', '));
  if ((q.objectives || []).length) t += `\n## Objectives\n\n${q.objectives.map((o, n) => `${n + 1}. ${describe(o)}`).join('\n')}\n`;
  const objectiveSpecies = [...new Set((q.objectives || []).map(o => o.target).filter(id => byId[id]?.attackIds))];
  if (objectiveSpecies.length) {
    t += `\n## Field preparation\n\n`;
    for (const id of objectiveSpecies) {
      const m = byId[id];
      const signatureAttacks = (m.attackIds || []).map(aid => attacks[aid]).filter(Boolean).slice(0, 3);
      t += `### ${m.name}\n\n- **Threat:** ${m.rank} rank, Lv ${m.level}, ${m.behavior} (${m.aiPattern}).\n- **Element:** ${m.element}; recorded weakness: ${m.weakness}.\n`;
      if (signatureAttacks.length) t += `- **Read its attacks:** ${signatureAttacks.map(a => `${a.name} (${a.telegraph} tell, ${a.kind})`).join('; ')}.\n`;
      t += `- **Route:** encounter is listed in ${link(m.habitats?.[0] || q.region)}; check the local terrain and the quest giver’s account before committing.\n`;
    }
    t += `\nPreparation is advice, not a hard build check. Learn tells, use movement and defense, and bring supplies that match the trip.\n`;
  }
  t += `\n## Play loop\n\n1. **Read the brief:** separate confirmed facts from uncertainty.\n2. **Prepare:** choose equipment, companions and supplies that fit the rank and objective.\n3. **Investigate and act:** follow the objectives; where permitted, support combat with tracking, conversation, stealth, crafting or monster knowledge.\n4. **Return and resolve:** claim the listed rewards and apply only the story flags or world-state changes recorded in source data.\n`;
  if ((q.setsFlags || []).length) t += `\n**Flags set:** ${q.setsFlags.map(x => link(`flag:${x}`, false, x)).join(', ')}\n`;
  if (q.regionState) t += `\n**Region-state gate:** available only while the region is **${q.regionState}**.\n`;
  put(q.id, t);
}

for (const q of weeklyQuests) {
  const rw = q.rewards || {};
  let t = front({ type: 'weekly-board-quest', id: q.id, day: q.day, slot: q.slot, repeat: q.repeat, tags: ['quest', 'weekly-board', tag(q.type)] }) + `# ${q.title}\n\n> ${q.summary}\n\n`;
  t += '| Field | Value |\n|---|---|\n';
  t += row('Weekday · slot', `${q.day} · ${q.slot}`);
  t += row('Repeat · time', `${q.repeat} · ${q.timeOfDay || 'any time'}`);
  t += row('Rank band', `${q.rankMin || '—'}–${q.rankMax || '—'}`);
  t += row('Region state', q.regionState || 'any');
  t += row('Region · giver', `${link(q.region, true)} · ${link(q.giver, true)}`);
  t += row('Type · trope', `${q.type} · ${q.trope || ''}`);
  t += row('Rewards', [rw.gold && `${rw.gold} gold`, rw.gp && `${rw.gp} GP`, rw.xp && `${rw.xp} XP`, ...(rw.items || []).map(id => link(id, true))].filter(Boolean).join(', '));
  if ((q.objectives || []).length) t += `\n## Objectives\n\n${q.objectives.map((o, n) => `${n + 1}. ${describe(o)}`).join('\n')}\n`;
  if ((q.twists || []).length) t += `\n## Possible twists\n\n${bullets(q.twists)}\n`;
  t += `\n## Board role\n\nThis entry is a recurring board template, not a one-time story quest. Its day, slot, time window, rank band and region-state filter control when it can appear. Repetition should preserve the premise while a selected twist, party banter or world-state change adds context; do not imply that a twist is guaranteed every time.\n`;
  notes[notePath[q.id]] = t;
}

for (const i of inns) {
  let t = front({ type: 'inn', id: i.id, tags: ['inn'] }) + `# ${i.name}\n\n`;
  t += '| Field | Value |\n|---|---|\n';
  t += row('Where', `${link(i.regionId, true)} · ${i.settlement}`);
  t += row('Keeper', i.keeperNpcId && notePath[i.keeperNpcId] ? link(i.keeperNpcId, true) : i.keeperName);
  t += row('Tier · ring', `${i.tier} · ${i.ring}`);
  if (i.dish) t += row('Dish', `${i.dish.name}: ${i.dish.effect}`);
  if (i.drink) t += row('Drink', `${i.drink.name}: ${i.drink.effect}`);
  if (i.quirk) t += row('Quirk', i.quirk);
  if (i.rumorTheme) t += row('Rumor theme', i.rumorTheme);
  if ((i.rooms || []).length) {
    t += '\n## Rooms\n\n| Room | Price (copper) | Rest | Perk |\n|---|---|---|---|\n';
    for (const r of i.rooms) t += `| ${r.name || r.tier} | ${r.priceCopper} | ${r.rest} | ${r.perk || ''} |\n`;
  }
  if (i.events?.length) t += `\n## Inn events\n\n${bullets(i.events)}\n`;
  if (i.secret) t += `\n> [!warning]- Spoiler\n> ${i.secret}\n`;
  if (questsIn[i.regionId]?.length) t += `\n## Nearby contracts\n\n${questsIn[i.regionId].map(id => `- ${link(id)} (${byId[id].rank}, ${byId[id].type})`).join('\n')}\n`;
  if (npcsIn[i.regionId]?.length) t += `\n## Local people\n\n${npcsIn[i.regionId].slice(0, 12).map(id => `- ${link(id)} — ${byId[id].role}`).join('\n')}${npcsIn[i.regionId].length > 12 ? `\n- ${npcsIn[i.regionId].length - 12} more residents are listed on the region page.` : ''}\n`;
  t += `\n## Stay and departure\n\nUse room tier, price and listed perk to make a deliberate rest choice. An inn is also a safe social hub: speak with the keeper, check regional rumours and use the settlement as a launch point for nearby contracts. Room data is authoritative for costs and effects; this note does not imply free lodging.\n`;
  put(i.id, t);
}

for (const i of items) {
  let t = front({ type: 'item', id: i.id, category: i.category, rank: `"${i.rank}"`, tags: ['item', tag(i.category)] }) + `# ${i.name}\n\n`;
  if (i.flavor) t += `> ${i.flavor}\n\n`;
  t += '| Field | Value |\n|---|---|\n';
  t += row('Category · rank', `${i.category} · ${i.rank}`);
  t += row('Rarity · slot', [i.rarity, i.slot].filter(Boolean).join(' · '));
  t += row('Value', i.value);
  if (i.stats) t += row('Stats', Object.entries(i.stats).map(([k, v]) => `${k} ${v}`).join(', '));
  t += `\n## Use in the world\n\n${i.category === 'material' ? 'Materials connect field activity to crafting and trade. Their source and value help players decide whether to sell, keep or gather more.' : i.category === 'weapon' || i.category === 'armor' ? 'Equipment changes the character’s combat profile. Compare its rank, slot and stat line with the current build before investing in an upgrade.' : 'This item belongs to the world’s economy and progression loop. Its category, rank, value and recorded effects define its practical use.'}\n`;
  if (droppedBy[i.id]) {
    const d = droppedBy[i.id];
    t += `\n## Drop sources (${d.length})\n\n| Monster | Chance | Quantity |\n|---|---:|---:|\n${d.slice(0, 60).map(x => `| ${link(x.speciesId, true)} | ${(x.chance * 100).toFixed(x.chance < 0.01 ? 3 : 1)}% | ${x.min}–${x.max} |`).join('\n')}${d.length > 60 ? `\n\n…and ${d.length - 60} additional sources.` : ''}\n`;
  }
  put(i.id, t);
}

const trainerNpc = name => npcs.find(n => n.name === name || n.name.includes(`"${name}"`) || n.name.endsWith(` ${name}`));
const costOf = k => [k.costSp && `${k.costSp} SP`, k.costMp && `${k.costMp} MP`, k.costAwakening && `${k.costAwakening} Awakening`].filter(Boolean).join(', ') || '—';
const hitsOf = k => {
  if (!k.hits.length) return '—';
  const total = k.hits.reduce((a, h) => a + h.power, 0);
  return `${k.hits.length} × (${[...new Set(k.hits.map(h => h.weight))].join('/')}) · ${Math.round(total * 100) / 100} total`;
};
for (const c of classes) {
  let t = front({ type: 'class', id: c.id, tier: c.tier, tags: ['class', c.tier] }) + `# ${c.name}\n\n`;
  t += '| Field | Value |\n|---|---|\n';
  t += row('Role', c.role);
  t += row('Growth (STR/VIT/AGI/DEX/INT/WIS/LUK/CHA)', ['str', 'vit', 'agi', 'dex', 'int', 'wis', 'luk', 'cha'].map(k => c.growth[k] || 0).join('/'));
  t += row('Weapons', c.weapons.join(', '));
  t += row('Armour', c.armor.join(', '));
  t += row('Mechanic', c.mechanic);
  if (c.recommendedAllocation) t += row('Suggested stat allocation', Object.entries(c.recommendedAllocation).map(([k, v]) => `${k.toUpperCase()} ${Math.round(v * 100)}%`).join(', '));
  const tr = trainerNpc(c.trainer || '');
  t += row('Trainer', tr ? link(tr.id, true) : c.trainer);
  t += row('Class quest', c.classQuest ? `*${c.classQuest}*` : '');
  if (c.starterWeaponId) t += row('Starter weapon', link(c.starterWeaponId, true));
  t += `\n## Kit\n\n| Lv | Skill | Kind | Hits | Cost | Cooldown | Element | Effect |\n|---|---|---|---|---|---|---|---|\n`;
  for (const k of [...c.kit].sort((a, b) => a.unlockLevel - b.unlockLevel))
    t += `| ${k.unlockLevel} | **${k.name}**${k.slot === 'basic' ? ' (basic)' : ''} | ${k.kind} | ${hitsOf(k)} | ${costOf(k)} | ${k.cooldownSec ? `${k.cooldownSec} s` : '—'} | ${k.element} | ${k.effect || ''} |\n`;
  t += `\n**Combat rhythm:** basic chains build the class’s ordinary tempo; active skills should create clear commitment and payoff, while mobility or control skills let the player change spacing. Resource cost and cooldown are part of the decision, so avoid spending every skill on the first available target.\n`;
  if ((c.passives || []).length)
    t += `\n## Passives\n\n${c.passives.map(p => `- **${p.name}** (Lv ${p.unlockLevel}): ${p.effect}`).join('\n')}\n`;
  t += `\n## How this class plays\n\nBuild around the class’s stated mechanic and growth profile. Weapons and armour shape its rhythm; the kit creates decisions about approach, commitment, recovery and resource use. A class is a playstyle identity, not a requirement to parry perfectly: defensive options and readable recovery windows should keep the wider game accessible.\n`;
  put(c.id, t);
}

for (const r of rigs) {
  const members = motions.filter(m => m.rigKey === r.key);
  const speciesFamilies = [...new Set(members.map(m => byId[m.speciesId]?.family).filter(Boolean))];
  let t = front({ type: 'monster-rig', id: `rig:${r.key}`, tags: ['rig', 'animation', tag(r.key)] }) + `# ${r.key} rig\n\n${r.description || 'Shared creature body plan used by the monster motion pipeline.'}\n\n`;
  t += '| Field | Value |\n|---|---|\n';
  t += row('Aliases', (r.aliases || []).join(', '));
  t += row('Species using rig', members.length);
  t += row('Families represented', speciesFamilies.join(', '));
  t += row('Bone count · budget', `${r.boneCount ?? '—'} · ${r.boneBudget ?? '—'}`);
  t += row('Unity avatar · material', `${r.unityAvatar || 'Generic'} · ${r.material || 'family material'}`);
  t += row('Reference size · axis', `${r.refSize ?? '—'} · ${r.sizeAxis || '—'}`);
  t += `\n## Locomotion and animations\n\n- **Locomotion:** ${JSON.stringify(r.locomotion || {})}\n- **Physics profile:** ${JSON.stringify(r.physics || {})}\n- **Animation set:** ${JSON.stringify(r.anims || {})}\n- **Procedural motion:** ${JSON.stringify(r.procedural || {})}\n`;
  if ((r.hurtboxes || []).length) t += `\n## Default hurtboxes\n\n${r.hurtboxes.map(h => `- **${h.bone}** — ${h.shape}; radius ${h.radius ?? '—'}; damage multiplier ${h.damageMult ?? 'default'}`).join('\n')}\n`;
  t += `\n## Species\n\n${members.map(m => `- ${link(m.speciesId)} — ${m.animSetId}, ${m.heightM} m high, ${m.rigVia || 'generated'} rig selection`).join('\n')}\n`;
  t += `\n## Production checks\n\nValidate the rig export axes, root transform, bone presence, animator mapping, hurtbox placement and a representative locomotion cycle before using it for a new species. Motion overrides should be reserved for species whose signature silhouette or action cannot be expressed by the shared rig rules.\n`;
  notes[notePath[`rig:${r.key}`]] = t;
}
notes['Systems/Rig Catalog'] = front({ type: 'system-index', source: 'Data/Monsters/rigs.json', tags: ['system', 'monster-rigs', 'animation'] })
  + `# Monster Rig Catalog\n\nThe motion pipeline uses ${rigs.length} reusable body plans for ${motions.length} species. A shared rig is a production foundation; silhouette, parts, materials, timing, VFX and authored motion keep species distinct.\n\n${rigs.map(r => `- ${link(`rig:${r.key}`, false, r.key)} — ${motions.filter(m => m.rigKey === r.key).length} species`).join('\n')}\n`;

const formula = f => {
  const parts = [];
  if (f.flat) parts.push(String(f.flat));
  for (const [k, v] of Object.entries(f)) if (!['flat', 'perLevel', 'max'].includes(k)) parts.push(`${v} × ${k.toUpperCase()}`);
  if (f.perLevel) parts.push(`${f.perLevel} × level`);
  return parts.join(' + ') || '—';
};
let progressionNote = front({ type: 'progression-rules', source: 'Data/Classes/progression.json', tags: ['system', 'progression', 'player-stats'] }) + `# Player Progression and Stats\n\nThis note summarizes the shared progression data used by the player rules and monster XP generator. Data/Classes/progression.json is authoritative; C# applies documented rounding.\n\n`;
progressionNote += `- **Base primary stat:** ${progression.baseStat}\n- **Free points:** ${progression.freePointsPerLevel} each level after level 1, allocated by the player’s build\n- **Level cap:** 300 (Canon)\n\n`;
progressionNote += `## Derived stats\n\n| Stat | Formula | Cap |\n|---|---|---:|\n`;
for (const [k, v] of Object.entries(progression.derived)) progressionNote += `| ${k.toUpperCase()} | ${formula(v)} | ${v.max ?? '—'} |\n`;
progressionNote += `\nPrimary stats are built from base value + class growth × level + free points allocated to the stat. Gear bonuses are applied to supported combat stats.\n`;
progressionNote += `\n## Experience curve\n\n- **Monster XP:** round(${progression.xp.monsterBase} + level^${progression.xp.monsterExponent} × ${progression.xp.monsterScale}); unique multiplier ×${progression.xp.uniqueMultiplier}.\n- **XP to next level:** same-level monster XP × (${progression.xp.killsPerLevelBase} + ${progression.xp.killsPerLevelGrowth} × level).\n- Quests, discovery and crafting add progress, so the kill count is a baseline, not a required grind target.\n- At the level cap, XP to next level is zero; post-cap growth follows the separate Transcendence rules in the design bible.\n`;
notes['Classes/Progression'] = progressionNote;

const flatten = (obj, prefix = '') => Object.entries(obj || {}).flatMap(([k, v]) => {
  const key = prefix ? `${prefix}.${k}` : k;
  return v && typeof v === 'object' && !Array.isArray(v) ? flatten(v, key) : [[key, Array.isArray(v) ? v.join(', ') : String(v)]];
});
const tuneNote = (title, source, data, description) => {
  let t = front({ type: 'tuning-reference', source, tags: ['system', 'tuning'] }) + `# ${title}\n\n${description}\n\n| Key | Value |\n|---|---|\n`;
  for (const [k, v] of flatten(data)) t += `| \`${k}\` | ${v} |\n`;
  return t + `\nEdit the source JSON, validate it, and rerun the relevant review before treating a tuned value as approved. This vault note is generated and will be overwritten on rebuild.\n`;
};
notes['Systems/Combat Tuning'] = tuneNote('Combat Tuning', 'Data/Combat/combat_tuning.json', combatTuning, 'Central tuning values for movement, camera, defense, attacks, poise, reactions, damage, style and feedback. Values are measured in the units described by the source data.');
notes['Systems/World Tuning'] = tuneNote('World Tuning', 'Data/World/world_tuning.json', worldTuning, 'Shared calendar, siege, prosperity and inn tuning used by the engine-agnostic game rules. The weekday order and day length are locked in Canon; the numeric details remain data-driven.');

const byDay = {};
for (const q of weeklyQuests) (byDay[q.day] = byDay[q.day] || []).push(q);
let weeklyIndex = front({ type: 'system', source: 'Data/Quests/weekly_board.json', tags: ['system', 'weekly-board', 'calendar'] }) + `# Weekly Board\n\nThe board turns the seven-day calendar into recurring local story texture. Specials frame a day; dailies provide varied work; rank, time and region-state filters keep the offer plausible. On a siege attack day, the defense contract takes priority at the top of the board.\n\n`;
for (const day of worldTuning.calendar.weekdays) {
  const entries = byDay[day] || [];
  weeklyIndex += `## ${day}\n\n${entries.map(q => `- ${link(q.id)} — ${q.slot}, ${q.type}, ${q.timeOfDay || 'any time'}, ${q.regionState || 'any region state'}`).join('\n') || 'No templates currently assigned.'}\n\n`;
}
weeklyIndex += `## Player-facing rules\n\nA Day Special should appear at most once in the same in-game week. Three dailies are selected from the weekday’s pool plus the Any pool, filtered by availability and time. A missed board offer is not a settlement disaster; only a posted defense follows the siege auto-resolution rules.\n`;
notes['Systems/Weekly Board'] = weeklyIndex;

for (const f of storyFlags) {
  const setters = [...quests, ...weeklyQuests].filter(q => (q.setsFlags || []).includes(f.id));
  const gates = [...quests, ...weeklyQuests].filter(q => (q.prerequisites?.flags || []).includes(f.id));
  notes[notePath[`flag:${f.id}`]] = front({ type: 'story-flag', id: `"${f.id}"`, tags: ['system', 'story-flag'] })
    + `# ${f.id}\n\n${f.description}\n\n- **Set by:** ${f.setBy}\n- **Written by:** ${setters.length ? setters.map(q => link(q.id)).join(', ') : 'No quest setter currently indexed'}\n- **Read by:** ${gates.length ? gates.map(q => link(q.id)).join(', ') : 'No quest prerequisite currently indexed'}\n\n## State ownership\n\nThis flag records one durable story fact. Quest gating should use it when it changes availability; presentation should check who knows the fact before exposing it in dialogue or rumor. Do not create duplicate flags for the same meaning.\n`;
}
notes['Systems/Story Flags'] = front({ type: 'system-index', tags: ['system', 'story-flags'] })
  + `# Story Flag Index\n\nStory flags are the compact bridge between quest outcomes and later world responses. Keep names stable, descriptions concrete and ownership clear. Use one flag for one fact; separate what happened from who knows it.\n\n${storyFlags.map(f => `- ${link(`flag:${f.id}`, false, f.id)} — ${f.description}`).join('\n')}\n`;

// ---------------------------------------------------------------- design bible mirror
const bible = [];
const mdLink = /\[([^\]]+)\]\((?!https?:)([^)#]+?\.md)(#[^)]*)?\)/g;
function mirror(rel) {
  const out = `Design Bible/${rel.replace(/\.md$/, '')}`;
  let text = fs.readFileSync(path.join(ROOT, rel), 'utf8');
  text = text.replace(mdLink, (m, txt, target) => {
    const resolved = path.posix.normalize(path.posix.join(path.posix.dirname(rel), target));
    return `[[Design Bible/${resolved.replace(/\.md$/, '')}|${txt}]]`;
  });
  text = text.replace(/!\[([^\]]*)\]\((?!https?:)([^)]+\.(png|jpe?g))\)/g, (m, alt, src) => `![[${path.basename(src)}]]`);
  notes[out] = text;
  bible.push(out);
}
for (const f of ['README.md', 'Canon.md', 'CHANGELOG.md']) mirror(f);
for (const d of BIBLE_DIRS) {
  for (const f of fs.readdirSync(path.join(ROOT, d)).sort()) if (f.endsWith('.md')) mirror(`${d}/${f}`);
}

// ---------------------------------------------------------------- home
const groupList = (ids, by) => {
  const g = {};
  for (const id of ids) (g[by(byId[id])] = g[by(byId[id])] || []).push(id);
  return Object.keys(g).sort().map(k => `### ${k}\n${g[k].map(id => `- ${link(id)}`).join('\n')}`).join('\n\n');
};
let home = front({ tags: ['index'] }) + `# Aethwyrd Ideas

The AETHWYRD idea vault. Open this \`ideas/\` folder in Obsidian (*Open folder as vault*).

- **Write new ideas** in the \`Ideas\` folder, starting from [[Idea Inbox]]. Use the *Idea* template. The build never touches \`Ideas/\` or \`Templates/\`.
- **Everything else is generated** from \`Data/\` and the design bible by \`npm run vault\`
  (\`Tools/vault/build_vault.js\`). Change the data or the design bible, then rebuild; edits made directly to generated notes are overwritten.
- [[Design Bible/Canon|Canon]] wins any conflict on story; \`Data/\` wins on numbers. NPC secrets sit in collapsed spoiler callouts.

## Design bible
${bible.map(p => `- [[${p}|${p.replace('Design Bible/', '')}]]`).join('\n')}

## Classes (${classes.length})
${classes.map(c => `- ${link(c.id)}: ${c.role}`).join('\n')}

## Game systems and tuning
- [[Classes/Progression|Player progression and derived stats]]
- [[Systems/Combat Tuning|Combat tuning reference]]
- [[Systems/World Tuning|World, siege and inn tuning]]
- [[Systems/Weekly Board|Weekly board by weekday]]
- [[Systems/Story Flags|Story flag index]]
- [[Systems/Rig Catalog|Monster rig and animation catalog]]

## Combat data libraries
- [[Systems/Attack Library|${Object.keys(attacks).length} attack notes]]
- [[Systems/Loot Table Index|${lootTables.length} loot tables]]

## Regions (${regions.length})
${groupList(regions.map(r => r.id), r => `${r.layer[0].toUpperCase()}${r.layer.slice(1)}`)}

## Monster families (${families.length} families, ${species.length} species)
${families.map(f => `- ${fam(f)} (${species.filter(s => s.family === f).length})`).join('\n')}

## Individual species by family
${groupList(species.map(s => s.id), s => s.family)}

## Population atlas (${populations.length} named forms)
Every population record is included in the complete register on its species note and its region note. Use Obsidian search for a population ID, local name, appearance, rank, level, size or spawn window; follow the linked species and region to see the broader ecology.

## Tyrants
${species.filter(s => s.isTyrant).map(s => `- ${link(s.id)} (${list(s.habitats || [])})`).join('\n') || '—'}

## People (${npcs.length})
${groupList(npcs.map(n => n.id), n => n.faction || 'Unaffiliated')}

## Clans and peoples (${(clanData.clans || []).length})
${(clanData.clans || []).map(c => `- ${link(`clan:${c.name}`, false, c.name)} — ${c.board || 'people'}`).join('\n') || 'No clan data loaded.'}

## Local fauna (${(clanData.fauna || []).length})
${(clanData.fauna || []).map(f => `- ${link(`fauna:${f.name}`, false, f.name)} — ${f.group || 'wildlife'}`).join('\n') || 'No local fauna data loaded.'}

## Quests (${quests.length})
${quests.map(q => `- ${link(q.id)} (${q.rank}, ${q.type})`).join('\n')}

## Inns (${inns.length})
${inns.map(i => `- ${link(i.id)}`).join('\n')}

## Items (${items.length})
${groupList(items.map(i => i.id), i => i.category)}
`;
notes['Home'] = home;

// ---------------------------------------------------------------- write
const write = (rel, text) => {
  const full = path.join(VAULT, rel);
  fs.mkdirSync(path.dirname(full), { recursive: true });
  fs.writeFileSync(full, text);
};
for (const d of GENERATED) fs.rmSync(path.join(VAULT, d), { recursive: true, force: true });
for (const [p, text] of Object.entries(notes)) write(`${p}.md`, text);
const shots = path.join(ROOT, '13_Production', 'screenshots');
fs.mkdirSync(path.join(VAULT, 'Assets'), { recursive: true });
fs.cpSync(shots, path.join(VAULT, 'Assets'), { recursive: true });  // includes buildings/ and cc0/ sheets

// ---------------------------------------------------------------- hand-written areas (only if missing)
const ensure = (rel, text) => { if (!fs.existsSync(path.join(VAULT, rel))) write(rel, text); };
ensure('Ideas/Idea Inbox.md', `---
tags: [index, idea]
---
# Idea Inbox

Drop rough ideas here as one-liners, or make one note per idea in this folder with the *Idea* template.
Statuses: \`raw\` → \`shaped\` → \`in the design bible\`. New lore is a **draft** until it is approved into Canon.

## Raw ideas
-
`);
ensure('Templates/Idea.md', `---
type: idea
status: raw
tags: [idea]
---
# {{title}}

**The idea in one line:**

**Why it's fun / what it adds:**

**Player moment:** what does the player see, decide, risk or feel?

**How it works:**
- Trigger / availability:
- Player choices:
- Immediate outcome:
- Long-term consequence:

**World connection:** which people, place, creature, item or system makes this feel native to Aethwyrd?

**Scope:** prototype / Ring 0 / later ring / optional

**Evidence or inspiration:**

**Risks and counterplay:** what could frustrate, confuse or trivialize it?

**Touches:** [[ ]] (regions, monsters, NPCs, quests or systems it affects)

**Canon check:** does it contradict Canon.md or Data/? Does it reveal a Canon §3 secret?

**Open questions:**
-

**Canon status:** raw ideas are proposals. Check [[Design Bible/Canon|Canon]] and the matching source data before promoting anything.

*Created {{date}}*
`);
ensure('Templates/Monster.md', `---
type: monster
status: idea
tags: [monster, idea]
---
# {{title}}

| Field | Value |
|---|---|
| Family · type | |
| Rank · level | |
| Menace | |
| Element · weakness | |
| Habitats | [[ ]] |

**Look:**

**Silhouette at gameplay camera distance:**

**Movement and habitat behavior:**

**Combat loop:** approach / tell / attack / recovery / retreat:

**Signature attack and counterplay:**

**Ecological role and reason for being here:**

**Drops and crafting use:**

**Rig, animation set and VFX:**

**Field note:**

**Trope:**

**Distinctive twist:**

**Production scope:** shared rig / new rig / elite / boss:

**Canon status and open questions:**
`);
ensure('.obsidian/app.json', JSON.stringify({ attachmentFolderPath: 'Assets', newFileLocation: 'folder',
  newFileFolderPath: 'Ideas', alwaysUpdateLinks: true }, null, 2) + '\n');
ensure('.obsidian/templates.json', JSON.stringify({ folder: 'Templates' }, null, 2) + '\n');
ensure('.obsidian/core-plugins.json', JSON.stringify(['file-explorer', 'global-search', 'switcher', 'graph', 'backlink',
  'outgoing-link', 'tag-pane', 'page-preview', 'templates', 'note-composer', 'command-palette', 'bookmarks', 'outline',
  'word-count', 'file-recovery']) + '\n');
ensure('.obsidian/graph.json', JSON.stringify({
  colorGroups: [['Monsters', 9744236], ['Regions', 15253626], ['NPCs', 7330000], ['Quests', 6935520],
    ['Design Bible', 11184810], ['Ideas', 16766720]].map(([p, rgb]) => ({ query: `path:"${p}"`, color: { a: 1, rgb } })),
  showAttachments: false, hideUnresolved: true }, null, 2) + '\n');
ensure('.gitignore', '.obsidian/workspace*.json\n.obsidian/cache\n.trash/\n');

console.log(`${Object.keys(notes).length} generated notes in ideas/`);
