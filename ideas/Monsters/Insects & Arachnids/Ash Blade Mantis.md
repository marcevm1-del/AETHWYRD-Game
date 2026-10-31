---
type: monster
id: mon_ash_blade_mantis
family: "Insects & Arachnids"
rank: "C-"
tier: variant
tags: [monster, insects-arachnids]
---
# Ash Blade Mantis

![[mon_ash_blade_mantis_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ash_blade_mantis_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,294 tris · 1.819 × 2 × 1.128 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Ash Blade Mantis is a person-sized creature with a six-legged armored body, about 2 m long. Its chitin is rough, scarred and spiked, colored in iridescent green, with ember-orange markings. Survivors describe forearms shaped like curved scythes. It has eyes that catch torchlight like coins. Battle-worn plates and trophies hang from its body. It charges without hesitation, surrounded by heat-shimmer and drifting sparks. This Fire-attuned variant carries one extra elemental feature, like crystal spikes, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Variant of | [[Monsters/Insects & Arachnids/Blade Mantis\|Blade Mantis]] (elemental) |
| Rank · level | C- · 65 (56–76) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 2 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 8447 · 270 · 405 · 162 · 270 · 70 |
| XP · gold | 2395 · 521 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/hexapod\|hexapod]] · `anim_hexapod` |
| Habitats | [[Regions/Zaruma\|Zaruma]], [[Regions/Moraveil\|Moraveil]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Water. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/hexapod|hexapod]] (rigId); animation set `anim_hexapod`.
- **Dimensions:** 0.66 m high × 2 m long × 1.02 m wide; prefab scale 2.5.
- **Physics:** 352 kg, gravity ×1.4, poise 163, knockback resistance 0.34, death style `flip_legs_curl`.
- **Navigation:** speed 5.88 m/s, turn 354°/s, stopping distance 0.68 m.
- **Attack count:** 5; **signature:** forearms shaped like curved scythes.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Mandible Crush\|Mandible Crush]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Burrow Ambush\|Burrow Ambush]] | dash | 1.5 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Acid Spray\|Acid Spray]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Silk Snare\|Silk Snare]] | ranged | 0.4 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Ash Blade Mantis is a **menacing insectoid** encountered at C- rank, around level 65. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** forearms shaped like curved scythes. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Zaruma|Zaruma]], [[Regions/Moraveil|Moraveil]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_hexapod`, animation set `anim_hexapod`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Insects & Arachnids C|loot_insect_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Carapace Shard\|Carapace Shard]] | 60% | 1–3 |
| [[Items/Silk\|Silk]] | 30% | 1–1 |
| [[Items/Venom Sac\|Venom Sac]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Zaruma\|Zaruma]] | 5 | C-, D, C+, C, B- | 48–96 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 6 | D, C, D+, C-, C+ | 48–86 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06407` | Zaruma Ash Blade Mantis | [[Regions/Zaruma\|Zaruma]] | Adult | C- | 65 | 2 m | Day & Night | A typical adult Ash Blade Mantis of this region, with golden, grass-toned coloring. |
| `pop_06408` | Zaruma Ash Blade Mantis Runt | [[Regions/Zaruma\|Zaruma]] | Runt | D | 48 | 1.4 m | Day & Night | Like a typical Ash Blade Mantis, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_06409` | Moraveil Ash Blade Mantis Runt | [[Regions/Moraveil\|Moraveil]] | Runt | D | 48 | 1.4 m | Day & Night | Like a typical Ash Blade Mantis, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_06410` | Moraveil Ash Blade Mantis Albino | [[Regions/Moraveil\|Moraveil]] | Albino | C | 76 | 2 m | Day & Night | Like a typical Ash Blade Mantis, but a rare pale form with white skin or fur and red eyes. |
| `pop_06411` | Zaruma Ash Blade Mantis Alpha | [[Regions/Zaruma\|Zaruma]] | Alpha | C+ | 86 | 2.5 m | Day & Night | Like a typical Ash Blade Mantis, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_06412` | Zaruma Ash Blade Mantis Scarred | [[Regions/Zaruma\|Zaruma]] | Scarred | C | 76 | 2.2 m | Day & Night | Like a typical Ash Blade Mantis, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_06413` | Zaruma Ash Blade Mantis Elderborn | [[Regions/Zaruma\|Zaruma]] | Elderborn | B- | 96 | 2.7 m | Day & Night | Like a typical Ash Blade Mantis, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_06414` | Moraveil Ash Blade Mantis Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | D+ | 56 | 1.7 m | Day & Night | Like a typical Ash Blade Mantis, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_06415` | Moraveil Ash Blade Mantis | [[Regions/Moraveil\|Moraveil]] | Adult | C- | 65 | 2 m | Day & Night | A typical adult Ash Blade Mantis of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_06416` | Moraveil Ash Blade Mantis Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | C+ | 86 | 2.5 m | Day & Night | Like a typical Ash Blade Mantis, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_06417` | Moraveil Ash Blade Mantis Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | C | 76 | 2.2 m | Day & Night | Like a typical Ash Blade Mantis, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_hexapod` · mesh `hexapod_base` · material `chitin_gloss` · VFX `embers_heat_haze` · palette `#428044` `#2e5630` `#ff7a3d` · triangle-based silhouette, sharp asymmetric spikes
