using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {
	public float damage = 200f;
	private PlayerHealth playerHealth;




	void Awake (){
		playerHealth = gameObject.GetComponent<PlayerHealth> ();
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("o"))
		    {
			playerHealth.TakeDamage(damage);}
	}
}
