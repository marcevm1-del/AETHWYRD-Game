# Library books audit (the 500 draft books)

Date: 2026-11-13. Author: library-shelf session. Scope: the 500 draft chapbooks in `E:\Ideas\books` (outside the repo, never edited), their fit with Canon and `Data/`, and their shelving in the repo. Machine-readable result for every book: `13_Production/library_scan_report.json`. Pipeline: `Tools/library/shelve.py`. System doc: `12_Systems/libraries_and_books.md`.

## 1. Verdict in plain words

The books are **scaffolding, not finished lore**. They are a template script's output (`generate_library.py`, a seeded random generator that fills fixed sentence frames with place names from `regions.json`, species from `species.json` and a bank of stock lines). Facts that come straight from the data are right (ranks, week names, region and settlement names, species rank, element and weakness, road names). The prose is competent and in one consistent, warm, slightly wry voice, but it is **heavily repeated**: measured over all 38,119 sentences, 92% of them appear in three or more books, 74% in ten or more, and 53% in thirty or more. A player who reads three books of one shelf will see the same paragraphs again. Roughly 48 books (letter books, the romance serial, a dozen myth tellings, two lectures) are genuinely varied and good; about 175 are average; about 300 are frames filled with a place name.

They carry almost no game content: nothing in them is a recipe, a price, a route time or a hint that the game could check. They give atmosphere, and in 41 cases they gave **wrong** field data (see 3.1). My recommendation: ship them as optional, clearly-draft atmosphere shelves now (that is what the catalogue does), mark the templated ones for a human rewrite in priority order (section 6), and never let a quest or rank depend on them.

## 2. How the generator works (and what that means)

- Each of the 20 shelves is a function (`cookbook`, `field_guide`, `road_book`, `essay_chapters`, `letters_book`, `play_book`, `memoir`, `romance_book` and so on) that picks sentences from short banks with `random.Random("aethwyrd-<genre>-<n>-shelf")`. Output is deterministic.
- The region of a book is `regions[(serial*3+number) % len(regions)]`, i.e. spread round-robin, not chosen for fit. This is why Whisperwood (the opening region) had 4 books and the Quaking Lands 22.
- Place names come from `regions.json` (`defenceSettlements`, `map.places`); road names from a hard-coded table equal to the Canon section 6 W1 decisions; weekdays and gods from fixed lists that match Canon. Authors are `given name + family name of <region>`, 487 distinct strings; titles are 267 distinct strings (45 books are all "Neighbors Near <place>").
- Species in field guides are a cyclic window over `species.json` (6 per book, six at a time), **not** filtered by habitat. That is the one structural bug (3.1).
- The generator has its own 17-pattern secret ban list and passes it; my scan is wider (section 4).

## 3. Quality and fit, by what I read

I read a spread of 40 books in full (two per shelf across all 20 shelves, listed in `E:\Ideas\books\_scan\sample40.txt`, assessed by a reading subagent; notes in `E:\Ideas\books\_scan\sample_reading.md`), and measured the other 460 by script. Voice: the sample reads as one author in 20 costumes.

### 3.1 Factual consistency with Canon and `Data/`
- Right: rank letters F to SSS, week and day names, region and settlement names, road names, species rank, element and weakness, the 8 gods and their domains, the 1024 SC "now".
- **Wrong, structural:** 41 of 45 field guides list species that do not live in that guide's region (sea bosses in a lake-glade guide, Labyrinth species in a plains guide), because the species window ignores `habitats`. Fixed by pruning chapters whose species does not list the region as a habitat; 41 guides were left with fewer than two species and are **held**; 4 survive. 20 habitat-correct replacement guides were generated (section 5).
- Template bugs, repaired in the repo copies: "The a hammer-mark stamp" (297 books), "Cores moves" (25), "records no numbered." (40), a real-world weekday "Tuesday" (6 cookeries, Canon week is Solenday to Vexday).
- Not checked: route distances in road books against `physical_map.json`; prices (the books give no numbers, so nothing to check); recipes (real-world recipes, not tied to `Data/Items`).
- Unknown proper nouns: the scan found almost none, because the generator draws names from the data. The invented names are the romance serial's own cast (Princess Seryth, Edwyn Carr, the Knight and the Wyvern Princess, by "Ilyra Penn of Aldmere"); that is an in-world fiction and is marked draft. "Mordant" is a dyer's word. Author names are ordinary generated names (none collide with Canon; "Vale" was excluded by the generator because of Adrian Vale).
- Chronology: books are dated 900 to 1019 SC (the in-world date line), always before 1024 SC; BSC and SC years in the text only repeat lore. No contradicting dates found. One note: the romance serial's header says "printer's copy circulating in 1024 SC"; harmless.

### 3.2 Strong and weak shelves
Templated-share = average share of a book's sentences that also occur in three or more other books.

| Shelf | Books | Templated share | Verdict |
|---|---|---|---|
| Romance serial | 12 | 0.61 | Strong. Continuous story, real characters. Draft cast is not Canon |
| Letter book | 25 | 0.68 | Strong. Varied, human, best used as flavour |
| Academy lecture | 18 | 0.77 | Good, a lecturer's voice with marginal notes |
| Veilborn memoir | 18 | 0.77 | Good; the old-world-kitchen idea works (and was the one shelf near a secret, see 4) |
| Trade notes | 25 | 0.85 | Average |
| A short play | 15 | 0.87 | Good: short, performable, the best of the template shelves |
| Myth telling | 30 | 0.88 | Mixed: 12 strong, 18 templated |
| Road book | 40 | 0.89 | Average; leg-by-leg, real road names, no distances |
| Field guide | 45 | 0.91 | Average prose, wrong data before repair |
| Cookery | 40 | 0.94 | Templated frame around real recipes |
| Story aloud | 20 | 0.97 | Templated |
| Valdrisian fragment | 12 | 0.97 | Templated, but safe and on-lore |
| Local history, household, craft, guild, chapel, law, ballad, festival | 15 to 40 each | 0.98 to 1.00 | Weak: nearly the same book with a place name swapped |

## 4. Spoiler and canon scan over all 500 (scripted)

Scanner: `Tools/library/shelve.py` (rules `HOLD`/`REVIEW`) over every book, plus my broader first pass (`E:\Ideas\books\_scan\scan.py`, raw output `scan_raw.json`, `unknown_clean.json`). Rules: every Canon section 3 name and concept (Azrael, Adrian Vale, Hero numbers, Kaede Aoyama and the rank origin, Tomás and the Lantern Seal, Malgareth, Malchior, Red Prophet, Night of Unweaving, Caspian, Nocturne, Mina, Ezrath, Forgotten Ninth, Hooded Traveler, Whiskers, Nyx, Valdrisia-is-the-moon, the System's harvest, Ilvaris's truth, the Loom and Floor 120, the two fourth-wall titles, "video game", "gamer"), other studios' names, real-world names and weekdays, teen-rating words, unknown proper nouns, invented years.

Hits and decisions:

| Hit | Books | Why it matters | Decision |
|---|---|---|---|
| "Kaede Aoyama founded the Guild in the year 12 under that charter" and the slang "a Kaede" | all 25 guild manuals | Canon section 3: Hero #1 Kaede is revealed with her journal in Act V; the manuals tie her to the rank chart | **fix**: sentence removed; the slang becomes "a brightlamp" |
| "The Guild's letters, F and upward, are a Veilborn habit that the world picked up" | 18 Veilborn memoirs | Near-reveal of who invented the ranks (section 3 "The ranks") | **fix**: reworded to "a door the world picked up" |
| "does not explain the sky, the System's purpose, or anybody else's secret" | 18 Veilborn memoirs | Tells the player there is a secret purpose | **fix**: the System clause removed |
| "Lantern Night" as a festival of the dead | 12 festival notes, 1 romance volume | Canon section 3 places the Red Prophet's reveal at Lantern Night | **fix**: renamed **the Lamp Vigil** (Canon section 6 row L4 asks the user) |
| "Tuesday" | 6 cookeries | Real-world weekday; Canon week has seven made-up days | **fix**: "Maelsday" |
| "the second Hero" outlawed slavery | 15 law notes | Hero #2 is Adrian Vale (Azrael); the books never name him, and slavery's end under a Hero is public history | clear (reviewed, kept) |
| Species "Umbrael, the Hollow Star", "Vesper Harvester", "Blood Vesper Alpha", etc. | 4 field guides | They are bestiary entries in `species.json`, not lore claims | clear (reviewed); a guide that listed them was out of habitat anyway |
| "red moon" mentions | a few festival/ballad lines | Sailors mention a red moon; nothing says what it is | clear |
| "the Overlord's country" | 3 letter books | Public (the Overlord exists in the open story) | clear |
| "Earth" | 53 | The element, not the planet | clear |
| Other studios' names, teen words, real-world nations | 0 | | clear |

Unresolved after repair: **0 books** name a section 3 secret (the validator rechecks every shelved text on each build). Status counts over all 520 files (500 originals plus 20 gap books): **clear 119, fix 360, hold 41**.
- Held (41): field guides whose species list could not be repaired (fewer than two habitat-correct species). They are not shelved and have no imported text. Ids are in `13_Production/library_scan_report.json` and the README of `02_Lore/library/`.
- Fix (360): 340 originals (template bugs, the Kaede, rank-origin, System and Lantern Night lines, Tuesday, off-habitat pruning) plus the 20 gap books, which carry the same template repair.

## 5. Gaps and what I wrote

Holes found: (a) Whisperwood, the opening region, had 4 books and its guild branch no shelf; (b) 41 held field guides left most regions without a bestiary book; (c) no book or library existed for the player's early game. Response: up to 20 new field guides (`bk_501` to `bk_520`, status draft, source `Tools/library/gap_books.py`) generated with the originals' own `field_guide` function but with species taken from the region's own habitat list, for the 20 lowest-ring surface regions. They go through the same scan and repair. I wrote no hand-authored books: the voice is better matched by the generator, and a human rewrite pass is the real fix (section 6).

## 6. Recommendations (not done here)

1. Rewrite the weak shelves by hand in this order: local history, guild manual, household, craft, chapel, law, ballad, festival (about 190 books that are the same text with a place swapped); a rewrite should add real content: a recipe that uses `Data/Items` ingredients, a route with a time from the map, a rumour a quest uses.
2. Keep letter books, the romance serial, the play shelf and the 12 strong myth tellings as the model of the voice.
3. Decide the open rows in Canon section 6 (L1 to L5).
4. Add the optional reading UI (the journal) later; the Core record and rewards are ready.

## 7. Checks that ran

See the final report of the library-shelf session and the commit log of `agent/library-shelf/shelf`: `node Tools/validate/build_schemas.js`, `node Tools/validate/validate.js` (library: 24 libraries, 479 shelved, 41 held; map warnings 28; graph findings 0), `node Tools/run_tests.js`.
