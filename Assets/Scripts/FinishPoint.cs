using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start ()
    {
		if (player.GetComponent<PlayerController>() == null)
        {
            Debug.Log("Player not put into FinishPoint script");
        }
	}

    void OnTriggerEnter()
    {
        player.GetComponent<PlayerController>().enabled = false;
        Debug.Log("Game Finished");
    }
}
