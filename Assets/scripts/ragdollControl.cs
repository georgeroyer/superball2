using UnityEngine;
using System.Collections;

public class ragdollControl : MonoBehaviour {
		
		
		public Component[] bones;
		public Animator anim;

		public bool isDead;

		
		
		//weirdo_ragdoll
		// Use this for initialization
		void Start () {
			
			bones = gameObject.GetComponentsInChildren<Rigidbody> (); 
			anim = gameObject.GetComponent<Animator> ();
			
		}

		void Update (){
		if (Input.GetKeyDown ("p")) {
			isDead = true;
		}
			
		{
			if (isDead)
				killRagdoll ();
				//killAI ();
				
			
		}
	}
		
		// Update is called once per frame
		void killRagdoll () 
		{
			foreach (Rigidbody ragdoll in bones)
			{
				ragdoll.isKinematic = false;
			}
			
			anim.enabled = false;
			//anim.StopPlayback();
		}
	//void killAI ()
	//{
		//aiOn = false;

//}
}
