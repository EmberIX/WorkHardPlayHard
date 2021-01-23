using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperRotate : MonoBehaviour
{
    public float speed;
    public Transform target;

    private Vector3 zAxis = new Vector3(0, 0, 1);

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            transform.RotateAround(target.position, zAxis, speed);
        }
    }
}
