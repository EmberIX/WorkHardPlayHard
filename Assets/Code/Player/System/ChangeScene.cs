using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    //Pause p;
    public string LevelToLoad;
    public bool isLoading;
    public float Loading;

    void start()
    {
        //p = GameObject.FindObjectOfType<Pause>();
    }

    private void Update()
    {
        if(Input.GetKeyDown("j"))
        {
            RestartScene();
            Time.timeScale = 1f;
        }

        if (Input.GetKeyDown("i"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Time.timeScale = 1f;
        }

        if (Input.GetKeyDown("n"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            Time.timeScale = 1f;
        }

        if(isLoading)
        {
            Loading += Time.deltaTime;
            if (Loading >= 1)
            {
                FinishFade();
            }
        }
    }

    public void Quit()
    {
            Application.Quit();
    }

    public void LoadScene(string scene)
    {
        Time.timeScale = 1f;
        transition.SetTrigger("FadeOut");
        LevelToLoad = scene;
        isLoading = true;    

    }

    public void LoadNextLevel(string level)
    {
        Time.timeScale = 1f;
        transition.SetTrigger("PlayToNextLevel");
        LevelToLoad = level;

    }

    public void RestartScene()
    {
        Time.timeScale = 1f;
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    public void FinishFade()
    {
        SceneManager.LoadScene(LevelToLoad);
        Time.timeScale = 1f;
    }

    public void endLevelTrans()
    {
        transition.SetTrigger("endLevel");
    }
    
}
