# Blender primer: what I have actually verified

A working knowledge base for driving Blender from Claude, built from measurements rather than recollection.
Started 2026-11-21. Everything here was observed on this machine unless marked otherwise.

## The setup, as it stands

- **Blender 5.3.0**, Steam install at `E:/SteamLibrary/steamapps/common/Blender/blender.exe` **[verified]**.
- Two ways in, and they are different things:
  - **Headless**: `blender -b --factory-startup --python-exit-code 1 -P <script>`. This is how every generator and
    check runs (`build_character_library.py`, `check_characters.py`, the clip builders). Deterministic, scriptable,
    and it never touches the user's open session. `--python-exit-code 1` matters: without it Blender exits 0 even
    when the script raises, so a broken rig would pass **[verified — it is in the scripts' own docstrings]**.
  - **Live MCP**: an add-on serving on `localhost:9876`, driving the user's *running* Blender. Read the scene, run
    `bpy`, take screenshots. This is for inspection and iteration, not for pipeline work.
- Add-on protocol was **15 against an expected 16** on 2026-11-21 — it works through fallbacks, and
  `uvx mcp-for-blender install-addon` updates it **[verified from the status call]**.
- **All asset libraries and generators are switched off**: `polyhaven`, `sketchfab`, `polypizza`, and the
  `tripo` / `hunyuan3d` / `hyper3d` / `meshy` generators **[verified]**. Poly Haven is CC0 with no attribution
  required (see `tools_and_sources.md`), so switching it on in the add-on preferences is the cheapest route to
  non-stand-in environment material. That switch is the user's to flip.

## Two traps I walked into, both worth remembering

**1. "Deform bones with no group" is per mesh, and usually correct.**
The scene report lists, for each mesh, the rig's deform bones that mesh has no vertex group for. The body legitimately
has no group for `HairBack_1`, and the hair legitimately has none for `Hips`. Reading that list as a defect made me
think our hair was not weighted to its swing chain. Checking properly showed the opposite: on the female base, **all
ten swing bones are weighted** — hair uses all seven `Hair*` bones, cloak uses all three `CloakBack_*`, and none is
carried unused **[verified]**. The per-mesh list is only alarming if a bone appears in *every* mesh's list.

**2. A pole count means nothing without saying what you counted.**
Counting "vertices whose edge count is not 4" makes every boundary vertex a pole, so a flat decal strip reads as 74%
poles when it is simply an open plane. Measured that way the brows came out at 78% and the belt at 74% — both
meaningless. The number is only informative on closed meshes, and even then capped tubes (every hair strand) create
poles by construction.

Where it does mean something: **the body is 111 poles across 5,108 vertices, 2.2%** — that is genuinely clean quad
topology for a generated mesh **[verified]**. Compare hair at 22.1%, most of it from strand caps.

So: if a topology rule goes into an art gate, it must state the mesh class and exclude boundary and cap vertices, or
it will fire on things that are fine and stay silent on things that are not.

## What our own character actually measures

Female base, 13 meshes, 13,519 vertices in total, read live on 2026-11-21 **[verified]**:

| Check | Result |
|---|---|
| Unweighted vertices | **0 of 13,519**, every mesh |
| Non-manifold edges | **0**, every mesh |
| Loose vertices | **0**, every mesh |
| Ngons | **0**, every mesh |
| Tris | 200 (eyes) + 18 (hair); everything else pure quads |
| Swing bones weighted | **10 of 10** |
| Body poles | 111 / 5,108 = 2.2% |

This is the first independent confirmation of what `check_characters.py` asserts. The generator's own validator and a
live inspection from outside it now agree, which is worth more than either alone.

## Working in someone else's Blender

The user's session is not a scratch file. Rules I am holding myself to:

- **Look before touching.** `get_scene_info` first, every time. Between two calls minutes apart the scene changed
  from the male base to the female base, because the user was working — assuming continuity would have been wrong.
- **Read-only unless asked.** No loading files, no deleting, no saving over their work. An unsaved scene is somebody's
  afternoon.
- **Look node types up, never names** (`n.type == "BSDF_PRINCIPLED"`), because interface names are localised.
- **Never hardcode enum identifiers** — read them from the RNA.
- Material colour lives on shader node inputs; `material.diffuse_color` only changes the viewport.

## Where this is useful

Headless remains the pipeline. The live connection is worth having for exactly the things a render cannot show:
topology, weights, bone usage, modifier state, and whether a thing is where it claims to be. Those are also the
measurable half of the character-art rules the design skill needs, which is why this is written down.

## Still unknown

- Whether the **male** base weights its hair swing chain. The crop is short, so it may legitimately not — unchecked,
  because the scene had changed to the female by the time I looked.
- Whether a fair pole metric (excluding boundaries and caps) separates good hair from bad. Untested.
- What the add-on's screenshot and render tools cost in practice; not yet used.
