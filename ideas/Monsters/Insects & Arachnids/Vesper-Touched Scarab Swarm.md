---
type: monster
id: mon_vesper_touched_scarab_swarm
family: "Insects & Arachnids"
rank: "S-"
tier: variant
tags: [monster, insects-arachnids]
---
# Vesper-Touched Scarab Swarm

> The Vesper-Touched Scarab Swarm is a tiny creature with a cloud of tiny creatures, each one is about 0.05 m long, but the swarm covers several meters. Its chitin is patchy and subtly wrong, as if assembled from memory, colored in ink black with bruised violet. Its most striking feature is golden beetles that flow like spilled coins. It has eyes that never blink. Its regal silhouette is crowned by a halo-like ring of aura. It freezes whenever it is looked at, surrounded by shadows that lean toward it. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Variant of | [[Monsters/Insects & Arachnids/Scarab Swarm\|Scarab Swarm]] (corrupted) |
| Rank · level | S- · 173 (159–188) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 0.05 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 8626 · 562 · 421 · 421 · 421 · 110 |
| XP · gold | 11437 · 2042 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/swarm\|swarm]] · `anim_swarm` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/The Maw\|The Maw]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/swarm|swarm]] (rigId); animation set `anim_swarm`.
- **Dimensions:** 0.05 m high × 0.02 m long × 0.01 m wide; prefab scale 0.017.
- **Physics:** 0.5 kg, gravity ×0, poise 6, knockback resistance 1, death style `scatter_and_fall`.
- **Navigation:** speed 1.14 m/s, turn 900°/s, stopping distance 0.5 m.
- **Attack count:** 5; **signature:** golden beetles that flow like spilled coins.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Nibble\|Nibble]] | melee | 0.6 | 0 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Scatter\|Scatter]] | evade | 0 | 10 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Silk Snare\|Silk Snare]] | ranged | 0.4 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched Scarab Swarm is a **dread insectoid** encountered at S- rank, around level 173. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** golden beetles that flow like spilled coins. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/The Maw|The Maw]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_swarm`, animation set `anim_swarm`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Insects & Arachnids S|loot_insect_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Carapace Shard\|Carapace Shard]] | 60% | 1–3 |
| [[Items/Silk\|Silk]] | 30% | 1–1 |
| [[Items/Venom Sac\|Venom Sac]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/The Maw\|The Maw]] | 5 | SS-, S, S+, A+, A | 146–218 | Night |
| [[Regions/Moraveil\|Moraveil]] | 6 | S, S-, S+, A, SS-, A+ | 146–218 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03606` | The Maw Vesper-Touched Scarab Swarm Elderborn | [[Regions/The Maw\|The Maw]] | Elderborn | SS- | 218 | 0.07 m | Night | Like a typical Vesper-Touched Scarab Swarm, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_03607` | Moraveil Vesper-Touched Scarab Swarm Albino | [[Regions/Moraveil\|Moraveil]] | Albino | S | 188 | 0.05 m | Night | Like a typical Vesper-Touched Scarab Swarm, but a rare pale form with white skin or fur and red eyes. |
| `pop_03608` | Moraveil Vesper-Touched Scarab Swarm | [[Regions/Moraveil\|Moraveil]] | Adult | S- | 173 | 0.05 m | Night | A typical adult Vesper-Touched Scarab Swarm of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_03609` | Moraveil Vesper-Touched Scarab Swarm Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | S+ | 203 | 0.06 m | Night | Like a typical Vesper-Touched Scarab Swarm, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_03610` | The Maw Vesper-Touched Scarab Swarm Albino | [[Regions/The Maw\|The Maw]] | Albino | S | 188 | 0.05 m | Night | Like a typical Vesper-Touched Scarab Swarm, but a rare pale form with white skin or fur and red eyes. |
| `pop_03611` | The Maw Vesper-Touched Scarab Swarm Alpha | [[Regions/The Maw\|The Maw]] | Alpha | S+ | 203 | 0.06 m | Night | Like a typical Vesper-Touched Scarab Swarm, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_03612` | The Maw Vesper-Touched Scarab Swarm Juvenile | [[Regions/The Maw\|The Maw]] | Juvenile | A+ | 159 | 0.04 m | Night | Like a typical Vesper-Touched Scarab Swarm, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_03613` | The Maw Vesper-Touched Scarab Swarm Runt | [[Regions/The Maw\|The Maw]] | Runt | A | 146 | 0.03 m | Night | Like a typical Vesper-Touched Scarab Swarm, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_03614` | Moraveil Vesper-Touched Scarab Swarm Runt | [[Regions/Moraveil\|Moraveil]] | Runt | A | 146 | 0.03 m | Night | Like a typical Vesper-Touched Scarab Swarm, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_03615` | Moraveil Vesper-Touched Scarab Swarm Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | SS- | 218 | 0.07 m | Night | Like a typical Vesper-Touched Scarab Swarm, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_03616` | Moraveil Vesper-Touched Scarab Swarm Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | A+ | 159 | 0.04 m | Night | Like a typical Vesper-Touched Scarab Swarm, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_swarm` · mesh `swarm_base` · material `chitin_gloss` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · elongated, irregular silhouette; still-then-sudden timing
