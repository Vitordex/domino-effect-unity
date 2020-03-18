using UnityEngine.Events;

namespace domino_effect.BlockSpawn {
  public interface IBlocker {
    bool IsBlocked { get; }

    UnityEvent OnBlock { get; }
    UnityEvent OnUnblock { get; }
  }
}
