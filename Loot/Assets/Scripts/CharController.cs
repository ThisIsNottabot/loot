using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour {
	public float moveSpeed = 4f;
	public Rigidbody rb;
	private Vector3 forward, right; //keeps track of relative forward and right vectors

	void Start () {
		forward = Camera.main.transform.forward; //sets local forward to the camera's forward vector
		forward.y = 0;
		forward = Vector3.Normalize(forward); //caps the length of the forward vetor to 1.0
		right = Quaternion.Euler(new Vector3(0,90,0)) * forward; //sets the local right vector to be relative to our local forward vector
	}

	void Update () {
		if(Input.GetButton("HorizontalKey") || Input.GetButton("VerticalKey")) { //execute move() if any key is pressed
			Move();
		}
	}

	void Move () {
		Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey"); //right movement is based on the right vector, moveSpeed and GetAxis. Time.deltaTime smooths movement
		Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey"); //up movement is based on the forward vector, moveSpeed and GetAxis.

		Vector3 heading = Vector3.Normalize(rightMovement + upMovement); //combines up and right movement and normalizes them to 1.0 to get a direction
		transform.forward = heading; //sets the forward direction of the gameObject to the heading variable direction

		rb.velocity = rightMovement + upMovement;
	}

}
