using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Trap : MonoBehaviour
{
    public float ATKCount;
    public float StartATK;
    public int Damage;
    public float BulletOut = 1;

    public bool isRange;
    public bool isSight;
    public bool isAttacking;
    public float prepareAttack;
    public float readyAttack;
    public Vector2 Direaction;

    public bool Up;
    public bool Down;
    public bool Left;
    public bool Right;
    Vector2 target;
    public GameObject errorBullet;
    public ParticleSystem damageP;
    public PlayerScript Ps;
    void Start()
    {
        Ps = GameObject.FindObjectOfType<PlayerScript>();

        if (Up)
            Direaction = (transform.up).normalized * 8;

        if (Down)
            Direaction = (-transform.up).normalized * 8;

        if (Left)
            Direaction = (-transform.right).normalized * 8;

        if (Right)
            Direaction = (transform.right).normalized * 8;
    }

    // Update is called once per frame
    void Update()
    {
        if (Ps.isDead != true)
        {
            ATKCount += Time.deltaTime;

            if (isRange)
            {
                if (ATKCount >= StartATK)
                {
                    isAttacking = true;

                }


            }

            if (isAttacking == true)
            {
                //ani.SetTrigger("Attack");
                Attack();
                isAttacking = false;
                ATKCount = 0;
            }
        }
    }

    public void Attack()
    {
        GameObject Bullet = Instantiate(errorBullet, transform.position, Quaternion.identity);
        Bullet.GetComponent<TrapBullet>().targetDirection = Direaction;
        Bullet.GetComponent<TrapBullet>().Damage = Damage;
        Bullet.GetComponent<TrapBullet>().bulletOut = BulletOut;
    }
}
