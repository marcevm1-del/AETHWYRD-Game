---
type: monster-attack
id: atk_vine_lash
telegraph: blue
kind: melee
tags: [attack, melee, none]
---
# Vine Lash

| Field | Value |
|---|---|
| Kind · element | melee · None |
| Power · cooldown | 1.1 · 0 s |
| Telegraph | blue |

## Player response

Standard readable cue: guard, dodge or practice a parry.

## Used by

- [[Monsters/Plants & Fungi/Thornvine|Thornvine]]
- [[Monsters/Plants & Fungi/Man-Eater Plant|Man-Eater Plant]]
- [[Monsters/Plants & Fungi/Corpse Flower|Corpse Flower]]
- [[Monsters/Plants & Fungi/Blighted World Root|Blighted World Root]]
- [[Monsters/Plants & Fungi/Vesper-Touched Thornvine|Vesper-Touched Thornvine]]
- [[Monsters/Plants & Fungi/Vine Man-Eater Plant|Vine Man-Eater Plant]]
- [[Monsters/Plants & Fungi/Blaze Corpse Flower|Blaze Corpse Flower]]

## Animation and fairness

The telegraph describes attack intent; motion data supplies windup, active timing, hitboxes and recovery. Preserve a visible decision window at gameplay camera distance, and verify that effects do not hide the tell. A shared attack can be reused across a family, but its delivery should still match the creature’s silhouette and behavior.
