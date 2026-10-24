---
type: monster
id: mon_elder_simurrah
family: "Avians"
rank: "SS"
tier: variant
tags: [monster, avians]
---
# Elder Simurrah

> The Elder Simurrah is a colossal creature with a feathered avian body, about 32 m tall. Its plumage is smooth and clean, colored in warm gold and pearl white. Look for a healing bird with peacock-eyed plumage. It has big round glossy eyes. The air distorts slightly around its outline. It hops in little bursts, surrounded by soft radiance and floating motes of light. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Avians|Avians]] · Avian |
| Variant of | [[Monsters/Avians/Simurrah\|Simurrah]] (elder) |
| Rank · level | SS · 236 (218–253) |
| Menace | 1 · Charming |
| Element · weakness | Light · Dark |
| Size | 32 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 78356 · 954 · 763 · 668 · 763 · 135 |
| XP · gold | 18792 · 3152 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/avian\|avian]] · `anim_avian` |
| Habitats | [[Regions/Sky Archipelago\|Sky Archipelago]] |
| Genre | High Fantasy |
| Trope | Griffons, harpies and phoenixes of classic fantasy |

**Field note:** Weak to Dark. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/avian|avian]] (rigId); animation set `anim_avian`.
- **Dimensions:** 14.72 m high × 32 m long × 55.04 m wide; prefab scale 53.333.
- **Physics:** 435814.4 kg, gravity ×0.9, poise 12860, knockback resistance 0.26, death style `tumble_feathers_burst`.
- **Navigation:** speed 13.81 m/s, turn 106°/s, stopping distance 6.8 m.
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

Elder Simurrah is a **charming avian** encountered at SS rank, around level 236. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a healing bird with peacock-eyed plumage. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Sky Archipelago|Sky Archipelago]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_avian`, animation set `anim_avian`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Avians SS|loot_avian_ss]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Feather\|Feather]] | 60% | 1–3 |
| [[Items/Talon\|Talon]] | 30% | 1–1 |
| [[Items/Egg\|Egg]] | 15% | 1–1 |
| [[Items/SS-Rank Monster Core\|SS-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (7)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Sky Archipelago\|Sky Archipelago]] | 7 | SSS, SS-, SS+, S+, SS, SSS- | 203–281 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04997` | Sky Archipelago Elder Simurrah Elderborn | [[Regions/Sky Archipelago\|Sky Archipelago]] | Elderborn | SSS | 281 | 43.2 m | Day | Like a typical Elder Simurrah, but old and wise, with greying features and a cautious hunting style, with cloud-pale coloring and lighter bones. |
| `pop_04998` | Sky Archipelago Elder Simurrah Juvenile | [[Regions/Sky Archipelago\|Sky Archipelago]] | Juvenile | SS- | 218 | 27.2 m | Day | Like a typical Elder Simurrah, but young, with brighter colors and unworn features, with cloud-pale coloring and lighter bones. |
| `pop_04999` | Sky Archipelago Elder Simurrah Scarred | [[Regions/Sky Archipelago\|Sky Archipelago]] | Scarred | SS+ | 253 | 35.2 m | Day | Like a typical Elder Simurrah, but covered in old battle scars, with cloud-pale coloring and lighter bones. |
| `pop_05000` | Sky Archipelago Elder Simurrah Runt | [[Regions/Sky Archipelago\|Sky Archipelago]] | Runt | S+ | 203 | 22.4 m | Day | Like a typical Elder Simurrah, but smaller and scrappier than usual, with cloud-pale coloring and lighter bones. |
| `pop_05001` | Sky Archipelago Elder Simurrah | [[Regions/Sky Archipelago\|Sky Archipelago]] | Adult | SS | 236 | 32 m | Day | A typical adult Elder Simurrah of this region, with cloud-pale coloring and lighter bones. |
| `pop_05002` | Sky Archipelago Elder Simurrah Albino | [[Regions/Sky Archipelago\|Sky Archipelago]] | Albino | SS+ | 253 | 32 m | Day | Like a typical Elder Simurrah, but a rare pale form with white skin or fur and red eyes. |
| `pop_05003` | Sky Archipelago Elder Simurrah Alpha | [[Regions/Sky Archipelago\|Sky Archipelago]] | Alpha | SSS- | 267 | 40 m | Day | Like a typical Elder Simurrah, but larger and scarred, and others of its kind follow it, with cloud-pale coloring and lighter bones. |

## Design recipe

Rig `rig_avian` · mesh `avian_base` · material `feather_groom` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · circle-based, soft silhouette
