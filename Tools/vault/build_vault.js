// Builds the Obsidian vault in ideas/ from Data/ and the design bible. Dependency-free (plain Node).
// Usage: node Tools/vault/build_vault.js   (or: npm run vault)
// Generated folders are wiped and rebuilt each run. Ideas/ and Templates/ are only created when
// missing, so notes written there by hand are never overwritten.
const fs = require('fs');
const path = require('path');
const ROOT = path.join(__dirname, '..', '..');
const VAULT = path.join(ROOT, 'ideas');
const load = p => JSON.parse(fs.readFileSync(path.join(ROOT, 'Data', p), 'utf8'));

const GENERATED = ['Monsters', 'Families', 'Regions', 'NPCs', 'Quests', 'Inns', 'Items', 'Classes', 'Design Bible', 'Assets'];
const BIBLE_DIRS = ['00_Questions', '01_Core_Concept', '02_Lore', '03_Rank_System', '04_Classes', '05_Skills_Magic',
  '06_Races_Origins', '07_Characters', '08_Bestiary', '09_Equipment', '10_World', '11_Quests_Encounters',
  '12_Systems', '13_Production'];

const species = load('Monsters/species.json');
const regions = load('World/regions.json');
const npcs = load('NPCs/npcs.json');
const quests = load('Quests/quests.json');
const inns = load('World/inns.json');
const items = [...load('Items/items.json'), ...load('Items/materials.json')];
const classes = load('Classes/classes.json');
// Optional world-building data (gazetteer, clans and fauna); region notes skip it when absent.
const loadOpt = p => fs.existsSync(path.join(ROOT, 'Data', p)) ? load(p) : null;
const gazetteer = (loadOpt('World/gazetteer.json') || {}).regions || {};
const clanData = loadOpt('World/clans.json') || {};
const byRegion = arr => (arr || []).reduce((m, x) => ((m[x.regionId] = m[x.regionId] || []).push(x), m), {});
const clansIn = byRegion(clanData.clans), faunaIn = byRegion(clanData.fauna);
const attacks = Object.fromEntries(load('Monsters/attacks.json').map(a => [a.id, a]));
const loot = Object.fromEntries(load('Monsters/loot_tables.json').map(l => [l.id, l]));

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
for (const i of inns) claim(i.id, 'Inns', i.name);
for (const i of items) claim(i.id, 'Items', i.name);
for (const c of classes) claim(c.id, 'Classes', c.name);
const families = [...new Set(species.map(s => s.family))].sort();
for (const f of families) notePath[`fam:${f}`] = `Families/${safe(f)}`;

const byId = Object.fromEntries([...species, ...regions, ...npcs, ...quests, ...inns, ...items, ...classes].map(x => [x.id, x]));
const label = id => (byId[id] && (byId[id].name || byId[id].title)) || id;
// inTable: escape the alias pipe so the link survives inside a Markdown table cell
const link = (id, inTable = false, text) => notePath[id]
  ? `[[${notePath[id]}${inTable ? '\\|' : '|'}${text || label(id)}]]` : (text || id);
const fam = f => `[[${notePath[`fam:${f}`]}|${f}]]`;
const list = (ids, inTable) => ids.length ? ids.map(id => link(id, inTable)).join(', ') : '—';
const row = (k, v) => (v === undefined || v === '' || v === null) ? '' : `| ${k} | ${v} |\n`;
const front = o => '---\n' + Object.entries(o).map(([k, v]) => `${k}: ${Array.isArray(v) ? `[${v.join(', ')}]` : v}`).join('\n') + '\n---\n';
const tag = s => String(s).toLowerCase().replace(/[^a-z0-9]+/g, '-').replace(/^-|-$/g, '');

// ---------------------------------------------------------------- indexes
const speciesIn = {}, npcsIn = {}, questsIn = {}, innsIn = {}, droppedBy = {}, questsBy = {}, variantsOf = {};
for (const s of species) {
  for (const r of s.habitats || []) (speciesIn[r] = speciesIn[r] || []).push(s.id);
  for (const e of (loot[s.lootTableId] || {}).entries || []) (droppedBy[e.itemId] = droppedBy[e.itemId] || []).push(s.id);
  if (s.baseSpeciesId) (variantsOf[s.baseSpeciesId] = variantsOf[s.baseSpeciesId] || []).push(s.id);
}
for (const n of npcs) (npcsIn[n.homeRegion] = npcsIn[n.homeRegion] || []).push(n.id);
for (const q of quests) {
  (questsIn[q.region] = questsIn[q.region] || []).push(q.id);
  (questsBy[q.giver] = questsBy[q.giver] || []).push(q.id);
}
for (const i of inns) (innsIn[i.regionId] = innsIn[i.regionId] || []).push(i.id);

// ---------------------------------------------------------------- notes
const notes = {}; // vault path -> text
const put = (id, text) => { notes[notePath[id]] = text; };

for (const s of species) {
  const st = s.stats || {};
  const lt = loot[s.lootTableId];
  let t = front({ type: 'monster', id: s.id, family: `"${s.family}"`, rank: `"${s.rank}"`, tier: s.tier,
    tags: ['monster', tag(s.family), ...(s.isTyrant ? ['tyrant'] : []), ...(s.isUnique ? ['unique'] : [])] });
  t += `# ${s.name}\n\n`;
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
  t += row('Habitats', list(s.habitats || [], true));
  if (s.isTyrant) t += row('Tyrant', 'Yes');
  if (s.genre) t += row('Genre', s.genre);
  if (s.trope) t += row('Trope', s.trope);
  if (s.fieldNote) t += `\n**Field note:** ${s.fieldNote}\n`;
  if ((s.attackIds || []).length) {
    t += '\n## Attacks\n\n| Attack | Kind | Power | Cooldown | Element | Telegraph |\n|---|---|---|---|---|---|\n';
    for (const id of s.attackIds) {
      const a = attacks[id] || { name: id };
      t += `| ${a.name} | ${a.kind || ''} | ${a.power ?? ''} | ${a.cooldownSec ?? ''} s | ${a.element || ''} | ${a.telegraph || ''} |\n`;
    }
  }
  if (lt) {
    t += `\n## Loot (\`${lt.id}\`)\n\n| Item | Chance | Amount |\n|---|---|---|\n`;
    for (const e of lt.entries) t += `| ${link(e.itemId, true)} | ${Math.round(e.chance * 100)}% | ${e.min}–${e.max} |\n`;
  }
  if (variantsOf[s.id]) t += `\n## Variants\n\n${variantsOf[s.id].map(id => `- ${link(id)}`).join('\n')}\n`;
  if (s.designRecipe) {
    const d = s.designRecipe;
    t += `\n## Design recipe\n\nRig \`${d.rigId}\` · mesh \`${d.baseMesh}\` · material \`${d.material}\` · VFX \`${d.vfx}\` · `
      + `palette ${(d.palette || []).map(c => `\`${c}\``).join(' ')} · ${d.menaceStyle}\n`;
  }
  put(s.id, t);
}

for (const f of families) {
  const members = species.filter(s => s.family === f).sort((a, b) => a.level - b.level);
  let t = front({ type: 'family', tags: ['family', tag(f)] }) + `# ${f}\n\n${members.length} species. Sorted by level.\n\n`;
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
  if (clansIn[r.id]) t += `\n## Clans\n\n${clansIn[r.id].map(c => `- **${c.name}** (${c.board}${c.leader ? `, led by ${c.leader}` : ''}): ${c.culture || c.look || ''}`).join('\n')}\n`;
  if (faunaIn[r.id]) t += `\n## Fauna\n\n${faunaIn[r.id].map(f => `- **${f.name}** (${f.group}): ${f.text}`).join('\n')}\n`;
  if (npcsIn[r.id]) t += `\n## People\n\n${npcsIn[r.id].map(id => `- ${link(id)}: ${byId[id].role}`).join('\n')}\n`;
  if (innsIn[r.id]) t += `\n## Inns\n\n${innsIn[r.id].map(id => `- ${link(id)} (${byId[id].settlement})`).join('\n')}\n`;
  if (questsIn[r.id]) t += `\n## Quests\n\n${questsIn[r.id].map(id => `- ${link(id)} (${byId[id].rank})`).join('\n')}\n`;
  const here = (speciesIn[r.id] || []).map(id => byId[id]).sort((a, b) => a.level - b.level);
  if (here.length) {
    t += `\n## Monsters (${here.length})\n\n| Monster | Family | Rank | Level |\n|---|---|---|---|\n`;
    for (const s of here) t += `| ${link(s.id, true)} | ${fam(s.family).replace('|', '\\|')} | ${s.rank} | ${s.level} |\n`;
  }
  put(r.id, t);
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
  if (questsBy[n.id]) t += `\n## Quests given\n\n${questsBy[n.id].map(id => `- ${link(id)}`).join('\n')}\n`;
  if (n.secret || (n.states || []).length) {
    t += '\n> [!warning]- Spoilers (Canon §3)\n';
    if (n.secret) t += `> **Secret:** ${n.secret}\n`;
    for (const s of n.states || []) t += `> **After \`${s.flag}\`:** ${s.role}. ${s.note || ''}\n`;
  }
  put(n.id, t);
}

const describe = o => o.kind === 'kill' || o.target ? `${o.kind} ${link(o.target)}${o.count ? ` ×${o.count}` : ''}` : JSON.stringify(o);
for (const q of quests) {
  let t = front({ type: 'quest', id: q.id, rank: `"${q.rank}"`, tags: ['quest', tag(q.type)] }) + `# ${q.title}\n\n> ${q.summary}\n\n`;
  t += '| Field | Value |\n|---|---|\n';
  t += row('Rank · type', `${q.rank} · ${q.type}`);
  t += row('Giver', link(q.giver, true));
  t += row('Region', link(q.region, true));
  const rw = q.rewards || {};
  t += row('Rewards', [rw.gold && `${rw.gold} gold`, rw.gp && `${rw.gp} GP`, rw.xp && `${rw.xp} XP`,
    ...(rw.items || []).map(i => link(i, true))].filter(Boolean).join(', '));
  if ((q.objectives || []).length) t += `\n## Objectives\n\n${q.objectives.map(o => `- ${describe(o)}`).join('\n')}\n`;
  put(q.id, t);
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
  if ((i.rooms || []).length) {
    t += '\n## Rooms\n\n| Room | Price (copper) | Rest | Perk |\n|---|---|---|---|\n';
    for (const r of i.rooms) t += `| ${r.name || r.tier} | ${r.priceCopper} | ${r.rest} | ${r.perk || ''} |\n`;
  }
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
  if (droppedBy[i.id]) {
    const d = droppedBy[i.id];
    t += `\n## Dropped by (${d.length})\n\n${d.slice(0, 60).map(id => `- ${link(id)}`).join('\n')}${d.length > 60 ? `\n- …and ${d.length - 60} more` : ''}\n`;
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
  const tr = trainerNpc(c.trainer || '');
  t += row('Trainer', tr ? link(tr.id, true) : c.trainer);
  t += row('Class quest', c.classQuest ? `*${c.classQuest}*` : '');
  if (c.starterWeaponId) t += row('Starter weapon', link(c.starterWeaponId, true));
  t += `\n## Kit\n\n| Lv | Skill | Kind | Hits | Cost | Cooldown | Element | Effect |\n|---|---|---|---|---|---|---|---|\n`;
  for (const k of [...c.kit].sort((a, b) => a.unlockLevel - b.unlockLevel))
    t += `| ${k.unlockLevel} | **${k.name}**${k.slot === 'basic' ? ' (basic)' : ''} | ${k.kind} | ${hitsOf(k)} | ${costOf(k)} | ${k.cooldownSec ? `${k.cooldownSec} s` : '—'} | ${k.element} | ${k.effect || ''} |\n`;
  if ((c.passives || []).length)
    t += `\n## Passives\n\n${c.passives.map(p => `- **${p.name}** (Lv ${p.unlockLevel}): ${p.effect}`).join('\n')}\n`;
  put(c.id, t);
}

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
let home = front({ tags: ['index'] }) + `# Aetheria Ideas

The Project Ascend idea vault. Open this \`ideas/\` folder in Obsidian (*Open folder as vault*).

- **Write new ideas** in the \`Ideas\` folder, starting from [[Idea Inbox]]. Use the *Idea* template. The build never touches \`Ideas/\` or \`Templates/\`.
- **Everything else is generated** from \`Data/\` and the design bible by \`npm run vault\`
  (\`Tools/vault/build_vault.js\`). Change the data or the design bible, then rebuild; edits made directly to generated notes are overwritten.
- [[Design Bible/Canon|Canon]] wins any conflict on story; \`Data/\` wins on numbers. NPC secrets sit in collapsed spoiler callouts.

## Design bible
${bible.map(p => `- [[${p}|${p.replace('Design Bible/', '')}]]`).join('\n')}

## Classes (${classes.length})
${classes.map(c => `- ${link(c.id)}: ${c.role}`).join('\n')}

## Regions (${regions.length})
${groupList(regions.map(r => r.id), r => `${r.layer[0].toUpperCase()}${r.layer.slice(1)}`)}

## Monster families (${families.length} families, ${species.length} species)
${families.map(f => `- ${fam(f)} (${species.filter(s => s.family === f).length})`).join('\n')}

## Tyrants
${species.filter(s => s.isTyrant).map(s => `- ${link(s.id)} (${list(s.habitats || [])})`).join('\n') || '—'}

## People (${npcs.length})
${groupList(npcs.map(n => n.id), n => n.faction || 'Unaffiliated')}

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
for (const f of fs.readdirSync(shots)) fs.copyFileSync(path.join(shots, f), path.join(VAULT, 'Assets', f));

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

**Touches:** [[ ]] (regions, monsters, NPCs, quests or systems it affects)

**Canon check:** does it contradict Canon.md or Data/? Does it reveal a Canon §3 secret?

**Open questions:**
-

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

**Field note:**

**Trope:**
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
