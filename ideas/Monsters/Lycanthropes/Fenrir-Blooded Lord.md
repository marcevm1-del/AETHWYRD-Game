---
type: monster
id: mon_fenrir_blooded_lord
family: "Lycanthropes"
rank: "A"
tier: core
tags: [monster, lycanthropes]
---
# Fenrir-Blooded Lord

![[mon_fenrir_blooded_lord_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_fenrir_blooded_lord_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,840 tris · 2.121 × 3.491 × 3.6 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Fenrir-Blooded Lord is a large creature with a lean humanoid frame, about 3.6 m tall. Its fur is rough, scarred and spiked, colored in black-brown, with frost-blue markings. Its most striking feature is a crown of frost spikes growing from its mane. It has narrow glowing eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It strides with heavy steps, surrounded by falling snow motes and frosted ground where it steps.

| Field | Value |
|---|---|
| Family · type | [[Families/Lycanthropes|Lycanthropes]] · Cursed Beast |
| Rank · level | A · 146 (132–159) |
| Menace | 3 · Menacing |
| Element · weakness | Ice · Fire |
| Size | 3.6 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 27010 · 713 · 594 · 475 · 535 · 100 |
| XP · gold | 8719 · 1611 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Hoshizora\|Hoshizora]], [[Regions/Apu Highlands\|Apu Highlands]], [[Regions/Zarvan\|Zarvan]], [[Regions/Frostveil\|Frostveil]] |
| Genre | Gothic Horror |
| Trope | Moon-cursed transformation horror |

**Field note:** Weak to Fire. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 3.6 m high × 1.08 m long × 1.15 m wide; prefab scale 2.
- **Physics:** 667.2 kg, gravity ×1.58, poise 124, knockback resistance 0.45, death style `ragdoll`.
- **Navigation:** speed 7.06 m/s, turn 211°/s, stopping distance 1.01 m.
- **Attack count:** 5; **signature:** a crown of frost spikes growing from its mane.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Moon Frenzy\|Moon Frenzy]] | buff | 0 | 20 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Frost Breath\|Frost Breath]] | magic | 1.5 | 10 s | Ice | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Fenrir-Blooded Lord is a **menacing cursed beast** encountered at A rank, around level 146. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a crown of frost spikes growing from its mane. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Shen-Lu|Shen-Lu]], [[Regions/Hoshizora|Hoshizora]], [[Regions/Apu Highlands|Apu Highlands]], [[Regions/Zarvan|Zarvan]], [[Regions/Frostveil|Frostveil]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Lycanthropes A|loot_lycan_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Cursed Fur\|Cursed Fur]] | 60% | 1–3 |
| [[Items/Silver-Bane Claw\|Silver-Bane Claw]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Lycanthropes/Phantom Fenrir-Blooded Lord|Phantom Fenrir-Blooded Lord]]
- [[Monsters/Lycanthropes/Thunder Fenrir-Blooded Lord|Thunder Fenrir-Blooded Lord]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Apu Highlands\|Apu Highlands]] | 2 | B+, A+ | 120–159 | Day & Night |
| [[Regions/Frostveil\|Frostveil]] | 2 | B+, S- | 120–173 | Day & Night |
| [[Regions/Shen-Lu\|Shen-Lu]] | 1 | A+ | 159–159 | Day & Night |
| [[Regions/Zarvan\|Zarvan]] | 2 | A, A+ | 146–159 | Day & Night |
| [[Regions/Hoshizora\|Hoshizora]] | 4 | B+, A-, S-, S | 120–188 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00597` | Apu Highlands Fenrir-Blooded Lord Runt | [[Regions/Apu Highlands\|Apu Highlands]] | Runt | B+ | 120 | 2.52 m | Day & Night | Like a typical Fenrir-Blooded Lord, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_00598` | Frostveil Fenrir-Blooded Lord Runt | [[Regions/Frostveil\|Frostveil]] | Runt | B+ | 120 | 2.52 m | Day & Night | Like a typical Fenrir-Blooded Lord, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_00599` | Shen-Lu Fenrir-Blooded Lord Scarred | [[Regions/Shen-Lu\|Shen-Lu]] | Scarred | A+ | 159 | 3.96 m | Day & Night | Like a typical Fenrir-Blooded Lord, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_00600` | Zarvan Fenrir-Blooded Lord | [[Regions/Zarvan\|Zarvan]] | Adult | A | 146 | 3.6 m | Day & Night | A typical adult Fenrir-Blooded Lord of this region, with slate-grey coloring and hardened hide. |
| `pop_00601` | Hoshizora Fenrir-Blooded Lord Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | B+ | 120 | 2.52 m | Day & Night | Like a typical Fenrir-Blooded Lord, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_00602` | Hoshizora Fenrir-Blooded Lord Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | A- | 132 | 3.06 m | Day & Night | Like a typical Fenrir-Blooded Lord, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_00603` | Hoshizora Fenrir-Blooded Lord Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | S- | 173 | 4.5 m | Day & Night | Like a typical Fenrir-Blooded Lord, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_00604` | Apu Highlands Fenrir-Blooded Lord Albino | [[Regions/Apu Highlands\|Apu Highlands]] | Albino | A+ | 159 | 3.6 m | Day & Night | Like a typical Fenrir-Blooded Lord, but a rare pale form with white skin or fur and red eyes. |
| `pop_00605` | Frostveil Fenrir-Blooded Lord Alpha | [[Regions/Frostveil\|Frostveil]] | Alpha | S- | 173 | 4.5 m | Day & Night | Like a typical Fenrir-Blooded Lord, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_00606` | Zarvan Fenrir-Blooded Lord Albino | [[Regions/Zarvan\|Zarvan]] | Albino | A+ | 159 | 3.6 m | Day & Night | Like a typical Fenrir-Blooded Lord, but a rare pale form with white skin or fur and red eyes. |
| `pop_00607` | Hoshizora Fenrir-Blooded Lord Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | S | 188 | 4.86 m | Day & Night | Like a typical Fenrir-Blooded Lord, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `fur_rough` · VFX `frost_trail_snow` · palette `#53453b` `#403537` `#9fdcff` · triangle-based silhouette, sharp asymmetric spikes
