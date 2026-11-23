---
type: monster
id: mon_phantom_kobold_sneak
family: "Kobolds"
rank: "E+"
tier: variant
tags: [monster, kobolds]
---
# Phantom Kobold Sneak

![[mon_phantom_kobold_sneak_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_phantom_kobold_sneak_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 0.498 × 0.944 × 0.8 m · local file `Game/Assets/_Game/Art/Models/Monsters/Kobolds/mon_phantom_kobold_sneak.fbx`

> The Phantom Kobold Sneak is a small creature with a scrawny biped with long arms and bowed legs, about 0.8 m tall. Its mangy fur is patchy and subtly wrong, as if assembled from memory, colored in slate-blue, with gold markings. Its most striking feature is soot-blackened fur for hiding in tunnels. It has pale, pupil-less eyes. Small scars and rough edges mark it as a survivor. It freezes whenever it is looked at, surrounded by soft radiance and floating motes of light. Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.

| Field | Value |
|---|---|
| Family · type | [[Families/Kobolds|Kobolds]] · Humanoid |
| Variant of | [[Monsters/Kobolds/Kobold Sneak\|Kobold Sneak]] (spirit) |
| Rank · level | E+ · 32 (26–40) |
| Menace | 4 · Dread |
| Element · weakness | Light · Dark |
| Size | 0.8 m |
| Behaviour | Skittish (skittish_flee+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1338 · 138 · 110 · 97 · 110 · 135 |
| XP · gold | 776 · 195 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Dungeon Crawl |
| Trope | Dog-headed first-floor monsters (DanMachi), trap-builders (classic tabletop) |

**Field note:** Weak to Dark. Flees when hurt. Snares or ranged attacks work best.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (rigId); animation set `anim_small_biped`.
- **Dimensions:** 0.8 m high × 0.24 m long × 0.32 m wide; prefab scale 0.727.
- **Physics:** 7.8 kg, gravity ×1.35, poise 29, knockback resistance 0.18, death style `ragdoll_crumple`.
- **Navigation:** speed 4.94 m/s, turn 470°/s, stopping distance 0.56 m.
- **Attack count:** 5; **signature:** soot-blackened fur for hiding in tunnels.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Trip-Wire Trap\|Trip-Wire Trap]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Phantom Kobold Sneak is a **dread humanoid** encountered at E+ rank, around level 32. Its documented behaviour is *Skittish* and its AI pattern is *skittish_flee+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** soot-blackened fur for hiding in tunnels. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Kobolds E|loot_kobold_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Kobold Fang\|Kobold Fang]] | 60% | 1–3 |
| [[Items/Scrap Metal\|Scrap Metal]] | 30% | 1–1 |
| [[Items/Candle Stub\|Candle Stub]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 6 | D-, D+, E+, E-, E | 19–56 | Night |
| [[Regions/Whisperwood\|Whisperwood]] | 5 | D+, E+, D-, D, E | 26–56 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06055` | Great Labyrinth (Floors 1-40) Phantom Kobold Sneak Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | D- | 40 | 0.88 m | Night | Like a typical Phantom Kobold Sneak, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_06056` | Great Labyrinth (Floors 1-40) Phantom Kobold Sneak Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | D- | 40 | 0.8 m | Night | Like a typical Phantom Kobold Sneak, but a rare pale form with white skin or fur and red eyes. |
| `pop_06057` | Whisperwood Phantom Kobold Sneak Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | D+ | 56 | 1.08 m | Night | Like a typical Phantom Kobold Sneak, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_06058` | Whisperwood Phantom Kobold Sneak | [[Regions/Whisperwood\|Whisperwood]] | Adult | E+ | 32 | 0.8 m | Night | A typical adult Phantom Kobold Sneak of this region, with dust-grey coloring and old rune scars. |
| `pop_06059` | Whisperwood Phantom Kobold Sneak Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | D- | 40 | 0.8 m | Night | Like a typical Phantom Kobold Sneak, but a rare pale form with white skin or fur and red eyes. |
| `pop_06060` | Great Labyrinth (Floors 1-40) Phantom Kobold Sneak Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | D+ | 56 | 1.08 m | Night | Like a typical Phantom Kobold Sneak, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_06061` | Great Labyrinth (Floors 1-40) Phantom Kobold Sneak | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | E+ | 32 | 0.8 m | Night | A typical adult Phantom Kobold Sneak of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_06062` | Whisperwood Phantom Kobold Sneak Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | D | 48 | 1 m | Night | Like a typical Phantom Kobold Sneak, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_06063` | Great Labyrinth (Floors 1-40) Phantom Kobold Sneak Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | E- | 19 | 0.56 m | Night | Like a typical Phantom Kobold Sneak, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_06064` | Whisperwood Phantom Kobold Sneak Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | E | 26 | 0.68 m | Night | Like a typical Phantom Kobold Sneak, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_06065` | Great Labyrinth (Floors 1-40) Phantom Kobold Sneak Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | E | 26 | 0.68 m | Night | Like a typical Phantom Kobold Sneak, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `fur_short` · VFX `holy_motes` · palette `#678aa5` `#435a6e` `#ffd166` · elongated, irregular silhouette; still-then-sudden timing
