---
type: monster-attack
id: atk_venom_coil
telegraph: gold
kind: grab
tags: [attack, grab, none]
---
# Venom Coil

| Field | Value |
|---|---|
| Kind · element | grab · None |
| Power · cooldown | 1.3 · 11 s |
| Telegraph | gold |

## Player response

Grab cue: create distance or dodge before contact.

## Used by

- [[Monsters/Serpentfolk/Lamia|Lamia]]
- [[Monsters/Serpentfolk/Naga Warrior|Naga Warrior]]
- [[Monsters/Serpentfolk/Naga Priestess|Naga Priestess]]
- [[Monsters/Serpentfolk/Serpent Empress|Serpent Empress]]
- [[Monsters/Serpentfolk/Vine Lamia|Vine Lamia]]
- [[Monsters/Serpentfolk/Blaze Naga Warrior|Blaze Naga Warrior]]
- [[Monsters/Serpentfolk/Dune Naga Priestess|Dune Naga Priestess]]
- [[Monsters/Serpentfolk/Night Serpent Empress|Night Serpent Empress]]

## Animation and fairness

The telegraph describes attack intent; motion data supplies windup, active timing, hitboxes and recovery. Preserve a visible decision window at gameplay camera distance, and verify that effects do not hide the tell. A shared attack can be reused across a family, but its delivery should still match the creature’s silhouette and behavior.
