---
type: monster
id: mon_phantom_goblin_archer
family: "Goblinoids"
rank: "E-"
tier: variant
tags: [monster, goblinoids]
---
# Phantom Goblin Archer

> The Phantom Goblin Archer is a small creature with a small, compact humanoid body, about 1 m tall. Its skin is patchy and subtly wrong, as if assembled from memory, colored in warm gold and pearl white. Guild sketches always show a crooked bow strung with gut and a quiver of bone-tipped arrows. It has eyes that never blink. Small scars and rough edges mark it as a survivor. It freezes whenever it is looked at, surrounded by soft radiance and floating motes of light. Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Variant of | [[Monsters/Goblinoids/Goblin Archer\|Goblin Archer]] (spirit) |
| Rank · level | E- · 19 (13–26) |
| Menace | 4 · Dread |
| Element · weakness | Light · Dark |
| Size | 1 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 685 · 86 · 69 · 60 · 69 · 135 |
| XP · gold | 342 · 96 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
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

## Loot (`loot_goblinoid_e`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `rough_skin_leather` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · elongated, irregular silhouette; still-then-sudden timing
