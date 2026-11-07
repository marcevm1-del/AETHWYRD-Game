// Builds Data/World/labyrinth.json: the first and only data list of the Great Labyrinth's 120 floors (Wave F-lite,
// upgrade v10 section 13). The authored tables below restate what Canon and the lore already say, with the source
// beside each; nothing here is a new design.
//   node Tools/atlas/build_labyrinth_registry.js          write the file
//   node Tools/atlas/build_labyrinth_registry.js --check  exit 1 if the file on disk differs
//
// Sources:
//   floors 120, 3 depth bands, regions        Canon section 2 table, regions.json (reg_labyrinth_upper / _deep / _abyss)
//   12 biome decades with rank ranges         10_World/world.md, "THE GREAT LABYRINTH" table
//   a guardian floor on every tenth floor     10_World/gazetteer.md (Floors 1-40), world.md
//   safe towns on floors 30 and 40            gazetteer.md (Floors 1-40); world.md says "every 10 floors" (see world_graph.md, proposal WF4)
//   deep floors have camps, not towns         gazetteer.md (Floors 41-90); camp floors are inferred to be the guardian floors
//   camps on the abyss guardian floors        gazetteer.md (Floors 91-120): "camps on the guardian floors", the Rememberer's Camp on floor 100
//   B licence below floor 40, SS below 90     gazetteer.md ("only B-rank and above are licensed"), regions.json rankMin of the deep and abyss bands
//   hidden floors 101-110, secret 111-120     world.md ("Hall of Heroes (hidden)", "The Loom (secret)")
//   back-doors on floors 30 / 60 / 90         world.md (Underworld entrances table: "Labyrinth back-doors, hidden on floors 30/60/90, 3";
//                                             "connected to layers 3-5 by secret passages"); the pairing 30->3, 60->4, 90->5 is inferred
//   landmarks                                 gazetteer.md landmark and hook lines
//   dungeons.json floors                      cross-linked by the validator, not copied
const fs = require('fs');
const path = require('path');

const ROOT = path.join(__dirname, '..', '..');
const OUT = path.join(ROOT, 'Data', 'World', 'labyrinth.json');
const regions = JSON.parse(fs.readFileSync(path.join(ROOT, 'Data', 'World', 'regions.json'), 'utf8'));
const tuning = JSON.parse(fs.readFileSync(path.join(ROOT, 'Data', 'World', 'world_tuning.json'), 'utf8'));
const dungeons = JSON.parse(fs.readFileSync(path.join(ROOT, 'Data', 'World', 'dungeons.json'), 'utf8'));
const reg = id => regions.find(r => r.id === id);

const BANDS = [
  { id: 'upper', regionId: 'reg_labyrinth_upper', floors: [1, 40], licenceRank: 'F', settlement: 'towns' },
  { id: 'deep', regionId: 'reg_labyrinth_deep', floors: [41, 90], licenceRank: 'B', settlement: 'camps' },
  { id: 'abyss', regionId: 'reg_labyrinth_abyss', floors: [91, 120], licenceRank: 'SS', settlement: 'camps' }
].map(b => {
  const r = reg(b.regionId);
  return { ...b, name: r.name, rankMin: r.rankMin, rankMax: r.rankMax, ring: r.ring };
});

const DECADES = [
  ['Stone maze', 'F', 'D'], ['Sunken temple', 'D', 'C'], ['Fungal swamp', 'C', 'C'], ['Bone cathedral', 'C', 'B'],
  ['Lava fields', 'B', 'A'], ['Frozen ocean', 'A', 'A'], ['Mirror world', 'A', 'S'], ['Clockwork Titan machinery', 'S', 'S'],
  ['Void edge', 'S', 'SS'], ["Inside the Titan's heart", 'SS', 'SS'], ['Hall of Heroes', 'SS+', 'SS+'], ['The Loom', 'EX', 'EX']
].map(([biome, rankMin, rankMax], i) => {
  const d = { floors: [i * 10 + 1, i * 10 + 10], biome, rankMin, rankMax };
  if (i === 10) d.hidden = true;
  if (i === 11) d.secret = true;
  return d;
});

const SAFE = { 30: ['town', 'gazetteer'], 40: ['town', 'gazetteer'], 50: ['camp', 'inferred'], 60: ['camp', 'inferred'], 70: ['camp', 'inferred'], 80: ['camp', 'inferred'], 90: ['camp', 'inferred'], 100: ['camp', 'gazetteer'] };
const LANDMARKS = {
  30: ["the dwarven brewers' tavern", 'a cavern with clean water'],
  40: ['the ghost market'],
  55: ['the Sunken City (floors 55-58)'], 56: ['the Sunken City'], 57: ['the Sunken City'], 58: ['the Sunken City'],
  66: ['the Inverted Forest'],
  72: ['the upside-down library'],
  100: ["the Rememberer's Camp"],
  120: ['the Door at One-Twenty']
};
const BACK_DOORS = [[30, 3, 'reg_aurumdeep'], [60, 4, 'reg_the_maw'], [90, 5, 'reg_root_of_the_world']];

const floors = [];
for (let n = 1; n <= 120; n++) {
  const band = BANDS.find(b => n >= b.floors[0] && n <= b.floors[1]);
  const dec = DECADES[Math.floor((n - 1) / 10)];
  const f = {
    id: 'flr_' + String(n).padStart(3, '0'), n, band: band.id, biome: dec.biome, rankMin: dec.rankMin, rankMax: dec.rankMax,
    guardian: n % 10 === 0
  };
  if (SAFE[n]) { f.safe = SAFE[n][0]; f.safeSource = SAFE[n][1]; }
  if (dec.hidden) f.hidden = true;
  if (dec.secret) f.secret = true;
  const lm = LANDMARKS[n] ? LANDMARKS[n].slice() : [];
  const ds = dungeons.filter(d => (d.floors || []).includes(n)).map(d => d.id);
  if (ds.length) { f.dungeonIds = ds; }
  if (lm.length) f.landmarks = lm;
  floors.push(f);
}

const stairs = [];
for (let n = 1; n < 120; n++) {
  const s = { id: `stair_${String(n).padStart(3, '0')}_${String(n + 1).padStart(3, '0')}`, from: n, to: n + 1 };
  const next = BANDS.find(b => b.floors[0] === n + 1);
  if (next) s.licenceRank = next.licenceRank;
  if (n === 100 || n === 110) s.hidden = true; // the way into the hidden Hall of Heroes and the secret Loom
  stairs.push(s);
}

const out = {
  version: 1,
  note: 'Generated by Tools/atlas/build_labyrinth_registry.js; do not edit by hand. Docs: 12_Systems/world_graph.md.',
  id: 'great_labyrinth',
  entrance: { regionId: 'reg_aldmere', text: 'Beneath Aldmere City, guarded by the Guild', mapAt: reg('reg_labyrinth_upper').map.at },
  floorCount: 120,
  resets: 'weekly',
  startHeard: tuning.map.startHeard.includes('reg_labyrinth_upper') ? [1] : [],
  bands: BANDS,
  decades: DECADES,
  floors,
  stairs,
  backDoors: BACK_DOORS.map(([floor, layer, regionId]) => ({
    id: 'bd_' + String(floor).padStart(3, '0'), floor, layer, regionId, hidden: true, pairing: 'inferred'
  }))
};
const text = JSON.stringify(out, null, 1) + '\n';
if (process.argv.includes('--check')) {
  const cur = fs.existsSync(OUT) ? fs.readFileSync(OUT, 'utf8') : '';
  if (cur.split('\r\n').join('\n') !== text) { console.error('labyrinth.json is out of date: run node Tools/atlas/build_labyrinth_registry.js'); process.exit(1); }
  console.log('labyrinth.json is up to date');
} else {
  fs.writeFileSync(OUT, text);
  console.log(`labyrinth.json: ${floors.length} floors, ${stairs.length} stairs, ${out.backDoors.length} back-doors`);
}
