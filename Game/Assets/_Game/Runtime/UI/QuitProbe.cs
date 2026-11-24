using System;
using System.Collections;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ascend.Game
{
    /// <summary>
    /// Reproduces quitting from play: <c>-ascendQuitProbe seconds</c> uses a throwaway save folder, loads the field, waits, opens
    /// the pause menu and chooses Quit without saving, exactly as a player does. Add <c>-ascendQuitProbeMap</c> to open and close
    /// the world map first. The player's own save is never read or written. Does nothing without the argument.
    /// </summary>
    public sealed class QuitProbe : MonoBehaviour
    {
        float _seconds;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void Boot()
        {
            var arg = FrontEndSession.Arg("-ascendQuitProbe");
            if (string.IsNullOrEmpty(arg)) return;
            if (!float.TryParse(arg, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out var sec)) sec = 20f;
            string sandbox = Path.Combine(Application.temporaryCachePath, "ascend_quit_probe_save");
            if (Directory.Exists(sandbox)) Directory.Delete(sandbox, true);
            Directory.CreateDirectory(sandbox);
            PlayerSave.Folder = sandbox;
            var go = new GameObject("QuitProbe");
            DontDestroyOnLoad(go);
            go.AddComponent<QuitProbe>()._seconds = Mathf.Clamp(sec, 1f, 600f);
        }

        IEnumerator Start()
        {
            yield return null;
            SceneManager.LoadScene(FrontEndSession.FieldScene);
            yield return new WaitForSecondsRealtime(_seconds);
            var player = FindFirstObjectByType<PlayerCombat>();
            Debug.Log($"[quit-probe] player {(player != null ? "found" : "MISSING")}");
            if (player != null && Array.IndexOf(Environment.GetCommandLineArgs(), "-ascendQuitProbeMap") >= 0 && player.TryGetComponent<PlayerMap>(out var map))
            {
                WorldMapWindow.Instance.Toggle(map);
                yield return new WaitForSecondsRealtime(8f);
                WorldMapWindow.Instance.Toggle(map);
                yield return new WaitForSecondsRealtime(1f);
            }
            Debug.Log($"[quit-probe] paused {PauseMenu.TryOpen(player)}");
            yield return new WaitForSecondsRealtime(1f);
            Press("Quit game");
            yield return new WaitForSecondsRealtime(0.5f);
            Debug.Log("[quit-probe] quitting");
            Press("Quit without saving");
        }

        static void Press(string row)
        {
            int i = PauseMenu.Instance.Rows.ToList().FindIndex(r => r.Text.StartsWith(row, StringComparison.Ordinal));
            if (i < 0 || !PauseMenu.Instance.Choose(i)) Debug.Log($"[quit-probe] row not found: {row}");
        }
    }
}
