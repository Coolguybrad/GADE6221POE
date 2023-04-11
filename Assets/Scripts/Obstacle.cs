using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float speed = 20f;
    [SerializeField]
    public GameObject obstacle;
    
   

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
        if (obstacle.transform.position.z < -41f)
        {
            GameObject.Find("Player").GetComponent<Score>().score++;
            Destroy(obstacle);
        }
        obstacle.transform.Translate(Vector3.back * speed * Time.fixedDeltaTime);
        
    }

    






}
