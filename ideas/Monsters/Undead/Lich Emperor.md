---
type: monster
id: mon_lich_emperor
family: "Undead"
rank: "SSS"
tier: core
tags: [monster, undead]
---
# Lich Emperor

![[mon_lich_emperor_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_lich_emperor_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,250 tris · 1.397 × 2.115 × 3 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Lich Emperor is a large creature with a bodiless, glowing form, about 3 m tall. Its flesh and bone are patchy and subtly wrong, as if assembled from memory, colored in pale blues and frost-white. Survivors describe a crown of frozen souls and a phylactery the size of a castle tower. It has eyes set slightly too far apart. Its outline is crowned by slowly turning rings of light; lesser monsters flee from it. It freezes whenever it is looked at, surrounded by falling snow motes and frosted ground where it steps.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Rank · level | SSS · 281 (267–294) |
| Menace | 4 · Dread |
| Element · weakness | Ice · Fire |
| Size | 3 m |
| Behaviour | Guardian (guardian_hold+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 49246 · 680 · 794 · 1588 · 1474 · 90 |
| XP · gold | 24842 · 4024 |
| Ring | 8 |
| Rig · animation | [[Systems/Rigs/spirit_float\|spirit_float]] · `anim_floating` |
| Habitats | [[Regions/Nox Dominion\|Nox Dominion]], [[Regions/Vesper\|Vesper]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Fire. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/spirit_float|spirit_float]] (rigId); animation set `anim_floating`.
- **Dimensions:** 3 m high × 0.9 m long × 1.92 m wide; prefab scale 3.
- **Physics:** 3 kg, gravity ×0, poise 50, knockback resistance 0.24, death style `dissolve_into_motes`.
- **Navigation:** speed 7.78 m/s, turn 416°/s, stopping distance 1.15 m.
- **Attack count:** 5; **signature:** a crown of frozen souls and a phylactery the size of a castle tower.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Chill Touch\|Chill Touch]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Phase Lunge\|Phase Lunge]] | dash | 1.3 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wail\|Wail]] | aoe | 1.2 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grave Grasp\|Grave Grasp]] | grab | 1.2 | 10 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Frost Breath\|Frost Breath]] | magic | 1.5 | 10 s | Ice | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Lich Emperor is a **dread undead** encountered at SSS rank, around level 281. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a crown of frozen souls and a phylactery the size of a castle tower. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Nox Dominion|Nox Dominion]], [[Regions/Vesper|Vesper]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_floating`, animation set `anim_floating`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Undead SSS|loot_undead_sss]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/SSS-Rank Monster Core\|SSS-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Undead/Bog Lich Emperor|Bog Lich Emperor]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Vesper\|Vesper]] | 5 | SSS+, SSS-, EX-, SS+ | 253–300 | Night |
| [[Regions/Nox Dominion\|Nox Dominion]] | 6 | SSS, SSS-, EX-, EX, SS+, SSS+ | 253–300 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00972` | Vesper Lich Emperor Scarred | [[Regions/Vesper\|Vesper]] | Scarred | SSS+ | 294 | 3.3 m | Night | Like a typical Lich Emperor, but covered in old battle scars, with red-black coloring with faint ember veins. |
| `pop_00973` | Nox Dominion Lich Emperor | [[Regions/Nox Dominion\|Nox Dominion]] | Adult | SSS | 281 | 3 m | Night | A typical adult Lich Emperor of this region, with red-black coloring with faint ember veins. |
| `pop_00974` | Vesper Lich Emperor Juvenile | [[Regions/Vesper\|Vesper]] | Juvenile | SSS- | 267 | 2.55 m | Night | Like a typical Lich Emperor, but young, with brighter colors and unworn features, with red-black coloring with faint ember veins. |
| `pop_00975` | Vesper Lich Emperor Alpha | [[Regions/Vesper\|Vesper]] | Alpha | EX- | 300 | 3.75 m | Night | Like a typical Lich Emperor, but larger and scarred, and others of its kind follow it, with red-black coloring with faint ember veins. |
| `pop_00976` | Nox Dominion Lich Emperor Juvenile | [[Regions/Nox Dominion\|Nox Dominion]] | Juvenile | SSS- | 267 | 2.55 m | Night | Like a typical Lich Emperor, but young, with brighter colors and unworn features, with red-black coloring with faint ember veins. |
| `pop_00977` | Vesper Lich Emperor Runt | [[Regions/Vesper\|Vesper]] | Runt | SS+ | 253 | 2.1 m | Night | Like a typical Lich Emperor, but smaller and scrappier than usual, with red-black coloring with faint ember veins. |
| `pop_00978` | Nox Dominion Lich Emperor Alpha | [[Regions/Nox Dominion\|Nox Dominion]] | Alpha | EX- | 300 | 3.75 m | Night | Like a typical Lich Emperor, but larger and scarred, and others of its kind follow it, with red-black coloring with faint ember veins. |
| `pop_00979` | Nox Dominion Lich Emperor Elderborn | [[Regions/Nox Dominion\|Nox Dominion]] | Elderborn | EX | 300 | 4.05 m | Night | Like a typical Lich Emperor, but old and wise, with greying features and a cautious hunting style, with red-black coloring with faint ember veins. |
| `pop_00980` | Nox Dominion Lich Emperor Runt | [[Regions/Nox Dominion\|Nox Dominion]] | Runt | SS+ | 253 | 2.1 m | Night | Like a typical Lich Emperor, but smaller and scrappier than usual, with red-black coloring with faint ember veins. |
| `pop_00981` | Nox Dominion Lich Emperor Albino | [[Regions/Nox Dominion\|Nox Dominion]] | Albino | SSS+ | 294 | 3 m | Night | Like a typical Lich Emperor, but a rare pale form with white skin or fur and red eyes. |
| `pop_00982` | Vesper Lich Emperor Albino | [[Regions/Vesper\|Vesper]] | Albino | SSS+ | 294 | 3 m | Night | Like a typical Lich Emperor, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `rot_bone` · VFX `frost_trail_snow` · palette `#bfe9ff` `#5fa8d3` `#f4fbff` · elongated, irregular silhouette; still-then-sudden timing
