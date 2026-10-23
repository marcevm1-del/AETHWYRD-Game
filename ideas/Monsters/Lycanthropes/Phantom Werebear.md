---
type: monster
id: mon_phantom_werebear
family: "Lycanthropes"
rank: "C+"
tier: variant
tags: [monster, lycanthropes]
---
# Phantom Werebear

> The Phantom Werebear is a large creature with an upright humanoid build, about 3 m tall. Its fur is patchy and subtly wrong, as if assembled from memory, colored in warm gold and pearl white. Look for tribal tattoos showing through thick bear fur. It has eyes that never blink. Battle-worn plates and trophies hang from its body. It glides without moving its legs, surrounded by soft radiance and floating motes of light. Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.

| Field | Value |
|---|---|
| Family · type | [[Families/Lycanthropes|Lycanthropes]] · Cursed Beast |
| Variant of | [[Monsters/Lycanthropes/Werebear\|Werebear]] (spirit) |
| Rank · level | C+ · 86 (76–96) |
| Menace | 4 · Dread |
| Element · weakness | Light · Dark |
| Size | 3 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 11544 · 425 · 354 · 283 · 319 · 100 |
| XP · gold | 3743 · 769 |
| Ring | 6 |
| Habitats | [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Hoshizora\|Hoshizora]] |
| Genre | Gothic Horror |
| Trope | Moon-cursed transformation horror |

**Field note:** Weak to Dark. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slash | melee | 1 | 0 s | None | blue |
| Heavy Swing | melee | 1.6 | 6 s | None | red |
| Guard Counter | counter | 1.3 | 10 s | None | blue |
| Moon Frenzy | buff | 0 | 20 s | None | none |
| Radiant Pulse | magic | 1.5 | 10 s | Light | red |

## Loot (`loot_lycan_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Cursed Fur\|Cursed Fur]] | 60% | 1–3 |
| [[Items/Silver-Bane Claw\|Silver-Bane Claw]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `fur_rough` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · elongated, irregular silhouette; still-then-sudden timing
