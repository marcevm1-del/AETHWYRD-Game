---
type: monster
id: mon_ancient_goblin_king
family: "Goblinoids"
rank: "A"
tier: variant
tags: [monster, goblinoids]
---
# Ancient Goblin King

![[mon_ancient_goblin_king_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ancient_goblin_king_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,170 tris · 3.607 × 2.391 × 4.2 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Ancient Goblin King is a large creature with a giant, barrel-chested humanoid body, about 4.2 m tall. Its skin is rough, scarred and spiked, colored in ochre, clay and mossy stone. Survivors describe throne-backed armor and a crown of hammered coins. It has burning slit pupils. An elegant crest and glowing veins of mana mark it as a champion of its kind. It charges without hesitation, surrounded by pebbles that tremble and float near it. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Variant of | [[Monsters/Goblinoids/Goblin King\|Goblin King]] (ancient) |
| Rank · level | A · 146 (132–159) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 4.2 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 36153 · 594 · 891 · 356 · 594 · 70 |
| XP · gold | 8719 · 1611 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/large_biped\|large_biped]] · `anim_large_biped` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Quaking Lands\|Quaking Lands]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Wind. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/large_biped|large_biped]] (rigId); animation set `anim_large_biped`.
- **Dimensions:** 4.2 m high × 1.26 m long × 1.76 m wide; prefab scale 1.2.
- **Physics:** 1733.7 kg, gravity ×1.43, poise 268, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 6.97 m/s, turn 185°/s, stopping distance 1.24 m.
- **Attack count:** 5; **signature:** throne-backed armor and a crown of hammered coins.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stomp\|Stomp]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Club Slam\|Club Slam]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grab and Throw\|Grab and Throw]] | grab | 2 | 14 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Sand Toss\|Sand Toss]] | debuff | 0 | 12 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Ancient Goblin King is a **menacing humanoid** encountered at A rank, around level 146. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** throne-backed armor and a crown of hammered coins. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Quaking Lands|Quaking Lands]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_large_biped`, animation set `anim_large_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Goblinoids A|loot_goblinoid_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Moraveil\|Moraveil]] | 6 | A-, A+, S-, S, A | 132–188 | Day & Night |
| [[Regions/Quaking Lands\|Quaking Lands]] | 5 | S-, A-, S, A, B+ | 120–188 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06000` | Moraveil Ancient Goblin King Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | A- | 132 | 3.57 m | Day & Night | Like a typical Ancient Goblin King, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_06001` | Quaking Lands Ancient Goblin King Alpha | [[Regions/Quaking Lands\|Quaking Lands]] | Alpha | S- | 173 | 5.25 m | Day & Night | Like a typical Ancient Goblin King, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_06002` | Quaking Lands Ancient Goblin King Juvenile | [[Regions/Quaking Lands\|Quaking Lands]] | Juvenile | A- | 132 | 3.57 m | Day & Night | Like a typical Ancient Goblin King, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_06003` | Moraveil Ancient Goblin King Albino | [[Regions/Moraveil\|Moraveil]] | Albino | A+ | 159 | 4.2 m | Day & Night | Like a typical Ancient Goblin King, but a rare pale form with white skin or fur and red eyes. |
| `pop_06004` | Moraveil Ancient Goblin King Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | S- | 173 | 5.25 m | Day & Night | Like a typical Ancient Goblin King, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_06005` | Moraveil Ancient Goblin King Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | S | 188 | 5.67 m | Day & Night | Like a typical Ancient Goblin King, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_06006` | Quaking Lands Ancient Goblin King Elderborn | [[Regions/Quaking Lands\|Quaking Lands]] | Elderborn | S | 188 | 5.67 m | Day & Night | Like a typical Ancient Goblin King, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_06007` | Moraveil Ancient Goblin King Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | A+ | 159 | 4.62 m | Day & Night | Like a typical Ancient Goblin King, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_06008` | Moraveil Ancient Goblin King | [[Regions/Moraveil\|Moraveil]] | Adult | A | 146 | 4.2 m | Day & Night | A typical adult Ancient Goblin King of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_06009` | Quaking Lands Ancient Goblin King | [[Regions/Quaking Lands\|Quaking Lands]] | Adult | A | 146 | 4.2 m | Day & Night | A typical adult Ancient Goblin King of this region, with slate-grey coloring and hardened hide. |
| `pop_06010` | Quaking Lands Ancient Goblin King Runt | [[Regions/Quaking Lands\|Quaking Lands]] | Runt | B+ | 120 | 2.94 m | Day & Night | Like a typical Ancient Goblin King, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `rough_skin_leather` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · triangle-based silhouette, sharp asymmetric spikes
