using UnityEngine;
using System.Collections;

public class TidyObject : MonoBehaviour {
	// Generic class to remove a game object from game after a specified time period 
	
	public float removeTime = 3.0f;

	// Use this for initialization
	void Start () {
		// destroys the game object
		Destroy(gameObject, removeTime);
	}
	
	
}
