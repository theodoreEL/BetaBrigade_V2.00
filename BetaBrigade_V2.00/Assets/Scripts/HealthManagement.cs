using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManagement : MonoBehaviour {

    //create variables
    public float maxPlayerHealth = 10;
    public static float playerHealth;
    public Slider healthBar;

    // Use this for initialization
    void Start () {
        playerHealth = 6;
        healthBar = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        //if player health goes over max health, resets it back down to max health
        if (playerHealth > maxPlayerHealth)
            playerHealth = maxPlayerHealth;

        //displaying current health on the health bar
        healthBar.value = playerHealth;
	}

    public static void DamagePlayer(int damageApplied) //method for damaging a player when getting hit by projectiles (once they're programmed)
    {
        playerHealth -= damageApplied;
    }
}
