using UnityEngine;
using System.Collections;

public class WinGame : MonoBehaviour {
	// Handles Win Game behavoir for game.
	
	public GameObject winSequence;
	public GUITexture fader;
	public AudioClip winClip;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// co-routine handling Win Game behavoir
	IEnumerator GameOver (){
		// plays Win Game sound
		AudioSource.PlayClipAtPoint(winClip, transform.position);
		// adds game winning GUI elements to screen
		Instantiate(winSequence);
		// pauses function for specified time
		yield return new WaitForSeconds(8.0f);
		// adds fade out graphic elements to game screen
		Instantiate(fader);
	}
}
