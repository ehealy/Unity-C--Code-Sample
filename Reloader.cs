using UnityEngine;
using System.Collections;

public class Reloader : MonoBehaviour {
	// a generic class to handle the reloading of the game upon completion.

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// a class that reloads the game
	void Reload(){
		// loads main menu
		Application.LoadLevel("Menu");	
	}
}
