using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject playerParent, artistChar, boomBoxChar, segwayChar, nerfGunChar, snakeChar;
    public static GameManager control;
    public PlayerController player;
    public GameObject[] characters = new GameObject[5];
    public int characterselect = 0;


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
        for (int i = 0; i < characters.Length; i++)
        {
            if (characterselect == i)
            {
                characters[i].SetActive(true);
            }
            else
            {
                characters[i].SetActive(false);
            }
        }
    }
}
