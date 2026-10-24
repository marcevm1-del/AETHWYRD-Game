---
type: monster
id: mon_bog_lich
family: "Undead"
rank: "A+"
tier: variant
tags: [monster, undead]
---
# Bog Lich

![[mon_bog_lich_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_bog_lich_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,632 tris · 1.598 × 1.594 × 2.2 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Bog Lich is a person-sized creature with a floating, cloth-like shape, about 2.2 m tall. Its flesh and bone are patchy and subtly wrong, as if assembled from memory, colored in bruise purple with sickly green. Its most striking feature is a crowned skull with a phylactery chained to its chest. It has pale, pupil-less eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It glides without moving its legs, surrounded by a low toxic haze that clings to the ground. Adapted to swamp lands, it has mud-slick, algae-streaked skin.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Lich\|Lich]] (regional) |
| Rank · level | A+ · 159 (146–173) |
| Menace | 4 · Dread |
| Element · weakness | Poison · Light |
| Size | 2.2 m |
| Behaviour | Guardian (guardian_hold+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 18903 · 388 · 452 · 904 · 840 · 90 |
| XP · gold | 9993 · 1815 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/spirit_float\|spirit_float]] · `anim_floating` |
| Habitats | [[Regions/Lumbaya\|Lumbaya]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Light. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/spirit_float|spirit_float]] (rigId); animation set `anim_floating`.
- **Dimensions:** 2.2 m high × 0.66 m long × 1.41 m wide; prefab scale 2.2.
- **Physics:** 1.1 kg, gravity ×0, poise 23, knockback resistance 0.15, death style `dissolve_into_motes`.
- **Navigation:** speed 7.02 m/s, turn 485°/s, stopping distance 0.95 m.
- **Attack count:** 5; **signature:** a crowned skull with a phylactery chained to its chest.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Chill Touch\|Chill Touch]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Phase Lunge\|Phase Lunge]] | dash | 1.3 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wail\|Wail]] | aoe | 1.2 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grave Grasp\|Grave Grasp]] | grab | 1.2 | 10 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Bog Lich is a **dread undead** encountered at A+ rank, around level 159. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a crowned skull with a phylactery chained to its chest. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Lumbaya|Lumbaya]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_floating`, animation set `anim_floating`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Undead A|loot_undead_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 5 | S-, S, A, S+, A- | 132–203 | Night |
| [[Regions/Lumbaya\|Lumbaya]] | 6 | A-, S, S-, A, S+ | 132–203 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03837` | Great Labyrinth (Floors 41-90) Bog Lich Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | S- | 173 | 2.42 m | Night | Like a typical Bog Lich, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_03838` | Lumbaya Bog Lich Runt | [[Regions/Lumbaya\|Lumbaya]] | Runt | A- | 132 | 1.54 m | Night | Like a typical Bog Lich, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_03839` | Great Labyrinth (Floors 41-90) Bog Lich Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | S | 188 | 2.75 m | Night | Like a typical Bog Lich, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_03840` | Great Labyrinth (Floors 41-90) Bog Lich Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | A | 146 | 1.87 m | Night | Like a typical Bog Lich, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_03841` | Lumbaya Bog Lich Alpha | [[Regions/Lumbaya\|Lumbaya]] | Alpha | S | 188 | 2.75 m | Night | Like a typical Bog Lich, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_03842` | Lumbaya Bog Lich Scarred | [[Regions/Lumbaya\|Lumbaya]] | Scarred | S- | 173 | 2.42 m | Night | Like a typical Bog Lich, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_03843` | Lumbaya Bog Lich Juvenile | [[Regions/Lumbaya\|Lumbaya]] | Juvenile | A | 146 | 1.87 m | Night | Like a typical Bog Lich, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_03844` | Great Labyrinth (Floors 41-90) Bog Lich Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | S+ | 203 | 2.97 m | Night | Like a typical Bog Lich, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_03845` | Great Labyrinth (Floors 41-90) Bog Lich Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | A- | 132 | 1.54 m | Night | Like a typical Bog Lich, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_03846` | Lumbaya Bog Lich Elderborn | [[Regions/Lumbaya\|Lumbaya]] | Elderborn | S+ | 203 | 2.97 m | Night | Like a typical Bog Lich, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_03847` | Lumbaya Bog Lich Albino | [[Regions/Lumbaya\|Lumbaya]] | Albino | S- | 173 | 2.2 m | Night | Like a typical Bog Lich, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `rot_bone` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · elongated, irregular silhouette; still-then-sudden timing
