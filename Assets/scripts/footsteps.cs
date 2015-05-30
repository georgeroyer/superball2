using UnityEngine;
using System.Collections;

public class footsteps : MonoBehaviour {

	public AudioClip [] steps;
	public GameObject stepsound;

	// Use this for initialization


	
	// Update is called once per frame
	void Update() {
		if (Input.GetKeyDown ("w"))
		{
			AudioSource audio = GetComponent<AudioSource>();
			audio.Play ();
	}
}
}