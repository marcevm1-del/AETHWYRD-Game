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
// Mounted combat (Combat/mounted_combat.json): derived coverage against mounts.json families and the weapon families above.
function runMounted({ DATA, load, check, schema, err }) {
  const f = 'Combat/mounted_combat.json';
  const need = [f, 'Companions/mounts.json', 'Combat/weapon_movesets.json', 'Combat/combat_tuning.json'];
  for (const n of need) if (!fs.existsSync(path.join(DATA, n))) { err(f, `${n} missing: mounted combat NOT ASSESSED`); return; }
  const mc = load(f), mounts = load('Companions/mounts.json'), wf = load('Combat/weapon_movesets.json'), t = load('Combat/combat_tuning.json');
  check(mc, schema('mounted_combat'), 'mounted_combat.json');
  const base = mounts.mountedCombat || {};
  const fams = Object.keys(mounts.families || {});
  for (const k of fams) if (!(k in (mc.familyPoiseMult || {}))) err(f, `mount family "${k}" has no familyPoiseMult`);
  for (const k of Object.keys(mc.familyPoiseMult || {})) if (!fams.includes(k)) err(f, `familyPoiseMult "${k}" is not a ground mount family in mounts.json (no flying, celestial, dragon or aquatic mounts)`);
  const wfIds = new Map((wf.families || []).map(x => [x.id, x]));
  for (const id of wfIds.keys()) if (!(id in (mc.weaponFamilies || {}))) err(f, `weapon family ${id} has no mounted rule`);
  for (const [id, r] of Object.entries(mc.weaponFamilies || {})) {
    const fam = wfIds.get(id);
    if (!fam) { err(f, `weaponFamilies "${id}" is not a family in weapon_movesets.json`); continue; }
    if (!r.allowed && (r.maxChainHits !== 0 || r.reachCapM !== 0)) err(`${f}#${id}`, 'a banned family must have maxChainHits 0 and reachCapM 0');
    if (r.allowed && !(r.maxChainHits >= 1 && r.maxChainHits <= (base.maxChainHits || 3))) err(`${f}#${id}`, `maxChainHits ${r.maxChainHits} must be 1..${base.maxChainHits} (mounts.json mountedCombat.maxChainHits)`);
    const maxReach = Math.max(...fam.moves.flatMap(m => m.hits.map(h => h.reachM)));
    if (r.allowed && r.reachCapM > maxReach) err(`${f}#${id}`, `reachCapM ${r.reachCapM} is more than the weapon can reach (${maxReach})`);
    if (r.allowed && r.reachCapM > (base.meleeReachCapM || 2.5) && maxReach <= 8 && !/exception|reach|wide|swing/i.test(r.note)) err(`${f}#${id}`, 'a melee family above the base reach cap must say why in its note');
  }
  const d = mc.mountedDodge || {}, dd = t.dodge || {};
  if (d.iframeSec >= dd.iframeSec) err(f, `mountedDodge.iframeSec ${d.iframeSec} must be below the rider dodge ${dd.iframeSec} (a mount is clumsier)`);
  if (d.distanceM > dd.distance) err(f, 'mountedDodge.distanceM must not exceed the rider dodge distance');
  if ((mc.trample || {}).maxTargetPoise > (t.poise || {}).medium_biped) err(f, 'trample may only knock aside targets up to medium_biped poise');
  if ((mc.charge || {}).minSpeedMps > (mounts.speedMps || {}).value) err(f, 'charge.minSpeedMps is above the base mount speed: no mount could charge');
}
module.exports = { run, runMounted };
