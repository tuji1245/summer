using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private PayerStatus _status;
	public int _HP { get { return _status._Hp; } }
	private Input _input;
	private Transform _cursor;

	[SerializeField]
	private GameObject _bullet;
	[SerializeField]
	private float _bulletPower;

	private void Start()
	{
		_status = Resources.Load<PayerStatus>("Data/PlayerStatus");
		_status = Instantiate(_status); // ï°êª
		_input = new Input();
		_input.Enable();
		_input.Player.Fire.performed += x => Fire();

		_cursor = GameObject.Find("Cursor").transform;

		if(_bullet == null)
			_bullet = Resources.Load<GameObject>("Prefab/Bullet");
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

	private void Fire()
	{
		// ï˚å¸éZèo
		Vector2 targetPos = _cursor.position;
		Vector2 selfPos = transform.position;
		Vector2 dir = (targetPos - selfPos).normalized;
		var bullet = GameObject.Instantiate(_bullet, selfPos, Quaternion.identity);
		var movement = bullet.AddComponent<Bullet>();
		movement._bulletStatus = new BulletStatus(dir, _bulletPower);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag != "Enemy") { return; }
		Debug.Log(collision.GetComponent<Enemy>()._Atk);
		_status._Hp -= collision.GetComponent<Enemy>()._Atk;
	}
}
