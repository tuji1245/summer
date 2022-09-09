using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MyCollider : MonoBehaviour
{
	public class Polygon
	{
		public Polygon()
		{
			_Vertex = new List<Vector2>();
		}

		public List<Vector2> _Vertex;
	}

	static public bool CheckPointPolygon(Vector2 p, Polygon other)
	{
		int hitCount = 0;
		Debug.Log(other._Vertex.Count);
		for (int i = 0; i < other._Vertex.Count - 1; i++)
		{
			Vector2 first = other._Vertex[i];
			Vector2 second = other._Vertex[i + 1];

			// 水平チェック
			if (first.y == second.y) continue;

			{	// yの範囲に入っているか
				float y_bigger = (first.y > second.y) ? first.y : second.y;
				float y_smaller = (first.y < second.y) ? first.y : second.y;
				if (p.y < y_smaller || y_bigger <= p.y) continue;
			}

			// 交点が右にあるならプラス
			int t = (int)(((second.x - first.x) * (p.y - first.y))
				/ (second.y - first.y) - (p.x - first.x));
			if (t > 0){ hitCount++;	}
		}

		return ((hitCount % 2) == 0) ? false: true;
	}
}
