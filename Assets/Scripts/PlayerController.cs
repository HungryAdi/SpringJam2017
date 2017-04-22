using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //How high can the player jump?
    public float jumpHeight;

    //Is the player jumping?
    private bool isJumping;
    //Can the player jump?
    private bool canJump;
    //Keeps track of the position where the player's jump started - used for jump height
    private Vector3 jumpStart;

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
            //If player pressed jump key (up/w)
            if (vertical > 0.1 && canJump)
            {
                Debug.Log( "jump" );
                isJumping = true;
                jumpStart = transform.position;
                Jump( jumpStart );
                canJump = false;
            }
            //Player is not jumping
            else
            {
                charControl.Move(Vector3.down * Time.deltaTime);

                if (Physics.Raycast(transform.position, Vector3.down, 1))
                {
                    canJump = true;
                }
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
            charControl.Move(Vector3.up * Time.deltaTime);
        }
        else
        {
            isJumping = false;
        }
    }
}
