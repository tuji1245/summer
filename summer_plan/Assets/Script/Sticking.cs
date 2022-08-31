using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticking : MonoBehaviour
{
	[SerializeField]
	GameObject _gameObject;

	[SerializeField]
	bool freezZ = true;

	private void Update()
	{
		Vector3 pos = transform.position;
		float z = pos.z;
		pos = _gameObject.transform.position;
		if (freezZ) { pos.z = z; }
		transform.position = pos;
	}
}
