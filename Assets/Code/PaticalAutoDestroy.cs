using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaticalAutoDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem ps;

    void Start()
    {

    }

    void Update()
    {
        if (ps)
        {
            if (!ps.IsAlive())
            {
                Destroy(gameObject);
            }
        }
    }
}
