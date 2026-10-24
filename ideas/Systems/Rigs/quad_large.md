---
type: monster-rig
id: rig:quad_large
tags: [rig, animation, quad-large]
---
# quad_large rig

Heavy quadrupeds 2.5–8 m. Can rear up on hind legs (bears). Charges are its signature.

| Field | Value |
|---|---|
| Aliases | bear, behemoth, rhino, mammoth, large_beast, drake_ground |
| Species using rig | 73 |
| Families represented | Beasts, Shadows, Reptiles, Dragons, Demons, Avians, Chimeras & Mythic Beasts, Yokai-Inspired Spirits, Floor-born |
| Bone count · budget | 39 · 48 |
| Unity avatar · material | Generic · flesh |
| Reference size · axis | 4 · length |

## Locomotion and animations

- **Locomotion:** {"gaits":[{"name":"walk","froude":0.2,"legFrac":0.5},{"name":"trot","froude":0.8,"legFrac":0.5},{"name":"charge","froude":2.5,"legFrac":0.5}],"fantasyMult":1.05,"turnDegPerSecAt1m":320,"accelG":0.5,"jumpHeightFrac":0.1,"canClimb":false,"canSwim":true,"canFly":false,"hovers":false}
- **Physics profile:** {"shapeK":0.02,"density":1000,"collider":{"type":"capsule","axis":"y","radiusFrac":0.2,"heightFrac":0.95},"gravityScale":1.2,"linearDrag":0.03,"knockbackResist":0.85,"launchable":"only_while_staggered","ragdoll":"partial","deathStyle":"heavy_fall_dust"}
- **Animation set:** [{"name":"idle","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_alert","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_fidget_01","frames":120,"loop":false,"rootMotion":false,"events":[]},{"name":"turn_90_L","frames":20,"loop":false,"rootMotion":true,"events":[]},{"name":"turn_90_R","frames":20,"loop":false,"rootMotion":true,"events":[]},{"name":"turn_180","frames":30,"loop":false,"rootMotion":true,"events":[]},{"name":"hit_light_front","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_light_back","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_heavy","frames":22,"loop":false,"rootMotion":true,"events":[]},{"name":"stagger","frames":40,"loop":false,"rootMotion":true,"events":[]},{"name":"break_down_loop","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"break_recover","frames":30,"loop":false,"rootMotion":false,"events":[]},{"name":"knockdown","frames":28,"loop":false,"rootMotion":true,"events":[]},{"name":"getup","frames":36,"loop":false,"rootMotion":false,"events":[]},{"name":"death","frames":45,"loop":false,"rootMotion":true,"events":[{"f":30,"e":"ragdoll"}]},{"name":"spawn","frames":40,"loop":false,"rootMotion":false,"events":[{"f":0,"e":"vfx"}]},{"name":"taunt","frames":45,"loop":false,"rootMotion":false,"events":[{"f":10,"e":"vocal"}]},{"name":"flee_start","frames":15,"loop":false,"rootMotion":true,"events":[]},{"name":"sleep_loop","frames":120,"loop":true,"rootMotion":false,"events":[]},{"name":"eat_loop","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"frozen_pose","frames":1,"loop":true,"rootMotion":false,"events":[]},{"name":"stun_loop","frames":40,"loop":true,"rootMotion":false,"events":[]},{"name":"walk","frames":36,"loop":true,"rootMotion":true,"events":[{"f":0,"e":"footstep_L"},{"f":9,"e":"footstep_R"},{"f":18,"e":"footstep_R"},{"f":27,"e":"footstep_L"}]},{"name":"trot","frames":24,"loop":true,"rootMotion":true,"events":[]},{"name":"gallop","frames":16,"loop":true,"rootMotion":true,"events":[{"f":3,"e":"footstep_L"},{"f":11,"e":"footstep_R"}]},{"name":"circle_L","frames":30,"loop":true,"rootMotion":true,"events":[]},{"name":"circle_R","frames":30,"loop":true,"rootMotion":true,"events":[]},{"name":"rear_up","frames":40,"loop":false,"rootMotion":false,"events":[{"f":6,"e":"telegraph"}]},{"name":"rear_slam","frames":30,"loop":false,"rootMotion":false,"events":[{"f":14,"e":"hit_on"},{"f":15,"e":"land"}]},{"name":"charge_windup","frames":30,"loop":false,"rootMotion":false,"events":[{"f":2,"e":"telegraph"}]},{"name":"charge_loop","frames":16,"loop":true,"rootMotion":true,"events":[]},{"name":"charge_skid_stop","frames":30,"loop":false,"rootMotion":true,"events":[]},{"name":"roar","frames":60,"loop":false,"rootMotion":false,"events":[{"f":12,"e":"vocal"}]},{"name":"attack_01","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_02","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_03","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_04","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_05","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]}]
- **Procedural motion:** ["look_at_target","foot_ik_ground","footstep_camera_shake","heavy_breathing","charge_lean"]

## Default hurtboxes

- **head** — sphere; radius 0.08; damage multiplier default
- **chest** — capsule; radius 0.18; damage multiplier default
- **spine_01** — capsule; radius 0.17; damage multiplier default
- **forearm_L** — capsule; radius 0.04; damage multiplier default
- **forearm_R** — capsule; radius 0.04; damage multiplier default

## Species

- [[Monsters/Beasts/Bandit Bear|Bandit Bear]] — anim_quad_large, 1.43 m high, rigId rig selection
- [[Monsters/Beasts/Dire Wolf|Dire Wolf]] — anim_quad_large, 1.3 m high, rigId rig selection
- [[Monsters/Beasts/Owlbear|Owlbear]] — anim_quad_large, 1.69 m high, rigId rig selection
- [[Monsters/Beasts/Thunderhorn Elk|Thunderhorn Elk]] — anim_quad_large, 1.82 m high, rigId rig selection
- [[Monsters/Beasts/Frost Fenrir Pup|Frost Fenrir Pup]] — anim_quad_large, 0.98 m high, rigId rig selection
- [[Monsters/Beasts/Behemoth Calf|Behemoth Calf]] — anim_quad_large, 2.6 m high, rigId rig selection
- [[Monsters/Beasts/Sabretooth King|Sabretooth King]] — anim_quad_large, 2.08 m high, rigId rig selection
- [[Monsters/Beasts/Silver Fenrir|Silver Fenrir]] — anim_quad_large, 3.9 m high, rigId rig selection
- [[Monsters/Beasts/Behemoth Ascendant|Behemoth Ascendant]] — anim_quad_large, 26 m high, rigId rig selection
- [[Monsters/Beasts/Garmrok, the World-Eater|Garmrok, the World-Eater]] — anim_quad_large, 78 m high, rigId rig selection
- [[Monsters/Shadows/Shade Hound|Shade Hound]] — anim_quad_large, 0.91 m high, rigId rig selection
- [[Monsters/Reptiles/Giant Lizard|Giant Lizard]] — anim_quad_large, 1.3 m high, rigId rig selection
- [[Monsters/Reptiles/Salamander|Salamander]] — anim_quad_large, 1.04 m high, rigId rig selection
- [[Monsters/Reptiles/Basilisk|Basilisk]] — anim_quad_large, 2.6 m high, rigId rig selection
- [[Monsters/Dragons/Drake|Drake]] — anim_quad_large, 1.3 m high, rigId rig selection
- [[Monsters/Dragons/Fire Drake|Fire Drake]] — anim_quad_large, 1.95 m high, rigId rig selection
- [[Monsters/Dragons/Frost Drake|Frost Drake]] — anim_quad_large, 1.95 m high, rigId rig selection
- [[Monsters/Dragons/Thunder Drake|Thunder Drake]] — anim_quad_large, 1.95 m high, rigId rig selection
- [[Monsters/Demons/Hellhound|Hellhound]] — anim_quad_large, 0.98 m high, rigId rig selection
- [[Monsters/Demons/Nightmare Steed|Nightmare Steed]] — anim_quad_large, 1.63 m high, rigId rig selection
- [[Monsters/Avians/Griffon|Griffon]] — anim_quad_large, 1.95 m high, rigId rig selection
- [[Monsters/Avians/Hippogriff|Hippogriff]] — anim_quad_large, 1.82 m high, rigId rig selection
- [[Monsters/Chimeras & Mythic Beasts/Manticore|Manticore]] — anim_quad_large, 1.95 m high, rigId rig selection
- [[Monsters/Chimeras & Mythic Beasts/Chimera|Chimera]] — anim_quad_large, 2.28 m high, rigId rig selection
- [[Monsters/Chimeras & Mythic Beasts/Nue|Nue]] — anim_quad_large, 1.95 m high, rigId rig selection
- [[Monsters/Chimeras & Mythic Beasts/Unicorn|Unicorn]] — anim_quad_large, 1.3 m high, rigId rig selection
- [[Monsters/Chimeras & Mythic Beasts/Cerberus|Cerberus]] — anim_quad_large, 3.25 m high, rigId rig selection
- [[Monsters/Chimeras & Mythic Beasts/Sphinx|Sphinx]] — anim_quad_large, 3.9 m high, rigId rig selection
- [[Monsters/Chimeras & Mythic Beasts/Qilin|Qilin]] — anim_quad_large, 1.95 m high, rigId rig selection
- [[Monsters/Yokai-Inspired Spirits/Nine-Tailed Vixen Queen|Nine-Tailed Vixen Queen]] — anim_quad_large, 5.2 m high, rigId rig selection
- [[Monsters/Floor-born/Labyrinth Hound|Labyrinth Hound]] — anim_quad_large, 0.91 m high, rigId rig selection
- [[Monsters/Beasts/Elder Bandit Bear|Elder Bandit Bear]] — anim_quad_large, 2.28 m high, rigId rig selection
- [[Monsters/Beasts/Meadow Dire Wolf|Meadow Dire Wolf]] — anim_quad_large, 1.3 m high, rigId rig selection
- [[Monsters/Beasts/Ancient Owlbear|Ancient Owlbear]] — anim_quad_large, 2.54 m high, rigId rig selection
- [[Monsters/Beasts/Phantom Thunderhorn Elk|Phantom Thunderhorn Elk]] — anim_quad_large, 1.82 m high, rigId rig selection
- [[Monsters/Beasts/Thorn Fenrir Pup|Thorn Fenrir Pup]] — anim_quad_large, 0.98 m high, rigId rig selection
- [[Monsters/Beasts/Elder Behemoth Calf|Elder Behemoth Calf]] — anim_quad_large, 4.16 m high, rigId rig selection
- [[Monsters/Beasts/Ancient Sabretooth King|Ancient Sabretooth King]] — anim_quad_large, 3.12 m high, rigId rig selection
- [[Monsters/Beasts/Ancient Silver Fenrir|Ancient Silver Fenrir]] — anim_quad_large, 5.85 m high, rigId rig selection
- [[Monsters/Beasts/Ember Behemoth Ascendant|Ember Behemoth Ascendant]] — anim_quad_large, 26 m high, rigId rig selection
- [[Monsters/Shadows/Ancient Shade Hound|Ancient Shade Hound]] — anim_quad_large, 1.37 m high, rigId rig selection
- [[Monsters/Reptiles/Ancient Giant Lizard|Ancient Giant Lizard]] — anim_quad_large, 1.95 m high, rigId rig selection
- [[Monsters/Reptiles/Phantom Salamander|Phantom Salamander]] — anim_quad_large, 1.04 m high, rigId rig selection
- [[Monsters/Reptiles/Greater Basilisk|Greater Basilisk]] — anim_quad_large, 4.16 m high, rigId rig selection
- [[Monsters/Dragons/Elder Drake|Elder Drake]] — anim_quad_large, 2.08 m high, rigId rig selection
- [[Monsters/Dragons/Greater Fire Drake|Greater Fire Drake]] — anim_quad_large, 3.12 m high, rigId rig selection
- [[Monsters/Dragons/Cinder Drake|Cinder Drake]] — anim_quad_large, 1.95 m high, rigId rig selection
- [[Monsters/Dragons/Ancient Thunder Drake|Ancient Thunder Drake]] — anim_quad_large, 2.93 m high, rigId rig selection
- [[Monsters/Demons/Mud Hellhound|Mud Hellhound]] — anim_quad_large, 0.98 m high, rigId rig selection
- [[Monsters/Demons/Phantom Nightmare Steed|Phantom Nightmare Steed]] — anim_quad_large, 1.63 m high, rigId rig selection
- [[Monsters/Avians/Vesper-Touched Griffon|Vesper-Touched Griffon]] — anim_quad_large, 1.95 m high, rigId rig selection
- [[Monsters/Avians/Ancient Hippogriff|Ancient Hippogriff]] — anim_quad_large, 2.73 m high, rigId rig selection
- [[Monsters/Chimeras & Mythic Beasts/Vesper-Touched Manticore|Vesper-Touched Manticore]] — anim_quad_large, 1.95 m high, rigId rig selection
- [[Monsters/Chimeras & Mythic Beasts/Greater Chimera|Greater Chimera]] — anim_quad_large, 3.64 m high, rigId rig selection
- [[Monsters/Chimeras & Mythic Beasts/Phantom Nue|Phantom Nue]] — anim_quad_large, 1.95 m high, rigId rig selection
- [[Monsters/Chimeras & Mythic Beasts/Dune Unicorn|Dune Unicorn]] — anim_quad_large, 1.3 m high, rigId rig selection
- [[Monsters/Chimeras & Mythic Beasts/Greater Cerberus|Greater Cerberus]] — anim_quad_large, 5.2 m high, rigId rig selection
- [[Monsters/Chimeras & Mythic Beasts/Phantom Sphinx|Phantom Sphinx]] — anim_quad_large, 3.9 m high, rigId rig selection
- [[Monsters/Chimeras & Mythic Beasts/Ancient Qilin|Ancient Qilin]] — anim_quad_large, 2.93 m high, rigId rig selection
- [[Monsters/Yokai-Inspired Spirits/Phantom Nine-Tailed Vixen Queen|Phantom Nine-Tailed Vixen Queen]] — anim_quad_large, 5.2 m high, rigId rig selection
- [[Monsters/Floor-born/Ruin Hound|Ruin Hound]] — anim_quad_large, 0.91 m high, rigId rig selection
- [[Monsters/Beasts/Phantom Bandit Bear|Phantom Bandit Bear]] — anim_quad_large, 1.43 m high, rigId rig selection
- [[Monsters/Beasts/Phantom Dire Wolf|Phantom Dire Wolf]] — anim_quad_large, 1.3 m high, rigId rig selection
- [[Monsters/Beasts/Vesper-Touched Owlbear|Vesper-Touched Owlbear]] — anim_quad_large, 1.69 m high, rigId rig selection
- [[Monsters/Beasts/Ancient Thunderhorn Elk|Ancient Thunderhorn Elk]] — anim_quad_large, 2.73 m high, rigId rig selection
- [[Monsters/Beasts/Steppe Fenrir Pup|Steppe Fenrir Pup]] — anim_quad_large, 0.98 m high, rigId rig selection
- [[Monsters/Beasts/Steppe Behemoth Calf|Steppe Behemoth Calf]] — anim_quad_large, 2.6 m high, rigId rig selection
- [[Monsters/Beasts/Night Sabretooth King|Night Sabretooth King]] — anim_quad_large, 2.08 m high, rigId rig selection
- [[Monsters/Beasts/Night Silver Fenrir|Night Silver Fenrir]] — anim_quad_large, 3.9 m high, rigId rig selection
- [[Monsters/Beasts/Phantom Behemoth Ascendant|Phantom Behemoth Ascendant]] — anim_quad_large, 26 m high, rigId rig selection
- [[Monsters/Chimeras & Mythic Beasts/Mansacor, the Gold-Eating Manticore|Mansacor, the Gold-Eating Manticore]] — anim_quad_large, 3.25 m high, rigId rig selection
- [[Monsters/Beasts/Thrakka, Sabretooth Khan of the Steppe Horde|Thrakka, Sabretooth Khan of the Steppe Horde]] — anim_quad_large, 2.6 m high, rigId rig selection
- [[Monsters/Beasts/Quakeback, the Earthshaker Behemoth|Quakeback, the Earthshaker Behemoth]] — anim_quad_large, 13 m high, rigId rig selection

## Production checks

Validate the rig export axes, root transform, bone presence, animator mapping, hurtbox placement and a representative locomotion cycle before using it for a new species. Motion overrides should be reserved for species whose signature silhouette or action cannot be expressed by the shared rig rules.
