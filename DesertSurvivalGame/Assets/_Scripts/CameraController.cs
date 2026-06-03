using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;
    private Camera cam;

    private float zoom;
    [SerializeField] private float zoomMultiplier = 4;
    [SerializeField] private float zoomMin;
    [SerializeField] private float zoomMax;
    [SerializeField] private float smoothTime;

    private float zoomVelocity;

    private void Start()
    {
        cam = GetComponent<Camera>();
        zoom = cam.orthographicSize;
    }

    private void Update()
    {
        Follow();
        Zoom();
    }

    private void Follow()
    {
        transform.position = player.position + offset;
    }

    private void Zoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        zoom -= scroll * zoomMultiplier;
        zoom = Mathf.Clamp(zoom, zoomMin, zoomMax);
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref zoomVelocity, smoothTime);
    }
}
