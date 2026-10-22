# 12 — Game Systems (v0.2)

## 1. The Status Window
A translucent blue holographic panel with soft chimes; it opens in a burst of runes.
```
╔════════════════════════════════════════════════╗
║  [Player]                Human · Transported   ║
║  RANK: C  (Card shows: F)   TITLE: Goblin Bane ║
║  CLASS: Blademaster Lv.34 · Sub: Cook Lv.12    ║
║  HP 2,140  MP 480  SP 720                      ║
║  STR 168 VIT 112 AGI 190 DEX 141               ║
║  INT 44  WIS 39  LUK 81  CHA 66                ║
║  UNIQUE: [Copy] 3/5 · Affinity: Wind, Light    ║
║  BLESSING: Kaelthas (Devotion 4)               ║
║  SKILLS ▸  TITLES ▸  BESTIARY ▸  JOURNAL ▸     ║
╚════════════════════════════════════════════════╝
```
- **System Voice** (optional voice-over): level-ups, skill evolutions, and world announcements: *"An individual has slain an Elder Dragon. World Recognition updated."*
- **Glitches** (story): the Voice occasionally stutters your old-world name.
- **Titles:** 200+ titles, each with a small passive. Equip 1 main title (shown to NPCs) + 3 passive titles.

## 2. Progression Tracks
| Track | Grows from |
|---|---|
| Level | XP from everything (combat, quests, discovery, crafting) |
| Rank | GP + requirements + trial |
| Class tier | Rank + class quest |
| Skills | Use (proficiency) |
| Unique Skill | Story milestones + feats |
| Titles | Achievements |
| Reputation | Faction actions |
| Devotion | Prayer + divine quests |
| Bonds | Companion time + choices |
| Home/Territory | Investment |
| Bestiary | Appraisal and kills (100% completion rewards) |

**Discovery XP:** finding vistas, ruins, lore and secrets gives meaningful XP. Exploration is a valid way to level.

## 3. Combat Feel
> Overview only. The full, numbered spec is **`12_Systems/combat.md`** (tuning values in `Data/Combat/combat_tuning.json`); it wins on any detail.

- **Third-person action:** light/heavy attack, dodge (i-frames), block/parry, jump, sprint, lock-on.
- **Skill palette:** 4 slots + Ultimate (6 at B, 8 at S); hold a trigger to open the second palette.
- **Companion commands:** a quick wheel (Focus, Defend, Heal, Hold, Union Skill).
- **Union Skills:** when you and a companion both have meter, trigger a cinematic combo.
- **Awakening / Limit Burst:** 100% meter → transformation (aura, hair glow, music swells).
- **Stagger/Break** on bosses; breakable parts.
- **Elemental world interactions:** fire burns grass, lightning chains through water, ice freezes rivers into bridges, wind spreads fire.
- **Difficulty modes:** Story / Adventurer / Veteran / Hardcore (permadeath).

## 4. Economy
- **Coins:** Copper → Silver (100c) → Gold (100s) → Platinum (100g) → **Mithril Coin** (100p).
- **Income:** quests, monster cores, loot, crafting, shops, trade routes, farm produce, arena bets, territory taxes.
- **Sinks:** repairs, enhancement, housing, taxes, tuition, respec, airships, festival goods.
- **Regional prices:** sell ice gems in the desert for profit, buy cheap spices in the Isles. A trade-route minigame.
- **Supply/demand (light):** flooding a market lowers prices for a while.

## 5. Crafting & Life Skills
| Life Skill | Produces | Station |
|---|---|---|
| Blacksmithing | Metal weapons/armor | Forge |
| Leatherworking | Light armor, bags | Tannery |
| Tailoring | Cloth armor, cosmetics, dyes | Loom |
| Alchemy | Potions, bombs, transmutation | Alembic |
| Enchanting | Enchantments, scrolls | Enchanting table |
| Runecraft | Khazdûr runes | Rune anvil (Iron Hold) |
| Jewelcrafting | Rings, amulets, gems | Jeweler's bench |
| Cooking | Food buffs, permanent stat dishes | Kitchen/campfire |
| Brewing | Ales, spirits, potions-lite | Brewery |
| Farming | Crops, magic herbs, monster plants | Fields |
| Animal husbandry | Eggs, wool, milk, mounts | Barn |
| Mining / Logging / Herbalism | Raw materials | World nodes |
| Fishing | Fish, sea loot, legendary fish | Water |
| Engineering (Otherworld) | Gadgets, guns, golems, airships | Workshop |
| Painting / Music | Decor, buffs, hidden classes | Easel / instruments |

- **Quality:** Poor → Normal → Fine → Superior → Masterwork → **Legendary**.
- **Crafting minigames** (optional, skippable): forging rhythm, alchemy mixing, cooking timing. Better play gives better quality.
- **Recipe discovery:** experiment, buy, loot, learn from NPCs, or **recall from your old world**.

## 6. Housing → Territory (Slow-Life Pillar)
| Stage | Rank | Features |
|---|---|---|
| Inn room | F | Storage, bed (rest bonus) |
| Rented room in the guild house | C | Party base, crafting stations |
| **Home + land** (Brindlewick plot) | B | Farm, barn, garden, decorate, pets roam, companions live there |
| Manor / Shop | A | Hire NPC staff; your shop sells crafts while you adventure |
| **Village / Territory** | S | Recruit residents (rescued NPCs!), build structures, defense raids, festivals |
| **Free City Patronage** | SS+ | Become a city's Lord Protector (no crown, no guild ownership); diplomacy, defense |

- **Decorating:** free-placement furniture, trophies from bosses (mounted heads, displayed legendary weapons), paintings you made.
- **Residents** come from quests: refugees you saved, a goblin child, a retired knight, a fairy family.

## 7. Taming & Familiars
- **Tame:** weaken → offer the right food/item → CHA + skill check (some need special quests).
- **Familiar slots:** 1 → 2 → 3 by rank.
- **Familiars:** level, evolve, learn skills, gain names; large ones can be **ridden**; all can live at your home (ranch).
- **Name-Giving:** naming a strong monster with a *Name-Giving Ribbon* can trigger a special evolution.

## 8. Bonds & Romance
- Bond 0–10 with each companion. Raise it through camp talks, gifts, shared battles, choices they approve of, and personal quests.
- **Bond rewards:** Union Skills, new outfits, their ultimate class, and their ending epilogue.
- **Romance:** optional, available with the adult companions listed in `Canon.md` §4 (not Nyx, Mochi or Named-monster companions), for male and female player characters, no gender locks, no gameplay gating. A marriage ceremony is possible at your home.
- **Rivalries:** some NPCs have rival meters too (Kaito).

## 9. Karma & Morality
- Hidden −1000 to +1000.
- Affects: class unlocks (Paladin +, Necromancer −), unicorns, sentient weapons, NPC trust, guards, endings, the Demon Realm reception.
- **Not binary:** some "dark" acts are justified; the Church's "holy" acts can be monstrous.

## 10. Death & Difficulty
| Mode | Death penalty |
|---|---|
| Story | Respawn at waystone, no loss |
| Adventurer (default) | Drop 10% carried gold (recover it at your death spot), durability loss |
| Veteran | Lose 5% XP toward next level + item durability |
| Hardcore | Permadeath; your grave appears in the world for new characters to find |
- *Second Dawn* (Unique Skill) replaces death with a time rewind.
- Companions can be "downed" and revived; permanent companion death only in story moments.

## 11. Quality-of-Life
- **Journal:** quests, rumors, lore, bestiary, recipes, people met.
- **Rumor board:** in every tavern; hints toward secrets and Named monsters.
- **Map:** hand-drawn style; fills in as you explore; custom pins.
- **Photo mode:** with poses, filters, companions.
- **Accessibility:** subtitles, colorblind palettes, combat assist, remappable controls, difficulty sliders.
- **Steam:** achievements (150+), cloud saves, Steam Deck controls, rich presence ("Exploring Whisperwood · Rank D").

## Combat Pillars
> Summary of the pillars detailed in `12_Systems/combat.md`.

1. **Fluid:** every attack can cancel into a dodge; skills cancel into skills (on a combo budget).
2. **Fast:** quick base speed, dash, air dash, launch → juggle → slam.
3. **Heavy:** hit-stop on impact, camera shake, enemies get knocked back, ground cracks, sound punches.
4. **Flashy:** elemental VFX trails, a short cinematic camera for ultimates, glowing magic circles, screen-wide explosions.
5. **Stylish:** a **Style Rank** meter (C → B → A → S → SS → SSS, fitting our rank theme!) rewards variety; higher style gives bonus XP and drops.
6. **Combinational:** weapon arts + spells + elemental reactions + companion Union Skills chain together.

---

## Difficulty: Player Choice + the S-Rank Floor
| Setting | F → A content | S → SSS content |
|---|---|---|
| Story | Gentle | **Brutal** |
| Adventurer | Balanced | **Brutal** |
| Veteran | Hard | **Brutal+** |
| Hardcore (permadeath) | Hard | **Nightmare** |
- **"Brutal"** = full enemy AI aggression, unique mechanics, unblockable combos, and boss enrage timers. Easy-mode assists (auto-dodge, damage reduction) **switch off** in S+ zones and fights.
- The game tells you this ahead of time: an in-world Guild warning at A-rank. *"Beyond this point, the world will not go easy on you."*

## Respec
| Level | Stat/skill reset |
|---|---|
| 1–10 | **Free**, unlimited (learning phase) |
| 11+ | **Tome of Forgetting** (rare drop or craft) + gold scaling with level + a 1-day cooldown |
| 100+ | Also requires a **Shrine of Ilvaris trial** |

## Taming Roster
- **3 active monsters max** (always), plus a **Ranch** for stored monsters (capacity grows with home upgrades).
- **Trade-up loop:** tame a low-rank partner → evolve it, or release it, or retire it to the ranch → tame higher-ranked ones as you climb.
- **Taming rank cap:** you can tame monsters up to **your rank +0** (Tamer line: +1).
- **Bond and evolution:** partners gain Bond; at Bond 5 they can evolve; at Bond 10 with a Name-Giving Ribbon they become **Named** (a full companion with a personality).
- **Monster Collector Codex:** tame one of every species for titles and relics (*Crown of the Beast God* Apex Relic).

## Settlement Prosperity
Every town/village has persistent stats:
| Stat | Raised by | Lowered by |
|---|---|---|
| **Wealth** | Quest rewards spent locally, trade routes, your investments | Raids, taxes, neglect |
| **Safety** | Clearing nearby dens, defending in Stampedes, hiring guards | Ignored threats, monster dens growing |
| **Faith/Morale** | Festivals, healing plagues, shrines restored | Disasters, cult activity |
| **Population** | Safety + Wealth over time; rescued refugees | Deaths, fleeing |

**Visual state stages** (the 3D town actually changes):
| Stage | What you see |
|---|---|
| 0 · Ruined | Burned houses, no NPCs |
| 1 · Struggling | Broken fences, boarded windows, beggars |
| 2 · Stable | Default |
| 3 · Thriving | Repaired roofs, new market stalls, children playing, music |
| 4 · Prosperous | New buildings, stone walls, a bigger guild branch, a festival plaza |
| 5 · Renowned | A statue of **you**, a new district, unique shops and rare traders |

Higher stages unlock better shops, quests, residents and trainers. Neglected towns can fall back.

## Named Nemesis System
- A Named monster that **defeats you, or escapes you**, levels up, gains a scar/title, learns a counter to your favorite skill, and may **evolve** a rank.
- It **hunts you**: it shows up on the rumor board, ambushes you in its region, and sometimes follows you to other regions.
- **Resolve it any way:** kill it (relic-grade drop), tame it, or **name it** (Name-Giving Ribbon after earning its respect: win while sparing it, feed it, or save it from a bigger threat) → it becomes a **full companion** with its own voice, personality, arc and evolution.
- Named monster companions count toward the companion roster.

## Inventory Model
| Difficulty | Base inventory |
|---|---|
| Story | Unlimited bag |
| Adventurer | Weight-limited, generous |
| Veteran / Hardcore | Strict weight; encumbrance slows you and drains stamina |

**Expansions:** backpacks (Satchel → Explorer's Pack → Bag of Holding) · **Item Box** (skill, Unique Skill or relic: weightless storage) · **pack animals** (mule, carry-lizard, giant tortoise, Fluffcap ram) that carry a lot but **can be attacked and killed**, dropping their cargo as a lootable pile monsters may steal · a hireable **Porter NPC** (who can also die).

## UI Style Guide
> Full HUD and UI spec (layouts, notifications, Status Window tabs, appraisal tiers, dialogue, accessibility, controller layout, the Lying Interface stages): **`12_Systems/hud_and_ui.md`**.

- The classic anime **System window**: translucent blue-glass panels, thin glowing borders, angled corners, small ornate filigree at the corners, crisp sans-serif text with a fantasy display font for headers.
- Pop-ups appear in a burst of runes, with soft chimes (*"Skill acquired!"*).
- Rank colors are consistent everywhere (F grey → SSS gold).
- HUD is minimal in exploration and expands in combat.

## Loss Safety (protecting a 1,000-hour investment)
Several systems can take things away from the player. These rules keep any single mistake from costing 100+ hours:
| System | Default settings | Only on Hardcore / Mortal Bonds |
|---|---|---|
| Companion combat death | Gravely wounded, back in a few days | Permanent death |
| Pack animals & hired porters | Knocked out; cargo dropped in a lootable pile that stays for 3 in-game days | Can die |
| Respec | Always possible: free before Lv 10, then a Tome of Forgetting + gold; **one free respec token** at every class-tier change | Same |
| Class change | Costly (Rebirth Sigil + trial), but character level and learned skills are never lost | Same |
| Story deaths | Only through a clearly signposted choice | Same |
| Character death | Respawn at a waystone (gold can be recovered from your death spot) | Hardcore: permadeath |
