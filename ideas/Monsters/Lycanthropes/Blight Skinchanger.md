---
type: monster
id: mon_blight_skinchanger
family: "Lycanthropes"
rank: "A-"
tier: variant
tags: [monster, lycanthropes]
---
# Blight Skinchanger

![[mon_blight_skinchanger_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_blight_skinchanger_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,206 tris · 1.275 × 1.619 × 2.4 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Blight Skinchanger is a person-sized creature with an upright humanoid build, about 2.4 m tall. Its fur is stretched, stitched and constantly shifting, colored in bruise purple with sickly green. Look for half its body stuck mid-transformation, forever. It has no eyes at all, only a wide and patient mouth. An elegant crest and glowing veins of mana mark it as a champion of its kind. It crawls across ceilings, surrounded by a low toxic haze that clings to the ground. This Poison-attuned variant carries one extra elemental feature, like a crest of elemental energy, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Lycanthropes|Lycanthropes]] · Cursed Beast |
| Variant of | [[Monsters/Lycanthropes/Skinchanger\|Skinchanger]] (elemental) |
| Rank · level | A- · 132 (120–146) |
| Menace | 5 · Horror |
| Element · weakness | Poison · Light |
| Size | 2.4 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 20275 · 646 · 538 · 430 · 484 · 100 |
| XP · gold | 7422 · 1399 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Iron Hold\|Iron Hold]], [[Regions/Moraveil\|Moraveil]], [[Regions/Shen-Lu\|Shen-Lu]] |
| Genre | Gothic Horror |
| Trope | Moon-cursed transformation horror |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2.4 m high × 0.72 m long × 0.77 m wide; prefab scale 1.333.
- **Physics:** 179.7 kg, gravity ×1.5, poise 101, knockback resistance 0.45, death style `ragdoll`.
- **Navigation:** speed 6.08 m/s, turn 258°/s, stopping distance 0.81 m.
- **Attack count:** 5; **signature:** half its body stuck mid-transformation, forever.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Moon Frenzy\|Moon Frenzy]] | buff | 0 | 20 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Blight Skinchanger is a **horror cursed beast** encountered at A- rank, around level 132. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** half its body stuck mid-transformation, forever. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Iron Hold|Iron Hold]], [[Regions/Moraveil|Moraveil]], [[Regions/Shen-Lu|Shen-Lu]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Shen-Lu\|Shen-Lu]] | 2 | S-, B | 108–173 | Night |
| [[Regions/Moraveil\|Moraveil]] | 5 | A+, B, A, A-, S- | 108–173 | Night |
| [[Regions/Iron Hold\|Iron Hold]] | 4 | A+, B, B+, A | 108–159 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06330` | Shen-Lu Blight Skinchanger Elderborn | [[Regions/Shen-Lu\|Shen-Lu]] | Elderborn | S- | 173 | 3.24 m | Night | Like a typical Blight Skinchanger, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_06331` | Moraveil Blight Skinchanger Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | A+ | 159 | 3 m | Night | Like a typical Blight Skinchanger, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_06332` | Iron Hold Blight Skinchanger Alpha | [[Regions/Iron Hold\|Iron Hold]] | Alpha | A+ | 159 | 3 m | Night | Like a typical Blight Skinchanger, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_06333` | Shen-Lu Blight Skinchanger Runt | [[Regions/Shen-Lu\|Shen-Lu]] | Runt | B | 108 | 1.68 m | Night | Like a typical Blight Skinchanger, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_06334` | Moraveil Blight Skinchanger Runt | [[Regions/Moraveil\|Moraveil]] | Runt | B | 108 | 1.68 m | Night | Like a typical Blight Skinchanger, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_06335` | Iron Hold Blight Skinchanger Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | B | 108 | 1.68 m | Night | Like a typical Blight Skinchanger, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_06336` | Iron Hold Blight Skinchanger Juvenile | [[Regions/Iron Hold\|Iron Hold]] | Juvenile | B+ | 120 | 2.04 m | Night | Like a typical Blight Skinchanger, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_06337` | Moraveil Blight Skinchanger Albino | [[Regions/Moraveil\|Moraveil]] | Albino | A | 146 | 2.4 m | Night | Like a typical Blight Skinchanger, but a rare pale form with white skin or fur and red eyes. |
| `pop_06338` | Moraveil Blight Skinchanger | [[Regions/Moraveil\|Moraveil]] | Adult | A- | 132 | 2.4 m | Night | A typical adult Blight Skinchanger of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_06339` | Iron Hold Blight Skinchanger Scarred | [[Regions/Iron Hold\|Iron Hold]] | Scarred | A | 146 | 2.64 m | Night | Like a typical Blight Skinchanger, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_06340` | Moraveil Blight Skinchanger Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | S- | 173 | 3.24 m | Night | Like a typical Blight Skinchanger, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `fur_rough` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · broken symmetry, mimicry, audio-first reveal
