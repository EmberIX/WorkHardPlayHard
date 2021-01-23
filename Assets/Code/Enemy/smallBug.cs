using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class smallBug : MonoBehaviour
{
    //If player in sight, move till the player in range.
    //If the player in range, start attacking player.
    public float HP;
    public float MaxHP;
    public float speed;
    public float ATKCount;
    public float StartATK;
    public int Damage;
    public Image HPBar;
    public float expDrop;

    public bool isRange;
    public bool isSight;
    public bool isAttacking;
    public float prepareAttack;
    public float readyAttack;
    public bool TakeHit;
    Vector2 target;
    public Rigidbody2D rb;

    public GameObject errorBullet;
    public Animation attack;
    public Animator ani;

    public SpriteRenderer spriteRenderer;
    public Transform player;
    public PlayerScript Ps;

    public ParticleSystem damageP;
    public FinishLevel FL;

    public AIPath AP;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        FL = GameObject.FindObjectOfType<FinishLevel>();
        Ps = GameObject.FindObjectOfType<PlayerScript>();
        HP = MaxHP;
        SetHPBar();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //this.spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            target = new Vector2(player.position.x, player.position.y);
            this.spriteRenderer.flipX = player.transform.position.x > this.transform.position.x;
        }

        if (isSight && (isRange == false) && player != null && isAttacking == false)
        { 
            //transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
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
                //prepareAttack += Time.deltaTime;

                //if (prepareAttack >= readyAttack)
                //{
                //    Attack();
                //    ATKCount = 0;
                //}
            }            
            
 
        }



        if (isAttacking == true)
        {
            ani.SetTrigger("Attack");
            isAttacking = false;
            ATKCount = 0;
        }
    }
    public void SetHPBar()
    {
        HPBar.fillAmount = HP / MaxHP;
    }
    public void Attack()
    {
        if (Ps.isDead != true)
        {
            SoundManagerScript.PlaySound(SoundManagerScript.bugSound);
            GameObject bullet = Instantiate(errorBullet, transform.position, Quaternion.identity);
            prepareAttack = 0;
        }
    }

    public void TakeDamage(float amount)
    {
        //ani.SetTrigger("Damage");
        //Instantiate(damageP, transform.position, Quaternion.identity);
        HP -= amount;
        SetHPBar();
        SoundManagerScript.PlaySound(SoundManagerScript.enemyTakeDamage);
        //ani.SetTrigger("Damage");
        //SetHPBar();

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
