using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchingChars : MonoBehaviour {

    public PlayerController player;
    private float switchTime = 0f;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		if(player.switchChars)
            switchTime += Time.deltaTime;
        if(switchTime >= 1)
            player.switchChars = false;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "OtherSpawn" && Input.GetKeyDown(KeyCode.F))
        {
            player.switchChars = true;
            for(int i = 0; i < player.characters.Length; i++)
            {
                Debug.Log("you've made it here");
                player.characters[i].character.SetActive(true);
                if (other.transform.GetComponent<SpriteRenderer>().sprite == player.characters[i].charSprite)
                {
                    player.characters[i].isActive = true;
                    player.characterselect = i;
                    break;
                }
            }
        }
    }
}
