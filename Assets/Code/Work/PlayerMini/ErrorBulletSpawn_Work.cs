using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorBulletSpawn_Work : MonoBehaviour
{
    public Vector3 whereToSpawn;
    public  GameObject bullet;

    public float randomX;
    public float spawnRate = 2f;
    public float nextSpawn;

    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
       
        if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randomX = Random.Range(0f, 6f);
            whereToSpawn = new Vector3(randomX, transform.position.y, transform.position.z);
            
            GameObject SpawnedBullet = Instantiate(bullet, whereToSpawn, Quaternion.identity);
            SpawnedBullet.GetComponent<Rigidbody2D>().velocity = this.transform.up * 12f;
            SpawnedBullet.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas_Work").transform);
        }

    }
}
