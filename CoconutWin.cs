using UnityEngine;
using System.Collections;
[RequireComponent (typeof(AudioSource))]

public class CoconutWin : MonoBehaviour {
	//handles the behvoir when the player has won coconut thrower game.
	
	public static int targets = 0;
	public static bool haveWon = false;
	public AudioClip winSound;
	public GameObject cellPrefab;
	
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// checks to see if player has met conditions for winng game before running routine
		if(targets == 3 && haveWon == false){
			// resets target counter
			targets = 0;
			// plays game winning sound
			audio.PlayOneShot(winSound);
			// finds powercell graphic component of coconut shy and moves object from shy's wall
			GameObject winCell = transform.Find("powerCell").gameObject;
			winCell.transform.Translate(-1,0,0);
			// replaces powercell graphic with powercell player can collect
			Instantiate(cellPrefab, winCell.transform.position, transform.rotation);
			Destroy(winCell);
			// sets game winning conditional so player cannot collect multiple powercells from game
			haveWon = true;
		}
	
	}
}
