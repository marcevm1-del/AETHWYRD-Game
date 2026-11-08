# Phase 1 code review (commit d6914c6, branch phase1-wire-core)

Read-only review. Nothing was run (no Unity, no tests). Ranked by severity.

## High
1. **Crafted non-Normal items vanish from the game.** Crafter.Make stores output as `itm_x@fine` (ItemQuality.Compose), but these places look up the raw key in Db.Items and skip or fail:
   - BagWindow.cs ~line 70 (`db.Items.TryGetValue(kv.Key) ... continue`): the item cannot be equipped, used or sold.
   - BagWindow ~line 66: `db.Items[id]` for an equipped slot would throw KeyNotFound.
   - PlayerInventory.DrinkHealingPotion (~line 82): a Fine potion is never found.
   - PlayerCombat.cs:92: equipment kit is built from raw ids.
   - Quest "collect" counts and shop sell use exact ids.
   Scenario: rank C smith (+0.25 per rank index gives the first Fine) crafts a Fine Fangblade and it disappears from the Bag. Normal quality is unaffected, so it is latent until mid-game ranks. Fix: split the key with ItemQuality.Split in every consumer (or do not emit tier keys until the consumers handle them).
2. **CraftingWindow blocks valid crafts when inputs are quality stacks.** PlayerCrafting.StatusOf calls Crafter.CanCraft, which counts exact ids via Missing, while Crafter.Make counts every quality (CanMake). CraftingWindow.DoCraft returns early on `MissingMaterials` from StatusOf, so a bag holding only `itm_herb@fine` shows "Missing" and the craft is refused. NpcDialog.RebuildWorkbench has the same mislabel ("(missing)"), as does PlayerCrafting.StatusText (it uses Crafter.Missing). Experiment also removes exact ids. Fix: expose Core CanMake (public) and use it in StatusOf, StatusText and NpcDialog.

## Medium
3. **Rank gating has no way up past D.** life_skills commissionFromRank is D, and PlayerCrafting.PassCommission has no caller anywhere in Runtime. Recipes with lifeRank D or higher (bronze greaves, cursed iron blade, greater healing potion, shadehide cloak and others) become permanently RankTooLow once the player reaches the commission gate. Torvald and Fennick also sell recipes (`Learn`) that cannot be crafted yet, with no warning at purchase. This is a gameplay regression versus the old unconditional craft. Fix: add a commission source (quest hook), or warn on Learn and flag it in the handover.
4. **Load merges instead of replacing for Archive, DungeonKnowledge, LabyrinthKnowledge** (Core `Load` never clears). A reload or slot switch in a session keeps knowledge from the earlier state. By design for "never downgrade", but wrong for a true load. Fix: add a Reset/clear in Apply before Load, or construct fresh objects.
5. **Per-frame allocations.**
   - SystemWindow.AnyOpen (used via UiModal.Any / WindowHub.AnyOpen, polled by input code every frame) runs `All.Any(lambda)` on a List through IEnumerable, which boxes an enumerator each call. Use a plain for loop, or keep an open counter.
   - MusicStateLogger.Sample (4 Hz) calls FindObjectsByType twice (MonsterController, CompanionAI), allocates arrays, and `_prevEngaged.All(lambda)`. Cache a registry (the MonsterController/CompanionAI static lists) instead of scene scans.
   - SystemWindow.Update rebuilds all rows with LINQ twice a second while open (acceptable, but the cursor index can land on a different row if the row count changes between rebuilds).
   - PlaytestShortcuts.OnGUI allocates a new GUIStyle every OnGUI event while the overlay is visible, and OverlayText builds strings each event. Cache both.
6. **MusicStateLogger with SignalSource** mutates the externally supplied MusicInput (`_input.Outcome = None` after each tick) and replaces `_input` with it. Copy the input, or do not reset it.

## Low
7. **Crafting seed is not stable.** `CraftCounter = _crafts + (int)PlaySeconds`: `_crafts` is not saved, and different (crafts, seconds) pairs collide, so the same recipe can repeat identical jitter. Use a saved monotonic counter.
8. **Duplicated Core logic.** CraftingWindow.ExpectedQuality re-implements the Make quality formula (display and craft can drift). Add a Core `QualityRange(...)` and call it from both.
9. **Static Instance windows** (CraftingWindow and the others) plus static event `OpenRequested` rely on the SubsystemRegistration reset in PlaytestShortcuts only. SystemWindow `_lastCloseFrame` and the `All` list are not reset on domain-reload-disabled play, which can leave `AnyOpen` stale for one frame. Add a ResetStatics there too.
10. **IMGUI.** Windows do not pause time or unlock the cursor (UiModal only blocks controls), so enemies can hit the player while a window is open. The glyphs "▶", "■" and "·" may render as boxes in the default IMGUI font. SystemWindow.OnGUI recomputes layout each event; fine for a placeholder.
11. **CompanionWindow, JournalWindow, AccessibilityWindow, PhotoModeController** were not reviewed in depth (time). Worth a second pass for null World access.

## Verified clean
- Save compat: SaveRules.Upgrade null-fills every new section, drops bad companion rows, and does not bump the version (additive). PlayerWorldState.Apply is null-tolerant and each section is Guard-isolated. LifeSkills, Home, Stables and GearFitter `Load(null)` are safe.
- No shared-mutable data singleton bug: accessibility Defaults are deep-cloned before Sanitize. AscendData optional files are cached and cleared in Reload.
- AscendData.Db: missing optional files fall back to non-null empty defaults in GameDatabase, so Db.Quality / Db.LifeSkills are never null.
- Core stays engine-agnostic (SaveGame.cs change uses no UnityEngine).
- Old plain-id saves stay Normal quality (ItemQuality.Split).
