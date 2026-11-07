// Wave F-lite schemas: Data/World/region_graph.json, labyrinth.json, underworld.json. Called from build_schemas.js.
module.exports = function (SCHEMAS) {
  const RANK = { type: 'string', pattern: '^(F|E|D|C|B|A|S|SS|SSS|EX)[+-]?$' };
  const RL = { type: 'string', enum: ['F', 'E', 'D', 'C', 'B', 'A', 'S', 'SS', 'SSS', 'EX'] };
  const reg = { type: 'string', pattern: '^reg_[a-z0-9_]+$' };
  const POINT = { type: 'array', minItems: 2, maxItems: 2, items: { type: 'number', minimum: 0, maximum: 150 } };
  const FLOOR_RANGE = { type: 'array', minItems: 2, maxItems: 2, items: { type: 'integer', minimum: 1, maximum: 120 } };

  SCHEMAS.region_graph = {
    title: 'Region connection graph (Wave F-lite)', type: 'object', additionalProperties: false,
    required: ['version', 'source', 'scale', 'nodes', 'edges', 'portals'],
    properties: {
      version: { type: 'integer', minimum: 1 }, note: { type: 'string' },
      source: { type: 'object', additionalProperties: false, required: ['startRegion'], properties: { physicalMap: { type: 'string' }, regions: { type: 'string' }, startRegion: reg } },
      scale: { type: 'object', additionalProperties: false, required: ['unitKm', 'passLimitM'], properties: { unitKm: { type: 'number', exclusiveMinimum: 0 }, passLimitM: { type: 'number', exclusiveMinimum: 0 }, minWalkBorderKm: { type: 'number', minimum: 0 } } },
      edgeKinds: { type: 'object' },
      portals: { type: 'array', maxItems: 0 },
      nodes: { type: 'array', minItems: 1, items: { type: 'object', additionalProperties: false, required: ['id', 'name', 'ring', 'at'],
        properties: { id: reg, name: { type: 'string', minLength: 1 }, ring: { type: 'integer', minimum: 0, maximum: 9 }, at: POINT, isle: { type: 'boolean' }, floating: { type: 'boolean' } } } },
      edges: { type: 'array', minItems: 1, items: { type: 'object', additionalProperties: false, required: ['id', 'a', 'b', 'kind', 'km', 'kmBasis', 'foot'],
        properties: {
          id: { type: 'string', pattern: '^edge_[a-z0-9_]+$' }, a: reg, b: reg, kind: { type: 'string', enum: ['road', 'pass', 'sea', 'border'] },
          km: { type: 'number', exclusiveMinimum: 0 }, kmBasis: { type: 'string', enum: ['road_length', 'corridor_leg', 'anchor_straight_line'] }, foot: { type: 'boolean' },
          roadId: { type: 'string' }, corridorId: { type: 'string' }, passId: { type: 'string' }, passName: { type: 'string' }, passM: { type: 'number' },
          via: { type: 'array', items: reg }, riverCrossings: { type: 'integer', minimum: 1 }, widestCrossingM: { type: 'number', minimum: 0 },
          borderKm: { type: 'number', minimum: 0 }, lowestCrossingM: { type: 'number' }
        } } }
    } };

  const band = { type: 'object', additionalProperties: false, required: ['id', 'regionId', 'floors', 'licenceRank', 'settlement', 'name', 'rankMin', 'rankMax', 'ring'],
    properties: { id: { type: 'string', enum: ['upper', 'deep', 'abyss'] }, regionId: reg, floors: FLOOR_RANGE, licenceRank: RL, settlement: { type: 'string', enum: ['towns', 'camps', 'none'] },
      name: { type: 'string', minLength: 1 }, rankMin: RL, rankMax: RL, ring: { type: 'integer', minimum: 0, maximum: 9 } } };
  SCHEMAS.labyrinth = {
    title: 'Great Labyrinth floor registry (Wave F-lite)', type: 'object', additionalProperties: false,
    required: ['version', 'id', 'entrance', 'floorCount', 'bands', 'decades', 'floors', 'stairs', 'backDoors'],
    properties: {
      version: { type: 'integer', minimum: 1 }, note: { type: 'string' }, id: { type: 'string', enum: ['great_labyrinth'] },
      entrance: { type: 'object', additionalProperties: false, required: ['regionId', 'text', 'mapAt'], properties: { regionId: reg, text: { type: 'string', minLength: 1 }, mapAt: POINT } },
      floorCount: { type: 'integer', enum: [120] }, resets: { type: 'string', enum: ['weekly'] },
      startHeard: { type: 'array', items: { type: 'integer', minimum: 1, maximum: 120 } },
      bands: { type: 'array', minItems: 3, maxItems: 3, items: band },
      decades: { type: 'array', minItems: 12, maxItems: 12, items: { type: 'object', additionalProperties: false, required: ['floors', 'biome', 'rankMin', 'rankMax'],
        properties: { floors: FLOOR_RANGE, biome: { type: 'string', minLength: 1 }, rankMin: RANK, rankMax: RANK, hidden: { type: 'boolean' }, secret: { type: 'boolean' } } } },
      floors: { type: 'array', minItems: 120, maxItems: 120, items: { type: 'object', additionalProperties: false, required: ['id', 'n', 'band', 'biome', 'rankMin', 'rankMax', 'guardian'],
        properties: {
          id: { type: 'string', pattern: '^flr_\\d{3}$' }, n: { type: 'integer', minimum: 1, maximum: 120 }, band: { type: 'string', enum: ['upper', 'deep', 'abyss'] },
          biome: { type: 'string', minLength: 1 }, rankMin: RANK, rankMax: RANK, guardian: { type: 'boolean' },
          safe: { type: 'string', enum: ['town', 'camp'] }, safeSource: { type: 'string', enum: ['gazetteer', 'inferred'] },
          hidden: { type: 'boolean' }, secret: { type: 'boolean' }, landmarks: { type: 'array', items: { type: 'string', minLength: 1 } },
          dungeonIds: { type: 'array', items: { type: 'string', pattern: '^dng_[a-z0-9_]+$' } }
        } } },
      stairs: { type: 'array', minItems: 119, maxItems: 119, items: { type: 'object', additionalProperties: false, required: ['id', 'from', 'to'],
        properties: { id: { type: 'string', pattern: '^stair_\\d{3}_\\d{3}$' }, from: { type: 'integer', minimum: 1, maximum: 119 }, to: { type: 'integer', minimum: 2, maximum: 120 }, hidden: { type: 'boolean' }, licenceRank: RL } } },
      backDoors: { type: 'array', items: { type: 'object', additionalProperties: false, required: ['id', 'floor', 'layer', 'regionId', 'hidden', 'pairing'],
        properties: { id: { type: 'string', pattern: '^bd_\\d{3}$' }, floor: { type: 'integer', minimum: 1, maximum: 120 }, layer: { type: 'integer', minimum: 1, maximum: 5 }, regionId: reg, hidden: { type: 'boolean', enum: [true] }, pairing: { type: 'string', enum: ['canon', 'inferred'] } } } }
    } };

  SCHEMAS.underworld = {
    title: 'Underworld layer registry (Wave F-lite)', type: 'object', additionalProperties: false, required: ['version', 'layers'],
    properties: {
      version: { type: 'integer', minimum: 1 }, note: { type: 'string' },
      layers: { type: 'array', minItems: 5, maxItems: 5, items: { type: 'object', additionalProperties: false, required: ['layer', 'regionId', 'name', 'rankMin', 'rankMax', 'ring', 'gate'],
        properties: {
          layer: { type: 'integer', minimum: 1, maximum: 5 }, regionId: reg, name: { type: 'string', minLength: 1 }, rankMin: RL, rankMax: RL, ring: { type: 'integer', minimum: 0, maximum: 9 },
          gate: { type: 'object', additionalProperties: false, required: ['at', 'surfaceRegionId'], properties: { at: POINT, surfaceRegionId: reg } },
          regionsJsonDepth: { type: 'integer', minimum: 1, maximum: 5 }, labyrinthBackDoor: { type: 'string', pattern: '^bd_\\d{3}$' }, weavePressure: { type: 'boolean' }
        } } }
    } };
};
