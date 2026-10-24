---
type: monster
id: mon_ember_mana_fox
family: "Familiars & Gentle Creatures"
rank: "E+"
tier: variant
tags: [monster, familiars-gentle-creatures]
---
# Ember Mana Fox

> The Ember Mana Fox is a small creature with a compact quadruped frame, about 0.6 m long. Its coat is smooth and clean, colored in ember reds fading to soot black. Its most striking feature is ears that twitch toward magic. It has two bright dot eyes. Small scars and rough edges mark it as a survivor. It waddles, surrounded by heat-shimmer and drifting sparks. This Fire-attuned variant carries one extra elemental feature, like a crest of elemental energy, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Familiars & Gentle Creatures|Familiars & Gentle Creatures]] · Familiar |
| Variant of | [[Monsters/Familiars & Gentle Creatures/Mana Fox\|Mana Fox]] (elemental) |
| Rank · level | E+ · 32 (26–40) |
| Menace | 1 · Charming |
| Element · weakness | Fire · Water |
| Size | 0.6 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1228 · 138 · 110 · 97 · 110 · 135 |
| XP · gold | 776 · 195 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/quad_small\|quad_small]] · `anim_quad_small` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Fanghold\|Fanghold]] |
| Genre | Cozy Fantasy |
| Trope | Cozy companion creatures |

**Field note:** Weak to Water. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_small|quad_small]] (rigId); animation set `anim_quad_small`.
- **Dimensions:** 0.41 m high × 0.6 m long × 0.08 m wide; prefab scale 1.2.
- **Physics:** 6.5 kg, gravity ×1.6, poise 25, knockback resistance 0.08, death style `ragdoll_tumble`.
- **Navigation:** speed 5.87 m/s, turn 697°/s, stopping distance 0.5 m.
- **Attack count:** 5; **signature:** ears that twitch toward magic.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Bite\|Bite]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Charge\|Charge]] | dash | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Leap\|Leap]] | dash | 1.2 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Playful Nudge\|Playful Nudge]] | melee | 0.5 | 6 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Ember Mana Fox is a **charming familiar** encountered at E+ rank, around level 32. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** ears that twitch toward magic. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Fanghold|Fanghold]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_small`, animation set `anim_quad_small`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Familiars & Gentle Creatures E|loot_familiar_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Soft Fur\|Soft Fur]] | 60% | 1–3 |
| [[Items/Shed Scale\|Shed Scale]] | 30% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 5 | E, D-, E+, D, E- | 19–48 | Day |
| [[Regions/Fanghold\|Fanghold]] | 6 | D, D-, E+, E, E-, D+ | 19–56 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05703` | Aldmere Ember Mana Fox Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E | 26 | 0.51 m | Day | Like a typical Ember Mana Fox, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_05704` | Aldmere Ember Mana Fox Albino | [[Regions/Aldmere\|Aldmere]] | Albino | D- | 40 | 0.6 m | Day | Like a typical Ember Mana Fox, but a rare pale form with white skin or fur and red eyes. |
| `pop_05705` | Fanghold Ember Mana Fox Alpha | [[Regions/Fanghold\|Fanghold]] | Alpha | D | 48 | 0.75 m | Day | Like a typical Ember Mana Fox, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_05706` | Aldmere Ember Mana Fox | [[Regions/Aldmere\|Aldmere]] | Adult | E+ | 32 | 0.6 m | Day | A typical adult Ember Mana Fox of this region, with golden, grass-toned coloring. |
| `pop_05707` | Fanghold Ember Mana Fox Scarred | [[Regions/Fanghold\|Fanghold]] | Scarred | D- | 40 | 0.66 m | Day | Like a typical Ember Mana Fox, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_05708` | Fanghold Ember Mana Fox | [[Regions/Fanghold\|Fanghold]] | Adult | E+ | 32 | 0.6 m | Day | A typical adult Ember Mana Fox of this region, with golden, grass-toned coloring. |
| `pop_05709` | Fanghold Ember Mana Fox Juvenile | [[Regions/Fanghold\|Fanghold]] | Juvenile | E | 26 | 0.51 m | Day | Like a typical Ember Mana Fox, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_05710` | Aldmere Ember Mana Fox Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D | 48 | 0.75 m | Day | Like a typical Ember Mana Fox, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_05711` | Fanghold Ember Mana Fox Runt | [[Regions/Fanghold\|Fanghold]] | Runt | E- | 19 | 0.42 m | Day | Like a typical Ember Mana Fox, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_05712` | Aldmere Ember Mana Fox Runt | [[Regions/Aldmere\|Aldmere]] | Runt | E- | 19 | 0.42 m | Day | Like a typical Ember Mana Fox, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_05713` | Fanghold Ember Mana Fox Elderborn | [[Regions/Fanghold\|Fanghold]] | Elderborn | D+ | 56 | 0.81 m | Day | Like a typical Ember Mana Fox, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_quad_small` · mesh `quad_small_base` · material `fur_soft` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · circle-based, soft silhouette
