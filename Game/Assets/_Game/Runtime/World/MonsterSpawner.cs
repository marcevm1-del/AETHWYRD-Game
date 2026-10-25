using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// Spawns one-off monsters at runtime (siege raiders, defence events, escort ambushes). Uses an inactive scene
    /// template for the species when there is one (its blockout model, built by the scene builder), else a labelled
    /// capsule sized from species.json. Each monster lives under a "Raider_&lt;species&gt;" object with its label.
    /// </summary>
    public static class MonsterSpawner
    {
        public static MonsterDummy Spawn(IEnumerable<GameObject> templates, string speciesId, Vector3 at, Vector3 faceToward, bool respawns = false)
        {
            Vector3 face = faceToward - at; face.y = 0;
            var rot = face.sqrMagnitude > 1e-4f ? Quaternion.LookRotation(face) : Quaternion.identity;
            var template = (templates ?? Enumerable.Empty<GameObject>()).FirstOrDefault(t => t != null && SpeciesOf(t) == speciesId);
            MonsterDummy body;
            if (template != null)
            {
                var go = Object.Instantiate(template, at, rot);
                go.name = "Raider_" + speciesId;
                go.SetActive(true);
                body = go.GetComponentInChildren<MonsterDummy>();
            }
            else
            {
                if (!AscendData.Db.Species.TryGetValue(speciesId, out var sp)) return null;
                float size = sp.SizeMeters > 0 ? (float)sp.SizeMeters : 1f;
                var wrapper = new GameObject("Raider_" + speciesId);
                wrapper.transform.position = at;
                var go = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                go.name = speciesId;
                go.transform.SetParent(wrapper.transform, true);
                go.transform.localScale = new Vector3(size * 0.45f, size * 0.5f, size * 0.45f);
                go.transform.SetPositionAndRotation(at + Vector3.up * size * 0.5f, rot);
                go.SetActive(false);
                body = go.AddComponent<MonsterDummy>(); body.SpeciesId = speciesId;
                go.AddComponent<MonsterController>();
                go.AddComponent<MonsterAnimator>();
                go.SetActive(true);
            }
            if (body != null) body.Respawns = respawns;
            if (body != null && body.TryGetComponent<MonsterController>(out var ai)) ai.IgnoresWard = true; // raids and ambushes come into town on purpose
            return body;
        }

        /// <summary>The object to destroy for a spawned monster (its "Raider_" wrapper, label included).</summary>
        public static GameObject RootOf(MonsterDummy m) =>
            m.transform.parent != null && m.transform.parent.name.StartsWith("Raider_") ? m.transform.parent.gameObject : m.gameObject;

        public static string SpeciesOf(GameObject template)
        {
            var body = template.GetComponentInChildren<MonsterDummy>(true);
            return body != null ? body.SpeciesId : null;
        }

        /// <summary>Raider templates in the scene (the siege director's), for other spawners to share.</summary>
        public static IEnumerable<GameObject> SceneTemplates => SiegeDirector.Instance != null ? SiegeDirector.Instance.Templates : Enumerable.Empty<GameObject>();
    }
}
