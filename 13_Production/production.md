# 13 — Production Plan: Two-Person Team, 3D, Steam (v0.2)

## 1. Reality Check (honest)
A full 3D open-world RPG of this size is something studios of 50–300 people build over 4–6 years. **We can still make it**, but only by:
1. **Building in rings:** ship a polished first region, then expand.
2. **Being data-driven:** content lives in text data files I can generate and balance quickly.
3. **Buying and assembling art, not hand-making all of it:** anime character tools, animation libraries, asset packs, plus Blender for custom pieces.
4. **Keeping systems modular:** each system (combat, quests, crafting…) is its own module that we finish before the next one.

## 2. Engine Recommendation: **Unity 6 (URP)**
| Reason | Detail |
|---|---|
| Claude-friendly | C# scripts, JSON data, editor tools: I can write and modify all of it directly as text |
| Anime look | Unity's free **Toon Shader** (official), plus many anime shader options |
| Anime characters | **VRoid Studio** (free) → VRM → **UniVRM** importer. Fast anime-style characters, customizable |
| Animation | Mixamo (free) + anime animation packs on the Asset Store; Unity's Humanoid retargeting |
| Open world | Terrain tools, additive scene streaming, many open-world assets |
| Steam | **Steamworks.NET** is mature and free |
| Alternatives | **Unreal 5**: best visuals, but Blueprints are binary, so I can't edit them directly; heavier for 2 people. **Godot 4**: text-based and great for AI collaboration, but weaker 3D open-world tooling and fewer anime assets |

## 3. Pipeline: Who Does What
| Area | You | Claude |
|---|---|---|
| Creative direction | ✅ final say | Proposals, options, consistency checks |
| Design docs | Review, decide | Write, expand, balance |
| Gameplay code (C#) | Test, playtest, report | Write systems, fix bugs, editor tools |
| Data (monsters, items, quests) | Approve, tweak | Generate JSON/CSV, balance curves |
| 3D characters | Build in VRoid, pick assets | Setup scripts, import pipeline, Blender automation |
| Environments | Place, art-direct in editor | Procedural tools, placement scripts |
| Writing (dialogue, lore, flavor) | Review voice, tone | Draft everything |
| Music/SFX | Choose, commission, or license | Specify needs per region and event |
| Release & marketing (later) | Account, trailers, posting | Copy, descriptions, update notes |

## 4. Project Structure (Unity)
```
ProjectAscend/
├── Assets/
│   ├── _Game/
│   │   ├── Code/
│   │   │   ├── Core/          (GameState, SaveSystem, EventBus, TimeOfDay, Moons)
│   │   │   ├── Combat/        (Damage, Elements, StatusEffects, Hitboxes, Parry)
│   │   │   ├── Actors/        (Player, Companion, Monster, NPC, AI)
│   │   │   ├── Progression/   (Stats, Leveling, Rank, Classes, Skills, Titles)
│   │   │   ├── Items/         (Inventory, Equipment, Crafting, Loot)
│   │   │   ├── Quests/        (QuestEngine, Requirements, GuildBoard, Events)
│   │   │   ├── World/         (Regions, Spawning, Weather, Waystones, Streaming)
│   │   │   ├── Social/        (Dialogue, Reputation, Bonds, Karma)
│   │   │   ├── Settlement/    (Housing, Farming, Territory)
│   │   │   └── UI/            (StatusWindow, HUD, Menus, Journal, Map)
│   │   ├── Data/              (JSON → imported into ScriptableObjects)
│   │   │   ├── Ranks/ Classes/ Skills/ Races/ Origins/
│   │   │   ├── Monsters/ Items/ Quests/ Dialogue/ Regions/ Loot/
│   │   ├── Art/ Audio/ Prefabs/ Scenes/ Shaders/ VFX/
│   └── ThirdParty/
├── Design/                    (this bible)
└── Tools/                     (data validators, balance spreadsheets, import scripts)
```
**Version control:** Git + Git LFS (GitHub private repo). Commit often; I can manage commits.

## 5. Build Rings (roadmap)
Rings are **internal milestones**, not release dates. Each ring adds regions (see `ring` in `Data/World/regions.json`) and the monsters tagged for it (`ring` in `Data/Monsters/species.json`).

| Ring | Name | Content | Goal |
|---|---|---|---|
| **0** | *Graybox Prototype* | One test field: movement, camera, lock-on/free aim, combat (light/heavy/dodge/parry/skills, hit-stop), **3 monsters** (Blue Slime, Goblin, Horned Rabbit), one elemental combo, Status Window, level-ups | **Is combat fun?** |
| **1** | *Vertical Slice: "The Wooden Card"* | Brindlewick + Whisperwood, ranks F→E, 4 of the 12 base classes, Transported Origin, Lyra + Mochi, Goblin Chief trial, 1 dungeon, guild board, **20 monsters** | **Is the whole loop fun?** |
| **2** | *"Heartland"* | All of Aldmere + Greymoor + Labyrinth floors 1–40, ranks F→C, all 12 base + 24 advanced classes, 3 Origins, 5 companions, Stampede event, housing stage 1 | First big content milestone (playtest build) |
| **3** | *"Green Cathedral"* | Sylvaran, Mossdeep, Lirian | Rank B, Expert classes |
| **4** | *"Gold, Iron & Monsters"* | Fanghold, Iron Hold, Moraveil, Strife Marches, Velmark | Arena, forging, monster nation |
| **5** | *"East & North"* | Hoshizora, Kitsune Isles, Shen-Lu, Haneul, Frostveil, Whitewater Reach, Umbravel | Monster Origin, cultivation |
| **6** | *"Sand & Sea"* | Sunscar, Zarvan, Zaruma, Dunewhale, Xochitl, Lumbaya, Stormreach, Goldmere, True-Name Isles, Hollow Sea, Ashira Vale, Labyrinth 41–90 | Rank S, sailing |
| **7** | *"The Generals"* | Dragon Spine, Sky Archipelago, Heavenreach, Vharlen, Gearholm, Cinderhole, Bastion, Everdusk, Apu, Lustrine, Quaking Lands, Aurumdeep | Act IV complete, rank SS |
| **8** | *"Ascension"* | Nox Dominion, Calamity Steppe, The Maw, Root of the World, Labyrinth 91–120 | Acts V–VI, SSS, all endings |
| **9** | *Post-game* | Vesper, the Drowned Sky-City | Malgareth, the 1,000-hour secret ending |

**Art budget per ring:** the species counts per ring (from the generator) are an upper bound. Ring 2's ~145 tagged species will be trimmed during Ring 2 planning; core designs come first, variants follow.

## 6. Release & Steam (deferred, Q49)
Steam and release planning are **parked until we're near the end** (your decision). Notes for then:
- Steamworks account + $100 app fee; Coming Soon page; trailers; achievements, Cloud Save, Steam Deck, controller support.
- **Open decision:** full 1.0 release vs Early Access. Ring 2 is far too small to sell against a 1,000-hour promise, so if Early Access is chosen, the earliest sensible point is after Ring 4–5.
- Realistic timeline: Ring 0 (first prototype) is the January 2027 target. A public release is years away at 4–5 hrs/week.

## 7. Immediate Next Steps
1. ✅ Design bible consolidated (v0.7), data layer validated (`npm run build`).
2. Write the **combat feel** spec (moveset, timings, camera) → Ring 0 design doc.
3. Install **Unity 6 LTS** + Unity Hub **on E:**; create the Unity project inside this repo.
4. Claude writes the core: player controller, camera, combat skeleton, stats, Status Window, JSON data importer.
5. Make your character in **VRoid Studio**, import via UniVRM, and run around a graybox field.

## 8. Open Questions
1. Release model (Early Access vs full 1.0): **deferred** until near the end.
2. **Voice acting:** none, partial (key lines/System Voice), or full? (You'll decide later.)
3. **Companion count lock:** see Canon.md (proposed: 12 companions + Mochi).
4. **Title:** revisit around **Nov 1, 2026**.

## Reality Check: January 2027
At 4–5 hrs/week (~50 hours by January), an Early Access 3D open-world RPG isn't achievable. What **is** realistic: the **Ring 0 playable prototype**: your VRoid character in a graybox field; run, climb, lock-on/free aim, light/heavy/dodge combos with hit-stop; Blue Slime, Goblin and Horned Rabbit; one elemental combo; the Status Window; level-ups.
