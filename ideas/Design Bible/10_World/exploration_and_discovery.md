# Exploration and Discovery: The Route Is the Adventure

> Design proposal informed by official developer interviews. Canon and region data remain authoritative; spacing and frequency targets are untested until graybox play.

## The player promise

Travel in Aetheria should feel scenic when the world is safe and attentive when the world is dangerous. The player should usually have a reason to continue beyond the quest marker: a silhouette on the horizon, a trace to interpret, an unusual sound, a person who needs help, an ecology clue or a route that may change what they know about a familiar place.

Exploration is not a checklist of icons. It is a relationship between **what the player notices, what they infer and what they choose to pursue**. Guidance can be available without revealing every secret. A player who wants a clear route should be able to use it; a curious player should still find things the interface did not enumerate.

## Research notes: transferable patterns

### Familiar ground can become newly strange

Nintendo’s *Tears of the Kingdom* developers described how adding caves to cliffs changed the meaning of familiar terrain: after finding one cave, players could wonder where else a cliff might hide an entrance. The team also discussed adjusting sky-island placement and appearance when the view became too cluttered. The transferable lesson is to make a discovery change how the player reads nearby space, while treating visual density as a composition problem—not a content quota. ([Nintendo, Ask the Developer Vol. 9, Part 3, 9 May 2023](https://www.nintendo.com/en-ca/whatsnew/ask-the-developer-vol-9-the-legend-of-zelda-tears-of-the-kingdom-part-3/))

### Show a destination; let the route conceal itself

The *Dragon’s Dogma 2* director described placing an intriguing destination in view, then shaping portions of its route with occlusion so the approach still feels like an adventure. The same interview emphasized experience quality and frequency over map size. This is a useful direction for Ascend’s mountains, forests, cliff paths and underworld entrances, but it provides no validated spacing or travel-time formula. ([PlayStation Blog Japan, director interview, 19 March 2024](https://blog.ja.playstation.com/2024/03/19/20240319-dragonsdogma2/))

### Guidance should allow independence

Bandai Namco’s official *Elden Ring* overview describes Sites of Grace and map fragments as sources of directional guidance, while treating avoidance and returning later as viable responses to danger. For Ascend, this suggests making the main lead readable while allowing the player to postpone a threat or follow a side discovery. ([Bandai Namco, Elden Ring Gameplay Overview, 2022](https://www.bandainamcoent.com/es_mx/news/elden-ring-introduction-part-3-gameplay-overview))

These sources document specific developer statements. The design rules below are **Ascend proposals inferred from those examples**, not claims that the cited games use these exact systems.

## The three discovery layers

The shared information rules, event receipts and offline boundaries are defined in [[../01_Core_Concept/world_response_and_information_flow]]. This document specifies how those rules feel during travel.

### 1. Landmarks

Landmarks orient the player before they know the local story. Each region needs at least one distant anchor that can be recognized from more than one approach: a crown of cliffs, a tower, a World Tree branch, a broken bridge, a strange moonlit ridge or a moving silhouette.

A landmark should answer “where am I?” and raise a second question: “why is that there?” It does not need to contain a reward. A visible landmark can make the world feel coherent simply by letting the player connect routes and memories.

### 2. Leads

Leads point toward investigation without giving away the full answer. They can come from a rumor, a track, an unusual plant, damaged architecture, weather, a missing animal, a changed patrol or a companion’s observation.

The journal separates information into three confidence levels:

- **Observed:** the player personally saw or measured it.
- **Reported:** a named source or reliable institution told the player.
- **Unconfirmed:** a rumor, theory or interpretation that may be wrong.

This keeps uncertainty meaningful. The player can act on a rumor, ask another person, test a hypothesis or leave it unresolved. When evidence changes the likely answer, the journal updates the *reason*, not only the quest marker.

### 3. Unmarked discoveries

Unmarked discoveries are optional details the player notices without being directed there: a safe ledge behind a waterfall, a creature’s feeding trail, a quiet shrine, an old camp, a hidden approach to a familiar ruin or a small act of kindness between NPCs.

Use them sparingly. If every metre contains a reward, nothing feels hidden and travel becomes work. A discovery can be valuable because it changes the player’s understanding, gives a shortcut, supplies a useful material, creates a memory or simply offers a beautiful pause.

## Landmark and route grammar

Plan each region as a readable sequence of nested questions:

1. **Distant anchor:** what can the player recognize from a long way off?
2. **Route choice:** what are two plausible ways to approach it?
3. **Intermediate clue:** what tells the player that one branch may be safer, stranger or more rewarding?
4. **Local tell:** what detail reveals the hidden entrance, encounter or story object?
5. **Return knowledge:** what did this trip teach that makes the next trip different?

Some routes keep the destination visible; others briefly hide it behind a ridge, canopy, building or weather. When the destination is occluded, preserve another signal—a sound, a trail, a shaft of light, a map clue or a conversation. The player should feel uncertain about the route, not uncertain whether the game has stopped communicating.

Climbing, gliding and later movement abilities should change route choice, not merely increase speed. A cliff might offer a longer safe trail, a climb with readable rests, or a short glide to a visible shelf. Show plausible landing and fallback areas. The obvious route remains valid; secret routes reward curiosity but are not required for ordinary progression.

## A guidance system that respects the player

The broader signal-to-receipt pattern, including provenance and accessibility options, is defined in [[world_response_and_information_flow]].

The map and journal can record discoveries in layers:

- A **rumor** marks a broad search area and names who said it.
- A **clue** narrows the area or adds a hypothesis.
- A **confirmed discovery** becomes a stable map entry.
- An **unseen secret** remains off-map until the player notices it or finds a relevant clue.

Let players choose a guidance style: a clear route for their active objective, a broad region hint, or no active marker. Accessibility options can add stronger navigation cues without changing rewards or judging the player. Never make an essential objective depend on color alone or on noticing a low-contrast detail.

Expose guidance controls independently: **natural/world cues**, **broad search area**, **direct route/marker**, and **off**. Players may mix channels where practical (for example, broad area plus audio direction). Every essential lead must have an accessible equivalent clue path: readable text/journal and map clues for audio or subtle visual tells; captions/directional sound options for audio cues; shape, motion or contrast plus labels rather than color alone; and direct guidance as an option. Companion hints are helpful redundancy, never the sole route. Assistance changes presentation, not rewards or objective availability. Optional secrets can remain undiscovered, but essential progression cannot depend on a narrow perception channel or pixel hunting.

After a long absence, the journal may offer a spoiler-safe return recap: discovered current state, recent resolved outcomes with their known causes, active leads and next-step choices. Do not reveal undiscovered content or pretend that real time advanced the world. See [[reactive_world_and_field_journal]] for recap and memory rules.

## Travel pacing: vary attention, not just encounter count

A long route can contain a deliberate mix of:

- a combat encounter that teaches or tests one readable behavior;
- a social encounter that introduces a person, rumor or obligation;
- a tracking or ecology clue;
- a resource opportunity with a meaningful choice to gather or continue;
- a weather or terrain obstacle with multiple approaches;
- a quiet stretch where the player can enjoy the vista, music and companion conversation.

The mixture changes with region state, time, weather and story. A Besieged road can contain signs of pressure without forcing combat every few minutes. A Liberated route can feel safer and busier while still allowing ordinary monsters, stampedes and calamities. These differences are world-state feedback, not a new siege cycle.

Repeated travel should become more comfortable through roads, knowledge, relationships, abilities and carefully limited teleportation. Preserve the option to travel manually for discoveries; make skipping a known route convenient when the player has already earned a reliable connection.

## Ecology clues as exploration content

Monsters make the landscape readable. Teach players to notice where a creature feeds, rests, hunts, hides, migrates or avoids weather. A clue should help answer a practical question: where might it be, what could draw it toward a settlement, and what is a safe time or approach?

One discovery can teach a transferable rule, but the next instance should deepen or change that rule. A player who sees an animal shelter before a storm can later recognize a similar sign elsewhere; a different species might exploit the same weather in the opposite way. This gives the player a feeling of learning the world without cloning the same encounter.

## Region kit for production

Before producing a region’s detailed content, define:

- a distant landmark and an arrival composition;
- one traversal obstacle with at least two sensible solutions;
- one local ecology rule and its visible evidence;
- one settlement routine that shows ordinary life;
- one clue chain that rewards investigation;
- one signature encounter grounded in the region’s ecology or history;
- one optional quiet place for rest or a companion moment;
- a small number of persistent visual and social changes for Besieged, Weakened and Liberated states where siege applies.

This is an authoring kit, not a player-facing checklist. Reuse rigs, props and encounter grammar where sensible, but give each region a cultural, ecological or traversal reason it cannot be mistaken for another. Regional details should grow from the existing gazetteer and data, not from a quota to add new lore.

## Prototype and evaluation

Do not import map measurements from larger studios. Public interviews do not establish ideal landmark spacing, climbing duration, glide distance or encounter frequency. Test those in a small route and tune from observation.

For a Ring 0 route, record:

- whether a first-time player can name the destination and one reason to go there;
- how often they notice something without a marker;
- whether they can explain why a creature or hazard is present;
- how long a quiet stretch feels before it becomes aimless;
- whether an optional detour feels like a reward or a chore;
- whether the route remains readable with reduced camera effects and color-independent cues.

The success question is: **after a journey, can the player tell a small story about what they noticed, what they decided, and how the world answered?**

## Research trace

Related systems: [[Design Bible/12_Systems/systems|world state and liberation]], [[Design Bible/11_Quests_Encounters/quests_and_encounters|quests and encounters]], [[Design Bible/08_Bestiary/monster_design_kit|monster design]] and [[Design Bible/01_Core_Concept/open_world_rpg_research_2026|the 2026 comparable-game research]]. Source-by-source notes and caveats are in the repository’s research_notes folder.
