---
type: monster
id: mon_phantom_kobold_scavenger
family: "Kobolds"
rank: "F+"
tier: variant
tags: [monster, kobolds]
---
# Phantom Kobold Scavenger

![[mon_phantom_kobold_scavenger_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_phantom_kobold_scavenger_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 11,998 tris · 0.558 × 1.073 × 0.9 m · local file `Game/Assets/_Game/Art/Models/Monsters/Kobolds/mon_phantom_kobold_scavenger.fbx`

> The Phantom Kobold Scavenger is a small creature with a scrawny biped with long arms and bowed legs, about 0.9 m tall. Its mangy fur is patchy and subtly wrong, as if assembled from memory, colored in slate-blue, with gold markings. Guild sketches always show a dog-like head with a chipped snout and a sack of stolen tools. It has eyes set slightly too far apart. It has no ornament at all: simple, readable shapes. It freezes whenever it is looked at, surrounded by soft radiance and floating motes of light. Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.

| Field | Value |
|---|---|
| Family · type | [[Families/Kobolds|Kobolds]] · Humanoid |
| Variant of | [[Monsters/Kobolds/Kobold Scavenger\|Kobold Scavenger]] (spirit) |
| Rank · level | F+ · 13 (8–19) |
| Menace | 4 · Dread |
| Element · weakness | Light · Dark |
| Size | 0.9 m |
| Behaviour | Pack (pack_flank+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 396 · 62 · 50 · 43 · 50 · 135 |
| XP · gold | 190 · 57 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Aldmere\|Aldmere]] |
| Genre | Dungeon Crawl |
| Trope | Dog-headed first-floor monsters (DanMachi), trap-builders (classic tabletop) |

**Field note:** Weak to Dark. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (rigId); animation set `anim_small_biped`.
- **Dimensions:** 0.9 m high × 0.27 m long × 0.36 m wide; prefab scale 0.818.
- **Physics:** 11.1 kg, gravity ×1.35, poise 27, knockback resistance 0.15, death style `ragdoll_crumple`.
- **Navigation:** speed 4.59 m/s, turn 443°/s, stopping distance 0.58 m.
- **Attack count:** 5; **signature:** a dog-like head with a chipped snout and a sack of stolen tools.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Trip-Wire Trap\|Trip-Wire Trap]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Phantom Kobold Scavenger is a **dread humanoid** encountered at F+ rank, around level 13. Its documented behaviour is *Pack* and its AI pattern is *pack_flank+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a dog-like head with a chipped snout and a sack of stolen tools. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Aldmere|Aldmere]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Kobolds F|loot_kobold_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Kobold Fang\|Kobold Fang]] | 60% | 1–3 |
| [[Items/Scrap Metal\|Scrap Metal]] | 30% | 1–1 |
| [[Items/Candle Stub\|Candle Stub]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 5 | E, F-, E-, E+ | 3–32 | Night |
| [[Regions/Aldmere\|Aldmere]] | 6 | E+, F, E-, F-, F+, E | 3–32 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06033` | Great Labyrinth (Floors 1-40) Phantom Kobold Scavenger Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | E | 26 | 1.13 m | Night | Like a typical Phantom Kobold Scavenger, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_06034` | Aldmere Phantom Kobold Scavenger Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | E+ | 32 | 1.22 m | Night | Like a typical Phantom Kobold Scavenger, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_06035` | Aldmere Phantom Kobold Scavenger Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | F | 8 | 0.77 m | Night | Like a typical Phantom Kobold Scavenger, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_06036` | Aldmere Phantom Kobold Scavenger Albino | [[Regions/Aldmere\|Aldmere]] | Albino | E- | 19 | 0.9 m | Night | Like a typical Phantom Kobold Scavenger, but a rare pale form with white skin or fur and red eyes. |
| `pop_06037` | Aldmere Phantom Kobold Scavenger Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F- | 3 | 0.63 m | Night | Like a typical Phantom Kobold Scavenger, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_06038` | Great Labyrinth (Floors 1-40) Phantom Kobold Scavenger Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | F- | 3 | 0.63 m | Night | Like a typical Phantom Kobold Scavenger, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_06039` | Aldmere Phantom Kobold Scavenger | [[Regions/Aldmere\|Aldmere]] | Adult | F+ | 13 | 0.9 m | Night | A typical adult Phantom Kobold Scavenger of this region, with dust-grey coloring and old rune scars. |
| `pop_06040` | Great Labyrinth (Floors 1-40) Phantom Kobold Scavenger Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | E- | 19 | 0.99 m | Night | Like a typical Phantom Kobold Scavenger, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_06041` | Great Labyrinth (Floors 1-40) Phantom Kobold Scavenger Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | E- | 19 | 0.9 m | Night | Like a typical Phantom Kobold Scavenger, but a rare pale form with white skin or fur and red eyes. |
| `pop_06042` | Aldmere Phantom Kobold Scavenger Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | E | 26 | 1.13 m | Night | Like a typical Phantom Kobold Scavenger, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_06043` | Great Labyrinth (Floors 1-40) Phantom Kobold Scavenger Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | E+ | 32 | 1.22 m | Night | Like a typical Phantom Kobold Scavenger, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `fur_short` · VFX `holy_motes` · palette `#6683a4` `#42556d` `#ffd166` · elongated, irregular silhouette; still-then-sudden timing
