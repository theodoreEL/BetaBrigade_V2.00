using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropController : MonoBehaviour {

	//GAME OBJECT Array to store the items that can be dropped
	public GameObject[] itemDrops;

	public int tempHealth; //USED TO TEST DROP FUNCTION WITHOUT THE HEALTH FUNCTIONALITY
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		tempHealth = tempHealth - 1;

		if (tempHealth <= 0)
			{
				dropItem();
			}
	}


	void dropItem()
	{
		//gernerate a random number
		int itemNumber = Random.Range(0, itemDrops.Length);
		//use the random number to select an item from the array
		GameObject itemToDrop = itemDrops[itemNumber];
		//create the object at the bosses location
		Instantiate(itemToDrop, transform.position, transform.rotation);
		//destry the boss
		Destroy(gameObject);
	}
}
