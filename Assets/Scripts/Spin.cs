using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {

    public float speed;
    public bool clockwise;

	// Use this for initialization
	void Start () {
        speed = 400;
        clockwise = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(clockwise)
        {
            transform.Rotate(Vector3.forward * speed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(Vector3.back * speed * Time.deltaTime);
        }
        
	}
}
