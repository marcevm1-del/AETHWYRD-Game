---
type: monster
id: mon_elder_skinchanger
family: "Lycanthropes"
rank: "A+"
tier: variant
tags: [monster, lycanthropes]
---
# Elder Skinchanger

![[mon_elder_skinchanger_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_elder_skinchanger_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,072 tris · 2.086 × 1.96 × 3.8 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Elder Skinchanger is a large creature with a broad-shouldered humanoid build, about 3.8 m tall. Its fur is stretched, stitched and constantly shifting, colored in ink black with bruised violet. Guild sketches always show half its body stuck mid-transformation, forever. It has no eyes at all, only a wide and patient mouth. An elegant crest and glowing veins of mana mark it as a champion of its kind. It unfolds into something larger, surrounded by shadows that lean toward it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Lycanthropes|Lycanthropes]] · Cursed Beast |
| Variant of | [[Monsters/Lycanthropes/Skinchanger\|Skinchanger]] (elder) |
| Rank · level | A+ · 159 (146–173) |
| Menace | 5 · Horror |
| Element · weakness | Dark · Light |
| Size | 3.8 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 31233 · 775 · 646 · 517 · 581 · 100 |
| XP · gold | 9993 · 1815 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Iron Hold\|Iron Hold]], [[Regions/Shen-Lu\|Shen-Lu]] |
| Genre | Gothic Horror |
| Trope | Moon-cursed transformation horror |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 3.8 m high × 1.14 m long × 1.22 m wide; prefab scale 2.111.
- **Physics:** 713.3 kg, gravity ×1.5, poise 127, knockback resistance 0.45, death style `ragdoll`.
- **Navigation:** speed 8.28 m/s, turn 205°/s, stopping distance 1.05 m.
- **Attack count:** 5; **signature:** half its body stuck mid-transformation, forever.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Moon Frenzy\|Moon Frenzy]] | buff | 0 | 20 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Elder Skinchanger is a **horror cursed beast** encountered at A+ rank, around level 159. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** half its body stuck mid-transformation, forever. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Iron Hold|Iron Hold]], [[Regions/Shen-Lu|Shen-Lu]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Lycanthropes A|loot_lycan_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Cursed Fur\|Cursed Fur]] | 60% | 1–3 |
| [[Items/Silver-Bane Claw\|Silver-Bane Claw]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Iron Hold\|Iron Hold]] | 4 | S-, A-, S+, A | 132–203 | Night |
| [[Regions/Shen-Lu\|Shen-Lu]] | 5 | S, A, S+, A-, S- | 132–203 | Night |
| [[Regions/Moraveil\|Moraveil]] | 2 | S-, S+ | 173–203 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03485` | Iron Hold Elder Skinchanger Scarred | [[Regions/Iron Hold\|Iron Hold]] | Scarred | S- | 173 | 4.18 m | Night | Like a typical Elder Skinchanger, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_03486` | Shen-Lu Elder Skinchanger Alpha | [[Regions/Shen-Lu\|Shen-Lu]] | Alpha | S | 188 | 4.75 m | Night | Like a typical Elder Skinchanger, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_03487` | Moraveil Elder Skinchanger Albino | [[Regions/Moraveil\|Moraveil]] | Albino | S- | 173 | 3.8 m | Night | Like a typical Elder Skinchanger, but a rare pale form with white skin or fur and red eyes. |
| `pop_03488` | Iron Hold Elder Skinchanger Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | A- | 132 | 2.66 m | Night | Like a typical Elder Skinchanger, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_03489` | Shen-Lu Elder Skinchanger Juvenile | [[Regions/Shen-Lu\|Shen-Lu]] | Juvenile | A | 146 | 3.23 m | Night | Like a typical Elder Skinchanger, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_03490` | Shen-Lu Elder Skinchanger Elderborn | [[Regions/Shen-Lu\|Shen-Lu]] | Elderborn | S+ | 203 | 5.13 m | Night | Like a typical Elder Skinchanger, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_03491` | Shen-Lu Elder Skinchanger Runt | [[Regions/Shen-Lu\|Shen-Lu]] | Runt | A- | 132 | 2.66 m | Night | Like a typical Elder Skinchanger, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_03492` | Iron Hold Elder Skinchanger Elderborn | [[Regions/Iron Hold\|Iron Hold]] | Elderborn | S+ | 203 | 5.13 m | Night | Like a typical Elder Skinchanger, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_03493` | Shen-Lu Elder Skinchanger Albino | [[Regions/Shen-Lu\|Shen-Lu]] | Albino | S- | 173 | 3.8 m | Night | Like a typical Elder Skinchanger, but a rare pale form with white skin or fur and red eyes. |
| `pop_03494` | Moraveil Elder Skinchanger Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | S+ | 203 | 5.13 m | Night | Like a typical Elder Skinchanger, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_03495` | Iron Hold Elder Skinchanger Juvenile | [[Regions/Iron Hold\|Iron Hold]] | Juvenile | A | 146 | 3.23 m | Night | Like a typical Elder Skinchanger, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `fur_rough` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · broken symmetry, mimicry, audio-first reveal
