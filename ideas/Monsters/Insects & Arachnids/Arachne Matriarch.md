---
type: monster
id: mon_arachne_matriarch
family: "Insects & Arachnids"
rank: "S"
tier: core
tags: [monster, insects-arachnids]
---
# Arachne Matriarch

![[mon_arachne_matriarch_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_arachne_matriarch_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Arachne Matriarch is a huge creature with a squat, many-legged arachnid build, about 8 m long. Its chitin is patchy and subtly wrong, as if assembled from memory, colored in ink black with bruised violet. Survivors describe a crown of silk and eight eyes like jewels. It has pale, pupil-less eyes. Its regal silhouette is crowned by a halo-like ring of aura. It freezes whenever it is looked at, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Rank · level | S · 188 (173–203) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 8 m |
| Behaviour | Swarm (swarm_surround+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 39076 · 762 · 610 · 533 · 610 · 135 |
| XP · gold | 13063 · 2293 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/arachnid\|arachnid]] · `anim_octopod` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/The Maw\|The Maw]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Light. Dangerous in numbers. Area attacks and chokepoints help.

## Motion implementation

- **Rig:** [[Systems/Rigs/arachnid|arachnid]] (rigId); animation set `anim_octopod`.
- **Dimensions:** 2.24 m high × 8 m long × 5.47 m wide; prefab scale 8.
- **Physics:** 16896 kg, gravity ×1.4, poise 1478, knockback resistance 0.38, death style `flip_legs_curl`.
- **Navigation:** speed 15.13 m/s, turn 212°/s, stopping distance 2.4 m.
- **Attack count:** 5; **signature:** a crown of silk and eight eyes like jewels.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Fang Bite\|Fang Bite]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Web Shot\|Web Shot]] | ranged | 0.5 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ceiling Drop\|Ceiling Drop]] | dash | 1.7 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Silk Snare\|Silk Snare]] | ranged | 0.4 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Arachne Matriarch is a **dread insectoid** encountered at S rank, around level 188. Its documented behaviour is *Swarm* and its AI pattern is *swarm_surround+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a crown of silk and eight eyes like jewels. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/The Maw|The Maw]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_octopod`, animation set `anim_octopod`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Insects & Arachnids S|loot_insect_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Carapace Shard\|Carapace Shard]] | 60% | 1–3 |
| [[Items/Silk\|Silk]] | 30% | 1–1 |
| [[Items/Venom Sac\|Venom Sac]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Insects & Arachnids/Greater Arachne Matriarch|Greater Arachne Matriarch]]
- [[Monsters/Insects & Arachnids/Sky Arachne Matriarch|Sky Arachne Matriarch]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Moraveil\|Moraveil]] | 7 | S-, S, SS-, SS, S+, A+ | 159–236 | Night |
| [[Regions/The Maw\|The Maw]] | 4 | SS-, S+, SS, A+ | 159–236 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00718` | Moraveil Arachne Matriarch Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | S- | 173 | 6.8 m | Night | Like a typical Arachne Matriarch, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_00719` | The Maw Arachne Matriarch Alpha | [[Regions/The Maw\|The Maw]] | Alpha | SS- | 218 | 10 m | Night | Like a typical Arachne Matriarch, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_00720` | Moraveil Arachne Matriarch | [[Regions/Moraveil\|Moraveil]] | Adult | S | 188 | 8 m | Night | A typical adult Arachne Matriarch of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_00721` | Moraveil Arachne Matriarch Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | SS- | 218 | 10 m | Night | Like a typical Arachne Matriarch, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_00722` | Moraveil Arachne Matriarch Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | SS | 236 | 10.8 m | Night | Like a typical Arachne Matriarch, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_00723` | Moraveil Arachne Matriarch Albino | [[Regions/Moraveil\|Moraveil]] | Albino | S+ | 203 | 8 m | Night | Like a typical Arachne Matriarch, but a rare pale form with white skin or fur and red eyes. |
| `pop_00724` | The Maw Arachne Matriarch Scarred | [[Regions/The Maw\|The Maw]] | Scarred | S+ | 203 | 8.8 m | Night | Like a typical Arachne Matriarch, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_00725` | Moraveil Arachne Matriarch Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | S+ | 203 | 8.8 m | Night | Like a typical Arachne Matriarch, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_00726` | Moraveil Arachne Matriarch Runt | [[Regions/Moraveil\|Moraveil]] | Runt | A+ | 159 | 5.6 m | Night | Like a typical Arachne Matriarch, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_00727` | The Maw Arachne Matriarch Elderborn | [[Regions/The Maw\|The Maw]] | Elderborn | SS | 236 | 10.8 m | Night | Like a typical Arachne Matriarch, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_00728` | The Maw Arachne Matriarch Runt | [[Regions/The Maw\|The Maw]] | Runt | A+ | 159 | 5.6 m | Night | Like a typical Arachne Matriarch, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_octopod` · mesh `octopod_base` · material `chitin_gloss` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · elongated, irregular silhouette; still-then-sudden timing
