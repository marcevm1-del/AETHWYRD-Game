# ai-engineer job 1: companion presets + group tactics wired into Unity (not yet compiled or run in Unity)

Branch `agent/ai-engineer/companion-presets-tactics`. Written without a Unity run (another session owned the editor). **Needs: Unity compile + PlayMode suite** (new tests in `Tests/PlayMode/AiPresetsAndTacticsPlayModeTests.cs`; Unity will create its `.meta`).

## Companions (`CompanionAI`, `CompanionWindow`)
- Effective tuning = `CompanionPresetBrain.ApplyPreset(base, rules, preset)`; `SetPreset` (window stance cycle) also sets the preset's default order. Balanced is the identity.
- Decision goes through `CompanionPresetBrain.Decide`: retreat below the preset threshold with hysteresis, plus the commanded "Fall back" (new command-wheel row; ends when she is out of the fight or any other order is given).
- Retreat = sprint to the player, no attacking. Added a small recovery (`OutOfCombatRegenPerSec` = 5% max HP/s, out of combat or while retreating) because HP otherwise never rose and a retreat could never end. Decision to overrule if unwanted.
- Not wired: Revive (the player has no downed state, death is a respawn) and Interact (no runtime behaviour); both fall back to Follow.

## Monsters (`MonsterController`)
- `brain.Tactics` from `Db.Tuning.GroupTactics.ToTuning()` (shared). Each frame fills `AiSense.PlayerHpFraction`, `AlliesNear`, `FlankSlot`, `FlankSlotCount`, `YieldToken` from the live fighters within `PackCallRadius` (sorted ids, `PeerCoordinator`, `YieldSec` hold). `Circle` aims at the slot angle from the pack approach axis. No state survives the fight (cleared on idle/return/death).
