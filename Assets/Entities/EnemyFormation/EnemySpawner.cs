using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;

	// Use this for initialization
	void Start () {
		foreach (Transform child in transform) {
			GameObject enemy = Instantiate (enemyPrefab, child.transform.position, Quaternion.identity) as GameObject; // needs as GameObject because Instantiate creates Objects
			enemy.transform.parent = child;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
