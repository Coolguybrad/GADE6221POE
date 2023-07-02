using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;
using TMPro;
using UnityEngine;




public class DataManager : MonoBehaviour
{

    public static DataManager instance;
    public PlayFabManager pfManager;
    public TMP_Text leaderboard;
    public TMP_Text leaderboardScore;
    public TMP_Text personalRank;
    public TMP_Text personalHighScore;
    public TMP_Text personalHighLevel;
    public Canvas loginUI;
    public Canvas mainUI;
    public bool loggedIn = false;


    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null) //if else makes sure theres only one instance of the game manager
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);

        }
    }

    public void sendLeaderBoard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate> { new StatisticUpdate { StatisticName = "High Score", Value = score } }
        };


        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);


    }

    public void sendLevelLeaderBoard(int levelScore)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate> { new StatisticUpdate { StatisticName = "LevelHighScore", Value = levelScore } }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLevelLeaderboardUpdate, OnError);
    }

    private void OnError(PlayFabError e)
    {
        Debug.Log(e.GenerateErrorReport());
    }

    private void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("sent");
    }
    private void OnLevelLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("sent");
    }

    public void getLeaderBoard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "High Score",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);

    }

    public void getPersonalBestScore() 
    {
        var request = new GetLeaderboardAroundPlayerRequest
        {
            StatisticName = "High Score",
            MaxResultsCount = 1
        };
        PlayFabClientAPI.GetLeaderboardAroundPlayer(request, OnLeaderboardAroundPlayerGet, OnError);
    }

    public void getPersonalBestLevel() 
    {
        var request = new GetLeaderboardAroundPlayerRequest
        {
            StatisticName = "LevelHighScore",
            MaxResultsCount = 1
        };
        PlayFabClientAPI.GetLeaderboardAroundPlayer(request, OnLevelLeaderboardAroundPlayerGet, OnError);
    }

    private void OnLevelLeaderboardAroundPlayerGet(GetLeaderboardAroundPlayerResult result)
    {

        
        foreach (var item in result.Leaderboard)
        {
            if (item.DisplayName != null)
            {
                personalHighLevel.text = "Highest Level: " + item.StatValue;
            }
           

        }
    }

    private void OnLeaderboardAroundPlayerGet(GetLeaderboardAroundPlayerResult result)
    {
        
        foreach (var item in result.Leaderboard)
        {
            personalRank.text = "Your Rank: " + item.Position+1;
            personalHighScore.text = "High Score: " + item.StatValue;

        }
    }
    public void getLevelLeaderBoard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "LevelHighScore",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLevelLeaderboardGet, OnError);
    }


    private void OnLeaderboardGet(GetLeaderboardResult result)
    {
        leaderboard.text = "Rank\t\tID\n";
        leaderboardScore.text = "Score\n";
        foreach (var item in result.Leaderboard)
        {
            if (item.DisplayName != null)
            {
                leaderboard.text += item.Position + 1 + "\t\t" + item.DisplayName + "\n";
                leaderboardScore.text += item.StatValue + "\n";
            }
            else
            {
                leaderboard.text += item.Position + 1 + "\t" + item.PlayFabId + "\n";
                leaderboardScore.text += item.StatValue + "\n";
            }
        }
    }

    private void OnLevelLeaderboardGet(GetLeaderboardResult result)
    {

        leaderboard.text = "Rank\t\tID\n";
        leaderboardScore.text = "Level\n";
        foreach (var item in result.Leaderboard)
        {
            if (item.DisplayName != null)
            {
                leaderboard.text += item.Position + 1 + "\t\t" + item.DisplayName + "\n";
                leaderboardScore.text += item.StatValue + "\n";
            }
            else
            {
                leaderboard.text += item.Position + 1 + "\t" + item.PlayFabId + "\n";
                leaderboardScore.text += item.StatValue + "\n";
            }

        }
    }

    private void Update()
    {
        if (loginUI.gameObject.activeInHierarchy)
        {
            if (loggedIn)
            {
                loginUI.gameObject.SetActive(false);
                mainUI.gameObject.SetActive(true);
            }
        }
    }
}


