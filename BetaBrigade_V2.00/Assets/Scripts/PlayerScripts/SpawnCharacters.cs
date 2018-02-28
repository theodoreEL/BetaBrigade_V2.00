using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacters : MonoBehaviour {

    public PlayerController player;
    private int count = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < player.characters.Length; i++)
        {
            if (!(player.characters[i].isActive))
            {
                transform.GetChild(count).GetComponent<SpriteRenderer>().sprite = player.characters[count].charSprite;
                count++;
            }
        }
        count = 0;
	}
}
