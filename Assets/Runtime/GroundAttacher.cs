using domino_effect.Input;
using UnityEngine;

namespace domino_effect {
  public class GroundAttacher : BaseMonoBehaviour {
    private MeshRenderer _currentMeshRenderer;
    protected MeshRenderer MeshRenderer {
      get {
        if (_currentMeshRenderer == null) {
          _currentMeshRenderer = _previewSpawn.GetComponent<MeshRenderer>();
        }

        return _currentMeshRenderer;
      }
    }

    private MeshRenderer _groundMesh;

    public LayerMask PlaceLayer;
    public float MaxRayDistance = 5;

    private float _positionZ;

    private Transform _previewSpawn;

    private void Awake() {
      _positionZ = Transform.position.z;
      _previewSpawn = Transform.GetChild(0);

      _previewSpawn.SetParent(null);
    }

    private void Update() {
      var mousePosition = InputManager.Instance.GetMousePosition();
      var boundsX = MeshRenderer.bounds.size.x;
      var rightMesh = GetMeshBeneathPosition(mousePosition, GetOffset(boundsX), _positionZ, MaxRayDistance);
      var leftMesh = GetMeshBeneathPosition(mousePosition, GetOffset(boundsX, true), _positionZ, MaxRayDistance);
      if (rightMesh == null && leftMesh == null) return;

      if (leftMesh == null) _groundMesh = rightMesh;
      else if (rightMesh == null) _groundMesh = leftMesh;
      else _groundMesh = rightMesh.transform.position.y >= leftMesh.transform.position.y ? rightMesh : leftMesh;

      var placeY = _groundMesh.transform.position.y + _groundMesh.bounds.extents.y + MeshRenderer.bounds.extents.y;
      var position = Transform.position;
      var placeX = _groundMesh.bounds.extents.x <= MeshRenderer.bounds.extents.x ? _groundMesh.transform.position.x : position.x;
      _previewSpawn.position = new Vector3(placeX, placeY, position.z);
    }

    private Vector3 GetOffset(float boundsX, bool left = false) {
      return new Vector3((boundsX * (left ? -1 : 1)) / 2f, 0f, 0f);
    }

    private MeshRenderer GetMeshBeneathPosition(Vector3 mousePosition, Vector3 originOffset, float positionZ, float maxDistance) {
      var origin = MainCamera.ScreenToWorldPoint(mousePosition);
      origin.z = positionZ;
      var ray = GetDownRayFromOrigin(origin + originOffset, maxDistance);
      var mesh = GetMeshRenderer(ray, maxDistance);
      return mesh;
    }

    private MeshRenderer GetMeshRenderer(Ray ray, float maxDistance) {
      MeshRenderer renderer = null;
      if (Physics.Raycast(ray, out RaycastHit hit, maxDistance, PlaceLayer)) {
        renderer = hit.transform.GetComponent<MeshRenderer>();
      }

      return renderer;
    }

    private Ray GetDownRayFromOrigin(Vector3 origin, float rayLength) {
      return new Ray(origin, origin + Vector3.down * rayLength);
    }
  }
}
