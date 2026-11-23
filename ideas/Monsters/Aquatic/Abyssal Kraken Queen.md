---
type: monster
id: mon_abyssal_kraken_queen
family: "Aquatic"
rank: "SSS"
tier: core
tags: [monster, aquatic]
---
# Abyssal Kraken Queen

![[mon_abyssal_kraken_queen_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_abyssal_kraken_queen_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 30,000 tris · 199.763 × 200 × 201.555 m · local file `Game/Assets/_Game/Art/Models/Monsters/Aquatic/mon_abyssal_kraken_queen.fbx`

> The Abyssal Kraken Queen is a colossal creature with a tentacled, soft-bodied form, about 200 m long. Its scales and skin are patchy and subtly wrong, as if assembled from memory, colored in silver, with violet-edged markings. Guild sketches always show tentacles that can wrap around whole islands. It has pale, pupil-less eyes. Its outline is crowned by slowly turning rings of light; lesser monsters flee from it. It glides without moving its legs, surrounded by warped air, as if space bends around it.

| Field | Value |
|---|---|
| Family · type | [[Families/Aquatic|Aquatic]] · Aquatic |
| Rank · level | SSS · 281 (267–294) |
| Menace | 4 · Dread |
| Element · weakness | Void · Light |
| Size | 200 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 148588 · 1418 · 1021 · 1021 · 1021 · 100 |
| XP · gold | 24842 · 4024 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/tentacled\|tentacled]] · `anim_cephalopod` |
| Habitats | [[Regions/Goldmere Coast\|Goldmere Coast]], [[Regions/Whitewater Reach\|Whitewater Reach]] |
| Genre | Seafaring |
| Trope | Sea kings and krakens (One Piece), sirens and merfolk |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/tentacled|tentacled]] (rigId); animation set `anim_cephalopod`.
- **Dimensions:** 110 m high × 200 m long × 240 m wide; prefab scale 66.667.
- **Physics:** 160000000 kg, gravity ×0.7, poise 121878, knockback resistance 0.94, death style `sink_limp`.
- **Navigation:** speed 53.37 m/s, turn 60°/s, stopping distance 12.4 m.
- **Attack count:** 5; **signature:** tentacles that can wrap around whole islands.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Tentacle Slap\|Tentacle Slap]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Drag Under\|Drag Under]] | grab | 1.8 | 12 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Ink Cloud\|Ink Cloud]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Tidal Drag\|Tidal Drag]] | grab | 1.3 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Null Rift\|Null Rift]] | magic | 1.5 | 10 s | Void | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Abyssal Kraken Queen is a **dread aquatic** encountered at SSS rank, around level 281. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** tentacles that can wrap around whole islands. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Goldmere Coast|Goldmere Coast]], [[Regions/Whitewater Reach|Whitewater Reach]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_cephalopod`, animation set `anim_cephalopod`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Aquatic SSS|loot_aquatic_sss]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Fish Scale\|Fish Scale]] | 60% | 1–3 |
| [[Items/Pearl\|Pearl]] | 30% | 1–1 |
| [[Items/Ink Sac\|Ink Sac]] | 15% | 1–1 |
| [[Items/SSS-Rank Monster Core\|SSS-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Aquatic/Phantom Abyssal Kraken Queen|Phantom Abyssal Kraken Queen]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Goldmere Coast\|Goldmere Coast]] | 6 | SSS+, EX-, SSS-, SS+, EX | 253–300 | Night |
| [[Regions/Whitewater Reach\|Whitewater Reach]] | 5 | SSS, SSS+, EX-, EX | 281–300 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02040` | Goldmere Coast Abyssal Kraken Queen Albino | [[Regions/Goldmere Coast\|Goldmere Coast]] | Albino | SSS+ | 294 | 200 m | Night | Like a typical Abyssal Kraken Queen, but a rare pale form with white skin or fur and red eyes. |
| `pop_02041` | Goldmere Coast Abyssal Kraken Queen Alpha | [[Regions/Goldmere Coast\|Goldmere Coast]] | Alpha | EX- | 300 | 250 m | Night | Like a typical Abyssal Kraken Queen, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_02042` | Goldmere Coast Abyssal Kraken Queen Juvenile | [[Regions/Goldmere Coast\|Goldmere Coast]] | Juvenile | SSS- | 267 | 170 m | Night | Like a typical Abyssal Kraken Queen, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_02043` | Goldmere Coast Abyssal Kraken Queen Runt | [[Regions/Goldmere Coast\|Goldmere Coast]] | Runt | SS+ | 253 | 140 m | Night | Like a typical Abyssal Kraken Queen, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_02044` | Goldmere Coast Abyssal Kraken Queen Elderborn | [[Regions/Goldmere Coast\|Goldmere Coast]] | Elderborn | EX | 300 | 270 m | Night | Like a typical Abyssal Kraken Queen, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_02045` | Whitewater Reach Abyssal Kraken Queen | [[Regions/Whitewater Reach\|Whitewater Reach]] | Adult | SSS | 281 | 200 m | Night | A typical adult Abyssal Kraken Queen of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_02046` | Whitewater Reach Abyssal Kraken Queen Scarred | [[Regions/Whitewater Reach\|Whitewater Reach]] | Scarred | SSS+ | 294 | 220 m | Night | Like a typical Abyssal Kraken Queen, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_02047` | Whitewater Reach Abyssal Kraken Queen Alpha | [[Regions/Whitewater Reach\|Whitewater Reach]] | Alpha | EX- | 300 | 250 m | Night | Like a typical Abyssal Kraken Queen, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_02048` | Whitewater Reach Abyssal Kraken Queen Elderborn | [[Regions/Whitewater Reach\|Whitewater Reach]] | Elderborn | EX | 300 | 270 m | Night | Like a typical Abyssal Kraken Queen, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_02049` | Whitewater Reach Abyssal Kraken Queen Albino | [[Regions/Whitewater Reach\|Whitewater Reach]] | Albino | SSS+ | 294 | 200 m | Night | Like a typical Abyssal Kraken Queen, but a rare pale form with white skin or fur and red eyes. |
| `pop_02050` | Goldmere Coast Abyssal Kraken Queen Scarred | [[Regions/Goldmere Coast\|Goldmere Coast]] | Scarred | SSS+ | 294 | 220 m | Night | Like a typical Abyssal Kraken Queen, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |

## Design recipe

Rig `rig_cephalopod` · mesh `cephalopod_base` · material `wet_scale` · VFX `void_distortion` · palette `#9aa4b0` `#646c7a` `#8a7cff` · elongated, irregular silhouette; still-then-sudden timing
