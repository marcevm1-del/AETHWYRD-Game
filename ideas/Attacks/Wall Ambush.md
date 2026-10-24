---
type: monster-attack
id: atk_wall_ambush
telegraph: red
kind: dash
tags: [attack, dash, none]
---
# Wall Ambush

| Field | Value |
|---|---|
| Kind · element | dash · None |
| Power · cooldown | 1.4 · 10 s |
| Telegraph | red |

## Player response

Unblockable cue: leave the attack line or marked area with a dodge.

## Used by

- [[Monsters/Floor-born/Floor Crawler|Floor Crawler]]
- [[Monsters/Floor-born/Wall Stalker|Wall Stalker]]
- [[Monsters/Floor-born/Labyrinth Hound|Labyrinth Hound]]
- [[Monsters/Floor-born/Core Sentinel|Core Sentinel]]
- [[Monsters/Floor-born/Maze Weaver|Maze Weaver]]
- [[Monsters/Floor-born/Floor Tyrant|Floor Tyrant]]
- [[Monsters/Floor-born/Thunder Floor Crawler|Thunder Floor Crawler]]
- [[Monsters/Floor-born/Ruin Wall Stalker|Ruin Wall Stalker]]
- [[Monsters/Floor-born/Ruin Hound|Ruin Hound]]
- [[Monsters/Floor-born/Greater Core Sentinel|Greater Core Sentinel]]
- [[Monsters/Floor-born/Elder Maze Weaver|Elder Maze Weaver]]
- [[Monsters/Floor-born/Greater Floor Tyrant|Greater Floor Tyrant]]

## Animation and fairness

The telegraph describes attack intent; motion data supplies windup, active timing, hitboxes and recovery. Preserve a visible decision window at gameplay camera distance, and verify that effects do not hide the tell. A shared attack can be reused across a family, but its delivery should still match the creature’s silhouette and behavior.
