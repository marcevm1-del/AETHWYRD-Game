---
type: monster
id: mon_cavern_blade_mantis
family: "Insects & Arachnids"
rank: "C-"
tier: variant
tags: [monster, insects-arachnids]
---
# Cavern Blade Mantis

![[mon_cavern_blade_mantis_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_cavern_blade_mantis_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,398 tris · 2.101 × 2 × 1.837 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Cavern Blade Mantis is a person-sized creature with a segmented six-limbed frame, about 2 m long. Its chitin is rough, scarred and spiked, colored in ochre, clay and mossy stone. Guild sketches always show forearms shaped like curved scythes. It has eyes that catch torchlight like coins. Battle-worn plates and trophies hang from its body. It circles its prey, surrounded by pebbles that tremble and float near it. Adapted to cave lands, it has pale, light-starved coloring and oversized eyes.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Variant of | [[Monsters/Insects & Arachnids/Blade Mantis\|Blade Mantis]] (regional) |
| Rank · level | C- · 65 (56–76) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 2 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 8447 · 270 · 405 · 162 · 270 · 70 |
| XP · gold | 2395 · 521 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/hexapod\|hexapod]] · `anim_hexapod` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Iron Hold\|Iron Hold]], [[Regions/Umbravel\|Umbravel]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Wind. Dangerous in numbers. Area attacks and chokepoints help.

## Motion implementation

- **Rig:** [[Systems/Rigs/hexapod|hexapod]] (rigId); animation set `anim_hexapod`.
- **Dimensions:** 0.66 m high × 2 m long × 1.02 m wide; prefab scale 2.5.
- **Physics:** 457.6 kg, gravity ×1.54, poise 179, knockback resistance 0.49, death style `flip_legs_curl`.
- **Navigation:** speed 4.92 m/s, turn 354°/s, stopping distance 0.68 m.
- **Attack count:** 5; **signature:** forearms shaped like curved scythes.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Mandible Crush\|Mandible Crush]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Burrow Ambush\|Burrow Ambush]] | dash | 1.5 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Acid Spray\|Acid Spray]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Silk Snare\|Silk Snare]] | ranged | 0.4 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Cavern Blade Mantis is a **menacing insectoid** encountered at C- rank, around level 65. Its documented behaviour is *Swarm* and its AI pattern is *swarm_surround*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** forearms shaped like curved scythes. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Iron Hold|Iron Hold]], [[Regions/Umbravel|Umbravel]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Moraveil\|Moraveil]] | 5 | C, B-, D+, D | 48–96 | Day & Night |
| [[Regions/Iron Hold\|Iron Hold]] | 3 | C, D | 48–76 | Day & Night |
| [[Regions/Umbravel\|Umbravel]] | 3 | C, B- | 76–96 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03562` | Moraveil Cavern Blade Mantis Albino | [[Regions/Moraveil\|Moraveil]] | Albino | C | 76 | 2 m | Day & Night | Like a typical Cavern Blade Mantis, but a rare pale form with white skin or fur and red eyes. |
| `pop_03563` | Moraveil Cavern Blade Mantis Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | C | 76 | 2.2 m | Day & Night | Like a typical Cavern Blade Mantis, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_03564` | Iron Hold Cavern Blade Mantis Scarred | [[Regions/Iron Hold\|Iron Hold]] | Scarred | C | 76 | 2.2 m | Day & Night | Like a typical Cavern Blade Mantis, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_03565` | Moraveil Cavern Blade Mantis Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | B- | 96 | 2.7 m | Day & Night | Like a typical Cavern Blade Mantis, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_03566` | Moraveil Cavern Blade Mantis Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | D+ | 56 | 1.7 m | Day & Night | Like a typical Cavern Blade Mantis, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_03567` | Iron Hold Cavern Blade Mantis Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | D | 48 | 1.4 m | Day & Night | Like a typical Cavern Blade Mantis, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_03568` | Umbravel Cavern Blade Mantis Scarred | [[Regions/Umbravel\|Umbravel]] | Scarred | C | 76 | 2.2 m | Day & Night | Like a typical Cavern Blade Mantis, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_03569` | Moraveil Cavern Blade Mantis Runt | [[Regions/Moraveil\|Moraveil]] | Runt | D | 48 | 1.4 m | Day & Night | Like a typical Cavern Blade Mantis, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_03570` | Iron Hold Cavern Blade Mantis Albino | [[Regions/Iron Hold\|Iron Hold]] | Albino | C | 76 | 2 m | Day & Night | Like a typical Cavern Blade Mantis, but a rare pale form with white skin or fur and red eyes. |
| `pop_03571` | Umbravel Cavern Blade Mantis Albino | [[Regions/Umbravel\|Umbravel]] | Albino | C | 76 | 2 m | Day & Night | Like a typical Cavern Blade Mantis, but a rare pale form with white skin or fur and red eyes. |
| `pop_03572` | Umbravel Cavern Blade Mantis Elderborn | [[Regions/Umbravel\|Umbravel]] | Elderborn | B- | 96 | 2.7 m | Day & Night | Like a typical Cavern Blade Mantis, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_hexapod` · mesh `hexapod_base` · material `chitin_gloss` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · triangle-based silhouette, sharp asymmetric spikes
