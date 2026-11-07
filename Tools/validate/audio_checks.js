// Wave D validator rules for Data/Audio/*.json (schemas are checked here too). Mirrors Code/Ascend.Core
// AdaptiveMusic.cs, EnvironmentAudio.cs, Accessibility.cs and PhotoMode.cs; the Core tests are the full rule set.
// Canon: one rock stem and only in the boss state; companion themes only for the roster; every map terrain has a
// surface and a bed; no photo pose may carry a blocked (teen-rating) tag. Called from validate.js.
const fs = require('fs');
const path = require('path');

const MAP_TERRAIN = ['plains', 'forest', 'swamp', 'steppe', 'mountain', 'volcanic', 'tundra', 'desert', 'jungle', 'spirit', 'demon'];

function run({ DATA, load, check, schema, err, companionIds, regionTerrain }) {
  const exists = f => fs.existsSync(path.join(DATA, f));
  const files = ['Audio/music_states.json', 'Audio/environment_audio.json', 'Audio/accessibility.json', 'Audio/photo_mode.json'];
  for (const f of files) if (!exists(f)) { err(f, 'file missing'); return; }

  // music
  {
    const w = 'music_states.json', m = load('Audio/music_states.json');
    check(m, schema('music_states'), w);
    const layers = new Set(m.layers.map(l => l.id));
    if (layers.size !== m.layers.length) err(w, 'duplicate layer id');
    const ids = new Set(m.states.map(s => s.id));
    if (ids.size !== m.states.length) err(w, 'duplicate state id');
    for (const need of ['explore', 'town', 'rest', 'uncertainty', 'aftermath', 'combat', 'elite', 'boss', 'cutscene']) if (!ids.has(need)) err(w, `missing state ${need}`);
    if (!layers.has('companion_theme')) err(w, 'missing companion_theme layer');
    for (const s of m.states) {
      const used = [...Object.keys(s.layers || {}), ...(s.phaseLayers || []).flatMap(p => Object.keys(p))];
      for (const l of used) {
        if (!layers.has(l)) err(`${w}#${s.id}`, `unknown layer ${l}`);
        if (l === 'rock_lead' && s.id !== 'boss') err(`${w}#${s.id}`, 'the rock stem is boss-only (Canon: mostly instrumental)');
      }
      if (s.combatClass && !(s.exitDelaySeconds > 0 && s.minHoldSeconds > 0)) err(`${w}#${s.id}`, 'combat states need a minimum hold and an exit delay (hysteresis)');
      if (s.retreatExitDelaySeconds && s.retreatExitDelaySeconds < s.exitDelaySeconds) err(`${w}#${s.id}`, 'retreat exit must not be shorter than the normal exit');
      if (s.phaseLayers && s.phaseLayers.length && s.id !== 'boss') err(`${w}#${s.id}`, 'only the boss has phase layers');
    }
    const boss = m.states.find(s => s.id === 'boss');
    if (boss && !(boss.phaseLayers || []).length) err(w, 'boss needs phase layers');
    for (const k of Object.keys(m.crossfades)) {
      const [a, b] = k.split('>');
      if (!ids.has(a) || !ids.has(b)) err(w, `crossfade "${k}" names an unknown state`);
    }
    for (const o of ['advantage', 'danger']) for (const l of Object.keys(m.overlays[o].layers)) if (!layers.has(l)) err(w, `overlay ${o}: unknown layer ${l}`);
    if (!(m.overlays.danger.exitAboveHp > m.overlays.danger.enterBelowHp)) err(w, 'danger overlay needs exit HP above enter HP (hysteresis)');
    const roster = new Set(companionIds);
    for (const c of m.companionThemes) if (!roster.has(c)) err(w, `companion theme for ${c}, who is not in Data/Companions/companions.json`);
    if (new Set(m.companionThemes).size !== m.companionThemes.length) err(w, 'duplicate companion theme');
  }

  // environment
  const weatherIds = new Set();
  {
    const w = 'environment_audio.json', e = load('Audio/environment_audio.json');
    check(e, schema('environment_audio'), w);
    const surfaces = new Set(e.surfaces.map(s => s.id));
    if (surfaces.size !== e.surfaces.length) err(w, 'duplicate surface id');
    if (!surfaces.has(e.fallbackSurface)) err(w, 'fallbackSurface is not a surface');
    for (const t of MAP_TERRAIN) {
      if (!e.terrainSurface[t]) err(w, `terrain ${t} has no surface`);
      else if (!surfaces.has(e.terrainSurface[t])) err(w, `terrain ${t} maps to unknown surface ${e.terrainSurface[t]}`);
      if (!e.biomeBeds[t]) err(w, `terrain ${t} has no biome bed`);
    }
    for (const t of Object.keys(e.terrainSurface).concat(Object.keys(e.biomeBeds))) if (!MAP_TERRAIN.includes(t)) err(w, `unknown terrain kind ${t}`);
    for (const t of regionTerrain) if (!e.terrainSurface[t]) err(w, `regions.json uses terrain ${t}, which has no surface`);
    for (const wt of e.weather) weatherIds.add(wt.id);
    if (!weatherIds.has('clear')) err(w, 'weather needs a clear entry');
    for (const d of ['morning', 'day', 'dusk', 'night']) if (!e.timeOfDay[d]) err(w, `no ambience for ${d}`);
    const zones = new Set(e.reverbZones.map(z => z.id));
    if (!zones.has('open_air')) err(w, 'reverb zones need open_air');
    for (const z of e.reverbZones) {
      if (z.indoor && z.biomeBedGain > 0) err(`${w}#${z.id}`, 'an indoor zone must not play the biome bed');
      if (z.id !== 'open_air' && z.priority <= 0) err(`${w}#${z.id}`, 'only open_air may sit at priority 0');
    }
  }

  // accessibility
  {
    const w = 'accessibility.json', a = load('Audio/accessibility.json');
    check(a, schema('accessibility'), w);
    for (const p of ['off', 'protanopia', 'deuteranopia', 'tritanopia']) {
      const pal = a.palettes[p];
      if (!pal) { err(w, `missing palette ${p}`); continue; }
      if (new Set([pal.parry, pal.unblockable, pal.grab].map(c => c.toUpperCase())).size !== 3) err(`${w}#${p}`, 'the three telegraph colours must differ');
    }
    if (new Set(Object.values(a.telegraphShapes)).size !== Object.keys(a.telegraphShapes).length) err(w, 'telegraph shapes must differ');
    for (const need of ['parry', 'unblockable', 'grab']) if (!a.telegraphShapes[need]) err(w, `no telegraph shape for ${need}`);
  }

  // photo mode
  {
    const w = 'photo_mode.json', p = load('Audio/photo_mode.json');
    check(p, schema('photo_mode'), w);
    const ids = new Set();
    for (const pose of p.poses) {
      if (ids.has(pose.id)) err(w, `duplicate pose ${pose.id}`);
      ids.add(pose.id);
      for (const t of pose.tags) if (p.blockedTags.includes(t)) err(`${w}#${pose.id}`, `blocked tag ${t} (teen rating)`);
    }
    for (const need of ['suggestive', 'undress', 'gore']) if (!p.blockedTags.includes(need)) err(w, `blockedTags must include ${need}`);
    for (const need of ['combat', 'cutscene', 'siege_battle', 'dialogue']) if (!p.blockedWhen.includes(need)) err(w, `blockedWhen must include ${need}`);
    if (!p.filters.some(f => f.id === 'filter_none')) err(w, 'filters need filter_none');
    if (!p.frames.some(f => f.id === 'frame_none')) err(w, 'frames need frame_none');
    if (!(p.tuning.fovMin < p.tuning.fovMax && p.tuning.fovDefault >= p.tuning.fovMin && p.tuning.fovDefault <= p.tuning.fovMax)) err(w, 'fov range invalid');
  }
}

module.exports = { run, MAP_TERRAIN };
