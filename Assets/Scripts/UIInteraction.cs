using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIInteraction : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;
    public TMP_Text txtScore;
    public TMP_Text txtPickup;
    public Button btnRestart;
    public TMP_Text txtFinalScore;
    public int finalScore;
    void Start()
    {
        
    }

    private void Awake()
    {
        btnRestart.onClick.AddListener(restart); //whenever the restart button is pressed restart is called
    }

    // Update is called once per frame
    void Update()
    {
        txtScore.text = "Score: " + player.GetComponent<Score>().score; //updates the score on the onscreen gui
        //finalScore = player.GetComponent<Score>().score;
        if (player.transform.position.y < 0f) //if the player is below 0 on the y position that means they have died and a final score will be displayed
        {
            txtFinalScore.text = "Final Score: " + player.GetComponent<Score>().score;
        }
        //.text = "Score: " + player.GetComponent<Score>().score;

    }

    private void restart() 
    {
        Time.timeScale = 1; //sets time back to normal
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name); //scene is restarted
    }
}
