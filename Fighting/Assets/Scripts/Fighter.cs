using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour {

	// Use this for initialization
	public string fighterTag = "Fighter";
	public float attackRate = 0f;

	private Animator anim;
	private Collider2D attackCollider;
	private StateManager state;
	private float nextAttack;

	void Start () {
		anim = GetComponentInParent<Animator> ();
		attackCollider = GetComponentInChildren<Collider2D> ();
		state = GetComponent<StateManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetButtonDown ("Fire1") && state.canAttack) {
			state.punchLight = true; 
			nextAttack = 0;//Time.time + attackRate;
			print ("punch");
		}
		else if (Input.GetButtonDown ("Fire2") && Time.time >= nextAttack && state.canAttack) {
			
			state.kickLight = true;
			nextAttack = 0f;//Time.time + attackRate;
			print ("kick");
		}

	}


}
