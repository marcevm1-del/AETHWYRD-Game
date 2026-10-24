---
type: monster
id: mon_varrick_kade_the_slaver_lord
family: "Humanoid Enemies"
rank: "B+"
tier: core
tags: [monster, humanoid-enemies, tyrant, unique]
---
# Varrick Kade, the Slaver Lord

![[mon_varrick_kade_the_slaver_lord_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_varrick_kade_the_slaver_lord_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Varrick Kade, the Slaver Lord is a person-sized creature with an upright humanoid build, about 1.9 m tall. Its clothing and gear are rough, scarred and spiked, colored in muted greys and dusty browns. Look for a whip of braided chains and a ledger of every beastkin he has sold. It has eyes that catch torchlight like coins. Faint runes glow along its body when it fights. It charges without hesitation. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Humanoid Enemies|Humanoid Enemies]] · Humanoid |
| Rank · level | B+ · 120 (108–132) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 1.9 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 16235 · 588 · 490 · 274 · 441 · 100 |
| XP · gold | 127464 · 1225 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Fanghold\|Fanghold]] |
| Tyrant | Yes |
| Genre | Low Fantasy |
| Trope | Bandits, cultists and fallen heroes |

**Field note:** Weak to Fire. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 1.9 m high × 0.57 m long × 0.61 m wide; prefab scale 1.056.
- **Physics:** 89.2 kg, gravity ×1.5, poise 95, knockback resistance 0.42, death style `ragdoll`.
- **Navigation:** speed 5.32 m/s, turn 290°/s, stopping distance 0.72 m.
- **Attack count:** 4; **signature:** a whip of braided chains and a ledger of every beastkin he has sold.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Feint Strike\|Feint Strike]] | counter | 1.2 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |

## Field guide

Varrick Kade, the Slaver Lord is a **menacing humanoid** encountered at B+ rank, around level 120. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a whip of braided chains and a ledger of every beastkin he has sold. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Fanghold|Fanghold]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Fanghold\|Fanghold]] | 1 | B+ | 120–120 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06721` | Varrick Kade, the Slaver Lord | [[Regions/Fanghold\|Fanghold]] | Unique | B+ | 120 | 1.9 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `cloth_leather_metal` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · triangle-based silhouette, sharp asymmetric spikes
