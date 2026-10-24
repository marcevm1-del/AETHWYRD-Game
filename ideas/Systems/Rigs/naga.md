---
type: monster-rig
id: rig:naga
tags: [rig, animation, naga]
---
# naga rig

Humanoid torso on a serpent tail: nagas, lamias. Upper body uses humanoid arm/head bones; lower uses the serpent spine.

| Field | Value |
|---|---|
| Aliases | lamia, mer, serpent_humanoid |
| Species using rig | 13 |
| Families represented | Aquatic, Serpentfolk |
| Bone count · budget | 29 · 40 |
| Unity avatar · material | Generic · scaled |
| Reference size · axis | 4 · length |

## Locomotion and animations

- **Locomotion:** {"gaits":[{"name":"slither","froude":0.5,"legFrac":0.15},{"name":"fast_slither","froude":2,"legFrac":0.15}],"fantasyMult":1.1,"turnDegPerSecAt1m":350,"accelG":0.8,"jumpHeightFrac":0,"canClimb":false,"canSwim":true,"canFly":false,"hovers":false}
- **Physics profile:** {"shapeK":0.003,"density":1150,"collider":{"type":"capsule","radiusFrac":0.05,"heightFrac":0.45},"gravityScale":1.3,"linearDrag":0.15,"knockbackResist":0.4,"launchable":false,"ragdoll":"chain_physics","deathStyle":"limp_chain"}
- **Animation set:** [{"name":"idle","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_alert","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_fidget_01","frames":120,"loop":false,"rootMotion":false,"events":[]},{"name":"turn_90_L","frames":20,"loop":false,"rootMotion":true,"events":[]},{"name":"turn_90_R","frames":20,"loop":false,"rootMotion":true,"events":[]},{"name":"turn_180","frames":30,"loop":false,"rootMotion":true,"events":[]},{"name":"hit_light_front","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_light_back","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_heavy","frames":22,"loop":false,"rootMotion":true,"events":[]},{"name":"stagger","frames":40,"loop":false,"rootMotion":true,"events":[]},{"name":"break_down_loop","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"break_recover","frames":30,"loop":false,"rootMotion":false,"events":[]},{"name":"knockdown","frames":28,"loop":false,"rootMotion":true,"events":[]},{"name":"getup","frames":36,"loop":false,"rootMotion":false,"events":[]},{"name":"death","frames":45,"loop":false,"rootMotion":true,"events":[{"f":30,"e":"ragdoll"}]},{"name":"spawn","frames":40,"loop":false,"rootMotion":false,"events":[{"f":0,"e":"vfx"}]},{"name":"taunt","frames":45,"loop":false,"rootMotion":false,"events":[{"f":10,"e":"vocal"}]},{"name":"flee_start","frames":15,"loop":false,"rootMotion":true,"events":[]},{"name":"sleep_loop","frames":120,"loop":true,"rootMotion":false,"events":[]},{"name":"eat_loop","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"frozen_pose","frames":1,"loop":true,"rootMotion":false,"events":[]},{"name":"stun_loop","frames":40,"loop":true,"rootMotion":false,"events":[]},{"name":"slither","frames":30,"loop":true,"rootMotion":true,"events":[]},{"name":"tail_sweep","frames":40,"loop":false,"rootMotion":false,"events":[{"f":6,"e":"telegraph"},{"f":20,"e":"hit_on"},{"f":28,"e":"hit_off"}]},{"name":"constrict_grab","frames":36,"loop":false,"rootMotion":true,"events":[]},{"name":"attack_01","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_02","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_03","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_04","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_05","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]}]
- **Procedural motion:** ["spline_follow_head","upper_body_stays_upright","look_at_target","hair_spring"]

## Default hurtboxes

- **head** — sphere; radius 0.03; damage multiplier default
- **chest** — capsule; radius 0.04; damage multiplier default
- **tail_03** — sphere; radius 0.05; damage multiplier default
- **tail_08** — sphere; radius 0.04; damage multiplier default

## Species

- [[Monsters/Aquatic/Siren|Siren]] — anim_naga, 0.92 m high, rigId rig selection
- [[Monsters/Aquatic/Merfolk Warden|Merfolk Warden]] — anim_naga, 1.01 m high, rigId rig selection
- [[Monsters/Serpentfolk/Lamia|Lamia]] — anim_naga, 1.61 m high, rigId rig selection
- [[Monsters/Serpentfolk/Naga Warrior|Naga Warrior]] — anim_naga, 1.84 m high, rigId rig selection
- [[Monsters/Serpentfolk/Naga Priestess|Naga Priestess]] — anim_naga, 1.84 m high, rigId rig selection
- [[Monsters/Serpentfolk/Serpent Empress|Serpent Empress]] — anim_naga, 5.52 m high, rigId rig selection
- [[Monsters/Aquatic/Ancient Siren|Ancient Siren]] — anim_naga, 1.38 m high, rigId rig selection
- [[Monsters/Aquatic/Bog Merfolk Warden|Bog Merfolk Warden]] — anim_naga, 1.01 m high, rigId rig selection
- [[Monsters/Serpentfolk/Vine Lamia|Vine Lamia]] — anim_naga, 1.61 m high, rigId rig selection
- [[Monsters/Serpentfolk/Blaze Naga Warrior|Blaze Naga Warrior]] — anim_naga, 1.84 m high, rigId rig selection
- [[Monsters/Serpentfolk/Dune Naga Priestess|Dune Naga Priestess]] — anim_naga, 1.84 m high, rigId rig selection
- [[Monsters/Serpentfolk/Night Serpent Empress|Night Serpent Empress]] — anim_naga, 5.52 m high, rigId rig selection
- [[Monsters/Aquatic/The Drowned Choir, Sirens of the Canals|The Drowned Choir, Sirens of the Canals]] — anim_naga, 0.92 m high, rigId rig selection

## Production checks

Validate the rig export axes, root transform, bone presence, animator mapping, hurtbox placement and a representative locomotion cycle before using it for a new species. Motion overrides should be reserved for species whose signature silhouette or action cannot be expressed by the shared rig rules.
