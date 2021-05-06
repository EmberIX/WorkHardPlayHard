using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurplebulletSprite : MonoBehaviour
{

    public SpriteRenderer Sprite;
    public Sprite I1;
    public Sprite I2;
    public Sprite I3;
    int random;

    void Start()
    {
        random = Random.Range(1, 4);
        if(random == 1)
        {
            Sprite.sprite = I1;
        }
        if (random == 2)
        {
            Sprite.sprite = I2;
        }
        if (random == 3)
        {
            Sprite.sprite = I3;
        }
    }


    void Update()
    {
        
    }
}
