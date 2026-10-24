---
type: monster
id: mon_ruin_ooze
family: "Slimes"
rank: "C+"
tier: variant
tags: [monster, slimes]
---
# Ruin Ooze

![[mon_ruin_ooze_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ruin_ooze_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Ruin Ooze is a person-sized creature with a dome-shaped gelatinous body, about 1.5 m tall. Its gel is rough, scarred and spiked, colored in ink black with bruised violet. Survivors describe molten trails that harden into glass behind it. It has eyes that catch torchlight like coins. Battle-worn plates and trophies hang from its body. It circles its prey, surrounded by shadows that lean toward it. Adapted to ruins lands, it has dust-grey coloring and old rune scars.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Variant of | [[Monsters/Slimes/Ember Ooze\|Ember Ooze]] (regional) |
| Rank · level | C+ · 86 (76–96) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 1.5 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 5800 · 283 · 212 · 212 · 212 · 110 |
| XP · gold | 3743 · 769 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/blob\|blob]] · `anim_blob` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Light. Dangerous in numbers. Area attacks and chokepoints help.

## Motion implementation

- **Rig:** [[Systems/Rigs/blob|blob]] (rigId); animation set `anim_blob`.
- **Dimensions:** 1.5 m high × 1.4 m long × 1.35 m wide; prefab scale 3.
- **Physics:** 1771.9 kg, gravity ×1.6, poise 63, knockback resistance 0.19, death style `splat_dissolve`.
- **Navigation:** speed 7.69 m/s, turn 294°/s, stopping distance 1.08 m.
- **Attack count:** 5; **signature:** molten trails that harden into glass behind it.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Body Slam\|Body Slam]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Split\|Split]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Acid Splash\|Acid Splash]] | ranged | 1.1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Ruin Ooze is a **menacing ooze** encountered at C+ rank, around level 86. Its documented behaviour is *Swarm* and its AI pattern is *swarm_surround*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** molten trails that harden into glass behind it. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 6 | C-, B+, C+, B-, C, B | 65–120 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 5 | B-, C+, B, C | 76–108 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03016` | Great Labyrinth (Floors 1-40) Ruin Ooze Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | C- | 65 | 1.05 m | Day & Night | Like a typical Ruin Ooze, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_03017` | Aldmere Ruin Ooze Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | B- | 96 | 1.65 m | Day & Night | Like a typical Ruin Ooze, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_03018` | Aldmere Ruin Ooze | [[Regions/Aldmere\|Aldmere]] | Adult | C+ | 86 | 1.5 m | Day & Night | A typical adult Ruin Ooze of this region, with golden, grass-toned coloring. |
| `pop_03019` | Aldmere Ruin Ooze Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | B | 108 | 1.88 m | Day & Night | Like a typical Ruin Ooze, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_03020` | Great Labyrinth (Floors 1-40) Ruin Ooze Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | B+ | 120 | 2.03 m | Day & Night | Like a typical Ruin Ooze, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_03021` | Great Labyrinth (Floors 1-40) Ruin Ooze | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | C+ | 86 | 1.5 m | Day & Night | A typical adult Ruin Ooze of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_03022` | Great Labyrinth (Floors 1-40) Ruin Ooze Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | B- | 96 | 1.65 m | Day & Night | Like a typical Ruin Ooze, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_03023` | Great Labyrinth (Floors 1-40) Ruin Ooze Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | C | 76 | 1.27 m | Day & Night | Like a typical Ruin Ooze, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_03024` | Aldmere Ruin Ooze Albino | [[Regions/Aldmere\|Aldmere]] | Albino | B- | 96 | 1.5 m | Day & Night | Like a typical Ruin Ooze, but a rare pale form with white skin or fur and red eyes. |
| `pop_03025` | Aldmere Ruin Ooze Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | C | 76 | 1.27 m | Day & Night | Like a typical Ruin Ooze, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_03026` | Great Labyrinth (Floors 1-40) Ruin Ooze Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | B | 108 | 1.88 m | Day & Night | Like a typical Ruin Ooze, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · triangle-based silhouette, sharp asymmetric spikes
