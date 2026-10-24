---
type: monster-attack
id: atk_scatter
telegraph: none
kind: evade
tags: [attack, evade, none]
---
# Scatter

| Field | Value |
|---|---|
| Kind · element | evade · None |
| Power · cooldown | 0 · 10 s |
| Telegraph | none |

## Player response

Read the animation and keep moving; do not assume a block is safe.

## Used by

- [[Monsters/Insects & Arachnids/Firefly Swarm|Firefly Swarm]]
- [[Monsters/Insects & Arachnids/Scarab Swarm|Scarab Swarm]]
- [[Monsters/Aquatic/Piranha Swarm|Piranha Swarm]]
- [[Monsters/Insects & Arachnids/Phantom Firefly Swarm|Phantom Firefly Swarm]]
- [[Monsters/Insects & Arachnids/Vesper-Touched Scarab Swarm|Vesper-Touched Scarab Swarm]]
- [[Monsters/Aquatic/Bog Piranha Swarm|Bog Piranha Swarm]]
- [[Monsters/Insects & Arachnids/Blight Firefly Swarm|Blight Firefly Swarm]]
- [[Monsters/Insects & Arachnids/Elder Scarab Swarm|Elder Scarab Swarm]]

## Animation and fairness

The telegraph describes attack intent; motion data supplies windup, active timing, hitboxes and recovery. Preserve a visible decision window at gameplay camera distance, and verify that effects do not hide the tell. A shared attack can be reused across a family, but its delivery should still match the creature’s silhouette and behavior.
