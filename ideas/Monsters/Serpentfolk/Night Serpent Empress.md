---
type: monster
id: mon_night_serpent_empress
family: "Serpentfolk"
rank: "S+"
tier: variant
tags: [monster, serpentfolk]
---
# Night Serpent Empress

> The Night Serpent Empress is a huge creature with a humanoid upper body on a long serpent tail, about 12 m long. Its scales are rough, scarred and spiked, colored in ink black with bruised violet. Guild sketches always show a crown of living snakes. It has burning slit pupils. Its regal silhouette is crowned by a halo-like ring of aura. It strides with heavy steps, surrounded by shadows that lean toward it. This Dark-attuned variant carries one extra elemental feature, like element-scarred hide, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Serpentfolk|Serpentfolk]] · Serpentfolk |
| Variant of | [[Monsters/Serpentfolk/Serpent Empress\|Serpent Empress]] (elemental) |
| Rank · level | S+ · 203 (188–218) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 12 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 63576 · 986 · 822 · 658 · 740 · 100 |
| XP · gold | 14769 · 2553 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/naga\|naga]] · `anim_naga` |
| Habitats | [[Regions/Nox Dominion\|Nox Dominion]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] |
| Genre | Jungle Temple |
| Trope | Lamia and naga temple guardians |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/naga|naga]] (rigId); animation set `anim_naga`.
- **Dimensions:** 5.52 m high × 12 m long × 1.92 m wide; prefab scale 3.
- **Physics:** 5961.6 kg, gravity ×1.3, poise 629, knockback resistance 0.58, death style `limp_chain`.
- **Navigation:** speed 7.93 m/s, turn 101°/s, stopping distance 1 m.
- **Attack count:** 5; **signature:** a crown of living snakes.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Coil Strike\|Coil Strike]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Constrict\|Constrict]] | grab | 1.8 | 12 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Hypnotic Gaze\|Hypnotic Gaze]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Venom Coil\|Venom Coil]] | grab | 1.3 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Night Serpent Empress is a **menacing serpentfolk** encountered at S+ rank, around level 203. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a crown of living snakes. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Nox Dominion|Nox Dominion]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_naga`, animation set `anim_naga`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Serpentfolk S|loot_serpentfolk_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Serpent Scale\|Serpent Scale]] | 60% | 1–3 |
| [[Items/Temple Gold\|Temple Gold]] | 30% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 5 | S, SS, SS-, S- | 173–236 | Day & Night |
| [[Regions/Nox Dominion\|Nox Dominion]] | 6 | SS-, S, S-, S+, SS | 173–236 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05125` | Great Labyrinth (Floors 41-90) Night Serpent Empress Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | S | 188 | 10.2 m | Day & Night | Like a typical Night Serpent Empress, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_05126` | Nox Dominion Night Serpent Empress Albino | [[Regions/Nox Dominion\|Nox Dominion]] | Albino | SS- | 218 | 12 m | Day & Night | Like a typical Night Serpent Empress, but a rare pale form with white skin or fur and red eyes. |
| `pop_05127` | Nox Dominion Night Serpent Empress Scarred | [[Regions/Nox Dominion\|Nox Dominion]] | Scarred | SS- | 218 | 13.2 m | Day & Night | Like a typical Night Serpent Empress, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_05128` | Great Labyrinth (Floors 41-90) Night Serpent Empress Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | SS | 236 | 15 m | Day & Night | Like a typical Night Serpent Empress, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_05129` | Great Labyrinth (Floors 41-90) Night Serpent Empress Albino | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Albino | SS- | 218 | 12 m | Day & Night | Like a typical Night Serpent Empress, but a rare pale form with white skin or fur and red eyes. |
| `pop_05130` | Nox Dominion Night Serpent Empress Juvenile | [[Regions/Nox Dominion\|Nox Dominion]] | Juvenile | S | 188 | 10.2 m | Day & Night | Like a typical Night Serpent Empress, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_05131` | Nox Dominion Night Serpent Empress Runt | [[Regions/Nox Dominion\|Nox Dominion]] | Runt | S- | 173 | 8.4 m | Day & Night | Like a typical Night Serpent Empress, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_05132` | Nox Dominion Night Serpent Empress | [[Regions/Nox Dominion\|Nox Dominion]] | Adult | S+ | 203 | 12 m | Day & Night | A typical adult Night Serpent Empress of this region, with dust-grey coloring and old rune scars. |
| `pop_05133` | Nox Dominion Night Serpent Empress Alpha | [[Regions/Nox Dominion\|Nox Dominion]] | Alpha | SS | 236 | 15 m | Day & Night | Like a typical Night Serpent Empress, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_05134` | Great Labyrinth (Floors 41-90) Night Serpent Empress Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | SS- | 218 | 13.2 m | Day & Night | Like a typical Night Serpent Empress, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_05135` | Great Labyrinth (Floors 41-90) Night Serpent Empress Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | S- | 173 | 8.4 m | Day & Night | Like a typical Night Serpent Empress, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_naga` · mesh `naga_base` · material `scale_gloss` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · triangle-based silhouette, sharp asymmetric spikes
