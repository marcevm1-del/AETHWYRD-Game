---
type: monster
id: mon_bog_mimic_slime
family: "Slimes"
rank: "D+"
tier: variant
tags: [monster, slimes]
---
# Bog Mimic Slime

![[mon_bog_mimic_slime_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_bog_mimic_slime_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Bog Mimic Slime is a small creature with a dome-shaped gelatinous body, about 1 m tall. Its gel is patchy and subtly wrong, as if assembled from memory, colored in bruise purple with sickly green. Survivors describe a surface that ripples into the shape of whatever it last ate. It has eyes that never blink. A distinctive marking runs along its back. It moves in jerky stop-motion bursts, surrounded by a low toxic haze that clings to the ground. Adapted to swamp lands, it has mud-slick, algae-streaked skin.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Variant of | [[Monsters/Slimes/Mimic Slime\|Mimic Slime]] (regional) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 4 · Dread |
| Element · weakness | Poison · Light |
| Size | 1 m |
| Behaviour | Passive (passive_wander+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2682 · 187 · 140 · 140 · 140 · 110 |
| XP · gold | 1888 · 423 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/blob\|blob]] · `anim_blob` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Xochitl Mire\|Xochitl Mire]], [[Regions/Greymoor\|Greymoor]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Light. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/blob|blob]] (rigId); animation set `anim_blob`.
- **Dimensions:** 1 m high × 0.93 m long × 0.9 m wide; prefab scale 2.
- **Physics:** 525 kg, gravity ×1.6, poise 46, knockback resistance 0.16, death style `splat_dissolve`.
- **Navigation:** speed 5 m/s, turn 360°/s, stopping distance 0.85 m.
- **Attack count:** 5; **signature:** a surface that ripples into the shape of whatever it last ate.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Body Slam\|Body Slam]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Split\|Split]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Acid Splash\|Acid Splash]] | ranged | 1.1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Bog Mimic Slime is a **dread ooze** encountered at D+ rank, around level 56. Its documented behaviour is *Passive* and its AI pattern is *passive_wander+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a surface that ripples into the shape of whatever it last ate. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Xochitl Mire|Xochitl Mire]], [[Regions/Greymoor|Greymoor]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Greymoor\|Greymoor]] | 5 | C-, D+, C+, C | 56–86 | Night |
| [[Regions/Aldmere\|Aldmere]] | 2 | C- | 65–65 | Night |
| [[Regions/Xochitl Mire\|Xochitl Mire]] | 4 | D-, C-, C | 40–76 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02972` | Greymoor Bog Mimic Slime Albino | [[Regions/Greymoor\|Greymoor]] | Albino | C- | 65 | 1 m | Night | Like a typical Bog Mimic Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_02973` | Aldmere Bog Mimic Slime Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | C- | 65 | 1.1 m | Night | Like a typical Bog Mimic Slime, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_02974` | Greymoor Bog Mimic Slime | [[Regions/Greymoor\|Greymoor]] | Adult | D+ | 56 | 1 m | Night | A typical adult Bog Mimic Slime of this region, with mud-slick, algae-streaked skin. |
| `pop_02975` | Greymoor Bog Mimic Slime Elderborn | [[Regions/Greymoor\|Greymoor]] | Elderborn | C+ | 86 | 1.35 m | Night | Like a typical Bog Mimic Slime, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |
| `pop_02976` | Xochitl Mire Bog Mimic Slime Runt | [[Regions/Xochitl Mire\|Xochitl Mire]] | Runt | D- | 40 | 0.7 m | Night | Like a typical Bog Mimic Slime, but smaller and scrappier than usual, with mud-slick, algae-streaked skin. |
| `pop_02977` | Xochitl Mire Bog Mimic Slime Scarred | [[Regions/Xochitl Mire\|Xochitl Mire]] | Scarred | C- | 65 | 1.1 m | Night | Like a typical Bog Mimic Slime, but covered in old battle scars, with mud-slick, algae-streaked skin. |
| `pop_02978` | Greymoor Bog Mimic Slime Scarred | [[Regions/Greymoor\|Greymoor]] | Scarred | C- | 65 | 1.1 m | Night | Like a typical Bog Mimic Slime, but covered in old battle scars, with mud-slick, algae-streaked skin. |
| `pop_02979` | Greymoor Bog Mimic Slime Alpha | [[Regions/Greymoor\|Greymoor]] | Alpha | C | 76 | 1.25 m | Night | Like a typical Bog Mimic Slime, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |
| `pop_02980` | Aldmere Bog Mimic Slime Albino | [[Regions/Aldmere\|Aldmere]] | Albino | C- | 65 | 1 m | Night | Like a typical Bog Mimic Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_02981` | Xochitl Mire Bog Mimic Slime Albino | [[Regions/Xochitl Mire\|Xochitl Mire]] | Albino | C- | 65 | 1 m | Night | Like a typical Bog Mimic Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_02982` | Xochitl Mire Bog Mimic Slime Alpha | [[Regions/Xochitl Mire\|Xochitl Mire]] | Alpha | C | 76 | 1.25 m | Night | Like a typical Bog Mimic Slime, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · elongated, irregular silhouette; still-then-sudden timing
