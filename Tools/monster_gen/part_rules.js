// Project Ascend — designRecipe part rules.
// Chooses each species' designRecipe.parts from what the species is, not at random from its rig:
//   1. FEATURES: parts the name/signature asks for ("curved tusks" -> tusks, "a crown of horns" -> horn_crown).
//   2. PLANS:    the body plan's plausible optional parts (a wolf can have a mane, fangs, claws, a bushy tail,
//                never antlers or an armored back), matched on the core species' name/signature, family and rig.
//   3. BANS:     a safety net over every optional pool (no weapons on animals, no wings on walkers...).
// Variants read their core species' name, so a Crag Wild Boar is still a boar.
// Deterministic: optional parts are shuffled with a hash of the species id (independent of the main RNG stream).
// Check the result with Tools/monster_gen/audit_recipes.js.

// ---------- text ----------
// Rewrites similes and carried items so they don't read as anatomy, before any matching.
const NORMALIZE = [
  [/growing from its crown/g, 'growing from its head'],
  [/a horn carved from an ogre's tusk/g, 'a war bugle'],
  [/mask-like band/g, 'dark band'],
  [/a head like a split mask/g, 'a split head'],
  [/lance-like stinger/g, 'long stinger'],
  [/humming armored wings/g, 'humming hard wings'],
  [/forearms shaped like curved scythes/g, 'scythe-like claws on its forearms'],
  [/soft lantern lights/g, 'soft lights'],
  [/a boulder slung over its shoulder like a sack/g, 'a sack of boulders'],
  [/the shape of whatever it last ate/g, 'the form of its last meal'],
  [/as long as (swords|spears)/g, 'as long as a forearm'],
  [/shield-shaped/g, 'broad']
];
function coreText(name, signature) {
  let t = `${name} ${signature || ''}`.toLowerCase();
  for (const [re, to] of NORMALIZE) t = t.replace(re, to);
  return t;
}

// ---------- features: the text asks for these parts ----------
// any: candidates (the first one the rig or plan already uses wins, else the first); also: extra parts.
// consume: remove the matched words so later, more generic rules don't fire on them. sig: match the signature only.
const FEATURES = [
  // crowns and horns (specific forms first)
  { re: /crown of (broken )?horns/, any: ['horn_crown', 'horns'], consume: true },
  { re: /crown of (frost )?spikes/, any: ['horn_crown'], also: ['crystal_growths'], consume: true },
  { re: /crown of stalactites/, any: ['stone_growths'], also: ['crown'], consume: true },
  { re: /crown of stingers/, any: ['horn_crown'], consume: true },
  { re: /mushroom crown/, any: ['cap'], consume: true },
  { re: /\bcrown(ed|s)?\b/, any: ['crown', 'crown_slot', 'horn_crown'] },
  { re: /antler/, any: ['antlers'] },
  { re: /spiral horn|single horn/, any: ['horn_single'], consume: true },
  { re: /\bhorn(s|ed)?\b|bull's head|\boni\b|kijin/, any: ['horns', 'horns_small', 'horns_swept', 'horn_single', 'horn_crown'] },
  { re: /tusk|\borcs?\b|\bogre\b|\bboar\b/, any: ['tusks'] },
  // hair, wings, tails
  { re: /\bmane\b/, any: ['mane', 'hair_mane'] },
  { re: /\bhair\b|beard(ed)?\b/, any: ['hair_mane', 'mane'] },
  { re: /feathered wings|wings of golden light|wings of red glass|crow wings/, any: ['wing_feathers'], consume: true },
  { re: /\bwing(s|ed)?\b/, any: ['wing_membrane', 'membrane_wings', 'wing_feathers', 'wing_cases'] },
  { re: /fish tail|coiling tail/, any: [], consume: true }, // the serpent/naga body is the tail
  { re: /nine tails|three tails|nine-tailed|tails tipped/, any: ['tail_bushy'], consume: true },
  { re: /scorpion tail|tail stinger/, any: ['stinger'], consume: true },
  { re: /venom-tipped tail/, any: ['tail_spike'], consume: true },
  { re: /snake for a tail|lizard's tail|pointed tail|tail that burns/, any: ['tail_thin', 'tail'], consume: true },
  { re: /\btail\b/, any: ['tail', 'tail_thin', 'tail_bushy'] },
  // faces, clothes, armor, gear
  { re: /sack face/, any: ['mask', 'mask_face'] },
  { re: /\bmask\b/, any: ['mask', 'mask_face', 'human_mask', 'empty_visor'] },
  { re: /hood(ed)? shape|hood with no face/, any: ['tattered_shroud'], consume: true },
  { re: /\bhood\b/, any: ['hood'] },
  { re: /torn clothing|tiger-skin wrap/, any: ['loincloth'], consume: true },
  { re: /cloak of mycelium/, any: ['moss_cover'], also: ['tattered_shroud'], consume: true },
  { re: /cape of fog|cape that dissolves/, any: ['tattered_cape', 'cloak'], consume: true },
  { re: /\b(cloak|cape|robes?|mantle)\b|noble's coat|silk coat|aristocratic clothes|burial clothes/, any: ['cloak', 'tattered_cape', 'tattered_shroud'] },
  { re: /stone-plated back|armored ridges/, any: ['armored_back'], consume: true },
  { re: /head plate/, any: ['carapace_ridges'], consume: true },
  { re: /barding/, any: ['barding'], consume: true },
  { re: /\barmou?r(ed)?\b|suit of plate|black plate|\bplating\b|helmet|\bhelm\b/, any: ['armor_plates', 'plate_armor', 'crude_armor', 'barding'], sig: true },
  { re: /\bclub\b/, any: ['club_socket', 'weapon_socket'], sig: true },
  { re: /\blance\b/, any: ['lance', 'weapon_socket'], sig: true },
  { re: /sword|\bblades?\b|\baxe\b|spear|\bbow\b|horsebow|staff|wrench|hammer|\bscythe of\b|knives|cleaver|trident|labrys|pistols?|feather fan|\bfan that\b|banner|war standard|shield/, any: ['weapon_socket', 'club_socket', 'lance'], sig: true },
  { re: /chain/, any: ['chains', 'chain_belt'] },
  { re: /lantern|\blamp\b|phylactery/, any: ['lantern_core'] },
  { re: /saddle|\bmount\b/, any: ['mount'] },
  { re: /head carried|carried under one arm/, any: ['head_carried'] },
  { re: /jewel|nose ring/, any: ['jewelry'] },
  { re: /skull headdress|collar of teeth|trophies/, any: ['bone_trinkets'] },
  // mouths, eyes, teeth, claws
  { re: /sabre fangs|fangs as long/, any: ['fangs_long'], consume: true },
  { re: /\bfangs?\b/, any: ['fangs_long', 'fangs', 'teeth_rows'] },
  { re: /crystal teeth|ring of teeth|ringed with teeth/, any: ['teeth_ring'] },
  { re: /mouth of glass teeth/, any: ['teeth_rows'] },
  { re: /mouths opening along its arms/, any: ['mouth_clusters'], consume: true },
  { re: /eight eyes|cloud of eyes/, any: ['eye_cluster', 'eye_clusters'] },
  { re: /\bbeak\b|owl's feathered face|eagle's (head|front)/, any: ['beak_hooked', 'beak'] },
  { re: /rooster/, any: ['crest'] },
  { re: /mandible|jaw that never stops/, any: ['mandibles'] },
  { re: /\bclaws?\b|black nails|shovel-like paws/, any: ['claws'] },
  { re: /tongue/, any: ['tongue'] },
  { re: /stolen legs/, any: ['hidden_legs'] },
  { re: /sting(er|ers)?\b/, any: ['stinger'] },
  { re: /four arms/, any: ['multiple_arms'] },
  { re: /upper body|humanoid torso/, any: ['humanoid_torso'] },
  // surfaces and growths
  { re: /tentacle/, any: ['tentacles'] },
  { re: /fins like the sails/, any: ['fins_sail'], consume: true },
  { re: /\bfins?\b/, any: ['fins', 'fins_sail'] },
  { re: /\blure\b/, any: ['lure'] },
  { re: /whisker/, any: ['whiskers', 'whiskers_long'] },
  { re: /frill/, any: ['neck_frill'] },
  { re: /\bcrest\b/, any: ['crest', 'neck_frill', 'horn_crown'] },
  { re: /shell like|on its shell|shell made from/, any: ['carapace_ridges', 'scales_armored', 'wing_cases'] },
  { re: /moss|herbs and flowers|forests? growing/, any: ['moss_cover'] },
  { re: /thorn/, any: ['thorns'] },
  { re: /\bvines\b/, any: ['vine_whips'] },
  { re: /jaws made of petals|rotting bloom/, any: ['petal_jaws'] },
  { re: /\broots?\b/, any: ['root_tendrils'] },
  { re: /\bcap\b|mushroom/, any: ['cap'] },
  { re: /\bweb\b|crown of silk/, any: ['web_spinneret'] },
  { re: /\bgears?\b|springs/, any: ['gear_joints'] },
  { re: /\brunes?\b/, any: ['rune_core', 'glowing_spots'] },
  { re: /prisms|fused desert glass|frost crystals|crystals growing/, any: ['crystal_growths'] },
  { re: /stone body|stone-crusted|bedrock|a mountain with|statues/, any: ['stone_growths'] },
  { re: /tattoo/, any: ['glowing_spots', 'scale_patterns', 'scar_decals'] },
  { re: /\bscar(s|red)?\b/, any: ['scar_decals'] },
  { re: /made of smoke|shape of smoke|mane of smoke|of mist\b|cloud body|half of clouds/, any: ['trailing_wisps'] },
  { re: /molten trails/, any: ['drip_trail'] },
  { re: /bubbles|spheres/, any: ['surface_bubbles'] },
  { re: /suspended inside|swallowed debris|ember core|storm-cloud interior|void core|heartwood core|furnace heart|core crystal|dungeon-core/, any: ['inner_core', 'rune_core', 'glowing_knots', 'lantern_core'] },
  { re: /dot eyes|thumbprint eyes|sleepy face/, any: ['face_decal'] }
];

// ---------- body plans: plausible optional parts ----------
// First match wins. re: tested on the core text; rig/fam: restrict to rigs/family keys.
const PLANS = [
  // quadrupeds
  { rig: ['quad_large', 'quad_small'], re: /brick-patterned|stone-colored skin/, pool: ['stone_growths', 'claws', 'scale_ridges', 'scar_decals'] },
  { rig: ['quad_large', 'quad_small'], re: /cerberus|fenrir|garmrok|wolf|hound|\bdog\b/, pool: ['mane', 'fangs_long', 'claws', 'tail_bushy', 'fur_tufts', 'scar_decals'] },
  { rig: ['quad_large', 'quad_small'], re: /\bboar\b|\bhog\b|swine/, pool: ['mane', 'fur_tufts', 'scar_decals', 'tail_thin'] },
  { rig: ['quad_large'], re: /owlbear/, pool: ['beak_hooked', 'claws', 'fur_tufts', 'scar_decals'] },
  { rig: ['quad_large'], re: /\bbear\b/, pool: ['claws', 'fur_tufts', 'fangs_long', 'scar_decals'] },
  { rig: ['quad_large'], re: /\belk\b|deer|stag/, pool: ['fur_tufts', 'mane', 'scar_decals'] },
  { rig: ['quad_large'], re: /behemoth|mammoth/, pool: ['horns', 'armored_back', 'tail_club', 'tusks', 'stone_growths', 'scar_decals'] },
  { rig: ['quad_large'], re: /manticore/, pool: ['mane', 'stinger', 'fangs_long', 'claws', 'wing_membrane'] },
  { rig: ['quad_large'], re: /chimera/, pool: ['mane', 'horns', 'wing_membrane', 'claws', 'fangs_long', 'tail_thin'] },
  { rig: ['quad_large'], re: /sphinx/, pool: ['mane', 'wing_feathers', 'claws', 'jewelry'] },
  { rig: ['quad_large'], re: /griffon/, pool: ['wing_feathers', 'beak_hooked', 'talons', 'claws', 'tail_thin'], must: ['wing_feathers'] },
  { rig: ['quad_large'], re: /hippogriff/, pool: ['wing_feathers', 'beak_hooked', 'talons', 'mane'], must: ['wing_feathers'] },
  { rig: ['quad_large'], re: /unicorn|qilin|steed|horse/, pool: ['mane', 'tail_bushy', 'fur_tufts'] },
  { rig: ['quad_large'], re: /\bnue\b/, pool: ['fur_tufts', 'claws', 'fangs_long', 'tail_thin'] },
  { rig: ['quad_large'], re: /sabre|lion|tiger|panther|lynx|leopard/, pool: ['fangs_long', 'claws', 'whiskers', 'tail_thin', 'fur_tufts'] },
  { rig: ['quad_large', 'quad_small'], re: /vixen|\bfox\b/, pool: ['tail_bushy', 'ears_tall', 'whiskers', 'fur_tufts'] },
  { rig: ['quad_large'], re: /drake|basilisk/, pool: ['horns', 'spine_plates', 'claws', 'scale_ridges', 'glowing_throat', 'neck_frill'] },
  { rig: ['quad_large', 'quad_small'], re: /lizard|salamander|skink|crawler/, pool: ['claws', 'scale_ridges', 'neck_frill', 'tail_thin', 'spine_plates'] },
  { rig: ['quad_small'], re: /rabbit|\bhare\b|jackalope/, pool: ['ears_tall', 'tail_bushy', 'fur_tufts', 'whiskers'] },
  { rig: ['quad_small'], re: /kitten|\bcat\b/, pool: ['whiskers', 'ears_tall', 'tail_thin', 'fur_tufts'] },
  { rig: ['quad_small'], re: /sheep|lamb/, pool: ['fur_tufts', 'tail_bushy'] },
  { rig: ['quad_small'], re: /\bmole\b|snowmole/, pool: ['whiskers', 'claws', 'fur_tufts'] },
  { rig: ['quad_small'], re: /tortoise|turtle/, pool: ['scales_armored', 'moss_cover', 'tail_thin'], must: ['scales_armored'] },
  { rig: ['quad_small'], re: /toad|frog/, pool: ['tongue'] },
  { rig: ['quad_large'], pool: ['claws', 'fangs_long', 'fur_tufts', 'scar_decals'] },
  { rig: ['quad_small'], pool: ['ears_tall', 'tail_bushy', 'fur_tufts', 'whiskers'] },
  // small bipeds
  { rig: ['small_biped'], fam: ['kobold'], pool: ['ears_long', 'crude_armor', 'loincloth', 'weapon_socket', 'bone_trinkets', 'tail_thin'] },
  { rig: ['small_biped'], fam: ['gremlin'], pool: ['ears_long', 'nose_hooked', 'weapon_socket', 'bone_trinkets', 'gear_joints', 'tail_thin'] },
  { rig: ['small_biped'], re: /mud doll/, pool: ['face_decal', 'moss_cover', 'scar_decals'] },
  { rig: ['small_biped'], re: /gnome/, pool: ['nose_hooked', 'hair_mane', 'crystal_growths', 'stone_growths'] },
  { rig: ['small_biped'], re: /umbrella/, pool: ['face_decal', 'tattered_shroud', 'tongue'] },
  { rig: ['small_biped'], re: /river imp/, pool: ['scales_armored', 'beak_hooked', 'fins'] },
  // medium bipeds
  { rig: ['medium_biped'], re: /wererat/, pool: ['tail_thin', 'whiskers', 'claws', 'fangs', 'fur_tufts'] },
  { rig: ['medium_biped'], re: /werebear/, pool: ['claws', 'fur_tufts', 'scar_decals', 'fangs'] },
  { rig: ['medium_biped'], fam: ['lycan'], pool: ['mane', 'fangs_long', 'claws', 'tail_bushy', 'ears_tall', 'fur_tufts', 'scar_decals'] },
  { rig: ['medium_biped', 'large_biped'], re: /\borcs?\b/, pool: ['armor_plates', 'crude_armor', 'weapon_socket', 'cloak', 'scar_decals', 'chain_belt'] },
  { rig: ['medium_biped'], fam: ['goblinoid'], pool: ['ears_long', 'armor_plates', 'crude_armor', 'weapon_socket', 'cloak', 'scar_decals', 'bone_trinkets'] },
  { rig: ['medium_biped'], re: /skeleton knight|death knight|living armor|demon knight|shade knight/, pool: ['armor_plates', 'weapon_socket', 'cloak', 'tattered_cape', 'empty_visor'] },
  { rig: ['medium_biped'], re: /skeleton/, pool: ['weapon_socket', 'crude_armor', 'tattered_cape', 'bone_trinkets'] },
  { rig: ['medium_biped'], re: /zombie|ghoul|mourner/, pool: ['tattered_cape', 'scar_decals', 'loincloth', 'claws'] },
  { rig: ['medium_biped'], re: /vampire/, pool: ['cloak', 'fangs', 'jewelry', 'tattered_cape'] },
  { rig: ['medium_biped'], fam: ['shadow'], pool: ['trailing_wisps', 'weapon_socket', 'empty_visor', 'cloak', 'joint_spikes'] },
  { rig: ['medium_biped'], re: /satyr/, pool: ['horns_small', 'tail', 'fur_tufts', 'loincloth'] },
  { rig: ['medium_biped'], re: /gnoll/, pool: ['ears_tall', 'fangs', 'tail', 'crude_armor', 'weapon_socket', 'mane'] },
  { rig: ['medium_biped'], re: /lizardman/, pool: ['tail', 'crest', 'scale_ridges', 'weapon_socket', 'crude_armor'] },
  { rig: ['medium_biped'], re: /sahuagin/, pool: ['fins', 'teeth_rows', 'weapon_socket', 'scale_ridges', 'gills'] },
  { rig: ['medium_biped'], re: /undine|sylph/, pool: ['trailing_wisps', 'glowing_spots', 'hair_mane'] },
  { rig: ['medium_biped'], re: /spirit king/, pool: ['trailing_wisps', 'glowing_spots', 'cloak', 'rune_core'] },
  { rig: ['medium_biped'], re: /scarecrow/, pool: ['mask', 'cloak', 'loincloth', 'scar_decals'] },
  { rig: ['medium_biped'], fam: ['demon'], pool: ['horns', 'armor_plates', 'cloak', 'weapon_socket', 'tail'] },
  { rig: ['medium_biped'], fam: ['vesperite'], pool: ['mask', 'cloak', 'weapon_socket', 'armor_plates', 'crystal_growths', 'glowing_spots'] },
  { rig: ['medium_biped'], fam: ['humanoid_enemy'], pool: ['armor_plates', 'cloak', 'weapon_socket', 'mask', 'crude_armor', 'chains'] },
  { rig: ['medium_biped'], pool: ['armor_plates', 'cloak', 'weapon_socket', 'scar_decals'] },
  // large bipeds
  { rig: ['large_biped'], re: /skeleton|bones of/, pool: ['chain_belt', 'bone_trinkets', 'tattered_cape', 'scar_decals'] },
  { rig: ['large_biped'], fam: ['minotaur'], pool: ['horns', 'weapon_socket', 'chain_belt', 'scar_decals', 'hair_mane', 'armor_plates'] },
  { rig: ['large_biped'], re: /\boni\b/, pool: ['horns', 'club_socket', 'chain_belt', 'hair_mane', 'loincloth', 'scar_decals'] },
  { rig: ['large_biped'], re: /goblin/, pool: ['ears_long', 'armor_plates', 'weapon_socket', 'chain_belt', 'scar_decals'] },
  { rig: ['large_biped'], re: /titan remnant/, pool: ['stone_growths', 'moss_cover'] },
  { rig: ['large_biped'], re: /titan-kin|bedrock/, pool: ['stone_growths', 'armor_plates', 'rune_core', 'crystal_growths'] },
  { rig: ['large_biped'], re: /floor tyrant/, pool: ['stone_growths', 'crown', 'club_socket', 'scar_decals', 'crystal_growths'] },
  { rig: ['large_biped'], re: /ogre|troll|orc disaster/, pool: ['tusks', 'club_socket', 'chain_belt', 'stone_growths', 'scar_decals', 'hair_mane'] },
  { rig: ['large_biped'], pool: ['club_socket', 'chain_belt', 'stone_growths', 'scar_decals', 'hair_mane', 'armor_plates'] },
  // constructs
  { rig: ['golem'], re: /clockwork|iron golem|mithril|starmetal|titan of the first age/, pool: ['plate_armor', 'gear_joints', 'rune_core', 'empty_visor'] },
  { rig: ['golem'], re: /crystal|core sentinel|prism/, pool: ['crystal_growths', 'rune_core', 'empty_visor', 'stone_growths'] },
  { rig: ['golem'], pool: ['rune_core', 'stone_growths', 'crystal_growths', 'moss_cover', 'empty_visor'] },
  // arthropods
  { rig: ['hexapod'], re: /beetle|weevil/, pool: ['wing_cases', 'antennae', 'carapace_ridges', 'mandibles'] },
  { rig: ['hexapod'], re: /mantis/, pool: ['wing_cases', 'antennae', 'mandibles', 'leg_spikes', 'claws'] },
  { rig: ['hexapod'], re: /\bcrab\b/, pool: ['claws', 'carapace_ridges', 'antennae'] },
  { rig: ['hexapod'], re: /scorpion/, pool: ['stinger', 'claws', 'carapace_ridges', 'leg_spikes'] },
  { rig: ['hexapod'], pool: ['mandibles', 'antennae', 'carapace_ridges', 'leg_spikes'] },
  { rig: ['octopod'], pool: ['fangs', 'eye_cluster', 'web_spinneret', 'leg_spikes', 'hair_bristles'] },
  // long bodies
  { rig: ['serpent'], re: /centipede/, pool: ['mandibles', 'carapace_ridges', 'leg_spikes', 'antennae'] },
  { rig: ['serpent'], re: /leech/, pool: ['lantern_core', 'suckers', 'glowing_spots', 'drip_trail'] },
  { rig: ['serpent'], re: /crocodile/, pool: ['scale_ridges', 'armored_back', 'teeth_rows', 'claws'] },
  { rig: ['serpent'], re: /hydra/, pool: ['scale_ridges', 'fangs', 'hood', 'neck_frill'] },
  { rig: ['serpent'], re: /gorgon/, pool: ['stone_growths', 'scale_ridges', 'hood', 'fangs'] },
  { rig: ['serpent'], re: /salamander/, pool: ['trailing_wisps', 'scale_ridges', 'claws', 'flame_neck'] },
  { rig: ['serpent'], re: /sandworm/, pool: ['teeth_ring', 'crystal_growths', 'scale_ridges'] },
  { rig: ['serpent'], re: /sea serpent/, pool: ['fins', 'scale_ridges', 'teeth_rows', 'neck_frill'] },
  // flyers
  { rig: ['wyvern'], re: /hive tyrant/, pool: ['wing_membrane', 'stinger', 'mandibles', 'carapace_ridges'], must: ['wing_membrane'] },
  { rig: ['wyvern'], re: /gargoyle/, pool: ['wing_membrane', 'horns', 'talons', 'stone_growths', 'tail_spike'], must: ['wing_membrane'] },
  { rig: ['wyvern'], pool: ['wing_membrane', 'tail_spike', 'horn_crown', 'neck_frill', 'talons'], must: ['wing_membrane'] },
  { rig: ['dragon'], re: /hatchling|bone dragon/, pool: ['wing_membrane', 'horn_crown', 'spine_plates', 'tail_blade'], must: ['wing_membrane'] },
  { rig: ['dragon'], pool: ['horn_crown', 'wing_membrane', 'spine_plates', 'whiskers_long', 'tail_blade', 'glowing_throat'], must: ['wing_membrane'] },
  { rig: ['avian'], re: /\bcrow\b/, pool: ['wing_feathers', 'beak_hooked', 'talons', 'tail_plumes'], must: ['wing_feathers'] },
  { rig: ['avian'], re: /cockatrice/, pool: ['crest', 'wing_feathers', 'talons', 'beak_hooked', 'tail_thin'], must: ['wing_feathers'] },
  { rig: ['avian'], re: /harpy/, pool: ['wing_feathers', 'talons', 'hair_mane', 'tail_plumes'], must: ['wing_feathers'] },
  { rig: ['avian'], re: /tengu/, pool: ['wing_feathers', 'mask', 'weapon_socket', 'talons', 'cloak'], must: ['wing_feathers'] },
  { rig: ['avian'], pool: ['crest', 'tail_plumes', 'talons', 'beak_hooked', 'wing_feathers'], must: ['wing_feathers'] },
  { rig: ['flyer_small'], re: /wasp|hornet/, pool: ['membrane_wings', 'stinger', 'antennae', 'mandibles'], must: ['membrane_wings'] },
  { rig: ['flyer_small'], re: /pixie/, pool: ['membrane_wings', 'trailing_wisps', 'glowing_spots'], must: ['membrane_wings'] },
  { rig: ['flyer_small'], re: /moth/, pool: ['membrane_wings', 'antennae', 'glowing_spots', 'fur_tufts'], must: ['membrane_wings'] },
  { rig: ['flyer_small'], pool: ['membrane_wings', 'horns_small', 'tail_thin', 'fangs'], must: ['membrane_wings'] },
  // floating
  { rig: ['floating'], re: /\blich\b/, pool: ['chains', 'tattered_shroud', 'trailing_wisps', 'lantern_core'] },
  { rig: ['floating'], re: /ghost|wraith|banshee|reaper|mourner/, pool: ['trailing_wisps', 'tattered_shroud', 'chains'] },
  { rig: ['floating'], re: /\bwisp\b|will-o/, pool: ['trailing_wisps', 'lantern_core', 'glowing_spots'] },
  { rig: ['floating'], re: /watcher/, pool: ['eye_clusters', 'trailing_wisps'] },
  { rig: ['floating'], re: /seraph/, pool: ['wing_feathers', 'mask_face', 'glowing_spots', 'crystal_growths', 'trailing_wisps'] },
  { rig: ['floating'], re: /harvester/, pool: ['lantern_core', 'chains', 'tattered_shroud', 'mask_face', 'trailing_wisps'] },
  { rig: ['floating'], re: /lantern ghost/, pool: ['lantern_core', 'tongue', 'trailing_wisps'] },
  { rig: ['floating'], fam: ['elemental'], pool: ['trailing_wisps', 'lantern_core', 'glowing_spots', 'rune_core'] },
  { rig: ['floating'], pool: ['trailing_wisps', 'tattered_shroud', 'glowing_spots'] },
  // plants
  { rig: ['plant_walker'], re: /mushroom|puffcap|spore lord/, pool: ['cap', 'spore_pods', 'moss_cover', 'glowing_knots'], must: ['cap'] },
  { rig: ['plant_walker'], re: /mandrake/, pool: ['root_tendrils', 'face_decal', 'moss_cover'] },
  { rig: ['plant_walker'], pool: ['bark_plates', 'moss_cover', 'branch_arms', 'glowing_knots'] },
  // others keep their rig pool, minus bans
  { rig: ['taur'], re: /scorpion/, pool: ['humanoid_torso', 'stinger', 'claws', 'carapace_ridges', 'weapon_socket'], must: ['humanoid_torso'] },
  { rig: ['taur'], pool: ['humanoid_torso', 'weapon_socket', 'mane', 'barding'], must: ['humanoid_torso'] },
  { rig: ['naga'], re: /siren|merfolk/, pool: ['fins', 'scale_patterns', 'jewelry', 'hair_mane'] },
  { rig: ['naga'], pool: ['hood', 'jewelry', 'scale_patterns'] },
  { rig: ['cephalopod'], pool: ['tentacles', 'suckers', 'ink_sac', 'beak', 'glowing_spots'], must: ['tentacles'] },
  { rig: ['fish'], re: /whale|leviathan/, pool: ['fins_sail', 'glowing_spots', 'scales_armored'] },
  { rig: ['fish'], re: /\bkoi\b/, pool: ['fins', 'fins_sail', 'whiskers'] },
  { rig: ['fish'], pool: ['fins_sail', 'teeth_rows', 'scales_armored', 'gills'] }
];

// ---------- bans: a safety net over the optional pools ----------
const BEAST_TYPES = new Set(['Beast', 'Insectoid', 'Reptile', 'Avian', 'Aquatic', 'Plant', 'Ooze', 'Mythic Beast', 'Cursed Beast', 'Familiar', 'Dragon', 'Desert Beast']);
const FLYER_RIGS = new Set(['wyvern', 'dragon', 'avian', 'flyer_small']);
const HORNED = /\bhorn(s|ed)?\b|\b(oni|kijin|demon|satyr|minotaur|dragon|drake|wyrm|wyvern|behemoth|imp|gargoyle|chimera|basilisk|bull)\b/;
// Optional weapons only for armed humanoids by name; crowns only for royalty by name or text.
const ARMED = /bandit|knight|warrior|archer|lancer|raider|grunt|berserker|champion|general|warlord|soldier|guard|highwayman|slaver|hero|inquisitor|reaper|rider|khan|scout|captain|syndicate blade/;
const ROYAL = /crown|\bking\b|queen|\blord\b|monarch|matriarch|sovereign|emperor|empress|prince/;
const GROUPS = {
  horn: ['horns', 'horn_single', 'horns_small', 'horns_swept', 'horn_crown'],
  wing: ['wing_membrane', 'membrane_wings', 'wing_feathers'],
  weapon: ['weapon_socket', 'club_socket', 'lance'],
  dress: ['cloak', 'tattered_cape', 'tattered_shroud', 'loincloth', 'mask', 'mask_face', 'armor_plates', 'plate_armor', 'crude_armor', 'barding', 'jewelry']
};
function allowed(part, c) {
  const t = c.text;
  if (part === 'antlers') return /antler/.test(t);
  if (GROUPS.horn.includes(part)) return HORNED.test(t) || c.fam === 'demon' || c.fam === 'draconic';
  if (part === 'tusks') return /tusk|\borcs?\b|ogre|troll|\bboar\b|\bhog\b|behemoth|mammoth/.test(t);
  if (GROUPS.wing.includes(part)) return FLYER_RIGS.has(c.rig) || /wing|griffon|hippogriff|chimera|sphinx|manticore|seraph/.test(t);
  if (part === 'wing_cases') return /beetle|weevil|mantis/.test(t);
  if (GROUPS.weapon.includes(part)) return !BEAST_TYPES.has(c.type) && ARMED.test(t); // a named weapon comes in through FEATURES
  if (GROUPS.dress.includes(part)) return !BEAST_TYPES.has(c.type);
  if (part === 'armored_back' || part === 'tail_club') return /behemoth|mammoth|stone|plate|brick|shell|armou?r|ridge/.test(t) || ['reptile', 'draconic'].includes(c.fam);
  if (part === 'humanoid_torso') return c.rig === 'taur' || /upper body|torso/.test(t);
  if (part === 'crown' || part === 'crown_slot') return ROYAL.test(t);
  if (part === 'stinger') return /sting|scorpion|wasp|hornet|\bbee\b|manticore|hive/.test(t);
  if (part === 'multiple_arms') return /\barms\b/.test(t);
  if (part === 'hood') return /hood|cobra|naga|lamia|snake|hydra|gorgon/.test(t);
  if (part === 'rattle_tail') return /rattle|snake|viper/.test(t);
  if (part === 'lure') return /lure|angler/.test(t);
  if (part === 'gear_joints') return /gear|clockwork|machin|iron|brass|mithril|starmetal|boiler|wrench|bolt|trap|spring|gremlin/.test(t);
  return true;
}

// ---------- selection ----------
function hashRng(str) {
  let h = 2166136261;
  for (let i = 0; i < str.length; i++) h = Math.imul(h ^ str.charCodeAt(i), 16777619);
  return () => {
    h = (h + 0x6D2B79F5) | 0;
    let t = Math.imul(h ^ (h >>> 15), 1 | h);
    t = (t + Math.imul(t ^ (t >>> 7), 61 | t)) ^ t;
    return ((t ^ (t >>> 14)) >>> 0) / 4294967296;
  };
}
function findPlan(text, rig, fam) {
  return PLANS.find(p => (!p.rig || p.rig.includes(rig)) && (!p.fam || p.fam.includes(fam)) && (!p.re || p.re.test(text)));
}
const MAX_PARTS = 5;

/**
 * @param {object} o  { id, coreName, signature, familyKey, type, rig, rigPool, count }
 *                    count: how many parts to aim for (2-4); the text may ask for more (up to MAX_PARTS).
 */
function chooseParts(o) {
  const text = coreText(o.coreName, o.signature);
  const sigText = coreText('', o.signature);
  const plan = findPlan(text, o.rig, o.familyKey);
  const ctx = { text, rig: o.rig, fam: o.familyKey, type: o.type };
  const basePool = plan ? plan.pool : o.rigPool;
  const known = new Set([...basePool, ...o.rigPool]);
  const must = [];
  const add = p => { if (p && !must.includes(p)) must.push(p); };
  let t = text, s = sigText;
  for (const f of FEATURES) {
    const src = f.sig ? s : t;
    if (!f.re.test(src)) continue;
    if (f.any.length) add(f.any.find(p => known.has(p)) || f.any[0]);
    for (const p of f.also || []) add(p);
    if (f.consume) { t = t.replace(f.re, ' '); s = s.replace(f.re, ' '); }
  }
  for (const p of (plan && plan.must) || []) add(p);
  // An elemental variant named for thorns grows them (Thorn Forest Wolf).
  if (o.name && /^(thorn|bramble|briar) /i.test(o.name)) add('thorns');
  const rng = hashRng(o.id);
  const optional = basePool.filter(p => !must.includes(p) && allowed(p, ctx) && !(o.rig === 'blob' && p === 'face_decal'));
  for (let i = optional.length - 1; i > 0; i--) { const j = Math.floor(rng() * (i + 1)); [optional[i], optional[j]] = [optional[j], optional[i]]; }
  const target = Math.max(Math.min(o.count, must.length + optional.length), Math.min(must.length, MAX_PARTS));
  // Slimes get no face decal: the creature artist adds a small mouth instead.
  const out = must.slice(0, MAX_PARTS).concat(optional).slice(0, target);
  return o.rig === 'blob' ? out.filter(p => p !== 'face_decal') : out;
}

module.exports = { chooseParts, allowed, coreText, FEATURES, PLANS };
