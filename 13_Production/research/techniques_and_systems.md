# Techniques and systems for the half-built parts

> World streaming, companion and monster AI, combat feel, save migration. Entry format and
> verification vocabulary: [README.md](README.md).
>
> **Mechanics and patterns only.** Nothing here reproduces or recommends reusing another studio's code,
> decompiled logic, art, text or data. Where an open-source dependency is named, its licence is stated
> and it would need a row in [third_party_assets.md](../third_party_assets.md).

Part A is what reading this repo's own code turned up — the most actionable material in the whole
library, because it needs no third party at all. Part B, the external survey, is still being written.

---

# Part A — what the code says

## A1. The streaming system is designed, not built — and one decision made the precision case worse

**VERIFIED — source read:** `13_Production/terrain_unity_import.md` §2, §5, §8; `Data/World/world_scale.json`;
`Code/Ascend.Core/WorldScale.cs`; a `-- '*.cs'` grep for `WorldOrigin|LoadSceneAsync|SetNeighbors|Addressables`.

**1. What it is.** Floating-origin rebasing: periodically moving the whole world so the player stays near
coordinate zero, because single-precision floats lose resolution with distance from the origin.

**2. What it would do for us.** `terrain_unity_import.md` §2 already states the problem correctly and
proposes the fix — a world origin at Brindlewick, plus runtime rebasing of all root transforms once the
player is more than 4 km from zero — and §8 step 5 assigns "streaming manager, `WorldOrigin`, origin
shifting" to world-builder-engineer. **None of it exists in C#.** There is no `WorldOrigin` type, no
`SetNeighbors` call, no Addressables usage and no scene-streaming manager; the only matches for
"streaming" in code are `StreamingAssets`, the unrelated build-time data copy.

**And the decision that was taken went against the plan.** `Data/World/world_scale.json` records
`origin.mapAt [0, 0]` — the map's north-west corner — "decided 2026-11-07 by Claude under delegated
creative control (Canon §6 WF9); the user may overrule". `WorldScale.MapToMetres` honours it, so every
position in the continent lies between 0 and **+153,600 m** east and 0 to **−102,400 m** north.

That is the worst of the three available choices for precision. The arithmetic is three lines and worth
checking rather than taking on trust: a float's ULP at magnitude *m* is `2^(floor(log2 m) − 23)`. At
153,600 m that is `2^-6` = **15.6 mm**; at 72,600 m (Brindlewick, where the plan measured) it is `2^-7`
= **7.8 mm**, which independently confirms the plan's own "8 mm" figure. Centring the origin would have
halved the worst case; a Brindlewick origin would have put the heartland near zero at sub-millimetre ULP.

**3. Cost, licence and requirements.** None. This is a design and data change: no GPU cost, no package,
no money. It is entirely within `Code/Ascend.Core` and the Unity runtime.

**4. Effort and risk.** The plan's floating-origin section names none of the things that break when you
rebase a running game. That checklist is the genuinely new contribution here:

| # | What breaks on a rebase | Why |
|---|---|---|
| 1 | **Saved absolute positions** — see A2; this is the one that couples streaming to save migration | A position written under one origin offset and restored under another lands in the wrong place |
| 2 | **Cached world positions held outside transforms** — monster home and leash centres, the companion `Hold` spot, siege positions, gather-node and waystone positions | A `Vector3` field does not move when transforms move, so it silently desynchronises by the shift |
| 3 | **NavMesh data instances** | Placed in world space when added; they do not follow a transform move. *Verify against the AI Navigation package docs before relying on this.* |
| 4 | **Static batching** | Static-batched renderers cannot be moved at runtime |
| 5 | **World-space particles and trails** | Already-emitted points stay in world space, so a rebase smears every live effect across the shift distance |
| 6 | **Rigidbody interpolation and camera damping** | Both blend from a previous position that is stale by the shift distance on the shift frame |
| 7 | **World-space UVs and shader noise** | The planned `Ascend/TerrainToon` wants triplanar on steep rock, and triplanar is world-position-driven by definition. Every rebase pops the rock texture unless the accumulated offset is fed back as a shader global. Found only in playtest otherwise |
| 8 | **Audio with world-space positions**, reverb zones, sources cached at play start | Same class of problem |

Effort: making the save origin-independent is about **4–8 hours** in Core plus tests. A `WorldOrigin`
singleton and a rebase routine covering the table above is about **10–20 hours**.

**5. Verdict. Adopt the save-side fix now; build the rebase when streaming is built.** Doing item 1
before the origin ever moves is nearly free; doing it after saves exist in players' hands is a migration
with no clean answer.

**Also, a documentation contradiction to resolve first:** `terrain_unity_import.md` §2 still reads
"Plan: a world origin at Brindlewick", which now contradicts `Data/World/world_scale.json`. Fix the doc
before anyone builds from §2.

## A2. `SaveGame` stores absolute Unity floats, and that is the first real migration

**VERIFIED — source read:** `Code/Ascend.Core/SaveGame.cs`; `Game/Assets/_Game/Runtime/Player/PlayerSave.cs`.

`SaveGame` holds `public float[] Respawn` (x, y, z, yaw) and `public float[] Lantern` (x, y, z), written
straight from `_respawn.Point` and the lantern transform. `SaveRules.Validate` checks only length and
finite-ness. If the origin ever moves — or runtime rebasing arrives — every existing save's respawn point
moves with it; under the plan's recommended Y-rebase that is about **290 m underground**.

The fix is to store something origin-independent: **map kilometres as `double`**, or a
`(tileIndex, localOffset)` pair. `WorldScale.MetresToMap` and `MapToMetres` already exist in Core and are
`double` throughout — the conversion is written, it is simply not used by the save. This would be the
first `CurrentVersion` 1 → 2 migration, and the first that the existing null-fill pattern cannot handle:
it needs a real coordinate transform keyed on the old version.

**Verdict. Adopt now.** 4–8 hours, and the cost of skipping it rises the moment a save exists in the wild.

## A3. The save migration suite is better than expected — and tests a loader the game does not use

**VERIFIED — source read:** `Code/Ascend.Core.Tests/SaveMigrationTests.cs` (all 127 lines),
`SaveGameTests.cs`, `Phase1SaveTests.cs`.

**What `SaveRules.Upgrade` actually is.** Not a version-stepped chain — its own comment says "nothing to
do yet at version 1". It is a single idempotent null-fill and sanitise pass: `??=` over roughly 35
collections and nested sections including second-level nulls; `Accessibility.Sanitize()`; and a repair
rather than reject policy for companion rows (drop bond entries with no id, de-duplicate keeping the last,
drop presets that do not parse, normalise preset casing). One line is genuinely version-aware and well
judged: a **future** version is deliberately left alone so `Validate` still rejects it and an older build
cannot load a newer save and then overwrite it on the next autosave.

**The suite's design is the good part.** `EveryReferenceFieldIsFilledByUpgradeOrDeclaredNullByDesign`
reflects over `SaveGame`'s properties and asserts each reference field is either non-null after
`Upgrade("{}")` or named in an explicit `NullByDesign` set — and that every name in that set still exists.
**A new field cannot ship without a migration decision.** And
`UpgradeIsIdempotentAndTheSerialisedFormIsAFixedPoint` loads, serialises, loads again and asserts
byte-identical JSON. Idempotence as a fixed point of serialisation is the most valuable shape a migration
test has, and it is already here. Keep both; they are worth more than anything this library could add.

Three findings against that, each the same risk class:

**(a) The tests do not exercise the real loader.** `SaveMigrationTests` deserialises with
**`System.Text.Json`**; `PlayerSave.cs` deserialises with **Newtonsoft.Json**
(`JsonConvert.DeserializeObject<SaveGame>`, `StringEnumConverter`, `InvariantCulture`). The two differ in
migration-relevant ways: missing versus explicitly-null members, numeric coercion, unparseable enum
strings, float round-tripping, and how a malformed trailing structure fails. **Every migration guarantee
the suite proves is proved about a loader the game does not use.** The engine-free rule for
`Code/Ascend.Core` is not an obstacle — Newtonsoft is a plain .NET library and the Unity side already
depends on it. Fix: run the same fixtures through both serializers, or move the game to
`System.Text.Json`. About **3–6 hours**. **Verdict: adopt now.**
`NOT SOURCEABLE — the licence text of Newtonsoft.Json was not read in this sweep.` It is widely stated to
be MIT, which would be fine, but verify on its repository and record it in `third_party_assets.md` before
it becomes a declared dependency of the test project.

**(b) The "atomic" write is not atomic, and the comment claims it is.** `PlayerSave.Save()` writes
`<path>.tmp`, then `File.Delete(path)`, then `File.Move(tmp, path)`, commented "write-then-move: a crash
mid-save never leaves half a file". True as far as it goes — but **between the delete and the move no slot
file exists at all**, and `Load()` only ever looks at the live path, never at the complete `.tmp` sitting
beside it. A crash, power cut or process kill in that window loses the save outright; the next session
starts fresh and the first autosave overwrites the orphan. There is also no flush-to-disk step and **no
rotating backup**: one slot, one file, no previous-good copy. A save-destroying bug with a narrow window
is the worst kind — it will not show in testing and it will show in reviews.
Options to evaluate: `File.Replace` (one operation, and it can keep a backup), a `File.Move` overwrite
overload that removes the delete, or the three-file dance (write `.new`, flush, rename live to `.bak`,
rename `.new` to live, keep `.bak`); and on `Load`, offer a `.tmp` or `.bak` when the live file is missing
or rejected. The existing `.bad` quarantine on a rejected load is a good pattern already in place — keep it.
`NOT SOURCEABLE — the exact atomicity guarantees of .NET's File.Replace and File.Move(overwrite) on NTFS,
and their availability in Unity's API profile, were not read in this sweep.` Check both against Microsoft's
.NET API documentation and Unity's scripting-backend documentation before relying on either; do not take
the above as settled. About **3–5 hours** including tests. **Verdict: adopt now** — this is the cheapest
serious bug in the repo to fix.

**(c) `Validate` is thin where a data-driven RPG actually breaks.** It checks version range, level, XP and
money sign, clock sanity, stack sanity and array shape. It does **not** check referential integrity: that
item keys exist in `Data/Items/items.json`, that quest ids still exist, that `CompanionPresets` keys name
real companions, that `GearFittings` keys name owned gear, that `Home.Tier` is real. In a game where
`Data/` churns, the likeliest future save break is not a schema change but **a content id that was renamed
or removed**. `Upgrade` already shows the right instinct with companions — drop the unusable row quietly,
never reject the save. Generalise it to every id-keyed collection and surface a single count of what was
dropped. About **4–8 hours**. **Verdict: trial** — valuable, but worth doing after (a) and (b).

## A4. There is no golden-save fixture corpus, and the window to start one for free is now

**VERIFIED — source read:** `find Code/Ascend.Core.Tests -name "*.json"` returns nothing; every test save
in the suite is a string literal in the test file.

So there is no artefact recording what a **shipped** save looked like — only what the current author
believes an old save looked like. "A save from version N opens in version N+5" is therefore not testable
today, and adding more literals will never make it testable, because a literal written at N+5 is written
with N+5's knowledge of the schema. The suite is still at version 1, so nothing has been lost yet.

**Verdict. Adopt now** — about **2–4 hours**: commit a real `slot0.json` produced by the current build as
`Code/Ascend.Core.Tests/Fixtures/save_v1_<date>.json`, add a test that loads every fixture in that folder
and asserts `Upgrade` succeeds and `Validate` passes, and add one fixture per version bump thereafter.
(The player's live save at `%USERPROFILE%/AppData/LocalLow/DefaultCompany/Game/slot0.json` is never
touched — a fixture is produced by a fresh test playthrough, not copied from it.)

## A5. What `TerrainTileImportStub.cs` still lacks

**VERIFIED — source read:** the file itself and `13_Production/terrain_unity_import.md` §8.

What it does: reads one tile's sidecar plus the 16-bit heightmap (and splat when present), writes **one
`TerrainData` asset** into the throwaway `Assets/_TerrainImportScratch`, creates four `TerrainLayer`s with
flat palette colours from `art_direction.md` §9, resamples the alphamap to 512 and normalises it, and logs
a `SetHeights`/`GetHeights` round-trip error in metres.

What it lacks, against §8 — its own doc comment admits the first four:

1. No scene objects and no `Terrain` component: an asset, not a placed tile.
2. No neighbour links — no `SetNeighbors`, no `Flush()`, no shared settings asset, **so nothing yet proves
   the bit-exact-edge claim survives Unity**.
3. No dressing. The `_dressing.json` export it would read **does not exist yet** — §4's
   `ascend-terrain-dressing/1` format is a request to environment-artist, not a built thing.
4. No water: no sea plane, no lake or river meshes from the sidecar polylines.
5. Not a batch importer. `ImportBatch` takes **one** `-terrainSidecar`; §8 step 2 wants a folder sweep
   producing one `TerrainData` **and a prefab** per tile. There is no prefab output at all.
6. No hash check against the sidecar's `heightmapSha256` — the `Sidecar` class does not even declare the
   field — so a run cannot prove it consumed the tile the generator produced.
7. No pad-height assert against `settlements[].padHeightM`, and no `ring0Violations == 0` assert.
8. **Wrong tile geometry, by its own admission.** The tiles that exist are 10 km / 501 samples; the stub
   bilinearly resamples to 513 "for a look only". The 10.24 km rebuild has not happened, so the bit-exact
   and SHA-256 guarantees do not hold for anything the stub currently produces.
9. No colour map: `_albedo.png` does not exist as an export, only the *shaded* `_top.png`, which cannot be
   used as colour. Without it the cel look living in the generator's `albedo` vertex colour is lost and
   four flat layer tones are all the stub can show.
10. No `Ascend/TerrainToon` shader — no toon ramp, no shadow tint, no triplanar on steep faces.
11. No prototype mesh LODs and no `TerrainDressingLibrary` asset.
12. No streaming manager, no `WorldOrigin`, no origin shifting — see A1.

**Verdict. Adopt items 6, 7 and 8 first** (about **4–6 hours** together): a hash check, the pad asserts and
the 10.24 km rebuild are what turn the stub's output from "a look" into something the rest of §8 can be
built on. The others are the plan's own work queue, not research findings.

## A6. `AscendToon.shader` would be excluded from the GPU Resident Drawer

**VERIFIED — source read:** `Game/Assets/_Game/Art/Shaders/AscendToon.shader` (210 lines; no
`DOTS_INSTANCING_ON` or `UNITY_DOTS_INSTANCING` block anywhere in it) and Unity's URP documentation on the
GPU Resident Drawer, read 2026-11-15.

**1. What it is.** Unity 6 URP's GPU-driven rendering path. It batches compatible Mesh Renderers on the
GPU and adds its own GPU occlusion culling, which is the main lever for drawing a lot of static scenery
cheaply.

**2. What it would do for us.** It is the obvious answer to drawing 49 regions of buildings and scenery on
a GTX 1650 — and the project would not get it. Unity's requirements list says a GameObject must, among
other things, "use a shader that supports DOTS instancing", not use `MaterialPropertyBlock`, not have a
per-instance callback, and use only static global illumination. `AscendToon.shader` meets none of the
DOTS-instancing requirement, so **every toon-shaded building would be excluded and fall back to the SRP
Batcher.** Separately, the pipeline-level requirements are Forward+ or Deferred+ renderers only, a
compute-shader-capable API (not OpenGL ES), Enlighten realtime GI off, and BatchRendererGroup Variants set
to "Keep All" under Shader Stripping — which Unity's own page notes **lengthens build times** because all
those variants get compiled in.

Two further limits worth knowing before anyone plans around it: **animated LOD cross-fading is not
supported** (transitions fall back to static distance-based cross-fading), and `Light.shadowMatrixOverride`
stops affecting shadow-caster culling.

**3. Cost, licence and requirements.** Free, in URP 17.6.0 which is already in
`Game/Packages/manifest.json`. No money, no account.

**4. Effort and risk.** Adding DOTS-instancing support to `AscendToon.shader` and re-validating the
inverted-hull outline pass under it: **8–16 hours**, with real risk, because the outline pass and the
smoothed-normal-in-vertex-colour trick that `BuildingImport.cs` writes are exactly the kind of thing a
GPU-driven path interacts badly with. The honest alternative is to measure first: enable the drawer, read
the Rendering Profiler's GRD coverage row and the Frame Debugger to see what is actually excluded, and
only then decide.

**5. Verdict. Trial** — measure the exclusion before paying for the shader work. But it belongs on the
record now, because it is a constraint on `AscendToon.shader` that nothing in the repo currently mentions.

---

# Part B — the external survey

Still being written: comparable-RPG streaming and LOD with published numbers, Unity 6 Addressables versus
additive scene streaming for 49 regions, golden-save corpus practice, companion-AI "don't be annoying"
design, group tactics and alert propagation, and sourced combat-feel numbers. The repo's own
[reference_games.md](../reference_games.md) already records what has been borrowed (RimWorld's taming
fields; Project Greyborn's unsticking and reflex hop) and three ideas still on its "to consider" list
(utility goals with hysteresis, a path budget, evolution stages by level), so Part B starts past those.
