using UnityEngine;
using System.Collections;

public class DoorManager : MonoBehaviour {
	// Manages player's interaction with door objects within game
	
	bool doorIsOpen = false;
	float doorTimer = 0.0f;
	public float doorOpenTime = 3.0f;
	public AudioClip doorOpenSound;
	public AudioClip doorShutSound;
	

	// Use this for initialization
	void Start () {
		// initializes door timer when script is first invoked
		doorTimer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		// checks status of door before running routine
		if(doorIsOpen){
			// adds time to doorTime
			doorTimer += Time.deltaTime;
			// checks to see if time door has been open exceeds value door open time varible before starting door closing routine
			if(doorTimer > doorOpenTime){
				// runs Door function to close door
				Door(doorShutSound, false, "doorclose");
				// resets value of doorTimer variable
				doorTimer = 0.0f;
			}
		}
		// NOTE: the preceeding was used solely as demonstartion to show how variables can be updated and set within an Update function. 
		// since this is expensive processor-wise, a better alternative would be to change to Door function to a co-routine
	}
	
	// function to check if door is open when player character's collider interacts with a door's collider
	void DoorCheck(){
		// check status of doorIsOpen boolean before running routine
		if(!doorIsOpen){
			// runs Door function to open door
			Door(doorOpenSound, true, "dooropen");	
		}
	}
	
	
	// function to handle the opening and closing of door game objects
	void Door (AudioClip aClip, bool openCheck, string animName){
		// plays door open/close sound
		audio.PlayOneShot(aClip);
		// set value of doorIsOpen boolean
		doorIsOpen = openCheck;
		// plays door opening/closing animation
		transform.parent.gameObject.animation.Play(animName);		
	}
	
}
