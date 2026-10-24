---
type: monster
id: mon_goblin_shaman
family: "Goblinoids"
rank: "E"
tier: core
tags: [monster, goblinoids]
---
# Goblin Shaman

![[mon_goblin_shaman_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_goblin_shaman_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Goblin Shaman is a small creature with a small, compact humanoid body, about 1 m tall. Its skin is rough, scarred and spiked, colored in ember reds fading to soot black. Survivors describe a skull headdress and a staff hung with smoking charms. It has eyes that catch torchlight like coins. Small scars and rough edges mark it as a survivor. It circles its prey, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Rank · level | E · 26 (19–32) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 1 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1065 · 114 · 91 · 80 · 91 · 135 |
| XP · gold | 559 · 147 |
| Ring | 1 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Water. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (override); animation set `anim_small_biped`.
- **Dimensions:** 1 m high × 0.3 m long × 0.4 m wide; prefab scale 0.909.
- **Physics:** 16 kg, gravity ×1.5, poise 33, knockback resistance 0.18, death style `ragdoll_crumple`.
- **Navigation:** speed 5.33 m/s, turn 420°/s, stopping distance 0.6 m.
- **Attack count:** 5; **signature:** [object Object].

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Sand Toss\|Sand Toss]] | debuff | 0 | 12 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Goblin Shaman is a **menacing humanoid** encountered at E rank, around level 26. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a skull headdress and a staff hung with smoking charms. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Goblinoids E|loot_goblinoid_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Goblinoids/Dawn Goblin Shaman|Dawn Goblin Shaman]]
- [[Monsters/Goblinoids/Ruin Goblin Shaman|Ruin Goblin Shaman]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Whisperwood\|Whisperwood]] | 5 | E, E+, D, D-, E- | 19–48 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 6 | E-, E, D, E+, D- | 19–48 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00189` | Whisperwood Goblin Shaman | [[Regions/Whisperwood\|Whisperwood]] | Adult | E | 26 | 1 m | Day & Night | A typical adult Goblin Shaman of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_00190` | Whisperwood Goblin Shaman Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | E+ | 32 | 1.1 m | Day & Night | Like a typical Goblin Shaman, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_00191` | Whisperwood Goblin Shaman Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | D | 48 | 1.35 m | Day & Night | Like a typical Goblin Shaman, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_00192` | Aldmere Goblin Shaman Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E- | 19 | 0.85 m | Day & Night | Like a typical Goblin Shaman, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_00193` | Aldmere Goblin Shaman | [[Regions/Aldmere\|Aldmere]] | Adult | E | 26 | 1 m | Day & Night | A typical adult Goblin Shaman of this region, with golden, grass-toned coloring. |
| `pop_00194` | Aldmere Goblin Shaman Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | D | 48 | 1.35 m | Day & Night | Like a typical Goblin Shaman, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_00195` | Whisperwood Goblin Shaman Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | D- | 40 | 1.25 m | Day & Night | Like a typical Goblin Shaman, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_00196` | Aldmere Goblin Shaman Albino | [[Regions/Aldmere\|Aldmere]] | Albino | E+ | 32 | 1 m | Day & Night | Like a typical Goblin Shaman, but a rare pale form with white skin or fur and red eyes. |
| `pop_00197` | Whisperwood Goblin Shaman Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | E- | 19 | 0.85 m | Day & Night | Like a typical Goblin Shaman, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_00198` | Aldmere Goblin Shaman Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | E+ | 32 | 1.1 m | Day & Night | Like a typical Goblin Shaman, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_00199` | Aldmere Goblin Shaman Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D- | 40 | 1.25 m | Day & Night | Like a typical Goblin Shaman, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `rough_skin_leather` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · triangle-based silhouette, sharp asymmetric spikes
