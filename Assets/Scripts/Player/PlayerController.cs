using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public InputManager myInputManager;
    public InputManager.ButtonName jumpButton;
    [HideInInspector]

    public Animator myAnimator;
    [HideInInspector]
    public bool facingRight = true;         // For determining which way the player is currently facing.
    [HideInInspector]
    public bool jump = false;               // Condition for whether the player should jump.
    public float moveForce = 365f;          // Amount of force added to move the player left and right.
    public float maxSpeed = 5f;             // The fastest the player can travel in the x axis.
    public AudioClip[] jumpClips;           // Array of clips for when the player jumps.
    //public float jumpForce = 1000f;			// Amount of force added when the player jumps.
    public float normalJumpForce = 1500f;

    private bool grounded = false;          // Whether or not the player is grounded.
    private Transform groundCheck;

    void Awake()
    {
        //myAnimator = gameObject.GetComponentInChildren<Animator>();
        myInputManager = gameObject.GetComponent<InputManager>();
        groundCheck = transform.Find("groundCheck");
    }


    void Update()
    {
        // The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        // If the jump button is pressed and the player is grounded then the player should jump.
        if (myInputManager.GetButtonDown(jumpButton) && grounded)
            jump = true;
    }


    void FixedUpdate()
    {

        // Cache the horizontal input.
        float h = myInputManager.GetAxis("Horizontal");

        // The Speed animator parameter is set to the absolute value of the horizontal input.
        if (grounded)
        {
            if (myAnimator != null)
                myAnimator.SetFloat("Velocity", Mathf.Abs(h));
        }
        else
        {
            if (myAnimator != null)
                myAnimator.SetFloat("Velocity", 0);
        }
        // If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
        if (h * GetComponent<Rigidbody2D>().velocity.x < maxSpeed)
        {
            if (grounded == false)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * moveForce);

            }
            else
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * moveForce);
            }
        }


        // If the player's horizontal velocity is greater than the maxSpeed...
        if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > maxSpeed && grounded == true)
        {
            // ... set the player's velocity to the maxSpeed in the x axis.
            GetComponent<Rigidbody2D>().velocity = (new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * maxSpeed, GetComponent<Rigidbody2D>().velocity.y));
        }
        // If the input is moving the player right and the player is facing left...
        if (h > 0 && transform.localScale.x < 0)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

        // Otherwise if the input is moving the player left and the player is facing right...
        else if (h < 0 && transform.localScale.x > 0)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

        if (transform.localScale.x > 0)
        {
            facingRight = true;

        }
        else
        {
            facingRight = false;
        }
        // If the player should jump...
        if (jump)
        {
            doJump();
            // Make sure the player can't jump again until the jump conditions from Update are satisfied.

        }
    }

    public void doJump()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, normalJumpForce));
        jump = false;
        //return;

        /*if (remaningForce <= 0)
        {
            jump = false;
        }*/
    }

    void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
