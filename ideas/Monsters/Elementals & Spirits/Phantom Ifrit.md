---
type: monster
id: mon_phantom_ifrit
family: "Elementals & Spirits"
rank: "B+"
tier: variant
tags: [monster, elementals-spirits]
---
# Phantom Ifrit

> The Phantom Ifrit is a huge creature with a bodiless, glowing form, about 5 m tall. Its body is patchy and subtly wrong, as if assembled from memory, colored in warm gold and pearl white. Its most striking feature is a torso of fire rising from a smoking lamp. It has eyes set slightly too far apart. Faint runes glow along its body when it fights. It moves in jerky stop-motion bursts, surrounded by soft radiance and floating motes of light. Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.

| Field | Value |
|---|---|
| Family · type | [[Families/Elementals & Spirits|Elementals & Spirits]] · Elemental |
| Variant of | [[Monsters/Elementals & Spirits/Ifrit\|Ifrit]] (spirit) |
| Rank · level | B+ · 120 (108–132) |
| Menace | 4 · Dread |
| Element · weakness | Light · Dark |
| Size | 5 m |
| Behaviour | Passive (passive_wander+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 16297 · 294 · 343 · 686 · 637 · 90 |
| XP · gold | 6373 · 1225 |
| Ring | 5 |
| Habitats | [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Hoshizora\|Hoshizora]] |
| Genre | Spirit Realm |
| Trope | Spirits you can contract with; elemental kings |

**Field note:** Weak to Dark. Leaves you alone unless attacked.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Chill Touch | melee | 0.9 | 0 s | None | blue |
| Phase Lunge | dash | 1.3 | 7 s | None | red |
| Wail | aoe | 1.2 | 12 s | None | red |
| Elemental Burst | magic | 1.4 | 9 s | None | red |
| Radiant Pulse | magic | 1.5 | 10 s | Light | red |

## Loot (`loot_elemental_b`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Elemental Essence\|Elemental Essence]] | 60% | 1–3 |
| [[Items/Spirit Mote\|Spirit Mote]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `elemental_emissive` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · elongated, irregular silhouette; still-then-sudden timing
