using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {


    public Button isEasy;
    public Button isNormal;
    public Button isHard;
    public Button isYes;
    public Button isNo;

    // Use this for initialization
    void Start () {
        isEasy.onClick.AddListener(EasyTask);
        isNormal.onClick.AddListener(NormalTask);
        isHard.onClick.AddListener(HardTask);
        isYes.onClick.AddListener(YesTask);
        isNo.onClick.AddListener(NoTask);
    }
	
	// Update is called once per frame
	void Update () {
	}
    void ContinueTask()
    {
        //Load last saved game
    }
    void EasyTask()
    {
        //Start game in Easy mode
        SceneManager.LoadScene("Hub");
    }
    void NormalTask()
    {
        //Start game in Normal mode
        SceneManager.LoadScene("Hub");
    }
    void HardTask()
    {
        //Start game in Hard mode
        SceneManager.LoadScene("Hub");
    }
    void YesTask()
    {
        //Quit game
    }
    void NoTask()
    {
        isNo.animationTriggers.pressedTrigger = isNo.animationTriggers.normalTrigger;
    }
}
