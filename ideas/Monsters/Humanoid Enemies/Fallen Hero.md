---
type: monster
id: mon_fallen_hero
family: "Humanoid Enemies"
rank: "S"
tier: core
tags: [monster, humanoid-enemies]
---
# Fallen Hero

![[mon_fallen_hero_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_fallen_hero_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Fallen Hero is a person-sized creature with a broad-shouldered humanoid build, about 1.9 m tall. Its clothing and gear are rough, scarred and spiked, colored in warm gold and pearl white. Its most striking feature is tarnished hero armor and eyes that have seen the truth of the System. It has burning slit pupils. Its regal silhouette is crowned by a halo-like ring of aura. It circles its prey, surrounded by soft radiance and floating motes of light.

| Field | Value |
|---|---|
| Family · type | [[Families/Humanoid Enemies|Humanoid Enemies]] · Humanoid |
| Rank · level | S · 188 (173–203) |
| Menace | 3 · Menacing |
| Element · weakness | Light · Dark |
| Size | 1.9 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 31757 · 914 · 762 · 610 · 686 · 100 |
| XP · gold | 13063 · 2293 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Everdusk\|Everdusk]] |
| Genre | Low Fantasy |
| Trope | Bandits, cultists and fallen heroes |

**Field note:** Weak to Dark. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 1.9 m high × 0.57 m long × 0.61 m wide; prefab scale 1.056.
- **Physics:** 84.7 kg, gravity ×1.35, poise 98, knockback resistance 0.48, death style `ragdoll`.
- **Navigation:** speed 5.58 m/s, turn 290°/s, stopping distance 0.72 m.
- **Attack count:** 5; **signature:** tarnished hero armor and eyes that have seen the truth of the System.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Feint Strike\|Feint Strike]] | counter | 1.2 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Fallen Hero is a **menacing humanoid** encountered at S rank, around level 188. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** tarnished hero armor and eyes that have seen the truth of the System. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Shen-Lu|Shen-Lu]], [[Regions/Everdusk|Everdusk]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Humanoid Enemies S|loot_humanoid_enemy_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Coin Purse\|Coin Purse]] | 60% | 1–3 |
| [[Items/Weapon\|Weapon]] | 30% | 1–1 |
| [[Items/Bounty Proof\|Bounty Proof]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Humanoid Enemies/Elite Fallen Hero|Elite Fallen Hero]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Shen-Lu\|Shen-Lu]] | 6 | S+, SS, A+, S-, SS- | 159–236 | Day & Night |
| [[Regions/Everdusk\|Everdusk]] | 5 | SS-, A+, S+, SS, S- | 159–236 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02806` | Shen-Lu Fallen Hero Albino | [[Regions/Shen-Lu\|Shen-Lu]] | Albino | S+ | 203 | 1.9 m | Day & Night | Like a typical Fallen Hero, but a rare pale form with white skin or fur and red eyes. |
| `pop_02807` | Everdusk Fallen Hero Alpha | [[Regions/Everdusk\|Everdusk]] | Alpha | SS- | 218 | 2.38 m | Day & Night | Like a typical Fallen Hero, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_02808` | Shen-Lu Fallen Hero Elderborn | [[Regions/Shen-Lu\|Shen-Lu]] | Elderborn | SS | 236 | 2.56 m | Day & Night | Like a typical Fallen Hero, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_02809` | Everdusk Fallen Hero Runt | [[Regions/Everdusk\|Everdusk]] | Runt | A+ | 159 | 1.33 m | Day & Night | Like a typical Fallen Hero, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_02810` | Shen-Lu Fallen Hero Runt | [[Regions/Shen-Lu\|Shen-Lu]] | Runt | A+ | 159 | 1.33 m | Day & Night | Like a typical Fallen Hero, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_02811` | Shen-Lu Fallen Hero Scarred | [[Regions/Shen-Lu\|Shen-Lu]] | Scarred | S+ | 203 | 2.09 m | Day & Night | Like a typical Fallen Hero, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_02812` | Everdusk Fallen Hero Scarred | [[Regions/Everdusk\|Everdusk]] | Scarred | S+ | 203 | 2.09 m | Day & Night | Like a typical Fallen Hero, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_02813` | Everdusk Fallen Hero Elderborn | [[Regions/Everdusk\|Everdusk]] | Elderborn | SS | 236 | 2.56 m | Day & Night | Like a typical Fallen Hero, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_02814` | Shen-Lu Fallen Hero Juvenile | [[Regions/Shen-Lu\|Shen-Lu]] | Juvenile | S- | 173 | 1.61 m | Day & Night | Like a typical Fallen Hero, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_02815` | Shen-Lu Fallen Hero Alpha | [[Regions/Shen-Lu\|Shen-Lu]] | Alpha | SS- | 218 | 2.38 m | Day & Night | Like a typical Fallen Hero, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_02816` | Everdusk Fallen Hero Juvenile | [[Regions/Everdusk\|Everdusk]] | Juvenile | S- | 173 | 1.61 m | Day & Night | Like a typical Fallen Hero, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `cloth_leather_metal` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · triangle-based silhouette, sharp asymmetric spikes
