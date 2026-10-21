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
| Steam page, marketing | Account, trailers, posting | Copy, descriptions, update notes |

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
| Ring | Name | Content | Goal |
|---|---|---|---|
| **0** | *Graybox Prototype* | One test field: movement, camera, combat (light/heavy/dodge/parry/skills), 3 monsters, Status Window, level-up | **Is combat fun?** |
| **1** | *Vertical Slice: "The Wooden Card"* | Brindlewick + Whisperwood, F→E, 4 base classes, Transported Origin, Lyra + Mochi, Goblin Chief trial, 1 dungeon, guild board, 20 monsters, basic crafting | **Steam page + demo for Steam Next Fest** |
| **2** | *Early Access 1.0: "Heartland"* | All of Aldmere F→C, all 8 base + 16 advanced classes, 3 Origins, 5 companions, Labyrinth 1–20, Stampede event, housing stage 1, ~20–25 hrs | **Paid Early Access launch** (one-time purchase) |
| **3** | *"Green Cathedral"* | Sylvaran Forest, B rank, Expert classes, 3 more companions | EA update |
| **4** | *"Endless Gold & Iron"* | Beastkin Plains + Iron Hold, A rank, arena, forging | EA update |
| **5** | *"Isles & Ice"* | Eastern Isles + Frostveil, Monster Origin | EA update |
| **6** | *"Sand & Sea"* | Sunscar + Abyssal Coast, sailing, S rank | EA update |
| **7** | *"The Generals"* | Act IV full, Dragon Spine, Sky Archipelago, SS | EA update |
| **8** | *"Ascension" (1.0)* | Demon Realm, Acts V–VI, SSS, all endings, Labyrinth 120 | **Full release** |

> **Recommendation:** use **Steam Early Access** with a one-time price. It fits "buy once", funds development, builds a community, and matches the ring structure. (Your decision, see Open Questions.)

## 6. Steam Checklist
- Steamworks account + **$100 app fee**.
- **Coming Soon page early** (wishlists are everything): at Ring 1.
- Capsule art, trailer, screenshots, a "Status Granted" hook trailer.
- **Steam Next Fest** demo (Ring 1 slice).
- Achievements, Cloud Save, Steam Deck verification, controller support.
- Price: decide at Ring 2 (EA usually a bit lower than 1.0 price).

## 7. Immediate Next Steps
1. ✅ Design bible v0.2 (this).
2. Lock the **combat feel** spec (moveset, timings, camera) → Ring 0 design doc.
3. Install **Unity 6 LTS** + Unity Hub; create the project; set up Git.
4. I write the core: player controller, camera, combat skeleton, stats, Status Window.
5. Make your character in **VRoid Studio**, import it via UniVRM, and run around a graybox field.
6. First playable within the first milestone; then iterate on fun.

## 8. Open Questions
1. **Early Access**, or wait for a full 1.0 launch? (Recommend EA.)
2. ~~Art direction~~ **DECIDED:** bright, flowing **Genshin-style cel-shaded anime**: vivid colors, flowing cloth and hair physics, stylized skies, glowing elemental VFX.
3. **Voice acting:** none, partial (key lines/System Voice), or full? (Partial recommended for budget.)
4. Romance: keep as designed (optional, all companions), or trim?
5. What's your experience with Unity and 3D tools? That tells me how much I should script vs explain.
6. **Title:** revisit around **Nov 1, 2026**.
