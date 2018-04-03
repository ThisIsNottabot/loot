using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour {
	public float moveSpeed = 4f;
	public Rigidbody rb;
	//keeps track of relative forward and right vectors
	private Vector3 forward, right;

	void Start () {
		//sets local forward to the camera's forward vector
		forward = Camera.main.transform.forward;
		forward.y = 0;
		//caps the length of the forward vetor to 1.0
		forward = Vector3.Normalize(forward);
		//sets the local right vector to be relative to our local forward vector
		right = Quaternion.Euler(new Vector3(0,90,0)) * forward;
	}

	void Update () {
		//execute move() if any key is pressed
		if(Input.GetButton("HorizontalKey") || Input.GetButton("VerticalKey")) {
			Move();
		}
	}

	void Move () {
		//right movement is based on the right vector, moveSpeed and GetAxis. Time.deltaTime smooths movement
		Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
		//up movement is based on the forward vector, moveSpeed and GetAxis
		Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");

		//combines up and right movement and normalizes them to 1.0 to get a direction
		Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
		//sets the forward direction of the gameObject to the heading variable direction
		transform.forward = heading;

		rb.velocity = rightMovement + upMovement;
	}

}
