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
- **Romance:** optional, available with most adult companions, no gender locks, no gameplay gating. A marriage ceremony is possible at your home.
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
