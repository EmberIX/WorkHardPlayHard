using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_HP : MonoBehaviour
{
    public float HP;
    public float MaxHP;

    public GameObject HPB;
    public Image HPBar;
    public bool TakeHit;
    
    public bool isIFlame;
    public PlayerScript Ps;
    private void Start()
    {
        Ps = GameObject.FindObjectOfType<PlayerScript>();
    }

    void TakeDamage(float amount)
    {
        if(isIFlame)
        {
            return;
        }

        HP -= amount;

        if(HP <= 0)
        {
            Die();
        }
    }

    public void SetHPBar()
    {
        HPBar.fillAmount = HP / MaxHP;
    }

    public void BeginrFight()
    {
        isIFlame = false;
        HPB.SetActive(true);
    }

    void Die()
    {
        Destroy(GameObject.FindGameObjectWithTag("BigSlime"));
        Destroy(GameObject.FindGameObjectWithTag("smallBug"));
        Destroy(GameObject.FindObjectOfType<Trap>());
        Destroy(GameObject.FindObjectOfType<EnemyBullet>());
        Destroy(HPB);

        Destroy(this.gameObject);

        SoundManagerScript.PlaySound(SoundManagerScript.enemyDie);
        if (Ps != null)
        {
            Ps.HP = Ps.MaxHP;
        }
    }
}
