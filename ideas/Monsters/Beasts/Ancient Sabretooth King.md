---
type: monster
id: mon_ancient_sabretooth_king
family: "Beasts"
rank: "S"
tier: variant
tags: [monster, beasts]
---
# Ancient Sabretooth King

![[mon_ancient_sabretooth_king_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ancient_sabretooth_king_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,718 tris · 1.652 × 4.8 × 3.224 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Ancient Sabretooth King is a large creature with a long-legged predatory quadruped build, about 4.8 m long. Its coat is rough, scarred and spiked, colored in pale blues and frost-white. Survivors describe two sabre fangs as long as swords. It has burning slit pupils. Its regal silhouette is crowned by a halo-like ring of aura. It charges without hesitation, surrounded by falling snow motes and frosted ground where it steps. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Beasts|Beasts]] · Beast |
| Variant of | [[Monsters/Beasts/Sabretooth King\|Sabretooth King]] (ancient) |
| Rank · level | S · 188 (173–203) |
| Menace | 3 · Menacing |
| Element · weakness | Ice · Fire |
| Size | 4.8 m |
| Behaviour | Skittish (skittish_flee) |
| HP · ATK · DEF · MATK · MDEF · SPD | 43271 · 914 · 762 · 610 · 686 · 100 |
| XP · gold | 13063 · 2293 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Quaking Lands\|Quaking Lands]], [[Regions/Shen-Lu\|Shen-Lu]] |
| Genre | Classic Fantasy |
| Trope | The horned rabbit "rookie killer" and wolf packs of every isekai starter forest |

**Field note:** Weak to Fire. Flees when hurt. Snares or ranged attacks work best.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 3.12 m high × 4.8 m long × 0.77 m wide; prefab scale 1.2.
- **Physics:** 2433 kg, gravity ×1.26, poise 146, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 9.34 m/s, turn 146°/s, stopping distance 1.36 m.
- **Attack count:** 5; **signature:** two sabre fangs as long as swords.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rending Bite\|Rending Bite]] | melee | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frost Breath\|Frost Breath]] | magic | 1.5 | 10 s | Ice | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Ancient Sabretooth King is a **menacing beast** encountered at S rank, around level 188. Its documented behaviour is *Skittish* and its AI pattern is *skittish_flee*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** two sabre fangs as long as swords. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Quaking Lands|Quaking Lands]], [[Regions/Shen-Lu|Shen-Lu]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Beasts S|loot_beast_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Pelt\|Pelt]] | 60% | 1–3 |
| [[Items/Fang\|Fang]] | 30% | 1–1 |
| [[Items/Prime Meat\|Prime Meat]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Shen-Lu\|Shen-Lu]] | 6 | A+, SS-, S+, S-, SS | 159–236 | Day & Night |
| [[Regions/Quaking Lands\|Quaking Lands]] | 5 | S+, SS, A+, S, S- | 159–236 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03379` | Shen-Lu Ancient Sabretooth King Runt | [[Regions/Shen-Lu\|Shen-Lu]] | Runt | A+ | 159 | 3.36 m | Day & Night | Like a typical Ancient Sabretooth King, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_03380` | Quaking Lands Ancient Sabretooth King Scarred | [[Regions/Quaking Lands\|Quaking Lands]] | Scarred | S+ | 203 | 5.28 m | Day & Night | Like a typical Ancient Sabretooth King, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_03381` | Quaking Lands Ancient Sabretooth King Elderborn | [[Regions/Quaking Lands\|Quaking Lands]] | Elderborn | SS | 236 | 6.48 m | Day & Night | Like a typical Ancient Sabretooth King, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_03382` | Shen-Lu Ancient Sabretooth King Alpha | [[Regions/Shen-Lu\|Shen-Lu]] | Alpha | SS- | 218 | 6 m | Day & Night | Like a typical Ancient Sabretooth King, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_03383` | Shen-Lu Ancient Sabretooth King Albino | [[Regions/Shen-Lu\|Shen-Lu]] | Albino | S+ | 203 | 4.8 m | Day & Night | Like a typical Ancient Sabretooth King, but a rare pale form with white skin or fur and red eyes. |
| `pop_03384` | Shen-Lu Ancient Sabretooth King Juvenile | [[Regions/Shen-Lu\|Shen-Lu]] | Juvenile | S- | 173 | 4.08 m | Day & Night | Like a typical Ancient Sabretooth King, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_03385` | Quaking Lands Ancient Sabretooth King Runt | [[Regions/Quaking Lands\|Quaking Lands]] | Runt | A+ | 159 | 3.36 m | Day & Night | Like a typical Ancient Sabretooth King, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_03386` | Quaking Lands Ancient Sabretooth King | [[Regions/Quaking Lands\|Quaking Lands]] | Adult | S | 188 | 4.8 m | Day & Night | A typical adult Ancient Sabretooth King of this region, with slate-grey coloring and hardened hide. |
| `pop_03387` | Shen-Lu Ancient Sabretooth King Scarred | [[Regions/Shen-Lu\|Shen-Lu]] | Scarred | S+ | 203 | 5.28 m | Day & Night | Like a typical Ancient Sabretooth King, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_03388` | Quaking Lands Ancient Sabretooth King Juvenile | [[Regions/Quaking Lands\|Quaking Lands]] | Juvenile | S- | 173 | 4.08 m | Day & Night | Like a typical Ancient Sabretooth King, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_03389` | Shen-Lu Ancient Sabretooth King Elderborn | [[Regions/Shen-Lu\|Shen-Lu]] | Elderborn | SS | 236 | 6.48 m | Day & Night | Like a typical Ancient Sabretooth King, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `fur_groom` · VFX `frost_trail_snow` · palette `#bfe9ff` `#5fa8d3` `#f4fbff` · triangle-based silhouette, sharp asymmetric spikes
