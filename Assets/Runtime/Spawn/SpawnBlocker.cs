using System.Linq;
using domino_effect.BlockSpawn;
using UnityEngine;

namespace domino_effect.Spawn {
  public class SpawnBlocker : BaseMonoBehaviour {
    private bool _blocked;

    private IBlocker[] _blockers;

    private void Awake() {
      _blockers = FindObjectsOfType<MonoBehaviour>().OfType<IBlocker>().ToArray();
    }

    public bool IsSpawnBlocked() {
      return _blockers.Any((blocker) => blocker.IsBlocked);
    }
  }
}
