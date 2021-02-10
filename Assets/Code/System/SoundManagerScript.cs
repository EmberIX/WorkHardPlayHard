using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioSource playAudio;
    
    public static AudioClip walk;
    
    public static AudioClip roll;
    public static AudioClip shootBullet;
    public static AudioClip spear;
    public static AudioClip EnemyBullet;
    public static AudioClip takeDamage;
    public static AudioClip die;
    public static AudioClip enemyTakeDamage;
    public static AudioClip enemyDie;
    public static AudioClip getMoney;
    public static AudioClip butItem;
    public static AudioClip clickSound;
    public static AudioClip upSkill;
    public static AudioClip bugSound;
    public static AudioClip summonBug;
    public static AudioClip heal;
    public static AudioClip Research;
    public static AudioClip CounterBullet;
    public static AudioClip particleBullet;
    public static AudioClip spearPower;
    void Start()
    {
        playAudio = GameObject.FindGameObjectWithTag("PlayerAudio").GetComponent<AudioSource>();
        
        walk = Resources.Load<AudioClip>("walk");
        roll = Resources.Load<AudioClip>("roll");
        shootBullet = Resources.Load<AudioClip>("shootBullet");
        spear = Resources.Load<AudioClip>("spear");
        getMoney = Resources.Load<AudioClip>("getMoney");
        butItem = Resources.Load<AudioClip>("buyItem");
        enemyDie = Resources.Load<AudioClip>("enemyDie");
        clickSound = Resources.Load<AudioClip>("clickSound");
        upSkill = Resources.Load<AudioClip>("upSkill");
        bugSound = Resources.Load<AudioClip>("bugSound");
        summonBug = Resources.Load<AudioClip>("summonBug");
        heal = Resources.Load<AudioClip>("heal");
        Research = Resources.Load<AudioClip>("Research");
        CounterBullet = Resources.Load<AudioClip>("counterBullet");
        particleBullet = Resources.Load<AudioClip>("particleBullet");
        spearPower = Resources.Load<AudioClip>("spearPower");
        takeDamage = Resources.Load<AudioClip>("takeDamage");
        die = Resources.Load<AudioClip>("dead");
        enemyTakeDamage = Resources.Load<AudioClip>("enemyTakeDamage");
        EnemyBullet = Resources.Load<AudioClip>("enemyBullet");
    }

    public static void PlaySound(AudioClip sound)
    {
        playAudio.PlayOneShot(sound);
    }

    public static void clickButton()
    {
        playAudio.PlayOneShot(clickSound);
    }

}
