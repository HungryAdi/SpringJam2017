using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSelection : MonoBehaviour {
    GameObject[] mainMenuButtons;
    GameObject[] leaderboardButtons;
    GameObject leaderboardPanel;
    int selectionTarget = 0;
    int selectionTarget2 = 0;

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
                    Debug.Log("Reset Leaderboard in construction...");
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
                }
                else if (selectionTarget == 2)
                {
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
    }
}
