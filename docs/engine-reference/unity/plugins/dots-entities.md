# DOTS / Entities - status in Project Ascend

**Not installed.** `com.unity.entities` (and related DOTS packages) are not in
`Game/Packages/manifest.json` (checked 2026-11-07). Monster motion, springs and
hurtboxes run as normal MonoBehaviour-style code in `Code/Unity/Runtime`.

`unity-dots-specialist` has nothing to work on until a DOTS package is added.
Treat adopting DOTS as an architecture decision (technical-director, ADR under
`13_Production/architecture/`) with a measured need first (`/perf-profile`). This
file has no verified API information.
