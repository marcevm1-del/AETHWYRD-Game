---
type: monster-rig
id: rig:swarm
tags: [rig, animation, swarm]
---
# swarm rig

A cloud of tiny units acting as one monster. One controller bone; units are GPU-instanced (VFX Graph or particle system) with boid rules. HP shown as density.

| Field | Value |
|---|---|
| Aliases | swarm, hive, locust, bat_swarm, pixie_swarm |
| Species using rig | 8 |
| Families represented | Insects & Arachnids, Aquatic |
| Bone count · budget | 3 · 3 |
| Unity avatar · material | Generic · swarm |
| Reference size · axis | 3 · height |

## Locomotion and animations

- **Locomotion:** {"gaits":[{"name":"drift","froude":0.5,"legFrac":0.5},{"name":"surge","froude":4,"legFrac":0.5}],"fantasyMult":1,"turnDegPerSecAt1m":720,"accelG":1,"jumpHeightFrac":0,"canClimb":false,"canSwim":false,"canFly":true,"hovers":true,"hoverHeightFrac":0.3}
- **Physics profile:** {"shapeK":0.001,"density":1,"collider":{"type":"sphere","radiusFrac":0.4,"centerZFrac":0.5},"gravityScale":0,"linearDrag":2,"knockbackResist":1,"launchable":false,"ragdoll":"none","deathStyle":"scatter_and_fall"}
- **Animation set:** [{"name":"form_shape","frames":30,"loop":false,"rootMotion":false,"events":[]},{"name":"surge_attack","frames":40,"loop":false,"rootMotion":true,"events":[{"f":6,"e":"telegraph"},{"f":20,"e":"hit_on"},{"f":34,"e":"hit_off"}]},{"name":"engulf_loop","frames":40,"loop":true,"rootMotion":false,"events":[{"f":0,"e":"hit_on"}]}]
- **Procedural motion:** ["boids_cohesion_alignment_separation","shape_morph_targets (sphere, wall, funnel, arrow)","density_from_hp","aoe_damage_preferred"]

## Default hurtboxes

- **center** — sphere; radius 0.4; damage multiplier default

## Species

- [[Monsters/Insects & Arachnids/Firefly Swarm|Firefly Swarm]] — anim_swarm, 0.05 m high, rigId rig selection
- [[Monsters/Insects & Arachnids/Scarab Swarm|Scarab Swarm]] — anim_swarm, 0.05 m high, rigId rig selection
- [[Monsters/Aquatic/Piranha Swarm|Piranha Swarm]] — anim_swarm, 0.2 m high, rigId rig selection
- [[Monsters/Insects & Arachnids/Phantom Firefly Swarm|Phantom Firefly Swarm]] — anim_swarm, 0.05 m high, rigId rig selection
- [[Monsters/Insects & Arachnids/Vesper-Touched Scarab Swarm|Vesper-Touched Scarab Swarm]] — anim_swarm, 0.05 m high, rigId rig selection
- [[Monsters/Aquatic/Bog Piranha Swarm|Bog Piranha Swarm]] — anim_swarm, 0.2 m high, rigId rig selection
- [[Monsters/Insects & Arachnids/Blight Firefly Swarm|Blight Firefly Swarm]] — anim_swarm, 0.05 m high, rigId rig selection
- [[Monsters/Insects & Arachnids/Elder Scarab Swarm|Elder Scarab Swarm]] — anim_swarm, 0.1 m high, rigId rig selection

## Production checks

Validate the rig export axes, root transform, bone presence, animator mapping, hurtbox placement and a representative locomotion cycle before using it for a new species. Motion overrides should be reserved for species whose signature silhouette or action cannot be expressed by the shared rig rules.
