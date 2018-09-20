using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{



    private Rigidbody2D myRigidbody;
    private Animator myAnimator;

    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private Transform groundPoints;

    [SerializeField]
    private float groundRadius;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private LayerMask groundMask;

    [SerializeField]
    public bool onLadder;

    public float climbSpeed;
    public float climbVelecoty;
    private float gravityStore;


    private bool isGrounded;
    private bool facingRight;
    private bool jump;
   


    void Start()
    {
        facingRight = true;
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        gravityStore = myRigidbody.gravityScale;
    }
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        HandleMovement(horizontal);
        Flip(horizontal);
        isGrounded = Physics2D.OverlapCircle(groundPoints.position, groundRadius, groundMask);
        HandleLayers();

        


    }

    public void JumpPad(int strenght)
    {

            myRigidbody.AddForce(new Vector2(0, strenght));
            myAnimator.SetTrigger("jump");
          
    }

    private void HandleMovement(float horizontal)
    {
        myRigidbody.velocity = new Vector2(horizontal * movementSpeed, myRigidbody.velocity.y);
        myAnimator.SetFloat("speed", Mathf.Abs(horizontal));



        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            myRigidbody.AddForce(new Vector2(0, jumpForce));
            myAnimator.SetTrigger("jump");
        }

        if(onLadder)
        {
           myRigidbody.gravityScale = 0F;

            climbVelecoty = climbSpeed * Input.GetAxisRaw("Vertical");

            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, climbVelecoty);

        }

        if (!onLadder)
        {
            myRigidbody.gravityScale = gravityStore;
        }

    }
 private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundPoints.position, groundRadius);
    }
    private void HandleLayers()
    {
        if (!isGrounded)
        {
            myAnimator.SetLayerWeight(1, 1);
        }
        else
        {
            myAnimator.SetLayerWeight(1, 0);
        }
    }
}