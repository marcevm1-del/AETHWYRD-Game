---
type: monster
id: mon_moss_slime
family: "Slimes"
rank: "E+"
tier: variant
tags: [monster, slimes]
---
# Moss Slime

> The Moss Slime is a small creature with a dome-shaped gelatinous body, about 0.5 m tall. Its gel is weathered and natural, colored in leaf greens over bark brown. Survivors describe a faint ember core pulsing like a heartbeat. It has dark, wary eyes. Small scars and rough edges mark it as a survivor. It stalks low to the ground, surrounded by drifting pollen and tiny blossoms. This Nature-attuned variant carries one extra elemental feature, like crystal spikes, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Variant of | [[Monsters/Slimes/Red Slime\|Red Slime]] (elemental) |
| Rank · level | E+ · 32 (26–40) |
| Menace | 2 · Wild |
| Element · weakness | Nature · Fire |
| Size | 0.5 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 962 · 110 · 83 · 83 · 83 · 110 |
| XP · gold | 776 · 195 |
| Ring | 3 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Fire. Leaves you alone unless attacked.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Body Slam | melee | 1 | 0 s | None | blue |
| Engulf | grab | 1.4 | 8 s | None | gold |
| Split | summon | 0 | 20 s | None | none |
| Acid Splash | ranged | 1.1 | 6 s | None | blue |
| Thorn Volley | magic | 1.5 | 10 s | Nature | red |

## Loot (`loot_slime_e`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `pollen_petals` · palette `#4caf50` `#a5d66f` `#3e2723` · real-animal silhouette with one fantasy exaggeration
