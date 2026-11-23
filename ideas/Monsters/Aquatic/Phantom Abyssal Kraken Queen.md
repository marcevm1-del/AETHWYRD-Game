---
type: monster
id: mon_phantom_abyssal_kraken_queen
family: "Aquatic"
rank: "SSS+"
tier: variant
tags: [monster, aquatic]
---
# Phantom Abyssal Kraken Queen

![[mon_phantom_abyssal_kraken_queen_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_phantom_abyssal_kraken_queen_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 30,000 tris · 163.494 × 199.986 × 206.1 m · local file `Game/Assets/_Game/Art/Models/Monsters/Aquatic/mon_phantom_abyssal_kraken_queen.fbx`

> The Phantom Abyssal Kraken Queen is a colossal creature with a bulbous body with writhing arms, about 200 m long. Its scales and skin are stretched, stitched and constantly shifting, colored in silver, with gold markings. Its most striking feature is tentacles that can wrap around whole islands. It has too many eyes, opening one after another. Its outline is crowned by slowly turning rings of light; lesser monsters flee from it. It unfolds into something larger, surrounded by soft radiance and floating motes of light. Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.

| Field | Value |
|---|---|
| Family · type | [[Families/Aquatic|Aquatic]] · Aquatic |
| Variant of | [[Monsters/Aquatic/Abyssal Kraken Queen\|Abyssal Kraken Queen]] (spirit) |
| Rank · level | SSS+ · 294 (281–300) |
| Menace | 5 · Horror |
| Element · weakness | Light · Dark |
| Size | 200 m |
| Behaviour | Territorial (territorial_guard+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 159003 · 1483 · 1067 · 1067 · 1067 · 100 |
| XP · gold | 26706 · 4286 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/tentacled\|tentacled]] · `anim_cephalopod` |
| Habitats | [[Regions/Goldmere Coast\|Goldmere Coast]], [[Regions/Whitewater Reach\|Whitewater Reach]] |
| Genre | Seafaring |
| Trope | Sea kings and krakens (One Piece), sirens and merfolk |

**Field note:** Weak to Dark. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/tentacled|tentacled]] (rigId); animation set `anim_cephalopod`.
- **Dimensions:** 110 m high × 200 m long × 240 m wide; prefab scale 66.667.
- **Physics:** 152000000 kg, gravity ×0.9, poise 119723, knockback resistance 0.94, death style `sink_limp`.
- **Navigation:** speed 50.95 m/s, turn 60°/s, stopping distance 12.4 m.
- **Attack count:** 5; **signature:** tentacles that can wrap around whole islands.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Tentacle Slap\|Tentacle Slap]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Drag Under\|Drag Under]] | grab | 1.8 | 12 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Ink Cloud\|Ink Cloud]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Tidal Drag\|Tidal Drag]] | grab | 1.3 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Phantom Abyssal Kraken Queen is a **horror aquatic** encountered at SSS+ rank, around level 294. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

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

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Goldmere Coast\|Goldmere Coast]] | 5 | SSS+, SSS, EX-, EX+ | 281–300 | Night |
| [[Regions/Whitewater Reach\|Whitewater Reach]] | 6 | EX-, SSS-, SSS, EX, EX+ | 267–300 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04906` | Goldmere Coast Phantom Abyssal Kraken Queen | [[Regions/Goldmere Coast\|Goldmere Coast]] | Adult | SSS+ | 294 | 200 m | Night | A typical adult Phantom Abyssal Kraken Queen of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_04907` | Goldmere Coast Phantom Abyssal Kraken Queen Juvenile | [[Regions/Goldmere Coast\|Goldmere Coast]] | Juvenile | SSS | 281 | 170 m | Night | Like a typical Phantom Abyssal Kraken Queen, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_04908` | Goldmere Coast Phantom Abyssal Kraken Queen Albino | [[Regions/Goldmere Coast\|Goldmere Coast]] | Albino | EX- | 300 | 200 m | Night | Like a typical Phantom Abyssal Kraken Queen, but a rare pale form with white skin or fur and red eyes. |
| `pop_04909` | Whitewater Reach Phantom Abyssal Kraken Queen Scarred | [[Regions/Whitewater Reach\|Whitewater Reach]] | Scarred | EX- | 300 | 220 m | Night | Like a typical Phantom Abyssal Kraken Queen, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_04910` | Whitewater Reach Phantom Abyssal Kraken Queen Runt | [[Regions/Whitewater Reach\|Whitewater Reach]] | Runt | SSS- | 267 | 140 m | Night | Like a typical Phantom Abyssal Kraken Queen, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_04911` | Whitewater Reach Phantom Abyssal Kraken Queen Juvenile | [[Regions/Whitewater Reach\|Whitewater Reach]] | Juvenile | SSS | 281 | 170 m | Night | Like a typical Phantom Abyssal Kraken Queen, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_04912` | Goldmere Coast Phantom Abyssal Kraken Queen Elderborn | [[Regions/Goldmere Coast\|Goldmere Coast]] | Elderborn | EX+ | 300 | 270 m | Night | Like a typical Phantom Abyssal Kraken Queen, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_04913` | Goldmere Coast Phantom Abyssal Kraken Queen Scarred | [[Regions/Goldmere Coast\|Goldmere Coast]] | Scarred | EX- | 300 | 220 m | Night | Like a typical Phantom Abyssal Kraken Queen, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_04914` | Whitewater Reach Phantom Abyssal Kraken Queen Alpha | [[Regions/Whitewater Reach\|Whitewater Reach]] | Alpha | EX | 300 | 250 m | Night | Like a typical Phantom Abyssal Kraken Queen, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_04915` | Whitewater Reach Phantom Abyssal Kraken Queen Albino | [[Regions/Whitewater Reach\|Whitewater Reach]] | Albino | EX- | 300 | 200 m | Night | Like a typical Phantom Abyssal Kraken Queen, but a rare pale form with white skin or fur and red eyes. |
| `pop_04916` | Whitewater Reach Phantom Abyssal Kraken Queen Elderborn | [[Regions/Whitewater Reach\|Whitewater Reach]] | Elderborn | EX+ | 300 | 270 m | Night | Like a typical Phantom Abyssal Kraken Queen, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |

## Design recipe

Rig `rig_cephalopod` · mesh `cephalopod_base` · material `wet_scale` · VFX `holy_motes` · palette `#a0aab7` `#68707f` `#ffd166` · broken symmetry, mimicry, audio-first reveal
