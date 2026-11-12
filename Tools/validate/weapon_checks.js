// Rules for Data/Combat/weapon_movesets.json beyond the schema (12_Systems/weapon_movesets.md, combat.md section 13).
// Coverage is DERIVED from Data/Classes/classes.json: a weapon type or class added there without a family is an error,
// and a missing input file is reported, never silently skipped.
const fs = require('fs');
const path = require('path');
const ROLES = ['opener', 'punish', 'spacing', 'crowd_control', 'payoff'];
const total = h => h.startupSec + h.activeSec + h.recoverySec;

function run({ DATA, load, check, schema, err }) {
  const f = 'Combat/weapon_movesets.json';
  if (!fs.existsSync(path.join(DATA, f))) { err(f, 'file missing (weapon movesets NOT ASSESSED)'); return; }
  const classesPath = path.join(DATA, 'Classes/classes.json');
  if (!fs.existsSync(classesPath)) { err(f, 'Classes/classes.json missing: coverage NOT ASSESSED'); return; }
  const wf = load(f), classes = load('Classes/classes.json');
  check(wf, schema('weapon_movesets'), 'weapon_movesets.json');
  const kit = new Map(), types = new Set();
  for (const c of classes) { kit.set(c.id, new Set((c.kit || []).map(s => s.id))); for (const w of c.weapons || []) types.add(w); }
  const ids = new Set(), covered = new Set(), coveredClass = new Set();
  for (const fam of wf.families || []) {
    const w = 'weapon_movesets.json#' + fam.id;
    if (ids.has(fam.id)) err(w, 'duplicate family id'); ids.add(fam.id);
    for (const t of fam.weaponTypes || []) { if (!types.has(t)) err(w, `weaponType "${t}" is not a weapon of any class in classes.json`); covered.add(t); }
    for (const c of fam.classes || []) { if (!kit.has(c)) err(w, `unknown class ${c}`); coveredClass.add(c); }
    const byRole = {};
    for (const m of fam.moves || []) {
      if (byRole[m.role]) err(w, `two moves for role ${m.role}`); byRole[m.role] = m;
      if (m.skillId && !(fam.classes || []).some(c => kit.has(c) && kit.get(c).has(m.skillId))) err(`${w}.${m.name}`, `skillId ${m.skillId} is not in the kit of any class of this family`);
    }
    for (const r of ROLES) if (!byRole[r]) err(w, `missing role ${r}`);
    const { opener, punish, spacing, crowd_control: cc, payoff } = byRole;
    if (opener && punish && spacing && cc && payoff) {
      const o = opener.hits[0];
      if (o.startupSec > 0.35) err(w, `opener starts in ${o.startupSec}s: too slow for a reliable first hit (max 0.35)`);
      if (punish.hits[0].startupSec > 0.2) err(w, `punish starts in ${punish.hits[0].startupSec}s: must fit a recovery window (max 0.2)`);
      const last = payoff.hits[payoff.hits.length - 1];
      if (total(last) < 1.5 * total(o)) err(w, `payoff last hit (${total(last).toFixed(2)}s) must carry at least 1.5x the commitment of the opener first hit (${total(o).toFixed(2)}s)`);
      if (!(Math.abs(spacing.moveM) >= 1.5 || Math.max(...spacing.hits.map(h => h.reachM)) >= 4 || ['push', 'slow'].includes(spacing.control))) err(w, 'spacing move must move the player 1.5 m, work from 4 m or more, or push/slow');
      if (!(cc.control !== 'none' || Math.max(...cc.hits.map(h => h.arcDeg)) >= 180)) err(w, 'crowd_control move needs a control effect or an arc of 180 degrees or more');
    }
  }
  for (const t of types) if (!covered.has(t)) err(f, `weapon type "${t}" (classes.json) has no family`);
  for (const c of kit.keys()) if (!coveredClass.has(c)) err(f, `class ${c} has no weapon family`);
}
module.exports = { run };
