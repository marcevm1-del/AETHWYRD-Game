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


const LADDER = [[0, 0, 'none'], [10, 1, 'none'], [40, 3, 'none'], [120, 8, 'none'], [300, 15, 'test'], [600, 25, 'appointment'], [1200, 40, 'appointment'], [2500, 60, 'story']];
const DISCOUNT = [0, 0, 2, 4, 6, 8, 10, 12];
// kind: gain or loss. dailyCap: most reputation one guild can give per in-game day for this event (anti-farming, bible section 14).
const REP_EVENTS = [
  { id: 'contract_completed', kind: 'gain', delta: 10, dailyCap: 40, text: 'A guild contract handed in.' },
  { id: 'donation', kind: 'gain', delta: 2, dailyCap: 10, text: 'A donation to the guild (per 100 copper).' },
  { id: 'discovery', kind: 'gain', delta: 8, dailyCap: 16, text: 'A discovery the guild cares about.' },
  { id: 'rescue', kind: 'gain', delta: 15, dailyCap: 30, text: 'A rescue the guild recognises.' },
  { id: 'fair_conduct', kind: 'gain', delta: 2, dailyCap: 6, text: 'Fair conduct in guild dealings.' },
  { id: 'abandoned_mission', kind: 'loss', delta: -15, dailyCap: 45, text: 'An accepted mission abandoned.' },
  { id: 'stole_guild_property', kind: 'loss', delta: -60, dailyCap: 120, text: 'Guild property stolen.' },
  { id: 'harmed_protected_creature', kind: 'loss', delta: -40, dailyCap: 80, text: 'A protected creature harmed.' },
  { id: 'broke_contract', kind: 'loss', delta: -30, dailyCap: 60, text: 'A signed contract broken.' },
  { id: 'betrayed_member', kind: 'loss', delta: -80, dailyCap: 160, text: 'A guild member betrayed.' }
];
// Per-guild gates for non-public guilds. requiresAdventurerRank uses the Adventurers' Guild F to SSS rank. unlockFlag is a story flag.
const GATES = {
  necromancers: { requiresAdventurerRank: 'C' },
  shadow_syndicate: { unlockFlag: 'guild_shadow_syndicate_found' },
  veiled_hand: { unlockFlag: 'guild_veiled_hand_found', impliedContractsOnly: true }
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
  // Placeholder tuning (configurable; balance by playtest). gate: none = reputation and contracts only; test = a mastery test the quest
  // system supplies; appointment = a vote or appointment by the guild; story = a story event only. Grandmaster is never held by the
  // player through play (Canon section 4: the player cannot own or run a guild).
  memberLadder: RANKS.map(([key, name, access, requirements], i) => ({
    id: `gr_${key}`, tier: i + 1, name, access, exampleRequirements: requirements,
    reputationToReach: LADDER[i][0], contractsToReach: LADDER[i][1], gate: LADDER[i][2], playerCanHold: i < 7,
    discountPercent: DISCOUNT[i]
  })),
  playerMaxTier: 7,
  maxDiscountPercent: 12,
  standings: { distrustedBelow: -50, bannedBelow: -150, note: 'Below distrustedBelow the guild refuses services and contracts; below bannedBelow membership is revoked and tier resets. Standing recovers only by completing guild contracts or donations.' },
  reputationEvents: REP_EVENTS,
  facilities: FACILITIES,
  rivalries: RIVALRIES.map(([a, b, text]) => ({ a: `gld_${a}`, b: `gld_${b}`, text })),
  councilNote: 'The Free Cities Guild Council can mediate charters, monopolies, sanctions and inter-city conflicts.',
  guilds: GUILDS.map(([slug, name, purpose, access, standing, services], i) => ({
    id: `gld_${slug}`, order: i + 1, name, purpose, access, standing, services,
    usesMemberLadder: slug !== 'adventurers',
    ...(GATES[slug] || {}),
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

// Placeholder balance (configurable). statMods multiply the base stat; only the part above 1 is scaled by the stacking strength.
// excludedLines: evolution-line ids a variation cannot appear on without a special lore reason. exclusiveWith: never together.
// rankShift is always 0: a variation never changes threat rank (bible sections 5 and 6).
const VRULES = {
  horned: { mods: { atk: 1.15 }, excl: ['slimes', 'spirits', 'elementals', 'void', 'crystals'], ex: [], cue: 'Horns, antlers or a crown of horns.', weak: 'Slow to turn; flanking hits.' },
  petrified: { mods: { def: 1.4, mdef: 1.2, spd: 0.8 }, excl: ['golems', 'crystals', 'elementals', 'spirits', 'void', 'slimes'], ex: ['electrified'], cue: 'Grey stone skin, cracks and moss.', weak: 'Blunt and shattering hits.' },
  corrupted: { mods: { atk: 1.1, matk: 1.2 }, excl: ['demons'], ex: ['blessed'], element: 'Dark', cue: 'Red veins and black smoke.', weak: 'Purification; Light.', note: 'Purify for bonus loot (bestiary_lore.md).' },
  possessed: { mods: { atk: 1.2, def: 0.9 }, excl: ['spirits', 'void'], ex: ['blessed'], cue: 'Glowing eyes and jerky motion.', weak: 'Exorcism; Light.' },
  blessed: { mods: { hp: 1.15, mdef: 1.2 }, excl: ['demons', 'undead', 'vampires', 'void'], ex: ['cursed', 'corrupted', 'possessed'], element: 'Light', cue: 'Soft gold glow and petals.', weak: 'Dark; corruption.' },
  cursed: { mods: { matk: 1.1, def: 0.95 }, excl: ['celestials'], ex: ['blessed'], cue: 'Dark sigils and dripping ink.', weak: 'Cleansing; Light.' },
  frozen: { mods: { matk: 1.1, spd: 0.95 }, excl: [], ex: ['infernal'], element: 'Ice', cue: 'Frost crust and icicles.', weak: 'Fire.' },
  infernal: { mods: { atk: 1.1, matk: 1.1 }, excl: [], ex: ['frozen'], element: 'Fire', cue: 'Glowing cracks and embers.', weak: 'Water; Ice.' },
  electrified: { mods: { spd: 1.2, matk: 1.1 }, excl: [], ex: ['petrified'], element: 'Lightning', cue: 'Arcing sparks and standing hair.', weak: 'Earth; insulation.' },
  shadow: { mods: { spd: 1.15, def: 0.95 }, excl: [], ex: [], element: 'Dark', cue: 'Dim, blurred outline.', weak: 'Light.' },
  ancient: { mods: { hp: 2.0 }, excl: [], ex: [], cue: 'Moss and crystals growing on it.', weak: 'None added.', note: 'x2 HP as in bestiary_lore.md; age only, no threat rank change.' },
  awakened: { mods: { hp: 1.2, atk: 1.2, matk: 1.2, spd: 1.1 }, excl: [], ex: [], cue: 'A calm, aware stare and a soft halo.', weak: 'None added.', scripted: true }
};
const RARITY = ['Common', 'Uncommon', 'Rare', 'Very rare', 'Exceptional'];
const variations = {
  notes: 'DRAFT from the bible v1.0 section 5. 12 universal variation modifiers with five rarity tiers. A variation modifies a creature; it never creates a new species and never sets threat rank. Overlaps with the existing Variant Modifiers in 08_Bestiary/bestiary_lore.md are recorded in ours.existingModifier. Needs the Canon section 6 OK before any is spawned.',
  rarityTiers: RARITY.map((label, i) => ({ tier: i + 1, label })),
  stacking: { maxVariations: 3, strengthByCount: [1.0, 0.6, 0.35], note: 'The 2nd and 3rd variation apply only this share of the part of each stat multiplier above 1 (and a below-1 multiplier is softened the same way).' },
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
    statMods: VRULES[slug].mods, excludedLines: VRULES[slug].excl.map(x => `evl_${x}`), exclusiveWith: VRULES[slug].ex.map(x => `var_${x}`),
    ...(VRULES[slug].element ? { element: VRULES[slug].element } : {}), visualCue: VRULES[slug].cue, weaknessNote: VRULES[slug].weak,
    rankShift: 0, scriptedOnly: !!VRULES[slug].scripted, ...(VRULES[slug].note ? { note: VRULES[slug].note } : {}),
    ...(existing ? { existingModifier: existing } : {})
  }))
};

fs.writeFileSync(path.join(D, 'World', 'guilds.json'), JSON.stringify(guilds, null, 1) + '\n');
fs.writeFileSync(path.join(D, 'Monsters', 'variations.json'), JSON.stringify(variations, null, 1) + '\n');
console.log(`guilds.json: ${guilds.guilds.length} guilds, ${guilds.memberLadder.length} ladder tiers; variations.json: ${variations.variations.length} variations`);
