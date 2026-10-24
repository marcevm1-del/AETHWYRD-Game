---
type: monster-attack
id: atk_nip
telegraph: blue
kind: melee
tags: [attack, melee, none]
---
# Nip

| Field | Value |
|---|---|
| Kind · element | melee · None |
| Power · cooldown | 0.9 · 0 s |
| Telegraph | blue |

## Player response

Standard readable cue: guard, dodge or practice a parry.

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
