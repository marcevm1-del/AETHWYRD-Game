---
type: monster
id: mon_phantom_harpy
family: "Avians"
rank: "D+"
tier: variant
tags: [monster, avians]
---
# Phantom Harpy

> The Phantom Harpy is a person-sized creature with a feathered avian body, about 1.6 m tall. Its plumage is patchy and subtly wrong, as if assembled from memory, colored in warm gold and pearl white. Its most striking feature is a bird body with a shrieking human-like face. It has eyes set slightly too far apart. A distinctive marking runs along its back. It moves in jerky stop-motion bursts, surrounded by soft radiance and floating motes of light. Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.

| Field | Value |
|---|---|
| Family · type | [[Families/Avians|Avians]] · Avian |
| Variant of | [[Monsters/Avians/Harpy\|Harpy]] (spirit) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 4 · Dread |
| Element · weakness | Light · Dark |
| Size | 1.6 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3812 · 234 · 187 · 164 · 187 · 135 |
| XP · gold | 1888 · 423 |
| Ring | 5 |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Kitsune Isles\|Kitsune Isles]] |
| Genre | High Fantasy |
| Trope | Griffons, harpies and phoenixes of classic fantasy |

**Field note:** Weak to Dark. Attacks on sight. Expect a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Peck | melee | 1 | 0 s | None | blue |
| Swoop | dash | 1.4 | 6 s | None | blue |
| Screech | debuff | 0 | 14 s | None | none |
| Feather Volley | ranged | 1 | 6 s | None | blue |
| Radiant Pulse | magic | 1.5 | 10 s | Light | red |

## Loot (`loot_avian_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Feather\|Feather]] | 60% | 1–3 |
| [[Items/Talon\|Talon]] | 30% | 1–1 |
| [[Items/Egg\|Egg]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_avian` · mesh `avian_base` · material `feather_groom` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · elongated, irregular silhouette; still-then-sudden timing
