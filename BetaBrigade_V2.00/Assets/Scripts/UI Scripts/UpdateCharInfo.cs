using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCharInfo : MonoBehaviour {

    // UI Components
    public Image[] ProfilPic; 
    public Image[] SB;

    //Game objects used to help update UI
    private GameObject art;
    private GameObject boomBox;
    private GameObject segSq;
    private GameObject nerf;
    private GameObject snek;
    private GameObject dinoD;

    //Array of game objects to store characters
    private static GameObject[] player = new GameObject[6];

    // Use this for initialization to 
    void Start () {
        //Find game objects to store into our game object array
        art = GameObject.Find("artistCharacter");
        boomBox = GameObject.Find("boomBoxCharacter");
        segSq = GameObject.Find("segwaySquid");
        nerf = GameObject.Find("nerfGun");
        snek = GameObject.Find("snakeGunner");
        dinoD = GameObject.Find("dinoDude");

        //Store game objects into player game object array
        player[0] = nerf;
        player[1] = snek;
        player[2] = dinoD;
        player[3] = art;
        player[4] = segSq;
        player[5] = boomBox;
    }
	
	// Update is called once per frame
	void Update () {

        //for loop to find the current active character
		for(int j = 0; j < 6; j++)
        {
            if(player[j].activeSelf == true)
            {
                FindCharacter(j);
            }
        }
    }

    // Find Profile Picture and Stats needed related to the current active characters
    void FindCharacter(int myNum)
    {
        for(int i = 0; i < 6; i++)
        {
            if(myNum == i) //active character found, set stats to be active on pause menu screen
            {
                ProfilPic[i].enabled = true;
                SB[i].enabled = true;
            }
            else //ignore all other characters and info
            {
                ProfilPic[i].enabled = false;
                SB[i].enabled = false;
            }
        }
    }

    /*
    void updateCharStats()
    {

    }
    */
}
