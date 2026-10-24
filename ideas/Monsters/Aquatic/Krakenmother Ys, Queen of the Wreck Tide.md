---
type: monster
id: mon_krakenmother_ys_queen_of_the_wreck_tide
family: "Aquatic"
rank: "S"
tier: core
tags: [monster, aquatic, tyrant, unique]
---
# Krakenmother Ys, Queen of the Wreck Tide

![[mon_krakenmother_ys_queen_of_the_wreck_tide_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_krakenmother_ys_queen_of_the_wreck_tide_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,898 tris · 34.452 × 40 × 45.496 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Krakenmother Ys, Queen of the Wreck Tide is a colossal creature with a tentacled, soft-bodied form, about 40 m long. Its scales and skin are patchy and subtly wrong, as if assembled from memory, colored in deep blues with a glassy shine. Look for a mother kraken wearing sunken ships like jewelry. It has pale, pupil-less eyes. Its regal silhouette is crowned by a halo-like ring of aura. It freezes whenever it is looked at, surrounded by fine mist and droplets that orbit it.

| Field | Value |
|---|---|
| Family · type | [[Families/Aquatic|Aquatic]] · Aquatic |
| Rank · level | S · 188 (173–203) |
| Menace | 4 · Dread |
| Element · weakness | Water · Lightning |
| Size | 40 m |
| Behaviour | Territorial (territorial_guard+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 68869 · 953 · 686 · 686 · 686 · 100 |
| XP · gold | 261258 · 2293 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/tentacled\|tentacled]] · `anim_cephalopod` |
| Habitats | [[Regions/Goldmere Coast\|Goldmere Coast]] |
| Tyrant | Yes |
| Genre | Seafaring |
| Trope | Sea kings and krakens (One Piece), sirens and merfolk |

**Field note:** Weak to Lightning. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/tentacled|tentacled]] (rigId); animation set `anim_cephalopod`.
- **Dimensions:** 22 m high × 40 m long × 48 m wide; prefab scale 13.333.
- **Physics:** 1344000 kg, gravity ×1, poise 10165, knockback resistance 0.88, death style `sink_limp`.
- **Navigation:** speed 21.7 m/s, turn 60°/s, stopping distance 8.4 m.
- **Attack count:** 5; **signature:** a mother kraken wearing sunken ships like jewelry.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Tentacle Slap\|Tentacle Slap]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Drag Under\|Drag Under]] | grab | 1.8 | 12 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Ink Cloud\|Ink Cloud]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Tidal Drag\|Tidal Drag]] | grab | 1.3 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Tide Lash\|Tide Lash]] | magic | 1.5 | 10 s | Water | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Krakenmother Ys, Queen of the Wreck Tide is a **dread aquatic** encountered at S rank, around level 188. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Lightning**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a mother kraken wearing sunken ships like jewelry. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Goldmere Coast|Goldmere Coast]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_cephalopod`, animation set `anim_cephalopod`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Aquatic S|loot_aquatic_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Fish Scale\|Fish Scale]] | 60% | 1–3 |
| [[Items/Pearl\|Pearl]] | 30% | 1–1 |
| [[Items/Ink Sac\|Ink Sac]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (1)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Goldmere Coast\|Goldmere Coast]] | 1 | S | 188–188 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06734` | Krakenmother Ys, Queen of the Wreck Tide | [[Regions/Goldmere Coast\|Goldmere Coast]] | Unique | S | 188 | 40 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_cephalopod` · mesh `cephalopod_base` · material `wet_scale` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · elongated, irregular silhouette; still-then-sudden timing
