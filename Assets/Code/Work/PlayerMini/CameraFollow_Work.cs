using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow_Work : MonoBehaviour
{

    public Transform Target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player_Mini").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Target != null)
        {
            transform.position = Target.position + offset;
        }
    }
}
