using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingToCryo : MonoBehaviour {

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
            PlayerController.player.westSideCryo = true;
            StartCoroutine(LoadNextScene());
        }
        else if (other.tag == "Player" && gameObject.name == "RoomChangeEast")
        {
            PlayerController.player.eastSideCryo = true;
            StartCoroutine(LoadNextScene());
        }
        else if (other.tag == "Player" && gameObject.name == "RoomChangeNorth")
        {
            PlayerController.player.southSideCryo = true;
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
