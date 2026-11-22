# CharMorph: a licence problem, not a tooling one

Assessed 2026-11-22 from the copy at `E:/Game Projects/CharMorph/CharMorph` (18 MB).

CharMorph is a Blender add-on for character creation — morph-driven bodies, faces, hair and clothing fitting,
descended from MB-Lab and ManuelbastioniLAB. As a tool it is mature and does things our generator does not.

**The question that decides it is not what it can do. It is what we are allowed to ship.**

## What its own licence file says

The add-on separates two licences, and the split is the whole story **[verified 2026-11-22, `license.txt`]**:

- **The code: GPL-3.0.** "All python files released in the CharMorph package, are released under GNU General Public
  License 3." That is unremarkable for a Blender add-on — Blender is GPL, every add-on is, and using a GPL tool does
  not put its licence on what you make with it.
- **The database: AGPL-3.0.** "CharMorph contains MB-Lab characters that are based on ManuelbastioniLAB package,
  all the meshes and data contained in these directories including .blend files, all the images and all the json,
  yaml files are released under GNU Affero General Public License 3."

That second clause is the one that matters. **It puts AGPL-3.0 on meshes** — the things that would end up inside our
shipped game, not merely in our toolchain.

## Mixed, and per asset

`data/lists.json` lists five asset entries with **three different licences: one CC0, two CC-BY, two AGPL**
**[verified 2026-11-22]**. The licence file says as much: "Each character has its own license stated in select list."

No meshes are bundled in the download — **zero `.blend`, `.npy` or `.npz` files in the whole 18 MB**
**[verified]** — so the character packs arrive separately, and *which pack you pick decides whether you can ship
what you make*. That is a trap: the tool works identically whichever you choose, and nothing stops you at the point
of use.

## Verdict: hold, and if used at all, CC0 assets only

Three reasons, in order of weight.

1. **The AGPL packs are unusable for us.** AGPL-3.0 is written for software and applies awkwardly to meshes, which
   is exactly why it is dangerous: the conservative reading is that a character derived from an MB-Lab base is a
   derivative work, and we would be shipping it in a closed-source commercial game. I am not able to resolve that
   ambiguity, and it is not the kind of ambiguity to resolve by hoping.
2. **We would not gain much.** `Tools/blender/ascend_characters` already produces characters with clean topology
   (body 2.2% poles), our own 62-bone rig, zero unweighted vertices, and data-driven variants — verified
   independently on 2026-11-21. CharMorph's value is morph-based variety on *its* base mesh with *its* topology and
   *its* rig, none of which our animation clips, hitboxes or Unity import expect.
3. **Mixing pipelines costs more than it looks.** Every downstream thing we have built — the 62-bone contract, the
   106 combat clips, the hurtbox fitting, the art gate — assumes our generator's output.

**If someone wants to use it anyway:** restrict to the CC0 entry, record it in `13_Production/third_party_assets.md`
with the licence text saved on the download date, and keep AGPL packs off this machine entirely so they cannot be
picked by accident.

## What is worth taking without taking anything

The idea, not the assets: CharMorph drives a body from a small set of named morph sliders with fitting that follows
the body. Our generator already does the data-driven half. If character variety becomes a bottleneck, the thing to
copy is **morph targets on our own base mesh**, which carries no licence question at all.

## Not assessed

Whether the CC0 entry is a complete, usable character or a partial one — I did not download any pack. Whether
CharMorph's rig could be retargeted to our 62-bone contract — untested, and moot while the licence question stands.
