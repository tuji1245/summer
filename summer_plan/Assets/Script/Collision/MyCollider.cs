using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MyCollider : MonoBehaviour
{
	public struct Poligon
	{
		public List<Vector2> _Vertex;
	}

	static public bool CheckPointPolygon(Vector2 p, Poligon other)
	{
		int hitCount = 0;

		for (int i = 0; i < other._Vertex.Count; i++)
		{
			Vector2 first = other._Vertex[i];
			Vector2 second = other._Vertex[i + 1];

			// �����`�F�b�N
			if (first.y == second.y) continue;

			{	// y�͈̔͂ɓ����Ă��邩
				float y_bigger = (first.y > second.y) ? first.y : second.y;
				float y_smaller = (first.y < second.y) ? first.y : second.y;
				if (p.y < y_smaller || y_bigger <= p.y) continue;
			}

			// ��_���E�ɂ���Ȃ�v���X
			int t = (int)(((second.x - first.x) * (p.y - first.y))
				/ (second.y - first.y) - (p.x - first.x));
			if (t > 0){ hitCount++;
			}
		}

		return ((hitCount % 2) == 0) ? false: true;
	}
}
