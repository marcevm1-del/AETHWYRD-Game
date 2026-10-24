---
type: monster-attack
id: atk_null_rift
telegraph: red
kind: magic
tags: [attack, magic, void]
---
# Null Rift

| Field | Value |
|---|---|
| Kind · element | magic · Void |
| Power · cooldown | 1.5 · 10 s |
| Telegraph | red |

## Player response

Unblockable cue: leave the attack line or marked area with a dodge.

## Used by

- [[Monsters/Slimes/Abyss Slime|Abyss Slime]]
- [[Monsters/Slimes/Primordial Ooze|Primordial Ooze]]
- [[Monsters/Beasts/Garmrok, the World-Eater|Garmrok, the World-Eater]]
- [[Monsters/Insects & Arachnids/Hive Mother of the Abyss|Hive Mother of the Abyss]]
- [[Monsters/Shadows/Night Leviathan|Night Leviathan]]
- [[Monsters/Dragons/Umbrael, the Hollow Star|Umbrael, the Hollow Star]]
- [[Monsters/Dragons/Kaelumbra, the Twilight Arbiter|Kaelumbra, the Twilight Arbiter]]
- [[Monsters/Elementals & Spirits/Elemental Primarch|Elemental Primarch]]
- [[Monsters/Demons/Abyss Prince|Abyss Prince]]
- [[Monsters/Demons/Abyss Herald|Abyss Herald]]
- [[Monsters/Aquatic/Abyssal Kraken Queen|Abyssal Kraken Queen]]
- [[Monsters/Avians/Aethernax, the Sky Devourer|Aethernax, the Sky Devourer]]
- [[Monsters/Chimeras & Mythic Beasts/Nameless Abomination|Nameless Abomination]]
- [[Monsters/The Headless/Pale Herald|Pale Herald]]
- [[Monsters/Aberrations/Faceless One|Faceless One]]
- [[Monsters/Aberrations/The Many-Mouthed|The Many-Mouthed]]
- [[Monsters/Aberrations/Thousand-Eyed Watcher|Thousand-Eyed Watcher]]
- [[Monsters/Shadows/Greater Night Leviathan|Greater Night Leviathan]]
- [[Monsters/Demons/Ancient Abyss Prince|Ancient Abyss Prince]]
- [[Monsters/Aberrations/Vesper-Touched Faceless One|Vesper-Touched Faceless One]]
- [[Monsters/Demons/Varos, Herald of the Red Gate|Varos, Herald of the Red Gate]]
- [[Monsters/Aberrations/The Gentle Warden, Keeper of Ashira|The Gentle Warden, Keeper of Ashira]]

## Animation and fairness

The telegraph describes attack intent; motion data supplies windup, active timing, hitboxes and recovery. Preserve a visible decision window at gameplay camera distance, and verify that effects do not hide the tell. A shared attack can be reused across a family, but its delivery should still match the creature’s silhouette and behavior.
