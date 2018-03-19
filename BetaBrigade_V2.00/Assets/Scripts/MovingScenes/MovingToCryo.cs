using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingToCryo : MonoBehaviour {

    public PlayerController playController;
   
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && gameObject.name == "RoomChangeWest")
        {
            playController.westSideCryo = true;
            StartCoroutine(LoadNextScene());
        }
        else if (other.tag == "Player" && gameObject.name == "RoomChangeEast")
        {
            playController.eastSideCryo = true;
            StartCoroutine(LoadNextScene());
        }
        else if (other.tag == "Player" && gameObject.name == "RoomChangeNorth")
        {
            playController.southSideCryo = true;
            StartCoroutine(LoadNextScene());
        }
    }
   
    IEnumerator LoadNextScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("CryoRoom");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

}
