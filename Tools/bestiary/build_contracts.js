// Builds Data/Quests/guild_contracts.json: quest categories, bounty rules and two contract templates per guild (bible v1.0 sections 8 and 9).
// Templates are TEMPLATES, not quests: the quest system fills in the target, place and giver at run time.
// All numbers are placeholder tuning. Usage: node Tools/bestiary/build_contracts.js (deterministic)
const fs = require('fs');
const path = require('path');
const OUT = path.join(__dirname, '..', '..', 'Data', 'Quests', 'guild_contracts.json');
const guilds = JSON.parse(fs.readFileSync(path.join(__dirname, '..', '..', 'Data', 'World', 'guilds.json'), 'utf8')).guilds;

const CATEGORIES = [
  ['hunt', 'Hunt', 'Track, defeat, capture or study a target.', 'Currency, trophy, core, reputation.'],
  ['gather', 'Gather', 'Collect herbs, crystals, monster parts or samples.', 'Materials, recipes, crafting XP.'],
  ['escort', 'Escort', 'Protect caravans, scholars, breeders or refugees.', 'Currency, trade access, reputation.'],
  ['explore', 'Explore', 'Map ruins, caves, nests, lairs or unknown regions.', 'Maps, relics, discovery XP.'],
  ['research', 'Research', 'Observe behaviour, identify species or test a weakness.', 'Bestiary entries, recipes, guild standing.'],
  ['rescue', 'Rescue', 'Recover captives, lost parties, eggs or injured creatures.', 'Reputation, allies, rare rewards.'],
  ['defence', 'Defence', 'Protect a settlement, gate, mine, village or convoy.', 'Currency, settlement upgrades.'],
  ['infiltration', 'Sabotage / Infiltration', 'Disable a threat, retrieve intelligence or expose a plot.', 'Information, faction influence.'],
  ['raid', 'Boss / Raid', 'Defeat a lair ruler, world boss or coordinated encounter.', 'Legendary materials, titles, unique loot.'],
  ['diplomacy', 'Diplomacy', 'Negotiate with a monster faction or resolve a guild dispute.', 'Alliances, access, peace or trade.']
];
const RANKS = ['F', 'E', 'D', 'C', 'B', 'A', 'S', 'SS', 'SSS'];
// Placeholder copper reward at "mid" band, by quest rank (existing quests: F 40 to 60, C bounty 4,500).
// Member tier needed by the contract's lowest rank (bible section 8 ladder: Initiate low-risk, Member standard, Veteran advanced, Expert high-risk).
const TIER_BY_RANK = { F: 1, E: 2, D: 3, C: 3, B: 4, A: 4, S: 5, SS: 6, SSS: 7 };
const COPPER = { F: 50, E: 250, D: 900, C: 3000, B: 8000, A: 20000, S: 50000, SS: 120000, SSS: 300000 };

// slug: [[category, title, minRank, maxRank, cooldownDays, band], x2]
const T = {
  monster_hunters: [['hunt', 'Field bounty: a named pest', 'F', 'C', 1, 'mid'], ['research', 'Trophy survey for the hunters', 'E', 'B', 3, 'low']],
  rangers: [['explore', 'Mark a safe route through the wilds', 'F', 'C', 2, 'low'], ['escort', 'Guide a party over a dangerous pass', 'E', 'B', 3, 'mid']],
  mercenaries: [['escort', 'Armed escort for a supply column', 'D', 'A', 3, 'mid'], ['defence', 'Hold a gate for a season of siege work', 'C', 'S', 7, 'high']],
  merchants: [['escort', 'Caravan protection on a trade road', 'F', 'B', 2, 'mid'], ['diplomacy', 'Settle a market dispute fairly', 'D', 'A', 5, 'mid']],
  blacksmiths: [['gather', 'Fetch ore and charcoal for the forge', 'F', 'C', 1, 'low'], ['hunt', 'Hunt a metal-hided beast for masterwork scales', 'C', 'A', 5, 'high']],
  alchemists: [['gather', 'Collect catalyst herbs', 'F', 'D', 1, 'low'], ['research', 'Test a monster extract for the Circle', 'D', 'B', 4, 'mid']],
  mages: [['research', 'Observe a mana nexus for the Conclave', 'D', 'A', 4, 'mid'], ['gather', 'Recover spell reagents', 'E', 'B', 2, 'low']],
  healers: [['rescue', 'Carry the wounded back from a battlefield', 'E', 'B', 2, 'mid'], ['gather', 'Find antidote herbs before the fever spreads', 'F', 'C', 1, 'low']],
  scholars: [['research', 'Identify and describe an unlisted species', 'D', 'A', 4, 'mid'], ['explore', 'Copy an inscription from a ruin', 'E', 'B', 3, 'low']],
  cartographers: [['explore', 'Survey an unmapped cave', 'E', 'B', 2, 'mid'], ['explore', 'Chart a new landmark', 'F', 'C', 1, 'low']],
  beast_tamers: [['hunt', 'Capture a compatible beast alive', 'E', 'B', 3, 'mid'], ['rescue', 'Recover a runaway companion', 'F', 'C', 2, 'low']],
  bounty_registry: [['hunt', 'Bring in a named target', 'D', 'S', 3, 'high'], ['hunt', 'Deliver proof for a standing bounty', 'F', 'B', 1, 'mid']],
  maritime: [['explore', 'Run a coastal sea expedition', 'D', 'A', 4, 'mid'], ['gather', 'Salvage a wreck before the tide', 'E', 'B', 3, 'mid']],
  miners: [['defence', 'Clear a cave-in and the things nesting in it', 'D', 'A', 3, 'mid'], ['gather', 'Mine a vein for the Union', 'F', 'C', 1, 'low']],
  enchanters: [['research', 'Test a rune on a living target', 'D', 'A', 4, 'mid'], ['gather', 'Collect rune-stones', 'E', 'B', 2, 'low']],
  jewelers: [['gather', 'Source rare crystals', 'D', 'A', 3, 'mid'], ['research', 'Appraise a gem for the Guild', 'E', 'B', 2, 'low']],
  cooks: [['gather', 'Hunt for a rare ingredient', 'E', 'B', 2, 'low'], ['escort', 'Deliver camp supplies to a patrol', 'F', 'C', 2, 'low']],
  stablemasters: [['escort', 'Deliver a mount safely', 'F', 'C', 2, 'low'], ['rescue', 'Find a strayed mount', 'E', 'B', 2, 'mid']],
  sailors: [['escort', 'Convoy through stormy water', 'D', 'A', 4, 'mid'], ['rescue', 'Rescue a crew from a wreck', 'C', 'S', 5, 'high']],
  builders: [['defence', 'Reinforce a village gate', 'F', 'C', 3, 'mid'], ['gather', 'Haul stone and timber for a bridge', 'F', 'D', 1, 'low']],
  farmers: [['defence', 'Protect the harvest from raiders', 'F', 'D', 1, 'low'], ['gather', 'Collect herbs for the Cooperative', 'F', 'C', 1, 'low']],
  conservation: [['rescue', 'Relocate a rare species to safety', 'D', 'A', 4, 'mid'], ['research', 'Record a nest for the Society', 'E', 'B', 3, 'low']],
  necromancers: [['research', 'Contain a restless grave', 'C', 'A', 5, 'mid'], ['explore', 'Recover funerary relics', 'C', 'S', 6, 'high']],
  exorcists: [['rescue', 'Lift a haunting from a house', 'D', 'A', 3, 'mid'], ['research', 'Break a curse on an heirloom', 'D', 'S', 5, 'high']],
  relic_seekers: [['explore', 'Authenticate a relic in the field', 'D', 'S', 4, 'mid'], ['raid', 'Recover a relic from a guarded vault', 'B', 'SS', 7, 'high']],
  arena: [['diplomacy', 'Arrange a sanctioned exhibition duel', 'E', 'A', 3, 'mid'], ['raid', 'Win a ranked tournament bout', 'D', 'S', 5, 'high']],
  shadow_syndicate: [['infiltration', 'Carry a message past the watch', 'D', 'A', 3, 'mid'], ['infiltration', 'Learn what a merchant is hiding', 'C', 'S', 5, 'high']],
  veiled_hand: [['infiltration', 'Expose a plot before it ripens', 'B', 'SS', 7, 'high'], ['diplomacy', 'Broker a quiet truce between houses', 'B', 'SS', 7, 'high']],
  free_cities_council: [['diplomacy', 'Carry a charter to a free city', 'D', 'A', 4, 'mid'], ['diplomacy', 'Arbitrate a dispute between guilds', 'C', 'S', 6, 'high']]
};
// Guilds that never appear on the plain board (hidden or restricted): templates are offered only to members.
const templates = [];
for (const g of guilds) {
  if (!T[g.id.replace('gld_', '')]) continue;
  T[g.id.replace('gld_', '')].forEach(([cat, title, min, max, cd, band], i) => {
    templates.push({ id: `gct_${g.id.replace('gld_', '')}_${i + 1}`, guildId: g.id, category: `cqc_${cat}`, title, minRank: min, maxRank: max, cooldownDays: cd, rewardBand: band, minTier: TIER_BY_RANK[min], membersOnly: g.access !== 'public' });
  });
}

const out = {
  notes: 'DRAFT from the bible v1.0 sections 8 and 9: ten quest categories, bounty board rules and two contract templates per guild (58 templates; the Adventurers Guild keeps the existing quest system). Templates are not quests. All numbers are placeholder tuning. Quest rewards must not create infinite material or currency loops: every template has a cooldown, and a guild gives only the daily reputation cap in guilds.json.',
  categories: CATEGORIES.map(([id, name, objectives, reward]) => ({ id: `cqc_${id}`, name, objectiveExamples: objectives, typicalReward: reward })),
  rewardBands: { low: 0.6, mid: 1.0, high: 1.5 },
  rewardBandsNote: 'rewardBands multiply copperByRank. Placeholder tuning.',
  copperByRank: COPPER,
  scaling: { note: 'Scale difficulty by threat rank, party size, gear, location, monster intelligence, environmental hazards and objective complexity, never by evolution stage alone.', factors: ['threatRank', 'partySize', 'gear', 'location', 'monsterIntelligence', 'environmentalHazards', 'objectiveComplexity'] },
  bounty: {
    objectives: ['kill', 'capture', 'sample', 'investigate', 'relocate'],
    proofs: ['core', 'marked_trophy', 'field_report', 'captured_target', 'witness_testimony'],
    proofsAccepted: {
      kill: ['core', 'marked_trophy', 'witness_testimony'],
      capture: ['captured_target', 'witness_testimony'],
      sample: ['field_report', 'marked_trophy'],
      investigate: ['field_report', 'witness_testimony'],
      relocate: ['captured_target', 'witness_testimony']
    },
    // Several parties may hunt the same target. Credit follows contribution; the reward is held in escrow until proof is accepted.
    claim: { rule: 'first_valid_proof', minContributionShare: 0.15, splitBy: 'contribution', escrow: true, reputationToQualifyingClaimants: true },
    listFields: ['targetIdentity', 'knownLocation', 'threatEstimate', 'behaviour', 'knownWeaknesses', 'proofRequirements', 'deadline', 'reward'],
    targetsMayChange: ['move', 'evolve', 'gainAllies', 'changeTerritory'],
    targetChangeNote: 'A target may change during an active bounty only by region state, ecology or story flags, never because it defeated the player (Canon 4d).'
  },
  templates
};
fs.writeFileSync(OUT, JSON.stringify(out, null, 1) + '\n');
console.log(`guild_contracts.json: ${out.categories.length} categories, ${templates.length} templates`);
