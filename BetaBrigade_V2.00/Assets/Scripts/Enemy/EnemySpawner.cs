using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    private float spawnRate;
    private float nextSpawn = 0.0f;
    private int spawnCount = 0;
    private int whatToSpawn = 0;
    Vector2 whereToSpawn;

    public GameObject meleeEnemy; // A game object for melee enemies
    public GameObject rangedEnemy; // A game object for ranged enemies

    void Start()
    {
        spawnRate = Random.Range(3, 15);
        whereToSpawn = new Vector2(transform.position.x, transform.position.y);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (spawnCount <= Random.Range(10, 20))
        {
            if (Time.time > nextSpawn)
            {
                whatToSpawn = Random.Range(0, 50);
                nextSpawn = Time.time + spawnRate;

                if (whatToSpawn < 25)
                {
                    Instantiate(rangedEnemy, whereToSpawn, Quaternion.identity);
                    spawnCount++;
                }
                else
                {
                    Instantiate(rangedEnemy, whereToSpawn, Quaternion.identity);
                    spawnCount++;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Projectile")
        {
            Destroy(gameObject);
        }

    }
}
