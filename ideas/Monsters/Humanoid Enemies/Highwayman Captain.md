---
type: monster
id: mon_highwayman_captain
family: "Humanoid Enemies"
rank: "D"
tier: core
tags: [monster, humanoid-enemies]
---
# Highwayman Captain

![[mon_highwayman_captain_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_highwayman_captain_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Highwayman Captain is a person-sized creature with a broad-shouldered humanoid build, about 1.8 m tall. Its clothing and gear are rough, scarred and spiked, colored in muted greys and dusty browns. Its most striking feature is a feathered hat and two pistols of Veilborn design. It has burning slit pupils. A distinctive marking runs along its back. It charges without hesitation. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Humanoid Enemies|Humanoid Enemies]] · Humanoid |
| Rank · level | D · 48 (40–56) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 1.8 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 4092 · 242 · 202 · 113 · 182 · 100 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Moraveil\|Moraveil]] |
| Genre | Low Fantasy |
| Trope | Bandits, cultists and fallen heroes |

**Field note:** Weak to Fire. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 1.8 m high × 0.54 m long × 0.58 m wide; prefab scale 1.
- **Physics:** 75.8 kg, gravity ×1.5, poise 65, knockback resistance 0.36, death style `ragdoll`.
- **Navigation:** speed 5.43 m/s, turn 298°/s, stopping distance 0.71 m.
- **Attack count:** 4; **signature:** a feathered hat and two pistols of Veilborn design.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Feint Strike\|Feint Strike]] | counter | 1.2 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |

## Field guide

Highwayman Captain is a **menacing humanoid** encountered at D rank, around level 48. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a feathered hat and two pistols of Veilborn design. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Strife Marches|Strife Marches]], [[Regions/Moraveil|Moraveil]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Humanoid Enemies D|loot_humanoid_enemy_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Coin Purse\|Coin Purse]] | 60% | 1–3 |
| [[Items/Weapon\|Weapon]] | 30% | 1–1 |
| [[Items/Bounty Proof\|Bounty Proof]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Humanoid Enemies/Meadow Highwayman Captain|Meadow Highwayman Captain]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Strife Marches\|Strife Marches]] | 6 | C, D-, E+, C-, D, D+ | 32–76 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 3 | D, D-, C- | 40–65 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 2 | C-, D+ | 56–65 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02729` | Strife Marches Highwayman Captain Elderborn | [[Regions/Strife Marches\|Strife Marches]] | Elderborn | C | 76 | 2.43 m | Day & Night | Like a typical Highwayman Captain, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_02730` | Strife Marches Highwayman Captain Juvenile | [[Regions/Strife Marches\|Strife Marches]] | Juvenile | D- | 40 | 1.53 m | Day & Night | Like a typical Highwayman Captain, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_02731` | Strife Marches Highwayman Captain Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | E+ | 32 | 1.26 m | Day & Night | Like a typical Highwayman Captain, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_02732` | Strife Marches Highwayman Captain Alpha | [[Regions/Strife Marches\|Strife Marches]] | Alpha | C- | 65 | 2.25 m | Day & Night | Like a typical Highwayman Captain, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_02733` | Aldmere Highwayman Captain | [[Regions/Aldmere\|Aldmere]] | Adult | D | 48 | 1.8 m | Day & Night | A typical adult Highwayman Captain of this region, with golden, grass-toned coloring. |
| `pop_02734` | Strife Marches Highwayman Captain | [[Regions/Strife Marches\|Strife Marches]] | Adult | D | 48 | 1.8 m | Day & Night | A typical adult Highwayman Captain of this region, with golden, grass-toned coloring. |
| `pop_02735` | Moraveil Highwayman Captain Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | C- | 65 | 2.25 m | Day & Night | Like a typical Highwayman Captain, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_02736` | Moraveil Highwayman Captain Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | D+ | 56 | 1.98 m | Day & Night | Like a typical Highwayman Captain, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_02737` | Aldmere Highwayman Captain Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | D- | 40 | 1.53 m | Day & Night | Like a typical Highwayman Captain, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_02738` | Strife Marches Highwayman Captain Scarred | [[Regions/Strife Marches\|Strife Marches]] | Scarred | D+ | 56 | 1.98 m | Day & Night | Like a typical Highwayman Captain, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_02739` | Aldmere Highwayman Captain Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | C- | 65 | 2.25 m | Day & Night | Like a typical Highwayman Captain, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `cloth_leather_metal` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · triangle-based silhouette, sharp asymmetric spikes
