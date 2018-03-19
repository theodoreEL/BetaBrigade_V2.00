using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyablesCollison : MonoBehaviour {

    public GameObject healthPotion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Projectile")
        {

            //see if spwan potion;
            int spawnChance = Random.Range(0, 51);

            if(spawnChance <= 25)
            {
                Instantiate(healthPotion, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
       
    }
}
