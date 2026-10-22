using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

namespace Ascend.EditorTools
{
    /// <summary>
    /// One-time project setup, runnable from the menu or headless:
    ///   Unity.exe -batchmode -projectPath Game -executeMethod Ascend.EditorTools.ProjectSetup.AddPackagesBatch
    /// Adds the Ring 0 packages at the newest versions compatible with this editor.
    /// </summary>
    public static class ProjectSetup
    {
        public static readonly string[] Packages =
        {
            "com.unity.render-pipelines.universal", // URP (toon shading)
            "com.unity.inputsystem",                // controller + keyboard/mouse, rebinding
            "com.unity.cinemachine",                // orbit, lock-on and cinematic cameras
            "com.unity.nuget.newtonsoft-json"       // loads the JSON in Data/ into Ascend.Core models
        };

        static AddAndRemoveRequest _request;
        static bool _exitWhenDone;

        [MenuItem("Ascend/Setup/Add Ring 0 Packages")]
        public static void AddPackages() => Start(false);

        public static void AddPackagesBatch() => Start(true);

        static void Start(bool exit)
        {
            _exitWhenDone = exit;
            _request = Client.AddAndRemove(Packages, null);
            EditorApplication.update += Poll;
            Debug.Log("[Ascend] Adding packages: " + string.Join(", ", Packages));
        }

        static void Poll()
        {
            if (_request == null || !_request.IsCompleted) return;
            EditorApplication.update -= Poll;
            if (_request.Status == StatusCode.Success)
            {
                foreach (var p in _request.Result.Where(p => Packages.Contains(p.name)))
                    Debug.Log($"[Ascend] Package ready: {p.name}@{p.version}");
                if (_exitWhenDone) EditorApplication.Exit(0);
            }
            else
            {
                Debug.LogError("[Ascend] Package setup failed: " + _request.Error?.message);
                if (_exitWhenDone) EditorApplication.Exit(1);
            }
        }
    }
}
