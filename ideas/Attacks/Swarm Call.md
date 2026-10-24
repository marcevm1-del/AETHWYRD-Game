---
type: monster-attack
id: atk_swarm_call
telegraph: none
kind: summon
tags: [attack, summon, none]
---
# Swarm Call

| Field | Value |
|---|---|
| Kind · element | summon · None |
| Power · cooldown | 0 · 20 s |
| Telegraph | none |

## Player response

Watch for a change in enemy count and reposition or interrupt where possible.

## Used by

- [[Monsters/Killer Insects/Needle Wasp|Needle Wasp]]
- [[Monsters/Killer Insects/Hornet Lancer|Hornet Lancer]]
- [[Monsters/Elementals & Spirits/Pixie|Pixie]]
- [[Monsters/Demons/Imp|Imp]]
- [[Monsters/Familiars & Gentle Creatures/Lantern Moth|Lantern Moth]]
- [[Monsters/Killer Insects/Cavern Needle Wasp|Cavern Needle Wasp]]
- [[Monsters/Killer Insects/Greater Hornet Lancer|Greater Hornet Lancer]]
- [[Monsters/Elementals & Spirits/Elder Pixie|Elder Pixie]]
- [[Monsters/Demons/Thorn Imp|Thorn Imp]]
- [[Monsters/Familiars & Gentle Creatures/Elder Lantern Moth|Elder Lantern Moth]]
- [[Monsters/Killer Insects/Greater Needle Wasp|Greater Needle Wasp]]
- [[Monsters/Killer Insects/Zephyr Hornet Lancer|Zephyr Hornet Lancer]]

## Animation and fairness

The telegraph describes attack intent; motion data supplies windup, active timing, hitboxes and recovery. Preserve a visible decision window at gameplay camera distance, and verify that effects do not hide the tell. A shared attack can be reused across a family, but its delivery should still match the creature’s silhouette and behavior.
