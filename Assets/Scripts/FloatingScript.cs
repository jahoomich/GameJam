using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingScript : MonoBehaviour
{
    public float speed = 2f;
    public float height = 5f;
    Vector3 default_pos;

    void Start()
    {
        default_pos = transform.position;
    }

    void Update()
    {
        Vector3 pos = transform.position;
        float new_pos = Mathf.Sin(Time.time * speed);
        transform.position = new Vector3(pos.x, (new_pos * height)+default_pos.y, pos.z);
    }
}

