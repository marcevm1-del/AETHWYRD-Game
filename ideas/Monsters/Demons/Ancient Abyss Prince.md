---
type: monster
id: mon_ancient_abyss_prince
family: "Demons"
rank: "EX"
tier: variant
tags: [monster, demons, unique]
---
# Ancient Abyss Prince

![[mon_ancient_abyss_prince_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ancient_abyss_prince_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 19,998 tris · 8.146 × 5.167 × 6 m · local file `Game/Assets/_Game/Art/Models/Monsters/Demons/mon_ancient_abyss_prince.fbx`

> The Ancient Abyss Prince is a huge creature with an upright humanoid build, about 6 m tall. Its hide is rough, scarred and spiked, colored in char-black, with violet-edged markings. Its most striking feature is a crown of black flame and wings of torn night. It has narrow glowing eyes. Its presence is world-scale; the sky changes color when it appears. It strides with heavy steps, surrounded by warped air, as if space bends around it. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Demons|Demons]] · Demon |
| Variant of | [[Monsters/Demons/Abyss Prince\|Abyss Prince]] (ancient) |
| Rank · level | EX · 300 (300–300) |
| Menace | 3 · Menacing |
| Element · weakness | Void · Light |
| Size | 6 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 93400 · 1452 · 1210 · 968 · 1089 · 100 |
| XP · gold | 551660 · 4409 |
| Ring | 9 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Vesper\|Vesper]] |
| Genre | Abyssal |
| Trope | Demons as a people of the Abyss, not just evil (Frieren, Maoyuu) |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 6 m high × 1.8 m long × 1.92 m wide; prefab scale 3.333.
- **Physics:** 2808 kg, gravity ×1.05, poise 247, knockback resistance 0.57, death style `ragdoll`.
- **Navigation:** speed 9.91 m/s, turn 163°/s, stopping distance 1.42 m.
- **Attack count:** 5; **signature:** a crown of black flame and wings of torn night.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Hellfire Brand\|Hellfire Brand]] | magic | 1.4 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Null Rift\|Null Rift]] | magic | 1.5 | 10 s | Void | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Ancient Abyss Prince is a **menacing demon** encountered at EX rank, around level 300. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a crown of black flame and wings of torn night. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Vesper|Vesper]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Demons EX|loot_demon_ex]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Demon Core\|Demon Core]] | 60% | 1–3 |
| [[Items/Horn Shard\|Horn Shard]] | 30% | 1–1 |
| [[Items/Brimstone\|Brimstone]] | 15% | 1–1 |
| [[Items/EX-Rank Monster Core\|EX-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (1)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Vesper\|Vesper]] | 1 | EX | 300–300 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04788` | Ancient Abyss Prince | [[Regions/Vesper\|Vesper]] | Unique | EX | 300 | 6 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `demon_hide_emissive` · VFX `void_distortion` · palette `#4b4654` `#3e3944` `#8a7cff` · triangle-based silhouette, sharp asymmetric spikes
