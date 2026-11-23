---
type: monster
id: mon_ancient_death_mantis
family: "Insects & Arachnids"
rank: "A"
tier: variant
tags: [monster, insects-arachnids]
---
# Ancient Death Mantis

![[mon_ancient_death_mantis_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ancient_death_mantis_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 19,996 tris · 4.079 × 4.5 × 2.297 m · local file `Game/Assets/_Game/Art/Models/Monsters/Insects & Arachnids/mon_ancient_death_mantis.fbx`

> The Ancient Death Mantis is a large creature with a low, wide insectoid build, about 4.5 m long. Its chitin is patchy and subtly wrong, as if assembled from memory, colored in blue-black, with violet markings. Guild sketches always show black chitin and a skull-like head. It has pale, pupil-less eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It moves in jerky stop-motion bursts, surrounded by shadows that lean toward it. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Variant of | [[Monsters/Insects & Arachnids/Death Mantis\|Death Mantis]] (ancient) |
| Rank · level | A · 146 (132–159) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 4.5 m |
| Behaviour | Swarm (swarm_surround+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 36965 · 594 · 891 · 356 · 594 · 70 |
| XP · gold | 8719 · 1611 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/hexapod\|hexapod]] · `anim_hexapod` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Iron Hold\|Iron Hold]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Light. Dangerous in numbers. Area attacks and chokepoints help.

## Motion implementation

- **Rig:** [[Systems/Rigs/hexapod|hexapod]] (rigId); animation set `anim_hexapod`.
- **Dimensions:** 1.49 m high × 4.5 m long × 2.29 m wide; prefab scale 5.625.
- **Physics:** 4009.5 kg, gravity ×1.4, poise 689, knockback resistance 0.4, death style `flip_legs_curl`.
- **Navigation:** speed 8.02 m/s, turn 236°/s, stopping distance 1.03 m.
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

Ancient Death Mantis is a **dread insectoid** encountered at A rank, around level 146. Its documented behaviour is *Swarm* and its AI pattern is *swarm_surround+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** black chitin and a skull-like head. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Iron Hold|Iron Hold]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_hexapod`, animation set `anim_hexapod`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Insects & Arachnids A|loot_insect_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Carapace Shard\|Carapace Shard]] | 60% | 1–3 |
| [[Items/Silk\|Silk]] | 30% | 1–1 |
| [[Items/Venom Sac\|Venom Sac]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Iron Hold\|Iron Hold]] | 6 | B+, A+, A-, A, S- | 120–173 | Night |
| [[Regions/Moraveil\|Moraveil]] | 5 | S, B+, A-, S-, A+ | 120–188 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06429` | Iron Hold Ancient Death Mantis Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | B+ | 120 | 3.15 m | Night | Like a typical Ancient Death Mantis, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_06430` | Iron Hold Ancient Death Mantis Albino | [[Regions/Iron Hold\|Iron Hold]] | Albino | A+ | 159 | 4.5 m | Night | Like a typical Ancient Death Mantis, but a rare pale form with white skin or fur and red eyes. |
| `pop_06431` | Moraveil Ancient Death Mantis Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | S | 188 | 6.08 m | Night | Like a typical Ancient Death Mantis, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_06432` | Iron Hold Ancient Death Mantis Juvenile | [[Regions/Iron Hold\|Iron Hold]] | Juvenile | A- | 132 | 3.82 m | Night | Like a typical Ancient Death Mantis, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_06433` | Iron Hold Ancient Death Mantis | [[Regions/Iron Hold\|Iron Hold]] | Adult | A | 146 | 4.5 m | Night | A typical adult Ancient Death Mantis of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_06434` | Iron Hold Ancient Death Mantis Alpha | [[Regions/Iron Hold\|Iron Hold]] | Alpha | S- | 173 | 5.63 m | Night | Like a typical Ancient Death Mantis, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_06435` | Moraveil Ancient Death Mantis Runt | [[Regions/Moraveil\|Moraveil]] | Runt | B+ | 120 | 3.15 m | Night | Like a typical Ancient Death Mantis, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_06436` | Moraveil Ancient Death Mantis Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | A- | 132 | 3.82 m | Night | Like a typical Ancient Death Mantis, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_06437` | Moraveil Ancient Death Mantis Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | S- | 173 | 5.63 m | Night | Like a typical Ancient Death Mantis, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_06438` | Moraveil Ancient Death Mantis Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | A+ | 159 | 4.95 m | Night | Like a typical Ancient Death Mantis, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_06439` | Iron Hold Ancient Death Mantis Scarred | [[Regions/Iron Hold\|Iron Hold]] | Scarred | A+ | 159 | 4.95 m | Night | Like a typical Ancient Death Mantis, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_hexapod` · mesh `hexapod_base` · material `chitin_gloss` · VFX `shadow_wisps` · palette `#47597b` `#344059` `#9a86d8` · elongated, irregular silhouette; still-then-sudden timing
