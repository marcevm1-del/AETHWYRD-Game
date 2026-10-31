---
type: monster
id: mon_cinderlord_vasque_the_smoke_mage
family: "Humanoid Enemies"
rank: "A+"
tier: core
tags: [monster, humanoid-enemies, tyrant, unique]
---
# Cinderlord Vasque, the Smoke Mage

![[mon_cinderlord_vasque_the_smoke_mage_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_cinderlord_vasque_the_smoke_mage_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,194 tris · 0.793 × 1.458 × 1.9 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Cinderlord Vasque, the Smoke Mage is a person-sized creature with a broad-shouldered humanoid build, about 1.9 m tall. Its clothing and gear are patchy and subtly wrong, as if assembled from memory, colored in worn green and leather brown, with ember-orange markings. Its most striking feature is a gas mask of brass and lungs full of living smoke. It has pale, pupil-less eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It glides without moving its legs, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Humanoid Enemies|Humanoid Enemies]] · Humanoid |
| Rank · level | A+ · 159 (146–173) |
| Menace | 4 · Dread |
| Element · weakness | Fire · Water |
| Size | 1.9 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 24719 · 775 · 646 · 517 · 581 · 100 |
| XP · gold | 199864 · 1815 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Cinderhole\|Cinderhole]] |
| Tyrant | Yes |
| Genre | Low Fantasy |
| Trope | Bandits, cultists and fallen heroes |

**Field note:** Weak to Water. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 1.9 m high × 0.57 m long × 0.61 m wide; prefab scale 1.056.
- **Physics:** 89.2 kg, gravity ×1.5, poise 103, knockback resistance 0.45, death style `ragdoll`.
- **Navigation:** speed 5.58 m/s, turn 290°/s, stopping distance 0.72 m.
- **Attack count:** 5; **signature:** a gas mask of brass and lungs full of living smoke.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Feint Strike\|Feint Strike]] | counter | 1.2 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Cinderlord Vasque, the Smoke Mage is a **dread humanoid** encountered at A+ rank, around level 159. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a gas mask of brass and lungs full of living smoke. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Cinderhole|Cinderhole]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Humanoid Enemies A|loot_humanoid_enemy_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Coin Purse\|Coin Purse]] | 60% | 1–3 |
| [[Items/Weapon\|Weapon]] | 30% | 1–1 |
| [[Items/Bounty Proof\|Bounty Proof]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (1)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Cinderhole\|Cinderhole]] | 1 | A+ | 159–159 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06748` | Cinderlord Vasque, the Smoke Mage | [[Regions/Cinderhole\|Cinderhole]] | Unique | A+ | 159 | 1.9 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `cloth_leather_metal` · VFX `embers_heat_haze` · palette `#5e7451` `#51493b` `#ff7a3d` · elongated, irregular silhouette; still-then-sudden timing
