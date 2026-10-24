---
type: monster
id: mon_grove_goblin_trapper
family: "Goblinoids"
rank: "E+"
tier: variant
tags: [monster, goblinoids]
---
# Grove Goblin Trapper

> The Grove Goblin Trapper is a small creature with a scrawny biped with long arms and bowed legs, about 1 m tall. Its skin is rough, scarred and spiked, colored in leaf greens over bark brown. Its most striking feature is snares and rusted bells hanging from its belt. It has narrow glowing eyes. Small scars and rough edges mark it as a survivor. It strides with heavy steps, surrounded by drifting pollen and tiny blossoms. Adapted to forest lands, it has moss-green coloring that blends with the undergrowth.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Variant of | [[Monsters/Goblinoids/Goblin Trapper\|Goblin Trapper]] (regional) |
| Rank · level | E+ · 32 (26–40) |
| Menace | 3 · Menacing |
| Element · weakness | Nature · Fire |
| Size | 1 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1436 · 138 · 110 · 97 · 110 · 135 |
| XP · gold | 776 · 195 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]], [[Regions/Mossdeep\|Mossdeep]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Fire. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (override (base species)); animation set `anim_small_biped`.
- **Dimensions:** 1 m high × 0.3 m long × 0.4 m wide; prefab scale 0.909.
- **Physics:** 16 kg, gravity ×1.5, poise 33, knockback resistance 0.18, death style `ragdoll_crumple`.
- **Navigation:** speed 5.08 m/s, turn 420°/s, stopping distance 0.6 m.
- **Attack count:** 5; **signature:** snares and rusted bells hanging from its belt.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Sand Toss\|Sand Toss]] | debuff | 0 | 12 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Thorn Volley\|Thorn Volley]] | magic | 1.5 | 10 s | Nature | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Grove Goblin Trapper is a **menacing humanoid** encountered at E+ rank, around level 32. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** snares and rusted bells hanging from its belt. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]], [[Regions/Mossdeep|Mossdeep]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Mossdeep\|Mossdeep]] | 4 | D, D-, E-, E | 19–48 | Day & Night |
| [[Regions/Whisperwood\|Whisperwood]] | 5 | D, E+, D+, D-, E | 26–56 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 2 | D-, E | 26–40 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03082` | Mossdeep Grove Goblin Trapper Alpha | [[Regions/Mossdeep\|Mossdeep]] | Alpha | D | 48 | 1.25 m | Day & Night | Like a typical Grove Goblin Trapper, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_03083` | Mossdeep Grove Goblin Trapper Scarred | [[Regions/Mossdeep\|Mossdeep]] | Scarred | D- | 40 | 1.1 m | Day & Night | Like a typical Grove Goblin Trapper, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_03084` | Mossdeep Grove Goblin Trapper Runt | [[Regions/Mossdeep\|Mossdeep]] | Runt | E- | 19 | 0.7 m | Day & Night | Like a typical Grove Goblin Trapper, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_03085` | Whisperwood Grove Goblin Trapper Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | D | 48 | 1.25 m | Day & Night | Like a typical Grove Goblin Trapper, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_03086` | Whisperwood Grove Goblin Trapper | [[Regions/Whisperwood\|Whisperwood]] | Adult | E+ | 32 | 1 m | Day & Night | A typical adult Grove Goblin Trapper of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_03087` | Aldmere Grove Goblin Trapper Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | D- | 40 | 1.1 m | Day & Night | Like a typical Grove Goblin Trapper, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_03088` | Whisperwood Grove Goblin Trapper Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | D+ | 56 | 1.35 m | Day & Night | Like a typical Grove Goblin Trapper, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_03089` | Whisperwood Grove Goblin Trapper Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | D- | 40 | 1.1 m | Day & Night | Like a typical Grove Goblin Trapper, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_03090` | Whisperwood Grove Goblin Trapper Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | E | 26 | 0.85 m | Day & Night | Like a typical Grove Goblin Trapper, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_03091` | Aldmere Grove Goblin Trapper Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E | 26 | 0.85 m | Day & Night | Like a typical Grove Goblin Trapper, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_03092` | Mossdeep Grove Goblin Trapper Juvenile | [[Regions/Mossdeep\|Mossdeep]] | Juvenile | E | 26 | 0.85 m | Day & Night | Like a typical Grove Goblin Trapper, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `rough_skin_leather` · VFX `pollen_petals` · palette `#4caf50` `#a5d66f` `#3e2723` · triangle-based silhouette, sharp asymmetric spikes
