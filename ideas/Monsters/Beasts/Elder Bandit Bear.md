---
type: monster
id: mon_elder_bandit_bear
family: "Beasts"
rank: "D+"
tier: variant
tags: [monster, beasts]
---
# Elder Bandit Bear

![[mon_elder_bandit_bear_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_elder_bandit_bear_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 20,000 tris · 1.623 × 3.5 × 2.406 m · local file `Game/Assets/_Game/Art/Models/Monsters/Beasts/mon_elder_bandit_bear.fbx`

> The Elder Bandit Bear is a large creature with a heavy, muscular quadruped frame, about 3.5 m long. Its coat is weathered and natural, colored in ash-grey. Guild sketches always show a dark mask-like band across its eyes. It has amber predator eyes. A distinctive marking runs along its back. It stalks low to the ground. It has no visible aura; you hear its breathing before you see it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Beasts|Beasts]] · Beast |
| Variant of | [[Monsters/Beasts/Bandit Bear\|Bandit Bear]] (elder) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 2 · Wild |
| Element · weakness | None · Fire |
| Size | 3.5 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 6434 · 281 · 234 · 131 · 211 · 100 |
| XP · gold | 1888 · 423 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Strife Marches\|Strife Marches]] |
| Genre | Classic Fantasy |
| Trope | The horned rabbit "rookie killer" and wolf packs of every isekai starter forest |

**Field note:** Weak to Fire. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 2.28 m high × 3.5 m long × 0.56 m wide; prefab scale 0.875.
- **Physics:** 857.5 kg, gravity ×1.2, poise 85, knockback resistance 0.91, death style `heavy_fall_dust`.
- **Navigation:** speed 7.22 m/s, turn 171°/s, stopping distance 1.1 m.
- **Attack count:** 4; **signature:** a dark mask-like band across its eyes.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rending Bite\|Rending Bite]] | melee | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |

## Field guide

Elder Bandit Bear is a **wild beast** encountered at D+ rank, around level 56. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a dark mask-like band across its eyes. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Hoshizora|Hoshizora]], [[Regions/Strife Marches|Strife Marches]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Strife Marches\|Strife Marches]] | 6 | C+, C-, D+, D-, D, C | 40–86 | Day & Night |
| [[Regions/Hoshizora\|Hoshizora]] | 5 | D+, C, C-, D- | 40–76 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03313` | Strife Marches Elder Bandit Bear Elderborn | [[Regions/Strife Marches\|Strife Marches]] | Elderborn | C+ | 86 | 4.73 m | Day & Night | Like a typical Elder Bandit Bear, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_03314` | Hoshizora Elder Bandit Bear | [[Regions/Hoshizora\|Hoshizora]] | Adult | D+ | 56 | 3.5 m | Day & Night | A typical adult Elder Bandit Bear of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_03315` | Strife Marches Elder Bandit Bear Albino | [[Regions/Strife Marches\|Strife Marches]] | Albino | C- | 65 | 3.5 m | Day & Night | Like a typical Elder Bandit Bear, but a rare pale form with white skin or fur and red eyes. |
| `pop_03316` | Strife Marches Elder Bandit Bear | [[Regions/Strife Marches\|Strife Marches]] | Adult | D+ | 56 | 3.5 m | Day & Night | A typical adult Elder Bandit Bear of this region, with golden, grass-toned coloring. |
| `pop_03317` | Strife Marches Elder Bandit Bear Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | D- | 40 | 2.45 m | Day & Night | Like a typical Elder Bandit Bear, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_03318` | Strife Marches Elder Bandit Bear Juvenile | [[Regions/Strife Marches\|Strife Marches]] | Juvenile | D | 48 | 2.98 m | Day & Night | Like a typical Elder Bandit Bear, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_03319` | Hoshizora Elder Bandit Bear Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | C | 76 | 4.38 m | Day & Night | Like a typical Elder Bandit Bear, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_03320` | Hoshizora Elder Bandit Bear Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | C- | 65 | 3.85 m | Day & Night | Like a typical Elder Bandit Bear, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_03321` | Hoshizora Elder Bandit Bear Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | D- | 40 | 2.45 m | Day & Night | Like a typical Elder Bandit Bear, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_03322` | Strife Marches Elder Bandit Bear Alpha | [[Regions/Strife Marches\|Strife Marches]] | Alpha | C | 76 | 4.38 m | Day & Night | Like a typical Elder Bandit Bear, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_03323` | Hoshizora Elder Bandit Bear Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | C- | 65 | 3.5 m | Day & Night | Like a typical Elder Bandit Bear, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `fur_groom` · VFX `dust_puffs` · palette `#8b8884` `#5b5955` `#cbc8c1` · real-animal silhouette with one fantasy exaggeration
