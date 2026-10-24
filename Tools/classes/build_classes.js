// Builds Data/Classes/classes.json for the 12 base classes from 04_Classes/base_and_advanced.md.
// Skill names, unlock levels, mechanics, trainers and quests come from the doc. Hit data and costs are a
// first-pass tuning on the Swordsman's scale (keep in step with combat_tuning.json):
//   light 0.6-1.0 · medium 1.2-1.6 · heavy 1.8-2.4 · launch ~1.2 · AoE hits ×0.7 per target · ultimates ≈ 6-8 total.
//   Physical classes pay SP, casters pay MP, ultimates cost 100 Awakening.
// Where the doc lists names without levels, levels follow the doc's cadence: 1,1,1,4,7,10,14,18,22, ULT 30.
// A class whose doc kit has no combo string gets a weapon basic string, marked "(added: basic string)".
// Existing Swordsman kit entries are kept verbatim (tests and the Unity combat rely on them).
// Run: node Tools/classes/build_classes.js   (part of `npm run build` via validate)
const fs = require('fs');
const path = require('path');
const ROOT = path.join(__dirname, '..', '..');
const CLASSES = path.join(ROOT, 'Data', 'Classes', 'classes.json');
const ITEMS = path.join(ROOT, 'Data', 'Items', 'items.json');

const W = { l: 'light', m: 'medium', h: 'heavy', L: 'launch', u: 'ultimate', s: 'skill' };
/** "0.8l,0.8l,1.4m" or "0.6l*11,3u" → hit list */
const hits = spec => !spec ? [] : spec.split(',').flatMap(part => {
  const m = part.trim().match(/^([\d.]+)([lmhLus])(?:\*(\d+))?$/);
  if (!m) throw new Error(`bad hit spec "${part}"`);
  return Array.from({ length: m[3] ? +m[3] : 1 }, () => ({ power: +m[1], weight: W[m[2]] }));
});
const slug = s => s.toLowerCase().replace(/\(.*?\)/g, '').replace(/[^a-z0-9]+/g, '_').replace(/^_|_$/g, '');
const STATS = ['str', 'vit', 'agi', 'dex', 'int', 'wis', 'luk', 'cha'];
const growthOf = g => Object.fromEntries(g.split('/').map((v, i) => [STATS[i], +v]));
/** Recommended free-point split: the class's growth weights, normalised to sum to 1 (2 decimals). */
function allocationOf(growth) {
  const keys = STATS.filter(k => growth[k] > 0), total = keys.reduce((a, k) => a + growth[k], 0);
  const a = Object.fromEntries(keys.map(k => [k, Math.round(growth[k] / total * 100) / 100]));
  const top = keys.reduce((x, k) => growth[k] > growth[x] ? k : x, keys[0]);
  a[top] = Math.round((a[top] + 1 - Object.values(a).reduce((s, v) => s + v, 0)) * 100) / 100;
  return a;
}

// Skill row: [name, level, kind, hits, cost, cooldownSec, element, effect]   kind 'passive' → [name, level, 'passive', effect]
// cost: 'sp10' | 'mp8' | 'aw100' | ''
const DEF = [
  {
    id: 'swordsman', name: 'Swordsman', role: 'Balanced melee DPS', growth: '3/2/3/2/0/0/1/1',
    weapons: 'Sword, Greatsword, Dual Swords, Katana', armor: 'Light, Medium',
    mechanic: 'Edge Flow: consecutive hits without being struck build Flow (0-5), each stack +6% attack speed; getting hit drops 2 stacks',
    trainer: 'Old Hollis', classQuest: 'A Thousand Swings', starter: null,
    skills: [
      ['Guard Break', 1, 'chain', '2.0h', 'sp8', 5, 'None', 'Heavy overhead; breaks blocks'],
      ['Sword Mastery', 1, 'passive', '+damage and attack speed per mastery level'],
      ['Sidestep', 6, 'passive', 'A perfect dodge grants a free counter-slash'],
      ['Whirlwind', 9, 'aoe', '0.7m*3', 'sp14', 7, 'None', 'Spinning AoE'],
      ['Fighting Spirit', 15, 'passive', 'Low HP grants +crit chance'],
      ['Parry Riposte', 22, 'chain', '2.4h', 'sp12', 8, 'None', 'Parry window into a heavy counter'],
    ],
  },
  {
    id: 'guardian', name: 'Guardian', role: 'Tank / protector', growth: '3/4/1/1/0/1/0/0',
    weapons: '1H Sword, Mace, Shield, Tower Shield, Lance', armor: 'Medium, Heavy',
    mechanic: 'Bulwark: blocking fills Bulwark; spend it on counters or a team shield',
    trainer: 'Captain Bryndis Oakshield', classQuest: 'The Bridge at Millbrook',
    starter: ['itm_guild_issue_mace', 'Guild Issue Mace & Buckler', { atk: 6, def: 4 }, 'Heavy enough to matter, light enough to lift all day.'],
    skills: [
      ['Shield Combo', 1, 'chain', '0.7l,0.8l,1.3m', '', 0, 'None', 'Mace-and-shield string (added: basic string)', 'basic'],
      ['Shield Bash', 1, 'chain', '1.0m', 'sp8', 5, 'None', 'Stun'],
      ['Provoke', 1, 'utility', '', 'sp6', 10, 'None', 'Taunt nearby enemies'],
      ['Iron Skin', 1, 'passive', 'Passive defense'],
      ['Shield Wall', 4, 'buff', '', '', 0, 'None', 'Frontal invulnerable block (drains stamina)'],
      ['Retaliate', 7, 'passive', 'A perfect block reflects damage'],
      ["Guardian's Oath", 10, 'buff', '', 'sp10', 20, 'None', 'Link to an ally; take 30% of their damage'],
      ['Earth Stomp', 14, 'aoe', '1.1m', 'sp14', 9, 'Earth', 'AoE stagger'],
      ['Last Stand', 18, 'passive', 'Below 20% HP, damage reduction ×2'],
      ['Charge', 22, 'dash', '1.5m', 'sp12', 8, 'None', 'Shield charge through a line'],
      ['Aegis of the Unbroken', 30, 'ultimate', '', 'aw100', 0, 'Light', 'Giant mana shield dome for the party, 8 s'],
    ],
  },
  {
    id: 'mage', name: 'Mage', role: 'Ranged elemental DPS / control', growth: '0/1/1/1/4/3/0/0',
    weapons: 'Staff, Wand, Grimoire, Orb', armor: 'Cloth',
    mechanic: 'Chant: hold to chant longer for stronger tiers of the same spell (Basic, Intermediate, Advanced); being interrupted causes backlash',
    trainer: 'Magistra Eolande Fairweather', classQuest: 'Words of Weave',
    starter: ['itm_guild_issue_staff', 'Guild Issue Staff', { matk: 8 }, 'The crystal is glass. The intent is real.'],
    skills: [
      ['Arcane Bolts', 1, 'chain', '0.6l,0.6l,1.0m', '', 0, 'None', 'Three quick mana bolts (added: basic string)', 'basic'],
      ['Fire Bolt', 1, 'ranged', '1.2m', 'mp6', 2, 'Fire', 'Element starter (choose one affinity)', null, true],
      ['Water Lance', 1, 'ranged', '1.1m', 'mp6', 2, 'Water', 'Element starter (choose one affinity)', null, true],
      ['Wind Cutter', 1, 'ranged', '0.6l*2', 'mp6', 2, 'Wind', 'Element starter (choose one affinity)', null, true],
      ['Stone Bullet', 1, 'ranged', '1.3m', 'mp6', 2.5, 'Earth', 'Element starter (choose one affinity)', null, true],
      ['Mana Shield', 1, 'buff', '', 'mp10', 12, 'None', 'MP absorbs damage'],
      ['Arcane Insight', 1, 'passive', 'See enemy elements'],
      ['Second Element', 5, 'passive', "Learn a second element's starter"],
      ['Frost Nova', 8, 'aoe', '0.9m', 'mp14', 10, 'Ice', 'Freeze nearby enemies', null, true],
      ['Chain Lightning', 11, 'ranged', '0.8l*4', 'mp16', 7, 'Lightning', 'Bounces between enemies', null, true],
      ['Blink', 14, 'utility', '', 'mp8', 5, 'None', 'Short teleport'],
      ['Fireball', 17, 'aoe', '2.0h', 'mp24', 9, 'Fire', 'Big AoE explosion (the true Fireball)', null, true],
      ['Mana Surge', 21, 'passive', 'MP regeneration boost'],
      ['Elemental Cataclysm', 30, 'ultimate', '1.0m*4,3.5u', 'aw100', 0, 'None', 'Massive tier-3 spell of your main element'],
    ],
  },
  {
    id: 'cleric', name: 'Cleric', role: 'Healer / support', growth: '0/2/0/1/1/4/1/1',
    weapons: 'Mace, Holy Tome, Censer, Staff', armor: 'Cloth, Light, Medium',
    mechanic: 'Devotion: choose a patron god at class start; spells change flavour (Solenne holy fire, Sylvara vines and regen, Morrowyn spirit lanterns)',
    trainer: 'Sister Pell', classQuest: 'The Fevered Village',
    starter: ['itm_guild_issue_censer', 'Guild Issue Censer', { matk: 5, mdef: 3 }, 'Smells of cheap incense and good intentions.'],
    skills: [
      ['Censer Swings', 1, 'chain', '0.6l,0.7l,1.0m', '', 0, 'Light', 'Censer string (added: basic string)', 'basic'],
      ['Heal', 1, 'buff', '', 'mp8', 2, 'Light', 'Restore an ally’s HP'],
      ['Blessing', 1, 'buff', '', 'mp10', 15, 'Light', 'Party buff from your patron god'],
      ['Purify', 1, 'utility', '', 'mp6', 6, 'Light', 'Remove a status effect'],
      ['Holy Light', 4, 'ranged', '1.2m', 'mp8', 3, 'Light', 'Beam of holy light', null, true],
      ['Sanctuary', 7, 'buff', '', 'mp18', 20, 'Light', 'Healing zone'],
      ['Group Heal', 10, 'buff', '', 'mp20', 10, 'Light', 'Heal the whole party'],
      ['Revive', 14, 'utility', '', 'mp30', 0, 'Light', 'Revive a fallen ally (out of combat)'],
      ['Smite Undead', 18, 'ranged', '2.2h', 'mp16', 8, 'Light', 'Heavy holy damage, ×2 to undead', null, true],
      ['Divine Ward', 22, 'buff', '', 'mp20', 25, 'Light', 'Shield the party from the next hit'],
      ['Miracle', 30, 'ultimate', '', 'aw100', 0, 'Light', 'Full party heal and revive'],
    ],
  },
  {
    id: 'rogue', name: 'Rogue', role: 'Stealth, burst crits, utility', growth: '1/1/4/3/0/0/2/0',
    weapons: 'Daggers, Short Sword, Throwing Knives', armor: 'Light',
    mechanic: 'Shadow: in stealth, the first strike is a guaranteed crit for ×2 damage; kills from stealth refund some stealth',
    trainer: 'Nobody', classQuest: "The Mayor's Ledger",
    starter: ['itm_guild_issue_daggers', 'Guild Issue Daggers', { atk: 6, crit: 0.03 }, 'A matched pair. Mostly matched.'],
    skills: [
      ['Dagger Flurry', 1, 'chain', '0.5l,0.5l,0.6l,1.2m', '', 0, 'None', 'Four quick stabs (added: basic string)', 'basic'],
      ['Backstab', 1, 'chain', '2.2h', 'sp8', 6, 'None', 'Massive damage from behind'],
      ['Stealth', 1, 'utility', '', 'sp10', 8, 'None', 'Vanish from sight'],
      ['Steal', 1, 'utility', '', 'sp4', 4, 'None', 'Pick an enemy’s pocket'],
      ['Lockpick', 4, 'passive', 'Open locked chests and doors'],
      ['Smoke Bomb', 7, 'utility', '', 'sp10', 14, 'None', 'Blind the area and slip away'],
      ['Poison Blade', 10, 'buff', '', 'sp10', 18, 'Poison', 'Coat blades in poison', null, true],
      ['Shadow Step', 14, 'dash', '1.4m', 'sp12', 7, 'Dark', 'Teleport behind a target and strike'],
      ['Disarm Trap', 18, 'passive', 'Disarm and reuse traps'],
      ['Fan of Knives', 22, 'aoe', '0.6l*3', 'sp14', 8, 'None', 'Knives in every direction'],
      ['Death Lotus', 30, 'ultimate', '0.7m*8,2.5u', 'aw100', 0, 'Dark', 'Teleport between 8 enemies'],
    ],
  },
  {
    id: 'ranger', name: 'Ranger', role: 'Ranged physical, tracking, traps', growth: '1/1/3/4/0/1/1/0',
    weapons: 'Shortbow, Longbow, Crossbow', armor: 'Light, Medium',
    mechanic: 'Focus: aim down sights to build Focus; release at max for Pierce shots that ignore armour',
    trainer: 'Wren Ashbourne', classQuest: 'The White Stag',
    starter: ['itm_guild_issue_bow', 'Guild Issue Shortbow', { atk: 7 }, 'The string is new. The bow remembers other hands.'],
    skills: [
      ['Quick Shots', 1, 'chain', '0.6l,0.6l,1.1m', '', 0, 'None', 'Three rapid arrows (added: basic string)', 'basic'],
      ['Power Shot', 1, 'ranged', '1.8h', 'sp8', 5, 'None', 'A drawn, heavy arrow'],
      ['Multishot', 1, 'ranged', '0.7l*3', 'sp10', 6, 'None', 'Three arrows in a fan'],
      ['Tracking', 1, 'passive', 'See footprints and trails'],
      ['Snare Trap', 4, 'utility', '', 'sp8', 10, 'None', 'Root the first enemy that steps in'],
      ['Rain of Arrows', 7, 'aoe', '0.5l*5', 'sp16', 10, 'None', 'Arrows fall over an area'],
      ['Explosive Arrow', 10, 'ranged', '1.6m', 'sp14', 8, 'Fire', 'Arrow that bursts on impact', null, true],
      ['Camouflage', 14, 'utility', '', 'sp10', 15, 'None', 'Blend in while still'],
      ['Eagle Eye', 18, 'passive', 'Longer range and weak-point highlights'],
      ['Backflip Shot', 22, 'dash', '1.4m', 'sp10', 6, 'None', 'Leap back and fire'],
      ['Starfall Volley', 30, 'ultimate', '0.5l*12,2.5u', 'aw100', 0, 'Light', 'A volley of star-arrows'],
    ],
  },
  {
    id: 'tamer', name: 'Tamer', role: 'Pet/summon control', growth: '0/1/1/1/1/2/1/4',
    weapons: 'Whip, Rod, Flute, Bell', armor: 'Cloth, Light',
    mechanic: 'Bond Slots: 1 active pet at F, 2 at D, 3 at B; pets share your XP and evolve',
    trainer: 'Granny Mabel', classQuest: "Mochi's Friends",
    starter: ['itm_guild_issue_whip', 'Guild Issue Whip', { atk: 5, cha: 1 }, 'Mostly for making a noise. Monsters respect a good noise.'],
    skills: [
      ['Whip Lashes', 1, 'chain', '0.6l,0.6l,1.0m', '', 0, 'None', 'Whip string; pets follow up (added: basic string)', 'basic'],
      ['Tame', 1, 'utility', '', 'sp10', 3, 'None', 'Begin a taming encounter'],
      ['Command', 1, 'utility', '', '', 1, 'None', 'Order your pet to attack, guard or fetch'],
      ['Pet Heal', 1, 'buff', '', 'mp8', 6, 'Nature', 'Heal your pet'],
      ['Swap', 4, 'utility', '', '', 3, 'None', 'Swap the active pet'],
      ['Feral Link', 7, 'utility', '', 'mp6', 20, 'None', 'Share senses with your pet'],
      ['Rally', 10, 'buff', '', 'sp12', 20, 'None', 'Pets gain attack and speed'],
      ['Evolution Catalyst', 14, 'passive', 'Pets evolve sooner'],
      ['Unison Attack', 18, 'chain', '1.0m*2,1.6h', 'sp16', 10, 'None', 'You and your pet strike together'],
      ['Grand Menagerie', 30, 'ultimate', '0.8m*6,2.5u', 'aw100', 0, 'None', 'All stored pets attack at once'],
    ],
  },
  {
    id: 'artisan', name: 'Artisan', role: 'Crafter / gadgeteer / utility', growth: '1/1/1/4/2/1/1/0',
    weapons: 'Hammer, Wrench, Tool Staff, Throwables', armor: 'Light, Medium',
    mechanic: 'Gadgets: deploy crafted turrets, traps and bombs; crafting quality boosts them',
    trainer: 'Brannoc Emberfist', classQuest: 'The Perfect Nail',
    starter: ['itm_guild_issue_hammer', 'Guild Issue Smithing Hammer', { atk: 7 }, 'Drives nails. Also goblins.'],
    skills: [
      ['Hammer Strikes', 1, 'chain', '0.8l,0.8l,1.5m', '', 0, 'None', 'Hammer string (added: basic string)', 'basic'],
      ['Appraise', 1, 'utility', '', '', 1, 'None', 'Read an item’s quality and traits'],
      ['Field Repair', 1, 'utility', '', 'sp6', 10, 'None', 'Restore gear durability'],
      ['Bomb Toss', 1, 'aoe', '1.2m', 'sp8', 5, 'Fire', 'Thrown bomb'],
      ['Deploy Turret', 4, 'ranged', '0.4l*8', 'sp14', 18, 'None', 'A turret that fires on its own'],
      ['Reinforce Armor', 7, 'buff', '', 'sp10', 20, 'None', 'Raise an ally’s defense'],
      ['Overclock', 10, 'buff', '', 'sp12', 25, 'Lightning', 'Gadgets fire faster'],
      ['Salvage', 14, 'passive', 'Extra materials from defeated constructs and wrecks'],
      ['Masterwork Strike', 18, 'chain', '2.3h', 'sp14', 9, 'None', 'A perfectly placed blow'],
      ['Grand Invention', 30, 'ultimate', '1.2m*4,3u', 'aw100', 0, 'None', 'A giant temporary golem'],
    ],
  },
  {
    id: 'lancer', name: 'Lancer', role: 'Mid-range melee, aerial, mobility', growth: '3/2/3/2/0/0/1/1',
    weapons: 'Spear, Lance, Halberd, Glaive, Naginata, Trident', armor: 'Medium, Heavy',
    mechanic: 'Momentum: moving builds Momentum; charge thrusts and leaps spend it; max Momentum unlocks a cinematic piercing dash',
    trainer: 'Sergeant Odessa Vale', classQuest: 'The Bridge of Spears',
    starter: ['itm_guild_issue_spear', 'Guild Issue Spear', { atk: 8 }, 'Long enough to keep a goblin honest.'],
    skills: [
      ['Spear Thrusts', 1, 'chain', '0.7l,0.7l,0.9l,1.4m', '', 0, 'None', 'Reaching thrust string (added: basic string)', 'basic'],
      ['Piercing Thrust', 1, 'chain', '1.5m', 'sp8', 4, 'None', 'Long-reach poke, armour-piercing'],
      ['Sweep', 1, 'aoe', '1.0m', 'sp8', 6, 'None', '180° knockdown'],
      ['Polearm Mastery', 1, 'passive', '+damage and reach per mastery level'],
      ['Vault', 5, 'launcher', '1.0L', 'sp10', 5, 'None', 'Pole-vault into the air for aerial combos'],
      ['Impale', 9, 'chain', '1.8h', 'sp12', 8, 'None', 'Pin an enemy to the ground'],
      ['Whirling Guard', 13, 'buff', '', 'sp10', 10, 'None', 'Spin to deflect projectiles'],
      ['Dragon Ascent', 17, 'launcher', '0.6l*3,1.2L', 'sp14', 8, 'Wind', 'Rising spiral launcher'],
      ['Comet Dive', 21, 'aoe', '2.2h', 'sp16', 9, 'None', 'Plunging attack from the air'],
      ['Heaven-Piercing Spear', 30, 'ultimate', '4.0u,3.0u', 'aw100', 0, 'Light', 'A spear of light that pierces the whole screen'],
    ],
  },
  {
    id: 'martial_artist', name: 'Martial Artist', role: 'Ultra-fast melee combos, juggles', growth: '3/2/4/2/0/1/0/0',
    weapons: 'Fists, Knuckles, Gauntlets, Greaves, Bo Staff', armor: 'Light, Cloth',
    mechanic: 'Combo Chain: every consecutive hit raises the chain; at 30/60/100 hits you unlock finisher tiers',
    trainer: 'Master Lio Shan', classQuest: 'Carry the Water',
    starter: ['itm_guild_issue_wraps', 'Guild Issue Hand Wraps', { atk: 5, spd: 4 }, 'Cloth, tape and a strong suggestion.'],
    skills: [
      ['Jab Flurry', 1, 'chain', '0.4l,0.4l,0.4l,0.5l,1.0m', '', 0, 'None', 'Rapid strikes', 'basic'],
      ['Rising Uppercut', 1, 'launcher', '1.2L', 'sp8', 4, 'None', 'Launcher'],
      ['Iron Body', 1, 'passive', 'Passive defense'],
      ['Air Combo', 5, 'chain', '0.5l*4,1.0m', 'sp12', 6, 'None', 'Juggle in the air'],
      ['Palm Blast', 9, 'ranged', '1.6m', 'sp12', 6, 'None', 'Ki shockwave'],
      ['Flash Kick', 13, 'dash', '1.5m', 'sp12', 6, 'Wind', 'Teleport kick'],
      ['Counter Stance', 17, 'chain', '0.6l*3,1.6h', 'sp14', 9, 'None', 'Parry into an automatic combo'],
      ['Hundred Fists', 21, 'chain', '0.25l*16,1.4m', 'sp18', 10, 'None', 'Barrage'],
      ['Heavenfall Fist', 30, 'ultimate', '1.0m*3,4.5u', 'aw100', 0, 'None', 'A giant ki fist from the sky'],
    ],
  },
  {
    id: 'bard', name: 'Bard', role: 'Support / buffer / crowd control / charm', growth: '0/1/2/2/2/1/1/4',
    weapons: 'Lute, Flute, Harp, War Drum, Violin Blade', armor: 'Light, Cloth',
    mechanic: 'Rhythm: songs are played as rhythm inputs synced to the music; on-beat attacks deal bonus damage and songs stack party buffs',
    trainer: 'Rosalind "Rosie" Quill', classQuest: 'Encore at the Sleeping Griffon',
    starter: ['itm_guild_issue_lute', 'Guild Issue Lute', { matk: 5, cha: 2 }, 'Three strings in tune. The fourth has opinions.'],
    skills: [
      ['Chord Strikes', 1, 'chain', '0.6l,0.6l,1.0m', '', 0, 'None', 'On-beat strikes with the instrument (added: basic string)', 'basic'],
      ['Ballad of Courage', 1, 'buff', '', 'mp10', 15, 'None', 'Party ATK buff'],
      ['Sour Note', 1, 'ranged', '1.0m', 'mp4', 2, 'None', 'Sound projectile'],
      ['Soothing Melody', 1, 'buff', '', 'mp10', 12, 'None', 'Small party regeneration'],
      ['Lullaby', 5, 'utility', '', 'mp12', 15, 'None', 'Put enemies to sleep'],
      ['Song of Swiftness', 9, 'buff', '', 'mp12', 18, 'Wind', 'Party haste'],
      ['Dissonance', 13, 'aoe', '0.6l', 'mp14', 12, 'None', 'Confuse enemies'],
      ['Charm Serenade', 17, 'utility', '', 'mp18', 25, 'None', 'Turn a monster temporarily friendly'],
      ['Requiem', 21, 'aoe', '2.0h', 'mp20', 12, 'Light', 'Heavy damage to undead', null, true],
      ['Grand Finale', 30, 'ultimate', '0.8m*4,2.0u', 'aw100', 0, 'None', 'A concert-stage domain; the battle music becomes your song; massive party buffs'],
    ],
  },
  {
    id: 'occultist', name: 'Occultist', role: 'Dark caster: curses, summons, life drain', growth: '0/1/1/1/4/2/0/1',
    weapons: 'Grimoire, Ritual Dagger, Bone Staff, Censer', armor: 'Cloth',
    mechanic: 'Corruption Pool: dark spells fill your corruption meter; high corruption makes spells stronger but drains HP; purge it with a burst spell',
    trainer: 'Madame Esmerelda Grey', classQuest: 'The Seventh Candle',
    starter: ['itm_guild_issue_grimoire', 'Unmarked Grimoire', { matk: 8 }, 'The guild sells it without asking what you will write in it.'],
    skills: [
      ['Hex Bolts', 1, 'chain', '0.6l,0.6l,1.0m', '', 0, 'Dark', 'Three dark bolts (added: basic string)', 'basic'],
      ['Shadow Bolt', 1, 'ranged', '1.3m', 'mp6', 2, 'Dark', 'Dark projectile', null, true],
      ['Hex', 1, 'ranged', '0.3l*6', 'mp8', 6, 'Dark', 'Damage-over-time curse', null, true],
      ['Dark Pact', 1, 'utility', '', '', 10, 'Dark', 'Trade HP for MP'],
      ['Summon Shade', 5, 'utility', '', 'mp16', 20, 'Dark', 'A shadow minion fights for you'],
      ['Life Drain', 9, 'ranged', '0.4l*5', 'mp14', 8, 'Dark', 'Channelled heal-steal', null, true],
      ['Curse of Frailty', 13, 'utility', '', 'mp12', 15, 'Dark', 'Lower an enemy’s defense'],
      ['Bone Prison', 17, 'aoe', '0.8m', 'mp18', 14, 'Dark', 'Root enemies in bone'],
      ['Soul Harvest', 21, 'passive', 'Kills restore MP'],
      ['Night Without Dawn', 30, 'ultimate', '0.6l*6,4.0u', 'aw100', 0, 'Dark', 'A field of darkness; all curses detonate'],
    ],
  },
];

const listOf = s => s.split(',').map(x => slug(x.trim()));
const existing = JSON.parse(fs.readFileSync(CLASSES, 'utf8'));
const oldById = Object.fromEntries(existing.map(c => [c.id, c]));
const items = JSON.parse(fs.readFileSync(ITEMS, 'utf8'));
const itemIds = new Set(items.map(i => i.id));

const out = DEF.map(d => {
  const id = `cls_${d.id}`, old = oldById[id];
  const growth = growthOf(d.growth);
  const kit = old ? [...old.kit] : [], passives = [];
  const have = new Set(kit.map(k => k.name));
  for (const row of d.skills) {
    const [name, lv, kind] = row;
    if (kind === 'passive') { passives.push({ id: `psv_${slug(name)}`, name, unlockLevel: lv, effect: row[3] }); continue; }
    if (have.has(name)) continue;
    const [, , , spec, cost, cd, element, effect, slotOverride, applies] = row;
    const s = { id: `skl_${slug(name)}`, name, unlockLevel: lv, kind, slot: slotOverride || (kind === 'ultimate' ? 'ultimate' : 'skill'), effect, hits: hits(spec) };
    const m = (cost || '').match(/^(sp|mp|aw)(\d+)$/);
    if (m) s[{ sp: 'costSp', mp: 'costMp', aw: 'costAwakening' }[m[1]]] = +m[2];
    s.cooldownSec = cd; s.element = element;
    if (applies) s.appliesElement = true;
    kit.push(s);
  }
  if (d.starter && !itemIds.has(d.starter[0])) {
    const [iid, iname, stats, flavor] = d.starter;
    // Weapon type: the class weapon named in the item ("Guild Issue Censer" → censer), else the class's first weapon.
    const kinds = listOf(d.weapons);
    const weaponType = kinds.find(k => iname.toLowerCase().includes(k.replace(/_/g, ' '))) || kinds[0];
    items.push({ id: iid, name: iname, category: 'weapon', rank: 'F', rarity: 'Common', slot: 'main_hand', weaponType, value: 20, stats, flavor });
    itemIds.add(iid);
  }
  return {
    id, name: d.name, tier: 'base', role: d.role, growth,
    recommendedAllocation: old ? old.recommendedAllocation : allocationOf(growth),
    weapons: old ? old.weapons : listOf(d.weapons), armor: listOf(d.armor), mechanic: old ? old.mechanic : d.mechanic,
    starterWeaponId: old ? old.starterWeaponId : d.starter[0],
    trainer: d.trainer, classQuest: d.classQuest,
    kit, passives,
  };
});

fs.writeFileSync(CLASSES, JSON.stringify(out, null, 1) + '\n');
fs.writeFileSync(ITEMS, JSON.stringify(items, null, 1) + '\n');
const actives = out.reduce((n, c) => n + c.kit.length, 0), pas = out.reduce((n, c) => n + c.passives.length, 0);
console.log(`[classes] ${out.length} base classes · ${actives} kit skills · ${pas} passives · items ${items.length}`);
