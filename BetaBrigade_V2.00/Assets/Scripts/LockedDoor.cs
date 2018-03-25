using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && PlayerController.player.hasKey)
        {
            Destroy(GameObject.FindGameObjectWithTag("Pickup"));
            PlayerController.player.hasKey = false;
            Destroy(transform.parent.gameObject);
        }
    }
}