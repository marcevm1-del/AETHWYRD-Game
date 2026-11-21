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

## 10. Methods for learning Blender that work — from the official scripting talk and from doing it

**The Blender conference talk "Getting Started with Scripting in Python" (Blender's own channel, 49:24,
`wWTAQP7-ZUQ`).** Read from its cached captions only; **the video itself was not mined** — the 1080p
download crawled and was stopped, and a later fetch got HTTP 403. So this is `Verified: captions only`,
and the captions are auto-generated, so API names are sometimes mangled. It is an introductory talk, and
its most useful content is how to *discover* the API rather than what the API is:

1. **Do something in the UI, then read the Info log** (the scripting workspace's log pane). Blender prints
   the exact `bpy.ops` call it just ran — his demonstration is an extrude, whose operator call he copies
   from the log and pastes into the Python console to repeat it. This is the fastest way to learn which
   operator does what.
2. **Turn on Python tooltips** in Preferences → Interface. Hovering any UI property then shows its API
   path (for example `bpy.data.objects["Cube"].show_bounds`), and editing it in the UI prints the same
   assignment to the log. Every property in the interface has a script spelling you can read off.
3. **`help(bpy)`, `type(obj)`, and tab-completion in the console** to explore: `type(bpy.context.active_object)`
   gives `bpy.types.Object`, and `.data` is the mesh. Up-arrow recalls history.
4. **All of Python is available** — `random`, `time`, `sys` — so a generator can use ordinary libraries.
5. His worked project turns a script into an **operator class** that registers into a menu; the repo's
   generators do not need that, since they run headless with `-P`.

**What I did that worked here (this session):** every claim in sections 1–8 comes from a short script run
under `blender -b --factory-startup`, each answering one question with a number, and each caught something
a document had wrong. That is the method to keep: **ask the binary, not the docs, and time it.**
`Tools/blender/` already has a CLI shape (`-- --ids ...`) that makes a single-creature run take eight
seconds, so experiments are cheap.

**Mining the short tutorials — NOT ASSESSED at the time of writing.** Five short Blender videos were
queued (colour-palette atlas textures, vertex colours from Blender 4.5 into Unity 6, what Geometry Nodes
are, game-texture basics, rigging). The first fetch failed with **HTTP 403 on the video data**. The tool
does not work around that and I did not. They stay queued in [video_tutorials.md](video_tutorials.md).

---

## 11. Anime-character techniques — each RAN headless on Blender 5.3

**Inverted-hull outline — works.** Duplicate the mesh, give the copy a **Solidify** modifier
(`thickness = 0.04`, `offset = 1.0`, `use_flip_normals = True`; all four properties exist in 5.3) and a flat
emission material with **`material.use_backface_culling = True`** (the property exists in 5.3). EEVEE
rendered a clean dark ring around a toon-shaded egg; I confirmed it by reading the image, not by trusting
a number. The numeric check I first wrote **failed for a reason worth recording: `image.pixels` returns
sRGB-encoded values**, so a linear 0.05 outline colour reads as ≈0.25, and my "dark pixel" threshold of
0.12 counted nothing. **Always threshold in display space.** (This is the same technique as the Outline
pass in `Game/Assets/_Game/Art/Shaders/AscendToon.shader` — `Cull Front`, vertices pushed along the
smoothed normal — so the Blender preview and the Unity shader agree.) Cost of the Blender-side hull is a
second copy of the mesh; in the game the second *pass* replaces it.

**Clean face shading by transferring normals — works, and is measurable.** A sphere deformed with a nose
bump and cheek ripples had a mean **6.25°** deviation from a pure sphere's normals; adding a
**`DATA_TRANSFER`** modifier (`use_loop_data = True`, `data_types_loops = {"CUSTOM_NORMAL"}`,
`loop_mapping = "POLYINTERP_NEAREST"`) from a smooth sphere proxy took it to **0.1°**. This is the standard
anime trick (a face that shades like a smooth ball despite its relief), and in 5.3 it needs no auto-smooth
setting. Read corner normals with `mesh.corner_normals`. Whether the FBX export carries custom normals into
Unity is **NOT TESTED** and decides whether the trick survives the pipeline.

**Shape keys (blendshapes) — work.** `obj.shape_key_add(name="Basis", from_mix=False)` then a second key,
edit its `data[i].co`, set `.value`; evaluating the mesh showed bounding-box width go from **2.0 to 2.263**
as `Smile.value` went 0 → 1. Names are free-form, so a Unity/VRM/ARKit-style naming scheme is a convention
to choose, not an API constraint. `NOT TESTED` — FBX export of shape keys.

## 12. Monster techniques — RAN

**Skin modifier from a skeleton graph — the strongest finding for a 680-species generator.** A mesh of
**17 vertices and 16 edges** (spine, neck, head, four two-segment legs, tail) given a `SKIN` modifier with
per-vertex radii (`me.skin_vertices[0].data[i].radius = (rx, ry)`) and a `SUBSURF` modifier at level 2
evaluated to **2,122 vertices / 2,120 faces** and rendered as a clearly recognisable quadruped silhouette.
Species variation becomes **data**: change the graph and the radii. Applying both modifiers
(`modifier_apply`) gives a plain mesh the existing bake step can take. That is a far smaller input than the
repo's current generators build by hand, and it is the technique most of the Blender creature tutorials
use. The result is a smooth blob with no features — it is a *body*, and horns, eyes and limbs-with-joints
still need adding. `NOT TESTED` — whether it reads as the house style once toon-shaded and detailed.

**Geometry Nodes scatter, built from Python, works — with two traps.**
`bpy.data.node_groups.new("Spikes", "GeometryNodeTree")`, sockets via `ng.interface.new_socket(name=…,
in_out="INPUT"|"OUTPUT", socket_type="NodeSocketGeometry")`, then Distribute Points on Faces → Instance on
Points → Join Geometry gave **365 spike instances on a 1,152-face sphere**. The traps, both hit for real:
1. **Socket availability depends on the distribute method.** In `POISSON` mode the density input is
   **`Density Max`**, not `Density` (that socket exists in the list but is disabled), so
   `inputs["Density"]` raised `KeyError`. Check `[s.name for s in node.inputs if s.enabled]`.
2. **Instances are not geometry until realised.** Before adding a **Realize Instances** node the evaluated
   mesh still had 1,152 faces ("0 instances"); after it, 3,707. Anything that exports through a mesh path
   needs the node; the in-engine alternative is to keep them as instances.

Also confirmed present in 5.3: the Skin, Remesh, Subdivision, Boolean, Solidify, Weld, Displace and
Decimate modifier types (83 modifier types in all).

## 13. Rigging — RAN

- **Armature plus automatic weights works headless.** A subdivided cylinder, a three-bone armature built
  through `edit_bones` (`new()`, `parent`, `use_connect`), and `bpy.ops.object.parent_set(type="ARMATURE_AUTO")`
  → `{'FINISHED'}`, vertex groups `['root', 'mid', 'top']` created. Posing the `mid` bone 40° moved the
  topmost vertex from y = 0.40 to y = −1.36, so the weights really deform the mesh. (`parent_set` needs the
  mesh selected and the armature active.)
- **Rigify works headless — but only with `default_set=True`, in a fresh process.** My first attempt
  (`default_set=False`) failed with `'RigifyParameters' object has no attribute 'make_custom_pivot'` and I
  wrongly concluded the generator was not installed. **That conclusion was wrong** (a research subagent
  measured the opposite and I re-ran it): `addon_utils.enable("rigify", default_set=True, persistent=False)`
  then `armature_basic_quadruped_metarig_add()` and `bpy.ops.pose.rigify_generate()` → `{'FINISHED'}`, **283
  bones (46 deform) in 0.3 s**. Retrying a different variant *in the same process* collides with the
  half-registered add-on (`already registered as a subclass`), so test each variant in a fresh process.
  Metarig adders in 5.3: `human`, `basic_human`, `basic_quadruped`, `bird`, `cat`, `horse`, `shark`, `wolf`.
  The generated rigs are heavy for trash monsters (see section 16b).

**What this means for the repo:** `Tools/blender/rig_creature.py` and `build_rig.py` build rigs by hand
(936 and 367 lines); that is justified by weight, not availability: Rigify's output is 46–197 deform bones against the repo's 3–63. Weight
transfer between creature variants and spline-IK tails remain **NOT TESTED**.

## 14. What survives the FBX round trip — RAN, with the repo's own export settings

The settings are the ones `bake_to_game.py` documents: `axis_forward="-Z"`, `axis_up="Y"`,
`apply_scale_options="FBX_SCALE_UNITS"`, `bake_space_transform=True`, `mesh_smooth_type="FACE"`,
`colors_type="SRGB"`, `add_leaf_bones=False`. A 1,152-face head carrying shape keys, a `Col` vertex-colour
attribute and transferred custom normals was exported with them and re-imported with `wm.fbx_import`:

| Feature | With a `DATA_TRANSFER` **modifier** on the object | With the one-shot **`bpy.ops.object.data_transfer`** operator |
|---|---|---|
| Custom normals | survived (0.15° from the sphere) | survived (**0.10°**; was 6.25° before the transfer) |
| `Col` colour attribute | survived (`CORNER`, `BYTE_COLOR`) | survived |
| **Shape keys** | **LOST** — `shape_keys: None` | **survived** (`Basis`, `Smile`) |

**The rule this gives the pipeline: write the custom normals with the operator, never leave the transfer as
a modifier.** With a modifier on the object, `use_mesh_modifiers=True` made the exporter drop the shape keys
(a no-modifier control export kept them, which isolates the cause). The operator is called with the
**source active and the targets selected**: `bpy.ops.object.data_transfer(use_reverse_transfer=False,
data_type="CUSTOM_NORMAL", use_object_transform=True, loop_mapping="POLYINTERP_NEAREST")` → `{'FINISHED'}`,
leaving no modifiers behind.

Two honesty notes. My pre-export measurement of the operator variant read 5.94° because I measured it from an
evaluated mesh; **the re-import figure is the one that counts**, and I am not claiming to understand why the
two disagreed. And **`NOT TESTED` — whether Unity honours the FBX's custom normals on import** (the importer
has a Normals setting; "Import" is what would be needed) **and whether it reads the shape keys as
blendshapes.** That is a Unity-side check, one imported file, and it decides whether the anime face-shading
trick in section 11 reaches the game.

---

## 15. Anime-character strategies — from a research sweep, cross-checked against what ran

A research subagent produced 22 entries (E1–E22); the full file is a scratchpad artefact. The verdict table
below is its work; the **"ran here" column is mine**, added where one of this session's experiments tests
the same claim. Its own caveat: the Guilty Gear Xrd slides refused the connection and the archive was
blocked, so every Xrd detail is `SECONDARY`; Unity's model-import page returned 404; several Blender
manual pages were navigation-only; Apple's ARKit list is from recall.

**What the repo already has** (read directly): an inverted-hull `AscendToon.shader`, an EEVEE
Shader-to-RGB preview, FBX export with `-Z` forward / `Y` up and a rig-export axis fix, 4-influence weight
capping and shape keys in `rig_creature.py`, and colour attribute `Col`. **The gap the sweep found is a
humanoid hero/NPC pipeline** — Humanoid avatar, face blendshapes, hair, face shadow, lip sync, secondary
motion. Everything so far was built for monsters and buildings.

| # | Technique | Verdict | Hours | Ran here |
|---|---|---|---|---|
| E1 | Character triangle budget **30k / 12k / 4k** (LOD0/1/2); the only real figure found is ~40k for a Guilty Gear Xrd hero, `SECONDARY` | adopt | 2 | — |
| E2 | Anime face topology | hold — **NOT SOURCEABLE**, no primary worked example | — | — |
| E3 | One shared humanoid base mesh | trial | 12–20 | — |
| E4 | Hair as opaque clumps, cards only for strays | adopt clumps | 6–10 | — |
| E5 | Layered eyes plus an eyebrow stencil through the hair | trial | 8–14 | — |
| E6 | **Inverted hull plus a per-vertex outline-width mask** (Solidify option names VERIFIED in the 4.3 manual) | adopt | 4–6 | **outline RAN, section 11** |
| E7 | Geometry-nodes outlines (Blender Studio "Wing It!") | **reject** — camera-locked, so unusable at runtime; files are behind a membership | — | — |
| E8 | Face shading by proxy or edited normals | adopt / trial | 4–8 | **RAN: 6.25° → 0.10°, survives FBX, section 14** |
| E9 | Face-shadow SDF texture, **painted ourselves** | trial | 10–16 | — |
| E10 | Vertex-painted shadow-threshold offset | adopt | 3–5 | — |
| E11 | Shader-to-RGB as the Blender preview of the Unity ramp | adopt (already in use) | 0 | **RAN, section 3** |
| E12 | lilToon and Unity Toon Shader — read, do not ship | hold | 2 | — |
| E13 | Shape-key basics | adopt | 0 | **RAN: survive FBX only without a modifier** |
| E14 | **The 17 VRM 1.0 preset names as our face-shape contract** (VERIFIED from the vrm-specification): `aa ih ou ee oh`, blink, `look*`, emotions | adopt | 6–10 | — |
| E15 | ARKit-52 naming | reject — 30–50 h | — | — |
| E16 | Lip sync (uLipSync, Rhubarb) | trial, only if voiced | 6–10 | — |
| E17 | Humanoid look-at plus gaze shapes | adopt | 4–6 | — |
| E18 | Hand-built or Rigify Humanoid deform rig; Unity's Humanoid needs at least **15 bones**, a T-pose, optional Eye and Jaw bones (VERIFIED) | adopt; Auto-Rig Pro **reject** (paid, $25–50) | 10–16 | **Rigify generator does not run here — section 13** |
| E19 | 4-influence weights, reuse `rig_creature.py` | adopt | 3–5 | **auto weights RAN, section 13** |
| E20 | Our own spring-bone script for hair and capes; Wiggle Bones (GPL-3.0-or-later, VERIFIED) is fine for *authoring* only; Magica Cloth 2 is paid (~$17.50, `SECONDARY`) | trial; Magica reject unless approved | 8–12 | — |
| E21 | Keep the repo's FBX axis and scale settings | adopt | 1–2 | **RAN: round trip clean, section 14** |
| E22 | A **vertex-channel budget** so paint, smoothed normal, outline width and shadow threshold do not collide | adopt | 3–4 | — |

**Two warnings the sweep raised that I am repeating because they are easy to get wrong:**
- **Another studio's assets are an explicit reject.** A public Unity repository implementing a Genshin-style
  face shadow ships *face-shadow maps derived from that game's models*. Take the **technique** (E9) and paint
  our own textures; **do not use that repository, its textures or any of its code.**
- **Check what a membership hides.** The Blender Studio's anime-outline and toon-character material is behind
  a subscription (EUR 11.50 a month). That is the user's decision, and nothing here depends on it.

**The sequencing this implies for the missing humanoid pipeline** (my synthesis, not the sweep's):
(1) **one humanoid base** (E3) with the E18 deform skeleton; (2) **the vertex-channel budget (E22) before
anything paints a channel**, since E6, E10 and the smoothed normal all want one; (3) face shading by proxy
normals (E8, now verified to survive the pipeline); (4) VRM preset names for the blendshapes (E14), written
into shape keys with the **operator-not-modifier** rule from section 14. Items 1–3 can all be tested
headless exactly as this primer's experiments were.

---

## 16. Monster and creature strategies — from a research sweep, with its measurements

A second subagent produced 25 entries (E01–E25) and ran two experiments of its own on the repo's creatures
(`rigify_test.py`, `lod_compare.py`; they imported repo code with bytecode writing off and wrote nothing into
the repo). **Where its measurement and mine overlap I re-ran mine, and one of us was wrong: it was me, on
Rigify (section 13, now corrected).** Tags are the sweep's: **VERIFIED** (read at the primary page or
measured here), **SECONDARY** (a search summary or vendor listing), **NOT SOURCEABLE**.

### 16a. Making the body

- **E01 — Skin modifier from a skeleton graph. VERIFIED (4.5 manual) and RAN (section 12).** `Mark Root`
  sets the vertex used for limb rotation and the root bone of `Create Armature`; `Mark Loose` lets a branch
  vertex stretch between its neighbours; `Equalize Radii` evens the axes; the usual stack is
  Mirror → Skin → Subdivision. One tutorial calls it a *base-mesh tool, not for fine detail* (`SECONDARY`),
  which matches the featureless blob I got.
- **E02 — what the repo does is metaballs plus polygonise.** The sweep's point is that **Voxel Remesh or Mesh
  to Volume are alternatives, not upgrades**; no change recommended.
- **E03 — a data-driven body-plan table with per-species parameters.** This is the structural idea behind
  680 species: the *graph and radii* are data (my 17-point quadruped), the species is a row.
- **E06 — scales, spikes, horns via Geometry Nodes.** VERIFIED for the node semantics, and **RAN (section 12,
  365 instances)**. One gotcha from a Blender Artists thread (`SECONDARY`): **instances placed on an
  armature-deformed mesh pop or rotate wrongly** — build the points *before* the Armature modifier and
  instance them separately, or realise and weight the result.
- **E07 — stylised fur and feathers with Geometry Nodes** (an 80.lv tutorial on Blender 5.2 LTS) and **E08 —
  a "chunked rock" creature via Decimate Collapse plus extrude-by-face-area**. Both `SECONDARY`; the second
  is a cheap route to the faceted stylised look.

### 16b. Rigging non-humanoids — **and my Rigify correction**

- **E10 — Rigify works headless. VERIFIED, and re-run by me.** `addon_utils.enable("rigify", default_set=True,
  persistent=False)` in a **fresh process**, then any of the eight metarig adders and
  `bpy.ops.pose.rigify_generate()`: `{'FINISHED'}`, **283 bones (46 deform) from `basic_quadruped` in 0.3 s**.
  **My earlier "does not work" was wrong:** I passed `default_set=False` (the add-on then never registered
  its parameter class, giving `'RigifyParameters' object has no attribute 'make_custom_pivot'`), and a retry
  *in the same process* collided with the half-registered add-on (`already registered as a subclass`). **Lesson:
  Blender add-on state is per-process; test each variant in a fresh one.**
- **But the generated rigs are too heavy for trash monsters.** `basic_quadruped` is 46 deform bones (283
  total); `wolf` is **197 deform (823 total)**. The repo's `rigs.json` has **25 rigs of 3–63 bones**. Rigify
  is the right tool for *authoring a rich hero rig*, not for 680 species. Rigify's `generate.py` header is
  **GPL-2.0-or-later** (VERIFIED); using it to author rigs is fine, shipping its Python is not the question.
- **E11 — Spline IK for tails and necks does not export.** VERIFIED for the options (Chain Length, Even
  Divisions, Use Curve Radius…); `SECONDARY` for export: forum reports say **Unity does not reproduce Spline IK
  or bendy bones from FBX** ("snakes rock like a plank"). Workarounds: bake onto plain bones, bake bendy bones
  to shape keys, or solve the chain at runtime in Unity (a travelling sine wave on plain FK chains — E11 adopt).
- **E12 — Unity Generic rigs, one avatar shared across species.** VERIFIED from Unity's docs: Generic rigs
  have a Root node and *Optimize Game Objects*; **"Copy From Other Avatar" needs an identical source rig.**
  The implication — **25 clip sets could serve all 680 species** — is the largest multiplier in the sweep,
  and it is **NOT TESTED in Unity** (translation-curve scaling across different-sized species is the first
  thing to check). Verdict: adopt, test first.
- **E13 — weight transfer to LOD1 and LOD2 is the missing step.** Auto-weights are fine on organic meshes
  (confirmed by my run); the repo gap is that **`art_budgets.md` describes the LODs as static**, so
  `bake_to_game.py` produces unskinned LOD1 and LOD2. **Adopt: the only hard blocker between static LODs and
  skinned monsters. Not done, not tested.**
- **E14 — Auto-Rig Pro, Bonebrush, IKForge: paid third-party riggers.** Reject without a purchase decision,
  which is the user's.

### 16c. Animating many creatures cheaply

- **E15 — Spider Walker** (Blender add-on, v1.0.6): bakes procedural leg stepping to keyframes. Licence
  **MIT** per the article and the repo sidebar, but **the LICENSE text was not displayed**, so it is not
  "adopt now". Trial, for hexapod and octopod gait clips offline.
- **E16 — stop-motion "on twos".** Two routes: a Graph Editor **Stepped F-Curve modifier** (Step Size 2 gives
  a 12 fps feel at 24) or the extension **Stop Motion Style Animator** (**GPL-3.0-or-later**, Blender 5.0+,
  v0.3.2, 2026-08-01, VERIFIED). **How Unity treats stepped F-curves from FBX is NOT SOURCEABLE.** The sweep's
  recommendation, which I agree with, is to **sample "on twos" at runtime in `MonsterAnimator`**: it gives the
  look without depending on export behaviour (and `Code/Unity/Runtime/SteppedAnimator.cs` already exists).
- **E17 retargeting, E18 vertex-animation-texture crowds:** not opened at source; hold.

### 16d. LODs — measured, and it confirms the pipeline

On the repo's own creatures, same Blender, same machine:
**`mon_forest_wolf` 179k → 6k triangles and `mon_young_dragon` 320k → 10k.**

| Method | Result |
|---|---|
| **Quadric collapse** (what `bake_to_game.py` uses) | Fastest or near-fastest and most faithful. **Kept `Col` (error under 1 %)**; the dragon took **3.5 s at 0.05 % mean deviation** |
| Voxel remesh (modifier) | **Dropped `Col`**; on the dragon 1.2–4.6 M-triangle intermediates, **19–97 s**, 3.5–4.2 % deviation (cause not diagnosed) |
| QuadriFlow | **Dropped `Col`**; **missed its target** (5,356 from a 6,000 request; 6,708 from 10,000); 22 s on the dragon |

**Verdict (E19, E20): keep quadric collapse; add a face-protect vertex group** so eyes and mouth are not eaten.
Voxel remesh stays the right tool for buildings (hollow shells), where the repo uses it. **This independently
confirms the correction in section 6** — the QuadriFlow script I first recommended would have made things worse.
Two smaller repo findings: **E21 — `monster_model_pipeline.md` lists triangle caps (6k / 12k / 20k / 30k) that
differ from `art_budgets.md`**; one of them is stale and should be reconciled. And only two species were
measured, so the figures are a spot check, not a survey.

### 16e. Design principles (ideas only, mostly `SECONDARY`)

**E23** silhouette test: fill the model solid black and ask whether it is still distinct; settle shape language
before material; the creature should read in greyscale; strong variants differ by posture or a dominant feature,
not just colour. **E24** a Unity-blog case study of enemy design (Tempest Tower, read). **E25** colour scripting
by tier. None changes a file; all feed `anime-fantasy-director` reviews.

### 16f. The sweep's top five, by value per hour

1. **E13 — weight transfer to LOD1/LOD2 in `bake_to_game.py`.** Adopt; the one hard blocker.
2. **E12 — Generic rigs with Copy From Other Avatar per `rigId`.** Adopt; test the translation-curve scaling first.
3. **E16 — runtime "on twos" in `MonsterAnimator`.** Adopt.
4. **E19 — keep quadric collapse, add a face-protect group.** Adopt.
5. **E15 + E11 — Spider Walker for multi-leg gaits (trial) and plain FK plus a runtime wave for tails (adopt).**

**Still open (the sweep's list):** no Unity editor tests were run (Copy From Other Avatar across species sizes;
stepped-curve import); Retarget, ReNim and the paid add-on licences were not opened at source; VAT crowds not
researched; the QuadriFlow manual page and `blender.org/about/license` did not load.

---

## 17. Weight transfer to a decimated LOD — RAN, and it closes the gap named in section 16

The monster sweep found that `bake_to_game.py` produces **static** LOD1 and LOD2, so a skinned monster has no
weights on its lower LODs. This experiment tests the missing step on the smallest possible rig: a 1,946-face
tube skinned to three bones with `ARMATURE_AUTO`, a 443-face LOD1 made by `DECIMATE` collapse (ratio 0.15) on
a copy **with its vertex groups cleared**, then:

```
# source (LOD0) active, target (LOD1) selected
bpy.ops.object.data_transfer(use_reverse_transfer=False, data_type="VGROUP_WEIGHTS",
        vert_mapping="POLYINTERP_NEAREST", layers_select_src="ALL", layers_select_dst="NAME",
        use_object_transform=True)
```

→ `{'FINISHED'}`, and LOD1 gained the groups **`['root', 'mid', 'top']`**. After adding an Armature modifier to
LOD1 and bending the `mid` bone 40°:

| | Top vertex (x, y, z) |
|---|---|
| LOD0 (1,946 faces, auto weights) | (0.00, −1.36, 1.65) |
| LOD1 **with** transferred weights | (0.00, −1.36, 1.65) — **0.000 m apart** |
| LOD1 **without** weights (the failed first attempt) | (0.10, 0.39, 2.00) — **did not deform at all** |

The posed LOD1 vertices sit a mean **0.072 m** (max 0.31 m, tube radius 0.4 m) from the nearest LOD0 vertex;
treat that as an **upper bound on error**, because it compares two differently sampled point clouds, so
sampling density is mixed into it. The fair claim is only that the coarse mesh follows the fine one and the
top vertex is exact.

**The keyword trap I hit, worth writing down:** the operator's mapping properties are **`layers_select_src`
and `layers_select_dst`** (values `ALL`/`ACTIVE`/`BONE_SELECT`/`BONE_DEFORM` and `NAME`/`INDEX`).
`layers_vgroup_select_src` — which a related operator, `datalayout_transfer`, uses — raises *"keyword
unrecognized"* here. Read the operator's properties rather than guessing:
`[p.identifier for p in bpy.ops.object.data_transfer.get_rna_type().properties]` gave
`vert_mapping, edge_mapping, loop_mapping, poly_mapping, layers_select_src, layers_select_dst`.

**What it means for `Tools/blender/bake_to_game.py`.** The step slots in after each collapse: copy the LOD0
armature binding, run the transfer from the *previous* LOD, add the Armature modifier, and **carry the bone
weights through the four-influence cap** that `rig_creature.py` applies (Limit Total in the weight-paint menu;
the transfer can exceed four influences on a decimated mesh, which `NOT TESTED` here). The FBX export then
needs the armature to travel with the LODs. **Estimate 3–5 hours**, including a skinned-creature PlayMode
check in Unity — which is **NOT TESTED**, as is a *real creature* rather than a tube: face and limb joints
are where weight transfer fails, and that is the "face-protect vertex group" the sweep recommended
alongside quadric collapse.
