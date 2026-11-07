# Companions and ground mounts v8 audit and Wave C design contract

Source: `upgrade v8` (root; image links ignored). Canon wins: `Canon.md` rows 57-62 (romance, redeemable, "Player cannot"), §5 Loss Rules, and the §6 rows "Companion roster", "Named-monster companions", "Companion support economy", "Companion field AI", "Party synergy", "Companion relationship pacing". Systems rules: `12_Systems/systems.md` (Named Monsters, Mount role, Familiars), `12_Systems/companion_field_ai.md`, `12_Systems/party_synergy.md`, `07_Characters/companion_relationship_pacing.md`. This note says what existed before Wave C, what v8 asks for, what Wave C builds, and what it skips. It is also the contract the Wave C agents build against. Scope: Core, data and docs only. No Unity scene work.

## 1. What existed before Wave C

| Area | State on main | Where |
|---|---|---|
| Companion brain | Pure decision order (safety, player request, role, reaction, recovery). Orders `Follow, Hold, Focus, Assist`. Actions `Downed, Dodge, Regroup, SignatureAssist, Attack, Guard, Follow`. `CompanionTuning` loaded from `world_tuning.json` `companions` | `Code/Ascend.Core/Companions.cs`, `CompanionTests.cs` (4 tests) |
| Companion Unity side | `CompanionAI` runs the brain, `Command(order)`, joins/leaves, downed timer. `PartnerFollower` follows tamed partners | `Game/Assets/_Game/Runtime/World/{CompanionAI,PartnerFollower,Allies}.cs` |
| Companion data | No companion table. Only 2 of the 14 have an NPC row (`npc_lyra_brightwood`, `npc_torvald_stonebeard`; both `romanceable: true`, `canDie: true`). The other 12 have prose only | `Data/NPCs/npcs.json`, `07_Characters/companions_and_npcs.md` |
| Relationships | Prose only (four tracks as "design categories, not necessarily displayed as meters"). No code, no save state | `companion_relationship_pacing.md` |
| Taming and partners | Weaken, calm/fear, offer, flee/enrage; roster (3 active, rest to ranch); bond 0-10; evolution at bond 5; trainability limits orders; roles from behaviour (Vanguard, Striker, Support, Scout, Hauler, Mount) | `Taming.cs`, `TamingTests.cs` (12 tests), `world_tuning.json` `taming` |
| Mounts | Nothing in code or data. The `Mount` role exists as a label. A 10 m/s mount speed is proposed in `systems.md` §travel and is **not applied** (pending user decision) | `systems.md`, `world_upgrade_plan.md` |
| Locomotion | Singleton table (state, terrain, slope, conditions) is the pattern to copy for mounts | `Locomotion.cs`, `Data/Player/locomotion.json`, `SINGLETONS` in `validate.js` |
| Save | `PlayerSave` stores one `Companion` npc id and `Partners` (species, name, active, bond, assists, evolved). No relationship or mount state | `Game/Assets/_Game/Runtime/Player/PlayerSave.cs` |

## 2. v8 section map

Status: **built** (already covered), **extend** (existing file grows), **new in Wave C**, **deferred**.

| v8 section | Status | Wave C decision | Covered by / lands in |
|---|---|---|---|
| 1 Advanced companion system: categories (Warriors ... Legendary) | extend | Fold into `role` and `combatStyle` fields on the 14 companion rows. No new categories beyond Canon cast. "Legendary companions" = Nyx (and named monsters) only | `Data/Companions/companions.json` |
| 1 Personality, loyalty, levels, unique abilities, backstory | new in Wave C | `personality` tag drives preset default and banter. "Loyalty" is **not** one meter: it is the four tracks (see §3.2). Companion level follows player level (as partners do). Unique ability = the existing signature assist | `companions.json`, `CompanionRelations.cs` |
| 1 Equipment customization | deferred | Companion armor and cosmetics wait for a data-only wave tied to `Equipment.cs`; Canon "Companion support economy" says gifts and gear create bond moments, never upkeep | v8 §6 below |
| 2 Combat intelligence: defensive/offensive/healing/targeting/threat/cooldowns | built | Already the `CompanionBrain` decision order and the dodge/assist cooldowns | `Companions.cs` |
| 2 Formation positioning | built | Follow/personal space/leash distances exist. A formation offset is a data field only (`formationSlot`) | `CompanionTuning`, `companion_rules.json` |
| 2 Retreat, revive assistance | new in Wave C | `Retreat` and `Revive` rules in `CompanionPresets.cs`, tuned from `companion_rules.json` | `CompanionPresets.cs`, `CompanionV8Tests.cs` |
| 2 Command table (7 commands) | extend | Mapped onto the existing orders, see §2.1. No new order enum values | `CompanionPresets.cs` |
| 2 Four presets (Aggressive, Defensive, Supportive, Balanced) | new in Wave C | Data-driven presets that bias the existing brain (thresholds, assist eagerness, regroup distance). Autonomy stays adjustable (Canon "Companion field AI") | `companion_rules.json`, `CompanionPresets.cs` |
| 3 Taming and bonding: discovery, food preferences, trust, special interactions, rare conditions | built | Weaken, calm/fear, favourite food, wildness, untameable families, bond 0-10 all exist | `Taming.cs` |
| 3 "Avoid making every creature tameable" | built | `UntameableFamilies` and the rank gate | `Taming.cs`, `world_tuning.json` |
| 3 Creature-specific challenges, bonding animations, unique recruitment conditions | deferred | Content/quest work and animation. Hook only: `tameRequires` optional flag on `mounts.json` families | quests wave |
| 4 Mounts: ground families | new in Wave C | Horse, Wolf, Bear, Desert beast (ground), Magical ground mount. Stamina, terrain suitability, bond-gated abilities, mounted-combat limits | `Data/Companions/mounts.json`, `Mounts.cs`, `MountTests.cs` |
| 4 Speed progression | new in Wave C (placeholder) | Speed is a **placeholder**, flagged `speedIsPlaceholder: true`. The 10 m/s figure is a pending user decision (§4) | `mounts.json` |
| 4 Griffins, Dragons (flying) | **rejected** | Canon "Player cannot ride flying mounts" | §3.1 |
| 4 Aquatic mounts | deferred (question) | Needs a swim/dive locomotion rule; question Q3 | §5 |
| 4 Mount animations, saddles, customization, mount inventory | deferred | Animation and cosmetics are Unity/art; mount cargo reuses the Hauler role later | none |
| 5 Growth and evolution | built / extend | Bond 0-10, evolution at bond 5, level with player exist. Wave C adds only the **mount bond** thresholds and "some creatures specialise, not evolve" as a `growth` enum on mount families (`evolves`, `specialises`, `fixed`) | `Taming.cs`, `mounts.json` |
| 6 Equipment/customization (armor, saddles, colours, sets) | deferred | See companion equipment above; Canon support economy | none |
| 7 Personalities and relationships (levels, preferences, rivalries, reactions) | new in Wave C | Four tracks, preferences list, rivalry pairs, romance gate in `CompanionRelations.cs`; banter lines in `banter.json` | `companions.json`, `banter.json` |
| 7 Companion conversations (exploration commentary) | new in Wave C | `banter.json` rows keyed by trigger tag with a cooldown and `MaySpeak`. Triggers for V7 sites are tags only | `banter.json`, `Companions.cs` `MaySpeak` |
| 8 Companion quests and personal stories | deferred | Quest authoring (quest-designer). Companion rows carry a `personalQuestId` slot, empty until written | quests wave |
| 9 Creature ecology | deferred | Belongs to the living-world/ecology wave (`borrowed_features.md` ecology cycles) | none |
| 10 Stables and sanctuaries, breeding | deferred | Ranch/stable and breeding need the Housing wave. The Taming roster already sends extras to the ranch | none |
| 11 Legendary creatures | deferred | Content wave. Nyx is already Canon's legendary companion | none |
| 12 Technical systems (managers) | extend | Map to Core classes: Companion Manager = `CompanionRoster` (in `CompanionRelations.cs`), Bonding = `Relationships`, AI = `CompanionBrain`+presets, Mount Manager = `MountRules`, Save = additive `PlayerSave` fields (Unity, later) | §6 |
| 12 Creature Database editor | deferred | Validator and schemas only (as in v6 audit) | `Tools/validate/` |
| 13 Extra ideas (sanctuary, exploration companions) | deferred | Scout role already exists | none |
| 14-15 Roadmap and master directive | superseded | "Single-player, no online/guilds/trading" matches Canon. Phases 1-2 are Wave C; phases 3-4 covered/placeholder; 5 partial; 6 deferred | this note |

### 2.1 Command table mapping

| v8 command | Maps to | Notes |
|---|---|---|
| Follow | `Follow` | as is |
| Hold position | `Hold` | as is |
| Attack | `Focus` | engage the player's lock-on target |
| Defend | `Hold` with `guardPlayer` (preset flag) | protect the player; no new order |
| Assist | `Assist` | combo openings on the player's target |
| Retreat | `Follow` plus `Retreat` rule (disengage until clear) | wheel name is Regroup in `companion_field_ai.md`; same intent. Implemented as a rule in `CompanionPresets.cs`, not an enum value |
| Interact | **no order**: a context verb | Investigate a nearby object. Out of combat only; routes to the Scout role and banter. Left as a `CompanionIntent` flag, not in `CompanionOrder`, so the brain stays unchanged |

## 3. Canon constraints and resolution

### 3.1 Conflicts

| v8 ask | Canon / rule | Resolution |
|---|---|---|
| Griffin, dragon, celestial flying mounts | Canon "Player cannot": ride flying mounts (flight and teleport are abilities only; ground mounts are fine) | **Dropped.** `mounts.json` has ground families only; a validator test fails if any family has `flying`/`aerial` movement. Nyx (the dragon) fights beside you and is never rideable |
| Aquatic mounts | Not in Canon either way | Left out; question Q3 |
| One "loyalty" meter | §6 "Companion relationship pacing": trust, respect, closeness, tension tracked separately, no single approval meter | Four independent tracks; no derived "loyalty" total in data or save. Tests assert no aggregate field |
| New companions (Warriors ... Legendary lists) | §6 "Companion roster": 12 + 2 childhood friends, no more human-cast companions | Roster fixed at 14 rows. Sella is only a possible later addition (Q2) |
| Companions die in combat | Canon §5: death is opt-in (*Mortal Bonds*; Hardcore turns it on). Otherwise "gravely wounded" | Downed state is `GravelyWounded`. Death only when `mortalBonds` is on. Revive never fails randomly |
| Romance for every companion | Canon rows 57-58 | Romance table below; gate rejects the non-romanceable at the rules level |
| Redeemable arcs | Canon row 60: Kaito redeemable | Kaito stays redeemable; no new villains made redeemable |
| Pack animals/porters can die | Canon §5 | Knocked out, cargo recoverable, unless Mortal Bonds/Hardcore |
| Tactical commands become a control scheme | §6 "Companion field AI": autonomy adjustable, small intent wheel, no RTS grid; "Party synergy": player never swaps characters | Seven commands collapse to the existing orders (§2.1). Presets only bias the AI, never remove autonomy. No per-skill commands |
| Mount speed progression | `systems.md` proposes 10 m/s; user has not decided | Placeholder: `speedIsPlaceholder: true` in `mounts.json`; speed fields exist but no pacing test depends on the value (Q1) |
| Loyalty tied to equipment/upkeep | Canon "Companion support economy": no recurring payments | Gifts/meals raise tracks once; nothing decays and nothing is owed |
| Multiplayer/trading/guild | Product lock: single-player; player cannot own a guild | Out of scope |

### 3.2 Roster and ids

Ids (fixed by the lead): `cmp_lyra, cmp_seraphine, cmp_kiri, cmp_aldric, cmp_nyx, cmp_bram, cmp_kaito, cmp_mochi, cmp_elira, cmp_vexmor, cmp_torvald, cmp_suzune, cmp_tobin, cmp_elsie`.

| Companion | Romanceable | Notes |
|---|---|---|
| Lyra, Seraphine, Kiri, Aldric, Bram, Kaito, Elira, Vexmor, Torvald, Suzune | yes | Canon row 57. All adults |
| Tobin, Elsie | yes | Childhood friends, **origin-dependent** (only one pairing is available per origin; `originGate` field) |
| Nyx | **no** | Childlike appearance, never, whatever her true age |
| Mochi | **no** | Canon row 58 |
| Named-monster companions | **no** | Lighter dialogue tier: personality, banter, bond levels, no romance or full arc. Not in `companions.json`; they use the Taming roster |
| Whiskers | **no** | Secret companion (Vex in disguise); not one of the 14, `npc_whiskers` only |
| Azrael, Celestine | **no** | Not companions anyway |

The romance gate is `romanceable` (data, from Canon) AND player opt-in AND closeness/trust thresholds. A non-romanceable id can never enter the romance state, even if flags are forced (test).

### 3.3 Contract problem found: id convention vs `npcs.json`
`npcs.json` ids are `npc_<first>_<surname>` (`npc_lyra_brightwood`, `npc_torvald_stonebeard`), and `PlayerSave.Companion` stores that NPC id. The new `cmp_<first>` ids do not match. Resolution: `companions.json` rows carry an optional `npcId` (set for Lyra and Torvald; empty for the other 12 until they get NPC rows). The save keeps the NPC id for the joined companion; the Core maps `npcId -> cmpId` for lookup. The validator checks that every non-empty `npcId` exists in `npcs.json` and that its `romanceable` agrees with the companion row. A schema must therefore not require `npcId`.

## 4. Build contract

### 4.1 Data (`Data/Companions/`)

| File | Shape | Schema | Contents |
|---|---|---|---|
| `companions.json` | array of 14 | `companion` | `id` (`^cmp_[a-z]+$`), `name`, `npcId` (optional), `kind` (`human`, `beast`, `slime`, `dragon`), `role` (Vanguard, Striker, Support, Scout, Hauler), `combatStyle` (warrior, archer, mage, healer, assassin, guardian, creature), `personality` (tags), `defaultPreset`, `romanceable` (bool), `originGate` (optional), `likes`/`dislikes` (item or topic ids), `rivals` (cmp ids), `personalQuestId` (optional), `mortalBondsOnly` death flag |
| `companion_rules.json` | singleton | `companion_rules` | `presets` (aggressive, defensive, supportive, balanced: biases on assist eagerness, dodge threshold, regroup distance, heal threshold, risk), `retreat` (hpFraction, clearSec, regroupDistance), `revive` (channelSec, rangeM, hpFractionOnRevive, cooldownSec, gravelyWoundedSec), `relationships` (track min/max, per-event deltas, romance thresholds, tension decay per day), `commands` (the §2.1 mapping as data) |
| `mounts.json` | singleton | `mounts` | `speedIsPlaceholder: true`, `families` (horse, wolf, bear, desert_beast, magical_ground; each `terrain` multipliers keyed by the locomotion terrain names, `staminaMax`, `staminaDrainPerSec`, `staminaRegenPerSec`, `exhaustedSec`, `bondThresholds`, `growth`, `speedMult` placeholder, `abilities` ids, `tameRequires` optional), `mountedCombat` (allowed actions, banned actions, dismount-on-hit rule), `knockedOutNotKilled: true` |
| `banter.json` | array | `banter` | `id`, `companion` (cmp id or `any`), `trigger` tag, `minTrack` per track (optional), `preset` filter (optional), `line` text (short, teen rating), `cooldownSec` |

Wire-up: `Tools/validate/build_schemas.js` adds the four schemas (arrays: `companion`, `banter`; singletons: `companion_rules`, `mounts`, same pattern as `locomotion`). `validate.js` adds collections and `SINGLETONS` entries, plus cross-checks: all 14 ids present exactly once; romance table matches §3.2; no `flying`/`aerial`/`water` mount family; banter `companion` ids exist; `rivals` are symmetric and exist; `npcId` exists in `npcs.json` with matching `romanceable`; presets are exactly the four names.

### 4.2 Core (`Code/Ascend.Core/`, each new file also gets a `.cs.meta` copied from the `Locomotion.cs.meta` format with a fresh random 32-hex guid)

| File | Responsibility |
|---|---|
| `CompanionPresets.cs` | `CompanionPreset` (data class), `CompanionIntent` (Interact as a flag), `Retreat` decision, `Revive` rule (range, channel, never random, Mortal Bonds respected), `CompanionDownedState` (`GravelyWounded` vs `Dead` only under Mortal Bonds), `MapCommand(string) -> CompanionOrder`. Extends `CompanionBrain` with a biased wrapper; the existing `Decide` and orders are unchanged so `CompanionTests.cs` stays green |
| `CompanionRelations.cs` | `Relationships` with four independent tracks per companion (`Trust`, `Respect`, `Closeness`, `Tension`), clamped, event-driven deltas from `companion_rules.json`, tension decay, `RomanceGate.CanOpen(companion, state)` (romanceable + opted in + thresholds), departure foreshadow flag, `CompanionRoster` (14 rows, lookup by cmp id and by npc id) and a save-safe snapshot (`RelationshipSave`: plain dictionary, versioned, unknown ids ignored on load, no aggregate field) |
| `Mounts.cs` | `MountFamily`, `MountRules.CanMount`, stamina drain/regen and exhaustion, terrain multiplier (shared terrain names with `Locomotion`), bond tier lookup, `MountedCombat.Allows(action)`, `KnockedOut` handling (never a kill unless Mortal Bonds), and a guard that rejects any non-ground movement type |

### 4.3 Tests (`Code/Ascend.Core.Tests/`; harness: `[Tests]` static class, public static void methods, `Assert`/`Repo` helpers in `Program.cs`, `Repo.Load<T>("Data/..")`)

Baseline `npm run build` = 331 tests; Wave C adds the new ones below.

### 4.4 Out of this wave
Unity wiring of presets, mount controller, banter UI, and the additive `PlayerSave` fields (relationships, mount bonds) are a follow-up for gameplay-engineer and save-platform-engineer. The existing `Companion` save field and `Partners` list are untouched.

## 5. Open questions and Canon §6 proposals

Questions for the user (put in the daily note under "Waiting on you"; never decided by agents):

| # | Question | Default used meanwhile |
|---|---|---|
| Q1 | Ground mount speed: adopt the proposed 10 m/s (about 1.5x run speed), or another figure? | Placeholder flag set; per-family `speedMult` of 1.0 relative to a not-yet-fixed base; no pacing test depends on it |
| Q2 | Sella (Whisperwood Kinship Arc): add as a 13th companion? Canon caps at 12 + 2 | Not added |
| Q3 | Aquatic mounts: allow a swim mount (ground-like, surface only), or leave out? | Left out |
| Q4 | Tobin and Elsie: confirm that only one is offered per origin | Origin-gated, one per origin |
| Q5 | Should "Mortal Bonds" on mean permanent death for the 14, or only for the Companion-flagged story cases? | Per Canon §5: opt-in, all companions |

Canon §6 proposals (proposals only; locked rows untouched):
1. **Ground mount families** row: the five families above, bond-gated abilities, mounted-combat limits (no heavy casting, no two-handed combos; dismount on break).
2. **Companion command mapping** row: the seven commands map to the existing orders; presets bias, never replace, autonomy.
3. **Companion data authority**: `Data/Companions/` is canonical for the 14 ids and their romance flags, and must equal Canon rows 57-58 (validator-enforced).

## 6. Test plan

| Test file | Cases |
|---|---|
| `CompanionV8Tests.cs` | each preset changes only the biases it declares; Balanced equals the legacy `Decide` result; all seven commands map to an existing order; Interact is rejected in combat; Retreat triggers below hpFraction and clears after `clearSec`; Revive is not random, needs range and channel, respects cooldown; downed = GravelyWounded by default, Dead only with Mortal Bonds; data load: 14 ids unique, presets exactly four |
| `RelationshipTests.cs` | four tracks move independently; no aggregate/loyalty field in the save; tension decays, other tracks do not; romance gate: all 12 romanceable pass thresholds, Nyx, Mochi and named monsters never pass even with forced flags; opt-in required; Tobin/Elsie origin gate; save round-trip and unknown-id tolerance; `npcId` lookup for Lyra and Torvald; rivals symmetric |
| `MountTests.cs` | no family has flying/aerial/water movement; all `terrain` keys are valid locomotion terrains; stamina drains, regens, exhausts; mounted combat bans per data; knocked out not killed by default; speed placeholder flag set and speed not asserted numerically; bond tiers monotonic |
| Validator | schema errors for a bad id, a missing romance flag, a flying family; cross-checks in §4.1 |
| Regression | `npm run build` passes the 331 existing tests plus the new ones; `CompanionTests.cs` and `TamingTests.cs` unchanged |

Checks each agent runs: `node Tools/run_tests.js`, then `npm run build` (data + schemas + rules), then `node Tools/vault/build_vault.js` for any doc change.

## 7. Skipped and why
Flying and aquatic mounts (Canon, question), stables, sanctuaries and breeding (Housing wave), legendary creature content, creature ecology (living-world wave), creature database editor, companion and mount equipment/saddle cosmetics, companion personal quests (quest wave), animations and scene work (Unity wave).
