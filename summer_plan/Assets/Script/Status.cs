using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Status",menuName = "ScriptableObject/StatusObject")]
public class Status : ScriptableObject
{
	public int _Hp;
	public int _Atk;
	public float _MoveSpeed;

	public bool _isSwoon;
}
