using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private Rigidbody2D rbody;
    private SpriteRenderer sprite;
    private BoxCollider2D boxCollider;
    public bool started = false;
    public float speed = 6.8f;

	// Use this for initialization
	void Start () {
        rbody = gameObject.GetComponent<Rigidbody2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        StartCoroutine("countdownto3");
	}
	
	// Update is called once per frame
	void Update () {
        if (started)
        {
            MoveRight();
        }
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

    IEnumerator countdownto3()
    {
        yield return new WaitForSeconds(3f);
        started = true;
    }
}
