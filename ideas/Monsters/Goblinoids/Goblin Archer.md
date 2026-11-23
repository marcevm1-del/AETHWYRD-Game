---
type: monster
id: mon_goblin_archer
family: "Goblinoids"
rank: "F+"
tier: core
tags: [monster, goblinoids]
---
# Goblin Archer

![[mon_goblin_archer_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_goblin_archer_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 0.822 × 0.542 × 1 m · local file `Game/Assets/_Game/Art/Models/Monsters/Goblinoids/mon_goblin_archer.fbx`

> The Goblin Archer is a small creature with a scrawny biped with long arms and bowed legs, about 1 m tall. Its skin is rough, scarred and spiked, colored in moss green and leather brown. Survivors describe a crooked bow strung with gut and a quiver of bone-tipped arrows. It has narrow glowing eyes. It has no ornament at all: simple, readable shapes. It charges without hesitation. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Rank · level | F+ · 13 (8–19) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 1 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 410 · 62 · 50 · 30 · 50 · 135 |
| XP · gold | 190 · 57 |
| Ring | 1 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Fire. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (override); animation set `anim_small_biped`.
- **Dimensions:** 1 m high × 0.3 m long × 0.4 m wide; prefab scale 0.909.
- **Physics:** 16 kg, gravity ×1.5, poise 29, knockback resistance 0.15, death style `ragdoll_crumple`.
- **Navigation:** speed 5.32 m/s, turn 420°/s, stopping distance 0.6 m.
- **Attack count:** 4; **signature:** [object Object].

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Sand Toss\|Sand Toss]] | debuff | 0 | 12 s | None | none | Keep moving and read the animation; do not assume a safe block. |

## Field guide

Goblin Archer is a **menacing humanoid** encountered at F+ rank, around level 13. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a crooked bow strung with gut and a quiver of bone-tipped arrows. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Goblinoids F|loot_goblinoid_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Goblinoids/Phantom Goblin Archer|Phantom Goblin Archer]]
- [[Monsters/Goblinoids/Ancient Goblin Archer|Ancient Goblin Archer]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Whisperwood\|Whisperwood]] | 6 | E-, F-, E, F, F+, E+ | 3–32 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 5 | F, E-, F+, F-, E+ | 3–32 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00167` | Whisperwood Goblin Archer Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | E- | 19 | 1.1 m | Day & Night | Like a typical Goblin Archer, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_00168` | Aldmere Goblin Archer Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | F | 8 | 0.85 m | Day & Night | Like a typical Goblin Archer, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_00169` | Whisperwood Goblin Archer Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | F- | 3 | 0.7 m | Day & Night | Like a typical Goblin Archer, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_00170` | Whisperwood Goblin Archer Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | E | 26 | 1.25 m | Day & Night | Like a typical Goblin Archer, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_00171` | Whisperwood Goblin Archer Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | F | 8 | 0.85 m | Day & Night | Like a typical Goblin Archer, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_00172` | Whisperwood Goblin Archer | [[Regions/Whisperwood\|Whisperwood]] | Adult | F+ | 13 | 1 m | Day & Night | A typical adult Goblin Archer of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_00173` | Aldmere Goblin Archer Albino | [[Regions/Aldmere\|Aldmere]] | Albino | E- | 19 | 1 m | Day & Night | Like a typical Goblin Archer, but a rare pale form with white skin or fur and red eyes. |
| `pop_00174` | Aldmere Goblin Archer | [[Regions/Aldmere\|Aldmere]] | Adult | F+ | 13 | 1 m | Day & Night | A typical adult Goblin Archer of this region, with golden, grass-toned coloring. |
| `pop_00175` | Whisperwood Goblin Archer Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | E+ | 32 | 1.35 m | Day & Night | Like a typical Goblin Archer, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_00176` | Aldmere Goblin Archer Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F- | 3 | 0.7 m | Day & Night | Like a typical Goblin Archer, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_00177` | Aldmere Goblin Archer Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | E+ | 32 | 1.35 m | Day & Night | Like a typical Goblin Archer, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `rough_skin_leather` · VFX `dust_puffs` · palette `#6fae45` `#8a5a35` `#b8bec6` · triangle-based silhouette, sharp asymmetric spikes
