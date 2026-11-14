# Consistency check: new system docs vs Canon (canon-keeper, 2026-11-08)

Docs checked (12_Systems): living_world, party_synergy, stables, world_graph, world_map, audio_and_immersion, civilization_archive, companion_field_ai, companions_and_mounts, dungeons_and_puzzles, gear_and_runes, housing_and_farming. Method: read Canon sections 1 to 5 and grep each doc for Canon-sensitive terms (Big Secrets, flying mounts, enemy hierarchy, real-time timers, decay/durability, romance exclusions, voice acting, day/week/level numbers, housing tiers). Read-only; no doc edited.

## Result: no contradiction with a locked Canon row

| Canon rule | Doc check | Result |
|---|---|---|
| Section 1 Voice (System voice plus a few voiced moments) | audio_and_immersion lines 87 and 101 restate it | Matches |
| Section 1 Music (rock for bosses) | audio doc: boss-only rock stem (a section 6 decision) | Matches |
| Section 3 Big Secrets | civilization_archive shows public accounts only; its validator and a test scan for Vesper, Ezrath, Hooded Traveler, Caspian, Malchior | Matches. See watch note 1 |
| Section 4 romanceable cast, Nyx and Mochi excluded | companions_and_mounts: 12 + Tobin and Elsie = 14 (14 rows in `companions.json`), romance flags "all except Nyx and Mochi" | Matches |
| Section 4 no flying mounts | companions_and_mounts: ground families only, nobody rideable | Matches |
| Section 4 dungeons stay reusable | dungeons_and_puzzles: weekly reset, reusable | Matches |
| Section 4d no enemy hierarchy | dungeons_and_puzzles line 12: no captains or promotions | Matches |
| Section 5 loss rules, Mortal Bonds opt-in | companions_and_mounts line 29: downed companions only die with Mortal Bonds on | Matches |
| Section 2 day/week numbers | living_world runs only on in-game days; no real-time pressure found | Matches |
| Section 2 rank letters, currency in copper | housing prices in copper (800c, 6,000c, 40,000c) | Matches |

## Findings (none blocking, none changes a locked row)
1. **Housing tier names drift from `systems.md` section 6.** housing_and_farming has Inn Room F, Rented Room C, Home and Garden B, Manor A. systems.md section 6 names "Rented room in the guild house" (C), "Home + land" (B) and "Manor / Shop" (A, staff and shop front). The housing doc says the staff and shop front are not built in this wave, which is stated honestly. Not a Canon conflict; systems.md still lists the shop and staff as features. Suggest a one-line pointer in systems.md section 6.
2. **Housing prices are not in Canon**; they appear only in section 6 row H1 (decided 2026-11-08 by Claude). They are decisions awaiting user ratification, not locks.
3. **Gear has no durability** (gear_and_runes line 6). Canon is silent; the section 6 row "Default gear condition" (still open) proposes the same. The doc and the open proposal agree.
4. **Companion cast naming:** Canon section 4 writes "Sir Aldric"; the doc writes "Aldric". Cosmetic.
5. **Housing doc says the player cannot own a guild (Canon)**: correct per Canon section 4.

## Watch notes
1. civilization_archive lists "Valdrisia, the Old Magic Empire" and an entry "Roads That End at a Cliff". Canon section 3 secret: Vesper is Valdrisia. Valdrisia as a past empire is public history already; the entry must never say where it went. The existing scan does not search for the word "Valdrisia" by design. Keep wording about roads ending at cliffs from hinting at a sky city.
2. Section 6 still says "Proposed Locks (need the user's OK)" although 46 rows were decided by Claude. The user should ratify or overrule the delegated batch.

Not checked: Data/ numbers inside these docs beyond housing prices and the companion count (the validator and tests cover those); Unity-side behaviour.
