using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour {

    public GameObject attackHoriz;
    public GameObject attackVert;
    public GameObject player;
    public bool wait = false;

    void Update()
    {

        if (Input.GetAxisRaw("FireHoriz") == 1 && !wait)
        {
            Invoke("AttackRight", 2);
            wait = true;
        }
        else if (Input.GetAxisRaw("FireVert") == 1 && !wait)
        {

            Invoke("AttackUp", 2);
            wait = true;
        }
        else if (Input.GetAxisRaw("FireHoriz") == -1 && !wait)
        {
            Invoke("AttackLeft", 2);
            wait = true;
        }
        else if (Input.GetAxisRaw("FireVert") == -1 && !wait)
        {
            Invoke("AttackDown", 2);
            wait = true;
        }
    }

    void AttackRight()
    {
        Instantiate(attackHoriz, new Vector2(transform.position.x + 1, transform.position.y), transform.rotation);
        wait = false;
    }

    void AttackUp()
    {
        Instantiate(attackVert, new Vector2(transform.position.x, transform.position.y + 2), transform.rotation);
        wait = false;
    }

    void AttackLeft()
    {
        Instantiate(attackHoriz, new Vector2(transform.position.x - 1, transform.position.y), transform.rotation);
        wait = false;
    }

    void AttackDown()
    {
        Instantiate(attackVert, new Vector2(transform.position.x, transform.position.y - 2), transform.rotation);
        wait = false;
    }
}
