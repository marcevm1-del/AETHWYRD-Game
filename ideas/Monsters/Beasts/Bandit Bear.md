---
type: monster
id: mon_bandit_bear
family: "Beasts"
rank: "E+"
tier: core
tags: [monster, beasts]
---
# Bandit Bear

![[mon_bandit_bear_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_bandit_bear_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 11,994 tris · 0.943 × 2.199 × 1.49 m · local file `Game/Assets/_Game/Art/Models/Monsters/Beasts/mon_bandit_bear.fbx`

> The Bandit Bear is a person-sized creature with a long-legged predatory quadruped build, about 2.2 m long. Its coat is weathered and natural, colored in ash-grey. Guild sketches always show a dark mask-like band across its eyes. It has dark, wary eyes. Small scars and rough edges mark it as a survivor. It prowls. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Beasts|Beasts]] · Beast |
| Rank · level | E+ · 32 (26–40) |
| Menace | 2 · Wild |
| Element · weakness | None · Fire |
| Size | 2.2 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2425 · 166 · 138 · 77 · 124 · 100 |
| XP · gold | 776 · 195 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Fanghold\|Fanghold]], [[Regions/Aldmere\|Aldmere]], [[Regions/Mossdeep\|Mossdeep]] |
| Genre | Classic Fantasy |
| Trope | The horned rabbit "rookie killer" and wolf packs of every isekai starter forest |

**Field note:** Weak to Fire. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 1.43 m high × 2.2 m long × 0.35 m wide; prefab scale 0.55.
- **Physics:** 213 kg, gravity ×1.2, poise 60, knockback resistance 0.88, death style `heavy_fall_dust`.
- **Navigation:** speed 5.73 m/s, turn 216°/s, stopping distance 0.84 m.
- **Attack count:** 4; **signature:** a dark mask-like band across its eyes.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rending Bite\|Rending Bite]] | melee | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |

## Field guide

Bandit Bear is a **wild beast** encountered at E+ rank, around level 32. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a dark mask-like band across its eyes. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Fanghold|Fanghold]], [[Regions/Aldmere|Aldmere]], [[Regions/Mossdeep|Mossdeep]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Beasts E|loot_beast_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Pelt\|Pelt]] | 60% | 1–3 |
| [[Items/Fang\|Fang]] | 30% | 1–1 |
| [[Items/Prime Meat\|Prime Meat]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Beasts/Elder Bandit Bear|Elder Bandit Bear]]
- [[Monsters/Beasts/Phantom Bandit Bear|Phantom Bandit Bear]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Fanghold\|Fanghold]] | 4 | E+, D-, D+ | 32–56 | Day & Night |
| [[Regions/Mossdeep\|Mossdeep]] | 4 | D-, E-, E, E+ | 19–40 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 3 | D-, D, E+ | 32–48 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00409` | Fanghold Bandit Bear | [[Regions/Fanghold\|Fanghold]] | Adult | E+ | 32 | 2.2 m | Day & Night | A typical adult Bandit Bear of this region, with golden, grass-toned coloring. |
| `pop_00410` | Mossdeep Bandit Bear Scarred | [[Regions/Mossdeep\|Mossdeep]] | Scarred | D- | 40 | 2.42 m | Day & Night | Like a typical Bandit Bear, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_00411` | Mossdeep Bandit Bear Runt | [[Regions/Mossdeep\|Mossdeep]] | Runt | E- | 19 | 1.54 m | Day & Night | Like a typical Bandit Bear, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_00412` | Aldmere Bandit Bear Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | D- | 40 | 2.42 m | Day & Night | Like a typical Bandit Bear, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_00413` | Fanghold Bandit Bear Albino | [[Regions/Fanghold\|Fanghold]] | Albino | D- | 40 | 2.2 m | Day & Night | Like a typical Bandit Bear, but a rare pale form with white skin or fur and red eyes. |
| `pop_00414` | Fanghold Bandit Bear Elderborn | [[Regions/Fanghold\|Fanghold]] | Elderborn | D+ | 56 | 2.97 m | Day & Night | Like a typical Bandit Bear, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_00415` | Fanghold Bandit Bear Scarred | [[Regions/Fanghold\|Fanghold]] | Scarred | D- | 40 | 2.42 m | Day & Night | Like a typical Bandit Bear, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_00416` | Aldmere Bandit Bear Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D | 48 | 2.75 m | Day & Night | Like a typical Bandit Bear, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_00417` | Mossdeep Bandit Bear Juvenile | [[Regions/Mossdeep\|Mossdeep]] | Juvenile | E | 26 | 1.87 m | Day & Night | Like a typical Bandit Bear, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_00418` | Mossdeep Bandit Bear | [[Regions/Mossdeep\|Mossdeep]] | Adult | E+ | 32 | 2.2 m | Day & Night | A typical adult Bandit Bear of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_00419` | Aldmere Bandit Bear | [[Regions/Aldmere\|Aldmere]] | Adult | E+ | 32 | 2.2 m | Day & Night | A typical adult Bandit Bear of this region, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `fur_groom` · VFX `dust_puffs` · palette `#8b8a84` `#5b5a55` `#cbc8c1` · real-animal silhouette with one fantasy exaggeration
