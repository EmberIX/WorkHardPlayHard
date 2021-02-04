using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutScene : MonoBehaviour
{
    public GameObject NextCG;
    float showTime;
    public float playFadeOut;
    public float endTime;
    public ChangeScene Cs;
    public string Scene;

    public bool haveNextCutScene;
    public Animator animator;
    void Start()
    {
        Cs = GameObject.FindObjectOfType<ChangeScene>();
    }

    // Update is called once per frame
    void Update()
    {
        showTime += Time.deltaTime;

        if(showTime >= playFadeOut)
        {
            animator.SetTrigger("FadeOut");
        }

        if(showTime >= endTime)
        {
            if(haveNextCutScene)
            {
                OpenNextCutScene();
            }
            else
            {
                FinishCutScene();
            }
        }
    }

    void FinishCutScene()
    {
        Cs.LoadScene(Scene);
    }
    void OpenNextCutScene()
    {

    }
}
