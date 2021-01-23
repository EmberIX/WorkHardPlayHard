using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBullet : MonoBehaviour
{
    public float damage;
    public float bulletTime = 0f;
    public bool isSp;
    public ParticleSystem damageP;
    public ParticleSystem Burst;
    public PlayerScript Ps;
    void Start()
    {
        Ps = GameObject.FindObjectOfType<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        bulletTime += Time.deltaTime;

        if (bulletTime >= 6)
        {
            DestroyProjectile();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("smallBug") && isSp == false)
        {

            DestroyProjectile();
            other.gameObject.GetComponent<smallBug>().TakeDamage(damage + (Ps.ATK * 1 / 3.5f));  
            Instantiate(damageP, transform.position, Quaternion.identity);

        }

        if (other.CompareTag("BigSlime") && isSp == false)
        {

            DestroyProjectile();
            other.gameObject.GetComponent<BigSlimeScript>().TakeDamage(damage + (Ps.ATK * 1 / 3.5f));
            Instantiate(damageP, transform.position, Quaternion.identity);

        }

        if (other.CompareTag("Boss") && isSp == false)
        {

            DestroyProjectile();
            other.gameObject.GetComponent<Boss>().TakeDamage(damage + (Ps.ATK * 1 / 3.5f));
            Instantiate(damageP, transform.position, Quaternion.identity);

        }


        if (other.CompareTag("smallBug") && isSp)
        {

            DestroyProjectile();
            other.gameObject.GetComponent<smallBug>().TakeDamage(damage + (Ps.ATK * 1 / 2));
            Instantiate(Burst, transform.position, Quaternion.identity);

        }

        if (other.CompareTag("BigSlime") && isSp)
        {

            DestroyProjectile();
            other.gameObject.GetComponent<BigSlimeScript>().TakeDamage(damage + (Ps.ATK * 1 / 2));
            Instantiate(Burst, transform.position, Quaternion.identity);

        }

        if (other.CompareTag("Boss") && isSp)
        {

            DestroyProjectile();
            other.gameObject.GetComponent<Boss>().TakeDamage(damage + (Ps.ATK * 1 / 2));
            Instantiate(Burst, transform.position, Quaternion.identity);

        }
    }

    void DestroyProjectile()
    {
        Destroy(this.gameObject);
    }
}
