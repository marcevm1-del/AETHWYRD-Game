# 11e-33 — The Great Labyrinth, Floors 1-40: Ten Side Quests (draft)

> *"A chalk mark means someone made it down. A crossed mark means they did not. Mind which you draw."*
> — Gazetteer, Great Labyrinth (Floors 1-40)

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the second regional set ([[side_quests_index]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`. ⚠️ **Spoilers (light):** quest 10 plants an unexplained seed.

**Region:** `reg_labyrinth_upper` (the Entrance Hall, the floors, the floor 30 safe town, the floor 40 ghost market). **Rank band:** the region's data band is F-C; these ten sit at **D (quests 1-5) and C (quests 6-10)**, the ranks the guild actually sends to the middle floors. **Tone:** part sport, part trade, part religion; crowded, funny, kind underneath.

**Placement notes.**
- **There is no Tyrant and no siege.** The guardians are the floor bosses on every tenth floor; they return after each reset, and no quest here depends on one. The Maze King is a rumour the guild does not post bounties on, and **no quest confirms or denies him.** The unnamed thing killing parties on floor 39 is not touched.
- Customs the quests rely on: a **chalk mark** at a stairway means someone made it down safely, a **crossed mark** means they did not; adventurers **pray to Vex before every descent** and never spend a party's luckiest coin; the halls **reset every week** (once a year in the grandparents' day, with a festival); prices **triple every ten floors**; the **dwarf barkeep of the Deep Pint** (floor 30) outranks most barons; **kobold salvagers** trade in lost gear; the floor 40 **ghost market** is paid in stories and holds a nightly wake that newcomers are expected to attend.
- Monsters here do not eat, breed or age, and respawn where they fall; the quests treat them as weather, not villains. Rewards follow the D and C rows of `Data/World/guild_ranks.json` and the neighbouring C-rank quests (Velmark, Xochitl Mire).

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | The Crossed Chalk | D | Investigation | Bell-Warden Gerta Dunnock | Mystery: someone is crossing living names |
| 2 | Carry the Lamp | D | OddJob | Dessa Wrenfield | Comic-warm: a rookie and a hazing |
| 3 | Reset Day | D | Faction | Odalys Reedwhistle | Nostalgic: a festival nobody holds |
| 4 | A Cask for the Quiet Floor | D | Delivery | Brannoch Stoutbelt | Warm: ale for a wake |
| 5 | Lost and Found | D | Escort | Tik Ashgleam | Tender: a kobold, a dead stranger's pack |
| 6 | The Spring Under Siege | C | Defense | Springkeeper Ilsabet Rue | Action: slimes at the clean water |
| 7 | First Descent | C | Escort | Healer Wynne Harrowgate | Gentle: a healer afraid of the stairs |
| 8 | Paid in Stories | C | Hidden | Tam Ledgerwick | Eerie-warm: a market of the dead |
| 9 | A Letter for the Surface | C | Delivery | Hostess Lenore Hartsong | Bittersweet: a ghost's last errand |
| 10 | The Map of a Floor That Isn't | C | Exploration | Skritch Cindertoe | Strange: an unexplained seed |

## Cast

<!-- npc
id: npc_gerta_dunnock
name: Bell-Warden Gerta Dunnock
tier: major
race: Human
region: reg_labyrinth_upper
settlement: The Entrance Hall
role: Keeper of the rescue bell
backstory: A broad, tired woman who has rung the Entrance Hall's rescue bell for twenty years and knows every name on the chalk-mark ledger by the sound of its owner's boots.
-->
<!-- npc
id: npc_dessa_wrenfield
name: Dessa Wrenfield
tier: townsfolk
race: Human
region: reg_labyrinth_upper
settlement: The Entrance Hall
role: Rookie adventurer
backstory: A sixteen-year-old rookie from a salt farm who has been told by three separate parties that she must prove herself with the Lamp, and who has no idea what that means.
-->
<!-- npc
id: npc_odalys_reedwhistle
name: Odalys Reedwhistle
tier: townsfolk
race: Human
region: reg_labyrinth_upper
settlement: Floor 30 safe town
role: Retired porter
backstory: A seventy-year-old porter who carried packs down the Labyrinth for forty years and remembers the one yearly reset, when the whole Entrance Hall closed to dance.
-->
<!-- npc
id: npc_brannoch_stoutbelt
name: Brannoch Stoutbelt
tier: major
race: Dwarf
region: reg_labyrinth_upper
settlement: Floor 30 safe town
role: Barkeep of the Deep Pint
backstory: The dwarf who keeps the bar on floor thirty, a gruff, exact brewer whose word settles disputes that barons cannot, and who has never once sold a bad cask.
-->
<!-- npc
id: npc_tik_ashgleam
name: Tik Ashgleam
tier: townsfolk
race: Kobold
region: reg_labyrinth_upper
settlement: The upper floors
role: Dungeon-born kobold salvager
backstory: A small, quick kobold of the salvage trade who recovers lost gear for a fee and has a private rule never to sell what has a name on it.
-->
<!-- npc
id: npc_ilsabet_rue
name: Springkeeper Ilsabet Rue
tier: major
race: Human
region: reg_labyrinth_upper
settlement: Floor 30 safe town
role: Keeper of the floor 30 spring
backstory: A wiry former healer who keeps the clean spring of floor thirty and thinks of it, with some embarrassment, as a patient.
-->
<!-- npc
id: npc_wynne_harrowgate
name: Healer Wynne Harrowgate
tier: townsfolk
race: Human
region: reg_labyrinth_upper
settlement: The Entrance Hall
role: Temple healer, newly licensed
backstory: A gentle temple healer who has patched a thousand returning adventurers at the Entrance Hall and has never gone down the first stair herself.
-->
<!-- npc
id: npc_tam_ledgerwick
name: Tam Ledgerwick
tier: major
race: Spirit
region: reg_labyrinth_upper
settlement: Floor 40 ghost market
role: Ledger-keeper of the ghost market
backstory: A dry, courteous ghost who keeps the ghost market's books of stories and who was a customs clerk in life and has not noticed the difference.
-->
<!-- npc
id: npc_lenore_hartsong
name: Hostess Lenore Hartsong
tier: major
race: Spirit
region: reg_labyrinth_upper
settlement: Floor 40 ghost market
role: Hostess of the ghost market
backstory: The elegant ghost hostess of the floor forty market, who greets every living guest by name and has one unfinished letter she cannot carry herself.
-->
<!-- npc
id: npc_skritch_cindertoe
name: Skritch Cindertoe
tier: townsfolk
race: Kobold
region: reg_labyrinth_upper
settlement: The upper floors
role: Kobold map-seller
backstory: A brisk, honest kobold map-seller who has been selling the same inaccurate maps for years and is badly shaken by one that turned out to be accurate.
-->

---

## 1. The Crossed Chalk

*D · Investigation · the Entrance Hall and the stairways · giver Bell-Warden Gerta Dunnock*

**The short version.** Someone is drawing crossed marks over the chalk of parties who made it down safely. Families see the cross, ring the rescue bell, and then the party walks out alive and furious. The rescue teams, already thin, are being sent after people who are fine.

**What is really going on.** The culprit is Wystan Gantry, a retired porter with a bad knee who sits at the third-floor stairway. He crosses the marks of parties he believes are *too green for where they are going.* He wants them turned back by their own families. He is wrong about some and right about more, and he is lonely, and he has never once been thanked for the porters he did not lose.

**Scene 1: the bell.**

**GERTA:** "Four rescue teams out this week for parties who were *having lunch.*"
**GERTA:** "Every cross is the same hand. A heavy stroke, left to right, like someone who learned to write on a ledger."
**GERTA:** "I can't post a guard on every stair. I can post *you.*"
> ► **"Could it be a prank?"** — **GERTA:** "Pranks are funnier. This one *hurts* people."
> ► **"What do the families say?"** — **GERTA:** "They stop sleeping."
> ► **"I'll watch the stairs."** — **GERTA:** "Bring a stool. It's a long job."

**Scene 2: the stairs.** For two resets the player watches the third and fourth stairways, past the rookies who bounce down in loud parties and the veterans who nod to the chalk. On the second night a small figure in a patched coat shuffles to the landing, kneels with difficulty, and draws one long, deliberate cross over a fresh mark.

**WYSTAN:** (not looking up) "Don't say it. I know what it looks like."
**WYSTAN:** "That party was seven days into the Labyrinth with *one* healer who'd never held a staff. I carried packs down here forty years. I've seen what that mark means when it's *true.*"
> ► **"You're frightening families."** — **WYSTAN:** "Better a fright than a funeral."
> ► **"Do you cross every mark?"** — **WYSTAN:** "Only the ones I can't bear to see go on."
> ► **"Who taught you to read a party?"** — **WYSTAN:** "Nobody. I just carried the bodies up."

**Scene 3: the choice.** Wystan is not cruel, only certain. The player can take him to the Bell-Warden, which ends the crossing but shames an old man in the hall; or can sit with him and find a gentler form of what he is trying to do.

> ► **(Report him.)** — Gerta fines him and bans him from the stairs. The crossing stops. Wystan stops coming to the Hall at all.
> ► **(Propose a third mark.)** — A small dot beside the chalk: *turn back and talk to Wystan.* Gerta and the porters agree to try it.
> ► **(Cross his mark out for him.)** — A half-measure the player will regret when the next family rings the bell.

**Scene 4: the dot.** If the dot is chosen, a green party stops at the landing a week later, reads the little mark, and goes to sit with an old porter who tells them, bluntly and kindly, which stairs to leave alone. Two of the four come back with Wystan's name on a rope-cord. Gerta rings the bell once, for no one.

**GERTA:** "No rescue this week."
**GERTA:** "First week in two years."

**Outcomes and receipt.**
- The crossing ends. If the player reported Wystan, the rescue teams rest and the stairway feels emptier. If the dot was adopted, Wystan becomes the Hall's informal first-floor adviser and the dot becomes standard.
- **Receipt:** a small chalk dot at the third stairway, kept up by a stool-sitting porter; Gerta's ledger gains a column headed *Told.*

<!-- quest
id: qst_lab_crossed_chalk
title: The Crossed Chalk
rank: D
type: Investigation
giver: npc_gerta_dunnock
region: reg_labyrinth_upper
level: 36
act: 2
requires_rank: D
reward: 1400 | 85 | 5800
sets: lab_chalk_done
summary: Someone is crossing the chalk marks of living parties, and the rescue teams keep marching out to find them at lunch.
objectives:
  talk npc_gerta_dunnock
  reach labyrinth_third_stairway
  choice report_dot_or_cross
-->

---

## 2. Carry the Lamp

*D · OddJob · the Entrance Hall · giver Dessa Wrenfield*

**The short version.** A sixteen-year-old rookie has been told by three different parties that she must "carry the Lamp" before anyone will let her into a real run. Nobody will tell her what it means. She is too proud to ask a fourth time.

**What is really going on.** *Carry the Lamp* is the Labyrinth's oldest hazing. The rookie carries a lit oil lamp, with no spare, down to the first guardian floor's door and back, in the dark, while veterans follow at a distance making unpleasant noises. It is meant to teach that a lamp is a life. The tradition has curdled: last season a boy spilled the oil, got burned and left the trade. Dessa wants to do it properly. The veterans want to do it *loudly.*

**Scene 1: the hall.**

**DESSA:** "They said: 'carry the Lamp.' I said: 'which lamp.' They *laughed.*"
**DESSA:** "I'm not scared of monsters. I'm scared of looking stupid in front of monsters."
**DESSA:** "Will you carry my spare, and say nothing?"
> ► **"What do you know about the Lamp?"** — **DESSA:** "That it's lit. That's all."
> ► **"I'll find out what it is."** — **DESSA:** "Don't tell me. Tell me *after.*"
> ► **"You don't have to do it."** — **DESSA:** "Then I'm a rookie forever."

**Scene 2: the veterans.** At the board, a loud knot of veterans cheerfully explain the Lamp, with enthusiasm and no safety. One of them, a heavy swordswoman named Prue, admits under pressure that the lamp is "traditionally topped off with a bit of oil, nothing to worry about," and that the burned boy "just wasn't careful."

**PRUE:** "It's a *rite.* Everybody did it."
**PRUE:** "I cried the whole way. Best night of my life."
> ► **"A boy was burned."** — **PRUE:** "...That wasn't the *rite.* That was an accident."
> ► **"Teach her properly."** — **PRUE:** "Properly's no fun."
> ► **"Let her carry it. We'll follow."** — **PRUE:** "Now you're talking."

**Scene 3: the walk.** The player walks behind Dessa down the first long corridor, the hand-lamp a small gold dot ahead. Behind them, the veterans do their noises: boot-scrapes, a distant roar, a very bad cry of "ghost!" Dessa's hands shake. She does not stop.

**DESSA:** (whispering) "That's *Prue.* I know the cough."
**DESSA:** "I'm going to pretend I don't."
At the guardian floor's door, she sets the lamp down on the threshold, sits beside it and looks at the flame for a long moment.
**DESSA:** "It's only a *lamp.* It's the only thing down here that's *mine.*"
> ► **(Sit with her.)** — She is quiet, then grateful.
> ► **(Tell the veterans to stop.)** — The noises stop, a little ashamed.
> ► **(Let her finish alone.)** — She does, and is prouder for it.

**Scene 4: the return.** Back at the Hall the veterans, subdued, set out a table. Prue hands Dessa a coin: her old luckiest coin, never spent. The player is asked to put it in Dessa's purse.

**PRUE:** "First coin. Don't spend it. It's the only rule."

**Afterword: the table.** Late that night the player finds Prue alone at the board, turning her old coin over. "I cried the whole way," she says again, more quietly. "Nobody ever told me it was allowed to be scary *and* kind." She asks, awkwardly, whether the player thinks the rite could keep the lamp and lose the noise. The player can say yes, and mean it, or say it is not their rite to change. Either way, the next rookie will find the board a little warmer.

**Outcomes and receipt.**
- Dessa carries the Lamp and joins a party. If the player confronted the veterans, they quietly change the rite to *carry a lamp and a spare* and drop the noises; if not, the rite stays loud but Dessa is kept safe.
- **Receipt:** a small lamp hung over the board, lit at the start of every rookie's first descent; Dessa's luckiest coin in her purse.

<!-- quest
id: qst_lab_carry_lamp
title: Carry the Lamp
rank: D
type: OddJob
giver: npc_dessa_wrenfield
region: reg_labyrinth_upper
level: 39
act: 2
requires_rank: D
reward: 1500 | 90 | 6100
sets: lab_lamp_done
summary: A rookie must carry the Lamp before anyone will take her on a real run, and nobody will say what that means.
objectives:
  talk npc_dessa_wrenfield
  reach labyrinth_first_guardian_door
  choice sit_stop_or_alone
-->

---

## 3. Reset Day

*D · Faction · floor 30 safe town · giver Odalys Reedwhistle*

**The short version.** In Odalys's youth the Labyrinth reset only once a year, and the whole Entrance Hall closed and danced. Now it resets every week and nobody stops. She wants a small festival at the weekly reset, a single hour of music. The guild board says it will "lose a day of hours."

**What is really going on.** The weekly reset is a nuisance to everyone but its cause. Odalys is not asking for a holiday; she is asking for a *pause,* an hour in which no one is in a run or a rush. The board's resistance is mostly habit, and one clerk's fear of precedent. The player carries her petition between the safe town's tavern, the porters' bench and the guild board.

**Scene 1: the spring bench.**

**ODALYS:** "There was a *band.* A fiddler on a barrel. Everyone in the hall dancing, even the guardians, I swear, you could hear them tapping."
**ODALYS:** "Then it began resetting weekly, and nobody had time to dance."
**ODALYS:** "I'd like an hour. Just one."
> ► **"What do the others say?"** — **ODALYS:** "That it's *sentimental.* It is."
> ► **"Who runs the board?"** — **ODALYS:** "A man who keeps his boots in a drawer."
> ► **"I'll carry the petition."** — **ODALYS:** "Bring me a signature. I'll bring the tea."

**Scene 2: the petition.** The player collects names, a hard job in a place of rushing people. The Deep Pint signs at once, the porters sign cautiously, the healers sign for a free hour. Several veteran parties refuse, one with a laugh, one with a sigh and a signature on the back.

**VETERAN:** "An hour of lost loot."
**PORTER:** "An hour of *breath.*"
> ► **"It costs one hour."** — The veteran shrugs.
> ► **"It's for the ones who don't come back."** — The veteran signs, quietly.
> ► **"I'll take your hour's loot as a fee."** — A bargain, and a fair one.

**Scene 3: the board.** The guild clerk, Pruett, receives them in a cell of ledgers.

**PRUETT:** "A festival is a *precedent.* Next it's a feast, then a *fast.*"
**ODALYS:** "I'm seventy. I'll risk it."
**PRUETT:** (a long pause) "...The hour after dawn, the first reset day of the month. No *drums.*"
> ► **"Drums are half of it."** — **PRUETT:** "Then one drum."
> ► **"Accept the compromise."** — The clerk is relieved.
> ► **"Hold out for weekly."** — **PRUETT:** "Then *nothing.*"

**Scene 4: the hour.** On the first morning of the month, as the Labyrinth resets with a low, familiar groan, the Hall empties its rush into a single, awkward hour of music. A fiddler on a barrel. One drum. Parties who have never met dance badly. In the middle, Odalys, with a tin mug, taps her foot.

**ODALYS:** "...There. *That's* it."

**Afterword: the bench.** Odalys does not stay for the whole hour. She sits on the edge of the Hall with her tin mug, watching strangers dance badly, and says, to nobody in particular, that her husband used to step on her feet in exactly this way. "Forty years carrying packs," she tells the player, "and the best thing I ever carried out of here was that tune." Pruett, standing stiffly beside her, has been seen to tap one finger against his ledger in time.

**Outcomes and receipt.**
- A monthly Reset Hour is granted. If the player held out for weekly, the guild refuses everything and Odalys holds her hour in the safe town, unofficially, with three hundred people instead of thirty.
- **Receipt:** a fiddle hung on the Hall wall, taken down once a month; Odalys's tin mug, kept by the Deep Pint.

<!-- quest
id: qst_lab_reset_day
title: Reset Day
rank: D
type: Faction
giver: npc_odalys_reedwhistle
region: reg_labyrinth_upper
level: 43
act: 2
requires_rank: D
reward: 1650 | 98 | 6700
sets: lab_reset_day_done
summary: An old porter wants one hour of music on the weekly reset, as the Hall once danced when the Labyrinth reset only once a year.
objectives:
  talk npc_odalys_reedwhistle
  reach labyrinth_guild_board
  choice compromise_or_hold_out
-->

---

## 4. A Cask for the Quiet Floor

*D · Delivery · floor 30 to floor 40 · giver Brannoch Stoutbelt*

**The short version.** Brannoch brews one cask a year for the ghost market's wake: a dark, bitter ale the dead cannot taste but like to smell. This year's cask is ready, and every porter who could carry it has refused. The stairs between floor thirty and forty are long and the cask is heavy.

**What is really going on.** The cask is not why porters refuse. It is where the brew goes: the ghost market, where the living are *guests* and a wake is held nightly. A cask carried to a wake is a gift to the dead, and a gift must be carried by someone willing to sit through it. The porters are not scared of ghosts. They are scared of being *asked to remember someone.*

**Scene 1: the Deep Pint.**

**BRANNOCH:** "One cask a year. Forty-one years. Never sold a pint of it."
**BRANNOCH:** "The dead like to *smell* a good brew. It reminds them what they're missing."
**BRANNOCH:** "I can't leave the bar. Take it down, pour it at the wake, drink *one* mug, and don't be sentimental about it."
> ► **"Why won't the porters go?"** — **BRANNOCH:** "They'd have to *stay.*"
> ► **"Is it heavy?"** — **BRANNOCH:** "Dwarf-heavy. You'll live."
> ► **"I'll take it."** — **BRANNOCH:** "Don't spill. Or I'll know."

**Scene 2: the stairs.** Ten floors of grey stairway, the cask on a sling. The player passes a flooded gallery, a collapsed vault, a bored slime on every landing. On the thirty-seventh floor a little group of adventurers asks politely for a sip. A rookie is crying quietly on a stair.

**ROOKIE:** "My brother's name's going to be called at the wake tonight. I'm not ready to hear it."
> ► **"Come with me."** — **ROOKIE:** "...I can't."
> ► **"Have a mug."** — **ROOKIE:** "It's not mine to drink."
> ► **"I'll stand beside you."** — **ROOKIE:** "...All right."

**Scene 3: the wake.** The ghost market after dark is a street of paper lanterns and quiet counters. At a long table, the dead sit with their backs to the living guests, facing a wall of unlit candles. Tam Ledgerwick, a dry ghost in a clerk's cuffs, receives the cask.

**TAM:** "Stoutbelt's cask. At last."
**TAM:** "We'll not drink it. But we'll sit with it. That's the toast."
Names are called, one by one, from a ledger, and for each a candle lights.
> ► **(Pour at each name.)** — A mug for every candle.
> ► **(Pour one mug and stay.)** — Brannoch's instruction, kept.
> ► **(Pour for your own dead.)** — The player adds a name.

**Scene 4: the return.** At the top of the stairs, if the rookie came, they carry an empty mug home. The cask, empty, returns to Brannoch, who weighs it without comment and fills the player's mug with something warmer.

**BRANNOCH:** "...Lit?"
**BRANNOCH:** "All the candles?"
**BRANNOCH:** "Good. Drink. *Don't* be sentimental."

**Afterword: the mug.** Back at the Deep Pint, Brannoch will not take thanks. He wipes the same mug three times and asks only one thing: what the ghosts did when the candles were lit. If the player says they smiled, the dwarf nods slowly and goes to the cellar. When he returns he carries a second, smaller cask and sets it aside without a word. "For next year," he mutters. "Don't tell anyone I was moved."

**Outcomes and receipt.**
- The wake is served. If the rookie came, her brother's candle is lit with the others and she is welcome at the Pint for free. If the player spilled the cask on the stairs, Brannoch brews a second batch that takes a year.
- **Receipt:** a mug on the Deep Pint's shelf with the player's name; a ghost-market candle lit in their colour.

<!-- quest
id: qst_lab_quiet_cask
title: A Cask for the Quiet Floor
rank: D
type: Delivery
giver: npc_brannoch_stoutbelt
region: reg_labyrinth_upper
level: 47
act: 2
requires_rank: D
reward: 1800 | 105 | 7200
sets: lab_cask_done
summary: A dwarf brews one cask a year for the ghost market's wake, and no porter will carry it down.
objectives:
  talk npc_brannoch_stoutbelt
  reach labyrinth_ghost_market_wake
  choice pour_stay_or_name
-->

---

## 5. Lost and Found

*D · Escort · the upper floors · giver Tik Ashgleam*

**The short version.** A kobold salvager wants an escort to floor fourteen, where she has found a dead adventurer's pack with a name sewn inside. She never sells what has a name on it. She wants to bring it home, and the nearest road is a day of corridors she does not trust alone.

**What is really going on.** The pack belongs to a young man, Corwen Marlow, who went down eleven years ago and was crossed out on the Hall's ledger. His mother still lights a candle each reset. In the pack: a half-written letter, a pressed flower, and a sealed coin of the kind a party never spends. The salvager's conscience is the only thing standing between the pack and a collector who would pay for the coin.

**Scene 1: the gear trade.**

**TIK:** "Everything down here has a price. Boots, rope, rings, teeth."
**TIK:** "*Names* don't. A name's a *debt.*"
**TIK:** "I found a pack. It's got a name. I'd like to carry it home. I'd like *not to be eaten on the way.*"
> ► **"Can you read the name?"** — **TIK:** "C-O-R-W-E-N. M-A-R-L-O-W. I had a cousin teach me letters."
> ► **"Why not sell it?"** — **TIK:** "Rules. Mine."
> ► **"I'll escort you."** — **TIK:** "Good. Walk slow. I have short legs."

**Scene 2: the corridors.** The two walk down fourteen floors of echoing grey stone, past a bat colony, a fungus garden that releases a sour cloud and a gallery flooded to the knee. Tik is shrewd, funny and entirely unarmed. The player guards her across a bridge of fallen pillars where a pair of skeletons patrol.

**TIK:** "I like that you don't shout."
**TIK:** "Shouting wakes the walls."
At floor fourteen, in an alcove, the pack: a leather bag, a broken sword hilt and a small cairn of stones someone built over it long ago.
> ► **"Someone buried him."** — **TIK:** "Someone *tried.*"
> ► **"Read the letter."** — **TIK:** "It's his."
> ► **"Take the pack."** — **TIK:** "Gently."

**Scene 3: the letter.** The half-written letter is short: *"Mam, I made it to floor fourteen. It's not so bad. I met a kobold who gave me a half-rope. I'm going to go on. I'll write when I'm back up."* The coin is sealed in a wrap of cloth.

**TIK:** (very quietly) "...That's *me.* The rope. I gave a boy a half-rope, once. I never knew his name."
> ► **"Take it home."** — **TIK:** "Yes."
> ► **"Keep the coin; sell it."** — **TIK:** "*No.*"
> ► **"Leave the letter with her."** — **TIK:** "Of course."

**Scene 4: the door.** On the surface, in a lane behind the Hall, an old woman opens a door. Tik hands her the pack and the letter.

**MAM:** "...He wrote."
**MAM:** "Eleven years. He *wrote.*"
She holds the coin up to the light and does not spend it.

**Afterword: the rope.** Tik walks back down alone, which the player has been told is foolish and which she insists is not. At the first landing she ties a half-rope to the railing, the kind she once gave a nervous boy, and pats the knot twice. "Salvage rule," she says to the player's look. "Everything that can be given back should be given back at least once." Then she is gone down the stairs, small and quick, whistling something with no tune.

**Outcomes and receipt.**
- The pack is returned. If the player urged Tik to sell the coin, she refuses, and trusts the player a little less. If the player read the letter aloud, the mother asks them to read it again.
- **Receipt:** Corwen Marlow's name added back in chalk to a quiet stairway; Tik leaves a half-rope tied to the Hall's railing for any boy who needs one.

<!-- quest
id: qst_lab_lost_found
title: Lost and Found
rank: D
type: Escort
giver: npc_tik_ashgleam
region: reg_labyrinth_upper
level: 52
act: 2
requires_rank: D
reward: 2000 | 115 | 8000
sets: lab_lost_found_done
summary: A kobold salvager who never sells anything with a name on it needs an escort to bring a dead boy's pack home.
objectives:
  talk npc_tik_ashgleam
  escort npc_tik_ashgleam
  choice return_sell_or_read
-->

---

## 6. The Spring Under Siege

*C · Defense · floor 30 safe town · giver Springkeeper Ilsabet Rue*

**The short version.** The floor thirty spring is the only clean water for eleven floors. Slimes, which the spring's warm mineral smell attracts, have started to pool in it. Ilsabet does not want them dead. She wants them out, without a fight that fouls the water.

**What is really going on.** The slimes are not hunting. They are *thirsty,* which is a strange thing for a dungeon-born creature. The spring is slowly changing them: the ones that touch it settle, stop moving, and pulse faintly like heartbeats. Ilsabet thinks of the spring as a patient and the slimes as a symptom. The player has one night and one lantern.

**Scene 1: the spring.**

**ILSABET:** "I was a healer for twenty years. Then I took the spring. It's the same job."
**ILSABET:** "You don't *fight* a symptom. You find what it's saying."
**ILSABET:** "Three hundred slimes since dusk. They're drinking, not hunting. I'd like to know *why.*"
> ► **"Can we just kill them?"** — **ILSABET:** "Their bodies would foul the water for a month."
> ► **"What do they want?"** — **ILSABET:** "To be near it."
> ► **"I'll hold the east pool."** — **ILSABET:** "Don't use fire."

**Scene 2: the night.** *(Gameplay: wave defense; the player guards three pools of the spring against slime surges using water-barriers and nets, without destroying any slime near the water.)* The slimes push gently, not angrily, in slow blue waves. Ilsabet runs the lines with a laundry paddle. A grumpy porter nearby offers advice that is, for once, helpful.

**PORTER:** "Move them with *light.* They hate the glare."
**ILSABET:** "Lantern line. *Now.*"
The slimes withdraw, and gather again.
> ► **"Lead them away with light."** — It works, slowly.
> ► **"Build a second pool for them."** — A bold plan.
> ► **"Fight them off."** — The water darkens.

**Scene 3: the second pool.** Near dawn, in a side cavern, the player and Ilsabet scoop a shallow basin and fill it with a bucket-chain from the spring, a hundred hands on a hundred buckets. The slimes, sensing the water, flow toward it in a slow, shining stream and settle there, gently pulsing.

**ILSABET:** "They don't want to *drink* it. They want to *be near it.*"
**ILSABET:** "Everyone does."

**Scene 4: the morning.** The first reset after the night brings the slimes back, but they do not return to the spring; they go to the basin, and the porters leave them be. A hand-lettered sign goes up: *Slime Pool. Do Not Poke.*

**Afterword: the paddle.** In the grey hour after dawn Ilsabet sits on the spring wall with her feet in the water and a cold cup of tea, looking unusually pleased with herself. "I spent twenty years telling people the body will heal if you stop shouting at it," she says. "Turns out a spring is the same." She asks the player to sign the little board that hangs by the basin. Beneath the sign that reads *Do Not Poke* someone has already scrawled, in a child's hand: *But gently, if you must.* By the next reset the basin has a bench, a bucket of lanterns and a regular visitor: a porter who sits beside it every evening and tells the slimes about his day, as if they were old friends.

**Outcomes and receipt.**
- The spring runs clean. If the player fought the slimes, the water is foul for a month and Ilsabet closes the safe town to casual visitors. If the player built the pool, the safe town gains a quiet, glowing nook children visit at dusk.
- **Receipt:** a small blue basin glowing in the side cavern; Ilsabet's laundry paddle, hung over the spring, labelled *Staff of Office.*

<!-- quest
id: qst_lab_spring_siege
title: The Spring Under Siege
rank: C
type: Defense
giver: npc_ilsabet_rue
region: reg_labyrinth_upper
level: 58
act: 3
requires_rank: C
reward: 3600 | 200 | 14000
sets: lab_spring_done
summary: Slimes are gathering in the floor 30 spring, and the keeper wants them moved without fouling the only clean water for eleven floors.
objectives:
  talk npc_ilsabet_rue
  defend labyrinth_floor30_spring
  choice light_pool_or_fight
-->

---

## 7. First Descent

*C · Escort · the Entrance Hall to floor 10 · giver Healer Wynne Harrowgate*

**The short version.** Wynne has patched returning adventurers for years but has never gone down the first stair. Her temple has told her she cannot be a *real* healer for the Labyrinth until she has seen what she heals. She wants an escort to floor ten and back, and she wants to not be laughed at.

**What is really going on.** Wynne's fear is not monsters. It is that, down there, she will freeze: that she has read every treatise and knows every wound by name and will still stand useless over a body. The Labyrinth, as it happens, will give her one on the way. The player's job is to keep her alive *and* let her be useful.

**Scene 1: the infirmary.**

**WYNNE:** "A thousand patients. I've never met one *before* they were hurt."
**WYNNE:** "The temple says I can't call myself a Labyrinth healer until I've *seen* it."
**WYNNE:** "I'd like to go to the tenth floor and come back. Without freezing. Without being a burden."
> ► **"Are you afraid?"** — **WYNNE:** "I'm *terrified.* I'm very good at hiding it."
> ► **"What do you need?"** — **WYNNE:** "Someone who'll let me *try.*"
> ► **"I'll take you."** — **WYNNE:** "Don't make it easy."

**Scene 2: the stairs.** At the first stair, Wynne makes a clumsy Vex-prayer and refuses to spend her luckiest coin. On the third floor, a bat swarm scatters her staff. She laughs, a high, panicked laugh, and picks it up.

**WYNNE:** "I'm all right. I'm all right."
**WYNNE:** "I'm not all right."
> ► **"Breathe."** — **WYNNE:** "That's what I tell *them.*"
> ► **"Rest here."** — **WYNNE:** "Yes. For a moment."
> ► **"Keep walking."** — **WYNNE:** "...Yes. Walking."

**Scene 3: the wounded.** On the eighth floor, in a collapsed vault, the player and Wynne find a stranger, a young swordsman, bleeding badly from a spear wound, his party scattered. Wynne freezes. For the length of a held breath, she does nothing at all.

**WYNNE:** (barely) "I can't."
> ► **"Tell me what to do."** — She starts, mechanically.
> ► **"Hold the lantern."** — The player takes the first aid; Wynne watches.
> ► **"You can. Now."** — She breathes, and moves.

She pushes pressure, packs the wound, mutters a litany of names from her books, her voice steadying with each one. The swordsman lives.

**WYNNE:** (shaking, delighted) "He's *breathing.*"
**WYNNE:** "I did a *thing.*"

**Scene 4: the return.** At the Hall, the swordsman's party finds them and pays in tears. The temple, informed by a shaking Wynne, says nothing at all, then sends a plain stole.

**WYNNE:** "I don't think I'll be afraid again."
**WYNNE:** "I think I'll be afraid *every time,* and I'll do it anyway."

**Afterword: the infirmary.** A week later the player passes Wynne's infirmary and finds the door propped open and a line out of it. She is mid-sentence with a bandaged porter, explaining a wound with the unhurried confidence of someone who has now seen the real thing. Over the lintel she has hung a plain chalk-mark on a nail. When the player asks, she shrugs. "A reminder that I went down once. That I'll go again. It's allowed to be hard."

**Outcomes and receipt.**
- Wynne becomes the Hall's first licensed Labyrinth healer by descent. If the player took the first aid, she is more cautious and slower to trust herself; if they urged her, she is bolder.
- **Receipt:** a plain temple stole with a small chalk mark sewn on the hem; the swordsman's party leaves a pot of flowers at her infirmary door each reset.

<!-- quest
id: qst_lab_first_descent
title: First Descent
rank: C
type: Escort
giver: npc_wynne_harrowgate
region: reg_labyrinth_upper
level: 62
act: 3
requires_rank: C
reward: 3800 | 210 | 14500
sets: lab_first_descent_done
summary: A temple healer who has patched a thousand adventurers but never gone down the stair needs an escort to floor ten and back.
objectives:
  talk npc_wynne_harrowgate
  escort npc_wynne_harrowgate
  choice guide_hold_or_urge
-->

---

## 8. Paid in Stories

*C · Hidden · the floor 40 ghost market · giver Tam Ledgerwick*

**The short version.** The ghost market sells everything the living miss: a dead sparrow's song, a perfect afternoon, a good knot. Nothing costs coin. Everything is paid for in *stories.* Tam Ledgerwick audits the books, and the player, as a first-time guest, has been entered in them.

**What is really going on.** The ghost market's economy is a kindly bookkeeping of memory: the dead give what they remember; the living give what they remember; the ledger keeps both, so that nothing is lost twice. Tam's trouble is a deficit. A recent flood of parties has taken more than they gave. The ledger is *thin.* He needs one honest story, not a clever one, from someone who has not told it before.

**Scene 1: the arrival.** The market opens at midnight under paper lanterns. The stalls are tended by quiet shapes. Newcomers are expected to attend a wake before they go deeper, and the player does, standing at the back of the long table among the unlit candles.

**TAM:** (a dry cough) "You attended. Good. Most don't."
**TAM:** "I'm Ledgerwick. I was a customs clerk. I don't notice the difference."
**TAM:** "You've a story in you that no one's heard. I'd like it, if you'd spare it."
> ► **"What will it cost me?"** — **TAM:** "Nothing you'll miss."
> ► **"What do I get?"** — **TAM:** "Whatever you'd like. Within the ledger."
> ► **"What if I have none?"** — **TAM:** "Everyone does. They hide in the small ones."

**Scene 2: the telling.** The player picks a memory, and the market goes quiet. The player's story is the player's own, to write: an afternoon, a grief, a kindness. The ghosts listen with the particular, unhurried attention of the dead. One of them, an old woman in a river-grey shawl, leans forward at the end.

**GHOST:** "That was *warm.*"
**GHOST:** "I haven't been warm since the stair."
> ► **(Tell a happy memory.)** — Warmth spreads along the stalls.
> ► **(Tell a sad one.)** — A hush, then a low murmur.
> ► **(Tell a small, silly one.)** — A ghost laughs for the first time in a decade.

**Scene 3: the purchase.** Tam, writing, offers the player a choice of goods. A stall of perfect afternoons. A bag of old songs. A recipe for a stew that no living person remembers. A small key labelled *for the next door.*

**TAM:** "The key is yours if you want it. I wouldn't. It's *heavy.*"
> ► **"I'll take the stew."** — **TAM:** "Sensible."
> ► **"I'll take an afternoon."** — **TAM:** "Lovely."
> ► **"Give my story to someone else."** — **TAM:** "That is *not* in the book."

**Scene 4: the ledger.** Tam closes the book with a small, satisfied snap and puts a seal on the page. The ledger, he notes, is *balanced,* for the first time in a season. He sits for a moment with his hands folded.

**TAM:** "A good story balances a great many thefts."
**TAM:** "Come back and tell me another. Not tonight."

**Afterword: the balance.** As the market thins towards dawn, an old ghost in the river-grey shawl drifts up beside the player and presses something small into their palm that is not quite there: the warmth of a hand, held for one second. "You told it honestly," she says. "That is the only currency that does not spoil." Tam, writing in his ledger without looking up, adds that the dead have always been generous to the living, once the living remember to be generous first.

**Outcomes and receipt.**
- The ledger is balanced. If the player took the key, a locked door appears somewhere in the upper floors on a later reset. This is a seed and is **not explained.** If the player gave their story away, a living traveller, months later, receives a small, unexpected kindness.
- **Receipt:** a seal on the ghost market's ledger bearing the player's name; a faint scent of whatever was bought, at the start of each reset.

<!-- quest
id: qst_lab_paid_stories
title: Paid in Stories
rank: C
type: Hidden
giver: npc_tam_ledgerwick
region: reg_labyrinth_upper
level: 66
act: 3
requires_rank: C
reward: 4100 | 225 | 15500
sets: lab_stories_done
summary: The ghost market runs on stories, not coin, and its ledger is thin. A clerk asks for one honest story.
objectives:
  talk npc_tam_ledgerwick
  reach labyrinth_ghost_market
  choice happy_sad_or_silly
-->

---

## 9. A Letter for the Surface

*C · Delivery · floor 40 to the surface · giver Hostess Lenore Hartsong*

**The short version.** Lenore, the ghost hostess, greets every living guest by name and cannot leave the market. She has one unfinished letter that she wrote in life and never sent. It must reach the surface, and the one thing she asks is that the reader be given it by hand.

**What is really going on.** The letter is to her daughter, Wilda Hartsong, now a baker in a grey river-town three days from the Hall, who believes her mother left the family and never wrote. Lenore went down the Labyrinth to earn her daughter's dowry and did not come up. She has written on a stained card, in her own hand, every year of her death. The player carries a stack.

**Scene 1: the hostess.**

**LENORE:** "Good evening. You must be tired. Sit. I know your name."
**LENORE:** "I have a letter. It's been waiting twenty-six years."
**LENORE:** "I'd go myself, but the market won't let me."
> ► **"Who is it for?"** — **LENORE:** "My daughter. She was nine."
> ► **"What does it say?"** — **LENORE:** "That I didn't leave."
> ► **"I'll carry it."** — **LENORE:** "By hand, please. Not by a clerk."

**Scene 2: the climb.** The long walk up from floor forty, past the tavern on thirty, the Entrance Hall and out into daylight. The player carries a parcel of cards tied with a ribbon. On the road, an inn-keeper who knows the town tells the player that Wilda is "the baker with the flour on her ears, the one who doesn't smile on the first of the month."

**INNKEEPER:** "Her mother left. Everyone knows. She was the best baker in the county and she walked off."
**INNKEEPER:** "Wilda sells her mother's bread."
> ► **"She didn't leave."** — **INNKEEPER:** "You'll want to be sure of that."
> ► **"I have something for her."** — **INNKEEPER:** "Good luck."
> ► **"I'll wait until she's alone."** — **INNKEEPER:** "She's always alone, in the evenings."

**Scene 3: the bakery.** In the evening, with the ovens banked, the player knocks. Wilda is guarded and floury and kind. She does not take the cards at first.

**WILDA:** "A ghost wrote this?"
**WILDA:** "My mother's dead. Is that what you're telling me?"
> ► **"She wanted you to know she didn't leave."** — A long silence.
> ► **"She's well. She misses you."** — A gentler version.
> ► **"Read the first one."** — Wilda reads, and sits down.

The first card says only: *"I went to get you a dowry. I got lost. I'm sorry I'm late. Your bread was always better than mine."*

**Scene 4: the answer.** Wilda writes a reply on a flour-dusted card and hands it back. She does not say she'll go to the Labyrinth; she cannot. But she asks the player to carry the card down, and a loaf.

**WILDA:** "Tell her it's *her* bread."
**WILDA:** "Tell her I never changed the recipe."

**Afterword: the second card.** On the way back down, the player finds one more card tucked into the ribbon, forgotten at the bottom of the parcel: a single line, in Lenore's fine hand, *"If she is angry, let her be. I would be."* The player can leave it on the table at the market, as Lenore would want, or carry it up and read it to the baker on the next visit. Wilda, when she hears it, laughs once, wetly, and says that is exactly the sort of thing her mother would write.

**Outcomes and receipt.**
- The letters are delivered and answered. If the player softened the news, Wilda reads them more slowly. At the market, Lenore reads the reply and sets the loaf at the head of the wake-table.
- **Receipt:** a loaf on the ghost market's long table each reset; the hostess's greeting to the player now includes a second name, *"Wilda's friend."*

<!-- quest
id: qst_lab_letter_surface
title: A Letter for the Surface
rank: C
type: Delivery
giver: npc_lenore_hartsong
region: reg_labyrinth_upper
level: 70
act: 3
requires_rank: C
reward: 4300 | 240 | 16000
sets: lab_letter_done
summary: A ghost hostess has a letter she wrote in life and never sent, for a daughter who thinks her mother left.
objectives:
  talk npc_lenore_hartsong
  reach labyrinth_surface_bakery
  choice not_left_well_or_read
-->

---

## 10. The Map of a Floor That Isn't

*C · Exploration · the upper floors · giver Skritch Cindertoe*

**The short version.** Skritch sells maps of the upper floors, adjusted for the weekly shifts. Months ago she bought, from a customer she cannot remember, a map of a floor between eleven and twelve. She sold it as a joke. A party used it, and *the room on the map was real.*

**What is really going on.** *Nothing is explained.* The guild's maps have no floor between eleven and twelve. The corridor on the map is the same hand as the guild's ordinary survey, down to its smudges. The room exists, on one reset in several, behind a stairway that is not on the stair-list. In the room is a plain stone table, a single lit lamp and a dry, unsigned page. The quest ends on a question.

**Scene 1: the stall.**

**SKRITCH:** "I sell maps. *Honest* maps. I put a smudge where the walls shift."
**SKRITCH:** "Look at this one."
She unfolds a yellowed sheet. A corridor. A stair that does not belong. A door, and past it a room, labelled in a careful, unfamiliar hand: *Eleven and a half.*
> ► **"Where did you get it?"** — **SKRITCH:** "A customer. I can't remember their face."
> ► **"Is it a joke?"** — **SKRITCH:** "It was *supposed* to be."
> ► **"Who used it?"** — **SKRITCH:** "A party. They came back. Quiet."

**Scene 2: the corridor.** The player follows the map. Floors eleven and twelve are ordinary: bats, a slime, a gallery of cracked pillars. Behind a loose stair on the eleventh, the map's corridor appears, narrower than the others, its walls of a slightly lighter grey. There is no mist, no cold, no sound. The torches have burned down to stubs that are not burning.

**JOURNAL (auto):** *The air tastes faintly of lamp oil. Nothing has been killed here.*
> ► **(Walk on.)** — The corridor continues.
> ► **(Chalk a mark.)** — The chalk will not hold.
> ► **(Go back.)** — The stair is where it was.

**Scene 3: the room.** A small, plain room. A stone table. A lamp, lit, with no wick. On the table a single dry page, unsigned, with a short row of numbers.

**JOURNAL (auto):** *The numbers are the number of floors in the Labyrinth, written six times, each differently.*
> ► **(Read the page.)** — Nothing happens.
> ► **(Copy the numbers.)** — The page crumbles slightly.
> ► **(Leave the lamp lit.)** — A courtesy, perhaps.

**Scene 4: the exit.** The way back is exactly as it was. At the stall, Skritch examines the player's own sketch of the room with a face drained of its usual brisk cheer.

**SKRITCH:** "It's the same hand."
**SKRITCH:** "The room on the map. The hand that drew it. It's the same hand that draws the guild's survey."
**SKRITCH:** "I don't want to sell this one."
She folds the map and puts it, carefully, under her stall.

**Afterword: the stall.** Weeks later the player passes Skritch's stall and finds it unchanged: the same crowded maps, the same patient smudges. Only the folded sheet is gone from its hook. She does not mention it, and the player does not ask. But when a rookie reaches for a map of the lower eleven floors, Skritch quietly turns it face-down and sells him a better one for half the price, then watches the stair behind him until he is out of sight.

**Outcomes and receipt.**
- The room is found and left alone. If the player copied the numbers, the page crumbles and the numbers appear, once, in the player's journal. If they left the lamp lit, it is still lit on the next visit.
- **Receipt:** a sketch of the room in the player's Journal; one folded map under Skritch's stall.
- **Canon-safe:** this is a pure seed. It does not say who drew the map, what the room is, whether it relates to the Maze King, or why the guild's survey hand matches. It answers no open question.

<!-- quest
id: qst_lab_map_floor
title: The Map of a Floor That Isn't
rank: C
type: Exploration
giver: npc_skritch_cindertoe
region: reg_labyrinth_upper
level: 74
act: 3
requires_rank: C
reward: 4600 | 255 | 17000
sets: lab_map_done
summary: A kobold sold a joke map of a floor that does not exist, and a party found the room on it.
objectives:
  talk npc_skritch_cindertoe
  reach labyrinth_floor_eleven_half
  choice walk_chalk_or_back
-->
