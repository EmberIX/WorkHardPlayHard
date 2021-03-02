using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoBullet : MonoBehaviour
{
    public float damage;
    public float bulletTime = 0f;
    public float speed;

    public Transform target;
    private Vector2 targetDirection;

    public ParticleSystem damageP;
    public PlayerScript Ps;
    public PaperRotate PR;
    Rigidbody2D rb;
    void Start()
    {
        Ps = GameObject.FindObjectOfType<PlayerScript>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Ps.isDead)
        {
            DestroyProjectile();
        }

        if(target != null)
        {
            PR.enabled = false;
            targetDirection = (target.position - transform.position).normalized * speed;
            rb.velocity = new Vector2(targetDirection.x, targetDirection.y);
        }

        PR.speed = 4;

        //bulletTime += Time.deltaTime;

        //if (bulletTime >= 10)
        //{
        //    DestroyProjectile();
        //}


    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("smallBug"))
        {

            DestroyProjectile();
            other.gameObject.GetComponent<smallBug>().TakeDamage(damage + (Ps.ATK * 1 / 4));
            Instantiate(damageP, transform.position, Quaternion.identity);
        }

        if (other.CompareTag("BigSlime"))
        {

            DestroyProjectile();
            other.gameObject.GetComponent<BigSlimeScript>().TakeDamage(damage + (Ps.ATK * 1 / 4));
            Instantiate(damageP, transform.position, Quaternion.identity);
        }

        if (other.CompareTag("Boss"))
        {

            DestroyProjectile();
            other.gameObject.GetComponent<Boss>().TakeDamage(damage + (Ps.ATK * 1 / 4));
            Instantiate(damageP, transform.position, Quaternion.identity);
        }

        if (other.CompareTag("Bot_Boss"))
        {

            DestroyProjectile();
            other.gameObject.GetComponent<Boss_HP>().TakeDamage(damage + (Ps.ATK * 1 / 4));
            Instantiate(damageP, transform.position, Quaternion.identity);
        }

    }

    void DestroyProjectile()
    {
        Destroy(this.gameObject);
    }
}
