using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeAttack : MonoBehaviour
{
    //The part of the spikes that scales
    GameObject spikes;
    //Whether the "spikes" are growing or retracting
    int spikeGrowth;


	// Use this for initialization
	void Start ()
    {
        spikes = gameObject.transform.FindChild("Spikes").gameObject;
        spikeGrowth = 1;

        IEnumerator coroutine = SpikeMovement();
        StartCoroutine(coroutine);
	}
	
	// Update is called once per frame
	void Update ()
    {
        spikes.transform.localScale += new Vector3 (0, Time.deltaTime, 0) * spikeGrowth;
	}

    IEnumerator SpikeMovement()
    {
        while(true)
        {
            yield return new WaitForSeconds(1F);
            spikeGrowth = -1;
            yield return new WaitForSeconds(1F);
            spikeGrowth = 1;
        }
    }
}
