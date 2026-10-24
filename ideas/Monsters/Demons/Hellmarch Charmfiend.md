---
type: monster
id: mon_hellmarch_charmfiend
family: "Demons"
rank: "B-"
tier: variant
tags: [monster, demons]
---
# Hellmarch Charmfiend

![[mon_hellmarch_charmfiend_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_hellmarch_charmfiend_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,768 tris · 0.751 × 1.382 × 1.8 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Hellmarch Charmfiend is a person-sized creature with a lean humanoid frame, about 1.8 m tall. Its hide is patchy and subtly wrong, as if assembled from memory, colored in ink black with bruised violet. Guild sketches always show a beautiful porcelain mask hiding a hollow face. It has pale, pupil-less eyes. Faint runes glow along its body when it fights. It moves in jerky stop-motion bursts, surrounded by shadows that lean toward it. Adapted to demon lands, it has red-black coloring with faint ember veins.

| Field | Value |
|---|---|
| Family · type | [[Families/Demons|Demons]] · Demon |
| Variant of | [[Monsters/Demons/Charmfiend\|Charmfiend]] (regional) |
| Rank · level | B- · 96 (86–108) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 1.8 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 11427 · 473 · 394 · 315 · 355 · 100 |
| XP · gold | 4462 · 897 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Strife Marches\|Strife Marches]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] |
| Genre | Abyssal |
| Trope | Demons as a people of the Abyss, not just evil (Frieren, Maoyuu) |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 1.8 m high × 0.54 m long × 0.58 m wide; prefab scale 1.
- **Physics:** 75.8 kg, gravity ×1.5, poise 80, knockback resistance 0.42, death style `ragdoll`.
- **Navigation:** speed 5.43 m/s, turn 298°/s, stopping distance 0.71 m.
- **Attack count:** 5; **signature:** a beautiful porcelain mask hiding a hollow face.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Hellfire Brand\|Hellfire Brand]] | magic | 1.4 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Hellmarch Charmfiend is a **dread demon** encountered at B- rank, around level 96. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a beautiful porcelain mask hiding a hollow face. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Strife Marches|Strife Marches]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Demons B|loot_demon_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Demon Core\|Demon Core]] | 60% | 1–3 |
| [[Items/Horn Shard\|Horn Shard]] | 30% | 1–1 |
| [[Items/Brimstone\|Brimstone]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 6 | B+, B, B-, A-, C+ | 86–132 | Night |
| [[Regions/Strife Marches\|Strife Marches]] | 5 | C, B-, C+, B+, B | 76–120 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04733` | Great Labyrinth (Floors 41-90) Hellmarch Charmfiend Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | B+ | 120 | 2.25 m | Night | Like a typical Hellmarch Charmfiend, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_04734` | Great Labyrinth (Floors 41-90) Hellmarch Charmfiend Albino | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Albino | B | 108 | 1.8 m | Night | Like a typical Hellmarch Charmfiend, but a rare pale form with white skin or fur and red eyes. |
| `pop_04735` | Strife Marches Hellmarch Charmfiend Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | C | 76 | 1.26 m | Night | Like a typical Hellmarch Charmfiend, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_04736` | Strife Marches Hellmarch Charmfiend | [[Regions/Strife Marches\|Strife Marches]] | Adult | B- | 96 | 1.8 m | Night | A typical adult Hellmarch Charmfiend of this region, with dust-grey coloring and old rune scars. |
| `pop_04737` | Great Labyrinth (Floors 41-90) Hellmarch Charmfiend | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Adult | B- | 96 | 1.8 m | Night | A typical adult Hellmarch Charmfiend of this region, with dust-grey coloring and old rune scars. |
| `pop_04738` | Strife Marches Hellmarch Charmfiend Juvenile | [[Regions/Strife Marches\|Strife Marches]] | Juvenile | C+ | 86 | 1.53 m | Night | Like a typical Hellmarch Charmfiend, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_04739` | Great Labyrinth (Floors 41-90) Hellmarch Charmfiend Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | A- | 132 | 2.43 m | Night | Like a typical Hellmarch Charmfiend, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_04740` | Great Labyrinth (Floors 41-90) Hellmarch Charmfiend Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | C+ | 86 | 1.53 m | Night | Like a typical Hellmarch Charmfiend, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_04741` | Great Labyrinth (Floors 41-90) Hellmarch Charmfiend Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | B | 108 | 1.98 m | Night | Like a typical Hellmarch Charmfiend, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_04742` | Strife Marches Hellmarch Charmfiend Alpha | [[Regions/Strife Marches\|Strife Marches]] | Alpha | B+ | 120 | 2.25 m | Night | Like a typical Hellmarch Charmfiend, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_04743` | Strife Marches Hellmarch Charmfiend Scarred | [[Regions/Strife Marches\|Strife Marches]] | Scarred | B | 108 | 1.98 m | Night | Like a typical Hellmarch Charmfiend, but covered in old battle scars, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `demon_hide_emissive` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · elongated, irregular silhouette; still-then-sudden timing
