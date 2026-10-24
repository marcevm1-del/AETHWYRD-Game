---
type: monster-attack
id: atk_head_throw
telegraph: red
kind: ranged
tags: [attack, ranged, none]
---
# Head Throw

| Field | Value |
|---|---|
| Kind · element | ranged · None |
| Power · cooldown | 1.4 · 10 s |
| Telegraph | red |

## Player response

Unblockable cue: leave the attack line or marked area with a dodge.

## Used by

- [[Monsters/The Headless/Headless Rider|Headless Rider]]
- [[Monsters/The Headless/Dullahan|Dullahan]]
- [[Monsters/The Headless/Pale Herald|Pale Herald]]
- [[Monsters/The Headless/Vesper-Touched Headless Rider|Vesper-Touched Headless Rider]]
- [[Monsters/The Headless/Vesper-Touched Dullahan|Vesper-Touched Dullahan]]
- [[Monsters/The Headless/Phantom Pale Herald|Phantom Pale Herald]]

## Animation and fairness

The telegraph describes attack intent; motion data supplies windup, active timing, hitboxes and recovery. Preserve a visible decision window at gameplay camera distance, and verify that effects do not hide the tell. A shared attack can be reused across a family, but its delivery should still match the creature’s silhouette and behavior.
