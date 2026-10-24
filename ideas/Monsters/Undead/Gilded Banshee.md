---
type: monster
id: mon_gilded_banshee
family: "Undead"
rank: "C+"
tier: variant
tags: [monster, undead]
---
# Gilded Banshee

![[mon_gilded_banshee_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_gilded_banshee_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Gilded Banshee is a person-sized creature with a bodiless, glowing form, about 1.8 m tall. Its flesh and bone are patchy and subtly wrong, as if assembled from memory, colored in warm gold and pearl white. Guild sketches always show long white hair and a mouth that opens far too wide. It has eyes set slightly too far apart. Battle-worn plates and trophies hang from its body. It glides without moving its legs, surrounded by soft radiance and floating motes of light. This Light-attuned variant carries one extra elemental feature, like a crest of elemental energy, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Banshee\|Banshee]] (elemental) |
| Rank · level | C+ · 86 (76–96) |
| Menace | 4 · Dread |
| Element · weakness | Light · Dark |
| Size | 1.8 m |
| Behaviour | Guardian (guardian_hold+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 7055 · 212 · 248 · 496 · 460 · 90 |
| XP · gold | 3743 · 769 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/spirit_float\|spirit_float]] · `anim_floating` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Sunscar\|Sunscar]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Dark. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/spirit_float|spirit_float]] (rigId); animation set `anim_floating`.
- **Dimensions:** 1.8 m high × 0.54 m long × 1.15 m wide; prefab scale 1.8.
- **Physics:** 0.6 kg, gravity ×0, poise 14, knockback resistance 0.09, death style `dissolve_into_motes`.
- **Navigation:** speed 6.55 m/s, turn 537°/s, stopping distance 0.85 m.
- **Attack count:** 5; **signature:** long white hair and a mouth that opens far too wide.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Chill Touch\|Chill Touch]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Phase Lunge\|Phase Lunge]] | dash | 1.3 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wail\|Wail]] | aoe | 1.2 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grave Grasp\|Grave Grasp]] | grab | 1.2 | 10 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Gilded Banshee is a **dread undead** encountered at C+ rank, around level 86. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** long white hair and a mouth that opens far too wide. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Sunscar|Sunscar]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_floating`, animation set `anim_floating`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Undead C|loot_undead_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 7 | C+, B-, C-, B+, B, C | 65–120 | Night |
| [[Regions/Sunscar\|Sunscar]] | 4 | C-, B, B- | 65–108 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06649` | Aldmere Gilded Banshee | [[Regions/Aldmere\|Aldmere]] | Adult | C+ | 86 | 1.8 m | Night | A typical adult Gilded Banshee of this region, with mud-slick, algae-streaked skin. |
| `pop_06650` | Aldmere Gilded Banshee Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | B- | 96 | 1.98 m | Night | Like a typical Gilded Banshee, but covered in old battle scars, with mud-slick, algae-streaked skin. |
| `pop_06651` | Sunscar Gilded Banshee Runt | [[Regions/Sunscar\|Sunscar]] | Runt | C- | 65 | 1.26 m | Night | Like a typical Gilded Banshee, but smaller and scrappier than usual, with sun-bleached, sand-scoured coloring. |
| `pop_06652` | Aldmere Gilded Banshee Runt | [[Regions/Aldmere\|Aldmere]] | Runt | C- | 65 | 1.26 m | Night | Like a typical Gilded Banshee, but smaller and scrappier than usual, with mud-slick, algae-streaked skin. |
| `pop_06653` | Aldmere Gilded Banshee Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | B+ | 120 | 2.43 m | Night | Like a typical Gilded Banshee, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |
| `pop_06654` | Sunscar Gilded Banshee Alpha | [[Regions/Sunscar\|Sunscar]] | Alpha | B | 108 | 2.25 m | Night | Like a typical Gilded Banshee, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |
| `pop_06655` | Aldmere Gilded Banshee Albino | [[Regions/Aldmere\|Aldmere]] | Albino | B- | 96 | 1.8 m | Night | Like a typical Gilded Banshee, but a rare pale form with white skin or fur and red eyes. |
| `pop_06656` | Aldmere Gilded Banshee Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | B | 108 | 2.25 m | Night | Like a typical Gilded Banshee, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |
| `pop_06657` | Aldmere Gilded Banshee Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | C | 76 | 1.53 m | Night | Like a typical Gilded Banshee, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |
| `pop_06658` | Sunscar Gilded Banshee Albino | [[Regions/Sunscar\|Sunscar]] | Albino | B- | 96 | 1.8 m | Night | Like a typical Gilded Banshee, but a rare pale form with white skin or fur and red eyes. |
| `pop_06659` | Sunscar Gilded Banshee Scarred | [[Regions/Sunscar\|Sunscar]] | Scarred | B- | 96 | 1.98 m | Night | Like a typical Gilded Banshee, but covered in old battle scars, with sun-bleached, sand-scoured coloring. |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `rot_bone` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · elongated, irregular silhouette; still-then-sudden timing
