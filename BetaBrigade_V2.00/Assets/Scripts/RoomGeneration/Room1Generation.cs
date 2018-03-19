using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1Generation : MonoBehaviour
{
    public GameObject boxes; // The game object to spawn (In this case boxes)
    public GameObject enemySpawner; // A game object to spawn enemies

    float randX; // A float for a random x position
    float randY; // A float for a random y position
    Vector2 whereToSpawn; // A vector that uses the x and y positions to spawn the game objects

    // Use this for initialization
    void Start()
    {
        // A loop that spawns the boxes
        for (int i = 0; i < Random.Range(10, 20); i++)
        {
            randX = Random.Range(31, 59);
            randY = Random.Range(-13, 13);
            whereToSpawn = new Vector2(randX, randY);
            Instantiate(boxes, whereToSpawn, Quaternion.identity);
        }

        // Sets the location for the enemy spawner
        randX = Random.Range(31, 59); randY = Random.Range(-13, 13);
        whereToSpawn = new Vector2(randX, randY);
        Instantiate(enemySpawner, whereToSpawn, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
