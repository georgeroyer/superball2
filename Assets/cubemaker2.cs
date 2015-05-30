using UnityEngine;
using System.Collections;

public class cubemaker2 : MonoBehaviour {

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
		if (Input.GetKeyDown ("x")) {
			SpawnPosition = MainCamera.transform.forward * DistancetoCamera + MainCamera.transform.position;
			Instantiate (Cubeprefab, SpawnPosition, Quaternion.identity);
		}
	}
	
	//Instantiate(Cubeprefab, new Vector3 (gameObject.GetComponent("cubeorigin") 2, 0));
	//Cubeprefab.Instance = Instantiate(Cubeprefab, gameObject.GetComponent("cubeorigin"), gameObject.GetComponent("cubeorigin"))as Rigidbody;
	
}