using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour {

    public GameObject attack;
    public GameObject player;

    void Update()
    {

        if (Input.GetAxisRaw("FireHoriz") == 1)
        {
            Instantiate(attack, new Vector2(transform.position.x + 1, transform.position.y), transform.rotation);

        }
        else if (Input.GetAxisRaw("FireVert") == 1)
        {
            Instantiate(attack, new Vector2(transform.position.x, transform.position.y + 2), transform.rotation);

        }
        else if (Input.GetAxisRaw("FireHoriz") == -1)
        {
            Instantiate(attack, new Vector2(transform.position.x - 1, transform.position.y), transform.rotation);

        }
        else if (Input.GetAxisRaw("FireVert") == -1)
        {
            Instantiate(attack, new Vector2(transform.position.x, transform.position.y - 2), transform.rotation);

        }
    }
}
