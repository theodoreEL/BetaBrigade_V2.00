using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float speed;
    public Vector2 direction;
    public PlayerController player;
    private Rigidbody2D bullet;
    public int damageGiven = 1;
    public EnemyMovement enemy;

    private void Awake()
    {
        
    }

    // Use this for initialization
    void Start () {
        bullet = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>();
        
	}

	// Update is called once per frame
	void Update () {
        bullet.velocity = direction * speed;
        KillMeleeAttack();
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealthManager>().giveDamage(damageGiven);
            //enemy.hitLocation = transform.localPosition;
            Debug.Log(transform.localPosition);
            Destroy(gameObject);
        }
        else if (other.tag == "Destroyable")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.tag == "Projectile" || other.tag == "Pickup")
            return;
        else
            Destroy(gameObject);
    }

    void KillMeleeAttack()
    {
        if (gameObject.name == "MeleeAttackHoriz" || gameObject.name == "MeleeAttackVert")
            Destroy(gameObject, .2f);
    }

}

