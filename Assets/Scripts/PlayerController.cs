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
    private Rigidbody rBody;
    //Player's animator
    private Animator anim;

	// Use this for initialization
	void Start ()
    {
        charControl = gameObject.GetComponent<CharacterController>();
        rBody = gameObject.GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        MovePlayer();
	}

    void MovePlayer ()
    {
        float vertical = Input.GetAxis( "Vertical" );
        //If player pressed jump key (up/w) and the player is grounded (Raycast checks if they are close enough to the ground)
        if (vertical > 0.1 && Physics.Raycast(transform.position, Vector3.down, 0.75F))
        {
            //Debug.Log( "jump" );
            //isJumping = true;
            anim.SetBool("isJumping", true);
            Debug.Log("isJumping");
            jumpStart = transform.position;
            Jump( jumpStart );
        }
        //Player is not jumping
        else if (vertical <= 0.1 && Physics.Raycast(transform.position, Vector3.down, 0.75F))
        {
            anim.SetBool("isJumping", false);
            Debug.Log("isNotJumping");
            rBody.MovePosition(transform.position + (Vector3.right * horizSpeed) * Time.deltaTime);
        }
        else
        {
            //"Gravity" will take over, bringing the character back down.

            rBody.MovePosition( transform.position + (Vector3.right * horizSpeed) * Time.deltaTime );
        }
    }

    //Rudimentary jump mechanics - may change
    void Jump ( Vector3 start )
    {
        //Debug.Log("JUMPING");
        rBody.MovePosition( transform.position + (Vector3.right * horizSpeed) * Time.deltaTime );
        rBody.velocity = rBody.velocity + Vector3.up * vertSpeed;
    }
}
