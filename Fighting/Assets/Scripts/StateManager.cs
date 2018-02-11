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

	public string groundName = "Ground";

	public bool canAttack = true;
	public bool isHit;
	public bool isAttacking;

	private Animator anim;
	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();

	}

	void Update(){
		handleStates (horizontal, vertical);
	}
	
	// Update is called once per frame

	public void handleStates(float x, float y){

		if (y >= 0) {
			crouch = false;
		}

		anim.SetBool ("crouch", crouch);

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


		


	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == groundName){
			anim.SetBool("grounded", true);
			grounded = true;
			canAttack = true;
		}
	}


	void OnCollisionExit2D(Collision2D coll){
		if(coll.gameObject.tag == groundName){
			anim.SetBool("grounded", false);
			grounded = false;
			canAttack = false;
		}
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
