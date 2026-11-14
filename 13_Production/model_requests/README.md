# Model requests (designers ask, the triposr-modeler makes)

Need a quick 3D model of a prop, creature, plant, weapon, armor piece or building part? File a request here. The `triposr-modeler` agent turns it into a mesh with TripoSR (image to 3D, MIT), and the result goes to review and then to the owning artist for finishing in Blender.

## File a request
```
python Tools/ai3d/model_requests.py new --id warren_crate --kind prop --name "Salvage Warren supply crate" \
    --by environment-artist --prompt "a sturdy wooden supply crate with iron bands" --size 1.0
```
- `--kind`: prop, creature, building-part, weapon, armor, plant, terrain-feature.
- **No character or NPC bodies.** The queue refuses them: human bodies come from `Tools/blender/ascend_characters` (clean topology, a humanoid rig, data-driven variants). A test on 2026-11-13 showed TripoSR gives a body with mitten hands and no face.
- Give `--image` (a local reference image: our own render, our own concept, the user's own drawing) or `--prompt` (an image is made first; needs the user's image-API key, otherwise the request waits as `needs-image`).
- Never use another game's or studio's art, screenshots or unclear stock images as a reference.
- `--size` is the target height in metres (length for long things); `--species` links a creature to `Data/Monsters/species.json`.
- Commit the new JSON file on your own branch. One file per request.

## What happens next
`requested` → `generated` (mesh in `Art/Generation/staging/meshes/<image>/`, gitignored, with `provenance.json`) → `approved` or `rejected` by `anime-fantasy-director` → `finished` once the artist has finished it in Blender. `failed` keeps the error; `retry` sends it back.

Check the queue: `python Tools/ai3d/model_requests.py list`.

## Good reference images
One object, whole and centred, plain light background, three-quarter view, even lighting. TripoSR guesses the hidden sides, so a three-quarter view gives it the most to work with. Expect a rough shape with soft detail, not a finished game model.

## Limits
- The GTX 1650 has 4 GB: one job at a time, never while Unity or a Blender GPU render runs.
- Nothing generated enters `Game/` until `13_Production/third_party_assets.md` lists the AI tools and the art director approved the model.
