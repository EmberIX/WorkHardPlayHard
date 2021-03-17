using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;

public class Slime_Boss : MonoBehaviour
{
    public float speed;
    public float ATKCount;
    public float StartATK;
    public float expDrop;

    public bool isRange;
    public bool closeRange;
    public bool isSight;
    public bool isAttacking;
    public float readyAttack;
    Vector2 target;
    public Rigidbody2D rb;
    public Enemy_HP E_H;
    public GameObject errorBullet;
    public GameObject errorBullet2;
    public GameObject errorBlast;
    public Animation attack;
    public Animator ani;

    public GameObject Slime;
    public GameObject Bug;
    public GameObject BigSlime;

    //public SpriteRenderer spriteRenderer;
    public Transform player;
    public PlayerScript Ps;
    public FinishLevel FL;
    public GameObject EndBed;

    public bool State1;
    public bool State2;
    public bool State3;

    public AIPath AP;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        FL = GameObject.FindObjectOfType<FinishLevel>();
        Ps = GameObject.FindObjectOfType<PlayerScript>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        E_H = GetComponentInChildren<Enemy_HP>();
    }

    // Update is called once per frame
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
                //this.spriteRenderer.flipX = player.transform.position.x > this.transform.position.x;
            }

            if (isSight && (isRange == false) && isAttacking == false)
            {
                AP.enabled = true;
            }
            else if (isAttacking)
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
            }
            
        }

        if (E_H.HP <= 300)
        {
            if (E_H.HP <= 250)
            {
                if (E_H.HP <= 100)
                {
                    if (!State3)
                    {
                        ATKCount = 0;
                        Attack2();
                        State3 = true;
                    }

                }
                else if (!State2)
                {
                    ATKCount = 0;
                    Attack2();
                    State2 = true;
                }

            }
            else if (!State1)
            {
                ATKCount = 0;
                Attack2();
                State1 = true;
            }
        }
    }

    public void Attack()
    {
        ani.SetTrigger("Attack1");
        AP.enabled = false;
        StartCoroutine(Wait());
        //StartCoroutine(Wait());
        //StartCoroutine(Wait());

        IEnumerator Wait()
        {
            SoundManagerScript.PlaySound(SoundManagerScript.bugSound);
            yield return new WaitForSeconds(0.55f);
            Instantiate(errorBullet, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.055f);
            Instantiate(errorBullet2, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.055f);
            Instantiate(errorBullet, transform.position, Quaternion.identity);
            ATKCount = 0;
            SoundManagerScript.PlaySound(SoundManagerScript.bugSound);
            yield return new WaitForSeconds(0.3f);
            Instantiate(errorBullet2, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.055f);
            Instantiate(errorBullet, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.055f);
            Instantiate(errorBullet, transform.position, Quaternion.identity);
            ATKCount = 0;
            SoundManagerScript.PlaySound(SoundManagerScript.bugSound);
            yield return new WaitForSeconds(0.3f);
            Instantiate(errorBullet, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.055f);
            Instantiate(errorBullet, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.055f);
            Instantiate(errorBullet2, transform.position, Quaternion.identity);
            ATKCount = 0;
            yield return new WaitForSeconds(3f);
            
            AP.enabled = true;
        }

    }

    public void Attack2()
    {
        ani.SetTrigger("Attack2");
        AP.enabled = false;
        StartCoroutine(Wait());

        IEnumerator Wait()
        {
            yield return new WaitForSeconds(0.55f);
            Instantiate(errorBlast, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.055f);
            Instantiate(Slime, transform.position, Quaternion.identity);

            ATKCount = 0;

            yield return new WaitForSeconds(0.3f);
            Instantiate(errorBlast, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.055f);
            Instantiate(Bug, transform.position, Quaternion.identity);

            ATKCount = 0;

            yield return new WaitForSeconds(0.3f);
            Instantiate(errorBlast, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.055f);
            Instantiate(BigSlime, transform.position, Quaternion.identity);
            ATKCount = 0;
            yield return new WaitForSeconds(5f);
            ATKCount = 0;
            AP.enabled = true;
        }


    }

    public void Die()
    {
        Destroy(GameObject.FindGameObjectWithTag("BigSlime"));
        Destroy(GameObject.FindGameObjectWithTag("smallBug"));
        Destroy(GameObject.FindObjectOfType<Trap>());
        Destroy(GameObject.FindObjectOfType<EnemyBullet>());
        Destroy(E_H.HPB);
        Destroy(this.gameObject);

        Instantiate(EndBed, transform.position, Quaternion.identity);

        SoundManagerScript.PlaySound(SoundManagerScript.enemyDie);
    }

}
