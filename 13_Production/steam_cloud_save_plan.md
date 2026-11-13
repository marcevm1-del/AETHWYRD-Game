# Steam cloud saves: plan that keeps AETHWYRD offline-first

Owner: save-platform-engineer. Status: plan only, nothing is built and nothing needs a Steam account yet (Steam release prep is parked until M5, `production.md` §6 and `roadmap_after_upgrade_waves.md`).

## Principles (these never change)
1. **The local file is the truth.** The game reads and writes `slotN.json` and `settings.json` on disk exactly as it does today. It never waits for, asks for or needs the network or Steam. With Steam closed, offline, or absent (a non-Steam build, a dev PC), saving and loading behave identically.
2. **Steam is a copier, not a dependency.** Cloud is a sync of those same files. Remove it and nothing in the game changes.
3. **No game code is needed for phase 1.** Use Steam Auto-Cloud, which is configured on the Steamworks partner site and copies files from a folder around launch and exit. We add no SDK and no new package.
4. **A newer save is never damaged by an older build.** Already enforced: `SaveRules.Upgrade` leaves a future version alone and `Validate` rejects it (see `SaveMigrator`, job 1). So a cloud save written by a newer build and delivered to an older one is refused and kept as `.bad`, never overwritten.

## Phase 1: Steam Auto-Cloud (no code)
| Setting | Value |
|---|---|
| Root | `WinAppDataLocalLow` (Unity's `Application.persistentDataPath` is `%USERPROFILE%/AppData/LocalLow/<Company>/<Product>/`) |
| Subfolder | `<Company>/<Product>` as set in Player Settings |
| Include | `slot*.json`, `settings.json` |
| Exclude | `*.tmp`, `*.bak`, `*.bak.json`, `*.bad`, `Logs/`, `device.json` |
| Byte quota | 20 MB total (a save is well under 1 MB today) |
| File count | 16 |
| Platforms | Windows (Steam Deck runs the Windows build under Proton and uses the same path) |

Why the excludes: backups and `.bad` copies are local safety nets, not state to sync (they would also double the upload and fight with conflicts). `device.json` holds machine-specific choices (resolution, graphics quality, display), which must not follow the player to a different PC. Logs are for playtest bug reports (`crash_and_log_capture.md`).

### Blocker to fix before any release build: the save folder name
Saves live under `AppData/LocalLow/DefaultCompany/Game/` today, which is Unity's placeholder company and product name. Auto-Cloud is tied to that folder, and changing the name later would orphan every existing save. **Set the real Company and Product names in Player Settings before the first public build** (a Unity change, listed under "Needs a Unity run"). Until then nobody outside the team has saves, so the rename is free; after release it needs a one-time folder migration. The player's own slot at the old path must not be touched by tooling (CLAUDE.md); the rename is applied by the game on first launch of the new build by copying, never by moving, and the user decides when.

## Conflicts
Auto-Cloud shows Steam's own "keep local or keep cloud" dialog when both sides changed. Two things make that choice informed and safe:
- Each save already carries `SavedAtUtc`, `Version`, `Level` and the clock (`ClockSeconds`). **Add** a short human summary line (name, level, location, play time) to the slot file header so a future in-game or Steam dialog can show it. Not needed in phase 1.
- Atomic write with a kept backup (see below), so whichever copy loses can be recovered by the player from `slotN.bak.json` for at least one more save.
We never merge two saves. A save is one player's one timeline, and a field-level merge would corrupt it.

## Write path requirements (these make sync safe, and matter even offline)
- Write to a temp file, then replace, and keep the previous file as a backup. Today's `PlayerSave.Save` deletes the old file and then moves the temp into place, so a crash between those two lines leaves **no** save. Use `File.Replace(tmp, path, path + ".bak")` (falls back to copy-then-move where unavailable). Listed under "Needs a Unity run".
- Never rewrite a slot that was only loaded and not played (no autosave on load), so a stale local file does not get a new timestamp and win a conflict.
- Back up before migrating (`SaveMigrator.BackupName`, job 1): `slotN.vK.bak.json`.
- Hardcore: a `Fallen` slot is final. If the cloud holds a living copy of a fallen local slot, the Steam dialog decides; we do not try to resurrect.

## Phase 2 (optional, only if Auto-Cloud is not enough): Steamworks.NET
Needed only for things Auto-Cloud cannot do: showing sync status in our own menu, forcing a sync before quit, or per-save thumbnails. Rules:
- Wrap behind `ICloudSync { bool Available; void Push(path); void Pull(path); }` with a `NullCloudSync` default. The Steam implementation lives in its own assembly guarded by a scripting define (`AETHWYRD_STEAM`), so the non-Steam build compiles and runs without the DLL.
- Steamworks.NET must be added to `13_Production/third_party_assets.md` (MIT licence, free for commercial use) **before** it is imported.
- Every call is wrapped so any failure degrades to "local only", with at most one quiet log line. No error dialog for a missing Steam.
- Needs the Steamworks account, an app id and the user's decision; none of that is touched by agents.

## What waits on the user
- Steamworks partner account and app fee (parked, Q49). Agents never create accounts or enter keys.
- The real company and product name for Player Settings.
- Steam app id, when it exists, goes in `steam_appid.txt` for dev only (not committed).

## Needs a Unity run (not done in this branch)
1. Player Settings company/product name, then verify the save path in a built player.
2. `PlayerSave.Save`: `File.Replace` with `.bak`; `PlayerSave.Load`: if the main file is unreadable or invalid, try `.bak` before giving up.
3. Backup before migration using `SaveMigrator.PeekVersion` and `BackupName`.
4. Test in a sandbox folder, never at `slot0.json` of the player.

## Test plan
- Core (already in job 1): future version refused, old version migrates, failed migration stays invalid.
- Atomic write helper (job 3): crash simulated between temp and replace leaves the old file intact; corrupt main falls back to `.bak`.
- Manual, once a Steam build exists: play offline then go online and confirm upload; two PCs, conflict dialog; Steam Deck path.
