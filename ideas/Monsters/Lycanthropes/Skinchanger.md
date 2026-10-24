---
type: monster
id: mon_skinchanger
family: "Lycanthropes"
rank: "B+"
tier: core
tags: [monster, lycanthropes]
---
# Skinchanger

![[mon_skinchanger_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_skinchanger_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,806 tris · 1.318 × 1.619 × 2.4 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Skinchanger is a person-sized creature with a broad-shouldered humanoid build, about 2.4 m tall. Its fur is stretched, stitched and constantly shifting, colored in ink black with bruised violet. Its most striking feature is half its body stuck mid-transformation, forever. It has too many eyes, opening one after another. Faint runes glow along its body when it fights. It unfolds into something larger, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Lycanthropes|Lycanthropes]] · Cursed Beast |
| Rank · level | B+ · 120 (108–132) |
| Menace | 5 · Horror |
| Element · weakness | Dark · Light |
| Size | 2.4 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 17586 · 588 · 490 · 392 · 441 · 100 |
| XP · gold | 6373 · 1225 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Strife Marches\|Strife Marches]], [[Regions/Moraveil\|Moraveil]], [[Regions/Iron Hold\|Iron Hold]], [[Regions/Shen-Lu\|Shen-Lu]] |
| Genre | Gothic Horror |
| Trope | Moon-cursed transformation horror |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2.4 m high × 0.72 m long × 0.77 m wide; prefab scale 1.333.
- **Physics:** 179.7 kg, gravity ×1.5, poise 92, knockback resistance 0.42, death style `ragdoll`.
- **Navigation:** speed 6.58 m/s, turn 258°/s, stopping distance 0.81 m.
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

Skinchanger is a **horror cursed beast** encountered at B+ rank, around level 120. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** half its body stuck mid-transformation, forever. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Strife Marches|Strife Marches]], [[Regions/Moraveil|Moraveil]], [[Regions/Iron Hold|Iron Hold]], [[Regions/Shen-Lu|Shen-Lu]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Lycanthropes B|loot_lycan_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Cursed Fur\|Cursed Fur]] | 60% | 1–3 |
| [[Items/Silver-Bane Claw\|Silver-Bane Claw]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Lycanthropes/Elder Skinchanger|Elder Skinchanger]]
- [[Monsters/Lycanthropes/Blight Skinchanger|Blight Skinchanger]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Iron Hold\|Iron Hold]] | 1 | B- | 96–96 | Night |
| [[Regions/Shen-Lu\|Shen-Lu]] | 4 | B-, A-, A, B+ | 96–146 | Night |
| [[Regions/Moraveil\|Moraveil]] | 5 | A-, B-, B, B+ | 96–132 | Night |
| [[Regions/Strife Marches\|Strife Marches]] | 1 | B | 108–108 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00586` | Iron Hold Skinchanger Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | B- | 96 | 1.68 m | Night | Like a typical Skinchanger, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_00587` | Shen-Lu Skinchanger Runt | [[Regions/Shen-Lu\|Shen-Lu]] | Runt | B- | 96 | 1.68 m | Night | Like a typical Skinchanger, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_00588` | Moraveil Skinchanger Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | A- | 132 | 2.64 m | Night | Like a typical Skinchanger, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_00589` | Shen-Lu Skinchanger Albino | [[Regions/Shen-Lu\|Shen-Lu]] | Albino | A- | 132 | 2.4 m | Night | Like a typical Skinchanger, but a rare pale form with white skin or fur and red eyes. |
| `pop_00590` | Moraveil Skinchanger Runt | [[Regions/Moraveil\|Moraveil]] | Runt | B- | 96 | 1.68 m | Night | Like a typical Skinchanger, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_00591` | Moraveil Skinchanger Albino | [[Regions/Moraveil\|Moraveil]] | Albino | A- | 132 | 2.4 m | Night | Like a typical Skinchanger, but a rare pale form with white skin or fur and red eyes. |
| `pop_00592` | Shen-Lu Skinchanger Alpha | [[Regions/Shen-Lu\|Shen-Lu]] | Alpha | A | 146 | 3 m | Night | Like a typical Skinchanger, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_00593` | Moraveil Skinchanger Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | B | 108 | 2.04 m | Night | Like a typical Skinchanger, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_00594` | Shen-Lu Skinchanger | [[Regions/Shen-Lu\|Shen-Lu]] | Adult | B+ | 120 | 2.4 m | Night | A typical adult Skinchanger of this region, with slate-grey coloring and hardened hide. |
| `pop_00595` | Strife Marches Skinchanger Juvenile | [[Regions/Strife Marches\|Strife Marches]] | Juvenile | B | 108 | 2.04 m | Night | Like a typical Skinchanger, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_00596` | Moraveil Skinchanger | [[Regions/Moraveil\|Moraveil]] | Adult | B+ | 120 | 2.4 m | Night | A typical adult Skinchanger of this region, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `fur_rough` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · broken symmetry, mimicry, audio-first reveal
