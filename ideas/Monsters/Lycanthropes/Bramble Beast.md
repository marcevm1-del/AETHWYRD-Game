---
type: monster
id: mon_bramble_beast
family: "Lycanthropes"
rank: "B-"
tier: variant
tags: [monster, lycanthropes]
---
# Bramble Beast

> The Bramble Beast is a large creature with a lean humanoid frame, about 2.8 m tall. Its fur is patchy and subtly wrong, as if assembled from memory, colored in leaf greens over bark brown. Survivors describe fur that ripples like oil under moonlight. It has eyes set slightly too far apart. Faint runes glow along its body when it fights. It freezes whenever it is looked at, surrounded by drifting pollen and tiny blossoms. This Nature-attuned variant carries one extra elemental feature, like glowing vein-lines, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Lycanthropes|Lycanthropes]] · Cursed Beast |
| Variant of | [[Monsters/Lycanthropes/Moon Beast\|Moon Beast]] (elemental) |
| Rank · level | B- · 96 (86–108) |
| Menace | 4 · Dread |
| Element · weakness | Nature · Fire |
| Size | 2.8 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 13286 · 473 · 394 · 315 · 355 · 100 |
| XP · gold | 4462 · 897 |
| Ring | 5 |
| Habitats | [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Hoshizora\|Hoshizora]] |
| Genre | Gothic Horror |
| Trope | Moon-cursed transformation horror |

**Field note:** Weak to Fire. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slash | melee | 1 | 0 s | None | blue |
| Heavy Swing | melee | 1.6 | 6 s | None | red |
| Guard Counter | counter | 1.3 | 10 s | None | blue |
| Moon Frenzy | buff | 0 | 20 s | None | none |
| Thorn Volley | magic | 1.5 | 10 s | Nature | red |

## Loot (`loot_lycan_b`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Cursed Fur\|Cursed Fur]] | 60% | 1–3 |
| [[Items/Silver-Bane Claw\|Silver-Bane Claw]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `fur_rough` · VFX `pollen_petals` · palette `#4caf50` `#a5d66f` `#3e2723` · elongated, irregular silhouette; still-then-sudden timing
