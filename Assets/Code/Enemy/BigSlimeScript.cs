using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;

public class BigSlimeScript : MonoBehaviour
{
    public float speed;
    public float ATKCount;
    public float StartATK;

    public float expDrop;

    public bool isRange;
    public bool closeRange;
    public bool isSight;
    public bool isAttacking;
    public float prepareAttack;
    public float readyAttack;
    Vector2 target;
    public Rigidbody2D rb;
    Enemy_HP E_H;
    public GameObject errorBullet;
    public GameObject errorBullet2;
    public GameObject errorBlast;
    public Animation attack;
    public Animator ani;

    public Transform player;
    public PlayerScript Ps;
    public FinishLevel FL;

    public AIPath AP;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        FL = GameObject.FindObjectOfType<FinishLevel>();
        Ps = GameObject.FindObjectOfType<PlayerScript>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        E_H = GetComponentInChildren<Enemy_HP>();
    }


    void Update()
    {
        if (E_H.HP <= 0)
        {
            Die();
            return;
        }

        if (Ps.isDead != true)
        {
            if (player != null)
            {
                target = new Vector2(player.position.x, player.position.y);

            }

            if (isSight && (isRange == false) && player != null && isAttacking == false)
            {
                AP.enabled = true;
            }
            else
            {
                AP.enabled = false;
            }

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
                if (closeRange == false)
                {
                    Attack();
                    isAttacking = false;
                    ATKCount = 0;
                }

                if (closeRange == true)
                {
                    Attack2();
                    isAttacking = false;
                    ATKCount = 0;
                }
            }
        }
    }



    public void Attack()
    {
        ani.SetTrigger("Attack1");
        StartCoroutine(Wait());

        IEnumerator Wait()
        {
            yield return new WaitForSeconds(0.55f);
            Instantiate(errorBullet, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.3f);
            Instantiate(errorBullet2, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.3f);
            Instantiate(errorBullet, transform.position, Quaternion.identity);
        }

        prepareAttack = 0;
    }

    public void Attack2()
    {
        ani.SetTrigger("Attack2");
        StartCoroutine(Wait());
        
        IEnumerator Wait()
        {
            yield return new WaitForSeconds(0.55f);
            Instantiate(errorBlast, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.3f);
            Instantiate(errorBlast, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.3f);
            Instantiate(errorBlast, transform.position, Quaternion.identity);
        }

        prepareAttack = 0;

    }

    public void Die()
    {

        SoundManagerScript.PlaySound(SoundManagerScript.enemyDie);
        Destroy(this.gameObject);
        if (Ps != null)
        {
            FL.exp += expDrop;
        }

    }
}
