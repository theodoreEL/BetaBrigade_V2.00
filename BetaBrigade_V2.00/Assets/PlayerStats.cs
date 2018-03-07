using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	static int[,] heroStats = new int[6, 4];

	/*
	 * STRUCTURE OF ARRAY
	 * X INDEX - CHARACTERS
	 *	0 = Artist
	 *	1 = Boombox
	 *	2 = Segway Squid
	 *	3 = Nura F. Gunn
	 *	4 = Snek
	 *	5 = hero ----------REPLACE WITH NAME ONCE KNOWN
	 *	
	 *	Y INDEX - STATS
	 *	0 = speed
	 *	1 = attack
	 *	2 = health
	 *	3 = defense
	 *	
	 */

	// Use this for initialization
	void Start ()
	{

		//INITALIZE ALL THE STATS IN THE ARRAY

		//HERO 0 STATS
		heroStats[0, 0] = 0;
		heroStats[0, 1] = 0;
		heroStats[0, 2] = 0;
		heroStats[0, 3] = 0;

		//HERO 1 STATS
		heroStats[1, 0] = 0;
		heroStats[1, 1] = 0;
		heroStats[1, 2] = 0;
		heroStats[1, 3] = 0;

		//HERO 2 STATS
		heroStats[2, 0] = 0;
		heroStats[2, 1] = 0;
		heroStats[2, 2] = 0;
		heroStats[2, 3] = 0;

		//HERO 3 STATS
		heroStats[3, 0] = 0;
		heroStats[3, 1] = 0;
		heroStats[3, 2] = 0;
		heroStats[3, 3] = 0;

		//HERO 4 STATS
		heroStats[4, 0] = 0;
		heroStats[4, 1] = 0;
		heroStats[4, 2] = 0;
		heroStats[4, 3] = 0;

		//HERO 5 STATS
		heroStats[5, 0] = 0;
		heroStats[5, 1] = 0;
		heroStats[5, 2] = 0;
		heroStats[5, 3] = 0;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	
	/*
	 * PLAYER STATS
	 * STEPS TO FOLLOW:
	 * 1) figure out what charcter your are
	 * 2) find the coorisponding stats
	 * 3) set the stats to the player.
	 */ 

	public static void statChangeTo(int character)
	{
		// 1) FIGURE OUT THE CHARACTER YOU ARE BECOMING - this is done by the character being passed into the function
		int characterToBe = character;

		// 2) FIND AND SET THE STATS TO THE PLAYER DEPENDING ON NEW CHARACTER
		//process through the stats array (Y indexs) to set stats
		
		PlayerController.Character.speed = heroStats[characterToBe, 0];
		PlayerController.Character.attack = heroStats[characterToBe, 1];
		PlayerController.Character.health = heroStats[characterToBe, 2];
		PlayerController.Character.defense = heroStats[characterToBe, 3];

	}


}
