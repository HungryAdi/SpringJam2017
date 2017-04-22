using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSelection : MonoBehaviour {
    GameObject[] mainMenuButtons;
    int selectionTarget = 0;
    // Use this for initialization
    void Start () {
        mainMenuButtons = new GameObject[3];
        mainMenuButtons[0] = GameObject.Find("NewGameHighlight");
        mainMenuButtons[1] = GameObject.Find("HighScoreHighlight");
        mainMenuButtons[2] = GameObject.Find("ExitGameHighlight");
    }
	
	// Update is called once per frame
	void Update () {
        mainMenuButtons[0].SetActive(false);
        mainMenuButtons[1].SetActive(false);
        mainMenuButtons[2].SetActive(false);
         

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (selectionTarget == 0)
            {
                Navigator.Instance.LoadScene("LevelSelection");
            }
            else if (selectionTarget == 1)
            {

            }
            else if (selectionTarget == 2)
            {
                Navigator.Instance.LoadScene("Quit");
            }
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            
            selectionTarget = (selectionTarget - 1) % 3;
            Debug.Log(selectionTarget);
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectionTarget = (selectionTarget + 1) % 3;
            Debug.Log(selectionTarget);
        }

        mainMenuButtons[selectionTarget].SetActive(true);
    }
}
