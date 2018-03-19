using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    private static bool pause;
    public GameObject pMenu;
    public GameObject oMenu;

	// Use this for initialization
	void Start () {
        pause = false;
        pMenu.SetActive(false);
        oMenu.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause)
            {
                Game();
            }
            else
            {
                Pause();
            }
        }
	}

    public void Game()
    {
        Time.timeScale = 1;
        pMenu.SetActive(false);
        pause = false;
    }

    void Pause()
    {
        Time.timeScale = 0;
        pMenu.SetActive(true);
        pause = true;
    }

    public void Options()
    {
        //Time.timeScale = 0;
        pMenu.SetActive(false);
        oMenu.SetActive(true);
    }

    public void Exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Menu");
    }

    public void OptionsBack()
    {
        Time.timeScale = 0;
        pMenu.SetActive(true);
        oMenu.SetActive(false);
    }
}
