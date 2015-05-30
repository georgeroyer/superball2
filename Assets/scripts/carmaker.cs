using UnityEngine;
using System.Collections;

public class carmaker : MonoBehaviour {

	public Rigidbody Cubeprefab;
	public GameObject cubeorigin;
	private Vector3 SpawnPosition;
	public int DistancetoCamera; 
	public GameObject MainCamera;
	public Transform creation;
	
	void Start (){
		MainCamera = (GameObject)GameObject.FindWithTag ("MainCamera");
		DistancetoCamera = 5;
	}
	
	void Update ()
	{
		if (Input.GetKeyDown ("v")) {
			SpawnPosition = MainCamera.transform.forward * DistancetoCamera + MainCamera.transform.position;
			Instantiate (Cubeprefab, SpawnPosition, Quaternion.identity);
		}
	}


}
