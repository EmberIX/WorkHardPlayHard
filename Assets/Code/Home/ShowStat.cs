using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowStat : MonoBehaviour
{
    public PlayerScript Ps;
    public Text HPShow;
    public Text ATKShow;
    public Text EnergyShow;
    public Text EXPShow;
    public Image EXPBar;
    public Text LevelShow;
    public Text skillPointShow;
    public Text moneyShow;
    public Text moneyShow2;
    void Start()
    {
        Ps = GameObject.FindObjectOfType<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        HPShow.text = "" + Ps.MaxHP;
        ATKShow.text = "" + Ps.ATK;
        LevelShow.text = "" + Ps.level;
        EnergyShow.text = "" + Ps.energy;
        EXPShow.text = "" + Ps.exp;
        skillPointShow.text = "" + Ps.skillPoint;
        moneyShow.text = "" + Ps.money;
        moneyShow2.text = "" + Ps.money;

        SetEXPBar();
    }

    public void SetEXPBar()
    {
        EXPBar.fillAmount = Ps.exp / Ps.expMax;
    }

    public void HPUp()
    {
        if(Ps.skillPoint > 0)
        {
            Ps.MaxHP += 1;
            Ps.skillPoint -= 1;
            Ps.SavePlayer();
            SoundManagerScript.PlaySound(SoundManagerScript.upSkill);
        }
    }

    public void ATKUp()
    {
        if (Ps.skillPoint > 0)
        {
            Ps.ATK += 1;
            Ps.skillPoint -= 1;
            Ps.SavePlayer();
            SoundManagerScript.PlaySound(SoundManagerScript.upSkill);
        }
    }

    public void EnegyUp()
    {
        if (Ps.skillPoint > 0)
        {
            Ps.energy += 1;
            Ps.skillPoint -= 1;
            Ps.SavePlayer();
            SoundManagerScript.PlaySound(SoundManagerScript.upSkill);
        }
    }
}
