---
type: monster-attack
id: atk_trip_wire_trap
telegraph: none
kind: debuff
tags: [attack, debuff, none]
---
# Trip-Wire Trap

| Field | Value |
|---|---|
| Kind · element | debuff · None |
| Power · cooldown | 0 · 14 s |
| Telegraph | none |

## Player response

Read the animation and keep moving; do not assume a block is safe.

## Used by

- [[Monsters/Kobolds/Kobold Scavenger|Kobold Scavenger]]
- [[Monsters/Kobolds/Kobold Miner|Kobold Miner]]
- [[Monsters/Kobolds/Kobold Sneak|Kobold Sneak]]
- [[Monsters/Kobolds/Kobold Shaman|Kobold Shaman]]
- [[Monsters/Kobolds/Kobold Trapmaster|Kobold Trapmaster]]
- [[Monsters/Kobolds/Kobold Packleader|Kobold Packleader]]
- [[Monsters/Kobolds/Kobold Warlord|Kobold Warlord]]
- [[Monsters/Kobolds/Kobold Tunnel-Queen|Kobold Tunnel-Queen]]
- [[Monsters/Kobolds/Kobold Scavenger Veteran|Kobold Scavenger Veteran]]
- [[Monsters/Kobolds/Ruin Kobold Miner|Ruin Kobold Miner]]
- [[Monsters/Kobolds/Snow Kobold Sneak|Snow Kobold Sneak]]
- [[Monsters/Kobolds/Cavern Kobold Shaman|Cavern Kobold Shaman]]
- [[Monsters/Kobolds/Vesper-Touched Kobold Trapmaster|Vesper-Touched Kobold Trapmaster]]
- [[Monsters/Kobolds/Vesper-Touched Kobold Packleader|Vesper-Touched Kobold Packleader]]
- [[Monsters/Kobolds/Kobold Warlord Veteran|Kobold Warlord Veteran]]
- [[Monsters/Kobolds/Vesper-Touched Kobold Tunnel-Queen|Vesper-Touched Kobold Tunnel-Queen]]
- [[Monsters/Kobolds/Phantom Kobold Scavenger|Phantom Kobold Scavenger]]
- [[Monsters/Kobolds/Elite Kobold Miner|Elite Kobold Miner]]
- [[Monsters/Kobolds/Phantom Kobold Sneak|Phantom Kobold Sneak]]
- [[Monsters/Kobolds/Frost Kobold Shaman|Frost Kobold Shaman]]
- [[Monsters/Kobolds/Crag Kobold Trapmaster|Crag Kobold Trapmaster]]
- [[Monsters/Kobolds/Ancient Kobold Packleader|Ancient Kobold Packleader]]
- [[Monsters/Kobolds/Shade Kobold Warlord|Shade Kobold Warlord]]
- [[Monsters/Kobolds/Kobold Tunnel-Queen Veteran|Kobold Tunnel-Queen Veteran]]

## Animation and fairness

The telegraph describes attack intent; motion data supplies windup, active timing, hitboxes and recovery. Preserve a visible decision window at gameplay camera distance, and verify that effects do not hide the tell. A shared attack can be reused across a family, but its delivery should still match the creature’s silhouette and behavior.
