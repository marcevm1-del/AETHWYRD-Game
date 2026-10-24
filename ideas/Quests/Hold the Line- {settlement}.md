---
type: quest
id: qst_siege_whisperwood_defence
rank: "E"
tags: [quest, siegedefence]
---
# Hold the Line: {settlement}

> Template for Whisperwood siege attacks. Grukk's warband will hit {settlement} at dusk tomorrow. Set barricades and traps, then hold for three waves (Data/World/siege_waves.json).

| Field | Value |
|---|---|
| Rank · type | E · SiegeDefence |
| Giver | [[NPCs/Captain Agnes Holt\|Captain Agnes Holt]] |
| Region | [[Regions/Whisperwood\|Whisperwood]] |
| Region state | besieged |
| Rewards | 180 gold, 16 GP, 650 XP |

## Objectives

1. {"kind":"defend","target":"{settlement}","count":3}
2. Defeat 1 × [[Monsters/Goblinoids/Hobgoblin|Hobgoblin]] (E+, Lv 32)

## Field preparation

### Hobgoblin

- **Threat:** E+ rank, Lv 32, Aggressive (aggressive_chase).
- **Element:** None; recorded weakness: Fire.
- **Read its attacks:** Slash (blue tell, melee); Heavy Swing (red tell, melee); Guard Counter (blue tell, counter).
- **Route:** encounter is listed in [[Regions/Aldmere|Aldmere]]; check the local terrain and the quest giver’s account before committing.

Preparation is advice, not a hard build check. Learn tells, use movement and defense, and bring supplies that match the trip.

## Play loop

1. **Read the brief:** separate confirmed facts from uncertainty.
2. **Prepare:** choose equipment, companions and supplies that fit the rank and objective.
3. **Investigate and act:** follow the objectives; where permitted, support combat with tracking, conversation, stealth, crafting or monster knowledge.
4. **Return and resolve:** claim the listed rewards and apply only the story flags or world-state changes recorded in source data.

**Region-state gate:** available only while the region is **besieged**.
