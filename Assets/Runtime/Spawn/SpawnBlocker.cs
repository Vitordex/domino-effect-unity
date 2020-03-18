using System.Linq;
using domino_effect.BlockSpawn;
using UnityEngine;
using UnityEngine.Events;

namespace domino_effect.Spawn {
  public class SpawnBlocker : BaseMonoBehaviour {
    private bool _blocked;
    private bool _shouldBlock;
    private IBlocker[] _blockers;

    public UnityEvent OnBlock;
    public UnityEvent OnUnblock;

    private void Awake() {
      _blockers = FindObjectsOfType<MonoBehaviour>().OfType<IBlocker>().ToArray();

      foreach (var blocker in _blockers) {
        blocker.OnBlock.AddListener(OnBlockHandler);
        blocker.OnUnblock.AddListener(OnUnblockHandler);
      }
    }

    public void OnBlockHandler() {
      _blocked = true;
      OnBlock.Invoke();
    }

    public void OnUnblockHandler() {
      _blocked = false;
      OnUnblock.Invoke();
    }

    public bool IsSpawnBlocked() {
      return _shouldBlock || _blocked;
    }

    public void Block(bool shouldBlock) {
      _shouldBlock = shouldBlock;
    }
  }
}
