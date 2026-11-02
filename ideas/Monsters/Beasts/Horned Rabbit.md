---
type: monster
id: mon_horned_rabbit
family: "Beasts"
rank: "F-"
tier: core
tags: [monster, beasts]
---
# Horned Rabbit

![[mon_horned_rabbit_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_horned_rabbit_front/side/back.jpg`).*

> [!note] 3D model: hand-built Ring 0 model, or not exported yet.

> The Horned Rabbit is a tiny creature with a low, springy quadruped build, about 0.4 m long. Its coat is weathered and natural, colored in warm brown with a cream belly. Survivors describe a single spiral horn and oversized hind feet. It has dark, wary eyes. It has no ornament at all: simple, readable shapes. It prowls. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Beasts|Beasts]] · Beast |
| Rank · level | F- · 3 (1–5) |
| Menace | 2 · Wild |
| Element · weakness | None · Fire |
| Size | 0.4 m |
| Behaviour | Skittish (skittish_flee) |
| HP · ATK · DEF · MATK · MDEF · SPD | 42 · 25 · 12 · 11 · 18 · 176 |
| XP · gold | 25 · 10 |
| Ring | 0 |
| Rig · animation | [[Systems/Rigs/quad_small\|quad_small]] · `anim_quad_small` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Classic Fantasy |
| Trope | The horned rabbit "rookie killer" and wolf packs of every isekai starter forest |

**Field note:** Weak to Fire. Flees when hurt. Snares or ranged attacks work best.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_small|quad_small]] (override); animation set `anim_quad_small`.
- **Dimensions:** 0.27 m high × 0.4 m long × 0.06 m wide; prefab scale 0.8.
- **Physics:** 1.9 kg, gravity ×1.6, poise 18, knockback resistance 0.05, death style `ragdoll_tumble`.
- **Navigation:** speed 6.4 m/s, turn 854°/s, stopping distance 0.5 m.
- **Attack count:** 4; **signature:** [object Object].

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Bite\|Bite]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Charge\|Charge]] | dash | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Leap\|Leap]] | dash | 1.2 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Rending Bite\|Rending Bite]] | melee | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |

## Field guide

Horned Rabbit is a **wild beast** encountered at F- rank, around level 3. Its documented behaviour is *Skittish* and its AI pattern is *skittish_flee*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a single spiral horn and oversized hind feet. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_small`, animation set `anim_quad_small`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Beasts F|loot_beast_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Pelt\|Pelt]] | 60% | 1–3 |
| [[Items/Fang\|Fang]] | 30% | 1–1 |
| [[Items/Prime Meat\|Prime Meat]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Beasts/Ancient Horned Rabbit|Ancient Horned Rabbit]]
- [[Monsters/Beasts/Elder Horned Rabbit|Elder Horned Rabbit]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Whisperwood\|Whisperwood]] | 6 | E-, F+, F, F- | 3–19 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 5 | E-, F, F- | 3–19 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00376` | Whisperwood Horned Rabbit Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | E- | 19 | 0.54 m | Day & Night | Like a typical Horned Rabbit, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_00377` | Whisperwood Horned Rabbit Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | F+ | 13 | 0.5 m | Day & Night | Like a typical Horned Rabbit, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_00378` | Whisperwood Horned Rabbit Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | F | 8 | 0.4 m | Day & Night | Like a typical Horned Rabbit, but a rare pale form with white skin or fur and red eyes. |
| `pop_00379` | Aldmere Horned Rabbit Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | E- | 19 | 0.54 m | Day & Night | Like a typical Horned Rabbit, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_00380` | Whisperwood Horned Rabbit Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | F- | 3 | 0.34 m | Day & Night | Like a typical Horned Rabbit, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_00381` | Whisperwood Horned Rabbit Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | F | 8 | 0.44 m | Day & Night | Like a typical Horned Rabbit, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_00382` | Aldmere Horned Rabbit Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | F | 8 | 0.44 m | Day & Night | Like a typical Horned Rabbit, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_00383` | Aldmere Horned Rabbit | [[Regions/Aldmere\|Aldmere]] | Adult | F- | 3 | 0.4 m | Day & Night | A typical adult Horned Rabbit of this region, with golden, grass-toned coloring. |
| `pop_00384` | Aldmere Horned Rabbit Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F- | 3 | 0.28 m | Day & Night | Like a typical Horned Rabbit, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_00385` | Whisperwood Horned Rabbit | [[Regions/Whisperwood\|Whisperwood]] | Adult | F- | 3 | 0.4 m | Day & Night | A typical adult Horned Rabbit of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_00386` | Aldmere Horned Rabbit Albino | [[Regions/Aldmere\|Aldmere]] | Albino | F | 8 | 0.4 m | Day & Night | Like a typical Horned Rabbit, but a rare pale form with white skin or fur and red eyes. |

## Contracts and story encounters

- [[Quests/Rabbit Season|Rabbit Season]] — rank F, in [[Regions/Aldmere|Aldmere]]
- [[Quests/Weekly Board/Fix the Fence|Fix the Fence]] — rank undefined, in [[Regions/Aldmere|Aldmere]]
- [[Quests/Weekly Board/Granny's Taming Lesson|Granny's Taming Lesson]] — rank undefined, in [[Regions/Whisperwood|Whisperwood]]

These links show where the species already matters to authored play. A contract target is not a claim that every local population is hostile; check the quest objective and the creature’s behavior before engaging.

## Design recipe

Rig `rig_quad_small` · mesh `quad_small_base` · material `fur_groom` · VFX `dust_puffs` · palette `#a8774e` `#7a5434` `#f0e0c0` · real-animal silhouette with one fantasy exaggeration
