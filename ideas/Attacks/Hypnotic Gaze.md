---
type: monster-attack
id: atk_hypnotic_gaze
telegraph: none
kind: debuff
tags: [attack, debuff, none]
---
# Hypnotic Gaze

| Field | Value |
|---|---|
| Kind · element | debuff · None |
| Power · cooldown | 0 · 14 s |
| Telegraph | none |

## Player response

Read the animation and keep moving; do not assume a block is safe.

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
