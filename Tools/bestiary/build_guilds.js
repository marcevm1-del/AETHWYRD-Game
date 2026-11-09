// Builds Data/World/guilds.json and Data/Monsters/variations.json from the Monster Classification & Guild System bible v1.0.
// Content is transcribed from the user's PDF; "ours" fields record how it fits AETHWYRD Canon.
// Usage: node Tools/bestiary/build_guilds.js   (deterministic)
const fs = require('fs');
const path = require('path');
const D = path.join(__dirname, '..', '..', 'Data');

// [slug, name, purpose, access, standing, services, tags]
// access: public | restricted | hidden. tags drive the crosswalk to existing systems.
const GUILDS = [
  ['adventurers', "Adventurers' Consortium", 'General adventuring, party registration, quests, maps and expedition permits.', 'public', 'Neutral', 'Quest board, rank tests, party matching, expedition insurance.'],
  ['monster_hunters', "Monster Hunters' Guild", 'Specialized hunting, tracking, research and safe monster removal.', 'public', 'Neutral', 'Bounties, trophies, field reports, hunter licences.'],
  ['rangers', 'Ranger and Pathfinder Lodge', 'Wilderness navigation, scouting, escort and route mapping.', 'public', 'Generally protective', 'Trail maps, guide contracts, safe-camp networks.'],
  ['mercenaries', "Mercenary Companies' League", 'Professional armed contracts, guards and battlefield services.', 'public', 'Pragmatic', 'Escort contracts, siege work, military missions.'],
  ['merchants', "Merchants' Trade Union", 'Trade routes, caravans, market standards and commercial disputes.', 'public', 'Profit-driven', 'Caravan protection, trade permits, auctions, price boards.'],
  ['blacksmiths', "Blacksmiths' Forge Alliance", 'Weapon, armour and tool crafting and repair.', 'public', 'Craft-focused', 'Craft commissions, repair services, masterwork certification.'],
  ['alchemists', "Alchemists' Circle", 'Potions, antidotes, catalysts, monster extracts and transmutation.', 'public', 'Regulated', 'Potion orders, ingredient contracts, research licences.'],
  ['mages', "Mages' Conclave", 'Arcane study, spell certification, magical research and training.', 'public', 'Selective', 'Spell lessons, magical testing, research quests.'],
  ['healers', "Healers' and Apothecaries' Order", 'Medical care, recovery, antidotes and battlefield treatment.', 'public', 'Humanitarian', 'Healing services, rescue missions, clinic referrals.'],
  ['scholars', "Scholars' and Scribes' Society", 'Lore, translation, bestiary records, archives and identification.', 'public', 'Academic', 'Research tasks, ancient language translation, monster appraisal.'],
  ['cartographers', "Explorers' Cartographers' Guild", 'Mapping ruins, dungeons, caves and unknown regions.', 'public', 'Exploratory', 'Survey contracts, map sales, landmark discovery.'],
  ['beast_tamers', "Beast Tamers' Association", 'Capture, training, breeding and care of compatible beasts.', 'public', 'Regulated', 'Taming trials, stable services, companion permits.'],
  ['bounty_registry', "Bounty Hunters' Registry", 'Capture or elimination of named targets and fugitives.', 'public', 'Strict rules', 'Target dossiers, proof-of-capture, reward escrow.'],
  ['maritime', 'Fisherfolk and Maritime Guild', 'Fishing, sea routes, aquatic monster knowledge and salvage.', 'public', 'Coastal', 'Sea expeditions, salvage rights, harbour contracts.'],
  ['miners', "Miners' and Delvers' Union", 'Mining, excavation, tunnel safety and mineral appraisal.', 'public', 'Industrial', 'Mining rights, escort requests, cave-clearing contracts.'],
  ['enchanters', "Enchanters' Atelier", 'Enchantments, runes, magical item upgrades and identification.', 'public', 'Specialist', 'Enchanting commissions, rune research, item appraisal.'],
  ['jewelers', "Jewelers' and Gemcutters' Guild", 'Gem cutting, crystal work, jewellery and focus crafting.', 'public', 'Craft-focused', 'Gem appraisal, rare crystal procurement, commissions.'],
  ['cooks', "Cooks' and Provisioners' Guild", 'Rations, monster cuisine, buffs, preserved foods and supply logistics.', 'public', 'Service', 'Meal buffs, camp supply contracts, rare ingredient requests.'],
  ['stablemasters', "Stablemasters' and Mount Keepers' Guild", 'Mount care, breeding, transport and riding instruction.', 'public', 'Regulated', 'Mount registration, breeding services, stable rentals.'],
  ['sailors', "Sailors' and Skyship Captains' Union", 'Ship crews, airships, navigation and transport.', 'public', 'Transport', 'Passage contracts, convoy missions, rescue work.'],
  ['builders', "Builders' and Siege Engineers' Guild", 'Fortifications, bridges, traps, siege engines and settlement works.', 'public', 'Industrial', 'Construction contracts, repairs, defensive upgrades.'],
  ['farmers', "Farmers' and Herbalists' Cooperative", 'Food production, herb cultivation, gathering and rural defence.', 'public', 'Community', 'Harvest protection, herb orders, monster control.'],
  ['conservation', 'Beast Research and Conservation Society', 'Study, sanctuary, relocation and protection of rare species.', 'public', 'Conservation', 'Research expeditions, rescue, habitat restoration.'],
  ['necromancers', "Necromancers' Collegium", 'Controlled undead research, funerary rites and containment.', 'restricted', 'Controversial', 'Containment licences, relic recovery, undead investigations.'],
  ['exorcists', "Exorcists' and Cursebreakers' Order", 'Possession, curses, hauntings, corruption and spiritual threats.', 'public', 'Specialist', 'Exorcisms, curse removal, haunted-site contracts.'],
  ['relic_seekers', "Relic Seekers' Society", 'Recovery, authentication and protection of ancient artefacts.', 'public', 'Competitive', 'Relic expeditions, appraisal, ruin permits.'],
  ['arena', "Arena Champions' Association", 'Organized duels, tournaments, rankings and public challenges.', 'public', 'Competitive', 'Arena matches, sponsorships, training events.'],
  ['shadow_syndicate', 'Secretive Shadow Syndicate', 'Espionage, information brokerage, infiltration and covert work.', 'hidden', 'Illegal or morally grey', 'Rumours, stealth missions, black-market intelligence.'],
  ['veiled_hand', "Veiled Hand Assassins' Network", 'Covert elimination, sabotage and political intrigue.', 'hidden', 'Criminal', 'High-risk contracts, faction plots, wanted notices.'],
  ['free_cities_council', "Free Cities' Guild Council", 'Coordinates guild charters, dispute resolution and inter-city standards.', 'public', 'Political', 'Guild licensing, arbitration, regional policy.']
];

// Our integration notes. Absent = no special handling.
const OURS = {
  adventurers: { mapsTo: "The existing Adventurers' Guild (Canon section 2 ranks F to SSS; Data/World/guild_ranks.json). Keeps its F to SSS ladder and Rank cards; the 8-step member ladder does NOT apply to it.", canon: 'Keeps the Canon name "Adventurers\' Guild" in game; "Consortium" is a bible alias only.' },
  shadow_syndicate: { teenRating: 'Information and stealth work only; no real-world crime detail.' },
  veiled_hand: { teenRating: 'Contracts are political and implied, never shown as graphic; offer as faction plots and wanted notices. Needs a Canon section 6 OK before any assassination contract is playable.' },
  necromancers: { canon: 'Restricted/controversial: containment and funeral rites only, consistent with Canon section 3 secrets staying unspoiled.' },
  arena: { canon: 'No new Canon conflict, but Canon 4d forbids the arena from promoting named monsters.' }
};

const RANKS = [
  ['applicant', 'Applicant', 'Public services and basic notices.', 'Registration, identity check or introductory task.'],
  ['initiate', 'Initiate', 'Training and low-risk contracts.', 'Basic test, first contribution or recommendation.'],
  ['member', 'Member', 'Standard quests and guild facilities.', 'Completed starter quest and code acceptance.'],
  ['veteran', 'Veteran', 'Advanced contracts and specialist services.', 'Reputation, successful missions, skill proof.'],
  ['expert', 'Expert', 'High-risk quests, mentorship and restricted facilities.', 'Mastery test, significant contribution.'],
  ['officer', 'Officer', 'Team leadership, quest approval and local administration.', 'Trust, leadership record, guild vote or appointment.'],
  ['master', 'Master', 'Regional authority, rare services and training rights.', 'Exceptional achievements and senior approval.'],
  ['grandmaster', 'Grandmaster', 'Guild-wide influence and unique story access.', 'Major narrative achievement; usually one or few.']
];

const FACILITIES = [
  'Hall and reception: membership, noticeboards, contracts and public services.',
  'Training yard: combat practice, sparring, skill trials and weapon instruction.',
  'Library or archive: maps, monster records, spell research and lore.',
  'Workshop: crafting, repairs, enchanting and alchemy.',
  'Infirmary: healing, recovery and status-effect treatment.',
  'Stable, docks or hangar: mounts and transport where appropriate.',
  'Vault and auction room: escrow, rare goods, guild funds and secure storage.',
  'Private rooms: party planning, guild meetings, faction story scenes.'
];

const RIVALRIES = [
  ['adventurers', 'monster_hunters', 'Cooperate on contracts; compete for high-profile targets.'],
  ['merchants', 'bounty_registry', 'Cooperate on caravan security; dispute reward pricing.'],
  ['mages', 'alchemists', 'Share research; compete over patents and rare catalysts.'],
  ['beast_tamers', 'conservation', 'Cooperate on rescue; disagree over capture and ownership.'],
  ['necromancers', 'exorcists', 'Ideological conflict and occasional joint containment operations.'],
  ['relic_seekers', 'scholars', 'Cooperate on translation; dispute ownership and access.'],
  ['shadow_syndicate', 'veiled_hand', 'Share information but compete for influence.']
];

const guilds = {
  notes: 'DRAFT from the Monster Classification & Guild System bible v1.0 (user PDF), sections 8 and 9. 30 guilds, an 8-step membership ladder, per-guild reputation and facilities. Not yet wired to quests or the HUD; see 13_Production/monster_guild_integration.md for what needs the user OK. The player cannot own a guild (Canon section 4). The Adventurers Consortium is the existing Adventurers Guild and keeps the F to SSS rank ladder.',
  reputation: {
    perGuild: true,
    rules: [
      'Track reputation per guild, not as one global value.',
      'Positive: completed contracts, donations, discoveries, rescues, fair conduct.',
      'Negative: abandoning missions, stealing guild property, harming protected creatures, breaking contracts, betraying members.',
      'High reputation unlocks discounts, rare recipes, restricted quests, mentors, titles and voting rights.',
      'A player may be respected by one guild and distrusted by another; multiple compatible memberships are allowed.'
    ]
  },
  memberLadder: RANKS.map(([key, name, access, requirements], i) => ({ id: `gr_${key}`, tier: i + 1, name, access, exampleRequirements: requirements })),
  facilities: FACILITIES,
  rivalries: RIVALRIES.map(([a, b, text]) => ({ a: `gld_${a}`, b: `gld_${b}`, text })),
  councilNote: 'The Free Cities Guild Council can mediate charters, monopolies, sanctions and inter-city conflicts.',
  guilds: GUILDS.map(([slug, name, purpose, access, standing, services], i) => ({
    id: `gld_${slug}`, order: i + 1, name, purpose, access, standing, services,
    usesMemberLadder: slug !== 'adventurers',
    ...(OURS[slug] ? { ours: OURS[slug] } : {})
  }))
};

// Variations: 12 universal modifiers (section 5).
// ours.existing = the closest row already in 08_Bestiary/bestiary_lore.md "Variant Modifiers".
const VARIATIONS = [
  ['horned', 'Horned', 1, 'Physical mutation; charging and melee bonuses.', ['Single horn', 'Double horn', 'Crown horns', 'Antlers'], null],
  ['petrified', 'Petrified', 2, 'Stone transformation; high defence, reduced mobility.', ['Stone', 'Granite', 'Marble', 'Obsidian'], null],
  ['corrupted', 'Corrupted', 3, 'Dark or unstable energy; unusual powers and corruption effects.', ['Dark', 'Abyssal', 'Plague', 'Chaotic'], 'Corrupted'],
  ['possessed', 'Possessed', 4, 'External entity influences or controls the host.', ['Spirit', 'Demon', 'Ancient soul', 'Parasite'], null],
  ['blessed', 'Blessed', 3, 'Sacred energy; healing, protection and purification.', ['Divine', 'Sacred', 'Celestial', 'Nature-blessed'], null],
  ['cursed', 'Cursed', 3, 'Supernatural affliction; debuffs and dangerous effects.', ['Blood curse', 'Death curse', 'Ancient curse', 'Soul curse'], null],
  ['frozen', 'Frozen', 1, 'Ice enhancement; frost attacks and cold resistance.', ['Ice', 'Frost', 'Glacier', 'Absolute zero'], 'Regional'],
  ['infernal', 'Infernal', 1, 'Fire enhancement; heat resistance and explosive attacks.', ['Flame', 'Magma', 'Hellfire', 'Solar'], 'Regional'],
  ['electrified', 'Electrified', 2, 'Electrical energy; speed, lightning attacks and shock effects.', ['Lightning', 'Thunder', 'Storm', 'Plasma'], 'Regional'],
  ['shadow', 'Shadow', 2, 'Stealth and darkness manipulation.', ['Dark', 'Phantom', 'Night', 'Void-shadow'], null],
  ['ancient', 'Ancient', 4, 'Ancestral or primordial traits; forgotten abilities.', ['Primordial', 'Ancestral', 'Prehistoric', 'Forgotten'], 'Ancient'],
  ['awakened', 'Awakened', 5, 'Unlocks hidden potential, intelligence or advanced abilities.', ['Magical', 'Physical', 'Spiritual', 'Transcendental'], null]
];
const RARITY = ['Common', 'Uncommon', 'Rare', 'Very rare', 'Exceptional'];
const variations = {
  notes: 'DRAFT from the bible v1.0 section 5. 12 universal variation modifiers with five rarity tiers. A variation modifies a creature; it never creates a new species and never sets threat rank. Overlaps with the existing Variant Modifiers in 08_Bestiary/bestiary_lore.md are recorded in ours.existingModifier. Needs the Canon section 6 OK before any is spawned.',
  rarityTiers: RARITY.map((label, i) => ({ tier: i + 1, label })),
  balanceRules: [
    'Each variation defines compatible groups, attribute modifiers, new abilities, weaknesses and visual cues.',
    'Tags prevent nonsensical combinations unless a lore reason exists.',
    'Stacking has diminishing returns or a complexity cost; some variations are mutually exclusive.',
    'Awakened is a special state or transformation, not a routine cosmetic modifier.',
    'Ancient indicates age or lineage and does not automatically grant a higher threat rank.',
    'Rarity is not power: a common variation on an SSS monster can still be devastating.'
  ],
  variations: VARIATIONS.map(([slug, name, tier, effect, subtypes, existing]) => ({
    id: `var_${slug}`, name, rarityTier: tier, rarityLabel: RARITY[tier - 1], effect, subtypes,
    ...(existing ? { existingModifier: existing } : {})
  }))
};

fs.writeFileSync(path.join(D, 'World', 'guilds.json'), JSON.stringify(guilds, null, 1) + '\n');
fs.writeFileSync(path.join(D, 'Monsters', 'variations.json'), JSON.stringify(variations, null, 1) + '\n');
console.log(`guilds.json: ${guilds.guilds.length} guilds, ${guilds.memberLadder.length} ladder tiers; variations.json: ${variations.variations.length} variations`);
