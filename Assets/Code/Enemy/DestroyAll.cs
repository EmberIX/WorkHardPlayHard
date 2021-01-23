using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(GameObject.FindGameObjectWithTag("BigSlime"));
        Destroy(GameObject.FindGameObjectWithTag("smallBug"));
        Destroy(GameObject.FindObjectOfType<Trap>());
        Destroy(GameObject.FindObjectOfType<EnemyBullet>());
    }
}
