using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance;
    private AudioManager aManager;
    public float obstacleSpawnTime = 5;

    public AudioSource _audio;
    public AudioClip _clip;
    public GameObject[] obstacleArr;
    public GameObject obstacleSpawnRight;
    public GameObject obstacleSpawnMiddle;
    public GameObject obstacleSpawnLeft;

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

    private void Start()
    {

        //StartCoroutine("spawnWave");
        InvokeRepeating("spawnWave", obstacleSpawnTime, obstacleSpawnTime); //calls spawnWave method at the set intervals of obstacleSpawnTime
    }



    //IEnumerator spawnWave()
    //{
    //    int rndObstacle = Random.Range(0, obstacleArr.Length);
    //    int rndSpawn = Random.Range(0,2);
    //    if (rndSpawn == 0)
    //    {
    //        Instantiate(obstacleArr[rndObstacle], obstacleSpawnRight.transform);
    //        yield return new WaitForSeconds(obstacleSpawnTime);
    //    }
    //    else if (rndSpawn == 1)
    //    {
    //        Instantiate(obstacleArr[rndObstacle], obstacleSpawnMiddle.transform);
    //        yield return new WaitForSeconds(obstacleSpawnTime);
    //    }
    //    else
    //    {
    //        Instantiate(obstacleArr[rndObstacle], obstacleSpawnRight.transform);
    //        yield return new WaitForSeconds(obstacleSpawnTime);
    //    }

    //}

    private void spawnWave()
    {
        int rndObstacle = Random.Range(0, obstacleArr.Length); //chooses an obstacle from the array of obstacles
        int rndSpawn = Random.Range(0, 3); //randomizes a lane for the obstacles to spawn in

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
    // Update is called once per frame
    void Update()
    {

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
                GameObject.Find("UI").GetComponent<UIInteraction>().txtControls.text = "Up arrow - jump\nDown arrow - fast fall\nLeft arrow - move left\nRight arrow - move right";
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
