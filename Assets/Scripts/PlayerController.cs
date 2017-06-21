﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Object ship;
	public float speed = 10;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position += new Vector3 (-speed * Time.deltaTime, 0, 0);
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position += new Vector3 (speed * Time.deltaTime, 0, 0);
		}
	}
}
