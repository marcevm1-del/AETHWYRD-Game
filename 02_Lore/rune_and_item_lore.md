# Rune and item flavour: writer's reference

> Writer's draft by the narrative-writer agent, 2026-11-13. `Canon.md` wins. Everything here is public, in-world knowledge: nothing names a Canon §3 secret. Item ids are from `Data/Items/items.json`; rune words are from `Data/Items/gear_rules.json`. The rune-word lines below are **proposed tooltip text**: `gear_rules.json` has no flavour field yet (owner: items-designer / tools-pipeline-engineer), so they live here until a field exists.

## How people talk about runes

- Khazdur runes are dwarf-made and dwarf-named, and the dwarves treat them as *habits*, not magic. A smith cuts the Ember rune the way another person says grace.
- Iron Hold sayings: "A rune is a promise cut small." "Never cut on an angry day." "The first one is always crooked, and it is always kept."
- Surface folk buy runes for the stat; dwarves buy them for the mood. Both are right.
- The Guild appraises runes by how well they are cut, never by what they might mean.

## Rune lines (changed in this pass)

The six original runes each got one second sentence of *use* (who carries it, when it is cut). The five newer runes (Spark, Dusk, Bastion, Cinder, Warden) were written by the items-designer and are left alone.

| Item | New flavour |
|---|---|
| `itm_rune_ember` | A Khazdur glyph for heat, cut small enough to hold in a palm. Smiths press it to the anvil before the first strike of the day. |
| `itm_rune_tide` | Cool to the touch even beside a forge. Dwarf-divers carry one when they cross the flooded galleries. |
| `itm_rune_stone` | Heavy for its size. Dwarves say it remembers being a mountain, and would like to be one again. |
| `itm_rune_anvil` | The first glyph an apprentice learns to strike. Every dwarf remembers their own crooked first one. |
| `itm_rune_hearth` | Warm, and faintly smells of bread. Cut over doorposts in Iron Hold so that no one is ever shut out in winter. |
| `itm_rune_gale` | It hums when the wind turns. Sky-traders pin one to a sleeve before a crossing. |

## Rune words: proposed tooltip lines

| Word | Runes | Proposed line |
|---|---|---|
| **Forge-Oath** (`word_forge_oath`) | Ember + Anvil | What a smith swears at the first fire of a new blade: *I will finish what I heat.* |
| **Stonewatch** (`word_stonewatch`) | Stone + Anvil | A wall that does not argue. Old gate-wardens pressed it into their breastplates and slept well. |
| **Stormfast** (`word_stormfast`) | Gale + Tide | The two things a sailor trusts least, tied together so they will at least agree with each other. |
| **Hearthfire** (`word_hearthfire`) | Hearth + Ember + Anvil | Cut for a home-forge, never a war-forge. It makes a sword feel like it wants to come home. |
| **Cindersong** (`word_cindersong`) | Cinder + Spark | The warmth after the fire, and the first sound of the next one. |
| **Bastion-Vow** (`word_bastion_vow`) | Bastion + Warden | A promise to stand between a door and the dark. It is short. It has to be. |
| **Duskwalk** (`word_duskwalk`) | Dusk + Gale | For couriers who finish the road at lamp-lighting hour. They say the wind opens the gate for them. |

## Fragment lines (changed in this pass)

All eleven fragments carried the same line ("A broken piece of something old..."). Each now has its own, tied to the *public* account in `Data/World/civilization_archive.json` (no secrets, no names of gods):

| Item | New flavour |
|---|---|
| `itm_frag_covenant_a` | The upper half of a Draconic tablet. The first line is a name too long to say in one breath. |
| `itm_frag_covenant_b` | The lower half of a tablet. Claw-marks stand in place of signatures, and one is pressed deeper than the rest. |
| `itm_frag_dun_a` | Dwarf-cut bronze stamped with the opening of a forge-oath. The right edge would finish the sentence. |
| `itm_frag_dun_b` | The right edge of a founding plate. A single hammer-mark seals the oath. No smith has matched it since. |
| `itm_frag_seedbowl_a` | Pale green glaze and a ring of leaf-stamps. It still smells faintly of rain on bark. |
| `itm_frag_seedbowl_b` | The base of a shallow bowl, worn smooth from being carried. Something was meant to be planted here. |
| `itm_frag_primer_a` | A first lesson in Old Weave-tongue: one letter, one small picture, repeated. The picture is a thread. |
| `itm_frag_primer_b` | A row of simple words copied by careful, small hands. Someone drew a sleeping cat in the margin. |
| `itm_frag_primer_c` | A stitched binding with strands of red cord still in it. These pages were read until they came loose. |
| `itm_frag_glass_a` | It hums a half-note when held. Hold it near another piece and the note begins to climb. |
| `itm_frag_glass_b` | The curved rim of a glass circle, polished by hands, not tools. It hums lower than the shard. |

## Other fixes

| Item | Problem | Fix |
|---|---|---|
| `itm_minas_earring` | "A gift from her sister" tells the player Mina has a sister long before the rogue questline reveals it (Canon §3 clue, Act III-IV) | "A gift from someone she misses." |
| `itm_fire_bomb` | Mentioned "Ring 0's Firestorm starter" (a developer term in a player tooltip) | "The fuse is shorter than it looks." |
| `itm_hearth_stew` | "Marta ladle, Marta pot" read as a typo | "Marta's ladle, Marta's pot, and a seat by the fire." |

## Notes for other owners

- **Iron Hold doorpost custom** (Hearth rune) and **dwarf-divers in flooded galleries** (Tide rune) are new small facts. They are flavour only; if canon-keeper prefers, they can be reworded to "some dwarves say".
- `itm_frag_primer_b` mentions a sleeping cat. It is a plain cat doodle and not a hint about any specific character; keep it that way.
