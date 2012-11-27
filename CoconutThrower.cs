using UnityEngine;
using System.Collections;
[RequireComponent (typeof (AudioSource))]

public class CoconutThrower : MonoBehaviour {
	// Handles the instantiation and behavoir of coconut projectlies in coconut throw game.
	
	public AudioClip throwSound;
	public Rigidbody coconutPrefab;
	public float throwSpeed = 30.0f;
	public static bool canThrow = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// checks to see if player can throw coconut before running routine
		if(Input.GetButtonDown("Fire1") && canThrow){
			audio.PlayOneShot(throwSound);
			// creates coconut
			Rigidbody newCoconut = Instantiate(coconutPrefab,transform.position, transform.rotation) as Rigidbody;
			newCoconut.name = "coconut";
			// gives coconut velocity
			newCoconut.velocity = transform.forward * throwSpeed;
			// stops Rigidbody from detecting collisions between newly created coconuts and the player character's collider
			Physics.IgnoreCollision(transform.root.collider, newCoconut.collider, true);
			
		}
		
	
	}
}
