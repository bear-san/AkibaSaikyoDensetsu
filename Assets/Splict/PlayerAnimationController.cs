using UnityEngine;
using System.Collections;

public class PlayerAnimationController : MonoBehaviour {
	private Animator animator;
	
	public int maxHealth = 100;
	public int curHealth = 100;
	
	public float healthBarLength;

	GameRule GameRule;

	PlayerAnimationController status;

	enum State
	{
		Died,
	} ;

	// Use this for initialization
	void Start () {

		healthBarLength = Screen.width / 2;

		animator = GetComponent<Animator> ();
		//Animator = GetComponent<UnityEngine.Animator.SetBool(string , bool);

		GameRule = FindObjectOfType<GameRule> ();

	}

	/*void Died()
	{
		status.Died = true;
		GameRule.GameOver();
	}*/


	void OnGUI() {
		GUI.Box(new Rect(10, 10, Screen.width / 2 / (maxHealth / curHealth), 20), curHealth + "/" + maxHealth);
	}
	public void AddjustCurrentHealth(int abj) {
		curHealth += abj;
		
		if (curHealth < 0) 
			curHealth = 0;
		
		if (curHealth > maxHealth) 
			curHealth = maxHealth;
		
		if (maxHealth < 1) 
			maxHealth = 1;
	}

	// Update is called once per frame
	void Update () {
		AddjustCurrentHealth (0);

		if (Input.GetKey (KeyCode.W)) {
			transform.position += transform.forward * 0.09f;
			animator.SetBool ("is_running", true);
		} else {
			animator.SetBool ("is_running", false);
		}
		if (Input.GetKey (KeyCode.V)) {
			//transform.position += transform.forward * 0.09f;
			animator.SetBool ("IsAttack", true);
		} else {
			animator.SetBool ("IsAttack", false);
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.Rotate (0, 8, 0);
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.Rotate (0, -8, 0);
		}
		if (Input.GetKey (KeyCode.Space)) {
			animator.SetBool ("is_jumping", true);
		} else {
			animator.SetBool ("is_jumping", false);
		}
		if (curHealth <= 0) {
			animator.SetBool ("is_lose", true);
		}else{
			animator.SetBool ("is_lose", false);
		}
		/*if (EnemyHaelth <= 0) {
			animator.SetBool ("is_win", true);
		}else{
			animator.SetBool ("is_win", false);
		}*/
	}
}