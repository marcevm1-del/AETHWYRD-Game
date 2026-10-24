---
type: monster
id: mon_phantom_ifrit
family: "Elementals & Spirits"
rank: "B+"
tier: variant
tags: [monster, elementals-spirits]
---
# Phantom Ifrit

> The Phantom Ifrit is a huge creature with a bodiless, glowing form, about 5 m tall. Its body is patchy and subtly wrong, as if assembled from memory, colored in warm gold and pearl white. Its most striking feature is a torso of fire rising from a smoking lamp. It has eyes set slightly too far apart. Faint runes glow along its body when it fights. It moves in jerky stop-motion bursts, surrounded by soft radiance and floating motes of light. Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.

| Field | Value |
|---|---|
| Family · type | [[Families/Elementals & Spirits|Elementals & Spirits]] · Elemental |
| Variant of | [[Monsters/Elementals & Spirits/Ifrit\|Ifrit]] (spirit) |
| Rank · level | B+ · 120 (108–132) |
| Menace | 4 · Dread |
| Element · weakness | Light · Dark |
| Size | 5 m |
| Behaviour | Passive (passive_wander+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 16297 · 294 · 343 · 686 · 637 · 90 |
| XP · gold | 6373 · 1225 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/spirit_float\|spirit_float]] · `anim_floating` |
| Habitats | [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Hoshizora\|Hoshizora]] |
| Genre | Spirit Realm |
| Trope | Spirits you can contract with; elemental kings |

**Field note:** Weak to Dark. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/spirit_float|spirit_float]] (rigId); animation set `anim_floating`.
- **Dimensions:** 5 m high × 1.5 m long × 3.2 m wide; prefab scale 5.
- **Physics:** 11.9 kg, gravity ×0, poise 79, knockback resistance 0.12, death style `dissolve_into_motes`.
- **Navigation:** speed 11.52 m/s, turn 322°/s, stopping distance 1.65 m.
- **Attack count:** 5; **signature:** a torso of fire rising from a smoking lamp.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Chill Touch\|Chill Touch]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Phase Lunge\|Phase Lunge]] | dash | 1.3 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wail\|Wail]] | aoe | 1.2 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Elemental Burst\|Elemental Burst]] | magic | 1.4 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Phantom Ifrit is a **dread elemental** encountered at B+ rank, around level 120. Its documented behaviour is *Passive* and its AI pattern is *passive_wander+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a torso of fire rising from a smoking lamp. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Shen-Lu|Shen-Lu]], [[Regions/Hoshizora|Hoshizora]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_floating`, animation set `anim_floating`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Elementals & Spirits B|loot_elemental_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Elemental Essence\|Elemental Essence]] | 60% | 1–3 |
| [[Items/Spirit Mote\|Spirit Mote]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Hoshizora\|Hoshizora]] | 7 | A, B, A-, A+, B+, B- | 96–159 | Night |
| [[Regions/Shen-Lu\|Shen-Lu]] | 4 | A-, B-, A, B | 96–146 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04528` | Hoshizora Phantom Ifrit Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | A | 146 | 6.25 m | Night | Like a typical Phantom Ifrit, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_04529` | Shen-Lu Phantom Ifrit Albino | [[Regions/Shen-Lu\|Shen-Lu]] | Albino | A- | 132 | 5 m | Night | Like a typical Phantom Ifrit, but a rare pale form with white skin or fur and red eyes. |
| `pop_04530` | Hoshizora Phantom Ifrit Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | B | 108 | 4.25 m | Night | Like a typical Phantom Ifrit, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_04531` | Hoshizora Phantom Ifrit Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | A- | 132 | 5.5 m | Night | Like a typical Phantom Ifrit, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_04532` | Hoshizora Phantom Ifrit Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | A+ | 159 | 6.75 m | Night | Like a typical Phantom Ifrit, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_04533` | Shen-Lu Phantom Ifrit Runt | [[Regions/Shen-Lu\|Shen-Lu]] | Runt | B- | 96 | 3.5 m | Night | Like a typical Phantom Ifrit, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_04534` | Shen-Lu Phantom Ifrit Alpha | [[Regions/Shen-Lu\|Shen-Lu]] | Alpha | A | 146 | 6.25 m | Night | Like a typical Phantom Ifrit, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_04535` | Hoshizora Phantom Ifrit | [[Regions/Hoshizora\|Hoshizora]] | Adult | B+ | 120 | 5 m | Night | A typical adult Phantom Ifrit of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_04536` | Hoshizora Phantom Ifrit Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | B- | 96 | 3.5 m | Night | Like a typical Phantom Ifrit, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_04537` | Shen-Lu Phantom Ifrit Juvenile | [[Regions/Shen-Lu\|Shen-Lu]] | Juvenile | B | 108 | 4.25 m | Night | Like a typical Phantom Ifrit, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_04538` | Hoshizora Phantom Ifrit Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | A- | 132 | 5 m | Night | Like a typical Phantom Ifrit, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `elemental_emissive` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · elongated, irregular silhouette; still-then-sudden timing
