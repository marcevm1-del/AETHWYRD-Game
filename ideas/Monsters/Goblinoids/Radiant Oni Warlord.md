---
type: monster
id: mon_radiant_oni_warlord
family: "Goblinoids"
rank: "S+"
tier: variant
tags: [monster, goblinoids]
---
# Radiant Oni Warlord

> The Radiant Oni Warlord is a large creature with a giant, barrel-chested humanoid body, about 4.5 m tall. Its skin is rough, scarred and spiked, colored in warm gold and pearl white. Look for a towering horned silhouette carrying an iron club wrapped in prayer chains. It has burning slit pupils. Its regal silhouette is crowned by a halo-like ring of aura. It strides with heavy steps, surrounded by soft radiance and floating motes of light. This Light-attuned variant carries one extra elemental feature, like crystal spikes, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Variant of | [[Monsters/Goblinoids/Oni Warlord\|Oni Warlord]] (elemental) |
| Rank · level | S+ · 203 (188–218) |
| Menace | 3 · Menacing |
| Element · weakness | Light · Dark |
| Size | 4.5 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 60516 · 822 · 1233 · 493 · 822 · 70 |
| XP · gold | 14769 · 2553 |
| Ring | 5 |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Shen-Lu\|Shen-Lu]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Dark. Never alone. Kill the leader first and the rest may scatter.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Stomp | aoe | 1.3 | 6 s | None | red |
| Club Slam | melee | 1.8 | 8 s | None | red |
| Grab and Throw | grab | 2 | 14 s | None | gold |
| Sand Toss | debuff | 0 | 12 s | None | none |
| Radiant Pulse | magic | 1.5 | 10 s | Light | red |

## Loot (`loot_goblinoid_s`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `rough_skin_leather` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · triangle-based silhouette, sharp asymmetric spikes
