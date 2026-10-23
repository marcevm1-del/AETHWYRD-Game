# 01d — Market Research 2026: Similar Games, Lessons and New Additions (DRAFT v0.1)

> **Draft for the user's OK** (2026-10-23). This picks up where `borrowed_features.md` (30 items) and `the_big_upgrade.md` (52 items) stop. Games and ideas already mined there are **not repeated**, including Dragon's Dogma 2, Monster Hunter, Genshin, Xenoblade, Tales, Fire Emblem, Persona, Zelda, Stardew, Palworld, Rune Factory, Atelier, Octopath, Elden Ring, Ghost of Tsushima, Wuthering Waves and Echoes of Aincrad. Ascend already has sailing, life-skill ranks, telegraph colours and bounties. Every item below is a **proposal** ⚙.

---

## 0. ⚠️ Legal risk first: the Nemesis patent
Warner Bros.' patent on *"Nemesis characters, nemesis forts, social vendettas and followers in computer games"* (Shadow of Mordor) took effect in **February 2021** and is reported to run until **August 2036**, past any Ascend release. Monolith closed in 2025, but the patent stays with Warner Bros.

Our former **Named Nemesis System** (`12_Systems/systems.md`) had the features most associated with it: a Named monster that defeats or escapes you levels up, gains a scar or title, learns counters and hunts you across regions, and the Tyrants learn too (Big Upgrade §7).

**Recommended design-around** (not legal advice; have an IP lawyer review before release):
1. **The Named roster is hand-authored** (the named monsters in `bestiary_lore.md`, each written by us), never procedurally generated.
2. **No enemy hierarchy:** no promotions, power struggles, captains or warchiefs, and no forts that change hands between named enemies.
3. **Growth runs on world state, not on killing you:** named monsters grow with ecology cycles, siege escalation and story flags. Dying to one gives no personal scar or taunt; instead the **rumor board** reports what it has been doing.
4. **Tyrants adapt to tactics as a region-level siege rule** (shield bearers after fire defences). This is AI tuning, not a remembered personal vendetta.
5. **Name-Giving stays:** befriending and naming a monster is taming, which Ascend has plenty of other precedent for.
→ **Approved 2026-10-23** and applied: Canon §4d, `systems.md` → Named Monsters, Big Upgrade §7 (Tyrants Adapt), `hud_and_ui.md`.

---

## 1. What we researched and what it teaches
| Game (year) | What critics praised | What they criticised | Lesson for Ascend |
|---|---|---|---|
| **Metaphor: ReFantazio** (2024) | Archetypes (job classes) with skill inheritance between them; bonds that *always* advance; some Archetypes unlocked by bonds | Grinding job points; little room to experiment before the endgame; dull optional dungeons | Let class experimentation be cheap and early; no visit with a companion should be wasted |
| **Clair Obscur: Expedition 33** (2025) | Dodge and parry cost nothing, so defending never competes with attacking; parry strings against multi-hit bosses; warnings that show attack type *and* speed | Timing windows too tight for some; parry can dwarf build choices; camera hurts depth reading | Free defense, speed cues, an adjustable window, and builds that can win without parrying |
| **Unicorn Overlord** (2024) | Liberating towns shrinks the enemy's map; restored towns with a stationed guard produce materials and gold after battles | Repeated battles; setting up tactics is slow | Liberation should *pay* and be *visible* |
| **Dragon Quest Builders 2** (2019) | Island rebuilding; neighbours you've helped later divide up bigger projects themselves | Chores can feel repetitive | The town starts helping you back |
| **Ys X: Nordics** (2023/25) | Sea navigation; recruiting people to a base and watching it grow | — | Rescued people become your crew |
| **Baldur's Gate 3** (2023) | Reactivity: dialogue references choices back to character creation; the designers acted as "weird Dungeon Masters" | Enormous tracking cost (a spreadsheet of every ending path) | Budget callbacks deliberately: a few per quest, tracked in story flags |
| **Kingdom Come: Deliverance II** (2025) | Thousands of NPCs keep their own routines; NPCs have memory; goal-based AI | — | Systemic life with time-slicing beats hand-scripting 2,500 NPCs |
| **Avowed** (2025) | Dense, handcrafted regions; vertical secrets; caves as self-contained side adventures | Lifeless towns: no reaction to theft, most homes locked; filler quests | Towns must react, and side spaces need stories |
| **Crimson Desert** (Mar 2026) | A world that feels alive; combat | Weak side quests that ignore the game's strengths; clunky inventory and healing | A quality bar for side quests |
| **Fantasy Life i** (2025) | Cosy and action loops balanced; a dozen job "Lives"; town building | Quantity over depth | Depth per life skill over number of life skills |
| **Tensura: ISEKAI Chronicles** (2025) | Combat compared to the Tales series; bonds unlock special attacks | Truncated story; paid character DLC | Isekai players want the full journey, never cut short, and Canon already forbids paid extras |
| **Open-world fatigue** (GDC 2025 talk) | — | "How far is the next objective? Do I have to cross the whole map?" | Pace travel distance; no tower-and-icon checklists |

---

## 2. New additions (16)

### Classes and growth
**A1. Class Echo (anti-grind)** *(Metaphor)*: XP earned in a mastered class flows at 50% into the class you choose next ⚙. Any skill learned in a base class can be slotted in a later class of the **same role** for its cost. Experimenting stops costing hours.

**A2. Bond Keys** *(Metaphor)*: each Advanced class has **two ways in**: the existing Rank + Level + Quest + Mastery route, or a **bond route** through its trainer or a matching companion at bond rank 5 (for example Lyra opens Blademaster, Kiri opens Beastwarden). Bonds become a second path to power.

**A3. Every hangout pays** *(Metaphor)*: a hangout or tea time always advances the bond (no wasted visits), and its activity choice changes *how much* and *which* bonus you get.

### Combat
**A4. Free defense** *(Clair Obscur)*: a **perfect dodge refunds its stamina**, and a parry costs nothing. Defending well should never use up the means to attack.

**A5. Speed cues** *(Clair Obscur)*: the telegraph **colour** says the type (existing), and a shrinking **windup ring** plus a sound tick says **when**. Delayed attacks get a visibly slower ring, so feints are readable, not cheap.

**A6. Parry Practice and an assist slider**: the guild training yard replays any boss string you have seen (the Lantern Echo idea from borrowed #15, turned toward training). A parry-window slider in Accessibility goes up to ×2 and never locks achievements.

**A7. No mandatory parry**: design rule: every boss is beatable by a dodge-only build and a guard-only build (Guardian, Bulwark). Parrying is the stylish way to win, never the only one.

### World and regions
**A8. Liberation Dividends** *(Unicorn Overlord)*: a liberated settlement offers a **Waypost** where you station a hired adventurer, a monster worker or a companion. It gathers regional materials and earns coin each in-game week, collected at the inn. A stationed companion gains bond.

**A9. The Siege Map** *(Unicorn Overlord)*: the world map paints Besieged regions in the Tyrant's colour and Liberated ones in yours, and the Adventurer Times prints the shrinking front each week.

**A10. The town helps back** *(DQ Builders 2)*: when a settlement's prosperity and your Regular status are high, villagers volunteer for restoration bundles (Stardew, borrowed #16) and finish a share themselves, which also gives each villager a line about it.

**A11. Rescued crew** *(Ys X)*: NPCs you rescue in sieges and quests can join your **ship's crew** (sailing already exists) as cook, lookout, carpenter or navigator. Each crew role unlocks a ship upgrade and a sea event, so siege rescues pay off at sea.

**A12. Density and verticality rules** *(Avowed; open-world fatigue)*: a point of interest within **~45 seconds of running** (about 300 m at run speed 6.5 m/s) · at least three climb-only secrets per region · every cave or ruin is a small story with a beginning and an end · no reveal-the-map towers (the existing rumor board and Guiding Wisp do discovery).

### Towns and NPCs
**A13. Living towns** *(KCD2, Avowed)*: homes open on their owners' schedules · theft and trespass are judged by **witnesses**, and each witness remembers for a few in-game days (bounties from Big Upgrade §30 build on this) · off-screen NPCs advance their routines by time-slicing, so a baker you leave at dawn has bread out when you return at noon.

**A14. Callback budget** *(BG3)*: every main quest references **two** earlier choices or your Origin; every side quest references **one** (an Old-World Job line, a companion's opinion, a siege you won or lost). They are tracked as story flags, so the cost stays planned.

### Quests
**A15. Side-quest quality bar** *(Crimson Desert)*: a side quest needs at least one of: a real choice, a twist, a system it uses (siege, cuisine, appraisal, taming, the Lying Interface) or a callback. Repeatable board quests are exempt but keep their weekday flavour.

### The isekai fantasy
**A16. Frontier Patron** *(the kingdom-building isekai fantasy, within Canon)*: you can't be king or own a guild, but you can **sponsor a ruined hamlet**: fund its buildings, invite settlers you've met, and watch it grow while its people choose their own headman. ⚠️ Close to the Canon §4 limit, so it needs your explicit OK.

---

## 3. Lessons to keep (avoid what reviewers punished)
- **Grind:** Class Echo and bond routes (A1, A2).
- **Tight timing windows:** assist slider, speed cues, no mandatory parry (A5–A7).
- **Lifeless towns:** witnesses, open homes, routines (A13).
- **Filler quests:** the quality bar (A15).
- **Travel fatigue:** density rules and the rumor-board discovery we already have (A12).
- **Cut-short story and paid extras:** already ruled out by Canon (premium, no paid extras).

## Sources
- Metaphor: ReFantazio: [TechRadar](https://www.techradar.com/gaming/metaphor-refantazio-review) · [FullCleared](https://fullcleared.com/reviews/metaphor-refantazio-review/) · [Prima Games](https://primagames.com/news/metaphor-refantazio-places-big-twists-on-social-links-and-romance)
- Clair Obscur: Expedition 33: [Destructoid](https://vip-develop.destructoid.com/?p=1058393) · [PSU](https://www.psu.com/news/why-more-playstation-gamers-should-play-clair-obscur-expedition-33/) · [Steam discussion](https://steamcommunity.com/app/1903340/discussions/0/592895445665149150)
- Unicorn Overlord: [GameSpot](https://GameSpot.com/reviews/unicorn-overlord-review-a-rare-beast/1900-6418196/) · [RPGamer](https://rpgamer.com/review/unicorn-overlord-review/)
- Dragon Quest Builders 2: [RPGamer](https://rpgamer.com/game/dragon-quest-builders-2/) · Ys X: [OpenCritic](https://opencritic.com/game/15589/ys-x-nordics)
- Baldur's Gate 3 reactivity: [Yahoo / PC Gamer](https://malaysia.news.yahoo.com/larian-gave-baldurs-gate-3-022539159.html) · KCD2: [GDC Vault](https://gdcvault.com/play/1035576/Game-AI-Summit-Combining-GOAP) · [GameDev.net](https://gamedev.net/news/5526-supporting-thousands-of-npcs-in-kingdom-come-deliverance-kingdom-come/)
- Avowed: [Game Informer](https://www.gameinformer.com/review/avowed/high-fun-per-square-foot) · [RPG Site](https://rpgsite.net/review/16861-avowed-review)
- Crimson Desert: [GameSpot](https://www.gamespot.com/reviews/crimson-desert-review-highest-fantasy/1900-6418474/) · [Wikipedia](https://en.wikipedia.org/wiki/Crimson_Desert)
- Fantasy Life i: [Wikipedia](https://en.wikipedia.org/wiki/Fantasy_Life_i:_The_Girl_Who_Steals_Time) · [GamesHub](https://www.gameshub.com/news/reviews/fantasy-life-i-girl-who-steals-time-review-2728992/)
- Tensura ISEKAI Chronicles: [Siliconera](https://www.siliconera.com/review-that-time-i-got-reincarnated-as-a-slime-isekai-chronicles-feels-like-tales/)
- Open-world fatigue: [PC Gamer, GDC 2025](https://pcgamer.com/uk/tag/gdc-2025/page/5)
- Nemesis patent: [TechRadar](https://www.techradar.com/gaming/shadow-of-mordors-nemesis-system-will-remain-warner-bros-property-until-2036) · [TheSixthAxis](https://www.thesixthaxis.com/2021/02/08/shadow-of-war-nemesis-system-patent/)
