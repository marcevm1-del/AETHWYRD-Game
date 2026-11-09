// Writes the JSON Schemas in Data/Schemas. Rerun after changing a schema here.
// Usage: node Tools/validate/build_schemas.js
const fs = require('fs');
const path = require('path');
const OUT = path.join(__dirname, '..', '..', 'Data', 'Schemas');
fs.mkdirSync(OUT, { recursive: true });

const RANK = { type: 'string', pattern: '^(F|E|D|C|B|A|S|SS|SSS|EX)[+-]?$' };
const RL = { type: 'string', enum: ['F', 'E', 'D', 'C', 'B', 'A', 'S', 'SS', 'SSS', 'EX'] };
const EL = { type: 'string', enum: ['None', 'Fire', 'Water', 'Ice', 'Lightning', 'Earth', 'Wind', 'Nature', 'Poison', 'Light', 'Dark', 'Blood', 'Void'] };
const REACTION = { type: 'string', enum: ['Firestorm', 'StormPrison', 'Freeze', 'ThermalShock', 'Magma', 'Swirl', 'Wildfire', 'TwilightBurst', 'MiasmaBlast', 'Grounded'] };
const FLAG = { type: 'string', pattern: '^[a-z][a-z0-9_]*$' };
const WEEKDAYS = ['Solenday', 'Maelsday', 'Thorsday', 'Sylvasday', 'Kaelsday', 'Morrowsday', 'Vexday'];
const MAP_POINT = { type: 'array', minItems: 2, maxItems: 2, items: { type: 'number', minimum: 0, maximum: 150 } };
const MAP_TERRAIN = ['plains', 'forest', 'swamp', 'steppe', 'mountain', 'volcanic', 'tundra', 'desert', 'jungle', 'spirit', 'demon'];
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
      noSiege: { type: 'boolean' }, noSiegeReason: { type: 'string' },
      // Placement on the world map (150 x 100 map units; 12_Systems/world_map.md). Surface lands have a radius and
      // the terrain the map paints; underworld regions mark their gate; the Sky Archipelago floats.
      map: {
        type: 'object', additionalProperties: false, required: ['at'],
        properties: {
          at: MAP_POINT, radius: { type: 'number', minimum: 0, maximum: 20 }, isle: { type: 'boolean' }, floating: { type: 'boolean' },
          gate: { type: 'boolean' }, depth: { type: 'integer', minimum: 1, maximum: 5 },
          terrain: { type: 'array', minItems: 1, items: { type: 'string', enum: MAP_TERRAIN } },
          features: { type: 'array', items: { type: 'string', enum: ['city', 'ruins', 'coast', 'cave'] } },
          places: { type: 'object', additionalProperties: MAP_POINT }
        }
      }
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
      category: { type: 'string', enum: ['material', 'core', 'weapon', 'armor', 'accessory', 'consumable', 'key', 'relic', 'rune', 'scroll', 'part', 'fragment'] },
      rank: RL, rarity: { type: 'string', enum: ['Common', 'Uncommon', 'Rare', 'Epic', 'Legendary', 'Mythic', 'Divine'] },
      slot: { type: 'string' }, weaponType: { type: 'string', description: 'weapons: must appear in a class weapons list' }, armorWeight: { type: 'string', enum: ['cloth', 'light', 'medium', 'heavy'] }, value: { type: 'integer', minimum: 0 }, stats: { type: 'object' }, flavor: { type: 'string' }, setId: { type: 'string' },
      meal: { type: 'object', additionalProperties: false, required: ['effects', 'seconds'], description: 'cooking buff (Well Fed slot)', properties: {
        effects: { type: 'array', minItems: 1, items: { type: 'object', additionalProperties: false, required: ['stat', 'amount'], properties: { stat: { type: 'string', minLength: 1 }, amount: { type: 'number' } } } },
        seconds: { type: 'number', exclusiveMinimum: 0 } } }
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
  },
  // Combat reaction table (Data/Combat/reactions.json; 12_Systems/combat.md). Root object, not a row list.
  reactions: {
    title: 'Reactions', type: 'object', additionalProperties: false, required: ['version', 'notes', 'swirl', 'reactions', 'synergies'],
    properties: {
      version: { type: 'integer', minimum: 1 }, notes: { type: 'string' },
      swirl: { type: 'object', additionalProperties: false, required: ['element', 'spreadRadiusM', 'spreadDamageMult', 'maxSpreadTargets'], properties: {
        element: { type: 'string', enum: ['Wind'] }, spreadRadiusM: { type: 'number', minimum: 0 },
        spreadDamageMult: { type: 'number', minimum: 0 }, maxSpreadTargets: { type: 'integer', minimum: 0 } } },
      reactions: { type: 'array', minItems: 1, items: { type: 'object', additionalProperties: false, required: ['id', 'elements', 'consumesAura'], properties: {
        id: REACTION, elements: { type: 'array', minItems: 2, maxItems: 2, items: EL }, consumesAura: { type: 'boolean' },
        bonusDamageMult: { type: 'number', exclusiveMinimum: 0 }, note: { type: 'string' },
        dot: { type: 'object', additionalProperties: false, required: ['element', 'damagePerSecMult', 'durationSec', 'tickSec'], properties: {
          element: EL, damagePerSecMult: { type: 'number', minimum: 0 }, durationSec: { type: 'number', minimum: 0 }, tickSec: { type: 'number', minimum: 0 } } },
        hazard: { type: 'object', additionalProperties: false, required: ['kind', 'radiusM', 'durationSec', 'damagePerSecMult'], properties: {
          kind: { type: 'string', pattern: '^[a-z][a-z0-9_]*$' }, radiusM: { type: 'number', minimum: 0 }, durationSec: { type: 'number', minimum: 0 }, damagePerSecMult: { type: 'number', minimum: 0 } } },
        status: { type: 'object', additionalProperties: false, required: ['kind', 'durationSec'], properties: {
          kind: { type: 'string', enum: ['freeze', 'stun'] }, durationSec: { type: 'number', minimum: 0 } } } } } },
      synergies: { type: 'array', items: { type: 'object', additionalProperties: false, required: ['id', 'first', 'then', 'windowSec', 'bonusDamageMult'], properties: {
        id: { type: 'string', pattern: '^[a-z][a-z0-9_]*$' }, first: REACTION, then: REACTION,
        windowSec: { type: 'number', minimum: 0 }, bonusDamageMult: { type: 'number', exclusiveMinimum: 0 }, note: { type: 'string' } } } }
    }
  },
  // Boss armor and weak points (Data/Monsters/boss_weakpoints.json). boss_phases.json is untouched.
  boss_weakpoints: {
    title: 'BossWeakPoints', type: 'object', additionalProperties: false, required: ['version', 'notes', 'bosses'],
    properties: {
      version: { type: 'integer', minimum: 1 }, notes: { type: 'string' },
      armorDamageByWeight: { type: 'object', additionalProperties: false, required: ['light', 'medium', 'heavy', 'launch', 'skill', 'ultimate'], properties: {
        light: { type: 'number', exclusiveMinimum: 0 }, medium: { type: 'number', exclusiveMinimum: 0 }, heavy: { type: 'number', exclusiveMinimum: 0 },
        launch: { type: 'number', exclusiveMinimum: 0 }, skill: { type: 'number', exclusiveMinimum: 0 }, ultimate: { type: 'number', exclusiveMinimum: 0 } } },
      bosses: { type: 'array', items: { type: 'object', additionalProperties: false, required: ['speciesId', 'armor', 'weakPoints'], properties: {
        speciesId: id('mon_'),
        armor: { type: 'object', additionalProperties: false, required: ['maxArmor', 'breakSec', 'damageTakenMultWhileBroken', 'regenDelaySec'], properties: {
          maxArmor: { type: 'number', minimum: 0 }, breakSec: { type: 'number', minimum: 0 }, damageTakenMultWhileBroken: { type: 'number', minimum: 1 }, regenDelaySec: { type: 'number', exclusiveMinimum: 0 } } },
        weakPoints: { type: 'array', items: { type: 'object', additionalProperties: false, required: ['id', 'label', 'bodyPart', 'damageMult', 'armorDamageMult', 'exposedInPhases'], properties: {
          id: { type: 'string', pattern: '^[a-z][a-z0-9_]*$' }, label: { type: 'string', minLength: 1 }, bodyPart: { type: 'string', minLength: 1 },
          damageMult: { type: 'number', exclusiveMinimum: 0 }, armorDamageMult: { type: 'number', exclusiveMinimum: 0 },
          exposedInPhases: { type: 'array', minItems: 1, items: { type: 'string', minLength: 1 } }, exposedSec: { type: 'number', minimum: 0 } } } } } } }
    }
  }
};
// --- Player locomotion table (Data/Player/locomotion.json, a singleton object; Wave A1) ---
{
  const MULT = { type: 'number', exclusiveMinimum: 0, maximum: 3 };
  const mults = keys => ({ type: 'object', additionalProperties: false, required: keys, properties: Object.fromEntries(keys.map(k => [k, MULT])) });
  const num = (min, max) => ({ type: 'number', minimum: min, maximum: max });
  SCHEMAS.locomotion = {
    title: 'Player locomotion table', type: 'object', additionalProperties: false,
    required: ['version', 'baseSpeed', 'state', 'terrain', 'condition', 'slope', 'blend', 'damping'],
    properties: {
      version: { type: 'integer', minimum: 1 },
      baseSpeed: { type: 'number', minimum: 0.1, maximum: 30 },
      state: (() => { // idle is a standing speed of 0, so it may be 0; the rest must move
        const st = mults(['idle', 'walk', 'run', 'sprint', 'air', 'dodge']);
        st.properties.idle = { type: 'number', minimum: 0, maximum: 3 };
        return st;
      })(),
      terrain: mults(MAP_TERRAIN),
      condition: { type: 'object', additionalProperties: false, properties: { exhausted: MULT, attacking: MULT, charging: MULT, encumbered: MULT, wet: MULT } },
      slope: { type: 'object', additionalProperties: false, required: ['limitDeg', 'uphillK', 'downhillK', 'minMult', 'maxMult'],
        properties: { limitDeg: num(0, 89), uphillK: num(0, 3), downhillK: num(0, 3), minMult: num(0, 1), maxMult: num(1, 3) } },
      blend: { type: 'object', additionalProperties: false, required: ['idleMaxSpeed', 'walkEnter', 'runEnter', 'sprintEnter', 'hysteresis'],
        properties: { idleMaxSpeed: num(0, 30), walkEnter: num(0, 30), runEnter: num(0, 30), sprintEnter: num(0, 30), hysteresis: num(0, 5) } },
      damping: { type: 'object', additionalProperties: false, required: ['speedSec', 'groundedExitGraceSec', 'combatLayerBlendSec', 'pelvisSec'],
        properties: { speedSec: num(0, 5), groundedExitGraceSec: num(0, 5), combatLayerBlendSec: num(0, 5), pelvisSec: num(0, 5) } }
    }
  };
}
// --- Crafting rules, life skills and recipe rows (Wave B; Data/Items/crafting_rules.json, life_skills.json, recipes.json) ---
{
  const TIER_ID = { type: 'string', enum: ['poor', 'normal', 'fine', 'superior', 'masterwork', 'legendary'] };
  const RANKS9 = ['F', 'E', 'D', 'C', 'B', 'A', 'S', 'SS', 'SSS'];
  const R9 = { type: 'string', enum: RANKS9 };
  const byKeys = (keys, val) => ({ type: 'object', additionalProperties: false, required: keys, properties: Object.fromEntries(keys.map(k => [k, val])) });
  const STATIONS = ['campfire', 'forge', 'alembic', 'loom', 'tannery', 'hearth', 'brewery', 'jewelers_bench', 'rune_anvil', 'enchanting_table'];
  const SKILL_ID = { type: 'string', pattern: '^[a-z][a-z0-9_]*$' };
  SCHEMAS.crafting_rules = {
    title: 'Crafting quality rules', type: 'object', additionalProperties: false,
    required: ['notes', 'qualityTiers', 'formula', 'rankQualityCap', 'stationQualityCap'],
    properties: {
      notes: { type: 'string' },
      qualityTiers: { type: 'array', minItems: 2, items: { type: 'object', additionalProperties: false,
        required: ['id', 'name', 'index', 'statMult', 'valueMult', 'buffMult', 'mark', 'nameable', 'craftable'],
        properties: { id: TIER_ID, name: { type: 'string', minLength: 1 }, index: { type: 'integer', minimum: 0, maximum: 9 },
          statMult: { type: 'number', exclusiveMinimum: 0, maximum: 1.3 }, valueMult: { type: 'number', exclusiveMinimum: 0 },
          buffMult: { type: 'number', exclusiveMinimum: 0 }, mark: { type: 'boolean' }, nameable: { type: 'boolean' }, craftable: { type: 'boolean' } } } },
      formula: { type: 'object', additionalProperties: false, required: ['skillBonusPerRank', 'experimentBonus', 'jitterMax', 'tierAboveBest'],
        properties: { skillBonusPerRank: { type: 'number', minimum: 0, maximum: 1 }, experimentBonus: { type: 'number', minimum: 0, maximum: 2 },
          jitterMax: { type: 'number', minimum: 0, maximum: 0.99 }, tierAboveBest: { type: 'integer', minimum: 0, maximum: 5 } } },
      rankQualityCap: byKeys(RANKS9, TIER_ID),
      stationQualityCap: byKeys(STATIONS, TIER_ID)
    }
  };
  SCHEMAS.life_skills = {
    title: 'Life skill ladders', type: 'object', additionalProperties: false,
    required: ['notes', 'ranks', 'commissionFromRank', 'xp', 'skills'],
    properties: {
      notes: { type: 'string' },
      ranks: { type: 'array', minItems: 9, maxItems: 9, items: R9 },
      commissionFromRank: R9,
      xp: { type: 'object', additionalProperties: false,
        required: ['xpToReach', 'firstCraftMultiplier', 'trivialRankGap', 'trivialMultiplier', 'minXp', 'defaultRecipeXpByRank', 'gatherXpPerNode'],
        properties: {
          xpToReach: byKeys(RANKS9, { type: 'integer', minimum: 0 }),
          firstCraftMultiplier: { type: 'number', minimum: 1, maximum: 20 }, trivialRankGap: { type: 'integer', minimum: 1, maximum: 9 },
          trivialMultiplier: { type: 'number', exclusiveMinimum: 0, maximum: 1 }, minXp: { type: 'integer', minimum: 1 },
          defaultRecipeXpByRank: byKeys(RANKS9, { type: 'integer', minimum: 1 }),
          gatherXpPerNode: byKeys(RANKS9, { type: 'integer', minimum: 1 }) } },
      skills: { type: 'array', minItems: 1, items: { type: 'object', additionalProperties: false, required: ['id', 'name', 'kind', 'station'],
        properties: { id: SKILL_ID, name: { type: 'string', minLength: 1 }, kind: { type: 'string', enum: ['craft', 'gather', 'deferred'] },
          station: { type: ['string', 'null'] }, notes: { type: 'string' } } } }
    }
  };
  // One row of recipes.json (validated row by row in validate.js; cross-references are checked there too).
  const ITEM_COUNT = { type: 'object', additionalProperties: false, required: ['itemId', 'count'], properties: { itemId: id('itm_'), count: { type: 'integer', minimum: 1 } } };
  SCHEMAS.recipe = {
    title: 'Recipe', type: 'object', additionalProperties: false, required: ['id', 'name', 'skill', 'station', 'output', 'inputs'],
    properties: {
      id: id('rcp_'), name: { type: 'string', minLength: 1 }, skill: SKILL_ID, station: { type: 'string', minLength: 1 },
      output: ITEM_COUNT, inputs: { type: 'array', minItems: 1, items: ITEM_COUNT },
      learnFrom: { type: 'object', additionalProperties: false, required: ['npcId', 'price'], properties: { npcId: id('npc_'), price: { type: 'integer', minimum: 0 } } },
      lifeRank: R9, xp: { type: 'integer', minimum: 1 }, attuneItem: id('itm_')
    }
  };
}
// --- Gear customisation: sockets, runes, rune words, enchantments, assemblies (Step 1 of part 2; Data/Items/gear_rules.json) ---
{
  const CATS = { type: 'array', minItems: 1, uniqueItems: true, items: { type: 'string', enum: ['weapon', 'armor', 'accessory'] } };
  const STATS = { type: 'object', minProperties: 1, additionalProperties: false, properties: Object.fromEntries(['atk', 'matk', 'def', 'mdef', 'hp', 'crit'].map(k => [k, { type: 'number', exclusiveMinimum: 0 }])) };
  const RARITIES = ['Common', 'Uncommon', 'Rare', 'Epic', 'Legendary', 'Mythic', 'Divine'];
  SCHEMAS.gear_rules = {
    title: 'Gear rules (sockets, runes, enchantments, assemblies)', type: 'object', additionalProperties: false,
    required: ['notes', 'sockets', 'enchantSlots', 'stations', 'runes', 'runeWords', 'enchantments', 'assemblies'],
    properties: {
      notes: { type: 'string' },
      sockets: { type: 'object', additionalProperties: false, required: ['byRarity', 'masterworkBonus', 'max'], properties: {
        byRarity: { type: 'object', additionalProperties: false, required: RARITIES, properties: Object.fromEntries(RARITIES.map(r => [r, { type: 'integer', minimum: 0, maximum: 3 }])) },
        masterworkBonus: { type: 'integer', minimum: 0, maximum: 1 }, max: { type: 'integer', minimum: 1, maximum: 3 } } },
      enchantSlots: { type: 'integer', minimum: 1, maximum: 1 },
      stations: { type: 'object', additionalProperties: false, required: ['socket', 'enchant', 'assemble'], properties: { socket: { type: 'string' }, enchant: { type: 'string' }, assemble: { type: 'string' } } },
      runes: { type: 'array', minItems: 1, items: { type: 'object', additionalProperties: false, required: ['id', 'fits', 'stats'], properties: { id: id('itm_rune_'), fits: CATS, stats: STATS } } },
      runeWords: { type: 'array', items: { type: 'object', additionalProperties: false, required: ['id', 'name', 'runes', 'fits', 'stats'], properties: {
        id: id('word_'), name: { type: 'string', minLength: 1 }, runes: { type: 'array', minItems: 2, maxItems: 3, items: id('itm_rune_') }, fits: CATS, stats: STATS } } },
      enchantments: { type: 'array', minItems: 1, items: { type: 'object', additionalProperties: false, required: ['id', 'name', 'itemId', 'fits', 'stats'], properties: {
        id: id('enc_'), name: { type: 'string', minLength: 1 }, itemId: id('itm_scroll_'), fits: CATS, stats: STATS, element: EL } } },
      assemblies: { type: 'array', items: { type: 'object', additionalProperties: false, required: ['id', 'name', 'skill', 'lifeRank', 'output', 'blades', 'hilts'], properties: {
        id: id('asm_'), name: { type: 'string', minLength: 1 }, skill: { type: 'string', pattern: '^[a-z][a-z0-9_]*$' }, lifeRank: { type: 'string', enum: ['F', 'E', 'D', 'C', 'B', 'A', 'S', 'SS', 'SSS'] },
        xp: { type: 'integer', minimum: 1 }, output: id('itm_'),
        blades: { type: 'array', minItems: 1, items: id('itm_part_') }, hilts: { type: 'array', minItems: 1, items: id('itm_part_') } } } }
    }
  };
}
// --- Housing and farming (Step 2 of part 2; Data/World/housing.json, Data/Items/crops.json) ---
{
  const R9 = { type: 'string', enum: ['F', 'E', 'D', 'C', 'B', 'A', 'S', 'SS', 'SSS'] };
  SCHEMAS.housing = {
    title: 'Home tiers', type: 'object', additionalProperties: false, required: ['notes', 'tiers', 'starterSeeds'],
    properties: {
      notes: { type: 'string' },
      tiers: { type: 'array', minItems: 2, items: { type: 'object', additionalProperties: false, required: ['id', 'name', 'rank', 'cost', 'storageStacks', 'plots', 'features'], properties: {
        id: { type: 'string', pattern: '^[a-z][a-z0-9_]*$' }, name: { type: 'string', minLength: 1 }, rank: R9, cost: { type: 'integer', minimum: 0 },
        storageStacks: { type: 'integer', minimum: 1, maximum: 500 }, plots: { type: 'integer', minimum: 0, maximum: 12 },
        features: { type: 'array', uniqueItems: true, items: { type: 'string', pattern: '^[a-z][a-z0-9_]*$' } } } } },
      starterSeeds: { type: 'object', additionalProperties: { type: 'integer', minimum: 1, maximum: 10 } }
    }
  };
  SCHEMAS.crops = {
    title: 'Home crops', type: 'object', additionalProperties: false, required: ['notes', 'skill', 'qualityByRank', 'crops'],
    properties: {
      notes: { type: 'string' }, skill: { type: 'string', pattern: '^[a-z][a-z0-9_]*$' },
      qualityByRank: { type: 'object', additionalProperties: false, required: ['F', 'E', 'D', 'C', 'B', 'A', 'S', 'SS', 'SSS'], properties: Object.fromEntries(['F', 'E', 'D', 'C', 'B', 'A', 'S', 'SS', 'SSS'].map(r => [r, { type: 'string', enum: ['poor', 'normal', 'fine', 'superior', 'masterwork'] }])) },
      crops: { type: 'array', minItems: 1, items: { type: 'object', additionalProperties: false, required: ['id', 'name', 'seedItem', 'yieldItem', 'yieldCount', 'seedsBack', 'growHours', 'rank'], properties: {
        id: id('crop_'), name: { type: 'string', minLength: 1 }, seedItem: id('itm_seed_'), yieldItem: id('itm_'), yieldCount: { type: 'integer', minimum: 1, maximum: 10 },
        seedsBack: { type: 'integer', minimum: 1, maximum: 3 }, growHours: { type: 'number', minimum: 1, maximum: 240 }, rank: R9 } } }
    }
  };
}
// --- Stables and sanctuary (Step 3 of part 2; Data/Companions/stables.json) ---
{
  const P = { type: 'number', minimum: 0, maximum: 1 };
  SCHEMAS.stables = {
    title: 'Stables, breeding and sanctuary', type: 'object', additionalProperties: false, required: ['notes', 'boardingByTier', 'feeding', 'breeding', 'sanctuary'],
    properties: {
      notes: { type: 'string' },
      boardingByTier: { type: 'object', additionalProperties: { type: 'integer', minimum: 0, maximum: 40 } },
      feeding: { type: 'object', additionalProperties: false, required: ['cooldownHours', 'assistsPerFeed'], properties: { cooldownHours: { type: 'number', minimum: 1 }, assistsPerFeed: { type: 'integer', minimum: 1, maximum: 3 } } },
      breeding: { type: 'object', additionalProperties: false, required: ['requiresFeature', 'minBond', 'pairCooldownHours', 'incubateHours', 'hatchBond', 'crossElementChance', 'crossPityBreedings', 'heritableMarkings', 'inheritMarkingChance', 'nestMarkingChance', 'markingPityEggs', 'boardingSlotsPerEgg', 'eggFloor'], properties: {
        requiresFeature: { type: 'string' }, minBond: { type: 'integer', minimum: 1, maximum: 10 }, pairCooldownHours: { type: 'number', minimum: 1 }, incubateHours: { type: 'number', minimum: 1 },
        hatchBond: { type: 'integer', minimum: 0, maximum: 10 }, crossElementChance: P, crossPityBreedings: { type: 'integer', minimum: 1 },
        heritableMarkings: { type: 'array', uniqueItems: true, items: { type: 'string' } }, inheritMarkingChance: P, nestMarkingChance: P,
        markingPityEggs: { type: 'integer', minimum: 1 }, boardingSlotsPerEgg: { type: 'integer', minimum: 1 }, eggFloor: { type: 'integer', minimum: 1, maximum: 10 } } },
      sanctuary: { type: 'array', minItems: 1, items: { type: 'object', additionalProperties: false, required: ['minSpecies', 'name'], properties: { minSpecies: { type: 'integer', minimum: 0 }, name: { type: 'string', minLength: 1 } } } }
    }
  };
}
// --- Civilization Archive and archaeology (Step 4 of part 2; Data/World/civilization_archive.json) ---
{
  const PLACE = { type: 'object', additionalProperties: false, properties: { siteId: id('site_'), dungeonId: id('dng_'), roomId: { type: 'string', pattern: '^rm_[a-z0-9_]+$' }, clueId: { type: 'string', pattern: '^clue_[a-z0-9_]+$' } } };
  SCHEMAS.civilization_archive = {
    title: 'Civilization Archive', type: 'object', additionalProperties: false, required: ['notes', 'civilizations', 'sites', 'entries', 'fragments'],
    properties: {
      notes: { type: 'string' },
      civilizations: { type: 'array', minItems: 1, items: { type: 'object', additionalProperties: false, required: ['id', 'name', 'age', 'source', 'summary'], properties: {
        id: id('civ_'), name: { type: 'string', minLength: 1 }, age: { type: 'string', minLength: 1 }, source: { type: 'string', minLength: 3 }, summary: { type: 'string', minLength: 20 } } } },
      sites: { type: 'array', minItems: 1, items: { type: 'object', additionalProperties: false, required: ['id', 'regionId', 'name', 'civilizationId', 'loreStatus'], properties: {
        id: id('site_'), regionId: id('reg_'), name: { type: 'string', minLength: 1 }, civilizationId: id('civ_'), loreStatus: { type: 'string', enum: ['canon', 'draft'] } } } },
      entries: { type: 'array', minItems: 1, items: { type: 'object', additionalProperties: false, required: ['id', 'civilizationId', 'kind', 'title', 'text', 'source', 'how', 'draft'], properties: {
        id: id('ent_'), civilizationId: id('civ_'), kind: { type: 'string', enum: ['manuscript', 'inscription', 'painting', 'machine', 'record', 'object', 'map'] },
        title: { type: 'string', minLength: 1 }, text: { type: 'string', minLength: 20, maxLength: 400 }, source: { type: 'string', minLength: 3 }, how: { type: 'string', enum: ['read', 'restore'] },
        readAt: PLACE, hearsClues: { type: 'array', items: { type: 'object', additionalProperties: false, required: ['dungeonId', 'clueId'], properties: { dungeonId: id('dng_'), clueId: { type: 'string', pattern: '^clue_[a-z0-9_]+$' } } } },
        hearsRegions: { type: 'array', items: id('reg_') }, artifact: { type: 'string' }, draft: { type: 'boolean' } } } },
      fragments: { type: 'array', items: { type: 'object', additionalProperties: false, required: ['id', 'itemId', 'name', 'entryId', 'foundIn', 'draft'], properties: {
        id: id('frag_'), itemId: id('itm_frag_'), name: { type: 'string', minLength: 1 }, entryId: id('ent_'), foundIn: PLACE, draft: { type: 'boolean' } } } }
    }
  };
}
// --- Companion roster, banter and rules (Wave C; Data/Companions/*.json) ---
{
  const PERSONALITY = ['brave', 'cautious', 'curious', 'loyal', 'proud', 'gentle', 'playful', 'stoic', 'greedy', 'serene'];
  const ROLES = ['Vanguard', 'Guardian', 'Skirmisher', 'Ranger', 'Arcanist', 'Mender', 'Tamer', 'Specialist'];
  const PRESETS = ['Aggressive', 'Defensive', 'Supportive', 'Balanced'];
  const SLOTS = ['weapon', 'armor', 'accessory', 'charm'];
  const TRIGGERS = ['regionArrival', 'afterFight', 'restStop', 'campfire', 'lowHealth', 'revived', 'mounted', 'monsterSeen', 'questDone', 'idle'];
  SCHEMAS.companion = {
    title: 'Companion roster row', type: 'object', additionalProperties: false,
    required: ['id', 'name', 'kind', 'race', 'personalityTags', 'roleTags', 'preferredRole', 'presetDefault', 'romanceable', 'adult', 'equipmentSlots', 'rideable', 'partyRole', 'sourceDoc'],
    properties: {
      id: id('cmp_'), name: { type: 'string', minLength: 1 }, kind: { type: 'string', enum: ['companion', 'childhoodFriend'] },
      npcId: id('npc_'), race: { type: 'string', minLength: 1 },
      personalityTags: { type: 'array', maxItems: 4, items: { type: 'string', enum: PERSONALITY } },
      roleTags: { type: 'array', minItems: 1, maxItems: 2, items: { type: 'string', enum: ROLES } },
      preferredRole: { type: 'string', enum: ROLES }, presetDefault: { type: 'string', enum: PRESETS },
      romanceable: { type: 'boolean' }, adult: { type: 'boolean' }, redeemableArc: { type: 'boolean' },
      equipmentSlots: { type: 'array', minItems: 1, maxItems: 4, items: { type: 'string', enum: SLOTS } },
      rideable: { type: 'boolean', enum: [false] },
      partyRole: { type: 'string', minLength: 1 }, sourceDoc: { type: 'string', minLength: 1 },
      stub: { type: 'boolean' }, note: { type: 'string' }
    }
  };
  SCHEMAS.banter = {
    title: 'Companion banter line', type: 'object', additionalProperties: false,
    required: ['id', 'companionId', 'trigger', 'priority', 'cooldownSec', 'line'],
    properties: {
      id: id('bnt_'), companionId: id('cmp_'), trigger: { type: 'string', enum: TRIGGERS },
      priority: { type: 'integer', minimum: 0, maximum: 100 }, cooldownSec: { type: 'number', minimum: 0 },
      line: { type: 'string', minLength: 1, maxLength: 160 }, tone: { type: 'string', pattern: '^[a-z][a-z0-9_]*$' }
    }
  };
  const mult = { type: 'number', exclusiveMinimum: 0, maximum: 3 };
  const frac = { type: 'number', minimum: 0, maximum: 1 };
  const preset = { type: 'object', additionalProperties: false,
    required: ['defaultOrder', 'leashMult', 'followDistanceMult', 'retreatHpMult', 'reviveEagerness', 'assistBias', 'skillCostCaution'],
    properties: { defaultOrder: { type: 'string', enum: ['Follow', 'Hold', 'Focus', 'Assist'] }, leashMult: mult, followDistanceMult: mult,
      retreatHpMult: mult, reviveEagerness: mult, assistBias: mult, skillCostCaution: mult } };
  const TRACKS = ['trust', 'respect', 'closeness', 'tension'];
  const pct = { type: 'integer', minimum: 0, maximum: 100 };
  const stages = { type: 'array', minItems: 2, items: { type: 'object', additionalProperties: false, required: ['id', 'min'], properties: { id: { type: 'string', pattern: '^[a-z][a-z0-9_]*$' }, min: pct } } };
  const track = (extra) => ({ type: 'object', additionalProperties: false, required: ['start', 'stages'], properties: { start: pct, stages, ...extra } });
  const REL = { type: 'object', additionalProperties: false, required: ['maxDeltaPerEvent', 'tracks', 'romance', 'departure', 'kaito', 'events'],
    properties: {
      maxDeltaPerEvent: { type: 'integer', minimum: 1, maximum: 20 },
      tracks: { type: 'object', additionalProperties: false, required: TRACKS, properties: { trust: track({}), respect: track({}), closeness: track({}), tension: track({ easePerDay: { type: 'integer', minimum: 0, maximum: 10 } }) } },
      romance: { type: 'object', additionalProperties: false, required: ['minCloseness', 'minTrust', 'maxTensionExclusive'], properties: { minCloseness: { type: 'string' }, minTrust: { type: 'string' }, maxTensionExclusive: { type: 'integer', minimum: 1, maximum: 100 } } },
      departure: { type: 'object', additionalProperties: false, required: ['minTension', 'requiresForeshadow', 'requiresRepairOffered'], properties: { minTension: { type: 'integer', minimum: 1, maximum: 100 }, requiresForeshadow: { type: 'boolean', enum: [true] }, requiresRepairOffered: { type: 'boolean', enum: [true] } } },
      kaito: { type: 'object', additionalProperties: false, required: ['start', 'states'], properties: { start: { type: 'string', enum: ['ally', 'rival', 'fallen'] }, states: { type: 'array', items: { type: 'string', enum: ['ally', 'rival', 'fallen'] }, minItems: 3, maxItems: 3 } } },
      events: { type: 'object', minProperties: 1, propertyNames: { pattern: '^[a-z][a-z0-9_]*$' }, additionalProperties: { type: 'object', additionalProperties: false, required: ['deltas'],
        properties: { deltas: { type: 'object', additionalProperties: false, properties: Object.fromEntries(TRACKS.map(t => [t, { type: 'integer', minimum: -20, maximum: 20 }])) },
          once: { type: 'boolean' }, cooldownDays: { type: 'integer', minimum: 1 }, foreshadow: { type: 'boolean' }, offersRepair: { type: 'boolean' }, repair: { type: 'boolean' } } } }
    } };
  SCHEMAS.companion_rules = {
    title: 'Companion command presets, retreat, revive and downed rules', type: 'object', additionalProperties: false,
    required: ['version', 'presets', 'retreat', 'revive', 'downed', 'relationships'],
    properties: {
      version: { type: 'integer', minimum: 1 }, notes: { type: 'string' }, relationships: REL,
      presets: { type: 'object', additionalProperties: false, required: PRESETS, properties: Object.fromEntries(PRESETS.map(p => [p, preset])) },
      retreat: { type: 'object', additionalProperties: false, required: ['lowHpFraction', 'hysteresis', 'recoverHpFraction', 'mortalBondsHpMult', 'needsSafePathWhenPlayerDowned'],
        properties: { lowHpFraction: frac, hysteresis: frac, recoverHpFraction: frac, mortalBondsHpMult: mult, needsSafePathWhenPlayerDowned: { type: 'boolean', enum: [true] } } },
      revive: { type: 'object', additionalProperties: false, required: ['reviveRangeM', 'reviveCastSec', 'interruptible', 'cooldownSec', 'healFractionOnRevive', 'rareItemsRequireConsent'],
        properties: { reviveRangeM: { type: 'number', exclusiveMinimum: 0, maximum: 20 }, reviveCastSec: { type: 'number', minimum: 0, maximum: 30 }, interruptible: { type: 'boolean' },
          cooldownSec: { type: 'number', minimum: 0 }, healFractionOnRevive: { type: 'number', exclusiveMinimum: 0, maximum: 1 }, rareItemsRequireConsent: { type: 'boolean', enum: [true] } } },
      downed: { type: 'object', additionalProperties: false, required: ['gravelyWoundedRecoverySec', 'recoverHpFractionAfterWounded', 'mortalBonds'],
        properties: { gravelyWoundedRecoverySec: { type: 'number', exclusiveMinimum: 0 }, recoverHpFractionAfterWounded: { type: 'number', exclusiveMinimum: 0, maximum: 1 },
          mortalBonds: { type: 'object', additionalProperties: false, required: ['defaultEnabled', 'deathRequiresLethalBlowWhileDowned', 'timerCanKill', 'pathingCanKill'],
            properties: { defaultEnabled: { type: 'boolean', enum: [false] }, deathRequiresLethalBlowWhileDowned: { type: 'boolean', enum: [true] },
              timerCanKill: { type: 'boolean', enum: [false] }, pathingCanKill: { type: 'boolean', enum: [false] } } } } }
    }
  };
}
{
  const mult = { type: 'number', exclusiveMinimum: 0, maximum: 3 };
  const TERR = ['plains', 'forest', 'swamp', 'steppe', 'mountain', 'volcanic', 'tundra', 'desert', 'jungle', 'spirit', 'demon'];
  const num = { type: 'number', exclusiveMinimum: 0 };
  SCHEMAS.mounts = {
    title: 'Ground mounts (Wave C; speed settled at 10 m/s on 2026-11-07)', type: 'object', additionalProperties: false,
    required: ['version', 'speedMps', 'exhaustedWalkFraction', 'condition', 'families', 'mountedCombat', 'knockedOutNotKilled'],
    properties: {
      version: { type: 'integer', minimum: 1 }, notes: { type: 'string' },
      speedMps: { type: 'object', additionalProperties: false, required: ['value', 'placeholder', 'note'],
        properties: { value: num, placeholder: { type: 'boolean' }, note: { type: 'string', minLength: 1 } } },
      exhaustedWalkFraction: { type: 'number', exclusiveMinimum: 0, maximum: 1 },
      condition: { type: 'object', additionalProperties: mult },
      knockedOutNotKilled: { type: 'boolean', enum: [true] },
      families: { type: 'object', minProperties: 1, additionalProperties: { type: 'object', additionalProperties: false,
        required: ['label', 'speedMult', 'terrain', 'stamina', 'carryBonus', 'unlockRank', 'knockoutOnly', 'species'],
        properties: { label: { type: 'string' }, speedMult: mult, carryBonus: { type: 'number', minimum: 0 },
          unlockRank: { type: 'string', enum: ['F', 'E', 'D', 'C', 'B', 'A', 'S'] }, knockoutOnly: { type: 'boolean', enum: [true] },
          terrain: { type: 'object', additionalProperties: false, required: TERR, properties: Object.fromEntries(TERR.map(t => [t, mult])) },
          stamina: { type: 'object', additionalProperties: false, required: ['max', 'sprintDrainPerSec', 'regenPerSec', 'exhaustedBelow', 'recoverTo'],
            properties: { max: num, sprintDrainPerSec: num, regenPerSec: num, exhaustedBelow: { type: 'number', minimum: 0 }, recoverTo: num } },
          species: { type: 'array', minItems: 1, items: { type: 'string', pattern: '^mon_' } } } } },
      mountedCombat: { type: 'object', additionalProperties: false, required: ['bannedSkillTags', 'meleeReachCapM', 'dismountOnStagger', 'damageMult', 'maxChainHits', 'noMountInterior'],
        properties: { bannedSkillTags: { type: 'array', items: { type: 'string' } }, meleeReachCapM: num, dismountOnStagger: { type: 'boolean', enum: [true] },
          damageMult: { type: 'number', exclusiveMinimum: 0, maximum: 1.5 }, maxChainHits: { type: 'integer', minimum: 1 }, noMountInterior: { type: 'boolean', enum: [true] } } }
    } };
}
{
  // Wave E: dungeons and puzzles (12_Systems/dungeons_and_puzzles.md). Canon: puzzles are never a mandatory gate (optional: true),
  // dungeon cores are never allies (coreIsAlly: false), dungeons stay reusable (reusable: true).
  const sid = prefix => ({ type: 'string', pattern: `^${prefix}[a-z0-9_]+$` });
  const reward = { type: 'object', additionalProperties: false, required: ['itemId', 'count'],
    properties: { itemId: sid('itm_'), count: { type: 'integer', minimum: 1, maximum: 9 } } };
  const base = {
    id: sid('pzl_'), name: { type: 'string', minLength: 1 }, optional: { type: 'boolean', enum: [true] },
    hints: { type: 'array', minItems: 2, maxItems: 6, items: { type: 'string', minLength: 1 } }, reward
  };
  const wid = { type: 'string', pattern: '^[a-z][a-z0-9_]*$' };
  SCHEMAS.puzzles = {
    title: 'Puzzle set (Wave E)', type: 'object', additionalProperties: false, required: ['version', 'tuning', 'puzzles'],
    properties: {
      version: { type: 'integer', minimum: 1 }, notes: { type: 'string' },
      tuning: { type: 'object', additionalProperties: false, required: ['failsBeforeAssist'],
        properties: { failsBeforeAssist: { type: 'integer', minimum: 1, maximum: 10 } } },
      puzzles: { type: 'array', minItems: 1, items: {
        type: 'object', additionalProperties: false, required: ['id', 'type', 'name', 'optional', 'hints'],
        properties: {
          ...base, type: { type: 'string', enum: ['lever_sequence', 'pressure_plate', 'rune_match'] },
          levers: { type: 'array', minItems: 2, maxItems: 8, items: wid },
          sequence: { type: 'array', minItems: 2, maxItems: 8, items: wid },
          plates: { type: 'array', minItems: 1, maxItems: 6, items: { type: 'object', additionalProperties: false, required: ['id', 'weight'], properties: { id: wid, weight: { type: 'integer', minimum: 1, maximum: 99 } } } },
          objects: { type: 'array', minItems: 1, maxItems: 10, items: { type: 'object', additionalProperties: false, required: ['id', 'weight'], properties: { id: wid, weight: { type: 'integer', minimum: 1, maximum: 99 } } } },
          glyphs: { type: 'array', minItems: 2, maxItems: 8, items: wid },
          sconces: { type: 'array', minItems: 2, maxItems: 8, items: { type: 'object', additionalProperties: false, required: ['id', 'start', 'target'],
            properties: { id: wid, start: wid, target: wid, also: { type: 'array', items: wid } } } }
        } } }
    } };
  const spawn = { type: 'object', additionalProperties: false, required: ['speciesId', 'min', 'max'],
    properties: { speciesId: sid('mon_'), min: { type: 'integer', minimum: 0, maximum: 12 }, max: { type: 'integer', minimum: 1, maximum: 12 } } };
  SCHEMAS.dungeon = {
    title: 'Dungeon layout (Wave E)', type: 'object', additionalProperties: false,
    required: ['id', 'name', 'regionId', 'floors', 'recommendedRank', 'reusable', 'coreIsAlly', 'entryRoom', 'rooms', 'connections'],
    properties: {
      id: sid('dng_'), name: { type: 'string', minLength: 1 }, theme: { type: 'string' }, summary: { type: 'string' },
      regionId: sid('reg_'), floors: { type: 'array', minItems: 1, maxItems: 10, items: { type: 'integer', minimum: 1, maximum: 120 } },
      recommendedRank: RL, reusable: { type: 'boolean', enum: [true] }, coreIsAlly: { type: 'boolean', enum: [false] },
      entryRoom: sid('rm_'),
      rooms: { type: 'array', minItems: 2, maxItems: 24, items: { type: 'object', additionalProperties: false, required: ['id', 'name', 'level', 'role', 'spawns'],
        properties: {
          id: sid('rm_'), name: { type: 'string', minLength: 1 }, level: { type: 'integer', minimum: 1, maximum: 6 },
          role: { type: 'string', enum: ['entry', 'hub', 'key', 'checkpoint', 'boss', 'secret', 'combat', 'treasure'] },
          checkpoint: { type: 'boolean' }, secret: { type: 'boolean' },
          spawns: { type: 'array', items: spawn },
          boss: { type: 'object', additionalProperties: false, required: ['speciesId'], properties: { speciesId: sid('mon_') } },
          keys: { type: 'array', items: sid('key_') }, puzzles: { type: 'array', items: sid('pzl_') }
        } } },
      connections: { type: 'array', minItems: 1, maxItems: 60, items: { type: 'object', additionalProperties: false, required: ['id', 'from', 'to', 'kind'],
        properties: {
          id: sid('cn_'), from: sid('rm_'), to: sid('rm_'), kind: { type: 'string', enum: ['passage', 'stairs', 'door', 'secret', 'shortcut'] },
          oneWay: { type: 'boolean' }, requiresKey: sid('key_'), requiresPuzzle: sid('pzl_'), revealedByClue: sid('clue_')
        } } },
      clues: { type: 'array', items: { type: 'object', additionalProperties: false, required: ['id', 'roomId', 'kind', 'text'],
        properties: {
          id: sid('clue_'), roomId: sid('rm_'), kind: { type: 'string', enum: ['lever', 'secret', 'lore'] },
          text: { type: 'string', minLength: 1 }, heard: { type: 'string' }, reveals: { type: 'string', minLength: 1 }
        } } }
    } };
}
require('./graph_schemas')(SCHEMAS); // Wave F-lite
require('./audio_schemas')(SCHEMAS); // Wave D
require('./weapon_schemas')(SCHEMAS); // weapon movesets
require('./living_schemas')(SCHEMAS); // Upgrade v4 subset
for (const [name, s] of Object.entries(SCHEMAS)) {
  fs.writeFileSync(path.join(OUT, `${name}.schema.json`), JSON.stringify({ $schema: 'http://json-schema.org/draft-07/schema#', ...s }, null, 1));
}
console.log('Schemas:', Object.keys(SCHEMAS).join(', '));
