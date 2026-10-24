---
type: monster-attack
id: atk_frost_breath
telegraph: red
kind: magic
tags: [attack, magic, ice]
---
# Frost Breath

| Field | Value |
|---|---|
| Kind · element | magic · Ice |
| Power · cooldown | 1.5 · 10 s |
| Telegraph | red |

## Player response

Unblockable cue: leave the attack line or marked area with a dodge.

## Used by

- [[Monsters/Slimes/Frost Slime|Frost Slime]]
- [[Monsters/Beasts/Frost Fenrir Pup|Frost Fenrir Pup]]
- [[Monsters/Beasts/Sabretooth King|Sabretooth King]]
- [[Monsters/Lycanthropes/Fenrir-Blooded Lord|Fenrir-Blooded Lord]]
- [[Monsters/Undead/Lich|Lich]]
- [[Monsters/Undead/Lich Emperor|Lich Emperor]]
- [[Monsters/Orcs, Ogres & Giants/Frost Giant|Frost Giant]]
- [[Monsters/Dragons/Frost Drake|Frost Drake]]
- [[Monsters/Dragons/Glacirra, the White Silence|Glacirra, the White Silence]]
- [[Monsters/Familiars & Gentle Creatures/Snowmole|Snowmole]]
- [[Monsters/Slimes/Elder Frost Slime|Elder Frost Slime]]
- [[Monsters/Kobolds/Snow Kobold Sneak|Snow Kobold Sneak]]
- [[Monsters/Beasts/Ancient Sabretooth King|Ancient Sabretooth King]]
- [[Monsters/Orcs, Ogres & Giants/Rime Ogre|Rime Ogre]]
- [[Monsters/Orcs, Ogres & Giants/Vesper-Touched Frost Giant|Vesper-Touched Frost Giant]]
- [[Monsters/Reptiles/Frost Toad|Frost Toad]]
- [[Monsters/Reptiles/Frost Hydra|Frost Hydra]]
- [[Monsters/Dragons/Rime Hatchling|Rime Hatchling]]
- [[Monsters/Dragons/Rime Wyvern|Rime Wyvern]]
- [[Monsters/Plants & Fungi/Frost Puffcap Mushroom|Frost Puffcap Mushroom]]
- [[Monsters/Familiars & Gentle Creatures/Rime Fluffcap Sheep|Rime Fluffcap Sheep]]
- [[Monsters/Slimes/Vesper-Touched Frost Slime|Vesper-Touched Frost Slime]]
- [[Monsters/Slimes/Glacier Cube Slime|Glacier Cube Slime]]
- [[Monsters/Kobolds/Frost Kobold Shaman|Frost Kobold Shaman]]
- [[Monsters/Insects & Arachnids/Frost Arachne|Frost Arachne]]
- [[Monsters/Undead/Ancient Lich|Ancient Lich]]
- [[Monsters/Orcs, Ogres & Giants/Ymgrir, the Frost Sovereign|Ymgrir, the Frost Sovereign]]
- [[Monsters/Aquatic/Ysgrath, the Ice-Jaw Leviathan|Ysgrath, the Ice-Jaw Leviathan]]
- [[Monsters/Beasts/Thrakka, Sabretooth Khan of the Steppe Horde|Thrakka, Sabretooth Khan of the Steppe Horde]]
- [[Monsters/Plants & Fungi/The Briar King, Lord of the Winter Court|The Briar King, Lord of the Winter Court]]

## Animation and fairness

The telegraph describes attack intent; motion data supplies windup, active timing, hitboxes and recovery. Preserve a visible decision window at gameplay camera distance, and verify that effects do not hide the tell. A shared attack can be reused across a family, but its delivery should still match the creature’s silhouette and behavior.
