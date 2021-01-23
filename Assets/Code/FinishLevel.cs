using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    public float exp = 0;
    ChangeScene Cs;
    public PlayerScript Ps;
    public GameObject LevelUpAni;
    public GameObject ExpUpAni;
    public GameObject playerSleepingSprite;
    public Animator ani;
    void Start()
    {
        Ps = GameObject.FindObjectOfType<PlayerScript>();
        Cs = GameObject.FindObjectOfType<ChangeScene>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LevelEnd()
    {

            Ps.isInteracted = true;
            Ps.date += 1;

            playerSleepingSprite.SetActive(true);

            StartCoroutine(WaitTime());

            IEnumerator WaitTime()
            {
                yield return new WaitForSeconds(1.5f);
                Ps.exp += exp;
                if (Ps.exp >= Ps.expMax)
                {
                    Instantiate(LevelUpAni, transform.position, Quaternion.identity);
                }
                else
                    Instantiate(ExpUpAni, transform.position, Quaternion.identity);
                Ps.SavePlayer();
            }

        


    }

    public void GoBack()
    {
        ani.SetTrigger("FadeOut");
        Cs.LoadScene("LivingRoom");
    }

    public void EndGame()
    {
        ani.SetTrigger("FadeOut");
        Cs.Quit();
    }
}
