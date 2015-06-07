using UnityEngine;
using System.Collections;

public class pickupablebackup : MonoBehaviour {

	
	GameObject grabpoint;
	GameObject holdpoint;
	public static bool carrying;
	public bool held;
	GameObject carriedObject;
	public float distance;
	public float smooth;
	public float speed;
	private float throwdirection;
	public float pullspeed;
	public GameObject MainCamera;
	private Vector3 SpawnPosition;
	private Vector3 dir;
	
	// Use this for initialization
	void Start() {
		
		grabpoint = GameObject.FindWithTag("grabpoint"); 
		holdpoint = GameObject.FindWithTag ("holdpoint");
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
		//carriedObject.rigidbody.AddForce (dir * pullspeed);
		
		//float step = pullspeed * Time.deltaTime;
		o.rigidbody.isKinematic = false;
		//o.transform.position = Vector3.MoveTowards(holdpoint.transform.position, holdpoint.transform.position, step);
		//o.transform.position = Vector3.Lerp(holdpoint.transform.position, holdpoint.transform.position + holdpoint.transform.forward * distance, Time.deltaTime * smooth);
		
	}
	
	void OnTriggerEnter(Collider other){
		
		carriedObject.transform.position = Vector3.Lerp (holdpoint.transform.position, holdpoint.transform.position, Time.deltaTime * smooth);
		Debug.Log ("Object in Trigger");
		{
			if
			(other.gameObject == carriedObject) {
				//carrying = false;
				held = true;
				
				//carrying = false;
				//held = true;
			}
		}
	}
	
	void holding (GameObject o){
		carriedObject.transform.position = Vector3.Lerp (holdpoint.transform.position, holdpoint.transform.position, Time.deltaTime * smooth);
		o.transform.Rotate (new Vector3 (1, 1, 0) * Time.deltaTime);
	}
	
	
	
	
	public void pickup(){
		
		if (Input.GetButtonDown("Fire1")) {
			int x = Screen.width / 2;
			int y = Screen.height /2;
			
			//Ray ray = grabpoint.transform.forward.ScreenPointToRay(new Vector3(x,y));
			Ray ray = grabpoint.camera.ScreenPointToRay(new Vector3 (x,y));
			RaycastHit hit;
			
			if(Physics.Raycast(ray, out hit)){
				Pickupable p = hit.collider.GetComponent<Pickupable>();
				if(p != null){
					carrying = true;
					carriedObject = p.gameObject;
					
					
				}
			}
		}
	}
	
	void checkThrow (){
		if (Input.GetButtonDown ("Fire1")) {
			
			throwObject ();
		}
	}
	public void throwObject (){
		carrying = false;
		held = false;
		carriedObject.gameObject.rigidbody.isKinematic = false;
		
		//throwdirection = (MainCamera.transform.forward);
		
		//carriedObject.gameObject.rigidbody.AddTorque (Camera.main.transform.forward * speed);
		carriedObject.gameObject.rigidbody.AddForce (Camera.main.transform.forward * speed);
		
		//carriedObject.gameObject.rigidbody.AddForce 
		//(throwdirection * speed, 0, 0);
		
		
		
		//carriedObject.gameObject.rigidbody.transform.TransformDirection (new Vector3 (speed, 0, 0));
		
		
		
		
		
		carriedObject = null;
		
		//if (Input.GetKeyDown ("x")) {
		//SpawnPosition = MainCamera.transform.forward * DistancetoCamera + MainCamera.transform.position;
		//Instantiate (Cubeprefab, SpawnPosition, Quaternion.identity);
		
	}
}

