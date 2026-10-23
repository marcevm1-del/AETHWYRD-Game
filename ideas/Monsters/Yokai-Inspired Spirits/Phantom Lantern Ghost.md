---
type: monster
id: mon_phantom_lantern_ghost
family: "Yokai-Inspired Spirits"
rank: "E+"
tier: variant
tags: [monster, yokai-inspired-spirits]
---
# Phantom Lantern Ghost

> The Phantom Lantern Ghost is a small creature with a drifting, half-formed body, about 0.6 m tall. Its form is patchy and subtly wrong, as if assembled from memory, colored in warm gold and pearl white. Its most striking feature is a paper lantern with a torn mouth. It has eyes that never blink. Small scars and rough edges mark it as a survivor. It freezes whenever it is looked at, surrounded by soft radiance and floating motes of light. Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.

| Field | Value |
|---|---|
| Family · type | [[Families/Yokai-Inspired Spirits|Yokai-Inspired Spirits]] · Spirit |
| Variant of | [[Monsters/Yokai-Inspired Spirits/Lantern Ghost\|Lantern Ghost]] (spirit) |
| Rank · level | E+ · 32 (26–40) |
| Menace | 4 · Dread |
| Element · weakness | Light · Dark |
| Size | 0.6 m |
| Behaviour | Passive (passive_wander+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1156 · 83 · 97 · 193 · 179 · 90 |
| XP · gold | 776 · 195 |
| Ring | 6 |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Kitsune Isles\|Kitsune Isles]] |
| Genre | Japanese Folklore |
| Trope | Gentle and terrifying spirits (Natsume's Book of Friends, Mushishi, Inuyasha) |

**Field note:** Weak to Dark. Leaves you alone unless attacked.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Chill Touch | melee | 0.9 | 0 s | None | blue |
| Phase Lunge | dash | 1.3 | 7 s | None | red |
| Wail | aoe | 1.2 | 12 s | None | red |
| Spirit Flame | magic | 1.2 | 8 s | None | blue |
| Radiant Pulse | magic | 1.5 | 10 s | Light | red |

## Loot (`loot_yokai_e`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Spirit Paper\|Spirit Paper]] | 60% | 1–3 |
| [[Items/Fox Fire\|Fox Fire]] | 30% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `paper_ink_spirit` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · elongated, irregular silhouette; still-then-sudden timing
