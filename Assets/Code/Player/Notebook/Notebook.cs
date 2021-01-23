using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notebook : MonoBehaviour
{
    public PlayerMoveMent Pm;
    Vector2 target;
    public SpriteRenderer spriteRenderer;
    void Start()
    {
        Pm = GameObject.FindObjectOfType<PlayerMoveMent>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 objectScale = transform.localScale;
        if (Pm != null)
        {
            if(Pm.movement.x > 0)
            {
                objectScale.x = 1;
            }

            if (Pm.movement.x < 0)
            {
                objectScale.x = -1;
            }

            transform.localScale = objectScale;
        }
    }
}
