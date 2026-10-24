---
type: monster
id: mon_ancient_ember_ooze
family: "Slimes"
rank: "B"
tier: variant
tags: [monster, slimes]
---
# Ancient Ember Ooze

> The Ancient Ember Ooze is a person-sized creature with a dome-shaped gelatinous body, about 2.3 m tall. Its gel is rough, scarred and spiked, colored in ember reds fading to soot black. Its most striking feature is molten trails that harden into glass behind it. It has narrow glowing eyes. Faint runes glow along its body when it fights. It charges without hesitation, surrounded by heat-shimmer and drifting sparks. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Variant of | [[Monsters/Slimes/Ember Ooze\|Ember Ooze]] (ancient) |
| Rank · level | B · 108 (96–120) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 2.3 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 9425 · 354 · 265 · 265 · 265 · 110 |
| XP · gold | 5386 · 1057 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/blob\|blob]] · `anim_blob` |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Strife Marches\|Strife Marches]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Water. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/blob|blob]] (rigId); animation set `anim_blob`.
- **Dimensions:** 2.3 m high × 2.14 m long × 2.07 m wide; prefab scale 4.6.
- **Physics:** 6387.7 kg, gravity ×1.6, poise 86, knockback resistance 0.22, death style `splat_dissolve`.
- **Navigation:** speed 9.07 m/s, turn 237°/s, stopping distance 1.44 m.
- **Attack count:** 5; **signature:** molten trails that harden into glass behind it.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Body Slam\|Body Slam]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Split\|Split]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Acid Splash\|Acid Splash]] | ranged | 1.1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Ancient Ember Ooze is a **menacing ooze** encountered at B rank, around level 108. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** molten trails that harden into glass behind it. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Strife Marches|Strife Marches]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 6 | A-, C+, B, B+, B-, A | 86–146 | Day & Night |
| [[Regions/Strife Marches\|Strife Marches]] | 5 | A, B+, B, B- | 96–146 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05857` | Great Labyrinth (Floors 41-90) Ancient Ember Ooze Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | A- | 132 | 2.88 m | Day & Night | Like a typical Ancient Ember Ooze, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_05858` | Strife Marches Ancient Ember Ooze Elderborn | [[Regions/Strife Marches\|Strife Marches]] | Elderborn | A | 146 | 3.1 m | Day & Night | Like a typical Ancient Ember Ooze, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_05859` | Great Labyrinth (Floors 41-90) Ancient Ember Ooze Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | C+ | 86 | 1.61 m | Day & Night | Like a typical Ancient Ember Ooze, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_05860` | Strife Marches Ancient Ember Ooze Albino | [[Regions/Strife Marches\|Strife Marches]] | Albino | B+ | 120 | 2.3 m | Day & Night | Like a typical Ancient Ember Ooze, but a rare pale form with white skin or fur and red eyes. |
| `pop_05861` | Strife Marches Ancient Ember Ooze Scarred | [[Regions/Strife Marches\|Strife Marches]] | Scarred | B+ | 120 | 2.53 m | Day & Night | Like a typical Ancient Ember Ooze, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_05862` | Great Labyrinth (Floors 41-90) Ancient Ember Ooze | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Adult | B | 108 | 2.3 m | Day & Night | A typical adult Ancient Ember Ooze of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_05863` | Great Labyrinth (Floors 41-90) Ancient Ember Ooze Albino | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Albino | B+ | 120 | 2.3 m | Day & Night | Like a typical Ancient Ember Ooze, but a rare pale form with white skin or fur and red eyes. |
| `pop_05864` | Strife Marches Ancient Ember Ooze | [[Regions/Strife Marches\|Strife Marches]] | Adult | B | 108 | 2.3 m | Day & Night | A typical adult Ancient Ember Ooze of this region, with golden, grass-toned coloring. |
| `pop_05865` | Great Labyrinth (Floors 41-90) Ancient Ember Ooze Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | B- | 96 | 1.95 m | Day & Night | Like a typical Ancient Ember Ooze, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_05866` | Strife Marches Ancient Ember Ooze Juvenile | [[Regions/Strife Marches\|Strife Marches]] | Juvenile | B- | 96 | 1.95 m | Day & Night | Like a typical Ancient Ember Ooze, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_05867` | Great Labyrinth (Floors 41-90) Ancient Ember Ooze Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | A | 146 | 3.1 m | Day & Night | Like a typical Ancient Ember Ooze, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · triangle-based silhouette, sharp asymmetric spikes
