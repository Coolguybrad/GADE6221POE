using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float speed = 20f; //speed of the obstacle
    [SerializeField]
    public GameObject obstacle;

    public bool isEnvironment = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        //if (obstacle.transform.position.z == -41.90001f)
        //{
        //    
        //}
        if (isEnvironment)
        {
            if (obstacle.transform.position.z < -50f)
            {
                Destroy(obstacle);
            }
        }
        else if (obstacle.transform.position.z < -41f) //once the obstacle has passed -41 on the z axis
        {

            if (GameObject.Find("Player").GetComponent<PlayerController>().currentPickup == Pickup.pickupType.Pointboost)
            {
                GameObject.Find("Player").GetComponent<Score>().score++;//players score is increased
                GameObject.Find("Player").GetComponent<Score>().score++;
                Destroy(obstacle); //obstacle is destroyed
            }
            else
            {
                GameObject.Find("Player").GetComponent<Score>().score++; //players score is increased
                Destroy(obstacle); //obstacle is destroyed
            }

        }
        obstacle.transform.Translate(Vector3.back * speed * Time.fixedDeltaTime);//moves the obstacles in the players z direction at the speed set above

    }








}
