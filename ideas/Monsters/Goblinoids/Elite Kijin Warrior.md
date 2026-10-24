---
type: monster
id: mon_elite_kijin_warrior
family: "Goblinoids"
rank: "S"
tier: variant
tags: [monster, goblinoids]
---
# Elite Kijin Warrior

![[mon_elite_kijin_warrior_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_elite_kijin_warrior_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Elite Kijin Warrior is a large creature with a broad-shouldered humanoid build, about 3.8 m tall. Its skin is rough, scarred and spiked, colored in ember reds fading to soot black. Its most striking feature is twin horns, a disciplined stance and a lacquered blade. It has eyes that catch torchlight like coins. Its regal silhouette is crowned by a halo-like ring of aura. It charges without hesitation, surrounded by heat-shimmer and drifting sparks. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Variant of | [[Monsters/Goblinoids/Kijin Warrior\|Kijin Warrior]] (elder) |
| Rank · level | S · 188 (173–203) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 3.8 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 40127 · 914 · 762 · 610 · 686 · 100 |
| XP · gold | 13063 · 2293 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Nox Dominion\|Nox Dominion]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Water. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 3.8 m high × 1.14 m long × 1.22 m wide; prefab scale 2.111.
- **Physics:** 713.3 kg, gravity ×1.5, poise 138, knockback resistance 0.48, death style `ragdoll`.
- **Navigation:** speed 8.28 m/s, turn 205°/s, stopping distance 1.05 m.
- **Attack count:** 5; **signature:** twin horns, a disciplined stance and a lacquered blade.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Sand Toss\|Sand Toss]] | debuff | 0 | 12 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Elite Kijin Warrior is a **menacing humanoid** encountered at S rank, around level 188. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** twin horns, a disciplined stance and a lacquered blade. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Nox Dominion|Nox Dominion]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Goblinoids S|loot_goblinoid_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Moraveil\|Moraveil]] | 4 | S+, S-, S | 173–203 | Day & Night |
| [[Regions/Nox Dominion\|Nox Dominion]] | 7 | S+, S-, S, SS-, A+, SS | 159–236 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03170` | Moraveil Elite Kijin Warrior Albino | [[Regions/Moraveil\|Moraveil]] | Albino | S+ | 203 | 3.8 m | Day & Night | Like a typical Elite Kijin Warrior, but a rare pale form with white skin or fur and red eyes. |
| `pop_03171` | Nox Dominion Elite Kijin Warrior Scarred | [[Regions/Nox Dominion\|Nox Dominion]] | Scarred | S+ | 203 | 4.18 m | Day & Night | Like a typical Elite Kijin Warrior, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_03172` | Nox Dominion Elite Kijin Warrior Juvenile | [[Regions/Nox Dominion\|Nox Dominion]] | Juvenile | S- | 173 | 3.23 m | Day & Night | Like a typical Elite Kijin Warrior, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_03173` | Nox Dominion Elite Kijin Warrior | [[Regions/Nox Dominion\|Nox Dominion]] | Adult | S | 188 | 3.8 m | Day & Night | A typical adult Elite Kijin Warrior of this region, with dust-grey coloring and old rune scars. |
| `pop_03174` | Moraveil Elite Kijin Warrior Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | S+ | 203 | 4.18 m | Day & Night | Like a typical Elite Kijin Warrior, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_03175` | Moraveil Elite Kijin Warrior Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | S- | 173 | 3.23 m | Day & Night | Like a typical Elite Kijin Warrior, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_03176` | Moraveil Elite Kijin Warrior | [[Regions/Moraveil\|Moraveil]] | Adult | S | 188 | 3.8 m | Day & Night | A typical adult Elite Kijin Warrior of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_03177` | Nox Dominion Elite Kijin Warrior Alpha | [[Regions/Nox Dominion\|Nox Dominion]] | Alpha | SS- | 218 | 4.75 m | Day & Night | Like a typical Elite Kijin Warrior, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_03178` | Nox Dominion Elite Kijin Warrior Runt | [[Regions/Nox Dominion\|Nox Dominion]] | Runt | A+ | 159 | 2.66 m | Day & Night | Like a typical Elite Kijin Warrior, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_03179` | Nox Dominion Elite Kijin Warrior Elderborn | [[Regions/Nox Dominion\|Nox Dominion]] | Elderborn | SS | 236 | 5.13 m | Day & Night | Like a typical Elite Kijin Warrior, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_03180` | Nox Dominion Elite Kijin Warrior Albino | [[Regions/Nox Dominion\|Nox Dominion]] | Albino | S+ | 203 | 3.8 m | Day & Night | Like a typical Elite Kijin Warrior, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rough_skin_leather` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · triangle-based silhouette, sharp asymmetric spikes
