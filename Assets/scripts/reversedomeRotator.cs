﻿using UnityEngine;
using System.Collections;

public class reversedomeRotator : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0, -1, 0) * speed * Time.deltaTime);
	}
}
