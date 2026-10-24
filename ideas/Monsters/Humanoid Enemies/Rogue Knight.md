---
type: monster
id: mon_rogue_knight
family: "Humanoid Enemies"
rank: "A"
tier: core
tags: [monster, humanoid-enemies]
---
# Rogue Knight

![[mon_rogue_knight_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_rogue_knight_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Rogue Knight is a person-sized creature with a lean humanoid frame, about 2 m tall. Its clothing and gear are rough, scarred and spiked, colored in muted greys and dusty browns. Look for a broken oath engraved on its blade. It has eyes that catch torchlight like coins. An elegant crest and glowing veins of mana mark it as a champion of its kind. It charges without hesitation. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Humanoid Enemies|Humanoid Enemies]] · Humanoid |
| Rank · level | A · 146 (132–159) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 2 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 22146 · 713 · 594 · 333 · 535 · 100 |
| XP · gold | 8719 · 1611 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Vharlen\|Vharlen]], [[Regions/Quaking Lands\|Quaking Lands]], [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Gearholm\|Gearholm]] |
| Genre | Low Fantasy |
| Trope | Bandits, cultists and fallen heroes |

**Field note:** Weak to Fire. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2 m high × 0.6 m long × 0.64 m wide; prefab scale 1.111.
- **Physics:** 104 kg, gravity ×1.5, poise 92, knockback resistance 0.45, death style `ragdoll`.
- **Navigation:** speed 5.46 m/s, turn 283°/s, stopping distance 0.74 m.
- **Attack count:** 4; **signature:** a broken oath engraved on its blade.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Feint Strike\|Feint Strike]] | counter | 1.2 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |

## Field guide

Rogue Knight is a **menacing humanoid** encountered at A rank, around level 146. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a broken oath engraved on its blade. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Vharlen|Vharlen]], [[Regions/Quaking Lands|Quaking Lands]], [[Regions/Shen-Lu|Shen-Lu]], [[Regions/Gearholm|Gearholm]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Humanoid Enemies A|loot_humanoid_enemy_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Coin Purse\|Coin Purse]] | 60% | 1–3 |
| [[Items/Weapon\|Weapon]] | 30% | 1–1 |
| [[Items/Bounty Proof\|Bounty Proof]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Humanoid Enemies/Zephyr Rogue Knight|Zephyr Rogue Knight]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Quaking Lands\|Quaking Lands]] | 4 | A, B+, A-, S- | 120–173 | Day & Night |
| [[Regions/Gearholm\|Gearholm]] | 3 | S, A-, B+ | 120–188 | Day & Night |
| [[Regions/Vharlen\|Vharlen]] | 3 | B+, A, S | 120–188 | Day & Night |
| [[Regions/Shen-Lu\|Shen-Lu]] | 1 | A | 146–146 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02795` | Quaking Lands Rogue Knight | [[Regions/Quaking Lands\|Quaking Lands]] | Adult | A | 146 | 2 m | Day & Night | A typical adult Rogue Knight of this region, with slate-grey coloring and hardened hide. |
| `pop_02796` | Quaking Lands Rogue Knight Runt | [[Regions/Quaking Lands\|Quaking Lands]] | Runt | B+ | 120 | 1.4 m | Day & Night | Like a typical Rogue Knight, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_02797` | Gearholm Rogue Knight Elderborn | [[Regions/Gearholm\|Gearholm]] | Elderborn | S | 188 | 2.7 m | Day & Night | Like a typical Rogue Knight, but old and wise, with greying features and a cautious hunting style, with soot-stained hide and scavenged scraps. |
| `pop_02798` | Vharlen Rogue Knight Runt | [[Regions/Vharlen\|Vharlen]] | Runt | B+ | 120 | 1.4 m | Day & Night | Like a typical Rogue Knight, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_02799` | Gearholm Rogue Knight Juvenile | [[Regions/Gearholm\|Gearholm]] | Juvenile | A- | 132 | 1.7 m | Day & Night | Like a typical Rogue Knight, but young, with brighter colors and unworn features, with soot-stained hide and scavenged scraps. |
| `pop_02800` | Vharlen Rogue Knight | [[Regions/Vharlen\|Vharlen]] | Adult | A | 146 | 2 m | Day & Night | A typical adult Rogue Knight of this region, with golden, grass-toned coloring. |
| `pop_02801` | Gearholm Rogue Knight Runt | [[Regions/Gearholm\|Gearholm]] | Runt | B+ | 120 | 1.4 m | Day & Night | Like a typical Rogue Knight, but smaller and scrappier than usual, with soot-stained hide and scavenged scraps. |
| `pop_02802` | Vharlen Rogue Knight Elderborn | [[Regions/Vharlen\|Vharlen]] | Elderborn | S | 188 | 2.7 m | Day & Night | Like a typical Rogue Knight, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_02803` | Quaking Lands Rogue Knight Juvenile | [[Regions/Quaking Lands\|Quaking Lands]] | Juvenile | A- | 132 | 1.7 m | Day & Night | Like a typical Rogue Knight, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_02804` | Shen-Lu Rogue Knight | [[Regions/Shen-Lu\|Shen-Lu]] | Adult | A | 146 | 2 m | Day & Night | A typical adult Rogue Knight of this region, with slate-grey coloring and hardened hide. |
| `pop_02805` | Quaking Lands Rogue Knight Alpha | [[Regions/Quaking Lands\|Quaking Lands]] | Alpha | S- | 173 | 2.5 m | Day & Night | Like a typical Rogue Knight, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `cloth_leather_metal` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · triangle-based silhouette, sharp asymmetric spikes
