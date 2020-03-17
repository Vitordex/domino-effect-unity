using UnityEngine;

namespace domino_effect {
  public class FollowPosition : BaseMonoBehaviour {
    public GameObject Follow;

    private Transform _cachedFollowTransform;
    public Transform FollowTransform {
      get {
        if (_cachedFollowTransform == null) {
          _cachedFollowTransform = Follow.transform;
        }

        return _cachedFollowTransform;
      }
    }

    private void Awake() {
      if (Follow == null)
        Debug.LogError($"[{name}][FollowPosition][Awake] The Follow object should be assigned in the editor");
    }

    private void Update() {
      if (Follow == null) return;

      Transform.position = FollowTransform.position;
    }
  }
}
