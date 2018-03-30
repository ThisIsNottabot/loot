using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTerrain : MonoBehaviour {

	public GameObject floor;

	void Start () {
		for (int i = 0; i < 4; i++) {
			Instantiate(floor, new Vector3 (0, i, 0), Quaternion.identity, gameObject.transform);
		}
	}
}
