---
type: monster
id: mon_ruin_goblin_shaman
family: "Goblinoids"
rank: "E+"
tier: variant
tags: [monster, goblinoids]
---
# Ruin Goblin Shaman

![[mon_ruin_goblin_shaman_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ruin_goblin_shaman_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Ruin Goblin Shaman is a small creature with a scrawny biped with long arms and bowed legs, about 1 m tall. Its skin is rough, scarred and spiked, colored in ink black with bruised violet. Guild sketches always show a skull headdress and a staff hung with smoking charms. It has burning slit pupils. Small scars and rough edges mark it as a survivor. It strides with heavy steps, surrounded by shadows that lean toward it. Adapted to ruins lands, it has dust-grey coloring and old rune scars.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Variant of | [[Monsters/Goblinoids/Goblin Shaman\|Goblin Shaman]] (regional) |
| Rank · level | E+ · 32 (26–40) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 1 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1436 · 138 · 110 · 97 · 110 · 135 |
| XP · gold | 776 · 195 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (override (base species)); animation set `anim_small_biped`.
- **Dimensions:** 1 m high × 0.3 m long × 0.4 m wide; prefab scale 0.909.
- **Physics:** 16 kg, gravity ×1.5, poise 33, knockback resistance 0.18, death style `ragdoll_crumple`.
- **Navigation:** speed 5.59 m/s, turn 420°/s, stopping distance 0.6 m.
- **Attack count:** 5; **signature:** a skull headdress and a staff hung with smoking charms.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Sand Toss\|Sand Toss]] | debuff | 0 | 12 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Ruin Goblin Shaman is a **menacing humanoid** encountered at E+ rank, around level 32. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a skull headdress and a staff hung with smoking charms. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Goblinoids E|loot_goblinoid_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 5 | E, E-, D-, D, D+ | 19–56 | Day & Night |
| [[Regions/Whisperwood\|Whisperwood]] | 3 | E, E-, D | 19–48 | Day & Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 3 | D-, E, D+ | 26–56 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05934` | Aldmere Ruin Goblin Shaman Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E | 26 | 0.85 m | Day & Night | Like a typical Ruin Goblin Shaman, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_05935` | Whisperwood Ruin Goblin Shaman Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | E | 26 | 0.85 m | Day & Night | Like a typical Ruin Goblin Shaman, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_05936` | Great Labyrinth (Floors 1-40) Ruin Goblin Shaman Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | D- | 40 | 1.1 m | Day & Night | Like a typical Ruin Goblin Shaman, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_05937` | Aldmere Ruin Goblin Shaman Runt | [[Regions/Aldmere\|Aldmere]] | Runt | E- | 19 | 0.7 m | Day & Night | Like a typical Ruin Goblin Shaman, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_05938` | Great Labyrinth (Floors 1-40) Ruin Goblin Shaman Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | E | 26 | 0.85 m | Day & Night | Like a typical Ruin Goblin Shaman, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_05939` | Aldmere Ruin Goblin Shaman Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | D- | 40 | 1.1 m | Day & Night | Like a typical Ruin Goblin Shaman, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_05940` | Whisperwood Ruin Goblin Shaman Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | E- | 19 | 0.7 m | Day & Night | Like a typical Ruin Goblin Shaman, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_05941` | Aldmere Ruin Goblin Shaman Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D | 48 | 1.25 m | Day & Night | Like a typical Ruin Goblin Shaman, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_05942` | Whisperwood Ruin Goblin Shaman Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | D | 48 | 1.25 m | Day & Night | Like a typical Ruin Goblin Shaman, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_05943` | Aldmere Ruin Goblin Shaman Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | D+ | 56 | 1.35 m | Day & Night | Like a typical Ruin Goblin Shaman, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_05944` | Great Labyrinth (Floors 1-40) Ruin Goblin Shaman Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | D+ | 56 | 1.35 m | Day & Night | Like a typical Ruin Goblin Shaman, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `rough_skin_leather` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · triangle-based silhouette, sharp asymmetric spikes
