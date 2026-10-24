---
type: monster
id: mon_satyr_reveler
family: "Minotaurs & Beastmen"
rank: "D"
tier: core
tags: [monster, minotaurs-beastmen]
---
# Satyr Reveler

![[mon_satyr_reveler_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_satyr_reveler_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Satyr Reveler is a person-sized creature with a broad-shouldered humanoid build, about 1.7 m tall. Its hide is weathered and natural, colored in leaf greens over bark brown. Look for goat legs and a panpipe that makes you dance. It has alert animal eyes. A distinctive marking runs along its back. It lopes in long strides, surrounded by drifting pollen and tiny blossoms.

| Field | Value |
|---|---|
| Family · type | [[Families/Minotaurs & Beastmen|Minotaurs & Beastmen]] · Beastman |
| Rank · level | D · 48 (40–56) |
| Menace | 2 · Wild |
| Element · weakness | Nature · Fire |
| Size | 1.7 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 4013 · 242 · 202 · 162 · 182 · 100 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Hoshizora\|Hoshizora]], [[Regions/Aldmere\|Aldmere]], [[Regions/Moraveil\|Moraveil]] |
| Genre | Labyrinth Myth |
| Trope | The minotaur that appears where it shouldn't (DanMachi), Greek labyrinth myth |

**Field note:** Weak to Fire. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 1.7 m high × 0.51 m long × 0.54 m wide; prefab scale 0.944.
- **Physics:** 63.9 kg, gravity ×1.5, poise 63, knockback resistance 0.36, death style `ragdoll`.
- **Navigation:** speed 5.02 m/s, turn 307°/s, stopping distance 0.69 m.
- **Attack count:** 5; **signature:** goat legs and a panpipe that makes you dance.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Horn Charge\|Horn Charge]] | dash | 1.8 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Thorn Volley\|Thorn Volley]] | magic | 1.5 | 10 s | Nature | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Satyr Reveler is a **wild beastman** encountered at D rank, around level 48. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** goat legs and a panpipe that makes you dance. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Hoshizora|Hoshizora]], [[Regions/Aldmere|Aldmere]], [[Regions/Moraveil|Moraveil]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Minotaurs & Beastmen D|loot_minotaur_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Horn\|Horn]] | 60% | 1–3 |
| [[Items/Labyrinth Bronze\|Labyrinth Bronze]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Minotaurs & Beastmen/Ash Satyr Reveler|Ash Satyr Reveler]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Hoshizora\|Hoshizora]] | 5 | D+, E+, D-, C, D | 32–76 | Day & Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 2 | C, E+ | 32–76 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 2 | D-, C- | 40–65 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 2 | E+, D- | 32–40 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01201` | Hoshizora Satyr Reveler Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | D+ | 56 | 1.87 m | Day & Night | Like a typical Satyr Reveler, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_01202` | Hoshizora Satyr Reveler Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | E+ | 32 | 1.19 m | Day & Night | Like a typical Satyr Reveler, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_01203` | Great Labyrinth (Floors 1-40) Satyr Reveler Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | C | 76 | 2.29 m | Day & Night | Like a typical Satyr Reveler, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_01204` | Aldmere Satyr Reveler Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | D- | 40 | 1.44 m | Day & Night | Like a typical Satyr Reveler, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_01205` | Hoshizora Satyr Reveler Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | D- | 40 | 1.44 m | Day & Night | Like a typical Satyr Reveler, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_01206` | Great Labyrinth (Floors 1-40) Satyr Reveler Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | E+ | 32 | 1.19 m | Day & Night | Like a typical Satyr Reveler, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_01207` | Aldmere Satyr Reveler Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | C- | 65 | 2.13 m | Day & Night | Like a typical Satyr Reveler, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_01208` | Moraveil Satyr Reveler Runt | [[Regions/Moraveil\|Moraveil]] | Runt | E+ | 32 | 1.19 m | Day & Night | Like a typical Satyr Reveler, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_01209` | Hoshizora Satyr Reveler Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | C | 76 | 2.29 m | Day & Night | Like a typical Satyr Reveler, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_01210` | Hoshizora Satyr Reveler | [[Regions/Hoshizora\|Hoshizora]] | Adult | D | 48 | 1.7 m | Day & Night | A typical adult Satyr Reveler of this region, with slate-grey coloring and hardened hide. |
| `pop_01211` | Moraveil Satyr Reveler Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | D- | 40 | 1.44 m | Day & Night | Like a typical Satyr Reveler, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `short_hide` · VFX `pollen_petals` · palette `#4caf50` `#a5d66f` `#3e2723` · real-animal silhouette with one fantasy exaggeration
