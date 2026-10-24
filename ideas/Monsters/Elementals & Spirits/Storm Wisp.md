---
type: monster
id: mon_storm_wisp
family: "Elementals & Spirits"
rank: "F+"
tier: variant
tags: [monster, elementals-spirits]
---
# Storm Wisp

![[mon_storm_wisp_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_storm_wisp_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,438 tris · 0.224 × 0.312 × 0.3 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Storm Wisp is a tiny creature with a floating, cloth-like shape, about 0.3 m tall. Its body is smooth and clean, colored in storm violet shot through with electric yellow. Survivors describe a floating ball of soft light. It has two bright dot eyes. It has no ornament at all: simple, readable shapes. It hops in little bursts, surrounded by crackling arcs that jump across its body. This Lightning-attuned variant carries one extra elemental feature, like element-scarred hide, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Elementals & Spirits|Elementals & Spirits]] · Elemental |
| Variant of | [[Monsters/Elementals & Spirits/Wisp\|Wisp]] (elemental) |
| Rank · level | F+ · 13 (8–19) |
| Menace | 1 · Charming |
| Element · weakness | Lightning · Earth |
| Size | 0.3 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 278 · 37 · 43 · 87 · 81 · 90 |
| XP · gold | 190 · 57 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/spirit_float\|spirit_float]] · `anim_floating` |
| Habitats | [[Regions/Whisperwood\|Whisperwood]], [[Regions/Aldmere\|Aldmere]] |
| Genre | Spirit Realm |
| Trope | Spirits you can contract with; elemental kings |

**Field note:** Weak to Earth. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/spirit_float|spirit_float]] (override (base species)); animation set `anim_floating`.
- **Dimensions:** 0.3 m high × 0.09 m long × 0.19 m wide; prefab scale 0.3.
- **Physics:** 0.5 kg, gravity ×0, poise 4, knockback resistance 0, death style `dissolve_into_motes`.
- **Navigation:** speed 2.74 m/s, turn 900°/s, stopping distance 0.5 m.
- **Attack count:** 5; **signature:** a floating ball of soft light.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Chill Touch\|Chill Touch]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Phase Lunge\|Phase Lunge]] | dash | 1.3 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wail\|Wail]] | aoe | 1.2 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Elemental Burst\|Elemental Burst]] | magic | 1.4 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Static Arc\|Static Arc]] | magic | 1.5 | 10 s | Lightning | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Storm Wisp is a **charming elemental** encountered at F+ rank, around level 13. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Earth**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a floating ball of soft light. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Whisperwood|Whisperwood]], [[Regions/Aldmere|Aldmere]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_floating`, animation set `anim_floating`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Elementals & Spirits F|loot_elemental_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Elemental Essence\|Elemental Essence]] | 60% | 1–3 |
| [[Items/Spirit Mote\|Spirit Mote]] | 30% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 5 | E-, E, F-, F+, E+ | 3–32 | Day |
| [[Regions/Whisperwood\|Whisperwood]] | 6 | E-, E, F-, F+, F | 3–26 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04451` | Aldmere Storm Wisp Albino | [[Regions/Aldmere\|Aldmere]] | Albino | E- | 19 | 0.3 m | Day | Like a typical Storm Wisp, but a rare pale form with white skin or fur and red eyes. |
| `pop_04452` | Whisperwood Storm Wisp Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | E- | 19 | 0.33 m | Day | Like a typical Storm Wisp, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_04453` | Whisperwood Storm Wisp Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | E | 26 | 0.38 m | Day | Like a typical Storm Wisp, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_04454` | Aldmere Storm Wisp Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | E | 26 | 0.38 m | Day | Like a typical Storm Wisp, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_04455` | Aldmere Storm Wisp Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F- | 3 | 0.21 m | Day | Like a typical Storm Wisp, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_04456` | Whisperwood Storm Wisp Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | F- | 3 | 0.21 m | Day | Like a typical Storm Wisp, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_04457` | Aldmere Storm Wisp | [[Regions/Aldmere\|Aldmere]] | Adult | F+ | 13 | 0.3 m | Day | A typical adult Storm Wisp of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_04458` | Aldmere Storm Wisp Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | E+ | 32 | 0.41 m | Day | Like a typical Storm Wisp, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_04459` | Whisperwood Storm Wisp | [[Regions/Whisperwood\|Whisperwood]] | Adult | F+ | 13 | 0.3 m | Day | A typical adult Storm Wisp of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_04460` | Whisperwood Storm Wisp Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | F | 8 | 0.26 m | Day | Like a typical Storm Wisp, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_04461` | Whisperwood Storm Wisp Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | E- | 19 | 0.3 m | Day | Like a typical Storm Wisp, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `elemental_emissive` · VFX `arc_sparks` · palette `#ffe14d` `#6c5ce7` `#1b1b3a` · circle-based, soft silhouette
