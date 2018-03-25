using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController: MonoBehaviour {

    public static PlayerController player;
    private bool wait;
    public float moveSpeed;
    private float horizMoveVelocity, vertMoveVelocity, shootHoriz, shootVert;
    private Rigidbody2D playerRigidBody;
    public BulletController bullet;
    private float offset = 1.15f;
    private Vector3 shootPos;
    public Transform key;
    public bool eastSideCryo, westSideCryo, southSideCryo, hubRoom, hasKey;
    private SpriteRenderer parentSprite;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (player == null)
        {
            DontDestroyOnLoad(gameObject);
            player = this;
        }
        else if (player != this)
        {
            Destroy(gameObject);
        }

    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode = LoadSceneMode.Single)
    {
        if (hubRoom)
        {
            transform.position = GameObject.FindGameObjectWithTag("Level1Spawn").transform.position;
            Debug.Log(GameObject.FindWithTag("Level1Spawn"));
            hubRoom = false;
        }
        else if (westSideCryo)
        {
            transform.position = GameObject.Find("EastSpawn").transform.position;
            westSideCryo = false;
        }
        else if (eastSideCryo)
        {
            transform.position = GameObject.Find("WestSpawn").transform.position;
            eastSideCryo = false;
        }
        else if (southSideCryo)
        {
            transform.position = GameObject.Find("SouthSpawn").transform.position;
            southSideCryo = false;
        }
    }

    // Use this for initialization
    void Start () {
        wait = false;
        playerRigidBody = GetComponent<Rigidbody2D>();
        hubRoom = false;
        hasKey = false;
        eastSideCryo = false;
        westSideCryo = false;
        southSideCryo = false;
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

        if (hasKey)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                key.parent = null;
                hasKey = false;
            }
                
        }
    }
    
    void ShotBullet()
    {
        wait = false;
    }
}


