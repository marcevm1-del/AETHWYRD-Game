# 11e-39 — The Hollow Sea, the Ocean Under the World: Ten Side Quests (draft)

> *"We do not follow a light we have not been introduced to."*
> — boat-town saying, the Hollow Sea

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the second regional set ([[side_quests_index]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`. ⚠️ **Spoilers (light):** quests 9 and 10 plant unexplained seeds.

**Region:** `reg_hollow_sea` (the boat-towns, the Great Waterfall, the Glow Gardens, the False Light). **Rank band:** B–A. **Tone:** hushed, cold, tender; people who love the dark and keep each other close in it.

**Placement notes.**
- **The Lumen-Eater, the Abyss Angler,** is the region's Tyrant. Its lure shows prey whatever it most wants to see, most often the surface. It has taken two boat-towns this year. No quest here kills, defeats or even fully sees it; quests 1, 7 and 10 only brush against its light.
- Customs the quests rely on: boat-towns are lashed-together boats governed by a **captain and navigators;** they steer by **the glow of fish and the songs of navigators;** the fish-light is believed to be **the light of their ancestors;** they honour the day-gods without ever having seen a day; they **never follow a light they do not know;** they pity surface-dwellers.
- Not used: a siege. The Hollow Sea has no siege state, so every defence quest here is plain `Defense`.
- Everything the gazetteer lists as history stays as written: the first boats came down the waterfall by accident, and a boat-town sailed back up it a generation ago and was never seen again (quest 9 does not say what became of it).

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | The Navigator Who Dreams of Sun | B | OddJob | Captain Ulvric Duskwake | A dream with no word for it |
| 2 | The Man on the Rock | B | Investigation | Bailer Corrin Ropemark | A survivor who will not speak |
| 3 | A Guide Across the Dark | B | Escort | Surveyor Tilda Dawnfield | Nobody will take her; you do |
| 4 | The Glow Gardens Are Dimming | B | Gathering | Gardener Ombra Kelpwhistle | Fields that need singing to |
| 5 | The Ancestor Fish | B | OddJob | Widow Selvi Quillfin | A family lamp, fading |
| 6 | A Song for Saltlamp Row | B | Delivery | Songkeeper Dovan Echorill | A lullaby that must arrive whole |
| 7 | Night of the Loose Lashings | A | Defense | Hull-Warden Sorrin Tarrow | A town holding itself together |
| 8 | Behind the Great Waterfall | A | Exploration | Archivist Ruvane Undermere | The first boat, and its lantern |
| 9 | The Town That Sailed Up | A | Investigation | Elder Gwyn Tideless | A bottle, and no answer |
| 10 | A Light We Know | A | Hidden | Dill Fernglow | An introduction, made politely |

## Cast

<!-- npc
id: npc_captain_ulvric_duskwake
name: Captain Ulvric Duskwake
tier: major
race: Human
region: reg_hollow_sea
settlement: Hollow Sea boat-towns
role: Captain of the boat-town Low Lantern
backstory: A broad, soft-spoken captain with a navigator's squint who has kept his boat-town together for twenty years by never raising his voice and never leaving a question unasked.
-->
<!-- npc
id: npc_navigator_lisbet_gloamwren
name: Navigator Lisbet Gloamwren
tier: townsfolk
race: Human
region: reg_hollow_sea
settlement: Hollow Sea boat-towns
role: Navigator of Low Lantern
backstory: A pale, sharp-eared navigator of thirty who can hold a town on course by humming one note, and who has begun to wake each morning with a warmth on her face that she has no word for.
-->
<!-- npc
id: npc_bailer_corrin_ropemark
name: Bailer Corrin Ropemark
tier: townsfolk
race: Human
region: reg_hollow_sea
settlement: Hollow Sea boat-towns
role: Rope-hand who found a survivor
backstory: A stooped bailer with rope-scarred palms who found a stranger clinging to a rock beyond the Glow Gardens and has been bringing him soup ever since, unanswered.
-->
<!-- npc
id: npc_surveyor_dessa_dawnfield
name: Surveyor Tilda Dawnfield
tier: major
race: Human
region: reg_hollow_sea
settlement: The Great Waterfall
role: Surface-born surveyor seeking passage
backstory: A freckled, determined surface-born surveyor of thirty-five who came down the stair of the Great Waterfall with a lullaby her mother taught her and a promise to see the place it describes.
-->
<!-- npc
id: npc_gardener_ombra_kelpwhistle
name: Gardener Ombra Kelpwhistle
tier: townsfolk
race: Human
region: reg_hollow_sea
settlement: The Glow Gardens
role: Tender of the Glow Gardens
backstory: A wiry gardener who sings to her algae fields every hour of every watch and has just noticed that her voice is no longer enough.
-->
<!-- npc
id: npc_widow_selvi_quillfin
name: Widow Selvi Quillfin
tier: townsfolk
race: Human
region: reg_hollow_sea
settlement: Hollow Sea boat-towns
role: Keeper of a family's lamp-fish
backstory: A tiny, bright-eyed widow who keeps in a glass jar the single glowing fish her family has kept alive for nine generations and believes holds her husband's light.
-->
<!-- npc
id: npc_songkeeper_dovan_echorill
name: Songkeeper Dovan Echorill
tier: major
race: Human
region: reg_hollow_sea
settlement: Hollow Sea boat-towns
role: Songkeeper who carries songs between boat-towns
backstory: A lean, patient songkeeper who carries the town-songs of the Hollow Sea from boat to boat, word-perfect, and who has been asked to deliver a lullaby to a town that has no one left to sing it.
-->
<!-- npc
id: npc_hull_warden_sorrin_tarrow
name: Hull-Warden Sorrin Tarrow
tier: major
race: Human
region: reg_hollow_sea
settlement: Hollow Sea boat-towns
role: Hull-warden of the boat-town Seven Knots
backstory: A heavy-handed, tender-hearted hull-warden who has inspected every lashing of Seven Knots by touch for thirty years and can tell a tired rope by its silence.
-->
<!-- npc
id: npc_archivist_ruvane_undermere
name: Archivist Ruvane Undermere
tier: major
race: Human
region: reg_hollow_sea
settlement: Hollow Sea boat-towns
role: Archivist of the first-boat records
backstory: A dry, meticulous archivist who keeps the rope-knot records of the first boats and has never been able to explain why the oldest knots describe a sound she has never heard.
-->
<!-- npc
id: npc_elder_gwyn_tideless
name: Elder Gwyn Tideless
tier: major
race: Human
region: reg_hollow_sea
settlement: Hollow Sea boat-towns
role: Elder whose mother left on the boat-town that sailed up
backstory: An old woman, nearly blind, who was a girl of nine when her mother's boat-town sailed for the waterfall, and who has spent seventy years not being angry about it.
-->
<!-- npc
id: npc_dill_fernglow
name: Dill Fernglow
tier: townsfolk
race: Human
region: reg_hollow_sea
settlement: Hollow Sea boat-towns
role: Seven-year-old with a named fish
backstory: A grave seven-year-old who has noticed that all the grown-ups are afraid of lights they do not know, and has decided the cure is to meet them properly.
-->

---

## 1. The Navigator Who Dreams of Sun

*B · OddJob · the boat-town Low Lantern · giver Captain Ulvric Duskwake*

**The short version.** Lisbet, the town's best navigator, wakes each morning with a warmth on her face. She has never felt warmth like it. The captain wants to know why before the town has to decide whether to be afraid.

**What is really going on.** Lisbet is dreaming of the sun, a thing no one in the Hollow Sea has ever seen. Whether the dream is the Lumen-Eater testing her, an old memory in the blood, or something else is **not answered here.** What the player can do is help the town hold it safely, by the one custom it already has.

**Scene 1: the captain's lamp.**

**ULVRIC:** "Twenty years I have never lost a navigator to a light. I would like to keep the number."
**ULVRIC:** "Lisbet is dreaming of a yellow she cannot name. She wakes crying, and she is not sad."
**ULVRIC:** "You are not of the town. You can ask her things we are afraid to."
> ► **"Is she in danger?"** — **ULVRIC:** "Every navigator who followed a light was happy. Right up until."
> ► **"What do you want from me?"** — **ULVRIC:** "To listen. And then to tell me honestly what you heard."
> ► **"I'll sit with her."** — **ULVRIC:** "Keep the lamp low. She startles."

**Scene 2: the watch.** In a bunk-room that smells of lamp-oil and wet rope, Lisbet sits drawing in grease-pencil on a sail-scrap: a round shape, a spread of lines, a blue behind it that is not the blue of the fish.

**LISBET:** "It is warm on my face. Not like a lamp. A lamp is warm in front. This is warm from *everywhere above.*"
**LISBET:** "I have no word for the colour. I have asked the oldest woman in town. She says it is called *gold,* but gold is a thing you trade."
**LISBET:** "Captain thinks it is the Eater. I think so too. But it does not *pull.* A lure pulls. This only... *stays.*"
> ► **"Tell me the dream again."** — She does; the details do not shift between tellings. The Eater's lights shift.
> ► **"Do you want it to stop?"** — **LISBET:** "No. That is the part I am ashamed of."
> ► **"Who else dreams it?"** — **LISBET:** "...Nobody. I thought. I haven't asked."

**Scene 3: the asking.** The player asks, quietly, through the rope-decks. Two other sleepers, a net-mender and a boy, have woken with warmth in the last week. They never mentioned it, because they thought they were the only ones.

**NET-MENDER:** "I thought if I said it aloud it would be a light, and then I'd have to *not follow* it."
**NET-MENDER:** "I'm tired of not following things."

**Scene 4: the introduction.** The player brings the three to Ulvric. He listens a long time.

**ULVRIC:** "We do not follow a light we have not been introduced to. So. We introduce it."
*In the bow, under the town's one big lantern, the three sleepers say the dream aloud, in order. Lisbet names it. The captain writes it in the log as a thing that visits, not a thing that calls.*
> ► **(Say it may be the Eater.)** — Honest, and it frightens the boy. The town pairs sleepers and keeps a watch.
> ► **(Say it may be the ancestors remembering.)** — Gentler, unproven. Some of the town takes comfort; Ulvric writes a careful note beside it.
> ► **(Say you do not know.)** — **ULVRIC:** "Good. Write that down too."

**Outcomes and receipt.**
- Low Lantern adopts the *introduction:* a dream that visits is named, logged and told aloud at the next watch. If the player named it the Eater's work, the town pairs its sleepers; if the ancestors, it hangs a second lamp; if unknown, it does both, uneasily.
- **Receipt:** a sail-scrap in the captain's log with a round gold shape; Lisbet hums a new note, a little higher, when she steers.
- **Unexplained seed:** why three strangers share a dream of a thing none of them has seen. No answer is given.

<!-- quest
id: qst_hol_dreams_sun
title: The Navigator Who Dreams of Sun
rank: B
type: OddJob
giver: npc_captain_ulvric_duskwake
region: reg_hollow_sea
level: 88
act: 4
requires_rank: B
reward: 10000 | 600 | 44000
sets: hol_dreams_sun_done
summary: A navigator wakes each morning warm from a sun no one in the Hollow Sea has seen. The captain wants it understood before the town has to be afraid.
objectives:
  talk npc_captain_ulvric_duskwake
  talk npc_navigator_lisbet_gloamwren
  choice eater_ancestors_or_unknown
-->

---

## 2. The Man on the Rock

*B · Investigation · beyond the Glow Gardens · giver Bailer Corrin Ropemark*

**The short version.** A stranger was found clinging to a bare rock, soaked and silent. He wears the knotted wrist-cord of a boat-town that is no longer on any course. He has not said a word in nine days.

**What is really going on.** He is the only survivor of one of the two boat-towns the Lumen-Eater took this year. He does not speak because he *followed.* He was at the tiller. The player must find out what happened without making him say it before he is ready.

**Scene 1: the rock.**

**CORRIN:** "I bring him soup. He takes the bowl. He gives me back the bowl. That is all."
**CORRIN:** "His cord is Reedsilver Rise. Reedsilver went dark at midsummer. The Anglers' Watch said so."
**CORRIN:** "I do not want to make him talk. I want to know if there is a *reason* to keep bringing soup."
> ► **"There is always a reason for soup."** — **CORRIN:** "Good. Then I am not a fool."
> ► **"May I sit with him?"** — **CORRIN:** "He might not look at you. Do not mind."
> ► **"What do the town elders say?"** — **CORRIN:** "That a man who follows is a man who is gone."

**Scene 2: the sitting.** The player sits on the cold rock for the length of two watches. Nothing is said. A jellyfish drifts by, pale gold. The man watches it until it is out of sight.

**MAN (barely a whisper):** "That one is the wrong colour."
**MAN:** "It's always the wrong colour. It's never the right colour. That's how I know."
> ► **"The right colour for what?"** — He does not answer, but he stays.
> ► **"You are safe here."** — **MAN:** "That is not what I was afraid of."
> ► **(Say nothing.)** — He speaks again, an hour later, unprompted.

**Scene 3: the telling.** When he speaks, it is in a flat, level voice, as if reading from a log. His name is Tobin Marshlight. Reedsilver Rise had sailed the same circuit for forty years. Then, on a night with no moon in the roof, a light appeared ahead. It was the *surface.* He knew it, he says, because his grandmother's stories had a window in them that was exactly that shape.

**TOBIN:** "I steered toward it. I told the watch it was a harbour-light. I *told* them."
**TOBIN:** "Nobody argued. That is what I cannot... Nobody *argued.* They wanted to see it as much as I did."
> ► **"It showed each of you what you wanted."** — **TOBIN:** "Yes. I would like it to have been only me."
> ► **"It was not your fault."** — **TOBIN:** "That is what the elders will say, and it will be *true,* and it will not help."
> ► **"What do you need?"** — **TOBIN:** "A rope-cord. A new one. I cannot go back with the old one."

**Scene 4: the cord.** The player carries Tobin's account to the captain of the nearest boat-town, and to Corrin, who ties him a new wrist-cord of his own, in the knot used when a stranger is taken into a family.

**CORRIN:** "It is not Reedsilver. It will never be Reedsilver. But it is a cord."

**Outcomes and receipt.**
- The Anglers' Watch gets a first-hand account of how the lure behaves close to: a light that is *the wrong colour* on a second look. If the player pushed Tobin to speak early, he gives the account but not his name.
- **Receipt:** a second bowl on the rock beside the first; every watch someone leaves soup and does not wait for an answer.

<!-- quest
id: qst_hol_man_rock
title: The Man on the Rock
rank: B
type: Investigation
giver: npc_bailer_corrin_ropemark
region: reg_hollow_sea
level: 90
act: 4
requires_rank: B
reward: 10300 | 620 | 45000
sets: hol_man_rock_done
summary: A stranger clinging to a rock beyond the Glow Gardens wears the cord of a boat-town that went dark at midsummer. He has not spoken in nine days.
objectives:
  talk npc_bailer_corrin_ropemark
  reach hollow_sea_survivor_rock
  choice ask_soothe_or_silence
-->

---

## 3. A Guide Across the Dark

*B · Escort · the Great Waterfall to the Glow Gardens · giver Surveyor Tilda Dawnfield*

**The short version.** A surface-born surveyor has come down the waterfall's stair and wants to be taken to the Glow Gardens. No boat-captain will take her: surface-dwellers are pitied, and one who follows lights is thought to be a danger to everyone aboard.

**What is really going on.** Tilda's mother, who also came down once, taught her a lullaby that describes a field of light under the earth. Tilda wants to sing it there. The danger is not Tilda. It is that the way passes within sight of the False Light, and she has never been told not to look.

**Scene 1: the stair landing.**

**DESSA:** "Eleven captains. Eleven *no.* The last one said it kindly, which was worse."
**DESSA:** "I do not follow lights. I *map* them. I have never once stepped toward one I did not triangulate."
**DESSA:** "I need to get to the Gardens. I have a song to sing."
> ► **"Why do they say no?"** — **DESSA:** "They pity me. It is their form of refusal."
> ► **"What song?"** — She hums a few bars. It is tender and slightly out of tune. **DESSA:** "My mother's. She said it was a place."
> ► **"I'll take you."** — **DESSA:** "You do not have a boat." **YOU:** "I can borrow one." **DESSA:** "Then I will ask nothing of the captains."

**Scene 2: the crossing.** In a borrowed skiff, a long, quiet, black-water passage: the roar of the waterfall behind, the glow of fish below, a net of faint green sparks. Tilda sits upright, notebook closed.

**DESSA:** "It is the quietest loud place I have ever been."
**DESSA:** "My mother said it would be like being inside a lantern."
*(Gameplay: gentle navigation; the player steers by fish-glow and by song; no combat unless the player strays.)*

**Scene 3: the False Light.** Midway, off the port bow, something blooms in the black: a steady, warm, impossibly familiar yellow. Tilda stops writing.

**DESSA (very softly):** "That is the sun."
**DESSA:** "That is the *sun.* That is what I have been trying to draw since I was nine."
> ► **(Cover her eyes.)** — She flinches, then holds your wrist. **DESSA:** "Thank you. I think."
> ► **(Say the old rule: we don't follow lights we don't know.)** — **DESSA:** "I know it. I *know* it. Say it again."
> ► **(Sing her mother's song.)** — She sings with you. The light flickers, as if offended.

**Scene 4: the Gardens.** The skiff drifts into fields of green-blue sparks, and the light behind them is the right kind: dim, many, moving. Tilda sings her mother's lullaby. Slowly, from the fields, the algae glow brighter in time to the tune.

**DESSA:** "It's real. She wasn't *making it up.*"
**DESSA:** "Oh. I thought I'd mind that she was right."

**Coda: the borrowed skiff.** Before the player leaves, Tilda presses her notebook into their hands, open to a page of careful, hopeful coordinates.

**TILDA:** "Every captain said no. You said *which way.* I want you to have the map I made."
**TILDA:** "It is wrong in a dozen places. I would be glad if you corrected it."
> ► **"I'll bring it back marked."** — **TILDA:** "Then I will have to stay a season, won't I?"
> ► **"Keep it. Draw the next one."** — **TILDA:** "...Yes. That is better."
*Across the water, one boat-town lowers a lantern in greeting. It is the first that has done so for her.*

**Outcomes and receipt.**
- Tilda reaches the Gardens and the Gardens' keepers, who had watched from afar, invite her to stay a season. If she was left to look at the False Light unprompted, the passage costs her a day of sleep and a promise never to cross it alone.
- **Receipt:** a tune hummed back by the gardeners at the change of watch; a borrowed skiff returned with a small note: *"Thank you for the boat."*

<!-- quest
id: qst_hol_guide_dark
title: A Guide Across the Dark
rank: B
type: Escort
giver: npc_surveyor_dessa_dawnfield
region: reg_hollow_sea
level: 92
act: 4
requires_rank: B
reward: 10500 | 620 | 46000
sets: hol_guide_dark_done
summary: A surface-born surveyor wants to sing her mother's lullaby in the Glow Gardens. No captain will take her; the way passes within sight of the False Light.
objectives:
  talk npc_surveyor_dessa_dawnfield
  escort npc_surveyor_dessa_dawnfield
  reach hollow_sea_glow_gardens
  choice cover_rule_or_song
-->

---

## 4. The Glow Gardens Are Dimming

*B · Gathering · the Glow Gardens · giver Gardener Ombra Kelpwhistle*

**The short version.** The algae fields where the boat-towns fish are going dim, patch by patch. Ombra has sung to them for thirty years. Her voice is not enough any more.

**What is really going on.** The algae grow bright when they are sung to by *many different voices,* in rounds. Boat-towns have been staying home since the Lumen-Eater took two of their own, and the fields are lonely. The fix is to bring the songs back, and a spore-ring of living starter-algae from the deep fringe.

**Scene 1: the field.**

**OMBRA:** "Look at that. A dead patch. Grey as a drowned boot."
**OMBRA:** "I have sung to it. Morning, noon, night-watch. It does not answer."
**OMBRA:** "Every year the other towns sang with me. This year they stay in their own water. They are afraid. I do not blame them."
> ► **"Is it the Eater?"** — **OMBRA:** "It is the *fear* of the Eater, which is nearly as bad."
> ► **"What do you need?"** — **OMBRA:** "Starter-algae from the fringe. And voices."
> ► **"I'll fetch the starter."** — **OMBRA:** "Bring it in a wet cloth. Never in a jar. It sulks in glass."

**Scene 2: the fringe.** At the dark edge of the Gardens, where the light thins to nothing, the player gathers pale, hardy clumps of starter-algae from cold rocks, working by touch. A pale crab watches, unimpressed.

*(Gameplay: gathering; the player must carry each clump in wet cloth and avoid lights that are not the algae's, which is easy and slightly eerie.)*

**VOICE (from the dark, a call across the water):** "Whose boat?"
**YOU:** "Gardens work."
**VOICE:** "...Safe water, then."
*Out in the black, a lamp swings once, and is gone.*

**Scene 3: the rounds.** Back at the field, Ombra sets the starter in a ring and begins a four-note round. The patch glows a faint, sickly green. It needs more voices.

> ► **"I can sing."** — You are bad at it. The patch brightens anyway, a little, out of sympathy.
> ► **"I'll go fetch the other towns."** — A longer errand; three boats agree to come.
> ► **"Sing the round in four places at once."** — A clever trick with lashed horns; it half works.

**OMBRA:** "The algae do not mind *quality.* They mind *company.*"

**Scene 4: the Gardens return.** Over three watches, boats come, one and two and then seven, lashed at the edge, voices rising in the old rounds. By the third night the dead patch is a river of blue-green light. Ombra sits on a coil of rope and does not speak.

**OMBRA:** "I had forgotten it sounds like *this.*"

**Coda: the fringe-light.** On the last night, as the boats drift apart, a child on the nearest deck calls across the water.

**CHILD:** "Whose boat?"
**OMBRA (before you can answer):** "Gardens work! And she sings flat!"
**CHILD:** "Safe water, then!"
*Ombra grins in the dark. It is the old greeting, said to a stranger for the first time in a year, and the lamps along the Gardens' edge are, one by one, trimmed up to full.*
> ► **(Answer the child in the old words.)** — A small cheer from three decks.
> ► **(Hum the round.)** — The algae under the hull brighten with you.

**Outcomes and receipt.**
- The Gardens recover. If the player only brought the starter and sang alone, the patch recovers slowly and the other towns stay home another season.
- **Receipt:** a standing invitation, lamp hung at the Gardens' edge, *"Whose boat? Gardens work."* and a round named after the player's boat, if they used one.

<!-- quest
id: qst_hol_gardens_dim
title: The Glow Gardens Are Dimming
rank: B
type: Gathering
giver: npc_gardener_ombra_kelpwhistle
region: reg_hollow_sea
level: 94
act: 4
requires_rank: B
reward: 10800 | 640 | 46500
sets: hol_gardens_done
summary: The algae fields where the boat-towns fish are going dim. The gardener's voice is no longer enough.
objectives:
  talk npc_gardener_ombra_kelpwhistle
  collect hollow_sea_starter_algae 6
  choice sing_fetch_or_rounds
-->

---

## 5. The Ancestor Fish

*B · OddJob · a boat-town family hearth · giver Widow Selvi Quillfin*

**The short version.** Selvi's family has kept one glowing fish alive for nine generations. It is the family's ancestor-light. It is fading. She wants it kept.

**What is really going on.** The fish is old and dying of age, which is natural. It cannot be saved. What Selvi needs is to keep the *light,* not the fish, and to accept that the light and the ancestors are not the same thing. The player's part is to help her decide what "keeping" means.

**Scene 1: the jar.**

**SELVI:** "Nine generations. My husband's mother's mother's mother. Her light is in there."
**SELVI:** "Do not tell me it is a fish. I know it is a fish. I have fed it for fifty years."
**SELVI:** "It does not glow as it did. I would like it to glow until I go. After that I do not mind."
> ► **"Is it ill?"** — **SELVI:** "It is old. So am I."
> ► **"Can another fish carry the light?"** — **SELVI:** "That is what the town says. I do not like it."
> ► **"What would you like?"** — **SELVI:** "Time."

**Scene 2: the rounds of the town.** The player goes door to door asking the older families how their ancestor-lights are kept. A weaver keeps hers on a shelf above the bed. A boy keeps his in a bowl that he sings to. A cooper has let his go dark and keeps a ring of pale shell where it used to sit.

**COOPER:** "She went out at midwinter. I cried for a month. Then I put the shell where she was. She is in the shell now. Or in me. Or nowhere. I don't need to know."
> ► **"Did that comfort you?"** — **COOPER:** "It comforted me *that I was allowed to stop asking.*"
> ► **"What if the fish isn't the ancestor?"** — **COOPER:** "Then it is still a fish someone loved."

**Scene 3: the offer.** A navigator offers a hatchling from a clutch of the same lamp-fish, bred from the old one's line. Selvi will not look at it.

**SELVI:** "It is not *her.*"
**NAVIGATOR:** "It has her eyes."
**SELVI:** "Fish have the same eyes."
> ► **"It is not her. It is the next light."** — **SELVI:** "...Yes."
> ► **"Take your time."** — **SELVI:** "I have not much time to take."
> ► **"Let the old fish see the new one."** — A small, tender, strange thing.

**Scene 4: the meeting.** In the dark of Selvi's cabin, the two jars sit side by side. The old fish's light is a dim amber. The hatchling's is a bright, nervous blue. For a long moment neither moves. Then the old fish's glow warms, just once, and the hatchling's steadies.

**SELVI:** "She was a good fish."
**SELVI:** "She would have *liked* you."

**Coda: the shell.** A fortnight later the player is summoned back to Selvi's cabin. The old jar is dark and empty. In its place, on a folded scrap of sail, sits a pale shell.

**SELVI:** "She went in her sleep. Quietly. The way she did everything."
**SELVI:** "I thought I would feel she had gone out. I feel she has gone *round,* like a rope coming back to the cleat."
> ► **"Do you want company?"** — **SELVI:** "I have a hatchling that bites. I am well supplied."
> ► **"She had a good long light."** — **SELVI:** "She did. Nine generations of it. Sit; there is tea."

**Outcomes and receipt.**
- The old fish dies two weeks later, peacefully; the hatchling takes its place. If the player pushed Selvi to accept the hatchling at once, she does, but sits with the old jar until the end without speaking to either of you.
- **Receipt:** a second jar on the shelf; a small shell, set apart, where the first light used to burn.

<!-- quest
id: qst_hol_ancestor_fish
title: The Ancestor Fish
rank: B
type: OddJob
giver: npc_widow_selvi_quillfin
region: reg_hollow_sea
level: 96
act: 4
requires_rank: B
reward: 11000 | 640 | 47000
sets: hol_ancestor_fish_done
summary: A family has kept one glowing fish alive for nine generations, believing it holds its ancestors' light. It is fading.
objectives:
  talk npc_widow_selvi_quillfin
  reach hollow_sea_selvi_cabin
  choice time_next_or_meeting
-->

---

## 6. A Song for Saltlamp Row

*B · Delivery · between boat-towns · giver Songkeeper Dovan Echorill*

**The short version.** Songs in the Hollow Sea are the mail. A town's lullaby is its memory, and it must be delivered word-for-word. One town, Saltlamp Row, has lost all its lullaby-singers and wants its song back. Dovan has it. He cannot carry it alone.

**What is really going on.** The lullaby has a verse that the three living songkeepers each remember differently. Delivering it intact means agreeing on the verse, and the player must carry the verse between three keepers across black water.

**Scene 1: the songpost.**

**DOVAN:** "A song is cargo. It spoils if you shake it."
**DOVAN:** "Saltlamp Row lost its singers to the Eater in the spring. They have babies and no lullaby. I have the song. I do not trust my memory alone."
**DOVAN:** "There are two other keepers who know the Row's song. We three must agree on the third verse. I need a voice between us."
> ► **"What is wrong with the third verse?"** — **DOVAN:** "Nothing. It is *three* things."
> ► **"I'm a bad singer."** — **DOVAN:** "You do not need to be a singer. You need to be a *postman.*"
> ► **"I'll carry it."** — **DOVAN:** "Say it back to me."

**Scene 2: the three keepers.** On three different boat-towns, three keepers each hum the third verse. One has it rising, one falling, one with a long pause the others do not have.

**KEEPER OF LANTERN FORD:** "It rises. It always rose."
**KEEPER OF TWO LAMPS:** "It falls. My mother taught me. It falls like a baby going to sleep."
**KEEPER OF GREY MOORING:** "There is a pause. In the middle. Because the singer had to breathe, and she was always tired."
> ► **"Is there a way to hold all three?"** — The keepers glance at each other.
> ► **"Which is the original?"** — **KEEPER:** "Nobody knows."
> ► **"The pause is a good detail."** — **KEEPER OF GREY MOORING:** "Thank you." (This is a boat-town; saying thank-you is allowed.)

**Scene 3: the fitting.** In a rope-loft, in the dark, the player carries each keeper's version to the other two, humming and re-humming, until they find the shape that holds: the verse rises, pauses to breathe, and falls.

**DOVAN:** "That's not any one of the three."
**DOVAN:** "It is all three. It is the *real* one."
*(Gameplay: a humming puzzle; the player matches phrases by ear.)*

**Scene 4: Saltlamp Row.** The skiff slips into a small, dim cluster of boats. A mother rocking a baby at a window looks up. The songkeeper and the player sing the lullaby, all three verses, in the dark. The mother joins on the second line, voice cracking.

**MOTHER:** "That's how it goes. That's how it *goes.*"
*Behind her, lamp by lamp, every window of the Row lights.*

**Coda: the postmark.** On the ride home Dovan lets the player hold the songpost ledger and read the last line aloud.

**DOVAN:** "'*Saltlamp Row, third verse, delivered whole, carried by a postman who could not sing.*'"
**DOVAN:** "I have been keeper for thirty years. That is the best postmark I have written."
> ► **"The three keepers did the work."** — **DOVAN:** "They did. And you carried it between them. That is the work."
> ► **"I'll carry another."** — **DOVAN:** "There is always another. Learn to hum first."
*Behind them, across the water, a mother's voice, thin and sure, carries the first verse back into the dark.*

**Outcomes and receipt.**
- Saltlamp Row has its lullaby again. If the player chose one keeper's version over the others, the song arrives clean but the other two keepers refuse to carry it again.
- **Receipt:** a postmark in the songpost ledger, *"Delivered whole,"* with the player's name in the margin; the Row's babies fall asleep to the full song.

<!-- quest
id: qst_hol_saltlamp_song
title: A Song for Saltlamp Row
rank: B
type: Delivery
giver: npc_songkeeper_dovan_echorill
region: reg_hollow_sea
level: 98
act: 4
requires_rank: B
reward: 11300 | 660 | 48000
sets: hol_saltlamp_done
summary: Songs are the mail in the Hollow Sea. A boat-town that lost its singers wants its lullaby delivered whole, and the three keepers who know it disagree.
objectives:
  talk npc_songkeeper_dovan_echorill
  reach hollow_sea_saltlamp_row
  choice hold_all_pick_or_pause
-->

---

## 7. Night of the Loose Lashings

*A · Defense · the boat-town Seven Knots · giver Hull-Warden Sorrin Tarrow*

**The short version.** Seven Knots is a town of lashed boats, and tonight the lashings are failing. A swarm of ravenous eels has been drawn by the town's lamps. If the ropes go, the town comes apart in the dark.

**What is really going on.** The eels are not hunting the people. They are hunting the *light,* which is their kind of food. The hull-warden's fear is not the eels; it is that someone will panic and cut a boat loose. A boat cut loose is a boat lost.

**Scene 1: the lashings.**

**SORRIN:** "I know every rope in this town. I know when one is tired. Listen."
*A long, low groan from under the planks.*
**SORRIN:** "That is the third bow-line. She will hold four hours. Not five."
**SORRIN:** "The eels are at the lamps. We could douse the lamps. Then we are blind. Or we leave them lit, and the eels chew. I would like a third thing."
> ► **"What do the eels want?"** — **SORRIN:** "Light. Not meat. They have taken a taste for lamp-fish."
> ► **"What if we cut a boat loose?"** — **SORRIN:** "Then we have cut a *family* loose."
> ► **"Give me a rope."** — **SORRIN:** "Good. Start at the bow."

**Scene 2: the night.** A long defence, in the dark, over black water streaked with eel-light. The player splices ropes, holds a swinging boom, drives eels off with oars and thrown lamp-oil, and keeps the lashings taut.

*(Gameplay: wave defence; the player must keep at least five of seven lashing-points holding. Eels can be driven off, not exterminated.)*

**SORRIN (shouting):** "Port quarter! Lamp-fish, throw the *lamp-fish!*"
**ELDERLY WOMAN (from a cabin):** "Do not throw my husband's light!"

**Scene 3: the choice.** At the third watch, the town's two oldest boats begin to drag. If they go, the whole east flank goes with them.

> ► **(Cut the oldest boat loose.)** — The eels follow it. The town holds. A family is left adrift.
> ► **(Douse every lamp.)** — The eels scatter, and the town is blind for an hour. Two lashings snap.
> ► **(Lash a lantern-raft and tow it away.)** — The eels follow the raft, and the player must tow it out into the black alone.

**SORRIN:** "A raft. A *raft.* I should have thought of a raft."

**Scene 4: the dawn that isn't.** There is no dawn, only a grey brightening of the fish-light. Seven Knots is whole. The hull-warden, hoarse, walks the rail with his hand on every rope.

**SORRIN:** "Every one held."
**SORRIN:** "Every one. Even the tired ones."

**Coda: the inspection song.** At the next change of watch the hull-warden walks the rail one more time, and the player walks with him, and he sings the old inspection song under his breath, rope by rope.

**SORRIN:** "'*Bow-line, stern-line, spring and stay, hold till the glow comes round.*' It has eleven verses."
**SORRIN:** "Tonight I added a twelfth. It says *and a stranger spliced the third.*"
> ► **"Sing it for me."** — He does, gruff and tender, and the ropes seem to creak in time.
> ► **"Rest, warden."** — **SORRIN:** "When every rope has been touched. Not before."

**Outcomes and receipt.**
- Seven Knots holds. If the player cut a boat loose, its family drifts for three days before a patrol finds them, and the town does not speak of it. If the player towed the raft, it is lost, and a lamp-maker builds another.
- **Receipt:** a new rope, spliced into the bow-line in the player's colours; the hull-warden's inspection song gains a verse.
- No siege: the eels are a night's swarm, not an enemy, and the Lumen-Eater is not present.

<!-- quest
id: qst_hol_loose_lashings
title: Night of the Loose Lashings
rank: A
type: Defense
giver: npc_hull_warden_sorrin_tarrow
region: reg_hollow_sea
level: 124
act: 4
requires_rank: A
reward: 28000 | 1400 | 125000
sets: hol_lashings_done
summary: A swarm of lamp-hungry eels is chewing at the lashings of a boat-town. The hull-warden fears panic more than the eels.
objectives:
  talk npc_hull_warden_sorrin_tarrow
  defend hollow_sea_seven_knots
  choice cut_douse_or_raft
-->

---

## 8. Behind the Great Waterfall

*A · Exploration · the cave behind the Great Waterfall · giver Archivist Ruvane Undermere*

**The short version.** The oldest knot-records describe the first boats that came down the waterfall by accident, and a sound Ruvane has never heard. She wants to find the first boat's resting place behind the falls and learn what the sound was.

**What is really going on.** Behind the curtain of water is a long, drowned cave where the first boat came to rest. The sound in the knots was the *waterfall itself,* as heard by people who had never heard anything so loud. In the wreck is a lantern, still holding a flame that the first boat-folk carried down from the surface.

**Scene 1: the archive.**

**RUVANE:** "These knots are the oldest on any rope. They describe a sound. I have never heard it."
**RUVANE:** "Three long loops, one short, two hard turns. My teacher said: *rushing.* But nothing in the Hollow Sea *rushes.*"
**RUVANE:** "I think the first boat is behind the falls. I think the sound is there. I am too old to climb."
> ► **"What do you want brought back?"** — **RUVANE:** "Whatever remains. And the sound, if one can bring a sound."
> ► **"Why now?"** — **RUVANE:** "Because the Eater has taken two towns. I would like to hold something older than fear."
> ► **"I'll go."** — **RUVANE:** "Take oil and a rope. And a hat. It is wetter than you think."

**Scene 2: behind the water.** A long climb, hand over hand, through a gap in a curtain of thundering white. Behind it, a cave opens: wet black stone, rimmed with phosphorescent fungus, and, half-sunk in a pool, the keel of a boat older than any boat in the Sea.

**RUVANE (reading the knots aloud, from memory):** "Three long, one short, two hard. *Rushing.* There. That is what they meant."
*The roar of the falls fills the cave like a held breath. For the first time you understand the knots.*
> ► **(Touch the hull.)** — It is warm, as though still remembering hands.
> ► **(Listen to the falls.)** — You catch a rhythm in it; it sounds like breath.
> ► **(Look inside.)** — A cabin, dry, with a table set for six.

**Scene 3: the lantern.** In the cabin, on a hook, hangs a brass lantern with a flame no larger than a thumbnail, burning without oil. Six cups on the table. A child's boot. A book, its ink long gone.

**RUVANE (when you describe it back, by shell-whistle):** "...A flame. A real flame. Not a fish."
> ► **(Take the lantern to the archive.)** — The flame steadies, as if it knows the way.
> ► **(Leave it where it is.)** — The cabin is a grave of sorts; the flame stays.
> ► **(Light your own lamp from it.)** — A thin, warm light, the colour of a story you were told as a child.

**Scene 4: the return.** If the lantern is carried back, the flame is the first real fire the boat-towns have seen that was not oil. Ruvane sits with it a long hour.

**RUVANE:** "They kept it burning all the way down. For *three generations.* And then they let it be."
**RUVANE:** "They did not want us to follow it."

**Outcomes and receipt.**
- The first boat is recorded; the knots' sound is now understood. If the lantern is left, the archive records the cave as a place to visit, not to take from. The flame's nature is **not explained.**
- **Receipt:** a new knot in the archive, *"Rushing,"* tied by Ruvane with the player's name in the loop; a sound-shell in the player's pack that echoes the falls.

<!-- quest
id: qst_hol_behind_falls
title: Behind the Great Waterfall
rank: A
type: Exploration
giver: npc_archivist_ruvane_undermere
region: reg_hollow_sea
level: 126
act: 4
requires_rank: A
reward: 29000 | 1450 | 128000
sets: hol_behind_falls_done
summary: The oldest knot-records describe the first boat and a sound the archivist has never heard. It rests behind the Great Waterfall.
objectives:
  talk npc_archivist_ruvane_undermere
  reach hollow_sea_first_boat_cave
  choice take_leave_or_relight
-->

---

## 9. The Town That Sailed Up

*A · Investigation · the Great Waterfall · giver Elder Gwyn Tideless*

**The short version.** A generation ago, a boat-town tried to sail back up the waterfall and was never seen again. Gwyn's mother was aboard. A bottle has washed up at the foot of the falls.

**What is really going on.** The bottle holds a short note in her mother's hand. It does not say whether the town made it. It is a seed. **No answer is given in this quest about what became of them.** What the quest asks is whether Gwyn wants to be told.

**Scene 1: the elder's porch.**

**GWYN:** "I was nine. My mother said she would be gone a short while."
**GWYN:** "Seventy years. I have not been angry for most of them."
**GWYN:** "A child found a bottle at the foot of the falls. It has my mother's knot on the cork. I cannot read the note. My eyes are done."
> ► **"I will read it to you."** — **GWYN:** "Please."
> ► **"Do you want to hear it?"** — **GWYN:** "That is the question, isn't it."
> ► **"Where was it found?"** — **GWYN:** "At the very foot. Where the water hits."

**Scene 2: the foot of the falls.** The player is rowed to the spray-shrouded base, where the water crashes into black. Wedged in a rock, a few rotted ropes, a splinter of mast with a painted eye on it.

**ROWER:** "That is a Tideless mast. The eye is theirs."
**ROWER:** "Nothing else has come down. Nothing in seventy years. Until the bottle."
> ► **(Search the foam-line.)** — You find a second cork, empty.
> ► **(Touch the mast.)** — It is not wet. Not on the side that faces up.
> ► **(Look up the falls.)** — Mist; and, very far above, a faint paleness that might be only the cave's roof.

**Scene 3: the note.** Back on Gwyn's porch, the player unrolls a scrap of waxed sailcloth and reads it by lamplight, aloud.

**NOTE:** *"We are climbing. The rope holds. It is colder than we thought. The children sing to keep the rope warm. Tell Gwyn I am not afraid. Tell her I am almost"* — the rest is a smear.

**GWYN (after a long silence):** "Almost."
**GWYN:** "Almost *what.*"
> ► **"I don't know."** — **GWYN:** "No. Nor do I. It is a good word to leave open."
> ► **"They may have made it."** — **GWYN:** "They may. Do not say it as though it were so."
> ► **"I'm sorry."** — **GWYN:** "Don't be. I have waited seventy years for *almost.*"

**Scene 4: the porch.** Gwyn asks to keep the note, and the cork. She sits a while with them in her lap, then calls the neighbours, and, one by one, the Tideless family come out onto the planks, and she reads it again.

**GWYN:** "I am not angry any more. I wasn't, really. I was *waiting.*"
**GWYN:** "It is a different thing."

**Coda: the neighbours.** When the Tideless family gathers on the planks, a young cousin asks the question no one else has.

**COUSIN:** "If they were climbing, where were they climbing *to?*"
**GWYN:** "Up."
**COUSIN:** "And then?"
**GWYN:** "And then the note stops. Child, I have waited seventy years for a sentence that ends in the middle. I find I like it."
> ► **"Perhaps one day someone will finish it."** — **GWYN:** "Perhaps. I shall not rush them."
> ► **(Say nothing.)** — The cousin takes the cork gently from Gwyn's hand, turns it over, and gives it back.

**Outcomes and receipt.**
- The note is kept; the family holds a small memorial, and a new boat is named *Almost.* The fate of the town remains **unexplained.**
- **Receipt:** the cork on a cord around Gwyn's neck; a rope hung from the mast of every Tideless boat, one end loose, *"for climbing."*

<!-- quest
id: qst_hol_town_sailed_up
title: The Town That Sailed Up
rank: A
type: Investigation
giver: npc_elder_gwyn_tideless
region: reg_hollow_sea
level: 128
act: 4
requires_rank: A
reward: 30000 | 1500 | 130000
sets: hol_town_sailed_done
summary: A bottle bearing an old knot washes up at the foot of the Great Waterfall, seventy years after a boat-town tried to sail up it.
objectives:
  talk npc_elder_gwyn_tideless
  reach hollow_sea_waterfall_foot
  choice read_open_or_comfort
-->

---

## 10. A Light We Know

*A · Hidden · a boat-town deck · giver Dill Fernglow*

**The short version.** Dill, seven, has noticed that everyone is afraid of lights they do not know. Dill's idea is simple: do not meet strange lights alone. Meet them *properly,* with a name, a greeting and a friend.

**What is really going on.** Dill has a fish, Moth, that Dill has named, fed and sung to since it was a hatchling. When any light appears that is not Moth's, Moth goes dark. Dill believes this is a defence. It might be. It is also a very good habit. The player is asked to be the *friend,* and to test it, carefully, once.

**Scene 1: the deck.**

**DILL:** "This is Moth. Moth is a light I know."
**DILL:** "Everything else is a light I *don't.* I'm going to know more of them."
**DILL:** "You have to come. The grown-ups say no. It's a *rule.*"
> ► **"What's the rule?"** — **DILL:** "'We do not follow a light we have not been introduced to.' So. *Introduce* me."
> ► **"Is this safe?"** — **DILL:** "No. That's why you're coming."
> ► **"Where are we going?"** — **DILL:** "Just to the edge of the Gardens."

**Scene 2: the first light.** At the edge of the Gardens, a pale lamp-jelly drifts past. Dill kneels, holds up Moth, and says gravely:

**DILL:** "Hello. I'm Dill. This is Moth. Who are you?"
*The jelly pulses. It does not answer. It drifts on. Moth glows steadily.*
**DILL:** "That one's all right. It didn't ask me to follow."
> ► **"How do you know?"** — **DILL:** "Because it said *nothing.* The bad ones say *come.*"
> ► **"That's a good rule."** — **DILL:** "It's not a rule. It's *manners.*"
> ► **(Say nothing.)** — Dill nods approvingly.

**Scene 3: the other light.** Far off, low in the black, a warm yellow glow blooms. It is soft, steady and promising. It looks, to you, like the thing you would most like to see. Moth goes dark in Dill's hands.

**DILL (whispering):** "That's a bad one."
**DILL:** "Moth went out. Moth never goes out."
*The yellow glow does not pulse. It does not drift. It simply *waits,* the way a person waits at a door.*
> ► **(Cover Moth, and walk away.)** — The glow does not follow.
> ► **(Say, "Hello, I don't know you.")** — The glow flickers; Dill squeezes your hand hard.
> ► **(Turn the boat and sing.)** — Dill sings too, thin and fierce.

**Scene 4: the telling.** Back on the deck, Dill tells the captain. The captain, to everyone's surprise, listens.

**CAPTAIN:** "...The fish goes dark."
**CAPTAIN:** "Every town should have a child with a named fish."
*Within a week, three decks have lamp-fish with names.*

**Coda: the list of lights.** A week later Dill shows the player a long strip of sailcloth, covered in careful pencil.

**DILL:** "This is the list. Lights I know. There's Moth. And the Gardens. And the lamp on the bow. And the sound of the waterfall, which isn't a light, but I put it in."
**DILL:** "And there's *you.* Because you came when the grown-ups wouldn't."
> ► **"I'm honoured."** — **DILL:** "You're *noted.* It's better."
> ► **"What goes on the list next?"** — **DILL:** "Whatever introduces itself. Politely."
*Along the rail, three more small jars of named light wink in the dark.*

**Outcomes and receipt.**
- The town adopts a **named-light watch,** in which a named fish is kept at the bow, and a darkening of the fish marks an unknown light. It does not defeat or even reveal the Lumen-Eater, but it helps. If the player spoke to the glow, the Eater's light remembers the voice for a night.
- **Receipt:** a small brass tag on Moth's jar, *"A light I know;"* Dill adds your name to the list of lights.
- **Unexplained seed:** whether the named-fish defence is real or only a comfort. It works until it doesn't.

<!-- quest
id: qst_hol_light_we_know
title: A Light We Know
rank: A
type: Hidden
giver: npc_dill_fernglow
region: reg_hollow_sea
level: 132
act: 4
requires_rank: A
reward: 31000 | 1550 | 134000
sets: hol_light_known_done
summary: A seven-year-old believes the cure for the False Light is to meet strange lights properly, with a name and a friend.
objectives:
  talk npc_dill_fernglow
  reach hollow_sea_gardens_edge
  choice cover_greet_or_sing
-->
