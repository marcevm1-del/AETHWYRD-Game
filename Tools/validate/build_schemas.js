// Writes the JSON Schemas in Data/Schemas. Rerun after changing a schema here.
// Usage: node Tools/validate/build_schemas.js
const fs = require('fs');
const path = require('path');
const OUT = path.join(__dirname, '..', '..', 'Data', 'Schemas');
fs.mkdirSync(OUT, { recursive: true });

const RANK = { type: 'string', pattern: '^(F|E|D|C|B|A|S|SS|SSS|EX)[+-]?$' };
const RL = { type: 'string', enum: ['F', 'E', 'D', 'C', 'B', 'A', 'S', 'SS', 'SSS', 'EX'] };
const EL = { type: 'string', enum: ['None', 'Fire', 'Water', 'Ice', 'Lightning', 'Earth', 'Wind', 'Nature', 'Poison', 'Light', 'Dark', 'Blood', 'Void'] };
const FLAG = { type: 'string', pattern: '^[a-z][a-z0-9_]*$' };
const WEEKDAYS = ['Solenday', 'Maelsday', 'Thorsday', 'Sylvasday', 'Kaelsday', 'Morrowsday', 'Vexday'];
const id = prefix => ({ type: 'string', pattern: `^${prefix}[a-z0-9_]+$` });

const SCHEMAS = {
  region: {
    title: 'Region', type: 'object', additionalProperties: false,
    required: ['id', 'name', 'biomes', 'rankMin', 'rankMax', 'ring', 'layer'],
    properties: {
      id: id('reg_'), name: { type: 'string', minLength: 1 }, biomes: { type: 'array', minItems: 1, items: { type: 'string' } },
      rankMin: RL, rankMax: RL, ring: { type: 'integer', minimum: 0, maximum: 9 },
      layer: { type: 'string', enum: ['surface', 'underworld', 'post-game'] },
      allowedFamilies: { type: 'array', items: { type: 'string' } },
      // Regional Siege & Liberation (Systems; Canon §4b)
      tyrantSpeciesId: id('mon_'), siegeFaction: { type: 'string' },
      defenceSettlements: { type: 'array', minItems: 1, items: { type: 'string', minLength: 1 } },
      initialState: { type: 'string', enum: ['besieged', 'weakened', 'liberated'] },
      noSiege: { type: 'boolean' }, noSiegeReason: { type: 'string' }
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
      rank: RANK, level: { type: 'integer', minimum: 1, maximum: 300 },
      levelRange: { type: 'array', minItems: 2, maxItems: 2, items: { type: 'integer', minimum: 1, maximum: 300 } },
      bossHpMult: { type: 'number', minimum: 1 }, menace: { type: 'integer', minimum: 1, maximum: 5 }, menaceLabel: { type: 'string' },
      element: EL, weakness: EL, sizeMeters: { type: 'number', minimum: 0 },
      rigId: id('rig_'), animSetId: id('anim_'),
      behavior: { type: 'string', enum: ['Passive', 'Territorial', 'Swarm', 'Pack', 'Ambush', 'Aggressive', 'Skittish', 'Guardian'] },
      aiPattern: { type: 'string', pattern: '^[a-z_]+(\\+stalker)?$' },
      stats: {
        type: 'object', additionalProperties: false, required: ['hp', 'atk', 'def', 'matk', 'mdef', 'spd'],
        properties: { hp: { type: 'integer', minimum: 1 }, atk: { type: 'integer', minimum: 0 }, def: { type: 'integer', minimum: 0 }, matk: { type: 'integer', minimum: 0 }, mdef: { type: 'integer', minimum: 0 }, spd: { type: 'integer', minimum: 1 } }
      },
      xp: { type: 'integer', minimum: 0 }, gold: { type: 'integer', minimum: 0 },
      attackIds: { type: 'array', minItems: 1, items: id('atk_') }, isUnique: { type: 'boolean' }, isTyrant: { type: 'boolean' }, ring: { type: 'integer', minimum: 0, maximum: 9 },
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
        items: { type: 'object', additionalProperties: false, required: ['itemId', 'chance', 'min', 'max'], properties: { itemId: id('itm_'), chance: { type: 'number', minimum: 0.000001, maximum: 1 }, min: { type: 'integer', minimum: 0 }, max: { type: 'integer', minimum: 1 } } }
      }
    }
  },
  item: {
    title: 'Item', type: 'object', additionalProperties: false, required: ['id', 'name', 'category'],
    properties: {
      id: id('itm_'), name: { type: 'string', minLength: 1 },
      category: { type: 'string', enum: ['material', 'core', 'weapon', 'armor', 'accessory', 'consumable', 'key', 'relic'] },
      rank: RL, rarity: { type: 'string', enum: ['Common', 'Uncommon', 'Rare', 'Epic', 'Legendary', 'Mythic', 'Divine'] },
      slot: { type: 'string' }, weaponType: { type: 'string', description: 'weapons: must appear in a class weapons list' }, armorWeight: { type: 'string', enum: ['cloth', 'light', 'medium', 'heavy'] }, value: { type: 'integer', minimum: 0 }, stats: { type: 'object' }, flavor: { type: 'string' }, setId: { type: 'string' }
    }
  },
  npc: {
    title: 'NPC', type: 'object', additionalProperties: false, required: ['id', 'name', 'tier', 'homeRegion', 'role', 'backstory'],
    properties: {
      id: id('npc_'), name: { type: 'string' }, tier: { type: 'string', enum: ['core', 'major', 'townsfolk'] }, race: { type: 'string' },
      homeRegion: id('reg_'), settlement: { type: 'string' }, role: { type: 'string' }, backstory: { type: 'string', minLength: 20 },
      secret: { type: 'string' }, faction: { type: 'string' }, romanceable: { type: 'boolean' }, canDie: { type: 'boolean' },
      relationships: { type: 'array', items: { type: 'object', required: ['npcId', 'kind'], properties: { npcId: id('npc_'), kind: { type: 'string' } } } },
      states: { type: 'array', items: { type: 'object', additionalProperties: false, required: ['flag', 'note'], properties: { flag: FLAG, name: { type: 'string' }, role: { type: 'string' }, settlement: { type: 'string' }, note: { type: 'string', minLength: 5 } } } },
      schedule: { type: 'array', items: { type: 'object', additionalProperties: false, required: ['part', 'place'], properties: { part: { type: 'string', enum: ['morning', 'day', 'dusk', 'night'] }, place: { type: 'string', minLength: 1 }, days: { type: 'array', items: { type: 'string', enum: WEEKDAYS } } } } }
    }
  },
  quest: {
    title: 'Quest', type: 'object', additionalProperties: false, required: ['id', 'title', 'rank', 'type', 'giver', 'region', 'objectives', 'rewards'],
    properties: {
      id: id('qst_'), title: { type: 'string' }, rank: RANK,
      type: { type: 'string', enum: ['Main', 'Subjugation', 'Gathering', 'Escort', 'Delivery', 'Investigation', 'Exploration', 'Defense', 'SiegeDefence', 'Capture', 'Bounty', 'Dungeon', 'OddJob', 'Trial', 'Faction', 'Companion', 'Class', 'Hidden', 'Divine'] },
      giver: id('npc_'), region: id('reg_'), summary: { type: 'string' },
      regionState: { type: 'string', enum: ['any', 'besieged', 'liberated'] },
      requirements: { type: 'object', additionalProperties: false, properties: { minLevel: { type: 'integer', minimum: 1, maximum: 300 }, partySize: { type: 'string' } } },
      prerequisites: { type: 'object', additionalProperties: false, properties: { quests: { type: 'array', items: id('qst_') }, flags: { type: 'array', items: FLAG }, act: { type: 'integer', minimum: 0, maximum: 6 }, rank: RL } },
      setsFlags: { type: 'array', items: FLAG },
      objectives: { type: 'array', minItems: 1, items: { type: 'object', required: ['kind'], properties: { kind: { type: 'string', enum: ['kill', 'collect', 'talk', 'escort', 'reach', 'defend', 'tame', 'choice'] }, target: { type: 'string' }, count: { type: 'integer', minimum: 1 }, from: { ...id('mon_'), description: 'collect: the species that drops the item while the quest is active' } } } },
      rewards: { type: 'object', properties: { gold: { type: 'integer', minimum: 0 }, gp: { type: 'integer', minimum: 0 }, xp: { type: 'integer', minimum: 0 }, items: { type: 'array', items: id('itm_') } } }
    }
  },
  siege_wave: {
    title: 'Siege wave set for one besieged region', type: 'object', additionalProperties: false,
    required: ['id', 'regionId', 'faction', 'rankMin', 'rankMax', 'tyrantSpeciesId', 'waves', 'escalation', 'targetMinutes'],
    properties: {
      id: id('siege_'), regionId: id('reg_'), faction: { type: 'string' }, factionMixed: { type: 'boolean' },
      rankMin: RL, rankMax: RL, tyrantSpeciesId: id('mon_'),
      waves: {
        type: 'array', minItems: 1,
        items: {
          type: 'object', additionalProperties: false, required: ['wave', 'units'],
          properties: {
            wave: { type: 'integer', minimum: 1 }, lieutenantSpeciesId: id('mon_'),
            units: { type: 'array', minItems: 1, items: { type: 'object', additionalProperties: false, required: ['speciesId', 'count'], properties: { speciesId: id('mon_'), count: { type: 'integer', minimum: 1 } } } }
          }
        }
      },
      escalation: { type: 'object', additionalProperties: false, required: ['maxStep', 'countGrowthPerStep', 'eliteChancePerStep'], properties: { maxStep: { type: 'integer', minimum: 0 }, countGrowthPerStep: { type: 'number', minimum: 0 }, eliteChancePerStep: { type: 'number', minimum: 0, maximum: 1 } } },
      targetMinutes: { type: 'array', minItems: 2, maxItems: 2, items: { type: 'number', minimum: 1 } }
    }
  },
  class: {
    title: 'Player class', type: 'object', additionalProperties: false,
    required: ['id', 'name', 'tier', 'growth', 'recommendedAllocation', 'weapons', 'armor', 'mechanic', 'kit'],
    properties: {
      id: id('cls_'), name: { type: 'string' }, tier: { type: 'string', enum: ['base', 'advanced', 'expert', 'master', 'legendary', 'hidden', 'monster'] }, role: { type: 'string' },
      growth: { type: 'object', additionalProperties: false, properties: Object.fromEntries(["str","vit","agi","dex","int","wis","luk","cha"].map(k => [k, { type: 'number', minimum: 0 }])) },
      recommendedAllocation: { type: 'object', additionalProperties: false, properties: Object.fromEntries(["str","vit","agi","dex","int","wis","luk","cha"].map(k => [k, { type: 'number', minimum: 0, maximum: 1 }])) },
      weapons: { type: 'array', items: { type: 'string' } }, armor: { type: 'array', items: { type: 'string' } }, mechanic: { type: 'string' },
      starterWeaponId: id('itm_'),
      kit: {
        type: 'array', minItems: 1,
        items: {
          type: 'object', additionalProperties: false, required: ['id', 'name', 'unlockLevel', 'kind', 'slot', 'hits', 'cooldownSec', 'element'],
          properties: {
            id: id('skl_'), name: { type: 'string' }, unlockLevel: { type: 'integer', minimum: 1, maximum: 300 },
            kind: { type: 'string', enum: ['chain', 'launcher', 'dash', 'ranged', 'aoe', 'buff', 'utility', 'ultimate'] },
            slot: { type: 'string', enum: ['basic', 'skill', 'ultimate'] },
            effect: { type: 'string' },
            // Buffs, heals, utilities and support ultimates may have no hits; other kinds need at least one (validate.js).
            hits: { type: 'array', minItems: 0, items: { type: 'object', additionalProperties: false, required: ['power', 'weight'], properties: { power: { type: 'number', minimum: 0 }, weight: { type: 'string', enum: ['light', 'medium', 'heavy', 'launch', 'ultimate', 'skill'] } } } },
            costSp: { type: 'number', minimum: 0 }, costMp: { type: 'number', minimum: 0 }, costAwakening: { type: 'number', minimum: 0 },
            cooldownSec: { type: 'number', minimum: 0 }, element: EL, appliesElement: { type: 'boolean' }
          }
        }
      },
      passives: {
        type: 'array',
        items: {
          type: 'object', additionalProperties: false, required: ['id', 'name', 'unlockLevel', 'effect'],
          properties: { id: id('psv_'), name: { type: 'string' }, unlockLevel: { type: 'integer', minimum: 1, maximum: 300 }, effect: { type: 'string', minLength: 3 } }
        }
      },
      trainer: { type: 'string' }, classQuest: { type: 'string' }
    }
  },
  story_flag: {
    title: 'Story flag', type: 'object', additionalProperties: false, required: ['id', 'description', 'setBy'],
    properties: { id: FLAG, description: { type: 'string', minLength: 5 }, setBy: { type: 'string', enum: ['quest', 'story', 'system'] } }
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
,
  shop: {
    title: 'Shop (a merchant NPC: what they sell and what they buy)', type: 'object', additionalProperties: false, required: ['id', 'npcId', 'name', 'buys', 'stock'],
    properties: {
      id: id('shop_'), npcId: id('npc_'), name: { type: 'string', minLength: 1 }, note: { type: 'string' },
      buys: { type: 'object', additionalProperties: false, required: ['categories', 'rate'], properties: {
        categories: { type: 'array', items: { type: 'string', enum: ['weapon', 'armor', 'accessory', 'consumable', 'material', 'core', 'key'] } },
        rate: { type: 'number', minimum: 0, maximum: 1, description: 'fraction of item value paid; the Guild core buyback is 1.0 (posted price)' } } },
      stock: { type: 'array', items: { type: 'object', additionalProperties: false, required: ['itemId', 'price'], properties: {
        itemId: id('itm_'), price: { type: 'integer', minimum: 1, description: 'copper; authored retail price including the service premium' },
        quantity: { type: 'integer', minimum: 1, description: 'limited stock; omit for unlimited' } } } }
    }
  },
  inn: {
    title: 'Inn', type: 'object', additionalProperties: false,
    required: ['id', 'name', 'regionId', 'settlement', 'tier', 'ring', 'keeperName', 'rooms', 'dish', 'drink', 'quirk', 'rumorTheme', 'events', 'secret'],
    properties: {
      id: id('inn_'), name: { type: 'string', minLength: 1 }, regionId: id('reg_'), settlement: { type: 'string' },
      tier: { type: 'string', enum: ['village', 'town', 'city', 'special'] }, ring: { type: 'integer', minimum: 0, maximum: 9 },
      keeperNpcId: id('npc_'), keeperName: { type: 'string' },
      rooms: { type: 'array', minItems: 1, items: { type: 'object', additionalProperties: false, required: ['tier', 'priceCopper', 'rest'], properties: {
        tier: { type: 'string', enum: ['common', 'private', 'suite', 'signature'] }, name: { type: 'string' }, priceCopper: { type: 'integer', minimum: 0 }, rest: { type: 'string' }, perk: { type: 'string' } } } },
      dish: { type: 'object', required: ['name', 'effect'], properties: { name: { type: 'string' }, effect: { type: 'string' } } },
      drink: { type: 'object', required: ['name', 'effect'], properties: { name: { type: 'string' }, effect: { type: 'string' } } },
      quirk: { type: 'string' }, rumorTheme: { type: 'string' }, events: { type: 'array', items: { type: 'string' } }, secret: { type: 'string' }
    }
  }
};
for (const [name, s] of Object.entries(SCHEMAS)) {
  fs.writeFileSync(path.join(OUT, `${name}.schema.json`), JSON.stringify({ $schema: 'http://json-schema.org/draft-07/schema#', ...s }, null, 1));
}
console.log('Schemas:', Object.keys(SCHEMAS).join(', '));
