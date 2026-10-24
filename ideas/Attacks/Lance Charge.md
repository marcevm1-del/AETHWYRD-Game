---
type: monster-attack
id: atk_lance_charge
telegraph: red
kind: dash
tags: [attack, dash, none]
---
# Lance Charge

| Field | Value |
|---|---|
| Kind · element | dash · None |
| Power · cooldown | 1.7 · 8 s |
| Telegraph | red |

## Player response

Unblockable cue: leave the attack line or marked area with a dodge.

## Used by

- [[Monsters/Centaurs & Taurs/Centaur Scout|Centaur Scout]]
- [[Monsters/Centaurs & Taurs/Centaur Lancer|Centaur Lancer]]
- [[Monsters/Centaurs & Taurs/Scorpion Rider|Scorpion Rider]]
- [[Monsters/Centaurs & Taurs/Centaur Khan|Centaur Khan]]
- [[Monsters/Centaurs & Taurs/Shade Centaur Scout|Shade Centaur Scout]]
- [[Monsters/Centaurs & Taurs/Crag Centaur Lancer|Crag Centaur Lancer]]
- [[Monsters/Centaurs & Taurs/Ancient Scorpion Rider|Ancient Scorpion Rider]]
- [[Monsters/Centaurs & Taurs/Dune Centaur Khan|Dune Centaur Khan]]

## Animation and fairness

The telegraph describes attack intent; motion data supplies windup, active timing, hitboxes and recovery. Preserve a visible decision window at gameplay camera distance, and verify that effects do not hide the tell. A shared attack can be reused across a family, but its delivery should still match the creature’s silhouette and behavior.
