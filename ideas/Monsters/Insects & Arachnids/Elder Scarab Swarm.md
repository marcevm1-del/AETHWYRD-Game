---
type: monster
id: mon_elder_scarab_swarm
family: "Insects & Arachnids"
rank: "S"
tier: variant
tags: [monster, insects-arachnids]
---
# Elder Scarab Swarm

> The Elder Scarab Swarm is a tiny creature with a cloud of tiny creatures, each one is about 0.1 m long, but the swarm covers several meters. Its chitin is rough, scarred and spiked, colored in ink black with bruised violet. Its most striking feature is golden beetles that flow like spilled coins. It has narrow glowing eyes. Its regal silhouette is crowned by a halo-like ring of aura. It circles its prey, surrounded by shadows that lean toward it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Variant of | [[Monsters/Insects & Arachnids/Scarab Swarm\|Scarab Swarm]] (elder) |
| Rank · level | S · 188 (173–203) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 0.1 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 9962 · 610 · 457 · 457 · 457 · 110 |
| XP · gold | 13063 · 2293 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/swarm\|swarm]] · `anim_swarm` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Light. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/swarm|swarm]] (rigId); animation set `anim_swarm`.
- **Dimensions:** 0.1 m high × 0.04 m long × 0.01 m wide; prefab scale 0.033.
- **Physics:** 0.5 kg, gravity ×0, poise 6, knockback resistance 1, death style `scatter_and_fall`.
- **Navigation:** speed 1.54 m/s, turn 900°/s, stopping distance 0.5 m.
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

Elder Scarab Swarm is a **menacing insectoid** encountered at S rank, around level 188. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** golden beetles that flow like spilled coins. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Great Labyrinth (Floors 91-120)|Great Labyrinth (Floors 91-120)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Moraveil\|Moraveil]] | 7 | SS-, S+, S-, S, SS, A+ | 159–236 | Day & Night |
| [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | 4 | S, SS-, S+ | 188–218 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06451` | Moraveil Elder Scarab Swarm Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | SS- | 218 | 0.13 m | Day & Night | Like a typical Elder Scarab Swarm, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_06452` | Moraveil Elder Scarab Swarm Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | S+ | 203 | 0.11 m | Day & Night | Like a typical Elder Scarab Swarm, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_06453` | Great Labyrinth (Floors 91-120) Elder Scarab Swarm | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Adult | S | 188 | 0.1 m | Day & Night | A typical adult Elder Scarab Swarm of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_06454` | Moraveil Elder Scarab Swarm Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | S- | 173 | 0.09 m | Day & Night | Like a typical Elder Scarab Swarm, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_06455` | Great Labyrinth (Floors 91-120) Elder Scarab Swarm Alpha | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Alpha | SS- | 218 | 0.13 m | Day & Night | Like a typical Elder Scarab Swarm, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_06456` | Great Labyrinth (Floors 91-120) Elder Scarab Swarm Albino | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Albino | S+ | 203 | 0.1 m | Day & Night | Like a typical Elder Scarab Swarm, but a rare pale form with white skin or fur and red eyes. |
| `pop_06457` | Great Labyrinth (Floors 91-120) Elder Scarab Swarm Scarred | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Scarred | S+ | 203 | 0.11 m | Day & Night | Like a typical Elder Scarab Swarm, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_06458` | Moraveil Elder Scarab Swarm Albino | [[Regions/Moraveil\|Moraveil]] | Albino | S+ | 203 | 0.1 m | Day & Night | Like a typical Elder Scarab Swarm, but a rare pale form with white skin or fur and red eyes. |
| `pop_06459` | Moraveil Elder Scarab Swarm | [[Regions/Moraveil\|Moraveil]] | Adult | S | 188 | 0.1 m | Day & Night | A typical adult Elder Scarab Swarm of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_06460` | Moraveil Elder Scarab Swarm Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | SS | 236 | 0.14 m | Day & Night | Like a typical Elder Scarab Swarm, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_06461` | Moraveil Elder Scarab Swarm Runt | [[Regions/Moraveil\|Moraveil]] | Runt | A+ | 159 | 0.07 m | Day & Night | Like a typical Elder Scarab Swarm, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_swarm` · mesh `swarm_base` · material `chitin_gloss` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · triangle-based silhouette, sharp asymmetric spikes
