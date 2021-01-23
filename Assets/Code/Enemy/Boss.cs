using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;

public class Boss : MonoBehaviour
{
    public float HP;
    public float MaxHP;
    public float speed;
    public float ATKCount;
    public float StartATK;
    public int Damage;
    public GameObject HPB;
    public Image HPBar;
    public float expDrop;

    public bool isRange;
    public bool closeRange;
    public bool isSight;
    public bool isAttacking;
    public float readyAttack;
    public bool TakeHit;
    Vector2 target;
    public Rigidbody2D rb;

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
    public ParticleSystem damageP;
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
        HP = MaxHP;
        SetHPBar();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
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

                //if (closeRange == true)
                //{
                //    Attack2();
                //    isAttacking = false;
                //    ATKCount = 0;
                //}
            }

            
        }
    }
    public void SetHPBar()
    {
        HPBar.fillAmount = HP / MaxHP;
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

    public void TakeDamage(float amount)
    {
        //ani.SetTrigger("Damage");
        //Instantiate(damageP, transform.position, Quaternion.identity);
        HP -= amount;
        SoundManagerScript.PlaySound(SoundManagerScript.enemyTakeDamage);
        SetHPBar();
        //ani.SetTrigger("Damage");
        //SetHPBar();
        if(HP <= 300)
        {
            if(HP<= 200)
            {
                if(HP <= 100)
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
            else if(!State1)
            {
                ATKCount = 0;
                Attack2();
                State1 = true;
            }
        }

        if (HP <= 0)
        {
            Destroy(GameObject.FindGameObjectWithTag("BigSlime"));
            Destroy(GameObject.FindGameObjectWithTag("smallBug"));
            Destroy(GameObject.FindObjectOfType<Trap>());
            Destroy(GameObject.FindObjectOfType<EnemyBullet>());
            Destroy(HPB);
            Destroy(this.gameObject);
            Instantiate(EndBed, transform.position, Quaternion.identity);

            SoundManagerScript.PlaySound(SoundManagerScript.enemyDie);
            if (Ps != null)
            {
                Ps.HP = Ps.MaxHP;
                FL.exp += expDrop;
            }
        }
    }

}
