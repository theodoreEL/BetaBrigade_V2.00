using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement: MonoBehaviour {

    public float range;
    public GameObject Player;
    public float speed;
    private float horizMoveVelocity;
    private float vertMoveVelocity;
    public bool left, right, up, down;
    public float knockback;
    public float knockbackLength;
    //[HideInInspector]
    //public Vector3 hitLocation;
    private Vector2 referenceHit;
    float step;

    // Use this for initialization
    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");


    }
	
	// Update is called once per frame
	void Update () {
        step = speed * Time.deltaTime;
        MoveEnemy();
       /* if (hitLocation == Vector3.zero)
        {
            Invoke("MoveEnemy", .4f);
        }
        else
        {
            referenceHit = hitLocation - transform.position;
            enemyRB.velocity = new Vector3(referenceHit.x / Mathf.Abs(referenceHit.x) * (-knockback), referenceHit.y / Mathf.Abs(referenceHit.x) * (-knockback));
            hitLocation = Vector3.zero;
        }*/
    }



    private void MoveEnemy()
    {
        if (Vector2.Distance(Player.transform.position, transform.position) <= range)
        {
            //transform.Translate(Vector2.MoveTowards(transform.position, -Player.position, 0) * Time.deltaTime);
            //transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, step);

            horizMoveVelocity = 0f;
            vertMoveVelocity = 0f;
            Vector2 path = Player.transform.position - transform.position;

            if (path.x < 0)
            {
                if (path.y > 0)
                {
                    //shoot up to the left
                    left = true;
                    right = false;
                    up = true;
                    down = false;
                }
                else if (path.y > -.5 && path.y < .5)
                {
                    //shoot direcly to the left
                    left = true;
                    right = false;
                    up = false;
                    down = false;
                }
                else if (path.y < 0)
                {
                    //shoot down to the left
                    left = true;
                    right = false;
                    up = false;
                    down = true;
                }
            }
            else if (path.x > -.5 && path.x < .5)
            {
                if (path.y > 0)
                {
                    //shoot directly up
                    left = false;
                    right = false;
                    up = true;
                    down = false;
                }
                else if (path.y < 0)
                {
                    //shoot direcly down
                    left = false;
                    right = false;
                    up = false;
                    down = true;
                }
            }
            else if (path.x > 0)
            {
                if (path.y > 0)
                {
                    //shoot up and to the right
                    left = false;
                    right = true;
                    up = true;
                    down = false;
                }
                else if (path.y > -.5 && path.y < .5)
                {
                    //shoot directly right
                    left = false;
                    right = true;
                    up = false;
                    down = false;
                }
                else if (path.y < 0)
                {
                    //shoot down and to the right
                    left = false;
                    right = true;
                    up = false;
                    down = true;
                }
            }

            if (left)
            {
                transform.Translate(Vector2.left * step);
            }
            if (right)
            {
                transform.Translate(Vector2.right * step);
            }
            if (up)
            {
                transform.Translate(Vector2.up * step);
            }
            if (down)
            {
                transform.Translate(Vector2.down * step);
            }
        }
    }
}
