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

	// Use this for initialization
	void Start ()
    {
        charControl = gameObject.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        MovePlayer();
	}

    void MovePlayer ()
    {
        float vertical = Input.GetAxis( "Vertical" );
        if ( !isJumping )
        {
            //If player pressed jump key (up/w) and the player is grounded (Raycast checks if they are close enough to the ground)
            if (vertical > 0.1 && Physics.Raycast(transform.position, Vector3.down, 0.75F))
            {
                //Debug.Log( "jump" );
                isJumping = true;
                jumpStart = transform.position;
                Jump( jumpStart );
            }
            //Player is not jumping
            else
            {
                //"Gravity" will take over, bringing the character back down.
                charControl.Move( (Vector3.down * vertSpeed + Vector3.right * horizSpeed) * Time.deltaTime);
            }
        }
        else
        {
            Jump(jumpStart);
        }
    }

    //Rudimentary jump mechanics - may change
    void Jump ( Vector3 start )
    {
        //Once the player reaches the jump height, the player will come back down
        if (transform.position.y - start.y < jumpHeight)
        {
            charControl.Move( (Vector3.up * vertSpeed + Vector3.right * horizSpeed) * Time.deltaTime);
        }
        else
        {
            isJumping = false;
        }
    }
}
