# 11e-18 — Slow-Life Errands: Five Cozy Quests (draft)

> *"Not every day needs a dragon. Some days need soup."*

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Pattern file 8 of 8 ([[patterns_index]]; research in [[side_quests_inspiration_notes]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`.

**The pattern.** Small, kind errands for early ranks (F–E) that make a town feel lived in: a basket, a seed swap, a cake, a song, a roof. They borrow the idea of **gentle, low-stakes chores with a warm payoff**, and they feed Canon's **slow-life** afterstory (farming, shops, festivals, recovery). They are written for **Brindlewick and its neighbours**, so they can ship in Ring 1.

**Rules.** No combat. No timer. No fail state. The reward is *small* and the receipt is *a thing you can see in town.* Each is **under ten minutes.**

| # | Quest | Rank | Giver | What it adds to town |
|---|---|---|---|---|
| 1 | A Basket for the Bridge-Keeper | F | Marta Gruel | A friend at the Millbrook bridge |
| 2 | Seed Swap | F | Gilda Marsh | A shared garden behind the market |
| 3 | A Hum for the Koi | F | Old Sal | A song at the Millrace dock |
| 4 | A Cake for Tamsin | E | Hugo Brand | A birthday in the square |
| 5 | Roof Day | E | Miller Jory | A town that shows up |

## Cast

<!-- npc
id: npc_gorm_bridge_keeper
name: Gorm
tier: townsfolk
race: Troll
region: reg_whisperwood
settlement: The Millbrook bridge
role: Bridge-keeper
backstory: A very large, very gentle troll who keeps the Millbrook bridge, charges a toll of one story, and has not eaten a traveller in his life.
-->

---

## 1. A Basket for the Bridge-Keeper

*F · Delivery · the Millbrook bridge · giver Marta Gruel*

**The errand.** Marta presses a heavy basket into the player's arms. *"For Gorm. At the bridge. He doesn't eat what the travellers leave, and he won't say so."*

**Scene 1: the kitchen.**

**MARTA:** "Take this to the bridge. Warm bread, cheese, a jar of pickles. *Don't open it.* He'll know."
**MARTA:** "He's a troll. He's *very* polite about it. He says the bridge is his *job,* and the toll is a *story.* One. Not a *good* one. A *true* one."
**MARTA:** "Don't let him eat your boots. He's *joking.* Mostly."
> ► **"What if I don't have a story?"** — **MARTA:** "Everyone has one. Tell him about your first day."
> ► **"Is he dangerous?"** — **MARTA:** "He's a *lamb.* A very large lamb."
> ► **"I'll take it."** — **MARTA:** "Good. Mind the pickles."

**Scene 2: the bridge.** The old stone bridge arches over the Brindle. Beneath it, a mountain of grey moss turns, blinks, and unfolds into a troll, eleven feet of gentle, mossy bulk.

**GORM:** "Good day. The toll is one story. I do hope you've brought one."
**GORM:** "...Oh. *Marta's.* I can *smell* the bread."
> ► **"I've brought a basket."** — **GORM:** "That is *very kind.* The toll is still one story."
> ► **"My first day was strange."** — **GORM:** "*Splendid.*"
> ► **"Can I tell it after lunch?"** — **GORM:** "Of course. I'll put the kettle on."

**Scene 3: the story.** Over cheese and pickles, on a flat rock in the shade, the player tells the story of their first day. Gorm listens with great, quiet attention.

**GORM:** "A *strange* day. A *lucky* one."
**GORM:** "Thank you. I have been collecting these for forty years. They hang on the *inside* of the bridge."
*He shows the player the underside: a thousand scratched marks, each a traveller's story, in a tiny, patient hand.*

**Outcomes and receipt.**
- Gorm adds the player's story; he now greets them by name. If the player tells *no* story, he waves them through, perfectly happy.
- **Receipt:** a small mark under the bridge; Gorm hums when the player crosses.

<!-- quest
id: qst_pat_errand_basket
title: A Basket for the Bridge-Keeper
rank: F
type: Delivery
giver: npc_marta_gruel
region: reg_whisperwood
level: 3
act: 1
requires_flags: guild_registered
reward: 50 | 6 | 140 | itm_healing_herb
sets: pat_errand_basket_done
summary: Marta sends a basket to the Millbrook bridge-keeper, a troll whose toll is one true story.
objectives:
  talk npc_gorm_bridge_keeper
  choice tell_first_day_or_after_lunch
-->

---

## 2. Seed Swap

*F · Gathering · the market · giver Gilda Marsh*

**The errand.** It is Seed Swap Day in Brindlewick. Gilda has a sack of seeds, a list of neighbours and a very small cart. She needs a runner.

**Scene 1: the stall.**

**GILDA:** "Five households. Five kinds of seed. Each wants what the others have. *Nobody* will say so."
**GILDA:** "I'll haggle for fun. You *carry.* We'll do this in an hour."
> ► **"What do they want?"** — **GILDA:** "Fennick wants *poppies.* Hugo wants *wheat.* The widow wants *roses.* The baker's boy wants *pumpkins.* And Old Sal wants... *anything.*"

**Scene 2: the swap.** A cheerful, funny run through town, each household a mini-scene:
- **Fennick Reed** (herbalist): *"Poppies? For a *cough*? Of course. But take my sage, and the lavender."*
- **Hugo Brand** (baker): *"Wheat. Always wheat. But I'd trade for rye, if you've got it."*
- **Widow Aster** (candlemaker): *"Roses. For the Hall of Cards. Joren liked roses."*
- **Baker's boy:** *"Pumpkins! I'll trade a pumpkin for a pumpkin. Is that a trade?"*
- **Old Sal** (fisherman): *"Seeds? What would a fish do with seeds? ...Give me the shiny one."*

**Scene 3: the garden.** At dusk, the five households meet behind the market with a small patch of cleared ground. Seeds go in. Gilda hands the player a trowel.

**GILDA:** "A shared garden. *No one's.* Everyone's. That was the plan from the start."
**GILDA:** "I'm *terrible* at plans. This one came out."

**Outcomes and receipt.**
- Every household gets what it wanted *and* a little more. The shared garden is planted.
- **Receipt:** a small plot behind the market that blooms through the seasons; neighbours leave seeds in a tin.

<!-- quest
id: qst_pat_errand_seed_swap
title: Seed Swap
rank: F
type: Gathering
giver: npc_gilda_marsh
region: reg_aldmere
level: 3
act: 1
requires_flags: guild_registered
reward: 60 | 7 | 160 | itm_healing_herb
sets: pat_errand_seed_swap_done
summary: Seed Swap Day in Brindlewick. Five households want what the others have, and nobody will say so.
objectives:
  talk npc_gilda_marsh
  reach brindlewick_five_households 5
  choice plant_the_garden
-->

---

## 3. A Hum for the Koi

*F · OddJob · the Millrace dock · giver Old Sal*

**The errand.** Old Sal has been trying for forty years to coax a Rainbow Koi into the shallows. He has failed. He has a theory: *it likes a song.*

**Scene 1: the dock.**

**SAL:** "Forty years. I have *seen* her. Once a spring. She shimmers, and she is *gone.*"
**SAL:** "I think she wants a *hum.* A low one. I can't *hum.* My lizard-throat does a *rattle.*"
**SAL:** "You've a *human* throat. It does lovely things."
> ► **"What do I hum?"** — **SAL:** "Whatever you like. As long as it's *kind.*"
> ► **"Will she come?"** — **SAL:** "I don't *know.* That's the *fun.*"

**Scene 2: the hum.** At dawn, on the weathered planks of the dock, the player hums. A thin, uncertain tune. Nothing. Then a ripple. Then a shimmer of colour beneath the water.

*(Gameplay: a short, gentle rhythm-light moment; the player chooses a mood: calm, hopeful, tender.)*

**SAL:** (whispering) "...*She's here.*"
*A koi the colour of every sunset at once rises, circles the dock, and lays her head on the surface, listening.*
> ► **(Keep humming.)** — She stays.
> ► **(Hum louder.)** — She startles.
> ► **(Hum a different tune.)** — She lingers.

**Scene 3: the gift.** Before she goes, the koi leaves a single, shimmering scale on the dock.

**SAL:** "...She's never done that."
**SAL:** "Keep it. It's *yours.* It always *was.*"

**Outcomes and receipt.**
- The player's tune becomes the dock's morning hum; if the player hummed loudly, the koi returns the *next* spring.
- **Receipt:** a faint rainbow ripple at the Millrace each dawn; Sal hums, badly, and does not mind.

<!-- quest
id: qst_pat_errand_koi_hum
title: A Hum for the Koi
rank: F
type: OddJob
giver: npc_old_sal
region: reg_aldmere
level: 4
act: 1
requires_flags: guild_registered
reward: 50 | 6 | 150
sets: pat_errand_koi_hum_done
summary: Old Sal thinks a shy Rainbow Koi will come to a hummed song. He can't hum; the player can.
objectives:
  talk npc_old_sal
  reach brindlewick_millrace_dock_dawn
  choice calm_hopeful_or_tender
-->

---

## 4. A Cake for Tamsin

*E · OddJob · Brindlewick · giver Hugo Brand*

**The errand.** Tamsin turns ten next week. She has never had a cake. Hugo wants to bake one and needs three things from three places.

**Scene 1: the bakery.**

**HUGO:** "Ten years old. *Ten.* And no cake. I only found out because she mentioned it, quietly, like she was apologising."
**HUGO:** "I can bake. I can't *fetch.* I need honey from Millbrook, a vanilla pod from the herbalist, and a dozen *very* fresh eggs from Cobb Farm."
**HUGO:** "It has to be a *surprise.* She counts *everything.*"
> ► **"I'll fetch them."** — **HUGO:** "Bless you. *Quietly.*"
> ► **"What flavour?"** — **HUGO:** "Honey and vanilla. She said she likes things that smell like home."

**Scene 2: the three errands.** A short, charming trio of scenes:
- **Millbrook honey:** the beekeeper, Mistress Dunn, asks for a *rhyme.* The player supplies one.
- **Vanilla pod:** Fennick Reed hands it over with a lecture on *proper storage* and a wink.
- **Eggs from Cobb Farm:** Tilda Cobb (if the wolf quest was done) insists on a *dozen and one*, "for luck."

**Scene 3: the baking.** In the bakery at dawn, Hugo and the player bake. The kitchen smells of honey, butter and warmth. Hugo hums as he works.

**HUGO:** "Eleven candles. One for luck."
**HUGO:** "She'll *count* them. I'd like her to get an *extra.*"

**Scene 4: the party.** In the square, at noon, the orphans gather. Tamsin, arms folded, regards a very large cake with a very small candle. She counts the candles twice.

**TAMSIN:** "...There are *eleven.*"
**HUGO:** "One for luck."
**TAMSIN:** (very quietly) "...I've never had luck."
**TAMSIN:** "...Thank you."
*She blows them out. Behind her, even Brother Caspian is smiling.*

**Outcomes and receipt.**
- The cake is shared with the whole square; Tamsin keeps one candle, unlit, in a small box.
- **Receipt:** a small candle-stub on Tamsin's windowsill; Hugo bakes a cake for every orphan's tenth birthday.

<!-- quest
id: qst_pat_errand_cake
title: A Cake for Tamsin
rank: E
type: OddJob
giver: npc_hugo_brand
region: reg_aldmere
level: 10
act: 1
requires_flags: met_brother_caspian
reward: 220 | 16 | 650
sets: pat_errand_cake_done
summary: Tamsin turns ten and has never had a cake. Hugo needs honey, vanilla and eggs, and it must be a surprise.
objectives:
  talk npc_hugo_brand
  reach brindlewick_cake_ingredients 3
  choice host_the_party
-->

---

## 5. Roof Day

*E · OddJob · the mill · giver Miller Jory*

**The errand.** The mill roof has a hole. The rain is coming. Jory has a ladder, a hammer, and a dozen cousins who are *not* coming. He needs the whole town.

**Scene 1: the mill.**

**JORY:** "The roof. *Seven* leaks. The rain starts *tomorrow.* I'd do it myself, but I fell off the last ladder."
**JORY:** "Everyone says they'll help. Nobody comes."
**JORY:** "I need someone who can *ask.*"
> ► **"I'll ask."** — **JORY:** "Thank you. Don't *beg.*"
> ► **"How many do we need?"** — **JORY:** "A dozen. Or a *hundred.* It's a roof."

**Scene 2: the asking.** The player goes door to door. A string of small, funny scenes:
- **Brannoc Emberfist:** "Hammers? I've *thousands.* Weep with me first."
- **Marta Gruel:** "Lunch. I'll bring *lunch.* For *forty.*"
- **Captain Holt:** "I'll send two guards. They need the practice. *Climbing.*"
- **The Crimson Wolves:** "A *roof?* Fine. We'll show you how it's *done.*"
- **Old Hollis:** "I can't climb. But I can *yell.* Very well."

**Scene 3: Roof Day.** On a bright, noisy afternoon, the mill roof is a scrum of ladders, shouts and flying shingles. Everyone has a different method; nobody listens to anyone. At the end, the roof is *crooked,* gloriously, but *whole.*

**JORY:** "It's *leaning.*"
**MARTA:** "It's *cheerful.*"
**HOLLIS:** "Leave it. It'll *settle.*"

**Scene 4: the rain.** That night, the rain falls. In the mill, the town sits at long tables, eating Marta's soup, listening to the drum of rain on a roof they built.

**JORY:** (quietly) "...Not one leak."
**JORY:** "I'd forgotten what it sounded like. When *everyone* shows up."

**Outcomes and receipt.**
- The roof is mended; the town's *"Roof Day"* becomes a custom each autumn.
- **Receipt:** a crooked, beloved mill roof; a small plaque inside, with forty names.

<!-- quest
id: qst_pat_errand_roof_day
title: Roof Day
rank: E
type: OddJob
giver: npc_miller_jory
region: reg_aldmere
level: 10
act: 1
requires_flags: guild_registered
reward: 230 | 17 | 680
sets: pat_errand_roof_day_done
summary: The mill roof has seven leaks and the rain is coming. Jory needs the whole town, and someone who can ask.
objectives:
  talk npc_miller_jory
  reach brindlewick_mill_neighbours 5
  choice host_roof_day
-->
