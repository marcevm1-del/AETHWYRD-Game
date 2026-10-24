---
type: monster
id: mon_phantom_abyss_slime
family: "Slimes"
rank: "S+"
tier: variant
tags: [monster, slimes]
---
# Phantom Abyss Slime

> The Phantom Abyss Slime is a large creature with a wobbling mound of translucent gel, about 4 m tall. Its gel is stretched, stitched and constantly shifting, colored in warm gold and pearl white. Guild sketches always show starless black jelly that swallows all light. It has a human-like face in the wrong place. Its regal silhouette is crowned by a halo-like ring of aura. It copies the walk of whatever it hunts, surrounded by soft radiance and floating motes of light. Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Variant of | [[Monsters/Slimes/Abyss Slime\|Abyss Slime]] (spirit) |
| Rank · level | S+ · 203 (188–218) |
| Menace | 5 · Horror |
| Element · weakness | Light · Dark |
| Size | 4 m |
| Behaviour | Territorial (territorial_guard+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 29128 · 658 · 493 · 493 · 493 · 110 |
| XP · gold | 14769 · 2553 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/blob\|blob]] · `anim_blob` |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Sky Archipelago\|Sky Archipelago]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Dark. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/blob|blob]] (rigId); animation set `anim_blob`.
- **Dimensions:** 4 m high × 3.72 m long × 3.6 m wide; prefab scale 8.
- **Physics:** 31920 kg, gravity ×1.44, poise 134, knockback resistance 0.28, death style `splat_dissolve`.
- **Navigation:** speed 11.39 m/s, turn 180°/s, stopping distance 2.2 m.
- **Attack count:** 5; **signature:** starless black jelly that swallows all light.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Body Slam\|Body Slam]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Split\|Split]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Acid Splash\|Acid Splash]] | ranged | 1.1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Phantom Abyss Slime is a **horror ooze** encountered at S+ rank, around level 203. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** starless black jelly that swallows all light. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Sky Archipelago|Sky Archipelago]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_blob`, animation set `anim_blob`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Slimes S|loot_slime_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Sky Archipelago\|Sky Archipelago]] | 7 | SS-, S-, S+, SS+, SS, S | 173–253 | Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 4 | SS, S+, SS+, SS- | 203–253 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05879` | Sky Archipelago Phantom Abyss Slime Albino | [[Regions/Sky Archipelago\|Sky Archipelago]] | Albino | SS- | 218 | 4 m | Night | Like a typical Phantom Abyss Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_05880` | Sky Archipelago Phantom Abyss Slime Runt | [[Regions/Sky Archipelago\|Sky Archipelago]] | Runt | S- | 173 | 2.8 m | Night | Like a typical Phantom Abyss Slime, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_05881` | Great Labyrinth (Floors 41-90) Phantom Abyss Slime Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | SS | 236 | 5 m | Night | Like a typical Phantom Abyss Slime, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_05882` | Sky Archipelago Phantom Abyss Slime | [[Regions/Sky Archipelago\|Sky Archipelago]] | Adult | S+ | 203 | 4 m | Night | A typical adult Phantom Abyss Slime of this region, with dust-grey coloring and old rune scars. |
| `pop_05883` | Sky Archipelago Phantom Abyss Slime Elderborn | [[Regions/Sky Archipelago\|Sky Archipelago]] | Elderborn | SS+ | 253 | 5.4 m | Night | Like a typical Phantom Abyss Slime, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_05884` | Sky Archipelago Phantom Abyss Slime Scarred | [[Regions/Sky Archipelago\|Sky Archipelago]] | Scarred | SS- | 218 | 4.4 m | Night | Like a typical Phantom Abyss Slime, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_05885` | Great Labyrinth (Floors 41-90) Phantom Abyss Slime | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Adult | S+ | 203 | 4 m | Night | A typical adult Phantom Abyss Slime of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_05886` | Great Labyrinth (Floors 41-90) Phantom Abyss Slime Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | SS+ | 253 | 5.4 m | Night | Like a typical Phantom Abyss Slime, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_05887` | Sky Archipelago Phantom Abyss Slime Alpha | [[Regions/Sky Archipelago\|Sky Archipelago]] | Alpha | SS | 236 | 5 m | Night | Like a typical Phantom Abyss Slime, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_05888` | Sky Archipelago Phantom Abyss Slime Juvenile | [[Regions/Sky Archipelago\|Sky Archipelago]] | Juvenile | S | 188 | 3.4 m | Night | Like a typical Phantom Abyss Slime, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_05889` | Great Labyrinth (Floors 41-90) Phantom Abyss Slime Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | SS- | 218 | 4.4 m | Night | Like a typical Phantom Abyss Slime, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · broken symmetry, mimicry, audio-first reveal
