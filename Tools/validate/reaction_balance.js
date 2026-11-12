// Reaction balance guard for Data/Combat/reactions.json (12_Systems/combat.md section 7a, balance pass).
// "Extra value" of a reaction = damage beyond a plain hit, in multiples of the triggering hit, for ONE target:
//   (bonusDamageMult - 1) + Swirl spread (spreadDamageMult x targets) + dot (dps mult x seconds) + hazard (dps mult x seconds) + freeze shatter bonus (tuning).
// Run `node Tools/validate/reaction_balance.js` to print the table. Rules (all fail the validator):
//   1. TwilightBurst (rare, late-game, "huge") is the highest extra value of any reaction.
//   2. Every reaction except Grounded (a deliberate absorb) is worth at least 0.2 extra.
//   3. No synergy bonus exceeds 1.5 (synergies must not outgrow the reactions they combine).
//   4. Missing inputs are reported (NOT ASSESSED), never skipped silently.
const fs = require('fs');
const path = require('path');

function extraValue(r, tuning, swirl) {
  let v = (r.bonusDamageMult == null ? 1 : r.bonusDamageMult) - 1;
  if (r.dot) v += r.dot.damagePerSecMult * r.dot.durationSec;
  if (r.hazard) v += r.hazard.damagePerSecMult * r.hazard.durationSec;
  if (r.status && r.status.kind === 'freeze') v += ((tuning.reactions || {}).shatterBonus || 1) - 1;
  if (r.id === 'Swirl' && swirl) v += swirl.spreadDamageMult * swirl.maxSpreadTargets; // spread to neighbours (area value)
  return v;
}

function run({ DATA, load, err }) {
  const rf = 'Combat/reactions.json', tf = 'Combat/combat_tuning.json';
  if (!fs.existsSync(path.join(DATA, rf)) || !fs.existsSync(path.join(DATA, tf))) { err('reaction_balance', 'reactions.json or combat_tuning.json missing: balance NOT ASSESSED'); return; }
  const t = load(tf), file = load(rf), reactions = file.reactions || [], syn = file.synergies || [];
  const val = Object.fromEntries(reactions.map(r => [r.id, extraValue(r, t, file.swirl)]));
  const tw = val.TwilightBurst;
  if (tw == null) { err('reaction_balance', 'TwilightBurst missing: balance NOT ASSESSED'); return; }
  for (const [id, v] of Object.entries(val)) {
    if (id !== 'TwilightBurst' && v >= tw) err('reaction_balance#' + id, `extra value ${v.toFixed(2)} is not below TwilightBurst ${tw.toFixed(2)} (the rare late-game reaction must be the biggest)`);
    if (id !== 'Grounded' && v < 0.2 - 1e-9) err('reaction_balance#' + id, `extra value ${v.toFixed(2)} is under 0.2: not worth the setup`);
  }
  for (const s of syn) if (s.bonusDamageMult > 1.5) err('reaction_balance#' + s.id, `synergy bonus ${s.bonusDamageMult} is over 1.5`);
}

module.exports = { run, extraValue };

if (require.main === module) {
  const DATA = path.join(__dirname, '../../Data');
  const load = f => JSON.parse(fs.readFileSync(path.join(DATA, f), 'utf8'));
  const t = load('Combat/combat_tuning.json');
  const rf = load('Combat/reactions.json');
  for (const r of rf.reactions) console.log(r.id.padEnd(14), extraValue(r, t, rf.swirl).toFixed(2));
}
