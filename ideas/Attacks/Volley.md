---
type: monster-attack
id: atk_volley
telegraph: blue
kind: ranged
tags: [attack, ranged, none]
---
# Volley

| Field | Value |
|---|---|
| Kind · element | ranged · None |
| Power · cooldown | 1 · 6 s |
| Telegraph | blue |

## Player response

Standard readable cue: guard, dodge or practice a parry.

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
