using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{

    public PlayerController thePlayer;

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
        if (col.tag == "Player" && thePlayer.hasKey == true)
        {
            Destroy(GameObject.FindGameObjectWithTag("Pickup"));
            thePlayer.hasKey = false;
            Destroy(transform.parent.gameObject);
        }
    }
}