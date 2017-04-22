using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //The player
    public GameObject player;
    //The finish point
    public GameObject finishPoint;
    //The menu
    public GameObject failedLevel;

    //The number of seconds the player has to complete the level
    public float secondsToComplete;

	// Use this for initialization
	void Start ()
    {
        //Debug stuff...
		if ( player.GetComponent<PlayerController>() == null)
        {
            Debug.Log("Timer script lacks a player with PlayerController");
        }

        if (finishPoint.GetComponent<FinishPoint>() == null)
        {
            Debug.Log("Timer script lacks a finish point with FinishPoint");
        }

        if ( gameObject.GetComponent<Text>() == null)
        {
            Debug.Log("Timer script needs to be attached to an object with Text (UI)");
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (secondsToComplete <= 0)
        {
            player.GetComponent<PlayerController>().GameOver();
            player.GetComponent<PlayerController>().enabled = false;
            finishPoint.GetComponent<FinishPoint>().enabled = false;
            gameObject.GetComponent<Text>().text = "00:00";
            failedLevel.SetActive(true);
            Debug.Log("Level failed");
            this.enabled = false;
        }
        else
        {
            secondsToComplete -= Time.deltaTime;
            int min = (int)secondsToComplete / 60;
            int seconds = (int) secondsToComplete % 60;
            //gameObject.GetComponent<Text>().text = secondsToComplete.ToString();
            gameObject.GetComponent<Text>().text = min.ToString("00") + ":" + seconds.ToString("00");
        }
	}
}
