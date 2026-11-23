---
type: monster
id: mon_phantom_dire_wolf
family: "Beasts"
rank: "D+"
tier: variant
tags: [monster, beasts]
---
# Phantom Dire Wolf

![[mon_phantom_dire_wolf_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_phantom_dire_wolf_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 0.501 × 2 × 1.207 m · local file `Game/Assets/_Game/Art/Models/Monsters/Beasts/mon_phantom_dire_wolf.fbx`

> The Phantom Dire Wolf is a person-sized creature with a long-legged predatory quadruped build, about 2 m long. Its coat is patchy and subtly wrong, as if assembled from memory, colored in cream, with gold markings. Look for a horse-sized frame and a jaw full of jagged fangs. It has pale, pupil-less eyes. A distinctive marking runs along its back. It glides without moving its legs, surrounded by soft radiance and floating motes of light. Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.

| Field | Value |
|---|---|
| Family · type | [[Families/Beasts|Beasts]] · Beast |
| Variant of | [[Monsters/Beasts/Dire Wolf\|Dire Wolf]] (spirit) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 4 · Dread |
| Element · weakness | Light · Dark |
| Size | 2 m |
| Behaviour | Pack (pack_flank+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 5324 · 281 · 234 · 187 · 211 · 100 |
| XP · gold | 1888 · 423 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Kitsune Isles\|Kitsune Isles]] |
| Genre | Classic Fantasy |
| Trope | The horned rabbit "rookie killer" and wolf packs of every isekai starter forest |

**Field note:** Weak to Dark. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 1.3 m high × 2 m long × 0.32 m wide; prefab scale 0.5.
- **Physics:** 152 kg, gravity ×1.08, poise 64, knockback resistance 0.91, death style `heavy_fall_dust`.
- **Navigation:** speed 5.46 m/s, turn 226°/s, stopping distance 0.8 m.
- **Attack count:** 5; **signature:** a horse-sized frame and a jaw full of jagged fangs.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rending Bite\|Rending Bite]] | melee | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Phantom Dire Wolf is a **dread beast** encountered at D+ rank, around level 56. Its documented behaviour is *Pack* and its AI pattern is *pack_flank+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a horse-sized frame and a jaw full of jagged fangs. Watch for its tell and leave a response window before committing to a long combo.

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
| [[Regions/Kitsune Isles\|Kitsune Isles]] | 5 | C+, C, D+, C-, D | 48–86 | Night |
| [[Regions/Hoshizora\|Hoshizora]] | 6 | D, C-, C, D-, D+, C+ | 40–86 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06165` | Kitsune Isles Phantom Dire Wolf Elderborn | [[Regions/Kitsune Isles\|Kitsune Isles]] | Elderborn | C+ | 86 | 2.7 m | Night | Like a typical Phantom Dire Wolf, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_06166` | Kitsune Isles Phantom Dire Wolf Alpha | [[Regions/Kitsune Isles\|Kitsune Isles]] | Alpha | C | 76 | 2.5 m | Night | Like a typical Phantom Dire Wolf, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_06167` | Kitsune Isles Phantom Dire Wolf | [[Regions/Kitsune Isles\|Kitsune Isles]] | Adult | D+ | 56 | 2 m | Night | A typical adult Phantom Dire Wolf of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_06168` | Hoshizora Phantom Dire Wolf Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | D | 48 | 1.7 m | Night | Like a typical Phantom Dire Wolf, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_06169` | Hoshizora Phantom Dire Wolf Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | C- | 65 | 2 m | Night | Like a typical Phantom Dire Wolf, but a rare pale form with white skin or fur and red eyes. |
| `pop_06170` | Hoshizora Phantom Dire Wolf Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | C | 76 | 2.5 m | Night | Like a typical Phantom Dire Wolf, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_06171` | Hoshizora Phantom Dire Wolf Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | D- | 40 | 1.4 m | Night | Like a typical Phantom Dire Wolf, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_06172` | Kitsune Isles Phantom Dire Wolf Scarred | [[Regions/Kitsune Isles\|Kitsune Isles]] | Scarred | C- | 65 | 2.2 m | Night | Like a typical Phantom Dire Wolf, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_06173` | Hoshizora Phantom Dire Wolf | [[Regions/Hoshizora\|Hoshizora]] | Adult | D+ | 56 | 2 m | Night | A typical adult Phantom Dire Wolf of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_06174` | Kitsune Isles Phantom Dire Wolf Juvenile | [[Regions/Kitsune Isles\|Kitsune Isles]] | Juvenile | D | 48 | 1.7 m | Night | Like a typical Phantom Dire Wolf, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_06175` | Hoshizora Phantom Dire Wolf Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | C+ | 86 | 2.7 m | Night | Like a typical Phantom Dire Wolf, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `fur_groom` · VFX `holy_motes` · palette `#c8b19c` `#8f7968` `#ffd166` · elongated, irregular silhouette; still-then-sudden timing
