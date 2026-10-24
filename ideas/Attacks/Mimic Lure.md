---
type: monster-attack
id: atk_mimic_lure
telegraph: none
kind: debuff
tags: [attack, debuff, none]
---
# Mimic Lure

| Field | Value |
|---|---|
| Kind · element | debuff · None |
| Power · cooldown | 0 · 16 s |
| Telegraph | none |

## Player response

Read the animation and keep moving; do not assume a block is safe.

## Used by

- [[Monsters/Aberrations/Skinwalker Mimic|Skinwalker Mimic]]
- [[Monsters/Aberrations/Grin in the Walls|Grin in the Walls]]
- [[Monsters/Aberrations/Faceless One|Faceless One]]
- [[Monsters/Aberrations/The Many-Mouthed|The Many-Mouthed]]
- [[Monsters/Aberrations/Thousand-Eyed Watcher|Thousand-Eyed Watcher]]
- [[Monsters/Aberrations/Phantom Skinwalker Mimic|Phantom Skinwalker Mimic]]
- [[Monsters/Aberrations/Storm Grin in the Walls|Storm Grin in the Walls]]
- [[Monsters/Aberrations/Vesper-Touched Faceless One|Vesper-Touched Faceless One]]
- [[Monsters/Aberrations/Phantom The Many-Mouthed|Phantom The Many-Mouthed]]
- [[Monsters/Aberrations/Deep Thousand-Eyed Watcher|Deep Thousand-Eyed Watcher]]
- [[Monsters/Aberrations/The Nightmother, Queen of the Nightshifters|The Nightmother, Queen of the Nightshifters]]
- [[Monsters/Aberrations/The Gentle Warden, Keeper of Ashira|The Gentle Warden, Keeper of Ashira]]

## Animation and fairness

The telegraph describes attack intent; motion data supplies windup, active timing, hitboxes and recovery. Preserve a visible decision window at gameplay camera distance, and verify that effects do not hide the tell. A shared attack can be reused across a family, but its delivery should still match the creature’s silhouette and behavior.
