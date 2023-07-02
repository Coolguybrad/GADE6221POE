using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;
using UnityEngine;




public class DataManager : MonoBehaviour
{

    public static DataManager instance;
    public PlayFabManager pfManager;


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
        foreach (var item in result.Leaderboard)
        {
            Debug.Log(item.Position + " " + item.PlayFabId + " " + item.StatValue);
        }
    }

    private void OnLevelLeaderboardGet(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            Debug.Log(item.Position + " " + item.PlayFabId + " " + item.StatValue);
        }
    }
}


