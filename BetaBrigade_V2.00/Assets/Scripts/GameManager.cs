using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager control;
    public PlayerController player;
    private GameObject otherCharSpawners;


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

	// Update is called once per frame
	void Update () {
		
	}
}
