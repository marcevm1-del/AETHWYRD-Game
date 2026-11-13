# Libraries and books

Status: draft system, **not Canon**. Built 2026-11-13 from the 500 draft books the user keeps in `E:\Ideas\books`. Audit and scan result: `13_Production/library_books_audit.md`. Optional: no quest, rank, ending or main-story step reads it; reading never gives XP.

## 1. What it is
Aethwyrd has libraries, archives, temples, schools and guild halls that keep books. A book is a short in-world chapbook (field guide, cookery, road book, local history, household book, craft notes, myth telling, guild manual, chapel notes, trade notes, letter book, law notes, academy lecture, ballad sheet, Veilborn memoir, story for reading aloud, short play, Valdrisian fragment, festival notes, romance serial). A player reads a book **in its library**, in the library's region, and may get a small knowledge reward once.

## 2. Data
- `Data/Library/libraries.json` (schema `Data/Schemas/libraries.schema.json`): 24 libraries. Fields: `id` (`lib_...`), `name`, `type` (library, archive, temple, school, guild_hall), `region`, `settlement`, `status` (**canon**: the place already exists in Canon, `02_Lore` or `Data/World`, with `source` saying where; **proposed**: invented for the shelf, not Canon), `blurb`, `covers` (regions whose books sit there by default), optional `rankGate`.
- `Data/Library/books.json` (schema `books.schema.json`): 520 books (500 originals plus 20 gap field guides). Fields: `id` (`bk_NNN`), `title`, `author` (in-world), `kind`, `library`, `region` (the library's region), `subjectRegion` (what the book is about), `shelf`, `language`, `blurb`, `readingMinutes`, `words`, `tags` (life skill or theme, plus the subject region id), `reliability`, `status`, `quality`, `inWorldDate`, `source` (the originating file), `text` (path under `02_Lore/library/`), optional `rankGate`, optional `rewards`.
- Texts: `02_Lore/library/<library-id>/<book-id>.md`; generated index `02_Lore/library/README.md`. The vault builder mirrors only the top-level `.md` files of each design folder, so the 479 texts add nothing to the vault and need no exclusion switch (checked: `node Tools/vault/build_vault.js` unchanged).

### Reliability
How far an in-world reader should trust the book: **accurate** (practical books: cookery, road, craft, household, trade; 170), **partial** (one-sided or second-hand: histories, guild manuals, letters, law, lectures, memoirs, fragments, field guides; 157), **folk belief** (myth, chapel, ballad, festival, children's stories, plays, the serial; 132), **propaganda** (reserved; no book carries it yet, see Canon section 6 L5).

### Status and quality
- `status`: **draft** (shelved, repaired by the scan, not approved), **clear** (passes the scan untouched, still not approved), **hold** (not shelved: no library, no text; stays in the data so the decision is visible).
- `quality`: strong, average or templated (how much of the text is repeated across books). Informational only.

## 3. Rules (Core: `Code/Ascend.Core/Library.cs`)
- `LibraryCatalogue` loads both files (`GameDatabase.Library`; empty when the files are missing).
- `ReadingRecord` keeps each book Unknown / Heard / Visited (Visited = read), like the map and the archive. `Hear` pencils a book from a rumour (never downgrades a read; a held book cannot be heard of). `CanOpen(book, rank, region)` returns Ok, Unknown, Held, NotShelved, WrongRegion or RankTooLow; the gates are the library's `rankGate` (the deep Labyrinth library needs B) and the book's own `rankGate`. `ReadBook` marks Visited and returns only rewards given for the first time; rereading returns AlreadyRead.
- Rewards: `bestiary` marks a species Seen; `archive` pencils a civilization's entries as Heard (never Visited, so reading cannot finish the Civilization Archive). Each `kind:id` is given **once ever**. No XP, no repeatable reward, no quest, rank or story gating.
- Save: `SaveGame.Reading` (`ReadingSave`: book statuses and rewards given). Null in older saves; `SaveRules.Upgrade` fills it; `Load(null)` changes nothing; unknown ids are ignored; a read is never downgraded.
- Not built: any library UI, art, audio or voice; a journal screen is a later `ui-engineer` job.

## 4. Validator (`Tools/validate/library_checks.js`, wired in `validate.js`)
Unique ids; every library in a real region; every shelved book names an existing library and a region equal to the library's; word count 300 to 3,000; the text file exists and sits under its library folder; **no `hold` book is shelved**; no shelved text names a Canon section 3 secret; rewards name real species and civilizations; no library holds more than 60 books.

## 5. How to add a book
1. Write the text as `02_Lore/library/<library-id>/<book-id>.md` (header lines like the existing books; teen rating; from what a person in the world could know; **no Canon section 3 secret**, not even as a hint).
2. Add its row to `Data/Library/books.json` (next free `bk_` id; status `draft`; a `source`; a `reliability`; shelve it in the library of the region where it sits).
3. Optional: a `rankGate`, and a `rewards` row (`bestiary` with a species id, `archive` with a civilization id).
4. `node Tools/validate/validate.js`. To regenerate the whole shelf from the originals: `python Tools/library/shelve.py E:/Ideas/books` (repairs are listed in the script; it overwrites `Data/Library/`, `02_Lore/library/` and the scan report, so hand-added books must be added to the script's input or re-added afterwards).
5. A book becomes Canon only when the user says so; flip nothing to Canon here.

## 6. To do later (not part of this change)
Hand rewrites of the weak shelves (audit section 6); recipe and route books tied to real data; a journal reading screen; the reliability field driving a "this is only a rumour" tag in the UI.
