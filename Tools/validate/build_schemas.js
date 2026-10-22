// Writes the JSON Schemas in Data/Schemas. Rerun after changing a schema here.
// Usage: node Tools/validate/build_schemas.js
const fs = require('fs');
const path = require('path');
const OUT = path.join(__dirname, '..', '..', 'Data', 'Schemas');
fs.mkdirSync(OUT, { recursive: true });

const RANK = { type: 'string', pattern: '^(F|E|D|C|B|A|S|SS|SSS|EX)[+-]?$' };
const RL = { type: 'string', enum: ['F', 'E', 'D', 'C', 'B', 'A', 'S', 'SS', 'SSS', 'EX'] };
const EL = { type: 'string', enum: ['None', 'Fire', 'Water', 'Ice', 'Lightning', 'Earth', 'Wind', 'Nature', 'Poison', 'Light', 'Dark', 'Blood', 'Void'] };
const id = prefix => ({ type: 'string', pattern: `^${prefix}[a-z0-9_]+$` });

const SCHEMAS = {
  region: {
    title: 'Region', type: 'object', additionalProperties: false,
    required: ['id', 'name', 'biomes', 'rankMin', 'rankMax', 'ring', 'layer'],
    properties: {
      id: id('reg_'), name: { type: 'string', minLength: 1 }, biomes: { type: 'array', minItems: 1, items: { type: 'string' } },
      rankMin: RL, rankMax: RL, ring: { type: 'integer', minimum: 0, maximum: 9 },
      layer: { type: 'string', enum: ['surface', 'underworld', 'post-game'] },
      allowedFamilies: { type: 'array', items: { type: 'string' } }
    }
  },
  species: {
    title: 'Monster species', type: 'object', additionalProperties: false,
    required: ['id', 'name', 'familyKey', 'family', 'type', 'tier', 'rank', 'level', 'menace', 'element', 'sizeMeters', 'rigId', 'animSetId', 'behavior', 'aiPattern', 'stats', 'xp', 'gold', 'attackIds', 'isUnique', 'ring', 'habitats', 'lootTableId', 'look', 'designRecipe'],
    properties: {
      id: id('mon_'), name: { type: 'string', minLength: 1 }, familyKey: { type: 'string' }, family: { type: 'string' }, type: { type: 'string' }, genre: { type: 'string' },
      tier: { type: 'string', enum: ['core', 'variant'] },
      variantKind: { type: 'string', enum: ['', 'elemental', 'elder', 'corrupted', 'ancient', 'spirit', 'regional'] },
      baseSpeciesId: { type: 'string' },
      rank: RANK, level: { type: 'integer', minimum: 1, maximum: 300 }, menace: { type: 'integer', minimum: 1, maximum: 5 }, menaceLabel: { type: 'string' },
      element: EL, weakness: EL, sizeMeters: { type: 'number', minimum: 0 },
      rigId: id('rig_'), animSetId: id('anim_'),
      behavior: { type: 'string', enum: ['Passive', 'Territorial', 'Swarm', 'Pack', 'Ambush', 'Aggressive', 'Skittish', 'Guardian'] },
      aiPattern: { type: 'string', pattern: '^[a-z_]+(\\+stalker)?$' },
      stats: {
        type: 'object', additionalProperties: false, required: ['hp', 'atk', 'def', 'matk', 'mdef', 'spd'],
        properties: { hp: { type: 'integer', minimum: 1 }, atk: { type: 'integer', minimum: 0 }, def: { type: 'integer', minimum: 0 }, matk: { type: 'integer', minimum: 0 }, mdef: { type: 'integer', minimum: 0 }, spd: { type: 'integer', minimum: 1 } }
      },
      xp: { type: 'integer', minimum: 0 }, gold: { type: 'integer', minimum: 0 },
      attackIds: { type: 'array', minItems: 1, items: id('atk_') }, isUnique: { type: 'boolean' }, ring: { type: 'integer', minimum: 0, maximum: 9 },
      habitats: { type: 'array', minItems: 1, maxItems: 5, items: id('reg_') }, lootTableId: id('loot_'),
      signature: { type: 'string' }, look: { type: 'string', minLength: 40 }, fieldNote: { type: 'string' }, trope: { type: 'string' },
      designRecipe: {
        type: 'object', required: ['rigId', 'parts', 'material', 'palette', 'vfx', 'animSetId'],
        properties: { palette: { type: 'array', minItems: 3, maxItems: 3, items: { type: 'string', pattern: '^#[0-9a-f]{6}$' } } }
      }
    }
  },
  population: {
    title: 'Population variant', type: 'object', additionalProperties: false,
    required: ['id', 'name', 'speciesId', 'regionId', 'tier', 'rank', 'level', 'size', 'ring', 'look', 'spawn'],
    properties: {
      id: { type: 'string', pattern: '^pop_[0-9]{5}$' }, name: { type: 'string' }, speciesId: id('mon_'), regionId: id('reg_'), region: { type: 'string' },
      tier: { type: 'string', enum: ['Runt', 'Juvenile', 'Adult', 'Scarred', 'Alpha', 'Albino', 'Elderborn', 'Unique'] },
      rank: RANK, level: { type: 'integer', minimum: 1, maximum: 300 }, size: { type: 'number' }, ring: { type: 'integer', minimum: 0, maximum: 9 },
      look: { type: 'string' }, spawn: { type: 'string', enum: ['Day', 'Night', 'Day & Night', 'Story'] }
    }
  },
  attack: {
    title: 'Attack', type: 'object', additionalProperties: false,
    required: ['id', 'name', 'kind', 'power', 'cooldownSec', 'telegraph', 'element'],
    properties: {
      id: id('atk_'), name: { type: 'string' },
      kind: { type: 'string', enum: ['melee', 'ranged', 'aoe', 'grab', 'dash', 'magic', 'buff', 'debuff', 'summon', 'counter', 'heal', 'evade', 'stealth'] },
      power: { type: 'number', minimum: 0 }, cooldownSec: { type: 'number', minimum: 0 },
      telegraph: { type: 'string', enum: ['none', 'blue', 'red', 'gold'] }, element: EL
    }
  },
  loot_table: {
    title: 'Loot table', type: 'object', additionalProperties: false, required: ['id', 'entries'],
    properties: {
      id: id('loot_'), family: { type: 'string' }, rank: RL,
      entries: {
        type: 'array', minItems: 1,
        items: { type: 'object', additionalProperties: false, required: ['itemId', 'weight', 'min', 'max'], properties: { itemId: id('itm_'), weight: { type: 'integer', minimum: 1 }, min: { type: 'integer', minimum: 0 }, max: { type: 'integer', minimum: 1 } } }
      }
    }
  },
  item: {
    title: 'Item', type: 'object', additionalProperties: false, required: ['id', 'name', 'category'],
    properties: {
      id: id('itm_'), name: { type: 'string', minLength: 1 },
      category: { type: 'string', enum: ['material', 'core', 'weapon', 'armor', 'accessory', 'consumable', 'key', 'relic'] },
      rank: RL, rarity: { type: 'string', enum: ['Common', 'Uncommon', 'Rare', 'Epic', 'Legendary', 'Mythic', 'Divine'] },
      slot: { type: 'string' }, value: { type: 'integer', minimum: 0 }, stats: { type: 'object' }, flavor: { type: 'string' }, setId: { type: 'string' }
    }
  },
  npc: {
    title: 'NPC', type: 'object', additionalProperties: false, required: ['id', 'name', 'tier', 'homeRegion', 'role', 'backstory'],
    properties: {
      id: id('npc_'), name: { type: 'string' }, tier: { type: 'string', enum: ['core', 'major', 'townsfolk'] }, race: { type: 'string' },
      homeRegion: id('reg_'), settlement: { type: 'string' }, role: { type: 'string' }, backstory: { type: 'string', minLength: 20 },
      secret: { type: 'string' }, faction: { type: 'string' }, romanceable: { type: 'boolean' }, canDie: { type: 'boolean' },
      relationships: { type: 'array', items: { type: 'object', required: ['npcId', 'kind'], properties: { npcId: id('npc_'), kind: { type: 'string' } } } }
    }
  },
  quest: {
    title: 'Quest', type: 'object', additionalProperties: false, required: ['id', 'title', 'rank', 'type', 'giver', 'region', 'objectives', 'rewards'],
    properties: {
      id: id('qst_'), title: { type: 'string' }, rank: RANK,
      type: { type: 'string', enum: ['Main', 'Subjugation', 'Gathering', 'Escort', 'Delivery', 'Investigation', 'Exploration', 'Defense', 'Capture', 'Bounty', 'Dungeon', 'OddJob', 'Trial', 'Faction', 'Companion', 'Class', 'Hidden', 'Divine'] },
      giver: id('npc_'), region: id('reg_'), summary: { type: 'string' },
      requirements: { type: 'object', properties: { minRank: RL, minLevel: { type: 'integer', minimum: 1, maximum: 300 }, prerequisites: { type: 'array', items: id('qst_') }, partySize: { type: 'string' } } },
      objectives: { type: 'array', minItems: 1, items: { type: 'object', required: ['kind'], properties: { kind: { type: 'string', enum: ['kill', 'collect', 'talk', 'escort', 'reach', 'defend', 'tame', 'choice'] }, target: { type: 'string' }, count: { type: 'integer', minimum: 1 } } } },
      rewards: { type: 'object', properties: { gold: { type: 'integer', minimum: 0 }, gp: { type: 'integer', minimum: 0 }, xp: { type: 'integer', minimum: 0 }, items: { type: 'array', items: id('itm_') } } }
    }
  },
  weekly_quest: {
    title: 'Weekly board quest (repeatable, tied to a weekday)', type: 'object', additionalProperties: false,
    required: ['id', 'title', 'day', 'slot', 'type', 'trope', 'giver', 'region', 'rankMin', 'rankMax', 'timeOfDay', 'regionState', 'repeat', 'summary', 'objectives', 'rewards'],
    properties: {
      id: id('qst_wk_'), title: { type: 'string', minLength: 1 },
      day: { type: 'string', enum: ['Solenday', 'Maelsday', 'Thorsday', 'Sylvasday', 'Kaelsday', 'Morrowsday', 'Vexday', 'Any', 'Week'] },
      slot: { type: 'string', enum: ['special', 'daily', 'weekly'] },
      type: { type: 'string', enum: ['Subjugation', 'Gathering', 'Escort', 'Delivery', 'Investigation', 'Exploration', 'Defense', 'Capture', 'Bounty', 'OddJob', 'Faction', 'Companion', 'Class', 'Hidden', 'Divine'] },
      trope: { type: 'string', minLength: 1 }, giver: id('npc_'), region: id('reg_'), rankMin: RL, rankMax: RL,
      timeOfDay: { type: 'string', enum: ['morning', 'day', 'dusk', 'night', 'any'] },
      regionState: { type: 'string', enum: ['any', 'besieged', 'liberated'] },
      repeat: { type: 'string', enum: ['weekly'] }, summary: { type: 'string', minLength: 1 },
      objectives: { type: 'array', minItems: 1, items: { type: 'object', required: ['kind'], properties: { kind: { type: 'string', enum: ['kill', 'collect', 'talk', 'escort', 'reach', 'defend', 'tame', 'choice'] }, target: { type: 'string' }, count: { type: 'integer', minimum: 1 } } } },
      rewards: { type: 'object', properties: { gold: { type: 'integer', minimum: 0 }, gp: { type: 'integer', minimum: 0 }, xp: { type: 'integer', minimum: 0 }, items: { type: 'array', items: id('itm_') } } },
      twists: { type: 'array', items: { type: 'string' } }
    }
  }
};
for (const [name, s] of Object.entries(SCHEMAS)) {
  fs.writeFileSync(path.join(OUT, `${name}.schema.json`), JSON.stringify({ $schema: 'http://json-schema.org/draft-07/schema#', ...s }, null, 1));
}
console.log('Schemas:', Object.keys(SCHEMAS).join(', '));
