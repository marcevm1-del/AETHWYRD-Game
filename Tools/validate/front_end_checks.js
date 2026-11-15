// Phase 1B validator rules: Data/Characters/player_appearance.json and Data/UI/loading_tips.json. Called from validate.js.
const fs = require('fs');
const path = require('path');

// The Core defaults (Code/Ascend.Core/PlayerAppearance.cs AppearanceDefaults); a Core test checks the same ids.
const DEFAULTS = { hairStyles: 'short', hairColours: 'chestnut', skinTones: 'fair', outfitColours: 'azure' };

function run({ DATA, load, check, schema, err }) {
  const exists = f => fs.existsSync(path.join(DATA, f));
  for (const f of ['Characters/player_appearance.json', 'UI/loading_tips.json']) if (!exists(f)) { err(f, 'file missing'); return; }
  {
    const w = 'player_appearance.json', a = load('Characters/player_appearance.json');
    check(a, schema('player_appearance'), w);
    for (const k of ['hairStyles', 'hairColours', 'skinTones', 'outfitColours', 'bodies']) {
      const ids = (a[k] || []).map(x => x.id);
      if (new Set(ids).size !== ids.length) err(w, `duplicate id in ${k}`);
      if (k in DEFAULTS && !ids.includes(DEFAULTS[k])) err(w, `${k} must contain the Core default "${DEFAULTS[k]}"`);
    }
    const bodies = (a.bodies || []).map(b => b.id);
    for (const need of ['masculine', 'feminine']) if (!bodies.includes(need)) err(w, `missing body ${need}`);
    if (a.defaultName && a.defaultName.length > a.maxNameLength) err(w, 'defaultName longer than maxNameLength');
    for (const n of a.suggestedNames || []) if (n.length > a.maxNameLength) err(w, `suggested name "${n}" too long`);
  }
  {
    const w = 'loading_tips.json', t = load('UI/loading_tips.json');
    check(t, schema('loading_tips'), w);
    const ids = (t.tips || []).map(x => x.id);
    if (new Set(ids).size !== ids.length) err(w, 'duplicate tip id');
  }
}
module.exports = { run };
