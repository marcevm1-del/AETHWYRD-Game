---
type: monster
id: mon_phantom_leviathan_young
family: "Aquatic"
rank: "S+"
tier: variant
tags: [monster, aquatic]
---
# Phantom Leviathan Young

![[mon_phantom_leviathan_young_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_phantom_leviathan_young_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,494 tris · 25.306 × 60 × 43.569 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Phantom Leviathan Young is a colossal creature with a heavy-jawed fish frame, about 60 m long. Its scales and skin are patchy and subtly wrong, as if assembled from memory, colored in teal, with gold markings. Guild sketches always show fins like the sails of a warship. It has pale, pupil-less eyes. Its regal silhouette is crowned by a halo-like ring of aura. It glides without moving its legs, surrounded by soft radiance and floating motes of light. Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.

| Field | Value |
|---|---|
| Family · type | [[Families/Aquatic|Aquatic]] · Aquatic |
| Variant of | [[Monsters/Aquatic/Leviathan Young\|Leviathan Young]] (spirit) |
| Rank · level | S+ · 203 (188–218) |
| Menace | 4 · Dread |
| Element · weakness | Light · Dark |
| Size | 60 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 83982 · 1028 · 740 · 740 · 740 · 100 |
| XP · gold | 14769 · 2553 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/aquatic\|aquatic]] · `anim_fish` |
| Habitats | [[Regions/Goldmere Coast\|Goldmere Coast]], [[Regions/Whitewater Reach\|Whitewater Reach]] |
| Genre | Seafaring |
| Trope | Sea kings and krakens (One Piece), sirens and merfolk |

**Field note:** Weak to Dark. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/aquatic|aquatic]] (rigId); animation set `anim_fish`.
- **Dimensions:** 24 m high × 60 m long × 21.6 m wide; prefab scale 40.
- **Physics:** 4719600 kg, gravity ×0.9, poise 23757, knockback resistance 0.48, death style `float_belly_up`.
- **Navigation:** speed 35.8 m/s, turn 60°/s, stopping distance 7.6 m.
- **Attack count:** 5; **signature:** fins like the sails of a warship.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Bite\|Bite]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Breach Lunge\|Breach Lunge]] | dash | 1.7 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Thrash\|Thrash]] | aoe | 1.3 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Tidal Drag\|Tidal Drag]] | grab | 1.3 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Phantom Leviathan Young is a **dread aquatic** encountered at S+ rank, around level 203. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** fins like the sails of a warship. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Goldmere Coast|Goldmere Coast]], [[Regions/Whitewater Reach|Whitewater Reach]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_fish`, animation set `anim_fish`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Aquatic S|loot_aquatic_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Fish Scale\|Fish Scale]] | 60% | 1–3 |
| [[Items/Pearl\|Pearl]] | 30% | 1–1 |
| [[Items/Ink Sac\|Ink Sac]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Whitewater Reach\|Whitewater Reach]] | 6 | SS-, S+, S-, SS+, SS | 173–253 | Night |
| [[Regions/Goldmere Coast\|Goldmere Coast]] | 5 | SS-, S+, SS, S | 188–236 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04895` | Whitewater Reach Phantom Leviathan Young Albino | [[Regions/Whitewater Reach\|Whitewater Reach]] | Albino | SS- | 218 | 60 m | Night | Like a typical Phantom Leviathan Young, but a rare pale form with white skin or fur and red eyes. |
| `pop_04896` | Goldmere Coast Phantom Leviathan Young Albino | [[Regions/Goldmere Coast\|Goldmere Coast]] | Albino | SS- | 218 | 60 m | Night | Like a typical Phantom Leviathan Young, but a rare pale form with white skin or fur and red eyes. |
| `pop_04897` | Goldmere Coast Phantom Leviathan Young | [[Regions/Goldmere Coast\|Goldmere Coast]] | Adult | S+ | 203 | 60 m | Night | A typical adult Phantom Leviathan Young of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_04898` | Whitewater Reach Phantom Leviathan Young | [[Regions/Whitewater Reach\|Whitewater Reach]] | Adult | S+ | 203 | 60 m | Night | A typical adult Phantom Leviathan Young of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_04899` | Goldmere Coast Phantom Leviathan Young Alpha | [[Regions/Goldmere Coast\|Goldmere Coast]] | Alpha | SS | 236 | 75 m | Night | Like a typical Phantom Leviathan Young, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_04900` | Goldmere Coast Phantom Leviathan Young Scarred | [[Regions/Goldmere Coast\|Goldmere Coast]] | Scarred | SS- | 218 | 66 m | Night | Like a typical Phantom Leviathan Young, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_04901` | Whitewater Reach Phantom Leviathan Young Scarred | [[Regions/Whitewater Reach\|Whitewater Reach]] | Scarred | SS- | 218 | 66 m | Night | Like a typical Phantom Leviathan Young, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_04902` | Whitewater Reach Phantom Leviathan Young Runt | [[Regions/Whitewater Reach\|Whitewater Reach]] | Runt | S- | 173 | 42 m | Night | Like a typical Phantom Leviathan Young, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_04903` | Whitewater Reach Phantom Leviathan Young Elderborn | [[Regions/Whitewater Reach\|Whitewater Reach]] | Elderborn | SS+ | 253 | 81 m | Night | Like a typical Phantom Leviathan Young, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_04904` | Goldmere Coast Phantom Leviathan Young Juvenile | [[Regions/Goldmere Coast\|Goldmere Coast]] | Juvenile | S | 188 | 51 m | Night | Like a typical Phantom Leviathan Young, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_04905` | Whitewater Reach Phantom Leviathan Young Alpha | [[Regions/Whitewater Reach\|Whitewater Reach]] | Alpha | SS | 236 | 75 m | Night | Like a typical Phantom Leviathan Young, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |

## Design recipe

Rig `rig_fish` · mesh `fish_base` · material `wet_scale` · VFX `holy_motes` · palette `#458f8b` `#2e635f` `#ffd166` · elongated, irregular silhouette; still-then-sudden timing
