using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    //The player
    public GameObject player;
    //The timer object
    public GameObject timer;
    //The level passed menu
    public GameObject levelPassed;

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
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            if (player == null)

                Debug.Log("THIS IS NULL!");

            //Disables player movement and the timer countdown
            //Debug.Log("RAAWR");
            //player.GetComponent<PlayerController>().GameOver();
            //Debug.Log("RAAWR2");
            player.GetComponent<PlayerController>().enabled = false;

            int score = (int) timer.GetComponent<Timer>().GetSecondsToComplete() * 100;
            HighScore.Instance.PutScore("Player", score);
            timer.GetComponent<Timer>().enabled = false;

            levelPassed.SetActive(true);
            //Debug.Log("Game Finished");
        }
    }
}
