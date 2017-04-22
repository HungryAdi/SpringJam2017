using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //The object the camera will follow
    //Might be an empty child object of the player
    public GameObject followPoint;

    void Start()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        //The position of the point the camera follows
        Vector3 followPointPos = followPoint.transform.position;
        //Camera keeps its z position - follows x and y of the follow point
        transform.position = new Vector3( followPointPos.x, followPointPos.y, transform.position.z) ;
	}
}
