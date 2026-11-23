---
type: monster
id: mon_oni_warlord
family: "Goblinoids"
rank: "S"
tier: core
tags: [monster, goblinoids]
---
# Oni Warlord

![[mon_oni_warlord_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_oni_warlord_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 20,000 tris · 4.683 × 3.679 × 4.501 m · local file `Game/Assets/_Game/Art/Models/Monsters/Goblinoids/mon_oni_warlord.fbx`

> The Oni Warlord is a large creature with a giant, barrel-chested humanoid body, about 4.5 m tall. Its skin is rough, scarred and spiked, colored in grey-green and patched leather, with ember-orange markings. Look for a towering horned silhouette carrying an iron club wrapped in prayer chains. It has narrow glowing eyes. Its regal silhouette is crowned by a halo-like ring of aura. It charges without hesitation, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Rank · level | S · 188 (173–203) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 4.5 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 53949 · 762 · 1143 · 457 · 762 · 70 |
| XP · gold | 13063 · 2293 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/large_biped\|large_biped]] · `anim_large_biped` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Dragon Spine\|Dragon Spine]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Water. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/large_biped|large_biped]] (rigId); animation set `anim_large_biped`.
- **Dimensions:** 4.5 m high × 1.35 m long × 1.89 m wide; prefab scale 1.286.
- **Physics:** 1640.3 kg, gravity ×1.3, poise 302, knockback resistance 0.93, death style `heavy_fall_dust`.
- **Navigation:** speed 8.24 m/s, turn 179°/s, stopping distance 1.3 m.
- **Attack count:** 5; **signature:** a towering horned silhouette carrying an iron club wrapped in prayer chains.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stomp\|Stomp]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Club Slam\|Club Slam]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grab and Throw\|Grab and Throw]] | grab | 2 | 14 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Sand Toss\|Sand Toss]] | debuff | 0 | 12 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Oni Warlord is a **menacing humanoid** encountered at S rank, around level 188. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a towering horned silhouette carrying an iron club wrapped in prayer chains. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Dragon Spine|Dragon Spine]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_large_biped`, animation set `anim_large_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Goblinoids S|loot_goblinoid_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Goblinoids/Radiant Oni Warlord|Radiant Oni Warlord]]
- [[Monsters/Goblinoids/Blight Oni Warlord|Blight Oni Warlord]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Moraveil\|Moraveil]] | 4 | SS-, A+, S-, SS | 159–236 | Day & Night |
| [[Regions/Dragon Spine\|Dragon Spine]] | 7 | S-, SS, SS-, S+, S, A+ | 159–236 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00277` | Moraveil Oni Warlord Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | SS- | 218 | 5.63 m | Day & Night | Like a typical Oni Warlord, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_00278` | Dragon Spine Oni Warlord Juvenile | [[Regions/Dragon Spine\|Dragon Spine]] | Juvenile | S- | 173 | 3.82 m | Day & Night | Like a typical Oni Warlord, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_00279` | Dragon Spine Oni Warlord Elderborn | [[Regions/Dragon Spine\|Dragon Spine]] | Elderborn | SS | 236 | 6.08 m | Day & Night | Like a typical Oni Warlord, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_00280` | Moraveil Oni Warlord Runt | [[Regions/Moraveil\|Moraveil]] | Runt | A+ | 159 | 3.15 m | Day & Night | Like a typical Oni Warlord, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_00281` | Dragon Spine Oni Warlord Alpha | [[Regions/Dragon Spine\|Dragon Spine]] | Alpha | SS- | 218 | 5.63 m | Day & Night | Like a typical Oni Warlord, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_00282` | Moraveil Oni Warlord Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | S- | 173 | 3.82 m | Day & Night | Like a typical Oni Warlord, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_00283` | Dragon Spine Oni Warlord Scarred | [[Regions/Dragon Spine\|Dragon Spine]] | Scarred | S+ | 203 | 4.95 m | Day & Night | Like a typical Oni Warlord, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_00284` | Dragon Spine Oni Warlord | [[Regions/Dragon Spine\|Dragon Spine]] | Adult | S | 188 | 4.5 m | Day & Night | A typical adult Oni Warlord of this region, with slate-grey coloring and hardened hide. |
| `pop_00285` | Dragon Spine Oni Warlord Albino | [[Regions/Dragon Spine\|Dragon Spine]] | Albino | S+ | 203 | 4.5 m | Day & Night | Like a typical Oni Warlord, but a rare pale form with white skin or fur and red eyes. |
| `pop_00286` | Moraveil Oni Warlord Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | SS | 236 | 6.08 m | Day & Night | Like a typical Oni Warlord, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_00287` | Dragon Spine Oni Warlord Runt | [[Regions/Dragon Spine\|Dragon Spine]] | Runt | A+ | 159 | 3.15 m | Day & Night | Like a typical Oni Warlord, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `rough_skin_leather` · VFX `embers_heat_haze` · palette `#738b67` `#584c31` `#ff7a3d` · triangle-based silhouette, sharp asymmetric spikes
