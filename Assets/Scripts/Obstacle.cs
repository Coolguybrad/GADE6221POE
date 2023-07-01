using System;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float speed = 20f; //speed of the obstacle
    [SerializeField]
    public GameObject obstacle;
    public GameObject player;


    public bool isEnvironment = false;

    void Start()
    {
        GameManager.instance.onObjectPassing += objectPassing;
        player = GameObject.Find("Player");
        
    }



    private void objectPassing() 
    {
        player.GetComponent<Score>().score += 1 * GameManager.instance.pointMultiplier;
        Destroy(obstacle);
    }



    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        
        if (isEnvironment)
        {
            if (obstacle.transform.position.z < -60f)
            {
                Destroy(obstacle);
            }
        }
        else if (obstacle.transform.position.z < -41f) //once the obstacle has passed -41 on the z axis
        {

            
            if (!GameManager.instance.boss.GetComponent<BossMechanics>().isSpawned || !GameManager.instance.sGoblin.GetComponent<StiffGoblin>().spawned)
            {
                GameManager.instance.bossSpawnPoints++;
            }
            player.GetComponent<Score>().score += 1 * GameManager.instance.pointMultiplier;
            Destroy(obstacle);


            //if (player.GetComponent<PlayerController>().currentPickup == Pickup.pickupType.Pointboost)
            //{
            //    player.GetComponent<Score>().score++;//players score is increased
            //    player.GetComponent<Score>().score++;
            //    Destroy(obstacle); //obstacle is destroyed
            //}
            //else
            //{
            //    player.GetComponent<Score>().score++; //players score is increased
            //    Destroy(obstacle); //obstacle is destroyed
            //}

        }
        obstacle.transform.Translate(Vector3.back * speed * Time.fixedDeltaTime);//moves the obstacles in the players z direction at the speed set above

    }








}
