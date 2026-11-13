# Crash and log capture for playtests

Code: `Code/Ascend.Core/PlaytestLog.cs`. Tests: `Code/Ascend.Core.Tests/PlaytestLogTests.cs`.

## What a playtester gets
- A rolling log of the last 500 lines in memory (`LogBuffer`, thread-safe, long lines cut).
- On a crash, an unhandled exception or a "Save a bug report" menu entry: one text file `crash_YYYYMMDD_HHMMSS.txt` in `<persistentDataPath>/Logs/`. It has the game version, platform, GPU, save format version, scene, play time, the reason and stack, and the last 200 log lines.
- The newest 10 reports are kept; older ones are deleted.
- Reports are **redacted**: Windows and macOS user names in paths, anything that looks like a key, token or password, and email addresses are replaced. They never include the save file (it holds the player's chosen name).
- **Nothing is uploaded.** The player opens the folder and sends the file themselves (or attaches it to a Steam discussion post). Offline-first and no telemetry (no consent screen needed).

## Hooks to add in Unity (not done here: needs a Unity run, and no scene or PlayerSave changes)
1. A `PlaytestLogHook` MonoBehaviour created at boot (RuntimeInitializeOnLoadMethod): `Application.logMessageReceivedThreaded` feeds `LogBuffer` (map LogType to `LogLevel`); `AppDomain.CurrentDomain.UnhandledException` and `TaskScheduler.UnobservedTaskException` build a report with `CrashReport.Build` and write it with `LogFiles.WriteCrashReport`.
2. Fill `CrashContext` from `Application.version`, `SystemInfo.operatingSystem`, `SystemInfo.graphicsDeviceName`, the active scene name and `WorldClock.Instance.PlaySeconds`.
3. A debug key (F8) and a menu entry "Save bug report" calling the same code with reason "player report".
4. Native crashes (the engine dying) are not catchable from C#; Unity writes its own `Player.log` and crash dumps. Tell playtesters where `Player.log` is (`%USERPROFILE%/AppData/LocalLow/<Company>/<Product>/Player.log`); the redactor can be run over it by `Tools` later if needed.
5. Test in a sandbox: throw a deliberate exception in a dev scene and check the file appears, is redacted and the game does not hang.

## Soak and playtest use
The `/soak-test` and `/playtest-report` skills can ask testers to attach the newest report. Reports from a run with warnings only (no crash) are also useful: use the menu entry.
