using UnityEngine;
using System.Collections;

public class jumpcube : MonoBehaviour {


	
	
	void Update () {
		
		if(Input.GetKeyDown("c")  )
		{
			rigidbody.AddForce(0,300,0);
		}

	}
}