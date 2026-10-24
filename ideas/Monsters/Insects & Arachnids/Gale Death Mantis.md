---
type: monster
id: mon_gale_death_mantis
family: "Insects & Arachnids"
rank: "B+"
tier: variant
tags: [monster, insects-arachnids]
---
# Gale Death Mantis

![[mon_gale_death_mantis_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_gale_death_mantis_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,342 tris · 1.574 × 3 × 1.181 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Gale Death Mantis is a large creature with a six-legged armored body, about 3 m long. Its chitin is patchy and subtly wrong, as if assembled from memory, colored in pale jade and cloud white. Survivors describe black chitin and a skull-like head. It has eyes that never blink. Faint runes glow along its body when it fights. It freezes whenever it is looked at, surrounded by swirling leaves and a constant breeze. This Wind-attuned variant carries one extra elemental feature, like element-scarred hide, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Variant of | [[Monsters/Insects & Arachnids/Death Mantis\|Death Mantis]] (elemental) |
| Rank · level | B+ · 120 (108–132) |
| Menace | 4 · Dread |
| Element · weakness | Wind · Fire |
| Size | 3 m |
| Behaviour | Territorial (territorial_guard+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 24138 · 490 · 735 · 294 · 490 · 70 |
| XP · gold | 6373 · 1225 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/hexapod\|hexapod]] · `anim_hexapod` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Zaruma\|Zaruma]], [[Regions/Strife Marches\|Strife Marches]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Fire. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/hexapod|hexapod]] (rigId); animation set `anim_hexapod`.
- **Dimensions:** 0.99 m high × 3 m long × 1.52 m wide; prefab scale 3.75.
- **Physics:** 1069.2 kg, gravity ×1.12, poise 325, knockback resistance 0.37, death style `flip_legs_curl`.
- **Navigation:** speed 6.42 m/s, turn 289°/s, stopping distance 0.82 m.
- **Attack count:** 5; **signature:** black chitin and a skull-like head.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Mandible Crush\|Mandible Crush]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Burrow Ambush\|Burrow Ambush]] | dash | 1.5 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Acid Spray\|Acid Spray]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Silk Snare\|Silk Snare]] | ranged | 0.4 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Gale Cutter\|Gale Cutter]] | magic | 1.5 | 10 s | Wind | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Gale Death Mantis is a **dread insectoid** encountered at B+ rank, around level 120. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** black chitin and a skull-like head. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Zaruma|Zaruma]], [[Regions/Strife Marches|Strife Marches]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_hexapod`, animation set `anim_hexapod`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Insects & Arachnids B|loot_insect_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Carapace Shard\|Carapace Shard]] | 60% | 1–3 |
| [[Items/Silk\|Silk]] | 30% | 1–1 |
| [[Items/Venom Sac\|Venom Sac]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Strife Marches\|Strife Marches]] | 6 | B-, B, A+, B+, A, A- | 96–159 | Night |
| [[Regions/Moraveil\|Moraveil]] | 2 | B-, A- | 96–132 | Night |
| [[Regions/Zaruma\|Zaruma]] | 3 | B-, B+, A- | 96–132 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03584` | Strife Marches Gale Death Mantis Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | B- | 96 | 2.1 m | Night | Like a typical Gale Death Mantis, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_03585` | Moraveil Gale Death Mantis Runt | [[Regions/Moraveil\|Moraveil]] | Runt | B- | 96 | 2.1 m | Night | Like a typical Gale Death Mantis, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_03586` | Strife Marches Gale Death Mantis Juvenile | [[Regions/Strife Marches\|Strife Marches]] | Juvenile | B | 108 | 2.55 m | Night | Like a typical Gale Death Mantis, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_03587` | Strife Marches Gale Death Mantis Elderborn | [[Regions/Strife Marches\|Strife Marches]] | Elderborn | A+ | 159 | 4.05 m | Night | Like a typical Gale Death Mantis, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_03588` | Strife Marches Gale Death Mantis | [[Regions/Strife Marches\|Strife Marches]] | Adult | B+ | 120 | 3 m | Night | A typical adult Gale Death Mantis of this region, with golden, grass-toned coloring. |
| `pop_03589` | Moraveil Gale Death Mantis Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | A- | 132 | 3.3 m | Night | Like a typical Gale Death Mantis, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_03590` | Strife Marches Gale Death Mantis Alpha | [[Regions/Strife Marches\|Strife Marches]] | Alpha | A | 146 | 3.75 m | Night | Like a typical Gale Death Mantis, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_03591` | Strife Marches Gale Death Mantis Scarred | [[Regions/Strife Marches\|Strife Marches]] | Scarred | A- | 132 | 3.3 m | Night | Like a typical Gale Death Mantis, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_03592` | Zaruma Gale Death Mantis Runt | [[Regions/Zaruma\|Zaruma]] | Runt | B- | 96 | 2.1 m | Night | Like a typical Gale Death Mantis, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_03593` | Zaruma Gale Death Mantis | [[Regions/Zaruma\|Zaruma]] | Adult | B+ | 120 | 3 m | Night | A typical adult Gale Death Mantis of this region, with golden, grass-toned coloring. |
| `pop_03594` | Zaruma Gale Death Mantis Scarred | [[Regions/Zaruma\|Zaruma]] | Scarred | A- | 132 | 3.3 m | Night | Like a typical Gale Death Mantis, but covered in old battle scars, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_hexapod` · mesh `hexapod_base` · material `chitin_gloss` · VFX `wind_ribbons` · palette `#a8e6cf` `#dcedc1` `#5b8c85` · elongated, irregular silhouette; still-then-sudden timing
