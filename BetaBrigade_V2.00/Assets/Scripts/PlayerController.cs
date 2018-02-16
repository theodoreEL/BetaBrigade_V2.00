using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour {

    public float moveSpeed;
    private bool wait;
    private float horizMoveVelocity;
    private float vertMoveVelocity;
    private Rigidbody2D playerRigidBody;
    //public Transform firePosition;
    public BulletController bullet;
    public Transform bulletProj;
    private float shootHoriz;
    private float shootVert;
    private float offset = 1.15f;
    private Vector3 shootPos;
    //Vector2 prevDir = Vector2.right;

    public float knockback;
    public float knockbackLength;
    public float knockbackCount;
    private Vector3 hitLocation;

    // This creates the multiple characters. The 3 we decided to start with are the artist, boombox, and segway squid
    GameObject artist, boomBox, segway, eighty, snek;
    int characterselect;
    int cooldown;

    private void Awake()
    {
        cooldown = 0;
        characterselect = 1;
        artist = GameObject.Find("artistCharacter"); // The artist character
        boomBox = GameObject.Find("boomBoxCharacter"); // The boombox character
        segway = GameObject.Find("segwaySquid"); // The segway character
        eighty = GameObject.Find("nerfGun"); // The eighty's guy character
        snek = GameObject.Find("snakeGunner"); // The snake with a gun
    }

    // Use this for initialization
    void Start () {
        wait = false;
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        //Movement: sets moveVelocity of horizontal and vertical movement to 0 each update, unless WASD keys are pressed, then sets them to movespeed
        //and makes playerRigidbody velocity equal to velocity given by specific key pressed

        horizMoveVelocity = 0f;
        vertMoveVelocity = 0f;

        if (Input.GetKey(KeyCode.D))
        {
            horizMoveVelocity = moveSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            horizMoveVelocity = -moveSpeed;
        }

        if (Input.GetKey(KeyCode.W))
        {
            vertMoveVelocity = moveSpeed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            vertMoveVelocity = -moveSpeed;
        }

        if (knockbackCount <= 0)
            playerRigidBody.velocity = new Vector2(horizMoveVelocity, vertMoveVelocity);
        else
        {

        }

        shootHoriz = Input.GetAxisRaw("FireHoriz");
        shootVert = Input.GetAxisRaw("FireVert");
        bullet.direction = new Vector2(shootHoriz, shootVert);
        shootPos = new Vector3(transform.position.x + offset * shootHoriz, transform.position.y + offset * shootVert, 0);
        if ((shootHoriz != 0 || shootVert != 0) && !wait)
        {
            wait = true;
            Instantiate(bullet, shootPos, transform.rotation);
            Invoke("ShotBullet", .1f);

        }
    }

    void Update()
    {
        // A cooldown tier for swithcing characters.
        if (cooldown > 0)
        {
            cooldown--;
        }

        // Increments the character number using the Jump button which is the Space Bar
        if (Input.GetButtonDown("Jump"))
        {
            if (characterselect == 1 && cooldown < 1)
            {
                characterselect = 2;
                cooldown = 300;
            }
            else if (characterselect == 2 && cooldown < 1)
            {
                characterselect = 3;
                cooldown = 300;
            }
            else if (characterselect == 3 && cooldown < 1)
            {
                characterselect = 4;
                cooldown = 300;
            }
            else if (characterselect == 4 && cooldown < 1)
            {
                characterselect = 5;
                cooldown = 300;
            }
            else if (characterselect == 5 && cooldown < 1)
            {
                characterselect = 1;
                cooldown = 300;
            }

        }
        // Sets the character based on the value of characterselect
        if (characterselect == 1)
        {
            artist.SetActive(true);
            snek.SetActive(false);
            segway.SetActive(false);
            eighty.SetActive(false);
            boomBox.SetActive(false);
        }
        else if (characterselect == 2)
        {
            artist.SetActive(false);
            boomBox.SetActive(true);
            snek.SetActive(false);
            eighty.SetActive(false);
            segway.SetActive(false);

        }
        else if (characterselect == 3)
        {
            boomBox.SetActive(false);
            segway.SetActive(true);
            artist.SetActive(false);
            eighty.SetActive(false);
            snek.SetActive(false);
        }
        else if (characterselect == 4)
        {
            segway.SetActive(false);
            eighty.SetActive(true);
            artist.SetActive(false);
            snek.SetActive(false);
            boomBox.SetActive(false);
        }
        else if (characterselect == 5)
        {
            eighty.SetActive(false);
            snek.SetActive(true);
            artist.SetActive(false);
            boomBox.SetActive(false);
            segway.SetActive(false);
        }
    }

    void ShotBullet()
    {
        wait = false;
    }
}


