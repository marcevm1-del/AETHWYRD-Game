// AETHWYRD — monster generator (v2).
// Usage (from the project root):  node Tools/monster_gen/generate.js
// Inputs:  Tools/monster_gen/families.js, Data/World/regions.json
// Outputs: Data/Monsters/{species,population,attacks,loot_tables}.json (+ .csv),
//          Data/Items/materials.json, 08_Bestiary/bestiary_viewer.html
// Deterministic: same inputs + seed → same output.
const fs = require('fs');
const path = require('path');
const FAMILIES = require('./families');
const TYRANTS = require('./tyrants');
const { chooseParts } = require('./part_rules');
const { paletteFor, valueOf, MIN_V } = require('./palettes');

const ROOT = path.join(__dirname, '..', '..');
const DATA = path.join(ROOT, 'Data');
const PROG = JSON.parse(fs.readFileSync(path.join(DATA, 'Classes', 'progression.json'), 'utf8'));
const REGIONS = JSON.parse(fs.readFileSync(path.join(DATA, 'World', 'regions.json'), 'utf8'));
const REGION_BY_NAME = Object.fromEntries(REGIONS.map(r => [r.name, r]));
const REGION_BY_ID = Object.fromEntries(REGIONS.map(r => [r.id, r]));
const MIN_SPECIES = 640;
const POP_PER_SPECIES = 11;

// Ring 0 = first prototype; Ring 1 = vertical slice (Brindlewick + Whisperwood).
const RING0 = ['Blue Slime', 'Goblin', 'Horned Rabbit'];
const RING1 = ['Green Slime', 'Forest Wolf', 'Goblin Archer', 'Goblin Shaman', 'Goblin Trapper', 'Hobgoblin', 'Wild Boar',
  'Giant Ant', 'Cave Spider', 'Mandrake', 'Walking Mushroom', 'Puffcap Mushroom', 'Zombie', 'Skeleton', 'Smiling Scarecrow',
  'Wisp', 'Giant Crow'];

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

// ---------- ranks & levels ----------
const RANKS = ['F', 'E', 'D', 'C', 'B', 'A', 'S', 'SS', 'SSS', 'EX'];
const LEVEL_BANDS = { F: [1, 15], E: [16, 35], D: [36, 60], C: [61, 90], B: [91, 125], A: [126, 165], S: [166, 210], SS: [211, 260], SSS: [261, 300], EX: [300, 300] };
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
const rankIdx = r => RANKS.indexOf(rankLetter(r));
function levelFor(rank) {
  const [a, b] = LEVEL_BANDS[rankLetter(rank)];
  const sub = rankVal(rank) % 3; // 0 '-', 1 '', 2 '+'
  return Math.round(a + (b - a) * [0.15, 0.5, 0.85][sub]);
}

// ---------- elements ----------
const EL = {
  None:      { pal: ['#8a8f98', '#5b5f66', '#c9c2b5'], tone: 'muted greys and dusty browns', aura: null, vfx: 'dust_puffs', weak: 'Fire', pre: ['Grim', 'Gutter', 'Old'], skill: null, biomes: [] },
  Fire:      { pal: ['#e2502b', '#ffb347', '#3a1a12'], tone: 'ember reds fading to soot black', aura: 'heat-shimmer and drifting sparks', vfx: 'embers_heat_haze', weak: 'Water', pre: ['Ember', 'Cinder', 'Blaze', 'Ash'], skill: 'Ember Burst', biomes: ['volcanic', 'desert', 'demon'] },
  Water:     { pal: ['#2f7fd1', '#9ad7ff', '#123a5c'], tone: 'deep blues with a glassy shine', aura: 'fine mist and droplets that orbit it', vfx: 'mist_droplets', weak: 'Lightning', pre: ['Tide', 'Brine', 'Rain'], skill: 'Tide Lash', biomes: ['coast', 'sea', 'swamp'] },
  Ice:       { pal: ['#bfe9ff', '#5fa8d3', '#f4fbff'], tone: 'pale blues and frost-white', aura: 'falling snow motes and frosted ground where it steps', vfx: 'frost_trail_snow', weak: 'Fire', pre: ['Frost', 'Rime', 'Glacier', 'Snow'], skill: 'Frost Breath', biomes: ['tundra', 'mountain'] },
  Lightning: { pal: ['#ffe14d', '#6c5ce7', '#1b1b3a'], tone: 'storm violet shot through with electric yellow', aura: 'crackling arcs that jump across its body', vfx: 'arc_sparks', weak: 'Earth', pre: ['Storm', 'Volt', 'Thunder'], skill: 'Static Arc', biomes: ['mountain', 'sky', 'steppe', 'coast'] },
  Earth:     { pal: ['#8b5a2b', '#c2a878', '#4a4a3a'], tone: 'ochre, clay and mossy stone', aura: 'pebbles that tremble and float near it', vfx: 'rock_debris', weak: 'Wind', pre: ['Stone', 'Crag', 'Iron', 'Mud'], skill: 'Stone Spike', biomes: ['mountain', 'cave', 'desert'] },
  Wind:      { pal: ['#a8e6cf', '#dcedc1', '#5b8c85'], tone: 'pale jade and cloud white', aura: 'swirling leaves and a constant breeze', vfx: 'wind_ribbons', weak: 'Fire', pre: ['Gale', 'Sky', 'Zephyr'], skill: 'Gale Cutter', biomes: ['sky', 'plains', 'steppe', 'mountain'] },
  Nature:    { pal: ['#4caf50', '#a5d66f', '#3e2723'], tone: 'leaf greens over bark brown', aura: 'drifting pollen and tiny blossoms', vfx: 'pollen_petals', weak: 'Fire', pre: ['Thorn', 'Moss', 'Bramble', 'Briar'], skill: 'Thorn Volley', biomes: ['forest', 'jungle', 'swamp'] },
  Poison:    { pal: ['#8e44ad', '#b8e986', '#2d1b3d'], tone: 'bruise purple with sickly green', aura: 'a low toxic haze that clings to the ground', vfx: 'toxic_fog', weak: 'Light', pre: ['Blight', 'Venom', 'Rot'], skill: 'Venom Spit', biomes: ['swamp', 'jungle', 'cave'] },
  Light:     { pal: ['#fff3b0', '#ffd166', '#ffffff'], tone: 'warm gold and pearl white', aura: 'soft radiance and floating motes of light', vfx: 'holy_motes', weak: 'Dark', pre: ['Radiant', 'Dawn', 'Gilded'], skill: 'Radiant Pulse', biomes: ['spirit', 'sky'] },
  Dark:      { pal: ['#2d2a4a', '#6b5b95', '#0d0d14'], tone: 'ink black with bruised violet', aura: 'shadows that lean toward it', vfx: 'shadow_wisps', weak: 'Light', pre: ['Shade', 'Dusk', 'Gloom', 'Night'], skill: 'Shadow Grasp', biomes: ['ruins', 'underworld', 'cave', 'demon'] },
  Blood:     { pal: ['#8b0000', '#d7263d', '#1a0505'], tone: 'arterial crimson and dried-blood brown', aura: 'a faint red mist that smells of iron', vfx: 'blood_mist', weak: 'Light', pre: ['Crimson', 'Sanguine'], skill: 'Blood Lance', biomes: ['demon', 'ruins'] },
  Void:      { pal: ['#0b0b1a', '#3d2c8d', '#c9c9ff'], tone: 'starless black with faint violet edges', aura: 'warped air, as if space bends around it', vfx: 'void_distortion', weak: 'Light', pre: ['Hollow', 'Null', 'Abyss'], skill: 'Null Rift', biomes: ['underworld', 'demon', 'sky'] }
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
const ORN = {
  F: 'It has no ornament at all: simple, readable shapes.', E: 'Small scars and rough edges mark it as a survivor.',
  D: 'A distinctive marking runs along its back.', C: 'Battle-worn plates and trophies hang from its body.',
  B: 'Faint runes glow along its body when it fights.', A: 'An elegant crest and glowing veins of mana mark it as a champion of its kind.',
  S: 'Its regal silhouette is crowned by a halo-like ring of aura.', SS: 'The air distorts slightly around its outline.',
  SSS: 'Its outline is crowned by slowly turning rings of light; lesser monsters flee from it.',
  EX: 'Its presence is world-scale; the sky changes color when it appears.'
};

// ---------- rigs: build text, parts, archetype, attacks ----------
const LONG_RIGS = new Set(['serpent', 'fish', 'dragon', 'wyvern', 'quad_large', 'quad_small', 'hexapod', 'octopod', 'cephalopod', 'naga']);
const ARCH = {
  tank:       { hp: 1.4, atk: 1.0, def: 1.5, matk: 0.6, mdef: 1.0, spd: 0.7 },
  bruiser:    { hp: 1.1, atk: 1.2, def: 1.0, matk: 0.8, mdef: 0.9, spd: 1.0 },
  skirmisher: { hp: 0.85, atk: 1.0, def: 0.8, matk: 0.7, mdef: 0.8, spd: 1.35 },
  caster:     { hp: 0.8, atk: 0.6, def: 0.7, matk: 1.4, mdef: 1.3, spd: 0.9 },
  swarm:      { hp: 0.7, atk: 0.8, def: 0.6, matk: 0.6, mdef: 0.6, spd: 1.1 },
  ambusher:   { hp: 1.0, atk: 1.25, def: 0.9, matk: 0.9, mdef: 0.9, spd: 1.0 },
  apex:       { hp: 1.5, atk: 1.3, def: 1.2, matk: 1.3, mdef: 1.2, spd: 1.0 }
};
// attack: [name, kind, power, cooldownSec, telegraph]
const RIGS = {
  blob: { arch: 'swarm', build: ['a dome-shaped gelatinous body', 'a teardrop-shaped jelly body', 'a wobbling mound of translucent gel'], parts: ['face_decal', 'crown_slot', 'inner_core', 'surface_bubbles', 'drip_trail'], atk: [['Body Slam', 'melee', 1.0, 0, 'blue'], ['Engulf', 'grab', 1.4, 8, 'gold'], ['Split', 'summon', 0, 20, 'none']] },
  small_biped: { arch: 'skirmisher', build: ['a hunched, wiry humanoid frame', 'a scrawny biped with long arms and bowed legs', 'a small, compact humanoid body'], parts: ['ears_long', 'nose_hooked', 'crude_armor', 'loincloth', 'weapon_socket', 'bone_trinkets'], atk: [['Stab', 'melee', 1.0, 0, 'blue'], ['Thrown Junk', 'ranged', 0.8, 4, 'blue'], ['Frenzied Lunge', 'melee', 1.5, 8, 'red']] },
  medium_biped: { arch: 'bruiser', build: ['an upright humanoid build', 'a lean humanoid frame', 'a broad-shouldered humanoid build'], parts: ['horns', 'armor_plates', 'cloak', 'weapon_socket', 'tail', 'mask'], atk: [['Slash', 'melee', 1.0, 0, 'blue'], ['Heavy Swing', 'melee', 1.6, 6, 'red'], ['Guard Counter', 'counter', 1.3, 10, 'blue']] },
  large_biped: { arch: 'tank', build: ['a towering, heavy-limbed body', 'a massive hunched brute frame', 'a giant, barrel-chested humanoid body'], parts: ['tusks', 'club_socket', 'chain_belt', 'stone_growths', 'scar_decals', 'hair_mane'], atk: [['Stomp', 'aoe', 1.3, 6, 'red'], ['Club Slam', 'melee', 1.8, 8, 'red'], ['Grab and Throw', 'grab', 2.0, 14, 'gold']] },
  quad_small: { arch: 'skirmisher', build: ['a small, quick four-legged body', 'a compact quadruped frame', 'a low, springy quadruped build'], parts: ['horn_single', 'ears_tall', 'tail_bushy', 'fur_tufts', 'whiskers'], atk: [['Bite', 'melee', 1.0, 0, 'blue'], ['Charge', 'dash', 1.3, 5, 'blue'], ['Leap', 'dash', 1.2, 6, 'blue']] },
  quad_large: { arch: 'bruiser', build: ['a powerful four-legged hunter\'s body', 'a heavy, muscular quadruped frame', 'a long-legged predatory quadruped build'], parts: ['mane', 'fangs_long', 'antlers', 'armored_back', 'tail_club', 'claws'], atk: [['Maul', 'melee', 1.2, 0, 'blue'], ['Pounce', 'dash', 1.6, 6, 'red'], ['Howl', 'buff', 0, 18, 'none']] },
  hexapod: { arch: 'tank', build: ['a six-legged armored body', 'a segmented six-limbed frame', 'a low, wide insectoid build'], parts: ['mandibles', 'wing_cases', 'antennae', 'stinger', 'carapace_ridges'], atk: [['Mandible Crush', 'melee', 1.1, 0, 'blue'], ['Burrow Ambush', 'dash', 1.5, 10, 'red'], ['Acid Spray', 'ranged', 1.0, 6, 'blue']] },
  octopod: { arch: 'skirmisher', build: ['an eight-legged arachnid body', 'a bulbous spider frame on long jointed legs', 'a squat, many-legged arachnid build'], parts: ['fangs', 'eye_cluster', 'web_spinneret', 'leg_spikes', 'hair_bristles', 'humanoid_torso'], atk: [['Fang Bite', 'melee', 1.1, 0, 'blue'], ['Web Shot', 'ranged', 0.5, 8, 'blue'], ['Ceiling Drop', 'dash', 1.7, 12, 'red']] },
  serpent: { arch: 'skirmisher', build: ['a long, sinuous serpentine body', 'a coiling, legless body', 'a massive snake-like frame'], parts: ['hood', 'fins', 'horns_swept', 'rattle_tail', 'scale_ridges'], atk: [['Strike', 'melee', 1.2, 0, 'blue'], ['Constrict', 'grab', 1.8, 12, 'gold'], ['Tail Sweep', 'aoe', 1.2, 7, 'red']] },
  wyvern: { arch: 'bruiser', build: ['a bipedal winged body with wing-arms', 'a lean, wing-armed drake frame', 'a sleek flying build'], parts: ['wing_membrane', 'tail_spike', 'horn_crown', 'neck_frill', 'talons'], atk: [['Talon Rake', 'melee', 1.2, 0, 'blue'], ['Dive Bomb', 'dash', 1.9, 10, 'red'], ['Tail Whip', 'aoe', 1.3, 6, 'red']] },
  dragon: { arch: 'apex', build: ['a four-legged, two-winged dragon body', 'a vast quadruped dragon frame with cathedral wings', 'an ancient, serpentine dragon body'], parts: ['horn_crown', 'wing_membrane', 'spine_plates', 'whiskers_long', 'tail_blade', 'glowing_throat'], atk: [['Claw', 'melee', 1.4, 0, 'blue'], ['Breath', 'aoe', 2.2, 14, 'red'], ['Wing Gust', 'aoe', 1.0, 10, 'blue'], ['Tail Blade', 'melee', 1.8, 8, 'red']] },
  avian: { arch: 'skirmisher', build: ['a feathered avian body', 'a broad-winged bird frame', 'a tall, long-legged bird build'], parts: ['crest', 'tail_plumes', 'talons', 'beak_hooked', 'wing_feathers'], atk: [['Peck', 'melee', 1.0, 0, 'blue'], ['Swoop', 'dash', 1.4, 6, 'blue'], ['Screech', 'debuff', 0, 14, 'none']] },
  flyer_small: { arch: 'skirmisher', build: ['a small winged body', 'a bat-like flying frame', 'a tiny, darting winged build'], parts: ['membrane_wings', 'horns_small', 'tail_thin', 'fangs'], atk: [['Nip', 'melee', 0.9, 0, 'blue'], ['Dart', 'dash', 1.1, 4, 'blue'], ['Swarm Call', 'summon', 0, 20, 'none']] },
  floating: { arch: 'caster', build: ['a drifting, half-formed body', 'a floating, cloth-like shape', 'a bodiless, glowing form'], parts: ['trailing_wisps', 'mask_face', 'lantern_core', 'chains', 'tattered_shroud'], atk: [['Chill Touch', 'melee', 0.9, 0, 'blue'], ['Phase Lunge', 'dash', 1.3, 7, 'red'], ['Wail', 'aoe', 1.2, 12, 'red']] },
  plant_rooted: { arch: 'caster', build: ['a rooted plant body', 'a huge bulbous flower on a thick stalk', 'a cluster of vines around a central bloom'], parts: ['petal_jaws', 'vine_whips', 'spore_pods', 'root_tendrils', 'thorns'], atk: [['Vine Lash', 'melee', 1.1, 0, 'blue'], ['Snap Jaw', 'grab', 1.7, 9, 'gold'], ['Spore Burst', 'aoe', 1.0, 10, 'blue']] },
  plant_walker: { arch: 'ambusher', build: ['a walking body of bark and root', 'a mushroom-capped walking body', 'a tall, tree-like walking frame'], parts: ['bark_plates', 'moss_cover', 'branch_arms', 'cap', 'glowing_knots'], atk: [['Branch Sweep', 'melee', 1.1, 0, 'blue'], ['Root Slam', 'aoe', 1.5, 9, 'red'], ['Regrow', 'heal', 0, 20, 'none']] },
  golem: { arch: 'tank', build: ['a blocky construct body', 'a heavy, hand-built humanoid shell', 'a towering machine-like frame'], parts: ['rune_core', 'plate_armor', 'gear_joints', 'crystal_growths', 'empty_visor'], atk: [['Slam', 'melee', 1.4, 0, 'blue'], ['Ground Pound', 'aoe', 1.8, 10, 'red'], ['Guard Stance', 'buff', 0, 15, 'none']] },
  taur: { arch: 'bruiser', build: ['a centauroid body with a humanoid torso on a four-legged base', 'a tall half-beast frame', 'a powerful taur build'], parts: ['humanoid_torso', 'horns', 'weapon_socket', 'mane', 'barding'], atk: [['Spear Thrust', 'melee', 1.2, 0, 'blue'], ['Trample', 'dash', 1.7, 8, 'red'], ['Volley', 'ranged', 1.0, 6, 'blue']] },
  naga: { arch: 'bruiser', build: ['a humanoid upper body on a long serpent tail', 'a coiling half-serpent frame', 'an elegant serpentfolk build'], parts: ['hood', 'jewelry', 'scale_patterns', 'multiple_arms', 'crown'], atk: [['Coil Strike', 'melee', 1.1, 0, 'blue'], ['Constrict', 'grab', 1.6, 12, 'gold'], ['Hypnotic Gaze', 'debuff', 0, 14, 'none']] },
  cephalopod: { arch: 'ambusher', build: ['a tentacled, soft-bodied form', 'a bulbous body with writhing arms', 'a huge many-armed sea body'], parts: ['tentacles', 'suckers', 'ink_sac', 'beak', 'glowing_spots'], atk: [['Tentacle Slap', 'melee', 1.1, 0, 'blue'], ['Drag Under', 'grab', 1.8, 12, 'gold'], ['Ink Cloud', 'debuff', 0, 14, 'none']] },
  fish: { arch: 'ambusher', build: ['a streamlined aquatic body', 'a heavy-jawed fish frame', 'a long, finned body'], parts: ['fins_sail', 'teeth_rows', 'lure', 'scales_armored', 'gills'], atk: [['Bite', 'melee', 1.2, 0, 'blue'], ['Breach Lunge', 'dash', 1.7, 9, 'red'], ['Thrash', 'aoe', 1.3, 8, 'red']] },
  swarm: { arch: 'swarm', build: ['a swarm of many small bodies moving as one', 'a cloud of tiny creatures', 'a living carpet of small bodies'], parts: ['individual_unit', 'formation_shapes', 'swarm_core'], atk: [['Nibble', 'melee', 0.6, 0, 'none'], ['Engulf', 'aoe', 1.2, 6, 'red'], ['Scatter', 'evade', 0, 10, 'none']] },
  mimic: { arch: 'ambusher', build: ['an object-shaped body that hides its true form', 'a disguised body pretending to be furniture', 'a hollow shell posing as an everyday object'], parts: ['tongue', 'teeth_ring', 'hinge_jaw', 'hidden_legs', 'fake_surface'], atk: [['Chomp', 'melee', 1.6, 0, 'red'], ['Tongue Lash', 'grab', 1.4, 6, 'gold'], ['Disguise', 'stealth', 0, 20, 'none']] },
  aberrant: { arch: 'ambusher', build: ['an asymmetric body with too many limbs', 'a shape that keeps rearranging itself', 'a tall, impossibly thin frame'], parts: ['extra_arms', 'mouth_clusters', 'eye_clusters', 'human_mask', 'joint_spikes'], atk: [['Grasp', 'melee', 1.2, 0, 'blue'], ['Unfold', 'aoe', 1.8, 12, 'red'], ['Mimic Voice', 'debuff', 0, 18, 'none']] },
  headless: { arch: 'tank', build: ['an armored humanoid body without a head', 'a headless rider frame', 'a tall, headless knightly build'], parts: ['head_carried', 'flame_neck', 'mount', 'lance', 'tattered_cape'], atk: [['Sweep', 'melee', 1.3, 0, 'blue'], ['Charge', 'dash', 1.8, 9, 'red'], ['Head Throw', 'ranged', 1.4, 10, 'red']] }
};

// ---------- biomes ----------
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

// ---------- behavior & AI ----------
const ADVICE = {
  Passive: 'Leaves you alone unless attacked.', Territorial: 'Attacks only if you come close to its home; back away to avoid a fight.',
  Swarm: 'Dangerous in numbers. Area attacks and chokepoints help.', Pack: 'Never alone. Kill the leader first and the rest may scatter.',
  Ambush: 'Waits in hiding. Perception skills and light sources reveal it.', Aggressive: 'Attacks on sight. Expect a fight.',
  Skittish: 'Flees when hurt. Snares or ranged attacks work best.', Guardian: 'Protects something nearby: a nest, a treasure, or a place.'
};
const AI = { Passive: 'passive_wander', Territorial: 'territorial_guard', Swarm: 'swarm_surround', Pack: 'pack_flank', Ambush: 'ambush_strike', Aggressive: 'aggressive_chase', Skittish: 'skittish_flee', Guardian: 'guardian_hold' };

// ---------- habitats (2–5 regions, rank band + climate + element) ----------
// Unique beings live in their lore lairs (see 02_Lore and 08_Bestiary/bosses_and_calamities.md).
const LAIRS = {
  'Ignivar, the Ember Throne': 'Iron Hold', 'Glacirra, the White Silence': 'Frostveil', 'Zephyros, the Endless Sky': 'Stormreach',
  'Terragon, the Mountain That Breathes': 'Dragon Spine', 'Umbrael, the Hollow Star': 'Sky Archipelago',
  'Solvoryn, the Dawnwyrm': 'Sky Archipelago', 'Nythraxa, the Duskwyrm': 'Sky Archipelago', 'Kaelumbra, the Twilight Arbiter': 'Sky Archipelago',
  'Garmrok, the World-Eater': 'Frostveil', 'Leviathan': 'Goldmere Coast', 'Titan of the First Age': 'Sky Archipelago',
  'Primordial Ooze': 'Great Labyrinth (Floors 91-120)', 'Hive Mother of the Abyss': 'The Maw', 'No-Life King': 'Sunscar',
  'Elemental Primarch': 'Root of the World', 'Blighted World Root': 'Sylvaran', 'Nameless Abomination': 'Great Labyrinth (Floors 91-120)',
  'Titan Remnant': 'Calamity Steppe', 'Aethernax, the Sky Devourer': 'Sky Archipelago', 'Dunewhale Thalassa': 'Dunewhale Drift',
  'Corrupted Summoned Hero': 'Nox Dominion', 'Taurgrim, the Maze King': 'Great Labyrinth (Floors 41-90)'
};
let CURRENT_FAMILY_KEY = null;
function familyRegions(fam) {
  const base = fam.regions ? REGIONS.filter(r => fam.regions.includes(r.name)) : REGIONS.filter(r => r.biomes.some(b => fam.biomes.includes(b)));
  return base.filter(r => !r.allowedFamilies || r.allowedFamilies.includes(CURRENT_FAMILY_KEY));
}
function inBand(r, rank) {
  const i = rankIdx(rank);
  return i >= RANKS.indexOf(r.rankMin) - 1 && i <= RANKS.indexOf(r.rankMax);
}
function bandDistance(r, rank) {
  const i = rankIdx(rank), lo = RANKS.indexOf(r.rankMin), hi = RANKS.indexOf(r.rankMax);
  return i < lo ? lo - i : i > hi ? i - hi : 0;
}
function chooseHabitats(sp, fam) {
  CURRENT_FAMILY_KEY = sp.familyKey;
  if (sp.lairRegionId) return [REGION_BY_ID[sp.lairRegionId]];
  if (LAIRS[sp.name]) return [REGION_BY_NAME[LAIRS[sp.name]]];
  const unique = sp.isUnique;
  const n = unique ? 1 : rankIdx(sp.rank) >= 6 ? 2 : sp.tier === 'core' ? 3 + Math.floor(rnd() * 3) : 2 + Math.floor(rnd() * 2);
  let pool = familyRegions(fam).filter(r => inBand(r, sp.rank));
  if (sp.regionalBiome) {
    const req = pool.filter(r => r.biomes.includes(sp.regionalBiome));
    if (req.length) pool = req;
  }
  if (pool.length < Math.min(n, 2)) {
    // relax: any in-band region sharing a biome, then nearest band among family regions
    const extra = REGIONS.filter(r => inBand(r, sp.rank) && (fam.biomes || []).some(b => r.biomes.includes(b)) && !pool.includes(r) && (!r.allowedFamilies || r.allowedFamilies.includes(sp.familyKey)));
    pool = pool.concat(extra);
  }
  if (pool.length < 1) pool = [...familyRegions(fam)].sort((a, b) => bandDistance(a, sp.rank) - bandDistance(b, sp.rank)).slice(0, n);
  const elBiomes = (EL[sp.element] || EL.None).biomes;
  const scored = pool.map(r => ({
    r,
    s: r.biomes.filter(b => (fam.biomes || []).includes(b)).length * 2 + (r.biomes.some(b => elBiomes.includes(b)) ? 3 : 0) + rnd() * 1.5
  })).sort((a, b) => b.s - a.s);
  return scored.slice(0, n).map(x => x.r);
}

// ---------- stats ----------
// Per-species stat profiles on top of the rig archetype (multipliers).
const STAT_PROFILES = {
  'Horned Rabbit': { hp: 0.6, def: 0.7, atk: 1.15, spd: 1.3 }   // the rookie killer: fast, fragile, hits hard
};
// Explicit spawn level ranges where the rank band is too wide (Ring 0 fun test: dangerous at Lv 1, trivial at Lv 10).
const LEVEL_RANGES = { 'Blue Slime': [1, 4], 'Horned Rabbit': [1, 5], 'Goblin': [2, 6] };
// Boss HP is a separate multiplier (stats stay comparable across species).
function bossHpMultFor(sp) { return sp.isTyrant ? 5 : rankLetter(sp.rank) === 'EX' ? 15 : sp.isUnique ? 6 : 1; }
function levelRangeFor(sp) {
  if (LEVEL_RANGES[sp.name]) return LEVEL_RANGES[sp.name];
  const v = rankVal(sp.rank);
  return [levelFor(rankStr(v - 1)), levelFor(rankStr(v + 1))];
}
function statsFor(sp) {
  const L = sp.level;
  const a = ARCH[RIGS[sp.rig].arch];
  const sizeF = Math.min(3.5, Math.max(0.6, 0.55 + Math.log2(sp.size + 1) * 0.45));
  const base = 10 + L * 4;
  const m = STAT_PROFILES[sp.name] || {};
  const k = key => m[key] || 1;
  return {
    hp: Math.round((60 + Math.pow(L, 1.5) * 9) * a.hp * sizeF * k('hp')),
    atk: Math.round(base * a.atk * k('atk')), def: Math.round(base * a.def * k('def')),
    matk: Math.round(base * a.matk * (sp.element === 'None' ? 0.7 : 1) * k('matk')), mdef: Math.round(base * a.mdef * k('mdef')),
    spd: Math.round(100 * a.spd * k('spd'))
  };
}

// ---------- attack library ----------
const ATTACKS = new Map();
function attackId(name, kind, power, cd, tele, element) {
  const id = 'atk_' + slug(name) + (element && element !== 'None' && kind === 'magic' ? '' : '');
  if (!ATTACKS.has(id)) ATTACKS.set(id, { id, name, kind, power, cooldownSec: cd, telegraph: tele, element: element || 'None' });
  return id;
}
// One signature attack per family, so species sharing a rig still fight differently.
const FAMILY_SIGNATURE = {
  slime: ['Acid Splash', 'ranged', 1.1, 6, 'blue'], goblinoid: ['Sand Toss', 'debuff', 0, 12, 'none'], kobold: ['Trip-Wire Trap', 'debuff', 0, 14, 'none'],
  beast: ['Rending Bite', 'melee', 1.3, 5, 'blue'], lycan: ['Moon Frenzy', 'buff', 0, 20, 'none'], insect: ['Silk Snare', 'ranged', 0.4, 10, 'blue'],
  killer_insect: ['Swarm Bite', 'aoe', 0.9, 6, 'red'], undead: ['Grave Grasp', 'grab', 1.2, 10, 'gold'], shadow: ['Shade Step Strike', 'dash', 1.4, 7, 'red'],
  orc_giant: ['War Cry', 'buff', 0, 18, 'none'], minotaur: ['Horn Charge', 'dash', 1.8, 9, 'red'], reptile: ['Tail Lash', 'aoe', 1.2, 7, 'blue'],
  draconic: ['Wing Buffet', 'aoe', 1.1, 9, 'blue'], construct: ['Rune Pulse', 'magic', 1.3, 10, 'red'], elemental: ['Elemental Burst', 'magic', 1.4, 9, 'red'],
  plant: ['Root Bind', 'grab', 1.0, 11, 'gold'], demon: ['Hellfire Brand', 'magic', 1.4, 10, 'red'], aquatic: ['Tidal Drag', 'grab', 1.3, 11, 'gold'],
  avian: ['Feather Volley', 'ranged', 1.0, 6, 'blue'], chimera: ['Many-Headed Bite', 'melee', 1.5, 7, 'red'], serpentfolk: ['Venom Coil', 'grab', 1.3, 11, 'gold'],
  centaur: ['Lance Charge', 'dash', 1.7, 8, 'red'], headless: ['Lantern Hurl', 'ranged', 1.3, 8, 'blue'], gremlin: ['Wrench Sabotage', 'debuff', 0, 14, 'none'],
  aberration: ['Mimic Lure', 'debuff', 0, 16, 'none'], yokai: ['Spirit Flame', 'magic', 1.2, 8, 'blue'], floorborn: ['Wall Ambush', 'dash', 1.4, 10, 'red'],
  vesperite: ['Moonglass Shard', 'ranged', 1.3, 6, 'blue'], sandborne: ['Sand Burrow', 'dash', 1.5, 10, 'red'], humanoid_enemy: ['Feint Strike', 'counter', 1.2, 8, 'blue'],
  familiar: ['Playful Nudge', 'melee', 0.5, 6, 'none']
};
function attacksFor(sp) {
  const ids = RIGS[sp.rig].atk.map(([n, k, p, cd, t]) => attackId(n, k, p, cd, t, 'None'));
  const sig = FAMILY_SIGNATURE[sp.familyKey];
  if (sig) ids.push(attackId(...sig, 'None'));
  const el = EL[sp.element] || EL.None;
  if (el.skill) ids.push(attackId(el.skill, 'magic', 1.5, 10, 'red', sp.element));
  return ids;
}

// ---------- items & loot ----------
const ITEMS = new Map();
function materialId(name, rank) {
  const id = 'itm_mat_' + slug(name);
  if (!ITEMS.has(id)) ITEMS.set(id, { id, name, category: 'material', rank, value: Math.round(4 * Math.pow(1.45, rankIdx(rank))) });
  return id;
}
function coreId(rank) {
  const L = rankLetter(rank);
  const id = 'itm_core_' + L.toLowerCase();
    // Cores are guaranteed ordinary-monster drops, so keep their guild buyback
    // modest and predictable. `value` is copper; each rank doubles the price.
    if (!ITEMS.has(id)) ITEMS.set(id, { id, name: `${L}-Rank Monster Core`, category: 'core', rank: L, value: 2 * Math.pow(2, rankIdx(rank)) });
  return id;
}
const LOOT = new Map();
function lootTableFor(famKey, fam, rank) {
  const L = rankLetter(rank);
  const id = `loot_${famKey}_${L.toLowerCase()}`;
  if (!LOOT.has(id)) {
    const entries = fam.drops.map((d, i) => ({ itemId: materialId(d, L), chance: [0.6, 0.3, 0.15][i] || 0.1, min: 1, max: i === 0 ? 3 : 1 }));
    entries.push({ itemId: coreId(L), chance: 1, min: 1, max: 1 });
    if (rankIdx(L) >= RANKS.indexOf('B')) entries.push({ itemId: materialId('Relic Shard', 'B'), chance: 0.001, min: 1, max: 1 }); // chase drop
    LOOT.set(id, { id, family: fam.name, rank: L, entries });
  }
  return id;
}

// ---------- description ----------
function describe(sp, fam, tone) {
  const rig = RIGS[sp.rig], menace = MEN[sp.menace], el = EL[sp.element] || EL.None;
  const dim = sp.rig === 'swarm' ? `each one is about ${sp.size} m long, but the swarm covers several meters` : `about ${sp.size} m ${LONG_RIGS.has(sp.rig) ? 'long' : 'tall'}`;
  const sizeWord = sp.size < 0.5 ? 'tiny' : sp.size < 1.2 ? 'small' : sp.size < 2.5 ? 'person-sized' : sp.size < 5 ? 'large' : sp.size < 15 ? 'huge' : 'colossal';
  const sig = /^(it |only |its )/i.test(sp.signature) ? cap(sp.signature) + '.' : pick(['Its most striking feature is ', 'Look for ', 'Guild sketches always show ', 'Survivors describe ']) + sp.signature + '.';
  const parts = [
    `The ${sp.name} is a ${sizeWord} creature with ${pick(rig.build)}, ${dim}.`,
    `Its ${fam.covering} ${/s$| and /.test(fam.covering) ? 'are' : 'is'} ${menace.tex}, colored in ${tone || el.tone}.`,
    sig,
    `It has ${pick(menace.eyes)}. ${ORN[rankLetter(sp.rank)]}`,
    el.aura ? `It ${pick(menace.motion)}, surrounded by ${el.aura}.` : `It ${pick(menace.motion)}. It has no visible aura; you hear its breathing before you see it.`
  ];
  if (sp.variantNote) parts.push(sp.variantNote);
  return parts.join(' ');
}

// ---------- species ----------
const species = [];
const usedNames = new Set();
function finalize(sp, fam, famKey) {
  if (usedNames.has(sp.name)) return null;
  usedNames.add(sp.name);
  sp.id = `mon_${slug(sp.name)}`;
  sp.familyKey = famKey; sp.family = fam.name; sp.type = fam.type; sp.genre = fam.genre; sp.trope = fam.trope;
  sp.menaceLabel = MEN[sp.menace].label;
  sp.isUnique = rankLetter(sp.rank) === 'EX' || sp.name.includes(',');
  sp.behavior = sp.behavior || pick(fam.behaviors);
  sp.aiPattern = AI[sp.behavior] + (sp.menace >= 4 ? '+stalker' : '');
  sp.level = levelFor(sp.rank);
  sp.stats = statsFor(sp);
  sp.levelRange = levelRangeFor(sp);
  sp.bossHpMult = bossHpMultFor(sp);
  sp.xp = Math.round((PROG.xp.monsterBase + Math.pow(sp.level, PROG.xp.monsterExponent) * PROG.xp.monsterScale) * (sp.isUnique ? PROG.xp.uniqueMultiplier : 1));
  sp.gold = Math.round(3 + Math.pow(sp.level, 1.4) * 1.5);
  sp.attackIds = attacksFor(sp);
  sp.rigId = `rig_${sp.rig}`; sp.animSetId = `anim_${sp.rig}`;
  const rig = RIGS[sp.rig];
  // Parts follow the species' name, signature and body plan (part_rules.js), not a random draw from the rig.
  // The old draw is still consumed (1 + nParts calls) so the seeded stream, and so every other field, stays stable.
  const nParts = Math.min(rig.parts.length, 2 + Math.floor(rnd() * 3));
  for (let i = 0; i < nParts; i++) rnd();
  const parts = chooseParts({ id: sp.id, name: sp.name, coreName: sp.coreName || sp.name, signature: sp.signature, familyKey: famKey, type: fam.type, rig: sp.rig, rigPool: rig.parts, count: nParts });
  const el = EL[sp.element] || EL.None;
  sp.weakness = el.weak;
  // Ring 0/1 species are pinned to the starter regions.
  if (RING0.includes(sp.name) || RING1.includes(sp.name)) {
    sp.habitatRegions = [REGION_BY_NAME['Aldmere'], REGION_BY_NAME['Whisperwood']];
    sp.ring = RING0.includes(sp.name) ? 0 : 1;
  } else {
    sp.habitatRegions = chooseHabitats(sp, fam);
    sp.ring = Math.max(2, Math.min(...sp.habitatRegions.map(r => r.ring)));
    if (sp.isTyrant) sp.ring = Math.max(1, sp.habitatRegions[0].ring); // a Tyrant ships with its region
    // Variants ship at least one ring after their base species, so early rings carry core designs only.
    if (sp.tier === 'variant') {
      const base = species.find(x => x.id === sp.baseSpeciesId);
      if (base) sp.ring = Math.max(sp.ring, base.ring + 1);
    }
  }
  sp.habitats = sp.habitatRegions.map(r => r.id);
  sp.lootTableId = lootTableFor(famKey, fam, sp.rank);
  sp.fieldNote = `Weak to ${el.weak}. ${ADVICE[sp.behavior]}`;
  const colour = paletteFor(sp, famKey, el); // family colour + element accent (palettes.js, design review C2)
  sp.designRecipe = { rigId: sp.rigId, baseMesh: `${sp.rig}_base`, parts, material: fam.material, palette: colour.palette, menaceStyle: MEN[sp.menace].shape, rankOrnament: rankLetter(sp.rank), vfx: el.vfx, animSetId: sp.animSetId, scale: sp.size };
  sp.look = describe(sp, fam, colour.tone);
  species.push(sp);
  return sp;
}

const cores = [];
for (const [famKey, fam] of Object.entries(FAMILIES)) {
  for (const line of fam.cores) {
    const [name, rank, menace, element, size, signature, rigOverride] = line.split('|');
    const sp = finalize({ name, rank, menace: +menace, element, size: +size, signature, rig: rigOverride || fam.rig, tier: 'core', variantKind: '', baseSpeciesId: '' }, fam, famKey);
    if (sp) cores.push(sp);
  }
}

// Regional Tyrants are added last so the seeded sequence for every other species stays stable.
function addTyrants() {
  for (const [famKey, line, regionId] of TYRANTS) {
    if (!REGION_BY_ID[regionId]) throw new Error('Tyrant region not found: ' + regionId);
    const [name, rank, menace, element, size, signature, rigOverride] = line.split('|');
    const fam = FAMILIES[famKey];
    const sp = finalize({ name, rank, menace: +menace, element, size: +size, signature, rig: rigOverride || fam.rig, tier: 'core', variantKind: '', baseSpeciesId: '', isTyrant: true, lairRegionId: regionId }, fam, famKey);
    if (!sp) throw new Error('Duplicate Tyrant name: ' + name);
  }
}

const HUMANOID_TYPES = new Set(['Humanoid', 'Beastman', 'Serpentfolk', 'Beastfolk', 'Lunar Raider']);
const VARIANT_TYPES = ['elemental', 'elemental', 'elemental', 'elder', 'elder', 'corrupted', 'corrupted', 'ancient', 'spirit', 'regional', 'regional'];
const stripElementWord = n => { const w = n.split(' '); return w.length > 1 && ELEMENT_WORDS.has(w[0]) ? w.slice(1).join(' ') : n; };
function makeVariant(core, kind) {
  const fam = FAMILIES[core.familyKey];
  const v = { name: core.name, rank: core.rank, menace: core.menace, element: core.element, size: core.size, signature: core.signature, rig: core.rig, tier: 'variant', variantKind: kind, baseSpeciesId: core.id, coreName: core.name };
  const rv = rankVal(core.rank);
  if (kind === 'elemental') {
    v.element = pick(SHIFT_ELEMENTS.filter(e => e !== core.element));
    v.name = `${pick(EL[v.element].pre)} ${stripElementWord(core.name)}`;
    v.rank = rankStr(rv + 1);
    v.variantNote = `This ${v.element}-attuned variant carries one extra elemental feature, like ${pick(['crystal spikes', 'glowing vein-lines', 'a crest of elemental energy', 'element-scarred hide'])}, in its element's colors.`;
  } else if (kind === 'elder') {
    v.name = HUMANOID_TYPES.has(fam.type) ? pick([`Elite ${core.name}`, `${core.name} Veteran`]) : pick([`Elder ${core.name}`, `Greater ${core.name}`]);
    v.rank = rankStr(rv + 3); v.size = +(core.size * 1.6).toFixed(1);
    v.variantNote = 'It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.';
  } else if (kind === 'corrupted') {
    v.name = `Vesper-Touched ${core.name}`;
    v.rank = rankStr(rv + 2); v.menace = Math.min(5, core.menace + 1); v.element = core.element === 'None' ? 'Blood' : core.element;
    v.variantNote = 'Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.';
  } else if (kind === 'ancient') {
    v.name = `Ancient ${core.name}`;
    v.rank = rankStr(rv + 3); v.size = +(core.size * 1.5).toFixed(1);
    v.variantNote = 'Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.';
  } else if (kind === 'spirit') {
    v.name = `Phantom ${core.name}`;
    v.rank = rankStr(rv + 1); v.menace = Math.min(5, core.menace + 1); v.element = 'Light';
    v.variantNote = 'Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.';
  } else if (kind === 'regional') {
    const biome = pick(fam.biomes || ['ruins']);
    v.name = `${BIOME_WORD[biome]} ${stripElementWord(core.name)}`;
    v.rank = rankStr(rv + 1); v.element = BIOME_ELEMENT[biome] || core.element; v.regionalBiome = biome;
    v.variantNote = `Adapted to ${biome} lands, it has ${BIOME_LOOK[biome]}.`;
  }
  return finalize(v, fam, core.familyKey);
}
const eligible = cores.filter(c => !c.isUnique);
for (let round = 0; species.length < MIN_SPECIES && round < 6; round++) {
  for (const c of eligible) {
    if (species.length >= MIN_SPECIES && round > 0) break;
    for (let t = 0; t < 4; t++) if (makeVariant(c, pick(VARIANT_TYPES))) break;
  }
}
addTyrants();

// ---------- population ----------
const TIERS = [
  { n: 'Runt', r: -2, s: 0.7, d: 'smaller and scrappier than usual', color: true },
  { n: 'Juvenile', r: -1, s: 0.85, d: 'young, with brighter colors and unworn features', color: true },
  { n: '', r: 0, s: 1.0, d: '', color: true },
  { n: 'Scarred', r: 1, s: 1.1, d: 'covered in old battle scars', color: true },
  { n: 'Alpha', r: 2, s: 1.25, d: 'larger and scarred, and others of its kind follow it', color: true },
  { n: 'Albino', r: 1, s: 1.0, d: 'a rare pale form with white skin or fur and red eyes', color: false },
  { n: 'Elderborn', r: 3, s: 1.35, d: 'old and wise, with greying features and a cautious hunting style', color: true }
];
const population = [];
const popNames = new Set();
for (const sp of species) {
  const fam = FAMILIES[sp.familyKey];
  if (sp.isUnique) {
    const r = sp.habitatRegions[0];
    population.push({ id: `pop_${String(population.length + 1).padStart(5, '0')}`, name: sp.name, speciesId: sp.id, regionId: r.id, region: r.name, tier: 'Unique', rank: sp.rank, level: sp.level, size: sp.size, ring: Math.max(sp.ring, r.ring), look: 'Unique being; see the species entry.', spawn: 'Story' });
    continue;
  }
  const combos = [];
  for (const r of sp.habitatRegions) for (const t of TIERS) combos.push([r, t]);
  for (let i = combos.length - 1; i > 0; i--) { const j = Math.floor(rnd() * (i + 1)); [combos[i], combos[j]] = [combos[j], combos[i]]; }
  let made = 0;
  for (const [r, t] of combos) {
    if (made >= POP_PER_SPECIES) break;
    const name = `${r.name} ${sp.name}${t.n ? ' ' + t.n : ''}`;
    if (popNames.has(name)) continue;
    popNames.add(name);
    const biome = r.biomes.find(b => (fam.biomes || []).includes(b)) || r.biomes[0];
    const coloring = BIOME_LOOK[biome] || 'local coloring';
    let look;
    if (!t.n) look = `A typical adult ${sp.name} of this region, with ${coloring}.`;
    else if (!t.color) look = `Like a typical ${sp.name}, but ${t.d}.`;
    else look = `Like a typical ${sp.name}, but ${t.d}, with ${coloring}.`;
    const rank = rankStr(rankVal(sp.rank) + t.r);
    population.push({
      id: `pop_${String(population.length + 1).padStart(5, '0')}`, name, speciesId: sp.id, regionId: r.id, region: r.name,
      tier: t.n || 'Adult', rank, level: levelFor(rank), size: +(sp.size * t.s).toFixed(2), ring: Math.max(sp.ring, r.ring),
      look, spawn: sp.menace >= 4 || sp.type === 'Undead' ? 'Night' : sp.menace === 1 ? 'Day' : 'Day & Night'
    });
    made++;
  }
}

// ---------- siege waves (Systems → Regional Siege & Liberation) ----------
// One wave template per besieged region: three waves from the Tyrant's faction living in that region,
// the last with a lieutenant. Escalation (each week the Tyrant lives) scales counts, capped.
const SIEGE = { maxEscalation: 5, countGrowthPerStep: 0.2, eliteChancePerStep: 0.08, baseCounts: [6, 8, 10], targetMinutes: [5, 8] };
const siegeWaves = [];
for (const r of REGIONS.filter(x => !x.noSiege)) {
  // Prefer species that already ship by this region's ring; fall back to all residents if too few.
  const residents = species.filter(s => !s.isUnique && s.habitats.includes(r.id));
  const shipped = residents.filter(s => s.ring <= r.ring);
  const inRegion = (shipped.length >= 3 ? shipped : residents).sort((a, b) => rankVal(a.rank) - rankVal(b.rank) || a.id.localeCompare(b.id));
  const factionPool = inRegion.filter(s => s.familyKey === r.siegeFaction);
  const mixed = factionPool.length < 3;
  const pool = mixed ? factionPool.concat(inRegion.filter(s => s.familyKey !== r.siegeFaction)) : factionPool;
  if (pool.length === 0) throw new Error('No siege species live in ' + r.id);
  const third = Math.max(1, Math.ceil(pool.length / 3));
  const tiers = [pool.slice(0, third), pool.slice(third, 2 * third), pool.slice(2 * third)].map((t, i, all) => t.length ? t : (all[i - 1] && all[i - 1].length ? all[i - 1] : pool));
  const lieutenant = [...pool].reverse().find(s => s.variantKind === 'elder' || s.variantKind === 'ancient') || pool[pool.length - 1];
  const waves = tiers.map((tier, i) => {
    // Strongest kind last; a lone elite kind is padded with fodder so elites stay the minority.
    let kinds = tier.slice(0, 2);
    if (kinds.length === 1 && pool[0].id !== kinds[0].id) kinds = [pool[0], kinds[0]];
    const total = SIEGE.baseCounts[i];
    const units = kinds.map((s, k) => ({ speciesId: s.id, count: kinds.length === 1 ? total : k === 0 ? Math.ceil(total * 0.6) : Math.floor(total * 0.4) }));
    return { wave: i + 1, units, ...(i === 2 ? { lieutenantSpeciesId: lieutenant.id } : {}) };
  });
  siegeWaves.push({
    id: 'siege_' + r.id.replace(/^reg_/, ''), regionId: r.id, faction: r.siegeFaction, factionMixed: mixed,
    rankMin: r.rankMin, rankMax: r.rankMax, tyrantSpeciesId: r.tyrantSpeciesId, waves,
    escalation: { maxStep: SIEGE.maxEscalation, countGrowthPerStep: SIEGE.countGrowthPerStep, eliteChancePerStep: SIEGE.eliteChancePerStep },
    targetMinutes: SIEGE.targetMinutes
  });
}

// ---------- write ----------
const MON = path.join(DATA, 'Monsters'), ITM = path.join(DATA, 'Items');
fs.mkdirSync(MON, { recursive: true }); fs.mkdirSync(ITM, { recursive: true });
const csvEsc = v => `"${String(v ?? '').replace(/"/g, '""')}"`;
function writeCsv(file, rows, cols) {
  fs.writeFileSync(file, [cols.join(',')].concat(rows.map(r => cols.map(c => csvEsc(typeof r[c] === 'object' ? JSON.stringify(r[c]) : r[c])).join(','))).join('\n'), 'utf8');
}
const SPECIES_FIELDS = ['id', 'name', 'familyKey', 'family', 'type', 'genre', 'tier', 'variantKind', 'baseSpeciesId', 'rank', 'level', 'levelRange', 'menace', 'menaceLabel', 'element', 'weakness', 'sizeMeters', 'rigId', 'animSetId', 'behavior', 'aiPattern', 'stats', 'bossHpMult', 'xp', 'gold', 'attackIds', 'isUnique', 'isTyrant', 'ring', 'habitats', 'lootTableId', 'signature', 'look', 'fieldNote', 'trope', 'designRecipe'];
const spOut = species.map(s => { const o = {}; for (const f of SPECIES_FIELDS) o[f] = f === 'sizeMeters' ? s.size : f === 'isTyrant' ? !!s.isTyrant : s[f]; return o; });
fs.writeFileSync(path.join(MON, 'species.json'), JSON.stringify(spOut, null, 1), 'utf8');
writeCsv(path.join(MON, 'species.csv'), spOut, SPECIES_FIELDS);
fs.writeFileSync(path.join(MON, 'population.json'), JSON.stringify(population, null, 1), 'utf8');
writeCsv(path.join(MON, 'population.csv'), population, ['id', 'name', 'speciesId', 'regionId', 'region', 'tier', 'rank', 'level', 'size', 'ring', 'look', 'spawn']);
fs.writeFileSync(path.join(MON, 'attacks.json'), JSON.stringify([...ATTACKS.values()], null, 1), 'utf8');
fs.writeFileSync(path.join(MON, 'loot_tables.json'), JSON.stringify([...LOOT.values()], null, 1), 'utf8');
fs.writeFileSync(path.join(ITM, 'materials.json'), JSON.stringify([...ITEMS.values()], null, 1), 'utf8');
fs.writeFileSync(path.join(DATA, 'World', 'siege_waves.json'), JSON.stringify(siegeWaves, null, 1), 'utf8');

// Viewer (filterable HTML with embedded data)
const viewerData = {
  regions: Object.fromEntries(REGIONS.map(r => [r.id, r.name])),
  species: spOut.map(s => ({ i: s.id, n: s.name, f: s.family, t: s.type, g: s.genre, k: s.tier, v: s.variantKind, r: s.rank, l: s.level, m: s.menaceLabel, e: s.element, w: s.weakness, z: s.sizeMeters, b: s.rigId, h: s.habitats, ring: s.ring, st: s.stats, a: s.attackIds, ai: s.aiPattern, x: s.look, fn: s.fieldNote, d: s.designRecipe, u: s.isUnique })),
  population: population.map(p => [p.id, p.name, p.speciesId, p.regionId, p.tier, p.rank, p.level, p.ring, p.look, p.spawn]),
  attacks: Object.fromEntries([...ATTACKS.values()].map(a => [a.id, a.name]))
};
const tpl = fs.readFileSync(path.join(__dirname, 'viewer_template.html'), 'utf8');
fs.writeFileSync(path.join(ROOT, '08_Bestiary', 'bestiary_viewer.html'), tpl.replace('/*__DATA__*/null', JSON.stringify(viewerData)), 'utf8');

const ringCount = {}; for (const s of species) ringCount[s.ring] = (ringCount[s.ring] || 0) + 1;
const habAvg = (species.reduce((a, s) => a + s.habitats.length, 0) / species.length).toFixed(2);
const tyrantCount = species.filter(s => s.isTyrant).length;
console.log(`Species: ${species.length} (core ${cores.length}, variants ${species.length - cores.length - tyrantCount}, Tyrants ${tyrantCount}) · avg habitats ${habAvg}`);
console.log(`Population: ${population.length} · Attacks: ${ATTACKS.size} · Loot tables: ${LOOT.size} · Materials: ${ITEMS.size}`);
console.log('Species per ring:', ringCount);
console.log(`Siege wave sets: ${siegeWaves.length} (${siegeWaves.filter(w => w.factionMixed).length} with mixed factions)`);
