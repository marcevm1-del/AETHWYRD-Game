---
type: monster
id: mon_night_sabretooth_king
family: "Beasts"
rank: "A+"
tier: variant
tags: [monster, beasts]
---
# Night Sabretooth King

![[mon_night_sabretooth_king_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_night_sabretooth_king_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Night Sabretooth King is a large creature with a heavy, muscular quadruped frame, about 3.2 m long. Its coat is rough, scarred and spiked, colored in ink black with bruised violet. Its most striking feature is two sabre fangs as long as swords. It has eyes that catch torchlight like coins. An elegant crest and glowing veins of mana mark it as a champion of its kind. It circles its prey, surrounded by shadows that lean toward it. This Dark-attuned variant carries one extra elemental feature, like element-scarred hide, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Beasts|Beasts]] · Beast |
| Variant of | [[Monsters/Beasts/Sabretooth King\|Sabretooth King]] (elemental) |
| Rank · level | A+ · 159 (146–173) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 3.2 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 29507 · 775 · 646 · 517 · 581 · 100 |
| XP · gold | 9993 · 1815 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Iron Hold\|Iron Hold]] |
| Genre | Classic Fantasy |
| Trope | The horned rabbit "rookie killer" and wolf packs of every isekai starter forest |

**Field note:** Weak to Light. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 2.08 m high × 3.2 m long × 0.51 m wide; prefab scale 0.8.
- **Physics:** 655.4 kg, gravity ×1.2, poise 110, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 7.61 m/s, turn 179°/s, stopping distance 1.04 m.
- **Attack count:** 5; **signature:** two sabre fangs as long as swords.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rending Bite\|Rending Bite]] | melee | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Night Sabretooth King is a **menacing beast** encountered at A+ rank, around level 159. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** two sabre fangs as long as swords. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Iron Hold|Iron Hold]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Moraveil\|Moraveil]] | 6 | S, S+, S-, A-, A+ | 132–203 | Day & Night |
| [[Regions/Iron Hold\|Iron Hold]] | 5 | S-, S, A+, A, A- | 132–188 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06220` | Moraveil Night Sabretooth King Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | S | 188 | 4 m | Day & Night | Like a typical Night Sabretooth King, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_06221` | Moraveil Night Sabretooth King Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | S+ | 203 | 4.32 m | Day & Night | Like a typical Night Sabretooth King, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_06222` | Moraveil Night Sabretooth King Albino | [[Regions/Moraveil\|Moraveil]] | Albino | S- | 173 | 3.2 m | Day & Night | Like a typical Night Sabretooth King, but a rare pale form with white skin or fur and red eyes. |
| `pop_06223` | Iron Hold Night Sabretooth King Albino | [[Regions/Iron Hold\|Iron Hold]] | Albino | S- | 173 | 3.2 m | Day & Night | Like a typical Night Sabretooth King, but a rare pale form with white skin or fur and red eyes. |
| `pop_06224` | Iron Hold Night Sabretooth King Alpha | [[Regions/Iron Hold\|Iron Hold]] | Alpha | S | 188 | 4 m | Day & Night | Like a typical Night Sabretooth King, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_06225` | Moraveil Night Sabretooth King Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | S- | 173 | 3.52 m | Day & Night | Like a typical Night Sabretooth King, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_06226` | Iron Hold Night Sabretooth King | [[Regions/Iron Hold\|Iron Hold]] | Adult | A+ | 159 | 3.2 m | Day & Night | A typical adult Night Sabretooth King of this region, with slate-grey coloring and hardened hide. |
| `pop_06227` | Iron Hold Night Sabretooth King Juvenile | [[Regions/Iron Hold\|Iron Hold]] | Juvenile | A | 146 | 2.72 m | Day & Night | Like a typical Night Sabretooth King, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_06228` | Moraveil Night Sabretooth King Runt | [[Regions/Moraveil\|Moraveil]] | Runt | A- | 132 | 2.24 m | Day & Night | Like a typical Night Sabretooth King, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_06229` | Iron Hold Night Sabretooth King Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | A- | 132 | 2.24 m | Day & Night | Like a typical Night Sabretooth King, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_06230` | Moraveil Night Sabretooth King | [[Regions/Moraveil\|Moraveil]] | Adult | A+ | 159 | 3.2 m | Day & Night | A typical adult Night Sabretooth King of this region, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `fur_groom` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · triangle-based silhouette, sharp asymmetric spikes
