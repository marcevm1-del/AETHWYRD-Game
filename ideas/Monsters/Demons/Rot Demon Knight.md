---
type: monster
id: mon_rot_demon_knight
family: "Demons"
rank: "A+"
tier: variant
tags: [monster, demons]
---
# Rot Demon Knight

![[mon_rot_demon_knight_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_rot_demon_knight_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,752 tris · 1.473 × 1.583 × 2.5 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Rot Demon Knight is a large creature with an upright humanoid build, about 2.5 m tall. Its hide is rough, scarred and spiked, colored in bruised violet, with sickly green markings. Guild sketches always show black-steel armor engraved with the Overlord's sigil. It has eyes that catch torchlight like coins. An elegant crest and glowing veins of mana mark it as a champion of its kind. It circles its prey, surrounded by a low toxic haze that clings to the ground. This Poison-attuned variant carries one extra elemental feature, like glowing vein-lines, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Demons|Demons]] · Demon |
| Variant of | [[Monsters/Demons/Demon Knight\|Demon Knight]] (elemental) |
| Rank · level | A+ · 159 (146–173) |
| Menace | 3 · Menacing |
| Element · weakness | Poison · Light |
| Size | 2.5 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 27150 · 775 · 646 · 517 · 581 · 100 |
| XP · gold | 9993 · 1815 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Nox Dominion\|Nox Dominion]], [[Regions/Lumbaya\|Lumbaya]], [[Regions/Cinderhole\|Cinderhole]] |
| Genre | Abyssal |
| Trope | Demons as a people of the Abyss, not just evil (Frieren, Maoyuu) |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2.5 m high × 0.75 m long × 0.8 m wide; prefab scale 1.389.
- **Physics:** 203.1 kg, gravity ×1.5, poise 103, knockback resistance 0.45, death style `ragdoll`.
- **Navigation:** speed 6.2 m/s, turn 253°/s, stopping distance 0.83 m.
- **Attack count:** 5; **signature:** black-steel armor engraved with the Overlord's sigil.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Hellfire Brand\|Hellfire Brand]] | magic | 1.4 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Rot Demon Knight is a **menacing demon** encountered at A+ rank, around level 159. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** black-steel armor engraved with the Overlord's sigil. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Nox Dominion|Nox Dominion]], [[Regions/Lumbaya|Lumbaya]], [[Regions/Cinderhole|Cinderhole]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Demons A|loot_demon_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Demon Core\|Demon Core]] | 60% | 1–3 |
| [[Items/Horn Shard\|Horn Shard]] | 30% | 1–1 |
| [[Items/Brimstone\|Brimstone]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Nox Dominion\|Nox Dominion]] | 5 | S+, S, S-, A- | 132–203 | Day & Night |
| [[Regions/Cinderhole\|Cinderhole]] | 4 | A-, S-, S+ | 132–203 | Day & Night |
| [[Regions/Lumbaya\|Lumbaya]] | 2 | S-, A- | 132–173 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04766` | Nox Dominion Rot Demon Knight Elderborn | [[Regions/Nox Dominion\|Nox Dominion]] | Elderborn | S+ | 203 | 3.38 m | Day & Night | Like a typical Rot Demon Knight, but old and wise, with greying features and a cautious hunting style, with red-black coloring with faint ember veins. |
| `pop_04767` | Cinderhole Rot Demon Knight Runt | [[Regions/Cinderhole\|Cinderhole]] | Runt | A- | 132 | 1.75 m | Day & Night | Like a typical Rot Demon Knight, but smaller and scrappier than usual, with soot-stained hide and scavenged scraps. |
| `pop_04768` | Nox Dominion Rot Demon Knight Alpha | [[Regions/Nox Dominion\|Nox Dominion]] | Alpha | S | 188 | 3.13 m | Day & Night | Like a typical Rot Demon Knight, but larger and scarred, and others of its kind follow it, with red-black coloring with faint ember veins. |
| `pop_04769` | Cinderhole Rot Demon Knight Albino | [[Regions/Cinderhole\|Cinderhole]] | Albino | S- | 173 | 2.5 m | Day & Night | Like a typical Rot Demon Knight, but a rare pale form with white skin or fur and red eyes. |
| `pop_04770` | Cinderhole Rot Demon Knight Elderborn | [[Regions/Cinderhole\|Cinderhole]] | Elderborn | S+ | 203 | 3.38 m | Day & Night | Like a typical Rot Demon Knight, but old and wise, with greying features and a cautious hunting style, with soot-stained hide and scavenged scraps. |
| `pop_04771` | Lumbaya Rot Demon Knight Scarred | [[Regions/Lumbaya\|Lumbaya]] | Scarred | S- | 173 | 2.75 m | Day & Night | Like a typical Rot Demon Knight, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_04772` | Nox Dominion Rot Demon Knight Scarred | [[Regions/Nox Dominion\|Nox Dominion]] | Scarred | S- | 173 | 2.75 m | Day & Night | Like a typical Rot Demon Knight, but covered in old battle scars, with red-black coloring with faint ember veins. |
| `pop_04773` | Nox Dominion Rot Demon Knight Albino | [[Regions/Nox Dominion\|Nox Dominion]] | Albino | S- | 173 | 2.5 m | Day & Night | Like a typical Rot Demon Knight, but a rare pale form with white skin or fur and red eyes. |
| `pop_04774` | Lumbaya Rot Demon Knight Runt | [[Regions/Lumbaya\|Lumbaya]] | Runt | A- | 132 | 1.75 m | Day & Night | Like a typical Rot Demon Knight, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_04775` | Cinderhole Rot Demon Knight Scarred | [[Regions/Cinderhole\|Cinderhole]] | Scarred | S- | 173 | 2.75 m | Day & Night | Like a typical Rot Demon Knight, but covered in old battle scars, with soot-stained hide and scavenged scraps. |
| `pop_04776` | Nox Dominion Rot Demon Knight Runt | [[Regions/Nox Dominion\|Nox Dominion]] | Runt | A- | 132 | 1.75 m | Day & Night | Like a typical Rot Demon Knight, but smaller and scrappier than usual, with red-black coloring with faint ember veins. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `demon_hide_emissive` · VFX `toxic_fog` · palette `#614674` `#443754` `#b8e986` · triangle-based silhouette, sharp asymmetric spikes
