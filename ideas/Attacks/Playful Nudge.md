---
type: monster-attack
id: atk_playful_nudge
telegraph: none
kind: melee
tags: [attack, melee, none]
---
# Playful Nudge

| Field | Value |
|---|---|
| Kind · element | melee · None |
| Power · cooldown | 0.5 · 6 s |
| Telegraph | none |

## Player response

Read the animation and keep moving; do not assume a block is safe.

## Used by

- [[Monsters/Familiars & Gentle Creatures/Moss Tortoise|Moss Tortoise]]
- [[Monsters/Familiars & Gentle Creatures/Lantern Moth|Lantern Moth]]
- [[Monsters/Familiars & Gentle Creatures/Fluffcap Sheep|Fluffcap Sheep]]
- [[Monsters/Familiars & Gentle Creatures/Rainbow Koi|Rainbow Koi]]
- [[Monsters/Familiars & Gentle Creatures/Mana Fox|Mana Fox]]
- [[Monsters/Familiars & Gentle Creatures/Ember Kitten|Ember Kitten]]
- [[Monsters/Familiars & Gentle Creatures/Snowmole|Snowmole]]
- [[Monsters/Familiars & Gentle Creatures/Sky Whale|Sky Whale]]
- [[Monsters/Familiars & Gentle Creatures/Crag Moss Tortoise|Crag Moss Tortoise]]
- [[Monsters/Familiars & Gentle Creatures/Elder Lantern Moth|Elder Lantern Moth]]
- [[Monsters/Familiars & Gentle Creatures/Rime Fluffcap Sheep|Rime Fluffcap Sheep]]
- [[Monsters/Familiars & Gentle Creatures/Crag Koi|Crag Koi]]
- [[Monsters/Familiars & Gentle Creatures/Ember Mana Fox|Ember Mana Fox]]
- [[Monsters/Familiars & Gentle Creatures/Moss Kitten|Moss Kitten]]
- [[Monsters/Familiars & Gentle Creatures/Sky Snowmole|Sky Snowmole]]
- [[Monsters/Familiars & Gentle Creatures/Greater Sky Whale|Greater Sky Whale]]

## Animation and fairness

The telegraph describes attack intent; motion data supplies windup, active timing, hitboxes and recovery. Preserve a visible decision window at gameplay camera distance, and verify that effects do not hide the tell. A shared attack can be reused across a family, but its delivery should still match the creature’s silhouette and behavior.
