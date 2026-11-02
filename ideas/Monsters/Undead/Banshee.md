---
type: monster
id: mon_banshee
family: "Undead"
rank: "C"
tier: core
tags: [monster, undead]
---
# Banshee

![[mon_banshee_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_banshee_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,776 tris · 1.308 × 1.222 × 1.8 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Banshee is a person-sized creature with a bodiless, glowing form, about 1.8 m tall. Its flesh and bone are patchy and subtly wrong, as if assembled from memory, colored in dusk-violet, with pale jade markings. Look for long white hair and a mouth that opens far too wide. It has pale, pupil-less eyes. Battle-worn plates and trophies hang from its body. It moves in jerky stop-motion bursts, surrounded by swirling leaves and a constant breeze.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Rank · level | C · 76 (65–86) |
| Menace | 4 · Dread |
| Element · weakness | Wind · Fire |
| Size | 1.8 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 5871 · 188 · 220 · 440 · 408 · 90 |
| XP · gold | 3073 · 648 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/spirit_float\|spirit_float]] · `anim_floating` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Zarvan\|Zarvan]], [[Regions/Vharlen\|Vharlen]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Fire. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/spirit_float|spirit_float]] (rigId); animation set `anim_floating`.
- **Dimensions:** 1.8 m high × 0.54 m long × 1.15 m wide; prefab scale 1.8.
- **Physics:** 0.5 kg, gravity ×0, poise 14, knockback resistance 0.09, death style `dissolve_into_motes`.
- **Navigation:** speed 8.65 m/s, turn 537°/s, stopping distance 0.85 m.
- **Attack count:** 5; **signature:** long white hair and a mouth that opens far too wide.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Chill Touch\|Chill Touch]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Phase Lunge\|Phase Lunge]] | dash | 1.3 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wail\|Wail]] | aoe | 1.2 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grave Grasp\|Grave Grasp]] | grab | 1.2 | 10 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Gale Cutter\|Gale Cutter]] | magic | 1.5 | 10 s | Wind | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Banshee is a **dread undead** encountered at C rank, around level 76. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** long white hair and a mouth that opens far too wide. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Zarvan|Zarvan]], [[Regions/Vharlen|Vharlen]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_floating`, animation set `anim_floating`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Undead C|loot_undead_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Undead/Tide Banshee|Tide Banshee]]
- [[Monsters/Undead/Gilded Banshee|Gilded Banshee]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 5 | C+, C-, B-, D+ | 56–96 | Night |
| [[Regions/Vharlen\|Vharlen]] | 4 | C+, D+, C- | 56–86 | Night |
| [[Regions/Zarvan\|Zarvan]] | 2 | C, B | 76–108 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00906` | Aldmere Banshee Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | C+ | 86 | 1.98 m | Night | Like a typical Banshee, but covered in old battle scars, with mud-slick, algae-streaked skin. |
| `pop_00907` | Vharlen Banshee Albino | [[Regions/Vharlen\|Vharlen]] | Albino | C+ | 86 | 1.8 m | Night | Like a typical Banshee, but a rare pale form with white skin or fur and red eyes. |
| `pop_00908` | Vharlen Banshee Runt | [[Regions/Vharlen\|Vharlen]] | Runt | D+ | 56 | 1.26 m | Night | Like a typical Banshee, but smaller and scrappier than usual, with soot-stained hide and scavenged scraps. |
| `pop_00909` | Aldmere Banshee Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | C- | 65 | 1.53 m | Night | Like a typical Banshee, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |
| `pop_00910` | Zarvan Banshee | [[Regions/Zarvan\|Zarvan]] | Adult | C | 76 | 1.8 m | Night | A typical adult Banshee of this region, with sun-bleached, sand-scoured coloring. |
| `pop_00911` | Aldmere Banshee Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | B- | 96 | 2.25 m | Night | Like a typical Banshee, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |
| `pop_00912` | Zarvan Banshee Elderborn | [[Regions/Zarvan\|Zarvan]] | Elderborn | B | 108 | 2.43 m | Night | Like a typical Banshee, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_00913` | Aldmere Banshee Albino | [[Regions/Aldmere\|Aldmere]] | Albino | C+ | 86 | 1.8 m | Night | Like a typical Banshee, but a rare pale form with white skin or fur and red eyes. |
| `pop_00914` | Aldmere Banshee Runt | [[Regions/Aldmere\|Aldmere]] | Runt | D+ | 56 | 1.26 m | Night | Like a typical Banshee, but smaller and scrappier than usual, with mud-slick, algae-streaked skin. |
| `pop_00915` | Vharlen Banshee Scarred | [[Regions/Vharlen\|Vharlen]] | Scarred | C+ | 86 | 1.98 m | Night | Like a typical Banshee, but covered in old battle scars, with soot-stained hide and scavenged scraps. |
| `pop_00916` | Vharlen Banshee Juvenile | [[Regions/Vharlen\|Vharlen]] | Juvenile | C- | 65 | 1.53 m | Night | Like a typical Banshee, but young, with brighter colors and unworn features, with soot-stained hide and scavenged scraps. |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `rot_bone` · VFX `wind_ribbons` · palette `#52557f` `#43466d` `#8fe0bd` · elongated, irregular silhouette; still-then-sudden timing
