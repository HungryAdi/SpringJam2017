using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private float speed;
    private Rigidbody2D rbody;
    private SpriteRenderer sprite;
    private BoxCollider2D boxCollider;

	// Use this for initialization
	void Start () {
        speed = 4.5f;
        rbody = gameObject.GetComponent<Rigidbody2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        MoveRight();
    }

    void MoveRight()
    {
        rbody.MovePosition( (Vector2)transform.position + (Vector2.right * speed) * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            sprite.color = new Color(125, 125, 125, 125);
        } 
    }
}
