using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBullet_Work : MonoBehaviour
{
    public float damage;
    public float bulletTime = 0f;
    public bool isSp;
    public GameObject damageP;
    public GameObject Burst;
    public PlayerScript Ps;
    private bool hasHit;
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
        if (other.TryGetComponent(out Enemy_HP enemy_HP) == true)
        {
            if(hasHit)
            {
                return;
            }

            if (isSp == false)
            {
                DestroyProjectile();
                other.gameObject.GetComponent<Enemy_HP>().TakeDamage(damage + (Ps.ATK * 1 / 3.5f));
                GameObject Par = Instantiate(damageP, transform.position, Quaternion.identity);
                Par.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas_Work").transform);
            }

            else if (isSp)
            {
                DestroyProjectile();
                other.gameObject.GetComponent<Enemy_HP>().TakeDamage(damage + (Ps.ATK * 1 / 2));
                Instantiate(Burst, transform.position, Quaternion.identity);
            }
            hasHit = true;
        }

    }

    void DestroyProjectile()
    {
        Destroy(this.gameObject);
    }
}
