---
type: monster
id: mon_syndicate_blade_veteran
family: "Humanoid Enemies"
rank: "A"
tier: variant
tags: [monster, humanoid-enemies]
---
# Syndicate Blade Veteran

![[mon_syndicate_blade_veteran_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_syndicate_blade_veteran_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Syndicate Blade Veteran is a large creature with an upright humanoid build, about 2.9 m tall. Its clothing and gear are rough, scarred and spiked, colored in ink black with bruised violet. Its most striking feature is no face, no name, two knives. It has burning slit pupils. An elegant crest and glowing veins of mana mark it as a champion of its kind. It strides with heavy steps, surrounded by shadows that lean toward it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Humanoid Enemies|Humanoid Enemies]] · Humanoid |
| Variant of | [[Monsters/Humanoid Enemies/Syndicate Blade\|Syndicate Blade]] (elder) |
| Rank · level | A · 146 (132–159) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 2.9 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 25132 · 713 · 594 · 475 · 535 · 100 |
| XP · gold | 8719 · 1611 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Vharlen\|Vharlen]], [[Regions/Cinderhole\|Cinderhole]] |
| Genre | Low Fantasy |
| Trope | Bandits, cultists and fallen heroes |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2.9 m high × 0.87 m long × 0.93 m wide; prefab scale 1.611.
- **Physics:** 317.1 kg, gravity ×1.5, poise 111, knockback resistance 0.45, death style `ragdoll`.
- **Navigation:** speed 7.23 m/s, turn 235°/s, stopping distance 0.89 m.
- **Attack count:** 5; **signature:** no face, no name, two knives.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Feint Strike\|Feint Strike]] | counter | 1.2 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Syndicate Blade Veteran is a **menacing humanoid** encountered at A rank, around level 146. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** no face, no name, two knives. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Vharlen|Vharlen]], [[Regions/Cinderhole|Cinderhole]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Humanoid Enemies A|loot_humanoid_enemy_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Coin Purse\|Coin Purse]] | 60% | 1–3 |
| [[Items/Weapon\|Weapon]] | 30% | 1–1 |
| [[Items/Bounty Proof\|Bounty Proof]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Cinderhole\|Cinderhole]] | 3 | B+, A-, A | 120–146 | Day & Night |
| [[Regions/Vharlen\|Vharlen]] | 4 | S, A, A-, A+ | 132–188 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 4 | A-, A+, B+ | 120–159 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05626` | Cinderhole Syndicate Blade Veteran Runt | [[Regions/Cinderhole\|Cinderhole]] | Runt | B+ | 120 | 2.03 m | Day & Night | Like a typical Syndicate Blade Veteran, but smaller and scrappier than usual, with soot-stained hide and scavenged scraps. |
| `pop_05627` | Vharlen Syndicate Blade Veteran Elderborn | [[Regions/Vharlen\|Vharlen]] | Elderborn | S | 188 | 3.92 m | Day & Night | Like a typical Syndicate Blade Veteran, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_05628` | Moraveil Syndicate Blade Veteran Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | A- | 132 | 2.46 m | Day & Night | Like a typical Syndicate Blade Veteran, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_05629` | Cinderhole Syndicate Blade Veteran Juvenile | [[Regions/Cinderhole\|Cinderhole]] | Juvenile | A- | 132 | 2.46 m | Day & Night | Like a typical Syndicate Blade Veteran, but young, with brighter colors and unworn features, with soot-stained hide and scavenged scraps. |
| `pop_05630` | Vharlen Syndicate Blade Veteran | [[Regions/Vharlen\|Vharlen]] | Adult | A | 146 | 2.9 m | Day & Night | A typical adult Syndicate Blade Veteran of this region, with golden, grass-toned coloring. |
| `pop_05631` | Moraveil Syndicate Blade Veteran Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | A+ | 159 | 3.19 m | Day & Night | Like a typical Syndicate Blade Veteran, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_05632` | Moraveil Syndicate Blade Veteran Albino | [[Regions/Moraveil\|Moraveil]] | Albino | A+ | 159 | 2.9 m | Day & Night | Like a typical Syndicate Blade Veteran, but a rare pale form with white skin or fur and red eyes. |
| `pop_05633` | Cinderhole Syndicate Blade Veteran | [[Regions/Cinderhole\|Cinderhole]] | Adult | A | 146 | 2.9 m | Day & Night | A typical adult Syndicate Blade Veteran of this region, with soot-stained hide and scavenged scraps. |
| `pop_05634` | Vharlen Syndicate Blade Veteran Juvenile | [[Regions/Vharlen\|Vharlen]] | Juvenile | A- | 132 | 2.46 m | Day & Night | Like a typical Syndicate Blade Veteran, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_05635` | Moraveil Syndicate Blade Veteran Runt | [[Regions/Moraveil\|Moraveil]] | Runt | B+ | 120 | 2.03 m | Day & Night | Like a typical Syndicate Blade Veteran, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_05636` | Vharlen Syndicate Blade Veteran Albino | [[Regions/Vharlen\|Vharlen]] | Albino | A+ | 159 | 2.9 m | Day & Night | Like a typical Syndicate Blade Veteran, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `cloth_leather_metal` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · triangle-based silhouette, sharp asymmetric spikes
