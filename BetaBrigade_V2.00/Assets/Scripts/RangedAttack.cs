using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour {

    public bool left, right, up, down;
    public GameObject Player;
    public float bulletSpeed;

    // Use this for initialization
    void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Vector2 shootingPath = Player.transform.position - transform.position;
        if (shootingPath.x < 0)
        {
            if (shootingPath.y > 0)
            {
                //shoot up to the left
                left = true;
                right = false;
                up = true;
                down = false;
            }
            else if (shootingPath.y > -.5 && shootingPath.y < .5)
            {
                //shoot direcly to the left
                left = true;
                right = false;
                up = false;
                down = false;
            }
            else if (shootingPath.y < 0)
            {
                //shoot down to the left
                left = true;
                right = false;
                up = false;
                down = true;
            }
        }
        else if (shootingPath.x > -.5 && shootingPath.x < .5)
        {
            if (shootingPath.y > 0)
            {
                //shoot directly up
                left = false;
                right = false;
                up = true;
                down = false;
            }
            else if (shootingPath.y < 0)
            {
                //shoot direcly down
                left = false;
                right = false;
                up = false;
                down = true;
            }
        }
        else if (shootingPath.x > 0)
        {
            if (shootingPath.y > 0)
            {
                //shoot up and to the right
                left = false;
                right = true;
                up = true;
                down = false;
            }
            else if (shootingPath.y > -.5 && shootingPath.y < .5)
            {
                //shoot directly right
                left = false;
                right = true;
                up = false;
                down = false;
            }
            else if (shootingPath.y < 0)
            {
                //shoot down and to the right
                left = false;
                right = true;
                up = false;
                down = true;
            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (left)
        {
            transform.Translate(Vector2.left * Time.deltaTime * bulletSpeed);
        }
        if (right)
        {
            transform.Translate(Vector2.right * Time.deltaTime * bulletSpeed);
        }
        if (up)
        {
            transform.Translate(Vector2.up * Time.deltaTime * bulletSpeed);
        }
        if (down)
        {
            transform.Translate(Vector2.down * Time.deltaTime * bulletSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            Destroy(gameObject);
        }
        else if (other.tag == "Enemy" || other.tag == "Projectile")
            return;
        else
            Destroy(gameObject);
    }
}
