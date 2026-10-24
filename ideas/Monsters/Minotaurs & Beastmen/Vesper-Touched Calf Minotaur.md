---
type: monster
id: mon_vesper_touched_calf_minotaur
family: "Minotaurs & Beastmen"
rank: "C-"
tier: variant
tags: [monster, minotaurs-beastmen]
---
# Vesper-Touched Calf Minotaur

![[mon_vesper_touched_calf_minotaur_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vesper_touched_calf_minotaur_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Vesper-Touched Calf Minotaur is a person-sized creature with a massive hunched brute frame, about 2 m tall. Its hide is patchy and subtly wrong, as if assembled from memory, colored in arterial crimson and dried-blood brown. Look for stubby horns and a bronze nose ring. It has eyes set slightly too far apart. Battle-worn plates and trophies hang from its body. It glides without moving its legs, surrounded by a faint red mist that smells of iron. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Minotaurs & Beastmen|Minotaurs & Beastmen]] · Beastman |
| Variant of | [[Monsters/Minotaurs & Beastmen/Calf Minotaur\|Calf Minotaur]] (corrupted) |
| Rank · level | C- · 65 (56–76) |
| Menace | 4 · Dread |
| Element · weakness | Blood · Light |
| Size | 2 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 8447 · 270 · 405 · 162 · 270 · 70 |
| XP · gold | 2395 · 521 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/large_biped\|large_biped]] · `anim_large_biped` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] |
| Genre | Labyrinth Myth |
| Trope | The minotaur that appears where it shouldn't (DanMachi), Greek labyrinth myth |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/large_biped|large_biped]] (rigId); animation set `anim_large_biped`.
- **Dimensions:** 2 m high × 0.6 m long × 0.84 m wide; prefab scale 0.571.
- **Physics:** 158.4 kg, gravity ×1.3, poise 153, knockback resistance 0.84, death style `heavy_fall_dust`.
- **Navigation:** speed 4.98 m/s, turn 269°/s, stopping distance 0.8 m.
- **Attack count:** 5; **signature:** stubby horns and a bronze nose ring.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stomp\|Stomp]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Club Slam\|Club Slam]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grab and Throw\|Grab and Throw]] | grab | 2 | 14 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Horn Charge\|Horn Charge]] | dash | 1.8 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Blood Lance\|Blood Lance]] | magic | 1.5 | 10 s | Blood | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched Calf Minotaur is a **dread beastman** encountered at C- rank, around level 65. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** stubby horns and a bronze nose ring. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_large_biped`, animation set `anim_large_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Minotaurs & Beastmen C|loot_minotaur_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Horn\|Horn]] | 60% | 1–3 |
| [[Items/Labyrinth Bronze\|Labyrinth Bronze]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 6 | C-, C, D+, D, B- | 48–96 | Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 5 | D, C, B-, C-, D+ | 48–96 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04080` | Great Labyrinth (Floors 1-40) Vesper-Touched Calf Minotaur | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | C- | 65 | 2 m | Night | A typical adult Vesper-Touched Calf Minotaur of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_04081` | Great Labyrinth (Floors 41-90) Vesper-Touched Calf Minotaur Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | D | 48 | 1.4 m | Night | Like a typical Vesper-Touched Calf Minotaur, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_04082` | Great Labyrinth (Floors 1-40) Vesper-Touched Calf Minotaur Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | C | 76 | 2 m | Night | Like a typical Vesper-Touched Calf Minotaur, but a rare pale form with white skin or fur and red eyes. |
| `pop_04083` | Great Labyrinth (Floors 41-90) Vesper-Touched Calf Minotaur Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | C | 76 | 2.2 m | Night | Like a typical Vesper-Touched Calf Minotaur, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_04084` | Great Labyrinth (Floors 1-40) Vesper-Touched Calf Minotaur Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | D+ | 56 | 1.7 m | Night | Like a typical Vesper-Touched Calf Minotaur, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_04085` | Great Labyrinth (Floors 1-40) Vesper-Touched Calf Minotaur Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | C | 76 | 2.2 m | Night | Like a typical Vesper-Touched Calf Minotaur, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_04086` | Great Labyrinth (Floors 41-90) Vesper-Touched Calf Minotaur Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | B- | 96 | 2.7 m | Night | Like a typical Vesper-Touched Calf Minotaur, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_04087` | Great Labyrinth (Floors 41-90) Vesper-Touched Calf Minotaur | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Adult | C- | 65 | 2 m | Night | A typical adult Vesper-Touched Calf Minotaur of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_04088` | Great Labyrinth (Floors 1-40) Vesper-Touched Calf Minotaur Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | D | 48 | 1.4 m | Night | Like a typical Vesper-Touched Calf Minotaur, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_04089` | Great Labyrinth (Floors 1-40) Vesper-Touched Calf Minotaur Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | B- | 96 | 2.7 m | Night | Like a typical Vesper-Touched Calf Minotaur, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_04090` | Great Labyrinth (Floors 41-90) Vesper-Touched Calf Minotaur Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | D+ | 56 | 1.7 m | Night | Like a typical Vesper-Touched Calf Minotaur, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `short_hide` · VFX `blood_mist` · palette `#8b0000` `#d7263d` `#1a0505` · elongated, irregular silhouette; still-then-sudden timing
