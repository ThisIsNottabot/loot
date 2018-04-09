using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GenerateTerrain : MonoBehaviour {

	public GameObject floor0, floor1, floor2, floor3, floor4;
	public NavMeshSurface surface;

	void Start () {
		//generate level using BuildLevel method
		BuildLevel();
		//generate navMesh for newly created level
		surface.BuildNavMesh();
	}

	void BuildLevel () {
		//generate width of level from 4-10
		int lWidth = Random.Range(10,50);
		Debug.Log ("lWidth = " + lWidth);

		//generate length of level from 4-10
		int lLength = Random.Range(10,50);
		Debug.Log ("lLength= " + lLength);

		//create minMap, maxMap and finalMap arrays
		int[][] minMap = new int[lWidth][];
		for (int i = 0; i < lWidth; i++) {
			minMap[i] = new int[lLength];
		}
		int[][] maxMap = new int[lWidth][];
		for (int i = 0; i < lWidth; i++) {
			maxMap[i] = new int[lLength];
		}
		int[][] levelMap = new int[lWidth][];
		for (int i = 0; i < lWidth; i++) {
			levelMap[i] = new int[lLength];
		}

		//fill all arrays
		for (int i = 0; i < lWidth; i++) {
			for (int j = 0; j < lLength; j++) {
				//fill the border of the map with blank tiles
				if (i == 0 || i == lWidth-1 || j == 0 || j == lLength-1){
					minMap[i][j] = 0;
					maxMap[i][j] = 0;
					levelMap[i][j] = 0;
				} else {
					minMap[i][j] = 1;
					maxMap[i][j] = 1;
					levelMap[i][j] = 0;
				}
			}
		}

		//configure max array
		for (int i = 0; i < lWidth; i++) {
			for (int j = 0; j < lLength; j++) {
				if (i != 0 && i != lWidth-1 && j != 0 && j != lLength-1){
					maxMap[i][j] = minMap[i-1][j] + minMap[i+1][j] + minMap[i][j-1] + minMap[i][j+1];
				}
			}
		}

		//configure min array
		for (int i = 0; i < lWidth; i++) {
			for (int j = 0; j < lLength; j++) {
				minMap[i][j] = 0;
			}
		}

		//construct levelMap based on minMap and maxMap
		for (int y = 1; y < lWidth-1; y++) {
			for (int x = 1; x < lLength-1; x++) {

				int variant = Random.Range(minMap[y][x], maxMap[y][x]);
				//reroll if 1 or 0
				if (variant == 1 || variant == 0) {
					variant = Random.Range(minMap[y][x], maxMap[y][x]);
				}
				levelMap[y][x] = variant;
				Debug.Log(variant);
				//check if 0 was generated and reduce surrounding tile's max by 1
				if (levelMap[y][x] == 0) {
					maxMap[y-1][x] -= 1;
					maxMap[y][x+1] -= 1;
					maxMap[y+1][x] -= 1;
					maxMap[y][x-1] -= 1;
				}
				//check to see if the maximum value was generated and increase surrounding tile's min by 1
				else if (levelMap[y][x] == maxMap[y][x]) {
					minMap[y-1][x] += 1;
					minMap[y][x+1] += 1;
					minMap[y+1][x] += 1;
					minMap[y][x-1] += 1;
				}
				//check to see if a number lower than the maximum value was generated
				else if (levelMap[y][x] < maxMap[y][x]) {
					int points = levelMap[y][x];
					//resolve needed connections for the tile above the current one if needed
					if (minMap[y-1][x] < levelMap[y-1][x]) {
						minMap[y-1][x] += 1;
						points -= 1;
					}
					//use remaining points to increase minimum or decrease maximum values of surrounding tiles
					if (minMap[y][x+1] < levelMap[y][x+1]) {
						if (points > 0) {
							minMap[y][x+1] += 1;
							points -= 1;
						} else {
							maxMap[y][x+1] -= 1;
						}
					}
					if (minMap[y+1][x] < levelMap[y][x-1]) {
						if (points > 0) {
							minMap[y+1][x] += 1;
							points -= 1;
						} else {
							maxMap[y+1][x] -= 1;
						}
					}
					if (minMap[y][x-1] < levelMap[y][x-1]) {
						if (points > 0) {
							minMap[y][x-1] += 1;
							points -= 1;
						} else {
							maxMap[y][x-1] -= 1;
						}
					}
				}
			}
		}

		//Instantiate floor based on levelMap array
		for (int i = 0; i < levelMap.Length; i++) {
			for (int j = 0; j < levelMap[i].Length; j++) {
				if (levelMap[i][j] == 0) {
					Instantiate(floor0, new Vector3 (i*10, 0, j*10), Quaternion.identity, gameObject.transform);
				} else if (levelMap[i][j] == 1) {
					Instantiate(floor1, new Vector3 (i*10, 0, j*10), Quaternion.identity, gameObject.transform);
				} else if (levelMap[i][j] == 2) {
					Instantiate(floor2, new Vector3 (i*10, 0, j*10), Quaternion.identity, gameObject.transform);
				} else if (levelMap[i][j] == 3) {
					Instantiate(floor3, new Vector3 (i*10, 0, j*10), Quaternion.identity, gameObject.transform);
				} else if (levelMap[i][j] == 4) {
					Instantiate(floor4, new Vector3 (i*10, 0, j*10), Quaternion.identity, gameObject.transform);
				}
			}
		}
	}
}
