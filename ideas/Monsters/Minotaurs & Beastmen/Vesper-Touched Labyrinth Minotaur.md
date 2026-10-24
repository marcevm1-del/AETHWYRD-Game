---
type: monster
id: mon_vesper_touched_labyrinth_minotaur
family: "Minotaurs & Beastmen"
rank: "A-"
tier: variant
tags: [monster, minotaurs-beastmen]
---
# Vesper-Touched Labyrinth Minotaur

![[mon_vesper_touched_labyrinth_minotaur_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vesper_touched_labyrinth_minotaur_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Vesper-Touched Labyrinth Minotaur is a large creature with a towering, heavy-limbed body, about 4 m tall. Its hide is patchy and subtly wrong, as if assembled from memory, colored in ochre, clay and mossy stone. Survivors describe horns carved with maze runes. It has pale, pupil-less eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It freezes whenever it is looked at, surrounded by pebbles that tremble and float near it. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Minotaurs & Beastmen|Minotaurs & Beastmen]] · Beastman |
| Variant of | [[Monsters/Minotaurs & Beastmen/Labyrinth Minotaur\|Labyrinth Minotaur]] (corrupted) |
| Rank · level | A- · 132 (120–146) |
| Menace | 4 · Dread |
| Element · weakness | Earth · Wind |
| Size | 4 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 30610 · 538 · 807 · 323 · 538 · 70 |
| XP · gold | 7422 · 1399 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/large_biped\|large_biped]] · `anim_large_biped` |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Iron Hold\|Iron Hold]], [[Regions/The Maw\|The Maw]] |
| Genre | Labyrinth Myth |
| Trope | The minotaur that appears where it shouldn't (DanMachi), Greek labyrinth myth |

**Field note:** Weak to Wind. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/large_biped|large_biped]] (rigId); animation set `anim_large_biped`.
- **Dimensions:** 4 m high × 1.2 m long × 1.68 m wide; prefab scale 1.143.
- **Physics:** 1497.6 kg, gravity ×1.43, poise 262, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 6.48 m/s, turn 190°/s, stopping distance 1.2 m.
- **Attack count:** 5; **signature:** horns carved with maze runes.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stomp\|Stomp]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Club Slam\|Club Slam]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grab and Throw\|Grab and Throw]] | grab | 2 | 14 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Horn Charge\|Horn Charge]] | dash | 1.8 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched Labyrinth Minotaur is a **dread beastman** encountered at A- rank, around level 132. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** horns carved with maze runes. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Iron Hold|Iron Hold]], [[Regions/The Maw|The Maw]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_large_biped`, animation set `anim_large_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Minotaurs & Beastmen A|loot_minotaur_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Horn\|Horn]] | 60% | 1–3 |
| [[Items/Labyrinth Bronze\|Labyrinth Bronze]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/The Maw\|The Maw]] | 4 | B, S-, A, A- | 108–173 | Night |
| [[Regions/Iron Hold\|Iron Hold]] | 2 | A+, S- | 159–173 | Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 5 | A, A-, S-, A+ | 132–173 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04124` | The Maw Vesper-Touched Labyrinth Minotaur Runt | [[Regions/The Maw\|The Maw]] | Runt | B | 108 | 2.8 m | Night | Like a typical Vesper-Touched Labyrinth Minotaur, but smaller and scrappier than usual, with bioluminescent spots along its body. |
| `pop_04125` | Iron Hold Vesper-Touched Labyrinth Minotaur Alpha | [[Regions/Iron Hold\|Iron Hold]] | Alpha | A+ | 159 | 5 m | Night | Like a typical Vesper-Touched Labyrinth Minotaur, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_04126` | Great Labyrinth (Floors 41-90) Vesper-Touched Labyrinth Minotaur Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | A | 146 | 4.4 m | Night | Like a typical Vesper-Touched Labyrinth Minotaur, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_04127` | Great Labyrinth (Floors 41-90) Vesper-Touched Labyrinth Minotaur Albino | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Albino | A | 146 | 4 m | Night | Like a typical Vesper-Touched Labyrinth Minotaur, but a rare pale form with white skin or fur and red eyes. |
| `pop_04128` | The Maw Vesper-Touched Labyrinth Minotaur Elderborn | [[Regions/The Maw\|The Maw]] | Elderborn | S- | 173 | 5.4 m | Night | Like a typical Vesper-Touched Labyrinth Minotaur, but old and wise, with greying features and a cautious hunting style, with bioluminescent spots along its body. |
| `pop_04129` | Great Labyrinth (Floors 41-90) Vesper-Touched Labyrinth Minotaur | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Adult | A- | 132 | 4 m | Night | A typical adult Vesper-Touched Labyrinth Minotaur of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_04130` | The Maw Vesper-Touched Labyrinth Minotaur Albino | [[Regions/The Maw\|The Maw]] | Albino | A | 146 | 4 m | Night | Like a typical Vesper-Touched Labyrinth Minotaur, but a rare pale form with white skin or fur and red eyes. |
| `pop_04131` | Iron Hold Vesper-Touched Labyrinth Minotaur Elderborn | [[Regions/Iron Hold\|Iron Hold]] | Elderborn | S- | 173 | 5.4 m | Night | Like a typical Vesper-Touched Labyrinth Minotaur, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_04132` | Great Labyrinth (Floors 41-90) Vesper-Touched Labyrinth Minotaur Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | S- | 173 | 5.4 m | Night | Like a typical Vesper-Touched Labyrinth Minotaur, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_04133` | Great Labyrinth (Floors 41-90) Vesper-Touched Labyrinth Minotaur Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | A+ | 159 | 5 m | Night | Like a typical Vesper-Touched Labyrinth Minotaur, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_04134` | The Maw Vesper-Touched Labyrinth Minotaur | [[Regions/The Maw\|The Maw]] | Adult | A- | 132 | 4 m | Night | A typical adult Vesper-Touched Labyrinth Minotaur of this region, with bioluminescent spots along its body. |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `short_hide` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · elongated, irregular silhouette; still-then-sudden timing
