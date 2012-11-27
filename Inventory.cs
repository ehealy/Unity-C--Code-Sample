using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {
	// Handles all inventory related ineractions for the player character
	
	// Powercell Variables
	public static int charge = 0;
	public AudioClip collectSound;
	// HUD
	public Texture2D[] hudCharge;
	public GUITexture chargeHudGUI;
	// Generator
	public Texture2D[] meterCharge;
	public Renderer meter;
	//Matches
	bool haveMatches = false;
	public GUITexture matchGUIprefab;
	GUITexture matchGUI;
	public GUIText textHints;
	bool fireIsLit = false;
	//Game Over Variable
	public GameObject winObj;
	
	// handles pickep of Powercells
	void CellPickup(){
		// calls HUDon function
		HUDon();
		// plays sound when player picks up Powercell
		AudioSource.PlayClipAtPoint(collectSound, transform.position);
		// increments charge collected counter
		charge++;
		// updates GUI Texture used by charge HUD meter
		chargeHudGUI.texture = hudCharge[charge];
		// updates texture used by meter object at outpost
		meter.material.mainTexture = meterCharge[charge];
	}
	
	// turns the charge HUD on
	void HUDon(){
		if(!chargeHudGUI.enabled){
			chargeHudGUI.enabled = true;
		}
	}
	
	// handles the pickup of the matches object
	void MatchPickup(){
		// sets haveMatches boolean to true
		haveMatches = true;
		// plays the match collections sound
		AudioSource.PlayClipAtPoint(collectSound, transform.position);
		// adds the matches GUI Texture to the game screen
		GUITexture matchHUD = Instantiate(matchGUIprefab, new Vector3(0.15f, 0.1f, 0),transform.rotation) as GUITexture;
		// sets matchHUD as value of matchGUI private variable so it canbe used within other fucntions within class
		matchGUI = matchHUD;
	}
	
	// handles players collision with campfire object
	void OnControllerColliderHit(ControllerColliderHit col){
		
		// check to see if object player has collided with is the campfire
		if(col.gameObject.name == "campfire"){
			// conditional checks of players invenotry and state of campfire
			if(haveMatches && !fireIsLit){
				// calls LightFire function
				LightFire(col.gameObject);
			}else if(!haveMatches && !fireIsLit){
				// dispalys message to player via textHint GUI Text
				textHints.SendMessage("ShowHint", "I could use this campfire to sgnal for help..if only I could light it..");	
			}
		}
	}
	
	// handles the campfire's functionality in game
	void LightFire(GameObject campfire){
		// creates ParticleEmitter array
		ParticleEmitter[] fireEmitters;
		// adds all partilve emitter compent children of campfire game object to array 
		fireEmitters = campfire.GetComponentsInChildren<ParticleEmitter>();
		// turns on all emmitters
		foreach(ParticleEmitter emitter in fireEmitters){
			emitter.emit = true;			
		}
		// plays campfire sound
		campfire.audio.Play();
		// removes match inventory HUD
		Destroy(matchGUI);
		// resets match inventory boolean
		haveMatches = false;
		// sets campfire boolean
		fireIsLit = true;
		// sends function call message to winObj game object
		winObj.SendMessage("GameOver");
	}
	
}
