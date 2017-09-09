using UnityEngine;
using System.Collections;

public class SearchArea1 : MonoBehaviour {
	EnemyCtrl3 enemyCtrl;
	void Start()
	{
		// EnemyCtrlをキャッシュする
		enemyCtrl = transform.root.GetComponent<EnemyCtrl3>();
	}
	
	void OnTriggerStay( Collider other )
	{
        // Playerタグをターゲットにする
		if (other.tag == "unitychan") {
			enemyCtrl.SetAttackTarget (other.transform);
		}
	}
}
