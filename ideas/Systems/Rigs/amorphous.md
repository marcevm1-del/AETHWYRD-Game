---
type: monster-rig
id: rig:amorphous
tags: [rig, animation, amorphous]
---
# amorphous rig

Menace-5 bodies that break symmetry: a core with 6 procedural limbs that can reattach, a mimic socket that copies other rigs' silhouettes. Audio-first reveals.

| Field | Value |
|---|---|
| Aliases | horror, mimic, aberration, flesh_horror, shapeshifter, aberrant |
| Species using rig | 26 |
| Families represented | Insects & Arachnids, Undead, Constructs & Mimics, Chimeras & Mythic Beasts, Aberrations, Yokai-Inspired Spirits, Floor-born |
| Bone count · budget | 39 · 64 |
| Unity avatar · material | Generic · flesh |
| Reference size · axis | 2 · height |

## Locomotion and animations

- **Locomotion:** {"gaits":[{"name":"lurch","froude":0.15,"legFrac":0.4},{"name":"skitter","froude":5,"legFrac":0.4}],"fantasyMult":1,"turnDegPerSecAt1m":500,"accelG":1.5,"jumpHeightFrac":0.8,"canClimb":"walls_and_ceilings","canSwim":true,"canFly":false,"hovers":false}
- **Physics profile:** {"shapeK":0.03,"density":1000,"collider":{"type":"sphere","radiusFrac":0.3,"centerZFrac":0.4},"gravityScale":1.2,"linearDrag":0.2,"knockbackResist":0.6,"launchable":false,"ragdoll":"chain_physics","deathStyle":"collapse_and_melt"}
- **Animation set:** [{"name":"idle","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_alert","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_fidget_01","frames":120,"loop":false,"rootMotion":false,"events":[]},{"name":"turn_90_L","frames":20,"loop":false,"rootMotion":true,"events":[]},{"name":"turn_90_R","frames":20,"loop":false,"rootMotion":true,"events":[]},{"name":"turn_180","frames":30,"loop":false,"rootMotion":true,"events":[]},{"name":"hit_light_front","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_light_back","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_heavy","frames":22,"loop":false,"rootMotion":true,"events":[]},{"name":"stagger","frames":40,"loop":false,"rootMotion":true,"events":[]},{"name":"break_down_loop","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"break_recover","frames":30,"loop":false,"rootMotion":false,"events":[]},{"name":"knockdown","frames":28,"loop":false,"rootMotion":true,"events":[]},{"name":"getup","frames":36,"loop":false,"rootMotion":false,"events":[]},{"name":"death","frames":45,"loop":false,"rootMotion":true,"events":[{"f":30,"e":"ragdoll"}]},{"name":"spawn","frames":40,"loop":false,"rootMotion":false,"events":[{"f":0,"e":"vfx"}]},{"name":"taunt","frames":45,"loop":false,"rootMotion":false,"events":[{"f":10,"e":"vocal"}]},{"name":"flee_start","frames":15,"loop":false,"rootMotion":true,"events":[]},{"name":"sleep_loop","frames":120,"loop":true,"rootMotion":false,"events":[]},{"name":"eat_loop","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"frozen_pose","frames":1,"loop":true,"rootMotion":false,"events":[]},{"name":"stun_loop","frames":40,"loop":true,"rootMotion":false,"events":[]},{"name":"lurch","frames":48,"loop":true,"rootMotion":true,"events":[]},{"name":"skitter","frames":14,"loop":true,"rootMotion":true,"events":[]},{"name":"unfold_reveal","frames":90,"loop":false,"rootMotion":false,"events":[{"f":10,"e":"vocal"},{"f":60,"e":"vfx"}]},{"name":"mimic_idle","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"ceiling_drop","frames":24,"loop":false,"rootMotion":false,"events":[{"f":18,"e":"land"}]},{"name":"attack_01","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_02","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_03","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_04","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_05","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]}]
- **Procedural motion:** ["asymmetric_limb_timing","limbs_procedural_walk_any_count","mimic_silhouette_swap","stop_motion_stepping","eyes_open_sequentially","copy_target_walk_cycle"]

## Default hurtboxes

- **core** — sphere; radius 0.2; damage multiplier default
- **maw** — sphere; radius 0.08; damage multiplier default
- **eye_1** — sphere; radius 0.03; damage multiplier default
- **eye_2** — sphere; radius 0.03; damage multiplier default
- **eye_3** — sphere; radius 0.03; damage multiplier default
- **eye_4** — sphere; radius 0.03; damage multiplier default

## Species

- [[Monsters/Insects & Arachnids/Hive Mother of the Abyss|Hive Mother of the Abyss]] — anim_aberrant, 60 m high, rigId rig selection
- [[Monsters/Undead/Bone Crawler|Bone Crawler]] — anim_aberrant, 1.4 m high, rigId rig selection
- [[Monsters/Constructs & Mimics/Door Mimic|Door Mimic]] — anim_mimic, 2 m high, rigId rig selection
- [[Monsters/Constructs & Mimics/Mimic|Mimic]] — anim_mimic, 1 m high, rigId rig selection
- [[Monsters/Constructs & Mimics/Mimic King|Mimic King]] — anim_mimic, 6 m high, rigId rig selection
- [[Monsters/Chimeras & Mythic Beasts/Nameless Abomination|Nameless Abomination]] — anim_aberrant, 50 m high, rigId rig selection
- [[Monsters/Aberrations/Skinwalker Mimic|Skinwalker Mimic]] — anim_aberrant, 1.8 m high, rigId rig selection
- [[Monsters/Aberrations/Grin in the Walls|Grin in the Walls]] — anim_mimic, 1 m high, rigId rig selection
- [[Monsters/Aberrations/Faceless One|Faceless One]] — anim_aberrant, 2.2 m high, rigId rig selection
- [[Monsters/Aberrations/The Many-Mouthed|The Many-Mouthed]] — anim_aberrant, 4 m high, rigId rig selection
- [[Monsters/Yokai-Inspired Spirits/Long-Neck Lady|Long-Neck Lady]] — anim_aberrant, 1.7 m high, rigId rig selection
- [[Monsters/Floor-born/Wall Stalker|Wall Stalker]] — anim_aberrant, 2 m high, rigId rig selection
- [[Monsters/Undead/Vesper-Touched Bone Crawler|Vesper-Touched Bone Crawler]] — anim_aberrant, 1.4 m high, rigId rig selection
- [[Monsters/Constructs & Mimics/Vesper-Touched Door Mimic|Vesper-Touched Door Mimic]] — anim_mimic, 2 m high, rigId rig selection
- [[Monsters/Constructs & Mimics/Cloud Mimic|Cloud Mimic]] — anim_mimic, 1 m high, rigId rig selection
- [[Monsters/Constructs & Mimics/Elder Mimic King|Elder Mimic King]] — anim_mimic, 9.6 m high, rigId rig selection
- [[Monsters/Aberrations/Phantom Skinwalker Mimic|Phantom Skinwalker Mimic]] — anim_aberrant, 1.8 m high, rigId rig selection
- [[Monsters/Aberrations/Storm Grin in the Walls|Storm Grin in the Walls]] — anim_mimic, 1 m high, rigId rig selection
- [[Monsters/Aberrations/Vesper-Touched Faceless One|Vesper-Touched Faceless One]] — anim_aberrant, 2.2 m high, rigId rig selection
- [[Monsters/Aberrations/Phantom The Many-Mouthed|Phantom The Many-Mouthed]] — anim_aberrant, 4 m high, rigId rig selection
- [[Monsters/Yokai-Inspired Spirits/Vesper-Touched Long-Neck Lady|Vesper-Touched Long-Neck Lady]] — anim_aberrant, 1.7 m high, rigId rig selection
- [[Monsters/Floor-born/Ruin Wall Stalker|Ruin Wall Stalker]] — anim_aberrant, 2 m high, rigId rig selection
- [[Monsters/Undead/Elder Bone Crawler|Elder Bone Crawler]] — anim_aberrant, 2.2 m high, rigId rig selection
- [[Monsters/Yokai-Inspired Spirits/The Hollow Bride, Matriarch of the Long Necks|The Hollow Bride, Matriarch of the Long Necks]] — anim_aberrant, 2 m high, rigId rig selection
- [[Monsters/Aberrations/The Nightmother, Queen of the Nightshifters|The Nightmother, Queen of the Nightshifters]] — anim_aberrant, 2.2 m high, rigId rig selection
- [[Monsters/Aberrations/The Gentle Warden, Keeper of Ashira|The Gentle Warden, Keeper of Ashira]] — anim_aberrant, 2.1 m high, rigId rig selection

## Production checks

Validate the rig export axes, root transform, bone presence, animator mapping, hurtbox placement and a representative locomotion cycle before using it for a new species. Motion overrides should be reserved for species whose signature silhouette or action cannot be expressed by the shared rig rules.
