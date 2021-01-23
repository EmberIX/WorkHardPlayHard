using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    public bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    PlayerScript Ps;

    //deadZone dz;

    private void Start()
    {
        Ps = GameObject.FindObjectOfType<PlayerScript>();
        //dz = GameObject.FindObjectOfType<deadZone>();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape) && Ps.HP > 0 && Ps.isInteracted == false)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                PPause();
            }
        }


    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void PPause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }

}
