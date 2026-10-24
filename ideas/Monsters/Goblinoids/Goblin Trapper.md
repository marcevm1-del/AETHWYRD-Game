---
type: monster
id: mon_goblin_trapper
family: "Goblinoids"
rank: "E"
tier: core
tags: [monster, goblinoids]
---
# Goblin Trapper

> The Goblin Trapper is a small creature with a scrawny biped with long arms and bowed legs, about 1 m tall. Its skin is rough, scarred and spiked, colored in muted greys and dusty browns. Guild sketches always show snares and rusted bells hanging from its belt. It has narrow glowing eyes. Small scars and rough edges mark it as a survivor. It charges without hesitation. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Rank · level | E · 26 (19–32) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 1 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1065 · 114 · 91 · 56 · 91 · 135 |
| XP · gold | 559 · 147 |
| Ring | 1 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Fire. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (override); animation set `anim_small_biped`.
- **Dimensions:** 1 m high × 0.3 m long × 0.4 m wide; prefab scale 0.909.
- **Physics:** 16 kg, gravity ×1.5, poise 33, knockback resistance 0.18, death style `ragdoll_crumple`.
- **Navigation:** speed 5.08 m/s, turn 420°/s, stopping distance 0.6 m.
- **Attack count:** 4; **signature:** [object Object].

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Sand Toss\|Sand Toss]] | debuff | 0 | 12 s | None | none | Keep moving and read the animation; do not assume a safe block. |

## Field guide

Goblin Trapper is a **menacing humanoid** encountered at E rank, around level 26. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** snares and rusted bells hanging from its belt. Watch for its tell and leave a response window before committing to a long combo.

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

- [[Monsters/Goblinoids/Grove Goblin Trapper|Grove Goblin Trapper]]
- [[Monsters/Goblinoids/Elite Goblin Trapper|Elite Goblin Trapper]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Whisperwood\|Whisperwood]] | 5 | E+, D-, E, E- | 19–40 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 6 | E+, E, F+, D, D- | 13–48 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00178` | Whisperwood Goblin Trapper Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | E+ | 32 | 1 m | Day & Night | Like a typical Goblin Trapper, but a rare pale form with white skin or fur and red eyes. |
| `pop_00179` | Aldmere Goblin Trapper Albino | [[Regions/Aldmere\|Aldmere]] | Albino | E+ | 32 | 1 m | Day & Night | Like a typical Goblin Trapper, but a rare pale form with white skin or fur and red eyes. |
| `pop_00180` | Aldmere Goblin Trapper | [[Regions/Aldmere\|Aldmere]] | Adult | E | 26 | 1 m | Day & Night | A typical adult Goblin Trapper of this region, with golden, grass-toned coloring. |
| `pop_00181` | Whisperwood Goblin Trapper Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | D- | 40 | 1.25 m | Day & Night | Like a typical Goblin Trapper, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_00182` | Aldmere Goblin Trapper Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | E+ | 32 | 1.1 m | Day & Night | Like a typical Goblin Trapper, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_00183` | Whisperwood Goblin Trapper Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | E+ | 32 | 1.1 m | Day & Night | Like a typical Goblin Trapper, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_00184` | Aldmere Goblin Trapper Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F+ | 13 | 0.7 m | Day & Night | Like a typical Goblin Trapper, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_00185` | Whisperwood Goblin Trapper | [[Regions/Whisperwood\|Whisperwood]] | Adult | E | 26 | 1 m | Day & Night | A typical adult Goblin Trapper of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_00186` | Aldmere Goblin Trapper Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | D | 48 | 1.35 m | Day & Night | Like a typical Goblin Trapper, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_00187` | Whisperwood Goblin Trapper Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | E- | 19 | 0.85 m | Day & Night | Like a typical Goblin Trapper, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_00188` | Aldmere Goblin Trapper Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D- | 40 | 1.25 m | Day & Night | Like a typical Goblin Trapper, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |

## Contracts and story encounters

- [[Quests/Weekly Board/Scrap Run|Scrap Run]] — rank undefined, in [[Regions/Whisperwood|Whisperwood]]

These links show where the species already matters to authored play. A contract target is not a claim that every local population is hostile; check the quest objective and the creature’s behavior before engaging.

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `rough_skin_leather` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · triangle-based silhouette, sharp asymmetric spikes
