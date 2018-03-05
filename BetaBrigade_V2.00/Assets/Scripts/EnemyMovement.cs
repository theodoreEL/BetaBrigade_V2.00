using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement: MonoBehaviour {

    public bool withinRange;
    public float speed;
    private float horizMoveVelocity;
    private float vertMoveVelocity;
    public bool left, right, up, down;

    [SerializeField]
    Transform Player;
    Transform lineOfSightEnd;

    // Use this for initialization
    void Start () {
        withinRange = false;
        Player = GameObject.Find("Player").transform;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float step = speed * Time.deltaTime;

        if (PlayerIsSeen())
        {
            //transform.Translate(Vector2.MoveTowards(transform.position, -Player.position, 0) * Time.deltaTime);
            //transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, step);

            horizMoveVelocity = 0f;
            vertMoveVelocity = 0f;
            Vector2 path = Player.position - transform.position;

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

    bool PlayerIsSeen()
    {
        if (withinRange)
        {
            /*if (FieldOfView())
            {
                return (!Hidden());
            }
            else
            {
                return false;
            }*/
            return (!Hidden());
        }
        else
        {
            return false;
        }

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            withinRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            withinRange = false;
        }
    }

    /*bool FieldOfView()
    {
        Vector2 direction = Player.position - transform.position;
        Debug.DrawLine(transform.position, Player.position, Color.red);

        Vector2 lineOfSight = lineOfSightEnd.position - transform.position;
        Debug.DrawLine(transform.position, lineOfSightEnd.position, Color.blue);

        float angle = Vector2.Angle(direction, lineOfSight);

        if (angle < 65)
        {
            return true;
        }
        else
        {
            return false;
        }

    }*/

    bool Hidden()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, Player.position);
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Player.position - transform.position, distanceToPlayer);
        Debug.DrawRay(transform.position, Player.position - transform.position, Color.green);
        List<float> distances = new List<float>();

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.transform.tag == "Enemy")
                continue;

            if (hit.transform.tag != "Player")
            {
                return true;
            }
        }

        return false;

    }


}
