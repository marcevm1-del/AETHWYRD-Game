---
type: monster
id: mon_the_nameless_tide_a_serpent_without_a_name
family: "Aquatic"
rank: "A+"
tier: core
tags: [monster, aquatic, tyrant, unique]
---
# The Nameless Tide, a Serpent Without a Name

> The The Nameless Tide, a Serpent Without a Name is a colossal creature with a long, sinuous serpentine body, about 30 m long. Its scales and skin are patchy and subtly wrong, as if assembled from memory, colored in deep blues with a glassy shine. Look for a sea serpent whose true name was stolen, and which drowns anyone who speaks theirs. It has pale, pupil-less eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It moves in jerky stop-motion bursts, surrounded by fine mist and droplets that orbit it.

| Field | Value |
|---|---|
| Family · type | [[Families/Aquatic|Aquatic]] · Aquatic |
| Rank · level | A+ · 159 (146–173) |
| Menace | 4 · Dread |
| Element · weakness | Water · Lightning |
| Size | 30 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 42771 · 646 · 517 · 452 · 517 · 135 |
| XP · gold | 199864 · 1815 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/serpent\|serpent]] · `anim_serpent` |
| Habitats | [[Regions/True-Name Isles\|True-Name Isles]] |
| Tyrant | Yes |
| Genre | Seafaring |
| Trope | Sea kings and krakens (One Piece), sirens and merfolk |

**Field note:** Weak to Lightning. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/serpent|serpent]] (rigId); animation set `anim_serpent`.
- **Dimensions:** 1.2 m high × 30 m long × 3 m wide; prefab scale 7.5.
- **Physics:** 65205 kg, gravity ×1.2, poise 2436, knockback resistance 0.55, death style `limp_chain`.
- **Navigation:** speed 16.01 m/s, turn 60°/s, stopping distance 1.45 m.
- **Attack count:** 5; **signature:** a sea serpent whose true name was stolen, and which drowns anyone who speaks theirs.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Strike\|Strike]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Constrict\|Constrict]] | grab | 1.8 | 12 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Tail Sweep\|Tail Sweep]] | aoe | 1.2 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Tidal Drag\|Tidal Drag]] | grab | 1.3 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Tide Lash\|Tide Lash]] | magic | 1.5 | 10 s | Water | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

The Nameless Tide, a Serpent Without a Name is a **dread aquatic** encountered at A+ rank, around level 159. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Lightning**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a sea serpent whose true name was stolen, and which drowns anyone who speaks theirs. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/True-Name Isles|True-Name Isles]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_serpent`, animation set `anim_serpent`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Aquatic A|loot_aquatic_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Fish Scale\|Fish Scale]] | 60% | 1–3 |
| [[Items/Pearl\|Pearl]] | 30% | 1–1 |
| [[Items/Ink Sac\|Ink Sac]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (1)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/True-Name Isles\|True-Name Isles]] | 1 | A+ | 159–159 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06741` | The Nameless Tide, a Serpent Without a Name | [[Regions/True-Name Isles\|True-Name Isles]] | Unique | A+ | 159 | 30 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_serpent` · mesh `serpent_base` · material `wet_scale` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · elongated, irregular silhouette; still-then-sudden timing
