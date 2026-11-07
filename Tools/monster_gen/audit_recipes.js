// AETHWYRD — designRecipe audit.
// Usage (from the project root):  node Tools/monster_gen/audit_recipes.js [--all] [--strict]
// Reads Data/Monsters/species.json and flags recipes whose parts disagree with the species:
//   CONTRA  a part implies anatomy or gear the species should not have
//           (antlers on a wolf, wings on a walker, a sword on an animal, a cloak on a beast...)
//   MISSING the name/signature mentions a feature (horn, tusk, mane, wings, tail, crown, mask, cloak,
//           spikes, shell, fins...) but no part in the recipe builds it.
// The rules here are written independently of the generator (part_rules.js) so they act as a check on it.
// --all prints every finding, not just examples. --strict exits 1 if anything is flagged.
const fs = require('fs');
const path = require('path');

const ROOT = path.join(__dirname, '..', '..');
const species = JSON.parse(fs.readFileSync(path.join(ROOT, 'Data', 'Monsters', 'species.json'), 'utf8'));
const byId = Object.fromEntries(species.map(s => [s.id, s]));
const args = new Set(process.argv.slice(2));

// Text the audit reads: the species' own name plus the core species' name and signature
// (a variant keeps its core's anatomy: a Frost Forest Wolf is still a wolf).
function textOf(s) {
  const base = byId[s.baseSpeciesId] || s;
  return `${s.name} ${base.name} ${base.signature || ''}`.toLowerCase();
}
const sigOf = s => ((byId[s.baseSpeciesId] || s).signature || '').toLowerCase();

const G = {
  horn: ['horns', 'horn_single', 'horns_small', 'horns_swept', 'horn_crown'],
  wing: ['wing_membrane', 'membrane_wings', 'wing_feathers', 'wing_cases'],
  tail: ['tail', 'tail_thin', 'tail_bushy', 'tail_club', 'tail_blade', 'tail_spike', 'rattle_tail', 'tail_plumes', 'stinger'],
  crown: ['crown', 'crown_slot', 'horn_crown'],
  mask: ['mask', 'mask_face', 'human_mask', 'empty_visor', 'face_decal'],
  cloth: ['cloak', 'tattered_cape', 'tattered_shroud', 'loincloth'],
  armor: ['armor_plates', 'plate_armor', 'crude_armor', 'barding', 'armored_back', 'scales_armored', 'carapace_ridges', 'spine_plates', 'scale_ridges'],
  weapon: ['weapon_socket', 'club_socket', 'lance'],
  spike: ['leg_spikes', 'joint_spikes', 'armored_back', 'spine_plates', 'crystal_growths', 'thorns', 'horn_crown', 'tail_spike'],
  shell: ['scales_armored', 'armored_back', 'carapace_ridges', 'wing_cases', 'plate_armor'],
  fin: ['fins', 'fins_sail'],
  mane: ['mane', 'hair_mane'],
  fang: ['fangs', 'fangs_long', 'teeth_rows', 'teeth_ring'],
  chain: ['chains', 'chain_belt']
};
const has = (parts, group) => parts.some(p => group.includes(p));

// Body types that are animals or animal-like: no weapons, clothes or masks unless the text says so.
const BEAST_TYPES = new Set(['Beast', 'Insectoid', 'Reptile', 'Avian', 'Aquatic', 'Plant', 'Ooze', 'Mythic Beast', 'Cursed Beast', 'Familiar', 'Dragon', 'Desert Beast']);
const FLYER_RIGS = new Set(['wyvern', 'dragon', 'avian', 'flyer_small']);
// Horns are plausible on these without the text saying "horn".
const HORNED = /\b(oni|kijin|demon|devil|satyr|minotaur|dragon|drake|wyrm|wyvern|behemoth|imp|gargoyle|chimera|basilisk|qilin|unicorn|bull)\b/;

const CONTRA = [
  ['antlers without antlers in the text', s => s.parts.includes('antlers') && !/antler/.test(s.text)],
  ['horns on a hornless species', s => has(s.parts, G.horn) && !/\bhorn(s|ed)?\b/.test(s.text) && !HORNED.test(s.text) && s.familyKey !== 'demon' && s.familyKey !== 'draconic' && !(s.parts.includes('horn_crown') && /crown/.test(s.text))],
  ['tusks on a tuskless species', s => s.parts.includes('tusks') && !/tusk|\borcs?\b|ogre|troll|boar|\bhog|swine|behemoth|mammoth/.test(s.text)],
  ['wings on a non-flyer', s => has(s.parts, G.wing) && !FLYER_RIGS.has(s.rig) && !/wing|griffon|hippogriff|pegasus|beetle|weevil|mantis|chimera|sphinx|manticore|\bbat|moth|drake|seraph/.test(s.text)],
  ['wing cases on a wingless arthropod', s => s.parts.includes('wing_cases') && /\bant\b|\bants\b|crab|scorpion|centipede|spider|guard/.test(s.text) && !/beetle|weevil/.test(s.text)],
  ['weapon on an animal', s => has(s.parts, G.weapon) && BEAST_TYPES.has(s.type) && !/sword|blade|axe|club|spear|lance|bow\b|staff|wrench|hammer|scythe|knife|knives|trident|fan\b|labrys|pistol|banner|standard/.test(sigOf(s))],
  ['clothing or mask on a beast', s => (has(s.parts, G.cloth) || s.parts.some(p => ['mask', 'mask_face', 'human_mask'].includes(p))) && BEAST_TYPES.has(s.type) && !/cloak|cape|robe|mask|cloth|wrap|shroud|mycelium/.test(sigOf(s))],
  ['made armor on a beast', s => s.parts.some(p => ['armor_plates', 'plate_armor', 'crude_armor', 'barding'].includes(p)) && BEAST_TYPES.has(s.type) && !/armor|barding|plate/.test(sigOf(s))],
  ['armored back / club tail on a furred or feathered animal', s => (s.parts.includes('armored_back') || s.parts.includes('tail_club')) && /coat|fur|plumage|feather|horse/.test(s.covering + ' ' + s.text) && !/plate|armor|shell|ridge|stone|behemoth|brick/.test(s.text)],
  ['humanoid torso on a non-taur', s => s.parts.includes('humanoid_torso') && s.rig !== 'taur' && !/upper body|torso/.test(s.text)],
  ['crown on an uncrowned species', s => s.parts.some(p => ['crown', 'crown_slot'].includes(p)) && !/crown|king|queen|sovereign|emperor|empress|prince/.test(s.text)],
  ['stinger on a stingless species', s => s.parts.includes('stinger') && !/sting|scorpion|wasp|hornet|\bbee\b|manticore/.test(s.text)],
  ['extra arms without arms in the text', s => s.parts.includes('multiple_arms') && !/arms/.test(s.text)],
  ['snake hood on a non-snake', s => s.parts.includes('hood') && !/hood|cobra|naga|lamia|snake|hydra|gorgon|serpent/.test(s.text)],
  ['rattle on a non-snake', s => s.parts.includes('rattle_tail') && !/rattle|snake|viper|naga|lamia|hydra|gorgon|serpent/.test(s.text)],
  ['angler lure on a non-angler', s => s.parts.includes('lure') && !/lure|angler/.test(s.text)],
  ['mechanical gears on a stone or flesh body', s => s.parts.includes('gear_joints') && !/gear|clockwork|machin|iron|brass|mithril|starmetal|boiler|wrench|bolt|trap/.test(s.text)]
];

// [label, regex on the name+signature, acceptable parts, regex that cancels it (simile or carried item)]
const MENTIONS = [
  ['horn', /\bhorn(s|ed)?\b/, G.horn.concat(['antlers']), /horn carved from|a horn\b.*\btusk/],
  ['antler', /antler/, ['antlers']],
  ['tusk', /tusk/, ['tusks'], /horn carved from an ogre/],
  ['mane', /\bmane\b/, G.mane],
  ['wings', /\bwing(s|ed)?\b/, G.wing],
  ['tail', /\btail(s|ed)?\b/, G.tail, null, s => ['naga', 'serpent', 'fish'].includes(s.rig)],
  ['crown', /\bcrown(ed)?\b/, G.crown.concat(['horns', 'crystal_growths', 'stone_growths', 'cap'])],
  ['mask', /\bmask\b/, G.mask, /mask-like|like a [a-z ]*mask/],
  ['cloak/cape/robe', /\b(cloak|cape|robes?|shroud|mantle)\b/, G.cloth.concat(['moss_cover', 'trailing_wisps'])],
  ['spikes', /\bspikes?\b|spiked|stalactite/, G.spike.concat(['stone_growths', 'crown', 'horns'])],
  ['shell', /\bshell\b/, G.shell, /shell of|hollow shell/],
  ['fins', /\bfins?\b/, G.fin],
  ['fangs', /\bfangs?\b|sabre/, G.fang],
  ['tentacles', /tentacle/, ['tentacles']],
  ['stinger', /sting(er|ers)?\b/, ['stinger', 'horn_crown']],
  ['lantern', /lantern|\blamp\b/, ['lantern_core'], /lantern lights/],
  ['chains', /\bchain(s|ed)?\b/, G.chain],
  ['armor', /\barmou?r(ed)?\b|\bplate\b|plated|plating/, G.armor, /lance-like|armored wings/],
  ['weapon', /sword|blade|\baxe\b|club|spear|\blance\b|\bbow\b|staff|wrench|hammer|scythe|knives|trident|labrys|pistol/, G.weapon.concat(['claws', 'leg_spikes']), /blades for hands|like curved scythes|lance-like|bow of red glass/],
  ['eyes (many)', /eight eyes|cloud of eyes|too many eyes/, ['eye_cluster', 'eye_clusters']],
  ['beak', /\bbeak\b/, ['beak_hooked', 'beak']],
  ['mandibles', /mandible/, ['mandibles']],
  ['thorns', /thorn/, ['thorns']],
  ['many arms', /four arms|arms holding/, ['multiple_arms', 'extra_arms']],
  ['upper body', /upper body|humanoid torso/, ['humanoid_torso']],
  ['cap', /\bcap\b|mushroom/, ['cap']],
  ['carried head', /head carried|carried under/, ['head_carried']],
  ['mount', /saddle|\bmount\b/, ['mount']],
  ['lure', /\blure\b/, ['lure']],
  ['whiskers', /whisker/, ['whiskers', 'whiskers_long']],
  ['gears', /\bgears?\b/, ['gear_joints']],
  ['frill/crest', /frill|\bcrest\b/, ['neck_frill', 'crest', 'horn_crown']]
];

const findings = [];
for (const sp of species) {
  const s = { ...sp, parts: sp.designRecipe.parts, rig: sp.rigId.replace(/^rig_/, ''), text: textOf(sp), covering: sp.designRecipe.material || '' };
  const text = `${sp.name} ${sigOf(sp)}`.toLowerCase();
  for (const [label, test] of CONTRA) if (test(s)) findings.push({ kind: 'CONTRA', label, sp });
  for (const [label, re, accept, cancel, exempt] of MENTIONS) {
    if (!re.test(text) || (cancel && cancel.test(text)) || (exempt && exempt(s))) continue;
    if (!has(s.parts, accept)) findings.push({ kind: 'MISSING', label, sp });
  }
}

const fams = {};
for (const f of findings) {
  const k = f.sp.familyKey;
  fams[k] = fams[k] || { CONTRA: 0, MISSING: 0, species: new Set() };
  fams[k][f.kind]++; fams[k].species.add(f.sp.id);
}
const total = k => findings.filter(f => f.kind === k).length;
const flaggedSpecies = new Set(findings.map(f => f.sp.id)).size;
console.log(`designRecipe audit: ${species.length} species, ${flaggedSpecies} flagged · contradictions ${total('CONTRA')} · missing ${total('MISSING')}`);
console.log('\nPer family (contradictions / missing / species flagged):');
for (const [k, v] of Object.entries(fams).sort((a, b) => (b[1].CONTRA + b[1].MISSING) - (a[1].CONTRA + a[1].MISSING)))
  console.log(`  ${k.padEnd(16)} ${String(v.CONTRA).padStart(4)} / ${String(v.MISSING).padStart(4)} / ${v.species.size}`);
const byLabel = {};
for (const f of findings) (byLabel[`${f.kind} ${f.label}`] = byLabel[`${f.kind} ${f.label}`] || []).push(f.sp);
console.log('\nBy rule:');
for (const [k, list] of Object.entries(byLabel).sort((a, b) => b[1].length - a[1].length)) {
  const ex = (args.has('--all') ? list : list.slice(0, 4)).map(s => `${s.name} [${s.designRecipe.parts.join(', ')}]`).join('; ');
  console.log(`  ${String(list.length).padStart(4)}  ${k}: ${ex}`);
}
const SPOT = ['Forest Wolf', 'Wild Boar', 'Sabretooth King', 'Werewolf', 'Goblin', 'Horned Rabbit', 'Thunderhorn Elk', 'Jackalope'];
console.log('\nSpotlight:');
for (const n of SPOT) {
  const sp = species.find(s => s.name === n);
  if (!sp) continue;
  const fl = findings.filter(f => f.sp === sp).map(f => `${f.kind} ${f.label}`);
  console.log(`  ${n.padEnd(16)} [${sp.designRecipe.parts.join(', ')}]${fl.length ? '  <- ' + fl.join('; ') : ''}`);
}
if (args.has('--strict') && findings.length) process.exit(1);
