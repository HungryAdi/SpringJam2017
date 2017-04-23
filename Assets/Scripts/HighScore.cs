using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour {


    public static HighScore Instance;
    string[] playerNames;
    public int[] hiScores;
    string leaderCode;
    

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
            leaderCode = "Leader" + i;
            hiScores[i] = PlayerPrefs.GetInt(leaderCode);
            playerNames[i] = PlayerPrefs.GetString(leaderCode);
        }
	}

    int PutScore(string name, int score)
    {
        int position = -1;
        int tempScore;
        for(int i=0; i<5; i++)
        {
            if (score > hiScores[position])
            {
                position = i;
            }
            if (position != -1)
            {
                tempScore = hiScores[position];
                hiScores[position] = score;
                score = tempScore;
            }
        }
        return position;
    }

    int CheckScore(int score)
    {
        for (int i = 0; i < 5; i++)
            if (score > hiScores[i])
                return i;
        return -1;
    }

    void SaveScore()
    {
        for(int i=0; i<5; i++)
        {
            leaderCode = "Leader" + i;
            PlayerPrefs.SetString(leaderCode, playerNames[i]);
            PlayerPrefs.SetInt(leaderCode,hiScores[i]);
        }
        PlayerPrefs.Save();
    }

    void ResetScore()
    {
        for (int i = 0; i < 5; i++)
        {
            playerNames[i] = "Player " + (i + 1);
            hiScores[i] = 0;
        }
    }
}
