---
type: monster-rig
id: rig:arachnid
tags: [rig, animation, arachnid]
---
# arachnid rig

Eight legs, cephalothorax + abdomen. Wave gait, wall and ceiling walking, web anchors. Menace-heavy: stillness then sudden speed.

| Field | Value |
|---|---|
| Aliases | spider, scorpion, tick, octopod |
| Species using rig | 18 |
| Families represented | Insects & Arachnids, Yokai-Inspired Spirits, Floor-born |
| Bone count · budget | 41 · 48 |
| Unity avatar · material | Generic · chitin |
| Reference size · axis | 1 · length |

## Locomotion and animations

- **Locomotion:** {"gaits":[{"name":"creep","froude":0.2,"legFrac":0.3},{"name":"dart","froude":8,"legFrac":0.3}],"fantasyMult":1,"turnDegPerSecAt1m":600,"accelG":2,"jumpHeightFrac":1.2,"canClimb":"walls_and_ceilings","canSwim":false,"canFly":false,"hovers":false}
- **Physics profile:** {"shapeK":0.03,"density":1100,"collider":{"type":"sphere","radiusFrac":0.25,"centerZFrac":0.2},"gravityScale":1.4,"linearDrag":0.1,"knockbackResist":0.2,"launchable":true,"ragdoll":"partial","deathStyle":"flip_legs_curl"}
- **Animation set:** [{"name":"idle","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_alert","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_fidget_01","frames":120,"loop":false,"rootMotion":false,"events":[]},{"name":"turn_90_L","frames":20,"loop":false,"rootMotion":true,"events":[]},{"name":"turn_90_R","frames":20,"loop":false,"rootMotion":true,"events":[]},{"name":"turn_180","frames":30,"loop":false,"rootMotion":true,"events":[]},{"name":"hit_light_front","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_light_back","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_heavy","frames":22,"loop":false,"rootMotion":true,"events":[]},{"name":"stagger","frames":40,"loop":false,"rootMotion":true,"events":[]},{"name":"break_down_loop","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"break_recover","frames":30,"loop":false,"rootMotion":false,"events":[]},{"name":"knockdown","frames":28,"loop":false,"rootMotion":true,"events":[]},{"name":"getup","frames":36,"loop":false,"rootMotion":false,"events":[]},{"name":"death","frames":45,"loop":false,"rootMotion":true,"events":[{"f":30,"e":"ragdoll"}]},{"name":"spawn","frames":40,"loop":false,"rootMotion":false,"events":[{"f":0,"e":"vfx"}]},{"name":"taunt","frames":45,"loop":false,"rootMotion":false,"events":[{"f":10,"e":"vocal"}]},{"name":"flee_start","frames":15,"loop":false,"rootMotion":true,"events":[]},{"name":"sleep_loop","frames":120,"loop":true,"rootMotion":false,"events":[]},{"name":"eat_loop","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"frozen_pose","frames":1,"loop":true,"rootMotion":false,"events":[]},{"name":"stun_loop","frames":40,"loop":true,"rootMotion":false,"events":[]},{"name":"creep","frames":40,"loop":true,"rootMotion":true,"events":[]},{"name":"dart","frames":10,"loop":true,"rootMotion":true,"events":[]},{"name":"wall_walk","frames":30,"loop":true,"rootMotion":true,"events":[]},{"name":"ceiling_drop","frames":24,"loop":false,"rootMotion":false,"events":[{"f":18,"e":"land"}]},{"name":"launch_air","frames":14,"loop":false,"rootMotion":false,"events":[]},{"name":"air_hit","frames":10,"loop":false,"rootMotion":false,"events":[]},{"name":"fall_loop","frames":20,"loop":true,"rootMotion":false,"events":[]},{"name":"slam_bounce","frames":18,"loop":false,"rootMotion":false,"events":[{"f":2,"e":"land"}]},{"name":"land","frames":14,"loop":false,"rootMotion":false,"events":[{"f":1,"e":"land"}]},{"name":"web_shot","frames":30,"loop":false,"rootMotion":false,"events":[{"f":4,"e":"telegraph"},{"f":16,"e":"hit_on"}]},{"name":"leap_strike","frames":30,"loop":false,"rootMotion":true,"events":[{"f":6,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"}]},{"name":"attack_01","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_02","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_03","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_04","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]}]
- **Procedural motion:** ["wave_gait_ik","wall_walk_align_to_normal","abdomen_pulse_breathing","leg_tap_idle","still_then_dart"]

## Default hurtboxes

- **cephalothorax** — sphere; radius 0.13; damage multiplier default
- **head_eyes** — sphere; radius 0.05; damage multiplier default
- **abdomen** — sphere; radius 0.18; damage multiplier default

## Species

- [[Monsters/Insects & Arachnids/Cave Spider|Cave Spider]] — anim_octopod, 0.2 m high, override rig selection
- [[Monsters/Insects & Arachnids/Venom Spider|Venom Spider]] — anim_octopod, 0.39 m high, rigId rig selection
- [[Monsters/Insects & Arachnids/Arachne|Arachne]] — anim_octopod, 0.84 m high, rigId rig selection
- [[Monsters/Insects & Arachnids/Arachne Matriarch|Arachne Matriarch]] — anim_octopod, 2.24 m high, rigId rig selection
- [[Monsters/Yokai-Inspired Spirits/Earth Weaver|Earth Weaver]] — anim_octopod, 1.68 m high, rigId rig selection
- [[Monsters/Floor-born/Maze Weaver|Maze Weaver]] — anim_octopod, 0.84 m high, rigId rig selection
- [[Monsters/Insects & Arachnids/Ancient Cave Spider|Ancient Cave Spider]] — anim_octopod, 0.28 m high, override (base species) rig selection
- [[Monsters/Insects & Arachnids/Gilded Spider|Gilded Spider]] — anim_octopod, 0.39 m high, rigId rig selection
- [[Monsters/Insects & Arachnids/Tide Arachne|Tide Arachne]] — anim_octopod, 0.84 m high, rigId rig selection
- [[Monsters/Insects & Arachnids/Greater Arachne Matriarch|Greater Arachne Matriarch]] — anim_octopod, 3.58 m high, rigId rig selection
- [[Monsters/Yokai-Inspired Spirits/Ancient Earth Weaver|Ancient Earth Weaver]] — anim_octopod, 2.52 m high, rigId rig selection
- [[Monsters/Floor-born/Elder Maze Weaver|Elder Maze Weaver]] — anim_octopod, 1.34 m high, rigId rig selection
- [[Monsters/Insects & Arachnids/Vesper-Touched Cave Spider|Vesper-Touched Cave Spider]] — anim_octopod, 0.2 m high, override (base species) rig selection
- [[Monsters/Insects & Arachnids/Cavern Spider|Cavern Spider]] — anim_octopod, 0.39 m high, rigId rig selection
- [[Monsters/Insects & Arachnids/Frost Arachne|Frost Arachne]] — anim_octopod, 0.84 m high, rigId rig selection
- [[Monsters/Insects & Arachnids/Sky Arachne Matriarch|Sky Arachne Matriarch]] — anim_octopod, 2.24 m high, rigId rig selection
- [[Monsters/Insects & Arachnids/Mother Webcrawler, Terror of the Small|Mother Webcrawler, Terror of the Small]] — anim_octopod, 0.34 m high, rigId rig selection
- [[Monsters/Insects & Arachnids/Vel'thara, the Web Queen|Vel'thara, the Web Queen]] — anim_octopod, 1.12 m high, rigId rig selection

## Production checks

Validate the rig export axes, root transform, bone presence, animator mapping, hurtbox placement and a representative locomotion cycle before using it for a new species. Motion overrides should be reserved for species whose signature silhouette or action cannot be expressed by the shared rig rules.
