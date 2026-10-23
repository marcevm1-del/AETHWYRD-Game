---
type: monster
id: mon_ancient_lich
family: "Undead"
rank: "S"
tier: variant
tags: [monster, undead]
---
# Ancient Lich

> The Ancient Lich is a large creature with a drifting, half-formed body, about 3.3 m tall. Its flesh and bone are patchy and subtly wrong, as if assembled from memory, colored in pale blues and frost-white. Look for a crowned skull with a phylactery chained to its chest. It has eyes that never blink. Its regal silhouette is crowned by a halo-like ring of aura. It freezes whenever it is looked at, surrounded by falling snow motes and frosted ground where it steps. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Lich\|Lich]] (ancient) |
| Rank · level | S · 188 (173–203) |
| Menace | 4 · Dread |
| Element · weakness | Ice · Fire |
| Size | 3.3 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 27855 · 457 · 533 · 1067 · 991 · 90 |
| XP · gold | 13063 · 2293 |
| Ring | 8 |
| Habitats | [[Regions/Vesper\|Vesper]], [[Regions/Nox Dominion\|Nox Dominion]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Fire. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Chill Touch | melee | 0.9 | 0 s | None | blue |
| Phase Lunge | dash | 1.3 | 7 s | None | red |
| Wail | aoe | 1.2 | 12 s | None | red |
| Grave Grasp | grab | 1.2 | 10 s | None | gold |
| Frost Breath | magic | 1.5 | 10 s | Ice | red |

## Loot (`loot_undead_s`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `rot_bone` · VFX `frost_trail_snow` · palette `#bfe9ff` `#5fa8d3` `#f4fbff` · elongated, irregular silhouette; still-then-sudden timing
