using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour {

    public Vector2 direction;
    private Rigidbody2D attack;
    public PlayerController player;

    private void Awake()
    {
        Destroy(gameObject, 1f);
    }

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        attack = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        attack.velocity = direction * 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.tag == "Projectile")
            return;
        else
            Destroy(gameObject);
    }

}
