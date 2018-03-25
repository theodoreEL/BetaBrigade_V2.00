using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchingChars : MonoBehaviour {

    public GameObject nerf, snek, artist, dino, boombox, segway;
    public GameObject switchCharUI;
    public Transform mainCamera;
    public PlayerController player;


    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

    }

    public void ActivateNerf()
    {
        GameManager.control.characterselect = 3;
        player.hubRoom = true;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            switchCharUI.SetActive(true);
            mainCamera.parent = null;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switchCharUI.SetActive(false);
    }
}
