using UnityEngine;
using System.Collections;

public class PowerCell : MonoBehaviour {	
	// Handles Powecell behavior.
	
	public float rotationSpeed = 100.0f;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// creates rotation animation effect on Powercell
		transform.Rotate(new Vector3 (0, rotationSpeed * Time.deltaTime, 0));
	
	}
	
	// handles collision with player
	void OnTriggerEnter(Collider col){
		// checks that collsiion is with player character before starting routine
		if(col.gameObject.tag == "Player"){
			// sends call to CellPickup function attached to player character
			col.gameObject.SendMessage("CellPickup");
			// destroys Powercell
			Destroy(gameObject);
		}
	}
	
	
	
}
