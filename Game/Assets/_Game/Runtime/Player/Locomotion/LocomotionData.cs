using System.IO;
using Ascend.Core;
using Newtonsoft.Json;

namespace Ascend.Game
{
    /// <summary>
    /// Lazy loader for Data/Player/locomotion.json (see Ascend.Core.LocomotionTable). The animation driver, the
    /// controller builder and foot IK read their thresholds and damping from here. Call Reload() after editing the JSON.
    /// </summary>
    public static class LocomotionData
    {
        static LocomotionTable _table;

        public static LocomotionTable Table => _table ??= Load();

        public static void Reload() => _table = null;

        static LocomotionTable Load()
        {
            var path = Path.Combine(AscendData.DataRoot, "Player", "locomotion.json");
            if (!File.Exists(path)) throw new FileNotFoundException($"Ascend data file missing: {path}");
            var t = JsonConvert.DeserializeObject<LocomotionTable>(File.ReadAllText(path));
            t.Validate();
            return t;
        }
    }
}
