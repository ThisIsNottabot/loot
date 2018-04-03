using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GenerateTerrain : MonoBehaviour {

	public GameObject floor0, floor1;
	public NavMeshSurface surface;

	void Start () {
		//generate level using BuildLevel method
		BuildLevel();
		//generate navMesh for newly created level
		surface.BuildNavMesh();
	}

	void BuildLevel () {
		//generate width of level from 3-10
		int lWidth = Random.Range(4,10);
		Debug.Log ("lWidth = " + lWidth);

		//generate length of level from 3-10
		int lLength = Random.Range(4,10);
		Debug.Log ("lLength= " + lLength);

		//create levelMap array
		int[][] levelMap = new int[lWidth][];
		for (int i = 0; i < lWidth; i++) {
			levelMap[i] = new int[lLength];
		}

		//fill levelMap array
		for (int i = 0; i < lWidth; i++) {
			for (int j = 0; j < lLength; j++) {
				//fill the border of the map with blank tiles
				if (i == 0 || i == lWidth-1 || j == 0 || j == lLength-1){
					levelMap[i][j] = 0;
				} else {
					levelMap[i][j] = 1;
				}
			}
		}

		//Instantiate floor based on levelMap array
		for (int i = 0; i < levelMap.Length; i++) {
			for (int j = 0; j < levelMap[i].Length; j++) {
				if (levelMap[i][j] == 1) {
					Instantiate(floor1, new Vector3 (i*10, 0, j*10), Quaternion.identity, gameObject.transform);
				} else {
					Instantiate(floor0, new Vector3 (i*10, 0, j*10), Quaternion.identity, gameObject.transform);
				}
			}
		}
	}
}
