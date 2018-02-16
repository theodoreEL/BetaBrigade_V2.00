using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnerScript : MonoBehaviour
{
    public GameObject boxes; // The game object to spawn (In this case boxes)
    public GameObject rangedEnemy; // A game object for enemies
    public GameObject enemySpawner; // A game object to spawn enemies

    float randX; // A float for a random x position
    float randY; // A float for a random y position
    Vector2 whereToSpawn; // A vector that uses the x and y positions to spawn the game objects
    public float spawnRate = 5.0f;
    float nextSpawn = 0.0f;

    // Use this for initialization
    void Start()
    {
        // A loop that spawns the boxes
        for (int i = 0; i < Random.Range(5, 30); i++)
        {
            randX = Random.Range(-18, 18);
            randY = Random.Range(-6, 6);
            whereToSpawn = new Vector2(randX, randY);
            Instantiate(boxes, whereToSpawn, Quaternion.identity);
        }

        // Sets the location for the enemy spawner
        randX = Random.Range(-18, 18); randY = Random.Range(-6, 6);
        whereToSpawn = new Vector2(randX, randY);
        Instantiate(enemySpawner, whereToSpawn, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
		if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            /*
            randX = Random.Range(-10, 10);
            randY = Random.Range(-5, 5);
            whereToSpawn = new Vector2(randX, randY); */
            Instantiate(rangedEnemy, whereToSpawn, Quaternion.identity);
            
        }
    }
}
