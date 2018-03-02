using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LevelManagerTest : MonoBehaviour
{
	public string[] levelsInOrder; //MUST BE STORED IN GAME ORDER
	static public int levelNumber;
	

    void Start()
    {
		string nextLevel;
		nextLevel = levelsInOrder[levelNumber];
		StartCoroutine(LoadNextScene(nextLevel));
		levelNumber = levelNumber + 1;

	}

    IEnumerator LoadNextScene(string levelName)
    {
        yield return new WaitForSeconds(5);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelName);


		while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
