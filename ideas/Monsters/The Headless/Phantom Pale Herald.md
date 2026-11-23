---
type: monster
id: mon_phantom_pale_herald
family: "The Headless"
rank: "S+"
tier: variant
tags: [monster, the-headless]
---
# Phantom Pale Herald

![[mon_phantom_pale_herald_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_phantom_pale_herald_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 20,000 tris · 2.118 × 4.931 × 3.5 m · local file `Game/Assets/_Game/Art/Models/Monsters/The Headless/mon_phantom_pale_herald.fbx`

> The Phantom Pale Herald is a large creature with an armored humanoid body without a head, about 3.5 m tall. Its armor is stretched, stitched and constantly shifting, colored in violet-black, with gold markings. Guild sketches always show a cape of fog trailing behind a headless knight. It has no eyes at all, only a wide and patient mouth. Its regal silhouette is crowned by a halo-like ring of aura. It unfolds into something larger, surrounded by soft radiance and floating motes of light. Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.

| Field | Value |
|---|---|
| Family · type | [[Families/The Headless|The Headless]] · Undead |
| Variant of | [[Monsters/The Headless/Pale Herald\|Pale Herald]] (spirit) |
| Rank · level | S+ · 203 (188–218) |
| Menace | 5 · Horror |
| Element · weakness | Light · Dark |
| Size | 3.5 m |
| Behaviour | Guardian (guardian_hold+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 55757 · 822 · 1233 · 493 · 822 · 70 |
| XP · gold | 14769 · 2553 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_headless` |
| Habitats | [[Regions/Sky Archipelago\|Sky Archipelago]], [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] |
| Genre | Celtic Gothic |
| Trope | The dullahan of Irish folklore |

**Field note:** Weak to Dark. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_headless`.
- **Dimensions:** 3.5 m high × 1.05 m long × 1.12 m wide; prefab scale 1.944.
- **Physics:** 529.5 kg, gravity ×1.35, poise 132, knockback resistance 0.48, death style `ragdoll`.
- **Navigation:** speed 6.19 m/s, turn 214°/s, stopping distance 1 m.
- **Attack count:** 5; **signature:** a cape of fog trailing behind a headless knight.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Sweep\|Sweep]] | melee | 1.3 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Charge\|Charge]] | dash | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Head Throw\|Head Throw]] | ranged | 1.4 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Lantern Hurl\|Lantern Hurl]] | ranged | 1.3 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Phantom Pale Herald is a **horror undead** encountered at S+ rank, around level 203. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a cape of fog trailing behind a headless knight. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Sky Archipelago|Sky Archipelago]], [[Regions/Great Labyrinth (Floors 91-120)|Great Labyrinth (Floors 91-120)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_headless`, animation set `anim_headless`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/The Headless S|loot_headless_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Rider's Lantern\|Rider's Lantern]] | 60% | 1–3 |
| [[Items/Cursed Iron\|Cursed Iron]] | 30% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Sky Archipelago\|Sky Archipelago]] | 6 | SS+, SS-, S-, S+, SS | 173–253 | Night |
| [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | 5 | SS-, S, SS+, S-, SS | 173–253 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05202` | Sky Archipelago Phantom Pale Herald Elderborn | [[Regions/Sky Archipelago\|Sky Archipelago]] | Elderborn | SS+ | 253 | 4.73 m | Night | Like a typical Phantom Pale Herald, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_05203` | Great Labyrinth (Floors 91-120) Phantom Pale Herald Albino | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Albino | SS- | 218 | 3.5 m | Night | Like a typical Phantom Pale Herald, but a rare pale form with white skin or fur and red eyes. |
| `pop_05204` | Sky Archipelago Phantom Pale Herald Scarred | [[Regions/Sky Archipelago\|Sky Archipelago]] | Scarred | SS- | 218 | 3.85 m | Night | Like a typical Phantom Pale Herald, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_05205` | Great Labyrinth (Floors 91-120) Phantom Pale Herald Juvenile | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Juvenile | S | 188 | 2.98 m | Night | Like a typical Phantom Pale Herald, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_05206` | Great Labyrinth (Floors 91-120) Phantom Pale Herald Elderborn | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Elderborn | SS+ | 253 | 4.73 m | Night | Like a typical Phantom Pale Herald, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_05207` | Sky Archipelago Phantom Pale Herald Runt | [[Regions/Sky Archipelago\|Sky Archipelago]] | Runt | S- | 173 | 2.45 m | Night | Like a typical Phantom Pale Herald, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_05208` | Sky Archipelago Phantom Pale Herald Albino | [[Regions/Sky Archipelago\|Sky Archipelago]] | Albino | SS- | 218 | 3.5 m | Night | Like a typical Phantom Pale Herald, but a rare pale form with white skin or fur and red eyes. |
| `pop_05209` | Sky Archipelago Phantom Pale Herald | [[Regions/Sky Archipelago\|Sky Archipelago]] | Adult | S+ | 203 | 3.5 m | Night | A typical adult Phantom Pale Herald of this region, with dust-grey coloring and old rune scars. |
| `pop_05210` | Great Labyrinth (Floors 91-120) Phantom Pale Herald Runt | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Runt | S- | 173 | 2.45 m | Night | Like a typical Phantom Pale Herald, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_05211` | Sky Archipelago Phantom Pale Herald Alpha | [[Regions/Sky Archipelago\|Sky Archipelago]] | Alpha | SS | 236 | 4.38 m | Night | Like a typical Phantom Pale Herald, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_05212` | Great Labyrinth (Floors 91-120) Phantom Pale Herald Alpha | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Alpha | SS | 236 | 4.38 m | Night | Like a typical Phantom Pale Herald, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_headless` · mesh `headless_base` · material `old_iron` · VFX `holy_motes` · palette `#4f527b` `#41446a` `#ffd166` · broken symmetry, mimicry, audio-first reveal
