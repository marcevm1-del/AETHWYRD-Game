---
type: monster-attack
id: atk_disguise
telegraph: none
kind: stealth
tags: [attack, stealth, none]
---
# Disguise

| Field | Value |
|---|---|
| Kind · element | stealth · None |
| Power · cooldown | 0 · 20 s |
| Telegraph | none |

## Player response

Read the animation and keep moving; do not assume a block is safe.

## Used by

- [[Monsters/Constructs & Mimics/Door Mimic|Door Mimic]]
- [[Monsters/Constructs & Mimics/Mimic|Mimic]]
- [[Monsters/Constructs & Mimics/Mimic King|Mimic King]]
- [[Monsters/Aberrations/Grin in the Walls|Grin in the Walls]]
- [[Monsters/Constructs & Mimics/Vesper-Touched Door Mimic|Vesper-Touched Door Mimic]]
- [[Monsters/Constructs & Mimics/Cloud Mimic|Cloud Mimic]]
- [[Monsters/Constructs & Mimics/Elder Mimic King|Elder Mimic King]]
- [[Monsters/Aberrations/Storm Grin in the Walls|Storm Grin in the Walls]]

## Animation and fairness

The telegraph describes attack intent; motion data supplies windup, active timing, hitboxes and recovery. Preserve a visible decision window at gameplay camera distance, and verify that effects do not hide the tell. A shared attack can be reused across a family, but its delivery should still match the creature’s silhouette and behavior.
