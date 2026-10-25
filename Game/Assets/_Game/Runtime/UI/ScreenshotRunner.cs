using System;
using System.IO;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// Review captures for the built player: run with <c>-ascendShot &lt;file.png&gt;</c> and it takes a quest, stands you
    /// in view of the Ring 0 field's monsters, waits for the HUD to settle, saves a screenshot and quits. Does nothing
    /// in normal play. Optional <c>-ascendShotAt x,z</c> moves you somewhere else first, <c>-ascendShotYaw degrees</c> turns you. <c>-ascendShotMap area|world</c>
    /// opens the map on that page instead (with <c>-ascendShotZoom z</c>, <c>-ascendShotRank E</c> to stand at a guild rank
    /// and get its map seal, and <c>-ascendShotWalk</c> to ink a stroll around the village first).
    /// </summary>
    public sealed class ScreenshotRunner : MonoBehaviour
    {
        string _path;
        float _at = -1f;
        int _frames;
        string _mapPage;
        bool _mapOpened;

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
                var yawArg = Arg("-ascendShotYaw");
                float yaw = yawArg != null ? float.Parse(yawArg, System.Globalization.CultureInfo.InvariantCulture) : 0f;
                player.transform.SetPositionAndRotation(to, Quaternion.Euler(0f, yaw, 0f));
                var follow = FindFirstObjectByType<ThirdPersonCamera>();
                if (cc != null) cc.enabled = true;
                if (follow != null) follow.SnapBehind();
            }
            _at = Time.realtimeSinceStartup + 3f;
            _mapPage = Arg("-ascendShotMap");
            if (_mapPage != null && player != null && player.TryGetComponent<PlayerMap>(out var map))
            {
                WorldMapArt.Begin();
                var rank = Arg("-ascendShotRank");
                if (rank != null && quests != null && System.Enum.TryParse<Ascend.Core.RankLetter>(rank, out var letter))
                {
                    quests.Rank.Load(letter, 0, 0);
                    map.Knowledge.OnGuildRank(letter);
                }
                if (System.Array.IndexOf(System.Environment.GetCommandLineArgs(), "-ascendShotWalk") >= 0)
                {
                    // A stroll: the village, the waystone, the north road into the wood and the farms to the east.
                    float r = (float)map.Knowledge.Tuning.AreaRevealMetres;
                    foreach (var p in new[] { new Vector2(0, 0), new Vector2(-10, -10), new Vector2(10, -8), new Vector2(-3, 10), new Vector2(-3, 27), new Vector2(-12, 40), new Vector2(-22, 55), new Vector2(18, 6), new Vector2(23, -14), new Vector2(12, 18) })
                        map.Fog.Reveal(p.x, p.y, r);
                }
            }
        }

        void Update()
        {
            if (_at < 0f || Time.realtimeSinceStartup < _at) return;
            if (_mapPage != null)
            {
                var map = FindFirstObjectByType<PlayerMap>();
                if (!_mapOpened && map != null)
                {
                    _mapOpened = true;
                    WorldMapWindow.IgnoreInput = true;
                    WorldMapWindow.Instance.Open(map, _mapPage == "world" ? WorldMapWindow.Page.World : WorldMapWindow.Page.Area);
                    var zoom = Arg("-ascendShotZoom");
                    if (zoom != null) WorldMapWindow.Instance.SetZoom(float.Parse(zoom, System.Globalization.CultureInfo.InvariantCulture));
                    if (map.HasSystemOverlay) WorldMapWindow.Instance.ToggleOverlay();
                    _at = Time.realtimeSinceStartup + 1.5f;
                    return;
                }
                if (!WorldMapArt.Wait(0) && Time.realtimeSinceStartup < _at + 30f) return;
            }
            if (_frames++ == 0) { Directory.CreateDirectory(Path.GetDirectoryName(_path)); ScreenCapture.CaptureScreenshot(_path); return; }
            if (_frames > 30) Application.Quit();
        }
    }
}
