using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Work : MonoBehaviour
{
    PlayerScript PS;
    ItemTrack IT;
    public GameObject Lock;
    public GameObject Finish;
    Computer C;
    DayEvent DE;

    [Header("Details")]
    public string workName;
    public int levelNeed;
    public int enegyNeed;
    public bool isFinish;
    public bool isLock;
    public Text unlockLevel;

    [Header("Give")]
    public int money;
    public int ATK;
    public int Energy;
    public int HP;
    public int skillPoint;

    [Header("Ref")]
    public GameObject WorkAni;
    public Text showText;
    public Text showText2;
    public GameObject TextBox1;
    public GameObject TextBox2;
    public Animator ani;

    [Header("Work")]
    public GameObject WorkCanvas;
    void Start()
    {
        PS = GameObject.FindObjectOfType<PlayerScript>();
        IT = GameObject.FindObjectOfType<ItemTrack>();
        C = GameObject.FindObjectOfType<Computer>();
        DE = GameObject.FindObjectOfType<DayEvent>();
        unlockLevel.text = "Level " + levelNeed;

        if (IT.workList.Contains(workName))
        {
            isFinish = true;
        }

        if (isFinish)
        {
            Finish.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(PS.level < levelNeed)
        {
            isLock = true;
            Lock.SetActive(true);
        }
        else
        {
            isLock = false;
            Lock.SetActive(false);
        }

        if (IT.workList.Contains(workName))
        {
            isFinish = true;
        }

        if (isFinish)
        {
            Finish.SetActive(true);
        }
    }

    public void WorkFinsih()
    {
        PS.MaxHP += HP;
        PS.ATK += ATK;
        PS.energy += Energy;
        PS.skillPoint += skillPoint;
        PS.money += money;
    }

    public void DoWork()
    {
        if (C.energy >= enegyNeed && isLock == false && isFinish == false && DE.time != 2)
        {
            C.energy -= enegyNeed;
            StartWorking();

        }

        else if (C.energy < enegyNeed && isLock == false && isFinish == false)
        {
            showText2.text = "Not enough energy!!";
            TextBox2.SetActive(false);
            TextBox2.SetActive(true);
        }

        else if (DE.time == 2)
        {
            showText2.text = "It time to sleep!!";
            TextBox2.SetActive(false);
            TextBox2.SetActive(true);
        }
    }

    void StartWorking()
    {
        C.isWorking = true;
        ani.SetTrigger("Play");
        StartCoroutine(Wait());
        IEnumerator Wait()
            {
            print("Work Success");
            yield return new WaitForSeconds(2.1f);
            WorkCanvas.SetActive(true);
        }

    }

    public void WorkSuccess()
    {
        WorkAni.SetActive(false);
        WorkAni.SetActive(true);
        StartCoroutine(Wait());
        IEnumerator Wait()
        {
            yield return new WaitForSeconds(0.5f);
            SoundManagerScript.PlaySound(SoundManagerScript.getMoney);

        }
        showText.text = "Work Done!!";
        TextBox1.SetActive(false);
        TextBox1.SetActive(true);
        DE.time += 1;
        isFinish = true;
        IT.workList.Add(this.workName);
        WorkCanvas.SetActive(false);

        WorkFinsih();
    }

    public void WorkFail()
    {
        StartCoroutine(Wait());
        IEnumerator Wait()
        {
            yield return new WaitForSeconds(0.5f);
            SoundManagerScript.PlaySound(SoundManagerScript.getMoney);

        }
        showText.text = "Work Fail!!";
        TextBox1.SetActive(false);
        TextBox1.SetActive(true);
        DE.time += 1;
        WorkCanvas.SetActive(false);

    }
}
