using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MyController : MonoBehaviour
{
    [SerializeField] private float JumpForce = 400f;
    [Range(0, .3f)] [SerializeField] private float MovementSmoothing = .05f;
    [SerializeField] private LayerMask WhatIsGround;
	[SerializeField] private Transform GroundCheck;
	[SerializeField] private Transform CeilingCheck;	

    private Rigidbody2D rb;
    const float GroundedRadius = .02f;
	const float CeilingRadius = .02f;
    private bool Grounded;
    private bool FacingRight = true;
    private Vector3 Velocity = Vector3.zero;

    [Header("Events")]
	[Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();
    }

    private void FixedUpdate()
    {
        bool wasGrounded = Grounded;
		Grounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheck.position, GroundedRadius, WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject.tag == "Ground" && colliders[i].gameObject != gameObject)
			{
                Debug.Log("pss");
				Grounded = true;
				if (!wasGrounded) {
                    OnLandEvent.Invoke();
                    Debug.Log(colliders[i].gameObject);
                }
			}
		}
    }

    public void Move(float move, bool jump)
    {
        Vector3 targetVelocity = new Vector2(move * 10f, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref Velocity, MovementSmoothing);
        if (move > 0 && !FacingRight)
        {
            Flip();
        }
        else if (move < 0 && FacingRight)
        {
            Flip();
        }
        if (Grounded && jump)
		{
			Grounded = false;
			rb.AddForce(new Vector2(0f, JumpForce));
		}
        if(jump)
        {
            Debug.Log("jump");
        }
    }

    private void Flip()
	{
		FacingRight = !FacingRight;
		transform.Rotate(0f,180f,0f);
	}
}
