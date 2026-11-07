// Upgrade v4 (Canon-safe subset) schema: Data/World/living_world.json. Called from build_schemas.js.
module.exports = function (SCHEMAS) {
  const reg = { type: 'string', pattern: '^reg_[a-z0-9_]+$' };
  const strs = { type: 'array', items: { type: 'string', minLength: 1 } };
  SCHEMAS.living_world = {
    title: 'Living world: schedules, event director, discovery journal (upgrade v4 subset)', type: 'object', additionalProperties: false,
    required: ['version', 'schedules', 'events', 'journalCategories'],
    properties: {
      version: { type: 'integer', minimum: 1 }, note: { type: 'string' },
      schedules: { type: 'object', additionalProperties: false, required: ['defaultEnabled', 'essentialTiers'],
        properties: { defaultEnabled: { type: 'boolean' }, essentialTiers: { type: 'array', items: { type: 'string', enum: ['core', 'major', 'townsfolk'] } } } },
      events: { type: 'object', additionalProperties: false, required: ['maxActive', 'maxActivePerRegion', 'catchUpDays', 'pool'],
        properties: {
          maxActive: { type: 'integer', minimum: 1, maximum: 4 }, maxActivePerRegion: { type: 'integer', minimum: 1, maximum: 2 }, catchUpDays: { type: 'integer', minimum: 1, maximum: 14 },
          pool: { type: 'array', minItems: 1, maxItems: 40, items: { type: 'object', additionalProperties: false,
            required: ['id', 'kind', 'name', 'text', 'regions', 'chancePerDay', 'cooldownDays', 'durationDays', 'effects'],
            properties: {
              id: { type: 'string', pattern: '^evt_[a-z0-9_]+$' }, kind: { type: 'string', enum: ['caravan', 'wanderer'] },
              name: { type: 'string', minLength: 1 }, text: { type: 'string', minLength: 1 },
              regions: { type: 'array', minItems: 1, items: reg }, weekdays: strs,
              chancePerDay: { type: 'number', exclusiveMinimum: 0, maximum: 1 }, cooldownDays: { type: 'integer', minimum: 1, maximum: 60 }, durationDays: { type: 'integer', minimum: 1, maximum: 7 },
              effects: { type: 'array', minItems: 1, maxItems: 4, items: { type: 'object', additionalProperties: false, required: ['kind', 'text'],
                properties: {
                  kind: { type: 'string', enum: ['shop_stock', 'rumour', 'small_encounter', 'board_note'] }, text: { type: 'string', minLength: 1 },
                  shopId: { type: 'string', pattern: '^shop_[a-z0-9_]+$' }, itemIds: { type: 'array', items: { type: 'string', pattern: '^itm_[a-z0-9_]+$' } },
                  speciesIds: { type: 'array', items: { type: 'string', pattern: '^mon_[a-z0-9_]+$' } }
                } } }
            } } }
        } },
      journalCategories: { type: 'array', minItems: 1, items: { type: 'object', additionalProperties: false, required: ['id', 'name'],
        properties: { id: { type: 'string', pattern: '^[a-z_]+$' }, name: { type: 'string', minLength: 1 } } } }
    } };
};
