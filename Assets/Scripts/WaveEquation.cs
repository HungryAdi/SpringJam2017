using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEquation : MonoBehaviour
{
    //Will move an object in a wave-like pattern

    //x distance the object will travel before being destroyed
    public float maxXDistance;
    //Amplitude of wave movement
    public float amplitude;

    //Point at which the object started moving
    private Vector3 startPos;
    //The wave attack's rigidbody
    private Rigidbody2D rBody;

    //used to reverse the wave's path
    int reverse;

	// Use this for initialization
	void Start ()
    {
        rBody = gameObject.GetComponent<Rigidbody2D>();

        startPos = transform.position;

        reverse = 1;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float yMovement = Mathf.Sin(transform.position.x -startPos.x) * amplitude;

        rBody.MovePosition(transform.position + ((reverse * Vector3.left) + (yMovement * Vector3.up)) * Time.deltaTime);
        if (Mathf.Abs(transform.position.x - startPos.x) > maxXDistance)
        {
            reverse = -reverse;
            startPos = transform.position;
        }
	}

    /*void OnTriggerEnter (Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Destroy(gameObject);
        }
    }*/
}
