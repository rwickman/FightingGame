using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotions : MonoBehaviour {

	public float jumpForce = 10f;
	public float walkingSpeed;


	private Animator anim;
	private BoxCollider2D boxCollider;      //The BoxCollider2D component attached to this object.
	private Rigidbody2D rb2D;               //The Rigidbody2D component attached to this object.
	private bool canWalk = true;

	// Use this for initialization
	void Start () {
		boxCollider = GetComponent<BoxCollider2D> ();
		rb2D = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");

		if(horizontal != 0 || vertical != 0) {
			Move (horizontal, vertical);
		}
		ResetAnimations (horizontal, vertical);


			
	}
	private void Move(float horizontal, float vertical){
		if (vertical == 0) {
			if (!anim.GetBool("isJumping")) {
				anim.SetBool ("isWalking", true);
			}
			rb2D.AddForce (new Vector2(horizontal, vertical) * walkingSpeed, ForceMode2D.Impulse);
		} else if (vertical < 0) {
			Crouch ();
		} else if(vertical > 0 && !anim.GetBool("isJumping")) {
			Jump ();
			rb2D.AddForce (new Vector2(horizontal, vertical) * jumpForce, ForceMode2D.Impulse);
		}




	}
	
	private void Crouch(){
		anim.SetBool ("isCrouching", true);
	}

	private void Jump(){
		anim.SetBool ("j", true);
	}
		

	private void ResetAnimations(float horizontal, float vertical){
		if(horizontal == 0){
			anim.SetBool ("isWalking", false);
		}
		if (vertical == 0) {
			anim.SetBool ("isCrouching", false);
		}
	}
	void OnCollisionStay2D(Collision2D coll){
		if (coll.gameObject.tag == "Ground") {
			anim.SetBool ("isJumping", false);
			canWalk = true;
		}
	}
	void OnCollisionExit2D(Collision2D coll){
		if (coll.gameObject.tag == "Ground") {
			//canMove = false;
			//canJump = false;

		}
	}
}
