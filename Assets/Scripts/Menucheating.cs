using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Menucheating : MonoBehaviour
{
    // Start is called before the first frame update
    public static Menucheating instance;

    private void Awake()
    {
        if (instance == null) //if else makes sure theres only one instance of the game manager
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);

        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
