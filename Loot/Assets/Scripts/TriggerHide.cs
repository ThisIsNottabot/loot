using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHide : MonoBehaviour {

	public GameObject model1;
	public GameObject model2;
	private GameObject currentModel;
	private int model = 1;

	public Collider prox;

	void Start() {
		Destroy(GetComponent<MeshRenderer>());
		currentModel = Instantiate(model1, transform.position, transform.rotation) as GameObject;
		currentModel.transform.parent = transform;
		Debug.Log(currentModel);
	}

	public void ChangeModel() {
		if (model == 1) {
			GameObject tempModel = Instantiate(model2, transform.position - new Vector3(0, 3.09F, 0), transform.rotation) as GameObject;
			Destroy(currentModel);
			tempModel.transform.parent = transform;
			currentModel = tempModel;
			model = 2;
			Debug.Log("2");
		} else {
			GameObject tempModel = Instantiate(model1, transform.position, transform.rotation) as GameObject;
			Destroy(currentModel);
			tempModel.transform.parent = transform;
			currentModel = tempModel;
			model = 1;
			Debug.Log("1");
		}
	}

	void OnTriggerEnter(Collider prox) {
		Debug.Log("Enter");
		ChangeModel();
	}

	void OnTriggerExit(Collider prox) {
		Debug.Log("Exit");
		ChangeModel();
	}
}
