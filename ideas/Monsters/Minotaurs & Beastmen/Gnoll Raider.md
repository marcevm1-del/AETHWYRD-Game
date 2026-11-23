---
type: monster
id: mon_gnoll_raider
family: "Minotaurs & Beastmen"
rank: "D"
tier: core
tags: [monster, minotaurs-beastmen]
---
# Gnoll Raider

![[mon_gnoll_raider_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_gnoll_raider_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 1.15 × 2.261 × 2 m · local file `Game/Assets/_Game/Art/Models/Monsters/Minotaurs & Beastmen/mon_gnoll_raider.fbx`

> The Gnoll Raider is a person-sized creature with a broad-shouldered humanoid build, about 2 m tall. Its hide is rough, scarred and spiked, colored in tan. Guild sketches always show a hyena head and a laugh that carries for miles. It has eyes that catch torchlight like coins. A distinctive marking runs along its back. It strides with heavy steps. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Minotaurs & Beastmen|Minotaurs & Beastmen]] · Beastman |
| Rank · level | D · 48 (40–56) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 2 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 4242 · 242 · 202 · 113 · 182 · 100 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Iron Hold\|Iron Hold]], [[Regions/Umbravel\|Umbravel]], [[Regions/Aldmere\|Aldmere]] |
| Genre | Labyrinth Myth |
| Trope | The minotaur that appears where it shouldn't (DanMachi), Greek labyrinth myth |

**Field note:** Weak to Fire. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2 m high × 0.6 m long × 0.64 m wide; prefab scale 1.111.
- **Physics:** 104 kg, gravity ×1.5, poise 69, knockback resistance 0.36, death style `ragdoll`.
- **Navigation:** speed 5.72 m/s, turn 283°/s, stopping distance 0.74 m.
- **Attack count:** 4; **signature:** a hyena head and a laugh that carries for miles.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Horn Charge\|Horn Charge]] | dash | 1.8 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Gnoll Raider is a **menacing beastman** encountered at D rank, around level 48. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a hyena head and a laugh that carries for miles. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Iron Hold|Iron Hold]], [[Regions/Umbravel|Umbravel]], [[Regions/Aldmere|Aldmere]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Minotaurs & Beastmen D|loot_minotaur_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Horn\|Horn]] | 60% | 1–3 |
| [[Items/Labyrinth Bronze\|Labyrinth Bronze]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Minotaurs & Beastmen/Cavern Gnoll Raider|Cavern Gnoll Raider]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 4 | D+, D, E+, C | 32–76 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 2 | D+, C- | 56–65 | Day & Night |
| [[Regions/Umbravel\|Umbravel]] | 3 | D+, D-, E+ | 32–56 | Day & Night |
| [[Regions/Iron Hold\|Iron Hold]] | 2 | D-, C | 40–76 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01212` | Great Labyrinth (Floors 1-40) Gnoll Raider Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | D+ | 56 | 2.2 m | Day & Night | Like a typical Gnoll Raider, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_01213` | Aldmere Gnoll Raider Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | D+ | 56 | 2.2 m | Day & Night | Like a typical Gnoll Raider, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_01214` | Umbravel Gnoll Raider Albino | [[Regions/Umbravel\|Umbravel]] | Albino | D+ | 56 | 2 m | Day & Night | Like a typical Gnoll Raider, but a rare pale form with white skin or fur and red eyes. |
| `pop_01215` | Great Labyrinth (Floors 1-40) Gnoll Raider | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | D | 48 | 2 m | Day & Night | A typical adult Gnoll Raider of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_01216` | Great Labyrinth (Floors 1-40) Gnoll Raider Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | E+ | 32 | 1.4 m | Day & Night | Like a typical Gnoll Raider, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_01217` | Iron Hold Gnoll Raider Juvenile | [[Regions/Iron Hold\|Iron Hold]] | Juvenile | D- | 40 | 1.7 m | Day & Night | Like a typical Gnoll Raider, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_01218` | Aldmere Gnoll Raider Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | C- | 65 | 2.5 m | Day & Night | Like a typical Gnoll Raider, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_01219` | Umbravel Gnoll Raider Juvenile | [[Regions/Umbravel\|Umbravel]] | Juvenile | D- | 40 | 1.7 m | Day & Night | Like a typical Gnoll Raider, but young, with brighter colors and unworn features, with bioluminescent spots along its body. |
| `pop_01220` | Great Labyrinth (Floors 1-40) Gnoll Raider Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | C | 76 | 2.7 m | Day & Night | Like a typical Gnoll Raider, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_01221` | Umbravel Gnoll Raider Runt | [[Regions/Umbravel\|Umbravel]] | Runt | E+ | 32 | 1.4 m | Day & Night | Like a typical Gnoll Raider, but smaller and scrappier than usual, with bioluminescent spots along its body. |
| `pop_01222` | Iron Hold Gnoll Raider Elderborn | [[Regions/Iron Hold\|Iron Hold]] | Elderborn | C | 76 | 2.7 m | Day & Night | Like a typical Gnoll Raider, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `short_hide` · VFX `dust_puffs` · palette `#8c644a` `#5e4232` `#cb9a6b` · triangle-based silhouette, sharp asymmetric spikes
