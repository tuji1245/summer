using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	float _range;
	Vector2[] _offset;

	GameObject _player;
	[SerializeField]
	float _moveSpeed;
	[SerializeField]
	int _atk;

	public int _Atk { get { return _atk; } }

	[HideInInspector]
	public EnemyGenerator _Generator;

	private void Start()
	{
		_range = 1.0f;
		_offset = new Vector2[4];
		_offset[0] = new Vector2(-_range, _range);
		_offset[1] = new Vector2(_range, _range);
		_offset[2] = new Vector2(_range, -_range);
		_offset[3] = new Vector2(-_range, -_range);

		_player = GameObject.Find("Player");
	}
	private void FixedUpdate()
	{
		drawNeer(MyTime.gameObjectTime);
	}

	void drawNeer(float tick)
	{
		Vector2 playerPos = _player.transform.position;
		Vector2 selfPos = transform.position;
		Vector2 dir = (playerPos - selfPos).normalized;

		selfPos += dir * _moveSpeed * tick;
		transform.position = new Vector3(selfPos.x, selfPos.y, 0);
	}

	MyCollider.Polygon calc()
	{
		var polygon = new MyCollider.Polygon();
		for (int i = 0; i < 4; i++)
		{
			Vector2 pos = transform.position;
			pos += _offset[i];
			polygon._Vertex.Add(pos);
		}
		return polygon;
	}
	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.tag != "bullet") { return; }

		bool hit = MyCollider.CheckPointPolygon(collision.transform.position, calc());
		if(!hit){ return; }
		_Generator.DestroyEnemy(gameObject);
	}
}
