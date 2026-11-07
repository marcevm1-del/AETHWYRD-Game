# Unity 6.6 - Physics

Sources: Unity 6.6 upgrade guide (read 2026-11-07); `Game/Packages/manifest.json`.
Status: **minimal**.

- The 6.6 upgrade guide lists **no physics API changes**.
- Physics simulation integrity checks now compile into Debug/Checked managed code variants only; `UNITY_PHYSICS_DISABLE_INTEGRITY_CHECKS` overrides.
- Manifest has the built-in physics modules (3D, 2D, cloth, terrain physics, vehicles). The engine in `project.yaml` is recorded as PhysX; that is an assumption, confirm in Project Settings > Physics.

**Not verified:** anything about collision layers, character controller behaviour or hurtbox setup. Read `Code/Unity/Runtime` (hurtboxes) first.
