# Canon watch list for later waves (canon-keeper, 2026-11-08)

Rows a later wave is most likely to bump into. Rule for all: never edit a locked row; propose in Canon section 6 and log in CHANGELOG.

| Canon row | Who may touch it | Risk | Safe move |
|---|---|---|---|
| 1 Voice (delegated edit 2026-11-07) | audio, narrative, ui | A wave adds full VO, lip-sync or a narrator | Check against "System voice plus a few key moments"; ask the user before any VO pipeline |
| 1 Music (rock only for bosses) | audio | Rock/J-pop in ordinary fights | Keep the single boss-only rock stem |
| 1 Art (Genshin-style cel shading), Content rules | art, creature, anime director | Fanservice, gore, realism drift | Anime director review before locking looks |
| 2 Ranks, Level cap 300, bands | combat, items, bestiary | New rank letters, band shifts, EX on non-monsters | Data/ stays canonical; tests must keep band edges |
| 2 Currency (100x ladder, copper storage) | items, economy | Prices stored in other units, new coin | Store copper only |
| 2 In-game day 90 min, 7-day week, weekday names | living world, quests, crafting | Real-time timers, 5- or 8-day cycles | In-game days only; no real-time deadlines |
| 2 Classes 12/24/48 | class wave | New base class, changed counts | Propose, do not add |
| 2 World (40+5+Labyrinth 120 floors, 49 rows) | world graph, dungeon, map | New regions, floor count change, depth renumbering | `regions.json` is the list; changes need a proposal |
| 2 Monsters (287 / 640 / 680 / 6,754, 25 rigs) | bestiary, animation | Species or rig count drift when adding monsters | Re-run the species-count tests; update Canon only with user OK |
| 2 NPCs (~2,500; 150/600/1,750) | narrative, world builder | Counts drift | Keep tier counts |
| 3 Big Secrets (12 rows) | narrative, quests, archive, dungeon puzzles, NPC dialogue | A spoiler leaks into player-facing text or data (Valdrisia/Vesper, Whiskers/Vex, Caspian, Mina) | Lore-guard scan on every new player-facing text; Act gating |
| 4 Romanceable list, Nyx/Mochi/Whiskers/Azrael/Celestine excluded | companions wave | Adding a romance flag to an excluded name; a 13th human companion | 12 + 2 cap holds; use the lighter tier for monsters |
| 4 Player cannot (no flying mounts, no guild, no king) | mounts, housing | Flight mounts, guild ownership, staff-run organisations | Ground mounts only; housing stays personal |
| 4 Dungeon cores never allies; dungeons reusable | dungeon wave | One-shot dungeons, allied cores | Weekly reset, reusable |
| 4 Narrator none, fourth wall | narrative, cutscenes | Narrator lines, player-addressing text | Only the two named endings address the player |
| 4b Siege rules (1-2 per week, never back-to-back, never destroyed) | AI, world | Destruction states, extra sieges | Auto-resolve missed defences |
| 4d Named monsters (locked 2026-10-23, patent reason) | AI, bestiary, combat | Promotions, captains, personal scars or taunts, memory of killing the player | Region-state growth only; IP lawyer review before release |
| 5 Loss rules (Mortal Bonds opt-in, respec, level never lost) | companions, combat, crafting | Permadeath default, level loss, forced repair | Opt-in only; no durability loss (see Default gear condition) |
| Section 6 open rows (48, notably Companion roster, Big Upgrade, Default gear condition, Monster-core price curve, Offline-first economy) | all waves | Waves build on rows the user never approved | Treat as proposals; ask the user to ratify in one pass |
| Section 6 delegated rows (46) | any wave | User overrules later and code already depends on it | Keep the code driven by `Data/`, so an overrule is a data change |
| Package ids, `Ascend.*` namespaces, `ProjectAscend.exe`, save path | save, build | Renaming for branding breaks saves | Save-path migration first (see migration report) |

Standing checks per wave: run `npm run build` (tests must not drop, warnings must not rise), grep new player-facing text for section 3 names, and diff `Canon.md` for any locked-row edit before merge.
