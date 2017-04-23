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

    EdgeCollider2D rightEdge;

    private float vertical;

    // Use this for initialization
    void Start()
    {
        charControl = gameObject.GetComponent<CharacterController>();
        rBody = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        vertical = 0;
        horizSpeed = 4f;

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector2 boxColliderEnd = boxCollider.bounds.size / 1.99999F;
        Debug.DrawRay((Vector2)transform.position + boxColliderEnd, Vector2.right);
        if (Physics2D.Raycast((Vector2)transform.position + boxColliderEnd, Vector2.right, 0.75F).collider != null)
        {
            rBody.velocity = new Vector2(0, rBody.velocity.y);
        }
        else if (Physics2D.Raycast((Vector2)transform.position - boxColliderEnd, Vector2.right, 0.75F).collider != null)
        {
            rBody.velocity = new Vector2(0, rBody.velocity.y);
        }
        else
        {
            rBody.velocity = new Vector2(horizSpeed, rBody.velocity.y);
        }
        //Debug.Log(Physics2D.Raycast((Vector2)transform.position, Vector2.down, 0.1F).collider);//.gameObject);
        /*if (Physics2D.Raycast((Vector2)transform.position, Vector2.down, 0.75F).collider == null)
            Debug.Log("RAWR");
        else
        {
            Debug.Log("grounded");
        }*/
        vertical = Input.GetAxis("Vertical");
        //If player pressed jump key (up/w) and the player is grounded (Raycast checks if they are close enough to the ground)
        if (vertical > 0.1 && Physics2D.Raycast((Vector2)transform.position, Vector2.down, 0.75F).collider != null)
        {
            //Debug.Log(Physics2D.Raycast((Vector2)transform.position, Vector2.down, 0.75F).collider);
            //Debug.Log( "jump" );
            //isJumping = true;
            anim.SetBool("isJumping", true);
            //Debug.Log("isJumping");
            boxCollider.size = new Vector2(boxCollider.size.x, .8f);
            boxCollider.offset = new Vector2(0.0f, 0.1f);
            jumpStart = (Vector2)transform.position;
            Jump(jumpStart);
        }
        //Player is not jumping
        else if (vertical <= 0.1 && Physics2D.Raycast((Vector2)transform.position, Vector2.down, 0.75F).collider != null)
        {
            //Debug.Log(Physics2D.Raycast((Vector2)transform.position, Vector2.down, 0.75F).collider);
            anim.SetBool("isJumping", false);
            boxCollider.size = new Vector2(boxCollider.size.x, 1.4f);
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
    void Jump(Vector2 start)
    {
        //Debug.Log("JUMPING");
        //rBody.MovePosition(transform.position + (Vector3.right * horizSpeed) * Time.deltaTime );
        rBody.AddForce(new Vector2(0, 180));  //180
    }

    //Switches the player's animation when the game is over
    public void GameOver()
    {
        anim.SetBool("GameOver", true);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hazards")
        {
            Debug.Log("DAMAGED");
            anim.SetBool("damaged", true);
            horizSpeed = 2.5f;
            StartCoroutine("damageEnd");
        }
    }

    IEnumerator damageEnd()
    {
        yield return new WaitForSeconds(0.75f);
        anim.SetBool("damaged", false);
        horizSpeed = 4f;
    }
}
