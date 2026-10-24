---
type: monster-attack
id: atk_regrow
telegraph: none
kind: heal
tags: [attack, heal, none]
---
# Regrow

| Field | Value |
|---|---|
| Kind · element | heal · None |
| Power · cooldown | 0 · 20 s |
| Telegraph | none |

## Player response

Read the animation and keep moving; do not assume a block is safe.

## Used by

- [[Monsters/Plants & Fungi/Mandrake|Mandrake]]
- [[Monsters/Plants & Fungi/Puffcap Mushroom|Puffcap Mushroom]]
- [[Monsters/Plants & Fungi/Walking Mushroom|Walking Mushroom]]
- [[Monsters/Plants & Fungi/Treant Sapling|Treant Sapling]]
- [[Monsters/Plants & Fungi/Spore Lord|Spore Lord]]
- [[Monsters/Plants & Fungi/Elder Treant|Elder Treant]]
- [[Monsters/Plants & Fungi/Ancient Treant|Ancient Treant]]
- [[Monsters/Plants & Fungi/Worldroot Behemoth|Worldroot Behemoth]]
- [[Monsters/Plants & Fungi/Ancient Mandrake|Ancient Mandrake]]
- [[Monsters/Plants & Fungi/Frost Puffcap Mushroom|Frost Puffcap Mushroom]]
- [[Monsters/Plants & Fungi/Phantom Walking Mushroom|Phantom Walking Mushroom]]
- [[Monsters/Plants & Fungi/Bog Treant Sapling|Bog Treant Sapling]]
- [[Monsters/Plants & Fungi/Bog Spore Lord|Bog Spore Lord]]
- [[Monsters/Plants & Fungi/Tide Elder Treant|Tide Elder Treant]]
- [[Monsters/Plants & Fungi/Bog Ancient Treant|Bog Ancient Treant]]
- [[Monsters/Plants & Fungi/Thunder Worldroot Behemoth|Thunder Worldroot Behemoth]]
- [[Monsters/Plants & Fungi/Mycelia, the Spore Lord|Mycelia, the Spore Lord]]
- [[Monsters/Plants & Fungi/The Briar King, Lord of the Winter Court|The Briar King, Lord of the Winter Court]]

## Animation and fairness

The telegraph describes attack intent; motion data supplies windup, active timing, hitboxes and recovery. Preserve a visible decision window at gameplay camera distance, and verify that effects do not hide the tell. A shared attack can be reused across a family, but its delivery should still match the creature’s silhouette and behavior.
