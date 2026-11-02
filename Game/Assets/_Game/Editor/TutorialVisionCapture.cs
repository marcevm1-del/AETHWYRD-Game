using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Ascend.EditorTools
{
    /// <summary>
    /// Tutorial Vision (13_Production/tutorial_vision.md): saves what the Game view camera and the Scene view see as
    /// PNGs, so an agent applying a tutorial through MCP for Unity can compare its result with the tutorial's frames.
    /// MCP for Unity has no screenshot tool; the agent calls execute_menu_item("Ascend/Tutorial Vision/Capture Game View").
    /// Output: Game/Logs/tutorial_vision/game_&lt;time&gt;.png and scene_&lt;time&gt;.png (gitignored). Read-only on the scene.
    /// </summary>
    public static class TutorialVisionCapture
    {
        const int Width = 1600, Height = 900;

        [MenuItem("Ascend/Tutorial Vision/Capture Game View")]
        public static void CaptureMenu()
        {
            string dir = Path.GetFullPath(Path.Combine(Application.dataPath, "..", "Logs", "tutorial_vision"));
            Directory.CreateDirectory(dir);
            string stamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            Camera game = Camera.main != null ? Camera.main : UnityEngine.Object.FindFirstObjectByType<Camera>();
            if (game != null) Save(game, Path.Combine(dir, "game_" + stamp + ".png"));
            else Debug.LogWarning("[TutorialVision] no camera in the scene for the Game view capture");
            SceneView sv = SceneView.lastActiveSceneView;
            if (sv != null && sv.camera != null) Save(sv.camera, Path.Combine(dir, "scene_" + stamp + ".png"));
        }

        static void Save(Camera cam, string path)
        {
            var rt = new RenderTexture(Width, Height, 24, RenderTextureFormat.ARGB32);
            RenderTexture prevTarget = cam.targetTexture, prevActive = RenderTexture.active;
            try
            {
                cam.targetTexture = rt;
                cam.Render();
                RenderTexture.active = rt;
                var tex = new Texture2D(Width, Height, TextureFormat.RGB24, false);
                tex.ReadPixels(new Rect(0, 0, Width, Height), 0, 0);
                tex.Apply();
                File.WriteAllBytes(path, tex.EncodeToPNG());
                UnityEngine.Object.DestroyImmediate(tex);
                Debug.Log("[TutorialVision] saved " + path);
            }
            finally
            {
                cam.targetTexture = prevTarget;
                RenderTexture.active = prevActive;
                rt.Release();
                UnityEngine.Object.DestroyImmediate(rt);
            }
        }
    }
}
