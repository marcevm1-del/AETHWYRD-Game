# Rune-word and enchantment skills (gear skills)

Data: `Data/Classes/rune_skills.json` (schema `rune_skills`, checks in `Tools/validate/validate.js`). Gear rules: `12_Systems/gear_and_runes.md`. Decided 2026-11-08 by Claude under delegated creative control; the user may overrule.

## Idea
A rune word or an enchantment already adds a small flat bonus. Each now also **teaches one extra skill while the gear is worn**. Same verb for every class ("do one extra thing"), but classes whose kit fits it get it as a natural fit (`affinityClasses`, a hint for the UI and for companions, not a lock). Any class may use any gear skill.

## Rules
- **One skill per fitting.** Four rune words and five scrolls give nine gear skills. Every rune word and enchantment must grant exactly one (the validator derives this from `gear_rules.json`, so a new word cannot ship without a skill).
- **Two gear-skill slots.** A loadout can slot at most `gearSkillSlots` (2) gear skills at once, beside the class kit. This keeps them a side option.
- **Small.** Total hit power at most 3 (class ultimates are 6-8); damaging gear skills have cooldown 5s or more; buffs are at most 15% and 8s; every skill costs SP or MP.
- **Quality, not luck.** Power and buff size scale with the fitting's quality `statMult` (a word uses its weakest rune). Nothing rolls, breaks or wears out.
- **Level gate.** `minLevel` 3-10, so early fittings (scrolls, Masterwork-Rare sockets) teach first and rune words (Epic gear) later, matching `gear_and_runes.md`.
- **Element.** An enchantment skill uses the enchantment's element (validated). A skill with `appliesElement` feeds the reaction system like any class skill.

## The nine skills
| Source | Skill | Kind | Cost / CD | Note |
|---|---|---|---|---|
| Forge-Oath (weapon) | Oathstrike | chain 1.0m + 1.8h | 14 SP / 8s | heavy second hit breaks a guard |
| Stonewatch (armour) | Stonewatch Stance | buff | 10 SP / 20s | -15% damage taken, 6s, no dash |
| Stormfast (accessory) | Stormfast Step | dash 0.8l, Wind | 12 SP / 7s | gust dash |
| Hearthfire (weapon) | Hearthfire Ring | aoe 2 x 0.7m, Fire | 16 MP / 12s | allies in the ring regain 4% HP over 5s |
| Emberbrand (weapon) | Emberbrand Slash | chain 1.2m, Fire | 10 SP / 6s | |
| Stormthread (weapon) | Stormthread Lance | ranged 1.1m, Lightning | 8 MP / 6s | |
| Wardweave (armour) | Ward Pulse | buff | 10 MP / 18s | shield 8% max HP, 5s |
| Vitality (armour/accessory) | Second Wind | utility | 12 SP / 30s | 8% max HP over 4s |
| Nightstep (armour/accessory) | Nightstep Slip | dash, no damage | 10 SP / 8s | next hit within 3s +5% crit |

Warmth over comedy: the healing and shield skills are as good as the damage ones; a support build is a real choice.

## Engine gaps (for the owning agents)
- **core-rules-engineer:** `GearFitter`/`GearFittings` does not yet return granted skill ids (a `GrantedSkills(loadout)` list from `rune_skills.json`), nor the two-slot limit, quality scaling or the `minLevel` gate. Old saves need no new field (skills derive from fittings).
- **gameplay-engineer:** Unity combat must read `rune_skills.json`, play the `gear_*` animation tags (new clips needed from animator-rigger) and show the two gear-skill slots; buff stats `damageTaken`, `shield`, `regenHp`, `crit` need handlers.
- **ux-designer / ui-engineer:** the socketing screen should show the skill a word or scroll will teach.
