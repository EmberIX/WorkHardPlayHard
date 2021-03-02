using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot_Boss : MonoBehaviour
{
    public Transform player;
    public PlayerScript Ps;
    Boss_HP B_H;

    Vector2 target;
    Animator ani;
    public Transform shooterA;
    public Transform shooterB;
    public GameObject shooter;
    void Start()
    {
        Ps = GameObject.FindObjectOfType<PlayerScript>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        B_H = GameObject.FindObjectOfType<Boss_HP>();
        ani = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Ps.isDead != true)
        {
            if (player != null)
            {
                target = new Vector2(player.position.x, player.position.y);
            }
        }
    }

    public IEnumerator WaittoAttack(int i)
    {
        yield return new WaitForSeconds(i);
        Debug.Log("AttackState");
        //animator.SetBool("Attack1", true);
    }

    public void prepareAttack(int i)
    {
        StartCoroutine(WaittoAttack(i));
        ani.SetBool("Attack1", true);
    }
    public void Stage2()
    {

    }

    public void Attack1()
    {
        GameObject attack1 = Instantiate(shooter, shooterA.position, Quaternion.identity);
        attack1 = Instantiate(shooter, shooterB.position, Quaternion.identity);

        attack1.GetComponent<BossBulletShoot>().bulletUse = 1;
        //attack1.GetComponent<BossBulletShoot>().Damage = 4;
        attack1.GetComponent<BossBulletShoot>().BulletOut = 4;
        attack1.GetComponent<BossBulletShoot>().StartATK = 0.3f;
        attack1.GetComponent<BossBulletShoot>().shootingEnd = 3;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ani.SetBool("Activate", true);
        }
    }
}
