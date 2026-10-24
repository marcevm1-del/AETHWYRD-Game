using System;
using System.IO;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// Review captures for the built player: run with <c>-ascendShot &lt;file.png&gt;</c> and it takes a quest, stands you
    /// in view of the Ring 0 field's monsters, waits for the HUD to settle, saves a screenshot and quits. Does nothing
    /// in normal play. Optional <c>-ascendShotAt x,z</c> moves you somewhere else first.
    /// </summary>
    public sealed class ScreenshotRunner : MonoBehaviour
    {
        string _path;
        float _at = -1f;
        int _frames;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        static void Boot()
        {
            string path = Arg("-ascendShot");
            if (string.IsNullOrEmpty(path)) return;
            var go = new GameObject("ScreenshotRunner");
            DontDestroyOnLoad(go);
            go.AddComponent<ScreenshotRunner>()._path = Path.GetFullPath(path);
            // Never touch the player's own save: captures use a throwaway folder.
            string sandbox = Path.Combine(Application.temporaryCachePath, "ascend_shot_save");
            if (Directory.Exists(sandbox)) Directory.Delete(sandbox, true);
            PlayerSave.Folder = sandbox;
        }

        static string Arg(string name)
        {
            var args = Environment.GetCommandLineArgs();
            for (int i = 0; i < args.Length - 1; i++) if (args[i] == name) return args[i + 1];
            return null;
        }

        void Start()
        {
            var quests = FindFirstObjectByType<PlayerQuests>();
            if (quests != null && AscendData.Db.Quests.TryGetValue("qst_gld_f_slime_cleanup", out var q)) quests.Accept(q);
            var player = FindFirstObjectByType<PlayerCombat>();
            if (player != null)
            {
                Vector3 to = new Vector3(0f, 0.05f, -1.5f);
                var at = Arg("-ascendShotAt");
                if (at != null)
                {
                    var p = at.Split(',');
                    to = new Vector3(float.Parse(p[0], System.Globalization.CultureInfo.InvariantCulture), 0.05f, float.Parse(p[1], System.Globalization.CultureInfo.InvariantCulture));
                }
                var cc = player.GetComponent<CharacterController>();
                if (cc != null) cc.enabled = false;
                player.transform.SetPositionAndRotation(to, Quaternion.LookRotation(Vector3.forward));
                if (cc != null) cc.enabled = true;
            }
            _at = Time.realtimeSinceStartup + 3f;
        }

        void Update()
        {
            if (_at < 0f || Time.realtimeSinceStartup < _at) return;
            if (_frames++ == 0) { Directory.CreateDirectory(Path.GetDirectoryName(_path)); ScreenCapture.CaptureScreenshot(_path); return; }
            if (_frames > 30) Application.Quit();
        }
    }
}
