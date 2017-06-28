using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;
	public float width = 4f;
	public float height = 4f;
	public float speed = 3f;

	bool movingRight;
	float xmax;
	float xmin;

	// Use this for initialization
	void Start () {
		float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint (new Vector3 (0,0, distanceToCamera));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint (new Vector3 (1,0, distanceToCamera));

		xmax = rightMost.x;
		xmin = leftMost.x;
        SpawnEnemies();

	}

	public void OnDrawGizmos() {
		Gizmos.DrawWireCube (transform.position, new Vector3 (width, height));
	}

	void Movement() {

	}

    bool AllMembersDead()
    {
        foreach(Transform child in transform)
        {
            if (child.childCount > 0)
            {
                return false;
            }
        }

        return true;
    }

    void SpawnEnemies()
    {
        foreach (Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject; // needs as GameObject because Instantiate creates Objects
            enemy.transform.parent = child;
        }
    }
	
	// Update is called once per frame
	void Update () {
		if (movingRight) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		} else {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}

		if (transform.position.x + 0.5f * width > xmax) {
			movingRight = false;
		}
        else if (transform.position.x - 0.5f * width < xmin)
        {
            movingRight = true;
        }

        if (AllMembersDead())
        {
            Debug.Log("Dead");
            SpawnEnemies();
        }

    }
}
