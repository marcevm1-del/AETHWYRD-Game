---
type: monster
id: mon_blight_arch_demon
family: "Demons"
rank: "S+"
tier: variant
tags: [monster, demons]
---
# Blight Arch Demon

![[mon_blight_arch_demon_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_blight_arch_demon_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Blight Arch Demon is a huge creature with a sleek flying build, about 8 m long. Its hide is rough, scarred and spiked, colored in bruise purple with sickly green. Its most striking feature is four wings and a voice like a choir. It has eyes that catch torchlight like coins. Its regal silhouette is crowned by a halo-like ring of aura. It strides with heavy steps, surrounded by a low toxic haze that clings to the ground. This Poison-attuned variant carries one extra elemental feature, like element-scarred hide, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Demons|Demons]] · Demon |
| Variant of | [[Monsters/Demons/Arch Demon\|Arch Demon]] (elemental) |
| Rank · level | S+ · 203 (188–218) |
| Menace | 3 · Menacing |
| Element · weakness | Poison · Light |
| Size | 8 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 56724 · 986 · 822 · 658 · 740 · 100 |
| XP · gold | 14769 · 2553 |
| Ring | 9 |
| Rig · animation | [[Systems/Rigs/wyvern\|wyvern]] · `anim_wyvern` |
| Habitats | [[Regions/Nox Dominion\|Nox Dominion]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] |
| Genre | Abyssal |
| Trope | Demons as a people of the Abyss, not just evil (Frieren, Maoyuu) |

**Field note:** Weak to Light. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/wyvern|wyvern]] (rigId); animation set `anim_wyvern`.
- **Dimensions:** 4 m high × 8 m long × 12.21 m wide; prefab scale 1.333.
- **Physics:** 2355.2 kg, gravity ×1, poise 303, knockback resistance 0.98, death style `crash_slide`.
- **Navigation:** speed 5.97 m/s, turn 212°/s, stopping distance 1.04 m.
- **Attack count:** 5; **signature:** four wings and a voice like a choir.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Talon Rake\|Talon Rake]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Dive Bomb\|Dive Bomb]] | dash | 1.9 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Tail Whip\|Tail Whip]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Hellfire Brand\|Hellfire Brand]] | magic | 1.4 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Blight Arch Demon is a **menacing demon** encountered at S+ rank, around level 203. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** four wings and a voice like a choir. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Nox Dominion|Nox Dominion]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_wyvern`, animation set `anim_wyvern`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Demons S|loot_demon_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Demon Core\|Demon Core]] | 60% | 1–3 |
| [[Items/Horn Shard\|Horn Shard]] | 30% | 1–1 |
| [[Items/Brimstone\|Brimstone]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 6 | S+, S, SS+, SS, S-, SS- | 173–253 | Day & Night |
| [[Regions/Nox Dominion\|Nox Dominion]] | 5 | SS+, S+, S, S-, SS- | 173–253 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04777` | Great Labyrinth (Floors 41-90) Blight Arch Demon | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Adult | S+ | 203 | 8 m | Day & Night | A typical adult Blight Arch Demon of this region, with dust-grey coloring and old rune scars. |
| `pop_04778` | Great Labyrinth (Floors 41-90) Blight Arch Demon Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | S | 188 | 6.8 m | Day & Night | Like a typical Blight Arch Demon, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_04779` | Nox Dominion Blight Arch Demon Elderborn | [[Regions/Nox Dominion\|Nox Dominion]] | Elderborn | SS+ | 253 | 10.8 m | Day & Night | Like a typical Blight Arch Demon, but old and wise, with greying features and a cautious hunting style, with red-black coloring with faint ember veins. |
| `pop_04780` | Nox Dominion Blight Arch Demon | [[Regions/Nox Dominion\|Nox Dominion]] | Adult | S+ | 203 | 8 m | Day & Night | A typical adult Blight Arch Demon of this region, with red-black coloring with faint ember veins. |
| `pop_04781` | Great Labyrinth (Floors 41-90) Blight Arch Demon Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | SS+ | 253 | 10.8 m | Day & Night | Like a typical Blight Arch Demon, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_04782` | Great Labyrinth (Floors 41-90) Blight Arch Demon Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | SS | 236 | 10 m | Day & Night | Like a typical Blight Arch Demon, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_04783` | Nox Dominion Blight Arch Demon Juvenile | [[Regions/Nox Dominion\|Nox Dominion]] | Juvenile | S | 188 | 6.8 m | Day & Night | Like a typical Blight Arch Demon, but young, with brighter colors and unworn features, with red-black coloring with faint ember veins. |
| `pop_04784` | Nox Dominion Blight Arch Demon Runt | [[Regions/Nox Dominion\|Nox Dominion]] | Runt | S- | 173 | 5.6 m | Day & Night | Like a typical Blight Arch Demon, but smaller and scrappier than usual, with red-black coloring with faint ember veins. |
| `pop_04785` | Great Labyrinth (Floors 41-90) Blight Arch Demon Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | S- | 173 | 5.6 m | Day & Night | Like a typical Blight Arch Demon, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_04786` | Great Labyrinth (Floors 41-90) Blight Arch Demon Albino | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Albino | SS- | 218 | 8 m | Day & Night | Like a typical Blight Arch Demon, but a rare pale form with white skin or fur and red eyes. |
| `pop_04787` | Nox Dominion Blight Arch Demon Albino | [[Regions/Nox Dominion\|Nox Dominion]] | Albino | SS- | 218 | 8 m | Day & Night | Like a typical Blight Arch Demon, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_wyvern` · mesh `wyvern_base` · material `demon_hide_emissive` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · triangle-based silhouette, sharp asymmetric spikes
