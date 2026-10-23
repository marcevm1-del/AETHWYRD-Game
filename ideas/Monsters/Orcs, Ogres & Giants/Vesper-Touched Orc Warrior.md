---
type: monster
id: mon_vesper_touched_orc_warrior
family: "Orcs, Ogres & Giants"
rank: "C-"
tier: variant
tags: [monster, orcs-ogres-giants]
---
# Vesper-Touched Orc Warrior

> The Vesper-Touched Orc Warrior is a person-sized creature with a lean humanoid frame, about 2.1 m tall. Its hide is patchy and subtly wrong, as if assembled from memory, colored in arterial crimson and dried-blood brown. Look for a fur mantle and rust-stained chain mail. It has pale, pupil-less eyes. Battle-worn plates and trophies hang from its body. It freezes whenever it is looked at, surrounded by a faint red mist that smells of iron. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Orcs, Ogres & Giants|Orcs, Ogres & Giants]] · Giant |
| Variant of | [[Monsters/Orcs, Ogres & Giants/Orc Warrior\|Orc Warrior]] (corrupted) |
| Rank · level | C- · 65 (56–76) |
| Menace | 4 · Dread |
| Element · weakness | Blood · Light |
| Size | 2.1 m |
| Behaviour | Pack (pack_flank+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 6749 · 324 · 270 · 216 · 243 · 100 |
| XP · gold | 2395 · 521 |
| Ring | 3 |
| Habitats | [[Regions/Strife Marches\|Strife Marches]], [[Regions/Aldmere\|Aldmere]] |
| Genre | Classic Fantasy |
| Trope | Orc warbands and the Orc Disaster that devours its way to power (Tensura) |

**Field note:** Weak to Light. Never alone. Kill the leader first and the rest may scatter.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slash | melee | 1 | 0 s | None | blue |
| Heavy Swing | melee | 1.6 | 6 s | None | red |
| Guard Counter | counter | 1.3 | 10 s | None | blue |
| War Cry | buff | 0 | 18 s | None | none |
| Blood Lance | magic | 1.5 | 10 s | Blood | red |

## Loot (`loot_orc_giant_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Tusk\|Tusk]] | 60% | 1–3 |
| [[Items/Giant's Hide\|Giant's Hide]] | 30% | 1–1 |
| [[Items/Crude Iron\|Crude Iron]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `thick_skin` · VFX `blood_mist` · palette `#8b0000` `#d7263d` `#1a0505` · elongated, irregular silhouette; still-then-sudden timing
