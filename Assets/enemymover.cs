using UnityEngine;
using System.Collections;

public class enemymover : MonoBehaviour {
	
		
		public Transform target;
	public float Speed;
	public float move;
	public float rotationSpeed;
	public Animator anim;
	private Transform myTransform;

	void Awake(){
		myTransform = transform;
	}
	
	//Use this to initialize
	void Start (){
		GameObject go = GameObject.FindGameObjectWithTag("Player");
		anim = GetComponent<Animator> ();
		anim.SetFloat ("Speed", move);

		
		target = go.transform;
	}
	
	//Remember that the Update() is called once per frame
	void Update(){

		
		//Look at target
		myTransform.rotation = Quaternion.Slerp(myTransform.rotation,   Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);
		
		//Move towards player
		myTransform.position += myTransform.forward * Speed * Time.deltaTime;
	}
}
