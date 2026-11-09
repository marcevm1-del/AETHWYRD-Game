// Builds Data/World/lairs_and_events.json, Data/World/faction_relations.json and Data/Items/grade_labels.json
// from the Monster Classification & Guild System bible v1.0 (sections 7, 10, 11, 12). Usage: node Tools/bestiary/build_world_layers.js
const fs = require('fs');
const path = require('path');
const D = path.join(__dirname, '..', '..', 'Data');
const w = (rel, o) => fs.writeFileSync(path.join(D, rel), JSON.stringify(o, null, 1) + '\n');
const L = a => a.map(x => `evl_${x}`);
const G = a => a.map(x => `gld_${x}`);

// ---- section 11: lair types, dungeon progression, world events ----
const lairs = {
  notes: 'DRAFT from the bible v1.0 section 11. Location-type tags for designing lairs and dungeons: a dungeon is an ecosystem and a faction stronghold, not a row of combat rooms. Nothing here adds a dungeon boss (Canon section 6: a boss is an existing species) or an enemy hierarchy (Canon 4d). World events are region-level only and are proposals for the living-world event director, not yet registered there.',
  locationTypes: [
    ['goblin_warren', 'Goblin warrens', ['goblins', 'hobgoblin_kind', 'slimes'], 'Traps, tunnels, alarms, workshops.'],
    ['orc_fortress', 'Orc fortress', ['orcs', 'ogres', 'trolls'], 'Barracks, war rooms, siege weapons.'],
    ['dragon_lair', 'Dragon lair', ['dragons', 'drakes', 'wyverns'], 'Treasure vault, elemental hazards, flight spaces.'],
    ['undead_crypt', 'Undead crypt', ['undead'], 'Curses, sealed chambers, soul anchors.'],
    ['demon_gate', 'Demon gate', ['demons'], 'Ritual circles, unstable portals, corruption.'],
    ['insect_hive', 'Insect hive', ['insects', 'arachnids'], 'Caste chambers, pheromone zones, brood chambers.'],
    ['crystal_cavern', 'Crystal cavern', ['crystals', 'golems'], 'Resonance puzzles, reflective attacks, mana fields.'],
    ['elemental_nexus', 'Elemental nexus', ['elementals', 'automata'], 'Changing terrain, elemental surges.'],
    ['abyssal_trench', 'Abyssal trench', ['aquatic'], 'Pressure, darkness, currents, oxygen limits.'],
    ['void_rift', 'Void rift', ['void'], 'Spatial distortion, reality hazards, shifting rooms.']
  ].map(([id, name, lines, features]) => ({ id: `lair_${id}`, name, inhabitantLines: L(lines), signatureFeatures: features })),
  progression: [
    ['discovery', 'Rumours, maps, guild contracts or environmental clues reveal the entrance.'],
    ['preparation', 'The party chooses supplies, resistance gear, research and a retreat plan.'],
    ['entry', 'The party meets scouts, environmental hazards and early warning signs.'],
    ['escalation', 'Defenders adapt, alarms trigger, reinforcements arrive or the dungeon changes.'],
    ['objective', 'Recover a relic, rescue captives, defeat a boss, close a rift or gather research.'],
    ['resolution', 'Claim rewards, report to guilds, shift region state and change the area.']
  ].map(([id, text], i) => ({ step: i + 1, id, text })),
  worldEvents: [
    ['goblin_warband_invasion', 'Goblin Warband Invasion', 'Multiple villages are threatened by a coordinated goblin host.', ['goblins', 'hobgoblin_kind'], ['mercenaries', 'adventurers', 'farmers']],
    ['dragon_migration', 'Dragon Migration', 'Draconic territories shift, disrupting trade routes and spawning rare hunts.', ['dragons', 'wyverns', 'drakes'], ['monster_hunters', 'merchants']],
    ['undead_moon', 'Undead Moon', 'Necromantic energy raises threats around graveyards and battlefields.', ['undead', 'spirits'], ['exorcists', 'necromancers']],
    ['insect_queen_awakening', 'Insect Queen Awakening', 'A hive expands underground and threatens mines and towns.', ['insects', 'arachnids'], ['miners', 'builders']],
    ['elemental_storm', 'Elemental Storm', 'A mana nexus destabilises, creating elemental outbreaks.', ['elementals', 'crystals'], ['mages', 'enchanters']],
    ['leviathan_rising', 'Leviathan Rising', 'Sea routes close and coastal guilds request a joint expedition.', ['aquatic'], ['maritime', 'sailors']],
    ['void_breach', 'Void Breach', 'Reality distortions spread and require a multi-guild containment effort.', ['void'], ['mages', 'exorcists', 'adventurers', 'free_cities_council']]
  ].map(([id, name, text, lines, guilds]) => ({ id: `wev_${id}`, name, text, lines: L(lines), requestedBy: G(guilds), scope: 'region', drivers: ['ecology', 'region_state', 'story_flag'] }))
};
w('World/lairs_and_events.json', lairs);

// ---- section 12: faction relations (player-facing) ----
const REL = [
  ['goblins', ['orcs', 'ogres'], ['hobgoblin_kind'], 'Wary', 'Allies: orcs, ogres, mercenary groups. Tensions: hobgoblin states, nearby settlements.'],
  ['orcs', ['ogres', 'trolls'], ['dragons', 'giants'], 'Wary', 'Allies: ogres, trolls, some beast clans. Tensions: dragons, giants, rival orc clans.'],
  ['dragons', ['wyverns', 'drakes', 'fae'], ['giants'], 'Neutral', 'Allies: wyverns, drakes, selected fae courts. Tensions: giants, titans, rival dragon houses.'],
  ['undead', ['vampires', 'spirits'], ['celestials'], 'Hostile', 'Allies: vampires, wraiths, necromantic factions. Tensions: celestials, exorcists, living kingdoms.'],
  ['demons', ['undead', 'void'], ['celestials'], 'Hostile', 'Allies: corrupted undead, cults, void agents. Tensions: celestials, cursebreakers, rival demon courts.'],
  ['insects', ['arachnids', 'plants'], ['beasts'], 'Hostile', 'Allies: arachnids, some plant monsters. Tensions: beasts, farmers, mining settlements.'],
  ['golems', ['elementals', 'automata'], ['demons'], 'Neutral', 'Allies: elementals, construct guilds. Tensions: demons, thieves, incompetent commands.'],
  ['fae', ['plants', 'spirits'], ['demons'], 'Wary', 'Allies: plant monsters, spirits, conservationists. Tensions: demons, exploitative hunters, oath-breakers.'],
  ['aquatic', ['hydras'], [], 'Neutral', 'Allies: sea serpents, hydras, coastal factions. Tensions: maritime empires, pollution, rival sea kings.'],
  ['void', ['automata'], ['celestials'], 'Hostile', 'Allies: other void entities, cults, unstable constructs. Tensions: celestial orders, reality wardens, world defenders.']
];
const DEFAULT_OTHER = { vampires: 'Wary', trolls: 'Wary', ogres: 'Wary', giants: 'Wary', hobgoblin_kind: 'Wary', arachnids: 'Hostile', celestials: 'Neutral', spirits: 'Neutral' };
const factions = {
  notes: 'DRAFT from the bible v1.0 section 12. Relations between the PLAYER and each monster group, tracked separately per group. The group-to-group table is flavour for event and quest writers only: it drives no hierarchy and no autonomous faction war (Canon 4d). The bible Subjugated and At-war group states are not imported (Canon 4d, proposal M4). Standing moves only through quests, flags and the player\'s own actions, never because the player was defeated.',
  playerStates: [
    ['hostile', 'Hostile', -100, 'Attacks on sight or actively obstructs the player.'],
    ['wary', 'Wary', -40, 'Avoids open conflict but distrusts outsiders.'],
    ['neutral', 'Neutral', 0, 'Trades or interacts under normal rules.'],
    ['friendly', 'Friendly', 40, 'Offers aid, information or safe passage.'],
    ['allied', 'Allied', 80, 'Shares resources, missions and coordinated support.']
  ].map(([id, name, minPoints, text]) => ({ id, name, minPoints, text })),
  startingStandingPoints: { Hostile: -70, Wary: -20, Neutral: 0, Friendly: 50, Allied: 85 },
  groups: [
    ...REL.map(([id, allies, rivals, start, text]) => ({ lineId: `evl_${id}`, defaultState: start, allyLines: L(allies), rivalLines: L(rivals), note: text })),
    ...Object.entries(DEFAULT_OTHER).map(([id, start]) => ({ lineId: `evl_${id}`, defaultState: start, allyLines: [], rivalLines: [], note: 'No relation row in the bible; defaults only.' }))
  ],
  exampleRule: 'A player may be allied with an Orc clan while an Orc clan confederation remains hostile, or trusted by a Vampire house while the Exorcists Order distrusts them (per-faction and per-guild tracking).'
};
w('World/faction_relations.json', factions);

// ---- section 10: core and harvest grades, as display labels over the existing item rarity (Canon proposal M5) ----
const grades = {
  notes: 'DRAFT from the bible v1.0 section 10. Core and harvest grades are DISPLAY LABELS over the existing item rarity (Common, Uncommon, Rare, Epic, Legendary) and the F to EX core price curve in 09_Equipment/monster_core_pricing.md. They add no second economy and no new prices (Canon proposal M5).',
  grades: [
    ['cracked', 'Cracked', 'Common', 'Damaged or unstable', 'Basic crafting or low-value sale.'],
    ['common', 'Common', 'Common', 'Standard core or material', 'Everyday recipes.'],
    ['refined', 'Refined', 'Uncommon', 'Clean, high-quality harvest', 'Improved gear and potions.'],
    ['rare', 'Rare', 'Rare', 'Unusual properties or strong energy', 'Specialist recipes and upgrades.'],
    ['epic', 'Epic', 'Epic', 'Powerful, difficult-to-obtain material', 'High-tier equipment and enchantments.'],
    ['legendary', 'Legendary', 'Legendary', 'Unique properties or boss origin', 'Named gear, major upgrades.'],
    ['mythic', 'Mythic', 'Legendary', 'Primordial or world-scale source', 'Endgame crafting and story-critical items.']
  ].map(([id, name, rarity, quality, use], i) => ({ id: `gradelabel_${id}`, tier: i + 1, name, itemRarity: rarity, quality, designUse: use })),
  materialCategories: [
    ['Monster cores', 'Mana core, elemental core, corrupted core, ancient core.', 'Spell fuel, evolution catalysts, crafting, research.'],
    ['Body parts', 'Horns, scales, claws, fangs, hides, wings, shells.', 'Weapons, armour, tools, trophies.'],
    ['Liquids', 'Blood, venom, slime, ichor, gland extract.', 'Potions, poisons, alchemy, enchantments.'],
    ['Minerals', 'Crystal shards, obsidian plates, golem fragments.', 'Jewellery, cores, runes, constructs.'],
    ['Organic materials', 'Spores, herbs, roots, silk, chitin.', 'Medicine, food, textiles, alchemy.'],
    ['Spiritual materials', 'Soul essence, ectoplasm, wraith residue.', 'Wards, spirit items, exorcism tools.'],
    ['Relics', 'Runed bones, ancient tablets, scale fragments.', 'Research, quests, legendary crafting.']
  ].map(([name, examples, uses]) => ({ name, examples, uses })),
  safeguards: [
    'Use regional supply and demand so materials are not equally valuable everywhere.',
    'Limit farming through spawn ecology, cooldowns, migration, lair depletion or harvest limits.',
    'Make rare drops useful across several systems; no single material is mandatory for all builds.',
    'Use guild commissions and trade contracts to create stable demand.',
    'Track item provenance for unique boss drops, stolen relics and faction-owned resources.'
  ]
};
w('Items/grade_labels.json', grades);
console.log(`lairs_and_events: ${lairs.locationTypes.length} lairs, ${lairs.worldEvents.length} events; faction_relations: ${factions.groups.length} groups; grade_labels: ${grades.grades.length} grades`);
