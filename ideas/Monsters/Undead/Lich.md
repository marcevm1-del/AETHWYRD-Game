---
type: monster
id: mon_lich
family: "Undead"
rank: "A"
tier: core
tags: [monster, undead]
---
# Lich

![[mon_lich_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_lich_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 1.63 × 1.719 × 2.2 m · local file `Game/Assets/_Game/Art/Models/Monsters/Undead/mon_lich.fbx`

> The Lich is a person-sized creature with a bodiless, glowing form, about 2.2 m tall. Its flesh and bone are patchy and subtly wrong, as if assembled from memory, colored in bleached bone and grave-cloth, with frost-blue markings. Look for a crowned skull with a phylactery chained to its chest. It has eyes set slightly too far apart. An elegant crest and glowing veins of mana mark it as a champion of its kind. It moves in jerky stop-motion bursts, surrounded by falling snow motes and frosted ground where it steps.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Rank · level | A · 146 (132–159) |
| Menace | 4 · Dread |
| Element · weakness | Ice · Fire |
| Size | 2.2 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 16640 · 356 · 416 · 832 · 772 · 90 |
| XP · gold | 8719 · 1611 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/spirit_float\|spirit_float]] · `anim_floating` |
| Habitats | [[Regions/Zarvan\|Zarvan]], [[Regions/Gearholm\|Gearholm]], [[Regions/Sunscar\|Sunscar]], [[Regions/Haneul\|Haneul]], [[Regions/Vharlen\|Vharlen]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Fire. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/spirit_float|spirit_float]] (rigId); animation set `anim_floating`.
- **Dimensions:** 2.2 m high × 0.66 m long × 1.41 m wide; prefab scale 2.2.
- **Physics:** 1.2 kg, gravity ×0, poise 26, knockback resistance 0.15, death style `dissolve_into_motes`.
- **Navigation:** speed 8.14 m/s, turn 485°/s, stopping distance 0.95 m.
- **Attack count:** 5; **signature:** a crowned skull with a phylactery chained to its chest.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Chill Touch\|Chill Touch]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Phase Lunge\|Phase Lunge]] | dash | 1.3 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wail\|Wail]] | aoe | 1.2 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grave Grasp\|Grave Grasp]] | grab | 1.2 | 10 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Frost Breath\|Frost Breath]] | magic | 1.5 | 10 s | Ice | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Lich is a **dread undead** encountered at A rank, around level 146. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a crowned skull with a phylactery chained to its chest. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Zarvan|Zarvan]], [[Regions/Gearholm|Gearholm]], [[Regions/Sunscar|Sunscar]], [[Regions/Haneul|Haneul]], [[Regions/Vharlen|Vharlen]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_floating`, animation set `anim_floating`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Undead A|loot_undead_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Undead/Bog Lich|Bog Lich]]
- [[Monsters/Undead/Ancient Lich|Ancient Lich]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Zarvan\|Zarvan]] | 3 | S-, A+ | 159–173 | Night |
| [[Regions/Gearholm\|Gearholm]] | 1 | A- | 132–132 | Night |
| [[Regions/Sunscar\|Sunscar]] | 1 | S | 188–188 | Night |
| [[Regions/Haneul\|Haneul]] | 4 | S-, S, B+, A+ | 120–188 | Night |
| [[Regions/Vharlen\|Vharlen]] | 2 | A-, A | 132–146 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00939` | Zarvan Lich Alpha | [[Regions/Zarvan\|Zarvan]] | Alpha | S- | 173 | 2.75 m | Night | Like a typical Lich, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |
| `pop_00940` | Gearholm Lich Juvenile | [[Regions/Gearholm\|Gearholm]] | Juvenile | A- | 132 | 1.87 m | Night | Like a typical Lich, but young, with brighter colors and unworn features, with soot-stained hide and scavenged scraps. |
| `pop_00941` | Sunscar Lich Elderborn | [[Regions/Sunscar\|Sunscar]] | Elderborn | S | 188 | 2.97 m | Night | Like a typical Lich, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_00942` | Haneul Lich Alpha | [[Regions/Haneul\|Haneul]] | Alpha | S- | 173 | 2.75 m | Night | Like a typical Lich, but larger and scarred, and others of its kind follow it, with soot-stained hide and scavenged scraps. |
| `pop_00943` | Haneul Lich Elderborn | [[Regions/Haneul\|Haneul]] | Elderborn | S | 188 | 2.97 m | Night | Like a typical Lich, but old and wise, with greying features and a cautious hunting style, with soot-stained hide and scavenged scraps. |
| `pop_00944` | Zarvan Lich Scarred | [[Regions/Zarvan\|Zarvan]] | Scarred | A+ | 159 | 2.42 m | Night | Like a typical Lich, but covered in old battle scars, with sun-bleached, sand-scoured coloring. |
| `pop_00945` | Haneul Lich Runt | [[Regions/Haneul\|Haneul]] | Runt | B+ | 120 | 1.54 m | Night | Like a typical Lich, but smaller and scrappier than usual, with soot-stained hide and scavenged scraps. |
| `pop_00946` | Zarvan Lich Albino | [[Regions/Zarvan\|Zarvan]] | Albino | A+ | 159 | 2.2 m | Night | Like a typical Lich, but a rare pale form with white skin or fur and red eyes. |
| `pop_00947` | Haneul Lich Scarred | [[Regions/Haneul\|Haneul]] | Scarred | A+ | 159 | 2.42 m | Night | Like a typical Lich, but covered in old battle scars, with soot-stained hide and scavenged scraps. |
| `pop_00948` | Vharlen Lich Juvenile | [[Regions/Vharlen\|Vharlen]] | Juvenile | A- | 132 | 1.87 m | Night | Like a typical Lich, but young, with brighter colors and unworn features, with soot-stained hide and scavenged scraps. |
| `pop_00949` | Vharlen Lich | [[Regions/Vharlen\|Vharlen]] | Adult | A | 146 | 2.2 m | Night | A typical adult Lich of this region, with soot-stained hide and scavenged scraps. |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `rot_bone` · VFX `frost_trail_snow` · palette `#d7c4b0` `#8a7868` `#9fdcff` · elongated, irregular silhouette; still-then-sudden timing
