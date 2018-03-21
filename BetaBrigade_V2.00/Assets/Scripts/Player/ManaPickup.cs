using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaPickup : MonoBehaviour
{
    public int manaToGive; // How much mana we'll give our character
    public AudioSource pickupSound; // Sound for picking up an object

    // Use this for initialization
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>() == null)  //if it's just sitting there and we haven't touched it
            return;

        ManaManagment.UseMana(-manaToGive);
        Destroy(gameObject);
    }
}
