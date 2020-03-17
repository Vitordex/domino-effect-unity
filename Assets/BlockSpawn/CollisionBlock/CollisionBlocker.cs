using UnityEngine;

namespace domino_effect.BlockSpawn {
  public class CollisionBlocker : MonoBehaviour, IBlocker {
    private bool _isBlocked = false;

    public bool IsBlocked => _isBlocked;

    private void OnTriggerEnter(Collider other) {
      _isBlocked = IsPlayerObject(other.tag) ? true : _isBlocked;
    }

    private void OnTriggerExit(Collider other) {
      _isBlocked = IsPlayerObject(other.tag) ? false : _isBlocked;
    }

    private bool IsPlayerObject(string tag) {
      return tag == Tags.Player;
    }
  }
}
