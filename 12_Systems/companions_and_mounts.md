# Companions and Ground Mounts (Wave C, upgrade v8)

> **Status: built in Core and data, proposals awaiting the user's OK.** Rules and data only; no Unity scene work. Audit: `13_Production/companions_v8_audit.md`. Canon proposals: `Canon.md` §6 rows 149-154. Extends `companion_field_ai.md`, `party_synergy.md` and `07_Characters/companion_relationship_pacing.md`; it replaces none of them.

## What is where

| Thing | File |
|---|---|
| The 12 companions + Tobin and Elsie | `Data/Companions/companions.json` (schema `companion`) |
| Presets, retreat, revive, downed, relationships | `Data/Companions/companion_rules.json` |
| Ground mounts | `Data/Companions/mounts.json` |
| Short banter lines (108) | `Data/Companions/banter.json` |
| Preset, retreat and revive logic | `Code/Ascend.Core/CompanionPresets.cs` (extends `Companions.cs`; `CompanionBrain.Decide` is unchanged) |
| Relationship tracks | `Code/Ascend.Core/CompanionRelations.cs` |
| Mount rules | `Code/Ascend.Core/Mounts.cs` |
| Tests | `CompanionV8Tests`, `RelationshipTests`, `MountTests` in `Code/Ascend.Core.Tests/` |

## Roster
Exactly Canon's cast: Lyra, Seraphine, Kiri, Aldric, Nyx, Bram, Kaito, Mochi, Elira, Vexmor, Torvald, Suzune, plus childhood friends Tobin and Elsie (stubs: Canon gives them no write-up yet). Each row has personality tags, role tags, a preferred role, a default preset and equipment slots. Romanceable flags equal Canon: all except Nyx and Mochi. Nobody in the roster is rideable. Ids are `cmp_*`; `npcId` links to `npcs.json` only where a row exists (Lyra, Torvald).

## Command presets
Four presets sit on top of the existing orders (Follow, Hold, Focus, Assist); each is a default order plus multipliers (leash, follow distance, retreat threshold, revive eagerness, assist bias, skill caution). **Balanced is the identity.** Aggressive leans Focus and retreats late; Defensive leans Hold and retreats early; Supportive leans Assist and revives eagerly.

The v8 command table maps as: Follow→Follow, Hold position→Hold, Attack→Focus, Defend→Hold at the player, Assist→Assist, Retreat→the same intent as Regroup (a rule on top of Follow), Interact→an out-of-combat flag. No new `CompanionOrder` value.

## Retreat and revive
- **Retreat** below `lowHpFraction` (0.25, scaled by preset), back in at `recoverHpFraction` (0.5), with hysteresis. It needs a safe path while the player is down.
- **Revive** the player or an ally within 3 m: 2.5 s cast, interruptible by a wind-up, 8 s cooldown, restores 35% HP. It never spends a rare item without consent.
- **Downed** companions are "gravely wounded" and recover on their own (Canon §5). They die **only** if *Mortal Bonds* is on **and** they take a lethal blow while already downed. A timer or a pathing failure can never kill them.

## Relationships
Four separate tracks per companion: **trust, respect, closeness, tension** (0-100 each). There is no loyalty, approval or affinity number anywhere, and a test asserts it. An event names the tracks it moves, with capped deltas; each event is once-only or has a day cooldown, so banter and repetition earn nothing. Romance is a pure gate: romanceable, adult, player opt-in, closeness and trust stages, tension below the cap. Nyx and Mochi fail it whatever their numbers. Departure needs high tension, a raised foreshadow flag and an offered repair chance, and a departed companion can return after amends. Kaito carries a state (ally / rival / fallen), not a number. Saves use a compact `CompanionBondSave`; a missing block loads as neutral defaults, so older saves still open.

## Ground mounts
Families: **horse, wolf, bear, desert beast, large ground monster**. Each has a speed multiplier, terrain multipliers (same keys as `locomotion.json`), a stamina block with hysteresis, a carry bonus, an unlock rank and `knockoutOnly` (a downed mount is knocked out, not killed, unless Mortal Bonds).

- **Speed:** base mount speed is `speedMps` = 10.0 and is flagged `placeholder: true`. It is the proposal from `world_upgrade_plan.md`, **not approved**. Real speed = base × family × terrain. An exhausted mount only walks until stamina recovers.
- **Mounted combat limits:** no big, aerial or channelled skills, a melee reach cap, a hit cap per chain, a stagger dismounts the rider, and no mounting in interior dungeons.
- **Never:** flying, celestial, dragon or aquatic mounts. The validator rejects such keys and any species that flies. Flight stays an ability (Canon).

## Not built (deferred)
Stables and sanctuaries, breeding, legendary creatures, a creature database editor, saddle and companion cosmetics, Unity scene and animation work, a Unity bridge for the new rules (the engine side must fill `CompanionContext` and read `MountTable`).

## Open questions for the user
1. Tobin and Elsie: both in every game, or one per origin?
2. Does Mortal Bonds cover all 14 companions?
3. Sella as a possible 13th companion (roster cap)?
4. Final mount speed (10 m/s is a placeholder).
5. Aquatic mounts: wanted at all?
6. Horse family stands in with `mon_thunderhorn_elk`; add a true horse species? Mythic and Spirit species (e.g. the nightmare steed, unicorn) were left out as mounts.
7. Kaito starts as `rival` (data field); confirm.
