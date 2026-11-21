# Driving Blender live from a Claude session

Set up and measured on 2026-11-21. This is the fast path for character and creature work: instead of running a
headless build, writing a turnaround sheet and reading the PNG back, a session generates the asset inside a running
Blender and looks at it directly.

## Starting it

```
"E:/SteamLibrary/steamapps/common/Blender/blender.exe" --python Tools/blender/start_mcp.py
```

That enables the `blender_mcp` add-on and starts its socket server on port 9876, so nobody has to click
"Connect to Claude" in the sidebar. From the session, `get_addon_status` should then answer.

If it does not: `netstat -ano | findstr 9876`. A second Blender already holding the port is the usual reason, and
two instances will both appear to listen.

## What it reported here

| | |
|---|---|
| Blender | 5.3.0 |
| Add-on | 1.8, protocol **15** against an expected **16** |
| Asset libraries | Poly Haven, Sketchfab, Poly Pizza — all **off** |
| 3D generators | Tripo, Hunyuan3D, Hyper3D, Meshy — all **off** |
| Telemetry | off |

The protocol is one version behind. The server's advice is `uvx mcp-for-blender install-addon`, and that was
**deliberately not run**: the older protocol works through fallbacks, and updating needs a Blender restart. Worth
doing on a quiet day, not mid-session.

Poly Haven is **CC0 with no attribution required** (read from its licence page on 2026-11-15, see
`13_Production/research/tools_and_sources.md`), so switching that library on is free and safe. Sketchfab and all
four generators need accounts or credits, which are the user's decision, and they stay off.

## What it is good for

Generating a character in the live session and inspecting it, in seconds:

```python
import sys, os, bpy
sys.path.insert(0, r"<repo>\Tools\blender")
os.chdir(r"<repo>")
from ascend_characters import generate
ch = generate.character("human_male_base")
```

Then `look` with `mode: angles` for front, three-quarter, side and back, or `get_scene_info` with the `topology`
and `weights` fields for numbers our own checks do not produce.

## What that measured, 2026-11-21

Numbers for `human_male_base` that we had never had before:

- **Body: 5,106 faces, 100% quads** — no tris, no ngons, **0 non-manifold edges, 0 boundary edges, 0 loose
  vertices**, 111 poles. The generator's topology is clean, which matters because it is what animation deforms.
- **Every mesh: 0 unweighted vertices.** Our own validator asserts this; an independent tool agrees.
- Whole character: 12 meshes, 11,484 faces, 62 bones.

And one thing that looked like a defect and is not. On the male base, the hair weights **only to `Head`** — the
`HairBack_*` and `HairSide*` swing chains carry nothing. That is correct for a crop, which should not swing. The
female base, whose style is `long_loose`, weights its hair across all seven chains (HairBack_1 460 verts, _2 528,
_3 892, each HairSide 92–108). Checked before reporting, because the male figure alone reads as a bug.

## Rules that still apply

An LLM running `bpy` in a live Blender can destroy unsaved work. Point it at a scratch file, never at a `.blend`
that matters, and never at a scene somebody has open and unsaved. Nothing here enters `Game/` without going through
`13_Production/third_party_assets.md` first.

## Creature detail: a knob that was doing nothing

Measured 2026-11-21 in the live session, across eight species chosen one per rig family.

**The Blender library builds every creature at 52,000 to 204,000 triangles.** For comparison, a whole human
character — body, hair, cloak, boots, the lot — is 11,484 faces.

**This is not what the game carries, and the first version of this page implied it was.** The 680 FBX in
`Game/Assets/_Game/Art/Models/Monsters/` measure **6,134 to 10,438 triangles** — Goblin 6,408, Horned Rabbit
10,438, Naga Priestess 6,134 — because `finish_generated_monster.py` decimates each export to a size-scaled
budget: 6k under 0.6 m, 12k under 2.5 m, 20k under 8 m, 30k above. The library mesh is a *source* asset. The
export pipeline was already doing its job.

**`--detail medium` and `--detail low` did nothing for five of the eight.** High, medium and low returned
identical face counts. The cause is in `ascend_creatures/generate.py`:

```python
res = max(0.004, min(DETAIL_RES.get(detail, 0.0075), min_r * 0.75))
```

`min_r` is the creature's smallest feature. Where that feature is small — an ear tip, a claw, a whisker, which is
most creatures — `min_r * 0.75` falls below the hard 0.004 m floor, `max()` clamps to the floor, and the detail
setting cannot reach the result. Confirmed by instrumenting the call: the werewolf and the fox both tessellated at
`res=0.00400` whether asked for high (0.0075) or low (0.0200).

**A reordering does not fix it.** Trying `res = min(detail, max(0.004, min_r * 0.75))` was measured and changed
nothing, because the floor still wins for small features. Recorded because it is the obvious fix and it is wrong.

**What works** is letting the floor itself follow the detail level:

```python
_floor = {"high": 0.004, "medium": 0.010, "low": 0.020}.get(detail, 0.004)
res = max(_floor, min(DETAIL_RES.get(detail, 0.0075), min_r * 0.75))
```

| Species | high | medium | low | low as % of high |
|---|---|---|---|---|
| mon_bog_werewolf | 142,665 | 37,405 | 11,061 | 8% |
| mon_grakkus_the_orc_disaster | 204,111 | 78,103 | 21,295 | 10% |
| mon_mana_fox | 181,592 | 46,364 | 12,524 | 7% |
| mon_meadow_armor_beetle | 75,325 | 42,521 | 11,049 | 15% |
| mon_bog_lich | 52,295 | 23,851 | 9,175 | 18% |
| mon_phantom_cube_slime | 186,591 | 73,663 | 27,335 | 15% |

Looked at as well as counted: the werewolf at 142,665 faces and at 11,061 are indistinguishable side by side from
the front and three-quarter views. Thirteen times the triangles buys nothing you can see at normal distance.

**Why this was safe to land.** The library builds at `--detail high`, and high is unchanged — verified by
regenerating all eight and comparing face counts against the recorded originals, all eight identical. The change
only affects medium and low, which previously did nothing at all. **Regenerating the 677 models as LODs is a
separate decision** and belongs to whoever owns the creature pipeline.

## Should the 677 be regenerated as LODs? No

Asked and answered on 2026-11-21, after the measurement above and before spending hours on it.

The detail fix is real and the library knob now works, but **regenerating the 677 would give the game nothing**.
What Unity loads is already 6k–10k triangles, inside the documented budget, and *lower* than the 9k–27k that
`--detail low` produces. The LOD work would take hours of GPU time and ship meshes no better than the ones already
there.

Where the fix does earn its place: anyone opening a family library in Blender to look at or edit creatures now has
a medium and low option that previously did nothing, and a 4.9 GB library of 31 files becomes far cheaper to open
at low. That is a workflow gain, not a game one.

**What would actually improve the monsters** is the finding from `13_Production/research/monsters.md`: the 680
species resolve to 193 distinguishable fight profiles, 41.8% duplicate another species' whole profile within their
own region and ring, and the rubric scores "reads at a glance" at 7.7/20. That is a design problem, not a triangle
problem, and no amount of regeneration touches it.

## The LOD regeneration, done 2026-11-21

Asked for again after the measurements above, so it was built. All **680 species × 2 levels, 31 families, zero
failures**, in **17 minutes** — low 6.6, medium 10.4 — with `--no-sheets`, which skips the per-family contact
sheet renders that dominate a normal build.

| Level | Files | Size |
|---|---|---|
| high (source, untouched) | 31 | 2.4 GB |
| medium | 31 | 893 MB |
| low | 31 | 316 MB |

Two changes to `build_creature_library.py` made it safe and repeatable:

- `--out <dir>` so a run can write somewhere other than beside the repo.
- a non-high build writes `<family>_<detail>.blend`, so an LOD build **cannot overwrite the source library**. Before
  this, `--detail low` would have silently replaced 2.4 GB of high-detail work with low-detail files of the same name.

Checked, not assumed: `beasts_low.blend` holds all 45 beasts at 12,096 to 31,562 triangles (median 18,124), and
they were looked at — bodies smooth, ears, tails and eyes intact, silhouettes clean.

**What this is and is not.** It is a working library that opens quickly: 316 MB against 2.4 GB. It is **not** an
improvement to the game, for the reason measured in the section above — Unity already loads 6k–10k triangle FBX,
decimated on export, which is *lower* than these LODs. Nothing in `Game/` changed and nothing should be re-exported
from these files expecting a gain.

One correction to my own arithmetic along the way: a first pass at counting the build log reported 405 creatures,
which was a parsing mistake on my side — family names contain spaces, so the column I summed was part of the name.
The real figure is 680 at each level.

## Polishing the monster models, 2026-11-21

Done the way the character pass was done: look first, measure the cause, change one thing, look again.

**What the live viewport showed.** Beasts ended in rounded stumps. The plan does build mitten hands and feet — the
Bog Werewolf's body carries 2 hands, 2 feet and 2 shoulders among its 361 metaball elements — but the wrist was
`r1 * 0.72` against a hand of `fist * 0.85`, close enough that the metaball union swallowed the hand into the
forearm. Pinching the wrist to `0.56` and the ankle to `0.58`, and enlarging the hand and foot, makes both read.
Nothing was added to the plan; what was already there simply became visible.

**The flat colour had a specific cause.** The Bog Werewolf is described as "brown, with sickly green markings" and
"a distinctive marking runs along its back", and its accent colour is a vivid green — but its pattern was `none`,
so the accent was never painted. The reason was one line in `looks.py`:

```python
self.pattern = o.get("pattern") or (pattern if pattern == "none" else rng.choice([pattern, pattern, "none", "spots"]))
```

A surface whose style says `none` should stay plain; that is a design decision. But a **patterned** hide had a
1-in-4 chance of rolling `none` and losing its accent colour for no design reason.

**Measured across all 680, before and after**, by running the generator both ways:

| | plain | patterned |
|---|---|---|
| before | 290 | 390 |
| after | 160 | 520 |

**130 creatures got their markings back.** The 160 still plain are the surfaces whose style says `none` on
purpose — gel, smoke, elemental, paper, porcelain, soft fur, horse coat, cloth.

Checked afterwards: 60 species spanning the roster built with zero errors in 6.8 s, 4,920 to 27,710 faces.

**This does not reach the game by itself.** The 680 FBX in `Game/` were exported before these changes, so they
still carry stumps and missing markings. They improve only when re-exported through
`finish_generated_monster.py`, which is a separate job.
