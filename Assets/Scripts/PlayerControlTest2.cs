using UnityEngine;
using System.Collections;

public class PlayerControlTest2 : MonoBehaviour {


    private Rigidbody2D rigid;
    public float runSpeed;
    public float jumpHeight;
    public float myGravity;

    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public float groundCheckRadius;

    private bool facingRight;

    public Animator animator;
    // Use this for initialization
    void Start () {
        rigid = this.GetComponent<Rigidbody2D>();
        rigid.gravityScale = myGravity; 

        animator = GetComponent<Animator>();
       
 
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        animator.SetBool("isGrounded", this.isGrounded);
        
    }

    public void Move()
    {


        //move right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigid.velocity = new Vector2(runSpeed, rigid.velocity.y);
            if(!facingRight)
            {
                Flip();
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigid.velocity = new Vector2(-runSpeed, rigid.velocity.y);
            if(facingRight)
            {
                Flip();
            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            //crouch
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space) && isGrounded)
        {   
            if(Input.GetKey(KeyCode.UpArrow))
            {
                print("up");
            }
            rigid.velocity = new Vector2(rigid.velocity.x, jumpHeight);
            animator.SetTrigger("Jump");
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
