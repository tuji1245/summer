using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionManager : MonoBehaviour
{
	public struct Poligon
	{
		public List<Vector2> _Vertex;
	}
	List<Poligon> _poligonList;
	UnityEvent _onCollision;


	private void Start()
	{
		_poligonList = new List<Poligon>();
	}

	public void AddList(GameObject gameObject, Poligon poligon)
	{
		_poligonList.Add(poligon);
	}

	private void FixedUpdate()
	{
		foreach(var other in _poligonList)
		{
			if (!Check(Player.pos, other)) continue;
			
			_

		}
	}
	private bool Check(Vector2 p, Poligon other)
	{
		int hitCount = 0;

		for (int i = 0; i < other._Vertex.Count; i++)
		{
			Vector2 first = other._Vertex[i];
			Vector2 second = other._Vertex[i + 1];

			// 水平チェック
			if (first.y == second.y) continue;

			{   // yの範囲に入っているか
				float y_bigger = (first.y > second.y) ? first.y : second.y;
				float y_smaller = (first.y < second.y) ? first.y : second.y;
				if (p.y < y_smaller || y_bigger <= p.y) continue;
			}

			// 交点が右にあるならプラス
			int t = (int)(((second.x - first.x) * (p.y - first.y))
				/ (second.y - first.y) - (p.x - first.x));
			if (t > 0){ hitCount++;
			}
		}

		return ((hitCount % 2) == 0) ? false: true;
	}


	private void OnCollisionEnter(Collision collision)
	{
		if(collision.transform.tag)
	}
}
