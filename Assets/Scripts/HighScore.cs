using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour {


    public static HighScore Instance;
    [System.NonSerialized]
    public string[] playerNames = new string[5];
    [System.NonSerialized]
    public int[] hiScores = new int[5];
    string leaderCodeName, leaderCodeScore;
    

    // Use this for initialization
    void Awake()
    {
        if (!Instance)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        playerNames = new string[5];
        hiScores = new int[5];
    }

    

	// Use this for initialization
	void Start () {
        
		for(int i=0; i<5; i++)
        {
            leaderCodeName = "LeaderName" + i;
            leaderCodeScore = "LeaderScore" + i;
            playerNames[i] = PlayerPrefs.GetString(leaderCodeName);
            hiScores[i] = PlayerPrefs.GetInt(leaderCodeScore);
            //Debug.Log("Get>> " + leaderCodeName + ":" + playerNames[i] + " | " + leaderCodeScore + ":" + hiScores[i]);
        }
	}

    public int PutScore(string name, int score)
    {
        int position = -1;
        int tempScore;
        string tempName;
        for(int i=0; i<5; i++)
        {
            if (score > hiScores[i])
            {
                position = i;
            }
            if (position != -1)
            {
                tempScore = hiScores[i];
                hiScores[i] = score;
                score = tempScore;

                tempName = playerNames[i];
                playerNames[i] = name;
                name = tempName;
            }
        }
        return position;
    }

    public int CheckScore(int score)
    {
        for (int i = 0; i < 5; i++)
            if (score > hiScores[i])
                return i;
        return -1;
    }

    public void SaveScore()
    {
        
        for(int i=0; i<5; i++)
        {
            
            leaderCodeName = "LeaderName" + i;
            leaderCodeScore = "LeaderScore" + i;
            
            PlayerPrefs.SetString(leaderCodeName, playerNames[i]);
            PlayerPrefs.SetInt(leaderCodeScore, hiScores[i]);
            //Debug.Log("Set>> " + leaderCodeName + ":" + playerNames[i] + " | " + leaderCodeScore + ":" + hiScores[i]);
        }
        PlayerPrefs.Save();
    }

    public void ResetScore()
    {
        for (int i = 0; i < 5; i++)
        {
            playerNames[i] = "Player " + (i + 1);
            hiScores[i] = 0;
        }
        SaveScore();
    }
}
