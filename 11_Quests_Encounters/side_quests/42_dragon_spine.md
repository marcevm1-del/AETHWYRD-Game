# 11e-42 — Dragon Spine, the Bones of the Dragon: Ten Side Quests (draft)

> *"We do not pray for the dragon to wake. We pray that it sleeps well."*
> — Skull monastery, evening lullaby

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the second regional set ([[second_set_index]]). Hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`. ⚠️ **Spoilers (light):** quest 10 plants an unexplained seed.

**Region:** `reg_dragon_spine` (the Bone Road, the Skull, the dragon-bone monasteries, the Burning Peaks). **Rank band:** A–S. **Tone:** hushed, devout, volcanic, tender toward sleep.

**Placement notes.**
- **Vyrmax, the Drake Lord,** believes the bones are his ancestor's and the monks are grave-robbers. No quest here defeats Vyrmax, settles who the bones belong to, or says whether the dragon is asleep, dead or something else. Hints only.
- Customs used: monks give up their old names; prayers are lullabies; no sound that echoes off the bones inside the walls; boots are removed; relic-chipping is the monks' shame.
- S-rank rewards are first-pass extrapolations from the promotion table, as in the Whitewater Reach file.

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | Boots at the Door | A | OddJob | Doorkeeper Brother Ulm | Quiet comedy of manners |
| 2 | Chips From a Rib | A | Investigation | Brother Casimir | A relic-thief with a reason |
| 3 | The Lullaby Cantor's Cold | A | OddJob | Cantor Sister Ysolde | A voice failing |
| 4 | Fire-Lily Harvest | A | Gathering | Herbalist Sister Marren | Warm, dangerous work |
| 5 | A Pilgrim Who Cannot Climb | A | Escort | Pilgrim Anwen Greaves | The Bone Road, slowly |
| 6 | The Abbots Split | A | Faction | Abbot Thessaly | A council that cannot agree |
| 7 | The Drake Who Came to the Gate | S | Faction | Brother Ulm | Mercy and a hatchling |
| 8 | The Book of the Burned Monk | S | Investigation | Archivist Sister Perrin | A ritual that went wrong |
| 9 | The Warm Vertebra | S | Exploration | Brother Otho Vane | A bone that is too warm |
| 10 | What the Mountain Dreams | S | Hidden | Elder Brother Quill | A seed, unexplained |

## Cast

<!-- npc
id: npc_brother_ulm
name: Doorkeeper Brother Ulm
tier: major
race: Human
region: reg_dragon_spine
settlement: The Skull
role: Doorkeeper of the Skull
backstory: A huge, soft-spoken monk who has taken the boots of every visitor to the Skull for twenty years and can read a pilgrim from the state of their socks.
-->
<!-- npc
id: npc_brother_casimir
name: Brother Casimir
tier: major
race: Human
region: reg_dragon_spine
settlement: Bone Road monasteries
role: Bone-warden of the middle monasteries
backstory: A watchful monk who catalogues chips and cracks in the bones and has found that someone is taking relics from places no miner can reach.
-->
<!-- npc
id: npc_sister_ysolde
name: Cantor Sister Ysolde
tier: townsfolk
race: Human
region: reg_dragon_spine
settlement: The Skull
role: Cantor of the evening lullaby
backstory: A thin cantor whose voice has begun to crack on the lowest note of the lullaby, the one the monks believe the sleeper listens for.
-->
<!-- npc
id: npc_sister_marren
name: Herbalist Sister Marren
tier: townsfolk
race: Human
region: reg_dragon_spine
settlement: Bone Road monasteries
role: Herbalist who presses fire-lily oil
backstory: A sunburned herbalist who has lost three fingertips to the lilies and refuses to hire anyone who is not afraid of them.
-->
<!-- npc
id: npc_anwen_greaves
name: Pilgrim Anwen Greaves
tier: townsfolk
race: Human
region: reg_dragon_spine
settlement: The Bone Road
role: Pilgrim walking the whole Bone Road
backstory: A retired courier with a ruined knee who promised her late husband she would walk the Bone Road from end to end and is on day nine of forty.
-->
<!-- npc
id: npc_abbot_thessaly
name: Abbot Thessaly
tier: major
race: Human
region: reg_dragon_spine
settlement: The Skull
role: Abbot who presides over the council
backstory: A careful abbot, tired of her council's split between fighting Vyrmax and bargaining with him, who believes the vote itself is the danger.
-->
<!-- npc
id: npc_sister_perrin
name: Archivist Sister Perrin
tier: major
race: Human
region: reg_dragon_spine
settlement: The Skull
role: Archivist of the restricted shelves
backstory: A dry, exact archivist who keeps the burned monk's book in a locked case and has read it exactly once.
-->
<!-- npc
id: npc_brother_otho_vane
name: Brother Otho Vane
tier: townsfolk
race: Human
region: reg_dragon_spine
settlement: Bone Road monasteries
role: Bone-surveyor
backstory: A surveyor who measures the bones' warmth every season with a brass probe and has just written down a number he does not like.
-->
<!-- npc
id: npc_elder_brother_quill
name: Elder Brother Quill
tier: major
race: Human
region: reg_dragon_spine
settlement: The Skull
role: Eldest monk of the Skull
backstory: A near-blind monk of ninety who sleeps in the skull's eye socket and says the mountain talks in its sleep.
-->

---

## 1. Boots at the Door

*A · OddJob · the Skull gate · giver Doorkeeper Brother Ulm*

**Short version.** Ulm needs a second doorkeeper for the pilgrim festival and the player is the only one in the queue without hobnailed boots.

**Really going on.** The rule is gentle but absolute: nothing may echo. A noisy delegation of lowland merchants, a child with a drum and a duellist with spurs all test it. Ulm wants the player to manage them without a single raised voice.

**Scenes.**
**ULM:** "Boots on the left shelf, names on the tags, and please do not announce anyone's rank. The bones listen."
> ► **"What if someone refuses?"** — **ULM:** "Then they sit in the porch and eat our soup. Nobody has ever refused soup."
> ► **"I'll take the door."** — **ULM:** "Whisper. It carries further than you think."

*The duellist's spurs ring on the threshold. The player may whisper a request, offer slippers or let him learn it by the sound.* The child with the drum is offered a muffled one made of a rolled blanket.

**Outcomes.** A quiet festival; the duellist leaves his spurs on a peg and comes back barefoot next year. **Receipt:** a pair of felt slippers marked with the player's tag on the Skull's shelf.

<!-- quest
id: qst_dsp_boots_door
title: Boots at the Door
rank: A
type: OddJob
giver: npc_brother_ulm
region: reg_dragon_spine
level: 128
act: 4
requires_rank: A
reward: 30000 | 1500 | 132000
sets: dsp_boots_done
summary: A doorkeeper needs help hushing a pilgrim festival so that nothing echoes off the bones.
objectives:
  talk npc_brother_ulm
  reach dragon_spine_skull_gate
  choice whisper_slippers_or_wait
-->

---

## 2. Chips From a Rib

*A · Investigation · the Bone Road · giver Brother Casimir*

**Short version.** Relics are vanishing from ribs no miner could reach. Casimir wants the thief found before the abbots blame the miners.

**Really going on.** The thief is a young monk who has been selling chips to pay for his sister's medicine in the lowlands. He is not greedy; the monasteries' healers cannot reach her. The player decides whether to report, to bargain, or to pay the debt themself.

**Scenes.** A night watch from a ledge above a rib; a rope; a quiet figure with a small chisel.
**THIEF:** "Ninety-one coppers a chip. My sister needs forty a week."
> ► **"Report him."** — Casimir is told; the abbots are not.
> ► **"Pay the medicine."** — The thief weeps and stops.
> ► **"Take the chips back."** — The thief keeps one.

**Outcomes.** The truth is kept inside the monastery or reaches the council depending on the choice. **Receipt:** a chisel left on the Bone Road marker.

<!-- quest
id: qst_dsp_chips_rib
title: Chips From a Rib
rank: A
type: Investigation
giver: npc_brother_casimir
region: reg_dragon_spine
level: 130
act: 4
requires_rank: A
reward: 31000 | 1550 | 135000
sets: dsp_chips_done
summary: Relics are vanishing from ribs no miner could reach; the thief has a reason.
objectives:
  talk npc_brother_casimir
  reach dragon_spine_high_rib
  choice report_pay_or_return
-->

---

## 3. The Lullaby Cantor's Cold

*A · OddJob · the Skull · giver Cantor Sister Ysolde*

**Short version.** Ysolde's voice cracks on the lowest note. Without it the evening lullaby is incomplete, and the monks fear the sleeper will notice.

**Really going on.** It is a cold. The real fear is that the lowest note was the part Ysolde loved most and that she is getting old. The player fetches honey-ash tea, warm stones and, in the end, a child who can hum the low note.

**Scenes.**
**YSOLDE:** "Eleven notes. The twelfth is the one that matters."
> ► **"Rest tonight."** — **YSOLDE:** "And let the mountain wonder?"
> ► **"Teach someone."** — **YSOLDE:** "...Who?"

*A kitchen boy turns out to have a bass voice nobody noticed.*

**Outcomes.** The lullaby is complete with the boy's twelfth note. **Receipt:** a hand-copied score with a pencilled low note.

<!-- quest
id: qst_dsp_cantor_cold
title: The Lullaby Cantor's Cold
rank: A
type: OddJob
giver: npc_sister_ysolde
region: reg_dragon_spine
level: 130
act: 4
requires_rank: A
reward: 31000 | 1550 | 135000
sets: dsp_cantor_done
summary: The cantor's voice fails on the lowest note of the evening lullaby.
objectives:
  talk npc_sister_ysolde
  reach dragon_spine_skull_choir
  choice rest_teach_or_cover
-->

---

## 4. Fire-Lily Harvest

*A · Gathering · the vents · giver Herbalist Sister Marren*

**Short version.** Fire-lilies bloom for one night on the steaming vents. Marren has three fingers fewer than she would like and wants careful hands.

**Really going on.** Plain, warm, risky work. The lilies lean toward the bones, as if listening, and the oil they make is the monasteries' only export that is not a shame.

**Scenes.** A moonlit climb through steam; Marren teaching the pinch, the twist and the count of four.
> ► **(Pick by the book.)** — Safe and slow.
> ► **(Take the high vent.)** — Better lilies, hotter ground.
> ► **(Leave a bloom.)** — **MARREN:** "Good. Always leave one."

**Outcomes.** Full baskets and a lesson. **Receipt:** a vial of fire-lily oil and Marren's three-fingered handshake.

<!-- quest
id: qst_dsp_fire_lily
title: Fire-Lily Harvest
rank: A
type: Gathering
giver: npc_sister_marren
region: reg_dragon_spine
level: 126
act: 4
requires_rank: A
reward: 29500 | 1480 | 130000
sets: dsp_lily_done
summary: Fire-lilies bloom for one night on the vents and the herbalist needs careful hands.
objectives:
  talk npc_sister_marren
  collect fire_lily 12
  choice book_high_or_leave_one
-->

---

## 5. A Pilgrim Who Cannot Climb

*A · Escort · the Bone Road · giver Pilgrim Anwen Greaves*

**Short version.** Anwen promised her husband she would walk the Bone Road end to end. Her knee has other ideas. She asks for an escort and a slow pace.

**Really going on.** The Road is long, and every stretch has its own custom: a rib to touch, a vertebra to name her husband to, a cairn to add a stone. The danger is wyverns on the cliff stretches; the real work is patience.

**Scenes.** Nine slow days compressed into four stops. At the third, Anwen cannot go on.
> ► **"Rest a day."** — The wyverns pass.
> ► **"I'll carry you."** — **ANWEN:** "You will do no such thing."
> ► **"Skip a stretch."** — **ANWEN:** "Then it does not count."

**Outcomes.** She finishes, or she finishes by rope-litter, but she says her husband's name at the Skull. **Receipt:** a stone from every stop in her pack.

<!-- quest
id: qst_dsp_pilgrim_climb
title: A Pilgrim Who Cannot Climb
rank: A
type: Escort
giver: npc_anwen_greaves
region: reg_dragon_spine
level: 132
act: 4
requires_rank: A
reward: 32000 | 1600 | 140000
sets: dsp_pilgrim_done
summary: A pilgrim with a ruined knee wants to walk the whole Bone Road.
objectives:
  talk npc_anwen_greaves
  escort npc_anwen_greaves
  reach dragon_spine_skull_gate
-->

---

## 6. The Abbots Split

*A · Faction · the Skull council hall · giver Abbot Thessaly*

**Short version.** The council is split between fighting Vyrmax and bargaining with him. Thessaly believes the vote itself is the danger and asks for witnesses to both arguments.

**Really going on.** Neither side is a villain. The fighters want to protect the bones; the bargainers want to protect the people. The player is asked to listen to both and report what they heard, not to cast a vote.

**Scenes.**
**THESSALY:** "I will not ask you who is right. I will ask you what each of them is afraid of."
> ► **(Hear the fighters.)** — They fear a sixth monastery burning.
> ► **(Hear the bargainers.)** — They fear the bones being used as a bargaining chip.
> ► **(Ask the novices.)** — They fear neither; they fear silence.

**Outcomes.** Thessaly writes the three fears on the council's wall and the vote is postponed (no resolution). **Receipt:** a slate with three lines in chalk.

<!-- quest
id: qst_dsp_abbots_split
title: The Abbots Split
rank: A
type: Faction
giver: npc_abbot_thessaly
region: reg_dragon_spine
level: 134
act: 4
requires_rank: A
reward: 32500 | 1620 | 142000
sets: dsp_abbots_done
summary: The council is split between fighting Vyrmax and bargaining with him; the abbot asks for honest witnesses.
objectives:
  talk npc_abbot_thessaly
  reach dragon_spine_council_hall
  choice fighters_bargainers_or_novices
-->

---

## 7. The Drake Who Came to the Gate

*S · Faction · the Skull gate · giver Brother Ulm*

**Short version.** A drake hatchling, half-starved, has come to the gate of the Skull alone. Ulm cannot decide whether it is a spy, a gift or a child.

**Really going on.** It is a hatchling that followed the warmth of the bones. Its mother is dead. If it is returned to Vyrmax, the hatchling lives and Vyrmax learns the monks gave it back; if kept, it grows into the thing the monks fear. This is a seed for later diplomacy, not a resolution.

**Scenes.**
**ULM:** "It sat in the porch and ate our soup. Nobody has ever refused soup."
> ► **"Return it."** — A long, cold climb to the Burning Peaks.
> ► **"Raise it here."** — The abbots object.
> ► **"Ask it."** — The hatchling hums, once, in the bones' key.

**Outcomes.** Each path leaves a different consequence for Vyrmax's temper; none resolves it. **Receipt:** a scorched soup bowl on the porch.

<!-- quest
id: qst_dsp_drake_gate
title: The Drake Who Came to the Gate
rank: S
type: Faction
giver: npc_brother_ulm
region: reg_dragon_spine
level: 172
act: 5
requires_rank: S
requires_quests: qst_dsp_boots_door
reward: 70000 | 3000 | 320000
sets: dsp_drake_gate_done
summary: A starving drake hatchling has come to the monastery gate alone.
objectives:
  talk npc_brother_ulm
  reach dragon_spine_burning_peaks_edge
  choice return_raise_or_ask
-->

---

## 8. The Book of the Burned Monk

*S · Investigation · the restricted shelves · giver Archivist Sister Perrin*

**Short version.** Within living memory a monk tried to wake the dragon with a ritual from an old book and was burned by a fire that came out of the rock. Perrin has read the book once and wants a second reader.

**Really going on.** The ritual was not an attempt to wake the dragon. It was a lullaby, mistranscribed, and the fire was the mountain *answering* a wrong note. The player is not told what that implies.

**Scenes.** A locked case; a shaking hand; a page of musical notation with one note crossed out in another hand.
> ► **"Read it aloud."** — **PERRIN:** "No. The bones listen."
> ► **"Compare it to the lullaby."** — A silence.
> ► **"Burn it."** — **PERRIN:** "That is what the last man thought."

**Outcomes.** The book is re-locked with a marginal note. **Receipt:** a page of the lullaby with one note circled.

<!-- quest
id: qst_dsp_burned_monk
title: The Book of the Burned Monk
rank: S
type: Investigation
giver: npc_sister_perrin
region: reg_dragon_spine
level: 176
act: 5
requires_rank: S
reward: 72000 | 3100 | 330000
sets: dsp_burned_monk_done
summary: A monk burned by a fire from the rock left a ritual book; a second reader compares it to the lullaby.
objectives:
  talk npc_sister_perrin
  reach dragon_spine_restricted_shelves
  choice aloud_compare_or_burn
-->

---

## 9. The Warm Vertebra

*S · Exploration · a high monastery · giver Brother Otho Vane*

**Short version.** Otho's brass probe says one vertebra is warmer this season than any in ninety years of records. He wants a second reading, at night, alone.

**Really going on.** Nothing is explained. The vertebra pulses very faintly, once a minute, slower than a heartbeat. The probe's needle rises on the pulse and falls. The drakes nest closer to it.

**Scenes.** A cold climb; a chamber of ribs; the needle.
> ► **(Record.)** — Otho writes it down.
> ► **(Touch the bone.)** — It is warm as skin.
> ► **(Tell the abbots.)** — **OTHO:** "Not yet."

**Outcomes.** A new line in the survey. **Receipt:** Otho's reading, copied in the Journal; no cause given.

<!-- quest
id: qst_dsp_warm_vertebra
title: The Warm Vertebra
rank: S
type: Exploration
giver: npc_brother_otho_vane
region: reg_dragon_spine
level: 180
act: 5
requires_rank: S
reward: 74000 | 3200 | 335000
sets: dsp_vertebra_done
summary: A brass probe says one vertebra is warmer than any in ninety years of records.
objectives:
  talk npc_brother_otho_vane
  reach dragon_spine_warm_vertebra
  choice record_touch_or_tell
-->

---

## 10. What the Mountain Dreams

*S · Hidden · the Skull's eye socket · giver Elder Brother Quill*

**Short version.** Quill, ninety and nearly blind, says the mountain talks in its sleep, and asks the player to sit with him in the eye socket until it does.

**Really going on.** *Nothing is explained.* Near dawn the bones hum a few notes in the lullaby's key, then a fifth note the lullaby does not contain. Quill nods. He does not say what it means.

**Scenes.**
**QUILL:** "I have heard it eleven times. I have never told anyone. You may."
> ► **(Listen.)** — Four notes, then a fifth.
> ► **(Hum back.)** — The hum stops.
> ► **(Say nothing.)** — **QUILL:** "Good."

**Outcomes.** A five-note sketch in the Journal. **Canon-safe:** a pure seed; it does not say what the fifth note is, who the dragon is, or whether it is asleep.

<!-- quest
id: qst_dsp_mountain_dreams
title: What the Mountain Dreams
rank: S
type: Hidden
giver: npc_elder_brother_quill
region: reg_dragon_spine
level: 184
act: 5
requires_rank: S
reward: 76000 | 3300 | 340000
sets: dsp_dreams_done
summary: The eldest monk asks the player to sit in the skull's eye socket until the mountain talks in its sleep.
objectives:
  talk npc_elder_brother_quill
  reach dragon_spine_skull_eye
  choice listen_hum_or_silence
-->
