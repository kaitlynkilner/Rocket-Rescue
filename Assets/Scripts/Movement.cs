using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jump = .5f;
    private bool facingRight = true;
    // Start is called before the first frame update
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if(Input.GetButtonDown("Jump") && canJump()){
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }
        Flip();
        
    }

    private void FixedUpdate(){
        rb.velocity = new Vector2(horizontal*speed, rb.velocity.y);
    }

    private void Flip(){
        if(facingRight && horizontal < 0f || !facingRight && horizontal > 0f){
            facingRight = !facingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    
    private bool canJump(){
        return Physics2D.OverlapCircle(groundCheck.position, .2f, groundLayer);
    }
}
