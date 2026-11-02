---
type: monster
id: mon_dire_wolf
family: "Beasts"
rank: "D"
tier: core
tags: [monster, beasts]
---
# Dire Wolf

![[mon_dire_wolf_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_dire_wolf_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,370 tris · 0.516 × 2 × 1.163 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Dire Wolf is a person-sized creature with a powerful four-legged hunter's body, about 2 m long. Its coat is rough, scarred and spiked, colored in cream. Its most striking feature is a horse-sized frame and a jaw full of jagged fangs. It has burning slit pupils. A distinctive marking runs along its back. It charges without hesitation. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Beasts|Beasts]] · Beast |
| Rank · level | D · 48 (40–56) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 2 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 4242 · 242 · 202 · 113 · 182 · 100 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Aldmere\|Aldmere]], [[Regions/Moraveil\|Moraveil]] |
| Genre | Classic Fantasy |
| Trope | The horned rabbit "rookie killer" and wolf packs of every isekai starter forest |

**Field note:** Weak to Fire. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 1.3 m high × 2 m long × 0.32 m wide; prefab scale 0.5.
- **Physics:** 160 kg, gravity ×1.2, poise 64, knockback resistance 0.91, death style `heavy_fall_dust`.
- **Navigation:** speed 5.73 m/s, turn 226°/s, stopping distance 0.8 m.
- **Attack count:** 4; **signature:** a horse-sized frame and a jaw full of jagged fangs.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rending Bite\|Rending Bite]] | melee | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |

## Field guide

Dire Wolf is a **menacing beast** encountered at D rank, around level 48. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a horse-sized frame and a jaw full of jagged fangs. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Hoshizora|Hoshizora]], [[Regions/Strife Marches|Strife Marches]], [[Regions/Aldmere|Aldmere]], [[Regions/Moraveil|Moraveil]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Beasts D|loot_beast_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Pelt\|Pelt]] | 60% | 1–3 |
| [[Items/Fang\|Fang]] | 30% | 1–1 |
| [[Items/Prime Meat\|Prime Meat]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Beasts/Meadow Dire Wolf|Meadow Dire Wolf]]
- [[Monsters/Beasts/Phantom Dire Wolf|Phantom Dire Wolf]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Moraveil\|Moraveil]] | 4 | C-, D+, E+ | 32–65 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 4 | C-, D+, E+ | 32–65 | Day & Night |
| [[Regions/Strife Marches\|Strife Marches]] | 2 | D, E+ | 32–48 | Day & Night |
| [[Regions/Hoshizora\|Hoshizora]] | 1 | D- | 40–40 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00420` | Moraveil Dire Wolf Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | C- | 65 | 2.5 m | Day & Night | Like a typical Dire Wolf, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_00421` | Aldmere Dire Wolf Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | C- | 65 | 2.5 m | Day & Night | Like a typical Dire Wolf, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_00422` | Strife Marches Dire Wolf | [[Regions/Strife Marches\|Strife Marches]] | Adult | D | 48 | 2 m | Day & Night | A typical adult Dire Wolf of this region, with golden, grass-toned coloring. |
| `pop_00423` | Moraveil Dire Wolf Albino | [[Regions/Moraveil\|Moraveil]] | Albino | D+ | 56 | 2 m | Day & Night | Like a typical Dire Wolf, but a rare pale form with white skin or fur and red eyes. |
| `pop_00424` | Moraveil Dire Wolf Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | D+ | 56 | 2.2 m | Day & Night | Like a typical Dire Wolf, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_00425` | Hoshizora Dire Wolf Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | D- | 40 | 1.7 m | Day & Night | Like a typical Dire Wolf, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_00426` | Strife Marches Dire Wolf Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | E+ | 32 | 1.4 m | Day & Night | Like a typical Dire Wolf, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_00427` | Aldmere Dire Wolf Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | D+ | 56 | 2.2 m | Day & Night | Like a typical Dire Wolf, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_00428` | Aldmere Dire Wolf Runt | [[Regions/Aldmere\|Aldmere]] | Runt | E+ | 32 | 1.4 m | Day & Night | Like a typical Dire Wolf, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_00429` | Moraveil Dire Wolf Runt | [[Regions/Moraveil\|Moraveil]] | Runt | E+ | 32 | 1.4 m | Day & Night | Like a typical Dire Wolf, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_00430` | Aldmere Dire Wolf Albino | [[Regions/Aldmere\|Aldmere]] | Albino | D+ | 56 | 2 m | Day & Night | Like a typical Dire Wolf, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `fur_groom` · VFX `dust_puffs` · palette `#d0c7a2` `#948a6c` `#ffecc6` · triangle-based silhouette, sharp asymmetric spikes
