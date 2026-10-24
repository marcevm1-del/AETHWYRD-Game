---
type: monster-rig
id: rig:wyvern
tags: [rig, animation, wyvern]
---
# wyvern rig

Two legs + wings that double as front limbs (walks on wing-knuckles). Lighter and faster than dragons.

| Field | Value |
|---|---|
| Aliases | wyvern, drake_winged, pterosaur |
| Species using rig | 12 |
| Families represented | Killer Insects, Dragons, Demons |
| Bone count · budget | 42 · 70 |
| Unity avatar · material | Generic · scaled |
| Reference size · axis | 6 · length |

## Locomotion and animations

- **Locomotion:** {"gaits":[{"name":"wingwalk","froude":0.4,"legFrac":0.3},{"name":"run","froude":1.8,"legFrac":0.3}],"fantasyMult":1,"turnDegPerSecAt1m":600,"accelG":0.6,"jumpHeightFrac":0.4,"canClimb":"cliffs","canSwim":false,"canFly":true,"hovers":true,"flySpeedMult":2.8}
- **Physics profile:** {"shapeK":0.004,"density":1150,"collider":{"type":"capsule","axis":"y","radiusFrac":0.08,"heightFrac":0.5},"gravityScale":1,"linearDrag":0.05,"knockbackResist":0.8,"launchable":false,"ragdoll":"partial","deathStyle":"crash_slide"}
- **Animation set:** [{"name":"idle","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_alert","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_fidget_01","frames":120,"loop":false,"rootMotion":false,"events":[]},{"name":"turn_90_L","frames":20,"loop":false,"rootMotion":true,"events":[]},{"name":"turn_90_R","frames":20,"loop":false,"rootMotion":true,"events":[]},{"name":"turn_180","frames":30,"loop":false,"rootMotion":true,"events":[]},{"name":"hit_light_front","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_light_back","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_heavy","frames":22,"loop":false,"rootMotion":true,"events":[]},{"name":"stagger","frames":40,"loop":false,"rootMotion":true,"events":[]},{"name":"break_down_loop","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"break_recover","frames":30,"loop":false,"rootMotion":false,"events":[]},{"name":"knockdown","frames":28,"loop":false,"rootMotion":true,"events":[]},{"name":"getup","frames":36,"loop":false,"rootMotion":false,"events":[]},{"name":"death","frames":45,"loop":false,"rootMotion":true,"events":[{"f":30,"e":"ragdoll"}]},{"name":"spawn","frames":40,"loop":false,"rootMotion":false,"events":[{"f":0,"e":"vfx"}]},{"name":"taunt","frames":45,"loop":false,"rootMotion":false,"events":[{"f":10,"e":"vocal"}]},{"name":"flee_start","frames":15,"loop":false,"rootMotion":true,"events":[]},{"name":"sleep_loop","frames":120,"loop":true,"rootMotion":false,"events":[]},{"name":"eat_loop","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"frozen_pose","frames":1,"loop":true,"rootMotion":false,"events":[]},{"name":"stun_loop","frames":40,"loop":true,"rootMotion":false,"events":[]},{"name":"wingwalk","frames":30,"loop":true,"rootMotion":true,"events":[]},{"name":"run","frames":20,"loop":true,"rootMotion":true,"events":[]},{"name":"fly_hover","frames":30,"loop":true,"rootMotion":false,"events":[]},{"name":"fly_forward","frames":24,"loop":true,"rootMotion":true,"events":[]},{"name":"fly_glide","frames":40,"loop":true,"rootMotion":true,"events":[]},{"name":"takeoff","frames":30,"loop":false,"rootMotion":true,"events":[]},{"name":"fly_land","frames":30,"loop":false,"rootMotion":true,"events":[]},{"name":"dive","frames":20,"loop":false,"rootMotion":true,"events":[]},{"name":"tail_sting","frames":30,"loop":false,"rootMotion":false,"events":[{"f":6,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":21,"e":"hit_off"}]},{"name":"dive_grab","frames":30,"loop":false,"rootMotion":true,"events":[]},{"name":"attack_01","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_02","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_03","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_04","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_05","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_06","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]}]
- **Procedural motion:** ["neck_aim_ik","wingwalk_ik","tail_counterbalance","bank_into_turns_in_air","footstep_camera_shake"]

## Default hurtboxes

- **head** — sphere; radius 0.05; damage multiplier default
- **chest** — sphere; radius 0.09; damage multiplier default
- **wing_radius_L** — capsule; radius 0.025; damage multiplier default
- **wing_radius_R** — capsule; radius 0.025; damage multiplier default
- **tail_05** — capsule; radius 0.02; damage multiplier default

## Species

- [[Monsters/Killer Insects/Hive Tyrant|Hive Tyrant]] — anim_wyvern, 3.5 m high, rigId rig selection
- [[Monsters/Dragons/Wyvern|Wyvern]] — anim_wyvern, 4 m high, rigId rig selection
- [[Monsters/Dragons/Drake Lord|Drake Lord]] — anim_wyvern, 5 m high, rigId rig selection
- [[Monsters/Demons/Gargoyle|Gargoyle]] — anim_wyvern, 1 m high, rigId rig selection
- [[Monsters/Demons/Arch Demon|Arch Demon]] — anim_wyvern, 4 m high, rigId rig selection
- [[Monsters/Killer Insects/Vine Hive Tyrant|Vine Hive Tyrant]] — anim_wyvern, 3.5 m high, rigId rig selection
- [[Monsters/Dragons/Rime Wyvern|Rime Wyvern]] — anim_wyvern, 4 m high, rigId rig selection
- [[Monsters/Dragons/Vesper-Touched Drake Lord|Vesper-Touched Drake Lord]] — anim_wyvern, 5 m high, rigId rig selection
- [[Monsters/Demons/Briar Gargoyle|Briar Gargoyle]] — anim_wyvern, 1 m high, rigId rig selection
- [[Monsters/Demons/Blight Arch Demon|Blight Arch Demon]] — anim_wyvern, 4 m high, rigId rig selection
- [[Monsters/Killer Insects/Greater Hive Tyrant|Greater Hive Tyrant]] — anim_wyvern, 5.6 m high, rigId rig selection
- [[Monsters/Dragons/Vyrmax, the Drake Lord|Vyrmax, the Drake Lord]] — anim_wyvern, 7 m high, rigId rig selection

## Production checks

Validate the rig export axes, root transform, bone presence, animator mapping, hurtbox placement and a representative locomotion cycle before using it for a new species. Motion overrides should be reserved for species whose signature silhouette or action cannot be expressed by the shared rig rules.
