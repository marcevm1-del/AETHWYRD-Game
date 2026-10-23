---
type: monster
id: mon_vesper_touched_poison_slime
family: "Slimes"
rank: "D-"
tier: variant
tags: [monster, slimes]
---
# Vesper-Touched Poison Slime

> The Vesper-Touched Poison Slime is a small creature with a dome-shaped gelatinous body, about 0.6 m tall. Its gel is patchy and subtly wrong, as if assembled from memory, colored in bruise purple with sickly green. Survivors describe purple bubbles that hiss when they pop. It has eyes that never blink. A distinctive marking runs along its back. It glides without moving its legs, surrounded by a low toxic haze that clings to the ground. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Variant of | [[Monsters/Slimes/Poison Slime\|Poison Slime]] (corrupted) |
| Rank · level | D- · 40 (32–48) |
| Menace | 4 · Dread |
| Element · weakness | Poison · Light |
| Size | 0.6 m |
| Behaviour | Territorial (territorial_guard+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1399 · 136 · 102 · 102 · 102 · 110 |
| XP · gold | 1106 · 265 |
| Ring | 3 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Moraveil\|Moraveil]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Light. Attacks only if you come close to its home; back away to avoid a fight.

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
