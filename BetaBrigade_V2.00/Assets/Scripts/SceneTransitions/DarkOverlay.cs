using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkOverlay : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
