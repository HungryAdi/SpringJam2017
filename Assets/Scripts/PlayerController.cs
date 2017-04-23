using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //How high can the player jump?
    public float jumpHeight;
    //How fast does the player move horizontally?
    public float horizSpeed;
    //How fast does the player move vertically?
    public float vertSpeed;

    //Is the player jumping?
    private bool isJumping;
    //Keeps track of the position where the player's jump started - used for jump height
    private Vector3 jumpStart;

    //Use CharacterController?  Or Rigidbody for physics?
    private CharacterController charControl;
    //Player's rigidbody
    private Rigidbody2D rBody;
    //Player's animator
    private Animator anim;
    //Player's boxcollider
    private BoxCollider2D boxCollider;
    private bool grounded;

    private float vertical;

    // Use this for initialization
    void Start ()
    {
        charControl = gameObject.GetComponent<CharacterController>();
        rBody = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        vertical = 0;
        
    }
	
	// Update is called once per frame
    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        rBody.velocity = new Vector2(2, rBody.velocity.y);
        //Debug.Log(Physics2D.Raycast((Vector2)transform.position, Vector2.down, 0.1F).collider.gameObject);
        if (Physics2D.Raycast((Vector2)transform.position, Vector2.down, 0.75F).collider == null)
            Debug.Log("RAWR");
        vertical = Input.GetAxis( "Vertical" );
        //If player pressed jump key (up/w) and the player is grounded (Raycast checks if they are close enough to the ground)
        if (vertical > 0.1 && Physics2D.Raycast((Vector2)transform.position, Vector2.down, 0.75F).collider != null)
        {
            //Debug.Log( "jump" );
            //isJumping = true;
            anim.SetBool("isJumping", true);
            Debug.Log("isJumping");
            boxCollider.size = new Vector2(boxCollider.size.x, .8f);
            boxCollider.offset = new Vector2(0.0f, 0.1f);
            jumpStart = (Vector2)transform.position;
            Jump( jumpStart );
        }
        //Player is not jumping
        else if (vertical <= 0.1 && Physics2D.Raycast((Vector2)transform.position, Vector2.down, 0.75F).collider != null)
        {
            anim.SetBool("isJumping", false);
            boxCollider.size = new Vector2(boxCollider.size.x, 1.0f);
            boxCollider.offset = new Vector2(0.0f, 0.0f);
            //rBody.MovePosition((Vector2)transform.position + (Vector2.right * horizSpeed) * Time.deltaTime);
        }
        else
        {
            //"Gravity" will take over, bringing the character back down.
            //rBody.MovePosition( (Vector2)transform.position + (Vector2.right * horizSpeed) * Time.deltaTime );
        }
        vertical = 0.1f;
    }

    //Rudimentary jump mechanics - may change
    void Jump( Vector2 start )
    {
        Debug.Log("JUMPING");
        //rBody.MovePosition(transform.position + (Vector3.right * horizSpeed) * Time.deltaTime );
        rBody.AddForce(new Vector2(0, 200));
    }

    //Switches the player's animation when the game is over
    public void GameOver()
    {
        anim.SetBool("GameOver", true);
    }
}
