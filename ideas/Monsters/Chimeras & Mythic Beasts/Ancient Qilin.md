---
type: monster
id: mon_ancient_qilin
family: "Chimeras & Mythic Beasts"
rank: "SS"
tier: variant
tags: [monster, chimeras-mythic-beasts]
---
# Ancient Qilin

![[mon_ancient_qilin_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ancient_qilin_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 19,998 tris · 1.191 × 4.501 × 2.702 m · local file `Game/Assets/_Game/Art/Models/Monsters/Chimeras & Mythic Beasts/mon_ancient_qilin.fbx`

> The Ancient Qilin is a large creature with a long-legged predatory quadruped build, about 4.5 m long. Its hide is smooth and clean, colored in lion-tawny, with gold markings. Look for scales, antlers and hooves that never bend the grass. It has wide curious eyes with star-shaped highlights. The air distorts slightly around its outline. It waddles, surrounded by soft radiance and floating motes of light. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Chimeras & Mythic Beasts|Chimeras & Mythic Beasts]] · Mythic Beast |
| Variant of | [[Monsters/Chimeras & Mythic Beasts/Qilin\|Qilin]] (ancient) |
| Rank · level | SS · 236 (218–253) |
| Menace | 1 · Charming |
| Element · weakness | Light · Dark |
| Size | 4.5 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 59574 · 1145 · 954 · 763 · 859 · 100 |
| XP · gold | 18792 · 3152 |
| Ring | 8 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Sky Archipelago\|Sky Archipelago]], [[Regions/Nox Dominion\|Nox Dominion]] |
| Genre | World Myth |
| Trope | Greek, Persian and East Asian mythic beasts |

**Field note:** Weak to Dark. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 2.93 m high × 4.5 m long × 0.72 m wide; prefab scale 1.125.
- **Physics:** 1731.4 kg, gravity ×1.08, poise 152, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 7.72 m/s, turn 151°/s, stopping distance 1.3 m.
- **Attack count:** 5; **signature:** scales, antlers and hooves that never bend the grass.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Many-Headed Bite\|Many-Headed Bite]] | melee | 1.5 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Ancient Qilin is a **charming mythic beast** encountered at SS rank, around level 236. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** scales, antlers and hooves that never bend the grass. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Sky Archipelago|Sky Archipelago]], [[Regions/Nox Dominion|Nox Dominion]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Chimeras & Mythic Beasts SS|loot_chimera_ss]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Chimera Heart\|Chimera Heart]] | 60% | 1–3 |
| [[Items/Mythic Horn\|Mythic Horn]] | 30% | 1–1 |
| [[Items/SS-Rank Monster Core\|SS-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Nox Dominion\|Nox Dominion]] | 5 | S+, SS-, SSS, SS, SS+ | 203–281 | Day |
| [[Regions/Sky Archipelago\|Sky Archipelago]] | 6 | S+, SSS, SS-, SS+, SS, SSS- | 203–281 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05081` | Nox Dominion Ancient Qilin Runt | [[Regions/Nox Dominion\|Nox Dominion]] | Runt | S+ | 203 | 3.15 m | Day | Like a typical Ancient Qilin, but smaller and scrappier than usual, with red-black coloring with faint ember veins. |
| `pop_05082` | Sky Archipelago Ancient Qilin Runt | [[Regions/Sky Archipelago\|Sky Archipelago]] | Runt | S+ | 203 | 3.15 m | Day | Like a typical Ancient Qilin, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_05083` | Sky Archipelago Ancient Qilin Elderborn | [[Regions/Sky Archipelago\|Sky Archipelago]] | Elderborn | SSS | 281 | 6.08 m | Day | Like a typical Ancient Qilin, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_05084` | Nox Dominion Ancient Qilin Juvenile | [[Regions/Nox Dominion\|Nox Dominion]] | Juvenile | SS- | 218 | 3.82 m | Day | Like a typical Ancient Qilin, but young, with brighter colors and unworn features, with red-black coloring with faint ember veins. |
| `pop_05085` | Sky Archipelago Ancient Qilin Juvenile | [[Regions/Sky Archipelago\|Sky Archipelago]] | Juvenile | SS- | 218 | 3.82 m | Day | Like a typical Ancient Qilin, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_05086` | Sky Archipelago Ancient Qilin Albino | [[Regions/Sky Archipelago\|Sky Archipelago]] | Albino | SS+ | 253 | 4.5 m | Day | Like a typical Ancient Qilin, but a rare pale form with white skin or fur and red eyes. |
| `pop_05087` | Sky Archipelago Ancient Qilin | [[Regions/Sky Archipelago\|Sky Archipelago]] | Adult | SS | 236 | 4.5 m | Day | A typical adult Ancient Qilin of this region, with dust-grey coloring and old rune scars. |
| `pop_05088` | Nox Dominion Ancient Qilin Elderborn | [[Regions/Nox Dominion\|Nox Dominion]] | Elderborn | SSS | 281 | 6.08 m | Day | Like a typical Ancient Qilin, but old and wise, with greying features and a cautious hunting style, with red-black coloring with faint ember veins. |
| `pop_05089` | Nox Dominion Ancient Qilin | [[Regions/Nox Dominion\|Nox Dominion]] | Adult | SS | 236 | 4.5 m | Day | A typical adult Ancient Qilin of this region, with red-black coloring with faint ember veins. |
| `pop_05090` | Sky Archipelago Ancient Qilin Alpha | [[Regions/Sky Archipelago\|Sky Archipelago]] | Alpha | SSS- | 267 | 5.63 m | Day | Like a typical Ancient Qilin, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_05091` | Nox Dominion Ancient Qilin Albino | [[Regions/Nox Dominion\|Nox Dominion]] | Albino | SS+ | 253 | 4.5 m | Day | Like a typical Ancient Qilin, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `mixed_hide` · VFX `holy_motes` · palette `#b48552` `#765435` `#ffd166` · circle-based, soft silhouette
