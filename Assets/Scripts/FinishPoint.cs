﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    //The player
    public GameObject player;
    //The timer object
    public GameObject timer;

	// Use this for initialization
	void Start ()
    {
		if (player.GetComponent<PlayerController>() == null)
        {
            Debug.Log("Player not put into FinishPoint script");
        }

        if (timer.GetComponent<Timer>() == null)
        {
            Debug.Log("FinishPointScript lacks a timer with the Timer script");
        }
	}

    void OnTriggerEnter()
    {
        //Disables player movement and the timer countdown
        player.GetComponent<PlayerController>().enabled = false;
        timer.GetComponent<Timer>().enabled = false;
        Debug.Log("Game Finished");
    }
}
