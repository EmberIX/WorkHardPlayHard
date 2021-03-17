using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class smallBug : MonoBehaviour
{
    //If player in sight, move till the player in range.
    //If the player in range, start attacking player.
    
    public float speed;
    public float ATKCount;
    public float StartATK;
    public float expDrop;

    public bool isRange;
    public bool isSight;
    public bool isAttacking;
    public float prepareAttack;
    public float readyAttack;
    public bool TakeHit;
    Vector2 target;
    public Rigidbody2D rb;
    Enemy_HP E_H;
    public GameObject errorBullet;
    public Animation attack;
    public Animator ani;

    public SpriteRenderer spriteRenderer;
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

    // Update is called once per frame
    void Update()
    {
        if(E_H.HP <= 0)
        {
            Die();
            return;
        }

        if (player != null)
        {
            target = new Vector2(player.position.x, player.position.y);
            this.spriteRenderer.flipX = player.transform.position.x > this.transform.position.x;
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
            ani.SetTrigger("Attack");
            isAttacking = false;
            ATKCount = 0;
        }
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
