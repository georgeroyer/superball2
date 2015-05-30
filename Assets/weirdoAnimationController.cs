using UnityEngine;
using System.Collections;

public class weirdoAnimationController : MonoBehaviour {
	public Animator anim;
	public float speed;
	public float move; 
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		anim.SetFloat ("Speed", move);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
