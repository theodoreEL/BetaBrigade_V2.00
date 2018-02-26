using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropController : MonoBehaviour {

	//GAME OBJECT Array to store the items that can be dropped
	public GameObject[] itemDrops = new GameObject[10];


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		/* if (health is <= 0)
			{
				dropItem();
			}*/
	}

	void dropItem()
	{
		//gernerate a random number
		int itemNumber = Random.Range(0, 10);
		//use the random number to select an item from the array
		GameObject itemToDrop = itemDrops[itemNumber];
		//create the object at the bosses location
		Instantiate(itemToDrop, transform.position, transform.rotation);
		//destry the boss
		Destroy(gameObject);
	}
}
