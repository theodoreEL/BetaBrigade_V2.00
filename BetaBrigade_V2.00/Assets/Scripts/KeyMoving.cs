using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMoving : MonoBehaviour {

    private Rigidbody2D keyRB;
    public Rigidbody2D playerRB;
    public Transform holdingSpot;

	// Use this for initialization
	void Start () {
        keyRB = gameObject.GetComponent<Rigidbody2D>();
        Vector3 holdingPos = holdingSpot.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.parent != null)
        {
            if (transform.parent.tag == "Player")
            {
                keyRB.velocity = playerRB.velocity;
                PlayerController.player.hasKey = true;
            }
        }
        else
            keyRB.velocity = Vector3.zero;
       
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                transform.parent = other.transform;
                transform.position = holdingSpot.position;
            }
        }
    }
}
