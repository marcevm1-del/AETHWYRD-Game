// Rules for Data/Player/difficulty.json and Data/Player/accessibility_presets.json (12_Systems/difficulty_and_accessibility.md).
// Canon: difficulty changes pressure and patterns before enemy health (preset enemy HP stays 1.0); nothing decays, charges upkeep or punishes
// absence; the S-rank floor (systems.md) only switches off difficulty assists, never accessibility. Called from validate.js.
const fs = require('fs');
const path = require('path');

function run({ DATA, load, check, schema, err }) {
  const D = 'Player/difficulty.json', A = 'Player/accessibility_presets.json', ACC = 'Audio/accessibility.json';
  for (const f of [D, A, ACC]) if (!fs.existsSync(path.join(DATA, f))) { err(f, 'file missing'); return; }
  const d = load(D), p = load(A), acc = load(ACC);
  check(d, schema('difficulty'), 'difficulty.json');
  check(p, schema('accessibility_presets'), 'accessibility_presets.json');
  const w = 'difficulty.json';

  const need = ['story', 'adventurer', 'veteran', 'hardcore'];
  for (const k of need) if (!d.presets[k]) err(w, `missing preset ${k}`);
  if (!d.presets[d.default]) err(w, `default preset "${d.default}" does not exist`);
  if (d.default !== 'adventurer') err(w, 'the default preset is adventurer (systems.md section 10)');

  // every preset value sits inside its slider range
  const sliderKeys = ['enemyDamageMult', 'enemyHpMult', 'enemyAggressionMult', 'telegraphLeadMult', 'maxSimultaneousAttackers', 'dodgeWindowMult', 'parryWindowMult', 'flashTimeDurationMult', 'lootMult'];
  for (const [id, pr] of Object.entries(d.presets)) {
    for (const key of sliderKeys) {
      const r = d.sliders[key];
      if (!r) { err(w, `no slider range for ${key}`); continue; }
      if (pr[key] < r[0] || pr[key] > r[1]) err(`${w}#${id}`, `${key} ${pr[key]} is outside its slider range ${r[0]} to ${r[1]}`);
    }
    // Canon: pressure and patterns before enemy health
    if (pr.enemyHpMult !== 1) err(`${w}#${id}`, 'presets keep enemyHpMult at 1 (difficulty changes pressure and patterns before enemy health; only the custom slider moves it)');
    if (pr.permadeath && !pr.mortalBonds) err(`${w}#${id}`, 'a permadeath preset turns Mortal Bonds on (Canon section 5)');
    if (!pr.permadeath && pr.mortalBonds) err(`${w}#${id}`, 'Mortal Bonds comes only with the permadeath preset here (Canon section 5: opt-in, Hardcore turns it on)');
  }
  for (const [k, r] of Object.entries(d.sliders)) if (!(r[0] < r[1])) err(w, `slider ${k} range must rise`);

  // ladder: each step is at least as hard as the one before
  for (let i = 1; i < need.length; i++) {
    const a = d.presets[need[i - 1]], b = d.presets[need[i]];
    if (!a || !b) continue;
    for (const k of ['enemyDamageMult', 'enemyAggressionMult', 'maxSimultaneousAttackers']) if (b[k] < a[k]) err(w, `${need[i]}.${k} is below ${need[i - 1]}`);
    for (const k of ['dodgeWindowMult', 'parryWindowMult', 'flashTimeDurationMult', 'telegraphLeadMult']) if (b[k] > a[k]) err(w, `${need[i]}.${k} is easier than ${need[i - 1]}`);
  }
  // death rules mirror Core (Code/Ascend.Core/Inventory.cs DeathRules)
  const dp = d.presets;
  if (dp.story && (dp.story.deathCopperFraction !== 0 || dp.story.deathXpFraction !== 0 || dp.story.permadeath)) err(w, 'Story deaths cost nothing');
  if (dp.adventurer && (dp.adventurer.deathCopperFraction !== 0.1 || dp.adventurer.deathXpFraction !== 0 || dp.adventurer.permadeath)) err(w, 'Adventurer drops 10% of carried coin only (Core DeathRules)');
  if (dp.veteran && (dp.veteran.deathCopperFraction !== 0.1 || dp.veteran.deathXpFraction !== 0.05 || dp.veteran.permadeath)) err(w, 'Veteran drops 10% coin and loses 5% of the XP toward the next level (Core DeathRules)');
  if (dp.hardcore && !dp.hardcore.permadeath) err(w, 'Hardcore is permadeath');
  for (const k of need) if (dp[k] && k !== 'hardcore' && dp[k].permadeath) err(w, `${k} must not be permadeath`);
  if (d.customRules.hardcoreLockedAtCreation !== true || d.customRules.permadeathOnlyFromHardcorePreset !== true) err(w, 'Hardcore is locked at creation and permadeath comes only from its preset (systems.md 10.2)');

  // S-rank floor: never easier than Adventurer, never touches accessibility
  const f = d.sRankFloor, base = dp.adventurer;
  if (base) {
    for (const [k, v] of Object.entries(f.min)) if (v < base[k]) err(w, `sRankFloor.min.${k} ${v} is below Adventurer ${base[k]}`);
    for (const [k, v] of Object.entries(f.max)) if (v > base[k]) err(w, `sRankFloor.max.${k} ${v} is above Adventurer ${base[k]}`);
    if (f.minAttackers < base.maxSimultaneousAttackers) err(w, 'sRankFloor.minAttackers is below Adventurer');
  }
  if (f.autoDodge !== false) err(w, 'auto-dodge switches off at the S-rank floor (systems.md)');
  for (const k of need) if (!f.profileNames[k]) err(w, `sRankFloor.profileNames has no entry for ${k}`);
  for (const keep of ['parryTimingIndicator', 'telegraphShapes', 'colorblindPalette', 'holdToggle']) if (!f.keepsAccessibility.includes(keep)) err(w, `the S-rank floor must keep ${keep} (accessibility is never a difficulty assist)`);
  const bad = /decay|upkeep|rent|wither|chore|spoil/i;
  if (bad.test((JSON.stringify(d).match(/"[^"]+":/g) || []).join(' '))) err(w, 'no decay, upkeep or chore keys (Canon Slow-Life)');

  // accessibility presets stay inside the accessibility ranges and only name real settings
  const pw = 'accessibility_presets.json';
  const settingKeys = Object.keys(acc.defaults);
  const rangeOf = { textScale: acc.ranges.textScale, hudScale: acc.ranges.hudScale, dialogueTextSpeed: acc.ranges.dialogueTextSpeed, screenShake: acc.ranges.screenShake, flashIntensity: acc.ranges.flashIntensity, motionBlur: acc.ranges.motionBlur };
  for (const [id, pr] of Object.entries(p.presets)) {
    const at = `${pw}#${id}`;
    for (const [k, v] of Object.entries(pr.settings)) {
      if (!settingKeys.includes(k)) { err(at, `"${k}" is not an accessibility setting`); continue; }
      if (rangeOf[k] && (v < rangeOf[k][0] || v > rangeOf[k][1])) err(at, `${k} ${v} is outside the range ${rangeOf[k][0]} to ${rangeOf[k][1]}`);
      if (k === 'colorblindPalette' && !acc.palettes[v]) err(at, `unknown palette ${v}`);
      if (k === 'subtitleSize' && !acc.subtitleSizes[v]) err(at, `unknown subtitle size ${v}`);
      if (k === 'subtitleBackground' && !acc.subtitleBackgrounds.includes(v)) err(at, `unknown subtitle background ${v}`);
      if (k === 'volumes') for (const [vk, vv] of Object.entries(v)) { if (!(vk in acc.defaults.volumes)) err(at, `unknown volume ${vk}`); else if (vv < 0 || vv > 1) err(at, `volume ${vk} out of range`); }
    }
    if (pr.settings.reducedFlash && pr.settings.flashIntensity !== undefined && pr.settings.flashIntensity > acc.reducedFlashCap) err(at, `reduced flash caps flashIntensity at ${acc.reducedFlashCap}`);
    if (pr.settings.subtitlesEnabled === false) err(at, 'a preset never turns subtitles off (speaker names always shown)');
  }
  for (const pair of p.pairings) {
    if (!d.presets[pair.with]) err(pw, `pairing names an unknown difficulty ${pair.with}`);
    for (const s of pair.suggest) if (!p.presets[s]) err(pw, `pairing suggests an unknown preset ${s}`);
  }
  if (!p.presets.one_handed || p.presets.one_handed.toggleAllHoldActions !== true) err(pw, 'the one_handed preset toggles every hold action (hud_and_ui.md section 14)');
  if (!p.presets.photosensitive || !p.presets.photosensitive.settings.reducedFlash) err(pw, 'the photosensitive preset turns reduced flash on');
  if (bad.test((JSON.stringify(p).match(/"[^"]+":/g) || []).join(' '))) err(pw, 'no decay, upkeep or chore keys (Canon Slow-Life)');
}

module.exports = { run };
