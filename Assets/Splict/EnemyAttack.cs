using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public GameObject taget;
    public float attackTimer;
    public float coolDown;

    // Use this for initialization
    void Start()
    {
        attackTimer = 0;
        coolDown = 2.0f;

    }

    // Update is called once per frame
    void Update(){
        if (attackTimer > 0)
            attackTimer -= Time.deltaTime;

        if (attackTimer < 0)
            attackTimer = 0;

        if (attackTimer == 0) ;{
            Attack();
            attackTimer = coolDown;
        }
    }

    private void Attack()
    {
        float distance = Vector3.Distance(taget.transform.position, transform.position);

        Vector3 dir = (taget.transform.position - transform.position).normalized;

        float direction = Vector3.Dot(dir, transform.forward);

        Debug.Log(direction);

/*		if (PlayerHaelth = 0)
			Attack = 0;
*/
        //Debug.Log(distance);
//        if (distance < 2.5f)
        if (distance < 0.25f)
		{
            if (distance > 0){
				PlayerAnimationController eh = (PlayerAnimationController)taget.GetComponent("PlayerAnimationController");
			eh.AddjustCurrentHealth(-1);
			}
        }
    }

}