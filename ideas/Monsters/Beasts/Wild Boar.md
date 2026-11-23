---
type: monster
id: mon_wild_boar
family: "Beasts"
rank: "E"
tier: core
tags: [monster, beasts]
---
# Wild Boar

![[mon_wild_boar_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_wild_boar_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 0.573 × 1.4 × 0.887 m · local file `Game/Assets/_Game/Art/Models/Monsters/Beasts/mon_wild_boar.fbx`

> The Wild Boar is a person-sized creature with a heavy, muscular quadruped frame, about 1.4 m long. Its coat is weathered and natural, colored in warm brown, with ochre markings. Look for curved tusks and a ridge of bristles like iron wire. It has amber predator eyes. Small scars and rough edges mark it as a survivor. It lopes in long strides, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Beasts|Beasts]] · Beast |
| Rank · level | E · 26 (19–32) |
| Menace | 2 · Wild |
| Element · weakness | Earth · Wind |
| Size | 1.4 m |
| Behaviour | Skittish (skittish_flee) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1542 · 137 · 114 · 91 · 103 · 100 |
| XP · gold | 559 · 147 |
| Ring | 1 |
| Rig · animation | [[Systems/Rigs/quad_medium\|quad_medium]] · `anim_quad_large` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Classic Fantasy |
| Trope | The horned rabbit "rookie killer" and wolf packs of every isekai starter forest |

**Field note:** Weak to Wind. Flees when hurt. Snares or ranged attacks work best.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_medium|quad_medium]] (override); animation set `anim_quad_large`.
- **Dimensions:** 0.94 m high × 1.4 m long × 0.2 m wide; prefab scale 0.933.
- **Physics:** 68.5 kg, gravity ×1.54, poise 44, knockback resistance 0.48, death style `ragdoll_slide`.
- **Navigation:** speed 7.06 m/s, turn 338°/s, stopping distance 0.62 m.
- **Attack count:** 5; **signature:** [object Object].

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rending Bite\|Rending Bite]] | melee | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Wild Boar is a **wild beast** encountered at E rank, around level 26. Its documented behaviour is *Skittish* and its AI pattern is *skittish_flee*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** curved tusks and a ridge of bristles like iron wire. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Beasts E|loot_beast_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Pelt\|Pelt]] | 60% | 1–3 |
| [[Items/Fang\|Fang]] | 30% | 1–1 |
| [[Items/Prime Meat\|Prime Meat]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Beasts/Crag Boar|Crag Boar]]
- [[Monsters/Beasts/Phantom Wild Boar|Phantom Wild Boar]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 6 | E+, F+, D, E, E- | 13–48 | Day & Night |
| [[Regions/Whisperwood\|Whisperwood]] | 5 | E+, E, E-, D- | 19–40 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00398` | Aldmere Wild Boar Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | E+ | 32 | 1.54 m | Day & Night | Like a typical Wild Boar, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_00399` | Whisperwood Wild Boar Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | E+ | 32 | 1.4 m | Day & Night | Like a typical Wild Boar, but a rare pale form with white skin or fur and red eyes. |
| `pop_00400` | Aldmere Wild Boar Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F+ | 13 | 0.98 m | Day & Night | Like a typical Wild Boar, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_00401` | Aldmere Wild Boar Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | D | 48 | 1.89 m | Day & Night | Like a typical Wild Boar, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_00402` | Aldmere Wild Boar | [[Regions/Aldmere\|Aldmere]] | Adult | E | 26 | 1.4 m | Day & Night | A typical adult Wild Boar of this region, with golden, grass-toned coloring. |
| `pop_00403` | Whisperwood Wild Boar | [[Regions/Whisperwood\|Whisperwood]] | Adult | E | 26 | 1.4 m | Day & Night | A typical adult Wild Boar of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_00404` | Aldmere Wild Boar Albino | [[Regions/Aldmere\|Aldmere]] | Albino | E+ | 32 | 1.4 m | Day & Night | Like a typical Wild Boar, but a rare pale form with white skin or fur and red eyes. |
| `pop_00405` | Whisperwood Wild Boar Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | E- | 19 | 1.19 m | Day & Night | Like a typical Wild Boar, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_00406` | Aldmere Wild Boar Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E- | 19 | 1.19 m | Day & Night | Like a typical Wild Boar, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_00407` | Whisperwood Wild Boar Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | E+ | 32 | 1.54 m | Day & Night | Like a typical Wild Boar, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_00408` | Whisperwood Wild Boar Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | D- | 40 | 1.75 m | Day & Night | Like a typical Wild Boar, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |

## Contracts and story encounters

- [[Quests/The Crimson Wolves|The Crimson Wolves]] — rank E, in [[Regions/Whisperwood|Whisperwood]]
- [[Quests/Two on the Road|Two on the Road]] — rank F, in [[Regions/Whisperwood|Whisperwood]]
- [[Quests/Weekly Board/Race the Crimson Wolves|Race the Crimson Wolves]] — rank undefined, in [[Regions/Whisperwood|Whisperwood]]
- [[Quests/Weekly Board/Open Hunting Contract|Open Hunting Contract]] — rank undefined, in [[Regions/Whisperwood|Whisperwood]]
- [[Quests/Weekly Board/Party of Two Contract|Party of Two Contract]] — rank undefined, in [[Regions/Whisperwood|Whisperwood]]

These links show where the species already matters to authored play. A contract target is not a claim that every local population is hostile; check the quest objective and the creature’s behavior before engaging.

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `fur_groom` · VFX `rock_debris` · palette `#886045` `#583c2f` `#d1a15a` · real-animal silhouette with one fantasy exaggeration
