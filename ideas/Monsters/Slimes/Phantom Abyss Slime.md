---
type: monster
id: mon_phantom_abyss_slime
family: "Slimes"
rank: "S+"
tier: variant
tags: [monster, slimes]
---
# Phantom Abyss Slime

> The Phantom Abyss Slime is a large creature with a wobbling mound of translucent gel, about 4 m tall. Its gel is stretched, stitched and constantly shifting, colored in warm gold and pearl white. Guild sketches always show starless black jelly that swallows all light. It has a human-like face in the wrong place. Its regal silhouette is crowned by a halo-like ring of aura. It copies the walk of whatever it hunts, surrounded by soft radiance and floating motes of light. Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Variant of | [[Monsters/Slimes/Abyss Slime\|Abyss Slime]] (spirit) |
| Rank · level | S+ · 203 (188–218) |
| Menace | 5 · Horror |
| Element · weakness | Light · Dark |
| Size | 4 m |
| Behaviour | Territorial (territorial_guard+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 29128 · 658 · 493 · 493 · 493 · 110 |
| XP · gold | 14769 · 2553 |
| Ring | 7 |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Sky Archipelago\|Sky Archipelago]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Dark. Attacks only if you come close to its home; back away to avoid a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Body Slam | melee | 1 | 0 s | None | blue |
| Engulf | grab | 1.4 | 8 s | None | gold |
| Split | summon | 0 | 20 s | None | none |
| Acid Splash | ranged | 1.1 | 6 s | None | blue |
| Radiant Pulse | magic | 1.5 | 10 s | Light | red |

## Loot (`loot_slime_s`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · broken symmetry, mimicry, audio-first reveal
