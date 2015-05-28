using UnityEngine;
using System.Collections;

public class AnimatorToRagdoll : MonoBehaviour 
{
	private Rigidbody[] childRigidBodies;

	void Awake()
	{
		childRigidBodies = this.GetComponentsInChildren<Rigidbody> ();
	}

	// Use this for initialization
	void Start () 
	{
		SetChildRigidBodiesKinimatic (true);
	}
	
	// Update is called once per frame
//	void Update () 
//	{
//		if(Input.GetMouseButtonDown(0))		
//		{			
//			Debug.Log("Activating ragdoll");
//			SetChildRigidBodiesKinimatic (false);
//
//			Destroy(this.rigidbody);
////			Destroy(this.collider);
////			Destroy (this.GetComponent<Animator>());
////			Destroy (this.GetComponent<DonePlayerMovement>());
////			Destroy (this.GetComponent<DonePlayerInventory>());
//			this.collider.enabled = false;
//			this.GetComponent<Animator>().enabled = false;
//			this.GetComponent<DonePlayerMovement>().enabled = false;
//			this.GetComponent<DonePlayerInventory>().enabled = false;
//		}
//	}

	public void SetChildRigidBodiesKinimatic (bool isKinematic)
	{
		if (childRigidBodies != null)
		{
			foreach (var childRigidBody in childRigidBodies) 
			{
				childRigidBody.isKinematic = isKinematic;
			}
		}
	}
}
