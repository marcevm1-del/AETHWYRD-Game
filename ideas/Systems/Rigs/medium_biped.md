---
type: monster-rig
id: rig:medium_biped
tags: [rig, animation, medium-biped]
---
# medium_biped rig

Human-scale bipeds 1.5–2.2 m. Standard Humanoid avatar so Mixamo and asset-store packs retarget directly.

| Field | Value |
|---|---|
| Aliases | humanoid, orc, skeleton, zombie, undead_biped, lizardfolk, bandit, scarecrow, headless |
| Species using rig | 138 |
| Families represented | Goblinoids, Lycanthropes, Undead, Shadows, Orcs, Ogres & Giants, Minotaurs & Beastmen, Reptiles, Constructs & Mimics, Elementals & Spirits, Demons, Aquatic, The Headless, Vesperites (Moon Raiders), Humanoid Enemies |
| Bone count · budget | 33 · 50 |
| Unity avatar · material | Humanoid · flesh |
| Reference size · axis | 1.8 · height |

## Locomotion and animations

- **Locomotion:** {"gaits":[{"name":"walk","froude":0.25,"legFrac":0.5},{"name":"run","froude":1.6,"legFrac":0.5}],"fantasyMult":1.25,"turnDegPerSecAt1m":400,"accelG":0.9,"jumpHeightFrac":0.4,"canClimb":"ledges","canSwim":true,"canFly":false,"hovers":false}
- **Physics profile:** {"shapeK":0.013,"density":1000,"collider":{"type":"capsule","radiusFrac":0.17,"heightFrac":1},"gravityScale":1.5,"linearDrag":0.1,"knockbackResist":0.3,"launchable":true,"ragdoll":"full","deathStyle":"ragdoll"}
- **Animation set:** [{"name":"idle","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_alert","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_fidget_01","frames":120,"loop":false,"rootMotion":false,"events":[]},{"name":"turn_90_L","frames":20,"loop":false,"rootMotion":true,"events":[]},{"name":"turn_90_R","frames":20,"loop":false,"rootMotion":true,"events":[]},{"name":"turn_180","frames":30,"loop":false,"rootMotion":true,"events":[]},{"name":"hit_light_front","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_light_back","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_heavy","frames":22,"loop":false,"rootMotion":true,"events":[]},{"name":"stagger","frames":40,"loop":false,"rootMotion":true,"events":[]},{"name":"break_down_loop","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"break_recover","frames":30,"loop":false,"rootMotion":false,"events":[]},{"name":"knockdown","frames":28,"loop":false,"rootMotion":true,"events":[]},{"name":"getup","frames":36,"loop":false,"rootMotion":false,"events":[]},{"name":"death","frames":45,"loop":false,"rootMotion":true,"events":[{"f":30,"e":"ragdoll"}]},{"name":"spawn","frames":40,"loop":false,"rootMotion":false,"events":[{"f":0,"e":"vfx"}]},{"name":"taunt","frames":45,"loop":false,"rootMotion":false,"events":[{"f":10,"e":"vocal"}]},{"name":"flee_start","frames":15,"loop":false,"rootMotion":true,"events":[]},{"name":"sleep_loop","frames":120,"loop":true,"rootMotion":false,"events":[]},{"name":"eat_loop","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"frozen_pose","frames":1,"loop":true,"rootMotion":false,"events":[]},{"name":"stun_loop","frames":40,"loop":true,"rootMotion":false,"events":[]},{"name":"walk","frames":32,"loop":true,"rootMotion":true,"events":[{"f":0,"e":"footstep_L"},{"f":16,"e":"footstep_R"}]},{"name":"run","frames":20,"loop":true,"rootMotion":true,"events":[{"f":0,"e":"footstep_L"},{"f":10,"e":"footstep_R"}]},{"name":"walk_back","frames":32,"loop":true,"rootMotion":true,"events":[]},{"name":"strafe_L","frames":28,"loop":true,"rootMotion":true,"events":[]},{"name":"strafe_R","frames":28,"loop":true,"rootMotion":true,"events":[]},{"name":"launch_air","frames":14,"loop":false,"rootMotion":false,"events":[]},{"name":"air_hit","frames":10,"loop":false,"rootMotion":false,"events":[]},{"name":"fall_loop","frames":20,"loop":true,"rootMotion":false,"events":[]},{"name":"slam_bounce","frames":18,"loop":false,"rootMotion":false,"events":[{"f":2,"e":"land"}]},{"name":"land","frames":14,"loop":false,"rootMotion":false,"events":[{"f":1,"e":"land"}]},{"name":"block_loop","frames":30,"loop":true,"rootMotion":false,"events":[]},{"name":"block_hit","frames":14,"loop":false,"rootMotion":false,"events":[]},{"name":"dodge_back","frames":18,"loop":false,"rootMotion":true,"events":[]},{"name":"throw","frames":30,"loop":false,"rootMotion":false,"events":[{"f":14,"e":"hit_on"}]},{"name":"climb_up","frames":40,"loop":false,"rootMotion":true,"events":[]},{"name":"attack_01","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_02","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_03","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_04","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_05","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_06","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]}]
- **Procedural motion:** ["look_at_target","foot_ik_ground","breathing","hit_lean_additive","aim_offset_upper_body"]

## Default hurtboxes

- **head** — sphere; radius 0.11; damage multiplier default
- **chest** — capsule; radius 0.16; damage multiplier default
- **pelvis** — sphere; radius 0.14; damage multiplier default
- **thigh_L** — capsule; radius 0.07; damage multiplier default
- **thigh_R** — capsule; radius 0.07; damage multiplier default
- **calf_L** — capsule; radius 0.05; damage multiplier default
- **calf_R** — capsule; radius 0.05; damage multiplier default
- **upperarm_L** — capsule; radius 0.05; damage multiplier default
- **upperarm_R** — capsule; radius 0.05; damage multiplier default

## Species

- [[Monsters/Goblinoids/Hobgoblin|Hobgoblin]] — anim_medium_biped, 1.8 m high, override rig selection
- [[Monsters/Goblinoids/Goblin Champion|Goblin Champion]] — anim_medium_biped, 2 m high, rigId rig selection
- [[Monsters/Goblinoids/Goblin General|Goblin General]] — anim_medium_biped, 2.2 m high, rigId rig selection
- [[Monsters/Goblinoids/Kijin Warrior|Kijin Warrior]] — anim_medium_biped, 2.4 m high, rigId rig selection
- [[Monsters/Lycanthropes/Werewolf|Werewolf]] — anim_medium_biped, 2.2 m high, rigId rig selection
- [[Monsters/Lycanthropes/Wererat|Wererat]] — anim_medium_biped, 1.5 m high, rigId rig selection
- [[Monsters/Lycanthropes/Werebear|Werebear]] — anim_medium_biped, 3 m high, rigId rig selection
- [[Monsters/Lycanthropes/Moon Beast|Moon Beast]] — anim_medium_biped, 2.8 m high, rigId rig selection
- [[Monsters/Lycanthropes/Blood Vesper Alpha|Blood Vesper Alpha]] — anim_medium_biped, 3.2 m high, rigId rig selection
- [[Monsters/Lycanthropes/Skinchanger|Skinchanger]] — anim_medium_biped, 2.4 m high, rigId rig selection
- [[Monsters/Lycanthropes/Fenrir-Blooded Lord|Fenrir-Blooded Lord]] — anim_medium_biped, 3.6 m high, rigId rig selection
- [[Monsters/Undead/Zombie|Zombie]] — anim_medium_biped, 1.7 m high, override rig selection
- [[Monsters/Undead/Skeleton|Skeleton]] — anim_medium_biped, 1.7 m high, override rig selection
- [[Monsters/Undead/Hollow Mourner|Hollow Mourner]] — anim_medium_biped, 1.7 m high, rigId rig selection
- [[Monsters/Undead/Ghoul|Ghoul]] — anim_medium_biped, 1.6 m high, rigId rig selection
- [[Monsters/Undead/Skeleton Knight|Skeleton Knight]] — anim_medium_biped, 2 m high, rigId rig selection
- [[Monsters/Undead/Death Knight|Death Knight]] — anim_medium_biped, 2.4 m high, rigId rig selection
- [[Monsters/Undead/Vampire|Vampire]] — anim_medium_biped, 1.8 m high, rigId rig selection
- [[Monsters/Undead/Vampire Lord|Vampire Lord]] — anim_medium_biped, 2.2 m high, rigId rig selection
- [[Monsters/Undead/No-Life King|No-Life King]] — anim_medium_biped, 3 m high, rigId rig selection
- [[Monsters/Shadows/War Shadow|War Shadow]] — anim_medium_biped, 2 m high, rigId rig selection
- [[Monsters/Shadows/Shade Knight|Shade Knight]] — anim_medium_biped, 2.3 m high, rigId rig selection
- [[Monsters/Shadows/Mirror Shade|Mirror Shade]] — anim_medium_biped, 1.8 m high, rigId rig selection
- [[Monsters/Orcs, Ogres & Giants/Orc Grunt|Orc Grunt]] — anim_medium_biped, 2 m high, rigId rig selection
- [[Monsters/Orcs, Ogres & Giants/Orc Warrior|Orc Warrior]] — anim_medium_biped, 2.1 m high, rigId rig selection
- [[Monsters/Orcs, Ogres & Giants/Orc Berserker|Orc Berserker]] — anim_medium_biped, 2.2 m high, rigId rig selection
- [[Monsters/Orcs, Ogres & Giants/Orc Lord|Orc Lord]] — anim_medium_biped, 2.6 m high, rigId rig selection
- [[Monsters/Minotaurs & Beastmen/Satyr Reveler|Satyr Reveler]] — anim_medium_biped, 1.7 m high, rigId rig selection
- [[Monsters/Minotaurs & Beastmen/Gnoll Raider|Gnoll Raider]] — anim_medium_biped, 2 m high, rigId rig selection
- [[Monsters/Reptiles/Lizardman|Lizardman]] — anim_medium_biped, 2 m high, rigId rig selection
- [[Monsters/Constructs & Mimics/Smiling Scarecrow|Smiling Scarecrow]] — anim_medium_biped, 2 m high, override rig selection
- [[Monsters/Constructs & Mimics/Living Armor|Living Armor]] — anim_medium_biped, 1.9 m high, rigId rig selection
- [[Monsters/Elementals & Spirits/Undine|Undine]] — anim_medium_biped, 1.6 m high, rigId rig selection
- [[Monsters/Elementals & Spirits/Sylph|Sylph]] — anim_medium_biped, 1.5 m high, rigId rig selection
- [[Monsters/Elementals & Spirits/Spirit King|Spirit King]] — anim_medium_biped, 6 m high, rigId rig selection
- [[Monsters/Demons/Lesser Demon|Lesser Demon]] — anim_medium_biped, 2.2 m high, rigId rig selection
- [[Monsters/Demons/Charmfiend|Charmfiend]] — anim_medium_biped, 1.8 m high, rigId rig selection
- [[Monsters/Demons/Greater Demon|Greater Demon]] — anim_medium_biped, 3.5 m high, rigId rig selection
- [[Monsters/Demons/Demon Knight|Demon Knight]] — anim_medium_biped, 2.5 m high, rigId rig selection
- [[Monsters/Demons/Abyss Prince|Abyss Prince]] — anim_medium_biped, 4 m high, rigId rig selection
- [[Monsters/Demons/Abyss Herald|Abyss Herald]] — anim_medium_biped, 10 m high, rigId rig selection
- [[Monsters/Aquatic/Sahuagin|Sahuagin]] — anim_medium_biped, 1.9 m high, rigId rig selection
- [[Monsters/The Headless/Headless Rider|Headless Rider]] — anim_headless, 2.6 m high, rigId rig selection
- [[Monsters/The Headless/Dullahan|Dullahan]] — anim_headless, 2.8 m high, rigId rig selection
- [[Monsters/The Headless/Pale Herald|Pale Herald]] — anim_headless, 3.5 m high, rigId rig selection
- [[Monsters/Vesperites (Moon Raiders)/Vesper Shard-Thrall|Vesper Shard-Thrall]] — anim_medium_biped, 1.8 m high, rigId rig selection
- [[Monsters/Vesperites (Moon Raiders)/Moon Archer|Moon Archer]] — anim_medium_biped, 2 m high, rigId rig selection
- [[Monsters/Humanoid Enemies/Bandit|Bandit]] — anim_medium_biped, 1.8 m high, rigId rig selection
- [[Monsters/Humanoid Enemies/Highwayman Captain|Highwayman Captain]] — anim_medium_biped, 1.8 m high, rigId rig selection
- [[Monsters/Humanoid Enemies/Slaver|Slaver]] — anim_medium_biped, 1.9 m high, rigId rig selection
- [[Monsters/Humanoid Enemies/Dark Cultist|Dark Cultist]] — anim_medium_biped, 1.8 m high, rigId rig selection
- [[Monsters/Humanoid Enemies/Rogue Mage|Rogue Mage]] — anim_medium_biped, 1.8 m high, rigId rig selection
- [[Monsters/Humanoid Enemies/Inquisitor|Inquisitor]] — anim_medium_biped, 1.9 m high, rigId rig selection
- [[Monsters/Humanoid Enemies/Syndicate Blade|Syndicate Blade]] — anim_medium_biped, 1.8 m high, rigId rig selection
- [[Monsters/Humanoid Enemies/Rogue Knight|Rogue Knight]] — anim_medium_biped, 2 m high, rigId rig selection
- [[Monsters/Humanoid Enemies/Fallen Hero|Fallen Hero]] — anim_medium_biped, 1.9 m high, rigId rig selection
- [[Monsters/Humanoid Enemies/Corrupted Summoned Hero|Corrupted Summoned Hero]] — anim_medium_biped, 1.9 m high, rigId rig selection
- [[Monsters/Goblinoids/Moss Hobgoblin|Moss Hobgoblin]] — anim_medium_biped, 1.8 m high, override (base species) rig selection
- [[Monsters/Goblinoids/Vesper-Touched Goblin Champion|Vesper-Touched Goblin Champion]] — anim_medium_biped, 2 m high, rigId rig selection
- [[Monsters/Goblinoids/Vesper-Touched Goblin General|Vesper-Touched Goblin General]] — anim_medium_biped, 2.2 m high, rigId rig selection
- [[Monsters/Goblinoids/Elite Kijin Warrior|Elite Kijin Warrior]] — anim_medium_biped, 3.8 m high, rigId rig selection
- [[Monsters/Lycanthropes/Bog Werewolf|Bog Werewolf]] — anim_medium_biped, 2.2 m high, rigId rig selection
- [[Monsters/Lycanthropes/Elder Wererat|Elder Wererat]] — anim_medium_biped, 2.4 m high, rigId rig selection
- [[Monsters/Lycanthropes/Vesper-Touched Werebear|Vesper-Touched Werebear]] — anim_medium_biped, 3 m high, rigId rig selection
- [[Monsters/Lycanthropes/Phantom Moon Beast|Phantom Moon Beast]] — anim_medium_biped, 2.8 m high, rigId rig selection
- [[Monsters/Lycanthropes/Venom Blood Vesper Alpha|Venom Blood Vesper Alpha]] — anim_medium_biped, 3.2 m high, rigId rig selection
- [[Monsters/Lycanthropes/Elder Skinchanger|Elder Skinchanger]] — anim_medium_biped, 3.8 m high, rigId rig selection
- [[Monsters/Lycanthropes/Phantom Fenrir-Blooded Lord|Phantom Fenrir-Blooded Lord]] — anim_medium_biped, 3.6 m high, rigId rig selection
- [[Monsters/Undead/Vesper-Touched Zombie|Vesper-Touched Zombie]] — anim_medium_biped, 1.7 m high, override (base species) rig selection
- [[Monsters/Undead/Greater Skeleton|Greater Skeleton]] — anim_medium_biped, 2.7 m high, override (base species) rig selection
- [[Monsters/Undead/Greater Hollow Mourner|Greater Hollow Mourner]] — anim_medium_biped, 2.7 m high, rigId rig selection
- [[Monsters/Undead/Vesper-Touched Ghoul|Vesper-Touched Ghoul]] — anim_medium_biped, 1.6 m high, rigId rig selection
- [[Monsters/Undead/Alley Skeleton Knight|Alley Skeleton Knight]] — anim_medium_biped, 2 m high, rigId rig selection
- [[Monsters/Undead/Bog Death Knight|Bog Death Knight]] — anim_medium_biped, 2.4 m high, rigId rig selection
- [[Monsters/Undead/Elder Vampire|Elder Vampire]] — anim_medium_biped, 2.9 m high, rigId rig selection
- [[Monsters/Undead/Ash Vampire Lord|Ash Vampire Lord]] — anim_medium_biped, 2.2 m high, rigId rig selection
- [[Monsters/Shadows/Elder War Shadow|Elder War Shadow]] — anim_medium_biped, 3.2 m high, rigId rig selection
- [[Monsters/Shadows/Vesper-Touched Shade Knight|Vesper-Touched Shade Knight]] — anim_medium_biped, 2.3 m high, rigId rig selection
- [[Monsters/Shadows/Ancient Mirror Shade|Ancient Mirror Shade]] — anim_medium_biped, 2.7 m high, rigId rig selection
- [[Monsters/Orcs, Ogres & Giants/Meadow Orc Grunt|Meadow Orc Grunt]] — anim_medium_biped, 2 m high, rigId rig selection
- [[Monsters/Orcs, Ogres & Giants/Vesper-Touched Orc Warrior|Vesper-Touched Orc Warrior]] — anim_medium_biped, 2.1 m high, rigId rig selection
- [[Monsters/Orcs, Ogres & Giants/Meadow Orc Berserker|Meadow Orc Berserker]] — anim_medium_biped, 2.2 m high, rigId rig selection
- [[Monsters/Orcs, Ogres & Giants/Meadow Orc Lord|Meadow Orc Lord]] — anim_medium_biped, 2.6 m high, rigId rig selection
- [[Monsters/Minotaurs & Beastmen/Ash Satyr Reveler|Ash Satyr Reveler]] — anim_medium_biped, 1.7 m high, rigId rig selection
- [[Monsters/Minotaurs & Beastmen/Cavern Gnoll Raider|Cavern Gnoll Raider]] — anim_medium_biped, 2 m high, rigId rig selection
- [[Monsters/Reptiles/Ancient Lizardman|Ancient Lizardman]] — anim_medium_biped, 3 m high, rigId rig selection
- [[Monsters/Constructs & Mimics/Volt Smiling Scarecrow|Volt Smiling Scarecrow]] — anim_medium_biped, 2 m high, override (base species) rig selection
- [[Monsters/Constructs & Mimics/Greater Living Armor|Greater Living Armor]] — anim_medium_biped, 3 m high, rigId rig selection
- [[Monsters/Elementals & Spirits/Greater Undine|Greater Undine]] — anim_medium_biped, 2.6 m high, rigId rig selection
- [[Monsters/Elementals & Spirits/Phantom Sylph|Phantom Sylph]] — anim_medium_biped, 1.5 m high, rigId rig selection
- [[Monsters/Elementals & Spirits/Vesper-Touched Spirit King|Vesper-Touched Spirit King]] — anim_medium_biped, 6 m high, rigId rig selection
- [[Monsters/Demons/Elder Lesser Demon|Elder Lesser Demon]] — anim_medium_biped, 3.5 m high, rigId rig selection
- [[Monsters/Demons/Hellmarch Charmfiend|Hellmarch Charmfiend]] — anim_medium_biped, 1.8 m high, rigId rig selection
- [[Monsters/Demons/Elder Greater Demon|Elder Greater Demon]] — anim_medium_biped, 5.6 m high, rigId rig selection
- [[Monsters/Demons/Rot Demon Knight|Rot Demon Knight]] — anim_medium_biped, 2.5 m high, rigId rig selection
- [[Monsters/Demons/Ancient Abyss Prince|Ancient Abyss Prince]] — anim_medium_biped, 6 m high, rigId rig selection
- [[Monsters/Demons/Alley Abyss Herald|Alley Abyss Herald]] — anim_medium_biped, 10 m high, rigId rig selection
- [[Monsters/Aquatic/Vesper-Touched Sahuagin|Vesper-Touched Sahuagin]] — anim_medium_biped, 1.9 m high, rigId rig selection
- [[Monsters/The Headless/Vesper-Touched Headless Rider|Vesper-Touched Headless Rider]] — anim_headless, 2.6 m high, rigId rig selection
- [[Monsters/The Headless/Vesper-Touched Dullahan|Vesper-Touched Dullahan]] — anim_headless, 2.8 m high, rigId rig selection
- [[Monsters/The Headless/Phantom Pale Herald|Phantom Pale Herald]] — anim_headless, 3.5 m high, rigId rig selection
- [[Monsters/Vesperites (Moon Raiders)/Ruin Vesper Shard-Thrall|Ruin Vesper Shard-Thrall]] — anim_medium_biped, 1.8 m high, rigId rig selection
- [[Monsters/Vesperites (Moon Raiders)/Vesper-Touched Moon Archer|Vesper-Touched Moon Archer]] — anim_medium_biped, 2 m high, rigId rig selection
- [[Monsters/Humanoid Enemies/Tide Bandit|Tide Bandit]] — anim_medium_biped, 1.8 m high, rigId rig selection
- [[Monsters/Humanoid Enemies/Meadow Highwayman Captain|Meadow Highwayman Captain]] — anim_medium_biped, 1.8 m high, rigId rig selection
- [[Monsters/Humanoid Enemies/Alley Slaver|Alley Slaver]] — anim_medium_biped, 1.9 m high, rigId rig selection
- [[Monsters/Humanoid Enemies/Dark Cultist Veteran|Dark Cultist Veteran]] — anim_medium_biped, 2.9 m high, rigId rig selection
- [[Monsters/Humanoid Enemies/Ancient Rogue Mage|Ancient Rogue Mage]] — anim_medium_biped, 2.7 m high, rigId rig selection
- [[Monsters/Humanoid Enemies/Cinder Inquisitor|Cinder Inquisitor]] — anim_medium_biped, 1.9 m high, rigId rig selection
- [[Monsters/Humanoid Enemies/Syndicate Blade Veteran|Syndicate Blade Veteran]] — anim_medium_biped, 2.9 m high, rigId rig selection
- [[Monsters/Humanoid Enemies/Zephyr Rogue Knight|Zephyr Rogue Knight]] — anim_medium_biped, 2 m high, rigId rig selection
- [[Monsters/Humanoid Enemies/Elite Fallen Hero|Elite Fallen Hero]] — anim_medium_biped, 3 m high, rigId rig selection
- [[Monsters/Goblinoids/Vesper-Touched Hobgoblin|Vesper-Touched Hobgoblin]] — anim_medium_biped, 1.8 m high, override (base species) rig selection
- [[Monsters/Goblinoids/Goblin Champion Veteran|Goblin Champion Veteran]] — anim_medium_biped, 3.2 m high, rigId rig selection
- [[Monsters/Goblinoids/Goblin General Veteran|Goblin General Veteran]] — anim_medium_biped, 3.5 m high, rigId rig selection
- [[Monsters/Goblinoids/Briar Kijin Warrior|Briar Kijin Warrior]] — anim_medium_biped, 2.4 m high, rigId rig selection
- [[Monsters/Lycanthropes/Grove Werewolf|Grove Werewolf]] — anim_medium_biped, 2.2 m high, rigId rig selection
- [[Monsters/Lycanthropes/Greater Wererat|Greater Wererat]] — anim_medium_biped, 2.4 m high, rigId rig selection
- [[Monsters/Lycanthropes/Phantom Werebear|Phantom Werebear]] — anim_medium_biped, 3 m high, rigId rig selection
- [[Monsters/Lycanthropes/Bramble Beast|Bramble Beast]] — anim_medium_biped, 2.8 m high, rigId rig selection
- [[Monsters/Lycanthropes/Ancient Blood Vesper Alpha|Ancient Blood Vesper Alpha]] — anim_medium_biped, 4.8 m high, rigId rig selection
- [[Monsters/Lycanthropes/Blight Skinchanger|Blight Skinchanger]] — anim_medium_biped, 2.4 m high, rigId rig selection
- [[Monsters/Lycanthropes/Thunder Fenrir-Blooded Lord|Thunder Fenrir-Blooded Lord]] — anim_medium_biped, 3.6 m high, rigId rig selection
- [[Monsters/Undead/Dawn Zombie|Dawn Zombie]] — anim_medium_biped, 1.7 m high, override (base species) rig selection
- [[Monsters/Undead/Elder Skeleton|Elder Skeleton]] — anim_medium_biped, 2.7 m high, override (base species) rig selection
- [[Monsters/Undead/Vesper-Touched Hollow Mourner|Vesper-Touched Hollow Mourner]] — anim_medium_biped, 1.7 m high, rigId rig selection
- [[Monsters/Undead/Blight Ghoul|Blight Ghoul]] — anim_medium_biped, 1.6 m high, rigId rig selection
- [[Monsters/Undead/Dune Skeleton Knight|Dune Skeleton Knight]] — anim_medium_biped, 2 m high, rigId rig selection
- [[Monsters/Undead/Phantom Death Knight|Phantom Death Knight]] — anim_medium_biped, 2.4 m high, rigId rig selection
- [[Monsters/Undead/Rot Vampire|Rot Vampire]] — anim_medium_biped, 1.8 m high, rigId rig selection
- [[Monsters/Undead/Rot Vampire Lord|Rot Vampire Lord]] — anim_medium_biped, 2.2 m high, rigId rig selection
- [[Monsters/Goblinoids/Grukk, Goblin Chief of Hollowpine|Grukk, Goblin Chief of Hollowpine]] — anim_medium_biped, 2.4 m high, rigId rig selection
- [[Monsters/Undead/Ashgrave, the Oathless Baron|Ashgrave, the Oathless Baron]] — anim_medium_biped, 2.4 m high, rigId rig selection
- [[Monsters/Humanoid Enemies/Varrick Kade, the Slaver Lord|Varrick Kade, the Slaver Lord]] — anim_medium_biped, 1.9 m high, rigId rig selection
- [[Monsters/Humanoid Enemies/Diego Alvarez, Voice of the Choir of Chains|Diego Alvarez, Voice of the Choir of Chains]] — anim_medium_biped, 1.8 m high, rigId rig selection
- [[Monsters/Demons/Varos, Herald of the Red Gate|Varos, Herald of the Red Gate]] — anim_medium_biped, 3 m high, rigId rig selection
- [[Monsters/Demons/Morvane, Vanguard of the Overlord|Morvane, Vanguard of the Overlord]] — anim_medium_biped, 2.6 m high, rigId rig selection
- [[Monsters/Humanoid Enemies/Cinderlord Vasque, the Smoke Mage|Cinderlord Vasque, the Smoke Mage]] — anim_medium_biped, 1.9 m high, rigId rig selection

## Production checks

Validate the rig export axes, root transform, bone presence, animator mapping, hurtbox placement and a representative locomotion cycle before using it for a new species. Motion overrides should be reserved for species whose signature silhouette or action cannot be expressed by the shared rig rules.
