---
type: monster
id: mon_iron_prismatic_slime_sovereign
family: "Slimes"
rank: "SSS+"
tier: variant
tags: [monster, slimes]
---
# Iron Prismatic Slime Sovereign

![[mon_iron_prismatic_slime_sovereign_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_iron_prismatic_slime_sovereign_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,096 tris · 8.505 × 8.505 × 8 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Iron Prismatic Slime Sovereign is a huge creature with a dome-shaped gelatinous body, about 8 m tall. Its gel is weathered and natural, colored in ochre, clay and mossy stone. Guild sketches always show a crown of rainbow light refracted through its whole body. It has amber predator eyes. Its outline is crowned by slowly turning rings of light; lesser monsters flee from it. It prowls, surrounded by pebbles that tremble and float near it. This Earth-attuned variant carries one extra elemental feature, like glowing vein-lines, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Variant of | [[Monsters/Slimes/Prismatic Slime Sovereign\|Prismatic Slime Sovereign]] (elemental) |
| Rank · level | SSS+ · 294 (281–300) |
| Menace | 2 · Wild |
| Element · weakness | Earth · Wind |
| Size | 8 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 62853 · 949 · 712 · 712 · 712 · 110 |
| XP · gold | 26706 · 4286 |
| Ring | 9 |
| Rig · animation | [[Systems/Rigs/blob\|blob]] · `anim_blob` |
| Habitats | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]], [[Regions/Root of the World\|Root of the World]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Wind. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/blob|blob]] (rigId); animation set `anim_blob`.
- **Dimensions:** 8 m high × 7.44 m long × 7.2 m wide; prefab scale 16.
- **Physics:** 349440 kg, gravity ×1.76, poise 220, knockback resistance 0.49, death style `splat_dissolve`.
- **Navigation:** speed 14.12 m/s, turn 127°/s, stopping distance 4 m.
- **Attack count:** 5; **signature:** a crown of rainbow light refracted through its whole body.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Body Slam\|Body Slam]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Split\|Split]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Acid Splash\|Acid Splash]] | ranged | 1.1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Iron Prismatic Slime Sovereign is a **wild ooze** encountered at SSS+ rank, around level 294. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a crown of rainbow light refracted through its whole body. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 91-120)|Great Labyrinth (Floors 91-120)]], [[Regions/Root of the World|Root of the World]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_blob`, animation set `anim_blob`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Slimes SSS|loot_slime_sss]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/SSS-Rank Monster Core\|SSS-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | 5 | EX-, SSS+, EX, SSS, SSS- | 267–300 | Day & Night |
| [[Regions/Root of the World\|Root of the World]] | 6 | EX, EX-, SSS-, SSS+, EX+, SSS | 267–300 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05890` | Great Labyrinth (Floors 91-120) Iron Prismatic Slime Sovereign Albino | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Albino | EX- | 300 | 8 m | Day & Night | Like a typical Iron Prismatic Slime Sovereign, but a rare pale form with white skin or fur and red eyes. |
| `pop_05891` | Root of the World Iron Prismatic Slime Sovereign Alpha | [[Regions/Root of the World\|Root of the World]] | Alpha | EX | 300 | 10 m | Day & Night | Like a typical Iron Prismatic Slime Sovereign, but larger and scarred, and others of its kind follow it, with bioluminescent spots along its body. |
| `pop_05892` | Root of the World Iron Prismatic Slime Sovereign Albino | [[Regions/Root of the World\|Root of the World]] | Albino | EX- | 300 | 8 m | Day & Night | Like a typical Iron Prismatic Slime Sovereign, but a rare pale form with white skin or fur and red eyes. |
| `pop_05893` | Great Labyrinth (Floors 91-120) Iron Prismatic Slime Sovereign | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Adult | SSS+ | 294 | 8 m | Day & Night | A typical adult Iron Prismatic Slime Sovereign of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_05894` | Root of the World Iron Prismatic Slime Sovereign Runt | [[Regions/Root of the World\|Root of the World]] | Runt | SSS- | 267 | 5.6 m | Day & Night | Like a typical Iron Prismatic Slime Sovereign, but smaller and scrappier than usual, with bioluminescent spots along its body. |
| `pop_05895` | Great Labyrinth (Floors 91-120) Iron Prismatic Slime Sovereign Alpha | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Alpha | EX | 300 | 10 m | Day & Night | Like a typical Iron Prismatic Slime Sovereign, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_05896` | Root of the World Iron Prismatic Slime Sovereign | [[Regions/Root of the World\|Root of the World]] | Adult | SSS+ | 294 | 8 m | Day & Night | A typical adult Iron Prismatic Slime Sovereign of this region, with bioluminescent spots along its body. |
| `pop_05897` | Great Labyrinth (Floors 91-120) Iron Prismatic Slime Sovereign Juvenile | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Juvenile | SSS | 281 | 6.8 m | Day & Night | Like a typical Iron Prismatic Slime Sovereign, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_05898` | Root of the World Iron Prismatic Slime Sovereign Elderborn | [[Regions/Root of the World\|Root of the World]] | Elderborn | EX+ | 300 | 10.8 m | Day & Night | Like a typical Iron Prismatic Slime Sovereign, but old and wise, with greying features and a cautious hunting style, with bioluminescent spots along its body. |
| `pop_05899` | Root of the World Iron Prismatic Slime Sovereign Juvenile | [[Regions/Root of the World\|Root of the World]] | Juvenile | SSS | 281 | 6.8 m | Day & Night | Like a typical Iron Prismatic Slime Sovereign, but young, with brighter colors and unworn features, with bioluminescent spots along its body. |
| `pop_05900` | Great Labyrinth (Floors 91-120) Iron Prismatic Slime Sovereign Runt | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Runt | SSS- | 267 | 5.6 m | Day & Night | Like a typical Iron Prismatic Slime Sovereign, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · real-animal silhouette with one fantasy exaggeration
