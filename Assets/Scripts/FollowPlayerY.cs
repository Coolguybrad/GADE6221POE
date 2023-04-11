using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerY : MonoBehaviour
{
    [SerializeField]
    private GameObject self;
    [SerializeField]
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        self.transform.position.Set(self.transform.position.x,player.transform.position.y,self.transform.position.z);
        
    }
}
