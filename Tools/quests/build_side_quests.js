// Builds Data/ rows from the side-quest design docs.
//   node Tools/quests/build_side_quests.js
// Reads 11_Quests_Encounters/side_quests/*.md. Each quest and each supporting NPC carries a hidden
// <!-- quest ... --> or <!-- npc ... --> block (key: value lines). The script merges them into
// Data/Quests/quests.json, Data/Quests/story_flags.json and Data/NPCs/npcs.json: rows whose id
// appears in a doc are replaced, everything else is left alone. Run `npm run validate` afterwards.
'use strict';
const fs = require('fs');
const path = require('path');

const ROOT = path.resolve(__dirname, '..', '..');
const DOCS = path.join(ROOT, '11_Quests_Encounters', 'side_quests');
const read = f => JSON.parse(fs.readFileSync(path.join(ROOT, f), 'utf8'));
const write = (f, v) => fs.writeFileSync(path.join(ROOT, f), JSON.stringify(v, null, 1) + '\n');

const RANKS = new Set(['F', 'E', 'D', 'C', 'B', 'A', 'S', 'SS', 'SSS']);
const KINDS = new Set(['kill', 'collect', 'talk', 'escort', 'reach', 'defend', 'tame', 'choice']);
const TYPES = new Set(['Main', 'Subjugation', 'Gathering', 'Escort', 'Delivery', 'Investigation', 'Exploration', 'Defense',
  'SiegeDefence', 'Capture', 'Bounty', 'Dungeon', 'OddJob', 'Trial', 'Faction', 'Companion', 'Class', 'Hidden', 'Divine']);
const errors = [];
const err = (where, msg) => errors.push(`${where}: ${msg}`);

function parseBlock(text) {
  const out = {}; let key = null;
  for (const raw of text.split('\n')) {
    const line = raw.replace(/\s+$/, '');
    if (!line.trim()) continue;
    const m = /^([a-z_]+):\s*(.*)$/.exec(line);
    if (m && !/^\s/.test(line)) { key = m[1]; out[key] = m[2]; if (key === 'objectives') out[key] = []; }
    else if (key === 'objectives') out.objectives.push(line.trim());
    else if (key) out[key] += ' ' + line.trim();
  }
  return out;
}
const list = s => (s || '').split(/[;,]/).map(x => x.trim()).filter(Boolean);

function parseObjective(line, where) {
  const t = line.split(/\s+/); const kind = t[0];
  if (!KINDS.has(kind)) { err(where, `unknown objective kind "${kind}"`); return null; }
  const o = { kind, target: t[1] };
  for (const x of t.slice(2)) {
    if (/^\d+$/.test(x)) o.count = parseInt(x, 10);
    else if (x.startsWith('from:')) o.from = x.slice(5);
    else err(where, `bad objective token "${x}"`);
  }
  if (!o.target) err(where, `objective "${line}" has no target`);
  return o;
}

const quests = [], npcs = [], flagsSet = [];
for (const f of fs.existsSync(DOCS) ? fs.readdirSync(DOCS).filter(f => f.endsWith('.md')).sort() : []) {
  const text = fs.readFileSync(path.join(DOCS, f), 'utf8');
  const re = /<!--\s*(quest|npc)\s*\n([\s\S]*?)-->/g; let m;
  while ((m = re.exec(text))) {
    const b = parseBlock(m[2]); const where = `${f}:${b.id || '?'}`;
    if (m[1] === 'npc') {
      for (const k of ['id', 'name', 'tier', 'region', 'role', 'backstory']) if (!b[k]) err(where, `npc missing ${k}`);
      const n = { id: b.id, name: b.name, tier: b.tier, race: b.race || 'Human', homeRegion: b.region, settlement: b.settlement || undefined,
        role: b.role, backstory: b.backstory };
      if (b.secret) n.secret = b.secret;
      if (b.faction) n.faction = b.faction;
      n.romanceable = b.romanceable === 'true'; n.canDie = b.candie !== 'false' && b.can_die !== 'false';
      if (b.rel) n.relationships = list(b.rel).map(r => { const [npcId, kind] = r.split('='); return { npcId: npcId.trim(), kind: (kind || '').trim() }; });
      npcs.push(JSON.parse(JSON.stringify(n)));
    } else {
      for (const k of ['id', 'title', 'rank', 'type', 'giver', 'region', 'level', 'reward', 'summary', 'objectives']) if (!b[k] || (k === 'objectives' && !b[k].length)) err(where, `quest missing ${k}`);
      if (!RANKS.has(b.rank)) err(where, `bad rank ${b.rank}`);
      if (!TYPES.has(b.type)) err(where, `bad type ${b.type}`);
      const [gold, gp, xp, ...items] = (b.reward || '').split('|').map(x => x.trim());
      const q = { id: b.id, title: b.title, rank: b.rank, type: b.type, giver: b.giver, region: b.region };
      if (b.region_state) q.regionState = b.region_state;
      q.summary = b.summary;
      q.requirements = { minLevel: parseInt(b.level, 10) }; if (b.party) q.requirements.partySize = b.party;
      q.objectives = (b.objectives || []).map(l => parseObjective(l, where)).filter(Boolean);
      q.rewards = { gold: parseInt(gold, 10) || 0, gp: parseInt(gp, 10) || 0, xp: parseInt(xp, 10) || 0 };
      const it = items.flatMap(list); if (it.length) q.rewards.items = it;
      const pre = {};
      if (b.requires_quests) pre.quests = list(b.requires_quests);
      if (b.requires_flags) pre.flags = list(b.requires_flags);
      if (b.act) pre.act = parseInt(b.act, 10);
      if (b.requires_rank) pre.rank = b.requires_rank;
      if (Object.keys(pre).length) q.prerequisites = pre;
      if (b.sets) { q.setsFlags = list(b.sets); for (const fl of q.setsFlags) flagsSet.push({ id: fl, title: b.title }); }
      quests.push(q);
    }
  }
}

const dup = (rows, what) => { const s = new Set(); for (const r of rows) { if (s.has(r.id)) err(r.id, `duplicate ${what} id in docs`); s.add(r.id); } };
dup(quests, 'quest'); dup(npcs, 'npc');
if (errors.length) { console.error(errors.join('\n')); process.exit(1); }

function merge(file, rows) {
  const have = read(file); const ids = new Set(rows.map(r => r.id));
  const kept = have.filter(r => !ids.has(r.id));
  write(file, kept.concat(rows)); return rows.length;
}
const nq = merge('Data/Quests/quests.json', quests);
const nn = merge('Data/NPCs/npcs.json', npcs);
const flags = read('Data/Quests/story_flags.json'); const haveF = new Set(flags.map(f => f.id)); let nf = 0;
for (const { id, title } of flagsSet) if (!haveF.has(id)) {
  haveF.add(id); nf++;
  flags.push({ id, description: id.startsWith('clue_') ? `Clue found in "${title}"` : `Side quest "${title}" resolved`, setBy: 'quest' });
}
write('Data/Quests/story_flags.json', flags);
console.log(`Side quests: ${nq} quests · ${nn} NPCs · ${nf} new flags (from ${fs.existsSync(DOCS) ? fs.readdirSync(DOCS).filter(f => f.endsWith('.md')).length : 0} docs)`);
