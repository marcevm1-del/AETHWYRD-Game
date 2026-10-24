---
type: monster
id: mon_poison_slime
family: "Slimes"
rank: "E"
tier: core
tags: [monster, slimes]
---
# Poison Slime

![[mon_poison_slime_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_poison_slime_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,726 tris · 0.612 × 0.612 × 0.6 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Poison Slime is a small creature with a wobbling mound of translucent gel, about 0.6 m tall. Its gel is rough, scarred and spiked, colored in bruise purple with sickly green. Survivors describe purple bubbles that hiss when they pop. It has burning slit pupils. Small scars and rough edges mark it as a survivor. It charges without hesitation, surrounded by a low toxic haze that clings to the ground.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Rank · level | E · 26 (19–32) |
| Menace | 3 · Menacing |
| Element · weakness | Poison · Light |
| Size | 0.6 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 750 · 91 · 68 · 68 · 68 · 110 |
| XP · gold | 559 · 147 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/blob\|blob]] · `anim_blob` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Greymoor\|Greymoor]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Light. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/blob|blob]] (rigId); animation set `anim_blob`.
- **Dimensions:** 0.6 m high × 0.56 m long × 0.54 m wide; prefab scale 1.2.
- **Physics:** 113.4 kg, gravity ×1.6, poise 31, knockback resistance 0.13, death style `splat_dissolve`.
- **Navigation:** speed 4.28 m/s, turn 465°/s, stopping distance 0.67 m.
- **Attack count:** 5; **signature:** purple bubbles that hiss when they pop.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Body Slam\|Body Slam]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Split\|Split]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Acid Splash\|Acid Splash]] | ranged | 1.1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Poison Slime is a **menacing ooze** encountered at E rank, around level 26. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** purple bubbles that hiss when they pop. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Greymoor|Greymoor]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_blob`, animation set `anim_blob`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Slimes E|loot_slime_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Slimes/Vesper-Touched Poison Slime|Vesper-Touched Poison Slime]]
- [[Monsters/Slimes/Greater Poison Slime|Greater Poison Slime]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 3 | E-, D, F+ | 13–48 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 3 | E-, D, D- | 19–48 | Day & Night |
| [[Regions/Whisperwood\|Whisperwood]] | 2 | D, E+ | 32–48 | Day & Night |
| [[Regions/Greymoor\|Greymoor]] | 3 | E, D, E+ | 26–48 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00034` | Great Labyrinth (Floors 1-40) Poison Slime Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | E- | 19 | 0.51 m | Day & Night | Like a typical Poison Slime, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_00035` | Aldmere Poison Slime Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E- | 19 | 0.51 m | Day & Night | Like a typical Poison Slime, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_00036` | Whisperwood Poison Slime Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | D | 48 | 0.81 m | Day & Night | Like a typical Poison Slime, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_00037` | Aldmere Poison Slime Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | D | 48 | 0.81 m | Day & Night | Like a typical Poison Slime, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_00038` | Greymoor Poison Slime | [[Regions/Greymoor\|Greymoor]] | Adult | E | 26 | 0.6 m | Day & Night | A typical adult Poison Slime of this region, with mud-slick, algae-streaked skin. |
| `pop_00039` | Great Labyrinth (Floors 1-40) Poison Slime Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | D | 48 | 0.81 m | Day & Night | Like a typical Poison Slime, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_00040` | Whisperwood Poison Slime Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | E+ | 32 | 0.6 m | Day & Night | Like a typical Poison Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_00041` | Greymoor Poison Slime Elderborn | [[Regions/Greymoor\|Greymoor]] | Elderborn | D | 48 | 0.81 m | Day & Night | Like a typical Poison Slime, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |
| `pop_00042` | Greymoor Poison Slime Albino | [[Regions/Greymoor\|Greymoor]] | Albino | E+ | 32 | 0.6 m | Day & Night | Like a typical Poison Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_00043` | Aldmere Poison Slime Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D- | 40 | 0.75 m | Day & Night | Like a typical Poison Slime, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_00044` | Great Labyrinth (Floors 1-40) Poison Slime Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | F+ | 13 | 0.42 m | Day & Night | Like a typical Poison Slime, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · triangle-based silhouette, sharp asymmetric spikes
