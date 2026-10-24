# Guild Hall Talk & Adventurer Lexicon

**Purpose:** give guild halls the sound of working people between expeditions. This is a reusable dialogue and world-building guide, not a list of mandatory voiced lines. Canon and the current NPC/quest data remain authoritative.

## 1. What guild talk does

Guild members talk about what they need to do next: prove a hunt, replace a cracked strap, settle a room bill, warn a rookie, argue over a monster's rank, boast about a clean run, or quietly remember someone who did not return. Their words should make the guild feel like a profession with routines, humor, skill and grief.

Ambient talk should give the player at least one of three things: **useful information**, **a glimpse of a relationship**, or **a small emotional texture**. A bark that only repeats "the world is dangerous" is not enough. Conversations can point toward an existing board contract, service, region, known monster behavior or canon event; ambient NPCs must not invent new quest facts or reveal protected spoilers.

## 2. Guild speech in layers

### Everyday vocabulary

| Word or phrase | Meaning | Example use |
|---|---|---|
| **card** | Guild membership and rank credential | “Show your card before you take that posting.” |
| **posting / board work** | A contract listed by the branch | “Anything decent on the board this morning?” |
| **proof** | A required token, report or verified objective | “The clerk needs proof, not a story.” |
| **turn-in** | Returning to report completion and claim payment | “Let's turn in before the branch closes.” |
| **share** | Agreed split of coin or materials | “We said even shares. Count it here.” |
| **cut** | A person's share of the reward | “Your cut is ready at the counter.” |
| **field pay** | Advance or allowance for supplies | “Keep two silver aside for field pay.” |
| **core** | A monster's condensed mana remnant | “Bag the core separately; don't crack it in the pack.” |
| **clean core** | A core recovered intact enough for research or crafting | “That one's clean. Brannoc can use it.” |
| **spoiled core** | A cracked or contaminated core with reduced use | “It still sells, but it's no smith's choice.” |
| **rank check** | Guild assessment before taking dangerous work | “Get a rank check before you accept a C posting.” |
| **suitability** | A warning about whether the party is ready for a boss | “The board says Worthy. That's a warning, not a promise.” |
| **route note** | A practical report about a road, cave or trail | “Leave a route note if the ford's up.” |
| **red mark** | A warning attached to a dangerous or changing contract | “That posting got a red mark overnight.” |
| **quiet board** | A day with few urgent contracts | “Quiet board. We can finally mend the kit.” |
| **rush board** | Many fresh or urgent postings at once | “Rush board at dawn. Take only what you can finish.” |
| **field-ready** | Equipped, supplied and informed enough to depart | “You look field-ready. Do you know what nests there?” |
| **pull aggro / draw it** | Deliberately attract a monster's attention | “I'll draw it; you get the villager clear.” |
| **break** | Stagger or damage a monster's part/poise | “Wait for its guard to break, then move.” |
| **leash** | The distance a monster will pursue before returning | “Don't drag it past the old marker; that's its leash.” |
| **call it** | End an attempt or retreat | “If the second flask goes, we call it.” |
| **wipe** | The whole party is defeated or a group hunt fails | “We wiped once. We change the plan and go again.” |
| **camp-safe** | A place currently suitable for rest | “That ledge is camp-safe unless the wind turns.” |
| **take the long road** | Choose a safer route over a quicker one | “We can take the long road and keep the cart.” |

### Rank and career slang already in the setting

Retain established terms from `life_in_aetheria.md`: **card-burner** (a rookie who died at F), **goblin-chewed** (badly beaten), **silver-sick** (someone stalled at C), and **a Kaede** (someone advancing at an astonishing pace). These are context-sensitive: friends may tease, while a stranger using them can sound cruel.

### Currency words

Everyday talk uses the denomination name, not a long number: “three silver,” “half a gold,” “a platinum for the lot.” Where exact change matters, characters may say “forty copper.” The UI always shows exact value and change; dialogue can round naturally if the context is casual.

## 3. Guild-hall conversational topics

### Work and risk

- Whether a posting's description matches the tracks, damage or witness accounts.
- Which monster part is useful, which is dangerous to handle, and what must remain intact.
- Whether a boss is Worthy, Risky or Overwhelming for the party; rank is a warning, never a hard prohibition.
- A settlement's siege notice, evacuation plan, guard roster or repair needs.
- A route's weather, bridge condition, camp safety and last confirmed sighting.

### Pay and trust

- Agreeing on equal shares or explaining a different split before departure.
- Paying for lodging, food and repairs; paying in copper, silver, gold or a documented Guild tab.
- A rookie learning not to spend the entire reward before replacing a potion.
- A party dispute over who kept a trophy, sold the hide or forgot to file proof.
- An honest correction when the client understated danger; the Guild investigates rather than silently changing the reward.

### Skill and reputation

- A veteran shows a stance or gives one practical warning, not a full tutorial monologue.
- Members debate whether a kill was clever, lucky, reckless or needlessly cruel.
- A crafter asks for a clean sample; an alchemist offers a safe handling tip.
- Someone recognizes the player after a visible deed, with the rumor arriving through a believable route.
- Friendly rivals compare completion times, but no dialogue claims a leaderboard result unless supported by game data.

### Warmth and loss

- Someone saves a seat for a party member who is still out on a hunt.
- The hall lowers its voice when a card is placed in the memorial display.
- A returning team shares food before telling the funny version of a frightening story.
- A mentor checks that the rookie has enough copper for the road home.
- After liberation, people celebrate without pretending the damage and fear vanished overnight.

## 4. Sample ambient conversations

These are tone samples. Use anonymous role labels in implementation until dialogue is assigned to existing NPCs. Avoid firing every line repeatedly; select by location, story state, rank band, schedule and recent player actions.

### At the board, before a hunt

**Rookie:** “This says rabbits. Why is there a warning mark?”  
**Veteran:** “Because the farmer saw one with a horn through the fence rail. Read the whole posting.”  
**Rookie:** “I did.”  
**Veteran:** “Then read it again, slower. The small ones are easy. The one that broke the fence is the job.”

### Core handling at the counter

**Hunter:** “Two F cores, one cracked. Put the clean one on the research tray.”  
**Clerk:** “You want the Guild rate or Brannoc's material exchange?”  
**Hunter:** “Exchange. I need a guard plate before tomorrow.”  
**Clerk:** “Then keep the other one. Don't sell a thing you already have a use for.”

### Splitting coin

**Ranger:** “Four gold, twelve silver, and the client covered the room.”  
**Swordsman:** “Three ways?”  
**Ranger:** “Four. The porter took the risk too.”  
**Swordsman:** “Fair. I'll change a platinum at the counter.”

### Rookie preparation

**Mentor:** “What have you packed?”  
**Rookie:** “Potion, rope, two bombs, map.”  
**Mentor:** “And?”  
**Rookie:** “A second potion?”  
**Mentor:** “The return route. You can be brave after you know how you're getting back.”

### A choice about an intelligent monster

**Hunter A:** “The contract says clear the den.”  
**Hunter B:** “The tracks lead to a family, not a warband.”  
**Hunter A:** “Then we ask the client what they mean by clear.”  
**Hunter B:** “Good. I'd rather lose a bonus than pretend the wording answered that.”

### After a failed attempt

**Rookie:** “We came back without the proof.”  
**Clerk:** “You came back. That's the first line in the report.”  
**Rookie:** “The guild will mark us down.”  
**Clerk:** “We'll record the failure honestly, adjust the posting, and tell you what the next attempt needs.”

### After a liberation festival

**Guard:** “First night this month I haven't heard the wall bell.”  
**Merchant:** “Give it a week before you call it peaceful.”  
**Guard:** “I said I hadn't heard it. Let me have that much.”

## 5. Dialogue authoring rules

1. **Talk about a concrete thing.** A place, person, contract, item, plan or recent event.
2. **Give each speaker a purpose.** Asking, correcting, boasting, avoiding, reassuring, negotiating, remembering.
3. **Use short turns for ambient barks.** Longer conversations belong to a deliberate interaction or a staged scene.
4. **Let rank change confidence, not intelligence.** F-rank adventurers can be observant; S-rank members can be wrong.
5. **Vary social texture.** Warm teasing, dry craft talk, nervous over-preparation, blunt warnings, low-voiced grief and occasional anime exuberance.
6. **Do not make everyone a quip machine.** Humor comes from personality and situation; the project's tone favors warmth over constant comedy.
7. **Do not turn currency into exposition.** Use denomination words naturally; explain conversion in the tutorial or wallet screen.
8. **Respect the single-player world.** No ambient lines about other players, server events, guild queues or player-to-player trades.
9. **Respect fact ownership.** Characters know what they witnessed, were told or could reasonably infer. Rumors can be marked uncertain.
10. **Avoid repetitive chatter.** Cool down exact lines; rotate conversation pools; let companions interrupt only at authored moments.

## 6. Implementation shape

Guild-hall conversation records can be data-driven later with:

`id`, `speakerRole`, `listenerRole`, `locationTag`, `timeWindow`, `rankBand`, `storyFlagsAny`, `storyFlagsAll`, `regionState`, `topicTags`, `lineSequence`, `cooldownDays`, `repeatLimit`, `interruptible`, `spoilerTier`, `voicePriority`.

For the first implementation, do not build a general conversation engine around ambient chatter. Start with authored small groups attached to existing board, shop, memorial, siege and liberation states. Reuse existing NPCs only where identity and schedule support the scene. Add anonymous guild members as ambient roles only when the project is ready to expand its named-NPC roster.

## Related docs

- [[life_in_aetheria]] — guild history, traditions, slang and daily culture.
- [[weekly_board]] — board cadence and contract vocabulary.
- [[quest_outcome_grammar]] — outcomes, failure recovery and consequences.
- [[monster_core_pricing]] — core valuation and material exchange.
- [[cultural_presence_and_named_population]] — distinct voices without simulating every NPC deeply.
- [[Canon]] — settled facts and proposed locks.
