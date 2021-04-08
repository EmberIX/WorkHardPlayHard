using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkBullet_Work : MonoBehaviour
{
    public float speed;

    private Transform player;
    public Vector2 targetDirection;

    public float Damage;

    public float bulletTime = 0f;
    public float bulletOut;

    public ParticleSystem DamagePar;
    Rigidbody2D rb;
    PlayerMini PM;
    bool hashit;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SoundManagerScript.PlaySound(SoundManagerScript.EnemyBullet);
        player = GameObject.FindGameObjectWithTag("Player_Mini").transform;

        if (player != null)
        {
            PM = GameObject.FindObjectOfType<PlayerMini>();
        }

        targetDirection = (-transform.up).normalized * 8;

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
        if (other.CompareTag("Player_Mini"))
        {

            if (hashit)
            {
                return;
            }

            if (this.CompareTag("EnemyBullet"))
            {
                DestroyProjectile();
            }
            other.gameObject.GetComponent<PlayerMini_HP>().TakeDamage(Damage);
            Instantiate(DamagePar, transform.position, Quaternion.identity);

            hashit = true;
        }

    }

    void DestroyProjectile()
    {
        Destroy(this.gameObject);
    }
}
