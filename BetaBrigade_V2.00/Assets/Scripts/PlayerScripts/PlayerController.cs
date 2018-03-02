using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController: MonoBehaviour {

    public struct Character
    {
        public bool isActive;
        public GameObject character;
        public Sprite charSprite;
        public Character(GameObject person, bool enabled)
        {
            character = person;
            isActive = enabled;
            charSprite = person.GetComponent<SpriteRenderer>().sprite;
        }
    };

    private bool wait;
    public float moveSpeed;
    private float horizMoveVelocity, vertMoveVelocity, shootHoriz, shootVert;
    private Rigidbody2D playerRigidBody;
    public BulletController bullet;
    public Transform bulletProj;
    private float offset = 1.15f;
    private Vector3 shootPos;
    public bool hasKey = false;
    private GameObject key;
    [HideInInspector]
    public bool eastSideCryo = false;
    [HideInInspector]
    public bool westSideCryo = false;
    [HideInInspector]
    public bool southSideCryo = false;
    [HideInInspector]
    public bool switchChars = false;
    private int count = 0;
    private GameObject otherCharSpawners;

    // This creates the multiple characters. The 3 we decided to start with are the artist, boombox, and segway squid
    [HideInInspector]
    public Character[] characters = new Character[5];
    Character artist, boomBox, segway, eighty, snek;
    [HideInInspector]
    public int characterselect;
    int cooldown;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        cooldown = 0;
        characterselect = 0;
        artist = new Character(GameObject.Find("artistCharacter"), true); // The artist character
        boomBox = new Character(GameObject.Find("boomBoxCharacter"), false); // The boombox character
        segway = new Character(GameObject.Find("segwaySquid"), false); // The segway character
        eighty = new Character(GameObject.Find("nerfGun"), false); // The eighty's guy character
        snek = new Character(GameObject.Find("snakeGunner"), false); // The snake with a gun
        characters[0] = artist;
        characters[1] = boomBox;
        characters[2] = segway;
        characters[3] = eighty;
        characters[4] = snek;
    }

    //OnEnable, OnDisable, and OnLevelFinishedLoading new way for unity's old OnLevelLoad function or w/e, places player at location inside cryoroom when entering it compared to the door that they entered
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    
    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        for(int i = 0; i < characters.Length; i++)
        {
            characters[i].character.SetActive(true);
        }
        if (westSideCryo)
        {
            transform.position = GameObject.FindGameObjectWithTag("WestCryo").transform.position;
            westSideCryo = false;
        }
        if (eastSideCryo)
        {
            transform.position = GameObject.FindGameObjectWithTag("EastCryo").transform.position;
            eastSideCryo = false;
        }
        if (southSideCryo)
        {
            transform.position = GameObject.FindGameObjectWithTag("SouthCryo").transform.position;
            southSideCryo = false;
        }

        otherCharSpawners = GameObject.FindGameObjectWithTag("OtherSpawnParent");

        for (int i = 0; i < characters.Length; i++)
        {
            if (!(characters[i].isActive))
            {
                    otherCharSpawners.transform.GetChild(count).GetComponent<SpriteRenderer>().sprite = characters[count].charSprite;
                    count++;
            }
        }
        count = 0;
    }
    // Use this for initialization
    void Start () {
        wait = false;
        playerRigidBody = GetComponent<Rigidbody2D>();
        key = GameObject.FindWithTag("Pickup");

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

        playerRigidBody.velocity = new Vector2(horizMoveVelocity, vertMoveVelocity);

        if (!hasKey) //as long as character doesn't have a key, they can shoot
        {
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
    }
        

    void Update()
    {

        // A cooldown tier for switching characters.
        if (cooldown > 0)
        {
            cooldown--;
        }

        if (hasKey)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                key.transform.parent = null;
                hasKey = false;
            }
                
        }
        // Increments the character number using the Jump button which is the Space Bar
        if (Input.GetButtonDown("Jump"))
        {
            if (characterselect == 0 && cooldown < 1)
            {
                characterselect = 1;
                cooldown = 300;
            }
            else if (characterselect == 1 && cooldown < 1)
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
                characterselect = 0;
                cooldown = 300;
            }

        }

        // Sets the character based on the value of characterselect
        if (!switchChars)
        {
            for (int i = 0; i < characters.Length; i++)
            {
                if (characterselect == i)
                {
                    characters[i].character.SetActive(true);
                    characters[i].isActive = true;
                }
                else
                {
                    characters[i].character.SetActive(false);
                    characters[i].isActive = false;
                }
            }
        }
    }
    
    void ShotBullet()
    {
        wait = false;
    }
}


