using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot_Boss : MonoBehaviour
{
    public Transform player;
    public PlayerScript Ps;

    Vector2 target;
    void Start()
    {
        Ps = GameObject.FindObjectOfType<PlayerScript>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Ps.isDead != true)
        {
            if (player != null)
            {
                target = new Vector2(player.position.x, player.position.y);
            }
        }
    }
}
