---
type: monster
id: mon_elder_behemoth_calf
family: "Beasts"
rank: "A+"
tier: variant
tags: [monster, beasts]
---
# Elder Behemoth Calf

![[mon_elder_behemoth_calf_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_elder_behemoth_calf_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 19,998 tris · 3.146 × 6.4 × 4.65 m · local file `Game/Assets/_Game/Art/Models/Monsters/Beasts/mon_elder_behemoth_calf.fbx`

> The Elder Behemoth Calf is a huge creature with a powerful four-legged hunter's body, about 6.4 m long. Its coat is weathered and natural, colored in warm brown, with ochre markings. Its most striking feature is a stone-plated back and stump-like legs. It has dark, wary eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It stalks low to the ground, surrounded by pebbles that tremble and float near it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Beasts|Beasts]] · Beast |
| Variant of | [[Monsters/Beasts/Behemoth Calf\|Behemoth Calf]] (elder) |
| Rank · level | A+ · 159 (146–173) |
| Menace | 2 · Wild |
| Element · weakness | Earth · Wind |
| Size | 6.4 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 36830 · 775 · 646 · 517 · 581 · 100 |
| XP · gold | 9993 · 1815 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Frostveil\|Frostveil]], [[Regions/Shen-Lu\|Shen-Lu]] |
| Genre | Classic Fantasy |
| Trope | The horned rabbit "rookie killer" and wolf packs of every isekai starter forest |

**Field note:** Weak to Wind. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 4.16 m high × 6.4 m long × 1.02 m wide; prefab scale 1.6.
- **Physics:** 6815.7 kg, gravity ×1.32, poise 155, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 8.56 m/s, turn 126°/s, stopping distance 1.68 m.
- **Attack count:** 5; **signature:** a stone-plated back and stump-like legs.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rending Bite\|Rending Bite]] | melee | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Elder Behemoth Calf is a **wild beast** encountered at A+ rank, around level 159. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a stone-plated back and stump-like legs. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Frostveil|Frostveil]], [[Regions/Shen-Lu|Shen-Lu]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Beasts A|loot_beast_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Pelt\|Pelt]] | 60% | 1–3 |
| [[Items/Fang\|Fang]] | 30% | 1–1 |
| [[Items/Prime Meat\|Prime Meat]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Frostveil\|Frostveil]] | 5 | A-, A+, S+, S-, A | 132–203 | Day & Night |
| [[Regions/Shen-Lu\|Shen-Lu]] | 6 | A, A+, S-, A-, S+ | 132–203 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03368` | Frostveil Elder Behemoth Calf Runt | [[Regions/Frostveil\|Frostveil]] | Runt | A- | 132 | 4.48 m | Day & Night | Like a typical Elder Behemoth Calf, but smaller and scrappier than usual, with a thick, frost-rimed coat. |
| `pop_03369` | Frostveil Elder Behemoth Calf | [[Regions/Frostveil\|Frostveil]] | Adult | A+ | 159 | 6.4 m | Day & Night | A typical adult Elder Behemoth Calf of this region, with a thick, frost-rimed coat. |
| `pop_03370` | Shen-Lu Elder Behemoth Calf Juvenile | [[Regions/Shen-Lu\|Shen-Lu]] | Juvenile | A | 146 | 5.44 m | Day & Night | Like a typical Elder Behemoth Calf, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_03371` | Shen-Lu Elder Behemoth Calf | [[Regions/Shen-Lu\|Shen-Lu]] | Adult | A+ | 159 | 6.4 m | Day & Night | A typical adult Elder Behemoth Calf of this region, with slate-grey coloring and hardened hide. |
| `pop_03372` | Shen-Lu Elder Behemoth Calf Albino | [[Regions/Shen-Lu\|Shen-Lu]] | Albino | S- | 173 | 6.4 m | Day & Night | Like a typical Elder Behemoth Calf, but a rare pale form with white skin or fur and red eyes. |
| `pop_03373` | Shen-Lu Elder Behemoth Calf Scarred | [[Regions/Shen-Lu\|Shen-Lu]] | Scarred | S- | 173 | 7.04 m | Day & Night | Like a typical Elder Behemoth Calf, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_03374` | Frostveil Elder Behemoth Calf Elderborn | [[Regions/Frostveil\|Frostveil]] | Elderborn | S+ | 203 | 8.64 m | Day & Night | Like a typical Elder Behemoth Calf, but old and wise, with greying features and a cautious hunting style, with a thick, frost-rimed coat. |
| `pop_03375` | Frostveil Elder Behemoth Calf Scarred | [[Regions/Frostveil\|Frostveil]] | Scarred | S- | 173 | 7.04 m | Day & Night | Like a typical Elder Behemoth Calf, but covered in old battle scars, with a thick, frost-rimed coat. |
| `pop_03376` | Frostveil Elder Behemoth Calf Juvenile | [[Regions/Frostveil\|Frostveil]] | Juvenile | A | 146 | 5.44 m | Day & Night | Like a typical Elder Behemoth Calf, but young, with brighter colors and unworn features, with a thick, frost-rimed coat. |
| `pop_03377` | Shen-Lu Elder Behemoth Calf Runt | [[Regions/Shen-Lu\|Shen-Lu]] | Runt | A- | 132 | 4.48 m | Day & Night | Like a typical Elder Behemoth Calf, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_03378` | Shen-Lu Elder Behemoth Calf Elderborn | [[Regions/Shen-Lu\|Shen-Lu]] | Elderborn | S+ | 203 | 8.64 m | Day & Night | Like a typical Elder Behemoth Calf, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `fur_groom` · VFX `rock_debris` · palette `#826d42` `#54442d` `#d1a15a` · real-animal silhouette with one fantasy exaggeration
