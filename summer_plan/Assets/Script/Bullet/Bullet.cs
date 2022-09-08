using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public BulletStatus _bulletStatus;
	private int _endurance = 2;



	private void FixedUpdate()
	{
		Vector2 thrust = _bulletStatus._Thrust * Time.fixedDeltaTime;
		transform.position += new Vector3(thrust.x, thrust.y, 0.0f);
	}
}
