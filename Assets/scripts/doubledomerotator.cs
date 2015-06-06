using UnityEngine;
using System.Collections;

public class doubledomerotator : MonoBehaviour {

	public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (1, -1, 0) * speed * Time.deltaTime);
	}
}