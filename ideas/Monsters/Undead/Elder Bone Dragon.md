---
type: monster
id: mon_elder_bone_dragon
family: "Undead"
rank: "SS"
tier: variant
tags: [monster, undead]
---
# Elder Bone Dragon

> The Elder Bone Dragon is a colossal creature with a four-legged, two-winged dragon body, about 32 m long. Its flesh and bone are patchy and subtly wrong, as if assembled from memory, colored in ink black with bruised violet. Its most striking feature is a dragon skeleton held together by green fire. It has eyes that never blink. The air distorts slightly around its outline. It freezes whenever it is looked at, surrounded by shadows that lean toward it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Bone Dragon\|Bone Dragon]] (elder) |
| Rank · level | SS · 236 (218–253) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 32 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 138276 · 1240 · 1145 · 1240 · 1145 · 100 |
| XP · gold | 18792 · 3152 |
| Ring | 9 |
| Habitats | [[Regions/Vesper\|Vesper]], [[Regions/Nox Dominion\|Nox Dominion]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Claw | melee | 1.4 | 0 s | None | blue |
| Breath | aoe | 2.2 | 14 s | None | red |
| Wing Gust | aoe | 1 | 10 s | None | blue |
| Tail Blade | melee | 1.8 | 8 s | None | red |
| Grave Grasp | grab | 1.2 | 10 s | None | gold |
| Shadow Grasp | magic | 1.5 | 10 s | Dark | red |

## Loot (`loot_undead_ss`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/SS-Rank Monster Core\|SS-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_dragon` · mesh `dragon_base` · material `rot_bone` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · elongated, irregular silhouette; still-then-sudden timing
