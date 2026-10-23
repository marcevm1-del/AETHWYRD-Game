---
type: monster
id: mon_ghoul
family: "Undead"
rank: "E+"
tier: core
tags: [monster, undead]
---
# Ghoul

> The Ghoul is a person-sized creature with a lean humanoid frame, about 1.6 m tall. Its flesh and bone are patchy and subtly wrong, as if assembled from memory, colored in ink black with bruised violet. Its most striking feature is grey, hairless skin and long black nails. It has eyes that never blink. Small scars and rough edges mark it as a survivor. It glides without moving its legs, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Rank · level | E+ · 32 (26–40) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 1.6 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2175 · 166 · 138 · 110 · 124 · 100 |
| XP · gold | 776 · 195 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Greymoor\|Greymoor]], [[Regions/Lirian\|Lirian]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slash | melee | 1 | 0 s | None | blue |
| Heavy Swing | melee | 1.6 | 6 s | None | red |
| Guard Counter | counter | 1.3 | 10 s | None | blue |
| Grave Grasp | grab | 1.2 | 10 s | None | gold |
| Shadow Grasp | magic | 1.5 | 10 s | Dark | red |

## Loot (`loot_undead_e`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Undead/Vesper-Touched Ghoul|Vesper-Touched Ghoul]]
- [[Monsters/Undead/Blight Ghoul|Blight Ghoul]]

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rot_bone` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · elongated, irregular silhouette; still-then-sudden timing
