using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour {
    //private RigidBody2D rawr;
    // Use this for initialization
    public float velocityX = 0;
    public float velocityY = 0;
    public Camera camera;
    private bool played = false;

	// Update is called once per frame
	void Update () {
        if (gameObject.GetComponent<SpriteRenderer>().isVisible)
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(velocityX, velocityY);
        if (Camera.main.WorldToViewportPoint(transform.position).x < 1f) {
            if (played == false) {
                gameObject.GetComponent<AudioSource>().PlayOneShot(gameObject.GetComponent<AudioSource>().clip);
                played = true;
            }
        }
        if (Camera.main.WorldToViewportPoint(transform.position).x < 0f) {
            Destroy(gameObject);
        }
	}
}
