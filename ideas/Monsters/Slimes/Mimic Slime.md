---
type: monster
id: mon_mimic_slime
family: "Slimes"
rank: "D"
tier: core
tags: [monster, slimes]
---
# Mimic Slime

![[mon_mimic_slime_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_mimic_slime_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 1.125 × 1.08 × 1 m · local file `Game/Assets/_Game/Art/Models/Monsters/Slimes/mon_mimic_slime.fbx`

> The Mimic Slime is a small creature with a wobbling mound of translucent gel, about 1 m tall. Its gel is patchy and subtly wrong, as if assembled from memory, colored in muted greys and dusty browns. Survivors describe a surface that ripples into the shape of whatever it last ate. It has eyes that never blink. A distinctive marking runs along its back. It glides without moving its legs. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Rank · level | D · 48 (40–56) |
| Menace | 4 · Dread |
| Element · weakness | None · Fire |
| Size | 1 m |
| Behaviour | Territorial (territorial_guard+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2137 · 162 · 121 · 85 · 121 · 110 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/blob\|blob]] · `anim_blob` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Fire. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/blob|blob]] (rigId); animation set `anim_blob`.
- **Dimensions:** 1 m high × 0.93 m long × 0.9 m wide; prefab scale 2.
- **Physics:** 525 kg, gravity ×1.6, poise 46, knockback resistance 0.16, death style `splat_dissolve`.
- **Navigation:** speed 5.42 m/s, turn 360°/s, stopping distance 0.85 m.
- **Attack count:** 4; **signature:** a surface that ripples into the shape of whatever it last ate.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Body Slam\|Body Slam]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Split\|Split]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Acid Splash\|Acid Splash]] | ranged | 1.1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |

## Field guide

Mimic Slime is a **dread ooze** encountered at D rank, around level 48. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a surface that ripples into the shape of whatever it last ate. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Strife Marches|Strife Marches]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_blob`, animation set `anim_blob`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Slimes D|loot_slime_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Slimes/Bog Mimic Slime|Bog Mimic Slime]]
- [[Monsters/Slimes/Sky Mimic Slime|Sky Mimic Slime]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 3 | D, C, C- | 48–76 | Night |
| [[Regions/Strife Marches\|Strife Marches]] | 5 | D+, C-, E+, C | 32–76 | Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 3 | D, E+, D+ | 32–56 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00067` | Aldmere Mimic Slime | [[Regions/Aldmere\|Aldmere]] | Adult | D | 48 | 1 m | Night | A typical adult Mimic Slime of this region, with golden, grass-toned coloring. |
| `pop_00068` | Strife Marches Mimic Slime Scarred | [[Regions/Strife Marches\|Strife Marches]] | Scarred | D+ | 56 | 1.1 m | Night | Like a typical Mimic Slime, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_00069` | Great Labyrinth (Floors 1-40) Mimic Slime | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | D | 48 | 1 m | Night | A typical adult Mimic Slime of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_00070` | Great Labyrinth (Floors 1-40) Mimic Slime Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | E+ | 32 | 0.7 m | Night | Like a typical Mimic Slime, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_00071` | Aldmere Mimic Slime Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | C | 76 | 1.35 m | Night | Like a typical Mimic Slime, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_00072` | Strife Marches Mimic Slime Alpha | [[Regions/Strife Marches\|Strife Marches]] | Alpha | C- | 65 | 1.25 m | Night | Like a typical Mimic Slime, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_00073` | Strife Marches Mimic Slime Albino | [[Regions/Strife Marches\|Strife Marches]] | Albino | D+ | 56 | 1 m | Night | Like a typical Mimic Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_00074` | Strife Marches Mimic Slime Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | E+ | 32 | 0.7 m | Night | Like a typical Mimic Slime, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_00075` | Strife Marches Mimic Slime Elderborn | [[Regions/Strife Marches\|Strife Marches]] | Elderborn | C | 76 | 1.35 m | Night | Like a typical Mimic Slime, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_00076` | Aldmere Mimic Slime Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | C- | 65 | 1.25 m | Night | Like a typical Mimic Slime, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_00077` | Great Labyrinth (Floors 1-40) Mimic Slime Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | D+ | 56 | 1.1 m | Night | Like a typical Mimic Slime, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · elongated, irregular silhouette; still-then-sudden timing
