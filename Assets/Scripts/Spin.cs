using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {

    public float speed = 400;
    public bool clockwise;
    public string xyz;

	// Use this for initialization
	void Start () {
        //clockwise = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(clockwise)
        {
            if (xyz == "x")
            {
                transform.Rotate(new Vector3(-(speed * Time.deltaTime), 0, 0));
            }
            else if (xyz == "y")
            {
                transform.Rotate(new Vector3(0, -(speed * Time.deltaTime), 0));
            }
            else if (xyz == "z")
            {
                transform.Rotate(new Vector3(0, 0, -(speed * Time.deltaTime)));
            }
            
            
        }
        else
        {
            if (xyz == "x")
            {
                transform.Rotate(new Vector3((speed * Time.deltaTime), 0, 0));
            }
            else if (xyz == "y")
            {
                transform.Rotate(new Vector3(0, (speed * Time.deltaTime), 0));
            }
            else if (xyz == "z")
            {
                transform.Rotate(new Vector3(0, 0, (speed * Time.deltaTime)));
            }
        }
        
	}
}
