using UnityEngine;
using System.Collections;

public class Animator : MonoBehaviour {
	// A generic animation class degined to slide game objects across the screen on the X axis. 
	// Mainly be used to move 2d gui elements as needed.
	
	public float xStartPosition = -1.0f;
	public float xEndposition = 0.5f;
	public float speed = 1.0f;
	float startTime;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		// creates new position for game object via linear interpretation
		Vector3 pos = new Vector3(Mathf.Lerp(xStartPosition, xEndposition, (Time.time - startTime) * speed), transform.position.y, transform.position.z);
		// updates game object to new poition
		transform.position = pos;
	}
}
