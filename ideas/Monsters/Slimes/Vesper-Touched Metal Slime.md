---
type: monster
id: mon_vesper_touched_metal_slime
family: "Slimes"
rank: "C-"
tier: variant
tags: [monster, slimes]
---
# Vesper-Touched Metal Slime

> The Vesper-Touched Metal Slime is a tiny creature with a wobbling mound of translucent gel, about 0.3 m tall. Its gel is weathered and natural, colored in ochre, clay and mossy stone. Survivors describe mirror-chrome skin that reflects the world around it. It has amber predator eyes. Battle-worn plates and trophies hang from its body. It lopes in long strides, surrounded by pebbles that tremble and float near it. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Variant of | [[Monsters/Slimes/Metal Slime\|Metal Slime]] (corrupted) |
| Rank · level | C- · 65 (56–76) |
| Menace | 2 · Wild |
| Element · weakness | Earth · Wind |
| Size | 0.3 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2408 · 216 · 162 · 162 · 162 · 110 |
| XP · gold | 2395 · 521 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/blob\|blob]] · `anim_blob` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Wind. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/blob|blob]] (rigId); animation set `anim_blob`.
- **Dimensions:** 0.3 m high × 0.28 m long × 0.27 m wide; prefab scale 0.6.
- **Physics:** 18.4 kg, gravity ×1.76, poise 28, knockback resistance 0.34, death style `splat_dissolve`.
- **Navigation:** speed 2.73 m/s, turn 657°/s, stopping distance 0.54 m.
- **Attack count:** 5; **signature:** mirror-chrome skin that reflects the world around it.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Body Slam\|Body Slam]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Split\|Split]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Acid Splash\|Acid Splash]] | ranged | 1.1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched Metal Slime is a **wild ooze** encountered at C- rank, around level 65. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** mirror-chrome skin that reflects the world around it. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_blob`, animation set `anim_blob`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Slimes C|loot_slime_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Moraveil\|Moraveil]] | 6 | C, D, C-, C+, B- | 48–96 | Day & Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 5 | D+, B-, C-, C, D | 48–96 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05802` | Moraveil Vesper-Touched Metal Slime Albino | [[Regions/Moraveil\|Moraveil]] | Albino | C | 76 | 0.3 m | Day & Night | Like a typical Vesper-Touched Metal Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_05803` | Moraveil Vesper-Touched Metal Slime Runt | [[Regions/Moraveil\|Moraveil]] | Runt | D | 48 | 0.21 m | Day & Night | Like a typical Vesper-Touched Metal Slime, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_05804` | Moraveil Vesper-Touched Metal Slime Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | C | 76 | 0.33 m | Day & Night | Like a typical Vesper-Touched Metal Slime, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_05805` | Great Labyrinth (Floors 41-90) Vesper-Touched Metal Slime Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | D+ | 56 | 0.26 m | Day & Night | Like a typical Vesper-Touched Metal Slime, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_05806` | Moraveil Vesper-Touched Metal Slime | [[Regions/Moraveil\|Moraveil]] | Adult | C- | 65 | 0.3 m | Day & Night | A typical adult Vesper-Touched Metal Slime of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_05807` | Moraveil Vesper-Touched Metal Slime Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | C+ | 86 | 0.38 m | Day & Night | Like a typical Vesper-Touched Metal Slime, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_05808` | Great Labyrinth (Floors 41-90) Vesper-Touched Metal Slime Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | B- | 96 | 0.41 m | Day & Night | Like a typical Vesper-Touched Metal Slime, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_05809` | Great Labyrinth (Floors 41-90) Vesper-Touched Metal Slime | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Adult | C- | 65 | 0.3 m | Day & Night | A typical adult Vesper-Touched Metal Slime of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_05810` | Great Labyrinth (Floors 41-90) Vesper-Touched Metal Slime Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | C | 76 | 0.33 m | Day & Night | Like a typical Vesper-Touched Metal Slime, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_05811` | Moraveil Vesper-Touched Metal Slime Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | B- | 96 | 0.41 m | Day & Night | Like a typical Vesper-Touched Metal Slime, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_05812` | Great Labyrinth (Floors 41-90) Vesper-Touched Metal Slime Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | D | 48 | 0.21 m | Day & Night | Like a typical Vesper-Touched Metal Slime, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · real-animal silhouette with one fantasy exaggeration
