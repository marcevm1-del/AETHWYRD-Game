---
type: monster-attack
id: atk_tail_whip
telegraph: red
kind: aoe
tags: [attack, aoe, none]
---
# Tail Whip

| Field | Value |
|---|---|
| Kind · element | aoe · None |
| Power · cooldown | 1.3 · 6 s |
| Telegraph | red |

## Player response

Unblockable cue: leave the attack line or marked area with a dodge.

## Used by

- [[Monsters/Killer Insects/Hive Tyrant|Hive Tyrant]]
- [[Monsters/Dragons/Wyvern|Wyvern]]
- [[Monsters/Dragons/Drake Lord|Drake Lord]]
- [[Monsters/Demons/Gargoyle|Gargoyle]]
- [[Monsters/Demons/Arch Demon|Arch Demon]]
- [[Monsters/Killer Insects/Vine Hive Tyrant|Vine Hive Tyrant]]
- [[Monsters/Dragons/Rime Wyvern|Rime Wyvern]]
- [[Monsters/Dragons/Vesper-Touched Drake Lord|Vesper-Touched Drake Lord]]
- [[Monsters/Demons/Briar Gargoyle|Briar Gargoyle]]
- [[Monsters/Demons/Blight Arch Demon|Blight Arch Demon]]
- [[Monsters/Killer Insects/Greater Hive Tyrant|Greater Hive Tyrant]]
- [[Monsters/Dragons/Vyrmax, the Drake Lord|Vyrmax, the Drake Lord]]

## Animation and fairness

The telegraph describes attack intent; motion data supplies windup, active timing, hitboxes and recovery. Preserve a visible decision window at gameplay camera distance, and verify that effects do not hide the tell. A shared attack can be reused across a family, but its delivery should still match the creature’s silhouette and behavior.
