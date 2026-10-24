---
type: monster
id: mon_unicorn
family: "Chimeras & Mythic Beasts"
rank: "A"
tier: core
tags: [monster, chimeras-mythic-beasts]
---
# Unicorn

> The Unicorn is a person-sized creature with a heavy, muscular quadruped frame, about 2 m long. Its hide is smooth and clean, colored in warm gold and pearl white. Look for a spiral horn of pearl. It has wide curious eyes with star-shaped highlights. An elegant crest and glowing veins of mana mark it as a champion of its kind. It hops in little bursts, surrounded by soft radiance and floating motes of light.

| Field | Value |
|---|---|
| Family · type | [[Families/Chimeras & Mythic Beasts|Chimeras & Mythic Beasts]] · Mythic Beast |
| Rank · level | A · 146 (132–159) |
| Menace | 1 · Charming |
| Element · weakness | Light · Dark |
| Size | 2 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 22146 · 713 · 594 · 475 · 535 · 100 |
| XP · gold | 8719 · 1611 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Sky Archipelago\|Sky Archipelago]], [[Regions/Heavenreach\|Heavenreach]], [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Hoshizora\|Hoshizora]], [[Regions/Nox Dominion\|Nox Dominion]] |
| Genre | World Myth |
| Trope | Greek, Persian and East Asian mythic beasts |

**Field note:** Weak to Dark. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 1.3 m high × 2 m long × 0.32 m wide; prefab scale 0.5.
- **Physics:** 152 kg, gravity ×1.08, poise 87, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 5.15 m/s, turn 226°/s, stopping distance 0.8 m.
- **Attack count:** 5; **signature:** a spiral horn of pearl.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Many-Headed Bite\|Many-Headed Bite]] | melee | 1.5 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Unicorn is a **charming mythic beast** encountered at A rank, around level 146. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a spiral horn of pearl. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Sky Archipelago|Sky Archipelago]], [[Regions/Heavenreach|Heavenreach]], [[Regions/Shen-Lu|Shen-Lu]], [[Regions/Hoshizora|Hoshizora]], [[Regions/Nox Dominion|Nox Dominion]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Chimeras & Mythic Beasts A|loot_chimera_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Chimera Heart\|Chimera Heart]] | 60% | 1–3 |
| [[Items/Mythic Horn\|Mythic Horn]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Chimeras & Mythic Beasts/Dune Unicorn|Dune Unicorn]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Shen-Lu\|Shen-Lu]] | 1 | A | 146–146 | Day |
| [[Regions/Heavenreach\|Heavenreach]] | 3 | A+, A, B+ | 120–159 | Day |
| [[Regions/Nox Dominion\|Nox Dominion]] | 5 | A+, S-, A-, S | 132–188 | Day |
| [[Regions/Sky Archipelago\|Sky Archipelago]] | 2 | A, S | 146–188 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02196` | Shen-Lu Unicorn | [[Regions/Shen-Lu\|Shen-Lu]] | Adult | A | 146 | 2 m | Day | A typical adult Unicorn of this region, with slate-grey coloring and hardened hide. |
| `pop_02197` | Heavenreach Unicorn Scarred | [[Regions/Heavenreach\|Heavenreach]] | Scarred | A+ | 159 | 2.2 m | Day | Like a typical Unicorn, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_02198` | Nox Dominion Unicorn Scarred | [[Regions/Nox Dominion\|Nox Dominion]] | Scarred | A+ | 159 | 2.2 m | Day | Like a typical Unicorn, but covered in old battle scars, with red-black coloring with faint ember veins. |
| `pop_02199` | Heavenreach Unicorn | [[Regions/Heavenreach\|Heavenreach]] | Adult | A | 146 | 2 m | Day | A typical adult Unicorn of this region, with slate-grey coloring and hardened hide. |
| `pop_02200` | Sky Archipelago Unicorn | [[Regions/Sky Archipelago\|Sky Archipelago]] | Adult | A | 146 | 2 m | Day | A typical adult Unicorn of this region, with dust-grey coloring and old rune scars. |
| `pop_02201` | Nox Dominion Unicorn Alpha | [[Regions/Nox Dominion\|Nox Dominion]] | Alpha | S- | 173 | 2.5 m | Day | Like a typical Unicorn, but larger and scarred, and others of its kind follow it, with red-black coloring with faint ember veins. |
| `pop_02202` | Heavenreach Unicorn Runt | [[Regions/Heavenreach\|Heavenreach]] | Runt | B+ | 120 | 1.4 m | Day | Like a typical Unicorn, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_02203` | Nox Dominion Unicorn Albino | [[Regions/Nox Dominion\|Nox Dominion]] | Albino | A+ | 159 | 2 m | Day | Like a typical Unicorn, but a rare pale form with white skin or fur and red eyes. |
| `pop_02204` | Nox Dominion Unicorn Juvenile | [[Regions/Nox Dominion\|Nox Dominion]] | Juvenile | A- | 132 | 1.7 m | Day | Like a typical Unicorn, but young, with brighter colors and unworn features, with red-black coloring with faint ember veins. |
| `pop_02205` | Sky Archipelago Unicorn Elderborn | [[Regions/Sky Archipelago\|Sky Archipelago]] | Elderborn | S | 188 | 2.7 m | Day | Like a typical Unicorn, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_02206` | Nox Dominion Unicorn Elderborn | [[Regions/Nox Dominion\|Nox Dominion]] | Elderborn | S | 188 | 2.7 m | Day | Like a typical Unicorn, but old and wise, with greying features and a cautious hunting style, with red-black coloring with faint ember veins. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `mixed_hide` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · circle-based, soft silhouette
