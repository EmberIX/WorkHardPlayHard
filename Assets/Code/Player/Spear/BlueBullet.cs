using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBullet : MonoBehaviour
{
    public float speed;
    public float Damage = 1;

    public Transform target;
    private Vector2 targetDirection;

    public float bulletTime = 0f;
    public SpearScript SS;

    public ParticleSystem DamagePar;
    public PlayerScript Ps;
    Rigidbody2D rb;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
