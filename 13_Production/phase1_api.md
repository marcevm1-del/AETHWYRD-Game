# Phase 1 wiring: gameplay API for the UI (gameplay-engineer -> ui-engineer)

All of this lives in `Game/Assets/_Game/Runtime/Player/` (namespace `Ascend.Game`) plus `Runtime/Audio/MusicStateLogger.cs`.
Read-only for the UI: every public member below is stable. If something here is wrong, the code in the files named is the truth.

## 1. Getting at the state

`PlayerWorldState` is a MonoBehaviour on the player. `PlayerSave` and `PlayerCrafting` add it themselves if it is missing, so any
object that has either can rely on it. From UI code:

```csharp
var world = player.GetComponent<PlayerWorldState>();   // or PlayerWorldState.Of(someComponent)
var craft = player.GetComponent<PlayerCrafting>();
```

Everything below is created in `Awake` from `AscendData` (data files are loaded lazily on first use). A property is **null** only when
its data file is missing, or (`Stables`, `Gear`) when the player has no `PlayerTaming` / `PlayerCrafting`; guard with `?.` in the UI.
Do not cache the Core objects across a load; ask the world state each time.

| Member of `PlayerWorldState` | Type | Notes |
|---|---|---|
| `LifeSkills` | `LifeSkills` (Core) | Same object `PlayerCrafting.Crafter` uses. `Ranks`, `Skills`, `Rank(id)`, `Xp(id)`, `XpToNext(id)`, `Eligible(id)` |
| `Home` | `Home` | tier, storage, plots (Core `Housing.cs`) |
| `Stables` | `Stables` | needs `PlayerTaming`; null on a player without it |
| `Archive` | `CivilizationArchive` | |
| `Dungeons` | `IReadOnlyDictionary<string, DungeonKnowledge>` | one per dungeon id in `dungeons.json` |
| `Labyrinth`, `LabyrinthKnowledge` | `Labyrinth`, `LabyrinthKnowledge` | |
| `Journal` | `DiscoveryJournal` | categories creature / landmark / region / secret. `Hear(cat,id)`, `Visit(cat,id)`, `StatusOf`, `Count` |
| `Events`, `EventState`, `ActiveEvents` | `EventDirector`, `EventDirectorSave`, `IReadOnlyList<ActiveLivingEvent>` | `ActiveEvents` = events present today. Advanced once per in-game day by `PlayerWorldState.Update` |
| `Gear` | `GearFitter` | runes / enchantments; `Of(gearKey)`, `BonusFor(gearKey)`, `SocketRune`, `ApplyScroll` ... |
| `Meals` | `MealBuffs` | `bool Eat(string itemKey)` on the world state eats from the bag and starts the Well Fed buff |
| `Accessibility` | `AccessibilitySettings` | the live, saved settings object |
| `AccessibilityData` | `AccessibilityFile` | palettes, ranges (static data) |
| `Music` | `MusicStateLogger` | adaptive-music state machine driver, no audio |
| `CompanionRoster` | `IReadOnlyList<CompanionData>` | from `companions.json` |
| `CompanionRules` | `CompanionRules` | presets tuning, relationships |

Methods:

```csharp
void SetAccessibility(AccessibilitySettings s);   // sanitises, replaces, pushes music prefs, raises AccessibilityChanged
void ApplyAccessibility();                          // call after you changed fields of world.Accessibility in place
event Action AccessibilityChanged;
bool Eat(string itemKey);                           // item key may carry a quality, "itm_hunters_skewer@fine"

// Companion presets and bonds (kept in memory; NOT in the save file yet, see "Not persisted")
CompanionPreset PresetOf(string companionId);       // default from CompanionData.PresetDefault
void SetPreset(string companionId, CompanionPreset p);   // stores the choice only; it does not retune a joined CompanionAI
RelationshipState BondOf(string companionId);       // created on first use from CompanionRules.Relationships
event Action CompanionsChanged;
```

## 2. Crafting window API (`PlayerCrafting`)

```csharp
LifeSkills Skills { get; }                           // same as world.LifeSkills
QualityRules Quality { get; }                        // tier list for display
CraftResult StatusOf(string recipeId, string atNpcId);        // Ok, MissingMaterials, WrongStation, RankTooLow, Unknown (not known yet)
string StatusText(CraftResult r);                    // short player text for the status
IEnumerable<RecipeData> CraftableHere(string atNpcId);        // KNOWN recipes whose station is here; atNpcId null = campfire/anywhere
MakeReport MakeQuality(string recipeId, string atNpcId, bool attune = false);
//   Core Crafter.Make with quality: report.Result, .Quality (tier id), .OutputKey, .Mark, .XpGained, .RankedUp.
//   Toasts "Made Fine Fangblade" and rank-ups itself. attune=true spends the recipe's AttuneItem (experiment bonus).
bool Make(RecipeData r, string atNpcId);             // old call, now goes through MakeQuality (talk window keeps working)
string QualityName(string tierId);                   // "Fine", "Masterwork" ... "" for normal
string ItemName(string itemKey);                     // quality-aware display name ("Fine Fangblade")
static string Name(string itemKey);                  // same, static (kept for old callers)
string InputsText(RecipeData r);                     // "2 Crude Blade (1), ..." counting every quality of the material

// life skill rank ladder
IReadOnlyList<SkillRow> SkillRows();                 // one row per life skill
string PassCommission(string skillId);               // masterwork commission handed in -> new rank or null (dev / commission NPC)
IReadOnlyList<LadderRung> Ladder(string skillId);    // F..SSS rungs of that skill

struct SkillRow   { string Id; string Name; string Rank; int RankIndex; long Xp; long XpToNext; bool CommissionPending; }
struct LadderRung { string Rank; long XpToReach; bool Reached; bool Current; bool NeedsCommission; }
```

`CommissionPending` = the XP for the next rank is in but a masterwork commission is still needed (rank D and up). Nothing is ever lost
or decays, show it as "ready for a commission".

## 3. Opening windows from the playtest keys (`PlaytestShortcuts`)

Windows are owned by ui-engineer. The keys do not reference them. `PlaytestShortcuts` raises a static event with the window's
**class name**:

```csharp
public static event Action<string> OpenRequested;     // "CraftingWindow" | "CompanionWindow" | "JournalWindow" | "AccessibilityWindow" | "PhotoModeController"
public static void Request(string windowName);        // same, callable from tests / other UI
public static event Action<bool> OverlayToggled;      // F1
```

Window name constants: `PlaytestShortcuts.Windows.Crafting` etc.

Keys: F1 playtest overlay (music log, life skill ranks), F2 crafting, F3 companion presets, F4 journal, F5 accessibility,
F6 photo mode. F8 level up (Shift = 5) and F9 raid already existed. Make each window subscribe in `OnEnable` and unsubscribe in
`OnDisable`:

```csharp
void OnEnable()  { PlaytestShortcuts.OpenRequested += OnOpenRequested; }
void OnDisable() { PlaytestShortcuts.OpenRequested -= OnOpenRequested; }
void OnOpenRequested(string name) { if (name == nameof(CraftingWindow)) Toggle(); }
```

Window contract (as agreed): `static X Instance`, `Toggle()`, `static bool IsOpen`. Keep the subscription in the window itself; the
coordinator does not need to wire anything. Note that a window component must exist in the scene (its `OnEnable` runs) for the event to reach it.

## 4. Music logger (`MusicStateLogger`, `Runtime/Audio/`)

No audio is played. It drives Core `MusicMachine` from game signals and keeps the last 30 state-change lines.

```csharp
IReadOnlyList<string> Log { get; }       // oldest first, at most 30 lines, e.g. "[03:12.4] explore -> combat (escalate, fade 1.5s) layers=bed,pulse"
string CurrentState { get; }             // "explore", "combat", "boss" ...
MusicFrame LastFrame { get; }
bool Ready { get; }                      // false when music_states.json is missing
```

## 5. Not persisted yet (needs a Core change, core-rules-engineer)

`SaveGame` has no field for companion bonds (`CompanionBondSave`) or chosen companion presets, so `BondOf` / `PresetOf` live only for the
session. Proposed: `SaveGame.CompanionBonds` (`List<CompanionBondSave>`) and `SaveGame.CompanionPresets` (`Dictionary<string,string>`),
both filled by `Upgrade`. `PlayerWorldState` already has the helpers `SaveBonds()` / `LoadBonds()` ready to wire.

Everything else in `SaveGame` (LifeSkills, GearFittings, Home, Stables, Archive, Dungeons, Labyrinth, LivingWorld, Accessibility) is saved
and loaded by `PlayerSave` through `PlayerWorldState.Capture(SaveGame)` / `Apply(SaveGame)`.
