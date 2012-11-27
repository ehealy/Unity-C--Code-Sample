using UnityEngine;
using System.Collections;

public class ThrowTrigger : MonoBehaviour {
	// Handles the behavoir of the trigger that allows cocunt throwing for the player character.
	
	public GUITexture crosshair;
	public GUIText textHints;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// handles the enabling of cocunt throwing for the player character
	void OnTriggerEnter(Collider col) {
		// check for collisions with the player character before carrying out routine
		if(col.gameObject.tag == "Player"){
			// passes a vaule to canThrow boolean within the CoconutThower class
			CoconutThrower.canThrow = true;
			// enables the crosshair GUI texture
			crosshair.enabled = true;
			// checks to see if player has already won game previously before carrying out routine
			if(!CoconutWin.haveWon){
				// sends a message to the ShowHint function to display a text hint
				textHints.SendMessage("ShowHint", "\n\n\n\n\n There's a power cell attahced to this game, \n maybe I'll win it if I can nock down all the targets...");
			}
		}
	}
	
	// handles the disabling of coconut throwing for the player character
	void OnTriggerExit(Collider col){
		// check for collisions with the player character before carrying out the routine
		if(col.gameObject.tag == "Player"){
			// passes a value to canThrow boolean within the CocoutThrower class
			CoconutThrower.canThrow = false;
			// disables the crosshair GUI texture
			crosshair.enabled = false;
		}
	}
}
