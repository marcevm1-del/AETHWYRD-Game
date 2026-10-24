---
type: monster
id: mon_death_mantis
family: "Insects & Arachnids"
rank: "B"
tier: core
tags: [monster, insects-arachnids]
---
# Death Mantis

> The Death Mantis is a large creature with a segmented six-limbed frame, about 3 m long. Its chitin is patchy and subtly wrong, as if assembled from memory, colored in ink black with bruised violet. Its most striking feature is black chitin and a skull-like head. It has eyes set slightly too far apart. Faint runes glow along its body when it fights. It glides without moving its legs, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Rank · level | B · 108 (96–120) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 3 m |
| Behaviour | Swarm (swarm_surround+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 20627 · 442 · 663 · 265 · 442 · 70 |
| XP · gold | 5386 · 1057 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/hexapod\|hexapod]] · `anim_hexapod` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Iron Hold\|Iron Hold]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Light. Dangerous in numbers. Area attacks and chokepoints help.

## Motion implementation

- **Rig:** [[Systems/Rigs/hexapod|hexapod]] (rigId); animation set `anim_hexapod`.
- **Dimensions:** 0.99 m high × 3 m long × 1.52 m wide; prefab scale 3.75.
- **Physics:** 1188 kg, gravity ×1.4, poise 338, knockback resistance 0.37, death style `flip_legs_curl`.
- **Navigation:** speed 6.55 m/s, turn 289°/s, stopping distance 0.82 m.
- **Attack count:** 5; **signature:** black chitin and a skull-like head.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Mandible Crush\|Mandible Crush]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Burrow Ambush\|Burrow Ambush]] | dash | 1.5 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Acid Spray\|Acid Spray]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Silk Snare\|Silk Snare]] | ranged | 0.4 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Death Mantis is a **dread insectoid** encountered at B rank, around level 108. Its documented behaviour is *Swarm* and its AI pattern is *swarm_surround+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** black chitin and a skull-like head. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Strife Marches|Strife Marches]], [[Regions/Iron Hold|Iron Hold]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_hexapod`, animation set `anim_hexapod`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Insects & Arachnids B|loot_insect_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Carapace Shard\|Carapace Shard]] | 60% | 1–3 |
| [[Items/Silk\|Silk]] | 30% | 1–1 |
| [[Items/Venom Sac\|Venom Sac]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Insects & Arachnids/Gale Death Mantis|Gale Death Mantis]]
- [[Monsters/Insects & Arachnids/Ancient Death Mantis|Ancient Death Mantis]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Strife Marches\|Strife Marches]] | 3 | B, C+, B- | 86–108 | Night |
| [[Regions/Iron Hold\|Iron Hold]] | 5 | A-, B, C+, B+ | 86–132 | Night |
| [[Regions/Moraveil\|Moraveil]] | 3 | B+, A-, A | 120–146 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00685` | Strife Marches Death Mantis | [[Regions/Strife Marches\|Strife Marches]] | Adult | B | 108 | 3 m | Night | A typical adult Death Mantis of this region, with golden, grass-toned coloring. |
| `pop_00686` | Iron Hold Death Mantis Alpha | [[Regions/Iron Hold\|Iron Hold]] | Alpha | A- | 132 | 3.75 m | Night | Like a typical Death Mantis, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_00687` | Strife Marches Death Mantis Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | C+ | 86 | 2.1 m | Night | Like a typical Death Mantis, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_00688` | Iron Hold Death Mantis | [[Regions/Iron Hold\|Iron Hold]] | Adult | B | 108 | 3 m | Night | A typical adult Death Mantis of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_00689` | Iron Hold Death Mantis Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | C+ | 86 | 2.1 m | Night | Like a typical Death Mantis, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_00690` | Moraveil Death Mantis Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | B+ | 120 | 3.3 m | Night | Like a typical Death Mantis, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_00691` | Strife Marches Death Mantis Juvenile | [[Regions/Strife Marches\|Strife Marches]] | Juvenile | B- | 96 | 2.55 m | Night | Like a typical Death Mantis, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_00692` | Iron Hold Death Mantis Scarred | [[Regions/Iron Hold\|Iron Hold]] | Scarred | B+ | 120 | 3.3 m | Night | Like a typical Death Mantis, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_00693` | Moraveil Death Mantis Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | A- | 132 | 3.75 m | Night | Like a typical Death Mantis, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_00694` | Iron Hold Death Mantis Albino | [[Regions/Iron Hold\|Iron Hold]] | Albino | B+ | 120 | 3 m | Night | Like a typical Death Mantis, but a rare pale form with white skin or fur and red eyes. |
| `pop_00695` | Moraveil Death Mantis Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | A | 146 | 4.05 m | Night | Like a typical Death Mantis, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_hexapod` · mesh `hexapod_base` · material `chitin_gloss` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · elongated, irregular silhouette; still-then-sudden timing
