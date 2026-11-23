---
type: monster
id: mon_diego_alvarez_voice_of_the_choir_of_chains
family: "Humanoid Enemies"
rank: "B+"
tier: core
tags: [monster, humanoid-enemies, tyrant, unique]
---
# Diego Alvarez, Voice of the Choir of Chains

![[mon_diego_alvarez_voice_of_the_choir_of_chains_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_diego_alvarez_voice_of_the_choir_of_chains_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 0.964 × 0.766 × 1.8 m · local file `Game/Assets/_Game/Art/Models/Monsters/Humanoid Enemies/mon_diego_alvarez_voice_of_the_choir_of_chains.fbx`

> The Diego Alvarez, Voice of the Choir of Chains is a person-sized creature with an upright humanoid build, about 1.8 m tall. Its clothing and gear are patchy and subtly wrong, as if assembled from memory, colored in leather browns and dull steel, with crimson markings. Look for a Veilborn con man in a red silk coat, smiling like a salesman. It has pale, pupil-less eyes. Faint runes glow along its body when it fights. It moves in jerky stop-motion bursts, surrounded by a faint red mist that smells of iron.

| Field | Value |
|---|---|
| Family · type | [[Families/Humanoid Enemies|Humanoid Enemies]] · Humanoid |
| Rank · level | B+ · 120 (108–132) |
| Menace | 4 · Dread |
| Element · weakness | Blood · Light |
| Size | 1.8 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 15937 · 588 · 490 · 392 · 441 · 100 |
| XP · gold | 127464 · 1225 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Strife Marches\|Strife Marches]] |
| Tyrant | Yes |
| Genre | Low Fantasy |
| Trope | Bandits, cultists and fallen heroes |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 1.8 m high × 0.54 m long × 0.58 m wide; prefab scale 1.
- **Physics:** 83.4 kg, gravity ×1.5, poise 92, knockback resistance 0.42, death style `ragdoll`.
- **Navigation:** speed 5.17 m/s, turn 298°/s, stopping distance 0.71 m.
- **Attack count:** 5; **signature:** a Veilborn con man in a red silk coat, smiling like a salesman.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Feint Strike\|Feint Strike]] | counter | 1.2 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Blood Lance\|Blood Lance]] | magic | 1.5 | 10 s | Blood | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Diego Alvarez, Voice of the Choir of Chains is a **dread humanoid** encountered at B+ rank, around level 120. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a Veilborn con man in a red silk coat, smiling like a salesman. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Strife Marches|Strife Marches]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Humanoid Enemies B|loot_humanoid_enemy_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Coin Purse\|Coin Purse]] | 60% | 1–3 |
| [[Items/Weapon\|Weapon]] | 30% | 1–1 |
| [[Items/Bounty Proof\|Bounty Proof]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (1)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Strife Marches\|Strife Marches]] | 1 | B+ | 120–120 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06724` | Diego Alvarez, Voice of the Choir of Chains | [[Regions/Strife Marches\|Strife Marches]] | Unique | B+ | 120 | 1.8 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `cloth_leather_metal` · VFX `blood_mist` · palette `#966839` `#62666f` `#e0344a` · elongated, irregular silhouette; still-then-sudden timing
