using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //The timer text
    public GameObject timer;
    //The player
    public GameObject player;

    //The number of seconds the player has to complete the level
    public float secondsToComplete;

	// Use this for initialization
	void Start ()
    {
		if ( player.GetComponent<PlayerController>() == null)
        {
            Debug.Log("Timer script lacks a player with PlayerController");
        }

        if ( timer.GetComponent<Text>() == null)
        {
            Debug.Log("Timer script lacks a timer with Text (UI)");
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (secondsToComplete <= 0)
        {
            player.GetComponent<PlayerController>().enabled = false;
            Debug.Log("Level failed");
        }
        else
        {
            secondsToComplete -= Time.deltaTime;
            timer.GetComponent<Text>().text = secondsToComplete.ToString();
        }
	}
}
