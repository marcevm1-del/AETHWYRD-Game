---
type: monster
id: mon_varos_herald_of_the_red_gate
family: "Demons"
rank: "A+"
tier: core
tags: [monster, demons, tyrant, unique]
---
# Varos, Herald of the Red Gate

> The Varos, Herald of the Red Gate is a large creature with a lean humanoid frame, about 3 m tall. Its hide is patchy and subtly wrong, as if assembled from memory, colored in starless black with faint violet edges. Guild sketches always show a demon who steps out of every Gate that opens in Haneul's towns. It has pale, pupil-less eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It moves in jerky stop-motion bursts, surrounded by warped air, as if space bends around it.

| Field | Value |
|---|---|
| Family · type | [[Families/Demons|Demons]] · Demon |
| Rank · level | A+ · 159 (146–173) |
| Menace | 4 · Dread |
| Element · weakness | Void · Light |
| Size | 3 m |
| Behaviour | Guardian (guardian_hold+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 28876 · 775 · 646 · 517 · 581 · 100 |
| XP · gold | 199864 · 1815 |
| Ring | 5 |
| Habitats | [[Regions/Haneul\|Haneul]] |
| Tyrant | Yes |
| Genre | Abyssal |
| Trope | Demons as a people of the Abyss, not just evil (Frieren, Maoyuu) |

**Field note:** Weak to Light. Protects something nearby: a nest, a treasure, or a place.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slash | melee | 1 | 0 s | None | blue |
| Heavy Swing | melee | 1.6 | 6 s | None | red |
| Guard Counter | counter | 1.3 | 10 s | None | blue |
| Hellfire Brand | magic | 1.4 | 10 s | None | red |
| Null Rift | magic | 1.5 | 10 s | Void | red |

## Loot (`loot_demon_a`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Demon Core\|Demon Core]] | 60% | 1–3 |
| [[Items/Horn Shard\|Horn Shard]] | 30% | 1–1 |
| [[Items/Brimstone\|Brimstone]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `demon_hide_emissive` · VFX `void_distortion` · palette `#0b0b1a` `#3d2c8d` `#c9c9ff` · elongated, irregular silhouette; still-then-sudden timing
