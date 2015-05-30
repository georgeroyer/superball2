using UnityEngine;
using System.Collections;

public class betterPickUpObject : MonoBehaviour {
	

		
		//GameObject grabpoint;
		GameObject holdpoint;
		bool carrying;
		bool held;
		bool goodforpickup;
		GameObject carriedObject;
		public float distance;
		public float smooth;
		public float speed;
		private float throwdirection;
		public float pullspeed;
		public GameObject MainCamera;
		private Vector3 SpawnPosition;
		private Vector3 dir;
		GameObject grabbed;
		
		// Use this for initialization
		void Start() {
			
			//grabpoint = GameObject.FindWithTag("grabpoint"); 
			holdpoint = GameObject.FindWithTag ("holdpoint");
			MainCamera = GameObject.FindWithTag ("MainCamera");
	
		}
		
		
		// Update is called once per frame
		void Update () {
			
			if (carrying) {
				carry (carriedObject);
				
			} 
			else 
			{
				pickup();
				
			}
			if (held) {
				holding (carriedObject);
				
				checkThrow ();
			}
			else
			{
				pickup();
				
			}
		}
		
		void carry(GameObject o) {
			dir = holdpoint.transform.position - carriedObject.transform.position;
			dir = dir.normalized;
			carriedObject.rigidbody.AddForce (dir * pullspeed);
			o.rigidbody.isKinematic = false;
		}
		
		void OnTriggerEnter(Collider other){
			
			carriedObject.transform.position = Vector3.Lerp (holdpoint.transform.position, holdpoint.transform.position, Time.deltaTime * smooth);
			Debug.Log ("Object in Trigger");
		{
			if
				(other.gameObject == carriedObject) {
				held = true;
					
					
			}
		}
}

		
		void holding (GameObject o){
			carriedObject.transform.position = Vector3.Lerp (holdpoint.transform.position, holdpoint.transform.position, Time.deltaTime * smooth);
			o.transform.Rotate (new Vector3 (15, 15, 0) * Time.deltaTime);
		}
		
	/**
		void OnTriggerEnter (Collision other) {
		if (other.gameObject.tag == "Pickupable") {
			Debug.Log ("Valid Object in Collider Box");
			grabbed = other.collider.rigidbody.gameObject;
			goodforpickup = true; 
		}
	}

		void OnTriggerExit (Collision other) {
			if (other.gameObject.tag == "Pickupable") {
				Debug.Log ("Valid Object left Collider Box");
				goodforpickup = false;
			grabbed = null;
								}
	}
	**/

		void pickup (){
	
			if(Input.GetButtonDown("Fire1")) {
			//int x = Screen.width / 2;
			//int y = Screen.height /2;
			if (goodforpickup == true){
			
			//Ray ray = MainCamera.camera.ScreenPointToRay(new Vector3 (x,y));
			//RaycastHit hit;
			
			//if(Physics.Raycast(ray, out hit)){
				Pickupable p = grabbed.collider.GetComponent<Pickupable>();
			//Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
			//Debug.DrawRay(transform.position, forward, Color.blue);
			if(p != null){
				carrying = true;
					carriedObject = grabbed.gameObject;
				carriedObject = p.gameObject;
	}
				}
		}
		}

			

		//void pickup(){
			
			//if (Input.GetButtonDown("Fire1")) {
				//int x = Screen.width / 2;
				//int y = Screen.height /2;
			//while (goodforpickup = true){
				
				//Ray ray = MainCamera.camera.ScreenPointToRay(new Vector3 (x,y));
					//RaycastHit hit;
				
				//if(Physics.Raycast(ray, out hit)){
					//Pickupable p = hit.collider.GetComponent<Pickupable>();
					//Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
					//Debug.DrawRay(transform.position, forward, Color.blue);
					//if(p != null){
						//carrying = true;
						//carriedObject = p.gameObject;
						
		void checkThrow (){
			if (Input.GetButtonDown ("Fire1")) {
				
				throwObject ();
			}
		}
		void throwObject (){
			carrying = false;
			held = false;
			carriedObject.gameObject.rigidbody.isKinematic = false;
			
			//throwdirection = (MainCamera.transform.forward);
			
			carriedObject.gameObject.rigidbody.AddTorque (Camera.main.transform.forward * speed);
			carriedObject.gameObject.rigidbody.AddForce (Camera.main.transform.forward * speed);
			
			//carriedObject.gameObject.rigidbody.AddForce 
			//(throwdirection * speed, 0, 0);
			
			//carriedObject.gameObject.rigidbody.transform.TransformDirection (new Vector3 (speed, 0, 0));
			
			
			carriedObject = null;
			
			
		}
	}

