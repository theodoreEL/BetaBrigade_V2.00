using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaManagment : MonoBehaviour
{
    // Create variables
    public float maxPlayerMana = 10;
    public float minPlayerMana = 0;
    public static float playerMana;
    public Slider manaBar;

    // Use this for initialization
    void Start()
    {
        playerMana = 6;
        manaBar = GetComponent<Slider>();

    }

    // Update is called once per frame
    void Update()
    {
        if (playerMana > maxPlayerMana)
        {
            playerMana = maxPlayerMana;
        }
        if (playerMana < 0)
        {
            playerMana = 0;
        }

        manaBar.value = playerMana;
    }

    public static void UseMana(int manaUsed)
    {
        playerMana -= manaUsed;
    }
}
