using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

    public static GameControl control;
    public PlayerController player;


    // Use this for initialization
    void Awake () {
		if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        } else if (control != this)
        {
            Destroy(gameObject);
        }

    }
	
    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode = LoadSceneMode.Single)
    {
        
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
