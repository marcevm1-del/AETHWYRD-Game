// Upgrade v4 (Canon-safe subset) validator: Data/World/living_world.json and the NPC schedules in Data/NPCs/npcs.json.
// Rules: events only use the four safe effect kinds (schema enum); regions are surface regions; small encounters use ordinary species
// (never a unique or Tyrant) that live in the event's region; shop and item ids exist; weekdays are real; no event text talks about
// war, sieges, destruction or ownership; NPC schedules use real day parts and weekdays and name a place.
const fs = require('fs');
const path = require('path');

const FORBIDDEN = /\b(war|siege|besiege|destroy|destroyed|raze|razed|conquer|conquered|takeover|take over|owner|ownership|succession|coup)\b/i;
const PARTS = ['morning', 'day', 'dusk', 'night'];

exports.run = function (ctx) {
  const { DATA, load, check, schema, err, regions, species, items, npcs } = ctx;
  const F = 'World/living_world.json';
  if (!fs.existsSync(path.join(DATA, F))) { err(F, 'file missing'); return; }
  const lw = load(F);
  check(lw, schema('living_world'), F);
  const surface = new Set(regions.filter(r => r.layer === 'surface').map(r => r.id));
  const wt = load('World/world_tuning.json');
  const weekdays = new Set(wt.calendar.weekdays);
  const shops = new Map(load('Items/shops.json').map(s => [s.id, s]));
  const ids = new Set();
  for (const e of lw.events.pool) {
    if (ids.has(e.id)) err(e.id, 'duplicate event id'); ids.add(e.id);
    for (const r of e.regions) if (!surface.has(r)) err(e.id, `${r} is not a surface region`);
    for (const d of e.weekdays || []) if (!weekdays.has(d)) err(e.id, `${d} is not a weekday of the calendar`);
    if (e.cooldownDays < e.durationDays) err(e.id, 'cooldownDays must be at least durationDays (an event never overlaps itself)');
    const texts = [e.name, e.text, ...e.effects.map(x => x.text)];
    for (const t of texts) if (FORBIDDEN.test(t)) err(e.id, `text mentions something events may not do: "${t.slice(0, 50)}"`);
    for (const x of e.effects) {
      if (x.kind === 'shop_stock') {
        if (!x.shopId || !shops.has(x.shopId)) err(e.id, 'shop_stock needs an existing shopId');
        if (!x.itemIds || !x.itemIds.length) err(e.id, 'shop_stock needs itemIds');
        for (const i of x.itemIds || []) if (!items.has(i)) err(e.id, `item ${i} does not exist`);
      }
      if (x.kind === 'small_encounter') {
        if (!x.speciesIds || !x.speciesIds.length) err(e.id, 'small_encounter needs speciesIds');
        for (const sid of x.speciesIds || []) {
          const s = species.get(sid);
          if (!s) { err(e.id, `species ${sid} does not exist`); continue; }
          if (s.isUnique || s.isTyrant) err(e.id, `${sid} is a unique or Tyrant: events place ordinary species only`);
          for (const r of e.regions) if (!(s.habitats || []).includes(r)) err(e.id, `${sid} does not live in ${r}`);
        }
      }
    }
  }
  const cats = new Set();
  for (const c of lw.journalCategories) { if (cats.has(c.id)) err(c.id, 'duplicate journal category'); cats.add(c.id); }
  // NPC schedules are optional data: when present they must be well formed
  for (const n of npcs) {
    const seen = new Set();
    for (const s of n.schedule || []) {
      if (!PARTS.includes(s.part)) err(n.id, `schedule part ${s.part}`);
      for (const d of s.days || []) if (!weekdays.has(d)) err(n.id, `schedule day ${d} is not a weekday`);
      const key = s.part + '|' + (s.days || []).join(',');
      if (seen.has(key)) err(n.id, `two schedule entries for ${key}`); seen.add(key);
    }
    if ((n.schedule || []).length && !n.settlement) err(n.id, 'an NPC with a schedule needs a settlement to fall back to');
  }
};
