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
        btnRestart.onClick.AddListener(restart);
    }

    // Update is called once per frame
    void Update()
    {
        txtScore.text = "Score: " + player.GetComponent<Score>().score;
        //finalScore = player.GetComponent<Score>().score;
        if (player.transform.position.y < 0f)
        {
            txtFinalScore.text = "Final Score: " + player.GetComponent<Score>().score;
        }
        //.text = "Score: " + player.GetComponent<Score>().score;

    }

    private void restart() 
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
}
