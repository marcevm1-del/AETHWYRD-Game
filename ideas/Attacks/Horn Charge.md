---
type: monster-attack
id: atk_horn_charge
telegraph: red
kind: dash
tags: [attack, dash, none]
---
# Horn Charge

| Field | Value |
|---|---|
| Kind · element | dash · None |
| Power · cooldown | 1.8 · 9 s |
| Telegraph | red |

## Player response

Unblockable cue: leave the attack line or marked area with a dodge.

## Used by

- [[Monsters/Minotaurs & Beastmen/Calf Minotaur|Calf Minotaur]]
- [[Monsters/Minotaurs & Beastmen/Satyr Reveler|Satyr Reveler]]
- [[Monsters/Minotaurs & Beastmen/Gnoll Raider|Gnoll Raider]]
- [[Monsters/Minotaurs & Beastmen/Minotaur|Minotaur]]
- [[Monsters/Minotaurs & Beastmen/Labyrinth Minotaur|Labyrinth Minotaur]]
- [[Monsters/Minotaurs & Beastmen/Taurgrim, the Maze King|Taurgrim, the Maze King]]
- [[Monsters/Minotaurs & Beastmen/Vesper-Touched Calf Minotaur|Vesper-Touched Calf Minotaur]]
- [[Monsters/Minotaurs & Beastmen/Ash Satyr Reveler|Ash Satyr Reveler]]
- [[Monsters/Minotaurs & Beastmen/Cavern Gnoll Raider|Cavern Gnoll Raider]]
- [[Monsters/Minotaurs & Beastmen/Deep Minotaur|Deep Minotaur]]
- [[Monsters/Minotaurs & Beastmen/Vesper-Touched Labyrinth Minotaur|Vesper-Touched Labyrinth Minotaur]]

## Animation and fairness

The telegraph describes attack intent; motion data supplies windup, active timing, hitboxes and recovery. Preserve a visible decision window at gameplay camera distance, and verify that effects do not hide the tell. A shared attack can be reused across a family, but its delivery should still match the creature’s silhouette and behavior.
