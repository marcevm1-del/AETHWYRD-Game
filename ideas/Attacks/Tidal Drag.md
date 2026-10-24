---
type: monster-attack
id: atk_tidal_drag
telegraph: gold
kind: grab
tags: [attack, grab, none]
---
# Tidal Drag

| Field | Value |
|---|---|
| Kind · element | grab · None |
| Power · cooldown | 1.3 · 11 s |
| Telegraph | gold |

## Player response

Grab cue: create distance or dodge before contact.

## Used by

- [[Monsters/Aquatic/Giant Crab|Giant Crab]]
- [[Monsters/Aquatic/Piranha Swarm|Piranha Swarm]]
- [[Monsters/Aquatic/Sahuagin|Sahuagin]]
- [[Monsters/Aquatic/Glowfin Angler|Glowfin Angler]]
- [[Monsters/Aquatic/Sea Serpent|Sea Serpent]]
- [[Monsters/Aquatic/Siren|Siren]]
- [[Monsters/Aquatic/Giant Octopus|Giant Octopus]]
- [[Monsters/Aquatic/Kraken Spawn|Kraken Spawn]]
- [[Monsters/Aquatic/Merfolk Warden|Merfolk Warden]]
- [[Monsters/Aquatic/Leviathan Young|Leviathan Young]]
- [[Monsters/Aquatic/Abyssal Kraken Queen|Abyssal Kraken Queen]]
- [[Monsters/Aquatic/Leviathan|Leviathan]]
- [[Monsters/Aquatic/Reef Crab|Reef Crab]]
- [[Monsters/Aquatic/Bog Piranha Swarm|Bog Piranha Swarm]]
- [[Monsters/Aquatic/Vesper-Touched Sahuagin|Vesper-Touched Sahuagin]]
- [[Monsters/Aquatic/Phantom Glowfin Angler|Phantom Glowfin Angler]]
- [[Monsters/Aquatic/Abyssal Sea Serpent|Abyssal Sea Serpent]]
- [[Monsters/Aquatic/Ancient Siren|Ancient Siren]]
- [[Monsters/Aquatic/Reef Octopus|Reef Octopus]]
- [[Monsters/Aquatic/Vesper-Touched Kraken Spawn|Vesper-Touched Kraken Spawn]]
- [[Monsters/Aquatic/Bog Merfolk Warden|Bog Merfolk Warden]]
- [[Monsters/Aquatic/Phantom Leviathan Young|Phantom Leviathan Young]]
- [[Monsters/Aquatic/Phantom Abyssal Kraken Queen|Phantom Abyssal Kraken Queen]]
- [[Monsters/Aquatic/The Drowned Choir, Sirens of the Canals|The Drowned Choir, Sirens of the Canals]]
- [[Monsters/Aquatic/Ysgrath, the Ice-Jaw Leviathan|Ysgrath, the Ice-Jaw Leviathan]]
- [[Monsters/Aquatic/Krakenmother Ys, Queen of the Wreck Tide|Krakenmother Ys, Queen of the Wreck Tide]]
- [[Monsters/Aquatic/The Nameless Tide, a Serpent Without a Name|The Nameless Tide, a Serpent Without a Name]]
- [[Monsters/Aquatic/Lumen-Eater, the Abyss Angler|Lumen-Eater, the Abyss Angler]]

## Animation and fairness

The telegraph describes attack intent; motion data supplies windup, active timing, hitboxes and recovery. Preserve a visible decision window at gameplay camera distance, and verify that effects do not hide the tell. A shared attack can be reused across a family, but its delivery should still match the creature’s silhouette and behavior.
