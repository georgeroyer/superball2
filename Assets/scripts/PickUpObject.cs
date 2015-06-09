using UnityEngine;
using System.Collections;

public class PickUpObject : MonoBehaviour {

	GameObject grabpoint;
	GameObject holdpoint;
	private Vector3 holdposition;
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
	Rigidbody clone;
	GameObject Clone;
	float z ;
	//private Rigidbody clone;



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
		Clone = null;

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

		GameObject clone = carriedObject;
		//Rigidbody clone = carriedObject.rigidbody;
		Clone = clone;

		midScreen = mainCamera.camera.ViewportToWorldPoint (new Vector3 (.5f, .5f, 100f));
		//carriedObject.gameObject.rigidbody.AddForce (Camera.main.transform.forward * speed);

		//dir = midScreen - carriedObject.transform.position ;
		dir = carriedObject.transform.position - midScreen ;
		dir = dir.normalized;
		carriedObject.rigidbody.AddRelativeForce (dir * speed);


		Clone.rigidbody.isKinematic = false; 
		Clone.gameObject.rigidbody.AddForce (0, 0, 1 * 50);
		//Destroy (carriedObject);
		//while (cloneinplay = true) {
			//cloneInstance.gameObject.rigidbody.velocity = transform.TransformDirection (Vector3.forward * speed);
			//cloneInstance = postClone;

	
		//clone.gameObject.rigidbody.AddForce (Vector3.forward * speed);

		/* 6-7
		carriedObject.gameObject.rigidbody.AddForce (Camera.main.transform.forward * speed);
		*/
		//float mainCameraZ = mainCamera.transform.position.z;
		//carriedObject.gameObject.rigidbody.AddForce (mainCamera.transform.forward * speed);


		//carriedObject.gameObject.rigidbody.AddForce ((carriedObject.transform.position - midScreen) * speed);

		//carriedObject.gameObject.rigidbody.AddForce (midScreen  * speed);
		//Destroy (carriedObject);

		carriedObject = null;
		Destroy (carriedObject.gameObject);
	}
	
	void FixedUpdate(){
		Clone.gameObject.rigidbody.AddForce (midScreen * 50);
		Debug.Log ("Made it this far");
		//Destroy (carriedObject.gameObject);

	}






}











