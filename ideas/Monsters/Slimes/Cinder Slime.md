---
type: monster
id: mon_cinder_slime
family: "Slimes"
rank: "B+"
tier: variant
tags: [monster, slimes]
---
# Cinder Slime

![[mon_cinder_slime_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_cinder_slime_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 11,998 tris · 1.101 × 1.058 × 1.2 m · local file `Game/Assets/_Game/Art/Models/Monsters/Slimes/mon_cinder_slime.fbx`

> The Cinder Slime is a person-sized creature with a dome-shaped gelatinous body, about 1.2 m tall. Its gel is weathered and natural, colored in ember reds fading to soot black. Guild sketches always show a storm-cloud interior that flashes with tiny lightning. It has amber predator eyes. Faint runes glow along its body when it fights. It lopes in long strides, surrounded by heat-shimmer and drifting sparks. This Fire-attuned variant carries one extra elemental feature, like element-scarred hide, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Variant of | [[Monsters/Slimes/Storm Slime\|Storm Slime]] (elemental) |
| Rank · level | B+ · 120 (108–132) |
| Menace | 2 · Wild |
| Element · weakness | Fire · Water |
| Size | 1.2 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 8839 · 392 · 294 · 294 · 294 · 110 |
| XP · gold | 6373 · 1225 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/blob\|blob]] · `anim_blob` |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Moraveil\|Moraveil]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Water. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/blob|blob]] (rigId); animation set `anim_blob`.
- **Dimensions:** 1.2 m high × 1.12 m long × 1.08 m wide; prefab scale 2.4.
- **Physics:** 907.2 kg, gravity ×1.6, poise 62, knockback resistance 0.22, death style `splat_dissolve`.
- **Navigation:** speed 6.24 m/s, turn 329°/s, stopping distance 0.94 m.
- **Attack count:** 5; **signature:** a storm-cloud interior that flashes with tiny lightning.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Body Slam\|Body Slam]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Split\|Split]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Acid Splash\|Acid Splash]] | ranged | 1.1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Cinder Slime is a **wild ooze** encountered at B+ rank, around level 120. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a storm-cloud interior that flashes with tiny lightning. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Moraveil|Moraveil]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_blob`, animation set `anim_blob`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Slimes B|loot_slime_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Moraveil\|Moraveil]] | 5 | A, B, A-, A+, B+ | 108–159 | Day & Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 6 | A-, A, A+, B, B+, B- | 96–159 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03027` | Moraveil Cinder Slime Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | A | 146 | 1.5 m | Day & Night | Like a typical Cinder Slime, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_03028` | Moraveil Cinder Slime Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | B | 108 | 1.02 m | Day & Night | Like a typical Cinder Slime, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_03029` | Moraveil Cinder Slime Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | A- | 132 | 1.32 m | Day & Night | Like a typical Cinder Slime, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_03030` | Great Labyrinth (Floors 41-90) Cinder Slime Albino | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Albino | A- | 132 | 1.2 m | Day & Night | Like a typical Cinder Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_03031` | Great Labyrinth (Floors 41-90) Cinder Slime Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | A | 146 | 1.5 m | Day & Night | Like a typical Cinder Slime, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_03032` | Great Labyrinth (Floors 41-90) Cinder Slime Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | A+ | 159 | 1.62 m | Day & Night | Like a typical Cinder Slime, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_03033` | Great Labyrinth (Floors 41-90) Cinder Slime Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | B | 108 | 1.02 m | Day & Night | Like a typical Cinder Slime, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_03034` | Great Labyrinth (Floors 41-90) Cinder Slime | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Adult | B+ | 120 | 1.2 m | Day & Night | A typical adult Cinder Slime of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_03035` | Moraveil Cinder Slime Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | A+ | 159 | 1.62 m | Day & Night | Like a typical Cinder Slime, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_03036` | Great Labyrinth (Floors 41-90) Cinder Slime Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | B- | 96 | 0.84 m | Day & Night | Like a typical Cinder Slime, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_03037` | Moraveil Cinder Slime | [[Regions/Moraveil\|Moraveil]] | Adult | B+ | 120 | 1.2 m | Day & Night | A typical adult Cinder Slime of this region, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#401d14` · real-animal silhouette with one fantasy exaggeration
