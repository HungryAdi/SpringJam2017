using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeAttack : MonoBehaviour
{
    //Will the flame start out as big?
    public bool startMax;

    //The part of the spikes that scales
    GameObject spikes;
    //Whether the "spikes" are growing or retracting
    int spikeGrowth;

    Vector3 origSize;

	// Use this for initialization
	void Start ()
    {
        spikes = gameObject.transform.FindChild("Spikes").gameObject;
        origSize = Vector3.zero + spikes.transform.localScale;

        if (!startMax)
        {
            spikeGrowth = 1;
        }
        else
        {
            spikeGrowth = -1;
            spikes.transform.localScale = new Vector3 (origSize.x, 2 * origSize.y, origSize.z);
        }

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
            spikeGrowth = -spikeGrowth;
            if (spikeGrowth == 1)
            {
                spikes.transform.localScale = origSize;
            }
            else
            {
                spikes.transform.localScale = new Vector3(origSize.x, 2 * origSize.y, origSize.z);
            }
            //spikes.transform.localScale += new Vector3(0, 1, 0) * spikeGrowth;
            yield return new WaitForSeconds(1F);
            spikeGrowth = -spikeGrowth;
            if (spikeGrowth == 1)
            {
                spikes.transform.localScale = origSize;
            }
            else
            {
                spikes.transform.localScale = new Vector3(origSize.x, 2 * origSize.y, origSize.z);
            }
        }
    }
}
