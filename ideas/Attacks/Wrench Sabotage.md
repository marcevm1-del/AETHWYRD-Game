---
type: monster-attack
id: atk_wrench_sabotage
telegraph: none
kind: debuff
tags: [attack, debuff, none]
---
# Wrench Sabotage

| Field | Value |
|---|---|
| Kind · element | debuff · None |
| Power · cooldown | 0 · 14 s |
| Telegraph | none |

## Player response

Read the animation and keep moving; do not assume a block is safe.

## Used by

- [[Monsters/Gremlins/Gremlin|Gremlin]]
- [[Monsters/Gremlins/Saboteur Gremlin|Saboteur Gremlin]]
- [[Monsters/Gremlins/Gremlin King|Gremlin King]]
- [[Monsters/Gremlins/Ancient Gremlin|Ancient Gremlin]]
- [[Monsters/Gremlins/Vesper-Touched Saboteur Gremlin|Vesper-Touched Saboteur Gremlin]]
- [[Monsters/Gremlins/Ruin Gremlin King|Ruin Gremlin King]]
- [[Monsters/Gremlins/Cogmaw, the Gremlin Engine-King|Cogmaw, the Gremlin Engine-King]]

## Animation and fairness

The telegraph describes attack intent; motion data supplies windup, active timing, hitboxes and recovery. Preserve a visible decision window at gameplay camera distance, and verify that effects do not hide the tell. A shared attack can be reused across a family, but its delivery should still match the creature’s silhouette and behavior.
