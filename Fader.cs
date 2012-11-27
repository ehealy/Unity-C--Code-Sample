using UnityEngine;
using System.Collections;

public class Fader : MonoBehaviour {
	// A class that applies a generic fade animation effect to the game screen when invoked
	
	public GUITexture loadGUI;

	// Use this for initialization
	void Start () {
		// creates a rectangele that matches the current size of the game screen to ensure fade will work at multiple resolutions 
		Rect currentRes = new Rect(-Screen.width * 0.5f, -Screen.height * 0.5f, Screen.width, Screen.height);
		// sets fade's pixelInset properites to match rectangle just created
		guiTexture.pixelInset = currentRes;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// istantiates a GUI Texture that will be loaded on screen
	void LoadAnim(){
		Instantiate(loadGUI);	
	}
	
	// destroys object as needed
	void DestroyObj(){
		Destroy(gameObject);	
	}
}
