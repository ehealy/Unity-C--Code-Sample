using UnityEngine;
using System.Collections;
[RequireComponent (typeof (AudioSource))]

public class TargetCollision : MonoBehaviour {
	// Handles the behavoir of targets if they have been struck by a coconut bullet.
	
	bool beenHit = false;
	Animation targetRoot;
	public AudioClip hitSound;
	public AudioClip resetSound;
	public float resetTime = 3.0f;
	
	
	// Use this for initialization
	void Start () {
		// creates the reference to the animations that are atatched to the parent object of the parent object of the target.
		targetRoot = transform.parent.transform.parent.animation;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// handles behavoir when target is struck by objects 
	void OnCollisionEnter(Collision theObject){
		// logic to check target before running routine
		if(beenHit == false && theObject.gameObject.name == "coconut"){
			// calls targetHit co-routine
			StartCoroutine("targetHit");
		}
	}
	
	// co-routine to handle target behavoir when struck 
	IEnumerator targetHit(){
		// plays hit sound
		audio.PlayOneShot(hitSound);
		// plays target hit animation
		targetRoot.Play("down");
		// sets beenHit boolean to true
		beenHit = true;
		// increments targets variable within CoconutWin class. 
		CoconutWin.targets++;
		
		// pauses function for time specified in resetTime variable
		yield return new WaitForSeconds(resetTime);
		
		// plays reset sound
		audio.PlayOneShot(resetSound);
		// plays target reset animation
		targetRoot.Play("up");
		// sets beenHit boolean to false
		beenHit = false;
		CoconutWin.targets--;
	}
}
