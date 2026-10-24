---
type: monster
id: mon_sky_mimic_slime
family: "Slimes"
rank: "D+"
tier: variant
tags: [monster, slimes]
---
# Sky Mimic Slime

> The Sky Mimic Slime is a small creature with a dome-shaped gelatinous body, about 1 m tall. Its gel is patchy and subtly wrong, as if assembled from memory, colored in pale jade and cloud white. Guild sketches always show a surface that ripples into the shape of whatever it last ate. It has pale, pupil-less eyes. A distinctive marking runs along its back. It freezes whenever it is looked at, surrounded by swirling leaves and a constant breeze. This Wind-attuned variant carries one extra elemental feature, like crystal spikes, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Variant of | [[Monsters/Slimes/Mimic Slime\|Mimic Slime]] (elemental) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 4 · Dread |
| Element · weakness | Wind · Fire |
| Size | 1 m |
| Behaviour | Swarm (swarm_surround+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2682 · 187 · 140 · 140 · 140 · 110 |
| XP · gold | 1888 · 423 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/blob\|blob]] · `anim_blob` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Moraveil\|Moraveil]], [[Regions/Strife Marches\|Strife Marches]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Fire. Dangerous in numbers. Area attacks and chokepoints help.

## Motion implementation

- **Rig:** [[Systems/Rigs/blob|blob]] (rigId); animation set `anim_blob`.
- **Dimensions:** 1 m high × 0.93 m long × 0.9 m wide; prefab scale 2.
- **Physics:** 472.5 kg, gravity ×1.28, poise 46, knockback resistance 0.16, death style `splat_dissolve`.
- **Navigation:** speed 6.15 m/s, turn 360°/s, stopping distance 0.85 m.
- **Attack count:** 5; **signature:** a surface that ripples into the shape of whatever it last ate.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Body Slam\|Body Slam]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Split\|Split]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Acid Splash\|Acid Splash]] | ranged | 1.1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Gale Cutter\|Gale Cutter]] | magic | 1.5 | 10 s | Wind | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Sky Mimic Slime is a **dread ooze** encountered at D+ rank, around level 56. Its documented behaviour is *Swarm* and its AI pattern is *swarm_surround+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a surface that ripples into the shape of whatever it last ate. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Moraveil|Moraveil]], [[Regions/Strife Marches|Strife Marches]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_blob`, animation set `anim_blob`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Slimes D|loot_slime_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 4 | C-, D+, C, C+ | 56–86 | Night |
| [[Regions/Moraveil\|Moraveil]] | 4 | C, D-, C- | 40–76 | Night |
| [[Regions/Strife Marches\|Strife Marches]] | 3 | C+, C-, C | 65–86 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05813` | Aldmere Sky Mimic Slime Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | C- | 65 | 1.1 m | Night | Like a typical Sky Mimic Slime, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_05814` | Aldmere Sky Mimic Slime | [[Regions/Aldmere\|Aldmere]] | Adult | D+ | 56 | 1 m | Night | A typical adult Sky Mimic Slime of this region, with golden, grass-toned coloring. |
| `pop_05815` | Aldmere Sky Mimic Slime Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | C | 76 | 1.25 m | Night | Like a typical Sky Mimic Slime, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_05816` | Moraveil Sky Mimic Slime Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | C | 76 | 1.25 m | Night | Like a typical Sky Mimic Slime, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_05817` | Moraveil Sky Mimic Slime Runt | [[Regions/Moraveil\|Moraveil]] | Runt | D- | 40 | 0.7 m | Night | Like a typical Sky Mimic Slime, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_05818` | Strife Marches Sky Mimic Slime Elderborn | [[Regions/Strife Marches\|Strife Marches]] | Elderborn | C+ | 86 | 1.35 m | Night | Like a typical Sky Mimic Slime, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_05819` | Aldmere Sky Mimic Slime Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | C+ | 86 | 1.35 m | Night | Like a typical Sky Mimic Slime, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_05820` | Moraveil Sky Mimic Slime Albino | [[Regions/Moraveil\|Moraveil]] | Albino | C- | 65 | 1 m | Night | Like a typical Sky Mimic Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_05821` | Strife Marches Sky Mimic Slime Scarred | [[Regions/Strife Marches\|Strife Marches]] | Scarred | C- | 65 | 1.1 m | Night | Like a typical Sky Mimic Slime, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_05822` | Strife Marches Sky Mimic Slime Alpha | [[Regions/Strife Marches\|Strife Marches]] | Alpha | C | 76 | 1.25 m | Night | Like a typical Sky Mimic Slime, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_05823` | Moraveil Sky Mimic Slime Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | C- | 65 | 1.1 m | Night | Like a typical Sky Mimic Slime, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `wind_ribbons` · palette `#a8e6cf` `#dcedc1` `#5b8c85` · elongated, irregular silhouette; still-then-sudden timing
