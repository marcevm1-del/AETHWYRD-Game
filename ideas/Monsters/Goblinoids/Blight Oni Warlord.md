---
type: monster
id: mon_blight_oni_warlord
family: "Goblinoids"
rank: "S+"
tier: variant
tags: [monster, goblinoids]
---
# Blight Oni Warlord

![[mon_blight_oni_warlord_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_blight_oni_warlord_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 20,000 tris · 4.734 × 3.729 × 4.499 m · local file `Game/Assets/_Game/Art/Models/Monsters/Goblinoids/mon_blight_oni_warlord.fbx`

> The Blight Oni Warlord is a large creature with a massive hunched brute frame, about 4.5 m tall. Its skin is rough, scarred and spiked, colored in grey-green and patched leather. Its most striking feature is a towering horned silhouette carrying an iron club wrapped in prayer chains. It has burning slit pupils. Its regal silhouette is crowned by a halo-like ring of aura. It circles its prey, surrounded by a low toxic haze that clings to the ground. This Poison-attuned variant carries one extra elemental feature, like crystal spikes, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Variant of | [[Monsters/Goblinoids/Oni Warlord\|Oni Warlord]] (elemental) |
| Rank · level | S+ · 203 (188–218) |
| Menace | 3 · Menacing |
| Element · weakness | Poison · Light |
| Size | 4.5 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 60516 · 822 · 1233 · 493 · 822 · 70 |
| XP · gold | 14769 · 2553 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/large_biped\|large_biped]] · `anim_large_biped` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Light. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/large_biped|large_biped]] (rigId); animation set `anim_large_biped`.
- **Dimensions:** 4.5 m high × 1.35 m long × 1.89 m wide; prefab scale 1.286.
- **Physics:** 1640.3 kg, gravity ×1.3, poise 302, knockback resistance 0.93, death style `heavy_fall_dust`.
- **Navigation:** speed 7.27 m/s, turn 179°/s, stopping distance 1.3 m.
- **Attack count:** 5; **signature:** a towering horned silhouette carrying an iron club wrapped in prayer chains.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stomp\|Stomp]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Club Slam\|Club Slam]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grab and Throw\|Grab and Throw]] | grab | 2 | 14 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Sand Toss\|Sand Toss]] | debuff | 0 | 12 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Blight Oni Warlord is a **menacing humanoid** encountered at S+ rank, around level 203. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a towering horned silhouette carrying an iron club wrapped in prayer chains. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_large_biped`, animation set `anim_large_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

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
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 6 | SS, S, S-, S+, SS-, SS+ | 173–253 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 5 | S-, SS+, S+, SS- | 173–253 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06022` | Great Labyrinth (Floors 41-90) Blight Oni Warlord Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | SS | 236 | 5.63 m | Day & Night | Like a typical Blight Oni Warlord, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_06023` | Great Labyrinth (Floors 41-90) Blight Oni Warlord Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | S | 188 | 3.82 m | Day & Night | Like a typical Blight Oni Warlord, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_06024` | Moraveil Blight Oni Warlord Runt | [[Regions/Moraveil\|Moraveil]] | Runt | S- | 173 | 3.15 m | Day & Night | Like a typical Blight Oni Warlord, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_06025` | Moraveil Blight Oni Warlord Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | SS+ | 253 | 6.08 m | Day & Night | Like a typical Blight Oni Warlord, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_06026` | Moraveil Blight Oni Warlord | [[Regions/Moraveil\|Moraveil]] | Adult | S+ | 203 | 4.5 m | Day & Night | A typical adult Blight Oni Warlord of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_06027` | Great Labyrinth (Floors 41-90) Blight Oni Warlord Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | S- | 173 | 3.15 m | Day & Night | Like a typical Blight Oni Warlord, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_06028` | Moraveil Blight Oni Warlord Albino | [[Regions/Moraveil\|Moraveil]] | Albino | SS- | 218 | 4.5 m | Day & Night | Like a typical Blight Oni Warlord, but a rare pale form with white skin or fur and red eyes. |
| `pop_06029` | Great Labyrinth (Floors 41-90) Blight Oni Warlord | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Adult | S+ | 203 | 4.5 m | Day & Night | A typical adult Blight Oni Warlord of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_06030` | Moraveil Blight Oni Warlord Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | SS- | 218 | 4.95 m | Day & Night | Like a typical Blight Oni Warlord, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_06031` | Great Labyrinth (Floors 41-90) Blight Oni Warlord Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | SS- | 218 | 4.95 m | Day & Night | Like a typical Blight Oni Warlord, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_06032` | Great Labyrinth (Floors 41-90) Blight Oni Warlord Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | SS+ | 253 | 6.08 m | Day & Night | Like a typical Blight Oni Warlord, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `rough_skin_leather` · VFX `toxic_fog` · palette `#7b956f` `#5e5134` `#b8e986` · triangle-based silhouette, sharp asymmetric spikes
