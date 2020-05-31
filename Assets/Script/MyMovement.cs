using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMovement : MonoBehaviour
{
    public BrackeyController controller;
    public float runSpeed;
    public Animator animator;
    private float horizontalMove;
    bool jump = false;
    bool crouch = false;

    void Start()
    {
        
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("Jump") && !jump)
        {
            jump = true;
            animator.SetBool("isJumping",jump);
        }
        if (Input.GetButton("Crouch") && horizontalMove==0.0f)
        {
            crouch = true;
        }
        else if(Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
        
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping",false);
        Debug.Log("Stop jumping");
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("isCrouching", crouch);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
