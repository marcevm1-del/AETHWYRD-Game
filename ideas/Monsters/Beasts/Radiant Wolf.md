---
type: monster
id: mon_radiant_wolf
family: "Beasts"
rank: "E-"
tier: variant
tags: [monster, beasts]
---
# Radiant Wolf

![[mon_radiant_wolf_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_radiant_wolf_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,184 tris · 0.272 × 1.2 × 0.539 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Radiant Wolf is a person-sized creature with a heavy, muscular quadruped frame, about 1.2 m long. Its coat is weathered and natural, colored in dark brown, with gold markings. Its most striking feature is a grey-green coat that blends with ferns. It has alert animal eyes. Small scars and rough edges mark it as a survivor. It prowls, surrounded by soft radiance and floating motes of light. This Light-attuned variant carries one extra elemental feature, like element-scarred hide, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Beasts|Beasts]] · Beast |
| Variant of | [[Monsters/Beasts/Forest Wolf\|Forest Wolf]] (elemental) |
| Rank · level | E- · 19 (13–26) |
| Menace | 2 · Wild |
| Element · weakness | Light · Dark |
| Size | 1.2 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 941 · 103 · 86 · 69 · 77 · 100 |
| XP · gold | 342 · 96 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/quad_medium\|quad_medium]] · `anim_quad_large` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Fanghold\|Fanghold]] |
| Genre | Classic Fantasy |
| Trope | The horned rabbit "rookie killer" and wolf packs of every isekai starter forest |

**Field note:** Weak to Dark. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_medium|quad_medium]] (override (base species)); animation set `anim_quad_large`.
- **Dimensions:** 0.8 m high × 1.2 m long × 0.17 m wide; prefab scale 0.8.
- **Physics:** 19.7 kg, gravity ×1.26, poise 27, knockback resistance 0.33, death style `ragdoll_slide`.
- **Navigation:** speed 5.92 m/s, turn 365°/s, stopping distance 0.59 m.
- **Attack count:** 5; **signature:** a grey-green coat that blends with ferns.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rending Bite\|Rending Bite]] | melee | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Radiant Wolf is a **wild beast** encountered at E- rank, around level 19. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a grey-green coat that blends with ferns. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Fanghold|Fanghold]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Beasts E|loot_beast_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Pelt\|Pelt]] | 60% | 1–3 |
| [[Items/Fang\|Fang]] | 30% | 1–1 |
| [[Items/Prime Meat\|Prime Meat]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Fanghold\|Fanghold]] | 6 | E, F+, E+, F, E- | 8–32 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 5 | E+, D-, E-, F, E | 8–40 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03291` | Fanghold Radiant Wolf Scarred | [[Regions/Fanghold\|Fanghold]] | Scarred | E | 26 | 1.32 m | Day & Night | Like a typical Radiant Wolf, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_03292` | Fanghold Radiant Wolf Juvenile | [[Regions/Fanghold\|Fanghold]] | Juvenile | F+ | 13 | 1.02 m | Day & Night | Like a typical Radiant Wolf, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_03293` | Aldmere Radiant Wolf Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | E+ | 32 | 1.5 m | Day & Night | Like a typical Radiant Wolf, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_03294` | Aldmere Radiant Wolf Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | D- | 40 | 1.62 m | Day & Night | Like a typical Radiant Wolf, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_03295` | Fanghold Radiant Wolf Alpha | [[Regions/Fanghold\|Fanghold]] | Alpha | E+ | 32 | 1.5 m | Day & Night | Like a typical Radiant Wolf, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_03296` | Fanghold Radiant Wolf Runt | [[Regions/Fanghold\|Fanghold]] | Runt | F | 8 | 0.84 m | Day & Night | Like a typical Radiant Wolf, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_03297` | Aldmere Radiant Wolf | [[Regions/Aldmere\|Aldmere]] | Adult | E- | 19 | 1.2 m | Day & Night | A typical adult Radiant Wolf of this region, with golden, grass-toned coloring. |
| `pop_03298` | Fanghold Radiant Wolf | [[Regions/Fanghold\|Fanghold]] | Adult | E- | 19 | 1.2 m | Day & Night | A typical adult Radiant Wolf of this region, with golden, grass-toned coloring. |
| `pop_03299` | Aldmere Radiant Wolf Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F | 8 | 0.84 m | Day & Night | Like a typical Radiant Wolf, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_03300` | Aldmere Radiant Wolf Albino | [[Regions/Aldmere\|Aldmere]] | Albino | E | 26 | 1.2 m | Day & Night | Like a typical Radiant Wolf, but a rare pale form with white skin or fur and red eyes. |
| `pop_03301` | Fanghold Radiant Wolf Albino | [[Regions/Fanghold\|Fanghold]] | Albino | E | 26 | 1.2 m | Day & Night | Like a typical Radiant Wolf, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `fur_groom` · VFX `holy_motes` · palette `#664f46` `#493834` `#ffd166` · real-animal silhouette with one fantasy exaggeration
