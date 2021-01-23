using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;

public class BigSlimeScript : MonoBehaviour
{
    public float HP;
    public float MaxHP;
    public float speed;
    public float ATKCount;
    public float StartATK;
    public int Damage;
    public Image HPBar;
    public float expDrop;

    public bool isRange;
    public bool closeRange;
    public bool isSight;
    public bool isAttacking;
    public float prepareAttack;
    public float readyAttack;
    public bool TakeHit;
    Vector2 target;
    public Rigidbody2D rb;

    public GameObject errorBullet;
    public GameObject errorBullet2;
    public GameObject errorBlast;
    public Animation attack;
    public Animator ani;

    //public SpriteRenderer spriteRenderer;
    public Transform player;
    public PlayerScript Ps;
    public FinishLevel FL;
    public ParticleSystem damageP;

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
    public void SetHPBar()
    {
        HPBar.fillAmount = HP / MaxHP;
    }


    public void Attack()
    {
        ani.SetTrigger("Attack1");
        StartCoroutine(Wait());
        //StartCoroutine(Wait());
        //StartCoroutine(Wait());

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

    public void TakeDamage(float amount)
    {
        //ani.SetTrigger("Damage");
        //Instantiate(damageP, transform.position, Quaternion.identity);
        HP -= amount;
        SetHPBar();
        //ani.SetTrigger("Damage");
        //SetHPBar();
        SoundManagerScript.PlaySound(SoundManagerScript.enemyTakeDamage);
        if (HP <= 0)
        {
            SoundManagerScript.PlaySound(SoundManagerScript.enemyDie);
            Destroy(this.gameObject);
            if (Ps != null)
            {
                FL.exp += expDrop;
            }
        }
    }

}
