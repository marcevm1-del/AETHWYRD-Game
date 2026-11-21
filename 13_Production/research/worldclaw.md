# WorldClaw: nothing to run, but a blueprint worth reading

Cloned and assessed 2026-11-21 at the user's request. `E:/Ideas/Hunyuan3D-WorldClaw`.

**The short version: there is no code to use, and the method is one we could largely reproduce with tools we
already have.** The second half is the useful part.

## What was actually in the repository

`README.md` and two images — `assets/teaser.jpg` and `assets/pipeline.jpg`. No source, no weights, no
requirements file, no licence file. The README's latest news entry is **2026-08-07**, announcing the paper and a
project page. That is the whole repository **[verified 2026-11-21, cloned and listed]**.

So "clone and use it" stops at clone. Nothing here runs.

## What the paper says it does

arXiv 2608.05248, *WorldClaw: Agentic 3D Open-World Generation at Scale*, submitted 5 August 2026.

Text prompt in; a large explorable 3D scene out. Planning agents turn the prompt into a specification of regions,
terrain, assets, materials and spatial relations; a terrain foundation is built as a **region-aware height field**;
detail-heavy regions get **editable textured meshes** placed on that terrain; and render-based agents then loop,
looking at renders and refining terrain, objects, appearance and contacts.

The paper claims the output suits "conventional game-engine workflows" and that scenes are "independently editable
textured meshes with explicit terrain placements". Texture maps are reported as 2048² for large objects and 1024²
for small ones.

### What it does not say

- **Release: not stated.** No statement about code, weights or a demo, in the paper or on the project page. The
  project page returned only its title to an anonymous fetch, so it may be JavaScript-rendered.
- **Licence for code or weights: not stated.** The only licence on arXiv is arXiv's own paper-distribution licence,
  which covers the PDF and nothing else.
- **Mesh file format, UVs, topology, collision export: not stated.** Object–terrain contact is checked during
  refinement, but no collision export is described.
- **Unity: not mentioned.** Unreal appears only as a future direction.
- **World size and generation time: not stated.** The spec includes a "world scale" parameter with no value given.

### What it would cost

Experiments ran on **a server with 4 NVIDIA H20 GPUs**, and the Limitations section admits "substantial inference
latency and computational cost". We have one GTX 1650 with 4 GB.

Being precise about the comparison: **the paper never states a minimum spec**, so "it will not run on our machine"
is an inference, not a quoted fact. What is quoted is the hardware they used and their own admission of cost. Either
way the question is moot while no code exists.

## The part that matters to us

Read the pipeline diagram rather than the abstract. The stages are:

1. **Intent analysis** — prompt to scene type, spatial layout, visual style ("cartoon NPR"), main objects, terrain
   categories.
2. **Prompt planning** — a layout map, a material and asset list, and a terrain design expressed as height-field
   operations per feature.
3. **Scene asset generation** — generate asset images, image-to-3D for meshes, procedural or image textures.
4. **Terrain generation and scatter** — height field, then assets scattered per a scatter plan.
5. **Region planning and placement** — divide into named regions (the diagram shows a Festival Plaza, Cabin Village,
   Supply Site and Fishing Village), render each, detect objects, place models.
6. **A render-and-refine loop** — render, look, adjust pose, scale and quality, refine terrain, check collision,
   repeat to an iteration budget.

**We already do most of this, and the parts we lack are the parts we already have tools for.** Our regions,
gazetteer and encounter data are the layout spec. `Tools/blender/ascend_terrain`, `ascend_buildings`,
`ascend_creatures` and `ascend_characters` are the asset generators. `Tools/ai_images/local_sd.py` makes asset
images locally. `Tools/ai3d/model_requests.py` already runs image-to-3D through TripoSR and records provenance.
And the render-and-refine loop is exactly the discipline that fixed the characters on 2026-11-15 — render, look,
change one thing, render again.

Two details are worth stealing outright:

- **The terrain as a region-aware height field composed from per-feature operations** (`frozen lake: hmap(x0,y0)`,
  `forests: hmap(x1,y1) + rise`, `road path: width(x2,y2)`). That is a cleaner contract between our region data and
  our terrain generator than anything we have written down.
- **A scatter plan as a file** (`scatter_plan.yaml` in their diagram) rather than scatter logic buried in a script.

And one detail is a coincidence worth noting: the paper says its terrain refinement is **"Powered by BlenderMCP"** —
the same kind of component as the Blender MCP already configured on this machine. The agentic half of their pipeline
is not exotic infrastructure; it is a Blender MCP and a loop.

## Verdict

**Reject as a dependency; adopt as a reference.** There is nothing to install, no licence to rely on, and the
hardware behind the paper is a four-GPU server. Keep the clone for the diagram and the height-field idea.

If a code release appears, the questions to ask then are the ones the paper leaves open: what licence, what the
mesh output actually is, and whether it can run on one consumer GPU.

## Where this leaves our environment art

Unchanged, and still the weakest area on the dashboard: buildings and environment at quality 1, "everything in it
is a stand-in". The honest path remains our own generators plus CC0 source material, not a model we cannot run.
