using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Spawn;

    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var mousePosition = Input.mousePosition;
            var worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
            GameObject.Instantiate(Spawn, new Vector3(worldPosition.x, worldPosition.y, Spawn.transform.position.z), Quaternion.identity);
        }
    }
}
