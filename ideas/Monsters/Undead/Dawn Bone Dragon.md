---
type: monster
id: mon_dawn_bone_dragon
family: "Undead"
rank: "S+"
tier: variant
tags: [monster, undead]
---
# Dawn Bone Dragon

> The Dawn Bone Dragon is a colossal creature with an ancient, serpentine dragon body, about 20 m long. Its flesh and bone are patchy and subtly wrong, as if assembled from memory, colored in warm gold and pearl white. Guild sketches always show a dragon skeleton held together by green fire. It has eyes set slightly too far apart. Its regal silhouette is crowned by a halo-like ring of aura. It freezes whenever it is looked at, surrounded by soft radiance and floating motes of light. This Light-attuned variant carries one extra elemental feature, like glowing vein-lines, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Bone Dragon\|Bone Dragon]] (elemental) |
| Rank · level | S+ · 203 (188–218) |
| Menace | 4 · Dread |
| Element · weakness | Light · Dark |
| Size | 20 m |
| Behaviour | Guardian (guardian_hold+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 98879 · 1069 · 986 · 1069 · 986 · 100 |
| XP · gold | 14769 · 2553 |
| Ring | 9 |
| Habitats | [[Regions/Vesper\|Vesper]], [[Regions/Sky Archipelago\|Sky Archipelago]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Dark. Protects something nearby: a nest, a treasure, or a place.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Claw | melee | 1.4 | 0 s | None | blue |
| Breath | aoe | 2.2 | 14 s | None | red |
| Wing Gust | aoe | 1 | 10 s | None | blue |
| Tail Blade | melee | 1.8 | 8 s | None | red |
| Grave Grasp | grab | 1.2 | 10 s | None | gold |
| Radiant Pulse | magic | 1.5 | 10 s | Light | red |

## Loot (`loot_undead_s`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_dragon` · mesh `dragon_base` · material `rot_bone` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · elongated, irregular silhouette; still-then-sudden timing
