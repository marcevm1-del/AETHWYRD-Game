---
type: monster-rig
id: rig:stub_biped
tags: [rig, animation, stub-biped]
---
# stub_biped rig

Tiny two-legged critters with no real arms: walking mushrooms, mandrakes, sprouts. Waddle gait, huge head/cap.

| Field | Value |
|---|---|
| Aliases | mushroom, mandrake, sprout, stub, walking_plant |
| Species using rig | 6 |
| Families represented | Plants & Fungi |
| Bone count · budget | 20 · 18 |
| Unity avatar · material | Generic · wood |
| Reference size · axis | 0.5 · height |

## Locomotion and animations

- **Locomotion:** {"gaits":[{"name":"waddle","froude":0.35,"legFrac":0.25},{"name":"scurry","froude":2.2,"legFrac":0.25}],"fantasyMult":1.2,"turnDegPerSecAt1m":300,"accelG":0.8,"jumpHeightFrac":0.6,"canClimb":false,"canSwim":false,"canFly":false,"hovers":false}
- **Physics profile:** {"shapeK":0.25,"density":700,"collider":{"type":"capsule","radiusFrac":0.3,"heightFrac":1},"gravityScale":1.5,"linearDrag":0.2,"knockbackResist":0.05,"launchable":true,"ragdoll":"partial","deathStyle":"topple_puff"}
- **Animation set:** [{"name":"idle","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_alert","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_fidget_01","frames":120,"loop":false,"rootMotion":false,"events":[]},{"name":"turn_90_L","frames":20,"loop":false,"rootMotion":true,"events":[]},{"name":"turn_90_R","frames":20,"loop":false,"rootMotion":true,"events":[]},{"name":"turn_180","frames":30,"loop":false,"rootMotion":true,"events":[]},{"name":"hit_light_front","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_light_back","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_heavy","frames":22,"loop":false,"rootMotion":true,"events":[]},{"name":"stagger","frames":40,"loop":false,"rootMotion":true,"events":[]},{"name":"break_down_loop","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"break_recover","frames":30,"loop":false,"rootMotion":false,"events":[]},{"name":"knockdown","frames":28,"loop":false,"rootMotion":true,"events":[]},{"name":"getup","frames":36,"loop":false,"rootMotion":false,"events":[]},{"name":"death","frames":45,"loop":false,"rootMotion":true,"events":[{"f":30,"e":"ragdoll"}]},{"name":"spawn","frames":40,"loop":false,"rootMotion":false,"events":[{"f":0,"e":"vfx"}]},{"name":"taunt","frames":45,"loop":false,"rootMotion":false,"events":[{"f":10,"e":"vocal"}]},{"name":"flee_start","frames":15,"loop":false,"rootMotion":true,"events":[]},{"name":"sleep_loop","frames":120,"loop":true,"rootMotion":false,"events":[]},{"name":"eat_loop","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"frozen_pose","frames":1,"loop":true,"rootMotion":false,"events":[]},{"name":"stun_loop","frames":40,"loop":true,"rootMotion":false,"events":[]},{"name":"walk","frames":32,"loop":true,"rootMotion":true,"events":[{"f":0,"e":"footstep_L"},{"f":16,"e":"footstep_R"}]},{"name":"run","frames":20,"loop":true,"rootMotion":true,"events":[{"f":0,"e":"footstep_L"},{"f":10,"e":"footstep_R"}]},{"name":"walk_back","frames":32,"loop":true,"rootMotion":true,"events":[]},{"name":"strafe_L","frames":28,"loop":true,"rootMotion":true,"events":[]},{"name":"strafe_R","frames":28,"loop":true,"rootMotion":true,"events":[]},{"name":"launch_air","frames":14,"loop":false,"rootMotion":false,"events":[]},{"name":"air_hit","frames":10,"loop":false,"rootMotion":false,"events":[]},{"name":"fall_loop","frames":20,"loop":true,"rootMotion":false,"events":[]},{"name":"slam_bounce","frames":18,"loop":false,"rootMotion":false,"events":[{"f":2,"e":"land"}]},{"name":"land","frames":14,"loop":false,"rootMotion":false,"events":[{"f":1,"e":"land"}]},{"name":"burrow","frames":40,"loop":false,"rootMotion":false,"events":[]},{"name":"emerge","frames":30,"loop":false,"rootMotion":false,"events":[]},{"name":"spore_puff","frames":30,"loop":false,"rootMotion":false,"events":[{"f":12,"e":"vfx"}]},{"name":"attack_01","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_02","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_03","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]}]
- **Procedural motion:** ["waddle_side_sway","cap_bob","look_at_target","foot_ik_ground"]

## Default hurtboxes

- **cap** — sphere; radius 0.32; damage multiplier default
- **body** — capsule; radius 0.17; damage multiplier default

## Species

- [[Monsters/Plants & Fungi/Mandrake|Mandrake]] — anim_plant_walker, 0.3 m high, override rig selection
- [[Monsters/Plants & Fungi/Puffcap Mushroom|Puffcap Mushroom]] — anim_plant_walker, 0.5 m high, override rig selection
- [[Monsters/Plants & Fungi/Walking Mushroom|Walking Mushroom]] — anim_plant_walker, 0.6 m high, override rig selection
- [[Monsters/Plants & Fungi/Ancient Mandrake|Ancient Mandrake]] — anim_plant_walker, 0.4 m high, override (base species) rig selection
- [[Monsters/Plants & Fungi/Frost Puffcap Mushroom|Frost Puffcap Mushroom]] — anim_plant_walker, 0.5 m high, override (base species) rig selection
- [[Monsters/Plants & Fungi/Phantom Walking Mushroom|Phantom Walking Mushroom]] — anim_plant_walker, 0.6 m high, override (base species) rig selection

## Production checks

Validate the rig export axes, root transform, bone presence, animator mapping, hurtbox placement and a representative locomotion cycle before using it for a new species. Motion overrides should be reserved for species whose signature silhouette or action cannot be expressed by the shared rig rules.
