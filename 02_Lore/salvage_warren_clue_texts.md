# The Salvage Warren: clue and puzzle texts

> Writer's draft by the narrative-writer agent, 2026-11-13. Source data: `Data/World/dungeons.json` (`dng_salvage_warren`) and `Data/World/puzzles.json` (`pzl_warren_levers`, `pzl_warren_plates`, `pzl_warren_runes`). Rules: `12_Systems/dungeons_and_puzzles.md`. `Canon.md` wins.
> Every line here is player-facing and spoiler-free: the Warren is a lair of kobold scavengers and old tally-keepers, and nothing in it touches a Canon §3 secret. Puzzle ids, solutions and hint counts are **unchanged**; this file proposes wording only. Puzzles stay optional, skippable for free, and reward only optional items (Canon puzzle contract).

## Voice

The Warren is written by two hands:

- **The tally-keepers** (old, gone, careful): short chalk marks, ledger shorthand, a dry bookkeeper's humour. They never say "puzzle." They say "count," "pull," "weigh," "match."
- **The kobolds** (current, scruffy, proud): scrawled on scrap with burnt sticks, always a little boastful, often misspelled in a way that is cute and never insulting. They stack lost adventurer gear and take a quiet pride in returning the occasional bootlace.

Hints are written as *notes someone left behind*, so that asking for a hint feels like finding a margin note, not being told off.

## Solutions (writer's check; keep clue text true to these)

| Puzzle | Solution as the data stands |
|---|---|
| **The Tally Levers** (`pzl_warren_levers`) | Pull in order: slate, ash, chalk, tin |
| **The Weighing Floor** (`pzl_warren_plates`) | East plate takes weight 3, west plate takes weight 5. The four stones weigh 1, 2, 2, 3 (8 in total), so all four are used. Any split works: slab on east and pebble + brick + block on west; or pebble + brick or pebble + block on east and the rest on west |
| **The Resonance Lock** (`pzl_warren_runes`) | Turns are additive, so order does not matter. Turn sconce two three times and sconce four twice; sconces one and three are never turned directly (checked by search: 5 turns is the minimum) |

## Room clue texts

### Chalk Landing (entry)

`clue_chalk_marks` (reveals the lever puzzle). Keep the existing text; the alternatives below are for a second reading or a different tone:

| Use | Text |
|---|---|
| Found in place (existing, keep) | Four chalk marks on the wall, from the bottom up: a slate-grey scrape, an ash smudge, a white line, a tin-bright dot. |
| Alt, closer to a kobold voice | LIFT ORDERS (do NOT skip). Bottom mark first. Grey. Then smoky. Then white. Then the shiny one. Eat after. |
| Heard (existing, keep) | Porters say the kobolds chalk their own lift orders on the landing wall. |
| Extra scrawl on the checkpoint | A tally of tiny sticks, forty of them, and one bigger stick. Under it: *DAYS WITHOUT A CAVE-IN*. The big stick is the number you want. |

### Scrap Hall (hub; the lever puzzle sits here)

| Place | Text |
|---|---|
| The four levers (inspect) | Four iron levers worn bright where hands have held them. Each has a dab of colour beside it: slate, ash, chalk, tin. |
| The idle lift (inspect, before solving) | A cage lift on a rusted chain. Someone has chalked *WORKS (SOMETIMES)* on the frame. |
| The idle lift (after a wrong pull) | The chain rattles, then settles. Nothing breaks. A small chalk tick appears on the frame as the tally resets. |
| The idle lift (solved) | The chain takes the weight with a long, tired groan, and the cage rises to meet you. Someone has added: *TOLD YOU*. |
| Kobold graffiti | A drawing of a kobold pulling a lever, labelled *ME*. A second drawing of the lever pulling a kobold, labelled *ALSO ME*. |

### Weighing Gallery (key room; the plate puzzle sits here)

| Place | Text |
|---|---|
| The two plates (inspect) | Two stone plates in the floor, each stamped with a number: a **3** on the east plate, a **5** on the west. Both are sunk a finger-width. |
| The pile of weights (inspect) | Four stones stacked by the wall, each cut with a small mark: one pebble, two squat blocks, one flat slab. A neat ledger scratched beside them lists the weights, light to heavy. |
| Wrong weight (plate pops back up) | The plate clicks and rises. Too much, or too little. Nothing is lost. |
| Right weight, one plate | The plate sinks and holds with a soft *chunk*. One half of the count. |
| Both plates held (solved) | A latch lets go behind the wall. In the alcove: a small stack of rune plates, wrapped in oiled cloth. |
| Kobold graffiti | *WE WEIGH EVERYTHING HERE. WE ALSO WEIGHED THE BOOT. THE BOOT WAS 4.* |
| The rusted tally key (flavour, `key_rusted_tally`) | A rusted token stamped with a count of nothing at all. The keepers used it to say *the way is open*. |

### Lower Landing (checkpoint)

`clue_cistern_draught` (reveals the secret seam):

| Use | Text |
|---|---|
| Found in place (existing, keep) | A cold draught leaks from a seam in the wall behind the broken lamp-post. The seam has a rune-lock on it. |
| Heard (existing, keep) | The cook on floor three swears the tally-keepers hid their pay-chest somewhere under the lower stairs. |
| The broken lamp-post (inspect) | An iron lamp-post, snapped at the shoulder. The flame-mouth is still sooty; the chill behind it is not. |
| Rumour variant (for a rumour board slot) | *The kobolds don't like the draught by the lower stairs. Old keepers' business, they say. They won't go near it after lamp-out.* |

### Beetle Vault (boss)

No puzzle. Mood line when the door is first opened: *A long hall lined with salvage: boots, shields, a whole cart wheel. In the middle, something very patient is wearing armour that was not made for it.*

### Rune Cistern (secret)

`clue_runesmith_mural` (reveals the rune puzzle). Existing text kept; extras:

| Place | Text |
|---|---|
| Found in place (existing, keep) | A faded mural: four runesmiths, each holding one glyph to the light. The oldest note says the lock was a children's game before it was a lock. |
| The four sconces (inspect) | Four sconces in a row along the cistern wall, each holding a carved glyph. Turn one, and its neighbour stirs. |
| A wrong arrangement | The sconces glow, then dim together, like a held breath let go. They stay where they are. |
| One sconce in place | One sconce settles on its glyph with a warm note, like a struck cup. |
| Solved | All four sconces ring at once, a clean chord, and the water in the cistern goes still. Something in the wall slides open. |
| Mural caption (the "children's game") | Under the four smiths, in a child's squared hand: *Ember to tide, tide to gale, gale to stone, stone to ember. Round and round. Don't let the neighbours cheat.* |

## Hints: proposed replacement wording (same count, same order)

`Puzzle.NextHint()` and the tests rely on three hints in order, with the last repeating. The wording below keeps the count at three and the meaning true to the solutions above. Where the current hint is misleading, that is marked.

### The Tally Levers

| # | Current | Proposed |
|---|---|---|
| 1 | The kobold tally-keepers chalked four marks on the landing wall, one for each lever. | The tally-keepers chalked four marks on the landing wall. Four marks, four levers. They did not do that for decoration. |
| 2 | Read the chalk marks from the bottom up: slate, ash, chalk, tin. | Read the marks from the bottom up: slate, ash, chalk, tin. Pull the levers in that order. |
| 3 | A wrong pull only resets the tally. Nothing is lost. | A wrong pull only resets the tally. Take your time; the lift will wait. |

(The current hints are accurate; the proposals only add a little warmth and clearer verbs.)

### The Weighing Floor

| # | Current | Proposed |
|---|---|---|
| 1 | Each plate wants an exact weight. Too much and the stone pops back up. | Each plate wants an exact weight. Too much, or too little, and it pops back up. Nothing is lost. |
| 2 | The east plate takes 3, the west plate takes 5. | The east plate is stamped **3**. The west plate is stamped **5**. The weights by the wall add up to 8. |
| 3 | Try the heaviest stone on the east plate, then fill the west plate with the rest. | If one stone is exactly right for the east plate, set it down first. Then use whatever is left on the west plate. |

(The current hint 3 gives the full answer with only one valid-looking split; the proposal keeps it as a nudge and is true for every valid split. The old note "too much and the stone pops back up" is also true for "too little", which the proposal now says.)

### The Resonance Lock

| # | Current | Proposed |
|---|---|---|
| 1 | The old runesmiths set four sconces to match the mural above the cistern. | The old runesmiths set four sconces to match the mural. The mural's caption is a children's rhyme about a ring of four glyphs. |
| 2 | Turning a sconce also turns its neighbour. Start from the far left. | **Misleading as written.** The second and fourth sconces are the ones that need turning, and sconces one and three never need turning directly. Proposed: *Turning a sconce also turns the one it points at. Count how far each glyph must travel. Two of the four never need touching.* |
| 3 | Each sconce cycles ember, tide, gale, stone and then back to ember. | Each sconce goes round in a ring: ember, tide, gale, stone, then ember again. Turn the second sconce three times and the fourth twice. |

(Hint 2 as written tells the player to start from the far left, but the minimal solution never turns sconce one at all. The proposal fixes that. Hint 3 now doubles as the free `Assist()` text: it names the move.)

## Free assist text (`Puzzle.Assist()`)

After `failsBeforeAssist` wrong tries, or after every hint has been read, the game names the next correct move. Proposed wording, one per puzzle:

| Puzzle | Assist text |
|---|---|
| Tally Levers | *Next pull: [lever colour]. The chalk says so.* |
| Weighing Floor | *Set [stone] on the [east/west] plate. The count will do the rest.* |
| Resonance Lock | *Turn the [second/fourth] sconce once more.* |

## Skip and reward lines

| Moment | Text |
|---|---|
| Skipping a puzzle (free, any time) | *Leave it. The keepers always said a count is not a debt.* |
| Coming back after a skip | *You left this one half-counted. Fresh chalk is on the wall. It is still yours to finish.* |
| Reward: rune plates (Weighing Floor) | *Rune plates, the kind runesmiths cut from. The keepers kept them for good counts.* |
| Reward: Rank E core (Resonance Lock) | *A small core, warm and unclaimed. The old pay-chest was this, and a note: **PAID IN FULL.*** |
| Quiet confirmation, any puzzle | *Counted. Done.* |

## Notes for other owners

- **Hint 2 of `pzl_warren_runes`** is misleading for the actual solution (see above). It is data (`Data/World/puzzles.json`, owner: quest-designer / items-designer), so I have not changed it. If it is replaced, `PuzzleTests.HintsAreFreeAndTheLastOneRepeats` and the validator expect three hints per puzzle in order; the proposals keep that.
- **Free assist and journal strings** are not in data yet; the lines above are the content for whoever adds an `assist` and `solved` text field to `puzzles.schema.json` (tools-pipeline-engineer).
- **Environmental texts** (graffiti, plate inspections, mood lines) have no data home yet. They map to the room descriptions the world-builder-engineer would place in the Warren when the dungeon is built in Unity.
