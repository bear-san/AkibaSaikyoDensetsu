using UnityEngine;
using System.Collections;

/*public class PlayerHaelth : MonoBehaviour {
	private Animator animator;

    public int maxHealth = 100;
    public int curHealth = 100;

    public float healthBarLength;

	//private Animator animator;

	// Use this for initialization
	void Start () {
        healthBarLength = Screen.width / 2;

		animator = GetComponent<Animator> ();

    }
	
	// Update is called once per frame
	void Update () {
        AddjustCurrentHealth(0);
	}

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

		if(curHealth <= 0 )
		{	
			animator.SetBool ("is_lose", true);
		}else{
			animator.SetBool ("is_lose", false);
			//LOSE ();

			// エネミーの削除
			//Destroy (gameObject);
		}

        healthBarLength = (Screen.width / 2) * (curHealth / (float)maxHealth);
    }
}*/