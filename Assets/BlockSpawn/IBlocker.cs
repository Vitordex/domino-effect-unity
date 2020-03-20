using UnityEngine.Events;

namespace domino_effect.BlockSpawn
{
    public interface IBlocker
    {
        bool IsBlocked { get; }
        bool IsEnabled { get; }

        void SetEnabled(bool value);

        UnityEvent OnBlock { get; }
        UnityEvent OnUnblock { get; }
    }
}
