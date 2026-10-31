---
type: monster
id: mon_bog_lich_emperor
family: "Undead"
rank: "SSS+"
tier: variant
tags: [monster, undead]
---
# Bog Lich Emperor

![[mon_bog_lich_emperor_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_bog_lich_emperor_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,438 tris · 1.397 × 2.173 × 3 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Bog Lich Emperor is a large creature with a drifting, half-formed body, about 3 m tall. Its flesh and bone are patchy and subtly wrong, as if assembled from memory, colored in bleached bone and grave-cloth, with sickly green markings. Its most striking feature is a crown of frozen souls and a phylactery the size of a castle tower. It has pale, pupil-less eyes. Its outline is crowned by slowly turning rings of light; lesser monsters flee from it. It freezes whenever it is looked at, surrounded by a low toxic haze that clings to the ground. Adapted to swamp lands, it has mud-slick, algae-streaked skin.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Lich Emperor\|Lich Emperor]] (regional) |
| Rank · level | SSS+ · 294 (281–300) |
| Menace | 4 · Dread |
| Element · weakness | Poison · Light |
| Size | 3 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 52698 · 712 · 830 · 1660 · 1542 · 90 |
| XP · gold | 26706 · 4286 |
| Ring | 9 |
| Rig · animation | [[Systems/Rigs/spirit_float\|spirit_float]] · `anim_floating` |
| Habitats | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]], [[Regions/Nox Dominion\|Nox Dominion]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/spirit_float|spirit_float]] (rigId); animation set `anim_floating`.
- **Dimensions:** 3 m high × 0.9 m long × 1.92 m wide; prefab scale 3.
- **Physics:** 2.7 kg, gravity ×0, poise 50, knockback resistance 0.24, death style `dissolve_into_motes`.
- **Navigation:** speed 10.03 m/s, turn 416°/s, stopping distance 1.15 m.
- **Attack count:** 5; **signature:** a crown of frozen souls and a phylactery the size of a castle tower.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Chill Touch\|Chill Touch]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Phase Lunge\|Phase Lunge]] | dash | 1.3 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wail\|Wail]] | aoe | 1.2 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grave Grasp\|Grave Grasp]] | grab | 1.2 | 10 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Bog Lich Emperor is a **dread undead** encountered at SSS+ rank, around level 294. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a crown of frozen souls and a phylactery the size of a castle tower. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 91-120)|Great Labyrinth (Floors 91-120)]], [[Regions/Nox Dominion|Nox Dominion]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_floating`, animation set `anim_floating`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Undead SSS|loot_undead_sss]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/SSS-Rank Monster Core\|SSS-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | 6 | EX-, SSS-, SSS, EX, EX+, SSS+ | 267–300 | Night |
| [[Regions/Nox Dominion\|Nox Dominion]] | 5 | SSS-, EX+, EX, SSS+, SSS | 267–300 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03870` | Great Labyrinth (Floors 91-120) Bog Lich Emperor Scarred | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Scarred | EX- | 300 | 3.3 m | Night | Like a typical Bog Lich Emperor, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_03871` | Great Labyrinth (Floors 91-120) Bog Lich Emperor Runt | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Runt | SSS- | 267 | 2.1 m | Night | Like a typical Bog Lich Emperor, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_03872` | Great Labyrinth (Floors 91-120) Bog Lich Emperor Juvenile | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Juvenile | SSS | 281 | 2.55 m | Night | Like a typical Bog Lich Emperor, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_03873` | Great Labyrinth (Floors 91-120) Bog Lich Emperor Alpha | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Alpha | EX | 300 | 3.75 m | Night | Like a typical Bog Lich Emperor, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_03874` | Nox Dominion Bog Lich Emperor Runt | [[Regions/Nox Dominion\|Nox Dominion]] | Runt | SSS- | 267 | 2.1 m | Night | Like a typical Bog Lich Emperor, but smaller and scrappier than usual, with red-black coloring with faint ember veins. |
| `pop_03875` | Nox Dominion Bog Lich Emperor Elderborn | [[Regions/Nox Dominion\|Nox Dominion]] | Elderborn | EX+ | 300 | 4.05 m | Night | Like a typical Bog Lich Emperor, but old and wise, with greying features and a cautious hunting style, with red-black coloring with faint ember veins. |
| `pop_03876` | Nox Dominion Bog Lich Emperor Alpha | [[Regions/Nox Dominion\|Nox Dominion]] | Alpha | EX | 300 | 3.75 m | Night | Like a typical Bog Lich Emperor, but larger and scarred, and others of its kind follow it, with red-black coloring with faint ember veins. |
| `pop_03877` | Great Labyrinth (Floors 91-120) Bog Lich Emperor Elderborn | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Elderborn | EX+ | 300 | 4.05 m | Night | Like a typical Bog Lich Emperor, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_03878` | Great Labyrinth (Floors 91-120) Bog Lich Emperor | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Adult | SSS+ | 294 | 3 m | Night | A typical adult Bog Lich Emperor of this region, with dust-grey coloring and old rune scars. |
| `pop_03879` | Nox Dominion Bog Lich Emperor | [[Regions/Nox Dominion\|Nox Dominion]] | Adult | SSS+ | 294 | 3 m | Night | A typical adult Bog Lich Emperor of this region, with red-black coloring with faint ember veins. |
| `pop_03880` | Nox Dominion Bog Lich Emperor Juvenile | [[Regions/Nox Dominion\|Nox Dominion]] | Juvenile | SSS | 281 | 2.55 m | Night | Like a typical Bog Lich Emperor, but young, with brighter colors and unworn features, with red-black coloring with faint ember veins. |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `rot_bone` · VFX `toxic_fog` · palette `#dfccb5` `#8e7e6b` `#b8e986` · elongated, irregular silhouette; still-then-sudden timing
