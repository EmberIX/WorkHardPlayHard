using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBullet : MonoBehaviour
{
    public float speed;

    private Transform player;
    public Vector2 targetDirection;

    public float Damage;

    public float bulletTime = 0f;
    public float bulletOut;

    public ParticleSystem DamagePar;
    Rigidbody2D rb;
    PlayerMoveMent PM;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SoundManagerScript.PlaySound(SoundManagerScript.EnemyBullet);
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (player != null)
        {
            PM = GameObject.FindObjectOfType<PlayerMoveMent>();
        }
        //targetDirection = (-transform.up).normalized * speed;
        rb.velocity = new Vector2(targetDirection.x, targetDirection.y);

    }

    void Update()
    {
        bulletTime += Time.deltaTime;


        if (bulletTime >= bulletOut)
        {
            DestroyProjectile();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (PM.isDash == false)
            {
                if (this.CompareTag("EnemyBullet"))
                {
                    DestroyProjectile();
                }
                other.gameObject.GetComponent<PlayerScript>().TakeDamage(Damage);
                Instantiate(DamagePar, transform.position, Quaternion.identity);
            }
        }

        if (other.CompareTag("friendlyBug"))
        {
            if (this.CompareTag("EnemyBullet"))
            {
                DestroyProjectile();
            }
            Instantiate(DamagePar, transform.position, Quaternion.identity);
        }

        //if (other.tag == "Sword")
        //{
        //    DestroyProjectile(); ;
        //}
        //if (other.tag == "Sword2")
        //{
        //    DestroyProjectile();
        //}
        //if (other.tag == "Sword3")
        //{
        //    DestroyProjectile();
        //}
    }

    void DestroyProjectile()
    {
        Destroy(this.gameObject);
    }
}
