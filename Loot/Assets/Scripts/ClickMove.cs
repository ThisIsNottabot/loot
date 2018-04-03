using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMove : MonoBehaviour {

	private UnityEngine.AI.NavMeshAgent agent;
	public GameObject indicator;

	void Awake() {
		//set player as NavMeshAgent for movement
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}

	void Update() {
		//set up raycast to get position of mouse clicks in world
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Input.GetButtonDown("Fire2")) {
			if (Physics.Raycast(ray, out hit, 100)) {
				//raycast and set the destination to hit location in world
				agent.destination = hit.point;
				agent.Resume();
				//also move the movement indicator to destination
				indicator.transform.position = hit.point;
			}
		}
	}
}
