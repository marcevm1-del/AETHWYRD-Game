---
type: monster-attack
id: atk_tentacle_slap
telegraph: blue
kind: melee
tags: [attack, melee, none]
---
# Tentacle Slap

| Field | Value |
|---|---|
| Kind · element | melee · None |
| Power · cooldown | 1.1 · 0 s |
| Telegraph | blue |

## Player response

Standard readable cue: guard, dodge or practice a parry.

## Used by

- [[Monsters/Aquatic/Giant Octopus|Giant Octopus]]
- [[Monsters/Aquatic/Kraken Spawn|Kraken Spawn]]
- [[Monsters/Aquatic/Abyssal Kraken Queen|Abyssal Kraken Queen]]
- [[Monsters/Aquatic/Reef Octopus|Reef Octopus]]
- [[Monsters/Aquatic/Vesper-Touched Kraken Spawn|Vesper-Touched Kraken Spawn]]
- [[Monsters/Aquatic/Phantom Abyssal Kraken Queen|Phantom Abyssal Kraken Queen]]
- [[Monsters/Aquatic/Krakenmother Ys, Queen of the Wreck Tide|Krakenmother Ys, Queen of the Wreck Tide]]

## Animation and fairness

The telegraph describes attack intent; motion data supplies windup, active timing, hitboxes and recovery. Preserve a visible decision window at gameplay camera distance, and verify that effects do not hide the tell. A shared attack can be reused across a family, but its delivery should still match the creature’s silhouette and behavior.
