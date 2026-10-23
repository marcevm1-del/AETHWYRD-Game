---
type: monster
id: mon_ancient_gremlin
family: "Gremlins"
rank: "E"
tier: variant
tags: [monster, gremlins]
---
# Ancient Gremlin

> The Ancient Gremlin is a small creature with a small, compact humanoid body, about 0.9 m tall. Its skin is weathered and natural, colored in storm violet shot through with electric yellow. Look for bat ears, a wrench and a laugh like a squeaky hinge. It has dark, wary eyes. Small scars and rough edges mark it as a survivor. It stalks low to the ground, surrounded by crackling arcs that jump across its body. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Gremlins|Gremlins]] · Fey Pest |
| Variant of | [[Monsters/Gremlins/Gremlin\|Gremlin]] (ancient) |
| Rank · level | E · 26 (19–32) |
| Menace | 2 · Wild |
| Element · weakness | Lightning · Earth |
| Size | 0.9 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1030 · 114 · 91 · 80 · 91 · 135 |
| XP · gold | 559 · 147 |
| Ring | 3 |
| Habitats | [[Regions/Lirian\|Lirian]], [[Regions/Aldmere\|Aldmere]] |
| Genre | Steampunk Mischief |
| Trope | Machine-breaking pests |

**Field note:** Weak to Earth. Dangerous in numbers. Area attacks and chokepoints help.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Stab | melee | 1 | 0 s | None | blue |
| Thrown Junk | ranged | 0.8 | 4 s | None | blue |
| Frenzied Lunge | melee | 1.5 | 8 s | None | red |
| Wrench Sabotage | debuff | 0 | 14 s | None | none |
| Static Arc | magic | 1.5 | 10 s | Lightning | red |

## Loot (`loot_gremlin_e`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Stolen Bolt\|Stolen Bolt]] | 60% | 1–3 |
| [[Items/Gremlin Ear\|Gremlin Ear]] | 30% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `rubbery_skin` · VFX `arc_sparks` · palette `#ffe14d` `#6c5ce7` `#1b1b3a` · real-animal silhouette with one fantasy exaggeration
