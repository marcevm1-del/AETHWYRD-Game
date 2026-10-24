---
type: monster
id: mon_bandit
family: "Humanoid Enemies"
rank: "F"
tier: core
tags: [monster, humanoid-enemies]
---
# Bandit

![[mon_bandit_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_bandit_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Bandit is a person-sized creature with a broad-shouldered humanoid build, about 1.8 m tall. Its clothing and gear are rough, scarred and spiked, colored in muted greys and dusty browns. Its most striking feature is a patched cloak and a mismatched sword. It has narrow glowing eyes. It has no ornament at all: simple, readable shapes. It charges without hesitation. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Humanoid Enemies|Humanoid Enemies]] · Humanoid |
| Rank · level | F · 8 (3–13) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 1.8 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 353 · 50 · 42 · 24 · 38 · 100 |
| XP · gold | 92 · 31 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Low Fantasy |
| Trope | Bandits, cultists and fallen heroes |

**Field note:** Weak to Fire. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 1.8 m high × 0.54 m long × 0.58 m wide; prefab scale 1.
- **Physics:** 75.8 kg, gravity ×1.5, poise 50, knockback resistance 0.3, death style `ragdoll`.
- **Navigation:** speed 5.43 m/s, turn 298°/s, stopping distance 0.71 m.
- **Attack count:** 4; **signature:** a patched cloak and a mismatched sword.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Feint Strike\|Feint Strike]] | counter | 1.2 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |

## Field guide

Bandit is a **menacing humanoid** encountered at F rank, around level 8. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a patched cloak and a mismatched sword. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Humanoid Enemies F|loot_humanoid_enemy_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Coin Purse\|Coin Purse]] | 60% | 1–3 |
| [[Items/Weapon\|Weapon]] | 30% | 1–1 |
| [[Items/Bounty Proof\|Bounty Proof]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Humanoid Enemies/Tide Bandit|Tide Bandit]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 6 | E-, F+, E, F- | 3–26 | Day & Night |
| [[Regions/Whisperwood\|Whisperwood]] | 5 | F+, E-, F, F- | 3–19 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02718` | Aldmere Bandit Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | E- | 19 | 2.25 m | Day & Night | Like a typical Bandit, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_02719` | Aldmere Bandit Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | F+ | 13 | 1.98 m | Day & Night | Like a typical Bandit, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_02720` | Aldmere Bandit Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | E | 26 | 2.43 m | Day & Night | Like a typical Bandit, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_02721` | Whisperwood Bandit Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | F+ | 13 | 1.8 m | Day & Night | Like a typical Bandit, but a rare pale form with white skin or fur and red eyes. |
| `pop_02722` | Whisperwood Bandit Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | F+ | 13 | 1.98 m | Day & Night | Like a typical Bandit, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_02723` | Whisperwood Bandit Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | E- | 19 | 2.25 m | Day & Night | Like a typical Bandit, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_02724` | Whisperwood Bandit | [[Regions/Whisperwood\|Whisperwood]] | Adult | F | 8 | 1.8 m | Day & Night | A typical adult Bandit of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_02725` | Aldmere Bandit Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F- | 3 | 1.26 m | Day & Night | Like a typical Bandit, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_02726` | Aldmere Bandit Albino | [[Regions/Aldmere\|Aldmere]] | Albino | F+ | 13 | 1.8 m | Day & Night | Like a typical Bandit, but a rare pale form with white skin or fur and red eyes. |
| `pop_02727` | Whisperwood Bandit Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | F- | 3 | 1.53 m | Day & Night | Like a typical Bandit, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_02728` | Aldmere Bandit Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | F- | 3 | 1.53 m | Day & Night | Like a typical Bandit, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `cloth_leather_metal` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · triangle-based silhouette, sharp asymmetric spikes
