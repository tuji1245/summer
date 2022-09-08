using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStatus
{
	Vector2 _ThrustDir = new Vector2(0, 0);
	float _coef = 0;

	public Vector2 _Thrust{ get { return _ThrustDir * _coef; } }

	public BulletStatus(Vector2 thrustDir, float coef)
	{
		_ThrustDir = thrustDir;
		_coef = coef;
	}
}