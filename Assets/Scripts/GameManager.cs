using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool Cheats = false;
    
    // Start is called before the first frame update
    public static GameManager instance;
    private AudioManager aManager;
    public float obstacleSpawnTime = 1;
    public float bossObstacleSpawnTime = 3;
    public GameObject boss;
    public int bossSpawnThreshhold = 20;

    public int level = 1;
    public int nextLevel = 2;

    public int bossSpawnPoints = 0;
    public int pointMultiplier = 1;


    public AudioSource _audio;
    public AudioClip _clip;
    public GameObject[] obstacleArr;
    public GameObject[] bossSpawnerObstArr;
    public GameObject obstacleSpawnRight;
    public GameObject obstacleSpawnMiddle;
    public GameObject obstacleSpawnLeft;

    public GameObject floorTile;
    public float floorSpawnTime = 0.05f;
    public GameObject floorSpawner;

    public float houseSpawnTimer = 1f;
    public GameObject houseSpawnLeft;
    public GameObject houseSpawnRight;
    public GameObject houseLeft;
    public GameObject houseRight;

    public GameObject dungeonEnvironment;
    public GameObject dungeonSpawner;


    public float speed = 0.5f;
    public float distance = 1f;
    private float startY;

    public GameObject Player;

    private bool isPaused = false;



    private void Awake()
    {
        if (instance == null) //if else makes sure theres only one instance of the game manager
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        aManager = gameObject.GetComponent<AudioManager>();

    }

    public event Action onBossThresholdPassing;
    public event Action onObjectPassing;

    public void ObjectPassing() 
    {
        if (onObjectPassing != null)
        {
            onObjectPassing();
        }
    }
    public void BossThreshHoldPass() 
    {
        if (onBossThresholdPassing != null)
        {
            onBossThresholdPassing();
        }
    }


    //public event Action spawnBoss;

    private void Start()
    {

        //StartCoroutine("spawnWave");
        startY = boss.transform.position.y;
        //InvokeRepeating("spawnWave", obstacleSpawnTime, obstacleSpawnTime); //calls spawnWave method at the set intervals of obstacleSpawnTime
        Invoke("spawnWave", obstacleSpawnTime);
        Invoke("bossSpawnWave", bossObstacleSpawnTime);
        Invoke("floorspawn", floorSpawnTime);
        Invoke("buildingSpawn", houseSpawnTimer);
    }




    private void spawnWave()
    {
        if (Player.GetComponent<Score>().score < bossSpawnThreshhold || boss.GetComponent<BossMechanics>().isDead)
        {
            obstacleSpawnTime = 1;
            int rndObstacle = UnityEngine.Random.Range(0, obstacleArr.Length); //chooses an obstacle from the array of obstacles
            int rndSpawn = UnityEngine.Random.Range(0, 3); //randomizes a lane for the obstacles to spawn in

            //Player.GetComponent<Score>().score;
            if (rndObstacle == 2 || rndObstacle == 4) //if the random obstacle is the long obstacle it will only spawn in the middle lane
            {
                Instantiate(obstacleArr[rndObstacle], obstacleSpawnMiddle.transform);
            }
            else if (rndSpawn == 0)//makes sure random obstacle spawns in left lane
            {
                Instantiate(obstacleArr[rndObstacle], obstacleSpawnLeft.transform);

            }
            else if (rndSpawn == 1)//makes sure random obstacle spawns in middle lane
            {


                Instantiate(obstacleArr[rndObstacle], obstacleSpawnMiddle.transform);



            }
            else if (rndSpawn == 2)//makes sure random obstacle spawns in right lane
            {

                Instantiate(obstacleArr[rndObstacle], obstacleSpawnRight.transform);



            }
        }
        else if (Player.GetComponent<Score>().score >= bossSpawnThreshhold)
        {
            obstacleSpawnTime = 3;
            int rndObstacle = UnityEngine.Random.Range(0, obstacleArr.Length); //chooses an obstacle from the array of obstacles
            Instantiate(obstacleArr[9], obstacleSpawnMiddle.transform);

        }
        Invoke("spawnWave", obstacleSpawnTime);

    }

    private void bossSpawnWave()
    {
        if (boss.GetComponent<BossMechanics>().isSpawned)
        {

            int rndObstacle = UnityEngine.Random.Range(0, bossSpawnerObstArr.Length); //chooses an obstacle from the array of obstacles
            Instantiate(bossSpawnerObstArr[rndObstacle], obstacleSpawnRight.transform);

        }
        Invoke("bossSpawnWave", bossObstacleSpawnTime);
    }

    private void floorspawn()
    {
        Instantiate(floorTile, floorSpawner.transform);
        Invoke("floorspawn", floorSpawnTime);
    }

    private void buildingSpawn()
    {
        if (level == 1)
        {
            Instantiate(houseLeft, houseSpawnLeft.transform);
            Instantiate(houseRight, houseSpawnRight.transform);
        }
        else
        {
            Instantiate(dungeonEnvironment, dungeonSpawner.transform);
        }


        Invoke("buildingSpawn", houseSpawnTimer);
    }
    // Update is called once per frame
    void Update()
    {
        if (Cheats)
        {
            Player.GetComponent<Rigidbody>().useGravity = false;
            Player.GetComponent<CapsuleCollider>().enabled = false;
            
        }

        if (Player.GetComponent<PlayerController>().currentPickup == Pickup.pickupType.Pointboost)
        {
            pointMultiplier = 2;
        }
        else
        {
            pointMultiplier = 1;
        }

        if (!boss.GetComponent<BossMechanics>().isSpawned && instance.bossSpawnPoints > bossSpawnThreshhold)
        {
            BossThreshHoldPass();
        }

        if (boss.GetComponent<BossMechanics>().isDead)
        {
            if (boss.transform.position.y > -9)
            {
                boss.transform.Translate(Vector3.up * (-speed*2) * Time.fixedDeltaTime);
            }
            else
            {
                boss.GetComponent<BossMechanics>().isDead = false;
                boss.GetComponent<BossMechanics>().isSpawned = false;
                instance.bossSpawnPoints = 0;
            }

        }
        //StartCoroutine("spawnWave");
        if (Input.GetKeyDown(KeyCode.Q)) //when q is pressed down the time scale is set to 0
        {
            if (isPaused) //checks if the game is paused if it is it unpauses
            {
                GameObject.Find("UI").GetComponent<UIInteraction>().txtControls.text = "";
                Time.timeScale = 1;
                isPaused = false;
            }
            else  //checks if the game is not paused it pauses the game
            {
                GameObject.Find("UI").GetComponent<UIInteraction>().txtControls.text = "Up arrow - jump\nDown arrow - fast fall\nLeft arrow - move left\nRight arrow - move right\n D - punch right\n A - punch left";
                Time.timeScale = 0;
                isPaused = true;
            }

        }

    }




    public void playAudio()
    {

        aManager.ReturnAudio();
    }


}
