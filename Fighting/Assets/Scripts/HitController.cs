using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitController : MonoBehaviour {

	public string fighterTag = "Fighter";
	public float lightKickForce = 10f;
	public float lightPunchForce = 10f;

	private Fighter player;

	// Use this for initialization
	void Start () {
		player = GetComponentInParent<Fighter> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D coll){
		//This is how you are dealt damage
		//Need to factor in how someone attacked to decide how much damage is dealt
		//Also need to perform hit animation
		if(coll.gameObject.tag == fighterTag){
			
			ContactPoint2D[] contacts = new ContactPoint2D[100];
			int hitPoint = coll.GetContacts (contacts);

			foreach (ContactPoint2D contact in contacts) {
				Vector2 direction = new Vector2 (transform.position.x, transform.position.y) - contact.point;
				coll.rigidbody.AddForceAtPosition (-contact.normal * lightKickForce, direction.normalized, ForceMode2D.Impulse);	
			}

			//coll.rigidbody.AddForce(contacts.,ForceMode2D.Impulse);
			print ("HitEnemy! " + "Velcoity: " + contacts [0].normal + " num: " + hitPoint);

			//coll.rigidbody.position += Vector2.up * lightKickForce;
		}
	} 

	/*void OnTriggerEnter2D(Collider2D other){
		if (other.transform.gameObject.tag == fighterTag) {
			/*ContactPoint2D[] contactPoints = new ContactPoint2D[100];
			int numPoints = other.GetContacts (contactPoints);
			for (int i = 0; i < numPoints; i++) {
				Vector2 direction = contactPoints [i].normal;
				contactPoints [i].rigidbody.AddForce(Vector2.up);
			}
			other		
		}
	} */
}
