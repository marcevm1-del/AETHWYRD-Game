---
type: monster
id: mon_vesper_touched_oni
family: "Yokai-Inspired Spirits"
rank: "A"
tier: variant
tags: [monster, yokai-inspired-spirits]
---
# Vesper-Touched Oni

> The Vesper-Touched Oni is a large creature with a massive hunched brute frame, about 3.5 m tall. Its form is patchy and subtly wrong, as if assembled from memory, colored in ember reds fading to soot black. Look for horns, a tiger-skin wrap and an iron club. It has pale, pupil-less eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It freezes whenever it is looked at, surrounded by heat-shimmer and drifting sparks. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Yokai-Inspired Spirits|Yokai-Inspired Spirits]] · Spirit |
| Variant of | [[Monsters/Yokai-Inspired Spirits/Oni\|Oni]] (corrupted) |
| Rank · level | A · 146 (132–159) |
| Menace | 4 · Dread |
| Element · weakness | Fire · Water |
| Size | 3.5 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 34058 · 594 · 891 · 356 · 594 · 70 |
| XP · gold | 8719 · 1611 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/large_biped\|large_biped]] · `anim_large_biped` |
| Habitats | [[Regions/Haneul\|Haneul]], [[Regions/Kitsune Isles\|Kitsune Isles]], [[Regions/Shen-Lu\|Shen-Lu]] |
| Genre | Japanese Folklore |
| Trope | Gentle and terrifying spirits (Natsume's Book of Friends, Mushishi, Inuyasha) |

**Field note:** Weak to Water. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/large_biped|large_biped]] (rigId); animation set `anim_large_biped`.
- **Dimensions:** 3.5 m high × 1.05 m long × 1.47 m wide; prefab scale 1.
- **Physics:** 771.8 kg, gravity ×1.3, poise 245, knockback resistance 0.9, death style `heavy_fall_dust`.
- **Navigation:** speed 6.92 m/s, turn 203°/s, stopping distance 1.1 m.
- **Attack count:** 5; **signature:** horns, a tiger-skin wrap and an iron club.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stomp\|Stomp]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Club Slam\|Club Slam]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grab and Throw\|Grab and Throw]] | grab | 2 | 14 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Spirit Flame\|Spirit Flame]] | magic | 1.2 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched Oni is a **dread spirit** encountered at A rank, around level 146. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** horns, a tiger-skin wrap and an iron club. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Haneul|Haneul]], [[Regions/Kitsune Isles|Kitsune Isles]], [[Regions/Shen-Lu|Shen-Lu]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_large_biped`, animation set `anim_large_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Yokai-Inspired Spirits A|loot_yokai_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Spirit Paper\|Spirit Paper]] | 60% | 1–3 |
| [[Items/Fox Fire\|Fox Fire]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Kitsune Isles\|Kitsune Isles]] | 5 | A-, S-, A, S, A+ | 132–188 | Night |
| [[Regions/Haneul\|Haneul]] | 3 | B+, S, A | 120–188 | Night |
| [[Regions/Shen-Lu\|Shen-Lu]] | 3 | S-, A+, A- | 132–173 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05378` | Kitsune Isles Vesper-Touched Oni Juvenile | [[Regions/Kitsune Isles\|Kitsune Isles]] | Juvenile | A- | 132 | 2.98 m | Night | Like a typical Vesper-Touched Oni, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_05379` | Haneul Vesper-Touched Oni Runt | [[Regions/Haneul\|Haneul]] | Runt | B+ | 120 | 2.45 m | Night | Like a typical Vesper-Touched Oni, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_05380` | Kitsune Isles Vesper-Touched Oni Alpha | [[Regions/Kitsune Isles\|Kitsune Isles]] | Alpha | S- | 173 | 4.38 m | Night | Like a typical Vesper-Touched Oni, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_05381` | Kitsune Isles Vesper-Touched Oni | [[Regions/Kitsune Isles\|Kitsune Isles]] | Adult | A | 146 | 3.5 m | Night | A typical adult Vesper-Touched Oni of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_05382` | Shen-Lu Vesper-Touched Oni Alpha | [[Regions/Shen-Lu\|Shen-Lu]] | Alpha | S- | 173 | 4.38 m | Night | Like a typical Vesper-Touched Oni, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_05383` | Kitsune Isles Vesper-Touched Oni Elderborn | [[Regions/Kitsune Isles\|Kitsune Isles]] | Elderborn | S | 188 | 4.73 m | Night | Like a typical Vesper-Touched Oni, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_05384` | Haneul Vesper-Touched Oni Elderborn | [[Regions/Haneul\|Haneul]] | Elderborn | S | 188 | 4.73 m | Night | Like a typical Vesper-Touched Oni, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_05385` | Shen-Lu Vesper-Touched Oni Albino | [[Regions/Shen-Lu\|Shen-Lu]] | Albino | A+ | 159 | 3.5 m | Night | Like a typical Vesper-Touched Oni, but a rare pale form with white skin or fur and red eyes. |
| `pop_05386` | Haneul Vesper-Touched Oni | [[Regions/Haneul\|Haneul]] | Adult | A | 146 | 3.5 m | Night | A typical adult Vesper-Touched Oni of this region, with slate-grey coloring and hardened hide. |
| `pop_05387` | Kitsune Isles Vesper-Touched Oni Scarred | [[Regions/Kitsune Isles\|Kitsune Isles]] | Scarred | A+ | 159 | 3.85 m | Night | Like a typical Vesper-Touched Oni, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_05388` | Shen-Lu Vesper-Touched Oni Juvenile | [[Regions/Shen-Lu\|Shen-Lu]] | Juvenile | A- | 132 | 2.98 m | Night | Like a typical Vesper-Touched Oni, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `paper_ink_spirit` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · elongated, irregular silhouette; still-then-sudden timing
