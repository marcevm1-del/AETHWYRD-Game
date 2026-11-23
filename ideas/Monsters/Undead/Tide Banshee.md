---
type: monster
id: mon_tide_banshee
family: "Undead"
rank: "C+"
tier: variant
tags: [monster, undead]
---
# Tide Banshee

![[mon_tide_banshee_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_tide_banshee_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 1.437 × 1.536 × 1.8 m · local file `Game/Assets/_Game/Art/Models/Monsters/Undead/mon_tide_banshee.fbx`

> The Tide Banshee is a person-sized creature with a drifting, half-formed body, about 1.8 m tall. Its flesh and bone are patchy and subtly wrong, as if assembled from memory, colored in dusk-violet, with sea-blue markings. Guild sketches always show long white hair and a mouth that opens far too wide. It has eyes set slightly too far apart. Battle-worn plates and trophies hang from its body. It glides without moving its legs, surrounded by fine mist and droplets that orbit it. This Water-attuned variant carries one extra elemental feature, like glowing vein-lines, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Banshee\|Banshee]] (elemental) |
| Rank · level | C+ · 86 (76–96) |
| Menace | 4 · Dread |
| Element · weakness | Water · Lightning |
| Size | 1.8 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 7055 · 212 · 248 · 496 · 460 · 90 |
| XP · gold | 3743 · 769 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/spirit_float\|spirit_float]] · `anim_floating` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Lumbaya\|Lumbaya]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Lightning. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/spirit_float|spirit_float]] (rigId); animation set `anim_floating`.
- **Dimensions:** 1.8 m high × 0.54 m long × 1.15 m wide; prefab scale 1.8.
- **Physics:** 0.6 kg, gravity ×0, poise 16, knockback resistance 0.09, death style `dissolve_into_motes`.
- **Navigation:** speed 8.01 m/s, turn 537°/s, stopping distance 0.85 m.
- **Attack count:** 5; **signature:** long white hair and a mouth that opens far too wide.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Chill Touch\|Chill Touch]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Phase Lunge\|Phase Lunge]] | dash | 1.3 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wail\|Wail]] | aoe | 1.2 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grave Grasp\|Grave Grasp]] | grab | 1.2 | 10 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Tide Lash\|Tide Lash]] | magic | 1.5 | 10 s | Water | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Tide Banshee is a **dread undead** encountered at C+ rank, around level 86. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Lightning**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** long white hair and a mouth that opens far too wide. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Lumbaya|Lumbaya]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Aldmere\|Aldmere]] | 6 | C, C-, C+, B+, B-, B | 65–120 | Night |
| [[Regions/Lumbaya\|Lumbaya]] | 5 | C-, C+, C, B-, B+ | 65–120 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03804` | Aldmere Tide Banshee Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | C | 76 | 1.53 m | Night | Like a typical Tide Banshee, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |
| `pop_03805` | Lumbaya Tide Banshee Runt | [[Regions/Lumbaya\|Lumbaya]] | Runt | C- | 65 | 1.26 m | Night | Like a typical Tide Banshee, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_03806` | Aldmere Tide Banshee Runt | [[Regions/Aldmere\|Aldmere]] | Runt | C- | 65 | 1.26 m | Night | Like a typical Tide Banshee, but smaller and scrappier than usual, with mud-slick, algae-streaked skin. |
| `pop_03807` | Lumbaya Tide Banshee | [[Regions/Lumbaya\|Lumbaya]] | Adult | C+ | 86 | 1.8 m | Night | A typical adult Tide Banshee of this region, with dust-grey coloring and old rune scars. |
| `pop_03808` | Aldmere Tide Banshee | [[Regions/Aldmere\|Aldmere]] | Adult | C+ | 86 | 1.8 m | Night | A typical adult Tide Banshee of this region, with mud-slick, algae-streaked skin. |
| `pop_03809` | Aldmere Tide Banshee Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | B+ | 120 | 2.43 m | Night | Like a typical Tide Banshee, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |
| `pop_03810` | Aldmere Tide Banshee Albino | [[Regions/Aldmere\|Aldmere]] | Albino | B- | 96 | 1.8 m | Night | Like a typical Tide Banshee, but a rare pale form with white skin or fur and red eyes. |
| `pop_03811` | Aldmere Tide Banshee Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | B | 108 | 2.25 m | Night | Like a typical Tide Banshee, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |
| `pop_03812` | Lumbaya Tide Banshee Juvenile | [[Regions/Lumbaya\|Lumbaya]] | Juvenile | C | 76 | 1.53 m | Night | Like a typical Tide Banshee, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_03813` | Lumbaya Tide Banshee Albino | [[Regions/Lumbaya\|Lumbaya]] | Albino | B- | 96 | 1.8 m | Night | Like a typical Tide Banshee, but a rare pale form with white skin or fur and red eyes. |
| `pop_03814` | Lumbaya Tide Banshee Elderborn | [[Regions/Lumbaya\|Lumbaya]] | Elderborn | B+ | 120 | 2.43 m | Night | Like a typical Tide Banshee, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `rot_bone` · VFX `mist_droplets` · palette `#585888` `#484975` `#4fa8e8` · elongated, irregular silhouette; still-then-sudden timing
