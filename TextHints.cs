using UnityEngine;
using System.Collections;

public class TextHints : MonoBehaviour {
	// Handles the behavoir of the text hint GUI in game.
	
	float timer = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// checks to ensure text hint GUI is enabled before carrying out routine 
		if (guiText.enabled){
			// increments timer variable
			timer += Time.deltaTime;
			// checks value of timer before carrying out routine
			if(timer >= 4){
				// shuts off text hint GUI
				guiText.enabled = false;
				// resets timer value
				timer = 0.0f;
			}
		}
	
	}
	
	// function to show text hint GUI if not currently displayed onscreen and to display a text hint
	void ShowHint(string message){
		// sets text in text hint GUI to string variable value passed in through argument  
		guiText.text = message;
		
		// logic to check if text hint is enabled beofre carrying out routine
		if(!guiText.enabled){
			// enables the text hint GUI
			guiText.enabled = true;
			}
	}
}
