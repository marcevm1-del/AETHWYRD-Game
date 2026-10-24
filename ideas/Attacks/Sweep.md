---
type: monster-attack
id: atk_sweep
telegraph: blue
kind: melee
tags: [attack, melee, none]
---
# Sweep

| Field | Value |
|---|---|
| Kind · element | melee · None |
| Power · cooldown | 1.3 · 0 s |
| Telegraph | blue |

## Player response

Standard readable cue: guard, dodge or practice a parry.

## Used by

- [[Monsters/The Headless/Headless Rider|Headless Rider]]
- [[Monsters/The Headless/Dullahan|Dullahan]]
- [[Monsters/The Headless/Pale Herald|Pale Herald]]
- [[Monsters/The Headless/Vesper-Touched Headless Rider|Vesper-Touched Headless Rider]]
- [[Monsters/The Headless/Vesper-Touched Dullahan|Vesper-Touched Dullahan]]
- [[Monsters/The Headless/Phantom Pale Herald|Phantom Pale Herald]]

## Animation and fairness

The telegraph describes attack intent; motion data supplies windup, active timing, hitboxes and recovery. Preserve a visible decision window at gameplay camera distance, and verify that effects do not hide the tell. A shared attack can be reused across a family, but its delivery should still match the creature’s silhouette and behavior.
