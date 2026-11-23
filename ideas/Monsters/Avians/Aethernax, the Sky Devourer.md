---
type: monster
id: mon_aethernax_the_sky_devourer
family: "Avians"
rank: "EX"
tier: core
tags: [monster, avians, unique]
---
# Aethernax, the Sky Devourer

![[mon_aethernax_the_sky_devourer_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_aethernax_the_sky_devourer_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 30,000 tris · 198.905 × 487.711 × 400 m · local file `Game/Assets/_Game/Art/Models/Monsters/Avians/mon_aethernax_the_sky_devourer.fbx`

> The Aethernax, the Sky Devourer is a colossal creature with a tall, long-legged bird build, about 400 m tall. Its plumage is patchy and subtly wrong, as if assembled from memory, colored in pale buff, with violet-edged markings. Survivors describe wings that leave holes in the sky. It has pale, pupil-less eyes. Its presence is world-scale; the sky changes color when it appears. It freezes whenever it is looked at, surrounded by warped air, as if space bends around it.

| Field | Value |
|---|---|
| Family · type | [[Families/Avians|Avians]] · Avian |
| Rank · level | EX · 300 (300–300) |
| Menace | 4 · Dread |
| Element · weakness | Void · Light |
| Size | 400 m |
| Behaviour | Skittish (skittish_flee+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 139305 · 1210 · 968 · 847 · 968 · 135 |
| XP · gold | 551660 · 4409 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/avian\|avian]] · `anim_avian` |
| Habitats | [[Regions/Sky Archipelago\|Sky Archipelago]] |
| Genre | High Fantasy |
| Trope | Griffons, harpies and phoenixes of classic fantasy |

**Field note:** Weak to Light. Flees when hurt. Snares or ranged attacks work best.

## Motion implementation

- **Rig:** [[Systems/Rigs/avian|avian]] (rigId); animation set `anim_avian`.
- **Dimensions:** 184 m high × 400 m long × 688 m wide; prefab scale 666.667.
- **Physics:** 896000000 kg, gravity ×0.7, poise 865250, knockback resistance 0.32, death style `tumble_feathers_burst`.
- **Navigation:** speed 60 m/s, turn 60°/s, stopping distance 12.4 m.
- **Attack count:** 5; **signature:** wings that leave holes in the sky.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Peck\|Peck]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Swoop\|Swoop]] | dash | 1.4 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Screech\|Screech]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Feather Volley\|Feather Volley]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Null Rift\|Null Rift]] | magic | 1.5 | 10 s | Void | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Aethernax, the Sky Devourer is a **dread avian** encountered at EX rank, around level 300. Its documented behaviour is *Skittish* and its AI pattern is *skittish_flee+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** wings that leave holes in the sky. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Sky Archipelago|Sky Archipelago]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_avian`, animation set `anim_avian`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Avians EX|loot_avian_ex]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Feather\|Feather]] | 60% | 1–3 |
| [[Items/Talon\|Talon]] | 30% | 1–1 |
| [[Items/Egg\|Egg]] | 15% | 1–1 |
| [[Items/EX-Rank Monster Core\|EX-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (1)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Sky Archipelago\|Sky Archipelago]] | 1 | EX | 300–300 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02162` | Aethernax, the Sky Devourer | [[Regions/Sky Archipelago\|Sky Archipelago]] | Unique | EX | 300 | 400 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_avian` · mesh `avian_base` · material `feather_groom` · VFX `void_distortion` · palette `#c8b49a` `#8a7660` `#8a7cff` · elongated, irregular silhouette; still-then-sudden timing
