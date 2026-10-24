---
type: monster-attack
id: atk_lantern_hurl
telegraph: blue
kind: ranged
tags: [attack, ranged, none]
---
# Lantern Hurl

| Field | Value |
|---|---|
| Kind · element | ranged · None |
| Power · cooldown | 1.3 · 8 s |
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
