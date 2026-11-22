---
name: character-design
description: "Design or improve a character or creature for AETHWYRD so it actually looks good: measure it, render it, look at it, change one thing, repeat. Use when making a new character or variant, when something looks wrong and nobody can say why, or before calling character art done."
---

# character-design

Making a character look good is not a thing you can do by reading code. Everything that was wrong with our
characters on 2026-11-15 — shoulders at 1.36 head-heights, hair built at 30% of the strands it asked for, a shadow
cutting every face in half, no ears visible from any angle — was invisible in the source and obvious in a render.

So this skill is a loop, not a checklist: **measure what a machine can measure, render it, look at it, change one
thing, render again.** The gate handles the first part and is honest about what it cannot judge; you handle the rest.

## The loop

### 1. Measure

```
blender -b --factory-startup --python-exit-code 1 -P Tools/art_gate/check_character_art.py -- --ids <variant>
```

Runs over every mesh the rig owns — derived from the rig, never a list of names, so a new part cannot ship outside
coverage. Verdicts rank **FAIL > NOT ASSESSED > CONCERNS > PASS**, and the script exits non-zero on either of the
first two, so a check that could not run never reads as a pass.

It measures: heads tall, shoulder joint span in head-heights, ngons, non-manifold edges, loose vertices, unweighted
vertices, triangle count, body pole ratio, and whether the rig's swing bones are actually weighted by anything.

### 2. Render and look

```
blender -b --factory-startup --python-exit-code 1 -P Tools/blender/build_character_library.py -- --ids <variant> --keys --no-export --no-blend
```

Then **open the images and look at them** — `reports/characters_<date>/<id>.png` for the turnaround and
`<id>_face.png` for the face. Not the code. The images.

Five things the gate reports as NOT ASSESSED until a person looks:

| Check | The question |
|---|---|
| `silhouette_reads` | Does the figure read at thumbnail size as a black shape? |
| `hair_reads_as_hair` | Does the hair have mass and a hairline, or is it slabs on a scalp? |
| `face_reads` | Are eyes, nose, mouth and ears legible at conversation distance? |
| `shading_clean` | Does the cel terminator avoid cutting the face in half? |
| `outfit_reads` | Does the clothing read as cloth with weight, not a cone or a sheet? |

### 3. Record what you saw

Write a verdict with your name on it into a looked-at file and pass `--looked-at <file>`:

```json
{"human_male_base": {"hair_reads_as_hair": {"verdict": "PASS", "by": "you", "on": "2026-11-22",
                                            "note": "mass and hairline present"}}}
```

Only `PASS`, `CONCERNS` or `FAIL` count; anything else leaves the criterion NOT ASSESSED. This exists so the gate
can reach green honestly. A gate that is permanently red gets muted, and a muted gate is worse than a narrow one
because it still reads as coverage.

### 4. Change one thing, then render again

One change per render. Two changes and you cannot tell which helped — and on this project at least one "fix" has
made things worse (a hood that became a flat shelf) and was only caught because it was the single change in that pass.

## What to look for first, in order

Ranked by what actually moved the needle on 2026-11-15, worst first:

1. **Density and mass.** The hair generator built 30% of the strands each style asked for. Before tuning shapes,
   check that the thing is actually all there.
2. **Proportion.** Shoulders at 1.54 head-heights read as weak; the fix was the single largest improvement. The
   gate measures this now, per sex — bands calibrated on a male figure fire falsely on a female one.
3. **Light.** A hard cel terminator across a face reads as dirt. Faces want a high, nearly frontal key; the shadow
   that looked like a shading bug was the hair casting onto the face.
4. **Silhouette details.** Ears inside the skull's own outline are invisible. A nose that does not break the
   profile is not a nose. A mouth drawn as one line has no body.
5. **Hands and extremities.** Fingers need gaps to read as fingers.

## Measuring traps, all three learned the hard way

**A number is not a measurement until you know what it counted.**

- **Pole ratio** counting every vertex with ≠4 edges makes boundary vertices poles, so a flat decal strip reads as
  78% broken. Only meaningful on closed meshes, excluding boundaries and caps.
- **Shoulder width** from an x span of the mesh measures the T-pose arm span (7.3 head-heights — the whole figure).
  Excluding arm-weighted vertices then measures the torso tube without deltoids (1.45). Take it from the rig: the
  distance between the UpperArm bone heads.
- **"Deform bones with no group"** is listed per mesh and is usually correct — the body legitimately has no group
  for `HairBack_1`. It is only a defect when a bone appears in *every* mesh's list.

When a measurement disagrees with your eyes, suspect the measurement first.

## Rules that hold whatever you are making

- **Canon wins.** `Canon.md` beats every other doc; never edit a locked row, propose in §6.
- **Teen rating, no fanservice, warmth over comedy.**
- **Original designs only.** Take ideas and techniques from other games, never their art, models, text or data, and
  never a design that reads as a specific existing character.
- **Human and NPC bodies come from `Tools/blender/ascend_characters`**, not from image-to-3D. The TripoSR test on
  2026-11-13 produced a watertight blockout with mitten hands and no face; the model request queue refuses body
  requests for that reason.
- **Before reporting anything done,** run the gate and say exactly what it returned, including what came back
  NOT ASSESSED and why.

## Creatures

Creature silhouette and variety have their own rubric, with a scorer that has been run over all 680 species:
`Tools/bestiary_rubric/score.js` and `13_Production/research/monsters.md`. The loop above still applies — the
difference is what you look for, which that dossier covers.

## Where the numbers come from

Bands live in `Tools/art_gate/check_character_art.py` with their reasoning attached. Several are marked **house** —
chosen by us and ours to defend, not read anywhere — because published figures for stylised proportion disagree with
each other and describe visual spans rather than the joint span the gate can measure reproducibly. The triangle
budget is explicitly estimated and flagged for replacement. Change a band when you have a better reason, and write
the reason in beside it.
