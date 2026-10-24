---
type: monster
id: mon_vesper_touched_drake_lord
family: "Dragons"
rank: "S"
tier: variant
tags: [monster, dragons]
---
# Vesper-Touched Drake Lord

![[mon_vesper_touched_drake_lord_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vesper_touched_drake_lord_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,752 tris · 14.005 × 10 × 14.036 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Vesper-Touched Drake Lord is a huge creature with a bipedal winged body with wing-arms, about 10 m long. Its scales are patchy and subtly wrong, as if assembled from memory, colored in ember reds fading to soot black. Look for a crown of broken horns from rivals it killed. It has pale, pupil-less eyes. Its regal silhouette is crowned by a halo-like ring of aura. It moves in jerky stop-motion bursts, surrounded by heat-shimmer and drifting sparks. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Dragons|Dragons]] · Dragon |
| Variant of | [[Monsters/Dragons/Drake Lord\|Drake Lord]] (corrupted) |
| Rank · level | S · 188 (173–203) |
| Menace | 4 · Dread |
| Element · weakness | Fire · Water |
| Size | 10 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 53902 · 914 · 762 · 610 · 686 · 100 |
| XP · gold | 13063 · 2293 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/wyvern\|wyvern]] · `anim_wyvern` |
| Habitats | [[Regions/Dragon Spine\|Dragon Spine]], [[Regions/Nox Dominion\|Nox Dominion]] |
| Genre | High Fantasy |
| Trope | Dragons as proud, intelligent apex beings; wyverns as their lesser kin |

**Field note:** Weak to Water. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/wyvern|wyvern]] (rigId); animation set `anim_wyvern`.
- **Dimensions:** 5 m high × 10 m long × 15.26 m wide; prefab scale 1.667.
- **Physics:** 4600 kg, gravity ×1, poise 429, knockback resistance 0.98, death style `crash_slide`.
- **Navigation:** speed 8.41 m/s, turn 190°/s, stopping distance 1.2 m.
- **Attack count:** 5; **signature:** a crown of broken horns from rivals it killed.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Talon Rake\|Talon Rake]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Dive Bomb\|Dive Bomb]] | dash | 1.9 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Tail Whip\|Tail Whip]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wing Buffet\|Wing Buffet]] | aoe | 1.1 | 9 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched Drake Lord is a **dread dragon** encountered at S rank, around level 188. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a crown of broken horns from rivals it killed. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Dragon Spine|Dragon Spine]], [[Regions/Nox Dominion|Nox Dominion]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_wyvern`, animation set `anim_wyvern`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Dragons S|loot_draconic_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dragon Scale\|Dragon Scale]] | 60% | 1–3 |
| [[Items/Dragon Blood\|Dragon Blood]] | 30% | 1–1 |
| [[Items/Dragon Heart\|Dragon Heart]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Nox Dominion\|Nox Dominion]] | 7 | A+, SS-, S+, S-, S, SS | 159–236 | Night |
| [[Regions/Dragon Spine\|Dragon Spine]] | 4 | S-, SS-, S+ | 173–218 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04296` | Nox Dominion Vesper-Touched Drake Lord Runt | [[Regions/Nox Dominion\|Nox Dominion]] | Runt | A+ | 159 | 7 m | Night | Like a typical Vesper-Touched Drake Lord, but smaller and scrappier than usual, with ash-dark coloring with glowing cracks. |
| `pop_04297` | Dragon Spine Vesper-Touched Drake Lord Juvenile | [[Regions/Dragon Spine\|Dragon Spine]] | Juvenile | S- | 173 | 8.5 m | Night | Like a typical Vesper-Touched Drake Lord, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_04298` | Dragon Spine Vesper-Touched Drake Lord Alpha | [[Regions/Dragon Spine\|Dragon Spine]] | Alpha | SS- | 218 | 12.5 m | Night | Like a typical Vesper-Touched Drake Lord, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_04299` | Dragon Spine Vesper-Touched Drake Lord Albino | [[Regions/Dragon Spine\|Dragon Spine]] | Albino | S+ | 203 | 10 m | Night | Like a typical Vesper-Touched Drake Lord, but a rare pale form with white skin or fur and red eyes. |
| `pop_04300` | Nox Dominion Vesper-Touched Drake Lord Alpha | [[Regions/Nox Dominion\|Nox Dominion]] | Alpha | SS- | 218 | 12.5 m | Night | Like a typical Vesper-Touched Drake Lord, but larger and scarred, and others of its kind follow it, with ash-dark coloring with glowing cracks. |
| `pop_04301` | Nox Dominion Vesper-Touched Drake Lord Scarred | [[Regions/Nox Dominion\|Nox Dominion]] | Scarred | S+ | 203 | 11 m | Night | Like a typical Vesper-Touched Drake Lord, but covered in old battle scars, with ash-dark coloring with glowing cracks. |
| `pop_04302` | Nox Dominion Vesper-Touched Drake Lord Juvenile | [[Regions/Nox Dominion\|Nox Dominion]] | Juvenile | S- | 173 | 8.5 m | Night | Like a typical Vesper-Touched Drake Lord, but young, with brighter colors and unworn features, with ash-dark coloring with glowing cracks. |
| `pop_04303` | Dragon Spine Vesper-Touched Drake Lord Scarred | [[Regions/Dragon Spine\|Dragon Spine]] | Scarred | S+ | 203 | 11 m | Night | Like a typical Vesper-Touched Drake Lord, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_04304` | Nox Dominion Vesper-Touched Drake Lord | [[Regions/Nox Dominion\|Nox Dominion]] | Adult | S | 188 | 10 m | Night | A typical adult Vesper-Touched Drake Lord of this region, with ash-dark coloring with glowing cracks. |
| `pop_04305` | Nox Dominion Vesper-Touched Drake Lord Elderborn | [[Regions/Nox Dominion\|Nox Dominion]] | Elderborn | SS | 236 | 13.5 m | Night | Like a typical Vesper-Touched Drake Lord, but old and wise, with greying features and a cautious hunting style, with ash-dark coloring with glowing cracks. |
| `pop_04306` | Nox Dominion Vesper-Touched Drake Lord Albino | [[Regions/Nox Dominion\|Nox Dominion]] | Albino | S+ | 203 | 10 m | Night | Like a typical Vesper-Touched Drake Lord, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_wyvern` · mesh `wyvern_base` · material `dragon_scale` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · elongated, irregular silhouette; still-then-sudden timing
