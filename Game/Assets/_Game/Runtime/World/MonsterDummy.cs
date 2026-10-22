using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// Graybox stand-in for a monster: reads its species from Data/Monsters/species.json and shows a floating label.
    /// Real AI and combat arrive in Ring 0 week 6.
    /// </summary>
    public sealed class MonsterDummy : MonoBehaviour
    {
        [SerializeField] string speciesId = "mon_goblin";
        [SerializeField] TextMesh label;

        public string SpeciesId { get => speciesId; set => speciesId = value; }

        void Start() => Refresh();

        public void Refresh()
        {
            if (label == null) return;
            if (!AscendData.Db.Species.TryGetValue(speciesId, out var s)) { label.text = $"? {speciesId}"; return; }
            label.text = $"{s.Name}\nRank {s.Rank} · Lv {s.LevelRange[0]}-{s.LevelRange[1]} · HP {s.Stats.Hp}";
        }

        public void SetLabel(TextMesh tm) => label = tm;

        void LateUpdate()
        {
            if (label != null && Camera.main != null)
                label.transform.rotation = Quaternion.LookRotation(label.transform.position - Camera.main.transform.position);
        }
    }
}
