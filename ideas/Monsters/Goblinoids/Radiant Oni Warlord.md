---
type: monster
id: mon_radiant_oni_warlord
family: "Goblinoids"
rank: "S+"
tier: variant
tags: [monster, goblinoids]
---
# Radiant Oni Warlord

> The Radiant Oni Warlord is a large creature with a giant, barrel-chested humanoid body, about 4.5 m tall. Its skin is rough, scarred and spiked, colored in warm gold and pearl white. Look for a towering horned silhouette carrying an iron club wrapped in prayer chains. It has burning slit pupils. Its regal silhouette is crowned by a halo-like ring of aura. It strides with heavy steps, surrounded by soft radiance and floating motes of light. This Light-attuned variant carries one extra elemental feature, like crystal spikes, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Variant of | [[Monsters/Goblinoids/Oni Warlord\|Oni Warlord]] (elemental) |
| Rank · level | S+ · 203 (188–218) |
| Menace | 3 · Menacing |
| Element · weakness | Light · Dark |
| Size | 4.5 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 60516 · 822 · 1233 · 493 · 822 · 70 |
| XP · gold | 14769 · 2553 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/large_biped\|large_biped]] · `anim_large_biped` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Shen-Lu\|Shen-Lu]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Dark. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/large_biped|large_biped]] (rigId); animation set `anim_large_biped`.
- **Dimensions:** 4.5 m high × 1.35 m long × 1.89 m wide; prefab scale 1.286.
- **Physics:** 1558.2 kg, gravity ×1.17, poise 302, knockback resistance 0.93, death style `heavy_fall_dust`.
- **Navigation:** speed 7.49 m/s, turn 179°/s, stopping distance 1.3 m.
- **Attack count:** 5; **signature:** a towering horned silhouette carrying an iron club wrapped in prayer chains.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stomp\|Stomp]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Club Slam\|Club Slam]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grab and Throw\|Grab and Throw]] | grab | 2 | 14 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Sand Toss\|Sand Toss]] | debuff | 0 | 12 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Radiant Oni Warlord is a **menacing humanoid** encountered at S+ rank, around level 203. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a towering horned silhouette carrying an iron club wrapped in prayer chains. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Shen-Lu|Shen-Lu]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Moraveil\|Moraveil]] | 7 | SS-, SS, S-, S, S+, SS+ | 173–253 | Day & Night |
| [[Regions/Shen-Lu\|Shen-Lu]] | 4 | S, S+, SS-, S- | 173–218 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03181` | Moraveil Radiant Oni Warlord Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | SS- | 218 | 4.95 m | Day & Night | Like a typical Radiant Oni Warlord, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_03182` | Moraveil Radiant Oni Warlord Albino | [[Regions/Moraveil\|Moraveil]] | Albino | SS- | 218 | 4.5 m | Day & Night | Like a typical Radiant Oni Warlord, but a rare pale form with white skin or fur and red eyes. |
| `pop_03183` | Moraveil Radiant Oni Warlord Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | SS | 236 | 5.63 m | Day & Night | Like a typical Radiant Oni Warlord, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_03184` | Shen-Lu Radiant Oni Warlord Juvenile | [[Regions/Shen-Lu\|Shen-Lu]] | Juvenile | S | 188 | 3.82 m | Day & Night | Like a typical Radiant Oni Warlord, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_03185` | Moraveil Radiant Oni Warlord Runt | [[Regions/Moraveil\|Moraveil]] | Runt | S- | 173 | 3.15 m | Day & Night | Like a typical Radiant Oni Warlord, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_03186` | Moraveil Radiant Oni Warlord Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | S | 188 | 3.82 m | Day & Night | Like a typical Radiant Oni Warlord, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_03187` | Moraveil Radiant Oni Warlord | [[Regions/Moraveil\|Moraveil]] | Adult | S+ | 203 | 4.5 m | Day & Night | A typical adult Radiant Oni Warlord of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_03188` | Shen-Lu Radiant Oni Warlord | [[Regions/Shen-Lu\|Shen-Lu]] | Adult | S+ | 203 | 4.5 m | Day & Night | A typical adult Radiant Oni Warlord of this region, with slate-grey coloring and hardened hide. |
| `pop_03189` | Moraveil Radiant Oni Warlord Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | SS+ | 253 | 6.08 m | Day & Night | Like a typical Radiant Oni Warlord, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_03190` | Shen-Lu Radiant Oni Warlord Albino | [[Regions/Shen-Lu\|Shen-Lu]] | Albino | SS- | 218 | 4.5 m | Day & Night | Like a typical Radiant Oni Warlord, but a rare pale form with white skin or fur and red eyes. |
| `pop_03191` | Shen-Lu Radiant Oni Warlord Runt | [[Regions/Shen-Lu\|Shen-Lu]] | Runt | S- | 173 | 3.15 m | Day & Night | Like a typical Radiant Oni Warlord, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `rough_skin_leather` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · triangle-based silhouette, sharp asymmetric spikes
