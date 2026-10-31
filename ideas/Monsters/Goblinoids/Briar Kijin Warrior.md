---
type: monster
id: mon_briar_kijin_warrior
family: "Goblinoids"
rank: "A+"
tier: variant
tags: [monster, goblinoids]
---
# Briar Kijin Warrior

![[mon_briar_kijin_warrior_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_briar_kijin_warrior_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,252 tris · 1.301 × 1.628 × 2.4 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Briar Kijin Warrior is a person-sized creature with a broad-shouldered humanoid build, about 2.4 m tall. Its skin is rough, scarred and spiked, colored in olive and hide brown, with leaf-green markings. Survivors describe twin horns, a disciplined stance and a lacquered blade. It has narrow glowing eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It circles its prey, surrounded by drifting pollen and tiny blossoms. This Nature-attuned variant carries one extra elemental feature, like element-scarred hide, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Variant of | [[Monsters/Goblinoids/Kijin Warrior\|Kijin Warrior]] (elemental) |
| Rank · level | A+ · 159 (146–173) |
| Menace | 3 · Menacing |
| Element · weakness | Nature · Fire |
| Size | 2.4 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 26775 · 775 · 646 · 517 · 581 · 100 |
| XP · gold | 9993 · 1815 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Hoshizora\|Hoshizora]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Fire. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2.4 m high × 0.72 m long × 0.77 m wide; prefab scale 1.333.
- **Physics:** 179.7 kg, gravity ×1.5, poise 101, knockback resistance 0.45, death style `ragdoll`.
- **Navigation:** speed 6.27 m/s, turn 258°/s, stopping distance 0.81 m.
- **Attack count:** 5; **signature:** twin horns, a disciplined stance and a lacquered blade.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Sand Toss\|Sand Toss]] | debuff | 0 | 12 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Thorn Volley\|Thorn Volley]] | magic | 1.5 | 10 s | Nature | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Briar Kijin Warrior is a **menacing humanoid** encountered at A+ rank, around level 159. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** twin horns, a disciplined stance and a lacquered blade. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Shen-Lu|Shen-Lu]], [[Regions/Hoshizora|Hoshizora]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Goblinoids A|loot_goblinoid_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Moraveil\|Moraveil]] | 5 | S, S-, A+, A, A- | 132–188 | Day & Night |
| [[Regions/Hoshizora\|Hoshizora]] | 5 | S+, S-, A, A+, A- | 132–203 | Day & Night |
| [[Regions/Shen-Lu\|Shen-Lu]] | 1 | A | 146–146 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06011` | Moraveil Briar Kijin Warrior Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | S | 188 | 3 m | Day & Night | Like a typical Briar Kijin Warrior, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_06012` | Moraveil Briar Kijin Warrior Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | S- | 173 | 2.64 m | Day & Night | Like a typical Briar Kijin Warrior, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_06013` | Hoshizora Briar Kijin Warrior Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | S+ | 203 | 3.24 m | Day & Night | Like a typical Briar Kijin Warrior, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_06014` | Hoshizora Briar Kijin Warrior Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | S- | 173 | 2.64 m | Day & Night | Like a typical Briar Kijin Warrior, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_06015` | Hoshizora Briar Kijin Warrior Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | A | 146 | 2.04 m | Day & Night | Like a typical Briar Kijin Warrior, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_06016` | Moraveil Briar Kijin Warrior | [[Regions/Moraveil\|Moraveil]] | Adult | A+ | 159 | 2.4 m | Day & Night | A typical adult Briar Kijin Warrior of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_06017` | Shen-Lu Briar Kijin Warrior Juvenile | [[Regions/Shen-Lu\|Shen-Lu]] | Juvenile | A | 146 | 2.04 m | Day & Night | Like a typical Briar Kijin Warrior, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_06018` | Moraveil Briar Kijin Warrior Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | A | 146 | 2.04 m | Day & Night | Like a typical Briar Kijin Warrior, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_06019` | Hoshizora Briar Kijin Warrior | [[Regions/Hoshizora\|Hoshizora]] | Adult | A+ | 159 | 2.4 m | Day & Night | A typical adult Briar Kijin Warrior of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_06020` | Hoshizora Briar Kijin Warrior Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | A- | 132 | 1.68 m | Day & Night | Like a typical Briar Kijin Warrior, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_06021` | Moraveil Briar Kijin Warrior Runt | [[Regions/Moraveil\|Moraveil]] | Runt | A- | 132 | 1.68 m | Day & Night | Like a typical Briar Kijin Warrior, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rough_skin_leather` · VFX `pollen_petals` · palette `#8e994b` `#6a4830` `#8fd16a` · triangle-based silhouette, sharp asymmetric spikes
