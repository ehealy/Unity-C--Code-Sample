using UnityEngine;
using System.Collections;

public class Matches : MonoBehaviour {
	// Controls behavoir of the matches game object.
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// handles interaction when player collides with matches
	void OnTriggerEnter (Collider col){
		// checkes to see if plyer has collided with matches
		if(col.gameObject.tag == "Player"){
			// sends message to MatchPickup function attached to player character
			col.gameObject.SendMessage("MatchPickup");
			// destroys the matches game object
			Destroy(gameObject);
		}
	}
}
