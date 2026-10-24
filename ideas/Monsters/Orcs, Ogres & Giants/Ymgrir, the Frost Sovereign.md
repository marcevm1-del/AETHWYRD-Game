---
type: monster
id: mon_ymgrir_the_frost_sovereign
family: "Orcs, Ogres & Giants"
rank: "S-"
tier: core
tags: [monster, orcs-ogres-giants, tyrant, unique]
---
# Ymgrir, the Frost Sovereign

> The Ymgrir, the Frost Sovereign is a huge creature with a massive hunched brute frame, about 11 m tall. Its hide is rough, scarred and spiked, colored in pale blues and frost-white. Survivors describe a crown of glacier ice and a voice that starts avalanches. It has narrow glowing eyes. Its regal silhouette is crowned by a halo-like ring of aura. It strides with heavy steps, surrounded by falling snow motes and frosted ground where it steps.

| Field | Value |
|---|---|
| Family · type | [[Families/Orcs, Ogres & Giants|Orcs, Ogres & Giants]] · Giant |
| Rank · level | S- · 173 (159–188) |
| Menace | 3 · Menacing |
| Element · weakness | Ice · Fire |
| Size | 11 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 62203 · 702 · 1053 · 421 · 702 · 70 |
| XP · gold | 228733 · 2042 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/large_biped\|large_biped]] · `anim_large_biped` |
| Habitats | [[Regions/Frostveil\|Frostveil]] |
| Tyrant | Yes |
| Genre | Classic Fantasy |
| Trope | Orc warbands and the Orc Disaster that devours its way to power (Tensura) |

**Field note:** Weak to Fire. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/large_biped|large_biped]] (rigId); animation set `anim_large_biped`.
- **Dimensions:** 11 m high × 3.3 m long × 4.62 m wide; prefab scale 3.143.
- **Physics:** 26353.8 kg, gravity ×1.37, poise 542, knockback resistance 0.93, death style `heavy_fall_dust`.
- **Navigation:** speed 10.26 m/s, turn 115°/s, stopping distance 2.6 m.
- **Attack count:** 5; **signature:** a crown of glacier ice and a voice that starts avalanches.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stomp\|Stomp]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Club Slam\|Club Slam]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grab and Throw\|Grab and Throw]] | grab | 2 | 14 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/War Cry\|War Cry]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Frost Breath\|Frost Breath]] | magic | 1.5 | 10 s | Ice | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Ymgrir, the Frost Sovereign is a **menacing giant** encountered at S- rank, around level 173. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a crown of glacier ice and a voice that starts avalanches. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Frostveil|Frostveil]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_large_biped`, animation set `anim_large_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Orcs, Ogres & Giants S|loot_orc_giant_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Tusk\|Tusk]] | 60% | 1–3 |
| [[Items/Giant's Hide\|Giant's Hide]] | 30% | 1–1 |
| [[Items/Crude Iron\|Crude Iron]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (1)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Frostveil\|Frostveil]] | 1 | S- | 173–173 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06728` | Ymgrir, the Frost Sovereign | [[Regions/Frostveil\|Frostveil]] | Unique | S- | 173 | 11 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `thick_skin` · VFX `frost_trail_snow` · palette `#bfe9ff` `#5fa8d3` `#f4fbff` · triangle-based silhouette, sharp asymmetric spikes
