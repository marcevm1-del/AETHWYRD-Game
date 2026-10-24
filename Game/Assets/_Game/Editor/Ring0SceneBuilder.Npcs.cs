using System.Linq;
using Ascend.Game;
using UnityEngine;

namespace Ascend.EditorTools
{
    /// <summary>
    /// Quest NPCs and "reach" places for the test fields. NPCs are coloured capsule stand-ins with a name label and a
    /// floating quest marker ("!" offer, "?" hand in) until characters are modelled; ids are from npcs.json.
    /// </summary>
    public static partial class Ring0SceneBuilder
    {
        static void BuildQuestNpcs(Transform world)
        {
            var root = new GameObject("NPCs").transform;
            // Brindlewick side of the field (Ring 0).
            Npc(root, "npc_mina_feathersby", new Vector3(3.5f, 0, -3f), new Color(0.85f, 0.55f, 0.75f));   // guild receptionist
            Npc(root, "npc_farmer_odo", new Vector3(6.5f, 0, 3.5f), new Color(0.75f, 0.6f, 0.35f));        // by the slime patch
            Npc(root, "npc_marta_gruel", new Vector3(-6.5f, 0, -1.5f), new Color(0.85f, 0.4f, 0.3f));        // the Sleeping Griffon's keeper
            Npc(root, "npc_torvald_stonebeard", new Vector3(-4f, 0, -5f), new Color(0.5f, 0.4f, 0.35f));   // smithy stall
            Npc(root, "npc_traveling_merchant_pell", new Vector3(5f, 0, 25f), new Color(0.9f, 0.6f, 0.2f)); // wagon at the Whisperwood edge
            // Whisperwood side, by the treeline waystone and the ruins.
            Npc(root, "npc_lyra_brightwood", new Vector3(3f, 0, 27f), new Color(0.95f, 0.8f, 0.4f));
            Npc(root, "npc_fennick_reed", new Vector3(-7f, 0, 29f), new Color(0.45f, 0.75f, 0.45f));
            Npc(root, "npc_eolande_fairweather", new Vector3(7f, 0, 30f), new Color(0.55f, 0.5f, 0.9f));
            Npc(root, "npc_dax_rowan", new Vector3(-12f, 0, 31f), new Color(0.8f, 0.25f, 0.25f));

            Npc(root, "npc_captain_holt", new Vector3(-3f, 0, 18.5f), new Color(0.6f, 0.6f, 0.7f));        // the gate's watch captain (siege contracts)

            // The guild board beside Mina: today's Day Special, dailies and the weekly commission.
            var board = Prim(PrimitiveType.Cube, "GuildBoard", new Vector3(6f, 1.1f, -3.5f), new Vector3(1.8f, 1.4f, 0.15f), Mat("Wood", new Color(0.55f, 0.38f, 0.24f)), root);
            board.transform.rotation = Quaternion.Euler(0, -30f, 0);
            board.AddComponent<QuestGiver>().NpcId = "npc_guild_clerk_wendel";
            board.AddComponent<QuestBoard>();
            Label(root, new Vector3(6f, 2.1f, -3.5f), "Guild Board", new Color(1f, 0.9f, 0.6f), 0.035f);

            Place(root, "brindlewick_north_gate", new Vector3(0, 0, 20f), 3.5f);
            BuildSiege();
            Place(root, "whisperwood_ruins_mural", new Vector3(0, 0, 88f), 10f);
        }

        /// <summary>
        /// Whisperwood's raids on the Brindlewick gate: a SiegeDirector plus one inactive template per raider species
        /// (its blockout model when exported, else a labelled capsule), cloned at runtime for each wave.
        /// </summary>
        static void BuildSiege()
        {
            var director = new GameObject("SiegeDirector").AddComponent<SiegeDirector>();
            director.Gate = new Vector3(0, 0, 21.5f);
            director.Muster = new Vector3(0, 0, 50f);
            var holder = new GameObject("SiegeTemplates");
            var waves = AscendData.Db.SiegeWaves["reg_whisperwood"];
            var templates = new System.Collections.Generic.List<GameObject>();
            var standIn = Mat("MonsterStandIn", new Color(0.8f, 0.45f, 0.55f));
            foreach (var id in waves.Waves.SelectMany(w => w.Units).Select(u => u.SpeciesId).Distinct())
            {
                var wrapper = new GameObject("Raider_" + id);
                wrapper.transform.SetParent(holder.transform, false);
                var at = new Vector3(0, 0, 0.01f); // faces -z (toward the gate) when cloned with the march rotation
                if (!Model(wrapper.transform, id, id, at))
                {
                    float size = AscendData.Db.Species.TryGetValue(id, out var sp) && sp.SizeMeters > 0 ? (float)sp.SizeMeters : 1f;
                    var s = new Vector3(size * 0.45f, size * 0.5f, size * 0.45f);
                    Dummy(wrapper.transform, id, PrimitiveType.Capsule, at + Vector3.up * s.y, s, standIn);
                }
                templates.Add(wrapper);
            }
            holder.SetActive(false);
            director.Templates = templates.ToArray();
        }

        static void Npc(Transform parent, string npcId, Vector3 feet, Color color)
        {
            var go = Prim(PrimitiveType.Capsule, npcId, feet + Vector3.up * 0.9f, new Vector3(0.6f, 0.9f, 0.6f), Mat("Npc_" + npcId, color), parent);
            go.transform.rotation = Quaternion.LookRotation(new Vector3(-feet.x, 0, -feet.z).normalized + Vector3.forward * 0.001f);
            var giver = go.AddComponent<QuestGiver>();
            giver.NpcId = npcId;

            var label = Label(parent, feet + Vector3.up * 2.05f, AscendData.Db.Npcs.TryGetValue(npcId, out var n) ? $"{n.Name}\n<size=36>{n.Role}</size>" : npcId, Color.white, 0.03f);
            label.GetComponent<TextMesh>().richText = true;
            var marker = Label(parent, feet + Vector3.up * 2.65f, "", new Color(1f, 0.85f, 0.2f), 0.09f);
            giver.SetMarker(marker.GetComponent<TextMesh>());
        }

        static GameObject Label(Transform parent, Vector3 at, string text, Color color, float size)
        {
            var go = new GameObject("Label");
            go.transform.SetParent(parent, false);
            go.transform.position = at;
            var tm = go.AddComponent<TextMesh>();
            tm.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
            go.GetComponent<MeshRenderer>().sharedMaterial = tm.font.material;
            tm.characterSize = size; tm.fontSize = 48; tm.anchor = TextAnchor.LowerCenter; tm.alignment = TextAlignment.Center;
            tm.color = color; tm.text = text;
            return go;
        }

        static void Place(Transform parent, string placeId, Vector3 at, float radius)
        {
            var go = new GameObject("Place_" + placeId);
            go.transform.SetParent(parent, false);
            go.transform.position = at;
            var p = go.AddComponent<QuestPlace>();
            p.PlaceId = placeId; p.Radius = radius;
        }
    }
}
