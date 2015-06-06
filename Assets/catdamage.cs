using UnityEngine;
using System.Collections;

public class catdamage : MonoBehaviour {

	private CatHealth catHealth;

	void Awake (){
		catHealth = gameObject.GetComponent<CatHealth> ();
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetKey ("o"))
		{
			SendDamage();
		}
	}
	void SendDamage (){
		float damage = 5.0f;
		catHealth.TakeDamage (damage);
}
}