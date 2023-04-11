using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance;
    private AudioManager aManager;
    public float obstacleSpawnTime = 5;

    public GameObject [] obstacleArr;
    public GameObject obstacleSpawnRight;
    public GameObject obstacleSpawnMiddle;
    public GameObject obstacleSpawnLeft;

    

    private void Awake()
    {
        if (instance == null)
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
        InvokeRepeating("spawnWave", obstacleSpawnTime, obstacleSpawnTime);
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
        int rndObstacle = Random.Range(0, obstacleArr.Length);
        int rndSpawn = Random.Range(0, 3);
        if (rndSpawn == 0)
        {
            Instantiate(obstacleArr[rndObstacle], obstacleSpawnRight.transform);
            
        }
        else if (rndSpawn == 1)
        {
            Instantiate(obstacleArr[rndObstacle], obstacleSpawnMiddle.transform);
            
        }
        else if (rndSpawn == 2)
        {

            Instantiate(obstacleArr[rndObstacle], obstacleSpawnRight.transform);
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        //StartCoroutine("spawnWave");


    }

    

    
    public void playAudio()
    {
        aManager.ReturnAudio();
    }

    
}
