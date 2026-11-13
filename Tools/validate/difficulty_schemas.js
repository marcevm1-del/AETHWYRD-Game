// Difficulty presets and accessibility presets (12_Systems/difficulty_and_accessibility.md).
// Called from build_schemas.js. Data: Data/Player/difficulty.json, Data/Player/accessibility_presets.json.
module.exports = function addDifficultySchemas(SCHEMAS) {
  const num = { type: 'number' };
  const range = { type: 'array', minItems: 2, maxItems: 2, items: num };
  const presetKeys = ['name', 'enemyDamageMult', 'enemyHpMult', 'enemyAggressionMult', 'telegraphLeadMult', 'maxSimultaneousAttackers', 'dodgeWindowMult',
    'parryWindowMult', 'flashTimeDurationMult', 'autoDodge', 'lootMult', 'deathCopperFraction', 'deathXpFraction', 'permadeath', 'mortalBonds', 'weightMode'];
  const preset = {
    type: 'object', additionalProperties: false, required: presetKeys,
    properties: {
      name: { type: 'string', minLength: 1 }, enemyDamageMult: num, enemyHpMult: num, enemyAggressionMult: num, telegraphLeadMult: num,
      maxSimultaneousAttackers: { type: 'integer', minimum: 1, maximum: 6 }, dodgeWindowMult: num, parryWindowMult: num, flashTimeDurationMult: num,
      autoDodge: { type: 'boolean' }, lootMult: num, deathCopperFraction: { type: 'number', minimum: 0, maximum: 1 }, deathXpFraction: { type: 'number', minimum: 0, maximum: 1 },
      permadeath: { type: 'boolean' }, mortalBonds: { type: 'boolean' }, weightMode: { type: 'string', enum: ['unlimited', 'generous', 'strict'] }
    }
  };
  const mult = { type: 'object', additionalProperties: num };
  SCHEMAS.difficulty = {
    title: 'Difficulty presets, sliders and the S-rank floor', type: 'object', additionalProperties: false,
    required: ['version', 'notes', 'default', 'presets', 'sliders', 'lootRule', 'customRules', 'sRankFloor'],
    properties: {
      version: { type: 'integer', minimum: 1 }, notes: { type: 'string' }, default: { type: 'string' },
      presets: { type: 'object', additionalProperties: preset },
      sliders: { type: 'object', additionalProperties: range },
      lootRule: { type: 'string' },
      customRules: { type: 'object', additionalProperties: { type: 'boolean' } },
      sRankFloor: {
        type: 'object', additionalProperties: false,
        required: ['appliesFromRank', 'warningRank', 'warningText', 'bruteForceEnrageTimers', 'autoDodge', 'min', 'max', 'minAttackers', 'keepsAccessibility', 'profileNames'],
        properties: {
          appliesFromRank: { type: 'string', enum: ['S', 'SS', 'SSS'] }, warningRank: { type: 'string', enum: ['B', 'A', 'S'] }, warningText: { type: 'string', minLength: 1 },
          bruteForceEnrageTimers: { type: 'boolean' }, autoDodge: { type: 'boolean' }, min: mult, max: mult,
          minAttackers: { type: 'integer', minimum: 1, maximum: 6 }, keepsAccessibility: { type: 'array', minItems: 1, items: { type: 'string', pattern: '^[a-zA-Z][a-zA-Z0-9]*$' } },
          profileNames: { type: 'object', additionalProperties: { type: 'string' } }
        }
      }
    }
  };
  SCHEMAS.accessibility_presets = {
    title: 'Accessibility preset bundles', type: 'object', additionalProperties: false,
    required: ['version', 'notes', 'presets', 'pairings'],
    properties: {
      version: { type: 'integer', minimum: 1 }, notes: { type: 'string' },
      presets: {
        type: 'object', additionalProperties: {
          type: 'object', additionalProperties: false, required: ['name', 'summary', 'settings'],
          properties: {
            name: { type: 'string', minLength: 1 }, summary: { type: 'string', minLength: 1 }, settings: { type: 'object' },
            assists: { type: 'object', additionalProperties: { type: 'boolean' } }, toggleAllHoldActions: { type: 'boolean' },
            layoutHint: { type: 'string' }, note: { type: 'string' }
          }
        }
      },
      pairings: { type: 'array', items: { type: 'object', additionalProperties: false, required: ['with', 'suggest', 'why'],
        properties: { with: { type: 'string' }, suggest: { type: 'array', minItems: 1, items: { type: 'string' } }, why: { type: 'string' } } } }
    }
  };
};
