using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour {

    public GameObject attack;
    public GameObject player;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 localPosition = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            float angle = (float)Mathf.Atan2(localPosition.y, localPosition.x) * Mathf.Rad2Deg;
            Debug.Log(angle);
            angle = Mathf.RoundToInt(angle / 90) * 90;
            

            if (angle == 0)
            {
                GameObject myAttack = Instantiate(attack, new Vector2(transform.position.x + 1, transform.position.y
                    ), transform.rotation);
                Debug.Log("Your angle is: " + angle);
            }
            else if (angle == 90)
            {
                GameObject myAttack = Instantiate(attack, new Vector2(transform.position.x, transform.position.y + 2
                    ), transform.rotation);
                Debug.Log("Your angle is: " + angle);
            }
            else if (angle == 180)
            {
                GameObject myAttack = Instantiate(attack, new Vector2(transform.position.x - 1, transform.position.y
                    ), transform.rotation);
                Debug.Log("Your angle is: " + angle);
            }
            else if (angle == -90)
            {
                GameObject myAttack = Instantiate(attack, new Vector2(transform.position.x, transform.position.y - 2
                    ), transform.rotation);
                Debug.Log("Your angle is: 360");
            }
        }
    }

}
