---
type: monster-attack
id: atk_coil_strike
telegraph: blue
kind: melee
tags: [attack, melee, none]
---
# Coil Strike

| Field | Value |
|---|---|
| Kind · element | melee · None |
| Power · cooldown | 1.1 · 0 s |
| Telegraph | blue |

## Player response

Standard readable cue: guard, dodge or practice a parry.

## Used by

- [[Monsters/Aquatic/Siren|Siren]]
- [[Monsters/Aquatic/Merfolk Warden|Merfolk Warden]]
- [[Monsters/Serpentfolk/Lamia|Lamia]]
- [[Monsters/Serpentfolk/Naga Warrior|Naga Warrior]]
- [[Monsters/Serpentfolk/Naga Priestess|Naga Priestess]]
- [[Monsters/Serpentfolk/Serpent Empress|Serpent Empress]]
- [[Monsters/Aquatic/Ancient Siren|Ancient Siren]]
- [[Monsters/Aquatic/Bog Merfolk Warden|Bog Merfolk Warden]]
- [[Monsters/Serpentfolk/Vine Lamia|Vine Lamia]]
- [[Monsters/Serpentfolk/Blaze Naga Warrior|Blaze Naga Warrior]]
- [[Monsters/Serpentfolk/Dune Naga Priestess|Dune Naga Priestess]]
- [[Monsters/Serpentfolk/Night Serpent Empress|Night Serpent Empress]]
- [[Monsters/Aquatic/The Drowned Choir, Sirens of the Canals|The Drowned Choir, Sirens of the Canals]]

## Animation and fairness

The telegraph describes attack intent; motion data supplies windup, active timing, hitboxes and recovery. Preserve a visible decision window at gameplay camera distance, and verify that effects do not hide the tell. A shared attack can be reused across a family, but its delivery should still match the creature’s silhouette and behavior.
