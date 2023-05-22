using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float speed = 20f;
    [SerializeField]
    public GameObject pickup;

    public enum pickupType {Nothing, Shield, Pointboost, Moonboots};
    public pickupType pU;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (pickup.transform.position.z < -50f) //once the pickup has passed -50 on the z axis
        {
            Destroy(pickup); //pickup is destroyed
        }
        pickup.transform.Translate(Vector3.back * speed * Time.fixedDeltaTime); //moves the pickup toward the player on the z axis

    }
}
