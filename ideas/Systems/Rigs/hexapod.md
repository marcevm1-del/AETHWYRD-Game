---
type: monster-rig
id: rig:hexapod
tags: [rig, animation, hexapod]
---
# hexapod rig

Six-legged insects. Tripod gait (3 legs down at once), procedural leg IK on uneven ground. Mandibles and antennae act.

| Field | Value |
|---|---|
| Aliases | insect, ant, beetle, mantis, bug |
| Species using rig | 34 |
| Families represented | Insects & Arachnids, Killer Insects, Aquatic, Sandborne |
| Bone count · budget | 35 · 40 |
| Unity avatar · material | Generic · chitin |
| Reference size · axis | 0.8 · length |

## Locomotion and animations

- **Locomotion:** {"gaits":[{"name":"walk","froude":0.5,"legFrac":0.2},{"name":"scuttle","froude":6,"legFrac":0.2}],"fantasyMult":1,"turnDegPerSecAt1m":500,"accelG":1.4,"jumpHeightFrac":0.3,"canClimb":"walls_and_ceilings","canSwim":false,"canFly":"some_variants","hovers":false}
- **Physics profile:** {"shapeK":0.04,"density":1100,"collider":{"type":"capsule","axis":"y","radiusFrac":0.14,"heightFrac":0.9},"gravityScale":1.4,"linearDrag":0.1,"knockbackResist":0.25,"launchable":true,"ragdoll":"partial","deathStyle":"flip_legs_curl"}
- **Animation set:** [{"name":"idle","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_alert","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_fidget_01","frames":120,"loop":false,"rootMotion":false,"events":[]},{"name":"turn_90_L","frames":20,"loop":false,"rootMotion":true,"events":[]},{"name":"turn_90_R","frames":20,"loop":false,"rootMotion":true,"events":[]},{"name":"turn_180","frames":30,"loop":false,"rootMotion":true,"events":[]},{"name":"hit_light_front","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_light_back","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_heavy","frames":22,"loop":false,"rootMotion":true,"events":[]},{"name":"stagger","frames":40,"loop":false,"rootMotion":true,"events":[]},{"name":"break_down_loop","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"break_recover","frames":30,"loop":false,"rootMotion":false,"events":[]},{"name":"knockdown","frames":28,"loop":false,"rootMotion":true,"events":[]},{"name":"getup","frames":36,"loop":false,"rootMotion":false,"events":[]},{"name":"death","frames":45,"loop":false,"rootMotion":true,"events":[{"f":30,"e":"ragdoll"}]},{"name":"spawn","frames":40,"loop":false,"rootMotion":false,"events":[{"f":0,"e":"vfx"}]},{"name":"taunt","frames":45,"loop":false,"rootMotion":false,"events":[{"f":10,"e":"vocal"}]},{"name":"flee_start","frames":15,"loop":false,"rootMotion":true,"events":[]},{"name":"sleep_loop","frames":120,"loop":true,"rootMotion":false,"events":[]},{"name":"eat_loop","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"frozen_pose","frames":1,"loop":true,"rootMotion":false,"events":[]},{"name":"stun_loop","frames":40,"loop":true,"rootMotion":false,"events":[]},{"name":"walk","frames":24,"loop":true,"rootMotion":true,"events":[]},{"name":"scuttle","frames":12,"loop":true,"rootMotion":true,"events":[]},{"name":"wall_walk","frames":24,"loop":true,"rootMotion":true,"events":[]},{"name":"launch_air","frames":14,"loop":false,"rootMotion":false,"events":[]},{"name":"air_hit","frames":10,"loop":false,"rootMotion":false,"events":[]},{"name":"fall_loop","frames":20,"loop":true,"rootMotion":false,"events":[]},{"name":"slam_bounce","frames":18,"loop":false,"rootMotion":false,"events":[{"f":2,"e":"land"}]},{"name":"land","frames":14,"loop":false,"rootMotion":false,"events":[{"f":1,"e":"land"}]},{"name":"rear_threat","frames":30,"loop":false,"rootMotion":false,"events":[{"f":4,"e":"telegraph"}]},{"name":"acid_spray","frames":36,"loop":false,"rootMotion":false,"events":[{"f":16,"e":"hit_on"}]},{"name":"attack_01","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_02","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_03","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]}]
- **Procedural motion:** ["tripod_gait_ik","body_height_follow_terrain","antenna_sweep","mandible_clack_idle","wall_walk_align_to_normal"]

## Default hurtboxes

- **head** — sphere; radius 0.08; damage multiplier default
- **thorax** — sphere; radius 0.1; damage multiplier default
- **abdomen_01** — capsule; radius 0.11; damage multiplier default

## Species

- [[Monsters/Insects & Arachnids/Giant Ant|Giant Ant]] — anim_hexapod, 0.2 m high, override rig selection
- [[Monsters/Insects & Arachnids/Armor Beetle|Armor Beetle]] — anim_hexapod, 0.4 m high, rigId rig selection
- [[Monsters/Insects & Arachnids/Blade Mantis|Blade Mantis]] — anim_hexapod, 0.66 m high, rigId rig selection
- [[Monsters/Insects & Arachnids/Queen Ant|Queen Ant]] — anim_hexapod, 1.16 m high, rigId rig selection
- [[Monsters/Insects & Arachnids/Death Mantis|Death Mantis]] — anim_hexapod, 0.99 m high, rigId rig selection
- [[Monsters/Killer Insects/Killer Ant|Killer Ant]] — anim_hexapod, 0.33 m high, rigId rig selection
- [[Monsters/Killer Insects/Needle Wasp|Needle Wasp]] — anim_flyer_small, 0.1 m high, override rig selection
- [[Monsters/Killer Insects/Hornet Lancer|Hornet Lancer]] — anim_flyer_small, 0.4 m high, override rig selection
- [[Monsters/Killer Insects/Queen's Guard|Queen's Guard]] — anim_hexapod, 0.66 m high, rigId rig selection
- [[Monsters/Killer Insects/Bone Weevil|Bone Weevil]] — anim_hexapod, 0.33 m high, rigId rig selection
- [[Monsters/Aquatic/Giant Crab|Giant Crab]] — anim_hexapod, 0.33 m high, rigId rig selection
- [[Monsters/Sandborne/Dune Scorpion|Dune Scorpion]] — anim_hexapod, 0.66 m high, rigId rig selection
- [[Monsters/Insects & Arachnids/Ancient Giant Ant|Ancient Giant Ant]] — anim_hexapod, 0.3 m high, override (base species) rig selection
- [[Monsters/Insects & Arachnids/Vesper-Touched Armor Beetle|Vesper-Touched Armor Beetle]] — anim_hexapod, 0.4 m high, rigId rig selection
- [[Monsters/Insects & Arachnids/Cavern Blade Mantis|Cavern Blade Mantis]] — anim_hexapod, 0.66 m high, rigId rig selection
- [[Monsters/Insects & Arachnids/Dune Queen Ant|Dune Queen Ant]] — anim_hexapod, 1.16 m high, rigId rig selection
- [[Monsters/Insects & Arachnids/Gale Death Mantis|Gale Death Mantis]] — anim_hexapod, 0.99 m high, rigId rig selection
- [[Monsters/Killer Insects/Thorn Killer Ant|Thorn Killer Ant]] — anim_hexapod, 0.33 m high, rigId rig selection
- [[Monsters/Killer Insects/Cavern Needle Wasp|Cavern Needle Wasp]] — anim_flyer_small, 0.1 m high, override (base species) rig selection
- [[Monsters/Killer Insects/Greater Hornet Lancer|Greater Hornet Lancer]] — anim_flyer_small, 0.63 m high, override (base species) rig selection
- [[Monsters/Killer Insects/Ancient Queen's Guard|Ancient Queen's Guard]] — anim_hexapod, 0.99 m high, rigId rig selection
- [[Monsters/Killer Insects/Venom Bone Weevil|Venom Bone Weevil]] — anim_hexapod, 0.33 m high, rigId rig selection
- [[Monsters/Aquatic/Reef Crab|Reef Crab]] — anim_hexapod, 0.33 m high, rigId rig selection
- [[Monsters/Sandborne/Elder Dune Scorpion|Elder Dune Scorpion]] — anim_hexapod, 1.06 m high, rigId rig selection
- [[Monsters/Insects & Arachnids/Greater Giant Ant|Greater Giant Ant]] — anim_hexapod, 0.33 m high, override (base species) rig selection
- [[Monsters/Insects & Arachnids/Meadow Armor Beetle|Meadow Armor Beetle]] — anim_hexapod, 0.4 m high, rigId rig selection
- [[Monsters/Insects & Arachnids/Ash Blade Mantis|Ash Blade Mantis]] — anim_hexapod, 0.66 m high, rigId rig selection
- [[Monsters/Insects & Arachnids/Elder Queen Ant|Elder Queen Ant]] — anim_hexapod, 1.85 m high, rigId rig selection
- [[Monsters/Insects & Arachnids/Ancient Death Mantis|Ancient Death Mantis]] — anim_hexapod, 1.49 m high, rigId rig selection
- [[Monsters/Killer Insects/Radiant Killer Ant|Radiant Killer Ant]] — anim_hexapod, 0.33 m high, rigId rig selection
- [[Monsters/Killer Insects/Greater Needle Wasp|Greater Needle Wasp]] — anim_flyer_small, 0.17 m high, override (base species) rig selection
- [[Monsters/Killer Insects/Zephyr Hornet Lancer|Zephyr Hornet Lancer]] — anim_flyer_small, 0.4 m high, override (base species) rig selection
- [[Monsters/Killer Insects/Deep Queen's Guard|Deep Queen's Guard]] — anim_hexapod, 0.66 m high, rigId rig selection
- [[Monsters/Killer Insects/Gale Bone Weevil|Gale Bone Weevil]] — anim_hexapod, 0.33 m high, rigId rig selection

## Production checks

Validate the rig export axes, root transform, bone presence, animator mapping, hurtbox placement and a representative locomotion cycle before using it for a new species. Motion overrides should be reserved for species whose signature silhouette or action cannot be expressed by the shared rig rules.
