---
type: monster
id: mon_moss_hobgoblin
family: "Goblinoids"
rank: "D-"
tier: variant
tags: [monster, goblinoids]
---
# Moss Hobgoblin

> The Moss Hobgoblin is a person-sized creature with a broad-shouldered humanoid build, about 1.8 m tall. Its skin is rough, scarred and spiked, colored in leaf greens over bark brown. Survivors describe a broad scarred chest and a helmet two sizes too small. It has eyes that catch torchlight like coins. A distinctive marking runs along its back. It strides with heavy steps, surrounded by drifting pollen and tiny blossoms. This Nature-attuned variant carries one extra elemental feature, like crystal spikes, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Variant of | [[Monsters/Goblinoids/Hobgoblin\|Hobgoblin]] (elemental) |
| Rank · level | D- · 40 (32–48) |
| Menace | 3 · Menacing |
| Element · weakness | Nature · Fire |
| Size | 1.8 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3132 · 204 · 170 · 136 · 153 · 100 |
| XP · gold | 1106 · 265 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Moraveil\|Moraveil]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Fire. Attacks on sight. Expect a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slash | melee | 1 | 0 s | None | blue |
| Heavy Swing | melee | 1.6 | 6 s | None | red |
| Guard Counter | counter | 1.3 | 10 s | None | blue |
| Sand Toss | debuff | 0 | 12 s | None | none |
| Thorn Volley | magic | 1.5 | 10 s | Nature | red |

## Loot (`loot_goblinoid_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rough_skin_leather` · VFX `pollen_petals` · palette `#4caf50` `#a5d66f` `#3e2723` · triangle-based silhouette, sharp asymmetric spikes
