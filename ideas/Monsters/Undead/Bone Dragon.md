---
type: monster
id: mon_bone_dragon
family: "Undead"
rank: "S"
tier: core
tags: [monster, undead]
---
# Bone Dragon

> The Bone Dragon is a colossal creature with a vast quadruped dragon frame with cathedral wings, about 20 m long. Its flesh and bone are patchy and subtly wrong, as if assembled from memory, colored in ink black with bruised violet. Its most striking feature is a dragon skeleton held together by green fire. It has eyes that never blink. Its regal silhouette is crowned by a halo-like ring of aura. It freezes whenever it is looked at, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Rank · level | S · 188 (173–203) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 20 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 88149 · 991 · 914 · 991 · 914 · 100 |
| XP · gold | 13063 · 2293 |
| Ring | 8 |
| Habitats | [[Regions/Vesper\|Vesper]], [[Regions/Nox Dominion\|Nox Dominion]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Claw | melee | 1.4 | 0 s | None | blue |
| Breath | aoe | 2.2 | 14 s | None | red |
| Wing Gust | aoe | 1 | 10 s | None | blue |
| Tail Blade | melee | 1.8 | 8 s | None | red |
| Grave Grasp | grab | 1.2 | 10 s | None | gold |
| Shadow Grasp | magic | 1.5 | 10 s | Dark | red |

## Loot (`loot_undead_s`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Undead/Dawn Bone Dragon|Dawn Bone Dragon]]
- [[Monsters/Undead/Elder Bone Dragon|Elder Bone Dragon]]

## Design recipe

Rig `rig_dragon` · mesh `dragon_base` · material `rot_bone` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · elongated, irregular silhouette; still-then-sudden timing
