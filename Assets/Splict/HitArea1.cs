using UnityEngine;
using System.Collections;

public class HitArea1 : MonoBehaviour {
	
	void Damage(AttackArea.AttackInfo attackInfo)
	{
		transform.root.SendMessage ("Damage",attackInfo);
	}
}
