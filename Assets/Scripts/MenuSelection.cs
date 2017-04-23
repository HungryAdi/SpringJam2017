using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSelection : MonoBehaviour {
    GameObject[] mainMenuButtons;
    GameObject[] leaderboardButtons;
    GameObject leaderboardPanel;
    int selectionTarget = 0;
    int selectionTarget2 = 0;
    string playerName, hiScore;

    int p1, p2, p3, p4, p5 = 0;
    

    // Use this for initialization
    void Start () {
        mainMenuButtons = new GameObject[3];
        mainMenuButtons[0] = GameObject.Find("NewGameHighlight");
        mainMenuButtons[1] = GameObject.Find("HighScoreHighlight");
        mainMenuButtons[2] = GameObject.Find("ExitGameHighlight");

        leaderboardButtons = new GameObject[2];
        leaderboardButtons[0] = GameObject.Find("OKHighlight");
        leaderboardButtons[1] = GameObject.Find("ResetHighlight");

        leaderboardPanel = GameObject.Find("LeaderboardPanelBlur");
        leaderboardPanel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        mainMenuButtons[0].SetActive(false);
        mainMenuButtons[1].SetActive(false);
        mainMenuButtons[2].SetActive(false);
        leaderboardButtons[0].SetActive(false);
        leaderboardButtons[1].SetActive(false);
        if (leaderboardPanel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (selectionTarget2 == 0)
                {
                    leaderboardPanel.SetActive(false);
                }
                else if (selectionTarget2 == 1)
                {
                    HighScore.Instance.ResetScore();
                    RefreshScore();
                }
            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                selectionTarget2 = (selectionTarget2 + 1) % 2;
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                selectionTarget2 = (selectionTarget2 + 3) % 2;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (selectionTarget == 0)
                {
                    Navigator.Instance.LoadScene("LevelSelection");
                }
                else if (selectionTarget == 1)
                {
                    leaderboardPanel.SetActive(true);
                    RefreshScore();
                    
                }
                else if (selectionTarget == 2)
                {
                    HighScore.Instance.SaveScore();
                    Navigator.Instance.LoadScene("Quit");
                }
            }
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                selectionTarget = (selectionTarget + 2) % 3;
            }
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                selectionTarget = (selectionTarget + 4) % 3;
            }
        }

        mainMenuButtons[selectionTarget].SetActive(true);
        leaderboardButtons[selectionTarget2].SetActive(true);
        
        //===== SECRET CODE === for testing high score ===
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            p1 += 100;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            p2 += 100;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            p3 += 100;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            p4 += 100;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            p5 += 100;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            HighScore.Instance.PutScore("P1", p1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            HighScore.Instance.PutScore("P2", p2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            HighScore.Instance.PutScore("P3", p3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            HighScore.Instance.PutScore("P4", p4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            HighScore.Instance.PutScore("P5", p5);
        }
        
    }
    void RefreshScore()
    {
        for (int i = 0; i < 5; i++)
        {
            playerName = HighScore.Instance.playerNames[i];
            if (HighScore.Instance.hiScores[i] == 0)
            {
                playerName = "None";
            }
            GameObject.Find("Player" + (i + 1) + "Label").GetComponent<UnityEngine.UI.Text>().text
                    = playerName;
            GameObject.Find("Player" + (i + 1) + "Score").GetComponent<UnityEngine.UI.Text>().text
                = HighScore.Instance.hiScores[i].ToString();
        }
    }
}
