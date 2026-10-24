---
type: monster-attack
id: atk_ground_pound
telegraph: red
kind: aoe
tags: [attack, aoe, none]
---
# Ground Pound

| Field | Value |
|---|---|
| Kind · element | aoe · None |
| Power · cooldown | 1.8 · 10 s |
| Telegraph | red |

## Player response

Unblockable cue: leave the attack line or marked area with a dodge.

## Used by

- [[Monsters/Constructs & Mimics/Stone Golem|Stone Golem]]
- [[Monsters/Constructs & Mimics/Clockwork Sentinel|Clockwork Sentinel]]
- [[Monsters/Constructs & Mimics/Iron Golem|Iron Golem]]
- [[Monsters/Constructs & Mimics/Crystal Golem|Crystal Golem]]
- [[Monsters/Constructs & Mimics/Mithril Colossus|Mithril Colossus]]
- [[Monsters/Constructs & Mimics/Starmetal Colossus|Starmetal Colossus]]
- [[Monsters/Constructs & Mimics/Titan of the First Age|Titan of the First Age]]
- [[Monsters/Floor-born/Core Sentinel|Core Sentinel]]
- [[Monsters/Constructs & Mimics/Greater Stone Golem|Greater Stone Golem]]
- [[Monsters/Constructs & Mimics/Dusk Clockwork Sentinel|Dusk Clockwork Sentinel]]
- [[Monsters/Constructs & Mimics/Greater Iron Golem|Greater Iron Golem]]
- [[Monsters/Constructs & Mimics/Vesper-Touched Crystal Golem|Vesper-Touched Crystal Golem]]
- [[Monsters/Constructs & Mimics/Ancient Mithril Colossus|Ancient Mithril Colossus]]
- [[Monsters/Constructs & Mimics/Tide Starmetal Colossus|Tide Starmetal Colossus]]
- [[Monsters/Floor-born/Greater Core Sentinel|Greater Core Sentinel]]
- [[Monsters/Constructs & Mimics/The Tithe Colossus, Hunger of the Foundation Stones|The Tithe Colossus, Hunger of the Foundation Stones]]
- [[Monsters/Constructs & Mimics/The Colossus of Sunscar, Walker of the Dunes|The Colossus of Sunscar, Walker of the Dunes]]

## Animation and fairness

The telegraph describes attack intent; motion data supplies windup, active timing, hitboxes and recovery. Preserve a visible decision window at gameplay camera distance, and verify that effects do not hide the tell. A shared attack can be reused across a family, but its delivery should still match the creature’s silhouette and behavior.
