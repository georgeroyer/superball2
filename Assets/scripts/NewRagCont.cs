using UnityEngine;
using System.Collections;

public class NewRagCont : MonoBehaviour {


	public GameObject HitReciever;
	public ragdollControl ragScript;
	public ICode.ICodeBehaviour aiScript;
	private string hitobject;

	
	void Start (){
		//ragScript.enabled = true; 

		foreach (Collider collide in GetComponentsInChildren<Collider>()) {
			collide.gameObject.AddComponent<Pickupable>();
		}
	} 
	
	void Update() {

	}
	 
	void OnPickableCollision(object obj) 
	{
		Collision other = (Collision)obj;
		foreach (ContactPoint contact in other.contacts) {
			if (other.gameObject.tag.Equals ("canHit")) {
				Debug.Log ("hit green man");
				//if (collision.relativeVelocity.magnitude > 2) {
					//gameObject.GetComponent<ragdollControl>().enabled = true;
					ragScript.enabled = true;
					aiScript.SetNode ("Ded");
					break;
				//}
			}
		}

	}
}


