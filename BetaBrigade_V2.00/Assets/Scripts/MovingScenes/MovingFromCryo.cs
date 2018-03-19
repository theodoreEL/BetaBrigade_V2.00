using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingFromCryo : MonoBehaviour {


    public PlayerController playController;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {/*
        if (other.tag == "Player" && gameObject.tag == "OutWestCryo")
        {
            playController.outWestCryo = true;
            StartCoroutine(LoadNextScene());
        }
        else if (other.tag == "Player" && gameObject.tag == "OutEastCryo")
        {
            playController.outEastCryo = true;
            StartCoroutine(LoadNextScene());
        }
        else if (other.tag == "Player" && gameObject.tag == "OutSouthCryo")
        {
            playController.outSouthCryo = true;
            StartCoroutine(LoadNextScene());
        }*/
    }

    IEnumerator LoadNextScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Hub");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

}
