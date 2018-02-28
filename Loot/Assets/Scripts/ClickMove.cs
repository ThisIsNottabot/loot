using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMove : MonoBehaviour {

	private UnityEngine.AI.NavMeshAgent agent;
	public GameObject indicator;

	void Awake() {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}

	void Update() {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Input.GetButtonDown("Fire2")) {
			if (Physics.Raycast(ray, out hit, 100)) {
				agent.destination = hit.point;
				agent.Resume();
				indicator.transform.position = hit.point;
			}
		}
	}
}
