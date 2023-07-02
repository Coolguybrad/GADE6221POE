using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public TMP_Text leaderboard;
    public Canvas leaderboardCanvas;
    public Canvas mainMenuCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void onLeaderboardClick() 
    {
        DataManager.instance.getLeaderBoard();
        mainMenuCanvas.gameObject.SetActive(false);
        leaderboardCanvas.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            SceneManager.LoadScene("Main Menu");
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            SceneManager.LoadScene("Main Scene");
        }
    }
}
