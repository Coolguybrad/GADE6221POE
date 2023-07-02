using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public TMP_Text leaderboard;
    public Canvas leaderboardCanvas;
    public Canvas mainMenuCanvas;
    public Canvas playerMetrics;
    // Start is called before the first frame update

    private void Awake()
    {
        //if (leaderboard == null)
        //{
        //    leaderboard = GameObject.Find("txtLeaderBoard").GetComponent<TMP_Text>();
        //    leaderboardCanvas = GameObject.Find("LeaderBoard").GetComponent<Canvas>();
        //    mainMenuCanvas = GameObject.Find("MainMenu Canvas").GetComponent<Canvas>();
        //    mainMenuCanvas = GameObject.Find("PlayerMetrics").GetComponent<Canvas>();
        //}
    }
    void Start()
    {
        //if (SceneManager.GetActiveScene().name == "Main Menu")
        //{
        //    if (leaderboard == null)
        //    {
        //        leaderboard = GameObject.Find("txtLeaderBoard").GetComponent<TMP_Text>();
        //        leaderboardCanvas = GameObject.Find("LeaderBoard").GetComponent<Canvas>();
        //        mainMenuCanvas = GameObject.Find("MainMenu Canvas").GetComponent<Canvas>();
        //        mainMenuCanvas = GameObject.Find("PlayerMetrics").GetComponent<Canvas>();
        //    }
        //}

    }

    public void onBackClick()
    {
        mainMenuCanvas.gameObject.SetActive(true);
        playerMetrics.gameObject.SetActive(false);
        leaderboardCanvas.gameObject.SetActive(false);
    }
    public void onLeaderboardClick()
    {
        DataManager.instance.getLeaderBoard();
        DataManager.instance.getLevelLeaderBoard();
        mainMenuCanvas.gameObject.SetActive(false);
        leaderboardCanvas.gameObject.SetActive(true);
    }



    public void onPlayerMetricsClick()
    {
        DataManager.instance.getPersonalBestScore();
        DataManager.instance.getPersonalBestLevel();
        mainMenuCanvas.gameObject.SetActive(false);
        playerMetrics.gameObject.SetActive(true);

    }

    public void onScoreLeaderboardClick()
    {
        DataManager.instance.getLeaderBoard();
    }

    public void onLevelLeaderboardClick()
    {
        DataManager.instance.getLevelLeaderBoard();
    }

    public void onQuitClick()
    {
        Application.Quit();
    }

    public void onPlayClick()
    {
        Time.timeScale = 1; //sets time back to normal
        Menucheating.instance.gameObject.SetActive(false);
        SceneManager.LoadSceneAsync(1); //scene is restarted
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
