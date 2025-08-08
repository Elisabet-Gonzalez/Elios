using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    [SerializeField] float moveSpeed = 6.5f;
    [SerializeField] float jumpForce = 7f;

    [Range(0f, 1f)]
    [SerializeField] float drag;

    public bool isGrounded;
    public float acceleration = 1.2f;
    private int jumpCount;

    float xInput;
    float yInput;

    public BoxCollider2D coll;
    public LayerMask ground;
    

    // Update is called once per frame
    void Update()
    {
        
        GetInput();
        Jump();
    }

    private void FixedUpdate()
    {
        CheckGround();
        ApplyFriction();
        MoveWithInput();
    }
    void GetInput()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
    }

    void MoveWithInput()
    {
        if (Mathf.Abs(xInput) > 0)
        {
            float increment = xInput * acceleration;
            float newSpeed = Mathf.Clamp(rb.velocity.x + increment,-moveSpeed, moveSpeed);
            rb.velocity = new Vector2(newSpeed, rb.velocity.y);
        }

        float direction = Mathf.Sign(xInput);
        transform.localScale = new Vector3(direction, 1, 1);
    }

    void Jump()
    {

        

        if (Input.GetButtonDown("Jump") && jumpCount == 0)
        {
           
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount++;
           // Debug.Log(jumpCount);
        }
    }

    void DoubleJump()
    {
        if (isGrounded)
        {
            jumpCount = 0;
           // Debug.Log(jumpCount);
            
        }
    }

    void CheckGround()
    {
        isGrounded = Physics2D.OverlapAreaAll(coll.bounds.min, coll.bounds.max,ground).Length > 0;
        DoubleJump();
    }

    void ApplyFriction()
    {
        if (isGrounded && xInput == 0 && yInput <=0)
        {

            rb.velocity *= drag;
        }
    }
}