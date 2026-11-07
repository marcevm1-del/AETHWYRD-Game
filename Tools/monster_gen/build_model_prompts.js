// Builds the text-to-3D prompt for every species, from our own design data (species.json `look`, signature,
// palette, size) so generated models stay original to AETHWYRD. Ordered by ring (what the game needs first).
// Output: Art/Generation/monster_model_prompts.json (consumed by the Blender generation pass).
// Run: node Tools/monster_gen/build_model_prompts.js
const fs = require('fs');
const path = require('path');
const ROOT = path.join(__dirname, '..', '..');
const species = require(path.join(ROOT, 'Data', 'Monsters', 'species.json'));

const STYLE = 'stylized anime fantasy game monster, clean cel-shaded look, readable silhouette, '
  + 'single creature, full body, neutral idle pose, centered, plain background, no text, no logo';

/** Turns "The Goblin is a small creature with ..., about 1 m tall. Its skin ..." into name-free physical traits. */
function traits(s) {
  let t = (s.look || '').replace(/\s+/g, ' ').trim();
  t = t.replace(new RegExp(`^The ${s.name.replace(/[.*+?^${}()|[\]\\]/g, '\\$&')} is (a|an) `, 'i'), '');
  t = t.replace(/^[^,]*?(is|are) (a|an) /i, '');
  const drop = [/It has no ornament at all: simple, readable shapes\.?/gi, /Guild sketches always show /gi, /Look for /gi,
    /Its most striking feature is /gi, /Small scars and rough edges mark it as a survivor\.?/gi,
    /you hear its breathing before you see it\.?/gi, /It has no visible aura;?/gi];
  for (const d of drop) t = t.replace(d, '');
  t = t.replace(/ named [A-Z][\w'-]+/g, '');                 // proper names of items ("a cleaver named Hungry")
  t = t.replace(/\s+([,.])/g, '$1').replace(/\.\s*\./g, '.').trim();
  return t;
}

/** What the creature is, without proper names: "Grukk, Goblin Chief of Hollowpine" → "Goblin Chief, a goblinoid monster". */
function subject(s) {
  let title = s.name.includes(',') ? s.name.split(',').slice(1).join(',').trim() : s.name;
  title = title.replace(/^the\s+/i, '').replace(/\s+of\s+(the\s+)?[A-Z][\w'-]*(\s+[A-Z][\w'-]*)*$/, '').trim();
  const kind = (s.familyKey || s.type || 'monster').replace(/_/g, ' ').toLowerCase();
  const an = w => (/^[aeiou]/i.test(w) ? 'An' : 'A');
  return `${an(title)} ${title}, ${an(kind).toLowerCase()} ${kind} monster:`;
}

const out = species
  .map(s => ({
    id: s.id,
    name: s.name,
    family: s.family,
    ring: s.ring ?? 99,
    rank: s.rank,
    sizeMeters: s.sizeMeters,
    baseMesh: (s.designRecipe || {}).baseMesh,
    palette: (s.designRecipe || {}).palette || [],
    isBoss: !!(s.isTyrant || s.isUnique),
    prompt: `${subject(s)} ${traits(s)} ${STYLE}.`.replace(/\s{2,}/g, ' '), // colours are already in words in the look text
  }))
  .sort((a, b) => a.ring - b.ring || Number(b.isBoss) - Number(a.isBoss) || a.id.localeCompare(b.id));

const file = path.join(ROOT, 'Art', 'Generation', 'monster_model_prompts.json');
fs.mkdirSync(path.dirname(file), { recursive: true });
fs.writeFileSync(file, JSON.stringify({ version: 1, style: STYLE, count: out.length, species: out }, null, 1) + '\n');
const lens = out.map(o => o.prompt.length);
console.log(`[prompts] ${out.length} species → ${path.relative(ROOT, file)} · prompt length avg ${Math.round(lens.reduce((a, b) => a + b) / lens.length)}, max ${Math.max(...lens)}`);
