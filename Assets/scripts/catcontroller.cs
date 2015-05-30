using UnityEngine;
using System.Collections;

public class catcontroller : MonoBehaviour {

	public Animator anim;

	public float move;
	public float h;
	public float a;
	//public float aa;
	public float sprint;
	public float runSpeed = 15.0f; //running speed
	private CharacterController chMotor;
	private Transform tr;



	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
	
		//CharacterController controller = GetComponent<CharacterController> ();
		//Vector3 horizontalVelocity = controller.velocity;
	}
	// Update is called once per frame
	void Update () {
		float move = Input.GetAxis ("Vertical");
		float h = Input.GetAxis ("Horizontal");
		anim.SetFloat ("Speed", move);
		anim.SetFloat ("Turn", h);
		anim.SetFloat ("Attack", a);
		//anim.SetFloat ("Attack2", aa);
		{
			if (Input.GetButtonDown("Fire1")) {
				 a = 0.2f;
			}
			else {
				 a = 0.0f;
			}
			//{
				//if (Input.GetButtonDown("Fire2")) {
				//	aa = 0.2f;
				//}
				//else {
				//	aa = 0.0f;
			//	}
				//anim.SetFloat ("SpeedBurst", move);
				//{
				//	if (Input.GetButtonDown("p")) {
					//	sprint = 0.2f;
				//	}
				//	else {
						//sprint = 0.0f;
				//	}
				//	{
				//		if (sprint > 0.0f) {

				//		}


		
	
}
}
}


