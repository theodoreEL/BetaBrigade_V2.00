using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour {

    public GameObject Player;
    public GameObject bulletPrefab;
    public float shootingCooldown;
    public float timeBetweenShots;
    public float attackRange;
    


    // Use this for initialization
    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Vector2.Distance(Player.transform.position, transform.position) <= attackRange)
        {
            if (shootingCooldown <= 0)
            {
                //Create bullet
                Instantiate(bulletPrefab, transform.position, transform.rotation);
                shootingCooldown = timeBetweenShots;
            }
            else
            {
                //reduce cooldown
                shootingCooldown = shootingCooldown - 1;
            }
        }
    }
}
