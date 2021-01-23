using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixingBullet : MonoBehaviour
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

        SS = GameObject.FindObjectOfType<SpearScript>();
        Ps = GameObject.FindObjectOfType<PlayerScript>();

        rb = GetComponent<Rigidbody2D>();

        if (target != null)
        {
            targetDirection = (target.position - transform.position).normalized * speed;
        }
        rb.velocity = new Vector2(targetDirection.x, targetDirection.y);
    }

    // Update is called once per frame
    void Update()
    {
        bulletTime += Time.deltaTime;

        if (bulletTime >= 6)
        {
            DestroyProjectile();
        }

        if(target == null)
            DestroyProjectile();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {

            DestroyProjectile();
            //other.gameObject.GetComponent<Enemy>().TakeDamage(Damage);
            Instantiate(DamagePar, transform.position, Quaternion.identity);
            SS.Durability += (Damage + (Ps.ATK * 1/4));
            SS.SetSpearBar();
        }

        if (other.CompareTag("smallBug"))
        {

            DestroyProjectile();
            other.gameObject.GetComponent<smallBug>().TakeDamage(Damage + (Ps.ATK * 1 / 4));
            Instantiate(DamagePar, transform.position, Quaternion.identity);
            SS.Durability += (Damage + (Ps.ATK * 1 / 4));
            SS.SetSpearBar();
        }

        if (other.CompareTag("BigSlime"))
        {

            DestroyProjectile();
            other.gameObject.GetComponent<BigSlimeScript>().TakeDamage(Damage + (Ps.ATK * 1 / 4));
            Instantiate(DamagePar, transform.position, Quaternion.identity);
            SS.Durability += (Damage + (Ps.ATK * 1 / 4));
            SS.SetSpearBar();
        }

        if (other.CompareTag("Boss"))
        {

            DestroyProjectile();
            other.gameObject.GetComponent<Boss>().TakeDamage(Damage + (Ps.ATK * 1 / 4));
            Instantiate(DamagePar, transform.position, Quaternion.identity);
            SS.Durability += (Damage + (Ps.ATK * 1 / 4));
            SS.SetSpearBar();
        }
    }

    void DestroyProjectile()
    {
        Destroy(this.gameObject);
    }

}
