using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
	List<GameObject> _enemyList;
	static GameObject _oridinal;
	GameObject _player;

	private void Start()
	{
		_enemyList = new List<GameObject>();
		if(_oridinal == null)
		{
			_oridinal = Resources.Load<GameObject>("Prefab/Enemy");
		}

		_player = GameObject.Find("Player");
	}

	private void FixedUpdate()
	{
		TryCreate();
	}
	private void TryCreate()
	{
		if (_enemyList.Count > 10) return;
		float range = 10.0f;
		Vector2 dir;
		dir.x = Mathf.Cos(Random.Range(0, 360) * Mathf.Deg2Rad);
		dir.y = Mathf.Sin(Random.Range(0, 360) * Mathf.Deg2Rad);
		Vector2 playerPos = _player.transform.position;
		Vector2 pos = playerPos + dir * range;
		Create(pos);
	}

	private void Create(Vector3 pos)
	{
		var obj = Instantiate<GameObject>(_oridinal, pos, Quaternion.identity, transform);
		obj.GetComponent<Enemy>()._Generator = this;
		_enemyList.Add(obj);
	}

	public void DestroyEnemy(GameObject obj)
	{
		_enemyList.Remove(obj);
		Destroy(obj);
	}
}
