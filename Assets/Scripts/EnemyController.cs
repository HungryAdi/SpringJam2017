using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private float speed;
    private Rigidbody rbody;
    private SpriteRenderer sprite;
    private BoxCollider boxCollider;

	// Use this for initialization
	void Start () {
        speed = 1.9f;
        rbody = gameObject.GetComponent<Rigidbody>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        boxCollider = gameObject.GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {
        MoveRight();
    }

    void MoveRight()
    {
        rbody.MovePosition(transform.position + (Vector3.right * speed) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            sprite.color = new Color(125, 125, 125, 125);
        } 
    }
}
