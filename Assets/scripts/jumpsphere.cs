using UnityEngine;
using System.Collections;

public class jumpsphere : MonoBehaviour {
	
	
	
	
	void Update () {
		
		if(Input.GetKeyDown("v")  )
		{
			rigidbody.AddForce(0,300,0);
		}
	}
}
