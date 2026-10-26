# 11e-44 — Cinderhole, the Smoking City: Ten Side Quests (draft)

> *"A person's mask says more about them than their face. That is why we sell masks and not faces."*
> — Mask Market saying

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the second regional set ([[second_set_index]]). Hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`.

**Region:** `reg_cinderhole` (the crater terraces, the Great Chimneys, the Burning Seams, the Mask Market). **Rank band:** A only. **Tone:** gritty, warm underneath, smoky, wary, community against a choking sky.

**Placement notes.**
- **Cinderlord Vasque** controls the vents and chimneys and has begun closing them to punish districts. No quest here defeats Vasque, ends his rule or opens every chimney for good. He is "not wrong about the city and utterly wrong about himself."
- Customs used: smoke-masks as identity; the fire as a debt for old miners' greed; the black market as the place to buy anything; refugees from every land.
- All quests are rank A, levels 126–150.

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | A Mask for a Stranger | A | OddJob | Maskmaker Odile Fenn | Identity, made small |
| 2 | The Last Open Chimney | A | Defense | Sweep-Captain Bruno Kell | A district that can still breathe |
| 3 | Debt of the Old Miners | A | Investigation | Miner Eskil Drogan | A ledger under the crater |
| 4 | Smuggler's Lullaby | A | Escort | Smuggler Neve Lasko | Moving a child through smoke |
| 5 | The Ash-Moth Census | A | Gathering | Naturalist Lio Pemberly | Small wings in the dark |
| 6 | A Mask Without a Face | A | Hidden | Mask Thief Pip Soot | A theft with a reason |
| 7 | Alchemist's Apprentice | A | OddJob | Alchemist Zenobia Quill | Fumes and a lesson |
| 8 | Choking District | A | Faction | Doctor Hale Arvid | Medicine without air |
| 9 | The Fire That Will Not Pay | A | Exploration | Old Miner Sigrun Dahl | The first seam |
| 10 | What Vasque Keeps in the Smoke | A | Hidden | Unknown whisperer | A seed, unexplained |

## Cast

<!-- npc
id: npc_odile_fenn
name: Maskmaker Odile Fenn
tier: major
race: Human
region: reg_cinderhole
settlement: The Mask Market
role: Maskmaker who reads people by their requests
backstory: A tiny maskmaker who has sold a mask to nearly every person in the crater and can tell what a stranger fears by the size of the mask they ask for.
-->
<!-- npc
id: npc_bruno_kell
name: Sweep-Captain Bruno Kell
tier: major
race: Human
region: reg_cinderhole
settlement: The Great Chimneys
role: Captain of the chimney-sweeps
backstory: A soot-black captain whose sweeps keep the chimneys clear by hand and who has refused Vasque's order to let one district's chimney close.
-->
<!-- npc
id: npc_eskil_drogan
name: Miner Eskil Drogan
tier: townsfolk
race: Human
region: reg_cinderhole
settlement: The Burning Seams
role: Miner who keeps the old tally
backstory: A deep miner who has kept his family's tally of the old miners' greed for four generations and wants it read by someone who will not flinch.
-->
<!-- npc
id: npc_neve_lasko
name: Smuggler Neve Lasko
tier: townsfolk
race: Human
region: reg_cinderhole
settlement: Cinderhole terraces
role: Smuggler of refugees
backstory: A cheerful smuggler who carries people, not goods, out of choked districts, and who has one small passenger tonight who will not stop singing.
-->
<!-- npc
id: npc_lio_pemberly
name: Naturalist Lio Pemberly
tier: townsfolk
race: Human
region: reg_cinderhole
settlement: Cinderhole terraces
role: Naturalist who counts ash moths
backstory: A mild naturalist who believes the ash moths are the crater's canary and is counting them to see how fast the air is failing.
-->
<!-- npc
id: npc_pip_soot
name: Mask Thief Tam Soot
tier: townsfolk
race: Human
region: reg_cinderhole
settlement: The Mask Market
role: Mask thief
backstory: A wiry thief who steals masks and gives them away, and who can explain why in exactly one sentence.
-->
<!-- npc
id: npc_zenobia_quill
name: Alchemist Zenobia Quill
tier: major
race: Human
region: reg_cinderhole
settlement: Cinderhole terraces
role: Alchemist who trains apprentices
backstory: A brisk alchemist who teaches by letting apprentices make small mistakes and who has one apprentice who makes only large ones.
-->
<!-- npc
id: npc_hale_arvid
name: Doctor Hale Arvid
tier: major
race: Human
region: reg_cinderhole
settlement: The choked districts
role: Doctor of the choked districts
backstory: A hollow-eyed doctor who treats smoke-lung without enough clean air or enough medicine and refuses to leave.
-->
<!-- npc
id: npc_sigrun_dahl
name: Old Miner Sigrun Dahl
tier: townsfolk
race: Human
region: reg_cinderhole
settlement: The Burning Seams
role: Oldest living miner
backstory: A seventy-year-old miner who remembers the first seam and says the fire is not a punishment but an invitation nobody answered.
-->
<!-- npc
id: npc_smoke_whisperer
name: The Whisperer in the Flue
tier: townsfolk
race: Spirit
region: reg_cinderhole
settlement: The Great Chimneys
role: A voice in a flue
backstory: A smoke-spirit voice that speaks from one chimney and says it was asked to keep something for someone, and cannot remember who.
-->

---

## 1. A Mask for a Stranger

*A · OddJob · the Mask Market · giver Maskmaker Odile Fenn*

**Short version.** A newcomer, new to Cinderhole and afraid, has asked Odile for a very small mask. Odile wants the player to talk her into a better one.

**Really going on.** The small mask is a plain one. The newcomer is a refugee who wants to be forgotten. Odile's trade tells her that to be forgotten is to be lonely.

**Scenes.**
**ODILE:** "Small mask, small face, small life. I do not sell those."
> ► **"What would you sell her?"** — **ODILE:** "A mask with a bit of colour."
> ► **"Let her choose."** — **ODILE:** "She will choose grey."
> ► **"I'll talk to her."** — **ODILE:** "Kindly."

**Outcomes.** The newcomer chooses a mask with one thread of colour, or keeps the grey. **Receipt:** a thread of colour sewn into the player's own mask.

<!-- quest
id: qst_cnd_mask_stranger
title: A Mask for a Stranger
rank: A
type: OddJob
giver: npc_odile_fenn
region: reg_cinderhole
level: 126
act: 4
requires_rank: A
reward: 28000 | 1400 | 125000
sets: cnd_mask_done
summary: A frightened newcomer asks for the smallest mask in the market.
objectives:
  talk npc_odile_fenn
  reach cinderhole_mask_market
  choice sell_choose_or_talk
-->

---

## 2. The Last Open Chimney

*A · Defense · the Great Chimneys · giver Sweep-Captain Bruno Kell*

**Short version.** Vasque has ordered one district's chimney closed. Bruno's sweeps have kept it open by hand for three nights. Tonight the Cinderlord's wardens come to finish the job.

**Really going on.** The wardens are ordinary people under orders. The sweeps do not want a fight. They want time for the district to be moved.

**Scenes.** A long smoky night; wardens with hammers; a chain of sweeps passing buckets of ash.
> ► **(Block the stair.)** — A standoff.
> ► **(Talk to the wardens.)** — Some leave.
> ► **(Help evacuate.)** — The district moves.

**Outcomes.** The chimney is closed, or the district moves. Nobody dies. **Receipt:** a sweep's brush hung at the district gate.

<!-- quest
id: qst_cnd_last_chimney
title: The Last Open Chimney
rank: A
type: Defense
giver: npc_bruno_kell
region: reg_cinderhole
level: 130
act: 4
requires_rank: A
reward: 30000 | 1500 | 132000
sets: cnd_chimney_done
summary: Sweeps have kept a condemned chimney open by hand; tonight the wardens come to close it.
objectives:
  talk npc_bruno_kell
  defend cinderhole_great_chimney
  choice stair_talk_or_evacuate
-->

---

## 3. Debt of the Old Miners

*A · Investigation · the Burning Seams · giver Miner Eskil Drogan*

**Short version.** Eskil's family has kept a tally of the old miners' greed for four generations. He wants it read by someone who will not flinch.

**Really going on.** The tally is not a curse. It lists the old miners' *kindnesses* beside their greed, and the sums are nearly equal. Nobody has ever read the right-hand column.

**Scenes.** A cramped tunnel; a stained ledger; a lamp.
> ► **"Read the greed."** — A heavy list.
> ► **"Read the kindness."** — Surprise.
> ► **"Read both."** — Silence.

**Outcomes.** Eskil adds a line to the tally. **Receipt:** a copy of the right-hand column.

<!-- quest
id: qst_cnd_old_miners_debt
title: Debt of the Old Miners
rank: A
type: Investigation
giver: npc_eskil_drogan
region: reg_cinderhole
level: 128
act: 4
requires_rank: A
reward: 29000 | 1450 | 128000
sets: cnd_debt_done
summary: A miner's family tally of the old miners' greed has a second column nobody has read.
objectives:
  talk npc_eskil_drogan
  reach cinderhole_old_seam
  choice greed_kindness_or_both
-->

---

## 4. Smuggler's Lullaby

*A · Escort · the terraces · giver Smuggler Neve Lasko*

**Short version.** Neve smuggles people out of choked districts. Tonight her passenger is a child who will not stop singing, and wardens have started listening.

**Really going on.** The song is the only thing keeping the child calm. The player must decide whether to hush her, hide the song or trust the dark.

**Scenes.** Tunnels, rope bridges, a checkpoint with a lantern.
> ► **(Hush her.)** — She cries.
> ► **(Hum with her, quietly.)** — She whispers.
> ► **(Let her sing.)** — A risk.

**Outcomes.** The child reaches the edge. **Receipt:** a hair ribbon tied to the player's mask.

<!-- quest
id: qst_cnd_smugglers_lullaby
title: Smuggler's Lullaby
rank: A
type: Escort
giver: npc_neve_lasko
region: reg_cinderhole
level: 130
act: 4
requires_rank: A
reward: 30000 | 1500 | 132000
sets: cnd_lullaby_done
summary: A smuggler of refugees carries a child who will not stop singing through the wardens' tunnels.
objectives:
  talk npc_neve_lasko
  escort npc_neve_lasko
  reach cinderhole_terrace_edge
-->

---

## 5. The Ash-Moth Census

*A · Gathering · the cave roofs · giver Naturalist Lio Pemberly*

**Short version.** Lio counts ash moths because he believes they are the crater's canary. This year the counts are falling.

**Really going on.** The moths avoid the districts with closed chimneys. The count is a map of where the air is failing.

**Scenes.** A quiet crawl through cave roofs with a lantern and a net.
> ► **(Count carefully.)** — Slow, accurate.
> ► **(Sample many roofs.)** — A map appears.
> ► **(Release them.)** — Lio smiles.

**Outcomes.** Lio's map is passed to Doctor Arvid. **Receipt:** a pressed moth wing in a paper fold.

<!-- quest
id: qst_cnd_ash_moths
title: The Ash-Moth Census
rank: A
type: Gathering
giver: npc_lio_pemberly
region: reg_cinderhole
level: 126
act: 4
requires_rank: A
reward: 28000 | 1400 | 125000
sets: cnd_moths_done
summary: A naturalist counts ash moths and finds they avoid the districts with closed chimneys.
objectives:
  talk npc_lio_pemberly
  collect ash_moth_count 20
  choice count_map_or_release
-->

---

## 6. A Mask Without a Face

*A · Hidden · the Mask Market · giver Mask Thief Tam Soot*

**Short version.** Tam steals masks and gives them away. A warden has found out and wants to talk. Tam asks the player to be there.

**Really going on.** Tam steals masks from stalls that overcharge and gives them to people who cannot afford them. The market quietly agrees with him and says so only to the player.

**Scenes.**
**TAM:** "A mask is air. Air should not be sold."
> ► **"Hide him."** — A scramble.
> ► **"Talk to the warden."** — Surprising sympathy.
> ► **"Pay for the masks."** — Tam groans.

**Outcomes.** The market adopts a mask-lending shelf. **Receipt:** a borrowed mask with a returning tag.

<!-- quest
id: qst_cnd_mask_no_face
title: A Mask Without a Face
rank: A
type: Hidden
giver: npc_pip_soot
region: reg_cinderhole
level: 128
act: 4
requires_rank: A
reward: 29000 | 1450 | 128000
sets: cnd_mask_thief_done
summary: A thief who gives away stolen masks has been found out by a warden.
objectives:
  talk npc_pip_soot
  reach cinderhole_mask_market_back
  choice hide_talk_or_pay
-->

---

## 7. Alchemist's Apprentice

*A · OddJob · the alchemist's cave · giver Alchemist Zenobia Quill*

**Short version.** Zenobia has an apprentice who makes only large mistakes. She asks the player to supervise one afternoon without taking the lesson away.

**Really going on.** The apprentice is trying to make a mask-filter to help the choked districts. The mistakes are brave, not careless.

**Scenes.** A cave workshop; a green flame; a very small explosion.
> ► **(Step in.)** — Safe, but he loses the lesson.
> ► **(Step back.)** — A bigger bang.
> ► **(Help him think.)** — A clean result.

**Outcomes.** The filter works well enough to distribute. **Receipt:** a cracked beaker kept as a lucky charm.

<!-- quest
id: qst_cnd_alchemist_apprentice
title: Alchemist's Apprentice
rank: A
type: OddJob
giver: npc_zenobia_quill
region: reg_cinderhole
level: 132
act: 4
requires_rank: A
reward: 31000 | 1550 | 135000
sets: cnd_apprentice_done
summary: An alchemist's accident-prone apprentice is secretly trying to build a filter for the choked districts.
objectives:
  talk npc_zenobia_quill
  reach cinderhole_alchemist_cave
  choice step_in_back_or_think
-->

---

## 8. Choking District

*A · Faction · a closed district · giver Doctor Hale Arvid*

**Short version.** Hale treats smoke-lung without clean air or enough medicine. He asks the player to carry what he needs through the wardens' lines.

**Really going on.** The medicine is not the shortage; air is. Hale needs a handful of bellows-lungs, hand-pumped, to ventilate one ward. The player may fetch, build or steal.

**Scenes.** A ward of sleepers; a rasp; a hand-pump that works.
> ► **(Fetch the bellows.)** — The usual way.
> ► **(Build them.)** — The slow way.
> ► **(Steal from the wardens.)** — The risky way.

**Outcomes.** One ward breathes. **Receipt:** a mask-filter in the player's pack.

<!-- quest
id: qst_cnd_choking_district
title: Choking District
rank: A
type: Faction
giver: npc_hale_arvid
region: reg_cinderhole
level: 136
act: 4
requires_rank: A
reward: 33000 | 1650 | 145000
sets: cnd_choking_done
summary: A doctor in a closed district needs hand-pumped bellows to ventilate his ward.
objectives:
  talk npc_hale_arvid
  reach cinderhole_closed_district
  choice fetch_build_or_steal
-->

---

## 9. The Fire That Will Not Pay

*A · Exploration · the first seam · giver Old Miner Sigrun Dahl*

**Short version.** Sigrun says the fire is not a punishment but an invitation nobody answered. She asks the player to walk with her to the first seam and see.

**Really going on.** At the seam is a narrow room, long sealed, with a table set for a shift-change meal. No one has dared to sit at it. Sigrun sits. The fire flickers, then settles. No explanation is given.

**Scenes.** A long descent; a sealed door; a table.
> ► **(Sit with her.)** — The fire settles.
> ► **(Eat.)** — Nothing happens.
> ► **(Stand guard.)** — A hush.

**Outcomes.** A small ritual begins in the crater. **Receipt:** a miner's tin cup.

<!-- quest
id: qst_cnd_fire_not_pay
title: The Fire That Will Not Pay
rank: A
type: Exploration
giver: npc_sigrun_dahl
region: reg_cinderhole
level: 140
act: 4
requires_rank: A
reward: 34000 | 1700 | 150000
sets: cnd_fire_done
summary: The oldest miner says the fire is an invitation no one answered and walks to the first seam.
objectives:
  talk npc_sigrun_dahl
  reach cinderhole_first_seam
  choice sit_eat_or_guard
-->

---

## 10. What Vasque Keeps in the Smoke

*A · Hidden · a flue · giver The Whisperer in the Flue*

**Short version.** A voice in one flue says it was asked to keep something for someone and cannot remember who.

**Really going on.** *Nothing is explained.* The voice recites a list of things it keeps (a name, a lantern, a child's laugh), none of them Vasque's, all of them lost. It asks the player to say them aloud somewhere the smoke cannot reach.

**Scenes.**
**VOICE:** "A name. A lantern. A laugh. I do not know whose."
> ► **(Say them aloud.)** — The smoke thins for a breath.
> ► **(Write them down.)** — The voice sighs.
> ► **(Ask who asked.)** — **VOICE:** "I do not know."

**Outcomes.** A short list in the Journal. **Canon-safe:** a pure seed; it does not say whom the smoke belongs to or what Vasque knows.

<!-- quest
id: qst_cnd_vasque_smoke
title: What Vasque Keeps in the Smoke
rank: A
type: Hidden
giver: npc_smoke_whisperer
region: reg_cinderhole
level: 144
act: 4
requires_rank: A
reward: 35000 | 1750 | 155000
sets: cnd_smoke_done
summary: A voice in a flue keeps three lost things for someone it cannot remember.
objectives:
  talk npc_smoke_whisperer
  reach cinderhole_whisper_flue
  choice speak_write_or_ask
-->
