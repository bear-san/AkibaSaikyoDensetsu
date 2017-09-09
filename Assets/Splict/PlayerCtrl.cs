using UnityEngine;
using System.Collections;

public class PlayerCtrl : MonoBehaviour {
	const float RayCastMaxDistance = 100.0f;
	CharacterStatus status;
	CharaAnimation1 CharaAnimation1;
	Transform attackTarget;
	InputManager inputManager;
	GameRuleCtrl gameRuleCtrl;
	public float attackRange = 1.5f;
	private Animator animator;
	
	// ステートの種類.
	enum State {
		Walking,
		Attacking,
		Died,

	} ;
	
	State state = State.Walking;		// 現在のステート.
	State nextState = State.Walking;	// 次のステート.
	
	
	// Use this for initialization
	void Start () {
		status = GetComponent<CharacterStatus>();
		CharaAnimation1 = GetComponent<CharaAnimation1>();
		inputManager = FindObjectOfType<InputManager>();
		gameRuleCtrl = FindObjectOfType<GameRuleCtrl>();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		switch (state) {
		case State.Walking:
			Walking();
			break;
		case State.Attacking:
			Attacking();
			break;
		}
		
		if (state != nextState)
		{
			state = nextState;
			switch (state) {
			case State.Walking:
				WalkStart();
				break;
			case State.Attacking:
				AttackStart();
				break;
			case State.Died:
				Died();
				break;
			}
		}
		if (Input.GetKey (KeyCode.W)) {
			transform.position += transform.forward * 0.5f;
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
		if (Input.GetKey (KeyCode.LeftShift)) {
			animator.SetBool ("IsAttack", true);
		} else {
			animator.SetBool ("IsAttack", false);
		}
	}
	
	
	// ステートを変更する.
	void ChangeState(State nextState)
	{
		this.nextState = nextState;
	}
	
	void WalkStart()
	{
		StateStartCommon();
	}
	
	void Walking()
	{
		if (inputManager.Clicked ()) {
			// RayCastで対象物を調べる.
			Ray ray = Camera.main.ScreenPointToRay (inputManager.GetCursorPosition ());
			RaycastHit hitInfo;
			if (Physics.Raycast (ray, out hitInfo, RayCastMaxDistance, (1 << LayerMask.NameToLayer ("Ground")) | (1 << LayerMask.NameToLayer ("EnemyHit")))) {
				// 地面がクリックされた.
				if (hitInfo.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
					SendMessage("SetDestination",hitInfo.point);
				// 敵がクリックされた.
				if (hitInfo.collider.gameObject.layer == LayerMask.NameToLayer ("EnemyHit")) {
					// 水平距離をチェックして攻撃するか決める.
					Vector3 hitPoint = hitInfo.point;
					hitPoint.y = transform.position.y;
					float distance = Vector3.Distance (hitPoint, transform.position);
					if (distance < attackRange) {
						// 攻撃.
						if (Input.GetKey (KeyCode.LeftShift)) {
							animator.SetBool ("IsAttack", true);
							attackTarget = hitInfo.collider.transform;
							ChangeState (State.Attacking);
						} else {
							SendMessage ("SetDestination", hitInfo.point);
							animator.SetBool ("IsAttack", false);
						}
					}
				}
			}
		}
	}

	// 攻撃ステートが始まる前に呼び出される.
	void AttackStart()
	{
		StateStartCommon();
		status.attacking = true;
		
		// 敵の方向に振り向かせる.
		Vector3 targetDirection = (attackTarget.position-transform.position).normalized;
		SendMessage("SetDirection",targetDirection);
		
		// 移動を止める.
		SendMessage("StopMove");
	}
	
	// 攻撃中の処理.
	void Attacking()
	{
		if (CharaAnimation1.IsAttacked())
			ChangeState(State.Walking);
	}
	
	void Died()
	{
		status.died = true;
		gameRuleCtrl.GameOver();
	}
	
	void Damage(AttackArea.AttackInfo attackInfo)
	{
		status.HP -= attackInfo.attackPower;
		if (status.HP <= 0) {
			status.HP = 0;
			// 体力０なので死亡ステートへ.
			ChangeState(State.Died);
		}
	}
	
	// ステートが始まる前にステータスを初期化する.
	void StateStartCommon()
	{
		status.attacking = false;
		status.died = false;
	}
}