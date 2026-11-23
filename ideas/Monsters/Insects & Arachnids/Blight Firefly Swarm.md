---
type: monster
id: mon_blight_firefly_swarm
family: "Insects & Arachnids"
rank: "E+"
tier: variant
tags: [monster, insects-arachnids]
---
# Blight Firefly Swarm

![[mon_blight_firefly_swarm_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_blight_firefly_swarm_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 6,000 tris · 0.072 × 0.05 × 0.065 m · local file `Game/Assets/_Game/Art/Models/Monsters/Insects & Arachnids/mon_blight_firefly_swarm.fbx`

> The Blight Firefly Swarm is a tiny creature with a living carpet of small bodies, each one is about 0.05 m long, but the swarm covers several meters. Its chitin is smooth and clean, colored in amber, with sickly green markings. Guild sketches always show hundreds of soft lantern lights moving together. It has two bright dot eyes. Small scars and rough edges mark it as a survivor. It bounces happily, surrounded by a low toxic haze that clings to the ground. This Poison-attuned variant carries one extra elemental feature, like glowing vein-lines, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Variant of | [[Monsters/Insects & Arachnids/Firefly Swarm\|Firefly Swarm]] (elemental) |
| Rank · level | E+ · 32 (26–40) |
| Menace | 1 · Charming |
| Element · weakness | Poison · Light |
| Size | 0.05 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 709 · 110 · 83 · 83 · 83 · 110 |
| XP · gold | 776 · 195 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/swarm\|swarm]] · `anim_swarm` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Light. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/swarm|swarm]] (rigId); animation set `anim_swarm`.
- **Dimensions:** 0.05 m high × 0.02 m long × 0.01 m wide; prefab scale 0.017.
- **Physics:** 0.5 kg, gravity ×0, poise 4, knockback resistance 1, death style `scatter_and_fall`.
- **Navigation:** speed 0.86 m/s, turn 900°/s, stopping distance 0.5 m.
- **Attack count:** 5; **signature:** hundreds of soft lantern lights moving together.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Nibble\|Nibble]] | melee | 0.6 | 0 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Scatter\|Scatter]] | evade | 0 | 10 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Silk Snare\|Silk Snare]] | ranged | 0.4 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Blight Firefly Swarm is a **charming insectoid** encountered at E+ rank, around level 32. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** hundreds of soft lantern lights moving together. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_swarm`, animation set `anim_swarm`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Insects & Arachnids E|loot_insect_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Carapace Shard\|Carapace Shard]] | 60% | 1–3 |
| [[Items/Silk\|Silk]] | 30% | 1–1 |
| [[Items/Venom Sac\|Venom Sac]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 2 | E, E- | 19–26 | Day |
| [[Regions/Aldmere\|Aldmere]] | 5 | D-, E+, E, D | 26–48 | Day |
| [[Regions/Whisperwood\|Whisperwood]] | 4 | E+, D, E, D- | 26–48 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06374` | Great Labyrinth (Floors 1-40) Blight Firefly Swarm Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | E | 26 | 0.04 m | Day | Like a typical Blight Firefly Swarm, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_06375` | Aldmere Blight Firefly Swarm Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | D- | 40 | 0.06 m | Day | Like a typical Blight Firefly Swarm, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_06376` | Whisperwood Blight Firefly Swarm | [[Regions/Whisperwood\|Whisperwood]] | Adult | E+ | 32 | 0.05 m | Day | A typical adult Blight Firefly Swarm of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_06377` | Aldmere Blight Firefly Swarm Albino | [[Regions/Aldmere\|Aldmere]] | Albino | D- | 40 | 0.05 m | Day | Like a typical Blight Firefly Swarm, but a rare pale form with white skin or fur and red eyes. |
| `pop_06378` | Whisperwood Blight Firefly Swarm Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | D | 48 | 0.06 m | Day | Like a typical Blight Firefly Swarm, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_06379` | Aldmere Blight Firefly Swarm | [[Regions/Aldmere\|Aldmere]] | Adult | E+ | 32 | 0.05 m | Day | A typical adult Blight Firefly Swarm of this region, with golden, grass-toned coloring. |
| `pop_06380` | Whisperwood Blight Firefly Swarm Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | E | 26 | 0.04 m | Day | Like a typical Blight Firefly Swarm, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_06381` | Aldmere Blight Firefly Swarm Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E | 26 | 0.04 m | Day | Like a typical Blight Firefly Swarm, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_06382` | Great Labyrinth (Floors 1-40) Blight Firefly Swarm Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | E- | 19 | 0.03 m | Day | Like a typical Blight Firefly Swarm, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_06383` | Whisperwood Blight Firefly Swarm Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | D- | 40 | 0.06 m | Day | Like a typical Blight Firefly Swarm, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_06384` | Aldmere Blight Firefly Swarm Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D | 48 | 0.06 m | Day | Like a typical Blight Firefly Swarm, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_swarm` · mesh `swarm_base` · material `chitin_gloss` · VFX `toxic_fog` · palette `#c88b30` `#7f571d` `#b8e986` · circle-based, soft silhouette
