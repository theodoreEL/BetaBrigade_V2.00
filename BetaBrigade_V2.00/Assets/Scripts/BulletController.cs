using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float speed;
    public Vector2 direction;
    public PlayerController player;
    private Rigidbody2D bullet;
    public GameObject healthPotion;

    private void Awake()
    {
        Destroy(gameObject, 3f);
    }

    // Use this for initialization
    void Start () {
        bullet = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>();
        
	}

	// Update is called once per frame
	void Update () {
        bullet.velocity = direction * speed;
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if(other.tag == "Destroyable")
        {
            int spawnChance = Random.Range(0, 51);

            if (spawnChance <= 10)
            {
                Instantiate(healthPotion, transform.position, transform.rotation);
                
            }

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
       
    }

}

