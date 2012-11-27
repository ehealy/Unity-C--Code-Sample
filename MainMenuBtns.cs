using UnityEngine;
using System.Collections;
[RequireComponent (typeof (AudioSource))]

public class MainMenuBtns : MonoBehaviour {
	// Manages the functionality of all buttons in use within the main menu.
	
	public string levelToLoad;
	public Texture2D normalTexture;
	public Texture2D rollOverTexture;
	public AudioClip beep;
	public bool quitButton  = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	// changes the GUI texture in use upon roll over
	void OnMouseEnter(){
		guiTexture.texture = rollOverTexture;	
	}
	// changes the GUI testure in use when levaing the area of the element
	void OnMouseExit(){
		guiTexture.texture = normalTexture;	
	}
	
	// co-routine handling actions when buttons are pressed
	IEnumerator OnMouseUp(){
		// plays a sound when button is pressed
		audio.PlayOneShot(beep);
		// pauses function
		yield return new WaitForSeconds(0.35f);
		// logic determining which button was pressed
		if(quitButton){
			// quits game
			Application.Quit();
			// added to test quit within Unity without having to build
			Debug.Log("Quit Button pressed.");
		}
		else{
			// loads level
			Application.LoadLevel(levelToLoad);
		}
	}
}
