---
type: monster
id: mon_phantom_bandit_bear
family: "Beasts"
rank: "D-"
tier: variant
tags: [monster, beasts]
---
# Phantom Bandit Bear

![[mon_phantom_bandit_bear_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_phantom_bandit_bear_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,322 tris · 0.506 × 2.2 × 0.988 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Phantom Bandit Bear is a person-sized creature with a long-legged predatory quadruped build, about 2.2 m long. Its coat is rough, scarred and spiked, colored in warm gold and pearl white. Guild sketches always show a dark mask-like band across its eyes. It has eyes that catch torchlight like coins. A distinctive marking runs along its back. It charges without hesitation, surrounded by soft radiance and floating motes of light. Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.

| Field | Value |
|---|---|
| Family · type | [[Families/Beasts|Beasts]] · Beast |
| Variant of | [[Monsters/Beasts/Bandit Bear\|Bandit Bear]] (spirit) |
| Rank · level | D- · 40 (32–48) |
| Menace | 3 · Menacing |
| Element · weakness | Light · Dark |
| Size | 2.2 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3355 · 204 · 170 · 136 · 153 · 100 |
| XP · gold | 1106 · 265 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Kitsune Isles\|Kitsune Isles]] |
| Genre | Classic Fantasy |
| Trope | The horned rabbit "rookie killer" and wolf packs of every isekai starter forest |

**Field note:** Weak to Dark. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 1.43 m high × 2.2 m long × 0.35 m wide; prefab scale 0.55.
- **Physics:** 202.3 kg, gravity ×1.08, poise 67, knockback resistance 0.91, death style `heavy_fall_dust`.
- **Navigation:** speed 5.73 m/s, turn 216°/s, stopping distance 0.84 m.
- **Attack count:** 5; **signature:** a dark mask-like band across its eyes.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rending Bite\|Rending Bite]] | melee | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Phantom Bandit Bear is a **menacing beast** encountered at D- rank, around level 40. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a dark mask-like band across its eyes. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Hoshizora|Hoshizora]], [[Regions/Kitsune Isles|Kitsune Isles]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Beasts D|loot_beast_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Pelt\|Pelt]] | 60% | 1–3 |
| [[Items/Fang\|Fang]] | 30% | 1–1 |
| [[Items/Prime Meat\|Prime Meat]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Kitsune Isles\|Kitsune Isles]] | 5 | C-, D, D-, E+ | 32–65 | Day & Night |
| [[Regions/Hoshizora\|Hoshizora]] | 6 | E, E+, D, D-, C- | 26–65 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06154` | Kitsune Isles Phantom Bandit Bear Elderborn | [[Regions/Kitsune Isles\|Kitsune Isles]] | Elderborn | C- | 65 | 2.97 m | Day & Night | Like a typical Phantom Bandit Bear, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_06155` | Kitsune Isles Phantom Bandit Bear Albino | [[Regions/Kitsune Isles\|Kitsune Isles]] | Albino | D | 48 | 2.2 m | Day & Night | Like a typical Phantom Bandit Bear, but a rare pale form with white skin or fur and red eyes. |
| `pop_06156` | Kitsune Isles Phantom Bandit Bear | [[Regions/Kitsune Isles\|Kitsune Isles]] | Adult | D- | 40 | 2.2 m | Day & Night | A typical adult Phantom Bandit Bear of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_06157` | Hoshizora Phantom Bandit Bear Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | E | 26 | 1.54 m | Day & Night | Like a typical Phantom Bandit Bear, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_06158` | Hoshizora Phantom Bandit Bear Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | E+ | 32 | 1.87 m | Day & Night | Like a typical Phantom Bandit Bear, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_06159` | Hoshizora Phantom Bandit Bear Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | D | 48 | 2.2 m | Day & Night | Like a typical Phantom Bandit Bear, but a rare pale form with white skin or fur and red eyes. |
| `pop_06160` | Hoshizora Phantom Bandit Bear | [[Regions/Hoshizora\|Hoshizora]] | Adult | D- | 40 | 2.2 m | Day & Night | A typical adult Phantom Bandit Bear of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_06161` | Kitsune Isles Phantom Bandit Bear Juvenile | [[Regions/Kitsune Isles\|Kitsune Isles]] | Juvenile | E+ | 32 | 1.87 m | Day & Night | Like a typical Phantom Bandit Bear, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_06162` | Hoshizora Phantom Bandit Bear Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | C- | 65 | 2.97 m | Day & Night | Like a typical Phantom Bandit Bear, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_06163` | Kitsune Isles Phantom Bandit Bear Scarred | [[Regions/Kitsune Isles\|Kitsune Isles]] | Scarred | D | 48 | 2.42 m | Day & Night | Like a typical Phantom Bandit Bear, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_06164` | Hoshizora Phantom Bandit Bear Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | D | 48 | 2.42 m | Day & Night | Like a typical Phantom Bandit Bear, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `fur_groom` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · triangle-based silhouette, sharp asymmetric spikes
