using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private Status _status;
	private Input _input;

	private void Start()
	{
		_status = Resources.Load<Status>("Data/PlayerStatus");
		_status = Instantiate(_status); // ï°êª
		_status._MoveSpeed = 1.0f;
		_input = new Input();
		_input.Enable();
	}

	private void FixedUpdate()
	{
		Move(Time.fixedDeltaTime);
	}

	private void Move(float deltaTime)
	{
		Vector2 dir = _input.Player.Move.ReadValue<Vector2>();

		Vector2 pos = transform.position;
		pos += dir * _status._MoveSpeed * deltaTime;
		transform.position = pos;
	}
}
