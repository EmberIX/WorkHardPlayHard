using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot_Boss : MonoBehaviour
{
    public Transform player;
    public PlayerScript Ps;
    public Enemy_HP B_H;

    Vector2 target;
    Animator ani;
    public Transform shooterA;
    public Transform shooterB;
    public GameObject shooter;
    public GameObject shooterPortal;
    public GameObject purpleShooter;

    public GameObject endBed;
    void Start()
    {
        Ps = GameObject.FindObjectOfType<PlayerScript>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        B_H = GetComponentInChildren<Enemy_HP>();
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


    public void prepareAttack(float i,string attack)
    {
        StartCoroutine(Wait());
        
        IEnumerator Wait()
        {
            yield return new WaitForSeconds(i);
            ani.SetBool(attack, true);
        }

    }

    public void StopAttack(string attack)
    {
        ani.SetBool(attack, false);
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
        attack1.GetComponent<BossBulletShoot>().BulletOut = 2f;
        attack1.GetComponent<BossBulletShoot>().StartATK = 0.3f;
        attack1.GetComponent<BossBulletShoot>().shootingEnd = 3;
        attack1.GetComponent<BossBulletShoot>().speed = 7;

    }
    public void Attack2()
    {
        GameObject attack2;
        attack2 = Instantiate(shooter, shooterA.position, Quaternion.identity);
        attack2.GetComponent<BossBulletShoot>().bulletUse = 2;
        attack2.GetComponent<BossBulletShoot>().shootingEnd = 1;
        attack2.GetComponent<BossBulletShoot>().BulletOut = 2f;
        attack2.GetComponent<BossBulletShoot>().StartATK = 0.3f;

        attack2 = Instantiate(shooter, shooterB.position, Quaternion.identity);
        attack2.GetComponent<BossBulletShoot>().bulletUse = 2;
        attack2.GetComponent<BossBulletShoot>().shootingEnd = 1;
        attack2.GetComponent<BossBulletShoot>().BulletOut = 2f;
        attack2.GetComponent<BossBulletShoot>().StartATK = 0.3f;
    }
    public void Attack5()
    {

        GameObject attack5;
        attack5 = Instantiate(purpleShooter, shooterA.position, Quaternion.identity);
        attack5.GetComponent<BossBulletShoot>().bulletUse = 1;
        attack5.GetComponent<BossBulletShoot>().shootingEnd = 1;
        attack5.GetComponent<BossBulletShoot>().BulletOut = 2f;
        attack5.GetComponent<BossBulletShoot>().StartATK = 0.1f;
        attack5.GetComponent<BossBulletShoot>().speed = 5.5f;

        attack5 = Instantiate(purpleShooter, shooterB.position, Quaternion.identity);
        attack5.GetComponent<BossBulletShoot>().bulletUse = 1;
        attack5.GetComponent<BossBulletShoot>().shootingEnd = 1;
        attack5.GetComponent<BossBulletShoot>().BulletOut = 2f;
        attack5.GetComponent<BossBulletShoot>().StartATK = 0.1f;
        attack5.GetComponent<BossBulletShoot>().speed = 5.5f;

    }

    public void Attack3()
    {
        GameObject shootPortal = Instantiate(shooterPortal, shooterA.position, Quaternion.identity);
        GameObject shootPortal2 = Instantiate(shooterPortal, shooterB.position, Quaternion.identity);

        GameObject attack3;
        attack3 = Instantiate(shooter, shooterA.position, Quaternion.identity);
        attack3.GetComponent<BossBulletShoot>().bulletUse = 2;
        attack3.GetComponent<BossBulletShoot>().rotate.z = 30;
        attack3.GetComponent<BossBulletShoot>().rotating = true;
        attack3.GetComponent<BossBulletShoot>().rotateSpeed = 30;
        attack3.GetComponent<BossBulletShoot>().shootingEnd = 15;
        attack3.GetComponent<BossBulletShoot>().BulletOut = 2f;
        attack3.GetComponent<BossBulletShoot>().StartATK = 0.2f;
        attack3.GetComponent<BossBulletShoot>().speed = 4.5f;
        
        StartCoroutine(Attackagain());
        IEnumerator Attackagain()
        {
            yield return new WaitForSeconds(3f);
            attack3 = Instantiate(shooter, shooterB.position, Quaternion.identity);
            attack3.GetComponent<BossBulletShoot>().bulletUse = 2;
            attack3.GetComponent<BossBulletShoot>().rotate.z = -30;
            attack3.GetComponent<BossBulletShoot>().rotating = true;
            attack3.GetComponent<BossBulletShoot>().rotateSpeed = 30;
            attack3.GetComponent<BossBulletShoot>().shootingEnd = 15;
            attack3.GetComponent<BossBulletShoot>().BulletOut = 2f;
            attack3.GetComponent<BossBulletShoot>().StartATK = 0.2f;
            attack3.GetComponent<BossBulletShoot>().speed = 4.5f;

            yield return new WaitForSeconds(4f);
            Destroy(shootPortal);
            Destroy(shootPortal2);
        }
    }

    public void Attack4()
    {
        GameObject attack1 = Instantiate(purpleShooter, shooterA.position, Quaternion.identity);
        attack1.GetComponent<BossBulletShoot>().bulletUse = 1;
        //attack1.GetComponent<BossBulletShoot>().Damage = 4;
        attack1.GetComponent<BossBulletShoot>().BulletOut = 2f;
        attack1.GetComponent<BossBulletShoot>().StartATK = 0.3f;
        attack1.GetComponent<BossBulletShoot>().shootingEnd = 3;

        attack1 = Instantiate(purpleShooter, shooterB.position, Quaternion.identity);

        attack1.GetComponent<BossBulletShoot>().bulletUse = 1;
        //attack1.GetComponent<BossBulletShoot>().Damage = 4;
        attack1.GetComponent<BossBulletShoot>().BulletOut = 2f;
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

    public void Attack6()
    {
        GameObject shootPortal = Instantiate(shooterPortal, shooterA.position, Quaternion.identity);
        GameObject shootPortal2 = Instantiate(shooterPortal, shooterB.position, Quaternion.identity);

        GameObject attack3;
        attack3 = Instantiate(shooter, shooterA.position, Quaternion.identity);
        attack3.GetComponent<BossBulletShoot>().bulletUse = 2;
        attack3.GetComponent<BossBulletShoot>().rotate.z = 45;
        attack3.GetComponent<BossBulletShoot>().rotating = true;
        attack3.GetComponent<BossBulletShoot>().rotateSpeed = 20;
        attack3.GetComponent<BossBulletShoot>().shootingEnd = 15;
        attack3.GetComponent<BossBulletShoot>().BulletOut = 2f;
        attack3.GetComponent<BossBulletShoot>().StartATK = 0.2f;
        attack3.GetComponent<BossBulletShoot>().speed = 4.5f;

        attack3 = Instantiate(purpleShooter, shooterB.position, Quaternion.identity);
        attack3.GetComponent<BossBulletShoot>().bulletUse = 2;
        attack3.GetComponent<BossBulletShoot>().shootingEnd = 15;
        attack3.GetComponent<BossBulletShoot>().BulletOut = 2f;
        attack3.GetComponent<BossBulletShoot>().StartATK = 0.2f;
        attack3.GetComponent<BossBulletShoot>().speed = 4.5f;

        StartCoroutine(DestroyPrortal());

        IEnumerator DestroyPrortal()
        {
            yield return new WaitForSeconds(4f);
            Destroy(shootPortal);
            Destroy(shootPortal2);
        }
    }

    public void Die()
    {
        Destroy(GameObject.FindObjectOfType<EnemyBullet>());
        Destroy(B_H.HPB);
        Destroy(this.gameObject);

        Instantiate(endBed, transform.position, Quaternion.identity);

        SoundManagerScript.PlaySound(SoundManagerScript.enemyDie);
    }
}
