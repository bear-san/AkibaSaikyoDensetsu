using UnityEngine;
using System.Collections;

public class PlayerAnimationController2 : MonoBehaviour {
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		//Animator = GetComponent<UnityEngine.Animator.SetBool(string , bool);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W)) {
			transform.position += transform.forward * 0.05f;
			animator.SetBool ("is_running", true);
		}else{
			animator.SetBool ("is_running", false);
		}
		if (Input.GetKey(KeyCode.D)) {
			transform.Rotate(0, 8, 0);
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.Rotate(0, -8, 0);
		}
		if (Input.GetKey (KeyCode.Space)) {
			animator.SetBool ("is_jumping", true);
		} else {
			animator.SetBool ("is_jumping", false);
		}
		if (Input.GetKey (KeyCode.V)) {
			animator.SetBool ("IsAttack", true);
		} else {
			animator.SetBool ("IsAttack", false);
		}
	}
}
