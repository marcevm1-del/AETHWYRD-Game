---
type: monster
id: mon_brine_crow
family: "Avians"
rank: "F+"
tier: variant
tags: [monster, avians]
---
# Brine Crow

> The Brine Crow is a small creature with a broad-winged bird frame, about 0.6 m tall. Its plumage is weathered and natural, colored in deep blues with a glassy shine. Guild sketches always show a beak full of stolen shiny things. It has alert animal eyes. It has no ornament at all: simple, readable shapes. It prowls, surrounded by fine mist and droplets that orbit it. This Water-attuned variant carries one extra elemental feature, like a crest of elemental energy, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Avians|Avians]] · Avian |
| Variant of | [[Monsters/Avians/Giant Crow\|Giant Crow]] (elemental) |
| Rank · level | F+ · 13 (8–19) |
| Menace | 2 · Wild |
| Element · weakness | Water · Lightning |
| Size | 0.6 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 350 · 62 · 50 · 43 · 50 · 135 |
| XP · gold | 190 · 57 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]] |
| Genre | High Fantasy |
| Trope | Griffons, harpies and phoenixes of classic fantasy |

**Field note:** Weak to Lightning. Attacks on sight. Expect a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Peck | melee | 1 | 0 s | None | blue |
| Swoop | dash | 1.4 | 6 s | None | blue |
| Screech | debuff | 0 | 14 s | None | none |
| Feather Volley | ranged | 1 | 6 s | None | blue |
| Tide Lash | magic | 1.5 | 10 s | Water | red |

## Loot (`loot_avian_f`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Feather\|Feather]] | 60% | 1–3 |
| [[Items/Talon\|Talon]] | 30% | 1–1 |
| [[Items/Egg\|Egg]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_avian` · mesh `avian_base` · material `feather_groom` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · real-animal silhouette with one fantasy exaggeration
