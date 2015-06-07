using UnityEngine;
using System.Collections;

public class pickupdetectorbackup : MonoBehaviour {

	
	
	public Camera mainCamera;
	private bool pickupcheck;
	GameObject rumbleObject;
	public float speed; 
	int layerMask = 1 << 9;
	//private bool carrying;
	
	// Use this for initialization
	void Awake () {
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera>();
		pickupcheck = GameObject.FindGameObjectWithTag ("Player").GetComponent<PickUpObject>();
		int layerMask = 1 << 8;
		//carrying = pickupcheck.carrying(); 
		
	}
	
	// Update is called once per frame
	void Update () {
		if (PickUpObject.carrying == false) {
			//{
			
			DetectRay ();
		}
		
	}
	
	
	void DetectRay(){
		
		Ray ray = mainCamera.ScreenPointToRay (new Vector3 (Screen.width / 2, Screen.height / 2, 0));	
		RaycastHit hit;  
		
		//if(Physics.Raycast(transform.position, Vector3.forward, Mathf.Infinity, layerMask)){
		//if (Physics.Raycast (ray, out hit)) {
		if (Physics.Raycast (ray, out hit, Mathf.Infinity, layerMask)) {
			Pickupable p = hit.collider.GetComponent<Pickupable> ();
			if (p != null) {
				print (" pick up at camera center");
				p.rigidbody.AddForce(0,40,0);
				//rumbleObject = p.gameObject;
				//rumbleObject.transform.Rotate (new Vector3 (1, 1, 0) * Time.deltaTime);;
				//rumbleObject.rigidbody.AddForce (0, 100, 0); 
			}
		}
	}
	
	void Shake (){
		rumbleObject.gameObject.rigidbody.AddForce (0, speed, 0);
	}
}
//void Shake (GameObject rumbleObject){
//	rumbleObject.rigidbody.AddForce (0, 100, 0);
//}
//}

