---
type: monster
id: mon_vesper_touched_frost_giant
family: "Orcs, Ogres & Giants"
rank: "S-"
tier: variant
tags: [monster, orcs-ogres-giants]
---
# Vesper-Touched Frost Giant

![[mon_vesper_touched_frost_giant_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vesper_touched_frost_giant_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,184 tris · 5.475 × 3.72 × 9 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Vesper-Touched Frost Giant is a huge creature with a massive hunched brute frame, about 9 m tall. Its hide is patchy and subtly wrong, as if assembled from memory, colored in pale blues and frost-white. Look for a beard of icicles and armor of glacier ice. It has eyes that never blink. Its regal silhouette is crowned by a halo-like ring of aura. It glides without moving its legs, surrounded by falling snow motes and frosted ground where it steps. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Orcs, Ogres & Giants|Orcs, Ogres & Giants]] · Giant |
| Variant of | [[Monsters/Orcs, Ogres & Giants/Frost Giant\|Frost Giant]] (corrupted) |
| Rank · level | S- · 173 (159–188) |
| Menace | 4 · Dread |
| Element · weakness | Ice · Fire |
| Size | 9 m |
| Behaviour | Territorial (territorial_guard+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 58800 · 702 · 1053 · 421 · 702 · 70 |
| XP · gold | 11437 · 2042 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/large_biped\|large_biped]] · `anim_large_biped` |
| Habitats | [[Regions/Quaking Lands\|Quaking Lands]], [[Regions/Dragon Spine\|Dragon Spine]] |
| Genre | Classic Fantasy |
| Trope | Orc warbands and the Orc Disaster that devours its way to power (Tensura) |

**Field note:** Weak to Fire. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/large_biped|large_biped]] (rigId); animation set `anim_large_biped`.
- **Dimensions:** 9 m high × 2.7 m long × 3.78 m wide; prefab scale 2.571.
- **Physics:** 14434.2 kg, gravity ×1.37, poise 427, knockback resistance 0.93, death style `heavy_fall_dust`.
- **Navigation:** speed 8.84 m/s, turn 127°/s, stopping distance 2.2 m.
- **Attack count:** 5; **signature:** a beard of icicles and armor of glacier ice.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stomp\|Stomp]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Club Slam\|Club Slam]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grab and Throw\|Grab and Throw]] | grab | 2 | 14 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/War Cry\|War Cry]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Frost Breath\|Frost Breath]] | magic | 1.5 | 10 s | Ice | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched Frost Giant is a **dread giant** encountered at S- rank, around level 173. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a beard of icicles and armor of glacier ice. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Quaking Lands|Quaking Lands]], [[Regions/Dragon Spine|Dragon Spine]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_large_biped`, animation set `anim_large_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Orcs, Ogres & Giants S|loot_orc_giant_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Tusk\|Tusk]] | 60% | 1–3 |
| [[Items/Giant's Hide\|Giant's Hide]] | 30% | 1–1 |
| [[Items/Crude Iron\|Crude Iron]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Quaking Lands\|Quaking Lands]] | 6 | A+, S-, SS-, S+, S | 159–218 | Night |
| [[Regions/Dragon Spine\|Dragon Spine]] | 5 | A+, A, SS-, S, S- | 146–218 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04046` | Quaking Lands Vesper-Touched Frost Giant Juvenile | [[Regions/Quaking Lands\|Quaking Lands]] | Juvenile | A+ | 159 | 7.65 m | Night | Like a typical Vesper-Touched Frost Giant, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_04047` | Dragon Spine Vesper-Touched Frost Giant Juvenile | [[Regions/Dragon Spine\|Dragon Spine]] | Juvenile | A+ | 159 | 7.65 m | Night | Like a typical Vesper-Touched Frost Giant, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_04048` | Dragon Spine Vesper-Touched Frost Giant Runt | [[Regions/Dragon Spine\|Dragon Spine]] | Runt | A | 146 | 6.3 m | Night | Like a typical Vesper-Touched Frost Giant, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_04049` | Quaking Lands Vesper-Touched Frost Giant | [[Regions/Quaking Lands\|Quaking Lands]] | Adult | S- | 173 | 9 m | Night | A typical adult Vesper-Touched Frost Giant of this region, with slate-grey coloring and hardened hide. |
| `pop_04050` | Quaking Lands Vesper-Touched Frost Giant Elderborn | [[Regions/Quaking Lands\|Quaking Lands]] | Elderborn | SS- | 218 | 12.15 m | Night | Like a typical Vesper-Touched Frost Giant, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_04051` | Quaking Lands Vesper-Touched Frost Giant Alpha | [[Regions/Quaking Lands\|Quaking Lands]] | Alpha | S+ | 203 | 11.25 m | Night | Like a typical Vesper-Touched Frost Giant, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_04052` | Quaking Lands Vesper-Touched Frost Giant Scarred | [[Regions/Quaking Lands\|Quaking Lands]] | Scarred | S | 188 | 9.9 m | Night | Like a typical Vesper-Touched Frost Giant, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_04053` | Dragon Spine Vesper-Touched Frost Giant Elderborn | [[Regions/Dragon Spine\|Dragon Spine]] | Elderborn | SS- | 218 | 12.15 m | Night | Like a typical Vesper-Touched Frost Giant, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_04054` | Dragon Spine Vesper-Touched Frost Giant Scarred | [[Regions/Dragon Spine\|Dragon Spine]] | Scarred | S | 188 | 9.9 m | Night | Like a typical Vesper-Touched Frost Giant, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_04055` | Dragon Spine Vesper-Touched Frost Giant | [[Regions/Dragon Spine\|Dragon Spine]] | Adult | S- | 173 | 9 m | Night | A typical adult Vesper-Touched Frost Giant of this region, with slate-grey coloring and hardened hide. |
| `pop_04056` | Quaking Lands Vesper-Touched Frost Giant Albino | [[Regions/Quaking Lands\|Quaking Lands]] | Albino | S | 188 | 9 m | Night | Like a typical Vesper-Touched Frost Giant, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `thick_skin` · VFX `frost_trail_snow` · palette `#bfe9ff` `#5fa8d3` `#f4fbff` · elongated, irregular silhouette; still-then-sudden timing
