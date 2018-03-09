using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour {
	

	public float vertical;
	public float horizontal;
	public bool grounded = true;
	public bool crouch;

	public bool punchLight;
	public bool punchHeavy;
	public bool kickLight;
	public bool kickHeavy;

	public bool canAttack = true;
	public bool isHit;
	public bool isAttacking;

	public float reduceOverlapX = 0.04f;
	public float increaseOverlapY = -0.1f;

	private Animator anim;
	private SpriteRenderer spriteRenderer;
	private BoxCollider2D boxCollider;
	//private Rigidbody2D rb2D;

	//Box Collider vertices
	private Vector2 botRightCorner;
	private Vector2 botLeftCorner; 

	private int layermask;	//Used for ground detection


	// Use this for initialization
	void Start () {
		boxCollider = GetComponent<BoxCollider2D> ();
		anim = GetComponent<Animator> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
		//rb2D = GetComponent<Rigidbody2D> ();

		layermask = ~((1 << gameObject.layer) | (1 << 12));	 //enables all layer except for this fighter's layer, and walls layer

	}

	void Update(){
		checkIfGrounded ();
		handleStates (horizontal, vertical);
	}

	public void handleStates(float x, float y){
		if (y >= 0) {
			crouch = false;
		}
		canAttack = grounded;
		anim.SetBool ("crouch", crouch);
		anim.SetBool("grounded", grounded);

		if (x < 0f)
			spriteRenderer.flipX = true;
		else if(x > 0f)
			spriteRenderer.flipX = false;

		if (punchLight) {
			anim.SetTrigger ("punch");
			punchLight = false;

		}
		else if(kickLight){
			anim.SetTrigger ("kick");
			kickLight = false;
		}
		anim.SetFloat ("velocityX", Mathf.Abs (x));
	}
		
	/*void OnCollisionEnter2D(Collision2D coll){
		checkIfGrounded ();
	}

	void OnCollisionExit2D(Collision2D coll){
		checkIfGrounded ();
	}*/

	void checkIfGrounded(){
		botLeftCorner = new Vector2 (boxCollider.bounds.min.x + reduceOverlapX, boxCollider.bounds.min.y);
		botRightCorner = new Vector2 (boxCollider.bounds.max.x - reduceOverlapX, boxCollider.bounds.min.y +increaseOverlapY);
		grounded = Physics2D.OverlapArea (botLeftCorner, botRightCorner, layermask);
		//print (Physics2D.OverlapArea (botLeftCorner, botRightCorner, layermask));


	}

	public void ResetStates(){
		vertical = 0f;
		horizontal = 0f;
		crouch = false;
		punchLight = false;
		punchHeavy = false;
		kickLight = false;
		kickHeavy = false;
		canAttack = true;
		isHit = false;
		isAttacking = false;

	}
}
