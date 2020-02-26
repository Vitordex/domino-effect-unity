using UnityEngine;

namespace domino_effect.Runtime {
  public class FollowMouse : BaseMonoBehaviour {
    [SerializeField] private float _distanceFromCamera = 1f;

    public bool DisconsiderX;
    public bool DisconsiderY;
    public bool DisconsiderZ;

    private void Update() {
      var worldPosition = MainCamera.ScreenToWorldPoint(Input.mousePosition);
      var position = Transform.position;
      Transform.position = new Vector3(
        DisconsiderX ? position.x : worldPosition.x,
        DisconsiderY ? position.y : worldPosition.y,
        DisconsiderZ ? position.z : worldPosition.z + _distanceFromCamera);
    }
  }
}