using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerScript : MonoBehaviour
{
    public float HP = 0;
    public float MaxHP;
    public int level;
    public int skillPoint;
    public float money;
    public int date;
    public float ATK;
    public float energy;
    public string weapon;
    public float exp = 0;
    public float expMax = 25;
    public float progress;

    public bool isdashing;
    public Image HPBar;
    public bool isDamaged;
    public float Stun;
    public float StunEnd = 0.5f;
    public GameObject playerCollider;
    //public GameObject LevelUpAni;
    public Animator animator;
    public bool isInteracted;
    public string itemUse;
    public bool isDead;
    public FinishLevel FL;
    ChangeScene Cs;
    public CameraShake cS;
    void Start()
    {
        HP = MaxHP;
        SetHPBar();
        cS = GameObject.FindObjectOfType<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDamaged)
        {
            SoundManagerScript.PlaySound(SoundManagerScript.takeDamage);
            Stun += Time.deltaTime;
            if(Stun >= StunEnd)
            {
                isDamaged = false;
                Stun = 0;
            }
        }


        if(exp >= expMax && level<20)
        {
            levelUp();
        }

        if(Input.GetKeyDown("h"))
        {
            HP += 5000;
            
        }
    }
    public void TakeDamage(float amount)
    {
        if (isDamaged == false)
        {
            HP -= amount;
            SetHPBar();
            animator.SetTrigger("Damage");
            StartCoroutine(cS.Shake(.05f,.04f));
            isDamaged = true;
        }
        //SetHPBar();

        if (HP <= 0)
        {
            isdashing = true;
            SoundManagerScript.PlaySound(SoundManagerScript.die);
            FL = GameObject.FindObjectOfType<FinishLevel>();
            StartCoroutine(cS.Shake(.06f, .05f));
            isDead = true;
            Cs = GameObject.FindObjectOfType<ChangeScene>();
            if (Cs.LevelToLoad == "Dungeon5")
            {
                Cs.LoadScene("Dungeon5");
            }
            else
            FL.LevelEnd();
            
        }
    }
    public void SetHPBar()
    {
        HPBar.fillAmount = HP / MaxHP;
    }

    public void SavePlayer()
    {
        SaveSetting.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSetting.LoadPlayer();

        level = data.level;
        MaxHP = data.MaxHP;
        level = data.level;
        ATK = data.ATK;
        energy = data.energy;
        weapon = data.weapon;
        exp = data.exp;
        expMax = data.expMax;
        skillPoint = data.skillPoint;
        money = data.money;
        progress = data.progress;
        date = data.date;
        itemUse = data.itemUse;
    }
    public void levelUp()
    {
        level += 1;
        skillPoint += 1;
        //Instantiate(LevelUpAni, transform.position, Quaternion.identity);
        exp -= expMax;
        expMax += 5;
    }    
}
