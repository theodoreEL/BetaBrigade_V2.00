using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

    public float enemyHealth = 4f;
    public float curHealth = 4f;
    public Transform healthBar;
    private float percent;
    private float scale;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (curHealth <= 0)
            Destroy(gameObject);

	}


    public void giveDamage(int damage)
    {
        curHealth -= damage;
        percent = 1f - (curHealth / enemyHealth);
        Debug.Log(percent);
        scale = healthBar.localScale.x * percent;
        Debug.Log(scale);
        healthBar.localScale = healthBar.localScale - new Vector3(scale, 0f, 0f);
        Debug.Log(healthBar.localPosition.x);
        healthBar.localPosition = healthBar.localPosition - new Vector3(scale/2, 0f, 0f);
        Debug.Log(healthBar.localPosition.x);
    }
}
