using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour {
	public GameObject target;

	void LateUpdate () {
		//set camera position to specific posiion above target --REWORK THIS--
		transform.position = target.transform.position + new Vector3(-10, 7, -10);
	}
}
