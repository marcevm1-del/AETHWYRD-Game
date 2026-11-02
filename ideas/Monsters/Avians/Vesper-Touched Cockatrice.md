---
type: monster
id: mon_vesper_touched_cockatrice
family: "Avians"
rank: "D-"
tier: variant
tags: [monster, avians]
---
# Vesper-Touched Cockatrice

![[mon_vesper_touched_cockatrice_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vesper_touched_cockatrice_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,782 tris · 0.756 × 0.896 × 0.8 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Vesper-Touched Cockatrice is a small creature with a tall, long-legged bird build, about 0.8 m tall. Its plumage is rough, scarred and spiked, colored in blue, with ochre markings. Its most striking feature is a rooster's head and a lizard's tail. It has narrow glowing eyes. A distinctive marking runs along its back. It charges without hesitation, surrounded by pebbles that tremble and float near it. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Avians|Avians]] · Avian |
| Variant of | [[Monsters/Avians/Cockatrice\|Cockatrice]] (corrupted) |
| Rank · level | D- · 40 (32–48) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 0.8 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1850 · 170 · 136 · 119 · 136 · 135 |
| XP · gold | 1106 · 265 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/avian\|avian]] · `anim_avian` |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Moraveil\|Moraveil]] |
| Genre | High Fantasy |
| Trope | Griffons, harpies and phoenixes of classic fantasy |

**Field note:** Weak to Wind. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/avian|avian]] (rigId); animation set `anim_avian`.
- **Dimensions:** 0.37 m high × 0.8 m long × 1.38 m wide; prefab scale 1.333.
- **Physics:** 9.3 kg, gravity ×1.1, poise 30, knockback resistance 0.26, death style `tumble_feathers_burst`.
- **Navigation:** speed 2.58 m/s, turn 671°/s, stopping distance 0.56 m.
- **Attack count:** 5; **signature:** a rooster's head and a lizard's tail.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Peck\|Peck]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Swoop\|Swoop]] | dash | 1.4 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Screech\|Screech]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Feather Volley\|Feather Volley]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched Cockatrice is a **menacing avian** encountered at D- rank, around level 40. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a rooster's head and a lizard's tail. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Hoshizora|Hoshizora]], [[Regions/Moraveil|Moraveil]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_avian`, animation set `anim_avian`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Avians D|loot_avian_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Feather\|Feather]] | 60% | 1–3 |
| [[Items/Talon\|Talon]] | 30% | 1–1 |
| [[Items/Egg\|Egg]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Hoshizora\|Hoshizora]] | 6 | E+, D, C-, D-, E | 26–65 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 5 | E+, D-, E, D | 26–48 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04924` | Hoshizora Vesper-Touched Cockatrice Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | E+ | 32 | 0.68 m | Day & Night | Like a typical Vesper-Touched Cockatrice, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_04925` | Moraveil Vesper-Touched Cockatrice Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | E+ | 32 | 0.68 m | Day & Night | Like a typical Vesper-Touched Cockatrice, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_04926` | Hoshizora Vesper-Touched Cockatrice Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | D | 48 | 0.8 m | Day & Night | Like a typical Vesper-Touched Cockatrice, but a rare pale form with white skin or fur and red eyes. |
| `pop_04927` | Moraveil Vesper-Touched Cockatrice | [[Regions/Moraveil\|Moraveil]] | Adult | D- | 40 | 0.8 m | Day & Night | A typical adult Vesper-Touched Cockatrice of this region, with golden, grass-toned coloring. |
| `pop_04928` | Moraveil Vesper-Touched Cockatrice Runt | [[Regions/Moraveil\|Moraveil]] | Runt | E | 26 | 0.56 m | Day & Night | Like a typical Vesper-Touched Cockatrice, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_04929` | Hoshizora Vesper-Touched Cockatrice Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | C- | 65 | 1.08 m | Day & Night | Like a typical Vesper-Touched Cockatrice, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_04930` | Moraveil Vesper-Touched Cockatrice Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | D | 48 | 0.88 m | Day & Night | Like a typical Vesper-Touched Cockatrice, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_04931` | Hoshizora Vesper-Touched Cockatrice | [[Regions/Hoshizora\|Hoshizora]] | Adult | D- | 40 | 0.8 m | Day & Night | A typical adult Vesper-Touched Cockatrice of this region, with slate-grey coloring and hardened hide. |
| `pop_04932` | Hoshizora Vesper-Touched Cockatrice Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | D | 48 | 0.88 m | Day & Night | Like a typical Vesper-Touched Cockatrice, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_04933` | Moraveil Vesper-Touched Cockatrice Albino | [[Regions/Moraveil\|Moraveil]] | Albino | D | 48 | 0.8 m | Day & Night | Like a typical Vesper-Touched Cockatrice, but a rare pale form with white skin or fur and red eyes. |
| `pop_04934` | Hoshizora Vesper-Touched Cockatrice Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | E | 26 | 0.56 m | Day & Night | Like a typical Vesper-Touched Cockatrice, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_avian` · mesh `avian_base` · material `feather_groom` · VFX `rock_debris` · palette `#5294b9` `#376680` `#d1a15a` · triangle-based silhouette, sharp asymmetric spikes
