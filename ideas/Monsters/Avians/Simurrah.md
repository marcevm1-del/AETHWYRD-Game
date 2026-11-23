---
type: monster
id: mon_simurrah
family: "Avians"
rank: "S"
tier: core
tags: [monster, avians]
---
# Simurrah

![[mon_simurrah_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_simurrah_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 30,000 tris · 9.93 × 18.038 × 20 m · local file `Game/Assets/_Game/Art/Models/Monsters/Avians/mon_simurrah.fbx`

> The Simurrah is a colossal creature with a feathered avian body, about 20 m tall. Its plumage is smooth and clean, colored in blue, with gold markings. Its most striking feature is a healing bird with peacock-eyed plumage. It has two bright dot eyes. Its regal silhouette is crowned by a halo-like ring of aura. It waddles, surrounded by soft radiance and floating motes of light.

| Field | Value |
|---|---|
| Family · type | [[Families/Avians|Avians]] · Avian |
| Rank · level | S · 188 (173–203) |
| Menace | 1 · Charming |
| Element · weakness | Light · Dark |
| Size | 20 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 49951 · 762 · 610 · 533 · 610 · 135 |
| XP · gold | 13063 · 2293 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/avian\|avian]] · `anim_avian` |
| Habitats | [[Regions/Heavenreach\|Heavenreach]], [[Regions/Shen-Lu\|Shen-Lu]] |
| Genre | High Fantasy |
| Trope | Griffons, harpies and phoenixes of classic fantasy |

**Field note:** Weak to Dark. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/avian|avian]] (rigId); animation set `anim_avian`.
- **Dimensions:** 9.2 m high × 20 m long × 34.4 m wide; prefab scale 33.333.
- **Physics:** 106400 kg, gravity ×0.9, poise 5748, knockback resistance 0.23, death style `tumble_feathers_burst`.
- **Navigation:** speed 12.01 m/s, turn 134°/s, stopping distance 4.4 m.
- **Attack count:** 5; **signature:** a healing bird with peacock-eyed plumage.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Peck\|Peck]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Swoop\|Swoop]] | dash | 1.4 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Screech\|Screech]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Feather Volley\|Feather Volley]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Simurrah is a **charming avian** encountered at S rank, around level 188. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a healing bird with peacock-eyed plumage. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Heavenreach|Heavenreach]], [[Regions/Shen-Lu|Shen-Lu]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_avian`, animation set `anim_avian`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Avians S|loot_avian_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Feather\|Feather]] | 60% | 1–3 |
| [[Items/Talon\|Talon]] | 30% | 1–1 |
| [[Items/Egg\|Egg]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Avians/Elder Simurrah|Elder Simurrah]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Shen-Lu\|Shen-Lu]] | 5 | S+, A+, S, SS | 159–236 | Day |
| [[Regions/Heavenreach\|Heavenreach]] | 6 | SS-, S+, SS, S, S- | 173–236 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02140` | Shen-Lu Simurrah Scarred | [[Regions/Shen-Lu\|Shen-Lu]] | Scarred | S+ | 203 | 22 m | Day | Like a typical Simurrah, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_02141` | Heavenreach Simurrah Alpha | [[Regions/Heavenreach\|Heavenreach]] | Alpha | SS- | 218 | 25 m | Day | Like a typical Simurrah, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_02142` | Shen-Lu Simurrah Runt | [[Regions/Shen-Lu\|Shen-Lu]] | Runt | A+ | 159 | 14 m | Day | Like a typical Simurrah, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_02143` | Shen-Lu Simurrah | [[Regions/Shen-Lu\|Shen-Lu]] | Adult | S | 188 | 20 m | Day | A typical adult Simurrah of this region, with slate-grey coloring and hardened hide. |
| `pop_02144` | Heavenreach Simurrah Scarred | [[Regions/Heavenreach\|Heavenreach]] | Scarred | S+ | 203 | 22 m | Day | Like a typical Simurrah, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_02145` | Heavenreach Simurrah Elderborn | [[Regions/Heavenreach\|Heavenreach]] | Elderborn | SS | 236 | 27 m | Day | Like a typical Simurrah, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_02146` | Heavenreach Simurrah | [[Regions/Heavenreach\|Heavenreach]] | Adult | S | 188 | 20 m | Day | A typical adult Simurrah of this region, with slate-grey coloring and hardened hide. |
| `pop_02147` | Shen-Lu Simurrah Elderborn | [[Regions/Shen-Lu\|Shen-Lu]] | Elderborn | SS | 236 | 27 m | Day | Like a typical Simurrah, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_02148` | Heavenreach Simurrah Juvenile | [[Regions/Heavenreach\|Heavenreach]] | Juvenile | S- | 173 | 17 m | Day | Like a typical Simurrah, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_02149` | Heavenreach Simurrah Albino | [[Regions/Heavenreach\|Heavenreach]] | Albino | S+ | 203 | 20 m | Day | Like a typical Simurrah, but a rare pale form with white skin or fur and red eyes. |
| `pop_02150` | Shen-Lu Simurrah Albino | [[Regions/Shen-Lu\|Shen-Lu]] | Albino | S+ | 203 | 20 m | Day | Like a typical Simurrah, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_avian` · mesh `avian_base` · material `feather_groom` · VFX `holy_motes` · palette `#506cb6` `#364a7e` `#ffd166` · circle-based, soft silhouette
