using UnityEngine;
using System.Collections;

public class EnemyHaelth : MonoBehaviour
{
    public int maxHealth = 100;
    public int curHealth = 100;

    public float healthBarLength;

	// 爆発のPrefab
	public GameObject explosion;

	GameRule GameRule;
	
	// 爆発の作成
	public void Explosion ()
	{
		Instantiate (explosion, transform.position, transform.rotation);
	}

    // Use this for initialization
    void Start()
    {
        healthBarLength = Screen.width / 2;

		GameRule = FindObjectOfType<GameRule> ();

    }

    // Update is called once per frame
    void Update()
    {
       AddjustCurrentHealth(0);
    }

    void OnGUI() {
        GUI.Box(new Rect(10, 40, Screen.width / 2 / (maxHealth / curHealth), 20), curHealth + "/" + maxHealth);
    }

	void Died()
	{
		//status.died = true;
		Destroy(gameObject);
		if (gameObject.tag == "Robot")
		{
			GameRule.GameClear();
		}
	}

    public void AddjustCurrentHealth(int abj){
		curHealth += abj;

		if (curHealth < 0)
			curHealth = 0;

		if (curHealth > maxHealth)
			curHealth = maxHealth;

		if (curHealth <= 0){

			Explosion ();

			Destroy (gameObject);

		}

		if (maxHealth < 1)
			maxHealth = 1;

		healthBarLength = (Screen.width / 2) * (curHealth / (float)maxHealth);
    }
}