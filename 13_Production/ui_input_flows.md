# Input flows: controller and keyboard-and-mouse (ux-designer, 2026-11-13)

Job 2 of the ux-designer queue. Handover to **gameplay-engineer** (gameplay bindings), **ui-engineer** (menus, prompts, rebinding screen) and **save-platform-engineer** (settings storage, rebinding persistence). Extends `12_Systems/hud_and_ui.md` §15 (controller layout) and §14 (accessibility). Companion to `13_Production/ui_new_systems_specs.md`.

**Sources read:** `PlayerInputDriver.cs`, `LockOn.cs`, `ThirdPersonCamera.cs`, `PlayerTaming.cs`, `PlaytestShortcuts.cs`, and the input blocks of `SystemWindow`, `NpcDialog`, `BagWindow`, `WorldMapWindow`, `PhotoModeController`, `FrontEndController`. **Not done:** no Unity run and no hands-on pad test, so every "current" row below is read from code, not played. Anything that depends on feel (deadzones, hold times, flick thresholds) is marked `TUNE IN PLAY`.

## 1. Principles
1. **Pad and keyboard-and-mouse are both complete.** Every action works on either alone; nothing needs both.
2. **One grammar for every menu:** the same five verbs on the same buttons everywhere (section 4). A player who learns one window knows them all.
3. **The last device used wins.** Glyphs, hints and cursor behaviour follow the device in use (section 7). Never show keyboard hints to a pad player.
4. **Nothing is lost by a wrong press.** Back always backs out one level; destructive or replacing actions confirm (the one-confirm rule from the new-systems spec).
5. **Steam Deck at 1280x800 is the reference:** all hints readable, no action needs a mouse, no action needs more than two buttons held.
6. **No input needs speed to be accessible:** every hold has a toggle option, every chord has a single-button alternative (section 9).

## 2. What the code does today (read, not played)
| Action | Keyboard / mouse | Pad | Where |
|---|---|---|---|
| Move | W A S D | left stick | `PlayerInputDriver` |
| Camera | mouse delta | right stick | `ThirdPersonCamera` |
| Sprint / dodge | Left Shift (held = sprint, press = dodge) | B (east) | driver |
| Walk | Left Alt | none | driver |
| Jump | Space | A (south) | driver |
| Light attack | LMB | X (west) | driver |
| Heavy (hold = charge) | RMB | Y (north) | driver |
| Block / parry | Q | RT | driver |
| Lock-on, flick to switch | MMB, mouse flick | R3, stick flick | `LockOn` |
| Skills 1 to 4 | keys 1 2 3 4 | RB held + X, Y, A, B | driver |
| Ultimate | R | L3 + R3 chord | driver |
| Quick item (bomb) | G | D-pad up | driver |
| Interact | E | D-pad down | driver |
| Potion | H | D-pad right | driver |
| Tame | T | D-pad left | `PlayerTaming` |
| Companion order | Z | LB | `PlayerTaming` |
| Bag | I | Start | driver |
| Bestiary | B | none | driver |
| Map | Tab or M | Select | driver |
| Playtest windows | F1 to F6, F8, F9 | none | `PlaytestShortcuts` (dev only) |
| Menus: confirm | Enter (E in dialog) | A | `SystemWindow` etc. |
| Menus: back | Esc | B | same |
| Menus: alt action | X | X | same |
| Menus: tab or step | Q / E or arrows | LB / RB or D-pad | `SystemWindow` |

## 3. Conflicts and gaps found (with a decision each)
| # | Finding | Decision | Owner |
|---|---|---|---|
| I1 | **Start opens the Bag; the doc says Start opens the Status Window** (hub with tabs). There is no Status hub or pause screen in the input code. | Start and Esc open the **Status Window hub** (Canon: tabs Status, Skills, Class, Titles, Bonds, Bestiary, Journal, Map, Memories, System). Bag becomes a tab with direct keys kept (I). Pause lives inside the hub (and in combat Esc and Start show a small Pause card with Resume, Settings, Quit to menu). | gameplay-engineer + ui-engineer |
| I2 | **Interact is D-pad down, not X.** `hud_and_ui` §15 says X / LMB interact, D-pad for quick items. X and LMB are the attack buttons, so an interact on them would swing a sword at a shopkeeper. | Keep **interact on its own button**: pad **D-pad down** stays but I propose moving it to **Y (north) when out of combat and no heavy is charging** only if play-tests show D-pad is too awkward on the Deck (`TUNE IN PLAY`). Update §15 to match the code and record the reason. Keyboard stays E. | ux-designer (doc), gameplay-engineer |
| I3 | **D-pad is overloaded:** up quick item, right potion, left tame, down interact. No room for a quick-item wheel, whistle-mount, or hotbar scroll. | Keep four fixed. Add **quick-item select** to a hold on D-pad up (opens a 4-slot radial) so more than one bomb type fits later. Mount whistle goes on **hold D-pad down** out of combat. | gameplay-engineer |
| I4 | **Companion command wheel:** `companion_field_ai.md` wants six intents on a wheel; code has a single LB "order" cycle. `hud_and_ui` says hold LB. | **Hold LB** opens the six-intent wheel (Focus, Hold, Assist, Support, Conserve, Regroup) with the right stick; a **tap LB** keeps the quick default (cycle). Keyboard: **hold Z** opens the wheel, tap Z cycles, 1 to 6 or mouse picks. | gameplay-engineer |
| I5 | **Ultimate is a two-stick chord (L3 + R3)** and keyboard R. The chord is hard on some hands and on the Deck's grips. | Add **LB + RB together** as an alternate and let the player pick either in Controls. Keep both chords out of accidental reach: require both within 0.15 s (`TUNE IN PLAY`). | gameplay-engineer |
| I6 | **Walk (Left Alt) has no pad equivalent.** | Pad: **gentle stick tilt walks** (analog already); add a Walk toggle option. Not a new button. | gameplay-engineer |
| I7 | **Free aim (LT / RMB hold) in §15 is not in code.** RMB is heavy attack here. | Free aim applies to ranged weapons only and is **hold LT** on pad; keyboard uses **RMB hold only when a ranged weapon is equipped** (heavy otherwise). Decision recorded; implement with the ranged kit. | gameplay-engineer |
| I8 | **Skill modifier on RB overrides face buttons.** With RB held the face buttons cast skills and do not attack; there is no way to tell this on screen. | While RB is held, the hotbar shows the four skills over X, Y, A, B glyphs and the rest of the HUD dims 15 %. A **second palette** (RB + LB held) is reserved, not built. | ui-engineer |
| I9 | **Keyboard Q is block and also tab-step-left in menus; E is interact and tab-step-right.** Safe only while a modal is open (the code uses PadActive and modal state), but a window that opens on a held Q would flicker. | Add a **0.15 s input grace** when a window opens (ignore buttons already held). | ui-engineer |
| I10 | **No rebinding, no input asset.** All bindings are built in code (`new InputAction`). `hud_and_ui` §14 promises full remapping, hold/toggle and a one-handed preset. | Move to an **`InputActionAsset`** with the action names in section 5 and rebinding overrides saved in the settings file (JSON of `rebindingOverrides`). Settings only: **never** the player's save. | save-platform-engineer |
| I11 | **Menus use IMGUI `OnGUI` input blocks per window,** each with its own copy of the verbs (SystemWindow, NpcDialog, Bag, Map each differ slightly: Map uses LB/RB for pages, SystemWindow for tabs; Dialog uses 1 to 9 for options). | One shared **menu input layer** reading the verbs in section 4; windows ask for "Confirm, Back, Alt, Step(-1/+1), Page, Move". Keyboard digits 1 to 9 remain a shortcut for lists of 9 or fewer. | ui-engineer |
| I12 | **Hints are written per window as raw strings** ("Tab / M close, 1 / 2 or LB / RB pages"); they show both devices at once and do not swap. | Hints come from a hint table keyed by verb and device (section 7). | ui-engineer |
| I13 | **Photo mode has Enter and A to capture** but no pad exit hint on the HUD-hidden screen, and Esc is the only keyboard exit. | No change needed: the hint already stays up for 4 s after any input (`_hintUntil`) and B exits on pad. Read from code only, not played. | none |
| I14 | **F1 to F9 are playtest keys** and must be excluded from rebinding and stripped from release builds. | Keep in editor and development builds only. | gameplay-engineer |

## 4. The menu grammar (applies to every window)
| Verb | Pad | Keyboard / mouse | Notes |
|---|---|---|---|
| Move cursor | D-pad or left stick | arrows or W/S, mouse hover | hover moves focus; a click confirms |
| **Confirm** | A | Enter, Space, LMB | Space only outside text entry |
| **Back** | B | Esc, RMB, mouse side button | backs out one level, then closes |
| **Alt action** (secondary: remove, compare, feed, details) | X | X, MMB | each screen names it on the hint line |
| **Tab or step** (previous / next) | LB / RB | Q / E, Page Up / Page Down, mouse wheel on tab bar | wheel over a list scrolls the list instead |
| Page scroll | LT / RT | Page Up / Page Down, wheel | long lists |
| Toggle detail / compare | Y | C | |
| Close everything | hold B 0.6 s | Esc twice | returns to the world |
| Direct open | Start hub, Select map | I bag, B bestiary, Tab or M map, J journal, P party, K skills | see section 6 |

- **Slider rows:** left and right adjust one step; hold for repeat (every 0.1 s after 0.4 s, `TUNE IN PLAY`). Home and End jump to ends on keyboard.
- **Text entry (name fields):** typing captures every key including Space, W, A, S, D; Esc leaves the field, Enter commits. On pad, A opens an on-screen keyboard (Steam Deck's own keyboard is acceptable first).
- **Wrap:** cursors wrap at list ends on pad, stop at the ends on keyboard (so holding down does not loop endlessly).
- **Disabled rows** are reachable and read their reason aloud (menu narration), never skipped.
- **Mouse is optional in menus** but fully supported; moving the mouse switches to mouse mode (section 7).

## 5. Action names for the input asset
Gameplay map: `Move, Look, Sprint, Dodge, Walk, Jump, LightAttack, HeavyAttack, Block, LockOn, LockSwitch, Skill1..Skill4, SkillModifier, Ultimate, QuickItem, Interact, Potion, Tame, CompanionOrder, CompanionWheel, MountWhistle, FreeAim`.
Menu map: `UiMove, UiConfirm, UiBack, UiAlt, UiStepPrev, UiStepNext, UiPageUp, UiPageDown, UiToggleDetail, UiCloseAll`.
System map: `OpenHub, OpenMap, OpenBag, OpenBestiary, OpenJournal, OpenParty, OpenSkills, PhotoMode, Screenshot`.
Developer map (editor and dev builds only, never rebindable): `PlaytestOverlay, PlaytestCrafting, ... F9`.

Rule: one action maps to up to **two bindings per device** (primary and alternate). A binding that is already used in the same map is a **conflict**: the Controls screen swaps the two and says so (section 8).

## 6. Direct-open keys and the hub
| Window | Pad | Keyboard | Opens as |
|---|---|---|---|
| Status Window hub | Start | Esc (out of combat), P in combat Esc = pause card | tabs |
| Map | Select | Tab, M | Map tab |
| Bag | hub tab | I | Bag tab |
| Bestiary | hub tab | B | Bestiary tab |
| Journal | hub tab | J | Journal tab (rumours, discovery, archive) |
| Party and companions | hub tab | P | Bonds tab |
| Skills | hub tab | K | Skills tab |
| Crafting, fitting, shop, stable | interact with the station or desk | E | station window |
| Photo mode | hold Select | F12 or hold Tab | photo mode |

Pressing the same key again closes. Opening a second window from the hub switches tab, not stacks. Windows over the world never stack more than one modal; dialogue and a station window are modal and close the hub.

## 7. Device switching, glyphs and hints
- **Detect:** any keyboard key or mouse move/click sets keyboard mode; any pad button or stick past 0.25 sets pad mode (the current `PadActive` flag does this; extend it to gameplay prompts).
- **Glyph set:** Xbox-style default; auto-detect PlayStation, Switch and Steam Deck and show their face labels (a settings override exists in Accessibility: "Button prompts: Auto, Xbox, PlayStation, Switch, Keyboard").
- **Hints** show only the active device, e.g. `A Confirm   B Back   X Remove   LB RB Tabs` or `Enter Confirm   Esc Back   X Remove   Q E Tabs`. A verb with no meaning on the current screen is not shown.
- **Interaction prompt (world):** the rune circle shows the active glyph and fills while held. Prompts that need a hold show a hold ring; toggle mode (section 9) turns them into a press.
- **Mouse in menus:** the cursor is hidden in gameplay and shown when the mouse moves in a window; it hides again after 3 s idle or on pad input.
- **Switching mid-menu** never loses the cursor row.

## 8. Controls screen and remapping (spec for ui-engineer)
A System-window tab under Settings, three pages: **Pad, Keyboard and mouse, Options**.
- **List:** one row per action in the groups Movement, Combat, Companions, Menus and Windows; row shows action name, primary and alternate binding as glyph chips, and a conflict chip when one exists.
- **Rebind flow:** A or Enter on a chip, "Press the new button, Esc to cancel", timeout 5 s cancels. If the binding is taken: "Swap with Dodge?" with Yes (swap) and No (cancel). No silent overwrite.
- **Reserved, never rebindable:** Esc (back or hub), Start, the menu confirm and back on pad, and the developer map.
- **Reset:** per row ("Default") and per page ("Reset page", confirmed).
- **Presets:** Default, Left-handed (mirrors move and look), **One-handed left**, **One-handed right** (section 9), Southpaw sticks (swap sticks), Legacy (Z/X/C style for people used to older action games; optional, low priority).
- **Storage:** overrides in the settings file only; loading ignores unknown actions and never throws; a missing file gives defaults. Old settings files load (null-coalesce).
- **Test button:** "Try it" row that shows live pressed state of each action, for checking a rebinding without playing.

## 9. Options that change how inputs behave
| Option | Choices | Default |
|---|---|---|
| Hold actions | Hold / Toggle, per action group (sprint, block, free aim, interact fill) | Hold |
| Sprint | Hold Shift or B / Toggle / Auto-sprint when stick fully pushed | Hold |
| Interact fill | Hold to fill / Press once | Hold |
| Lock-on | Press to toggle / Hold | Toggle |
| Look inversion | Invert Y, Invert X, separately for pad and mouse | Off |
| Sensitivity | Mouse 0.1 to 2.0, stick 0.1 to 2.0, separate X and Y | 1.0 |
| Stick deadzones | Left 0.05 to 0.4, right 0.05 to 0.4 | `TUNE IN PLAY` |
| Aim and look acceleration | Off / Low / High | Low |
| Vibration | 0 to 100 %, off | 70 % |
| Auto-lock assist | Off / Low / High (story difficulty assist) | Low |
| Timing assist | Auto-dodge window, parry window indicator (story assists in `hud_and_ui` §14) | Off |
| Button prompts | Auto, Xbox, PlayStation, Switch, Keyboard | Auto |
| **One-handed** | pad left-hand or right-hand preset; keyboard left-hand or right-hand preset; mouse-only preset (see below) | Off |

**One-handed presets (first draft, `TUNE IN PLAY`):**
- *Pad, left hand only:* left stick moves; left stick press = lock-on; LB hold = skill modifier; LT = block; face buttons are not needed (D-pad = attack cycle X, Y; A jump).
- *Pad, right hand only:* right stick moves the camera and steers; face buttons attack; RT block; RB skill modifier; movement is **auto-run toward the camera heading** while RT is not held (an assist, optional).
- *Keyboard, left hand:* WASD moves, Space jump, Shift dodge, Q block, E interact, R ultimate, 1 to 4 skills; attacks on **F (light) and V (heavy)**; camera on **arrow keys**.
- *Mouse only:* LMB light, RMB heavy, MMB lock, wheel cycles skills, click-to-move **not** provided (declare as not supported rather than half-supported).

## 10. Flows per context
| Context | Pad | Keyboard / mouse | Notes |
|---|---|---|---|
| **Exploring** | stick move, right stick camera, A jump, B dodge or sprint, D-pad down interact | WASD, mouse, Space, Shift, E | interaction ring fills on hold |
| **Combat** | X light, Y heavy, RT block, B dodge, R3 lock, RB + faces skills, L3 + R3 or LB + RB ultimate | LMB, RMB, Q, Shift, MMB, 1 to 4, R | Flash Time keeps the same inputs |
| **Dialogue** | A confirm line or choice, D-pad up/down choices, B skip or leave, hold X appraise | Enter or E, arrows, 1 to 9 for choices, Esc, hold X | hold input fills a ring; advancing text is one press, never a hold |
| **Companion wheel** | hold LB, right stick to pick, release picks | hold Z, mouse or 1 to 6, release picks | game slows to 0.3 x while open (not a pause) |
| **Shop** | D-pad list, A buy, X sell toggle, Y compare | arrows, Enter, X, C | haggling on A/Enter with a visible meter |
| **Station windows** (craft, fit, stable) | per menu grammar | per menu grammar | tabs on LB/RB or Q/E |
| **Puzzle panel** | D-pad to pick, A to act, X Hint, Y Assist, hold B leaves | arrows, Enter, X, C, Esc | Skip needs a confirm |
| **Plots grid** | D-pad moves in the grid, A plant or harvest, X details | arrows, Enter, X | long press A harvests all ready plots (optional) |
| **Dungeon map** | stick pans, LB/RB floor up/down, A set marker | WASD pan, Q/E floors | same as world map |
| **Map** | stick pan, triggers zoom, LB/RB page, Y overlay, R3 centre | WASD, wheel, 1 / 2, O, C | matches today's code |
| **Photo mode** | stick moves camera, triggers zoom, A capture, Y hide HUD, B exit | mouse, wheel, Enter, H, Esc | matches today |
| **Front end** (title, menu, creator) | D-pad or stick, A confirm, B back, X alt, Start any | arrows or WASD, Enter, Esc, X | text entry as in section 4 |

## 11. Accessibility hooks for input (full review is job 3)
- Every rebinding, hold-to-toggle and one-handed option works without a restart.
- No input requires a button mash or a very quick sequence; the only timing-based inputs are parry and perfect dodge, each with an assist (indicator, wider window).
- Haptic cues are a supplement; every vibration cue also has a visual and, where it matters, an audio cue.
- Menu narration speaks the focused row, chip and key hint.
- Steam Input: ship a default Steam Input configuration that maps to the pad layout in section 2 and exposes the gyro as **off**; touchpad / trackpad acts as mouse for menus.

## 12. Test checklist (qa-tester, ui-engineer)
| # | Check | Result |
|---|---|---|
| T1 | Every action in section 2 works with pad only, then keyboard and mouse only | NOT ASSESSED: no play-test run in this job |
| T2 | Every menu closes with Back and never traps focus | NOT ASSESSED |
| T3 | Hints swap with the device and never show both | NOT ASSESSED |
| T4 | Rebind each action, restart, bindings persist; a settings file from an older build loads | NOT ASSESSED (no input asset yet) |
| T5 | Conflict swap shows its confirm and never leaves an action unbound | NOT ASSESSED |
| T6 | Hold-to-toggle for sprint, block, interact works | NOT ASSESSED |
| T7 | Opening a window with a button still held does not fire it | NOT ASSESSED (I9) |
| T8 | 1280x800 on a Steam Deck: no hint clipped, text scale 1.5 holds | NOT ASSESSED |
| T9 | F-keys absent from a release build and from the Controls screen | NOT ASSESSED |

## 13. Decisions made (overrule me)
1. Start and Esc open the Status Window hub; Bag and others become tabs with direct keys.
2. Interact keeps its own button (D-pad down, keyboard E); X and LMB stay attacks.
3. Hold LB (hold Z) opens the six-intent companion wheel; tap keeps the quick cycle.
4. Ultimate gets an alternate LB + RB chord.
5. Menu grammar: A confirm, B back, X alt, LB/RB tabs, Y detail; the same on every screen.
6. Rebinding stored in settings only, never in the save; Esc, Start and developer keys are reserved.
7. No click-to-move and no half-supported mouse-only mode.

## 14. Handover
- **gameplay-engineer:** I1 (hub open), I2 to I7, one input asset, hold/toggle behaviour, wheel.
- **ui-engineer:** shared menu input layer (I11), hint table (I12), input grace (I9), Controls screen (section 8), prompt glyphs.
- **save-platform-engineer:** settings JSON with rebinding overrides (I10), defaults on missing file, Steam Input default config.
- **qa-tester:** section 12.
