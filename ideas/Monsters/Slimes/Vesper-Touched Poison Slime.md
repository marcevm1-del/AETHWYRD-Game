---
type: monster
id: mon_vesper_touched_poison_slime
family: "Slimes"
rank: "D-"
tier: variant
tags: [monster, slimes]
---
# Vesper-Touched Poison Slime

![[mon_vesper_touched_poison_slime_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vesper_touched_poison_slime_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,304 tris · 0.478 × 0.534 × 0.6 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Vesper-Touched Poison Slime is a small creature with a dome-shaped gelatinous body, about 0.6 m tall. Its gel is patchy and subtly wrong, as if assembled from memory, colored in bruise purple with sickly green. Survivors describe purple bubbles that hiss when they pop. It has eyes that never blink. A distinctive marking runs along its back. It glides without moving its legs, surrounded by a low toxic haze that clings to the ground. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Variant of | [[Monsters/Slimes/Poison Slime\|Poison Slime]] (corrupted) |
| Rank · level | D- · 40 (32–48) |
| Menace | 4 · Dread |
| Element · weakness | Poison · Light |
| Size | 0.6 m |
| Behaviour | Territorial (territorial_guard+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1399 · 136 · 102 · 102 · 102 · 110 |
| XP · gold | 1106 · 265 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/blob\|blob]] · `anim_blob` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Moraveil\|Moraveil]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Light. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/blob|blob]] (rigId); animation set `anim_blob`.
- **Dimensions:** 0.6 m high × 0.56 m long × 0.54 m wide; prefab scale 1.2.
- **Physics:** 113.4 kg, gravity ×1.6, poise 36, knockback resistance 0.16, death style `splat_dissolve`.
- **Navigation:** speed 4.08 m/s, turn 465°/s, stopping distance 0.67 m.
- **Attack count:** 5; **signature:** purple bubbles that hiss when they pop.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Body Slam\|Body Slam]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Split\|Split]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Acid Splash\|Acid Splash]] | ranged | 1.1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched Poison Slime is a **dread ooze** encountered at D- rank, around level 40. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** purple bubbles that hiss when they pop. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Moraveil|Moraveil]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Aldmere\|Aldmere]] | 6 | D, C-, E+, D-, E, D+ | 26–65 | Night |
| [[Regions/Moraveil\|Moraveil]] | 5 | E, C-, D, D+, E+ | 26–65 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02939` | Aldmere Vesper-Touched Poison Slime Albino | [[Regions/Aldmere\|Aldmere]] | Albino | D | 48 | 0.6 m | Night | Like a typical Vesper-Touched Poison Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_02940` | Aldmere Vesper-Touched Poison Slime Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | C- | 65 | 0.81 m | Night | Like a typical Vesper-Touched Poison Slime, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_02941` | Moraveil Vesper-Touched Poison Slime Runt | [[Regions/Moraveil\|Moraveil]] | Runt | E | 26 | 0.42 m | Night | Like a typical Vesper-Touched Poison Slime, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_02942` | Aldmere Vesper-Touched Poison Slime Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E+ | 32 | 0.51 m | Night | Like a typical Vesper-Touched Poison Slime, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_02943` | Moraveil Vesper-Touched Poison Slime Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | C- | 65 | 0.81 m | Night | Like a typical Vesper-Touched Poison Slime, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_02944` | Moraveil Vesper-Touched Poison Slime Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | D | 48 | 0.66 m | Night | Like a typical Vesper-Touched Poison Slime, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_02945` | Moraveil Vesper-Touched Poison Slime Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | D+ | 56 | 0.75 m | Night | Like a typical Vesper-Touched Poison Slime, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_02946` | Moraveil Vesper-Touched Poison Slime Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | E+ | 32 | 0.51 m | Night | Like a typical Vesper-Touched Poison Slime, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_02947` | Aldmere Vesper-Touched Poison Slime | [[Regions/Aldmere\|Aldmere]] | Adult | D- | 40 | 0.6 m | Night | A typical adult Vesper-Touched Poison Slime of this region, with golden, grass-toned coloring. |
| `pop_02948` | Aldmere Vesper-Touched Poison Slime Runt | [[Regions/Aldmere\|Aldmere]] | Runt | E | 26 | 0.42 m | Night | Like a typical Vesper-Touched Poison Slime, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_02949` | Aldmere Vesper-Touched Poison Slime Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D+ | 56 | 0.75 m | Night | Like a typical Vesper-Touched Poison Slime, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2f1c40` · elongated, irregular silhouette; still-then-sudden timing
