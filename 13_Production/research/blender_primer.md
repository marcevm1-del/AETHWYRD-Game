# Blender primer — what was learned by running it

> Written by a Claude session that was told to teach itself Blender. **Method: run the real binary
> headless, test every claim, record only what a run confirmed.** Nothing here is from memory. Tag
> vocabulary as in [README.md](README.md): **RAN** means executed here with the output shown; **DOCS**
> means read on Blender's own documentation site; **NOT TESTED** is a gap, not a pass.
>
> Probe scripts were scratch files and are not committed; every command is reproducible with
> `E:/SteamLibrary/steamapps/common/Blender/blender.exe -b --factory-startup -P <script>`.

## 1. The binary is Blender 5.3.0, not 5.2

**RAN.** `blender.exe --version` on the Steam path prints **`Blender 5.3.0`, build commit date
2026-11-09, hash `02f0899d78e3`.** `CLAUDE.md`, `13_Production/` docs and this library's
[mcp_servers.md](mcp_servers.md) all say 5.2. That also settles an earlier "NOT SOURCEABLE — which
Blender binary sits at the Steam path": **it is 5.3**, so `generate_gaussian_world` (needs 5.3+) is not
blocked by version here. Its reject verdict stands on the other three grounds.

The repo's own generator still works on it: `build_creature_library.py --ids mon_goblin --no-sheets`
finished in **8 s**, saved `goblinoids.blend` and rendered a toned cel goblin preview. **RAN.** (The run
touched tracked `Art/Blender/CreatureLibrary/blender_assets.cats.txt`; I restored it. Running this script
from a clean checkout dirties that file — worth knowing before committing.)

## 2. Things the scripts get wrong or will get wrong

| Finding | Evidence | Consequence |
|---|---|---|
| **`BLENDER_EEVEE_NEXT` does not exist in 5.3.** Setting it raises `TypeError: enum "BLENDER_EEVEE_NEXT" not found in ('BLENDER_EEVEE', 'BLENDER_WORKBENCH', 'CYCLES')` | RAN | Any `Tools/blender/` script that lists `BLENDER_EEVEE_NEXT` must fall back; `toon_preview.py` already tries `BLENDER_EEVEE` first and the repo's guarded loops cope. DOCS: `BLENDER_EEVEE_NEXT` existed in 4.2 to 4.5 and 5.0 renamed it back (section 7) |
| **`Material.use_nodes` is deprecated and "expected to be removed in Blender 6.0"** — Blender prints this on every use | RAN (the warning is emitted) | **34 uses in 14 files** under `Tools/` will break at 6.0. Not urgent; worth a tracked item in `tech_debt_register.md` |
| **The Python FBX importer rejects FBX 6.1; the `bpy.ops.wm.fbx_import` importer accepts it** | RAN on `Art/ThirdParty/nobiax_rocks/*.fbx`: `import_scene.fbx` → `Error: Version 6100 unsupported, must be 7100 or later`; `wm.fbx_import` → `FINISHED` | **`third_party_assets.md` says FBX 6.1 "is too old for Blender 5, so the OBJs beside them are imported". That is true only of `import_scene.fbx`.** `wm.fbx_import` gave rock_01 = 102 verts / 200 faces / 1 UV layer, rock_02 = 252 / 500, rock_03 = 252 / 500 — **identical counts to the OBJ**. Scale differs: FBX dims 1.4 m vs OBJ 140 (centimetres). No materials came across |
| **Enum introspection is unreliable in background mode.** `view_settings.view_transform` lists only `['NONE']` yet assigning `Standard`, `AgX` and `Filmic` all succeed | RAN | Never validate against the enum; **assign inside `try/except TypeError`**, exactly as the Blender MCP server's own instructions say and `toon_preview.setup_world` does |
| Principled BSDF socket names (5.3): `Specular IOR Level`, `Coat Weight`, `Emission Color`, `Emission Strength`, `Subsurface Weight`, `Transmission Weight`, `Diffuse Roughness`, `Thin Film Thickness` | RAN | Confirms the 2.8→5.x renaming table `tutorial_vision.md` documents. Look nodes up by `.type == "BSDF_PRINCIPLED"`, never by name |

**DOCS — 5.3 Python API release notes:** only one change that can affect scripts, `bpy.data.all_ids`
ordering (an "internal implementation detail"), plus an additive `Image.colorspace_settings.interop_id`.
**DOCS — 5.2 release notes (breaking):** Geometry Nodes modifier inputs moved from `modifier["id"]` to
`modifier.properties.inputs.<id>.value`; the Compare and Random Value node socket identifiers changed
(new ones not listed); sculpt automasking properties moved under `mesh_automasking_settings`;
`PreferencesFilePaths.active_asset_library` indices shifted (the first two entries are now "All
Libraries" and "Essentials"). The Geometry Nodes one matters if `Tools/blender/` ever drives a node
group by custom property.

## 3. Verified recipes

**Decimate (collapse).** A 32,768-face displaced UV sphere, `DECIMATE` modifier, `ratio = 0.1`, applied with
`bpy.ops.object.modifier_apply` → **5,912 faces in 0.44 s.** RAN. Note the result is *not* 3,277: the
ratio is a target the collapse approaches, and it keeps more where curvature is high.

**QuadriFlow.** A 20,480-face icosphere, `bpy.ops.object.quadriflow_remesh(target_faces=1500,
use_mesh_symmetry=False, use_preserve_sharp=False, use_preserve_boundary=False, smooth_normals=False,
seed=1)` → `{'FINISHED'}`, **1,358 faces, all quads, in 0.38 s.** RAN. It undershoots the target (1,358 vs
1,500) — treat the target as an upper bound. **NOT TESTED:** organic creature parts, thin appendages
(wings, tails, ears), anything non-manifold — which is where it fails in practice and what
[mcp_servers.md](mcp_servers.md) §4 warned about. Also `voxel_remesh`, `shade_smooth`,
`shade_auto_smooth`, `modifier_add` and `object.bake` all exist as operators in 5.3 (RAN, `hasattr`).

**Cel shading in EEVEE without a custom shader** (the technique `toon_preview.py` is built on): Diffuse
BSDF → `ShaderNodeShaderToRGB` → `ShaderNodeSeparateColor` (Red) → `ShaderNodeValToRGB` with
`color_ramp.interpolation = "CONSTANT"` → Emission → Material Output. RAN. With the view transform on
`Standard` and `render.filter_size = 0`, **the sphere disk contains exactly two tones** (rounding the
floats: 0.49/0.49/0.80 shadow and 0.95/0.91/0.58 lit), a 256×256 render took 5.3 s on EEVEE (first run, including shader compile). **The
non-obvious part: the band position depends on light strength.** With a Sun at energy 1 the entire
visible sphere fell below the 0.5 ramp threshold and rendered as one tone; at energy 4 both bands
appeared. `ShaderToRGB` returns lit radiance, not an angle. **A toon preview rig must pin the light
energy, or the look drifts with the lighting** — which is why a ramp texture in the Unity shader (see
[video_tutorials.md](video_tutorials.md) entry 1) is the better place to own it.

**Imports in 5.3:** `wm.fbx_import`, `wm.obj_import`, `wm.usd_import`, `wm.stl_import`,
`wm.ply_import`, `wm.alembic_import`, `wm.spz_import` (Gaussian splats); `import_scene.fbx` and
`import_scene.gltf` are the Python add-on importers. Exports include `wm.obj_export`, `wm.usd_export`,
`export_scene.fbx`, `export_scene.gltf`. RAN (`dir()` of the operator namespaces).

**Size of the surface:** 83 modifier types, 108 shader node classes, 292 geometry node classes in this
build. RAN.

## 4. How the learning was done, and what failed

1. **Read what the repo already does** — 10,327 lines of Blender Python under `Tools/blender/`, led by
   `town_buildings.py`, `world_diorama.py`, `bestiary_models.py`, `toon_preview.py`, `rig_creature.py`.
   The generators use a package structure (`ascend_buildings/`, `ascend_creatures/`, `ascend_terrain/`)
   with headless CLIs; **a goblin takes 8 s end to end**, so iteration on creature generation is cheap.
2. **Probe the real API** rather than recall it — three probe scripts, each answering a question with
   numbers. Two repo documents turned out wrong (the Blender version; FBX 6.1).
3. **Read Blender's own release notes** for what changed (5.2, 5.3) instead of searching forums.
4. **Tutorial mining** (`Tools/tutorial_vision/tv.py`) — the one Blender procedural-generation video
   queued (`s7NFsEPBtcA`, geometry-nodes dungeons) is **NOT ASSESSED**: YouTube returned HTTP 429. The
   tool does not work around that and neither did I.
5. **The Blender MCP is not available this session** (it disconnected), so no live-viewport work was
   possible; everything above is headless.

## 5. Not yet learned — the honest gap list

- **Baking** (`object.bake` exists; `bake_to_game.py` is 730 lines I read the header of and did not run).
- **Rigging and weighting** (`rig_creature.py`, `build_rig.py`) — never run here.
- **Geometry Nodes authoring**, which is where the 292-class surface is. Procedural dungeons video pending.
- **Whether QuadriFlow is useful as rig-prep topology** — see section 6 for why it is not the LOD tool.
- **The Blender Lab MCP server** (first-party) — its page returned HTTP 403.

**Next experiment:** run QuadriFlow on the goblin body only (not the whole creature) as rig-prep topology, then
`bake_to_game.py` on the goblin and compare against the budgets. The first run of the former is in section 6.

---

## 6. A correction to this library, found by running the pipeline

**`mon_goblin` as the generator emits it is one mesh of 151,423 faces (77,607 vertices, 147,950 of them
triangles) with 16 non-manifold edges.** RAN, from the `goblinoids.blend` the repo's own script just built.
`13_Production/art_budgets.md` budgets a small creature at **1,500 / 600 / 200 triangles** for LOD0, LOD1
and LOD2, so the generator's output is roughly **100× the LOD0 budget** — by design, because
`Tools/blender/bake_to_game.py` is the step that reduces it (voxel remesh, interior culling, quadric
collapse to the budget, flat-colour slots carried back by nearest-face lookup, and a ≤ 96-triangle convex
collider for trash-class creatures).

**So `mcp_servers.md` §4 and shortlist item 6 were wrong to call a QuadriFlow script "the highest value
per hour".** QuadriFlow on the whole goblin took **51.95 s** and returned **42,320 faces** — a 72 % cut,
still 28× over budget, and quad topology is not what a game LOD needs. The repository already solves
LOD generation, with a better-suited method. QuadriFlow's real use here is narrower: producing clean
**quad topology for rigging and weight-painting** on the *source* body before `rig_creature.py`, which is a
different question and **NOT TESTED**. The shortlist has been corrected.

The error came from taking an MCP-sweep claim ("closes the named gap in `monster_model_pipeline.md`")
without running the pipeline end to end. Running it took eight seconds. That is the lesson of this
whole primer: **the repo's own scripts are the fastest way to learn what it already does.**

## 7. Rules from Blender's own documentation

**DOCS — `docs.blender.org/api/current/`**, read 2026-11-21. Quotes are short; the pages were fetched in
parts because their navigation is most of the text.

**Operators (`info_gotchas_operators`).**
- Operators **take no data arguments**: they act on the current context, not on objects you pass in. The
  return value is a *status* (`{'FINISHED'}` or `{'CANCELLED'}`), not a result.
- A failed context check raises `RuntimeError`, reading like *"Operator bpy.ops.action.clean.poll()
  failed, context is incorrect."* Typical needs: an active area, a selection, or an active object.
- **Some operators are UI-only and fail from scripts** — the page names `texture.slot_move`,
  `constraint.limitdistance_reset`, **`object.modifier_copy`** and `buttons.file_browse`. If a generator
  needs one of these, use `bpy.data` instead.
- This matches what ran: `quadriflow_remesh` and `modifier_apply` both needed the right object to be
  `view_layer.objects.active` and selected, and `quadriflow_remesh` **replaces the active object's mesh**,
  so read the result through `view_layer.objects.active` afterwards.
- `NOT SOURCEABLE — operator performance versus bpy.data, and background-mode behaviour: the fetched
  excerpt does not cover either.`

**Mesh access (`info_gotchas_meshes`).**
- *"Edit-Mode having its own data which is only written back to the mesh when exiting Edit-Mode."* So
  `obj.data` is **stale while in edit mode**: leave it first, use `bmesh.from_edit_mesh()`, or push with
  `BMesh.to_mesh()`.
- Object-mode faces are `mesh.polygons`; triangulated faces are `mesh.loop_triangles`; edit-mode faces are
  `BMFace`. **Do not edit geometry through `loop_triangles`** (it tessellates n-gons).
- Polygons are efficient but rigid — all vertices and faces must exist up front — so **build geometry
  incrementally with BMesh**, and use polygons only for material and smooth-shading settings.
- For export: `polygons` if the format handles n-gons, `loop_triangles` if not.

**Stale references (`info_gotchas_internal_data_and_python_objects`).**
- Python wrappers around Blender data are created on demand and deleted when unused; *Blender may free its
  data and try to invalidate known wrappers, but this is not always possible*, which can read invalid
  memory. **Hold references for the current run only.**
- **Names are not guaranteed.** A requested name may differ if it is too long, already used, or empty, so
  keep a dictionary from the name you asked for to the datablock you created rather than looking it up in
  `bpy.data` afterwards — this matters for `ascend_creatures`-style generators that build hundreds of
  objects.
- Derived values such as `matrix_world` are stale until **`bpy.context.view_layer.update()`**.

**Baking (`manual/render/cycles/baking`, Blender 5.3 manual).** Bake needs a **UV map** and a target, which
is the *active Image Texture node* or the **active Color Attribute** (set Target to "Active Color
Attribute" and keep the right layer active; the active object must be a mesh). Selected-to-active casts
rays inward from the low-poly active object; **without a cage, rays follow mesh normals, which can cause
edge glitches**, so use a cage (and avoid Edge Split modifiers, whose hard splits give non-smooth
normals); joining many high-poly objects first avoids memory problems. Margin has two types, **Extend** and
**Adjacent Faces**, sized in pixels. Normal space defaults to Tangent, which works for animated meshes, and
the image's Normal Map setting should match. `NOT SOURCEABLE — colour-space guidance for baking is not on
this page.` Bake runs through **Cycles**, so a headless bake needs the Cycles add-on enabled under
`--factory-startup` (**NOT TESTED**).

**Version history for the engine name — DOCS.** `BLENDER_EEVEE_NEXT` was introduced in **4.2**; the
**5.0** notes say *"the EEVEE engine identifier changed from `BLENDER_EEVEE_NEXT` to `BLENDER_EEVEE`."*
That is why 5.3 rejects the old name, and why the repo's guarded loops are correct for both. Other 5.0
changes relevant here: **`scene.use_nodes` (compositor) is deprecated and removed in 6.0**, and
`scene.node_tree` was removed in favour of `scene.compositing_node_group`; **`SceneEEVEE.use_gtao` and
`gtao_quality` were removed**; **`mathutils.Vector` is now float32**, which can affect numpy code that
assumed float64; the legacy Action API (`action.fcurves`) was removed in favour of channelbags, which
matters to anything in `rig_creature.py` that writes animation. `NOT SOURCEABLE — the 5.0 page's last
6,834 characters, and any material-level `use_nodes` note, were not read; the material deprecation here
rests on Blender's own runtime warning (RAN).` Also from 4.2: `Material.blend_method` became
`surface_render_method`, and EEVEE bloom was deprecated.

**Checked in `Tools/blender/` (grep for `fcurves`, `gtao`, `blend_method`, scene `node_tree`):** the only hit is
`toon_preview.py:105`, `setattr(sc.eevee, "use_gtao", False)` inside `try/except AttributeError`, so the
5.0 removal is already handled and the generator ran cleanly on 5.3. **No 5.0 breakage found in the repo
scripts.** The only forward risk found is `Material.use_nodes` at Blender 6.0 (34 uses in 14 files).

## 8. Baking to vertex colours works headless — RAN

A UV sphere with a Principled material whose Base Color is a red/blue Checker texture, a
`BYTE_COLOR` / `CORNER` colour attribute named `Col` made active with
`me.color_attributes.active_color = ca`, `scene.render.engine = "CYCLES"`, 4 samples, CPU, and
`bpy.ops.object.bake(type="DIFFUSE", pass_filter={"COLOR"}, target="VERTEX_COLORS")` →
**`{'FINISHED'}` in 0.28 s under `--factory-startup`**, with the result in `Col` containing exactly the
two source colours (**0.96, 0, 0** and **0, 0, 0.96** — 992 corners each). Notes:

- **`render.bake.target` has two values here: `IMAGE_TEXTURES` and `VERTEX_COLORS`.** The operator takes
  `target=` too; pass both consistently.
- Cycles is selectable headless without enabling any add-on (`render.engine = "CYCLES"` succeeded), which
  answers the "NOT TESTED" in section 7.
- **The baked colour is 0.96, not 1.0.** The Principled diffuse pass does not return the raw albedo. If a
  pipeline needs the exact flat colour of a face (as `art_direction.md` and the Unity toon shader do), bake
  from an **Emission** material, or read the colour from the material directly as `bake_to_game.py`'s
  "every face's exact flat colour into the vertex colour `Col`" step evidently does. `NOT TESTED` — which
  of the two `bake_to_game.py` actually uses.
- This is the same attribute name, domain and kind `13_Production/art_budgets.md` describes the toon
  shader reading, so the technique matches what the game consumes.

## 9. What crashes Blender scripts — DOCS (`info_gotchas_crashes`), and what to do about it

For generators that build hundreds of objects (this repo's buildings, creatures, terrain tiles):

- **Adding to a container can re-allocate it and invalidate earlier references** (mesh elements, curve
  points). Re-fetch after the add; **store indices or string keys, not references.**
- **After `bpy.ops.object.mode_set`, data from before the switch is unsafe** — it re-allocates mesh, bone
  and curve data. Re-read `mesh.polygons` afterwards.
- **Assume undo and redo invalidate every `ID` instance and its sub-data.**
- **Never touch anything you have `remove()`d**, including its sub-data — the variable raises, but other
  references to the sub-data can crash.
- **Copy before iterating when you mutate**: `list(collection.all_objects)` before changing
  `hide_viewport`, `hide_select` or `hide_render`; convert a `bpy.data` iterator to a list before setting
  any `name`, because renaming re-sorts the data-blocks.
- Debugging: **`faulthandler`** points at the script line that triggered a crash, even when the crash is in
  C++; and a stray `sys.exit()` in a library can quit Blender silently — `sys.exit = None` reveals the line
  (the docs call it dirty).
- Style and speed (`info_best_practice`): avoid `+` for building strings in loops (use `"".join`), avoid
  `try` in hot loops (it is "significantly slower than `if`"), avoid `in`, `index` and `count` on big lists,
  and **time things with `time.time()`**, which is what the probes in this file did.
  `NOT SOURCEABLE — the best-practice page says nothing about bmesh, avoiding bpy.ops, or large object
  counts.`

None of these is exotic. The practical rule for a generator script: **hold a dict of what you created,
re-fetch rather than cache across mode switches, and iterate over a copy.**
