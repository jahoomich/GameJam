using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseParallax : MonoBehaviour
{
    [SerializeField] private GameObject[] ParallaxObjects;
    [SerializeField] private float MouseSpeedX = 1f, MouseSpeedY = 0.2f;
    private Vector3[] OriginalPositions;
    void Start()
    {
        /*Cursor.lockState = CursorLockMode.Confined;*/

        OriginalPositions = new Vector3[ParallaxObjects.Length];
        for (int i = 0; i < ParallaxObjects.Length; i++)
        {
            OriginalPositions[i] = ParallaxObjects[i].transform.position;
        }
    }


    void FixedUpdate()
    {
        float x, y;
        x = (Input.mousePosition.x - (Screen.width / 2)) * MouseSpeedX / Screen.width;
        y = (Input.mousePosition.y - (Screen.height / 2)) * MouseSpeedY / Screen.height;

        for (int i = 1; i < ParallaxObjects.Length + 1; i++)
        {
            ParallaxObjects[i - 1].transform.position = OriginalPositions[i - 1] + (new Vector3(x, y, 0f) * i * ((i - 1) - (ParallaxObjects.Length / 2)));
        }
    }
}


