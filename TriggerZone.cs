using UnityEngine;
using System.Collections;

public class TriggerZone : MonoBehaviour {
	// Handles the behavoir of trigger zone for the cabin door in game. 
	
	public AudioClip lockedSound;
	public Light doorLight;
	public GUIText textHints;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// handles door behavoir when player enters trigger area
	void OnTriggerEnter (Collider col){
		// checks to ensure collision is with player before carrying out routine
		if(col.gameObject.tag == "Player"){
			// checks to ensure all powercells have been collected before carrying out routine
			if(Inventory.charge == 4){
				// sends message to DoorCheck function attached to Door game object
				transform.FindChild("door").SendMessage("DoorCheck");
				// checks to see if charge GUI is still active before running routine. 
				if(GameObject.Find("PowerGUI")){
					// removes charge GUI from game
					Destroy(GameObject.Find("PowerGUI"));
					// changes color of light over cabin door
					doorLight.color = Color.green;
				}
					
			}else if(Inventory.charge > 0 && Inventory.charge < 4){
				// sends call to ShowHint function to turn on text hint GUI and dsiplay a message
				textHints.SendMessage("ShowHint", "This door won't budge.. guess it needs to be fully charged- maybe more power cells will help...");
				// plays locked sound from door
				transform.FindChild("door").audio.PlayOneShot(lockedSound);
				
			}else{
				// plays locked sound from door
				transform.FindChild("door").audio.PlayOneShot(lockedSound);
				// sends call to HUDon function to turn on charge GUI
				col.gameObject.SendMessage("HUDon");
				// sends call to ShowHint function to turn on text hint GUI and dsiplay a message
				textHints.SendMessage("ShowHint", "This door seems locked.. maybe that generator needs power...");
			}
		}
	}
}
