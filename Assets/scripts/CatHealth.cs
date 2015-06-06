using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class CatHealth : MonoBehaviour {

	public float maxHealth = 100f;
	public float curHealth ;
	public float maxPSI = 100f;
	public float curPSI ;
	public Text healthText;
	public Text psiText;
	private float psiloss;
	public float regenrate = 5f;

	// Use this for initialization
	void Start () {
		psiloss = 1.0f;
		curHealth = 100f;
		curPSI = 100f;
		regenrate = 1.0f;

	}


	
	// Update is called once per frame
	void Update () {
		Invoke ("RegenerateHealth", 1f);
		
		healthText.text = "Health:" + curHealth.ToString();
		psiText.text = "PSI:" + curPSI.ToString ();
		if (curPSI >= 0f) 
		{
			PSIDrain();
		}

	}
	void PSIDrain (){
		curPSI = (curPSI - psiloss);
}
	public void TakeDamage (float amount){
		curHealth -= amount;	
	}
	void RegenerateHealth (){
			if (curHealth < maxHealth)
		{
				curHealth += (regenrate * Time.deltaTime);
			}
}
	}

		

