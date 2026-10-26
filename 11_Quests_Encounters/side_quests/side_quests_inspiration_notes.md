# 11f — Side-Quest Inspirations: What We Borrow (ideas only)

> *"Take the mechanic, never the text."* — `CLAUDE.md`, commercial-game rule

**Status: research note, draft.** This document records what the research found, what pattern each finding suggests, and how Ascend adapts it. It supports the **forty pattern quests** in files 11–18 of this folder ([[patterns_index]]). `Canon.md` wins.

## 1. The rule

`CLAUDE.md` is explicit: **take only ideas and mechanics from other studios' games, never their code, art, text or data.** So:

- Every quest here is **original**: its premise, names, places, lines and rewards are written for Aetheria.
- No quest reproduces a named quest from another game. Where a source suggests a *shape* (a bargain with a god; a riddle trail; a relationship event with branching endings), we write our own *story* in that shape.
- No source text is copied. Findings are paraphrased and linked.
- This note is not legal advice; the Canon §4d Nemesis-patent caution and "IP lawyer review before release" still apply to anything adjacent.

## 2. What the research found

The web results were thin and uneven. Fan guides, listicles and spam pages were discounted. The findings below come from the more credible items, and each is marked with how much weight it can bear.

| Source | Finding (paraphrased) | Weight |
|---|---|---|
| [UESP: Skyrim Radiant quests](https://app.uesp.net/wiki/Skyrim:Radiant) | Skyrim's generator builds quests from swappable parts (a place, an enemy type, a reward). It yields endless quests cheaply but cannot make large or complicated ones | Reference wiki; reliable on mechanics |
| [Tom's Hardware, on Radiant quests](https://tomshardware.com/news/skyrim-Elder-Scrolls-Radiant-todd-howard-RPG,13935.html), plus a [forum repost of a Nesmith interview](https://forums.nexusmods.com/topic/542675-bethesda%E2%80%99s-nesmith-reflects-on-the-difficult-birth-of-skyrim%E2%80%99s-%E2%80%98radian) | Developers framed generated quests as a way to send players to places where *discoveries* matter more than the errand, and judged hand-written story better than automated objectives for anything important | Pre-release press and a repost; treat as a developer's claim |
| [Lisbon thesis on improving Radiant](https://labjogos.tecnico.ulisboa.pt/en/thesis/procedural-quest-generation-improving-skyrim-s-radiant-story) | Chaining generated events was tried to add depth; the base system limited it | Academic; narrow |
| [Prima's Daedric quest overview](https://primagames.com/eguides/elder-scrolls-v-skyrim-special-edition-eguide/Quests/daedric-quests) and [GamesRadar's guide](https://gamesradar.com/skyrim-daedric-quest-guide/2) | Skyrim's god-like patrons each run a self-contained quest with its own *tone*: one comic, one grim, one a lopsided bargain. They are largely independent of each other | Guides; good on structure |
| [Epic Store hangouts guide](https://store.epicgames.com/news/complete-genshin-impact-hangouts-guide-unlock-all-endings-and-earn-primogems), [TechRaptor's guide](https://techraptor.net/gaming/guides/genshin-impact-14-hangout-events-guide) | Genshin's hangout events pair a character with a short branching conversation-and-errand story. A mood meter tracks choices and can fail the event, softened by checkpoints; there are several endings | Fan/press guides; fine on structure |
| [Sportskeeda hidden-quest guides](https://sportskeeda.com/esports/5-hidden-genshin-impact-quests-may-missed-sumeru), [the Seirai guide](https://sportskeeda.com/esports/genshin-impact-how-complete-relics-seirai-world-quest-puzzle), [a six-part puzzle quest](https://sportskeeda.com/esports/good-stuff-terrible-taste-genshin-impact-quest-guide) | World quests often have no marker, start after a trigger or an earlier quest, run in several stages with a *different puzzle each stage*, and use riddles that point to places | Patch-specific guides; a pattern, not a spec |
| [Philosophical analysis of Witcher 3 choices](https://soctech.spbstu.ru/en/article/2024.14.11) and a [review of its contracts](https://gamebanshee.com/kaaqc) | A quarter of the quests offered a choice between rescue and ruin; about two fifths pit personal good against others'. Consequences are not easy to predict. Contracts reward investigation and talking as much as fighting | One academic content analysis; plus a review |
| [Quence on Elden Ring vs Horizon](https://quence.substack.com/p/approaches-to-open-worlds-elden-ring), [PC Gamer on Elden Ring vs Breath of the Wild](https://www.pcgamer.com/uk/stop-comparing-elden-rings-open-world-to-zelda-breath-of-the-wild) | Open worlds can hide their quests, rely on landmarks and visual cues, and let players find stories by exploring instead of by marker. This can also leave players unsure what counts as a quest | Opinion; useful as a trade-off |

**What the research did *not* give us:** hard numbers on how players experience any of this. Everything below is a design hypothesis to be tested in Ring 1 and Ring 2.

## 3. The lessons, and our eight patterns

| # | Lesson (generalised) | Our pattern | File |
|---|---|---|---|
| 1 | A place can tell a story with no one telling it; discovery is the reward | **Cairns and Notes**: found scenes, an echo or note, no marker; the player completes what someone left unfinished | 11 |
| 2 | A powerful patron can run a quest with its own *tone* and an odd, morally slanted ask | **Bargains of the Eight**: five shrine-herald quests, one per god, each with a different register | 12 |
| 3 | Puzzles work best in stages, each with a *different* idea, and a riddle can point to a place | **Riddles of the Realm**: five multi-stage puzzle quests built on Ascend's own rules (element auras, rhythm, light, water) | 13 |
| 4 | A branching conversation-and-errand with a character is a good small unit of bond | **Hangouts**: five companion bond quests with tracked *closeness, trust, respect and tension* (not one meter) and **no fail state** | 14 |
| 5 | A contract is better when the evidence contradicts the job | **Contracts with a Twist**: five investigation hunts where the "monster" is misread | 15 |
| 6 | A faction is best met through one vivid test, not a ladder of chores | **Guild Ladders**: five single-sitting faction tests | 16 |
| 7 | The road should surprise the player on the way somewhere else | **Strange Visitors**: five short random-encounter quests | 17 |
| 8 | Small, kind errands make a world feel lived in, and fit the slow-life afterstory | **Slow-Life Errands**: five cozy F–E quests | 18 |

## 4. How we adapt each lesson to Ascend's rules

| Ascend rule | Where it shapes the patterns |
|---|---|
| **Canon §5, loss rules** | Hangouts have *no* fail state; Bargains show their cost before the player commits; nothing is lost silently |
| **Canon §4d, Named monsters** | Contracts never turn on a monster "remembering" the player; the twist is *region* state or the monster's own situation |
| **Guidance channels** (Canon §6) | Cairns have no marker by default, but the *world cue* channel is always available (a lantern, a bird, a drifting petal), and a Journal note records the clue once found |
| **Quest outcome grammar** | Every quest still follows offer → facts and gaps → method → change → receipt |
| **Alternate routes** | None gates the main story |
| **Offline-first economy** | No quest here is time-limited by the real-world clock; "time" is in-game days |
| **Teen rating, no fanservice** | All five Hangouts are *friendship* beats; romance remains opt-in elsewhere |
| **Mysteries stay open** | Cairns and Riddles plant seeds without answering them |

## 5. What we deliberately do **not** copy

- Any named quest, place, character, item or line from the games above.
- **A fixed "mood meter fails the event"** from hangouts. Our version tracks *how the relationship shifts* and always lets the player continue, per Canon §5.
- **Generated filler.** The Skyrim-style generator is a cautionary tale: Ascend's weekly board (`11_Quests_Encounters/weekly_board.md`) already covers repeatable errands. These forty are hand-written.
- **Markerless-by-default** as a hard rule. Guidance is the player's choice (Canon §6).

## 6. What we want to test

| Hypothesis | Test |
|---|---|
| Players will *notice* a cairn story without a marker if the world cue is clear | Playtest the five Cairns with the cue channel on and off; count completions and "stuck" reports |
| A five-quest pattern file is a good unit of authoring | Track writer hours per pattern; compare against the region files |
| Hangouts without a fail state still feel like choices | Ask testers whether they believed their choices mattered |
| Contracts with a twist are fun on the *second* read | Compare first and replay satisfaction |
