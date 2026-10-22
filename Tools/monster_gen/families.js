// Core species data. Format per core: "Name|Rank|Menace|Element|Size(m)|Signature feature|rigOverride?"
// Family defaults: rig, type, genre, biomes (or regions whitelist), covering, material, drops, behaviors, trope.
module.exports = {
  slime: {
    name: 'Slimes', type: 'Ooze', rig: 'blob', genre: 'Classic Fantasy',
    biomes: ['forest', 'swamp', 'cave', 'plains', 'underworld', 'ruins'],
    covering: 'gel', material: 'translucent_gel_sss', drops: ['Slime Jelly', 'Gel Core'],
    behaviors: ['Passive', 'Territorial', 'Swarm'],
    trope: 'The cute first enemy (Dragon Quest) and the evolving hero (Tensura)',
    cores: [
      'Blue Slime|F-|1|Water|0.4|a teardrop body with a glossy highlight and two dot eyes',
      'Green Slime|F|1|Nature|0.4|fallen leaves suspended inside its jelly',
      'Red Slime|E|2|Fire|0.5|a faint ember core pulsing like a heartbeat',
      'Poison Slime|E|3|Poison|0.6|purple bubbles that hiss when they pop',
      'Bubble Slime|E|1|Water|0.3|a cluster of soap-bright spheres that split apart when hit',
      'Metal Slime|D|1|Earth|0.3|mirror-chrome skin that reflects the world around it',
      'Mimic Slime|D|4|None|1.0|a surface that ripples into the shape of whatever it last ate',
      'Frost Slime|D|2|Ice|0.5|frost crystals growing from its crown',
      'Cube Slime|D|2|Earth|0.8|a perfectly cubic body with swallowed debris visible inside',
      'King Slime|C|2|Water|3.0|a crown made of smaller slimes fused together',
      'Ember Ooze|C|3|Fire|1.5|molten trails that harden into glass behind it',
      'Storm Slime|B|2|Lightning|1.2|a storm-cloud interior that flashes with tiny lightning',
      'Abyss Slime|S|5|Void|4.0|starless black jelly that swallows all light',
      'Prismatic Slime Sovereign|SSS|2|Light|8.0|a crown of rainbow light refracted through its whole body',
      'Primordial Ooze|EX|5|Void|40|an ocean-sized mass that shows the faces of everything it has eaten'
    ]
  },
  goblinoid: {
    name: 'Goblinoids', type: 'Humanoid', rig: 'small_biped', genre: 'Dark Fantasy',
    biomes: ['forest', 'cave', 'plains', 'mountain', 'ruins'],
    covering: 'skin', material: 'rough_skin_leather', drops: ['Goblin Ear', 'Crude Blade', 'Stolen Trinket'],
    behaviors: ['Pack', 'Ambush', 'Aggressive'],
    trope: 'Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution',
    cores: [
      'Goblin|F-|3|None|1.0|a grin of needle teeth under a stolen tin helmet',
      'Goblin Archer|F+|3|None|1.0|a crooked bow strung with gut and a quiver of bone-tipped arrows',
      'Goblin Trapper|E|3|None|1.0|snares and rusted bells hanging from its belt',
      'Goblin Shaman|E|3|Fire|1.0|a skull headdress and a staff hung with smoking charms',
      'Hobgoblin|E+|3|None|1.8|a broad scarred chest and a helmet two sizes too small|medium_biped',
      'Goblin Bomber|D|3|Fire|1.0|a barrel of black powder strapped to its back and a lit fuse in its teeth',
      'Goblin Wolf Rider|D|3|None|1.0|a bone saddle on a snarling war-wolf mount',
      'Goblin Champion|D+|3|None|2.0|a trophy cloak stitched from adventurers\' capes|medium_biped',
      'Goblin General|C|3|None|2.2|a war banner and a horn carved from an ogre\'s tusk|medium_biped',
      'Goblin King|B|3|Earth|2.8|throne-backed armor and a crown of hammered coins|large_biped',
      'Kijin Warrior|A|3|Fire|2.4|twin horns, a disciplined stance and a lacquered blade|medium_biped',
      'Oni Warlord|S|3|Fire|4.5|a towering horned silhouette carrying an iron club wrapped in prayer chains|large_biped'
    ]
  },
  kobold: {
    name: 'Kobolds', type: 'Humanoid', rig: 'small_biped', genre: 'Dungeon Crawl',
    biomes: ['cave', 'mountain', 'underworld', 'ruins'],
    covering: 'mangy fur', material: 'fur_short', drops: ['Kobold Fang', 'Scrap Metal', 'Candle Stub'],
    behaviors: ['Pack', 'Skittish', 'Ambush'],
    trope: 'Dog-headed first-floor monsters (DanMachi), trap-builders (classic tabletop)',
    cores: [
      'Kobold Scavenger|F|3|None|0.9|a dog-like head with a chipped snout and a sack of stolen tools',
      'Kobold Miner|E|2|Earth|0.9|a candle-helmet and a pick worn smooth from use',
      'Kobold Sneak|E|3|Dark|0.8|soot-blackened fur for hiding in tunnels',
      'Kobold Shaman|D|3|Fire|0.9|tin-can wind chimes and singed whiskers',
      'Kobold Trapmaster|D|3|None|1.0|a harness of gears, springs and tripwires',
      'Kobold Packleader|D+|3|None|1.2|a collar of teeth from rival packs',
      'Kobold Warlord|C|3|Earth|1.4|scavenged knight armor hammered to fit',
      'Kobold Tunnel-Queen|B|3|Earth|1.6|a bloated, jewel-encrusted body carried on a litter'
    ]
  },
  beast: {
    name: 'Beasts', type: 'Beast', rig: 'quad_large', genre: 'Classic Fantasy',
    biomes: ['plains', 'forest', 'mountain', 'tundra', 'steppe'],
    covering: 'coat', material: 'fur_groom', drops: ['Pelt', 'Fang', 'Prime Meat'],
    behaviors: ['Pack', 'Territorial', 'Skittish'],
    trope: 'The horned rabbit "rookie killer" and wolf packs of every isekai starter forest',
    cores: [
      'Horned Rabbit|F-|2|None|0.4|a single spiral horn and oversized hind feet|quad_small',
      'Forest Wolf|F+|2|None|1.2|a grey-green coat that blends with ferns',
      'Wild Boar|E|2|Earth|1.4|curved tusks and a ridge of bristles like iron wire',
      'Bandit Bear|E+|2|None|2.2|a dark mask-like band across its eyes',
      'Dire Wolf|D|3|None|2.0|a horse-sized frame and a jaw full of jagged fangs',
      'Owlbear|D+|3|None|2.6|an owl\'s feathered face on a bear\'s muscled body',
      'Thunderhorn Elk|C|2|Lightning|2.8|branching antlers that crackle in storms',
      'Frost Fenrir Pup|B|2|Ice|1.5|frosted fur and breath that freezes the air',
      'Behemoth Calf|B+|2|Earth|4.0|a stone-plated back and stump-like legs',
      'Sabretooth King|A|3|Ice|3.2|two sabre fangs as long as swords',
      'Silver Fenrir|S|2|Light|6.0|silver fur that glows like moonlight',
      'Behemoth Ascendant|SSS|3|Earth|40|a back that carries the ruins of a fortress it once trampled',
      'Jackalope|E|1|None|0.4|tiny antlers on a fluffy rabbit|quad_small',
      'Moon Hare|D|1|Light|0.5|white fur that glows under the full moon|quad_small',
      'Garmrok, the World-Eater|EX|4|Void|120|a wolf so vast its broken chains drag across the sky'
    ]
  },
  lycan: {
    name: 'Lycanthropes', type: 'Cursed Beast', rig: 'medium_biped', genre: 'Gothic Horror',
    biomes: ['forest', 'mountain', 'swamp'],
    covering: 'fur', material: 'fur_rough', drops: ['Cursed Fur', 'Silver-Bane Claw'],
    behaviors: ['Aggressive', 'Ambush'],
    trope: 'Moon-cursed transformation horror',
    cores: [
      'Werewolf|D|4|Dark|2.2|a wolf\'s head on a twisted human body, torn clothing still clinging',
      'Wererat|D-|4|Poison|1.5|a hunched rodent body with human hands',
      'Werebear|C|3|Earth|3.0|tribal tattoos showing through thick bear fur',
      'Moon Beast|C+|4|Dark|2.8|fur that ripples like oil under moonlight',
      'Blood Vesper Alpha|B|4|Blood|3.2|red-veined fur that only appears under the red moon',
      'Skinchanger|B+|5|Dark|2.4|half its body stuck mid-transformation, forever',
      'Fenrir-Blooded Lord|A|3|Ice|3.6|a crown of frost spikes growing from its mane'
    ]
  },
  insect: {
    name: 'Insects & Arachnids', type: 'Insectoid', rig: 'hexapod', genre: 'Classic Fantasy',
    biomes: ['forest', 'plains', 'cave', 'jungle', 'desert'],
    covering: 'chitin', material: 'chitin_gloss', drops: ['Carapace Shard', 'Silk', 'Venom Sac'],
    behaviors: ['Swarm', 'Ambush', 'Territorial'],
    trope: 'Giant insects as low-floor threats; the arachne as an intelligent monster race',
    cores: [
      'Giant Ant|F|2|Earth|0.6|red-brown chitin and mandibles like pliers',
      'Cave Spider|F+|3|Poison|0.7|a pale body that glows faintly in the dark|octopod',
      'Firefly Swarm|E|1|Light|0.05|hundreds of soft lantern lights moving together|swarm',
      'Armor Beetle|E+|2|Earth|1.2|a shell like polished bronze',
      'Venom Spider|D|3|Poison|1.4|green-striped legs and dripping fangs|octopod',
      'Blade Mantis|D+|3|Wind|2.0|forearms shaped like curved scythes',
      'Queen Ant|C|3|Earth|3.5|a swollen abdomen pulsing with eggs',
      'Death Mantis|B|4|Dark|3.0|black chitin and a skull-like head',
      'Arachne|B+|3|Dark|3.0|a woman\'s upper body rising from a spider\'s|octopod',
      'Scarab Swarm|A|3|Dark|0.05|golden beetles that flow like spilled coins|swarm',
      'Arachne Matriarch|S|4|Dark|8.0|a crown of silk and eight eyes like jewels|octopod',
      'Hive Mother of the Abyss|EX|5|Void|60|a living hive-mountain that sings|aberrant'
    ]
  },
  killer_insect: {
    name: 'Killer Insects', type: 'Insectoid', rig: 'hexapod', genre: 'Dungeon Crawl',
    biomes: ['cave', 'underworld', 'ruins', 'jungle'],
    covering: 'chitin', material: 'chitin_matte', drops: ['Killer Mandible', 'Stinger'],
    behaviors: ['Swarm', 'Aggressive'],
    trope: 'The rookie-killing ants of the early dungeon floors (DanMachi)',
    cores: [
      'Killer Ant|E|4|None|1.0|a pale soldier ant with a jaw that never stops working',
      'Needle Wasp|E+|3|Poison|0.3|a stinger as long as its body|flyer_small',
      'Hornet Lancer|D|3|Poison|1.2|a lance-like stinger and humming armored wings|flyer_small',
      'Tunnel Centipede|D+|4|Poison|6.0|a hundred legs and a head like a split mask|serpent',
      'Queen\'s Guard|C|3|Earth|2.0|a shield-shaped head plate',
      'Bone Weevil|C|4|Dark|1.0|a shell made from the bones it eats',
      'Hive Tyrant|A|4|Poison|7.0|a winged queen-killer with a crown of stingers|wyvern'
    ]
  },
  undead: {
    name: 'Undead', type: 'Undead', rig: 'medium_biped', genre: 'Gothic Horror',
    biomes: ['ruins', 'swamp', 'city', 'demon', 'desert'],
    covering: 'flesh and bone', material: 'rot_bone', drops: ['Bone Dust', 'Grave Cloth', 'Soul Ember'],
    behaviors: ['Aggressive', 'Guardian', 'Ambush'],
    trope: 'Graveyard night threats; the lich and its phylactery; the vampire noble',
    cores: [
      'Zombie|F|3|Dark|1.7|grey skin, burial clothes and a slack jaw',
      'Skeleton|F+|3|Dark|1.7|yellowed bones held together by blue grave-light',
      'Hollow Mourner|F|4|Dark|1.7|a weeping figure that moves only when you look away',
      'Bone Crawler|F|4|Dark|1.4|a skeleton reassembled wrong, crawling on its hands|aberrant',
      'Lantern Leech|F|4|Water|0.6|a glow on its back like a lost traveler\'s lantern|serpent',
      'Ghost|E|3|Dark|1.7|a translucent figure frozen in its last moment|floating',
      'Ghoul|E+|4|Dark|1.6|grey, hairless skin and long black nails',
      'Wraith|D|4|Dark|2.0|a hooded shape of smoke with cold blue eyes|floating',
      'Skeleton Knight|D+|3|Dark|2.0|rusted plate armor and a shield it still keeps polished',
      'Banshee|C|4|Wind|1.8|long white hair and a mouth that opens far too wide|floating',
      'Death Knight|B|3|Dark|2.4|black plate, a cloak of ash and a sword of cold fire',
      'Vampire|B+|3|Blood|1.8|aristocratic clothes and eyes like garnets',
      'Lich|A|4|Ice|2.2|a crowned skull with a phylactery chained to its chest|floating',
      'Vampire Lord|S|3|Blood|2.2|a cape that dissolves into bats',
      'Bone Dragon|S|4|Dark|20|a dragon skeleton held together by green fire|dragon',
      'Lich Emperor|SSS|4|Ice|3.0|a crown of frozen souls and a phylactery the size of a castle tower|floating',
      'No-Life King|EX|4|Dark|3.0|a king of bone on a throne of a thousand skulls'
    ]
  },
  shadow: {
    name: 'Shadows', type: 'Spirit', rig: 'floating', genre: 'Dungeon Crawl',
    biomes: ['cave', 'underworld', 'ruins'],
    covering: 'smoke-like body', material: 'shadow_smoke', drops: ['Shade Essence', 'Night Shard'],
    behaviors: ['Ambush', 'Aggressive'],
    trope: 'Dungeon-born shadow warriors (DanMachi War Shadows)',
    cores: [
      'Shadow Wisp|E|3|Dark|0.4|a flickering smudge of darkness',
      'War Shadow|D|4|Dark|2.0|a humanoid silhouette with blades for hands|medium_biped',
      'Shade Hound|D+|4|Dark|1.4|a dog made of smoke with ember eyes|quad_large',
      'Shade Knight|C|3|Dark|2.3|armor with nothing but darkness inside|medium_biped',
      'Mirror Shade|B|5|Dark|1.8|your own silhouette, a heartbeat behind you|medium_biped',
      'Umbral Reaper|A|4|Dark|3.0|a scythe of night and a hood with no face',
      'Night Leviathan|S|4|Void|30|a shadow whale that swims through walls|fish'
    ]
  },
  orc_giant: {
    name: 'Orcs, Ogres & Giants', type: 'Giant', rig: 'large_biped', genre: 'Classic Fantasy',
    biomes: ['mountain', 'plains', 'tundra', 'volcanic', 'steppe'],
    covering: 'hide', material: 'thick_skin', drops: ['Tusk', 'Giant\'s Hide', 'Crude Iron'],
    behaviors: ['Aggressive', 'Territorial', 'Pack'],
    trope: 'Orc warbands and the Orc Disaster that devours its way to power (Tensura)',
    cores: [
      'Orc Grunt|E|3|None|2.0|tusks, war paint and a dented iron axe|medium_biped',
      'Orc Warrior|D|3|None|2.1|a fur mantle and rust-stained chain mail|medium_biped',
      'Orc Berserker|D+|3|Fire|2.2|blood-red war paint and broken chains on its wrists|medium_biped',
      'Ogre|C|3|Earth|3.5|a sagging belly, a tree-trunk club and a toll sack',
      'Troll|C+|3|Nature|3.2|moss-covered skin that knits itself back together',
      'Orc Lord|B|3|None|2.6|a horned helm and a cloak of wolf pelts|medium_biped',
      'Hill Giant|B+|2|Earth|7.0|a boulder slung over its shoulder like a sack',
      'Cyclops|B+|3|Earth|6.0|a single huge eye and a hammer made from a millstone',
      'Frost Giant|A|3|Ice|9.0|a beard of icicles and armor of glacier ice',
      'Fire Giant|A+|3|Fire|9.0|skin like cooling lava and a forge-hammer',
      'Orc Disaster|S|3|Dark|4.0|a body bloated with devoured power and a crown of bones',
      'Primeval Titan-Kin|SSS|3|Earth|40|a body of living bedrock wearing fragments of Titan armor',
      'Titan Remnant|EX|2|Earth|300|a mountain with a slow heartbeat'
    ]
  },
  minotaur: {
    name: 'Minotaurs & Beastmen', type: 'Beastman', rig: 'large_biped', genre: 'Labyrinth Myth',
    biomes: ['ruins', 'cave', 'underworld', 'mountain'],
    covering: 'hide', material: 'short_hide', drops: ['Horn', 'Labyrinth Bronze'],
    behaviors: ['Territorial', 'Aggressive'],
    trope: 'The minotaur that appears where it shouldn\'t (DanMachi), Greek labyrinth myth',
    cores: [
      'Calf Minotaur|D|3|None|2.0|stubby horns and a bronze nose ring',
      'Satyr Reveler|D|2|Nature|1.7|goat legs and a panpipe that makes you dance|medium_biped',
      'Gnoll Raider|D|3|None|2.0|a hyena head and a laugh that carries for miles|medium_biped',
      'Minotaur|C|3|Earth|3.2|a bull\'s head, a massive labrys axe and snorting breath',
      'Labyrinth Minotaur|B|3|Earth|4.0|horns carved with maze runes',
      'Taurgrim, the Maze King|S|3|Earth|6.0|a crown fused to its horns and a labrys of starmetal'
    ]
  },
  reptile: {
    name: 'Reptiles', type: 'Reptile', rig: 'quad_large', genre: 'Classic Fantasy',
    biomes: ['swamp', 'desert', 'coast', 'jungle'],
    covering: 'scales', material: 'scale_matte', drops: ['Scale', 'Reptile Eye', 'Tail Meat'],
    behaviors: ['Territorial', 'Ambush', 'Passive'],
    trope: 'Lizardmen as a proud people; the petrifying basilisk',
    cores: [
      'Swamp Toad|F|1|Water|0.5|a wide smile and bulging golden eyes|quad_small',
      'Giant Lizard|E|2|Earth|2.0|sun-baked scales and a frilled neck',
      'Lizardman|D|2|Water|2.0|a proud crest and a coral-tipped spear|medium_biped',
      'Salamander|D+|3|Fire|1.6|a tail that burns like a torch',
      'Basilisk|C|4|Earth|4.0|a crown of horns and eyes that petrify',
      'Crocodile Wyrm|C+|3|Water|7.0|a back of armored ridges like a sunken log|serpent',
      'Hydra|B+|3|Poison|9.0|five heads on long necks, each with its own temper|serpent',
      'Gorgon Wyrm|S|4|Earth|14|a stone-crusted body that leaves statues in its wake|serpent'
    ]
  },
  draconic: {
    name: 'Dragons', type: 'Dragon', rig: 'dragon', genre: 'High Fantasy',
    biomes: ['mountain', 'volcanic', 'sky', 'tundra', 'coast'],
    covering: 'scales', material: 'dragon_scale', drops: ['Dragon Scale', 'Dragon Blood', 'Dragon Heart'],
    behaviors: ['Territorial', 'Guardian', 'Aggressive'],
    trope: 'Dragons as proud, intelligent apex beings; wyverns as their lesser kin',
    cores: [
      'Hatchling|F|1|Fire|0.5|a too-big head and wings it can\'t use yet',
      'Drake|E|2|Fire|2.0|stubby wings and a smoking snout|quad_large',
      'Fire Drake|D|3|Fire|3.0|ember scales and a magma-glowing belly|quad_large',
      'Frost Drake|D|3|Ice|3.0|blue-white scales with frost on every edge|quad_large',
      'Thunder Drake|D|3|Lightning|3.0|horns that work like lightning rods|quad_large',
      'Wyvern|B|3|Wind|8.0|tattered wings and a venom-tipped tail|wyvern',
      'Young Dragon|A|3|Fire|12|a proud crest and scales that shine like new coins',
      'Drake Lord|A+|3|Fire|10|a crown of broken horns from rivals it killed|wyvern',
      'Adult Dragon|S|3|Lightning|25|cathedral wings and a voice that shakes stone',
      'Starfall Wyrm|SSS|3|Light|60|scales flecked with fallen starmetal that glitter like a night sky',
      'Ignivar, the Ember Throne|EX|3|Fire|80|a hoard of molten gold fused into its scales',
      'Glacirra, the White Silence|EX|2|Ice|80|wings like frozen waterfalls',
      'Zephyros, the Endless Sky|EX|2|Wind|90|a body made half of clouds',
      'Terragon, the Mountain That Breathes|EX|2|Earth|2000|forests growing along its back',
      'Umbrael, the Hollow Star|EX|4|Void|100|scales like a night sky full of dying stars',
      'Solvoryn, the Dawnwyrm|EX|2|Light|150|feathered wings of golden light',
      'Nythraxa, the Duskwyrm|EX|2|Dark|150|a body of dusk-colored mist and silver eyes',
      'Kaelumbra, the Twilight Arbiter|EX|2|Void|150|a body split down the middle, half dawn-gold and half dusk-violet'
    ]
  },
  construct: {
    name: 'Constructs & Mimics', type: 'Construct', rig: 'golem', genre: 'Ancient Ruins',
    biomes: ['ruins', 'city', 'underworld', 'sky', 'desert'],
    covering: 'surface', material: 'stone_metal_runes', drops: ['Golem Core', 'Rune Plate', 'Gear'],
    behaviors: ['Guardian', 'Ambush', 'Territorial'],
    trope: 'Treasure-chest mimics and ancient guardian golems',
    cores: [
      'Mud Doll|F|1|Earth|0.8|a child\'s clay figure with thumbprint eyes|small_biped',
      'Door Mimic|F|5|None|2.0|a dungeon door that breathes|mimic',
      'Smiling Scarecrow|F|5|None|2.0|a stitched sack face with a painted smile that is never in the same field twice|medium_biped',
      'Living Armor|E+|3|None|1.9|an empty suit of plate that walks|medium_biped',
      'Stone Golem|D|2|Earth|3.0|a rune glowing on its back',
      'Mimic|D|5|None|1.0|a treasure chest with a tongue and a ring of teeth|mimic',
      'Clockwork Sentinel|C|3|Lightning|2.5|brass gears visible through its ribs',
      'Iron Golem|B|2|Earth|4.0|riveted iron and a furnace heart',
      'Crystal Golem|B+|2|Light|3.5|a body of prisms that splits light into rainbows',
      'Mimic King|A|5|None|6.0|a treasure vault that walks on a hundred stolen legs|mimic',
      'Mithril Colossus|S|2|Light|50|silver plating and a face like a temple mask',
      'Starmetal Colossus|SSS|2|Light|120|a starmetal body that hums with Titan songs',
      'Titan of the First Age|EX|3|Earth|500|a walking continent of machinery and stone'
    ]
  },
  elemental: {
    name: 'Elementals & Spirits', type: 'Elemental', rig: 'floating', genre: 'Spirit Realm',
    biomes: ['forest', 'mountain', 'volcanic', 'sea', 'sky', 'spirit'],
    covering: 'body', material: 'elemental_emissive', drops: ['Elemental Essence', 'Spirit Mote'],
    behaviors: ['Passive', 'Territorial', 'Guardian'],
    trope: 'Spirits you can contract with; elemental kings',
    cores: [
      'Wisp|F|1|Light|0.3|a floating ball of soft light',
      'Will-o\'-Wisp|E|4|Dark|0.3|a pale flame that leads travelers into bogs',
      'Pixie|E|1|Wind|0.2|dragonfly wings and a mischievous grin|flyer_small',
      'Salamander Spirit|D|2|Fire|1.0|a lizard of living flame|serpent',
      'Undine|D|1|Water|1.6|a woman-shaped figure of flowing water|medium_biped',
      'Sylph|D+|1|Wind|1.5|a translucent dancer of wind and leaves|medium_biped',
      'Gnome|D+|2|Earth|0.7|a stone-bearded little figure with gem eyes|small_biped',
      'Ifrit|B|3|Fire|5.0|a torso of fire rising from a smoking lamp',
      'Storm Djinn|B+|3|Lightning|4.0|a cloud body with lightning tattoos',
      'Spirit King|S|2|Light|6.0|a crowned elemental giant of pure mana|medium_biped',
      'Elemental Sovereign|SSS|3|Lightning|20|four orbiting crowns of fire, ice, storm and stone',
      'Elemental Primarch|EX|3|Void|40|four elements orbiting a void core'
    ]
  },
  plant: {
    name: 'Plants & Fungi', type: 'Plant', rig: 'plant_rooted', genre: 'Fairy-tale Forest',
    biomes: ['forest', 'jungle', 'swamp', 'ruins'],
    covering: 'bark and leaves', material: 'bark_leaf', drops: ['Sap', 'Seed', 'Spore Cap'],
    behaviors: ['Passive', 'Ambush', 'Territorial'],
    trope: 'Screaming mandrakes, walking mushrooms and ancient treants',
    cores: [
      'Mandrake|F|2|Nature|0.3|a screaming root with a leafy tuft|plant_walker',
      'Puffcap Mushroom|F|1|Nature|0.5|a spotted cap that sneezes giggle-spores|plant_walker',
      'Walking Mushroom|F|1|Nature|0.6|a waddling cap on stubby legs|plant_walker',
      'Thornvine|E|3|Nature|3.0|vines covered in hooked thorns',
      'Man-Eater Plant|D|3|Nature|2.5|a flower with jaws made of petals',
      'Treant Sapling|D|1|Nature|2.0|a young tree with a sleepy face|plant_walker',
      'Spore Lord|C|4|Poison|3.0|a mushroom crown and a cloak of mycelium|plant_walker',
      'Corpse Flower|B|4|Dark|4.0|a rotting bloom the size of a cart',
      'Elder Treant|A|2|Nature|12|a moss beard and owls living in its branches|plant_walker',
      'Ancient Treant|S|2|Nature|30|a forest growing from its shoulders|plant_walker',
      'Worldroot Behemoth|SSS|3|Nature|80|a walking forest with a glowing heartwood core|plant_walker',
      'Blighted World Root|EX|5|Dark|300|black roots that pulse like veins'
    ]
  },
  demon: {
    name: 'Demons', type: 'Demon', rig: 'medium_biped', genre: 'Abyssal',
    biomes: ['demon', 'city', 'volcanic', 'ruins'],
    covering: 'hide', material: 'demon_hide_emissive', drops: ['Demon Core', 'Horn Shard', 'Brimstone'],
    behaviors: ['Aggressive', 'Ambush', 'Guardian'],
    trope: 'Demons as a people of the Abyss, not just evil (Frieren, Maoyuu)',
    cores: [
      'Imp|E|2|Fire|0.6|bat wings, a pointed tail and a cheeky grin|flyer_small',
      'Hellhound|D|3|Fire|1.5|a dog with a furnace glow inside its ribs|quad_large',
      'Lesser Demon|C|3|Dark|2.2|curled horns and a leathery hide',
      'Gargoyle|C|3|Earth|2.0|a stone body that cracks when it moves|wyvern',
      'Charmfiend|C+|4|Dark|1.8|a beautiful porcelain mask hiding a hollow face',
      'Greater Demon|B|3|Dark|3.5|a noble\'s coat and a crown of horns',
      'Nightmare Steed|B+|3|Fire|2.5|flame hooves and a mane of smoke|quad_large',
      'Demon Knight|A|3|Dark|2.5|black-steel armor engraved with the Overlord\'s sigil',
      'Arch Demon|S|3|Dark|8.0|four wings and a voice like a choir|wyvern',
      'Abyss Prince|SSS|3|Void|4.0|a crown of black flame and wings of torn night',
      'Abyss Herald|SS|4|Void|10|a tall figure with a void where its face should be'
    ]
  },
  aquatic: {
    name: 'Aquatic', type: 'Aquatic', rig: 'fish', genre: 'Seafaring',
    biomes: ['coast', 'sea', 'swamp'],
    covering: 'scales and skin', material: 'wet_scale', drops: ['Fish Scale', 'Pearl', 'Ink Sac'],
    behaviors: ['Territorial', 'Ambush', 'Swarm'],
    trope: 'Sea kings and krakens (One Piece), sirens and merfolk',
    cores: [
      'Giant Crab|F|2|Water|1.0|one claw much bigger than the other|hexapod',
      'Piranha Swarm|E|3|Water|0.2|silver flashes and red teeth|swarm',
      'Sahuagin|D|3|Water|1.9|a shark-like head and webbed hands|medium_biped',
      'Glowfin Angler|C|4|Dark|3.0|a lure of light dangling over a mouth of glass teeth',
      'Sea Serpent|C|3|Water|20|a long fin running down its spine|serpent',
      'Siren|C+|4|Water|2.0|a fish tail and a voice that sounds like home|naga',
      'Giant Octopus|B|3|Water|10|skin that changes color to match the rocks|cephalopod',
      'Kraken Spawn|B+|4|Water|25|a galleon-sized body with hooked tentacles|cephalopod',
      'Merfolk Warden|A|2|Water|2.2|coral armor and a trident|naga',
      'Leviathan Young|S|3|Water|60|fins like the sails of a warship',
      'Abyssal Kraken Queen|SSS|4|Void|200|tentacles that can wrap around whole islands|cephalopod',
      'Leviathan|EX|3|Water|600|a body so vast it moves the horizon'
    ]
  },
  avian: {
    name: 'Avians', type: 'Avian', rig: 'avian', genre: 'High Fantasy',
    biomes: ['mountain', 'plains', 'sky', 'coast'],
    covering: 'plumage', material: 'feather_groom', drops: ['Feather', 'Talon', 'Egg'],
    behaviors: ['Territorial', 'Skittish', 'Aggressive'],
    trope: 'Griffons, harpies and phoenixes of classic fantasy',
    cores: [
      'Giant Crow|F|2|Dark|0.6|a beak full of stolen shiny things',
      'Cockatrice|E|2|Earth|0.8|a rooster\'s head and a lizard\'s tail',
      'Harpy|D|3|Wind|1.6|a bird body with a shrieking human-like face',
      'Griffon|C|2|Wind|3.0|an eagle\'s front and a lion\'s back|quad_large',
      'Hippogriff|C|2|Wind|2.8|an eagle\'s head on a horse\'s body|quad_large',
      'Thunderbird|B|3|Lightning|8.0|wings that drum thunder',
      'Roc|A|3|Wind|30|a shadow as big as a cloud',
      'Phoenix|S|1|Fire|6.0|feathers of living flame that fall as embers',
      'Simurrah|S|1|Light|20|a healing bird with peacock-eyed plumage',
      'Eternal Phoenix|SSS|1|Fire|30|a sun-bright body that rises again from its own ash',
      'Aethernax, the Sky Devourer|EX|4|Void|400|wings that leave holes in the sky'
    ]
  },
  chimera: {
    name: 'Chimeras & Mythic Beasts', type: 'Mythic Beast', rig: 'quad_large', genre: 'World Myth',
    biomes: ['ruins', 'desert', 'mountain', 'demon'],
    covering: 'hide', material: 'mixed_hide', drops: ['Chimera Heart', 'Mythic Horn'],
    behaviors: ['Territorial', 'Guardian', 'Aggressive'],
    trope: 'Greek, Persian and East Asian mythic beasts',
    cores: [
      'Manticore|B|3|Poison|3.0|a lion\'s body, a scorpion tail and a too-human smile',
      'Chimera|B+|3|Fire|3.5|lion, goat and serpent heads on one body',
      'Nue|B|4|Lightning|3.0|a monkey\'s face, a tiger\'s body and a snake for a tail',
      'Unicorn|A|1|Light|2.0|a spiral horn of pearl',
      'Cerberus|A+|3|Fire|5.0|three heads with three different moods',
      'Sphinx|S|2|Light|6.0|a lion\'s body and a calm, ancient face',
      'Qilin|S|1|Light|3.0|scales, antlers and hooves that never bend the grass',
      'Nameless Abomination|EX|5|Void|50|a blank page given teeth|aberrant'
    ]
  },
  serpentfolk: {
    name: 'Serpentfolk', type: 'Serpentfolk', rig: 'naga', genre: 'Jungle Temple',
    biomes: ['jungle', 'desert', 'ruins', 'swamp'],
    covering: 'scales', material: 'scale_gloss', drops: ['Serpent Scale', 'Temple Gold'],
    behaviors: ['Guardian', 'Ambush'],
    trope: 'Lamia and naga temple guardians',
    cores: [
      'Lamia|C|3|Poison|3.5|a coiling tail and hypnotic golden eyes',
      'Naga Warrior|C+|3|Water|4.0|four arms holding four blades',
      'Naga Priestess|B|3|Dark|4.0|a hood of jeweled scales and temple tattoos',
      'Serpent Empress|S|3|Poison|12|a crown of living snakes'
    ]
  },
  centaur: {
    name: 'Centaurs & Taurs', type: 'Beastfolk', rig: 'taur', genre: 'Steppe Epic',
    biomes: ['plains', 'steppe', 'forest', 'desert'],
    covering: 'coat', material: 'horse_coat', drops: ['Horsehair', 'Painted Barding'],
    behaviors: ['Pack', 'Territorial'],
    trope: 'Proud nomadic centaur tribes',
    cores: [
      'Centaur Scout|C|2|Wind|2.4|a horsebow and a braided mane',
      'Centaur Lancer|C+|2|None|2.6|a long lance and painted barding',
      'Scorpion Rider|B|3|Poison|3.0|a humanoid torso on a giant scorpion body',
      'Centaur Khan|A|2|Lightning|3.0|a lightning-bolt war standard'
    ]
  },
  headless: {
    name: 'The Headless', type: 'Undead', rig: 'headless', genre: 'Celtic Gothic',
    biomes: ['ruins', 'swamp', 'plains'],
    covering: 'armor', material: 'old_iron', drops: ['Rider\'s Lantern', 'Cursed Iron'],
    behaviors: ['Aggressive', 'Guardian'],
    trope: 'The dullahan of Irish folklore',
    cores: [
      'Headless Rider|C|4|Dark|2.6|a lantern burning where its head should be',
      'Dullahan|B|4|Dark|2.8|its own laughing head carried under one arm',
      'Pale Herald|S|4|Void|3.5|a cape of fog trailing behind a headless knight'
    ]
  },
  gremlin: {
    name: 'Gremlins', type: 'Fey Pest', rig: 'small_biped', genre: 'Steampunk Mischief',
    biomes: ['city', 'ruins'],
    covering: 'skin', material: 'rubbery_skin', drops: ['Stolen Bolt', 'Gremlin Ear'],
    behaviors: ['Skittish', 'Swarm'],
    trope: 'Machine-breaking pests',
    cores: [
      'Gremlin|F|2|Lightning|0.6|bat ears, a wrench and a laugh like a squeaky hinge',
      'Saboteur Gremlin|E|3|Lightning|0.7|goggles and a bag of stolen bolts',
      'Gremlin King|C|3|Lightning|1.2|a throne bolted onto a walking boiler'
    ]
  },
  aberration: {
    name: 'Aberrations', type: 'Aberration', rig: 'aberrant', genre: 'Cosmic Horror',
    biomes: ['underworld', 'ruins', 'forest'],
    covering: 'skin', material: 'wet_flesh_unsettling', drops: ['Unreal Fragment', 'Eye of Nothing'],
    behaviors: ['Ambush', 'Aggressive'],
    trope: 'Mimicking things in the dark',
    cores: [
      'Skinwalker Mimic|F|5|Dark|1.8|it calls you in your companion\'s voice',
      'Grin in the Walls|D|5|Dark|1.0|only its smile is ever visible|mimic',
      'Faceless One|C|5|Void|2.2|a smooth blank face that slowly learns to look like yours',
      'The Many-Mouthed|B|5|Void|4.0|mouths opening along its arms, all whispering',
      'Thousand-Eyed Watcher|A|5|Void|6.0|a cloud of eyes that blink in sequence|floating'
    ]
  },
  yokai: {
    name: 'Yokai-Inspired Spirits', type: 'Spirit', rig: 'floating', genre: 'Japanese Folklore',
    regions: ['Hoshizora', 'Kitsune Isles', 'Shen-Lu', 'Haneul', 'Everdusk'],
    covering: 'form', material: 'paper_ink_spirit', drops: ['Spirit Paper', 'Fox Fire'],
    behaviors: ['Passive', 'Ambush', 'Territorial'],
    trope: 'Gentle and terrifying spirits (Natsume\'s Book of Friends, Mushishi, Inuyasha)',
    cores: [
      'Umbrella Spirit|F|1|Water|0.8|a one-eyed paper umbrella hopping on one leg|small_biped',
      'Lantern Ghost|E|3|Fire|0.6|a paper lantern with a torn mouth',
      'River Imp|E|2|Water|1.0|a dish-like hollow on its head full of water|small_biped',
      'Long-Neck Lady|D|4|Dark|1.7|a neck that stretches across rooftops|aberrant',
      'Fox Spirit|D|2|Fire|1.0|three tails tipped with blue flame|quad_small',
      'Tengu|C|2|Wind|2.0|crow wings, a long red mask and a feather fan|avian',
      'Earth Weaver|B|4|Earth|6.0|a tiger-striped spider the size of a house|octopod',
      'Oni|B+|3|Fire|3.5|horns, a tiger-skin wrap and an iron club|large_biped',
      'Hunger Colossus|A|4|Dark|30|a skeleton giant built from the bones of the starved|large_biped',
      'Great Tengu King|SSS|2|Wind|6.0|a mask of red lacquer and a fan that summons typhoons|avian',
      'Nine-Tailed Vixen Queen|S|2|Fire|8.0|nine tails that each hold a different spell|quad_large'
    ]
  },
  floorborn: {
    name: 'Floor-born', type: 'Dungeon-born', rig: 'golem', genre: 'Dungeon Crawl',
    regions: ['Great Labyrinth (Floors 1-40)', 'Great Labyrinth (Floors 41-90)', 'Great Labyrinth (Floors 91-120)', 'Aurumdeep', 'The Maw', 'Umbravel'],
    covering: 'stone-like hide', material: 'dungeon_stone', drops: ['Dungeon Core Shard'],
    behaviors: ['Aggressive', 'Swarm', 'Guardian'],
    trope: 'Monsters born directly from dungeon walls (DanMachi); dungeon as ecosystem (Dungeon Meshi)',
    cores: [
      'Floor Crawler|F|3|None|0.8|stone-colored skin that matches the walls it was born from|quad_small',
      'Wall Stalker|E|4|Earth|2.0|it peels itself out of the wall|aberrant',
      'Labyrinth Hound|D|3|Earth|1.4|a brick-patterned hide|quad_large',
      'Core Sentinel|C|3|Light|2.5|a dungeon-core crystal for a heart',
      'Maze Weaver|B|4|Dark|3.0|it rebuilds corridors behind you|octopod',
      'Floor Tyrant|A|3|Earth|8.0|a crown of stalactites|large_biped'
    ]
  },
  vesperite: {
    name: 'Vesperites (Moon Raiders)', type: 'Lunar Raider', rig: 'medium_biped', genre: 'Cosmic Fantasy',
    regions: ['Lustrine Shores', 'Vesper', 'Aldmere', 'Sunscar', 'Strife Marches'],
    covering: 'porcelain shell', material: 'porcelain_red_glow', drops: ['Vesper Glass', 'Captured Soul-Light'],
    behaviors: ['Aggressive', 'Ambush'],
    trope: 'Serene moon-raiders harvesting gem people (Land of the Lustrous)',
    cores: [
      'Vesper Shard-Thrall|C|4|Blood|1.8|porcelain skin cracked with red light',
      'Moon Archer|B|3|Blood|2.0|a bow of red glass and robes like falling silk',
      'Crimson Choir Seraph|A|4|Blood|3.5|six wings of red glass and a singing mask|floating',
      'Vesper Harvester|S|5|Blood|6.0|a lantern cage that holds stolen souls|floating'
    ]
  },
  sandborne: {
    name: 'Sandborne', type: 'Desert Beast', rig: 'serpent', genre: 'Desert Epic',
    biomes: ['desert'],
    covering: 'sand-scoured hide', material: 'sand_hide', drops: ['Desert Glass', 'Sand Pearl'],
    behaviors: ['Ambush', 'Territorial'],
    trope: 'Desert giants and sandworms (Dune, Children of the Whales)',
    cores: [
      'Sand Skink|F|2|Earth|0.5|sand-colored scales and a tongue that tastes for water|quad_small',
      'Dune Scorpion|D|3|Poison|2.0|a glass-like tail stinger|hexapod',
      'Glass Wraith|C|4|Light|2.0|a figure of fused desert glass, humming with old magic|floating',
      'Sandworm|B|3|Earth|40|a round mouth ringed with crystal teeth',
      'Dunewhale Thalassa|EX|1|Earth|900|a whale of stone and sand carrying a town on its back|fish'
    ]
  },
  humanoid_enemy: {
    name: 'Humanoid Enemies', type: 'Humanoid', rig: 'medium_biped', genre: 'Low Fantasy',
    biomes: ['city', 'plains', 'forest', 'mountain'],
    covering: 'clothing and gear', material: 'cloth_leather_metal', drops: ['Coin Purse', 'Weapon', 'Bounty Proof'],
    behaviors: ['Pack', 'Ambush', 'Aggressive'],
    trope: 'Bandits, cultists and fallen heroes',
    cores: [
      'Bandit|F|3|None|1.8|a patched cloak and a mismatched sword',
      'Highwayman Captain|D|3|None|1.8|a feathered hat and two pistols of Veilborn design',
      'Slaver|D|3|None|1.9|chains on its belt and a cruel smile',
      'Dark Cultist|C|4|Blood|1.8|red robes and a mask shaped like a crescent moon',
      'Rogue Mage|C|3|Fire|1.8|burnt academy robes and ink-stained fingers',
      'Inquisitor|B|3|Light|1.9|silver anti-magic chains and a sun-shaped mask',
      'Syndicate Blade|B|3|Dark|1.8|no face, no name, two knives',
      'Rogue Knight|A|3|None|2.0|a broken oath engraved on its blade',
      'Fallen Hero|S|3|Light|1.9|tarnished hero armor and eyes that have seen the truth of the System',
      'Corrupted Summoned Hero|EX|4|Blood|1.9|a Veilborn swallowed by the red moon'
    ]
  },
  familiar: {
    name: 'Familiars & Gentle Creatures', type: 'Familiar', rig: 'quad_small', genre: 'Cozy Fantasy',
    biomes: ['forest', 'plains', 'mountain', 'coast', 'sky', 'tundra'],
    covering: 'coat', material: 'fur_soft', drops: ['Soft Fur', 'Shed Scale'],
    behaviors: ['Passive'],
    trope: 'Cozy companion creatures',
    cores: [
      'Moss Tortoise|F|1|Nature|0.8|herbs and flowers growing on its shell',
      'Lantern Moth|F|1|Light|0.3|wings that glow like paper lanterns|flyer_small',
      'Fluffcap Sheep|F|1|Wind|1.0|wool so light it floats',
      'Rainbow Koi|F|1|Water|0.5|scales that shimmer every color|fish',
      'Mana Fox|E|1|Light|0.6|ears that twitch toward magic',
      'Ember Kitten|E|1|Fire|0.4|fur that flickers like candle flame',
      'Snowmole|E|1|Ice|0.4|a white nose and shovel-like paws',
      'Sky Whale|A|1|Wind|80|a gentle giant drifting between floating islands|fish'
    ]
  }
};
