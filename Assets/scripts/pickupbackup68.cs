using UnityEngine;
using System.Collections;

public class pickupbackup68 : MonoBehaviour {

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
	public Camera mainCamera;
	int layerMask = 1 << 9;
	private bool pickupcheck;
	private Vector3 centerScreen;
	private Vector3 midScreen;
	private GameObject clone;
	
	
	
	// Use this for initialization
	
	void Awake (){
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera>();
		pickupcheck = GameObject.FindGameObjectWithTag ("Player").GetComponent<PickUpObject>();
		int layerMask = 1 << 8;
		
	}
	
	void Start() {
		
		grabpoint = GameObject.FindWithTag("grabpoint"); 
		holdpoint = GameObject.FindWithTag ("holdpoint");
	}
	
	
	// Update is called once per frame
	void Update () {
		
		centerScreen = new Vector3 (Screen.width / 2, Screen.height / 2, 0);
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
			
			Ray ray = mainCamera.ScreenPointToRay (new Vector3 (Screen.width / 2, Screen.height / 2, 0));
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, Mathf.Infinity, layerMask)) {
				Pickupable p = hit.collider.GetComponent<Pickupable> ();
				if (p != null) {
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


		
		
		/* 6-7
		carriedObject.gameObject.rigidbody.AddForce (Camera.main.transform.forward * speed);
		*/
		//float mainCameraZ = mainCamera.transform.position.z;
		//carriedObject.gameObject.rigidbody.AddForce (mainCamera.transform.forward * speed);
		midScreen = mainCamera.camera.ScreenToWorldPoint(new Vector3 (Screen.width / 2, Screen.height / 2, 1));
		
		//carriedObject.gameObject.rigidbody.AddForce ((carriedObject.transform.position - midScreen) * speed);
		carriedObject.gameObject.rigidbody.AddForce (midScreen  * speed);
		
		
		carriedObject = null;
		
		
		
	}
}
