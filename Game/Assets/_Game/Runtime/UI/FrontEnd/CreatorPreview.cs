using Ascend.Core;
using UnityEngine;
using UnityEngine.Rendering;

namespace Ascend.Game
{
    /// <summary>
    /// The creator's live preview: the player body (<see cref="PlayerBodyLibrary"/> prefab or the placeholder rig) standing on a small
    /// disc, lit, turning slowly, rendered by its own camera into a RenderTexture that the creator draws in its portrait card.
    /// Everything sits far from the origin on one unused layer so the title scene and tests are unaffected.
    /// </summary>
    public sealed class CreatorPreview
    {
        public const int Layer = 31;
        public const float TurnDegreesPerSecond = 18f;
        static readonly Vector3 Anchor = new Vector3(4000f, 0f, 4000f);

        readonly GameObject _root;
        readonly Transform _turn;
        readonly Camera _cam;
        readonly RenderTexture _rt;
        readonly PlayerAppearanceFile _data;
        readonly AmbientMode _ambientWas;
        readonly Color _ambientColourWas;
        Body _built = (Body)(-1);
        float _yaw = 330f;

        public RenderTexture Texture => _rt;
        /// <summary>The "Visual" parent: the body's root, for tests and captures.</summary>
        public Transform BodyRoot => _turn;
        public float Yaw => _yaw;

        public CreatorPreview(PlayerAppearanceFile data, int width = 640, int height = 800)
        {
            _data = data;
            _ambientWas = RenderSettings.ambientMode;
            _ambientColourWas = RenderSettings.ambientLight;
            RenderSettings.ambientMode = AmbientMode.Flat;
            RenderSettings.ambientLight = new Color(0.52f, 0.56f, 0.72f);

            _root = new GameObject("CreatorPreview") { hideFlags = HideFlags.DontSave };
            _root.transform.position = Anchor;
            SetLayer(_root, Layer);

            _turn = new GameObject("Turntable").transform;
            _turn.SetParent(_root.transform, false);
            SetLayer(_turn.gameObject, Layer);

            // the stage: a low disc under the feet and a faint halo disc behind
            var disc = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            disc.name = "Stage";
            Object.DestroyImmediate(disc.GetComponent<Collider>());
            disc.transform.SetParent(_root.transform, false);
            disc.transform.localPosition = new Vector3(0f, -0.02f, 0f);
            disc.transform.localScale = new Vector3(1.5f, 0.02f, 1.5f);
            SetLayer(disc, Layer);
            var dr = disc.GetComponent<Renderer>();
            dr.material = PlaceholderPlayerBody.NewMaterial(new Color(0.16f, 0.25f, 0.45f, 1f)); // the primitive's Standard material would draw magenta in URP

            var lightGo = new GameObject("PreviewKey");
            lightGo.transform.SetParent(_root.transform, false);
            lightGo.transform.rotation = Quaternion.Euler(28f, -35f, 0f);
            var light = lightGo.AddComponent<Light>();
            light.type = LightType.Directional;
            light.color = new Color(1f, 0.95f, 0.88f);
            light.intensity = 1.35f;
            light.shadows = LightShadows.None;
            light.cullingMask = 1 << Layer;
            SetLayer(lightGo, Layer);

            _rt = new RenderTexture(width, height, 24, RenderTextureFormat.ARGB32, RenderTextureReadWrite.sRGB) { antiAliasing = 4, hideFlags = HideFlags.DontSave };
            _rt.Create();

            var camGo = new GameObject("PreviewCamera");
            camGo.transform.SetParent(_root.transform, false);
            camGo.transform.localPosition = new Vector3(0f, 1.0f, -4.4f);
            camGo.transform.localRotation = Quaternion.Euler(2f, 0f, 0f);
            _cam = camGo.AddComponent<Camera>();
            _cam.clearFlags = CameraClearFlags.SolidColor;
            _cam.backgroundColor = new Color(0.1f, 0.15f, 0.3f, 1f);
            _cam.cullingMask = 1 << Layer;
            _cam.fieldOfView = 34f;
            _cam.nearClipPlane = 0.3f;
            _cam.farClipPlane = 20f;
            _cam.targetTexture = _rt;
            _cam.allowHDR = false;
            _cam.depth = -50;
            _cam.tag = "Untagged";
        }

        static void SetLayer(GameObject go, int layer)
        {
            go.layer = layer;
            foreach (Transform t in go.transform) SetLayer(t.gameObject, layer);
        }

        /// <summary>Shows a look: rebuilds the body when the body type changed, then tints and shapes it.</summary>
        public void SetLook(AppearanceChoice look)
        {
            if (look == null) return;
            if (_built != look.Body || _turn.Find("Visual") == null)
            {
                PlaceholderPlayerBody.Build(_turn, look.Body);
                _built = look.Body;
            }
            PlaceholderPlayerBody.Apply(_turn, look, _data);
            CharacterLook.Apply(_turn, look, _data);
            SetLayer(_turn.gameObject, Layer); // new hair and face parts join the preview layer
        }

        /// <summary>Turns the body a little. Call every frame.</summary>
        public void Tick(float dt)
        {
            _yaw = Mathf.Repeat(_yaw + TurnDegreesPerSecond * dt, 360f);
            _turn.localRotation = Quaternion.Euler(0f, _yaw, 0f);
        }

        public void Dispose()
        {
            RenderSettings.ambientMode = _ambientWas;
            RenderSettings.ambientLight = _ambientColourWas;
            if (_cam != null) _cam.targetTexture = null;
            if (_rt != null) { _rt.Release(); Object.Destroy(_rt); }
            if (_root != null) Object.Destroy(_root);
        }
    }
}
