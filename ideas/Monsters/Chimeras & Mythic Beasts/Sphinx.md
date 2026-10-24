---
type: monster
id: mon_sphinx
family: "Chimeras & Mythic Beasts"
rank: "S"
tier: core
tags: [monster, chimeras-mythic-beasts]
---
# Sphinx

> The Sphinx is a huge creature with a long-legged predatory quadruped build, about 6 m long. Its hide is weathered and natural, colored in warm gold and pearl white. Guild sketches always show a lion's body and a calm, ancient face. It has dark, wary eyes. Its regal silhouette is crowned by a halo-like ring of aura. It stalks low to the ground, surrounded by soft radiance and floating motes of light.

| Field | Value |
|---|---|
| Family · type | [[Families/Chimeras & Mythic Beasts|Chimeras & Mythic Beasts]] · Mythic Beast |
| Rank · level | S · 188 (173–203) |
| Menace | 2 · Wild |
| Element · weakness | Light · Dark |
| Size | 6 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 46394 · 914 · 762 · 610 · 686 · 100 |
| XP · gold | 13063 · 2293 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Sky Archipelago\|Sky Archipelago]], [[Regions/Heavenreach\|Heavenreach]] |
| Genre | World Myth |
| Trope | Greek, Persian and East Asian mythic beasts |

**Field note:** Weak to Dark. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 3.9 m high × 6 m long × 0.96 m wide; prefab scale 1.5.
- **Physics:** 4104 kg, gravity ×1.08, poise 163, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 9.01 m/s, turn 131°/s, stopping distance 1.6 m.
- **Attack count:** 5; **signature:** a lion's body and a calm, ancient face.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Many-Headed Bite\|Many-Headed Bite]] | melee | 1.5 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Sphinx is a **wild mythic beast** encountered at S rank, around level 188. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a lion's body and a calm, ancient face. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Sky Archipelago|Sky Archipelago]], [[Regions/Heavenreach|Heavenreach]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Chimeras & Mythic Beasts S|loot_chimera_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Chimera Heart\|Chimera Heart]] | 60% | 1–3 |
| [[Items/Mythic Horn\|Mythic Horn]] | 30% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Chimeras & Mythic Beasts/Phantom Sphinx|Phantom Sphinx]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Sky Archipelago\|Sky Archipelago]] | 6 | SS, S-, S+, A+, S, SS- | 159–236 | Day & Night |
| [[Regions/Heavenreach\|Heavenreach]] | 5 | S, A+, S-, SS, S+ | 159–236 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02218` | Sky Archipelago Sphinx Elderborn | [[Regions/Sky Archipelago\|Sky Archipelago]] | Elderborn | SS | 236 | 8.1 m | Day & Night | Like a typical Sphinx, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_02219` | Heavenreach Sphinx | [[Regions/Heavenreach\|Heavenreach]] | Adult | S | 188 | 6 m | Day & Night | A typical adult Sphinx of this region, with slate-grey coloring and hardened hide. |
| `pop_02220` | Sky Archipelago Sphinx Juvenile | [[Regions/Sky Archipelago\|Sky Archipelago]] | Juvenile | S- | 173 | 5.1 m | Day & Night | Like a typical Sphinx, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_02221` | Heavenreach Sphinx Runt | [[Regions/Heavenreach\|Heavenreach]] | Runt | A+ | 159 | 4.2 m | Day & Night | Like a typical Sphinx, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_02222` | Sky Archipelago Sphinx Albino | [[Regions/Sky Archipelago\|Sky Archipelago]] | Albino | S+ | 203 | 6 m | Day & Night | Like a typical Sphinx, but a rare pale form with white skin or fur and red eyes. |
| `pop_02223` | Heavenreach Sphinx Juvenile | [[Regions/Heavenreach\|Heavenreach]] | Juvenile | S- | 173 | 5.1 m | Day & Night | Like a typical Sphinx, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_02224` | Sky Archipelago Sphinx Runt | [[Regions/Sky Archipelago\|Sky Archipelago]] | Runt | A+ | 159 | 4.2 m | Day & Night | Like a typical Sphinx, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_02225` | Sky Archipelago Sphinx | [[Regions/Sky Archipelago\|Sky Archipelago]] | Adult | S | 188 | 6 m | Day & Night | A typical adult Sphinx of this region, with dust-grey coloring and old rune scars. |
| `pop_02226` | Heavenreach Sphinx Elderborn | [[Regions/Heavenreach\|Heavenreach]] | Elderborn | SS | 236 | 8.1 m | Day & Night | Like a typical Sphinx, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_02227` | Sky Archipelago Sphinx Alpha | [[Regions/Sky Archipelago\|Sky Archipelago]] | Alpha | SS- | 218 | 7.5 m | Day & Night | Like a typical Sphinx, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_02228` | Heavenreach Sphinx Albino | [[Regions/Heavenreach\|Heavenreach]] | Albino | S+ | 203 | 6 m | Day & Night | Like a typical Sphinx, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `mixed_hide` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · real-animal silhouette with one fantasy exaggeration
