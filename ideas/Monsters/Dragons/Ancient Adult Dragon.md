---
type: monster
id: mon_ancient_adult_dragon
family: "Dragons"
rank: "SS"
tier: variant
tags: [monster, dragons]
---
# Ancient Adult Dragon

![[mon_ancient_adult_dragon_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ancient_adult_dragon_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 30,000 tris · 59.988 × 37.498 × 26.75 m · local file `Game/Assets/_Game/Art/Models/Monsters/Dragons/mon_ancient_adult_dragon.fbx`

> The Ancient Adult Dragon is a colossal creature with an ancient, serpentine dragon body, about 37.5 m long. Its scales are rough, scarred and spiked, colored in iron-grey, with electric-yellow markings. Look for cathedral wings and a voice that shakes stone. It has narrow glowing eyes. The air distorts slightly around its outline. It charges without hesitation, surrounded by crackling arcs that jump across its body. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Dragons|Dragons]] · Dragon |
| Variant of | [[Monsters/Dragons/Adult Dragon\|Adult Dragon]] (ancient) |
| Rank · level | SS · 236 (218–253) |
| Menace | 3 · Menacing |
| Element · weakness | Lightning · Earth |
| Size | 37.5 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 143183 · 1240 · 1145 · 1240 · 1145 · 100 |
| XP · gold | 18792 · 3152 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/dragon\|dragon]] · `anim_dragon` |
| Habitats | [[Regions/Sky Archipelago\|Sky Archipelago]], [[Regions/Nox Dominion\|Nox Dominion]] |
| Genre | High Fantasy |
| Trope | Dragons as proud, intelligent apex beings; wyverns as their lesser kin |

**Field note:** Weak to Earth. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/dragon|dragon]] (rigId); animation set `anim_dragon`.
- **Dimensions:** 21 m high × 37.5 m long × 52.88 m wide; prefab scale 3.125.
- **Physics:** 363867.2 kg, gravity ×1, poise 1450, knockback resistance 1, death style `cinematic_collapse`.
- **Navigation:** speed 14.1 m/s, turn 98°/s, stopping distance 3.4 m.
- **Attack count:** 6; **signature:** cathedral wings and a voice that shakes stone.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Claw\|Claw]] | melee | 1.4 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Breath\|Breath]] | aoe | 2.2 | 14 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wing Gust\|Wing Gust]] | aoe | 1 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Tail Blade\|Tail Blade]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wing Buffet\|Wing Buffet]] | aoe | 1.1 | 9 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Static Arc\|Static Arc]] | magic | 1.5 | 10 s | Lightning | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Ancient Adult Dragon is a **menacing dragon** encountered at SS rank, around level 236. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Earth**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** cathedral wings and a voice that shakes stone. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Sky Archipelago|Sky Archipelago]], [[Regions/Nox Dominion|Nox Dominion]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_dragon`, animation set `anim_dragon`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Dragons SS|loot_draconic_ss]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dragon Scale\|Dragon Scale]] | 60% | 1–3 |
| [[Items/Dragon Blood\|Dragon Blood]] | 30% | 1–1 |
| [[Items/Dragon Heart\|Dragon Heart]] | 15% | 1–1 |
| [[Items/SS-Rank Monster Core\|SS-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Nox Dominion\|Nox Dominion]] | 6 | SSS, SS+, SS, S+, SSS- | 203–281 | Day & Night |
| [[Regions/Sky Archipelago\|Sky Archipelago]] | 5 | SSS-, SS+, SS, SSS | 236–281 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04307` | Nox Dominion Ancient Adult Dragon Elderborn | [[Regions/Nox Dominion\|Nox Dominion]] | Elderborn | SSS | 281 | 50.63 m | Day & Night | Like a typical Ancient Adult Dragon, but old and wise, with greying features and a cautious hunting style, with ash-dark coloring with glowing cracks. |
| `pop_04308` | Nox Dominion Ancient Adult Dragon Albino | [[Regions/Nox Dominion\|Nox Dominion]] | Albino | SS+ | 253 | 37.5 m | Day & Night | Like a typical Ancient Adult Dragon, but a rare pale form with white skin or fur and red eyes. |
| `pop_04309` | Sky Archipelago Ancient Adult Dragon Alpha | [[Regions/Sky Archipelago\|Sky Archipelago]] | Alpha | SSS- | 267 | 46.88 m | Day & Night | Like a typical Ancient Adult Dragon, but larger and scarred, and others of its kind follow it, with cloud-pale coloring and lighter bones. |
| `pop_04310` | Sky Archipelago Ancient Adult Dragon Scarred | [[Regions/Sky Archipelago\|Sky Archipelago]] | Scarred | SS+ | 253 | 41.25 m | Day & Night | Like a typical Ancient Adult Dragon, but covered in old battle scars, with cloud-pale coloring and lighter bones. |
| `pop_04311` | Nox Dominion Ancient Adult Dragon | [[Regions/Nox Dominion\|Nox Dominion]] | Adult | SS | 236 | 37.5 m | Day & Night | A typical adult Ancient Adult Dragon of this region, with ash-dark coloring with glowing cracks. |
| `pop_04312` | Sky Archipelago Ancient Adult Dragon | [[Regions/Sky Archipelago\|Sky Archipelago]] | Adult | SS | 236 | 37.5 m | Day & Night | A typical adult Ancient Adult Dragon of this region, with cloud-pale coloring and lighter bones. |
| `pop_04313` | Nox Dominion Ancient Adult Dragon Runt | [[Regions/Nox Dominion\|Nox Dominion]] | Runt | S+ | 203 | 26.25 m | Day & Night | Like a typical Ancient Adult Dragon, but smaller and scrappier than usual, with ash-dark coloring with glowing cracks. |
| `pop_04314` | Nox Dominion Ancient Adult Dragon Scarred | [[Regions/Nox Dominion\|Nox Dominion]] | Scarred | SS+ | 253 | 41.25 m | Day & Night | Like a typical Ancient Adult Dragon, but covered in old battle scars, with ash-dark coloring with glowing cracks. |
| `pop_04315` | Sky Archipelago Ancient Adult Dragon Elderborn | [[Regions/Sky Archipelago\|Sky Archipelago]] | Elderborn | SSS | 281 | 50.63 m | Day & Night | Like a typical Ancient Adult Dragon, but old and wise, with greying features and a cautious hunting style, with cloud-pale coloring and lighter bones. |
| `pop_04316` | Sky Archipelago Ancient Adult Dragon Albino | [[Regions/Sky Archipelago\|Sky Archipelago]] | Albino | SS+ | 253 | 37.5 m | Day & Night | Like a typical Ancient Adult Dragon, but a rare pale form with white skin or fur and red eyes. |
| `pop_04317` | Nox Dominion Ancient Adult Dragon Alpha | [[Regions/Nox Dominion\|Nox Dominion]] | Alpha | SSS- | 267 | 46.88 m | Day & Night | Like a typical Ancient Adult Dragon, but larger and scarred, and others of its kind follow it, with ash-dark coloring with glowing cracks. |

## Design recipe

Rig `rig_dragon` · mesh `dragon_base` · material `dragon_scale` · VFX `arc_sparks` · palette `#726f80` `#504e5a` `#ffe14d` · triangle-based silhouette, sharp asymmetric spikes
