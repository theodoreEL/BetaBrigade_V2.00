using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPickup : MonoBehaviour {

    public int healthToGive; //how much health we'll give to our character
    public AudioSource pickupSound;  //pickup sound for finding object


    // Use this for initialization
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>() == null)  //if it's just sitting there and we haven't touched it
            return;

        HealthManagement.DamagePlayer(-healthToGive);
        Destroy(gameObject);
    }
}
