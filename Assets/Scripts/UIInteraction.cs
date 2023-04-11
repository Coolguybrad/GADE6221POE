using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject player;

    public TMP_Text txtScore;
    public TMP_Text txtPickup;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        txtScore.text = "Score: " + player.GetComponent<Score>().score;
        
        //.text = "Score: " + player.GetComponent<Score>().score;

    }
}
