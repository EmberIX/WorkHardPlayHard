using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoBulletHold : MonoBehaviour
{
    public float speed;
    public Transform target;

    private Vector3 zAxis = new Vector3(0, 0, 1);
    public AutoBullet AB;

    public float stayTime = 0;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        AB = GameObject.FindObjectOfType<AutoBullet>();
    }
    
    void Update()
    {
        stayTime += Time.deltaTime;
        AB = GameObject.FindObjectOfType<AutoBullet>();
        if (stayTime >= 20)
        {
            Destroy(this.gameObject);
        }

        if(AB == null)
        {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        //if (target != null)
        //{
        //    transform.RotateAround(target.position, zAxis, speed);
        //}
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.TryGetComponent(out Enemy_HP enemy_HP) == true)
        {
            print("Aim at " + other.tag);
            AB.target = other.transform;
            
        }

    }
}
