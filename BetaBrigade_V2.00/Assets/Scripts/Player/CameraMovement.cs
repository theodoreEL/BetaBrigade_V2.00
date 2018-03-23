using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    // Creates a GameObject player for which the camera will follow
    public GameObject player;

    private Vector3 offset;

	// Use this for initialization
	void Start ()
    {
        // Sets the value of offset which is the difference between the camera's location and the player's location
        offset = transform.position - player.transform.position;
	}
	
	// LateUpdate is called once per frame at the end of each frame
	void LateUpdate ()
    {
        // Updates the camera to follow the character's position
        transform.position = player.transform.position + offset;
	}
}
