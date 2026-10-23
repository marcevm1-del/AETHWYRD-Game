---
type: monster
id: mon_thorn_imp
family: "Demons"
rank: "E+"
tier: variant
tags: [monster, demons]
---
# Thorn Imp

> The Thorn Imp is a small creature with a bat-like flying frame, about 0.6 m tall. Its hide is weathered and natural, colored in leaf greens over bark brown. Guild sketches always show bat wings, a pointed tail and a cheeky grin. It has amber predator eyes. Small scars and rough edges mark it as a survivor. It prowls, surrounded by drifting pollen and tiny blossoms. This Nature-attuned variant carries one extra elemental feature, like a crest of elemental energy, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Demons|Demons]] · Demon |
| Variant of | [[Monsters/Demons/Imp\|Imp]] (elemental) |
| Rank · level | E+ · 32 (26–40) |
| Menace | 2 · Wild |
| Element · weakness | Nature · Fire |
| Size | 0.6 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1228 · 138 · 110 · 97 · 110 · 135 |
| XP · gold | 776 · 195 |
| Ring | 3 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Abyssal |
| Trope | Demons as a people of the Abyss, not just evil (Frieren, Maoyuu) |

**Field note:** Weak to Fire. Attacks on sight. Expect a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Nip | melee | 0.9 | 0 s | None | blue |
| Dart | dash | 1.1 | 4 s | None | blue |
| Swarm Call | summon | 0 | 20 s | None | none |
| Hellfire Brand | magic | 1.4 | 10 s | None | red |
| Thorn Volley | magic | 1.5 | 10 s | Nature | red |

## Loot (`loot_demon_e`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Demon Core\|Demon Core]] | 60% | 1–3 |
| [[Items/Horn Shard\|Horn Shard]] | 30% | 1–1 |
| [[Items/Brimstone\|Brimstone]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_flyer_small` · mesh `flyer_small_base` · material `demon_hide_emissive` · VFX `pollen_petals` · palette `#4caf50` `#a5d66f` `#3e2723` · real-animal silhouette with one fantasy exaggeration
