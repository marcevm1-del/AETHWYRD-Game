// Character customization and silhouette library schemas (12_Systems/character_customization.md). Called from build_schemas.js.
module.exports = function addCharacterSchemas(SCHEMAS) {
  const id = { type: 'string', pattern: '^[a-z][a-z0-9_]*$' };
  const hex = { type: 'string', pattern: '^#[0-9A-Fa-f]{6}$' };
  const name = { type: 'string', minLength: 1 };
  const status = { type: 'string', enum: ['built', 'planned'] };
  const fams = { type: 'array', minItems: 1, uniqueItems: true, items: { type: 'string', enum: ['feminine', 'masculine'] } };
  const notes = { type: 'string' };
  const swatch = { type: 'object', additionalProperties: false, required: ['id', 'name', 'hex'], properties: { id, name, hex } };
  const opt = { type: 'object', additionalProperties: false, required: ['id', 'name', 'status'], properties: { id, name, status, notes,
    decal: { type: 'object', additionalProperties: false, required: ['widthScale', 'heightRatio', 'tiltDeg', 'lidCurve'], properties: {
      widthScale: { type: 'number', minimum: 0.8, maximum: 1.3 }, heightRatio: { type: 'number', minimum: 0.5, maximum: 1.3 },
      tiltDeg: { type: 'number', minimum: -15, maximum: 15 }, lidCurve: { type: 'number', minimum: 0, maximum: 1 } } } } };
  const vec3 = { type: 'array', minItems: 3, maxItems: 3, items: { type: 'number' } };
  const SLOTS = ['top', 'outer', 'bottom', 'skirt', 'belt', 'footwear', 'gloves', 'arms', 'shoulder', 'neck', 'armor'];
  SCHEMAS.customization = {
    title: 'Character customization catalog', type: 'object', additionalProperties: false,
    required: ['version', 'families', 'colourSlots', 'materialSlots', 'styleGuard', 'palettes', 'hairColours', 'irisColours', 'eyeShapes', 'pupilStyles', 'brows', 'mouths', 'expressions', 'faces', 'hairStyles', 'outfitPieces', 'accessories', 'weapons', 'sockets', 'looks'],
    properties: {
      version: { type: 'integer', minimum: 1 }, notes,
      families: { type: 'array', minItems: 2, items: { type: 'object', additionalProperties: false, required: ['id', 'name', 'body', 'generatorBody', 'heightM', 'builds', 'defaultLook'], properties: {
        id: { type: 'string', enum: ['feminine', 'masculine'] }, name, body: { type: 'string', enum: ['feminine', 'masculine'] }, generatorBody: id,
        heightM: { type: 'object', additionalProperties: false, required: ['min', 'max', 'default'], properties: { min: { type: 'number', minimum: 1.3 }, max: { type: 'number', maximum: 2.2 }, default: { type: 'number' } } },
        builds: { type: 'array', minItems: 1, items: id }, defaultLook: id } } },
      colourSlots: { type: 'array', minItems: 1, items: { type: 'object', additionalProperties: false, required: ['id', 'name', 'group'], properties: { id, name, group: { type: 'string', enum: ['hair', 'face', 'clothing', 'gear', 'weapon'] } } } },
      materialSlots: { type: 'object', additionalProperties: id },
      styleGuard: { type: 'object', additionalProperties: false, required: ['minValue', 'maxValue', 'maxSaturation'], properties: { minValue: { type: 'number', minimum: 0, maximum: 1 }, maxValue: { type: 'number', minimum: 0, maximum: 1 }, maxSaturation: { type: 'number', minimum: 0, maximum: 1 }, notes } },
      palettes: { type: 'array', minItems: 1, items: { type: 'object', additionalProperties: false, required: ['id', 'name', 'swatches', 'slots'], properties: { id, name, notes, swatches: { type: 'array', minItems: 3, items: hex }, slots: { type: 'object', additionalProperties: hex } } } },
      hairColours: { type: 'array', minItems: 1, items: swatch }, irisColours: { type: 'array', minItems: 1, items: swatch },
      eyeShapes: { type: 'array', minItems: 1, items: opt }, pupilStyles: { type: 'array', minItems: 1, items: opt }, brows: { type: 'array', minItems: 1, items: opt }, mouths: { type: 'array', minItems: 1, items: opt },
      expressions: { type: 'array', minItems: 1, items: { type: 'object', additionalProperties: false, required: ['id', 'name', 'faceExpression', 'intensity'], properties: { id, name, faceExpression: id, intensity: { type: 'number', minimum: 0, maximum: 1 } } } },
      faces: { type: 'array', minItems: 1, items: { type: 'object', additionalProperties: false, required: ['id', 'name', 'families', 'eyes', 'brows', 'mouth', 'restExpression'], properties: { id, name, families: fams, eyes: id, brows: id, mouth: id, restExpression: id, notes } } },
      hairStyles: { type: 'array', minItems: 1, items: { type: 'object', additionalProperties: false, required: ['id', 'name', 'families', 'length', 'status', 'placeholder'], properties: {
        id, name, families: fams, length: { type: 'string', enum: ['short', 'medium', 'long'] }, status, generatorStyle: id,
        placeholder: { type: 'string', enum: ['short', 'long', 'ponytail', 'bun'] }, secondaryMotion: { type: 'string', enum: ['tail', 'locks'] }, notes } } },
      outfitPieces: { type: 'array', minItems: 1, items: { type: 'object', additionalProperties: false, required: ['id', 'name', 'slot', 'families', 'status'], properties: {
        id, name, slot: { type: 'string', enum: SLOTS }, families: fams, status, parts: { type: 'array', items: id }, materials: { type: 'object', additionalProperties: id },
        hides: { type: 'array', items: { type: 'string', enum: SLOTS.concat(['skirt', 'bracers']) } }, silhouette: { type: 'array', items: id }, notes } } },
      accessories: { type: 'array', items: { type: 'object', additionalProperties: false, required: ['id', 'name', 'socket', 'families', 'status', 'colourSlot'], properties: { id, name, socket: id, families: fams, status, colourSlot: id, notes } } },
      weapons: { type: 'array', items: { type: 'object', additionalProperties: false, required: ['id', 'name', 'weaponFamily', 'held', 'sheathed', 'status'], properties: { id, name, weaponFamily: id, held: id, heldOff: id, sheathed: id, status, notes } } },
      sockets: { type: 'array', minItems: 1, items: { type: 'object', additionalProperties: false, required: ['id', 'bone', 'position', 'rotationEuler'], properties: { id, bone: { type: 'string', minLength: 1 }, position: vec3, rotationEuler: vec3 } } },
      looks: { type: 'array', minItems: 2, items: { type: 'object', additionalProperties: false, required: ['id', 'name', 'family', 'face', 'hair', 'build', 'outfit', 'palette', 'accessories', 'status'], properties: {
        id, name, family: { type: 'string', enum: ['feminine', 'masculine'] }, face: id, hair: id, build: id, outfit: { type: 'object', additionalProperties: id }, palette: id,
        accessories: { type: 'array', items: id }, weapon: id, status, notes } } }
    } };
  const sil = { type: 'string', pattern: '^[a-z][a-z0-9_]*$' };
  SCHEMAS.silhouettes = {
    title: 'Character silhouette library', type: 'object', additionalProperties: false, required: ['version', 'categories', 'axes', 'silhouettes'],
    properties: {
      version: { type: 'integer', minimum: 1 }, notes,
      categories: { type: 'array', minItems: 10, items: { type: 'object', additionalProperties: false, required: ['id', 'name'], properties: { id, name } } },
      axes: { type: 'object', additionalProperties: { type: 'array', minItems: 2, items: sil } },
      silhouettes: { type: 'array', minItems: 60, items: { type: 'object', additionalProperties: false, required: ['id', 'name', 'family', 'category', 'shape', 'readsAs'], properties: {
        id: { type: 'string', pattern: '^sil_[fm]_[0-9]{2}$' }, name, family: { type: 'string', enum: ['feminine', 'masculine'] }, category: id, readsAs: { type: 'string', minLength: 10 },
        shape: { type: 'object', additionalProperties: sil }, uses: { type: 'array', items: id }, notes } } }
    } };
};
