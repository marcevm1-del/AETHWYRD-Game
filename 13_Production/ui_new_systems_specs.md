# UI specs for the new systems (ux-designer, 2026-11-13)

Handover to **ui-engineer**. Covers the systems built in Core and data in Waves B to F that have no screen yet: gear fitting, home and farm, stables and eggs, dungeon rooms and puzzles, the Civilization Archive, the region graph and Labyrinth, living-world notices, and the companion preset and relationship pieces missing from `CompanionWindow`. Extends `12_Systems/hud_and_ui.md` (it wins on look; this file wins on these screens). Review inputs used: `reports/design_review_ui_screens_2026-11-08.md`, `reports/phase1_window_review.md`, `13_Production/style_consistency_checklist.md` section D.

**What I opened:** the system docs listed in section 0, `SystemWindow.cs` (row model: `Row` with Text, Act, Adjust, Alt, Bar, Chip, Detail, Invite, Note, Header), `WindowHub.cs`, `PlaytestShortcuts.cs`, the two reviews above. **What I did not open:** any new render or Unity run (not allowed in this job), so nothing here is checked against a screenshot. Every screen below is `NOT ASSESSED` on checklist lines D12 and D13 until ui-engineer builds it and a capture exists.

## 0. Systems covered and where their rules live
| Screen | Rules doc | Core entry points the screen reads |
|---|---|---|
| Fitting bench (rune anvil, enchanting table, forge assembly) | `12_Systems/gear_and_runes.md` | `GearFitter`, `GearAssembler`, `WouldReplace` |
| Home, storage chest, plots | `12_Systems/housing_and_farming.md` | `Home` |
| Stable, ranch, nest, sanctuary | `12_Systems/stables.md` | `Stables` |
| Dungeon HUD and puzzle panels | `12_Systems/dungeons_and_puzzles.md` | `DungeonRun`, `Puzzle`, `DungeonKnowledge` |
| Archive and artifact restoring | `12_Systems/civilization_archive.md` | `CivilizationArchive` |
| Travel graph and Labyrinth floors on the map | `12_Systems/world_graph.md`, `world_map.md` | `RegionGraph`, `Labyrinth` |
| Notices, schedules, discovery journal | `12_Systems/living_world.md` | `EventDirector`, `NpcScheduleResolver`, `DiscoveryJournal` |
| Companion presets, relationships, mounts | `12_Systems/companions_and_mounts.md`, `companion_field_ai.md` | `CompanionPresets`, `CompanionRelations`, `Mounts` |
| Quality, Well Fed, life ranks | `12_Systems/crafting.md` | `Crafter`, `LifeSkills`, `MealBuffs` |

## 1. Shared rules (every screen below)
1. **Chrome:** `SystemWindow` chrome as in checklist D1 (navy glass `#0E1A2E` 82 %, 6 px radius, 1 px cyan line, 14 px brackets, chevron header with letter-spaced caps). Diegetic pages (archive, ranch board, home plots, letters) use paper `#F3E6C8` and ink `#3A2A1C` (D8). Archive and ranch are **World UI**; fitting, dungeon HUD and travel are **System UI**.
2. **Anatomy:** header bar, a left list of one-line rows with chips, a right detail pane for the selected row only, a hint line at the bottom (D4, D6). One anchor per screen: the thing the player is changing, shown large.
3. **Type:** body 20 px at 1080p, labels and hint line 14 px minimum, secondary text `#B8C8E0` or lighter (D2, D3). Everything scales with the text-size setting; layouts must hold at scale 1.5 and at 1280x720.
4. **Gains cyan then white, losses coral `#FF7A6B`**, never telegraph red (D3). Preview deltas show before confirm: `ATK 12 -> 14 (+2)`.
5. **No-punishment copy rule (Canon):** nothing wears out, breaks, withers, starves or expires. Never show a timer in red, a "lost" chip, a missed-day count or a warning that something will be taken away. Waiting states read as "ready when you are".
6. **Refusals are named before the action**, not after: a disabled row carries a chip saying why ("Needs rank E Runecraft", "Wrong station", "No free socket"). Nothing spends anything on a refused action.
7. **Empty states** (D5): a sigil, one warm sentence, and what to do next. Written per screen below.
8. **Confirm only where something is replaced or sent away**, and then in plain words naming both sides. Everything else is undoable and has no confirm.
9. **Over-the-world HUD pieces** carry a 2 px outline or 40 % navy plate (D7) and never cover the player, the quest tracker or the compass.
10. **Audio and motion** follow `hud_and_ui.md` section 24: open chime, hover hum, confirm click, cancel tone; panels slide in 120 to 180 ms. No element flashes more than 3 times per second (D11).

## 2. Fitting bench (rune anvil, enchanting table, forge)
**Purpose:** socket and remove runes, apply and strip enchantment scrolls, and assemble modular weapons. One window, three tabs; the opening station decides which tab is first and which are enabled.

| Tab | Station | Anchor (large) |
|---|---|---|
| Runes | rune anvil | the chosen gear piece with its sockets as round slots |
| Enchant | enchanting table | the gear piece with its single enchantment plate |
| Assemble | forge | a blade slot, a hilt slot and the resulting weapon between them |

**Layout:** left, gear list (equipped first, then bag; one line: name, quality chip, socket pips `o o .`). Centre, the anchor. Right, the delta pane: before and after stats, set bonuses and the active **rune word** name when the order matches (Forge-Oath, Stonewatch, Stormfast, Hearthfire). Bottom, the rune or scroll shelf as chips.

**Behaviour**
- Socket order matters; show the slots left to right and a faint outline of any near-match word ("Forge-Oath needs Ember then Anvil"). Only the longest matching word glows.
- Removing a rune is free and returns it with its quality intact: the hint line says so ("It comes back to your bag").
- **Replace confirm (the only one):** applying a scroll over an enchantment shows `Replaces Emberbrand` using `WouldReplace`, with the old name first. Default focus is Cancel.
- Sockets by rarity are shown as slots from the start, including locked-looking empty ones; a Divine item shows a calm "Story-bound: takes no fittings" line, not an error.
- Element from an enchantment shows as the element icon on the gear name, plus text (never colour alone).
- Quality chips use the five tier names; Fine and above show the Crafter's Mark; Masterwork may show its given name.
- **No durability, no repair, no failure line anywhere.**

**States**
| State | Shows |
|---|---|
| No fittable gear | Anvil sigil: "Nothing here has a socket yet. Rare gear and Masterwork pieces do." |
| No runes in bag | Shelf shows a recipe hint chip: "Made at this anvil from Rune Plate" with a link to the Crafting window |
| Refused | Row disabled with a chip (rank, station, wrong slot type) |
| Applied | Chime, the plate glows cyan once; delta pane updates; no toast |

**Controls:** pad: D-pad moves, A selects, B back, LB/RB switch tab, X removes the selected rune or scroll (hold to confirm only for scroll strip), Y toggles compare. Keyboard: arrows or WASD, Enter, Esc, Q/E tabs, Backspace removes.

## 3. Crafting additions (quality, life ranks, Well Fed)
Builds on the open P3 fixes in `reports/phase1_window_review.md` (one line per recipe, chips on the right).
- **Result preview** shows the predicted quality tier as a chip plus the three inputs to it in plain words: ingredient tier, your rank, station cap. Words, not the formula. Example: `Likely Fine. Capped by campfire: Normal.`
- **Attune** is an optional toggle row: "Add 1 Fire Salt for a better result. It can't fail." Show the extra unit's owned count.
- **Skip route** ("Quick make: Normal quality") is a visible secondary button, not buried.
- **Life skill panel** (tab inside Crafting): ranks F to SSS as a row of stamps; XP bar to the next rank; from D up a chip "Masterwork commission needed" when XP is full, with the line "Your XP waits, nothing is lost".
- **Well Fed:** a single buff chip on the HUD under the bars (icon, remaining time as a thin ring, not digits, in Standard; digits in Full Data). A new meal shows `Replaces Garden Stew`. It ends silently: no expiry toast.
- First craft of a recipe shows a small "First time" stamp (x3 XP once).

## 4. Home, storage and plots
**Entry:** the bed, chest, planter and garden are world objects with the rune-circle prompt (hud_and_ui §22). Three views, each a small paper-style panel:

**Storage chest.** Two columns: bag (left) and chest (right), one line per stack with quality chip and count. Header meter `Stacks 14 / 60` (stacks, not weight). Move with A (one), hold A (all), X (half). Full: the right header chip reads "Full: add to an existing stack or upgrade the home"; existing stacks always accept more, so say that. Empty chest: a drawer sigil and "Anything you set down here stays put."

**Plots.** A top-down card per plot (1 to 6): empty, growing, ready. Growing shows the crop icon and a **ring that fills**, plus "Ready in about 18 h" in game hours; no countdown colour change. Ready shows "Ready whenever you are" and a gentle sparkle. Harvest shows yield, seed returned and Farming XP as one line. Pulling a growing crop is allowed and says "Seed comes back". There is no watering, withering or "overdue" language.

**Home tiers.** The upgrade card lists the next tier: rank, price, what it adds (storage, plots, features), in one-line chips. Locked reasons are plain ("Guild rank C needed"). Tiers only add; never show anything lost.

**Controls:** same as the shared pattern; plots navigate as a grid with the D-pad.

## 5. Stables, ranch, eggs and sanctuary
**Place:** the ranch board and stalls at the home barn; the guild kennel desk in town. World UI (paper and wood).

**Roster view.** Three bands, always in this order: **Travelling (3 slots)**, **Home stable (n / cap)**, **Guild kennel**. Cards show portrait, name, family icon, Bond hearts and a marking badge if any. Moving a partner is a drag or A-then-A. **A full stable never refuses anything:** the surplus card slides to the kennel with the line "Waiting at the guild kennel. Nobody is sent away." Before the barn exists, the stable band reads "A barn comes with the Home and Garden" and the kennel is the only band.

**Detail pane:** Bond, favourite food (once learned), "Fed today" tick (a gentle optional action: feed with a treat; show "Shared a moment" on success). If already fed or max Bond, the button says "Not needed right now" and nothing is spent. Mount chip when the species is in a mount family and your rank qualifies: "Make mount" / "Release as mount".

**Breeding and eggs.** A pairing step: pick two boarded partners; the pane lists the checks as ticks (same family tree, Bond 3+, a free egg place, not unique). Failing a check is a plain line, not an error dialog. After pairing: "Resting together: about 3 days", then "Egg ready: it will wait for you." Egg cards show marking chances in words ("sometimes inherits Albino"), never percentages in Standard. Cross-element result is a small reveal on hatching. The guaranteed-after-4 rule is never shown (no pity meters in the UI).

**Nest eggs from dens:** appear as egg cards in the nest row; if the nest is full the egg stays put with "Waiting in the den nest".

**Sanctuary:** a four-stage painted card (Paddock, Meadow Run, Grove Sanctuary, Living Sanctuary) with "Species cared for: 9". The next stage's threshold is shown as a hint, not a goal bar. Marking collection is a page of silhouettes filling in.

**States:** no partners yet: a lead rope sigil and "Tamed partners will rest here when they aren't travelling." No eggs: "No eggs yet."

**Controls:** D-pad moves between cards, A pick up/place, X feed, Y detail, LB/RB switch band tab, B back.

## 6. Dungeon HUD and puzzle panels
### 6.1 HUD (System UI, only while inside a dungeon)
- **Room tag** under the compass: dungeon name, floor (`Floor 2 of 2`), room name on entry (fades after 3 s).
- **Checkpoint pip** shows when you stand in a checkpoint room ("Checkpoint: if you fall you return here with your keys").
- **Keys held** as small key icons by the quest tracker; keys never get used up, so there is no "used" state.
- **Clue found** toast: "Clue noted: a cold draught near the lower landing". Heard-only clues are not toasted.
- **Dungeon map** (opened with the map button inside the dungeon): rooms as nodes by floor, edges styled by type (passage, stairs, door with key icon, secret dotted, one-way arrow). Status uses the project vocabulary: **Unknown** blank, **Heard** pencilled, **Visited** inked. Hidden ways are not drawn until their clue is found in place. The map never shows boss spoilers beyond the species chosen to be named.
- **Soft-lock safety line:** if the player is on a one-way route (chute), the map pins a quiet "This way drops you back to the entrance."

### 6.2 Puzzle panels (one shared shell)
The shell has: title, one-sentence goal, the puzzle surface, a **Hint** button, an **Assist** button, a **Skip** button, a "Leave it for later" back action. All four are always available once relevant; none costs anything and none locks the door permanently (Skip can be undone by solving later).

| Puzzle | Surface | Notes |
|---|---|---|
| Lever sequence | Row of levers over chalk marks | A wrong pull plays a soft thud and re-chalks the tally; no red flash |
| Weight plates | Stones in a tray, plates with target weights as numerals and pips | An overloaded plate gently pops its stone back; show the number, not colour only |
| Resonance Lock (rune match) | Ring of sconces cycling ember, tide, gale, stone; linked sconces connect with a thin thread | Each glyph has a distinct **shape plus colour** (colourblind-safe); the target glyphs are shown in an inset |

- **Hint** reveals the next hint line (the last repeats). **Assist** names the next correct move once unlocked by tries or after all hints; before that it is greyed with "Try a few more times, or read the hints". **Skip** says "Skip this puzzle? You can come back." and is never framed as failure.
- Optional reward is shown only after solving, once, as an item card.
- No timers, no randomness, no score.

## 7. Civilization Archive and artifacts (World UI)
**Entry:** a book at the museum/archive desk and a tab inside the Collections Book (`hud_and_ui.md` §29). Spoiler rule: the screen shows only the entry text in the data (public account). No unlock hint ever points at a hidden entry's content.

**Layout:** left, five civilization tabs as bookmarks (Dragons and the First Folk, Titans, Dwarves of Karak Dun, Sylvaran Court, Valdrisia). Page: entries as paper cards with status ink: **Unknown** shows a smudge and no title, **Heard** a pencilled title and "Rumoured", **Visited** inked full text. Count per civilization `4 of 5`.

**Fragments and artifacts.** A satchel strip lists fragments held. An artifact card shows its silhouette with fragment slots (2 or 3). When all are held the button reads "Restore" and the page says plainly what is spent (the fragments) and what is given (the entry, the artifact, pencilled hints). Refusal before spending names the missing fragment and where such things are found ("a ruin in Sunscar"). Excavate prompts use the world rune-circle prompt, one fragment per site, once.

**Empty state:** "Nothing recorded yet. Old stones and ruins are worth a look." No percentage nag; the book shows completion quietly on the page.

**Never shown:** rewards of money, XP or items (there are none); any connection to a quest or ending.

## 8. Map additions: travel graph and Labyrinth
Extends `12_Systems/world_map.md`; keep its parchment style.
- **Route planner (optional):** pick a destination region; the map draws the shortest walkable route with distance in km and an "includes a sailed leg" chip when `IncludeSea` is on. Toggle: Roads only. No travel time is promised until `systems.md` §11.3 decides it (say "about N km").
- **Edge styles:** road (solid), pass (solid with a notch and height in metres), sea (dashed, with a ship mark), border (faint). Four border edges under 1 km are drawn faint and not offered as walkable.
- **Story-reached regions** (Sky Archipelago) appear as a cloud-stamp "Reached by story" and are never labelled "unreachable" or an error.
- **Labyrinth floors:** a vertical strip tab of floors 1 to 100 in bands, with safe-floor inns as lantern marks (floor 30 Deep Pint, floor 40 Lantern Wake) and each floor's status Unknown/Heard/Visited. The recommended rank per band is shown as the band's hardest guide, with the line "Rank shown is the hardest floor in the band".
- **Underworld layers** show as five stacked pages, depth 1 to 5.
- No waystone fast travel UI yet (no authored places; Canon §6 WF11): the entry stays hidden, not shown as locked.

## 9. Living world: notices, schedules and the discovery journal
- **Event notices** are small paper slips on the guild board or a rumour line, never a System alarm: caravans (what they sell today and until when, in days) and wanderers (a one-line rumour). Expiry just removes the slip; no "missed" state.
- **Shop shelf extras** carry a small "Caravan stock" ribbon until the caravan leaves.
- **NPC availability:** a sleeping NPC shows an emote bubble ("Zzz") and their door chip says "Resting. Back in the morning." Essential NPCs are never shown as unavailable. If schedules are turned off in options, no bubbles. Shops stay usable.
- **Discovery Journal** page in the Journal window: four categories (regions, landmarks, creatures, secrets), each entry Unknown (smudge), Heard (pencil), Visited (ink). Counts per category; a category with nothing shows "Nothing noted yet."

## 10. Companions: gaps in `CompanionWindow`
- **Preset row** (Balanced, Aggressive, Defensive, Supportive) at the top of each companion's page as four chips with one plain line ("Leans toward focusing your target"). The existing note stays: "The stance is a request: companions still retreat when badly hurt."
- **Relationship tracks:** four small bars per companion labelled **Trust, Respect, Closeness, Tension** (words, not icons only). Tension is not styled as bad red; it uses a neutral amber chip and the line "Strong feelings need talking through". No single loyalty/approval number anywhere.
- **Romance** page appears only when all gates hold (romanceable, adult, opt-in); it is a separate pressed-flower page and never shown for Nyx or Mochi.
- **Downed state:** "Gravely wounded, recovering" with a soft ring; never "dead". Mortal Bonds off or on is shown in the setup text, not mid-combat.
- **Departure foreshadow** appears as a talk request chip ("Wants to talk") with the repair option named; a departed companion appears in a "Away" list with the way back.
- **Empty states:** no companions recruited: the campfire sigil and "Companions will gather here as you meet them" (fixes the 70 % empty panel from the phase 1 review).
- **Mount chip** on a tamed partner as in section 5; mounted HUD shows stamina ring under the speed; exhausted shows "Walking until rested" (not "exhausted" in red).

## 11. HUD additions (Standard preset)
| Element | Where | When |
|---|---|---|
| Well Fed chip | under bars | while the buff is active |
| Dungeon room tag and key icons | top centre under the compass, tracker side | in a dungeon |
| Checkpoint pip | near room tag | in a checkpoint room |
| Mount stamina ring | around crosshair, reusing the sprint ring | while mounted |
| Companion preset glyph | on each companion strip card | always (Standard); text label in Full Data |
| Caravan or event ribbon | notification feed only | calm moments; suppressed in combat |

All of these respect the existing preset toggles and the HUD editor; Immersive hides them all except the room tag.

## 12. Accessibility notes for the new screens (full review is job 3)
- Every state conveyed by colour also has a shape, word or icon: puzzle glyphs, status chips (Unknown/Heard/Visited use smudge, pencil, ink and also the word), element on gear, marking badges.
- No timers that demand speed; none of the new screens has a real-time pressure state.
- All screens navigable by pad alone and by keyboard alone; focus order is left list, then centre, then right pane, then hint line.
- Reduced-flash mode swaps sparkles, glows and rune bursts for a single steady highlight.
- Menu narration reads the focused row, its chip and the detail pane in that order.
- Text scale from 0.8 to 1.5 must not clip any chip; chips wrap under the row name rather than truncate.

## 13. Build order for ui-engineer
1. Crafting additions (section 3): closes open items from the phase 1 review.
2. Fitting bench (section 2).
3. Companion gaps (section 10): includes the empty-state fix.
4. Home, storage and plots (section 4), then stables (section 5).
5. Dungeon HUD, map and puzzle shell (section 6).
6. Archive and map additions (sections 7 and 8), living-world notices (section 9).
Each screen needs, before it is called done: one capture per state at 1600x900 and 1280x720 (D12), a pad-only run, and the checklist section D marked line by line with `NOT ASSESSED` where no capture exists.

## 14. Decisions and open points
Decided (overrule me if you disagree):
- No pity or hidden-chance meters are ever shown (egg guarantees stay invisible).
- Percentages are not shown for marking chances in Standard.
- A full stable moves partners to the kennel with an explicit "nobody is sent away" line.
- Archive entries show public wording only; no hints toward hidden content.
Open, for the owners named:
- Window keys and button glyph assignments: settled in job 2 (the F-keys in `PlaytestShortcuts` are playtest only).
- Fitting bench art and rune icons: technical-artist and art-director.
- Wording polish of every quoted line: narrative-writer.
- Travel time text: waits for the `systems.md` §11.3 decision.
