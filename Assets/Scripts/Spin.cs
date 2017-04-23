using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Spin : MonoBehaviour {

    public float speed = 400;
    public bool clockwise;
    public string[] xyz;

	// Use this for initialization
	void Start () {
        //clockwise = false;
	}
	
	// Update is called once per frame
	void Update () {
        foreach(string item in xyz)
        {
            Debug.Log(item);
        }

        if (clockwise)
        {
            if (xyz.Contains("x"))
            {
                transform.Rotate(new Vector3(-(speed * Time.deltaTime), 0, 0));
            }
            if (xyz.Contains("y"))
            {
                transform.Rotate(new Vector3(0, -(speed * Time.deltaTime), 0));
            }
            if (xyz.Contains("z"))
            {
                transform.Rotate(new Vector3(0, 0, -(speed * Time.deltaTime)));
            }


        }
        else
        {
            if (xyz.Contains("x"))
            {
                transform.Rotate(new Vector3((speed * Time.deltaTime), 0, 0));
            }
            if (xyz.Contains("y"))
            {
                transform.Rotate(new Vector3(0, (speed * Time.deltaTime), 0));
            }
            if (xyz.Contains("z"))
            {
                transform.Rotate(new Vector3(0, 0, (speed * Time.deltaTime)));
            }
        }

    }
}
