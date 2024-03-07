using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
	private Vector3 moveDir = Vector3.zero;

	private Rigidbody rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		rb.velocity = moveDir * 10;
	}

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
		}
	}

	private void OnAttack(InputValue inputValue)
	{

	}
}
