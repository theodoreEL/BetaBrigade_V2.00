using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour {

    public float aliveTime;

    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (aliveTime <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            aliveTime = aliveTime - 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            Destroy(gameObject);
        }
        else
        {
            return;
        }
    }
}
