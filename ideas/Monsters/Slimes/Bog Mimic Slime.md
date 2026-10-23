---
type: monster
id: mon_bog_mimic_slime
family: "Slimes"
rank: "D+"
tier: variant
tags: [monster, slimes]
---
# Bog Mimic Slime

> The Bog Mimic Slime is a small creature with a dome-shaped gelatinous body, about 1 m tall. Its gel is patchy and subtly wrong, as if assembled from memory, colored in bruise purple with sickly green. Survivors describe a surface that ripples into the shape of whatever it last ate. It has eyes that never blink. A distinctive marking runs along its back. It moves in jerky stop-motion bursts, surrounded by a low toxic haze that clings to the ground. Adapted to swamp lands, it has mud-slick, algae-streaked skin.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Variant of | [[Monsters/Slimes/Mimic Slime\|Mimic Slime]] (regional) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 4 · Dread |
| Element · weakness | Poison · Light |
| Size | 1 m |
| Behaviour | Passive (passive_wander+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2682 · 187 · 140 · 140 · 140 · 110 |
| XP · gold | 1888 · 423 |
| Ring | 3 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Xochitl Mire\|Xochitl Mire]], [[Regions/Greymoor\|Greymoor]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Light. Leaves you alone unless attacked.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Body Slam | melee | 1 | 0 s | None | blue |
| Engulf | grab | 1.4 | 8 s | None | gold |
| Split | summon | 0 | 20 s | None | none |
| Acid Splash | ranged | 1.1 | 6 s | None | blue |
| Venom Spit | magic | 1.5 | 10 s | Poison | red |

## Loot (`loot_slime_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · elongated, irregular silhouette; still-then-sudden timing
