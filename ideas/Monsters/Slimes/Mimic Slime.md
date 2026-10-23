---
type: monster
id: mon_mimic_slime
family: "Slimes"
rank: "D"
tier: core
tags: [monster, slimes]
---
# Mimic Slime

> The Mimic Slime is a small creature with a wobbling mound of translucent gel, about 1 m tall. Its gel is patchy and subtly wrong, as if assembled from memory, colored in muted greys and dusty browns. Survivors describe a surface that ripples into the shape of whatever it last ate. It has eyes that never blink. A distinctive marking runs along its back. It glides without moving its legs. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Rank · level | D · 48 (40–56) |
| Menace | 4 · Dread |
| Element · weakness | None · Fire |
| Size | 1 m |
| Behaviour | Territorial (territorial_guard+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2137 · 162 · 121 · 85 · 121 · 110 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Fire. Attacks only if you come close to its home; back away to avoid a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Body Slam | melee | 1 | 0 s | None | blue |
| Engulf | grab | 1.4 | 8 s | None | gold |
| Split | summon | 0 | 20 s | None | none |
| Acid Splash | ranged | 1.1 | 6 s | None | blue |

## Loot (`loot_slime_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Slimes/Bog Mimic Slime|Bog Mimic Slime]]
- [[Monsters/Slimes/Sky Mimic Slime|Sky Mimic Slime]]

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · elongated, irregular silhouette; still-then-sudden timing
