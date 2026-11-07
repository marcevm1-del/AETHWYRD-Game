// Wave E validator rules for Data/World/dungeons.json and puzzles.json (schemas are checked here too).
// Mirrors Code/Ascend.Core/Dungeons.cs. Canon: puzzles are never a mandatory gate, dungeon cores are never allies,
// and a dungeon must have no soft-lock. Called from validate.js.
const fs = require('fs');
const path = require('path');

const BANDS = { reg_labyrinth_upper: [1, 40], reg_labyrinth_deep: [41, 90], reg_labyrinth_abyss: [91, 120] };
const RANK_ORDER = ['F', 'E', 'D', 'C', 'B', 'A', 'S', 'SS', 'SSS', 'EX'];
const rankVal = r => { const m = /^([A-Z]+)([+-]?)$/.exec(r || ''); return m ? RANK_ORDER.indexOf(m[1]) * 3 + (m[2] === '+' ? 1 : m[2] === '-' ? -1 : 0) : NaN; };

function plateSolvable(p) {
  const objs = p.objects || [], plates = p.plates || [];
  const total = plates.map(() => 0);
  const go = i => {
    if (i === objs.length) return plates.every((pl, k) => total[k] === pl.weight);
    for (let k = -1; k < plates.length; k++) {
      if (k >= 0) total[k] += objs[i].weight;
      const ok = go(i + 1);
      if (k >= 0) total[k] -= objs[i].weight;
      if (ok) return true;
    }
    return false;
  };
  return go(0);
}

function runeSolvable(p) {
  const g = p.glyphs.length, sc = p.sconces, idx = Object.fromEntries(sc.map((s, i) => [s.id, i]));
  const start = sc.map(s => p.glyphs.indexOf(s.start)), goal = sc.map(s => p.glyphs.indexOf(s.target));
  const key = a => a.join(',');
  const seen = new Set([key(start)]), q = [start];
  while (q.length) {
    if (seen.size > 250000) return false; // Core's search stops at the same cap, so the free assist would not work
    const cur = q.shift();
    if (key(cur) === key(goal)) return true;
    for (let i = 0; i < sc.length; i++) {
      const nx = cur.slice();
      for (const j of [i, ...(sc[i].also || []).map(x => idx[x])]) nx[j] = (nx[j] + 1) % g;
      if (!seen.has(key(nx))) { seen.add(key(nx)); q.push(nx); }
    }
  }
  return false;
}

const isOptionalEdge = c => !!(c.requiresPuzzle || c.revealedByClue || c.kind === 'secret');

function edgesOf(d) {
  const edges = [];
  for (const c of d.connections) { edges.push({ c, from: c.from, to: c.to }); if (!c.oneWay) edges.push({ c, from: c.to, to: c.from }); }
  return edges;
}

// Explores (room, keys) states from a start state. optional=false drops puzzle-gated and secret connections.
function explore(d, optional, startState) {
  const roomKeys = Object.fromEntries(d.rooms.map(r => [r.id, r.keys || []]));
  const grant = (room, keys) => { const k = new Set(keys); for (const x of roomKeys[room]) k.add(x); return [...k].sort(); };
  const keyOf = s => s.room + '|' + s.keys.join(',');
  const edges = edgesOf(d);
  const start = startState || { room: d.entryRoom, keys: grant(d.entryRoom, []) };
  const seen = new Map([[keyOf(start), start]]);
  const q = [start];
  while (q.length) {
    const s = q.shift();
    for (const e of edges) {
      if (e.from !== s.room) continue;
      if (e.c.requiresKey && !s.keys.includes(e.c.requiresKey)) continue;
      if (!optional && isOptionalEdge(e.c)) continue;
      const n = { room: e.to, keys: grant(e.to, s.keys) };
      if (!seen.has(keyOf(n))) { seen.set(keyOf(n), n); q.push(n); }
    }
  }
  return seen;
}

function canReach(d, s, optional, target) {
  return [...explore(d, optional, s).values()].some(x => x.room === target);
}

function run({ DATA, load, check, schema, err: rawErr, items, species, regions }) {
  let n = 0; // errors so far: lets a dungeon or puzzle skip its graph and search checks once its references are broken
  const err = (w, m) => { n++; rawErr(w, m); };
  const pPath = path.join(DATA, 'World/puzzles.json'), dPath = path.join(DATA, 'World/dungeons.json');
  const puzzles = {};
  if (fs.existsSync(pPath)) {
    const pf = load('World/puzzles.json');
    check(pf, schema('puzzles'), 'puzzles.json');
    for (const p of pf.puzzles || []) {
      const w = 'puzzles.json#' + p.id;
      if (puzzles[p.id]) err(w, 'duplicate puzzle id');
      puzzles[p.id] = p;
      if (p.reward && !items.has(p.reward.itemId)) err(w, `reward item "${p.reward.itemId}" does not exist`);
      if (p.type === 'lever_sequence') {
        if (!p.levers || !p.sequence) { err(w, 'lever_sequence needs levers and sequence'); continue; }
        if (new Set(p.levers).size !== p.levers.length) err(w, 'duplicate lever id');
        if (!p.sequence.length) err(w, 'empty sequence (unsolvable)');
        for (const s of p.sequence) if (!p.levers.includes(s)) err(w, `sequence names unknown lever "${s}"`);
      } else if (p.type === 'pressure_plate') {
        if (!p.plates || !p.objects) { err(w, 'pressure_plate needs plates and objects'); continue; }
        if (!p.plates.length) err(w, 'no plates (unsolvable)');
        else if (!plateSolvable(p)) err(w, 'no assignment of the objects gives every plate its exact weight (unsolvable)');
      } else if (p.type === 'rune_match') {
        if (!p.glyphs || !p.sconces) { err(w, 'rune_match needs glyphs and sconces'); continue; }
        const ids = new Set(p.sconces.map(s => s.id));
        const n0 = n;
        if (ids.size !== p.sconces.length) err(w, 'duplicate sconce id');
        for (const s of p.sconces) {
          if (!p.glyphs.includes(s.start) || !p.glyphs.includes(s.target)) err(w, `sconce ${s.id} uses a glyph not in glyphs`);
          for (const a of s.also || []) if (!ids.has(a)) err(w, `sconce ${s.id} also-turns unknown sconce "${a}"`);
        }
        if (n > n0) continue;
        if (!p.sconces.some(s => s.start !== s.target)) err(w, 'already solved at the start');
        else if (!runeSolvable(p)) err(w, 'the target pattern cannot be reached within the 250,000-state search cap (unsolvable or too large for the free assist)');
      }
    }
  }
  if (!fs.existsSync(dPath)) return;
  const list = load('World/dungeons.json');
  if (!Array.isArray(list)) return err('dungeons.json', 'top level must be an array');
  const seenD = new Set(), puzzleRoom = {};
  for (const d of list) {
    const w = 'dungeons.json#' + d.id;
    check(d, schema('dungeon'), w);
    if (seenD.has(d.id)) err(w, 'duplicate dungeon id');
    seenD.add(d.id);
    const region = regions.find(r => r.id === d.regionId);
    if (!region) { err(w, `unknown region "${d.regionId}"`); continue; }
    const band = BANDS[d.regionId];
    if (band && (d.floors || []).some(f => f < band[0] || f > band[1])) err(w, `floors must stay inside the band ${band[0]}-${band[1]}`);
    const rooms = new Map();
    for (const r of d.rooms || []) { if (rooms.has(r.id)) err(w, `duplicate room "${r.id}"`); rooms.set(r.id, r); }
    if (!rooms.has(d.entryRoom)) { err(w, `entryRoom "${d.entryRoom}" is not a room`); continue; }
    if (!rooms.get(d.entryRoom).checkpoint) err(w, 'the entry room must be a checkpoint');
    const n0 = n;
    const rankCap = rankVal(region.rankMax);
    const allKeys = new Set(), conns = new Set(), clueIds = new Set((d.clues || []).map(c => c.id));
    for (const r of d.rooms || []) {
      for (const k of r.keys || []) allKeys.add(k);
      const ids = [...(r.spawns || []).map(s => s.speciesId), ...(r.boss ? [r.boss.speciesId] : [])];
      for (const sp of r.spawns || []) if (sp.min > sp.max) err(`${w}.${r.id}`, `spawn ${sp.speciesId}: min is above max`);
      for (const sid of ids) {
        const s = species.get(sid);
        if (!s) { err(`${w}.${r.id}`, `unknown species "${sid}"`); continue; }
        if (!(s.habitats || []).includes(d.regionId)) err(`${w}.${r.id}`, `${sid} does not live in ${d.regionId}`);
        if (rankVal(s.rank) > rankCap) err(`${w}.${r.id}`, `${sid} (${s.rank}) is above the region's top rank ${region.rankMax}`);
      }
      if (r.role === 'boss' && !r.boss) err(`${w}.${r.id}`, 'boss room needs a boss slot');
      if (r.boss && r.role !== 'boss') err(`${w}.${r.id}`, 'a boss slot needs role "boss"');
      if (r.boss && (r.keys || []).length) err(`${w}.${r.id}`, 'a boss room holds no keys');
      for (const pid of r.puzzles || []) {
        if (!puzzles[pid]) err(`${w}.${r.id}`, `unknown puzzle "${pid}"`);
        if (puzzleRoom[pid]) err(`${w}.${r.id}`, `puzzle ${pid} is already placed in ${puzzleRoom[pid]}`);
        puzzleRoom[pid] = `${d.id}/${r.id}`;
      }
    }
    for (const c of d.connections || []) {
      if (conns.has(c.id)) err(w, `duplicate connection "${c.id}"`);
      conns.add(c.id);
      if (!rooms.has(c.from) || !rooms.has(c.to)) err(`${w}.${c.id}`, 'connects an unknown room');
      if (c.from === c.to) err(`${w}.${c.id}`, 'connects a room to itself');
      if (c.requiresKey && !allKeys.has(c.requiresKey)) err(`${w}.${c.id}`, `key "${c.requiresKey}" is never found in this dungeon`);
      if (c.requiresPuzzle && !puzzles[c.requiresPuzzle]) err(`${w}.${c.id}`, `unknown puzzle "${c.requiresPuzzle}"`);
      if (c.requiresPuzzle && !(d.rooms || []).some(r => (r.puzzles || []).includes(c.requiresPuzzle))) err(`${w}.${c.id}`, `puzzle ${c.requiresPuzzle} is not in any room of this dungeon`);
      if (c.revealedByClue && !clueIds.has(c.revealedByClue)) err(`${w}.${c.id}`, `unknown clue "${c.revealedByClue}"`);
      if (c.kind === 'secret' && !c.revealedByClue) err(`${w}.${c.id}`, 'a secret connection needs revealedByClue');
    }
    for (const cl of d.clues || []) {
      if (!rooms.has(cl.roomId)) err(`${w}.${cl.id}`, `clue in unknown room "${cl.roomId}"`);
      if (cl.reveals && !puzzles[cl.reveals] && !conns.has(cl.reveals)) err(`${w}.${cl.id}`, `reveals unknown puzzle or connection "${cl.reveals}"`);
    }
    if (n > n0) continue; // broken references: report them, skip the graph checks
    // Canon: nothing optional may be mandatory.
    const req = explore(d, false), full = explore(d, true);
    const reqRooms = new Set([...req.values()].map(s => s.room)), fullRooms = new Set([...full.values()].map(s => s.room));
    for (const r of d.rooms || []) {
      if (!fullRooms.has(r.id)) err(`${w}.${r.id}`, 'room cannot be reached even with every puzzle solved and every secret found');
      else if (!reqRooms.has(r.id) && !r.secret) err(`${w}.${r.id}`, 'reachable only through a puzzle or secret but not marked "secret": optional content must not hide a required room');
      if (r.secret && reqRooms.has(r.id)) err(`${w}.${r.id}`, 'marked secret but reachable without finding the secret');
      if (r.secret && ((r.keys || []).length || r.boss)) err(`${w}.${r.id}`, 'a secret room holds no key and no boss');
    }
    for (const r of (d.rooms || []).filter(r => r.role === 'boss')) if (!reqRooms.has(r.id)) err(`${w}.${r.id}`, 'the boss room must be reachable without any puzzle or secret');
    for (const c of d.connections || []) {
      if (!isOptionalEdge(c)) continue;
      const to = rooms.get(c.to) || {}, from = rooms.get(c.from) || {};
      const bothReq = reqRooms.has(c.from) && reqRooms.has(c.to);
      if (!bothReq && !to.secret && !from.secret) err(`${w}.${c.id}`, 'puzzle-gated connection leads somewhere the player cannot otherwise reach: a puzzle must never be the only way on');
    }
    // No soft-lock: from every reachable state the entry (the way out) and the boss room can still be reached.
    const boss = (d.rooms || []).find(r => r.role === 'boss');
    for (const [mode, states, opt] of [['required path', req, false], ['all optional done', full, true]]) {
      for (const s of states.values()) {
        if (!canReach(d, s, opt, d.entryRoom)) { err(w, `soft-lock (${mode}): in ${s.room} holding [${s.keys}] the player cannot get back to the entry`); break; }
        if (boss && !canReach(d, s, opt, boss.id)) { err(w, `soft-lock (${mode}): in ${s.room} holding [${s.keys}] the player cannot reach the boss room`); break; }
      }
    }
  }
  for (const pid of Object.keys(puzzles)) if (!puzzleRoom[pid]) err('puzzles.json#' + pid, 'puzzle is not placed in any dungeon room');
}

module.exports = { run };
