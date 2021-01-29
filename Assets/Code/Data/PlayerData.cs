using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData 
{
    public float MaxHP;
    public int level;
    public float ATK;
    public float energy;
    public string weapon;
    public string itemUse;
    public float exp;
    public float expMax;
    public int skillPoint;
    public float money;
    public int date;
    public float progress;

    public PlayerData (PlayerScript player)
    {
        MaxHP = player.MaxHP;
        level = player.level;
        ATK = player.ATK;
        energy = player.energy;
        weapon = player.weapon;
        exp = player.exp;
        expMax = player.expMax;
        skillPoint = player.skillPoint;
        money = player.money;
        progress = player.progress;
        date = player.date;
        itemUse = player.itemUse;
    }

}

