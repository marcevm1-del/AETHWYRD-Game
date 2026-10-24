---
type: monster-attack
id: atk_thrash
telegraph: red
kind: aoe
tags: [attack, aoe, none]
---
# Thrash

| Field | Value |
|---|---|
| Kind · element | aoe · None |
| Power · cooldown | 1.3 · 8 s |
| Telegraph | red |

## Player response

Unblockable cue: leave the attack line or marked area with a dodge.

## Used by

- [[Monsters/Shadows/Night Leviathan|Night Leviathan]]
- [[Monsters/Aquatic/Glowfin Angler|Glowfin Angler]]
- [[Monsters/Aquatic/Leviathan Young|Leviathan Young]]
- [[Monsters/Aquatic/Leviathan|Leviathan]]
- [[Monsters/Sandborne/Dunewhale Thalassa|Dunewhale Thalassa]]
- [[Monsters/Familiars & Gentle Creatures/Rainbow Koi|Rainbow Koi]]
- [[Monsters/Familiars & Gentle Creatures/Sky Whale|Sky Whale]]
- [[Monsters/Shadows/Greater Night Leviathan|Greater Night Leviathan]]
- [[Monsters/Aquatic/Phantom Glowfin Angler|Phantom Glowfin Angler]]
- [[Monsters/Aquatic/Phantom Leviathan Young|Phantom Leviathan Young]]
- [[Monsters/Familiars & Gentle Creatures/Crag Koi|Crag Koi]]
- [[Monsters/Familiars & Gentle Creatures/Greater Sky Whale|Greater Sky Whale]]
- [[Monsters/Aquatic/Ysgrath, the Ice-Jaw Leviathan|Ysgrath, the Ice-Jaw Leviathan]]
- [[Monsters/Aquatic/Lumen-Eater, the Abyss Angler|Lumen-Eater, the Abyss Angler]]

## Animation and fairness

The telegraph describes attack intent; motion data supplies windup, active timing, hitboxes and recovery. Preserve a visible decision window at gameplay camera distance, and verify that effects do not hide the tell. A shared attack can be reused across a family, but its delivery should still match the creature’s silhouette and behavior.
