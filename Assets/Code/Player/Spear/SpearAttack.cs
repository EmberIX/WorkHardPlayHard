using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearAttack : MonoBehaviour
{
    public float damage;
    public float SpearTime = 0f;
    public bool isSp;
    public ParticleSystem damageP;
    public ParticleSystem Burst;
    public Transform SpearHead;

    public PlayerScript Ps;
    public SpearScript SS;
    void Start()
    {
        SS = GameObject.FindObjectOfType<SpearScript>();
        SoundManagerScript.PlaySound(SoundManagerScript.spear);
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.up = direction;

        Ps = GameObject.FindObjectOfType<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {

        SpearTime += Time.deltaTime;

        if (SpearTime >= 0.25)
        {
            DestroyProjectile();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy_HP enemy_HP) == true && isSp == false)
        {

            other.gameObject.GetComponent<Enemy_HP>().TakeDamage(damage + (Ps.ATK*1/2));
            Instantiate(damageP, SpearHead.position, Quaternion.identity);

        }

    }


    void DestroyProjectile()
    {
        Destroy(this.gameObject);
    }
}
