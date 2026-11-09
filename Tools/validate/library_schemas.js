// Libraries and books schemas: Data/Library/libraries.json and Data/Library/books.json (12_Systems/libraries_and_books.md).
// Called from build_schemas.js.
module.exports = function (SCHEMAS) {
  const RL = { type: 'string', enum: ['F', 'E', 'D', 'C', 'B', 'A', 'S', 'SS', 'SSS'] };
  const reg = { type: 'string', pattern: '^reg_[a-z0-9_]+$' };
  SCHEMAS.libraries = {
    title: 'Libraries, archives, temples, schools and guild halls', type: 'object', additionalProperties: false,
    required: ['version', 'libraries'],
    properties: {
      version: { type: 'integer', minimum: 1 }, note: { type: 'string' },
      libraries: { type: 'array', minItems: 1, items: {
        type: 'object', additionalProperties: false,
        required: ['id', 'name', 'type', 'region', 'settlement', 'status', 'source', 'blurb'],
        properties: {
          id: { type: 'string', pattern: '^lib_[a-z0-9_]+$' }, name: { type: 'string', minLength: 1 },
          type: { type: 'string', enum: ['library', 'archive', 'temple', 'school', 'guild_hall'] },
          region: reg, settlement: { type: 'string', minLength: 1 },
          status: { type: 'string', enum: ['canon', 'proposed'] }, source: { type: 'string', minLength: 1 },
          blurb: { type: 'string', minLength: 1 }, covers: { type: 'array', items: reg }, rankGate: RL
        } } }
    } };
  SCHEMAS.books = {
    title: 'Books of the shelf', type: 'object', additionalProperties: false,
    required: ['version', 'books'],
    properties: {
      version: { type: 'integer', minimum: 1 }, note: { type: 'string' },
      books: { type: 'array', minItems: 1, items: {
        type: 'object', additionalProperties: false,
        required: ['id', 'title', 'author', 'kind', 'library', 'region', 'subjectRegion', 'shelf', 'language', 'blurb', 'readingMinutes', 'words', 'tags', 'reliability', 'status', 'quality', 'source', 'text'],
        properties: {
          id: { type: 'string', pattern: '^bk_[a-z0-9_]+$' }, title: { type: 'string', minLength: 1 }, author: { type: 'string', minLength: 1 },
          kind: { type: 'string', enum: ['field_guide', 'cookery', 'road_book', 'local_history', 'household_book', 'craft_notes', 'myth_telling', 'guild_manual', 'chapel_notes', 'trade_notes', 'letter_book', 'law_notes', 'academy_lecture', 'ballad_sheet', 'veilborn_memoir', 'story_aloud', 'play', 'valdrisian_fragment', 'festival_notes', 'romance_serial'] },
          library: { type: ['string', 'null'] }, region: { type: ['string', 'null'] }, subjectRegion: { type: ['string', 'null'] },
          shelf: { type: 'string', minLength: 1 }, language: { type: 'string', minLength: 1 }, blurb: { type: 'string', minLength: 1 },
          readingMinutes: { type: 'integer', minimum: 1, maximum: 60 }, words: { type: 'integer', minimum: 1 },
          tags: { type: 'array', items: { type: 'string', minLength: 1 } },
          reliability: { type: 'string', enum: ['accurate', 'partial', 'folk belief', 'propaganda'] },
          status: { type: 'string', enum: ['draft', 'clear', 'hold'] }, quality: { type: 'string', enum: ['strong', 'average', 'templated'] },
          inWorldDate: { type: 'string' }, source: { type: 'string', minLength: 1 }, text: { type: ['string', 'null'] },
          rankGate: RL,
          rewards: { type: 'array', items: { type: 'object', additionalProperties: false, required: ['kind', 'id'],
            properties: { kind: { type: 'string', enum: ['bestiary', 'archive', 'recipe_hint', 'clue'] }, id: { type: 'string', minLength: 1 } } } }
        } } }
    } };
};
