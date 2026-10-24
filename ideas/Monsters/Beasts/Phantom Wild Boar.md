---
type: monster
id: mon_phantom_wild_boar
family: "Beasts"
rank: "E+"
tier: variant
tags: [monster, beasts]
---
# Phantom Wild Boar

![[mon_phantom_wild_boar_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_phantom_wild_boar_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Phantom Wild Boar is a person-sized creature with a long-legged predatory quadruped build, about 1.4 m long. Its coat is rough, scarred and spiked, colored in warm gold and pearl white. Look for curved tusks and a ridge of bristles like iron wire. It has burning slit pupils. Small scars and rough edges mark it as a survivor. It strides with heavy steps, surrounded by soft radiance and floating motes of light. Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.

| Field | Value |
|---|---|
| Family · type | [[Families/Beasts|Beasts]] · Beast |
| Variant of | [[Monsters/Beasts/Wild Boar\|Wild Boar]] (spirit) |
| Rank · level | E+ · 32 (26–40) |
| Menace | 3 · Menacing |
| Element · weakness | Light · Dark |
| Size | 1.4 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2078 · 166 · 138 · 110 · 124 · 100 |
| XP · gold | 776 · 195 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/quad_medium\|quad_medium]] · `anim_quad_large` |
| Habitats | [[Regions/Fanghold\|Fanghold]], [[Regions/Aldmere\|Aldmere]], [[Regions/Sylvaran\|Sylvaran]] |
| Genre | Classic Fantasy |
| Trope | The horned rabbit "rookie killer" and wolf packs of every isekai starter forest |

**Field note:** Weak to Dark. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_medium|quad_medium]] (override (base species)); animation set `anim_quad_large`.
- **Dimensions:** 0.94 m high × 1.4 m long × 0.2 m wide; prefab scale 0.933.
- **Physics:** 31.3 kg, gravity ×1.26, poise 33, knockback resistance 0.33, death style `ragdoll_slide`.
- **Navigation:** speed 6.71 m/s, turn 338°/s, stopping distance 0.62 m.
- **Attack count:** 5; **signature:** curved tusks and a ridge of bristles like iron wire.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rending Bite\|Rending Bite]] | melee | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Phantom Wild Boar is a **menacing beast** encountered at E+ rank, around level 32. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** curved tusks and a ridge of bristles like iron wire. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Fanghold|Fanghold]], [[Regions/Aldmere|Aldmere]], [[Regions/Sylvaran|Sylvaran]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Sylvaran\|Sylvaran]] | 4 | E+, E-, D+, D- | 19–56 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 4 | D-, E+, E | 26–40 | Day & Night |
| [[Regions/Fanghold\|Fanghold]] | 3 | D, D-, D+ | 40–56 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06143` | Sylvaran Phantom Wild Boar | [[Regions/Sylvaran\|Sylvaran]] | Adult | E+ | 32 | 1.4 m | Day & Night | A typical adult Phantom Wild Boar of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_06144` | Aldmere Phantom Wild Boar Albino | [[Regions/Aldmere\|Aldmere]] | Albino | D- | 40 | 1.4 m | Day & Night | Like a typical Phantom Wild Boar, but a rare pale form with white skin or fur and red eyes. |
| `pop_06145` | Fanghold Phantom Wild Boar Alpha | [[Regions/Fanghold\|Fanghold]] | Alpha | D | 48 | 1.75 m | Day & Night | Like a typical Phantom Wild Boar, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_06146` | Fanghold Phantom Wild Boar Albino | [[Regions/Fanghold\|Fanghold]] | Albino | D- | 40 | 1.4 m | Day & Night | Like a typical Phantom Wild Boar, but a rare pale form with white skin or fur and red eyes. |
| `pop_06147` | Aldmere Phantom Wild Boar Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | D- | 40 | 1.54 m | Day & Night | Like a typical Phantom Wild Boar, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_06148` | Aldmere Phantom Wild Boar | [[Regions/Aldmere\|Aldmere]] | Adult | E+ | 32 | 1.4 m | Day & Night | A typical adult Phantom Wild Boar of this region, with golden, grass-toned coloring. |
| `pop_06149` | Aldmere Phantom Wild Boar Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E | 26 | 1.19 m | Day & Night | Like a typical Phantom Wild Boar, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_06150` | Sylvaran Phantom Wild Boar Runt | [[Regions/Sylvaran\|Sylvaran]] | Runt | E- | 19 | 0.98 m | Day & Night | Like a typical Phantom Wild Boar, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_06151` | Sylvaran Phantom Wild Boar Elderborn | [[Regions/Sylvaran\|Sylvaran]] | Elderborn | D+ | 56 | 1.89 m | Day & Night | Like a typical Phantom Wild Boar, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_06152` | Fanghold Phantom Wild Boar Elderborn | [[Regions/Fanghold\|Fanghold]] | Elderborn | D+ | 56 | 1.89 m | Day & Night | Like a typical Phantom Wild Boar, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_06153` | Sylvaran Phantom Wild Boar Scarred | [[Regions/Sylvaran\|Sylvaran]] | Scarred | D- | 40 | 1.54 m | Day & Night | Like a typical Phantom Wild Boar, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `fur_groom` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · triangle-based silhouette, sharp asymmetric spikes
