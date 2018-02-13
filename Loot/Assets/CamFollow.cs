using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour {
	public GameObject target;

	void LateUpdate () {
		transform.position = target.transform.position + new Vector3(-10, 8.39f, -10);
	}
}
