using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public float health = 100f;
	public float resetAfterDeathTime = 5f;
	// Use this for initialization
	public Animator anim;
	public catcontroller catcontrol;
	private float timer;
	public bool playerDead;
	private SceneFadeInOut sceneFadeInOut;



	void Start () {
		//anim = gameObject.GetComponent<Animator>;
		//catcontrol = gameObject.GetComponent<catcontroller>;
		sceneFadeInOut = GameObject.FindGameObjectWithTag ("gamecontroller").GetComponent<SceneFadeInOut> ();

	}

	void update (){
		if (health <= 0f) {
			if (!playerDead)
				PlayerDying ();
			else {
				PlayerDead ();
				LevelReset ();
			}
		}
	}

	void PlayerDying (){

		playerDead = true;
		Debug.Log ("I died");
	}

	void PlayerDead (){
		//anim.enabled = false;
		//catcontrol.enabled = false;
	}

	void LevelReset(){
		timer += Time.deltaTime;
		if (timer >= resetAfterDeathTime) {
			sceneFadeInOut.EndScene ();
		}
	}

	public void TakeDamage (float amount){
			health -= amount;

	}
}
