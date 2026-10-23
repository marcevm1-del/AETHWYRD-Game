---
type: monster
id: mon_phantom_goblin_wolf_rider
family: "Goblinoids"
rank: "D+"
tier: variant
tags: [monster, goblinoids]
---
# Phantom Goblin Wolf Rider

> The Phantom Goblin Wolf Rider is a small creature with a scrawny biped with long arms and bowed legs, about 1 m tall. Its skin is patchy and subtly wrong, as if assembled from memory, colored in warm gold and pearl white. Survivors describe a bone saddle on a snarling war-wolf mount. It has eyes set slightly too far apart. A distinctive marking runs along its back. It moves in jerky stop-motion bursts, surrounded by soft radiance and floating motes of light. Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Variant of | [[Monsters/Goblinoids/Goblin Wolf Rider\|Goblin Wolf Rider]] (spirit) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 4 · Dread |
| Element · weakness | Light · Dark |
| Size | 1 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3257 · 234 · 187 · 164 · 187 · 135 |
| XP · gold | 1888 · 423 |
| Ring | 4 |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Strife Marches\|Strife Marches]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Dark. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Stab | melee | 1 | 0 s | None | blue |
| Thrown Junk | ranged | 0.8 | 4 s | None | blue |
| Frenzied Lunge | melee | 1.5 | 8 s | None | red |
| Sand Toss | debuff | 0 | 12 s | None | none |
| Radiant Pulse | magic | 1.5 | 10 s | Light | red |

## Loot (`loot_goblinoid_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `rough_skin_leather` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · elongated, irregular silhouette; still-then-sudden timing
