

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
    public Entity knightCharacter;
    public Entity archerCharacter;
    public Entity bossCharacter;

    public int currentCharacterZoomed = 0;



    void Start()
    {
        currentCamera = GetComponent<Camera>();
        defaultCameraSize = currentCamera.orthographicSize;
    }

    
    void Update()
    {
        if (currentCharacterZoomed == 0)
        {
            ZoomOnCharacter(wizardCharacter);
        }
        else if (currentCharacterZoomed == 1)
        {
            ZoomOnCharacter(archerCharacter);
        }
        else if (currentCharacterZoomed == 2)
        {
            ZoomOnCharacter(knightCharacter);
        }
        else if (currentCharacterZoomed == 3)
        {
            ZoomOnCharacter(bossCharacter);
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
