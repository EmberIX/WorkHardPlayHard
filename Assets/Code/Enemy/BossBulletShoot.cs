using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletShoot : MonoBehaviour
{
    public float ATKCount;
    public float StartATK;
    public int Damage;
    public float speed;
    public float BulletOut = 4;

    public bool isAttacking;
    public float prepareAttack;
    public float readyAttack;
    public Vector3 Direaction;

    public bool Up = true;
    public bool Down;
    public bool Left;
    public bool Right;

    public Vector3 rotate;
    public bool rotating;
    public float rotateSpeed;
    Vector2 target;

    public int bulletUse;
    // 1 = Direction 2 = ToPlayer 3 = Shoot4Sides
    public GameObject errorBulletDirection;
    public GameObject errorBulletToPlayer;
    
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
                if (bulletUse == 0)
                {
                    AttackDirection();
                }
                if (bulletUse == 1)
                {
                    AttackPlayer();
                }
                if (bulletUse == 2)
                {
                    Attack4Side();
                }
                if(rotating)
                {
                    this.transform.Rotate(rotate * rotateSpeed * Time.deltaTime);
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

    public void AttackDirection()
    {
        GameObject Bullet = Instantiate(errorBulletDirection, shooter.position, Quaternion.identity);
        Bullet.GetComponent<TrapBullet>().targetDirection = Direaction;
        Bullet.GetComponent<TrapBullet>().Damage = Damage;
        Bullet.GetComponent<TrapBullet>().bulletOut = BulletOut;
        Bullet.GetComponent<TrapBullet>().speed = speed;
    }

    public void AttackPlayer()
    {
        GameObject Bullet = Instantiate(errorBulletToPlayer, shooter.position, Quaternion.identity);
        Bullet.GetComponent<EnemyBullet>().Damage = Damage;
        Bullet.GetComponent<EnemyBullet>().bulletOut = BulletOut;
        Bullet.GetComponent<EnemyBullet>().speed = speed;
    }

    public void Attack4Side()
    {
        GameObject Bullet = Instantiate(errorBulletDirection, shooter.position, Quaternion.identity);
        Bullet.GetComponent<TrapBullet>().targetDirection = (transform.up).normalized * 8;        
        Bullet.GetComponent<TrapBullet>().Damage = Damage;
        Bullet.GetComponent<TrapBullet>().bulletOut = BulletOut;

        GameObject Bullet2 = Instantiate(errorBulletDirection, shooter.position, Quaternion.identity);
        Bullet2.GetComponent<TrapBullet>().targetDirection = (-transform.up).normalized * 8;
        Bullet2.GetComponent<TrapBullet>().Damage = Damage;
        Bullet2.GetComponent<TrapBullet>().bulletOut = BulletOut;

        GameObject Bullet3 = Instantiate(errorBulletDirection, shooter.position, Quaternion.identity);
        Bullet3.GetComponent<TrapBullet>().targetDirection = (-transform.right).normalized * 8;
        Bullet3.GetComponent<TrapBullet>().Damage = Damage;
        Bullet3.GetComponent<TrapBullet>().bulletOut = BulletOut;        
        
        GameObject Bullet4 = Instantiate(errorBulletDirection, shooter.position, Quaternion.identity);
        Bullet4.GetComponent<TrapBullet>().targetDirection = (transform.right).normalized * 8;
        Bullet4.GetComponent<TrapBullet>().Damage = Damage;
        Bullet4.GetComponent<TrapBullet>().bulletOut = BulletOut;
    }
}
