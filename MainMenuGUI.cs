using UnityEngine;
using System.Collections;
[RequireComponent (typeof(AudioSource))]

public class MainMenuGUI : MonoBehaviour {
	// Handles the setup of the GUI element within the main menu.
	
	public AudioClip beep;
	public GUISkin menuSkin;
	public Rect menuArea;
	public Rect playButton;
	public Rect instructionsButton;
	public Rect quitButton;
	public Rect instructions;
	Rect menuAreaNormalized;
	string menuPage = "main";
	
	
	// Use this for initialization
	void Start () {
		// creates rectangle to set menu area to current resolution of game screen. 
		menuAreaNormalized = new Rect(menuArea.x * Screen.width - (menuArea.width * 0.5f), menuArea.y * Screen.height - (menuArea.height * 0.5f), menuArea.width, menuArea.height);
	
	}
	
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// handles the creation and content of the menu GUI
	void OnGUI(){
		// sets the skin of the GUI to the GUI Skin stored by the menuSkin variable
		GUI.skin = menuSkin;
		// opens GUI group
		GUI.BeginGroup(menuAreaNormalized);
		// logic for determining what to display within the menu area on the main page
		if(menuPage == "main"){
			// checkes to ensure level can be loaded before carrying out routine
			if(Application.CanStreamedLevelBeLoaded("Island")){
				// logic for play button interaction
				if(GUI.Button(new Rect (playButton), "Play")){
					// starts co-routine for level loading
					StartCoroutine("ButtonAction", "Island");
				}
			}else{
				// calculates the current percent loaded of level 
				float percentLoaded = Application.GetStreamProgressForLevel(1) * 100;
				// shows the percentage of level loaded within the play button
				GUI.Box(new Rect(playButton), "Loading.." + percentLoaded.ToString("f0") + "% Loaded");
			}
			// logic for instructions button interaction
			if(GUI.Button(new Rect (instructionsButton), "Instructions")){
				// plays a sound when button is pressed
				audio.PlayOneShot(beep);
				// sets menu GUI to the instructions view
				menuPage = "instructions";
			}
			// checks to ensure that the version of the game is not browser based
			if (Application.platform != RuntimePlatform.OSXWebPlayer && Application.platform != RuntimePlatform.WindowsWebPlayer){
			
				//logic for quit button interaction
				if(GUI.Button(new Rect (quitButton), "Quit")){
					// starts co-routine to quit game
					StartCoroutine("ButtonAction", "quit");
				}
			}
		}
		// logic for determining what to dispaly within the menu area on the instructions page
		else if (menuPage == "instructions"){
			// creates a rectangle to display the instructions for the game
			GUI.Label(new Rect(instructions), "You awake on a mysterious island...Find a way to signal for help or face certain doom!");
			// logic for a back button to bring player back to main menu
			if(GUI.Button(new Rect(quitButton), "Back")){
				// plays a beep sound
				audio.PlayOneShot(beep);
				// sets menu page back to main page
				menuPage = "main";
			}
		}
		// ends GUI group
		GUI.EndGroup();
	}
	
	// co-routine for loading levels or quitting game
	IEnumerator ButtonAction (string levelName){
		// plays a beep sound
		audio.PlayOneShot(beep);
		// pauses function for set amount of time
		yield return new WaitForSeconds(0.35f);
		// logic if play button is pressed
		if (levelName != "quit"){
			// loads level
			Application.LoadLevel(levelName);
		}else{
			// quits game
			Application.Quit();
			// added to test functionality in Unity preview
			Debug.Log("Have Quit.");
		}
	}
	
}
