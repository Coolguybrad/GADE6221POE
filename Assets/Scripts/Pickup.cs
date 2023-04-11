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



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (pickup.transform.position.z < -50f)
        {
            Destroy(pickup);
        }
        pickup.transform.Translate(Vector3.back * speed * Time.fixedDeltaTime);

    }
}
