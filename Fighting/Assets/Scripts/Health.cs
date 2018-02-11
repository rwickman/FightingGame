using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public int currentHealth; 
	public const int initialHealth = 100;

	public bool isDamaged;
	// Use this for initialization
	void Start () {
		currentHealth = initialHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TakeDamage(int damage){
		currentHealth -= damage;
		if (currentHealth <= 0) {
			Death ();
		}
	}

	private void Death(){
		//Death animation
	}


}
