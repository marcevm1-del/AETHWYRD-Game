---
type: monster-attack
id: atk_tail_lash
telegraph: blue
kind: aoe
tags: [attack, aoe, none]
---
# Tail Lash

| Field | Value |
|---|---|
| Kind · element | aoe · None |
| Power · cooldown | 1.2 · 7 s |
| Telegraph | blue |

## Player response

Standard readable cue: guard, dodge or practice a parry.

## Used by

- [[Monsters/Reptiles/Swamp Toad|Swamp Toad]]
- [[Monsters/Reptiles/Giant Lizard|Giant Lizard]]
- [[Monsters/Reptiles/Lizardman|Lizardman]]
- [[Monsters/Reptiles/Salamander|Salamander]]
- [[Monsters/Reptiles/Basilisk|Basilisk]]
- [[Monsters/Reptiles/Crocodile Wyrm|Crocodile Wyrm]]
- [[Monsters/Reptiles/Hydra|Hydra]]
- [[Monsters/Reptiles/Gorgon Wyrm|Gorgon Wyrm]]
- [[Monsters/Reptiles/Frost Toad|Frost Toad]]
- [[Monsters/Reptiles/Ancient Giant Lizard|Ancient Giant Lizard]]
- [[Monsters/Reptiles/Ancient Lizardman|Ancient Lizardman]]
- [[Monsters/Reptiles/Phantom Salamander|Phantom Salamander]]
- [[Monsters/Reptiles/Greater Basilisk|Greater Basilisk]]
- [[Monsters/Reptiles/Gale Crocodile Wyrm|Gale Crocodile Wyrm]]
- [[Monsters/Reptiles/Frost Hydra|Frost Hydra]]
- [[Monsters/Reptiles/Elder Gorgon Wyrm|Elder Gorgon Wyrm]]
- [[Monsters/Reptiles/Xibalbar, the Hydra of the Mire|Xibalbar, the Hydra of the Mire]]

## Animation and fairness

The telegraph describes attack intent; motion data supplies windup, active timing, hitboxes and recovery. Preserve a visible decision window at gameplay camera distance, and verify that effects do not hide the tell. A shared attack can be reused across a family, but its delivery should still match the creature’s silhouette and behavior.
