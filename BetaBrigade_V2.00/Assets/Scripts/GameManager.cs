using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager control;


    // Use this for initialization

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode = LoadSceneMode.Single)
    {

    }

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

	// Update is called once per frame
	void Update () {
		
	}
}
