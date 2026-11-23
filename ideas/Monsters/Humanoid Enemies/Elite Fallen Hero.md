---
type: monster
id: mon_elite_fallen_hero
family: "Humanoid Enemies"
rank: "SS"
tier: variant
tags: [monster, humanoid-enemies]
---
# Elite Fallen Hero

![[mon_elite_fallen_hero_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_elite_fallen_hero_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 19,996 tris · 1.709 × 1.517 × 3 m · local file `Game/Assets/_Game/Art/Models/Monsters/Humanoid Enemies/mon_elite_fallen_hero.fbx`

> The Elite Fallen Hero is a large creature with a lean humanoid frame, about 3 m tall. Its clothing and gear are rough, scarred and spiked, colored in worn green and leather brown, with gold markings. Look for tarnished hero armor and eyes that have seen the truth of the System. It has narrow glowing eyes. The air distorts slightly around its outline. It circles its prey, surrounded by soft radiance and floating motes of light. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Humanoid Enemies|Humanoid Enemies]] · Humanoid |
| Variant of | [[Monsters/Humanoid Enemies/Fallen Hero\|Fallen Hero]] (elder) |
| Rank · level | SS · 236 (218–253) |
| Menace | 3 · Menacing |
| Element · weakness | Light · Dark |
| Size | 3 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 52140 · 1145 · 954 · 763 · 859 · 100 |
| XP · gold | 18792 · 3152 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Moraveil\|Moraveil]] |
| Genre | Low Fantasy |
| Trope | Bandits, cultists and fallen heroes |

**Field note:** Weak to Dark. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 3 m high × 0.9 m long × 0.96 m wide; prefab scale 1.667.
- **Physics:** 333.5 kg, gravity ×1.35, poise 132, knockback resistance 0.51, death style `ragdoll`.
- **Navigation:** speed 7.01 m/s, turn 231°/s, stopping distance 0.91 m.
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

Elite Fallen Hero is a **menacing humanoid** encountered at SS rank, around level 236. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** tarnished hero armor and eyes that have seen the truth of the System. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Shen-Lu|Shen-Lu]], [[Regions/Moraveil|Moraveil]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Humanoid Enemies SS|loot_humanoid_enemy_ss]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Coin Purse\|Coin Purse]] | 60% | 1–3 |
| [[Items/Weapon\|Weapon]] | 30% | 1–1 |
| [[Items/Bounty Proof\|Bounty Proof]] | 15% | 1–1 |
| [[Items/SS-Rank Monster Core\|SS-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Moraveil\|Moraveil]] | 5 | SS-, SS+, S+, SSS-, SS | 203–267 | Day & Night |
| [[Regions/Shen-Lu\|Shen-Lu]] | 6 | SS, SS+, SSS, S+, SSS- | 203–281 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05648` | Moraveil Elite Fallen Hero Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | SS- | 218 | 2.55 m | Day & Night | Like a typical Elite Fallen Hero, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_05649` | Shen-Lu Elite Fallen Hero | [[Regions/Shen-Lu\|Shen-Lu]] | Adult | SS | 236 | 3 m | Day & Night | A typical adult Elite Fallen Hero of this region, with slate-grey coloring and hardened hide. |
| `pop_05650` | Moraveil Elite Fallen Hero Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | SS+ | 253 | 3.3 m | Day & Night | Like a typical Elite Fallen Hero, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_05651` | Shen-Lu Elite Fallen Hero Albino | [[Regions/Shen-Lu\|Shen-Lu]] | Albino | SS+ | 253 | 3 m | Day & Night | Like a typical Elite Fallen Hero, but a rare pale form with white skin or fur and red eyes. |
| `pop_05652` | Shen-Lu Elite Fallen Hero Elderborn | [[Regions/Shen-Lu\|Shen-Lu]] | Elderborn | SSS | 281 | 4.05 m | Day & Night | Like a typical Elite Fallen Hero, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_05653` | Shen-Lu Elite Fallen Hero Scarred | [[Regions/Shen-Lu\|Shen-Lu]] | Scarred | SS+ | 253 | 3.3 m | Day & Night | Like a typical Elite Fallen Hero, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_05654` | Moraveil Elite Fallen Hero Runt | [[Regions/Moraveil\|Moraveil]] | Runt | S+ | 203 | 2.1 m | Day & Night | Like a typical Elite Fallen Hero, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_05655` | Moraveil Elite Fallen Hero Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | SSS- | 267 | 3.75 m | Day & Night | Like a typical Elite Fallen Hero, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_05656` | Moraveil Elite Fallen Hero | [[Regions/Moraveil\|Moraveil]] | Adult | SS | 236 | 3 m | Day & Night | A typical adult Elite Fallen Hero of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_05657` | Shen-Lu Elite Fallen Hero Runt | [[Regions/Shen-Lu\|Shen-Lu]] | Runt | S+ | 203 | 2.1 m | Day & Night | Like a typical Elite Fallen Hero, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_05658` | Shen-Lu Elite Fallen Hero Alpha | [[Regions/Shen-Lu\|Shen-Lu]] | Alpha | SSS- | 267 | 3.75 m | Day & Night | Like a typical Elite Fallen Hero, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `cloth_leather_metal` · VFX `holy_motes` · palette `#526144` `#443c32` `#ffd166` · triangle-based silhouette, sharp asymmetric spikes
