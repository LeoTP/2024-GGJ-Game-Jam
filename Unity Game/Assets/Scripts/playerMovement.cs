using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    //VARIABLES - floats - 7.0, 6.3, bool - T or F, integers - 1,2,3
    private float moveInput; //to controll the movement of the player
    private Rigidbody2D rb; //Responsible for movement
    [SerializeField] float moveSpeed; //How fast can the player go
    private bool facingRight; //Responsible for changing the players direction right or left

    public GameObject spriteChild;
    public bool isGrounded;
    public KeyCode jump;
    public Transform groundChecker;
    [SerializeField] float radius;
    public LayerMask WhatIsGround;
    [SerializeField] float jumpForce;//NEW
    [SerializeField] Animator anim;//NEW!



    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundChecker.position, radius, WhatIsGround);
    }

    //Updates during a physics change rather than frame by frame like Update()
    void FixedUpdate()//NEW!
    {
        moveInput = Input.GetAxis("Horizontal");
        //check change here for animation
        if (isGrounded)
        {
            anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        }
        
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);


        if(facingRight == true && moveInput > 0)
        {
            Flip();
        }
        else if(facingRight == false && moveInput < 0)
        {
            Flip();
        }

        //Check button for when player is jumping
        if (Input.GetKey(jump)&& isGrounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);//NEW!
        }

    }



    void Flip()
    {
        facingRight = !facingRight;

        Vector3 rotation = transform.eulerAngles;
        rotation.y = facingRight ? 275f : 95f;  // Set Y rotation to 275 when facing right, and 95 when facing left
        transform.eulerAngles = rotation;
    }

}
