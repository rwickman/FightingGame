using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionControls : MonoBehaviour {

	public float moveSpeed = 5f;

	public float jumpSpeed = 10f;
	public float jumpHeight = 100f;

	private BoxCollider2D boxCollider;      
	private Rigidbody2D rb2D;
	private StateManager state;

	// Use this for initialization
	void Start () {
		boxCollider = GetComponent<BoxCollider2D> ();
		rb2D = GetComponent<Rigidbody2D> ();
		state = GetComponent<StateManager> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float horizontal = Input.GetAxisRaw ("Horizontal");
		float vertical = Input.GetAxisRaw ("Vertical");			

		//If the player is attempting to move and grounded and not crouching
		if ((horizontal != 0 || vertical != 0) && state.grounded && !state.crouch) {
			BasicMove (horizontal, vertical);
		}

			
		state.horizontal = horizontal;
		state.vertical = vertical;
	}

	private void BasicMove(float x, float y){
		
		if (y > 0) {
			rb2D.AddForce(new Vector2(x,y)  * jumpHeight, ForceMode2D.Impulse);
		} else if (x == 0 && y < 0) {
			state.crouch = true;
		} else {
			rb2D.MovePosition (rb2D.position + new Vector2 (x, 0) * Time.fixedDeltaTime * moveSpeed);

		}
	}




	void Jump(){
		
	}



}
