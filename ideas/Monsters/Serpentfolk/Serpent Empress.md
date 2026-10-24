---
type: monster
id: mon_serpent_empress
family: "Serpentfolk"
rank: "S"
tier: core
tags: [monster, serpentfolk]
---
# Serpent Empress

![[mon_serpent_empress_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_serpent_empress_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (5,882 tris · 6.07 × 12 × 7.661 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Serpent Empress is a huge creature with a humanoid upper body on a long serpent tail, about 12 m long. Its scales are rough, scarred and spiked, colored in bruise purple with sickly green. Look for a crown of living snakes. It has narrow glowing eyes. Its regal silhouette is crowned by a halo-like ring of aura. It strides with heavy steps, surrounded by a low toxic haze that clings to the ground.

| Field | Value |
|---|---|
| Family · type | [[Families/Serpentfolk|Serpentfolk]] · Serpentfolk |
| Rank · level | S · 188 (173–203) |
| Menace | 3 · Menacing |
| Element · weakness | Poison · Light |
| Size | 12 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 56677 · 914 · 762 · 610 · 686 · 100 |
| XP · gold | 13063 · 2293 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/naga\|naga]] · `anim_naga` |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] |
| Genre | Jungle Temple |
| Trope | Lamia and naga temple guardians |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/naga|naga]] (rigId); animation set `anim_naga`.
- **Dimensions:** 5.52 m high × 12 m long × 1.92 m wide; prefab scale 3.
- **Physics:** 5961.6 kg, gravity ×1.3, poise 629, knockback resistance 0.58, death style `limp_chain`.
- **Navigation:** speed 7.32 m/s, turn 101°/s, stopping distance 1 m.
- **Attack count:** 5; **signature:** a crown of living snakes.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Coil Strike\|Coil Strike]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Constrict\|Constrict]] | grab | 1.8 | 12 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Hypnotic Gaze\|Hypnotic Gaze]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Venom Coil\|Venom Coil]] | grab | 1.3 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Serpent Empress is a **menacing serpentfolk** encountered at S rank, around level 188. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a crown of living snakes. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Great Labyrinth (Floors 91-120)|Great Labyrinth (Floors 91-120)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_naga`, animation set `anim_naga`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Serpentfolk S|loot_serpentfolk_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Serpent Scale\|Serpent Scale]] | 60% | 1–3 |
| [[Items/Temple Gold\|Temple Gold]] | 30% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Serpentfolk/Night Serpent Empress|Night Serpent Empress]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 7 | SS, S, A+, SS-, S+, S- | 159–236 | Day & Night |
| [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | 4 | S+, A+, S-, SS- | 159–218 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02274` | Great Labyrinth (Floors 41-90) Serpent Empress Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | SS | 236 | 16.2 m | Day & Night | Like a typical Serpent Empress, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_02275` | Great Labyrinth (Floors 41-90) Serpent Empress | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Adult | S | 188 | 12 m | Day & Night | A typical adult Serpent Empress of this region, with dust-grey coloring and old rune scars. |
| `pop_02276` | Great Labyrinth (Floors 91-120) Serpent Empress Scarred | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Scarred | S+ | 203 | 13.2 m | Day & Night | Like a typical Serpent Empress, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_02277` | Great Labyrinth (Floors 41-90) Serpent Empress Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | A+ | 159 | 8.4 m | Day & Night | Like a typical Serpent Empress, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_02278` | Great Labyrinth (Floors 41-90) Serpent Empress Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | SS- | 218 | 15 m | Day & Night | Like a typical Serpent Empress, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_02279` | Great Labyrinth (Floors 41-90) Serpent Empress Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | S+ | 203 | 13.2 m | Day & Night | Like a typical Serpent Empress, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_02280` | Great Labyrinth (Floors 41-90) Serpent Empress Albino | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Albino | S+ | 203 | 12 m | Day & Night | Like a typical Serpent Empress, but a rare pale form with white skin or fur and red eyes. |
| `pop_02281` | Great Labyrinth (Floors 91-120) Serpent Empress Runt | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Runt | A+ | 159 | 8.4 m | Day & Night | Like a typical Serpent Empress, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_02282` | Great Labyrinth (Floors 41-90) Serpent Empress Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | S- | 173 | 10.2 m | Day & Night | Like a typical Serpent Empress, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_02283` | Great Labyrinth (Floors 91-120) Serpent Empress Juvenile | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Juvenile | S- | 173 | 10.2 m | Day & Night | Like a typical Serpent Empress, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_02284` | Great Labyrinth (Floors 91-120) Serpent Empress Alpha | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Alpha | SS- | 218 | 15 m | Day & Night | Like a typical Serpent Empress, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_naga` · mesh `naga_base` · material `scale_gloss` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · triangle-based silhouette, sharp asymmetric spikes
