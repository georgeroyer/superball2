using UnityEngine;
using System.Collections;

public class prayercuberotate : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (1, 1, 2) * Time.deltaTime);
	}
}
