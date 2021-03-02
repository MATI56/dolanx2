using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment2D : MonoBehaviour
{
   public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    public float jumpForce;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    private float moveInput;
    
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    public bool updateOn = true;
    
   
    void Update()
    {
    
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
   
        if (updateOn == true)
        {
     
       if(isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("takeOf");
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if(Input.GetKey(KeyCode.Space) && isJumping == true){
            if(jumpTimeCounter > 0){
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            } else {   
                isJumping = false;
            }
        
        }

        if(isGrounded == true){
            animator.SetBool("isJumping",false);
        }
        else{
            animator.SetBool("isJumping",true); 
        }
        if(Input.GetKeyUp(KeyCode.Space)){
                isJumping = false;
        }
        }

    }

    void FixedUpdate()
    {
        if (updateOn == true)
        {
            moveInput = Input.GetAxisRaw("Horizontal");
            animator.SetFloat("Blend", moveInput);
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);  
        }  
    }
 
    public IEnumerator updateOff ()
    {
        yield return new WaitForSeconds (1.0f);
        updateOn = true;
    }
}

