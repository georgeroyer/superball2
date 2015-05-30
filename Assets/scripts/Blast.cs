using UnityEngine;
using System.Collections;

public class Blast : MonoBehaviour {

	// Use this for initialization
	
	public Rigidbody blastbeam;
	public GameObject blastobject;
	public GameObject MainCamera;
	private Vector3 blastorigin;
	public float speed;

			

			void Update() {
				if (Input.GetButtonDown("Fire1")) {

			Rigidbody instantiatedBlast = Instantiate(blastbeam, transform.position, transform.rotation)
				as Rigidbody;

			instantiatedBlast.velocity = transform.TransformDirection(new Vector3 (0,0, speed));
		}
	}
			                                                          }
	


