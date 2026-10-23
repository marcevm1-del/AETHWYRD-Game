---
type: monster
id: mon_briar_kijin_warrior
family: "Goblinoids"
rank: "A+"
tier: variant
tags: [monster, goblinoids]
---
# Briar Kijin Warrior

> The Briar Kijin Warrior is a person-sized creature with a broad-shouldered humanoid build, about 2.4 m tall. Its skin is rough, scarred and spiked, colored in leaf greens over bark brown. Survivors describe twin horns, a disciplined stance and a lacquered blade. It has narrow glowing eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It circles its prey, surrounded by drifting pollen and tiny blossoms. This Nature-attuned variant carries one extra elemental feature, like element-scarred hide, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Variant of | [[Monsters/Goblinoids/Kijin Warrior\|Kijin Warrior]] (elemental) |
| Rank · level | A+ · 159 (146–173) |
| Menace | 3 · Menacing |
| Element · weakness | Nature · Fire |
| Size | 2.4 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 26775 · 775 · 646 · 517 · 581 · 100 |
| XP · gold | 9993 · 1815 |
| Ring | 5 |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Hoshizora\|Hoshizora]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Fire. Attacks on sight. Expect a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slash | melee | 1 | 0 s | None | blue |
| Heavy Swing | melee | 1.6 | 6 s | None | red |
| Guard Counter | counter | 1.3 | 10 s | None | blue |
| Sand Toss | debuff | 0 | 12 s | None | none |
| Thorn Volley | magic | 1.5 | 10 s | Nature | red |

## Loot (`loot_goblinoid_a`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rough_skin_leather` · VFX `pollen_petals` · palette `#4caf50` `#a5d66f` `#3e2723` · triangle-based silhouette, sharp asymmetric spikes
