# Group tactics: Unity wiring brief (Wave A3, ai-engineer)

Core is done (Wave A2): `Code/Ascend.Core/GroupTactics.cs` plus optional hooks in `MonsterAi.cs`. Nothing in Unity passes the new fields yet, so in-game behaviour is unchanged. Rules (Canon §4d): peers are symmetric, no captain/commander/rank of any kind, nothing is remembered about the player, nothing survives the end of a fight, no randomness outside the brain's injected `IRandom`.

## What `MonsterController` must pass in `AiSense` (all optional, 0/false = old behaviour)
| Field | Fill with |
|---|---|
| `PlayerHpFraction` | player HP / max HP (0-1). Leave 0 to switch the HP-aware retreat tweaks off. |
| `AlliesNear` | living monsters of any species in the fight within about the alert radius (feeds `ThreatLevel` only). `PackmatesNear` stays as is. |
| `FlankSlot` | 1-based slot from `FlankSlots.Assign` (below); 0 for none. |
| `FlankSlotCount` | slot count in play this frame (usually `min(packSize, tuning.SlotCountClamped)`); 0 uses the tuning default. |
| `YieldToken` | `PeerCoordinator.ShouldYield(selfId, members, tuning)` this frame. |

## Each frame, from the live pack list
1. Build the list of live monsters currently engaged with the same target (the same list the aggro-token code already walks). Member id = a stable per-fight int (spawn index); it only has to be stable and unique during the fight.
2. `var slots = FlankSlots.Assign(ids, tuning)`; give each monster `slots[id]` and the slot count. Assignment is by sorted id, so it is deterministic and distinct for the first `FlankSlotCount` members (extras wrap).
3. Build `PackMember { Id, HpFraction, WantsToken }` for each (`WantsToken` = last `AiCommand.WantsToken`, or it holds the token). `ShouldYield` is the same function for everyone: among members that want a token, the healthier (HP bucketed by `YieldHpGap`) keeps it, equal buckets fall to the lowest id. This is a contest rule, not a role.
4. When `ShouldYield` is true for a token holder the brain skips its windup, sets `ReleaseToken`, and keeps circling; the game returns the token to the pool as it does for any `ReleaseToken`. Hold the yield for `GroupTacticsTuning.YieldSec` before re-asking (a per-monster timer owned by the controller, cleared when the fight ends or the monster resets).

## Reading the output
- `AiCommand.FlankAngleDeg`: when `Move == Circle` and a slot was supplied, aim the circling target point at this angle (degrees) from the player-to-pack approach axis, at the usual circle radius. Otherwise 0 (circle as today).
- `AiCommand.ThreatLevel` (0-1): information only (animation barks, tuning telemetry); it does not change the brain's choices.

## Tuning
`MonsterBrain.Tactics` (a `GroupTacticsTuning`) defaults in code. After combat-designer's `groupTactics` block is in `combat_tuning.json` and core-rules-engineer exposes it on `CombatTuning`, assign it to each brain on spawn. Do not add state to the controller that outlives a fight.

## Do not
Add a leader/rank field, remember anything about the player between fights, or pick slots with `UnityEngine.Random`. Use sorted ids.
