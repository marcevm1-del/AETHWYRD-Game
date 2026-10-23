---
type: monster
id: mon_rain_hunger_colossus
family: "Yokai-Inspired Spirits"
rank: "A+"
tier: variant
tags: [monster, yokai-inspired-spirits]
---
# Rain Hunger Colossus

> The Rain Hunger Colossus is a colossal creature with a massive hunched brute frame, about 30 m tall. Its form is patchy and subtly wrong, as if assembled from memory, colored in deep blues with a glassy shine. Survivors describe a skeleton giant built from the bones of the starved. It has eyes that never blink. An elegant crest and glowing veins of mana mark it as a champion of its kind. It moves in jerky stop-motion bursts, surrounded by fine mist and droplets that orbit it. This Water-attuned variant carries one extra elemental feature, like crystal spikes, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Yokai-Inspired Spirits|Yokai-Inspired Spirits]] · Spirit |
| Variant of | [[Monsters/Yokai-Inspired Spirits/Hunger Colossus\|Hunger Colossus]] (elemental) |
| Rank · level | A+ · 159 (146–173) |
| Menace | 4 · Dread |
| Element · weakness | Water · Lightning |
| Size | 30 m |
| Behaviour | Territorial (territorial_guard+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 70446 · 646 · 969 · 388 · 646 · 70 |
| XP · gold | 9993 · 1815 |
| Ring | 6 |
| Habitats | [[Regions/Kitsune Isles\|Kitsune Isles]], [[Regions/Hoshizora\|Hoshizora]] |
| Genre | Japanese Folklore |
| Trope | Gentle and terrifying spirits (Natsume's Book of Friends, Mushishi, Inuyasha) |

**Field note:** Weak to Lightning. Attacks only if you come close to its home; back away to avoid a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Stomp | aoe | 1.3 | 6 s | None | red |
| Club Slam | melee | 1.8 | 8 s | None | red |
| Grab and Throw | grab | 2 | 14 s | None | gold |
| Spirit Flame | magic | 1.2 | 8 s | None | blue |
| Tide Lash | magic | 1.5 | 10 s | Water | red |

## Loot (`loot_yokai_a`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Spirit Paper\|Spirit Paper]] | 60% | 1–3 |
| [[Items/Fox Fire\|Fox Fire]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `paper_ink_spirit` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · elongated, irregular silhouette; still-then-sudden timing
