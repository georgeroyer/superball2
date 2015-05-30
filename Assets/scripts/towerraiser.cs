using UnityEngine;
using System.Collections;

public class towerraiser : MonoBehaviour {

	
	void Update () {
		
		if(Input.GetKeyDown("f")  )
		{
			rigidbody.AddForce(0,10000,0);
		}
		
	}
}

