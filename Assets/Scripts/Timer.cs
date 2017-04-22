using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //The timer text
    //public GameObject timer;
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
            player.GetComponent<PlayerController>().enabled = false;
            gameObject.GetComponent<Text>().text = "0";
            Debug.Log("Level failed");
            this.enabled = false;
        }
        else
        {
            secondsToComplete -= Time.deltaTime;
            gameObject.GetComponent<Text>().text = secondsToComplete.ToString();
        }
	}
}
