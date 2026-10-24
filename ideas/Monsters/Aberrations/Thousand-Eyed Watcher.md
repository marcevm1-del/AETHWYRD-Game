---
type: monster
id: mon_thousand_eyed_watcher
family: "Aberrations"
rank: "A"
tier: core
tags: [monster, aberrations]
---
# Thousand-Eyed Watcher

> The Thousand-Eyed Watcher is a huge creature with a bodiless, glowing form, about 6 m tall. Its skin is stretched, stitched and constantly shifting, colored in starless black with faint violet edges. Its most striking feature is a cloud of eyes that blink in sequence. It has no eyes at all, only a wide and patient mouth. An elegant crest and glowing veins of mana mark it as a champion of its kind. It crawls across ceilings, surrounded by warped air, as if space bends around it.

| Field | Value |
|---|---|
| Family · type | [[Families/Aberrations|Aberrations]] · Aberration |
| Rank · level | A · 146 (132–159) |
| Menace | 5 · Horror |
| Element · weakness | Void · Light |
| Size | 6 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 23119 · 356 · 416 · 832 · 772 · 90 |
| XP · gold | 8719 · 1611 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/spirit_float\|spirit_float]] · `anim_floating` |
| Habitats | [[Regions/Aurumdeep\|Aurumdeep]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Sky Archipelago\|Sky Archipelago]], [[Regions/The Maw\|The Maw]] |
| Genre | Cosmic Horror |
| Trope | Mimicking things in the dark |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/spirit_float|spirit_float]] (rigId); animation set `anim_floating`.
- **Dimensions:** 6 m high × 1.8 m long × 3.84 m wide; prefab scale 6.
- **Physics:** 21.6 kg, gravity ×0, poise 116, knockback resistance 0.15, death style `dissolve_into_motes`.
- **Navigation:** speed 15.35 m/s, turn 294°/s, stopping distance 1.9 m.
- **Attack count:** 5; **signature:** a cloud of eyes that blink in sequence.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Chill Touch\|Chill Touch]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Phase Lunge\|Phase Lunge]] | dash | 1.3 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wail\|Wail]] | aoe | 1.2 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Mimic Lure\|Mimic Lure]] | debuff | 0 | 16 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Null Rift\|Null Rift]] | magic | 1.5 | 10 s | Void | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Thousand-Eyed Watcher is a **horror aberration** encountered at A rank, around level 146. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a cloud of eyes that blink in sequence. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aurumdeep|Aurumdeep]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Sky Archipelago|Sky Archipelago]], [[Regions/The Maw|The Maw]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_floating`, animation set `anim_floating`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Aberrations A|loot_aberration_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Unreal Fragment\|Unreal Fragment]] | 60% | 1–3 |
| [[Items/Eye of Nothing\|Eye of Nothing]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Aberrations/Deep Thousand-Eyed Watcher|Deep Thousand-Eyed Watcher]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 4 | S, A, B+, A- | 120–188 | Night |
| [[Regions/Sky Archipelago\|Sky Archipelago]] | 4 | A, S, A+, S- | 146–188 | Night |
| [[Regions/Aurumdeep\|Aurumdeep]] | 1 | A+ | 159–159 | Night |
| [[Regions/The Maw\|The Maw]] | 2 | S-, B+ | 120–173 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02439` | Great Labyrinth (Floors 41-90) Thousand-Eyed Watcher Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | S | 188 | 8.1 m | Night | Like a typical Thousand-Eyed Watcher, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_02440` | Great Labyrinth (Floors 41-90) Thousand-Eyed Watcher | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Adult | A | 146 | 6 m | Night | A typical adult Thousand-Eyed Watcher of this region, with dust-grey coloring and old rune scars. |
| `pop_02441` | Sky Archipelago Thousand-Eyed Watcher | [[Regions/Sky Archipelago\|Sky Archipelago]] | Adult | A | 146 | 6 m | Night | A typical adult Thousand-Eyed Watcher of this region, with dust-grey coloring and old rune scars. |
| `pop_02442` | Sky Archipelago Thousand-Eyed Watcher Elderborn | [[Regions/Sky Archipelago\|Sky Archipelago]] | Elderborn | S | 188 | 8.1 m | Night | Like a typical Thousand-Eyed Watcher, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_02443` | Great Labyrinth (Floors 41-90) Thousand-Eyed Watcher Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | B+ | 120 | 4.2 m | Night | Like a typical Thousand-Eyed Watcher, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_02444` | Aurumdeep Thousand-Eyed Watcher Scarred | [[Regions/Aurumdeep\|Aurumdeep]] | Scarred | A+ | 159 | 6.6 m | Night | Like a typical Thousand-Eyed Watcher, but covered in old battle scars, with bioluminescent spots along its body. |
| `pop_02445` | The Maw Thousand-Eyed Watcher Alpha | [[Regions/The Maw\|The Maw]] | Alpha | S- | 173 | 7.5 m | Night | Like a typical Thousand-Eyed Watcher, but larger and scarred, and others of its kind follow it, with bioluminescent spots along its body. |
| `pop_02446` | The Maw Thousand-Eyed Watcher Runt | [[Regions/The Maw\|The Maw]] | Runt | B+ | 120 | 4.2 m | Night | Like a typical Thousand-Eyed Watcher, but smaller and scrappier than usual, with bioluminescent spots along its body. |
| `pop_02447` | Great Labyrinth (Floors 41-90) Thousand-Eyed Watcher Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | A- | 132 | 5.1 m | Night | Like a typical Thousand-Eyed Watcher, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_02448` | Sky Archipelago Thousand-Eyed Watcher Albino | [[Regions/Sky Archipelago\|Sky Archipelago]] | Albino | A+ | 159 | 6 m | Night | Like a typical Thousand-Eyed Watcher, but a rare pale form with white skin or fur and red eyes. |
| `pop_02449` | Sky Archipelago Thousand-Eyed Watcher Alpha | [[Regions/Sky Archipelago\|Sky Archipelago]] | Alpha | S- | 173 | 7.5 m | Night | Like a typical Thousand-Eyed Watcher, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `wet_flesh_unsettling` · VFX `void_distortion` · palette `#0b0b1a` `#3d2c8d` `#c9c9ff` · broken symmetry, mimicry, audio-first reveal
