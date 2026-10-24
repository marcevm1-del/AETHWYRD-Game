---
type: monster
id: mon_grukk_goblin_chief_of_hollowpine
family: "Goblinoids"
rank: "E+"
tier: core
tags: [monster, goblinoids, tyrant, unique]
---
# Grukk, Goblin Chief of Hollowpine

![[mon_grukk_goblin_chief_of_hollowpine_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_grukk_goblin_chief_of_hollowpine_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Grukk, Goblin Chief of Hollowpine is a person-sized creature with a lean humanoid frame, about 2.4 m tall. Its skin is rough, scarred and spiked, colored in ember reds fading to soot black. Its most striking feature is cult runes carved into its red-eyed hide and a cleaver named Hungry. It has eyes that catch torchlight like coins. Small scars and rough edges mark it as a survivor. It circles its prey, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Rank · level | E+ · 32 (26–40) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 2.4 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2498 · 166 · 138 · 110 · 124 · 100 |
| XP · gold | 15520 · 195 |
| Ring | 1 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Whisperwood\|Whisperwood]] |
| Tyrant | Yes |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Water. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2.4 m high × 0.72 m long × 0.77 m wide; prefab scale 1.333.
- **Physics:** 179.7 kg, gravity ×1.5, poise 76, knockback resistance 0.33, death style `ragdoll`.
- **Navigation:** speed 6.58 m/s, turn 258°/s, stopping distance 0.81 m.
- **Attack count:** 5; **signature:** cult runes carved into its red-eyed hide and a cleaver named Hungry.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Sand Toss\|Sand Toss]] | debuff | 0 | 12 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Grukk, Goblin Chief of Hollowpine is a **menacing humanoid** encountered at E+ rank, around level 32. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** cult runes carved into its red-eyed hide and a cleaver named Hungry. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Goblinoids E|loot_goblinoid_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (1)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Whisperwood\|Whisperwood]] | 1 | E+ | 32–32 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06715` | Grukk, Goblin Chief of Hollowpine | [[Regions/Whisperwood\|Whisperwood]] | Unique | E+ | 32 | 2.4 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rough_skin_leather` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · triangle-based silhouette, sharp asymmetric spikes
