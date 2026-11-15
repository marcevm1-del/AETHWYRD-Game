using Ascend.Core;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// The player's look in the field: the creator's choice (from <see cref="FrontEndSession"/> on a New Game), a saved look
    /// (<see cref="Load"/>) or the data defaults. Applies it to the placeholder rig under the player root (skin, outfit, hair, widths) and
    /// writes it into saves (<see cref="Capture"/>). Added by <see cref="PlayerSave"/>, so the Ring 0 scene needs no change and still works
    /// when started directly.
    /// </summary>
    public sealed class PlayerAppearance : MonoBehaviour
    {
        PlayerAppearanceFile _data;
        public AppearanceChoice Current { get; private set; }

        public static PlayerAppearance Ensure(GameObject player)
        {
            var a = player.GetComponent<PlayerAppearance>();
            return a != null ? a : player.AddComponent<PlayerAppearance>();
        }

        void Awake()
        {
            _data = AscendData.PlayerAppearance;
            var start = FrontEndSession.Pending == FrontEndSession.Mode.NewGame ? FrontEndSession.NewLook : null;
            Set(start ?? new AppearanceChoice());
        }

        /// <summary>Makes <paramref name="look"/> the player's look (normalised against the data) and applies it.</summary>
        public void Set(AppearanceChoice look)
        {
            Current = AppearanceRules.Normalize(look != null ? look.Clone() : new AppearanceChoice(), _data);
            Current.Custom = CustomizationRules.EnsureFor(Current, _data, AscendData.Customization);
            PlaceholderPlayerBody.Apply(transform, Current, _data);
            CharacterLook.Apply(transform, Current, _data);
        }

        public void Capture(SaveGame s)
        {
            if (Current != null) AppearanceRules.WriteTo(s, Current);
        }

        public void Load(SaveGame s)
        {
            if (s == null) return;
            Set(AppearanceRules.ReadFrom(s, _data));
        }
    }
}
