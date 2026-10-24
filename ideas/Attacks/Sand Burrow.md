---
type: monster-attack
id: atk_sand_burrow
telegraph: red
kind: dash
tags: [attack, dash, none]
---
# Sand Burrow

| Field | Value |
|---|---|
| Kind · element | dash · None |
| Power · cooldown | 1.5 · 10 s |
| Telegraph | red |

## Player response

Unblockable cue: leave the attack line or marked area with a dodge.

## Used by

- [[Monsters/Sandborne/Sand Skink|Sand Skink]]
- [[Monsters/Sandborne/Dune Scorpion|Dune Scorpion]]
- [[Monsters/Sandborne/Glass Wraith|Glass Wraith]]
- [[Monsters/Sandborne/Sandworm|Sandworm]]
- [[Monsters/Sandborne/Dunewhale Thalassa|Dunewhale Thalassa]]
- [[Monsters/Sandborne/Greater Sand Skink|Greater Sand Skink]]
- [[Monsters/Sandborne/Elder Dune Scorpion|Elder Dune Scorpion]]
- [[Monsters/Sandborne/Elder Glass Wraith|Elder Glass Wraith]]
- [[Monsters/Sandborne/Elder Sandworm|Elder Sandworm]]
- [[Monsters/Sandborne/Glassmaw, Worm of the Endless Dune|Glassmaw, Worm of the Endless Dune]]

## Animation and fairness

The telegraph describes attack intent; motion data supplies windup, active timing, hitboxes and recovery. Preserve a visible decision window at gameplay camera distance, and verify that effects do not hide the tell. A shared attack can be reused across a family, but its delivery should still match the creature’s silhouette and behavior.
