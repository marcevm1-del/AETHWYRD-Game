---
type: monster
id: mon_grove_werewolf
family: "Lycanthropes"
rank: "D+"
tier: variant
tags: [monster, lycanthropes]
---
# Grove Werewolf

> The Grove Werewolf is a person-sized creature with an upright humanoid build, about 2.2 m tall. Its fur is patchy and subtly wrong, as if assembled from memory, colored in leaf greens over bark brown. Guild sketches always show a wolf's head on a twisted human body, torn clothing still clinging. It has eyes set slightly too far apart. A distinctive marking runs along its back. It glides without moving its legs, surrounded by drifting pollen and tiny blossoms. Adapted to forest lands, it has moss-green coloring that blends with the undergrowth.

| Field | Value |
|---|---|
| Family · type | [[Families/Lycanthropes|Lycanthropes]] · Cursed Beast |
| Variant of | [[Monsters/Lycanthropes/Werewolf\|Werewolf]] (regional) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 4 · Dread |
| Element · weakness | Nature · Fire |
| Size | 2.2 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 5501 · 281 · 234 · 187 · 211 · 100 |
| XP · gold | 1888 · 423 |
| Ring | 3 |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Aldmere\|Aldmere]] |
| Genre | Gothic Horror |
| Trope | Moon-cursed transformation horror |

**Field note:** Weak to Fire. Attacks on sight. Expect a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slash | melee | 1 | 0 s | None | blue |
| Heavy Swing | melee | 1.6 | 6 s | None | red |
| Guard Counter | counter | 1.3 | 10 s | None | blue |
| Moon Frenzy | buff | 0 | 20 s | None | none |
| Thorn Volley | magic | 1.5 | 10 s | Nature | red |

## Loot (`loot_lycan_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Cursed Fur\|Cursed Fur]] | 60% | 1–3 |
| [[Items/Silver-Bane Claw\|Silver-Bane Claw]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `fur_rough` · VFX `pollen_petals` · palette `#4caf50` `#a5d66f` `#3e2723` · elongated, irregular silhouette; still-then-sudden timing
