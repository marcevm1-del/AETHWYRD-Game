// Project Ascend — monster generator.
// Usage: node Tools/monster_gen/generate.js
// Builds species (core + variants) and population variants from families.js.
// Deterministic: same seed → same output. Edit families.js and rerun.
const fs = require('fs');
const path = require('path');
const FAMILIES = require('./families');

const ROOT = path.join(__dirname, '..', '..');
const OUT_DATA = path.join(ROOT, 'Data', 'Monsters');
const OUT_DOC = path.join(ROOT, '08_Bestiary', 'species_catalog.md');
const MIN_SPECIES = 620;
const POP_PER_SPECIES = 11;

// ---------- seeded RNG ----------
let seed = 1024;
function rnd() {
  seed = (seed + 0x6D2B79F5) | 0;
  let t = Math.imul(seed ^ (seed >>> 15), 1 | seed);
  t = (t + Math.imul(t ^ (t >>> 7), 61 | t)) ^ t;
  return ((t ^ (t >>> 14)) >>> 0) / 4294967296;
}
const pick = a => a[Math.floor(rnd() * a.length)];
const cap = s => s.charAt(0).toUpperCase() + s.slice(1);
const slug = s => s.toLowerCase().replace(/[^a-z0-9]+/g, '_').replace(/^_|_$/g, '');

// ---------- ranks ----------
const RANKS = ['F', 'E', 'D', 'C', 'B', 'A', 'S', 'SS', 'SSS', 'EX'];
function rankVal(r) {
  const m = r.match(/^(SSS|SS|S|EX|F|E|D|C|B|A)([+-]?)$/);
  if (!m) throw new Error('Bad rank ' + r);
  return RANKS.indexOf(m[1]) * 3 + (m[2] === '-' ? 0 : m[2] === '+' ? 2 : 1);
}
function rankStr(v) {
  v = Math.max(0, Math.min(RANKS.length * 3 - 1, v));
  const i = Math.floor(v / 3), s = v % 3;
  return RANKS[i] + (s === 0 ? '-' : s === 2 ? '+' : '');
}
const rankLetter = r => r.replace(/[+-]$/, '');

// ---------- elements ----------
const EL = {
  None:      { pal: ['#8a8f98', '#5b5f66', '#c9c2b5'], tone: 'muted greys and dusty browns', aura: 'no visible aura, only the sound of its breathing', vfx: 'dust_puffs', weak: 'Fire', pre: ['Grim', 'Gutter', 'Old'] },
  Fire:      { pal: ['#e2502b', '#ffb347', '#3a1a12'], tone: 'ember reds fading to soot black', aura: 'heat-shimmer and drifting sparks', vfx: 'embers_heat_haze', weak: 'Water', pre: ['Ember', 'Cinder', 'Blaze', 'Ash'] },
  Water:     { pal: ['#2f7fd1', '#9ad7ff', '#123a5c'], tone: 'deep blues with a glassy shine', aura: 'fine mist and droplets that orbit it', vfx: 'mist_droplets', weak: 'Lightning', pre: ['Tide', 'Brine', 'Rain'] },
  Ice:       { pal: ['#bfe9ff', '#5fa8d3', '#f4fbff'], tone: 'pale blues and frost-white', aura: 'falling snow motes and frosted ground where it steps', vfx: 'frost_trail_snow', weak: 'Fire', pre: ['Frost', 'Rime', 'Glacier', 'Snow'] },
  Lightning: { pal: ['#ffe14d', '#6c5ce7', '#1b1b3a'], tone: 'storm violet shot through with electric yellow', aura: 'crackling arcs that jump across its body', vfx: 'arc_sparks', weak: 'Earth', pre: ['Storm', 'Volt', 'Thunder'] },
  Earth:     { pal: ['#8b5a2b', '#c2a878', '#4a4a3a'], tone: 'ochre, clay and mossy stone', aura: 'pebbles that tremble and float near it', vfx: 'rock_debris', weak: 'Wind', pre: ['Stone', 'Crag', 'Iron', 'Mud'] },
  Wind:      { pal: ['#a8e6cf', '#dcedc1', '#5b8c85'], tone: 'pale jade and cloud white', aura: 'swirling leaves and a constant breeze', vfx: 'wind_ribbons', weak: 'Fire', pre: ['Gale', 'Sky', 'Zephyr'] },
  Nature:    { pal: ['#4caf50', '#a5d66f', '#3e2723'], tone: 'leaf greens over bark brown', aura: 'drifting pollen and tiny blossoms', vfx: 'pollen_petals', weak: 'Fire', pre: ['Thorn', 'Moss', 'Bramble', 'Briar'] },
  Poison:    { pal: ['#8e44ad', '#b8e986', '#2d1b3d'], tone: 'bruise purple with sickly green', aura: 'a low toxic haze that clings to the ground', vfx: 'toxic_fog', weak: 'Light', pre: ['Blight', 'Venom', 'Rot'] },
  Light:     { pal: ['#fff3b0', '#ffd166', '#ffffff'], tone: 'warm gold and pearl white', aura: 'soft radiance and floating motes of light', vfx: 'holy_motes', weak: 'Dark', pre: ['Radiant', 'Dawn', 'Gilded'] },
  Dark:      { pal: ['#2d2a4a', '#6b5b95', '#0d0d14'], tone: 'ink black with bruised violet', aura: 'shadows that lean toward it', vfx: 'shadow_wisps', weak: 'Light', pre: ['Shade', 'Dusk', 'Gloom', 'Night'] },
  Blood:     { pal: ['#8b0000', '#d7263d', '#1a0505'], tone: 'arterial crimson and dried-blood brown', aura: 'a faint red mist that smells of iron', vfx: 'blood_mist', weak: 'Light', pre: ['Crimson', 'Sanguine'] },
  Void:      { pal: ['#0b0b1a', '#3d2c8d', '#c9c9ff'], tone: 'starless black with faint violet edges', aura: 'warped air, as if space bends around it', vfx: 'void_distortion', weak: 'Light', pre: ['Hollow', 'Null', 'Abyss'] }
};
const SHIFT_ELEMENTS = ['Fire', 'Water', 'Ice', 'Lightning', 'Earth', 'Wind', 'Nature', 'Poison', 'Light', 'Dark'];
const ELEMENT_WORDS = new Set(['Blue', 'Green', 'Red', 'Poison', 'Frost', 'Fire', 'Thunder', 'Storm', 'Ember', 'Metal', 'Bubble', 'Venom', 'Sand', 'Swamp', 'Cave', 'Forest', 'Moon', 'Earth', 'Shadow', 'Shade', 'Night', 'Glass', 'Rainbow', 'Dune', 'Tunnel', 'Labyrinth', 'Hill', 'Wild', 'Giant']);

// ---------- menace ----------
const MEN = {
  1: { label: 'Charming', eyes: ['big round glossy eyes', 'two bright dot eyes', 'wide curious eyes with star-shaped highlights'], tex: 'smooth and clean', motion: ['bounces happily', 'waddles', 'hops in little bursts'], shape: 'circle-based, soft silhouette' },
  2: { label: 'Wild', eyes: ['alert animal eyes', 'amber predator eyes', 'dark, wary eyes'], tex: 'weathered and natural', motion: ['prowls', 'stalks low to the ground', 'lopes in long strides'], shape: 'real-animal silhouette with one fantasy exaggeration' },
  3: { label: 'Menacing', eyes: ['narrow glowing eyes', 'burning slit pupils', 'eyes that catch torchlight like coins'], tex: 'rough, scarred and spiked', motion: ['charges without hesitation', 'strides with heavy steps', 'circles its prey'], shape: 'triangle-based silhouette, sharp asymmetric spikes' },
  4: { label: 'Dread', eyes: ['eyes set slightly too far apart', 'pale, pupil-less eyes', 'eyes that never blink'], tex: 'patchy and subtly wrong, as if assembled from memory', motion: ['moves in jerky stop-motion bursts', 'glides without moving its legs', 'freezes whenever it is looked at'], shape: 'elongated, irregular silhouette; still-then-sudden timing' },
  5: { label: 'Horror', eyes: ['too many eyes, opening one after another', 'a human-like face in the wrong place', 'no eyes at all, only a wide and patient mouth'], tex: 'stretched, stitched and constantly shifting', motion: ['crawls across ceilings', 'copies the walk of whatever it hunts', 'unfolds into something larger'], shape: 'broken symmetry, mimicry, audio-first reveal' }
};

// ---------- rank ornament ----------
const ORN = {
  F: 'It has no ornament at all: simple, readable shapes.',
  E: 'Small scars and rough edges mark it as a survivor.',
  D: 'A distinctive marking runs along its back.',
  C: 'Battle-worn plates and trophies hang from its body.',
  B: 'Faint runes glow along its body when it fights.',
  A: 'An elegant crest and glowing veins of mana mark it as a champion of its kind.',
  S: 'Its regal silhouette is crowned by a halo-like ring of aura.',
  SS: 'The air distorts slightly around its outline.',
  SSS: 'Its presence is world-scale; the sky changes color when it appears.',
  EX: 'Its presence is world-scale; the sky changes color when it appears.'
};

// ---------- rigs ----------
const LONG_RIGS = new Set(['serpent', 'fish', 'dragon', 'wyvern', 'quad_large', 'quad_small', 'hexapod', 'octopod', 'cephalopod', 'naga']);
const RIGS = {
  blob: { build: ['a dome-shaped gelatinous body', 'a teardrop-shaped jelly body', 'a wobbling mound of translucent gel'], parts: ['face_decal', 'crown_slot', 'inner_core', 'surface_bubbles', 'drip_trail'], anims: 'blob_set' },
  small_biped: { build: ['a hunched, wiry humanoid frame', 'a scrawny biped with long arms and bowed legs', 'a small, compact humanoid body'], parts: ['ears_long', 'nose_hooked', 'crude_armor', 'loincloth', 'weapon_socket', 'bone_trinkets'], anims: 'small_biped_set' },
  medium_biped: { build: ['an upright humanoid build', 'a lean humanoid frame', 'a broad-shouldered humanoid build'], parts: ['horns', 'armor_plates', 'cloak', 'weapon_socket', 'tail', 'mask'], anims: 'humanoid_set' },
  large_biped: { build: ['a towering, heavy-limbed body', 'a massive hunched brute frame', 'a giant, barrel-chested humanoid body'], parts: ['tusks', 'club_socket', 'chain_belt', 'stone_growths', 'scar_decals', 'hair_mane'], anims: 'brute_set' },
  quad_small: { build: ['a small, quick four-legged body', 'a compact quadruped frame', 'a low, springy quadruped build'], parts: ['horn_single', 'ears_tall', 'tail_bushy', 'fur_tufts', 'whiskers'], anims: 'quad_small_set' },
  quad_large: { build: ['a powerful four-legged hunter\'s body', 'a heavy, muscular quadruped frame', 'a long-legged predatory quadruped build'], parts: ['mane', 'fangs_long', 'antlers', 'armored_back', 'tail_club', 'claws'], anims: 'quad_large_set' },
  hexapod: { build: ['a six-legged armored body', 'a segmented six-limbed frame', 'a low, wide insectoid build'], parts: ['mandibles', 'wing_cases', 'antennae', 'stinger', 'carapace_ridges'], anims: 'insect_set' },
  octopod: { build: ['an eight-legged arachnid body', 'a bulbous spider frame on long jointed legs', 'a squat, many-legged arachnid build'], parts: ['fangs', 'eye_cluster', 'web_spinneret', 'leg_spikes', 'hair_bristles', 'humanoid_torso'], anims: 'spider_set' },
  serpent: { build: ['a long, sinuous serpentine body', 'a coiling, legless body', 'a massive snake-like frame'], parts: ['hood', 'fins', 'horns_swept', 'rattle_tail', 'scale_ridges'], anims: 'serpent_set' },
  wyvern: { build: ['a bipedal winged body with wing-arms', 'a lean, wing-armed drake frame', 'a sleek flying build'], parts: ['wing_membrane', 'tail_spike', 'horn_crown', 'neck_frill', 'talons'], anims: 'wyvern_set' },
  dragon: { build: ['a four-legged, two-winged dragon body', 'a vast quadruped dragon frame with cathedral wings', 'an ancient, serpentine dragon body'], parts: ['horn_crown', 'wing_membrane', 'spine_plates', 'whiskers_long', 'tail_blade', 'glowing_throat'], anims: 'dragon_set' },
  avian: { build: ['a feathered avian body', 'a broad-winged bird frame', 'a tall, long-legged bird build'], parts: ['crest', 'tail_plumes', 'talons', 'beak_hooked', 'wing_feathers'], anims: 'bird_set' },
  flyer_small: { build: ['a small winged body', 'a bat-like flying frame', 'a tiny, darting winged build'], parts: ['membrane_wings', 'horns_small', 'tail_thin', 'fangs'], anims: 'flyer_small_set' },
  floating: { build: ['a drifting, half-formed body', 'a floating, cloth-like shape', 'a bodiless, glowing form'], parts: ['trailing_wisps', 'mask_face', 'lantern_core', 'chains', 'tattered_shroud'], anims: 'float_set' },
  plant_rooted: { build: ['a rooted plant body', 'a huge bulbous flower on a thick stalk', 'a cluster of vines around a central bloom'], parts: ['petal_jaws', 'vine_whips', 'spore_pods', 'root_tendrils', 'thorns'], anims: 'rooted_set' },
  plant_walker: { build: ['a walking body of bark and root', 'a mushroom-capped walking body', 'a tall, tree-like walking frame'], parts: ['bark_plates', 'moss_cover', 'branch_arms', 'cap', 'glowing_knots'], anims: 'walker_set' },
  golem: { build: ['a blocky construct body', 'a heavy, hand-built humanoid shell', 'a towering machine-like frame'], parts: ['rune_core', 'plate_armor', 'gear_joints', 'crystal_growths', 'empty_visor'], anims: 'golem_set' },
  taur: { build: ['a centauroid body with a humanoid torso on a four-legged base', 'a tall half-beast frame', 'a powerful taur build'], parts: ['humanoid_torso', 'horns', 'weapon_socket', 'mane', 'barding'], anims: 'taur_set' },
  naga: { build: ['a humanoid upper body on a long serpent tail', 'a coiling half-serpent frame', 'an elegant serpentfolk build'], parts: ['hood', 'jewelry', 'scale_patterns', 'multiple_arms', 'crown'], anims: 'naga_set' },
  cephalopod: { build: ['a tentacled, soft-bodied form', 'a bulbous body with writhing arms', 'a huge many-armed sea body'], parts: ['tentacles', 'suckers', 'ink_sac', 'beak', 'glowing_spots'], anims: 'cephalopod_set' },
  fish: { build: ['a streamlined aquatic body', 'a heavy-jawed fish frame', 'a long, finned body'], parts: ['fins_sail', 'teeth_rows', 'lure', 'scales_armored', 'gills'], anims: 'fish_set' },
  swarm: { build: ['a swarm of many small bodies moving as one', 'a cloud of tiny creatures', 'a living carpet of small bodies'], parts: ['individual_unit', 'formation_shapes', 'swarm_core'], anims: 'swarm_set' },
  mimic: { build: ['an object-shaped body that hides its true form', 'a disguised body pretending to be furniture', 'a hollow shell posing as an everyday object'], parts: ['tongue', 'teeth_ring', 'hinge_jaw', 'hidden_legs', 'fake_surface'], anims: 'mimic_set' },
  aberrant: { build: ['an asymmetric body with too many limbs', 'a shape that keeps rearranging itself', 'a tall, impossibly thin frame'], parts: ['extra_arms', 'mouth_clusters', 'eye_clusters', 'human_mask', 'joint_spikes'], anims: 'aberrant_set' },
  headless: { build: ['an armored humanoid body without a head', 'a headless rider frame', 'a tall, headless knightly build'], parts: ['head_carried', 'flame_neck', 'mount', 'lance', 'tattered_cape'], anims: 'headless_set' }
};

// ---------- regions ----------
const REGIONS = [
  ['Aldmere', ['plains', 'forest', 'swamp', 'ruins', 'city']], ['Whisperwood', ['forest', 'ruins']], ['Greymoor', ['swamp']],
  ['Vharlen', ['plains', 'city', 'mountain']], ['Strife Marches', ['plains', 'ruins', 'forest']], ['Lirian', ['coast', 'city']],
  ['Bastion', ['steppe', 'city']], ['Gearholm', ['city', 'mountain']], ['Fanghold', ['plains', 'steppe']], ['Sylvaran', ['forest']],
  ['Iron Hold', ['mountain', 'volcanic', 'cave']], ['Hoshizora', ['forest', 'mountain', 'coast', 'spirit']], ['Shen-Lu', ['mountain', 'forest', 'spirit']],
  ['Haneul', ['mountain', 'city']], ['Kitsune Isles', ['coast', 'spirit', 'forest']], ['Frostveil', ['tundra', 'mountain']],
  ['Heavenreach', ['mountain', 'sky']], ['Sunscar', ['desert', 'ruins']], ['Zaruma', ['plains', 'desert']], ['Xochitl Mire', ['swamp', 'jungle']],
  ['Stormreach', ['coast', 'mountain']], ['True-Name Isles', ['coast', 'sea']], ['Goldmere Coast', ['coast', 'sea']], ['Everdusk', ['forest', 'spirit']],
  ['Moraveil', ['forest', 'plains', 'cave']], ['Calamity Steppe', ['steppe']], ['Nox Dominion', ['demon', 'volcanic', 'ruins']],
  ['Sky Archipelago', ['sky', 'ruins']], ['Dragon Spine', ['mountain', 'volcanic']], ['Dunewhale Drift', ['desert']], ['Lustrine Shores', ['coast']],
  ['Mossdeep', ['forest']], ['Velmark', ['plains', 'city']], ['Ashira Vale', ['plains', 'forest']], ['Cinderhole', ['city', 'cave']],
  ['Lumbaya', ['jungle', 'coast', 'ruins']], ['Whitewater Reach', ['tundra', 'coast', 'sea']], ['Apu Highlands', ['mountain']],
  ['Zarvan', ['desert', 'mountain', 'city']], ['Quaking Lands', ['mountain', 'plains']], ['Umbravel', ['underworld', 'cave']],
  ['Hollow Sea', ['underworld', 'sea']], ['Aurumdeep', ['underworld', 'ruins']], ['The Maw', ['underworld', 'cave']],
  ['Root of the World', ['underworld']], ['Great Labyrinth', ['cave', 'ruins', 'underworld']], ['Vesper', ['demon', 'ruins', 'sky']]
];
const BIOME_WORD = { forest: 'Grove', swamp: 'Bog', desert: 'Dune', tundra: 'Rime', mountain: 'Crag', volcanic: 'Cinder', coast: 'Reef', cave: 'Cavern', jungle: 'Vine', ruins: 'Ruin', city: 'Alley', underworld: 'Deep', sky: 'Cloud', plains: 'Meadow', steppe: 'Steppe', sea: 'Abyssal', demon: 'Hellmarch', spirit: 'Veil' };
const BIOME_ELEMENT = { forest: 'Nature', swamp: 'Poison', desert: 'Earth', tundra: 'Ice', mountain: 'Earth', volcanic: 'Fire', coast: 'Water', cave: 'Earth', jungle: 'Nature', ruins: 'Dark', city: 'None', underworld: 'Dark', sky: 'Wind', plains: 'Wind', steppe: 'Wind', sea: 'Water', demon: 'Dark', spirit: 'Light' };
const BIOME_LOOK = {
  forest: 'moss-green coloring that blends with the undergrowth', swamp: 'mud-slick, algae-streaked skin', desert: 'sun-bleached, sand-scoured coloring',
  tundra: 'a thick, frost-rimed coat', mountain: 'slate-grey coloring and hardened hide', volcanic: 'ash-dark coloring with glowing cracks',
  coast: 'salt-crusted, barnacle-flecked hide', cave: 'pale, light-starved coloring and oversized eyes', jungle: 'vivid tropical markings',
  ruins: 'dust-grey coloring and old rune scars', city: 'soot-stained hide and scavenged scraps', underworld: 'bioluminescent spots along its body',
  sky: 'cloud-pale coloring and lighter bones', plains: 'golden, grass-toned coloring', steppe: 'wind-burnt coloring and a lean frame',
  sea: 'deep-water coloring and glowing lures', demon: 'red-black coloring with faint ember veins', spirit: 'a faint translucent shimmer'
};
function regionsFor(fam) {
  if (fam.regions) return REGIONS.filter(r => fam.regions.includes(r[0]));
  const rs = REGIONS.filter(r => r[1].some(b => fam.biomes.includes(b)));
  return rs.length ? rs : REGIONS;
}

// ---------- behaviors ----------
const ADVICE = {
  Passive: 'Leaves you alone unless attacked.', Territorial: 'Attacks only if you come close to its home; back away to avoid a fight.',
  Swarm: 'Dangerous in numbers. Area attacks and chokepoints help.', Pack: 'Never alone. Kill the leader first and the rest may scatter.',
  Ambush: 'Waits in hiding. Perception skills and light sources reveal it.', Aggressive: 'Attacks on sight. Expect a fight.',
  Skittish: 'Flees when hurt. Snares or ranged attacks work best.', Guardian: 'Protects something nearby: a nest, a treasure, or a place.'
};

// ---------- variants ----------
const HUMANOID_TYPES = new Set(['Humanoid', 'Beastman', 'Serpentfolk', 'Beastfolk', 'Lunar Raider']);
const VARIANT_TYPES = ['elemental', 'elemental', 'elemental', 'elder', 'elder', 'corrupted', 'corrupted', 'ancient', 'spirit', 'regional', 'regional'];
function stripElementWord(name) {
  const w = name.split(' ');
  return w.length > 1 && ELEMENT_WORDS.has(w[0]) ? w.slice(1).join(' ') : name;
}

// ---------- species build ----------
const species = [];
const usedNames = new Set();

function describe(sp, fam) {
  const rig = RIGS[sp.rig];
  const menace = MEN[sp.menace];
  const el = EL[sp.element] || EL.None;
  const dim = sp.rig === 'swarm'
    ? `each one is about ${sp.size} m long, but the swarm covers several meters`
    : `about ${sp.size} m ${LONG_RIGS.has(sp.rig) ? 'long' : 'tall'}`;
  const sizeWord = sp.size < 0.5 ? 'tiny' : sp.size < 1.2 ? 'small' : sp.size < 2.5 ? 'person-sized' : sp.size < 5 ? 'large' : sp.size < 15 ? 'huge' : 'colossal';
  const sig = /^(it |only |its |a |an )/i.test(sp.signature) && !/^(a |an )/i.test(sp.signature)
    ? cap(sp.signature) + '.'
    : pick(['Its most striking feature is ', 'Look for ', 'Guild sketches always show ', 'Survivors describe ']) + sp.signature + '.';
  const parts = [
    `The ${sp.name} is a ${sizeWord} creature with ${pick(rig.build)}, ${dim}.`,
    `Its ${fam.covering} ${/s$| and /.test(fam.covering) ? "are" : "is"} ${menace.tex}, colored in ${el.tone}.`,
    sig,
    `It has ${pick(menace.eyes)}. ${ORN[rankLetter(sp.rank)]}`,
    sp.element === "None" ? `It ${pick(menace.motion)}. It has no visible aura; you hear its breathing before you see it.` : `It ${pick(menace.motion)}, surrounded by ${el.aura}.`
  ];
  if (sp.variantNote) parts.push(sp.variantNote);
  return parts.join(' ');
}

function addSpecies(sp, fam, famKey) {
  if (usedNames.has(sp.name)) return null;
  usedNames.add(sp.name);
  sp.id = `${famKey}_${slug(sp.name)}`;
  sp.family = fam.name;
  sp.familyKey = famKey;
  sp.type = fam.type;
  sp.genre = fam.genre;
  sp.trope = fam.trope;
  sp.menaceLabel = MEN[sp.menace].label;
  sp.behavior = sp.behavior || pick(fam.behaviors);
  const rig = RIGS[sp.rig];
  const nParts = Math.min(rig.parts.length, 2 + Math.floor(rnd() * 3));
  const partPool = [...rig.parts];
  const parts = [];
  while (parts.length < nParts) parts.push(partPool.splice(Math.floor(rnd() * partPool.length), 1)[0]);
  const el = EL[sp.element] || EL.None;
  sp.weakness = el.weak;
  sp.habitats = regionsFor(fam).map(r => r[0]);
  sp.drops = [...fam.drops.slice(0, 2), `${rankLetter(sp.rank)}-Rank Core`];
  sp.fieldNote = `Weak to ${el.weak}. ${ADVICE[sp.behavior]}`;
  sp.designRecipe = {
    rig: sp.rig, baseMesh: `${sp.rig}_base`, parts, material: fam.material, palette: el.pal,
    menaceStyle: MEN[sp.menace].shape, rankOrnament: rankLetter(sp.rank), vfx: el.vfx, animSet: rig.anims,
    scale: sp.size
  };
  sp.look = describe(sp, fam);
  species.push(sp);
  return sp;
}

// Cores
const cores = [];
for (const [famKey, fam] of Object.entries(FAMILIES)) {
  for (const line of fam.cores) {
    const [name, rank, menace, element, size, signature, rigOverride] = line.split('|');
    const sp = addSpecies({
      name, rank, menace: +menace, element, size: +size, signature, rig: rigOverride || fam.rig,
      tier: 'Core', baseOf: null
    }, fam, famKey);
    if (sp) cores.push(sp);
  }
}

// Variants
function makeVariant(core, kind) {
  const fam = FAMILIES[core.familyKey];
  const v = { ...core, tier: 'Variant', baseOf: core.id, variantKind: kind, signature: core.signature };
  delete v.id; delete v.look; delete v.designRecipe; delete v.behavior;
  const rv = rankVal(core.rank);
  if (kind === 'elemental') {
    const els = SHIFT_ELEMENTS.filter(e => e !== core.element);
    v.element = pick(els);
    v.name = `${pick(EL[v.element].pre)} ${stripElementWord(core.name)}`;
    v.rank = rankStr(rv + 1);
    v.variantNote = `This ${v.element}-attuned variant carries one extra elemental feature, like ${pick(['crystal spikes', 'glowing vein-lines', 'a crest of elemental energy', 'element-scarred hide'])}, in its element's colors.`;
  } else if (kind === 'elder') {
    v.name = HUMANOID_TYPES.has(core.type) ? pick([`Elite ${core.name}`, `${core.name} Veteran`]) : pick([`Elder ${core.name}`, `Greater ${core.name}`]);
    v.rank = rankStr(rv + 3);
    v.size = +(core.size * 1.6).toFixed(1);
    v.variantNote = 'It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.';
  } else if (kind === 'corrupted') {
    v.name = `Vesper-Touched ${core.name}`;
    v.rank = rankStr(rv + 2);
    v.menace = Math.min(5, core.menace + 1);
    v.element = core.element === 'None' ? 'Blood' : core.element;
    v.variantNote = 'Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.';
  } else if (kind === 'ancient') {
    v.name = `Ancient ${core.name}`;
    v.rank = rankStr(rv + 3);
    v.size = +(core.size * 1.5).toFixed(1);
    v.variantNote = 'Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.';
  } else if (kind === 'spirit') {
    v.name = `Phantom ${core.name}`;
    v.rank = rankStr(rv + 1);
    v.menace = Math.min(5, core.menace + 1);
    v.element = 'Light';
    v.variantNote = 'Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.';
  } else if (kind === 'regional') {
    const biome = pick(fam.biomes || ['ruins']);
    v.name = `${BIOME_WORD[biome]} ${stripElementWord(core.name)}`;
    v.rank = rankStr(rv + 1);
    v.element = BIOME_ELEMENT[biome] || core.element;
    v.variantNote = `Adapted to ${biome} lands, it has ${BIOME_LOOK[biome]}.`;
  }
  return addSpecies(v, fam, core.familyKey);
}

const eligible = cores.filter(c => rankLetter(c.rank) !== 'EX' && !c.name.includes(','));
let round = 0;
while (species.length < MIN_SPECIES && round < 6) {
  for (const c of eligible) {
    if (species.length >= MIN_SPECIES && round > 0) break;
    for (let tries = 0; tries < 4; tries++) {
      if (makeVariant(c, pick(VARIANT_TYPES))) break;
    }
  }
  round++;
}

// ---------- population ----------
const TIERS = [
  { n: 'Runt', r: -2, s: 0.7, d: 'smaller and scrappier than usual' },
  { n: 'Juvenile', r: -1, s: 0.85, d: 'young, with brighter colors and unworn features' },
  { n: '', r: 0, s: 1.0, d: 'a typical adult of its kind' },
  { n: 'Scarred', r: 1, s: 1.1, d: 'covered in old battle scars' },
  { n: 'Alpha', r: 2, s: 1.25, d: 'larger and scarred, and others of its kind follow it' },
  { n: 'Albino', r: 1, s: 1.0, d: 'a rare pale form with red eyes' },
  { n: 'Elderborn', r: 3, s: 1.35, d: 'old and wise, with greying features and a cautious hunting style' }
];
const population = [];
const popNames = new Set();
for (const sp of species) {
  const fam = FAMILIES[sp.familyKey];
  const regions = regionsFor(fam);
  const combos = [];
  for (const r of regions) for (const t of TIERS) combos.push([r, t]);
  // deterministic shuffle
  for (let i = combos.length - 1; i > 0; i--) { const j = Math.floor(rnd() * (i + 1)); [combos[i], combos[j]] = [combos[j], combos[i]]; }
  let made = 0;
  for (const [r, t] of combos) {
    if (made >= POP_PER_SPECIES) break;
    const name = `${r[0]} ${sp.name}${t.n ? ' ' + t.n : ''}`;
    if (popNames.has(name)) continue;
    popNames.add(name);
    const biome = r[1].find(b => (fam.biomes || []).includes(b)) || r[1][0];
    const isUnique = rankLetter(sp.rank) === 'EX' || sp.name.includes(',');
    if (isUnique && made >= 1) break; // unique beings have a single population entry
    population.push({
      id: `pop_${String(population.length + 1).padStart(5, '0')}`,
      name: isUnique ? sp.name : name,
      speciesId: sp.id, species: sp.name, family: sp.family, type: sp.type, genre: sp.genre,
      region: r[0], tier: t.n || 'Adult',
      rank: isUnique ? sp.rank : rankStr(rankVal(sp.rank) + t.r),
      size: +(sp.size * (isUnique ? 1 : t.s)).toFixed(2),
      menace: sp.menaceLabel, element: sp.element,
      look: isUnique ? 'Unique being; see species entry.' : (t.n ? `Like a typical ${sp.name}, but ${t.d}, with ${BIOME_LOOK[biome] || 'local coloring'}.` : `A typical adult ${sp.name} of this region, with ${BIOME_LOOK[biome] || 'local coloring'}.`),
      behavior: sp.behavior,
      spawn: sp.menace >= 4 || sp.type === 'Undead' ? 'Night' : sp.menace === 1 ? 'Day' : 'Day & Night'
    });
    made++;
  }
}

// ---------- write ----------
fs.mkdirSync(OUT_DATA, { recursive: true });
const csvEsc = v => `"${String(v ?? '').replace(/"/g, '""')}"`;
function writeCsv(file, rows, cols) {
  const lines = [cols.join(',')].concat(rows.map(r => cols.map(c => csvEsc(typeof r[c] === 'object' ? JSON.stringify(r[c]) : r[c])).join(',')));
  fs.writeFileSync(file, lines.join('\n'), 'utf8');
}
const spOut = species.map(s => ({
  id: s.id, name: s.name, family: s.family, type: s.type, genre: s.genre, tier: s.tier, variantKind: s.variantKind || '',
  baseSpecies: s.baseOf || '', rank: s.rank, menace: s.menace, menaceLabel: s.menaceLabel, element: s.element, weakness: s.weakness,
  sizeMeters: s.size, build: s.rig, behavior: s.behavior, signature: s.signature, look: s.look, habitats: s.habitats,
  drops: s.drops, fieldNote: s.fieldNote, trope: s.trope, designRecipe: s.designRecipe
}));
fs.writeFileSync(path.join(OUT_DATA, 'species.json'), JSON.stringify(spOut, null, 1), 'utf8');
writeCsv(path.join(OUT_DATA, 'species.csv'), spOut, ['id', 'name', 'family', 'type', 'genre', 'tier', 'variantKind', 'baseSpecies', 'rank', 'menaceLabel', 'element', 'weakness', 'sizeMeters', 'build', 'behavior', 'signature', 'look', 'habitats', 'drops', 'fieldNote', 'designRecipe']);
fs.writeFileSync(path.join(OUT_DATA, 'population.json'), JSON.stringify(population, null, 1), 'utf8');
writeCsv(path.join(OUT_DATA, 'population.csv'), population, ['id', 'name', 'speciesId', 'species', 'family', 'type', 'genre', 'region', 'tier', 'rank', 'size', 'menace', 'element', 'look', 'behavior', 'spawn']);

// Markdown catalog
let md = `# 08f — Species Catalog (generated)\n\n> Generated by \`Tools/monster_gen/generate.js\`. **Do not edit by hand**: edit \`families.js\` and rerun.\n\n**${species.length} species** (${cores.length} core + ${species.length - cores.length} variants) · **${population.length} population variants** in \`Data/Monsters/population.csv\`.\n\n`;
const byFam = {};
for (const s of spOut) (byFam[s.family] ||= []).push(s);
md += '## Families\n' + Object.entries(byFam).map(([f, l]) => `- ${f} (${l.length})`).join('\n') + '\n\n';
for (const [f, list] of Object.entries(byFam)) {
  md += `## ${f}\n*${list[0].type} · ${list[0].genre} · Trope: ${list[0].trope}*\n\n`;
  for (const s of list) {
    md += `### ${s.name} \`${s.rank}\`\n`;
    md += `**${s.tier}${s.variantKind ? ' (' + s.variantKind + ')' : ''}** · ${s.menaceLabel} · ${s.element} (weak: ${s.weakness}) · ${s.sizeMeters} m · Build: \`${s.build}\` · ${s.behavior}\n\n`;
    md += `${s.look}\n\n`;
    md += `- **Field note:** ${s.fieldNote}\n- **Drops:** ${s.drops.join(', ')}\n- **Found in:** ${s.habitats.slice(0, 6).join(', ')}${s.habitats.length > 6 ? ` +${s.habitats.length - 6} more` : ''}\n`;
    md += `- **Design:** rig \`${s.designRecipe.rig}\` + parts [${s.designRecipe.parts.join(', ')}] · material \`${s.designRecipe.material}\` · palette ${s.designRecipe.palette.join(' ')} · VFX \`${s.designRecipe.vfx}\`\n\n`;
  }
}
fs.writeFileSync(OUT_DOC, md, 'utf8');

console.log(`Families: ${Object.keys(FAMILIES).length}`);
console.log(`Species: ${species.length} (core ${cores.length}, variants ${species.length - cores.length})`);
console.log(`Population: ${population.length}`);
