using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour {

    public GameObject Player;
    public float meleeRange;
    public GameObject meleePrefab;
    public float meleeCooldown;
    public float timeBetweenMelee;

    // Use this for initialization
    void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Vector2.Distance(Player.transform.position, transform.position) <= meleeRange)
        {
            if (meleeCooldown <= 0)
            {
                //find player and create object in area

                GameObject mATK = Instantiate(meleePrefab, transform.position, transform.rotation);
                Vector2 meleeArea = Player.transform.position - transform.position;

                if (meleeArea.x < 0)
                {
                    if (meleeArea.y > 0)
                    {
                        //attack up to the left
                        mATK.transform.Translate(-1, 1, 0);
                    }
                    else if (meleeArea.y > -.5 && meleeArea.y < .5)
                    {
                        //shoot direcly to the left
                        mATK.transform.Translate(-1, 0, 0);
                    }
                    else if (meleeArea.y < 0)
                    {
                        //shoot down to the left
                        mATK.transform.Translate(-1, -1, 0);
                    }
                }
                else if (meleeArea.x > -.5 && meleeArea.x < .5)
                {
                    if (meleeArea.y > 0)
                    {
                        //shoot directly up
                        mATK.transform.Translate(0, 1, 0);
                    }
                    else if (meleeArea.y < 0)
                    {
                        //shoot direcly down
                        mATK.transform.Translate(0, -1, 0);
                    }
                }
                else if (meleeArea.x > 0)
                {
                    if (meleeArea.y > 0)
                    {
                        //shoot up and to the right
                        mATK.transform.Translate(1, 1, 0);
                    }
                    else if (meleeArea.y > -.5 && meleeArea.y < .5)
                    {
                        //shoot directly right
                        mATK.transform.Translate(1, 0, 0);
                    }
                    else if (meleeArea.y < 0)
                    {
                        //shoot down and to the right
                        mATK.transform.Translate(1, -1, 0);
                    }
                }

                //Reset cooldown for attack
                meleeCooldown = timeBetweenMelee;
            }

            else
            {
                //reduce cooldown for melee attack
                meleeCooldown = meleeCooldown - 1;
            }
        }
    }
}
