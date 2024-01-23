

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{
    public float cameraSpeed = 5f;
    public float zoomFactor = 2f;
    public float defaultCameraSize = 0f;

    private Camera currentCamera;
    void Start()
    {
        currentCamera = GetComponent<Camera>();
        defaultCameraSize = currentCamera.orthographicSize;
    }

    
    void Update()
    {
        /*ZoomOnCharacter();*/
    }

    void ZoomOnCharacter(Entity character)
    {
        float targetSize = defaultCameraSize * zoomFactor;
        if (targetSize != currentCamera.orthographicSize)
        {
            currentCamera.orthographicSize = Mathf.Lerp(currentCamera.orthographicSize,
    targetSize, Time.deltaTime * cameraSpeed);
        }
    }
}
