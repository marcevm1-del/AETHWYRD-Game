using System.Collections.Generic;
using Ascend.Core;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// Plays the face: copies <see cref="FaceExpressionPlayer"/> weights (expression blends and automatic blinking, Core) onto the
    /// blend shapes of the eyes, brows and mouth meshes every frame. Blend shapes are found by name on every SkinnedMeshRenderer
    /// under the character, so it works with any generated variant and does nothing on the placeholder body.
    /// </summary>
    public sealed class FaceExpressionDriver : MonoBehaviour
    {
        FaceExpressionPlayer _player;
        readonly List<(SkinnedMeshRenderer r, int index, string key)> _targets = new List<(SkinnedMeshRenderer, int, string)>();
        CustomizationFile _custom;

        public FaceExpressionPlayer Player => _player;
        /// <summary>How many blend shapes this face drives (0 on a body without the face rig).</summary>
        public int Driven => _targets.Count;

        public static FaceExpressionDriver Ensure(GameObject visual)
        {
            var d = visual.GetComponent<FaceExpressionDriver>();
            return d != null ? d : visual.AddComponent<FaceExpressionDriver>();
        }

        void Awake() => Rebind();

        /// <summary>Re-reads the meshes (after the body or hair changed).</summary>
        public void Rebind()
        {
            var data = AscendData.FaceExpressions;
            _custom = AscendData.Customization;
            if (_player == null) _player = new FaceExpressionPlayer(data, new DeterministicRandom((ulong)Mathf.Abs(gameObject.GetInstanceID()) + 1));
            _targets.Clear();
            var keys = new HashSet<string>();
            if (data != null)
            {
                foreach (var e in data.Expressions.Values) if (e != null) foreach (var k in e.Keys) keys.Add(k);
                if (data.Blink != null) foreach (var k in data.Blink.Keys) keys.Add(k);
            }
            foreach (var r in GetComponentsInChildren<SkinnedMeshRenderer>(true))
            {
                var mesh = r.sharedMesh;
                if (mesh == null) continue;
                for (int i = 0; i < mesh.blendShapeCount; i++)
                {
                    string n = mesh.GetBlendShapeName(i);
                    if (keys.Contains(n)) _targets.Add((r, i, n));
                }
            }
        }

        /// <summary>Shows a creator expression (an id from customization.json, such as "expr_happy") or a face-rig id.</summary>
        public void Show(string expressionId)
        {
            if (_player == null) return;
            var choice = _custom?.Expressions.Find(e => e.Id == expressionId);
            if (choice != null) _player.Set(choice.FaceExpression, choice.Intensity);
            else _player.Set(expressionId);
        }

        void LateUpdate()
        {
            if (_player == null || _targets.Count == 0) return;
            _player.Tick(Time.deltaTime);
            var w = _player.Weights;
            foreach (var (r, index, key) in _targets)
            {
                if (r == null) continue;
                r.SetBlendShapeWeight(index, w.TryGetValue(key, out var v) ? (float)(v * 100.0) : 0f);
            }
        }
    }
}
