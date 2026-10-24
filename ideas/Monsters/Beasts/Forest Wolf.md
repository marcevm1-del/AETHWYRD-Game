---
type: monster
id: mon_forest_wolf
family: "Beasts"
rank: "F+"
tier: core
tags: [monster, beasts]
---
# Forest Wolf

> The Forest Wolf is a person-sized creature with a long-legged predatory quadruped build, about 1.2 m long. Its coat is weathered and natural, colored in muted greys and dusty browns. Look for a grey-green coat that blends with ferns. It has alert animal eyes. It has no ornament at all: simple, readable shapes. It prowls. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Beasts|Beasts]] · Beast |
| Rank · level | F+ · 13 (8–19) |
| Menace | 2 · Wild |
| Element · weakness | None · Fire |
| Size | 1.2 m |
| Behaviour | Skittish (skittish_flee) |
| HP · ATK · DEF · MATK · MDEF · SPD | 563 · 74 · 62 · 35 · 56 · 100 |
| XP · gold | 190 · 57 |
| Ring | 1 |
| Rig · animation | [[Systems/Rigs/quad_medium\|quad_medium]] · `anim_quad_large` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Classic Fantasy |
| Trope | The horned rabbit "rookie killer" and wolf packs of every isekai starter forest |

**Field note:** Weak to Fire. Flees when hurt. Snares or ranged attacks work best.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_medium|quad_medium]] (override); animation set `anim_quad_large`.
- **Dimensions:** 0.8 m high × 1.2 m long × 0.17 m wide; prefab scale 0.8.
- **Physics:** 20.7 kg, gravity ×1.4, poise 23, knockback resistance 0.3, death style `ragdoll_slide`.
- **Navigation:** speed 7.1 m/s, turn 365°/s, stopping distance 0.59 m.
- **Attack count:** 4; **signature:** [object Object].

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rending Bite\|Rending Bite]] | melee | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |

## Field guide

Forest Wolf is a **wild beast** encountered at F+ rank, around level 13. Its documented behaviour is *Skittish* and its AI pattern is *skittish_flee*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a grey-green coat that blends with ferns. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Beasts F|loot_beast_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Pelt\|Pelt]] | 60% | 1–3 |
| [[Items/Fang\|Fang]] | 30% | 1–1 |
| [[Items/Prime Meat\|Prime Meat]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Beasts/Radiant Wolf|Radiant Wolf]]
- [[Monsters/Beasts/Ancient Forest Wolf|Ancient Forest Wolf]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Whisperwood\|Whisperwood]] | 6 | E-, F-, F+, E, F | 3–26 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 5 | E+, F, F+, E- | 8–32 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00387` | Whisperwood Forest Wolf Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | E- | 19 | 1.32 m | Day & Night | Like a typical Forest Wolf, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_00388` | Aldmere Forest Wolf Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | E+ | 32 | 1.62 m | Day & Night | Like a typical Forest Wolf, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_00389` | Whisperwood Forest Wolf Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | F- | 3 | 0.84 m | Day & Night | Like a typical Forest Wolf, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_00390` | Aldmere Forest Wolf Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | F | 8 | 1.02 m | Day & Night | Like a typical Forest Wolf, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_00391` | Aldmere Forest Wolf | [[Regions/Aldmere\|Aldmere]] | Adult | F+ | 13 | 1.2 m | Day & Night | A typical adult Forest Wolf of this region, with golden, grass-toned coloring. |
| `pop_00392` | Whisperwood Forest Wolf | [[Regions/Whisperwood\|Whisperwood]] | Adult | F+ | 13 | 1.2 m | Day & Night | A typical adult Forest Wolf of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_00393` | Aldmere Forest Wolf Albino | [[Regions/Aldmere\|Aldmere]] | Albino | E- | 19 | 1.2 m | Day & Night | Like a typical Forest Wolf, but a rare pale form with white skin or fur and red eyes. |
| `pop_00394` | Whisperwood Forest Wolf Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | E- | 19 | 1.2 m | Day & Night | Like a typical Forest Wolf, but a rare pale form with white skin or fur and red eyes. |
| `pop_00395` | Aldmere Forest Wolf Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | E- | 19 | 1.32 m | Day & Night | Like a typical Forest Wolf, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_00396` | Whisperwood Forest Wolf Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | E | 26 | 1.5 m | Day & Night | Like a typical Forest Wolf, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_00397` | Whisperwood Forest Wolf Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | F | 8 | 1.02 m | Day & Night | Like a typical Forest Wolf, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |

## Contracts and story encounters

- [[Quests/Status Granted|Status Granted]] — rank F, in [[Regions/Whisperwood|Whisperwood]]
- [[Quests/The Crimson Wolves|The Crimson Wolves]] — rank E, in [[Regions/Whisperwood|Whisperwood]]
- [[Quests/Whisperwood Hunting Contract|Whisperwood Hunting Contract]] — rank E, in [[Regions/Whisperwood|Whisperwood]]
- [[Quests/Weekly Board/Wolves on the Road|Wolves on the Road]] — rank undefined, in [[Regions/Whisperwood|Whisperwood]]

These links show where the species already matters to authored play. A contract target is not a claim that every local population is hostile; check the quest objective and the creature’s behavior before engaging.

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `fur_groom` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · real-animal silhouette with one fantasy exaggeration
