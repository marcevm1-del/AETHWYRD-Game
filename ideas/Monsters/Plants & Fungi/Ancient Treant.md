---
type: monster
id: mon_ancient_treant
family: "Plants & Fungi"
rank: "S"
tier: core
tags: [monster, plants-fungi]
---
# Ancient Treant

![[mon_ancient_treant_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ancient_treant_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 30,000 tris · 20.352 × 13.592 × 30 m · local file `Game/Assets/_Game/Art/Models/Monsters/Plants & Fungi/mon_ancient_treant.fbx`

> The Ancient Treant is a colossal creature with a mushroom-capped walking body, about 30 m tall. Its bark and leaves are weathered and natural, colored in leaf green over bark brown. Its most striking feature is a forest growing from its shoulders. It has dark, wary eyes. Its regal silhouette is crowned by a halo-like ring of aura. It stalks low to the ground, surrounded by drifting pollen and tiny blossoms.

| Field | Value |
|---|---|
| Family · type | [[Families/Plants & Fungi|Plants & Fungi]] · Plant |
| Rank · level | S · 188 (173–203) |
| Menace | 2 · Wild |
| Element · weakness | Nature · Fire |
| Size | 30 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 64647 · 953 · 686 · 686 · 686 · 100 |
| XP · gold | 13063 · 2293 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/giant_biped\|giant_biped]] · `anim_plant_walker` |
| Habitats | [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Moraveil\|Moraveil]] |
| Genre | Fairy-tale Forest |
| Trope | Screaming mandrakes, walking mushrooms and ancient treants |

**Field note:** Weak to Fire. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/giant_biped|giant_biped]] (override); animation set `anim_plant_walker`.
- **Dimensions:** 30 m high × 10.2 m long × 13.2 m wide; prefab scale 3.
- **Physics:** 432000 kg, gravity ×1, poise 2817, knockback resistance 1, death style `cinematic_collapse`.
- **Navigation:** speed 10.13 m/s, turn 60°/s, stopping distance 5.8 m.
- **Attack count:** 5; **signature:** [object Object].

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Branch Sweep\|Branch Sweep]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Root Slam\|Root Slam]] | aoe | 1.5 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Regrow\|Regrow]] | heal | 0 | 20 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Root Bind\|Root Bind]] | grab | 1 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Thorn Volley\|Thorn Volley]] | magic | 1.5 | 10 s | Nature | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Ancient Treant is a **wild plant** encountered at S rank, around level 188. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a forest growing from its shoulders. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Shen-Lu|Shen-Lu]], [[Regions/Moraveil|Moraveil]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_plant_walker`, animation set `anim_plant_walker`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Plants & Fungi S|loot_plant_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Sap\|Sap]] | 60% | 1–3 |
| [[Items/Seed\|Seed]] | 30% | 1–1 |
| [[Items/Spore Cap\|Spore Cap]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Plants & Fungi/Bog Ancient Treant|Bog Ancient Treant]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Moraveil\|Moraveil]] | 6 | SS-, A+, S+, S, SS | 159–236 | Day & Night |
| [[Regions/Shen-Lu\|Shen-Lu]] | 5 | S, A+, S+, SS-, SS | 159–236 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01790` | Moraveil Ancient Treant Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | SS- | 218 | 37.5 m | Day & Night | Like a typical Ancient Treant, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_01791` | Shen-Lu Ancient Treant | [[Regions/Shen-Lu\|Shen-Lu]] | Adult | S | 188 | 30 m | Day & Night | A typical adult Ancient Treant of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_01792` | Shen-Lu Ancient Treant Runt | [[Regions/Shen-Lu\|Shen-Lu]] | Runt | A+ | 159 | 21 m | Day & Night | Like a typical Ancient Treant, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_01793` | Moraveil Ancient Treant Runt | [[Regions/Moraveil\|Moraveil]] | Runt | A+ | 159 | 21 m | Day & Night | Like a typical Ancient Treant, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_01794` | Moraveil Ancient Treant Albino | [[Regions/Moraveil\|Moraveil]] | Albino | S+ | 203 | 30 m | Day & Night | Like a typical Ancient Treant, but a rare pale form with white skin or fur and red eyes. |
| `pop_01795` | Moraveil Ancient Treant Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | S+ | 203 | 33 m | Day & Night | Like a typical Ancient Treant, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_01796` | Shen-Lu Ancient Treant Scarred | [[Regions/Shen-Lu\|Shen-Lu]] | Scarred | S+ | 203 | 33 m | Day & Night | Like a typical Ancient Treant, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_01797` | Shen-Lu Ancient Treant Alpha | [[Regions/Shen-Lu\|Shen-Lu]] | Alpha | SS- | 218 | 37.5 m | Day & Night | Like a typical Ancient Treant, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_01798` | Moraveil Ancient Treant | [[Regions/Moraveil\|Moraveil]] | Adult | S | 188 | 30 m | Day & Night | A typical adult Ancient Treant of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_01799` | Shen-Lu Ancient Treant Elderborn | [[Regions/Shen-Lu\|Shen-Lu]] | Elderborn | SS | 236 | 40.5 m | Day & Night | Like a typical Ancient Treant, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_01800` | Moraveil Ancient Treant Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | SS | 236 | 40.5 m | Day & Night | Like a typical Ancient Treant, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_plant_walker` · mesh `plant_walker_base` · material `bark_leaf` · VFX `pollen_petals` · palette `#5d963e` `#614934` `#8fd16a` · real-animal silhouette with one fantasy exaggeration
