# In-world books: what makes one worth reading, and how to write ours

Status: research note, **not Canon**. Written 2026-11-15 by the `standing-library` research session for the `library-shelf` session to write to. Nothing here is a locked decision; new lore the model books imply is listed as proposed Canon section 6 rows in section 5.

**Scope.** Four questions, in the order they were asked: how players actually meet readable books in games (section 1); what a good in-world text does as a piece of craft (section 2); the style guide and the model books to copy (section 3); and the state of our own 24 libraries, with what each weak one should be *for* (section 4). The ten rules are at the end.

**Where the numbers come from.** Every figure about our own shelf was measured by me on `agent/library-shelf/shelf` at commit `d2a06a02` (batch 4 of the hand-written rewrite: 64 hand-written, 480 shelved, 40 held). Scripts are throwaway; the method is stated beside each number so it can be re-run. The brief's "245 distinct excerpts of 479" is the pre-rewrite baseline from `13_Production/library_books_audit.md`; at `d2a06a02` it is **280 distinct excerpts of 480 shelved books**. Both numbers are right about different moments.

**Where a claim has no source, it says so.** Section 1 is a literature sweep and is labelled by source type. Sections 2 and 3 are craft judgement, mine, and are marked as such — craft is argued, not cited. Section 4 is measurement of our own data.

**Reading this in a hurry:** section 3 is the deliverable. Sections 1, 2 and 4 are why it says what it says.

---
## 1. How players actually meet books in games

_IN PROGRESS: literature and postmortem sweep running; this section lands next._

---

## 2. What a good in-world text does

_IN PROGRESS._

---

## 3. The style guide

_IN PROGRESS._

---

## 4. Our library specifically

### 4.1 What I measured, and how

Source: `agent/library-shelf/shelf` at `d2a06a02`. 520 book rows, **480 shelved**, 40 held, 24 libraries, 64 hand-written texts. Measured on the 480 shelved texts with the header lines (title, author, Shelf, Region, In-world date, Status) stripped, sentences split on terminal punctuation, fragments under 25 characters discarded:

| Measurement | Result |
|---|---|
| Distinct sentences across the whole shelf | **3,701** distinct, from 33,011 sentence instances |
| Share of all sentence instances whose sentence also appears in ten or more books | **31%** |
| Share appearing in thirty or more books | **18%** |
| **Median share of a templated book's sentences that repeat an earlier sentence _in the same book_** | **59%** (336 of 416 templated books are at 30% or worse) |
| The same figure for the 64 hand-written books | **0%** (no hand-written book repeats a sentence inside itself) |
| Distinct excerpts (the card the reader sees first) | **280** of 480; 85 excerpts are shared by more than one book, covering 285 books; the most-reused excerpt is the card for **10** books |

**The intra-book figure is the one that matters, and it is new.** The existing audit measured repetition *across* books: a player who reads three books of one shelf meets the same paragraphs again. That is true, and it is the softer problem, because it takes three books to show. The median templated book repeats **59% of its own sentences inside its own covers**. Open `lib_aldmere_guild_hall/bk_262.md` and the paragraph beginning "At ice-fishing villages the work of the day sits inside spray, rope bridges, and wet stone" arrives four times, unchanged, under four different chapter headings. The seam is visible in **one** book, in about ninety seconds, to a player who has read nothing else.

That is the defect to fix first, and it is also the cheapest to detect: it needs no corpus, just a duplicate-sentence check inside each file. The 64 hand-written books score zero on it. Whatever else the rewrite is doing, it has already solved the worst thing.

### 4.2 Three separate ways a shelf can be bad

They need separating because they have different fixes, and the 24 libraries fail differently.

- **Templated** — the text is frame-filling. Fix: rewrite.
- **Thin** — too few books to be a shelf. Fix: write more, or fold the library into another.
- **Unfit** — the books do not match what the library is for. Fix: re-shelve, or give the book a reason to be here, or change what the library is.

"Unfit" is not the same as "about somewhere else". A central academy holding lectures about twenty-two regions is doing its job: **96% of the Mages Academy shelf is about another region and that is correct.** A guild headquarters holding branch manuals for every branch is doing its job too. A watch-house whose blurb promises "field notes about the dark country the Bastion stands against" and whose shelf is cookery, household books and ballad sheets is not. The test is the library's own stated purpose, not the region field.

### 4.3 The 24 libraries

Templated % and off-region % are of that library's shelved books, at `d2a06a02`. The verdict is my judgement.

| Library | n | Templated | Off-region | Verdict |
|---|---|---|---|---|
| The Peat Library (Greymoor) | 22 | **0%** | 0% | **The model.** 16 hand-written, every book about its own moor. Copy this shelf's shape. |
| Aldmere Royal and Noble Archives | 25 | **0%** | 28% | Strong. Holds the romance serial and the Labyrinth-gate guides; off-region is the Labyrinth below it, which is right. |
| Lirian Licence Archive | 14 | **0%** | 64% | Strong, slightly thin. Canal licences plus trunk-river trade; off-region is the river, which is right. |
| Karak Dun Hall of Records | 29 | 10% | 31% | Strong. 11 hand-written. |
| Lothaniel Root Archive | 30 | 13% | 27% | Strong. 14 hand-written. |
| Brindlewick Guild Branch Shelf | **3** | 0% | 0% | **Thin where it hurts most.** All three hand-written and good, and it is the first library almost every player will ever open. Three books. |
| Summoning Cathedral Shelf (Aldmere) | **2** | 0% | 100% | Thin to the point of not existing: two myth tellings, both about Whisperwood, in a cathedral in Aldmere. |
| The Mages Academy Library | 28 | 21% | 96% | Fit. Off-region is the point. Rewrite the 6 templated lectures and it is done. |
| Vharlen Legion Records House | 18 | 22% | 72% | Mostly fit: a frontier records house legitimately holds the marches it watches. |
| Hoshizora Shrine Library | 19 | 42% | 0% | Templated only. Local and coherent; needs prose. |
| Zaruma Earth Towers | **8** | 38% | 62% | Thin. Griot histories are the right idea; there are eight. |
| Zarvan Garden Library | **6** | 50% | 50% | Thin. |
| Port Goldmere Harbor Reading Room | 20 | 55% | 0% | Templated only. Fit is good: tide tables and sailors songs, all local. |
| Qadira Water Archive | 16 | 56% | 62% | Templated and partly unfit. |
| Shen-Lu Foothill Sect Library | 25 | 56% | 80% | Templated and unfit: a sect library holding 20 books about Haneul next door. |
| Labyrinth Upside-Down Library (Floor 72) | 31 | 61% | 87% | **The worst loss in the set.** The highest-concept library in the game, hanging the wrong way up, rank B to enter, and 21 of its 31 books are templated cookery and household notes about the Maw. |
| Bastion Watch Library | 22 | 64% | 18% | **Templated and unfit.** Promises field notes on the horde lands; delivers recipes. |
| Fox Shrine Isle Library | **9** | 67% | 56% | Thin and templated. |
| Dragon-Bone Monastery Library | 26 | 69% | 88% | Templated and unfit: 18 of 26 about Heavenreach, not the Bone Road. |
| Xochitl Cord Archive | 18 | **72%** | 0% | Templated, but perfectly fit: every book is about its own mire. A pure prose problem. |
| Skjaldheim Skald Hall | 30 | 73% | 87% | Templated and unfit: a skald hall whose 30 books are 22 Quaking Lands cookeries and household notes. |
| Aurumdeep Explorers Camp Shelf | 30 | 73% | 87% | Templated and unfit. 19 of 30 about the Hollow Sea. |
| Aldmere Guild Hall Reading Room | 40 | 75% | 100% | **The largest single mass of bad text: 30 templated books.** Fit is fine (branch manuals and street law for every branch); the prose is the problem, 25 guild manuals and 15 law notes deep. |
| Lumbaya Sky Temple Shelf | **9** | **89%** | 44% | Thin *and* the most templated shelf in the game. |

**The five weakest shelves, in the order I would fix them:** Aldmere Guild Hall (30 templated books, the largest mass, and street law is the most useful kind to a player), the Labyrinth Upside-Down Library (19, and the biggest gap between concept and content), Skjaldheim Skald Hall (22), Aurumdeep Camp Shelf (22), Dragon-Bone Monastery (18). Then Xochitl (13), Bastion (14), Shen-Lu (14), and the thin ones.

But **Brindlewick jumps the queue**, for a different reason: it is not weak, it is small. Almost every player opens it first and finds three books. The first library a player meets decides whether they ever open a second one (section 1.4). Six to eight more hand-written books for Brindlewick are worth more than thirty rewrites in ring 7.

### 4.4 What each weak library should be *for*

A library is not a shelf with a region attached; it is an institution with a reason to keep paper. Give each one a **collecting policy** — one sentence saying what it keeps and what it refuses — and the books start writing themselves, because the policy chooses the form and the form chooses the voice. A peat-cutters reading room and a guild archive want different books, and they want them in different *shapes*.

| Library | Its collecting policy | Therefore its forms |
|---|---|---|
| **Aldmere Guild Hall Reading Room** | What the Guild must be able to produce when a branch is accused of something: standing orders, desk procedure, the street law a clerk needs in order not to be sued. It keeps nothing beautiful on purpose. | Procedure manuals. Circulars with amendments pasted over them. Court records and findings. A desk clerk's unofficial notes kept beside the official ones and contradicting them. |
| **Labyrinth Upside-Down Library (Floor 72)** | Whatever the Labyrinth has swallowed and the library has caught, filed by the floor it fell from. It is a lost-property office with shelves. Nothing was written here. | Fragments. Marginalia in books whose main text is gone. Catalogue entries for missing volumes. A keeper's accession register: what arrived, when, from which floor, in what condition. Three pages of a ledger whose owner did not come back. |
| **Skjaldheim Skald Hall** | What is performed, not what is read: the hall keeps the authorised words of things that are spoken aloud. | Song texts with the performance notes attached (who sings which line, where the hall joins in). Verse genealogies. A skald's working notebook of half-finished lines. Disputed versions set side by side, which is what a hall of professional memory actually argues about. |
| **Aurumdeep Explorers Camp Shelf** | What the last party left for the next one. Nobody curates it; people add, and people take. | Route notes with the mistakes left in and corrected in a second hand. Equipment lists. A letter pinned to the shelf for someone who has not come back yet. Scrawled warnings. A party roster with names crossed out. |
| **Dragon-Bone Monastery Library** | The copying house of the Bone Road. It keeps what it has copied for other people, and the copies it was paid to make. | Copyists colophons. A rule of the house. Pilgrim registers. Letters sent up to the eyries, and the replies. The list of copying errors a careful monk has compiled so that the next copyist does not repeat them. |
| **Xochitl Cord Archive** | The cords, and the paper that explains the cords. Its business is the record of obligation: who owes water, flowers, labour, a ball-game debt. | Ledgers. Cord transcriptions with a second hand's corrections. Market tallies. A dispute settled by reading two cords against each other. |
| **Bastion Watch Library** | What the next watch needs to know about the steppe: sightings, counts, and the things that worked. An institutional memory with a short temper. | Duty logs. Incident books. Sighting registers with the ring and the hour. A standing order with the amendments nailed up under it. A captain's handover note. |
| **Shen-Lu Foothill Sect Library** | The sect's own rules, and the correspondence of its gate-towns. A sect keeps what settles arguments about correct practice. | Rule books with commentary in a smaller hand. Examination questions and model answers. Letters between gate-towns about a disagreement. A novice's copybook. |
| **Lumbaya Sky Temple Shelf** | What the temple villages teach their children and sing at their feasts. Nine books is a village school's entire shelf, and that is allowed to be the point. | Children's primers. Song books. A temple-keeper's calendar. A counting book whose examples are the harvest. |
| **Fox Shrine Isle Library** | Stories as they arrived by boat, each logged with who brought it and how it changed in the telling. | The same story in three versions with the provenance of each. A shrine ledger of offerings and the requests attached to them. |
| **Qadira Water Archive** | Water rights. Who may draw, when, how much, and every dispute about it since the well was dug. | Well registers. Allocation tables. Judgements. A recitation the water-keepers are supposed to know by heart, written down for the first time by somebody who is afraid they will forget it. |
| **Port Goldmere Harbor Reading Room** | What a harbour needs in writing: tides, dues, wrecks, and the songs the crews will not stop singing. | Tide tables with a harbour-master's annotations. A wreck register. Customs schedules. A ballad sheet printed to be sold on the quay. |
| **Hoshizora Shrine Library** | The river mouth's year: rain, festivals, households. | Rain tables. Festival instructions. A household book kept by one family for four generations, each hand distinguishable. |
| **Zaruma Earth Towers**, **Zarvan Garden Library**, **Summoning Cathedral Shelf**, **Brindlewick Guild Branch Shelf** | Thin, not wrong. Each needs volume, not redirection. Brindlewick's policy: what a newcomer is handed on their first day, plus what Magistra Eolande Fairweather thinks they should be reading instead. | For Brindlewick specifically: the trainer's own handout; a porter's bestiary of ring-1 nuisances; a village household book; and one wholly unsuitable book somebody left behind, which is the one the player will remember. |

### 4.5 How much rewriting is actually needed, and what can be retired

**416 of 480 shelved books are templated.** Rewriting all of them by hand is roughly eight to ten times the work done so far. It is not necessary, and attempting it is the main risk to the shelf.

Three piles.

**Pile 1 — rewrite: about 150 books.** Every book in a library a player will plausibly open, plus every book of a kind that can carry player-useful content. Concretely: the 30 templated Aldmere Guild Hall books; the 19 Upside-Down books; Brindlewick plus six to eight new ones; Xochitl's 13; Bastion's 14; the 8 templated Hoshizora; the 11 Port Goldmere; the 6 Mages Academy lectures; and the thin shelves brought up to about twelve books each (Lumbaya, Fox Shrine, Zaruma, Zarvan, the Cathedral: roughly 40 books, mostly new rather than rewritten). That is the shelf a player actually meets. Call it 150 — at the current rate of about 16 a batch, nine or ten more batches.

**Pile 2 — re-shelve or justify: about 110 books.** The books that are templated *and* sitting in a library whose purpose they do not match. This is **not** a prose problem, it is a filing problem, and its cause is structural: **28 of our 49 regions have no library of their own**, so the generator parked their books next door. Twenty-two Quaking Lands books live in Skjaldheim; 21 Maw books hang in the Upside-Down Library; 20 Haneul books sit in a Shen-Lu sect. Two honest fixes, and the second is better:

1. Add libraries in the regions that have none. Cheapest for the regions a player will actually reach.
2. **Keep the book where it is and give it a reason to be there** — one line in the text saying who carried it and why. A book about the Maw hanging in a library on Floor 72 is *excellent* once it says that a dead porter's pack was emptied onto the accession desk. The generator's real failure was not misfiling; it was misfiling silently. This becomes rule 7 in section 3.2.

**Pile 3 — retire: 80 to 150 books.** Templated, in a library that does not want them, about a region the player may never visit, of a kind that teaches nothing checkable. Retiring them costs very little, and I measured the cost: the 147 books that are templated *and* off-region carry only **11 reward entries between them, 4 distinct ids, of which only 2 exist nowhere else**. Re-point those two onto a book that is staying. Four subject regions would drop to zero books (Ashira Vale, Everdusk, Root of the World, Whitewater Reach), so keep or rewrite one book each for those four and retire the rest freely.

Two mechanical warnings:

- The mechanism already exists: set `status: hold` and unshelve. The validator enforces that a held book is not shelved, so a retirement is a real checkable state and not a deletion.
- **`shelve.py` regenerates the whole shelf from the originals in `E:/Ideas/books`.** A retirement made only in `Data/Library/books.json` is overwritten on the next run, exactly as a hand-added book would be. Retirements have to go into the script's own hold list, or the next regeneration silently un-retires them. Decide that, in the script, before retiring anything.

**Recommendation on volume:** 150 hand-written, 110 re-shelved or justified (a one-line edit each, not a rewrite), 150 retired, and the rest left as clearly-draft atmosphere in rings 7 and 8 where almost nobody will be standing. That is a finishable number.

---

## 5. Proposed Canon section 6 rows, and the ten rules

_IN PROGRESS._
