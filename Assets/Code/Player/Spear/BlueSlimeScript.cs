using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;

public class BlueSlimeScript : MonoBehaviour
{
    public float HP;
    public float MaxHP;
    public float speed;
    public float ATKCount;
    public float StartATK;
    public int Damage;
    public Image HPBar;
    public bool isFollowPlayer = true;

    public bool isRange;
    public bool isSight;
    public bool isAttacking;
    public float prepareAttack;
    public float readyAttack;
    Vector2 target;
    public GameObject FixingBullet;
    public Rigidbody2D rb;
    public Animator ani;

    public Transform player;
    public PlayerScript Ps;

    public Transform Target;

    public ParticleSystem damageP;

    public AIDestinationSetter AP;
    public GameObject Summon;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Ps = GameObject.FindObjectOfType<PlayerScript>();
        HP = MaxHP;
        SetHPBar();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        HP -= Time.deltaTime;
        SetHPBar();
        if (player != null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        if (player != null && isFollowPlayer)
        {

            target = new Vector2(player.position.x, player.position.y);
           
        }

        if (isSight == false && (isRange == false) && player != null && isAttacking == false)
        {
            isFollowPlayer = true;
            AP.enabled = true;
            AP.target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        if (isSight && (isRange == false) && isAttacking == false)
        {
            AP.target = Target;
            isFollowPlayer = false;
        }
        
        if (isSight && isRange)
        {
            isFollowPlayer = false;
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
            Attack();
            isAttacking = false;
            ATKCount = 0;
            
        }
    }

    public void Attack()
    {

        
        StartCoroutine(Wait());

        IEnumerator Wait()
        {
            ani.SetTrigger("Attack");

            yield return new WaitForSeconds(0.55f);
            SoundManagerScript.PlaySound(SoundManagerScript.CounterBullet);
            GameObject bullet1 = Instantiate(FixingBullet, transform.position, Quaternion.identity);
            bullet1.GetComponent<FixingBullet>().target = this.Target;
            yield return new WaitForSeconds(0.3f);
            SoundManagerScript.PlaySound(SoundManagerScript.CounterBullet);
            GameObject bullet2 = Instantiate(FixingBullet, transform.position, Quaternion.identity);
            bullet2.GetComponent<FixingBullet>().target = this.Target;
            yield return new WaitForSeconds(0.3f);
            SoundManagerScript.PlaySound(SoundManagerScript.CounterBullet);
            GameObject bullet3 = Instantiate(FixingBullet, transform.position, Quaternion.identity);
            bullet3.GetComponent<FixingBullet>().target = this.Target;
        }

        prepareAttack = 0;
    }

    public void TakeDamage(float amount)
    {
        HP -= amount;
        SetHPBar();

        if (HP <= 0)
        {

            Destroy(this.gameObject);
            Instantiate(Summon, transform.position, Quaternion.identity);
        }
    }

    public void SetHPBar()
    {
        HPBar.fillAmount = HP / MaxHP;

        if (HP <= 0)
        {

            Destroy(this.gameObject);
            Instantiate(Summon, transform.position, Quaternion.identity);
        }
    }
}
