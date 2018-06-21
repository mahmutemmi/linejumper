using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CavemanScript : MonoBehaviour {

    public float maxSpeed = 8f;
    private bool facingRight = true;
    public float jumpForce = 700f;
    Rigidbody2D cavemanRigidBody;
    Animator anim;
    bool grounded = false;
    bool doubleJump = false;
    bool jump = false;

    float groundRadius = 0.2f;
    public Transform groundCheck;
    public LayerMask whatIsGround;


    void Start()
    {
        cavemanRigidBody = this.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        if(grounded)
        {
            doubleJump = false;
        }
        //float move = Input.GetAxis("Horizontal");
        float move = 1f;

        anim.SetFloat("speed", Mathf.Abs(move));

        cavemanRigidBody.velocity = new Vector2(maxSpeed*move, cavemanRigidBody.velocity.y);

        if((grounded || !doubleJump) && jump)
        {
            cavemanRigidBody.velocity = new Vector2(cavemanRigidBody.velocity.x, 0);
            cavemanRigidBody.AddForce(new Vector2(0, jumpForce));
            if (!doubleJump && !grounded)
            {
                doubleJump = true;
            }
            jump = false;
        }

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void Update()
    {
        if((grounded || !doubleJump) && Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
    }
}
