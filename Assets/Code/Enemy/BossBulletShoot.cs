using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletShoot : MonoBehaviour
{
    public float ATKCount;
    public float StartATK;
    public int Damage;
    public float speed;
    public float BulletOut = 5;

    public bool isAttacking;
    public float prepareAttack;
    public float readyAttack;
    public Vector2 Direaction;

    public bool Up;
    public bool Down;
    public bool Left;
    public bool Right;

    public Vector3 rotate;
    public bool attack4Side;
    Vector2 target;
    public GameObject errorBullet;
    public GameObject errorBullet2;
    public PlayerScript Ps;

    public Transform shooter;
    public int shootingNum;
    public int shootingEnd;
    void Start()
    {
        Ps = GameObject.FindObjectOfType<PlayerScript>();
        this.transform.eulerAngles = rotate;

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


            if (ATKCount >= StartATK)
            {
                isAttacking = true;

            }

            if (isAttacking == true)
            {
                //ani.SetTrigger("Attack");
                if (errorBullet != null)
                {
                    if(attack4Side)
                    {
                        Attack4Side();
                    }
                    else
                    Attack();
                }
                if (errorBullet2 != null)
                {
                    Attack2();
                }

                shootingNum++;
                isAttacking = false;
                ATKCount = 0;
            }
        }

        if (shootingNum == shootingEnd)
        {
            Destroy(this.gameObject);
        }
    }

    public void Attack()
    {
        GameObject Bullet = Instantiate(errorBullet, shooter.position, Quaternion.identity);
        Bullet.GetComponent<TrapBullet>().targetDirection = Direaction;
        Bullet.GetComponent<TrapBullet>().Damage = Damage;
        Bullet.GetComponent<TrapBullet>().bulletOut = BulletOut;
    }

    public void Attack2()
    {
        GameObject Bullet = Instantiate(errorBullet2, shooter.position, Quaternion.identity);
        Bullet.GetComponent<EnemyBullet>().Damage = Damage;
        Bullet.GetComponent<EnemyBullet>().bulletOut = BulletOut;
        Bullet.GetComponent<EnemyBullet>().speed = speed;
    }

    public void Attack4Side()
    {
        GameObject Bullet = Instantiate(errorBullet, shooter.position, Quaternion.identity);
        Bullet.GetComponent<TrapBullet>().targetDirection = (transform.up).normalized * 8;        
        Bullet.GetComponent<TrapBullet>().Damage = Damage;
        Bullet.GetComponent<TrapBullet>().bulletOut = BulletOut;

        GameObject Bullet2 = Instantiate(errorBullet, shooter.position, Quaternion.identity);
        Bullet2.GetComponent<TrapBullet>().targetDirection = (-transform.up).normalized * 8;
        Bullet2.GetComponent<TrapBullet>().Damage = Damage;
        Bullet2.GetComponent<TrapBullet>().bulletOut = BulletOut;

        GameObject Bullet3 = Instantiate(errorBullet, shooter.position, Quaternion.identity);
        Bullet3.GetComponent<TrapBullet>().targetDirection = (-transform.right).normalized * 8;
        Bullet3.GetComponent<TrapBullet>().Damage = Damage;
        Bullet3.GetComponent<TrapBullet>().bulletOut = BulletOut;        
        
        GameObject Bullet4 = Instantiate(errorBullet, shooter.position, Quaternion.identity);
        Bullet4.GetComponent<TrapBullet>().targetDirection = (transform.right).normalized * 8;
        Bullet4.GetComponent<TrapBullet>().Damage = Damage;
        Bullet4.GetComponent<TrapBullet>().bulletOut = BulletOut;


    }
}
