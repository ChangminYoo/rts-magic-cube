using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, IState
{
	#region Animator Parameters
	private readonly string ANIMATOR_PARAM_IDLE = "Idle";
	private readonly string ANIMATOR_PARAM_WALK_BACK = "Walk Backward";
	private readonly string ANIMATOR_PARAM_MOVE_SPEED = "Move Speed";
	private readonly string ANIMATOR_PARAM_DEAD = "Dead";

	private readonly string ANIMATOR_PARAM_ATTACK= "Longbow Shoot Attack";
	#endregion

	private Vector3 moveDir = Vector3.zero;
	private Rigidbody rb;
	private Animator animator;
	private float moveSpeed = 0f;

	private IState.State characterState = IState.State.Idle;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
	}

	private void Update()
	{
		if (IsDead()) return;

		Move();
	}

	#region IState
	public void ChangeState(IState.State nextState)
	{
		switch (nextState)
		{
			case IState.State.Idle:
				animator.SetBool(ANIMATOR_PARAM_IDLE, true);
				moveSpeed = 0f;
				break;
			case IState.State.Run:
				animator.SetBool(ANIMATOR_PARAM_IDLE, false);
				moveSpeed = 200f;
				break;
			case IState.State.Dead:
				animator.SetBool(ANIMATOR_PARAM_DEAD, true);
				break;
		}

		characterState = nextState;
	}

	public bool IsDead()
	{
		return false;
	}

	public void Move()
	{		
		rb.velocity = moveDir * moveSpeed * Time.deltaTime;
		animator.SetFloat(ANIMATOR_PARAM_MOVE_SPEED, moveSpeed);
	}
	#endregion

	#region Input Actions
	/// <summary>
	/// Unity input actions 에서 설정한 키를 입력하면 On + Actions name 이름 함수를 자동으로 호출함
	/// </summary>
	/// <param name="inputValue"></param>
	private void OnMove(InputValue inputValue)
	{
		Vector2 input = inputValue.Get<Vector2>();
		if (input != null)
		{
			var moveXDir = input.x;
			var moveZDir = input.y;

			moveDir = new Vector3(moveXDir, 0, moveZDir);

			if (moveDir.magnitude == 0)
			{
				ChangeState(IState.State.Idle);
			}
			else
			{
				ChangeState(IState.State.Run);
			}
		}
	}

	private void OnAttack(InputValue inputValue)
	{
		animator.SetFloat(ANIMATOR_PARAM_MOVE_SPEED, moveSpeed);

		animator.SetTrigger(ANIMATOR_PARAM_ATTACK);
	}
	#endregion
}
