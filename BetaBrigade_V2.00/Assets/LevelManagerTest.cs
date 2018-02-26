using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LevelManagerTest : MonoBehaviour
{
    public string nextLevel;

    void Start()
    {
        StartCoroutine(LoadNextScene());
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(5);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Boss Room 1");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
