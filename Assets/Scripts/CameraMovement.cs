

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{
    public float cameraSpeed = 5f;
    public float zoomFactor = 2f;
    public float defaultCameraSize = 0f;

    private Camera currentCamera;

    public Entity wizardCharacter;
    void Start()
    {
        currentCamera = GetComponent<Camera>();
        defaultCameraSize = currentCamera.orthographicSize;
    }

    
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            ZoomOnCharacter(wizardCharacter);
        }
        
    }

    void ZoomOnCharacter(Entity character)
    {
        float targetSize = defaultCameraSize * zoomFactor;
        if (targetSize != currentCamera.orthographicSize)
        {
            
            currentCamera.orthographicSize = Mathf.Lerp(currentCamera.orthographicSize,
    targetSize, Time.deltaTime * cameraSpeed);
            currentCamera.transform.position = new Vector3(character.transform.position.x-0.4f, character.transform.position.y+0.6f, -10f);
        }
    }
}
