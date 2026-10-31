---
type: monster
id: mon_pale_herald
family: "The Headless"
rank: "S"
tier: core
tags: [monster, the-headless]
---
# Pale Herald

![[mon_pale_herald_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_pale_herald_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,872 tris · 1.555 × 3.245 × 3.5 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Pale Herald is a large creature with a tall, headless knightly build, about 3.5 m tall. Its armor is patchy and subtly wrong, as if assembled from memory, colored in violet-black, with violet-edged markings. Guild sketches always show a cape of fog trailing behind a headless knight. It has eyes set slightly too far apart. Its regal silhouette is crowned by a halo-like ring of aura. It glides without moving its legs, surrounded by warped air, as if space bends around it.

| Field | Value |
|---|---|
| Family · type | [[Families/The Headless|The Headless]] · Undead |
| Rank · level | S · 188 (173–203) |
| Menace | 4 · Dread |
| Element · weakness | Void · Light |
| Size | 3.5 m |
| Behaviour | Guardian (guardian_hold+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 49707 · 762 · 1143 · 457 · 762 · 70 |
| XP · gold | 13063 · 2293 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_headless` |
| Habitats | [[Regions/Sky Archipelago\|Sky Archipelago]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] |
| Genre | Celtic Gothic |
| Trope | The dullahan of Irish folklore |

**Field note:** Weak to Light. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_headless`.
- **Dimensions:** 3.5 m high × 1.05 m long × 1.12 m wide; prefab scale 1.944.
- **Physics:** 557.4 kg, gravity ×1.05, poise 132, knockback resistance 0.48, death style `ragdoll`.
- **Navigation:** speed 5.9 m/s, turn 214°/s, stopping distance 1 m.
- **Attack count:** 5; **signature:** a cape of fog trailing behind a headless knight.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Sweep\|Sweep]] | melee | 1.3 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Charge\|Charge]] | dash | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Head Throw\|Head Throw]] | ranged | 1.4 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Lantern Hurl\|Lantern Hurl]] | ranged | 1.3 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Null Rift\|Null Rift]] | magic | 1.5 | 10 s | Void | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Pale Herald is a **dread undead** encountered at S rank, around level 188. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a cape of fog trailing behind a headless knight. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Sky Archipelago|Sky Archipelago]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_headless`, animation set `anim_headless`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/The Headless S|loot_headless_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Rider's Lantern\|Rider's Lantern]] | 60% | 1–3 |
| [[Items/Cursed Iron\|Cursed Iron]] | 30% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/The Headless/Phantom Pale Herald|Phantom Pale Herald]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 6 | S, S+, S-, SS, SS- | 173–236 | Night |
| [[Regions/Sky Archipelago\|Sky Archipelago]] | 5 | S, SS-, S+, S- | 173–218 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02351` | Great Labyrinth (Floors 41-90) Pale Herald | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Adult | S | 188 | 3.5 m | Night | A typical adult Pale Herald of this region, with dust-grey coloring and old rune scars. |
| `pop_02352` | Great Labyrinth (Floors 41-90) Pale Herald Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | S+ | 203 | 3.85 m | Night | Like a typical Pale Herald, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_02353` | Sky Archipelago Pale Herald | [[Regions/Sky Archipelago\|Sky Archipelago]] | Adult | S | 188 | 3.5 m | Night | A typical adult Pale Herald of this region, with dust-grey coloring and old rune scars. |
| `pop_02354` | Great Labyrinth (Floors 41-90) Pale Herald Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | S- | 173 | 2.98 m | Night | Like a typical Pale Herald, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_02355` | Sky Archipelago Pale Herald Alpha | [[Regions/Sky Archipelago\|Sky Archipelago]] | Alpha | SS- | 218 | 4.38 m | Night | Like a typical Pale Herald, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_02356` | Great Labyrinth (Floors 41-90) Pale Herald Albino | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Albino | S+ | 203 | 3.5 m | Night | Like a typical Pale Herald, but a rare pale form with white skin or fur and red eyes. |
| `pop_02357` | Great Labyrinth (Floors 41-90) Pale Herald Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | SS | 236 | 4.73 m | Night | Like a typical Pale Herald, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_02358` | Sky Archipelago Pale Herald Albino | [[Regions/Sky Archipelago\|Sky Archipelago]] | Albino | S+ | 203 | 3.5 m | Night | Like a typical Pale Herald, but a rare pale form with white skin or fur and red eyes. |
| `pop_02359` | Sky Archipelago Pale Herald Scarred | [[Regions/Sky Archipelago\|Sky Archipelago]] | Scarred | S+ | 203 | 3.85 m | Night | Like a typical Pale Herald, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_02360` | Sky Archipelago Pale Herald Juvenile | [[Regions/Sky Archipelago\|Sky Archipelago]] | Juvenile | S- | 173 | 2.98 m | Night | Like a typical Pale Herald, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_02361` | Great Labyrinth (Floors 41-90) Pale Herald Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | SS- | 218 | 4.38 m | Night | Like a typical Pale Herald, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_headless` · mesh `headless_base` · material `old_iron` · VFX `void_distortion` · palette `#6b5c8f` `#594c7b` `#8a7cff` · elongated, irregular silhouette; still-then-sudden timing
