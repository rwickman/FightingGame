using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject {

	public float maxSpeed = 7;
	public float jumpTakeOffSpeed = 7;
	public bool dontMove;

	private SpriteRenderer spriteRenderer;
	private Animator animator;
	private bool isCrouching;



	// Use this for initialization
	void Awake () 
	{
		spriteRenderer = GetComponent<SpriteRenderer> (); 
		animator = GetComponent<Animator> ();
	}
		

	void Update(){
		if (!dontMove) {
			targetVelocity = Vector2.zero;
			ComputeVelocity (); 
			if (Input.GetAxis ("Vertical") < 0) {
				isCrouching = true;
			} else {
				isCrouching = false;
			}
			animator.SetBool ("crouch", isCrouching);

		}

	
	}

	protected override void ComputeVelocity()
	{
		Vector2 move = Vector2.zero;

		move.x = Input.GetAxis ("Horizontal");

		if (Input.GetButtonDown ("Jump") && grounded) {
			velocity.y = jumpTakeOffSpeed;
		} else if (Input.GetButtonUp ("Jump")) 
		{
			if (velocity.y > 0) {
				velocity.y = velocity.y * 0.5f;
			}
		}

		/*bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
		if (flipSprite && !(!spriteRenderer.flipX && move.x < 0.01f))
		{
			spriteRenderer.flipX = !spriteRenderer.flipX;
		} */

		if (move.x < 0f)
		{
			spriteRenderer.flipX = true;
		}
		else if(move.x > 0f)
		{
			spriteRenderer.flipX = false;
		}

		animator.SetBool ("grounded", grounded);
		animator.SetFloat ("velocityX", Mathf.Abs (velocity.x) / maxSpeed);

		targetVelocity = move * maxSpeed;
	}
		
}