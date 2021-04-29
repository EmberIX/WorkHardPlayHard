using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkShooter : MonoBehaviour
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

    public Enemy_HP EH;
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

        if(EH.HP <= 0)
        {
            GameObject toDestroy = GameObject.FindGameObjectWithTag("PurpleBullet");
            if (toDestroy != null)
            {
                Destroy(toDestroy);
            }
            else
            {
                Destroy(this.gameObject);
                return;
            }
        }

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
                if (rotating)
                {
                    this.transform.Rotate(rotate * rotateSpeed * Time.deltaTime);
                }

                isAttacking = false;
                ATKCount = 0;
            }
        }
    }

    public void AttackDirection()
    {
        GameObject Bullet = Instantiate(errorBulletDirection, shooter.position, Quaternion.identity);
        Bullet.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas_Work").transform);
        Bullet.GetComponent<TrapBullet>().targetDirection = Direaction;
        Bullet.GetComponent<TrapBullet>().Damage = Damage;
        Bullet.GetComponent<TrapBullet>().bulletOut = BulletOut;
        Bullet.GetComponent<TrapBullet>().speed = speed;

    }

    public void AttackPlayer()
    {
        GameObject Bullet = Instantiate(errorBulletToPlayer, shooter.position, Quaternion.identity);
        Bullet.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas_Work").transform);
        Bullet.GetComponent<purpleBullettoPlayer_Work>().Damage = Damage;
        Bullet.GetComponent<purpleBullettoPlayer_Work>().bulletOut = BulletOut;
        Bullet.GetComponent<purpleBullettoPlayer_Work>().speed = speed;
    }

    public void Attack4Side()
    {
        GameObject Bullet = Instantiate(errorBulletDirection, shooter.position, Quaternion.identity);
        Bullet.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas_Work").transform);
        Bullet.GetComponent<TrapBullet>().targetDirection = (transform.up).normalized * 8;
        Bullet.GetComponent<TrapBullet>().Damage = Damage;
        Bullet.GetComponent<TrapBullet>().bulletOut = BulletOut;

        GameObject Bullet2 = Instantiate(errorBulletDirection, shooter.position, Quaternion.identity);
        Bullet2.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas_Work").transform);
        Bullet2.GetComponent<TrapBullet>().targetDirection = (-transform.up).normalized * 8;
        Bullet2.GetComponent<TrapBullet>().Damage = Damage;
        Bullet2.GetComponent<TrapBullet>().bulletOut = BulletOut;

        GameObject Bullet3 = Instantiate(errorBulletDirection, shooter.position, Quaternion.identity);
        Bullet3.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas_Work").transform);
        Bullet3.GetComponent<TrapBullet>().targetDirection = (-transform.right).normalized * 8;
        Bullet3.GetComponent<TrapBullet>().Damage = Damage;
        Bullet3.GetComponent<TrapBullet>().bulletOut = BulletOut;

        GameObject Bullet4 = Instantiate(errorBulletDirection, shooter.position, Quaternion.identity);
        Bullet4.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas_Work").transform);
        Bullet4.GetComponent<TrapBullet>().targetDirection = (transform.right).normalized * 8;
        Bullet4.GetComponent<TrapBullet>().Damage = Damage;
        Bullet4.GetComponent<TrapBullet>().bulletOut = BulletOut;
    }


}
